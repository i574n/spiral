defmodule Spiral.Cells.CompilerDaemonStatusTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.CompilerDaemon

  test "an idle daemon retires early when free memory is under the threshold" do
    test = self()
    System.put_env("SPIRAL_CELLS_COMPILER_RETIRE_FREE_MB", "100000000")

    try do
      {:ok, pid} =
        CompilerDaemon.start_link(
          port: 0,
          on_retire: fn -> send(test, :retired) end,
          idle_ms: 60_000,
          idle_check_ms: 50
        )

      ref = Process.monitor(pid)
      assert_receive :retired, 5_000
      assert_receive {:DOWN, ^ref, :process, ^pid, :normal}, 5_000
    after
      System.delete_env("SPIRAL_CELLS_COMPILER_RETIRE_FREE_MB")
    end
  end

  test "the status line reports pid, stamp, idle minutes, queue and retiring" do
    {:ok, pid} = CompilerDaemon.start_link(port: 0)
    port = GenServer.call(pid, :port)
    {:ok, sock} = :gen_tcp.connect({127, 0, 0, 1}, port, [:binary, packet: :line, active: false], 2_000)
    :ok = :gen_tcp.send(sock, "status\n")
    {:ok, line} = :gen_tcp.recv(sock, 0, 5_000)
    :gen_tcp.close(sock)
    GenServer.stop(pid)

    assert ["status", os_pid, _stamp, "0", "0", "false"] = line |> String.trim() |> String.split("\t")
    assert os_pid == System.pid()
  end
end
