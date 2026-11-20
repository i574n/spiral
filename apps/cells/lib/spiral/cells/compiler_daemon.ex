defmodule Spiral.Cells.CompilerDaemon do
  use GenServer
  require Logger

  alias Spiral.Cells.{Domain, Runner}

  @default_port 13905
  @version "1"
  @idle_check_ms 60_000
  @default_idle_min 30

  @default_retire_free_mb 4096

  defp idle_ms do
    case Spiral.Cells.Domain.idle_window(System.get_env("SPIRAL_CELLS_COMPILER_IDLE_MIN") || "", @default_idle_min) do
      "" -> nil
      ms -> String.to_integer(ms)
    end
  end

  defp retire_free_mb, do: env_count("SPIRAL_CELLS_COMPILER_RETIRE_FREE_MB", @default_retire_free_mb)

  @memory_reading_timeout_ms 2_000

  defp system_memory_data do
    task = Task.async(fn -> :memsup.get_system_memory_data() end)

    case Task.yield(task, @memory_reading_timeout_ms) || Task.shutdown(task, :brutal_kill) do
      {:ok, data} -> data
      _ -> nil
    end
  end

  defp free_memory_mb do
    with {:ok, _} <- Application.ensure_all_started(:os_mon),
         data when is_list(data) <- system_memory_data(),
         bytes when is_integer(bytes) <- Keyword.get(data, :available_memory) || Keyword.get(data, :free_memory) do
      div(bytes, 1_048_576)
    else
      _ -> nil
    end
  catch
    _, _ -> nil
  end

  defp pressure_idle_ms, do: Spiral.Cells.Domain.pressure_window(System.get_env("SPIRAL_CELLS_COMPILER_PRESSURE_IDLE_MIN") || "")

  defp memory_pressed?, do: Spiral.Cells.Domain.memory_pressed(to_string(free_memory_mb() || ""), retire_free_mb())

  @spec port() :: 1..65535
  def port do
    case System.get_env("SPIRAL_CELLS_COMPILER_PORT") do
      value when value in [nil, ""] ->
        build_port(Domain.tool("compiler_dll", []))

      text ->
        case Integer.parse(String.trim(text)) do
          {number, ""} when number in 1..65535 ->
            number

          _ ->
            raise ArgumentError,
                  "SPIRAL_CELLS_COMPILER_PORT must be a TCP port, got: #{inspect(text)}"
        end
    end
  end

  @build_slots 12
  @build_stride 8

  @doc """
  The default port for the compiler at `dll`: #{@default_port} plus #{@build_stride} times a slot (0..#{@build_slots - 1})
  hashed from the DLL's path, its stamp (dll_stamp: the DLL and its sibling SpiralCompilerCore.dll) and this Cells
  checkout's root, so a reinstall, a core-only swap, a second compiler build or another checkout (a node mirror) gets
  its own daemon instead of meeting another's on a shared port. A missing DLL maps to the base port.
  """
  @spec build_port(String.t(), String.t()) :: 1..65535
  def build_port(dll, cells_root \\ Path.expand("../../..", __DIR__)) do
    case dll_stamp(dll) do
      {mtime, stamp} ->
        @default_port + @build_stride * :erlang.phash2({Path.expand(dll), stamp, mtime, Path.expand(cells_root)}, @build_slots)

      nil ->
        @default_port
    end
  end

  @spec start_link(keyword()) :: GenServer.on_start()
  def start_link(opts \\ []) do
    name = Keyword.get(opts, :name)
    GenServer.start_link(__MODULE__, opts, name: name)
  end

  @spec serve_app() :: no_return()
  def serve_app do
    {:ok, _} = Application.ensure_all_started(:spiral_cells)
    serve()
  end

  @spec serve() :: no_return()
  def serve do
    listen = port()
    {:ok, _} = start_link(name: __MODULE__, port: listen, on_retire: fn -> System.stop(0) end, pool: System.get_env("SPIRAL_CELLS_DAEMON_POOL") || "auto")
    IO.puts("spiral-cells-compiler listening port=#{listen} pid=#{System.pid()}")
    Process.sleep(:infinity)
  end

  @spec listen_port(GenServer.server()) :: non_neg_integer()
  def listen_port(server), do: GenServer.call(server, :port)

  @spec code_stamp() :: non_neg_integer()
  def code_stamp, do: boot_stamp()

  @spec banner() :: String.t()
  def banner, do: Spiral.Cells.Domain.banner_text(@version, System.pid(), Integer.to_string(boot_stamp()), served_dll_tag())

  @doc false
  def served_dll_tag, do: served_compiler_tag() <> "~" <> tool_tag(Domain.tool("bun", []))

  @doc false
  def served_compiler_tag, do: dll_tag(Domain.tool("compiler_dll", []))

  @doc false
  def tool_tag(nil), do: "none"
  def tool_tag(path), do: path |> Spiral.Cells.Domain.tool_spelling(match?({:win32, _}, :os.type())) |> :erlang.phash2() |> Integer.to_string(16)

  @doc false
  def dll_tag(dll), do: Spiral.Cells.Domain.dll_tag(dll)

  @doc false
  def slot_port(first, n), do: Spiral.Cells.Domain.slot_of(first, n, @default_port, @build_stride, @build_slots)

  defp owner, do: Spiral.Cells.Domain.owner_text(System.get_env("SPIRAL_CELLS_DAEMON_OWNER") || "unrecorded")

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

    server = self()

    case Spiral.Cells.Domain.daemon_listen(port, server, &callbacks/2) do
      {:ok, listen, actual, acceptor} ->
        start_pool(server, opts)
        send(acceptor, :go)
        idle_ms = if opts[:on_retire], do: Keyword.get(opts, :idle_ms, idle_ms()), else: nil
        idle_check_ms = Keyword.get(opts, :idle_check_ms, @idle_check_ms)
        pressure_idle = Keyword.get(opts, :pressure_idle_ms, pressure_idle_ms())
        if idle_ms, do: Process.send_after(self(), :idle_check, idle_check_ms)

        {:ok,
         %{
           listen_port: actual,
           listen: listen,
           acceptor: acceptor,
           retiring: false,
           idle_ms: idle_ms,
           idle_check_ms: idle_check_ms,
           pressure_idle_ms: pressure_idle,
           last_used: System.monotonic_time(:millisecond),
           on_retire: opts[:on_retire],
           compile: opts[:compile],
           compiler: nil,
           log: "",
           toolchain: Keyword.take(opts, [:dotnet, :compiler_dll, :workspace, :package_dir]),
           limits: pool_limits(opts, Spiral.Cells.CompilerPool.settings(opts[:pool]).max_workers)
         }}

      {:error, reason} ->
        {:stop, reason}
    end
  end

  @impl true
  def handle_call(:port, _from, state), do: {:reply, state.listen_port, state}

  def handle_call(:status, _from, state) do
    idle_min = div(System.monotonic_time(:millisecond) - state.last_used, 60_000)
    {:reply, %{idle_min: idle_min, queued: queued(), retiring: state.retiring}, state}
  end

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

    ms = if Process.delete(:spiral_cells_cold), do: 0, else: System.monotonic_time(:millisecond) - started
    result = normalize(result)
    log_compile(req, ms, result)
    state = recycle_heavy(%{state | last_used: System.monotonic_time(:millisecond)})
    retire_when_idle({:reply, {:compiled, result, ms}, state})
  end

  @impl true
  def handle_info(:idle_check, %{retiring: false, idle_ms: idle_ms} = state) when is_integer(idle_ms) do
    idle = System.monotonic_time(:millisecond) - state.last_used
    expired = idle >= idle_ms
    pressed = not expired and idle >= max(state.idle_check_ms, Map.get(state, :pressure_idle_ms, 0)) and memory_pressed?()

    if (expired or pressed) and queued() == 0 do
      reason = if expired, do: "idle for #{div(idle, 60_000)} min", else: "idle and free memory under #{retire_free_mb()} MB"
      IO.puts("#{clock()} #{reason}; retiring")
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
      max_mb: env_count("SPIRAL_CELLS_DAEMON_MAX_MB", @default_max_mb),
      max_compiles: env_count("SPIRAL_CELLS_DAEMON_MAX_COMPILES", 0)
    }
  end

  defp env_count(name, default), do: Spiral.Cells.Domain.count_or(System.get_env(name) || "", default)

  @doc false
  def recycle_reason(compiles, mb, %{max_mb: max_mb, max_compiles: max_compiles}) do
    case Spiral.Cells.Domain.recycle_why(compiles, if(is_integer(mb), do: Integer.to_string(mb), else: ""), max_mb, max_compiles) do
      "" -> nil
      reason -> reason
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
    case Spiral.Cells.Domain.working_set_mb(os_pid) do
      -1 -> nil
      mb -> mb
    end
  end

  @retire_grace_ms 2_000

  defp mailbox_empty? do
    match?({:message_queue_len, 0}, Process.info(self(), :message_queue_len))
  end

  defp retire_when_idle(reply) do
    state = elem(reply, tuple_size(reply) - 1)

    cond do
      state.retiring == false ->
        reply

      queued() > 0 or pool_busy?() or not mailbox_empty?() or System.monotonic_time(:millisecond) - state.retiring < @retire_grace_ms ->
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
      pool -> match?(%{queued: q, idle: i, workers: w} when q > 0 or i < w, Spiral.Cells.CompilerPool.stats(pool))
    end
  end

  defp stop_pool_workers do
    case :persistent_term.get({__MODULE__, :pool, self()}, nil) do
      nil -> :ok
      pool -> pool |> Spiral.Cells.CompilerPool.stats() |> Map.get(:extra_workers, []) |> Enum.each(&stop_worker/1)
    end
  end

  @doc false
  def stop_worker(worker, timeout_ms \\ 30_000) do
    GenServer.stop(worker, :normal, timeout_ms)
  catch
    :exit, _ -> Process.exit(worker, :kill)
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
    case prepare_compiler(state, req) do
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
    case start_compiler(state, compiler_source(state, req)) do
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

  defp prepare_compiler(state, req) do
    source = compiler_source(state, req)

    case state.compiler do
      %{booted: booted} = compiler when req.mtime <= booted ->
        if compiler_current?(compiler, dll_stamp(source)) and Map.get(compiler, :source) == source,
          do: {:ok, state},
          else: start_compiler(stop_compiler(state), source)

      nil ->
        start_compiler(state, source)

      _compiler ->
        start_compiler(stop_compiler(state), source)
    end
  end

  @doc false
  def compiler_source(state, req) do
    case Map.get(req, :pin) do
      pin when is_binary(pin) and pin != "" ->
        if File.regular?(pin), do: pin, else: Domain.tool("compiler_dll", state.toolchain)

      _ ->
        Domain.tool("compiler_dll", state.toolchain)
    end
  end

  defp start_compiler(state, source_dll) do
    dotnet = Domain.tool("dotnet", state.toolchain)
    dll = if source_dll == Domain.tool("compiler_dll", state.toolchain), do: shadow_dll(source_dll), else: source_dll
    socket = socket_path()

    cond do
      not is_binary(dotnet) ->
        {:error, "dotnet was not found", state}

      not File.regular?(dll) ->
        {:error, "Spiral compiler was not found at #{dll}", state}

      not Spiral.Cells.Domain.host_has(dotnet, dll, "server-tcp") ->
        {:error, "the Spiral compiler at #{source_dll} does not list server-tcp in --capabilities; rebuild it from apps/compiler/dotnet/host", state}

      true ->
        args = [dll, "--server-tcp", socket, "--stall-seconds", Integer.to_string(stall_seconds())]

        case open_compiler(state, dotnet, args, socket, source_dll) do
          {:error, reason, state} -> {:error, "Spiral compiler did not open #{socket}: #{inspect(reason)}", state}
          started -> started
        end
    end
  end

  defp open_compiler(state, dotnet, args, socket, source_dll) do
    port_file = socket <> ".bridge"
    File.rm(port_file)

    token = make_ref()
    workspace = Domain.tool("workspace", state.toolchain)
    env = Spiral.Cells.Domain.port_env(dotnet, workspace, Domain.tool("package_dir", state.toolchain))
    {port, os_pid} = Spiral.Cells.Domain.compiler_open(dotnet, args, spawn_dir(workspace), env, self(), token)

    case Spiral.Cells.Domain.await_port_file(port, port_file, 30_000) do
      {:ok, compiler_port} ->
        compiler = %{
          port: port,
          socket: socket,
          port_file: port_file,
          compiler_port: compiler_port,
          os_pid: os_pid,
          token: token,
          booted: System.os_time(:second),
          dll_stamp: dll_stamp(source_dll),
          source: source_dll
        }

        IO.puts("#{clock()} compiler pid=#{os_pid} port=#{compiler_port}")
        {:ok, %{state | compiler: compiler}}

      {:error, reason} ->
        if os_pid, do: Runner.kill_tree(os_pid)
        if Port.info(port), do: Port.close(port)
        {:error, reason, take_log(state)}
    end
  end

  @doc false
  def dll_stamp(dll), do: Spiral.Cells.Domain.dll_stamp(dll)

  @doc false
  def compiler_current?(compiler, source_stamp), do: Map.get(compiler, :dll_stamp) == source_stamp

  defp shadow_root, do: Path.join(System.tmp_dir!(), "spiral-cells-compiler")

  @doc false
  def spawn_dir(dir) when is_binary(dir) do
    if File.dir?(dir) do
      dir
    else
      cwd = File.cwd!()
      Logger.warning("Spiral.Cells.CompilerDaemon: workspace #{dir} does not exist; spawning the compiler in #{cwd}")
      cwd
    end
  end

  def spawn_dir(_dir), do: File.cwd!()

  defp gate_pin_root, do: Path.join(System.tmp_dir!(), "spiral-cells-gate-pins")

  @doc false
  def gate_pin(dll, root \\ gate_pin_root(), now \\ System.os_time(:second)) do
    Spiral.Cells.Domain.gate_pin(dll, root, now)
  rescue
    _ -> nil
  end

  @doc false
  def shadow_dll(dll, root \\ shadow_root()) do
    Spiral.Cells.Domain.shadow_dll(dll, root)
  rescue
    _ -> dll
  end

  @cold_compile_ms 1_200_000
  defp session(state, req) do
    cold = not Map.get(state.compiler, :warm, false)
    if cold, do: Process.put(:spiral_cells_cold, true)
    timeout = if req.timeout == :infinity, do: :infinity, else: max(req.timeout, 0)
    timeout = if cold and timeout != :infinity, do: max(timeout, @cold_compile_ms), else: timeout

    test = if is_binary(Map.get(req, :test)), do: req.test, else: ""
    wait = if timeout == :infinity, do: -1, else: min(timeout, 2_000_000_000)

    case Spiral.Cells.Domain.compiler_session(state.compiler.compiler_port, wait, req.backend, req.input, req.output, test)
         |> String.split("\t", parts: 2) do
      ["ok", revision] ->
        {:ok, revision}

      ["error", message] ->
        {:error, message}

      ["timeout"] ->
        {:error, :timeout}

      ["closed", why] ->
        IO.puts("compiler connection closed: #{why}")
        {:error, "compiler socket failed: #{why}"}

      ["refused", why] ->
        {:error, "compiler socket failed: #{why}"}
    end
  end

  defp stop_compiler(%{compiler: nil} = state), do: state

  defp stop_compiler(%{compiler: compiler} = state) do
    Spiral.Cells.Domain.kill_pidfile(compiler.socket <> ".pid")
    if compiler.os_pid, do: Runner.kill_tree(compiler.os_pid)
    close_port(compiler.port)
    File.rm(compiler.socket)
    File.rm(compiler.socket <> ".pid")
    File.rm(compiler.port_file)
    %{state | compiler: nil}
  end

  defp close_port(port) do
    if Port.info(port), do: Port.close(port)
    :ok
  rescue
    ArgumentError -> :ok
  end

  defp take_log(state) do
    receive do
      {:log, data} -> take_log(%{state | log: state.log <> data})
    after
      200 -> state
    end
  end

  defp callbacks(server, listen) do
    %{
      banner: fn -> banner() end,
      status: fn -> status_line(server) end,
      pool: fn -> pool_line(server) end,
      retire: fn -> :gen_tcp.close(listen); send(server, :retire) end,
      notebook: &notebook_reply/1,
      compile: fn req -> compile_line(server, req) end
    }
  end

  defp status_line(server) do
    %{idle_min: idle_min, queued: queued, retiring: retiring} = GenServer.call(server, :status, 5_000)
    [pid, stamp, idle, queue, since] = Enum.map([System.pid(), boot_stamp(), idle_min, queued, retiring], &to_string/1)
    Spiral.Cells.Domain.status_wire(pid, stamp, idle, queue, since, owner())
  end

  defp compile_line(server, req) do
    started = System.monotonic_time(:millisecond)
    IO.puts("#{clock()} received #{req.client} #{Path.basename(req.input)} #{req.input}")

    case compile_call(server, req) do
      {:compiled, result, compile_ms} -> encode(result, max(System.monotonic_time(:millisecond) - started - compile_ms, 0))
      result -> encode(result, nil)
    end
  catch
    :exit, reason -> encode({:error, "compiler connection failed: #{inspect(reason)}"}, nil)
  end

  defp pool_line(server) do
    case :persistent_term.get({__MODULE__, :pool, server}, nil) do
      nil ->
        Spiral.Cells.Domain.pool_wire(0, 0, 1, -1)

      pool ->
        stats = Spiral.Cells.CompilerPool.stats(pool)
        Spiral.Cells.Domain.pool_wire(stats.served, Map.get(stats, :refused_growth, 0), stats.peak_workers, Map.get(stats, :last_free_mb) || -1)
    end
  end

  defp start_pool(server, opts) do
    settings = Spiral.Cells.CompilerPool.settings(opts[:pool])

    if settings.max_workers > 1 or settings.fair_single do
      toolchain = Keyword.take(opts, [:dotnet, :compiler_dll, :workspace, :package_dir, :compile])

      {:ok, pool} =
        Spiral.Cells.CompilerPool.start_link(
          first: server,
          max_workers: settings.max_workers,
          fair: settings.fair,
          start_worker: Spiral.Cells.CompilerPool.worker_starter(toolchain, pool_limits(opts, settings.max_workers))
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
      pool -> Spiral.Cells.CompilerPool.compile(pool, req.client, req)
    end
  end

  @cells_root Path.expand("../../..", __DIR__)

  @doc false
  def source_stamp do
    ["lib/**/*.ex", "spi/*.spi", "spi/*.ex", "mix.exs", "data/**/*", "templates/**/*"]
    |> Enum.flat_map(&Path.wildcard(Path.join(@cells_root, &1)))
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
    modified = Enum.filter(:code.modified_modules(), &cells_module?/1)
    booted = :persistent_term.get({__MODULE__, :source_stamp}, nil)

    cond do
      modified != [] -> "reloaded beams: #{inspect(modified)}"
      booted == nil -> nil
      source_stamp() > booted -> "Cells sources changed since the daemon started"
      true -> nil
    end
  end

  defp cells_module?(module), do: Spiral.Cells.Domain.cells_module(Atom.to_string(module))

  @doc false
  def notebook_reply(request) do
    with {:ok, %{"args" => args, "root" => root} = fields} when is_list(args) and is_binary(root) <- JSON.decode(request),
         true <- Enum.all?(args, &is_binary/1) do
      cond do
        same_root(root) != same_root(@cells_root) -> {["stale\tthe daemon serves another Cells checkout: #{@cells_root}"], :keep}
        other_build?(fields["dll"]) -> {["stale\tthe daemon serves another compiler build: #{served_compiler_tag()}, requested #{dll_tag(fields["dll"])}"], :keep}
        other_bun?(fields["bun"]) -> {["stale\tthe daemon resolves another bun than this client: #{inspect(Domain.tool("bun", []))}, requested #{fields["bun"]}"], :keep}
        reason = stale_code() -> {["stale\t" <> reason <> "; retiring"], :retire}
        true -> {run_notebook(args), :keep}
      end
    else
      _ -> {["error\t" <> JSON.encode!("notebook request is not {\"args\": [...], \"root\": ...}"), "end\t1"], :keep}
    end
  end

  defp other_build?(dll), do: is_binary(dll) and dll_tag(dll) != served_compiler_tag()

  @doc false
  def other_bun?(bun) when is_binary(bun), do: tool_tag(if(bun == "", do: nil, else: bun)) != tool_tag(Domain.tool("bun", []))
  def other_bun?(_), do: false

  defp same_root(path), do: Spiral.Cells.Domain.root_key(Path.expand(path), match?({:win32, _}, :os.type()))

  defp run_notebook(args) do
    Spiral.Cells.Domain.ensure!()
    {status, lines} = Spiral.Cells.NotebookCli.execute(args)
    shown = Enum.map(lines, &("line\t" <> &1))

    case status do
      :ok -> shown ++ ["end\t0"]
      {:void, message} -> shown ++ ["error\t" <> JSON.encode!(Domain.json_safe(message)), "end\t3"]
      {:error, message} -> shown ++ ["error\t" <> JSON.encode!(Domain.json_safe(message)), "end\t1"]
    end
  rescue
    error -> ["error\t" <> JSON.encode!(Domain.json_safe(Exception.message(error))), "end\t1"]
  end

  defp encode(result, queue), do: Spiral.Cells.Domain.compile_result_reply(result, queue || -1)

  defp session_lost?(message), do: Spiral.Cells.Domain.session_lost(message)

  @default_stall_seconds 120

  @doc false
  def stall_seconds, do: env_count("SPIRAL_CELLS_COMPILER_STALL_S", @default_stall_seconds)

  defp compiler_log(%{log: log}), do: Spiral.Cells.Domain.log_tail(log)

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
    {_, {h, m, s}} = :calendar.local_time()
    Spiral.Cells.Domain.clock_text(h, m, s)
  end

  defp socket_path do
    path = Path.expand(Path.join(System.tmp_dir!(), "spiral-cells-#{System.pid()}-#{System.unique_integer([:positive])}.sock"))
    Spiral.Cells.Domain.native_path(path, match?({:win32, _}, :os.type()))
  end

end
