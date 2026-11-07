defmodule Spiral.Cells.CompilerDaemonRetireRaceTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.CompilerDaemon

  test "a call waiting in the mailbox when the retire check runs is answered before the daemon stops" do
    test = self()
    {:ok, pid} = CompilerDaemon.start_link(port: 0, on_retire: fn -> send(test, :retired) end, idle_ms: 60_000)
    port = GenServer.call(pid, :port)
    ref = Process.monitor(pid)

    :ok = :sys.suspend(pid)
    :sys.replace_state(pid, fn state -> %{state | retiring: System.monotonic_time(:millisecond) - 10_000} end)
    send(pid, :retire_check)
    caller =
      Task.async(fn ->
        try do
          GenServer.call(pid, :port, 5_000)
        catch
          :exit, reason -> {:exit, reason}
        end
      end)

    wait_for_mailbox(pid, 2)
    :ok = :sys.resume(pid)

    assert Task.await(caller, 6_000) == port
    assert_receive :retired, 5_000
    assert_receive {:DOWN, ^ref, :process, ^pid, :normal}, 5_000
  end

  defp wait_for_mailbox(pid, count) do
    case Process.info(pid, :message_queue_len) do
      {:message_queue_len, n} when n >= count -> :ok
      _ ->
        Process.sleep(5)
        wait_for_mailbox(pid, count)
    end
  end
end
