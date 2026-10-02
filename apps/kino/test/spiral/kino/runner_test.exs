defmodule Spiral.Kino.RunnerTest do
  use ExUnit.Case, async: false

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

  test "captures stdout and stderr and returns the exit status", %{dir: dir} do
    script =
      script!(dir, "exit3", """
      main(_) ->
          io:format("to stdout~n"),
          io:format(standard_error, "to stderr~n", []),
          halt(3).
      """)

    assert {:ok, %{exit_status: 3, output: output, os_pid: pid}} =
             Runner.run(escript(), [script], timeout: 30_000)

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
               timeout: 30_000,
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
          timeout: 8_000,
          on_start: fn os_pid -> send(test_pid, {:child, os_pid}) end
        )
      end)

    assert_receive {:child, child_pid}, 10_000
    grandchild_pid = wait_until(fn -> read_pid(pidfile) end)
    assert grandchild_pid, "grandchild never started"
    assert Runner.os_pid_alive?(grandchild_pid)

    assert {:error, {:timeout, %{timeout: 8_000, output: output}}} =
             Task.await(task, 60_000)

    assert output =~ "parent started"

    assert wait_until(fn -> not Runner.os_pid_alive?(grandchild_pid) end, 10_000),
           "grandchild #{grandchild_pid} survived the timeout"

    assert wait_until(fn -> not Runner.os_pid_alive?(child_pid) end, 10_000),
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

    assert_receive {:child, child_pid}, 10_000
    grandchild_pid = wait_until(fn -> read_pid(pidfile) end)
    assert grandchild_pid, "grandchild never started"

    Process.exit(caller, :kill)

    assert wait_until(fn -> not Runner.os_pid_alive?(grandchild_pid) end, 10_000),
           "grandchild #{grandchild_pid} survived the caller's death"

    assert wait_until(fn -> not Runner.os_pid_alive?(child_pid) end, 10_000),
           "child #{child_pid} survived the caller's death"
  end
end
