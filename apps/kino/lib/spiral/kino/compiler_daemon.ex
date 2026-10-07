defmodule Spiral.Kino.CompilerDaemon do
  use GenServer

  alias Spiral.Kino.{Runner, Toolchain}

  @default_port 13905
  @version "1"
  @idle_check_ms 60_000
  @default_idle_min 30

  # SPIRAL_KINO_COMPILER_IDLE_MIN: minutes without a compile before a serving daemon retires (default 30; 0 = never).
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

  @spec serve() :: no_return()
  def serve do
    listen = port()
    {:ok, _} = start_link(name: __MODULE__, port: listen, on_retire: fn -> System.stop(0) end)
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
    case :code.which(__MODULE__) do
      path when is_list(path) ->
        case File.stat(List.to_string(path), time: :posix) do
          {:ok, %{mtime: mtime}} -> mtime
          _ -> 0
        end

      _ ->
        0
    end
  end

  @impl true
  def init(opts) do
    Process.flag(:trap_exit, true)
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
        send(acceptor, :go)
        # A serving daemon (one with on_retire) retires after idle_ms without a compile, instead of holding its compiler
        # (GBs) forever: the next Kino run starts a fresh one. In-process servers (tests) never idle out.
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
           toolchain: Keyword.take(opts, [:dotnet, :compiler_dll, :workspace, :package_dir])
         }}

      {:error, reason} ->
        {:stop, reason}
    end
  end

  @impl true
  def handle_call(:port, _from, state), do: {:reply, state.listen_port, state}

  # The reply is `{:compiled, result, ms}`: `ms` is the time this compile held the compiler, so the client handler can
  # report `waited - ms` as queue time for every outcome (ok, error, timeout). Error and timeout replies used to carry no
  # queue time, so a cell whose first compile fails (the unit-result retry of every `_assert_eq` test cell) had its whole
  # wait behind the other cells charged to its own budget.
  def handle_call({:compile, req}, _from, state) do
    started = System.monotonic_time(:millisecond)

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

    # a cold compile (the first on a fresh compiler: it loads every package) is not the cell's own time: all of it is
    # reported as queue, so the cell's budget isn't spent on it
    ms = if Process.delete(:spiral_kino_cold), do: 0, else: System.monotonic_time(:millisecond) - started
    result = normalize(result)
    log_compile(req, ms, result)
    state = %{state | last_used: System.monotonic_time(:millisecond)}
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

  @retire_grace_ms 2_000

  defp retire_when_idle(reply) do
    state = elem(reply, tuple_size(reply) - 1)

    cond do
      state.retiring == false ->
        reply

      queued() > 0 or System.monotonic_time(:millisecond) - state.retiring < @retire_grace_ms ->
        Process.send_after(self(), :retire_check, 500)
        reply

      true ->
        IO.puts("retired; stopping")
        state = safe_stop_compiler(state)
        if is_function(state.on_retire, 0), do: state.on_retire.()

        case reply do
          {:reply, value, _} -> {:stop, :normal, value, state}
          {:noreply, _} -> {:stop, :normal, state}
        end
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
              # a rejected program still loaded the packages
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

  defp warm(%{compiler: %{} = compiler} = state), do: %{state | compiler: Map.put(compiler, :warm, true)}
  defp warm(state), do: state

  defp prepare_compiler(state, mtime) do
    case state.compiler do
      %{booted: booted} when mtime <= booted ->
        {:ok, state}

      nil ->
        start_compiler(state)

      _compiler ->
        start_compiler(stop_compiler(state))
    end
  end

  defp start_compiler(state) do
    dotnet = Toolchain.dotnet(state.toolchain)
    dll = Toolchain.compiler_dll(state.toolchain)
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
              booted: System.os_time(:second)
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

  # The first compile on a fresh compiler loads every package (minutes on a loaded machine): with the cell's budget as its
  # timeout it timed out, the timeout stopped the compiler, and the next compile was cold again (the 14:2x lib reruns:
  # every compile 'timeout 30xxxx ms'). A cold compile gets @cold_compile_ms at least.
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

          "retire" ->
            :gen_tcp.close(listen)
            send(server, :retire)
            :gen_tcp.send(sock, "retiring\n")
            :gen_tcp.close(sock)

          "compile\t" <> rest ->
            req = parse_request(rest)
            started = System.monotonic_time(:millisecond)

            reply =
              try do
                case GenServer.call(server, {:compile, req}, :infinity) do
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

  defp parse_request(rest) do
    [backend, input, output, timeout, mtime] = String.split(String.trim(rest), "\t")

    %{
      backend: backend,
      input: input,
      output: output,
      timeout: parse_timeout(timeout),
      mtime: String.to_integer(mtime)
    }
  end

  defp parse_timeout("-1"), do: :infinity
  defp parse_timeout(text), do: String.to_integer(text)

  # Replies: `ok\t<revision>\t<queue_ms>`, `error\ttimeout\t<queue_ms>`, `error\t<queue_ms>\t<message>`. The queue field
  # is left out only when the compile never reached the GenServer (the daemon went down).
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

  # One line per compile, whatever the outcome, with the wall-clock time it finished, so a cell's phases can be matched
  # with the daemon log (failed compiles, e.g. the unit-result first attempt of a test cell, used to be invisible).
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
    path = Path.expand(Path.join(System.tmp_dir!(), "spiral-kino-#{System.pid()}.sock"))

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
