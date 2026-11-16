defmodule Spiral.Cells.CompilerClient do
  alias Spiral.Cells.{CompilerDaemon, FileLock, ProcessError, Runner}

  @spec compile(map(), keyword()) :: {:ok, String.t()} | {:error, term()}
  def compile(req, opts \\ []) do
    case Keyword.fetch(opts, :port) do
      {:ok, port} ->
        exchange(port, req, false)

      :error ->
        port = acquire_port()

        try do
          with :ok <- ensure(port), do: exchange(port, req, true)
        after
          release_port(port)
        end
    end
  end

  @doc """
  The compiler daemons answering on the first 16 ports from the base port, each with its OS pid, code stamp, idle
  minutes, queued compiles and whether it is retiring. A daemon too old to answer `status` reports nil for those.
  """
  @spec live_daemons() :: [map()]
  def live_daemons do
    for row <- base_port() |> Spiral.Cells.Domain.live_status() |> String.split("\n", trim: true) do
      [port, line] = String.split(row, "\t", parts: 2)
      Map.put(status_fields(line), :port, String.to_integer(port))
    end
  end

  @spec pool_stats() :: map() | nil
  def pool_stats do
    case Spiral.Cells.Domain.pool_summary(base_port(), length(pool_ports())) |> String.split("\t") do
      [served, refused, peak, free] ->
        %{served: String.to_integer(served), refused_growth: String.to_integer(refused), peak_workers: String.to_integer(peak), last_free_mb: if(free == "-", do: nil, else: String.to_integer(free))}

      _ ->
        nil
    end
  end

  @spec pool_ports() :: [non_neg_integer()]
  def pool_ports do
    size =
      case Integer.parse(System.get_env("SPIRAL_CELLS_COMPILERS") || "1") do
        {n, ""} when n >= 1 -> n
        _ -> 1
      end

    Enum.map(0..(size - 1), &(base_port() + &1))
  end

  defp busy_table, do: Spiral.Cells.Tables.ensure(:spiral_cells_compiler_busy, [:set, write_concurrency: true])

  defp acquire_port do
    table = busy_table()

    port =
      Enum.min_by(pool_ports(), fn port ->
        case :ets.lookup(table, port) do
          [{^port, busy}] -> busy
          [] -> 0
        end
      end)

    :ets.update_counter(table, port, 1, {port, 0})
    port
  end

  defp release_port(port), do: :ets.update_counter(busy_table(), port, -1, {port, 1})

  @spec ensure() :: :ok | {:error, ProcessError.t()}
  def ensure, do: ensure(base_port())

  @spec ensure(non_neg_integer()) :: :ok | {:error, ProcessError.t()}
  def ensure(port) do
    case ping(port) do
      {:ok, stamp, pid} ->
        cond do
          stamp != CompilerDaemon.code_stamp() -> replace(port, pid)
          foreign_toolchain?(port) -> {:error, process_error(foreign_toolchain_message(port))}
          true -> :ok
        end

      :down ->
        start(port)

      {:occupied, detail} ->
        if handshake_pending?(detail) do
          start(port)
        else
          {:error, process_error("port #{port} is already used by another program (#{detail})")}
        end
    end
  end

  @doc """
  Launches the daemon on the base port when nothing listens there, without waiting for it: a notebook run whose steps
  were all recalled never needs a compiler, but the next run's thin client (`run_notebook.ps1`) wants a warm daemon.
  """
  @spec prestart() :: :ok
  def prestart do
    port = base_port()

    if ping(port) == :down do
      _ = spawn_daemon(port)
    end

    :ok
  end
  @doc """
  Retires the compiler daemons on this client's ports, if they are up: each finishes the compiles already queued and
  exits (killed if it is still up after 10 s). The test suite calls this when it ends, so no test daemon outlives `mix test`.
  """
  @spec shutdown() :: :ok
  def shutdown do
    Enum.each(pool_ports(), fn port ->
      case ping(port) do
        {:ok, _stamp, pid} -> retire(port, pid)
        _ -> :ok
      end
    end)

    :ok
  end

  defp start(port) do
    case FileLock.with_lock(lock_path(port), fn -> start_locked(port) end, 240_000) do
      :ok ->
        :ok

      {:error, %ProcessError{} = error} ->
        {:error, error}

      {:error, reason} ->
        {:error,
         process_error("could not start the compiler on port #{port}: #{inspect(reason)}")}
    end
  end

  defp start_locked(port) do
    case ping(port) do
      {:ok, stamp, pid} ->
        if stamp == CompilerDaemon.code_stamp() do
          :ok
        else
          retire(port, pid)
          launch(port)
        end

      :down ->
        launch(port)

      {:occupied, detail} ->
        if handshake_pending?(detail) do
          settle(port, System.monotonic_time(:millisecond) + 30_000)
        else
          {:error, process_error("port #{port} is already used by another program (#{detail})")}
        end
    end
  end

  defp settle(port, deadline) do
    case ping(port) do
      {:ok, stamp, pid} ->
        if stamp == CompilerDaemon.code_stamp() do
          :ok
        else
          retire(port, pid)
          launch(port)
        end

      :down ->
        launch(port)

      {:occupied, detail} ->
        cond do
          not handshake_pending?(detail) ->
            {:error, process_error("port #{port} is already used by another program (#{detail})")}

          System.monotonic_time(:millisecond) > deadline ->
            {:error, process_error("port #{port} accepts connections but never answers the handshake (#{detail})")}

          true ->
            Process.sleep(100)
            settle(port, deadline)
        end
    end
  end

  defp launch(port) do
    case spawn_daemon(port) do
      :ok -> wait_up(port, System.monotonic_time(:millisecond) + 180_000)
      {:error, error} -> {:error, error}
    end
  end

  defp retire(port, pid) do
    _ = Spiral.Cells.Domain.retire_daemon(port)
    wait_down(port, System.monotonic_time(:millisecond) + 10_000)

    case ping(port) do
      {:ok, _stamp, _pid} ->
        Runner.kill_tree(pid)
        wait_down(port, System.monotonic_time(:millisecond) + 10_000)

      _ ->
        :ok
    end
  end

  defp replace(port, _pid) do
    case FileLock.with_lock(lock_path(port), fn -> start_locked(port) end, 240_000) do
      :ok ->
        :ok

      {:error, %ProcessError{} = error} ->
        {:error, error}

      {:error, reason} ->
        {:error,
         process_error("could not replace the compiler on port #{port}: #{inspect(reason)}")}
    end
  end

  defp exchange(port, req, restart) do
    started = System.monotonic_time(:millisecond)

    case transact(port, req) do
      {:error, :stale} when restart ->
        relaunch(port, req)

      {:error, reason} = error ->
        if connection_lost?(reason) do
          remember_queue(System.monotonic_time(:millisecond) - started)

          if restart do
            relaunch(port, req)
          else
            transact(port, req)
          end
        else
          error
        end

      other ->
        other
    end
  end

  defp relaunch(port, req) do
    case ensure(port) do
      :ok -> transact(port, req)
      error -> error
    end
  end

  defp connection_lost?("compiler " <> rest), do: String.starts_with?(rest, ["connection failed: ", "worker failed: {:noproc,", "worker failed: {:normal,"])

  defp connection_lost?(%ProcessError{message: message}) do
    String.contains?(message, ["could not connect to the compiler", "compiler worker failed: {:noproc,", "compiler worker failed: {:normal,"])
  end

  defp connection_lost?(_reason), do: false

  defp remember_queue(ms) when is_integer(ms) and ms > 0 do
    Process.put(:spiral_cells_queue_ms, (Process.get(:spiral_cells_queue_ms) || 0) + ms)
  end

  defp remember_queue(_ms), do: :ok

  defp transact(port, req) do
    stamp = Integer.to_string(CompilerDaemon.code_stamp())

    case apply(Spiral.Cells.Domain, :compile_exchange, [port, stamp | request_fields(req)]) |> String.split("\t", parts: 2) do
      ["line", line] -> compile_result(line)
      ["stale"] -> {:error, :stale}
      ["waited"] -> {:error, :timeout}
      ["unreachable", why] -> {:error, process_error(why)}
      ["lost", why] -> {:error, why}
    end
  end

  defp ping(port) do
    case port |> Spiral.Cells.Domain.ping_wire() |> String.split("\t", parts: 3) do
      ["down"] -> :down
      ["ok", stamp, pid] -> {:ok, String.to_integer(stamp), String.to_integer(pid)}
      ["occupied" | detail] -> {:occupied, Enum.join(detail, "\t")}
    end
  end

  defp wait_up(port, deadline) do
    case ping(port) do
      {:ok, stamp, _pid} ->
        cond do
          stamp == CompilerDaemon.code_stamp() ->
            :ok

          System.monotonic_time(:millisecond) > deadline ->
            {:error, process_error("compiler on port #{port} started with a different build")}

          true ->
            Process.sleep(100)
            wait_up(port, deadline)
        end

      :down ->
        if System.monotonic_time(:millisecond) > deadline do
          {:error, process_error("compiler on port #{port} did not start\n#{log_tail(port)}")}
        else
          Process.sleep(100)
          wait_up(port, deadline)
        end

      {:occupied, detail} ->
        if handshake_pending?(detail) and System.monotonic_time(:millisecond) <= deadline do
          Process.sleep(100)
          wait_up(port, deadline)
        else
          {:error, process_error("port #{port} is already used by another program (#{detail})")}
        end
    end
  end

  defp handshake_pending?(detail), do: detail in [":timeout", ":closed"]

  defp wait_down(port, deadline) do
    case ping(port) do
      :down ->
        :ok

      _ ->
        if System.monotonic_time(:millisecond) > deadline do
          :ok
        else
          Process.sleep(50)
          wait_down(port, deadline)
        end
    end
  end

  defp spawn_daemon(port) do
    elixir = elixir_bat()
    project = project_dir()
    File.mkdir_p!(runtime_dir())
    log = Path.join(runtime_dir(), Spiral.Cells.Domain.runtime_file(port, ".log"))
    err = Path.join(runtime_dir(), Spiral.Cells.Domain.runtime_file(port, ".err.log"))
    Enum.each([log, err], &keep_previous/1)
    path = toolchain_path()

    if windows?(),
      do: spawn_daemon_windows(elixir, project, log, err, path, port),
      else: spawn_daemon_unix(elixir, project, log, err, path, port)
  end

  defp spawn_daemon_unix(elixir, project, log, err, path, port) do
    detach = if System.find_executable("setsid"), do: "setsid", else: "nohup"

    script =
      case compiled_ebins() do
        nil -> ~s(cd "$1" && #{detach} "$2" -S mix spiral.compiler_daemon </dev/null >"$3" 2>"$4" &)
        ebins -> ~s|cd "$1" && #{detach} "$2" -pa "#{ebins}" -e 'Spiral.Cells.CompilerDaemon.serve_app()' </dev/null >"$3" 2>"$4" &|
      end

    env = [
      {"PATH", path},
      {"MIX_ENV", mix_env()},
      {"SPIRAL_CELLS_COMPILER_PORT", Integer.to_string(port)},
      {"SPIRAL_CELLS_DAEMON_OWNER", daemon_owner()}
    ]

    case System.cmd("sh", ["-c", script, "sh", project, elixir, log, err],
           env: env,
           stderr_to_stdout: true
         ) do
      {_out, 0} ->
        :ok

      {out, status} ->
        {:error,
         process_error("could not start the compiler daemon (#{status}): #{String.trim(out)}")}
    end
  end

  defp spawn_daemon_windows(elixir, project, log, err, path, port) do
    script = Spiral.Cells.Domain.spawn_script(path, mix_env(), port, daemon_owner(), daemon_start(elixir, project, log, err, port))

    case System.cmd("powershell.exe", ["-NoProfile", "-Command", script], stderr_to_stdout: true) do
      {_out, 0} ->
        :ok

      {out, status} ->
        {:error,
         process_error("could not start the compiler daemon (#{status}): #{String.trim(out)}")}
    end
  end

  @doc false
  def daemon_owner do
    command = System.argv() |> Enum.join(" ") |> String.replace(["\t", "\r", "\n", "'", "\""], " ") |> String.slice(0, 160)
    job = System.get_env("KIT_JOB_ID")
    "#{if job, do: "job #{job} "}os_pid #{System.pid()} argv #{command}"
  end

  defp daemon_start(elixir, project, log, err, port) do
    case shell_launcher() do
      nil ->
        Spiral.Cells.Domain.start_process_line(project, daemon_command_line(elixir, log, err))

      launcher ->
        start = Path.join(runtime_dir(), Spiral.Cells.Domain.runtime_file(port, ".start.cmd"))
        File.write!(start, Spiral.Cells.Domain.start_cmd_text(project, daemon_command(elixir, log, err)))
        Spiral.Cells.Domain.launcher_line(launcher, start)
    end
  end

  @doc false
  def shell_launcher do
    case System.get_env("SPIRAL_CELLS_SHELL_LAUNCHER") do
      value when value in [nil, ""] -> default_shell_launcher()
      "none" -> nil
      value -> value
    end
  end

  @doc false
  def default_shell_launcher do
    with local when is_binary(local) <- System.get_env("LOCALAPPDATA"),
         kit = Path.join(local, "kit/bin/kit.exe"),
         true <- File.regular?(kit) do
      kit
    else
      _ -> nil
    end
  end

  @doc false
  def daemon_command_line(elixir, log, err, ebins \\ compiled_ebins()), do: ~s{/d /c "#{daemon_command(elixir, log, err, ebins)}"}

  @doc false
  def daemon_command(elixir, log, err, ebins \\ compiled_ebins()), do: Spiral.Cells.Domain.daemon_command(elixir, log, err, ebins || "")

  @doc false
  def compiled_ebins do
    case :code.lib_dir(:spiral_cells) do
      path when is_list(path) ->
        lib = path |> to_string() |> Path.dirname()
        if File.dir?(Path.join([lib, "spiral_cells", "ebin"])), do: Path.join(lib, "*/ebin"), else: nil

      _ ->
        nil
    end
  end

  defp keep_previous(path), do: keep_previous(path, System.monotonic_time(:millisecond) + 30_000)

  @doc false
  def keep_previous(path, deadline) do
    cond do
      not File.exists?(path) ->
        :ok

      File.rename(path, Path.rootname(path) <> ".prev.log") == :ok ->
        :ok

      System.monotonic_time(:millisecond) > deadline ->
        {:error, :locked}

      true ->
        Process.sleep(200)
        keep_previous(path, deadline)
    end
  end

  @doc """
  One compile reply line as the client result, ok with the revision, a timeout, or an error message, crediting the daemon
  queue wait the line reports.
  """
  @spec compile_result(String.t()) :: {:ok, String.t()} | {:error, :timeout | String.t()}
  def compile_result(line) do
    [tag, queue, payload] = line |> Spiral.Cells.Domain.compile_reply() |> String.split("\t", parts: 3)
    credit_queue(queue)

    case tag do
      "ok" -> {:ok, payload}
      "timeout" -> {:error, :timeout}
      "failed" -> {:error, payload}
    end
  end

  defp credit_queue(ms) when is_integer(ms) do
    Process.put(:spiral_cells_queue_ms, (Process.get(:spiral_cells_queue_ms) || 0) + ms)
  end

  defp credit_queue(queue) when is_binary(queue) do
    case Spiral.Cells.Domain.count_or(queue, -1) do
      ms when ms >= 0 -> credit_queue(ms)
      _ -> :ok
    end
  end


  defp request_fields(req) do
    [req.backend, req.spi, req.rs, timeout_field(req.timeout), req.mtime, System.pid(), Map.get(req, :pin), Map.get(req, :test)]
    |> Enum.map(&wire_field/1)
  end

  defp wire_field(value) when is_binary(value), do: value
  defp wire_field(value) when is_integer(value), do: Integer.to_string(value)
  defp wire_field(_value), do: ""

  defp timeout_field(:infinity), do: "-1"
  defp timeout_field(ms), do: Integer.to_string(ms)

  defp elixir_bat do
    scoop = System.get_env("SCOOP") || Path.join(System.user_home!(), "scoop")
    candidate = Path.join(scoop, "apps/elixir/current/bin/elixir.bat")

    cond do
      not windows?() -> System.find_executable("elixir") || "elixir"
      File.regular?(candidate) -> candidate
      path = System.find_executable("elixir.bat") -> path
      path = System.find_executable("elixir") -> path
      true -> "elixir"
    end
  end

  defp toolchain_path do
    scoop = System.get_env("SCOOP") || Path.join(System.user_home!(), "scoop")

    extra = [
      Path.join(scoop, "apps/erlang/current/bin"),
      Path.join(scoop, "apps/elixir/current/bin")
    ]

    present = Enum.filter(extra, &File.dir?/1)
    Enum.join(present ++ [System.get_env("PATH") || ""], if(windows?(), do: ";", else: ":"))
  end

  defp windows?, do: match?({:win32, _}, :os.type())

  defp project_dir do
    Application.app_dir(:spiral_cells)
    |> Path.expand()
    |> ancestors()
    |> Enum.find_value(fn dir ->
      mix = Path.join(dir, "mix.exs")
      if File.regular?(mix) and String.contains?(File.read!(mix), ":spiral_cells"), do: dir
    end) || File.cwd!()
  end

  defp ancestors(dir) do
    parent = Path.dirname(dir)
    if parent == dir, do: [dir], else: [dir | ancestors(parent)]
  end

  defp runtime_dir do
    base = System.get_env("LOCALAPPDATA") || Path.join(System.user_home!(), ".cache")
    Path.join(base, "spiral-bin")
  end

  defp base_port do
    case System.get_env("SPIRAL_CELLS_COMPILER_PORT") do
      value when value in [nil, ""] -> build_slot_port()
      _ -> CompilerDaemon.port()
    end
  end

  defp build_slot_port do
    first = CompilerDaemon.port()
    mine = CompilerDaemon.served_dll_tag()
    key = {__MODULE__, :slot_port, first, mine}

    case :persistent_term.get(key, nil) do
      nil ->
        port = pick_slot(first, mine, 0, &banner_dll/1)
        :persistent_term.put(key, port)
        _ = File.write(warm_port_file(Path.expand("../../..", __DIR__), CompilerDaemon.served_compiler_tag()), Integer.to_string(port))
        port

      port ->
        port
    end
  end

  @doc false
  def pick_slot(first, _mine, tries, _dll_ping) when tries >= 12, do: first

  def pick_slot(first, mine, tries, dll_ping) do
    port = CompilerDaemon.slot_port(first, tries)

    case dll_ping.(port) do
      {:dll, ^mine} -> port
      {:dll, _other} -> pick_slot(first, mine, tries + 1, dll_ping)
      _ -> port
    end
  end

  @doc false
  def root_key(root) do
    root |> Spiral.Cells.Domain.root_spelling() |> then(&:crypto.hash(:sha256, &1)) |> Base.encode16() |> binary_part(0, 16)
  end

  @doc false
  def warm_port_file(root, dll_tag), do: Path.join(runtime_dir(), Spiral.Cells.Domain.warm_port_name(root_key(root), dll_tag))

  defp foreign_toolchain?(port) do
    case banner_dll(port) do
      {:dll, tag} -> tag != CompilerDaemon.served_dll_tag()
      _ -> false
    end
  end

  defp foreign_toolchain_message(port), do: Spiral.Cells.Domain.foreign_toolchain_text(port)

  defp banner_dll(port) do
    case port |> Spiral.Cells.Domain.banner_dll_wire() |> String.split("\t", parts: 2) do
      ["dll", tag] -> {:dll, tag}
      ["down"] -> :down
      ["other"] -> :other
      ["legacy"] -> :legacy
    end
  end

  defp lock_path(port), do: Path.join(runtime_dir(), Spiral.Cells.Domain.runtime_file(port, ".lock"))

  defp log_tail(port) do
    path = Path.join(runtime_dir(), Spiral.Cells.Domain.runtime_file(port, ".err.log"))

    case File.read(path) do
      {:ok, text} ->
        text = String.trim(text)
        if text == "", do: "", else: String.slice(text, -1_000, 1_000)

      _ ->
        ""
    end
  end

  defp mix_env do
    if Code.ensure_loaded?(Mix) and List.keymember?(Application.started_applications(), :mix, 0),
      do: Mix.env() |> Atom.to_string(),
      else: "dev"
  end

  defp process_error(message), do: %ProcessError{message: message}

  @doc """
  One `status` reply line as the fields `live_daemons/0` reports, every field nil when the line is not a status reply.
  """
  @spec status_fields(String.t()) :: map()
  def status_fields(line) do
    case line |> Spiral.Cells.Domain.status_reply() |> String.split("\t") do
      ["" | _] -> %{pid: nil, stamp: nil, idle_min: nil, queued: nil, retiring: nil, owner: nil}
      [pid, stamp, idle, queued, retiring, owner] -> %{pid: pid, stamp: stamp, idle_min: idle, queued: queued, retiring: retiring, owner: owner}
    end
  end
end
