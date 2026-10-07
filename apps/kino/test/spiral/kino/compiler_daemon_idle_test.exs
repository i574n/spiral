defmodule Spiral.Kino.CompilerDaemonIdleTest do
  use ExUnit.Case, async: true

  alias Spiral.Kino.CompilerDaemon

  # A serving daemon (one with on_retire) retires by itself after idle_ms without a compile, so an idle daemon never
  # holds its compiler (GBs) for hours; an in-process server (no on_retire) never idles out.
  test "a serving daemon retires after its idle time" do
    test = self()

    {:ok, pid} =
      CompilerDaemon.start_link(
        port: 0,
        on_retire: fn -> send(test, :retired) end,
        idle_ms: 100,
        idle_check_ms: 50
      )

    ref = Process.monitor(pid)
    assert_receive :retired, 5_000
    assert_receive {:DOWN, ^ref, :process, ^pid, :normal}, 5_000
  end

  test "a server without on_retire never idles out" do
    {:ok, pid} = CompilerDaemon.start_link(port: 0, idle_ms: 50, idle_check_ms: 20)
    Process.sleep(300)
    assert Process.alive?(pid)
    GenServer.stop(pid)
  end
end
