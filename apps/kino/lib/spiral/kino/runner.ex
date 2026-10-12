defmodule Spiral.Kino.Runner do
  require Logger

  @type result :: %{
          exit_status: non_neg_integer(),
          output: binary(),
          os_pid: non_neg_integer() | nil,
          duration_ms: non_neg_integer()
        }

  @type error ::
          {:timeout, %{output: binary(), os_pid: non_neg_integer() | nil, timeout: timeout()}}
          | {:spawn_failed, term()}
          | {:runner_crashed, term()}

  @default_max_output 16 * 1024 * 1024
  @drain_after_kill_ms 5_000

  @spec run(String.t(), [String.t()], keyword()) :: {:ok, result()} | {:error, error()}
  def run(executable, args, opts \\ []) when is_binary(executable) and is_list(args) do
    opts =
      Keyword.validate!(opts,
        timeout: :infinity,
        cd: nil,
        env: [],
        max_output: @default_max_output,
        on_start: nil
      )

    caller = self()
    ref = make_ref()
    worker = fn -> watch(caller, ref, executable, args, opts) end
    {:ok, pid} = start_watcher(worker)
    mref = Process.monitor(pid)

    receive do
      {^ref, result} ->
        Process.demonitor(mref, [:flush])
        result

      {:DOWN, ^mref, :process, ^pid, reason} ->
        {:error, {:runner_crashed, reason}}
    end
  end

  defp start_watcher(fun) do
    case Process.whereis(Spiral.Kino.TaskSupervisor) do
      nil ->
        {:ok, spawn(fun)}

      _supervisor ->
        Task.Supervisor.start_child(Spiral.Kino.TaskSupervisor, fun, restart: :temporary)
    end
  end

  defp watch(caller, ref, executable, args, opts) do
    Process.flag(:trap_exit, true)
    caller_mref = Process.monitor(caller)

    case open_port(executable, args, opts) do
      {:ok, port} ->
        os_pid =
          case Port.info(port, :os_pid) do
            {:os_pid, os_pid} -> os_pid
            _ -> nil
          end

        if fun = opts[:on_start], do: fun.(os_pid)

        started = System.monotonic_time(:millisecond)

        deadline =
          case opts[:timeout] do
            :infinity -> :infinity
            ms when is_integer(ms) and ms >= 0 -> started + ms
          end

        state = %{
          caller: caller,
          caller_mref: caller_mref,
          ref: ref,
          port: port,
          os_pid: os_pid,
          started: started,
          deadline: deadline,
          timeout: opts[:timeout],
          max_output: opts[:max_output],
          out: [],
          out_size: 0
        }

        loop(state)

      {:error, reason} ->
        send(caller, {ref, {:error, {:spawn_failed, reason}}})
    end
  end

  defp open_port(executable, args, opts) do
    with {:ok, path} <- resolve_executable(executable) do
      port_opts =
        [
          :binary,
          :exit_status,
          :stderr_to_stdout,
          :use_stdio,
          :hide,
          args: args,
          env: Enum.map(opts[:env], &port_env/1)
        ] ++ if(opts[:cd], do: [cd: opts[:cd]], else: [])

      try do
        {:ok, Port.open({:spawn_executable, path}, port_opts)}
      rescue
        error -> {:error, error}
      end
    end
  end

  defp resolve_executable(executable) do
    cond do
      Path.type(executable) == :absolute and File.regular?(executable) -> {:ok, executable}
      path = System.find_executable(executable) -> {:ok, path}
      true -> {:error, {:executable_not_found, executable}}
    end
  end

  defp port_env({name, nil}), do: {to_charlist(name), false}
  defp port_env({name, value}), do: {to_charlist(name), to_charlist(value)}

  defp loop(%{port: port, caller_mref: caller_mref} = state) do
    receive do
      {^port, {:data, data}} ->
        loop(append(state, data))

      {^port, {:exit_status, status}} ->
        finish(state, {:ok, result(state, status)})

      {:DOWN, ^caller_mref, :process, _, _reason} ->
        kill_tree(state.os_pid)
        close_port(port)

      {:EXIT, ^port, _reason} ->
        loop(state)

      {:EXIT, _from, reason} ->
        kill_tree(state.os_pid)
        close_port(port)
        exit(reason)
    after
      remaining(state.deadline) ->
        kill_tree(state.os_pid)
        state = drain(state, System.monotonic_time(:millisecond) + @drain_after_kill_ms)
        close_port(port)

        error =
          {:timeout, %{output: output(state), os_pid: state.os_pid, timeout: state.timeout}}

        finish(state, {:error, error})
    end
  end

  defp drain(%{port: port} = state, until) do
    receive do
      {^port, {:data, data}} -> drain(append(state, data), until)
      {^port, {:exit_status, _}} -> state
    after
      max(until - System.monotonic_time(:millisecond), 0) -> state
    end
  end

  defp finish(state, result) do
    send(state.caller, {state.ref, result})
  end

  defp remaining(:infinity), do: :infinity

  defp remaining(deadline) do
    max(deadline - System.monotonic_time(:millisecond), 0)
  end

  defp append(state, data) do
    out = [data | state.out]
    size = state.out_size + byte_size(data)

    if size > state.max_output * 2 do
      bin = IO.iodata_to_binary(Enum.reverse(out))
      keep = binary_part(bin, byte_size(bin) - state.max_output, state.max_output)
      %{state | out: [keep], out_size: byte_size(keep)}
    else
      %{state | out: out, out_size: size}
    end
  end

  defp output(state) do
    bin = state.out |> Enum.reverse() |> IO.iodata_to_binary()

    if byte_size(bin) > state.max_output do
      binary_part(bin, byte_size(bin) - state.max_output, state.max_output)
    else
      bin
    end
  end

  defp result(state, status) do
    %{
      exit_status: status,
      output: output(state),
      os_pid: state.os_pid,
      duration_ms: System.monotonic_time(:millisecond) - state.started
    }
  end

  defp close_port(port) do
    Port.close(port)
  rescue
    ArgumentError -> :ok
  end

  @spec kill_tree(non_neg_integer() | nil) :: :ok
  def kill_tree(nil), do: :ok

  def kill_tree(os_pid) when is_integer(os_pid) do
    case :os.type() do
      {:win32, _} ->
        System.cmd("taskkill", ["/T", "/F", "/PID", Integer.to_string(os_pid)],
          stderr_to_stdout: true
        )

      {:unix, _} ->
        pids = [os_pid | descendants(os_pid)]

        System.cmd("kill", ["-KILL" | Enum.map(pids, &Integer.to_string/1)],
          stderr_to_stdout: true
        )
    end

    :ok
  rescue
    error ->
      Logger.warning("Spiral.Kino.Runner: failed to kill #{os_pid}: #{Exception.message(error)}")

      :ok
  end

  defp descendants(pid) do
    case System.cmd("pgrep", ["-P", Integer.to_string(pid)], stderr_to_stdout: true) do
      {out, 0} ->
        children =
          out
          |> String.split()
          |> Enum.flat_map(fn text ->
            case Integer.parse(text) do
              {n, ""} -> [n]
              _ -> []
            end
          end)

        children ++ Enum.flat_map(children, &descendants/1)

      _ ->
        []
    end
  end

  @spec os_pid_alive?(non_neg_integer()) :: boolean()
  def os_pid_alive?(os_pid) when is_integer(os_pid) do
    case :os.type() do
      {:win32, _} ->
        {out, _} =
          System.cmd("tasklist", ["/FI", "PID eq #{os_pid}", "/NH", "/FO", "CSV"],
            stderr_to_stdout: true
          )

        String.contains?(out, ~s("#{os_pid}"))

      {:unix, _} ->
        {_, status} =
          System.cmd("kill", ["-0", Integer.to_string(os_pid)], stderr_to_stdout: true)

        status == 0
    end
  end
end
