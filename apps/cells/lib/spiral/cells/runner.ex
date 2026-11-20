# TODO: KINO-WITHOUT-ELIXIR first strangler slice: runner.spi (watcher, caller monitor, deadline, drain, tail, tree kill) on lib
#     process/port Gleam arms, this module becomes a delegate, runner_test.exs stays the oracle until its cases move to ///> gleam blocks
defmodule Spiral.Cells.Runner do
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
    case Process.whereis(Spiral.Cells.TaskSupervisor) do
      nil ->
        {:ok, spawn(fun)}

      _supervisor ->
        Task.Supervisor.start_child(Spiral.Cells.TaskSupervisor, fun, restart: :temporary)
    end
  end

  defp watch(caller, ref, executable, args, opts) do
    Process.flag(:trap_exit, true)

    case open_port(executable, args, opts) do
      {:ok, port, capture} ->
        os_pid =
          case Port.info(port, :os_pid) do
            {:os_pid, os_pid} -> os_pid
            _ -> nil
          end

        if fun = opts[:on_start], do: fun.(os_pid)
        started = System.monotonic_time(:millisecond)
        timeout_ms = if opts[:timeout] == :infinity, do: -1, else: opts[:timeout]

        case Spiral.Cells.Domain.runner_loop(caller, port, os_pid, capture, started, timeout_ms, opts[:max_output]) do
          {:reply, result} -> send(caller, {ref, result})
          :caller_gone -> :ok
          {:exit, reason} -> exit(reason)
        end

      {:error, reason} ->
        send(caller, {ref, {:error, {:spawn_failed, reason}}})
    end
  end

  defp open_port(executable, args, opts) do
    with {:ok, path} <- resolve_executable(executable) do
      capture = capture_file(path, args)

      {spawn, spawn_args} =
        case capture do
          nil -> {{:spawn_executable, path}, [args: args]}
          file -> {{:spawn, captured_command_line(path, args, file)}, []}
        end

      port_opts =
        [:binary, :exit_status, :stderr_to_stdout, :use_stdio, :hide] ++
          spawn_args ++
          [env: Enum.map(opts[:env], &port_env/1)] ++
          if(opts[:cd], do: [cd: opts[:cd]], else: [])

      try do
        {:ok, Port.open(spawn, port_opts), capture}
      rescue
        error -> {:error, error}
      end
    end
  end


  @doc false
  @spec capture_file(String.t(), [String.t()]) :: String.t() | nil
  def capture_file(path, args) do
    file = Path.join(System.tmp_dir!(), "spiral-cells-run-#{System.pid()}-#{System.unique_integer([:positive])}.out")
    if Spiral.Cells.Domain.runner_capture_ok(path, file, args), do: file
  end

  @doc false
  @spec captured_command_line(String.t(), [String.t()], String.t()) :: String.t()
  def captured_command_line(path, args, file), do: Spiral.Cells.Domain.runner_command_line(path, args, file)

  defp resolve_executable(executable) do
    case Spiral.Cells.Domain.runner_resolve(executable) do
      "" -> {:error, {:executable_not_found, executable}}
      path -> {:ok, path}
    end
  end

  defp port_env({name, nil}), do: {to_charlist(name), false}
  defp port_env({name, value}), do: {to_charlist(name), to_charlist(value)}

  @spec kill_tree(non_neg_integer() | nil) :: :ok
  def kill_tree(nil), do: :ok

  def kill_tree(os_pid) when is_integer(os_pid), do: Spiral.Cells.Domain.runner_kill_tree(os_pid)

  @spec os_pid_alive?(non_neg_integer()) :: boolean()
  def os_pid_alive?(os_pid) when is_integer(os_pid), do: Spiral.Cells.Domain.pid_alive(Integer.to_string(os_pid))
end
