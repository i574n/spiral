defmodule Spiral.Cells.CompilerPoolTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.CompilerPool

  defmodule SlowWorker do
    use GenServer

    def start_link(log), do: GenServer.start_link(__MODULE__, log)

    @impl true
    def init(log), do: {:ok, log}

    @impl true
    def handle_call({:compile, req}, _from, log) do
      Process.sleep(req.ms)
      Agent.update(log, &(&1 ++ [req.id]))
      {:reply, {:compiled, {:ok, req.id}, req.ms}, log}
    end
  end

  defp pool(log, opts) do
    {:ok, first} = SlowWorker.start_link(log)
    starter = fn -> SlowWorker.start_link(log) end
    {:ok, pool} = CompilerPool.start_link([first: first, start_worker: starter, free_mb: fn -> nil end] ++ opts)
    pool
  end

  defp submit(pool, client, id, ms) do
    Task.async(fn -> CompilerPool.compile(pool, client, %{id: id, ms: ms}) end)
  end

  defp submit_queued(pool, client, id, ms) do
    %{queued: before} = CompilerPool.stats(pool)
    task = submit(pool, client, id, ms)
    Spiral.Cells.TestHelpers.wait_until(fn -> CompilerPool.stats(pool).queued > before end, 5_000, 2)
    task
  end

  test "one compiler serves clients in turn: a client with one request does not wait behind another's whole batch" do
    {:ok, log} = Agent.start_link(fn -> [] end)
    pool = pool(log, max_workers: 1, fair: true)
    busy = submit(pool, "a", "a0", 1_000)
    Spiral.Cells.TestHelpers.wait_until(fn -> CompilerPool.stats(pool).idle == 0 end, 5_000, 2)
    batch = for i <- 1..4, do: submit_queued(pool, "a", "a#{i}", 20)
    lone = submit_queued(pool, "b", "b1", 20)
    Task.await_many([busy, lone | batch])
    assert Agent.get(log, & &1) == ["a0", "a1", "b1", "a2", "a3", "a4"]
  end

  test "first come first served keeps arrival order when fairness is off" do
    {:ok, log} = Agent.start_link(fn -> [] end)
    pool = pool(log, max_workers: 1, fair: false)
    busy = submit(pool, "a", "a0", 1_000)
    Spiral.Cells.TestHelpers.wait_until(fn -> CompilerPool.stats(pool).idle == 0 end, 5_000, 2)
    batch = for i <- 1..2, do: submit_queued(pool, "a", "a#{i}", 20)
    lone = submit_queued(pool, "b", "b1", 20)
    Task.await_many([busy, lone | batch])
    assert Agent.get(log, & &1) == ["a0", "a1", "a2", "b1"]
  end

  test "the pool grows to max_workers under load and runs compiles side by side" do
    {:ok, log} = Agent.start_link(fn -> [] end)
    pool = pool(log, max_workers: 3, fair: true)
    started = System.monotonic_time(:millisecond)
    tasks = for i <- 1..3, do: submit(pool, "c#{i}", "c#{i}", 200)
    assert Enum.map(Task.await_many(tasks), fn {:compiled, {:ok, id}, _} -> id end) == ["c1", "c2", "c3"]
    assert System.monotonic_time(:millisecond) - started < 500
    assert %{peak_workers: 3, served: 3, queued: 0} = CompilerPool.stats(pool)
  end

  test "a pool without free memory for another compiler stays at the compilers it has" do
    {:ok, log} = Agent.start_link(fn -> [] end)
    {:ok, first} = SlowWorker.start_link(log)
    {:ok, pool} = CompilerPool.start_link(first: first, max_workers: 3, start_worker: fn -> SlowWorker.start_link(log) end, free_mb: fn -> 100 end)
    Task.await_many(for i <- 1..3, do: submit(pool, "d#{i}", "d#{i}", 30))
    assert %{peak_workers: 1, served: 3} = CompilerPool.stats(pool)
  end

  test "the real daemon pools up to 3 compilers fairly by default; off or a test daemon keeps one" do
    assert %{max_workers: 3, fair: true} = CompilerPool.settings("auto")
    assert %{max_workers: 1, fair_single: false} = CompilerPool.settings(nil)
    assert %{max_workers: 1, fair_single: false} = CompilerPool.settings("off")
    assert %{max_workers: 1, fair_single: true} = CompilerPool.settings("1")
    assert %{max_workers: 2} = CompilerPool.settings("2")
  end
end
