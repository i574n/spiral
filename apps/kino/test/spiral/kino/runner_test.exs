defmodule Spiral.Kino.RunnerTest do
  use ExUnit.Case, async: false

  @moduletag timeout: 300_000

  import Spiral.Kino.TestHelpers

  alias Spiral.Kino.Runner

  setup do
    {:ok, dir: tmp_dir!("runner")}
  end

  defp slow_tree!(dir) do
    pidfile = Path.join(dir, "grandchild.pid")

    grandchild =
      script!(dir, "grandchild", """
      main([PidFile]) ->
          ok = file:write_file(PidFile, os:getpid()),
          timer:sleep(infinity).
      """)

    parent =
      script!(dir, "parent", """
      main([Escript, Grandchild, PidFile]) ->
          io:format("parent started~n"),
          _Port = open_port({spawn_executable, Escript},
                            [{args, [Grandchild, PidFile]}, exit_status, hide]),
          timer:sleep(infinity).
      """)

    {[parent, escript(), grandchild, pidfile], pidfile}
  end

  test "the last line a program prints before it exits is never lost", %{dir: dir} do
    script =
      script!(dir, "burst", """
      main(_) ->
          lists:foreach(fun(I) -> io:format("line ~p~n", [I]) end, lists:seq(1, 2000)),
          io:format("SPIRAL_KINO_VALUE:49~n"),
          halt(0).
      """)

    for _ <- 1..10 do
      assert {:ok, %{exit_status: 0, output: output}} = Runner.run(escript(), [script], timeout: 60_000)
      assert String.ends_with?(String.replace(output, "\r\n", "\n"), "SPIRAL_KINO_VALUE:49\n")
    end
  end

  if match?({:win32, _}, :os.type()) do
    test "a program that prints and exits at once keeps its output under concurrent runs (Windows port drops it)" do
      shell = System.get_env("ComSpec") || System.find_executable("cmd.exe")

      outputs =
        1..300
        |> Task.async_stream(fn _ -> Runner.run(shell, ["/d", "/c", "echo", "ready"], timeout: 30_000) end, max_concurrency: 24, timeout: :infinity)
        |> Enum.map(fn {:ok, {:ok, %{exit_status: 0, output: output}}} -> output end)

      assert Enum.frequencies(outputs) == %{"ready\r\n" => 300}
    end

    test "capture quotes words cmd would split and leaves cmd-unsafe arguments to the direct port" do
      assert Runner.captured_command_line("C:/bin/cell.exe", ["a b", "", "x=1", "/flag"], "C:/tmp/out.txt") =~
               ~s|/d /v:off /s /c "> "C:\\tmp\\out.txt" 2>&1 "C:\\bin\\cell.exe" "a b" "" "x=1" /flag"|

      assert Runner.capture_file("C:/bin/cell.exe", ["100%"]) == nil
      assert Runner.capture_file("C:/bin/cell.exe", [~s|say "hi"|]) == nil
    end
  end

  test "captures stdout and stderr and returns the exit status", %{dir: dir} do
    script =
      script!(dir, "exit3", """
      main(_) ->
          io:format("to stdout~n"),
          io:format(standard_error, "to stderr~n", []),
          halt(3).
      """)

    assert {:ok, %{exit_status: 3, output: output, os_pid: pid}} =
             Runner.run(escript(), [script], timeout: 120_000)

    assert output =~ "to stdout"
    assert output =~ "to stderr"
    assert is_integer(pid)
  end

  test "passes env and cd", %{dir: dir} do
    script =
      script!(dir, "env", """
      main(_) ->
          {ok, Cwd} = file:get_cwd(),
          io:format("~s|~s~n", [os:getenv("SPIRAL_KINO_TEST_VAR"), filename:basename(Cwd)]).
      """)

    cwd = Path.join(dir, "the_cwd")
    File.mkdir_p!(cwd)

    assert {:ok, %{exit_status: 0, output: output}} =
             Runner.run(escript(), [script],
               timeout: 120_000,
               cd: cwd,
               env: [{"SPIRAL_KINO_TEST_VAR", "hello"}]
             )

    assert output =~ "hello|the_cwd"
  end

  test "reports a missing executable" do
    assert {:error, {:spawn_failed, {:executable_not_found, _}}} =
             Runner.run("definitely-not-a-real-executable-spiral-kino", [])
  end

  test "timeout kills the whole process tree (including grandchildren)", %{dir: dir} do
    {args, pidfile} = slow_tree!(dir)
    test_pid = self()

    task =
      Task.async(fn ->
        Runner.run(escript(), args,
          timeout: 40_000,
          on_start: fn os_pid -> send(test_pid, {:child, os_pid}) end
        )
      end)

    assert_receive {:child, child_pid}, 60_000
    grandchild_pid = wait_until(fn -> read_pid(pidfile) end, 60_000)
    assert grandchild_pid, "grandchild never started"
    assert Runner.os_pid_alive?(grandchild_pid)

    assert {:error, {:timeout, %{timeout: 40_000, output: output}}} =
             Task.await(task, 120_000)

    assert output =~ "parent started"

    assert wait_until(fn -> not Runner.os_pid_alive?(grandchild_pid) end, 30_000),
           "grandchild #{grandchild_pid} survived the timeout"

    assert wait_until(fn -> not Runner.os_pid_alive?(child_pid) end, 30_000),
           "child #{child_pid} survived the timeout"
  end

  test "killing the caller kills the process tree", %{dir: dir} do
    {args, pidfile} = slow_tree!(dir)
    test_pid = self()

    caller =
      spawn(fn ->
        Runner.run(escript(), args,
          timeout: :infinity,
          on_start: fn os_pid -> send(test_pid, {:child, os_pid}) end
        )
      end)

    assert_receive {:child, child_pid}, 60_000
    grandchild_pid = wait_until(fn -> read_pid(pidfile) end, 60_000)
    assert grandchild_pid, "grandchild never started"

    Process.exit(caller, :kill)

    assert wait_until(fn -> not Runner.os_pid_alive?(grandchild_pid) end, 30_000),
           "grandchild #{grandchild_pid} survived the caller's death"

    assert wait_until(fn -> not Runner.os_pid_alive?(child_pid) end, 30_000),
           "child #{child_pid} survived the caller's death"
  end
end
