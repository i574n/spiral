defmodule Spiral.Kino.CompilerClient do
  alias Spiral.Kino.{CompilerDaemon, FileLock, ProcessError, Runner}

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

  @spec pool_ports() :: [non_neg_integer()]
  def pool_ports do
    size =
      case Integer.parse(System.get_env("SPIRAL_KINO_COMPILERS") || "1") do
        {n, ""} when n >= 1 -> n
        _ -> 1
      end

    Enum.map(0..(size - 1), &(base_port() + &1))
  end

  defp busy_table do
    case :ets.whereis(:spiral_kino_compiler_busy) do
      :undefined ->
        try do
          :ets.new(:spiral_kino_compiler_busy, [:named_table, :public, :set, write_concurrency: true])
        rescue
          ArgumentError -> :spiral_kino_compiler_busy
        end

      table ->
        table
    end
  end

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
        if stamp == CompilerDaemon.code_stamp(), do: :ok, else: replace(port, pid)

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
          wait_up(port, System.monotonic_time(:millisecond) + 180_000)
        else
          {:error, process_error("port #{port} is already used by another program (#{detail})")}
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
    case :gen_tcp.connect({127, 0, 0, 1}, port, socket_opts(), 1_000) do
      {:ok, sock} ->
        :gen_tcp.send(sock, "retire\n")
        _ = recv_line(sock, 2_000)
        :gen_tcp.close(sock)

      _ ->
        :ok
    end

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

  defp connection_lost?("compiler connection failed: " <> _), do: true

  defp connection_lost?(%ProcessError{message: message}) do
    String.contains?(message, "could not connect to the compiler")
  end

  defp connection_lost?(_reason), do: false

  defp remember_queue(ms) when is_integer(ms) and ms > 0 do
    Process.put(:spiral_kino_queue_ms, (Process.get(:spiral_kino_queue_ms) || 0) + ms)
  end

  defp remember_queue(_ms), do: :ok

  defp transact(port, req) do
    with {:ok, sock} <- connect(port, 50) do
      try do
        :gen_tcp.send(sock, "hello\n")

        case recv_line(sock, 5_000) do
          {:ok, "spiral-kino\t1\t" <> rest} ->
            case String.split(rest, "\t") do
              [_pid, stamp | _] ->
                if String.to_integer(stamp) == CompilerDaemon.code_stamp() do
                  :gen_tcp.send(sock, request_line(req) <> "\n")

                  case recv_line(sock, :infinity) do
                    {:ok, "ok\t" <> rest} -> ok_revision(rest)
                    {:ok, "error\ttimeout"} -> {:error, :timeout}
                    {:ok, "error\ttimeout\t" <> queue} -> error_timeout(queue)
                    {:ok, "error\t" <> rest} -> error_message(rest)
                    {:ok, other} -> {:error, "unexpected compiler reply: #{other}"}
                    {:error, :timeout} -> {:error, :timeout}
                    {:error, reason} -> {:error, "compiler connection failed: #{inspect(reason)}"}
                  end
                else
                  {:error, :stale}
                end

              _ ->
                {:error, :stale}
            end

          {:ok, _other} ->
            {:error, :stale}

          {:error, reason} ->
            {:error, "compiler connection failed: #{inspect(reason)}"}
        end
      after
        :gen_tcp.close(sock)
      end
    end
  end

  defp connect(port, attempts) do
    case :gen_tcp.connect({127, 0, 0, 1}, port, socket_opts(), 2_000) do
      {:ok, sock} ->
        {:ok, sock}

      {:error, :econnrefused} when attempts > 0 ->
        Process.sleep(20)
        connect(port, attempts - 1)

      {:error, reason} ->
        {:error,
         process_error("could not connect to the compiler on port #{port}: #{inspect(reason)}")}
    end
  end

  defp ping(port) do
    case :gen_tcp.connect({127, 0, 0, 1}, port, socket_opts(), 500) do
      {:ok, sock} ->
        :gen_tcp.send(sock, "hello\n")

        result =
          case recv_line(sock, 1_000) do
            {:ok, "spiral-kino\t1\t" <> rest} ->
              case String.split(rest, "\t") do
                [pid, stamp | _] ->
                  case Integer.parse(stamp) do
                    {stamp, ""} -> {:ok, stamp, String.to_integer(pid)}
                    _ -> {:occupied, "unreadable banner"}
                  end

                _ ->
                  {:occupied, "unreadable banner"}
              end

            {:ok, other} ->
              {:occupied, String.trim(other)}

            {:error, reason} ->
              {:occupied, inspect(reason)}
          end

        :gen_tcp.close(sock)
        result

      {:error, reason} when reason in [:econnrefused, :timeout, :closed] ->
        :down

      {:error, reason} ->
        {:occupied, inspect(reason)}
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
    log = Path.join(runtime_dir(), "kino-#{port}.log")
    err = Path.join(runtime_dir(), "kino-#{port}.err.log")
    Enum.each([log, err], &keep_previous/1)
    path = toolchain_path()

    if windows?(),
      do: spawn_daemon_windows(elixir, project, log, err, path, port),
      else: spawn_daemon_unix(elixir, project, log, err, path, port)
  end

  defp spawn_daemon_unix(elixir, project, log, err, path, port) do
    detach = if System.find_executable("setsid"), do: "setsid", else: "nohup"

    script =
      ~s(cd "$1" && #{detach} "$2" -S mix spiral.compiler_daemon </dev/null >"$3" 2>"$4" &)

    env = [
      {"PATH", path},
      {"MIX_ENV", mix_env()},
      {"SPIRAL_KINO_COMPILER_PORT", Integer.to_string(port)}
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
    script =
      """
      $env:PATH = '#{String.replace(path, "'", "''")}'
      $env:MIX_ENV = '#{mix_env()}'
      $env:SPIRAL_KINO_COMPILER_PORT = '#{port}'
      Start-Process -FilePath $env:ComSpec -WorkingDirectory '#{String.replace(project, "'", "''")}' -WindowStyle Hidden -ArgumentList '#{String.replace(daemon_command_line(elixir, log, err), "'", "''")}'
      """

    case System.cmd("powershell.exe", ["-NoProfile", "-Command", script], stderr_to_stdout: true) do
      {_out, 0} ->
        :ok

      {out, status} ->
        {:error,
         process_error("could not start the compiler daemon (#{status}): #{String.trim(out)}")}
    end
  end

  @doc false
  def daemon_command_line(elixir, log, err) do
    ~s{/d /c ""#{elixir}" -S mix spiral.compiler_daemon 1>"#{log}" 2>"#{err}""}
  end

  defp keep_previous(path) do
    case File.stat(path) do
      {:ok, %{size: size}} when size > 0 ->
        _ = File.rename(path, Path.rootname(path) <> ".prev.log")
        :ok

      _ ->
        :ok
    end
  end

  defp error_timeout(queue) do
    credit_queue(queue)
    {:error, :timeout}
  end

  defp error_message(rest) do
    with [queue, message] <- String.split(rest, "\t", parts: 2),
         {ms, ""} when ms >= 0 <- Integer.parse(queue) do
      credit_queue(ms)
      {:error, message}
    else
      _ -> {:error, rest}
    end
  end

  defp credit_queue(ms) when is_integer(ms) do
    Process.put(:spiral_kino_queue_ms, (Process.get(:spiral_kino_queue_ms) || 0) + ms)
  end

  defp credit_queue(queue) when is_binary(queue) do
    case Integer.parse(queue) do
      {ms, ""} when ms >= 0 -> credit_queue(ms)
      _ -> :ok
    end
  end

  defp ok_revision(rest) do
    case String.split(rest, "\t") do
      [revision, queue] ->
        credit_queue(queue)
        {:ok, revision}

      [revision] ->
        {:ok, revision}

      _ ->
        {:error, "unexpected compiler reply: ok\t#{rest}"}
    end
  end

  defp request_line(req) do
    "compile\t#{req.backend}\t#{req.spi}\t#{req.rs}\t#{timeout_field(req.timeout)}\t#{req.mtime}"
  end

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
    Application.app_dir(:spiral_kino)
    |> Path.expand()
    |> ancestors()
    |> Enum.find_value(fn dir ->
      mix = Path.join(dir, "mix.exs")
      if File.regular?(mix) and String.contains?(File.read!(mix), ":spiral_kino"), do: dir
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

  defp base_port, do: CompilerDaemon.port()

  defp lock_path(port), do: Path.join(runtime_dir(), "kino-#{port}.lock")

  defp log_tail(port) do
    path = Path.join(runtime_dir(), "kino-#{port}.err.log")

    case File.read(path) do
      {:ok, text} ->
        text = String.trim(text)
        if text == "", do: "", else: String.slice(text, -1_000, 1_000)

      _ ->
        ""
    end
  end

  defp mix_env do
    if Code.ensure_loaded?(Mix), do: Mix.env() |> Atom.to_string(), else: "dev"
  end

  defp process_error(message), do: %ProcessError{message: message}

  defp recv_line(sock, timeout) do
    case :gen_tcp.recv(sock, 0, timeout) do
      {:ok, line} -> {:ok, String.trim(line)}
      other -> other
    end
  end

  defp socket_opts do
    [:binary, packet: :line, active: false, packet_size: 8_000_000]
  end
end
