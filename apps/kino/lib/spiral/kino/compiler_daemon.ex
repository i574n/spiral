defmodule Spiral.Kino.CompilerDaemon do
  use GenServer

  alias Spiral.Kino.{Runner, Toolchain}

  @default_port 13905
  @version "1"
  @idle_check_ms 60_000
  @default_idle_min 30

  defp idle_ms do
    case Integer.parse(System.get_env("SPIRAL_KINO_COMPILER_IDLE_MIN") || "") do
      {0, ""} -> nil
      {min, ""} when min > 0 -> min * 60_000
      _ -> @default_idle_min * 60_000
    end
  end

  @spec port() :: 1..65535
  def port do
    case System.get_env("SPIRAL_KINO_COMPILER_PORT") do
      value when value in [nil, ""] ->
        @default_port

      text ->
        case Integer.parse(String.trim(text)) do
          {number, ""} when number in 1..65535 ->
            number

          _ ->
            raise ArgumentError,
                  "SPIRAL_KINO_COMPILER_PORT must be a TCP port, got: #{inspect(text)}"
        end
    end
  end

  @spec start_link(keyword()) :: GenServer.on_start()
  def start_link(opts \\ []) do
    name = Keyword.get(opts, :name)
    GenServer.start_link(__MODULE__, opts, name: name)
  end

  @spec serve_app() :: no_return()
  def serve_app do
    {:ok, _} = Application.ensure_all_started(:spiral_kino)
    serve()
  end

  @spec serve() :: no_return()
  def serve do
    listen = port()
    {:ok, _} = start_link(name: __MODULE__, port: listen, on_retire: fn -> System.stop(0) end, pool: System.get_env("SPIRAL_KINO_DAEMON_POOL") || "auto")
    IO.puts("spiral-kino-compiler listening port=#{listen} pid=#{System.pid()}")
    Process.sleep(:infinity)
  end

  @spec listen_port(GenServer.server()) :: non_neg_integer()
  def listen_port(server), do: GenServer.call(server, :port)

  @spec code_stamp() :: non_neg_integer()
  def code_stamp, do: boot_stamp()

  @spec banner() :: String.t()
  def banner, do: "spiral-kino\t#{@version}\t#{System.pid()}\t#{boot_stamp()}"

  defp boot_stamp do
    case :persistent_term.get({__MODULE__, :boot_stamp}, :unset) do
      :unset ->
        stamp = read_stamp()
        :persistent_term.put({__MODULE__, :boot_stamp}, stamp)
        stamp

      stamp ->
        stamp
    end
  end

  defp read_stamp do
    __MODULE__.module_info(:md5) |> binary_part(0, 6) |> :binary.decode_unsigned()
  end

  @impl true
  def init(opts) do
    Process.flag(:trap_exit, true)
    :persistent_term.put({__MODULE__, :source_stamp}, source_stamp())
    if opts[:worker], do: {:ok, worker_state(opts)}, else: listen_init(opts)
  end

  defp worker_state(opts) do
    %{
      listen_port: nil,
      listen: nil,
      acceptor: nil,
      retiring: false,
      idle_ms: nil,
      idle_check_ms: @idle_check_ms,
      last_used: System.monotonic_time(:millisecond),
      on_retire: nil,
      compile: opts[:compile],
      compiler: nil,
      log: "",
      toolchain: Keyword.take(opts, [:dotnet, :compiler_dll, :workspace, :package_dir]),
      limits: Keyword.get(opts, :limits) || limits()
    }
  end

  defp listen_init(opts) do
    port = Keyword.get(opts, :port, port())

    case :gen_tcp.listen(port, listen_opts()) do
      {:ok, listen} ->
        {:ok, actual} = :inet.port(listen)
        server = self()

        acceptor =
          spawn_link(fn ->
            receive do
              :go -> accept_loop(listen, server)
            end
          end)

        :ok = :gen_tcp.controlling_process(listen, acceptor)
        start_pool(server, opts)
        send(acceptor, :go)
        idle_ms = if opts[:on_retire], do: Keyword.get(opts, :idle_ms, idle_ms()), else: nil
        idle_check_ms = Keyword.get(opts, :idle_check_ms, @idle_check_ms)
        if idle_ms, do: Process.send_after(self(), :idle_check, idle_check_ms)

        {:ok,
         %{
           listen_port: actual,
           listen: listen,
           acceptor: acceptor,
           retiring: false,
           idle_ms: idle_ms,
           idle_check_ms: idle_check_ms,
           last_used: System.monotonic_time(:millisecond),
           on_retire: opts[:on_retire],
           compile: opts[:compile],
           compiler: nil,
           log: "",
           toolchain: Keyword.take(opts, [:dotnet, :compiler_dll, :workspace, :package_dir]),
           limits: pool_limits(opts, Spiral.Kino.CompilerPool.settings(opts[:pool]).max_workers)
         }}

      {:error, reason} ->
        {:stop, reason}
    end
  end

  @impl true
  def handle_call(:port, _from, state), do: {:reply, state.listen_port, state}

  def handle_call({:compile, req}, _from, state) do
    started = System.monotonic_time(:millisecond)
    IO.puts("#{clock()} started #{Map.get(req, :client, "anonymous")} #{Path.basename(req.input)} #{req.input}")

    {result, state} =
      try do
        dispatch_compile(req, state)
      rescue
        error ->
          message = Exception.message(error)
          IO.puts("compile failed: #{message}")
          {{:error, message}, safe_stop_compiler(state)}
      catch
        kind, reason ->
          message = "compiler failed: #{Exception.format_banner(kind, reason)}"
          IO.puts("compile failed: #{message}")
          {{:error, message}, safe_stop_compiler(state)}
      end

    ms = if Process.delete(:spiral_kino_cold), do: 0, else: System.monotonic_time(:millisecond) - started
    result = normalize(result)
    log_compile(req, ms, result)
    state = recycle_heavy(%{state | last_used: System.monotonic_time(:millisecond)})
    retire_when_idle({:reply, {:compiled, result, ms}, state})
  end

  @impl true
  def handle_info(:idle_check, %{retiring: false, idle_ms: idle_ms} = state) when is_integer(idle_ms) do
    idle = System.monotonic_time(:millisecond) - state.last_used

    if idle >= idle_ms and queued() == 0 do
      IO.puts("#{clock()} idle for #{div(idle, 60_000)} min; retiring")
      handle_info(:retire, state)
    else
      Process.send_after(self(), :idle_check, state.idle_check_ms)
      {:noreply, state}
    end
  end

  def handle_info(:idle_check, state), do: {:noreply, state}

  @impl true
  def handle_info(:retire, state) do
    IO.puts("retire requested; the port is closed and the queue is drained")

    retire_when_idle(
      {:noreply, %{state | retiring: state.retiring || System.monotonic_time(:millisecond)}}
    )
  end

  def handle_info(:retire_check, state), do: retire_when_idle({:noreply, state})

  def handle_info({:EXIT, pid, reason}, %{acceptor: pid} = state) do
    if reason == :normal do
      {:noreply, state}
    else
      IO.puts("acceptor exited: #{inspect(reason)}")
      {:stop, {:acceptor, reason}, state}
    end
  end

  def handle_info({:EXIT, from, reason}, state) do
    if reason not in [:normal, :shutdown] do
      IO.puts("linked #{inspect(from)} exited: #{inspect(reason)}")
    end

    {:noreply, state}
  end

  def handle_info({:log, data}, state) do
    log = state.log <> data

    log =
      if byte_size(log) > 8_000, do: binary_part(log, byte_size(log) - 4_000, 4_000), else: log

    {:noreply, %{state | log: log}}
  end

  def handle_info({:compiler_exit, token, _status}, %{compiler: %{token: token}} = state) do
    {:noreply, %{state | compiler: nil}}
  end

  def handle_info({:compiler_exit, _token, _status}, state), do: {:noreply, state}

  def handle_info(_message, state), do: {:noreply, state}

  @impl true
  def terminate(_reason, state) do
    safe_stop_compiler(state)
    :ok
  end

  @default_max_mb 2_500

  @spec limits() :: %{max_mb: non_neg_integer(), max_compiles: non_neg_integer()}
  def limits do
    %{
      max_mb: env_count("SPIRAL_KINO_DAEMON_MAX_MB", @default_max_mb),
      max_compiles: env_count("SPIRAL_KINO_DAEMON_MAX_COMPILES", 0)
    }
  end

  defp env_count(name, default) do
    case Integer.parse(System.get_env(name) || "") do
      {n, ""} when n >= 0 -> n
      _ -> default
    end
  end

  @doc false
  def recycle_reason(compiles, mb, %{max_mb: max_mb, max_compiles: max_compiles}) do
    cond do
      max_compiles > 0 and compiles >= max_compiles -> "#{compiles} compiles"
      max_mb > 0 and is_integer(mb) and mb >= max_mb -> "reaching #{mb} MB"
      true -> nil
    end
  end

  defp recycle_heavy(%{compiler: %{} = compiler, limits: limits} = state) do
    mb = if limits.max_mb > 0, do: compiler_mb(compiler), else: nil

    case recycle_reason(Map.get(compiler, :compiles, 0), mb, limits) do
      nil ->
        state

      reason ->
        IO.puts("#{clock()} compiler recycled after #{reason}; the next compile starts a fresh one")
        stop_compiler(state)
    end
  end

  defp recycle_heavy(state), do: state

  defp compiler_mb(compiler) do
    with {:ok, text} <- File.read(compiler.socket <> ".pid"),
         {pid, ""} <- Integer.parse(String.trim(text)) do
      task = Task.async(fn -> working_set_mb(pid) end)

      case Task.yield(task, 5_000) || Task.shutdown(task, :brutal_kill) do
        {:ok, mb} -> mb
        _ -> nil
      end
    else
      _ -> nil
    end
  end

  @doc false
  def working_set_mb(os_pid) when is_integer(os_pid) do
    case :os.type() do
      {:win32, _} ->
        case System.cmd("tasklist", ["/FI", "PID eq #{os_pid}", "/FO", "CSV", "/NH"], stderr_to_stdout: true) do
          {out, 0} ->
            case Regex.run(~r/"#{os_pid}".*,"([^"]+)"\s*$/m, out) do
              [_, memory] ->
                case Integer.parse(String.replace(memory, ~r/\D/, "")) do
                  {kb, ""} -> div(kb, 1024)
                  _ -> nil
                end

              _ ->
                nil
            end

          _ ->
            nil
        end

      _ ->
        case File.read("/proc/#{os_pid}/status") do
          {:ok, status} ->
            case Regex.run(~r/^VmRSS:\s+(\d+)\s+kB/m, status) do
              [_, kb] -> div(String.to_integer(kb), 1024)
              _ -> nil
            end

          _ ->
            nil
        end
    end
  rescue
    _ -> nil
  end

  @retire_grace_ms 2_000

  defp retire_when_idle(reply) do
    state = elem(reply, tuple_size(reply) - 1)

    cond do
      state.retiring == false ->
        reply

      queued() > 0 or pool_busy?() or System.monotonic_time(:millisecond) - state.retiring < @retire_grace_ms ->
        Process.send_after(self(), :retire_check, 500)
        reply

      true ->
        IO.puts("retired; stopping")
        stop_pool_workers()
        state = safe_stop_compiler(state)
        if is_function(state.on_retire, 0), do: state.on_retire.()

        case reply do
          {:reply, value, _} -> {:stop, :normal, value, state}
          {:noreply, _} -> {:stop, :normal, state}
        end
    end
  end

  defp pool_busy? do
    case :persistent_term.get({__MODULE__, :pool, self()}, nil) do
      nil -> false
      pool -> match?(%{queued: q, idle: i, workers: w} when q > 0 or i < w, Spiral.Kino.CompilerPool.stats(pool))
    end
  end

  defp stop_pool_workers do
    case :persistent_term.get({__MODULE__, :pool, self()}, nil) do
      nil -> :ok
      pool -> pool |> Spiral.Kino.CompilerPool.stats() |> Map.get(:extra_workers, []) |> Enum.each(&GenServer.stop(&1, :normal, 30_000))
    end
  end

  defp queued do
    case Process.info(self(), :messages) do
      {:messages, messages} ->
        Enum.count(messages, &match?({:"$gen_call", _from, {:compile, _req}}, &1))

      _ ->
        0
    end
  end

  defp safe_stop_compiler(state) do
    stop_compiler(state)
  rescue
    error ->
      IO.puts("stop_compiler failed: #{Exception.message(error)}")
      %{state | compiler: nil}
  end

  defp dispatch_compile(req, %{compile: fun} = state) when is_function(fun, 1) do
    {fun.(req), state}
  end

  defp dispatch_compile(req, state), do: real_compile(state, req)

  defp normalize({:ok, revision, _ms}), do: {:ok, revision}
  defp normalize({:ok, _revision} = result), do: result
  defp normalize({:error, :timeout} = result), do: result
  defp normalize({:error, message} = result) when is_binary(message), do: result
  defp normalize(other), do: {:error, "unexpected compile result: #{inspect(other)}"}

  defp real_compile(state, req) do
    case prepare_compiler(state, req.mtime) do
      {:ok, state} ->
        case session(state, req) do
          {:ok, _revision} = reply ->
            {reply, warm(state)}

          {:error, :timeout} = reply ->
            {reply, stop_compiler(state)}

          {:error, message} = reply ->
            if session_lost?(message) do
              IO.puts(
                "compiler session lost (#{message}); restarting the compiler and retrying once"
              )

              retry_compile(stop_compiler(state), req)
            else
              {reply, warm(state)}
            end
        end

      {:error, message, state} ->
        {{:error, message <> compiler_log(state)}, state}
    end
  end

  defp retry_compile(state, req) do
    case start_compiler(state) do
      {:ok, state} ->
        case session(state, req) do
          {:ok, _revision} = reply ->
            {reply, warm(state)}

          {:error, :timeout} = reply ->
            {reply, stop_compiler(state)}

          reply ->
            {reply, stop_compiler(state)}
        end

      {:error, message, state} ->
        {{:error, message}, state}
    end
  end

  defp warm(%{compiler: %{} = compiler} = state) do
    %{state | compiler: compiler |> Map.put(:warm, true) |> Map.update(:compiles, 1, &(&1 + 1))}
  end
  defp warm(state), do: state

  defp prepare_compiler(state, mtime) do
    case state.compiler do
      %{booted: booted} = compiler when mtime <= booted ->
        if compiler_current?(compiler, dll_stamp(Toolchain.compiler_dll(state.toolchain))),
          do: {:ok, state},
          else: start_compiler(stop_compiler(state))

      nil ->
        start_compiler(state)

      _compiler ->
        start_compiler(stop_compiler(state))
    end
  end

  defp start_compiler(state) do
    dotnet = Toolchain.dotnet(state.toolchain)
    source_dll = Toolchain.compiler_dll(state.toolchain)
    dll = shadow_dll(source_dll)
    pwsh = pwsh_exe()
    script = bridge_script()
    socket = socket_path()
    bridge = socket <> ".bridge"

    cond do
      not is_binary(dotnet) ->
        {:error, "dotnet was not found", state}

      not File.regular?(dll) ->
        {:error, "Spiral compiler was not found at #{dll}", state}

      not is_binary(pwsh) ->
        {:error, "pwsh was not found", state}

      not File.regular?(script) ->
        {:error, "compiler bridge was not found at #{script}", state}

      true ->
        File.rm(bridge)

        port =
          Port.open({:spawn_executable, pwsh}, [
            :binary,
            :exit_status,
            :hide,
            :stderr_to_stdout,
            args: [
              "-NoProfile",
              "-ExecutionPolicy",
              "Bypass",
              "-File",
              script,
              "-Dotnet",
              dotnet,
              "-Dll",
              dll,
              "-Socket",
              socket,
              "-WorkDir",
              Toolchain.workspace(state.toolchain),
              "-BridgeFile",
              bridge
            ],
            cd: Toolchain.workspace(state.toolchain),
            env: port_env(state.toolchain, dotnet)
          ])

        os_pid =
          case Port.info(port, :os_pid) do
            {:os_pid, pid} -> pid
            _ -> nil
          end

        server = self()
        token = make_ref()
        drainer = spawn_link(fn -> drain(port, server, token) end)
        _ = Port.connect(port, drainer)

        case await_bridge(port, bridge, 30_000) do
          {:ok, bridge_port} ->
            compiler = %{
              port: port,
              socket: socket,
              bridge: bridge,
              bridge_port: bridge_port,
              os_pid: os_pid,
              token: token,
              booted: System.os_time(:second),
              dll_stamp: dll_stamp(source_dll)
            }

            {:ok, %{state | compiler: compiler}}

          {:error, reason} ->
            if os_pid, do: Runner.kill_tree(os_pid)
            if Port.info(port), do: Port.close(port)
            state = take_log(state)
            {:error, "Spiral compiler did not open #{socket}: #{inspect(reason)}", state}
        end
    end
  end

  @doc false
  def dll_stamp(dll) do
    case File.stat(dll, time: :posix) do
      {:ok, %{mtime: mtime, size: size}} -> {mtime, size}
      _ -> nil
    end
  end

  @doc false
  def compiler_current?(compiler, source_stamp), do: Map.get(compiler, :dll_stamp) == source_stamp

  defp shadow_root, do: Path.join(System.tmp_dir!(), "spiral-kino-compiler")

  @doc false
  def shadow_dll(dll, root \\ shadow_root()) do
    case dll_stamp(dll) do
      nil ->
        dll

      {mtime, size} ->
        dir = Path.join(root, "#{mtime}-#{size}")
        target = Path.join(dir, Path.basename(dll))

        unless File.regular?(Path.join(dir, ".complete")) do
          copy_shadow(dll, root, dir, {mtime, size})
        end

        if File.regular?(Path.join(dir, ".complete")) do
          prune_shadows(root, dir)
          target
        else
          dll
        end
    end
  rescue
    _ -> dll
  end

  defp copy_shadow(dll, root, dir, stamp) do
    staging = dir <> ".#{System.unique_integer([:positive])}"
    _ = File.mkdir_p(root)

    with {:ok, _} <- File.cp_r(Path.dirname(dll), staging),
         true <- dll_stamp(dll) == stamp,
         :ok <- File.write(Path.join(staging, ".complete"), ""),
         :ok <- File.rename(staging, dir) do
      :ok
    else
      _ -> File.rm_rf(staging)
    end
  rescue
    _ -> :error
  end

  defp prune_shadows(root, keep) do
    for old <- Path.wildcard(Path.join(String.replace(root, "\\", "/"), "*")),
        Path.basename(old) != Path.basename(keep),
        Regex.match?(~r/^\d+-\d+$/, Path.basename(old)) do
      trash = old <> ".trash#{System.unique_integer([:positive])}"
      if File.rename(old, trash) == :ok, do: File.rm_rf(trash)
    end

    :ok
  end

  @cold_compile_ms 1_200_000
  defp session(state, req) do
    cold = not Map.get(state.compiler, :warm, false)
    if cold, do: Process.put(:spiral_kino_cold, true)
    timeout = if req.timeout == :infinity, do: :infinity, else: max(req.timeout, 0)
    timeout = if cold and timeout != :infinity, do: max(timeout, @cold_compile_ms), else: timeout

    case :gen_tcp.connect({127, 0, 0, 1}, state.compiler.bridge_port, socket_opts(), 5_000) do
      {:ok, sock} ->
        :gen_tcp.send(sock, "compile\t#{req.backend}\t#{req.input}\t#{req.output}\n")

        result =
          case :gen_tcp.recv(sock, 0, timeout) do
            {:ok, line} ->
              parse_session(line)

            {:error, :timeout} ->
              {:error, :timeout}

            {:error, reason} ->
              IO.puts("compiler bridge closed: #{inspect(reason)} #{bridge_trace(state)}")
              {:error, "compiler socket failed: #{inspect(reason)}"}
          end

        :gen_tcp.close(sock)
        result

      {:error, reason} ->
        {:error, "compiler socket failed: #{inspect(reason)}"}
    end
  end

  defp parse_session(line) do
    case String.split(String.trim(line), "\t") do
      ["spiral-session", "ok", _pid, _bytes, _binding, revision | _] ->
        {:ok, revision}

      ["spiral-session", "error", _pid | rest] ->
        {:error, Enum.join(rest, " ")}

      parts ->
        {:error, Enum.join(parts, " ")}
    end
  end

  defp stop_compiler(%{compiler: nil} = state), do: state

  defp stop_compiler(%{compiler: compiler} = state) do
    kill_pidfile(compiler.socket <> ".pid")
    if compiler.os_pid, do: Runner.kill_tree(compiler.os_pid)
    close_port(compiler.port)
    File.rm(compiler.socket)
    File.rm(compiler.socket <> ".pid")
    if compiler[:bridge], do: File.rm(compiler.bridge)
    %{state | compiler: nil}
  end

  defp close_port(port) do
    if Port.info(port), do: Port.close(port)
    :ok
  rescue
    ArgumentError -> :ok
  end

  defp bridge_trace(%{compiler: %{socket: socket}}) do
    case File.read(socket <> ".trace") do
      {:ok, text} ->
        text = String.trim(text)
        if text == "", do: "", else: "\n" <> String.slice(text, -800, 800)

      _ ->
        ""
    end
  end

  defp bridge_trace(_state), do: ""

  defp kill_pidfile(path) do
    case File.read(path) do
      {:ok, text} ->
        case Integer.parse(String.trim(text)) do
          {pid, ""} -> Runner.kill_tree(pid)
          _ -> :ok
        end

      _ ->
        :ok
    end
  end

  defp await_bridge(port, bridge, left) do
    cond do
      File.regular?(bridge) ->
        case File.read(bridge) do
          {:ok, text} ->
            case Integer.parse(String.trim(String.trim_leading(text, "\uFEFF"))) do
              {number, ""} ->
                {:ok, number}

              _ when left <= 0 ->
                {:error, :bridge_port}

              _ ->
                Process.sleep(50)
                await_bridge(port, bridge, left - 50)
            end

          _ when left <= 0 ->
            {:error, :timeout}

          _ ->
            Process.sleep(50)
            await_bridge(port, bridge, left - 50)
        end

      left <= 0 ->
        {:error, :timeout}

      is_nil(Port.info(port)) ->
        {:error, :exited}

      true ->
        Process.sleep(50)
        await_bridge(port, bridge, left - 50)
    end
  end

  defp take_log(state) do
    receive do
      {:log, data} -> take_log(%{state | log: state.log <> data})
    after
      200 -> state
    end
  end

  defp drain(port, server, token) do
    receive do
      {^port, {:data, data}} ->
        send(server, {:log, data})
        drain(port, server, token)

      {^port, :connected} ->
        drain(port, server, token)

      {^port, {:exit_status, status}} ->
        send(server, {:compiler_exit, token, status})
    end
  end

  defp accept_loop(listen, server) do
    case :gen_tcp.accept(listen) do
      {:ok, sock} ->
        handler =
          spawn(fn ->
            receive do
              :go -> handle(sock, server, listen)
            end
          end)

        case :gen_tcp.controlling_process(sock, handler) do
          :ok ->
            send(handler, :go)

          {:error, reason} ->
            IO.puts("could not hand a client socket over: #{inspect(reason)}")
            Process.exit(handler, :kill)
            :gen_tcp.close(sock)
        end

        accept_loop(listen, server)

      {:error, :closed} ->
        :ok

      {:error, _reason} ->
        accept_loop(listen, server)
    end
  end

  defp handle(sock, server, listen) do
    case :gen_tcp.recv(sock, 0, 60_000) do
      {:ok, line} ->
        case String.trim(line) do
          "hello" ->
            :gen_tcp.send(sock, banner() <> "\n")
            handle(sock, server, listen)

          "notebook\t" <> request ->
            {lines, after_reply} = notebook_reply(request)
            Enum.each(lines, &:gen_tcp.send(sock, &1 <> "\n"))
            :gen_tcp.close(sock)

            if after_reply == :retire do
              :gen_tcp.close(listen)
              send(server, :retire)
            end

          "retire" ->
            :gen_tcp.close(listen)
            send(server, :retire)
            :gen_tcp.send(sock, "retiring\n")
            :gen_tcp.close(sock)

          "compile\t" <> rest ->
            req = parse_request(rest)
            started = System.monotonic_time(:millisecond)
            IO.puts("#{clock()} received #{req.client} #{Path.basename(req.input)} #{req.input}")

            reply =
              try do
                case compile_call(server, req) do
                  {:compiled, result, compile_ms} ->
                    encode(
                      result,
                      max(System.monotonic_time(:millisecond) - started - compile_ms, 0)
                    )

                  result ->
                    encode(result, nil)
                end
              catch
                :exit, reason ->
                  encode({:error, "compiler connection failed: #{inspect(reason)}"}, nil)
              end

            :gen_tcp.send(sock, reply <> "\n")
            :gen_tcp.close(sock)

          _ ->
            :gen_tcp.close(sock)
        end

      _ ->
        :gen_tcp.close(sock)
    end
  end

  defp start_pool(server, opts) do
    settings = Spiral.Kino.CompilerPool.settings(opts[:pool])

    if settings.max_workers > 1 or settings.fair_single do
      toolchain = Keyword.take(opts, [:dotnet, :compiler_dll, :workspace, :package_dir, :compile])

      {:ok, pool} =
        Spiral.Kino.CompilerPool.start_link(
          first: server,
          max_workers: settings.max_workers,
          fair: settings.fair,
          start_worker: Spiral.Kino.CompilerPool.worker_starter(toolchain, pool_limits(opts, settings.max_workers))
        )

      :persistent_term.put({__MODULE__, :pool, server}, pool)
      IO.puts("compiler pool: up to #{settings.max_workers} compiler(s), #{if settings.fair, do: "fair per client", else: "first come first served"}")
    end
  end

  defp pool_limits(opts, workers) do
    base = Keyword.get(opts, :limits) || limits()
    if workers > 1, do: %{base | max_mb: max(div(base.max_mb, workers), 1_200)}, else: base
  end

  defp compile_call(server, req) do
    case :persistent_term.get({__MODULE__, :pool, server}, nil) do
      nil -> GenServer.call(server, {:compile, req}, :infinity)
      pool -> Spiral.Kino.CompilerPool.compile(pool, req.client, req)
    end
  end

  @kino_root Path.expand("../../..", __DIR__)

  @doc false
  def source_stamp do
    ["lib/**/*.ex", "spi/*.spi", "spi/*.ex", "mix.exs", "priv/**/*"]
    |> Enum.flat_map(&Path.wildcard(Path.join(@kino_root, &1)))
    |> Enum.map(fn path ->
      case File.stat(path, time: :posix) do
        {:ok, %{mtime: mtime}} -> mtime
        _ -> 0
      end
    end)
    |> Enum.max(fn -> 0 end)
  end

  @doc false
  def stale_code do
    modified = Enum.filter(:code.modified_modules(), &kino_module?/1)
    booted = :persistent_term.get({__MODULE__, :source_stamp}, nil)

    cond do
      modified != [] -> "reloaded beams: #{inspect(modified)}"
      booted == nil -> nil
      source_stamp() > booted -> "Kino sources changed since the daemon started"
      true -> nil
    end
  end

  defp kino_module?(module) do
    name = Atom.to_string(module)
    String.starts_with?(name, "Elixir.Spiral.Kino") or String.starts_with?(name, "spiral_kino@")
  end

  @doc false
  def notebook_reply(request) do
    with {:ok, %{"args" => args, "root" => root}} when is_list(args) and is_binary(root) <- JSON.decode(request),
         true <- Enum.all?(args, &is_binary/1) do
      cond do
        same_root(root) != same_root(@kino_root) -> {["stale\tthe daemon serves another Kino checkout: #{@kino_root}"], :keep}
        reason = stale_code() -> {["stale\t" <> reason <> "; retiring"], :retire}
        true -> {run_notebook(args), :keep}
      end
    else
      _ -> {["error\t" <> JSON.encode!("notebook request is not {\"args\": [...], \"root\": ...}"), "end\t1"], :keep}
    end
  end

  defp same_root(path) do
    expanded = path |> Path.expand() |> String.trim_trailing("/")
    if match?({:win32, _}, :os.type()), do: String.downcase(expanded), else: expanded
  end

  defp run_notebook(args) do
    Spiral.Kino.Domain.ensure!()
    {status, lines} = Spiral.Kino.NotebookCli.execute(args)
    shown = Enum.map(lines, &("line\t" <> &1))

    case status do
      :ok -> shown ++ ["end\t0"]
      {:error, message} -> shown ++ ["error\t" <> JSON.encode!(message), "end\t1"]
    end
  rescue
    error -> ["error\t" <> JSON.encode!(Exception.message(error)), "end\t1"]
  end

  defp parse_request(rest) do
    [backend, input, output, timeout, mtime | client] = String.split(String.trim(rest), "\t")

    %{
      backend: backend,
      input: input,
      output: output,
      timeout: parse_timeout(timeout),
      mtime: String.to_integer(mtime),
      client: List.first(client) || "anonymous"
    }
  end

  defp parse_timeout("-1"), do: :infinity
  defp parse_timeout(text), do: String.to_integer(text)

  defp encode({:ok, revision}, nil), do: "ok\t#{revision}"
  defp encode({:ok, revision}, queue), do: "ok\t#{revision}\t#{queue}"
  defp encode({:error, :timeout}, nil), do: "error\ttimeout"
  defp encode({:error, :timeout}, queue), do: "error\ttimeout\t#{queue}"

  defp encode({:error, message}, queue) when is_binary(message) do
    message = String.replace(message, ~r/[\r\n\t]+/, " ")
    if queue, do: "error\t#{queue}\t" <> message, else: "error\t" <> message
  end

  defp encode(other, queue),
    do: encode({:error, "unexpected compile result: #{inspect(other)}"}, queue)

  defp session_lost?(message) do
    String.contains?(message, "compiler socket") or String.contains?(message, "bridge ") or
      String.contains?(message, "closed the socket")
  end

  defp compiler_log(%{log: ""}), do: ""
  defp compiler_log(%{log: log}), do: "\n" <> String.trim(log)

  defp log_compile(req, ms, result) do
    outcome =
      case result do
        {:ok, revision} -> revision
        {:error, :timeout} -> "timeout"
        {:error, _message} -> "error"
      end

    IO.puts("#{clock()} compile #{outcome} #{ms}ms #{Path.basename(req.input)} #{req.input}")
  end

  defp clock do
    {{_, _, _}, {h, m, s}} = :calendar.local_time()
    :io_lib.format("~2..0B:~2..0B:~2..0B", [h, m, s]) |> IO.iodata_to_binary()
  end

  defp socket_path do
    path = Path.expand(Path.join(System.tmp_dir!(), "spiral-kino-#{System.pid()}-#{System.unique_integer([:positive])}.sock"))

    case :os.type() do
      {:win32, _} -> String.replace(path, "/", "\\")
      _ -> path
    end
  end

  defp bridge_script, do: Application.app_dir(:spiral_kino, "priv/compiler_bridge.ps1")

  defp pwsh_exe do
    cond do
      path = System.find_executable("pwsh") ->
        path

      path = System.find_executable("pwsh.exe") ->
        path

      true ->
        scoop = System.get_env("SCOOP") || Path.join(System.user_home!(), "scoop")
        candidate = Path.join(scoop, "apps/pwsh/current/pwsh.exe")
        if File.regular?(candidate), do: candidate, else: nil
    end
  end

  defp port_env(opts, dotnet) do
    System.get_env()
    |> Map.merge(%{
      "DOTNET_ROOT" => Path.dirname(dotnet),
      "DOTNET_NOLOGO" => "1",
      "DOTNET_CLI_TELEMETRY_OPTOUT" => "1",
      "SPIRAL_WORKSPACE_ROOT" => Toolchain.workspace(opts),
      "SPIRAL_COMPILER_PACKAGE_DIR" => Toolchain.package_dir(opts),
      "SPIRAL_ATTENTION_SERVER" => "0"
    })
    |> Enum.map(fn {key, value} ->
      {String.to_charlist(key), String.to_charlist(to_string(value))}
    end)
  end

  defp listen_opts do
    [
      :binary,
      packet: :line,
      active: false,
      ip: {127, 0, 0, 1},
      reuseaddr: true,
      backlog: 128,
      packet_size: 8_000_000
    ]
  end

  defp socket_opts do
    [:binary, packet: :line, active: false, packet_size: 8_000_000]
  end
end
