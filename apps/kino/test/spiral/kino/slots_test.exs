defmodule Spiral.Kino.SlotsTest do
  use ExUnit.Case, async: false

  alias Spiral.Kino.{Result, Slots}

  @rust "fn main() {\n    std::process::exit(main.join().unwrap());\n}\n"

  test "no more than the limit run at once and the wait is reported" do
    server = start_supervised!({Slots, limit: 1})
    {:ok, agent} = Agent.start_link(fn -> [] end)

    work = fn name ->
      Slots.run(
        fn ->
          started = System.monotonic_time(:millisecond)
          Process.sleep(150)
          Agent.update(agent, &[{started, System.monotonic_time(:millisecond), name} | &1])
          name
        end,
        server: server
      )
    end

    results =
      [Task.async(fn -> work.(:a) end), Task.async(fn -> work.(:b) end)] |> Task.await_many(5_000)

    assert Enum.sort(Enum.map(results, &elem(&1, 0))) == [:a, :b]
    assert Enum.max(Enum.map(results, &elem(&1, 1))) >= 100

    [{_, first_done, _}, {second_start, _, _}] = Agent.get(agent, &Enum.sort/1)
    assert second_start + 5 >= first_done
  end

  test "a holder that dies gives its slot back" do
    server = start_supervised!({Slots, limit: 1})
    parent = self()

    holder =
      spawn(fn ->
        Slots.run(
          fn ->
            send(parent, :holding)
            Process.sleep(:infinity)
          end,
          server: server
        )
      end)

    assert_receive :holding, 2_000
    Process.exit(holder, :kill)

    assert {:ok, _waited} =
             Task.await(Task.async(fn -> Slots.run(fn -> :ok end, server: server) end), 2_000)

    assert %{held: 0, waiting: 0} = GenServer.call(server, :status)
  end

  test "time spent waiting for a slot does not count against the cell timeout" do
    holders = Slots.limit()
    parent = self()

    blockers =
      for _ <- 1..holders do
        spawn(fn ->
          Slots.run(fn ->
            send(parent, :holding)

            receive do
              :release -> :ok
            end
          end)
        end)
      end

    for _ <- 1..holders, do: assert_receive(:holding, 2_000)

    releaser =
      spawn(fn ->
        receive do
          :go -> Process.sleep(2_500)
        end

        Enum.each(blockers, &send(&1, :release))
      end)

    execute = fn _ctx ->
      left = Process.get(:spiral_kino_deadline) - System.monotonic_time(:millisecond)
      send(parent, {:left, left})
      {:ok, %{exit_status: 0, output: "SPIRAL_KINO_VALUE:7\n", duration_ms: 1}}
    end

    assert {:ok, %Result{value: "7", phases: phases}} =
             Spiral.Kino.run("7i32",
               compile: fn _ ->
                 send(releaser, :go)
                 {:ok, @rust}
               end,
               rustc: fn _ -> :ok end,
               execute: execute,
               timeout: 2_000
             )

    assert_receive {:left, left}
    assert left > 0
    assert phases.slot_wait_ms >= 2_400
    assert Map.has_key?(phases, :compile_ms)
    assert Map.has_key?(phases, :rustc_ms)
    assert Map.has_key?(phases, :run_ms)
  end
end
