defmodule Spiral.Cells.CompilerDaemonTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.{CompilerClient, CompilerDaemon}

  test "the daemon port: 13905 by default, SPIRAL_CELLS_COMPILER_PORT otherwise" do
    previous = System.get_env("SPIRAL_CELLS_COMPILER_PORT")

    try do
      System.delete_env("SPIRAL_CELLS_COMPILER_PORT")
      assert CompilerDaemon.port() == 13905
      System.put_env("SPIRAL_CELLS_COMPILER_PORT", "13806")
      assert CompilerDaemon.port() == 13806
      System.put_env("SPIRAL_CELLS_COMPILER_PORT", "x")
      assert_raise ArgumentError, fn -> CompilerDaemon.port() end
    after
      if previous,
        do: System.put_env("SPIRAL_CELLS_COMPILER_PORT", previous),
        else: System.delete_env("SPIRAL_CELLS_COMPILER_PORT")
    end
  end

  test "the Windows daemon starts through cmd with its own output files" do
    assert CompilerClient.daemon_command_line(
             ~S"C:\e\elixir.bat",
             ~S"C:\r\k.log",
             ~S"C:\r\k.err.log",
             nil
           ) ==
             ~S{/d /c ""C:\e\elixir.bat" -S mix spiral.compiler_daemon 1>"C:\r\k.log" 2>"C:\r\k.err.log""}
  end

  test "a relaunch rotates the daemon log even while the retiring daemon still holds it open" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("log_rotation")
    log = Path.join(dir, "kino-1.log")
    File.write!(log, "old daemon\n")
    {:ok, held} = File.open(log, [:append])
    spawn(fn -> Process.sleep(600); File.close(held) end)

    assert CompilerClient.keep_previous(log, System.monotonic_time(:millisecond) + 10_000) == :ok
    assert File.read!(Path.join(dir, "kino-1.prev.log")) == "old daemon\n"
    refute File.exists?(log)
  end
  test "a compiled Cells starts the daemon straight from its ebin directories, so it never waits for mix's build lock" do
    assert CompilerClient.daemon_command_line(~S"C:\e\elixir.bat", ~S"C:\r\k.log", ~S"C:\r\k.err.log", "C:/k/_build/dev/lib/*/ebin") ==
             ~S{/d /c ""C:\e\elixir.bat" -pa "C:/k/_build/dev/lib/*/ebin" -e Spiral.Cells.CompilerDaemon.serve_app() 1>"C:\r\k.log" 2>"C:\r\k.err.log""}

    assert CompilerClient.compiled_ebins() =~ ~r{/_build/[^/]+/lib/\*/ebin$}
  end

  test "queued clients share one compiler and do not overlap" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("daemon")
    {:ok, agent} = Agent.start_link(fn -> [] end)

    compile = fn req ->
      started = System.monotonic_time(:millisecond)
      Process.sleep(80)
      Agent.update(agent, &(&1 ++ [{started, System.monotonic_time(:millisecond), req.input}]))
      File.write!(req.output, "fn main() {}\n")
      {:ok, "open"}
    end

    daemon = start_supervised!({CompilerDaemon, compile: compile, port: 0})
    port = CompilerDaemon.listen_port(daemon)

    tasks =
      for name <- ["a.spi", "b.spi"] do
        Task.async(fn ->
          input = Path.join(dir, name)
          output = Path.join(dir, name <> ".rs")
          File.write!(input, "inl main () : i32 = 0i32\n")

          CompilerClient.compile(
            %{spi: input, rs: output, timeout: 5_000, mtime: 0, backend: "Rust"},
            port: port
          )
        end)
      end

    assert Enum.all?(Task.await_many(tasks, 5_000), &match?({:ok, "open"}, &1))
    [{_left, left_done, _}, {right, _right_done, _}] = Agent.get(agent, &Enum.sort/1)
    assert right + 5 >= left_done
  end

  test "a queued compile still returns when its own timeout is shorter than the wait" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("daemon-queue")

    compile = fn req ->
      Process.sleep(300)
      File.write!(req.output, "fn main() {}\n")
      {:ok, "open", 0}
    end

    daemon = start_supervised!({CompilerDaemon, compile: compile, port: 0})
    port = CompilerDaemon.listen_port(daemon)

    tasks =
      for name <- ["a.spi", "b.spi"] do
        Task.async(fn ->
          input = Path.join(dir, name)
          output = Path.join(dir, name <> ".rs")
          File.write!(input, "inl main () : i32 = 0i32\n")

          result =
            CompilerClient.compile(
              %{spi: input, rs: output, timeout: 50, mtime: 0, backend: "Rust"},
              port: port
            )

          {result, Process.get(:spiral_cells_queue_ms)}
        end)
      end

    results = Task.await_many(tasks, 5_000)
    assert Enum.all?(results, &match?({{:ok, "open"}, _}, &1))
    queues = Enum.map(results, fn {_result, queue} -> queue end)
    assert Enum.all?(queues, &is_integer/1)
    assert Enum.max(queues) - Enum.min(queues) >= 200
  end

  for {outcome, reply, expected} <- [
        {"error", {:error, "Unification failure. Got: () Expected: i32"},
         {:error, "Unification failure. Got: () Expected: i32"}},
        {"timeout", {:error, :timeout}, {:error, :timeout}}
      ] do
    test "an #{outcome} reply still reports the time spent queued behind other compiles" do
      dir = Spiral.Cells.TestHelpers.tmp_dir!("daemon-queue-#{unquote(outcome)}")
      parent = self()

      compile = fn req ->
        if String.contains?(req.input, "slow") do
          send(parent, :slow_started)
          Process.sleep(500)
          File.write!(req.output, "fn main() {}\n")
          {:ok, "open"}
        else
          Process.sleep(20)
          unquote(Macro.escape(reply))
        end
      end

      daemon = start_supervised!({CompilerDaemon, compile: compile, port: 0})
      port = CompilerDaemon.listen_port(daemon)

      slow = Path.join(dir, "slow.spi")
      File.write!(slow, "inl main () : i32 = 0i32\n")

      first =
        Task.async(fn ->
          CompilerClient.compile(
            %{spi: slow, rs: slow <> ".rs", timeout: 5_000, mtime: 0, backend: "Rust"},
            port: port
          )
        end)

      assert_receive :slow_started, 2_000
      cell = Path.join(dir, "cell.spi")
      File.write!(cell, "inl main () : i32 =\n    ()\n")

      second =
        Task.async(fn ->
          result =
            CompilerClient.compile(
              %{spi: cell, rs: cell <> ".rs", timeout: 5_000, mtime: 0, backend: "Rust"},
              port: port
            )

          {result, Process.get(:spiral_cells_queue_ms)}
        end)

      assert {:ok, "open"} = Task.await(first, 5_000)
      assert {unquote(Macro.escape(expected)), queue} = Task.await(second, 5_000)
      assert is_integer(queue) and queue >= 350, "queue time not credited: #{inspect(queue)}"
    end
  end

  test "a compile that raises leaves the daemon up for the next cell" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("daemon-raise")

    compile = fn req ->
      if String.contains?(req.input, "boom") do
        raise "compiler blew up"
      else
        File.write!(req.output, "fn main() {}\n")
        {:ok, "open", 0}
      end
    end

    daemon = start_supervised!({CompilerDaemon, compile: compile, port: 0})
    port = CompilerDaemon.listen_port(daemon)

    boom = Path.join(dir, "boom.spi")
    File.write!(boom, "inl main () : i32 = 0i32\n")

    assert {:error, "compiler blew up"} =
             CompilerClient.compile(
               %{spi: boom, rs: boom <> ".rs", timeout: 5_000, mtime: 0, backend: "Rust"},
               port: port
             )

    ok = Path.join(dir, "ok.spi")
    File.write!(ok, "inl main () : i32 = 1i32\n")

    assert {:ok, "open"} =
             CompilerClient.compile(
               %{spi: ok, rs: ok <> ".rs", timeout: 5_000, mtime: 0, backend: "Rust"},
               port: port
             )
  end

  test "the code stamp is fixed for the life of the VM" do
    stamp = CompilerDaemon.code_stamp()
    beam = List.to_string(:code.which(CompilerDaemon))
    {:ok, %{mtime: mtime}} = File.stat(beam, time: :posix)

    try do
      File.touch!(beam, mtime + 120)
      assert CompilerDaemon.code_stamp() == stamp
    after
      File.touch!(beam, mtime)
    end
  end

  test "the code stamp is the loaded code's md5, so every build of the same code shares one daemon" do
    <<head::binary-size(6), _::binary>> = CompilerDaemon.module_info(:md5)
    assert CompilerDaemon.code_stamp() == :binary.decode_unsigned(head)
    beam = :code.which(CompilerDaemon)
    {:ok, {CompilerDaemon, md5}} = :beam_lib.md5(beam)
    assert md5 == CompilerDaemon.module_info(:md5)
  end

  test "the compiler is recycled past its memory cap or compile count, never before" do
    limits = %{max_mb: 2_500, max_compiles: 0}
    assert CompilerDaemon.recycle_reason(10_000, 2_499, limits) == nil
    assert CompilerDaemon.recycle_reason(1, 2_500, limits) == "reaching 2500 MB"
    assert CompilerDaemon.recycle_reason(1, nil, limits) == nil
    assert CompilerDaemon.recycle_reason(50, 100, %{max_mb: 0, max_compiles: 50}) == "50 compiles"
    assert CompilerDaemon.recycle_reason(49, 9_000, %{max_mb: 0, max_compiles: 50}) == nil
    assert CompilerDaemon.limits().max_mb > 0
  end

  test "the working set of a live process is read in MB" do
    mb = CompilerDaemon.working_set_mb(String.to_integer(System.pid()))
    assert is_integer(mb) and mb > 0
    assert CompilerDaemon.working_set_mb(999_999_999) == nil
  end
  test "the compiler runs from a shadow copy keyed by the DLL stamp; a rebuilt DLL gets a fresh copy and restarts it" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("shadow")
    build = Path.join(dir, "net11.0")
    File.mkdir_p!(build)
    dll = Path.join(build, "SpiralCompiler.dll")
    File.write!(dll, "v1")
    File.write!(Path.join(build, "SpiralCompiler.deps.json"), "{}")
    root = Path.join(dir, "shadows")

    first = CompilerDaemon.shadow_dll(dll, root)
    refute first == dll
    assert File.read!(first) == "v1"
    assert File.regular?(Path.join(Path.dirname(first), "SpiralCompiler.deps.json"))
    assert CompilerDaemon.shadow_dll(dll, root) == first

    stamp = CompilerDaemon.dll_stamp(dll)
    assert CompilerDaemon.compiler_current?(%{dll_stamp: stamp}, stamp)

    File.write!(dll, "v2 rebuilt")
    {:ok, %{mtime: mtime}} = File.stat(dll, time: :posix)
    File.touch!(dll, mtime + 5)
    refute CompilerDaemon.compiler_current?(%{dll_stamp: stamp}, CompilerDaemon.dll_stamp(dll))

    second = CompilerDaemon.shadow_dll(dll, root)
    refute second == first
    assert File.read!(second) == "v2 rebuilt"
    refute File.exists?(first)
    assert CompilerDaemon.shadow_dll(Path.join(dir, "missing.dll"), root) == Path.join(dir, "missing.dll")
    assert CompilerDaemon.shadow_dll(dll, Path.join(dir, "shadows") <> "\u0000") == dll
  end
  test "an exit signal from a linked process does not stop the daemon" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("daemon-exit")

    compile = fn req ->
      File.write!(req.output, "fn main() {}\n")
      {:ok, "open", 0}
    end

    daemon = start_supervised!({CompilerDaemon, compile: compile, port: 0})
    port = CompilerDaemon.listen_port(daemon)
    Process.exit(daemon, :boom)
    Process.sleep(50)
    assert Process.alive?(daemon)

    input = Path.join(dir, "a.spi")
    File.write!(input, "inl main () : i32 = 0i32\n")

    assert {:ok, "open"} =
             CompilerClient.compile(
               %{spi: input, rs: input <> ".rs", timeout: 5_000, mtime: 0, backend: "Rust"},
               port: port
             )
  end

  test "a retired daemon frees its port, finishes queued compiles, then stops" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("daemon-retire")
    parent = self()

    compile = fn req ->
      send(parent, {:compiling, req.input})
      Process.sleep(300)
      File.write!(req.output, "fn main() {}\n")
      {:ok, "open", 0}
    end

    daemon =
      start_supervised!(
        Supervisor.child_spec({CompilerDaemon, compile: compile, port: 0}, restart: :temporary)
      )

    ref = Process.monitor(daemon)
    port = CompilerDaemon.listen_port(daemon)

    tasks =
      for name <- ["a.spi", "b.spi"] do
        input = Path.join(dir, name)
        File.write!(input, "inl main () : i32 = 0i32\n")

        Task.async(fn ->
          CompilerClient.compile(
            %{spi: input, rs: input <> ".rs", timeout: 5_000, mtime: 0, backend: "Rust"},
            port: port
          )
        end)
      end

    assert_receive {:compiling, _}, 2_000
    Process.sleep(100)
    {:ok, sock} = :gen_tcp.connect({127, 0, 0, 1}, port, [:binary, packet: :line, active: false])
    :ok = :gen_tcp.send(sock, "retire\n")
    assert {:ok, "retiring\n"} = :gen_tcp.recv(sock, 0, 2_000)
    :gen_tcp.close(sock)

    assert {:error, refused} =
             :gen_tcp.connect({127, 0, 0, 1}, port, [:binary, active: false], 1_000)

    assert refused in [:econnrefused, :timeout]

    assert Enum.all?(Task.await_many(tasks, 5_000), &match?({:ok, "open"}, &1))
    assert_receive {:DOWN, ^ref, :process, ^daemon, :normal}, 5_000
  end

  test "a dropped compiler connection is tried once more" do
    stamp = CompilerDaemon.code_stamp()

    {:ok, listen} =
      :gen_tcp.listen(0, [:binary, packet: :line, active: false, ip: {127, 0, 0, 1}])

    {:ok, port} = :inet.port(listen)
    parent = self()

    spawn(fn ->
      serve = fn close ->
        {:ok, sock} = :gen_tcp.accept(listen)
        {:ok, _hello} = :gen_tcp.recv(sock, 0, 5_000)
        :gen_tcp.send(sock, "spiral-cells\t1\t1\t#{stamp}\n")
        {:ok, _compile} = :gen_tcp.recv(sock, 0, 5_000)
        send(parent, if(close, do: :first, else: :second))

        if close do
          :gen_tcp.close(sock)
        else
          :gen_tcp.send(sock, "ok\topen\t0\n")
          :gen_tcp.close(sock)
        end
      end

      serve.(true)
      send(parent, :first)
      serve.(false)
      send(parent, :second)
    end)

    assert {:ok, "open"} =
             CompilerClient.compile(
               %{spi: "a.spi", rs: "a.rs", timeout: 1_000, mtime: 0, backend: "Rust"},
               port: port
             )

    assert_received :first
    assert_received :second
    :gen_tcp.close(listen)
  end

  @compiler_that_stalls_on_its_first_request """
  $ErrorActionPreference = 'Stop'
  if ($args[0] -eq '--capabilities') { 'server-tcp'; exit 0 }
  $socket = $args[1]
  $utf8 = New-Object System.Text.UTF8Encoding $false
  $listener = [System.Net.Sockets.TcpListener]::new([System.Net.IPAddress]::Loopback, 0)
  $listener.Start()
  [System.IO.File]::WriteAllText("$socket.pid", "$PID", $utf8)
  $stalls = -not (Test-Path -LiteralPath $env:SPIRAL_CELLS_TEST_HUNG_ONCE)
  if ($stalls) { [System.IO.File]::WriteAllText($env:SPIRAL_CELLS_TEST_HUNG_ONCE, "$PID", $utf8) }
  [System.IO.File]::WriteAllText("$socket.bridge", "$($listener.LocalEndpoint.Port)", $utf8)
  while ($true) {
      $client = $listener.AcceptTcpClient()
      $stream = $client.GetStream()
      $reader = [System.IO.StreamReader]::new($stream, $utf8)
      $writer = [System.IO.StreamWriter]::new($stream, $utf8)
      $writer.NewLine = "`n"
      $writer.AutoFlush = $true
      $parts = $reader.ReadLine().Split("`t")
      if ($stalls) {
          $writer.WriteLine("spiral-session`terror`t$PID`tcompiler stalled: 0 ms CPU in 5 s with a compile outstanding")
          $client.Dispose()
          exit 4
      }
      [System.IO.File]::WriteAllText($parts[3], "fn main() {}", $utf8)
      $writer.WriteLine("spiral-session`tok`t$PID`t12`tmain`trecovered")
      $client.Dispose()
  }
  """

  if System.find_executable("pwsh") do
    test "a compiler that reports a stall is restarted and the compile retried, instead of holding the daemon for the 20 min cold timeout" do
      dir = Path.join(System.tmp_dir!(), "kst#{System.unique_integer([:positive])}")
      File.mkdir_p!(Path.join(dir, "fake"))
      fake = Path.join([dir, "fake", "stalling_compiler.ps1"])
      File.write!(fake, @compiler_that_stalls_on_its_first_request)
      saved = Map.new(["TMPDIR", "SPIRAL_CELLS_TEST_HUNG_ONCE"], &{&1, System.get_env(&1)})
      System.put_env(%{"TMPDIR" => dir, "SPIRAL_CELLS_TEST_HUNG_ONCE" => Path.join(dir, "hung-once")})

      {:ok, daemon} = CompilerDaemon.start_link(port: 0, dotnet: System.find_executable("pwsh"), compiler_dll: fake, workspace: dir, package_dir: dir, pool: "off")

      try do
        output = Path.join(dir, "main.rs")
        {:ok, sock} = :gen_tcp.connect({127, 0, 0, 1}, CompilerDaemon.listen_port(daemon), [:binary, packet: :line, active: false], 5_000)
        :ok = :gen_tcp.send(sock, "compile\tRust\t#{Path.join(dir, "main.spi")}\t#{output}\t300000\t0\tstall-test\n")
        started = System.monotonic_time(:millisecond)

        assert {:ok, "ok\trecovered" <> _} = :gen_tcp.recv(sock, 0, 120_000)
        assert System.monotonic_time(:millisecond) - started < 90_000
        assert File.read!(output) == "fn main() {}"
        assert File.exists?(Path.join(dir, "hung-once"))
      after
        GenServer.stop(daemon, :normal, 30_000)
        Enum.each(saved, fn {name, value} -> if value, do: System.put_env(name, value), else: System.delete_env(name) end)
        File.rm_rf(dir)
      end
    end

    test "a compiler whose --capabilities lacks server-tcp is refused with the reason" do
      dir = Path.join(System.tmp_dir!(), "ksr#{System.unique_integer([:positive])}")
      File.mkdir_p!(Path.join(dir, "fake"))
      fake = Path.join([dir, "fake", "old_compiler.ps1"])
      File.write!(fake, "if ($args[0] -eq '--capabilities') { 'test-blocks'; exit 0 }\nexit 2\n")
      {:ok, daemon} = CompilerDaemon.start_link(port: 0, dotnet: System.find_executable("pwsh"), compiler_dll: fake, workspace: dir, package_dir: dir, pool: "off")

      try do
        {:ok, sock} = :gen_tcp.connect({127, 0, 0, 1}, CompilerDaemon.listen_port(daemon), [:binary, packet: :line, active: false], 5_000)
        :ok = :gen_tcp.send(sock, "compile\tRust\t#{Path.join(dir, "main.spi")}\t#{Path.join(dir, "main.rs")}\t60000\t0\trefused-test\n")
        assert {:ok, "error\t" <> reason} = :gen_tcp.recv(sock, 0, 60_000)
        assert reason =~ "does not list server-tcp"
      after
        GenServer.stop(daemon, :normal, 30_000)
        File.rm_rf(dir)
      end
    end
  end
  @compiler_that_listens_on_tcp """
  $ErrorActionPreference = 'Stop'
  if ($args[0] -eq '--capabilities') { 'server-tcp test-blocks'; exit 0 }
  $socket = $args[1]
  $utf8 = New-Object System.Text.UTF8Encoding $false
  $listener = [System.Net.Sockets.TcpListener]::new([System.Net.IPAddress]::Loopback, 0)
  $listener.Start()
  [System.IO.File]::WriteAllText("$socket.pid", "$PID", $utf8)
  [System.IO.File]::WriteAllText("$socket.bridge", "$($listener.LocalEndpoint.Port)", $utf8)
  while ($true) {
      $client = $listener.AcceptTcpClient()
      $stream = $client.GetStream()
      $reader = [System.IO.StreamReader]::new($stream, $utf8)
      $writer = [System.IO.StreamWriter]::new($stream, $utf8)
      $writer.NewLine = "`n"
      $writer.AutoFlush = $true
      $parts = $reader.ReadLine().Split("`t")
      [System.IO.File]::WriteAllText($parts[3], "fn main() {}", $utf8)
      $writer.WriteLine("spiral-session`tok`t$PID`t12`tmain`tdirect")
      $client.Dispose()
  }
  """

  if System.find_executable("pwsh") do
    test "the compiler is reached directly over TCP on the port it writes next to its socket" do
      dir = Path.join(System.tmp_dir!(), "ksd#{System.unique_integer([:positive])}")
      File.mkdir_p!(Path.join(dir, "fake"))
      fake = Path.join([dir, "fake", "tcp_compiler.ps1"])
      File.write!(fake, @compiler_that_listens_on_tcp)
      saved = System.get_env("TMPDIR")
      System.put_env("TMPDIR", dir)
      pwsh = System.find_executable("pwsh")
      {:ok, daemon} = CompilerDaemon.start_link(port: 0, dotnet: pwsh, compiler_dll: fake, workspace: dir, package_dir: dir, pool: "off")

      try do
        assert "server-tcp" in CompilerDaemon.host_capabilities(pwsh, fake)
        output = Path.join(dir, "main.rs")
        {:ok, sock} = :gen_tcp.connect({127, 0, 0, 1}, CompilerDaemon.listen_port(daemon), [:binary, packet: :line, active: false], 5_000)
        :ok = :gen_tcp.send(sock, "compile\tRust\t#{Path.join(dir, "main.spi")}\t#{output}\t300000\t0\tdirect-test\n")
        assert {:ok, "ok\tdirect" <> _} = :gen_tcp.recv(sock, 0, 60_000)
        assert File.read!(output) == "fn main() {}"
      after
        GenServer.stop(daemon, :normal, 30_000)
        if saved, do: System.put_env("TMPDIR", saved), else: System.delete_env("TMPDIR")
        File.rm_rf(dir)
      end
    end
  end
end