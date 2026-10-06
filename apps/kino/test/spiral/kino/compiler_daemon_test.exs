defmodule Spiral.Kino.CompilerDaemonTest do
  use ExUnit.Case, async: false

  alias Spiral.Kino.{CompilerClient, CompilerDaemon}

  test "the daemon never takes polyglot's Supervisor port" do
    previous = System.get_env("SPIRAL_KINO_COMPILER_PORT")

    try do
      System.delete_env("SPIRAL_KINO_COMPILER_PORT")
      assert CompilerDaemon.port() != CompilerDaemon.supervisor_port()

      System.put_env("SPIRAL_KINO_COMPILER_PORT", "13805")

      assert_raise ArgumentError, ~r/reserved for polyglot's Supervisor/, fn ->
        CompilerDaemon.port()
      end
    after
      if previous,
        do: System.put_env("SPIRAL_KINO_COMPILER_PORT", previous),
        else: System.delete_env("SPIRAL_KINO_COMPILER_PORT")
    end

    assert_raise ArgumentError, fn -> CompilerDaemon.check_port!(13805) end
  end

  test "queued clients share one compiler and do not overlap" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("daemon")
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
    dir = Spiral.Kino.TestHelpers.tmp_dir!("daemon-queue")

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

          {result, Process.get(:spiral_kino_queue_ms)}
        end)
      end

    results = Task.await_many(tasks, 5_000)
    assert Enum.all?(results, &match?({{:ok, "open"}, _}, &1))
    queues = Enum.map(results, fn {_result, queue} -> queue end)
    assert Enum.all?(queues, &is_integer/1)
    assert Enum.max(queues) - Enum.min(queues) >= 200
  end

  # Regression for the dice dib cells 23/24 (2026-10-03): every `_assert_eq` test cell compiles twice (the first attempt
  # fails with "Got: () Expected: i32" and is retried with `0i32` appended). Error and timeout replies carried no queue
  # time, so the first attempt's whole wait behind the other cells was charged to the cell budget (658 s "compile").
  for {outcome, reply, expected} <- [
        {"error", {:error, "Unification failure. Got: () Expected: i32"},
         {:error, "Unification failure. Got: () Expected: i32"}},
        {"timeout", {:error, :timeout}, {:error, :timeout}}
      ] do
    test "an #{outcome} reply still reports the time spent queued behind other compiles" do
      dir = Spiral.Kino.TestHelpers.tmp_dir!("daemon-queue-#{unquote(outcome)}")
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

          {result, Process.get(:spiral_kino_queue_ms)}
        end)

      assert {:ok, "open"} = Task.await(first, 5_000)
      assert {unquote(Macro.escape(expected)), queue} = Task.await(second, 5_000)
      assert is_integer(queue) and queue >= 350, "queue time not credited: #{inspect(queue)}"
    end
  end

  test "a compile that raises leaves the daemon up for the next cell" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("daemon-raise")

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

  test "an exit signal from a linked process does not stop the daemon" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("daemon-exit")

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
    dir = Spiral.Kino.TestHelpers.tmp_dir!("daemon-retire")
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
        :gen_tcp.send(sock, "spiral-kino\t1\t1\t#{stamp}\n")
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
end
