defmodule XsimTest do
  use ExUnit.Case, async: true
  alias Xsim.{Executors, Invariants, Runner, Scenario}

  @cells [
    "inl square x = x * x",
    "inl cube x = x * square x",
    "///- --test\n\nsquare 3 |> _assert_eq 9",
    "inl quad x = square (square x)",
    "///- --test\n\ncube 2 |> _assert_eq 8",
    "///- --test\n\nquad 2 |> _assert_eq 16"
  ]

  defp verdicts(state, baseline \\ Executors.fake()), do: Map.new(Invariants.check(state, baseline))

  test "a correct runner keeps every invariant on shuffled, duplicated deliveries" do
    scenario = Scenario.from_cells(@cells, seed: 3, users: 5, edits: 3)

    for schedule <- 1..6 do
      state = Runner.run(Scenario.deliveries(scenario, schedule_seed: schedule, duplicates: 0.3), Executors.fake())
      assert Enum.all?(verdicts(state), fn {_, v} -> v == :ok end), inspect(verdicts(state))
      assert map_size(state.visible) > 0
    end
  end

  test "different delivery orders of the same events reach the same visible results" do
    scenario = Scenario.from_cells(@cells, seed: 5, users: 4, edits: 2)
    a = Runner.run(Scenario.deliveries(scenario, schedule_seed: 1), Executors.fake())
    b = Runner.run(Scenario.deliveries(scenario, schedule_seed: 9, duplicates: 0.5, window: 12), Executors.fake())
    assert Invariants.commute(a, b) == :ok
  end

  test "an executor leaking state between requests breaks sequential equivalence" do
    scenario = Scenario.from_cells(@cells, seed: 2, users: 3, edits: 1)
    state = Runner.run(Scenario.deliveries(scenario), Executors.fake(:leak), max_concurrency: 1)
    assert match?({:violations, _}, verdicts(state)[:sequential_equivalence])
  end

  test "results assigned to whoever asked, without cancelling, surface stale revisions" do
    slow = fn sources ->
      if String.ends_with?(List.last(sources), "\n"), do: :ok, else: Process.sleep(80)
      Executors.fake().(sources)
    end

    deliveries = [{0, {:post, "p0", nil, "inl a = 1"}}, {1, {:like, "p0", "u1"}}, {2, {:edit, "p0", "inl a = 1\n"}}]
    state = Runner.run(deliveries, slow, naive_visibility: true, cancel: false)
    assert match?({:violations, ["p0"]}, verdicts(state, slow)[:no_stale_results])
    assert verdicts(Runner.run(deliveries, slow), slow)[:no_stale_results] == :ok
  end

  test "forgetting finished results recompiles shared prefixes" do
    scenario = Scenario.from_cells(@cells, seed: 4, users: 3, edits: 0)
    state = Runner.run(Scenario.deliveries(scenario, duplicates: 0.0), Executors.fake(), rerun_completed: true)
    assert match?({:violations, _}, verdicts(state)[:one_compile_per_prefix])
  end

  test "withdrawn demand stays hidden unless results are assigned naively" do
    deliveries = [{0, {:post, "p0", nil, "inl a = 1"}}, {1, {:like, "p0", "u1"}}, {2, {:unlike, "p0", "u1"}}]
    slow = fn sources -> Process.sleep(80) && Executors.fake().(sources) end
    naive = Runner.run(deliveries, slow, naive_visibility: true, cancel: false)
    assert match?({:violations, ["p0"]}, verdicts(naive)[:withdrawn_demand_hidden])
    assert verdicts(Runner.run(deliveries, slow))[:withdrawn_demand_hidden] == :ok
  end

  test "an unlike delivered before its like does not resurrect demand" do
    deliveries = [{0, {:post, "p0", nil, "inl a = 1"}}, {2, {:unlike, "p0", "u1"}}, {1, {:like, "p0", "u1"}}]
    state = Runner.run(deliveries, Executors.fake())
    assert state.visible == %{}
  end

  test "several notebooks become interleaved author threads with breaking edits" do
    other = ["inl twice x = x + x", "///- --test\n\ntwice 4 |> _assert_eq 8"]
    scenario = Scenario.from_corpus([@cells, other], seed: 2, users: 3, edits: 1, breaking: 2)
    ids = for {:post, id, _, _} <- scenario.posts, do: id
    assert length(ids) == length(Enum.uniq(ids))
    assert Enum.any?(ids, &String.starts_with?(&1, "f0")) and Enum.any?(ids, &String.starts_with?(&1, "f1"))
    breaking = for {:edit, _, source} <- scenario.events, String.contains?(source, "--test"), do: source
    assert breaking != [] and Enum.all?(breaking, &Regex.match?(~r/_assert_eq (10|17|9|5)\s*$/, &1))
    state = Runner.run(Scenario.deliveries(scenario, duplicates: 0.2), Executors.fake())
    assert Enum.all?(verdicts(state), fn {_, v} -> v == :ok end)
  end

  test "editing a root re-keys its whole subtree and every visible result follows the new revision" do
    deliveries = [
      {0, {:post, "a", nil, "inl a = 1"}},
      {1, {:post, "b", "a", "inl b = a + 1"}},
      {2, {:post, "c", "b", "inl c = b + 1"}},
      {3, {:like, "c", "u1"}},
      {4, {:like, "b", "u2"}},
      {5, {:edit, "a", "inl a = 2"}}
    ]

    state = Runner.run(deliveries, Executors.fake())
    before = Runner.run(Enum.take(deliveries, 5), Executors.fake())
    assert Enum.all?(verdicts(state), fn {_, v} -> v == :ok end)
    assert state.visible["b"] != before.visible["b"] and state.visible["c"] != before.visible["c"]
    assert Xsim.World.sources(state.world, "c") == ["inl a = 2", "inl b = a + 1", "inl c = b + 1"]
  end

  test "cells split into 280-weight frames rebuild exactly, CJK and Hangul weigh double" do
    korean = String.duplicate("인라인 제곱 x = x * x\n", 30)
    frames = Xsim.Frames.split("p7", korean)
    assert Xsim.Frames.weight("a") == 1 and Xsim.Frames.weight("한") == 2 and Xsim.Frames.weight("中") == 2
    assert length(frames) > 1
    assert Enum.all?(frames, fn frame -> Xsim.Frames.weight(Xsim.Frames.frame_text("p7", frame)) <= 280 end)
    assert Xsim.Frames.rebuild(Enum.shuffle(frames)) == :unicode.characters_to_nfc_binary(korean)
  end

  test "framed posts delivered out of order and duplicated keep every invariant" do
    scenario = Scenario.from_cells(@cells ++ [String.duplicate("inl long_name_#{1} = 1\n", 40)], seed: 7, users: 3, edits: 2)
    framed = %{scenario | events: Xsim.Frames.explode_posts(scenario.events, 120)}
    state = Runner.run(Scenario.deliveries(framed, duplicates: 0.3, window: 20), Executors.fake())
    plain = Runner.run(Scenario.deliveries(scenario), Executors.fake())
    assert state.world.framed == length(scenario.posts)
    assert Enum.all?(verdicts(state), fn {_, v} -> v == :ok end)
    assert Invariants.commute(state, plain) == :ok
  end

  test "a saved delivery log replays to the same visible results" do
    scenario = Scenario.from_cells(@cells, seed: 9, users: 3, edits: 2, breaking: 1)
    deliveries = Scenario.deliveries(%{scenario | events: Xsim.Frames.explode_posts(scenario.events, 100)}, duplicates: 0.2)
    path = Path.join(System.tmp_dir!(), "xsim-log-#{System.unique_integer([:positive])}.jsonl")
    Xsim.Log.write(path, deliveries)
    assert Xsim.Log.read(path) == deliveries
    assert Invariants.commute(Runner.run(deliveries, Executors.fake()), Runner.run(Xsim.Log.read(path), Executors.fake())) == :ok
    File.rm!(path)
  end

  test "heavy churn on the root re-keys everything repeatedly and still keeps every invariant" do
    scenario = Scenario.from_cells(@cells, seed: 11, users: 4, edits: 0, churn: 12)
    root_edits = for {:edit, "p0", source} <- scenario.events, do: source
    assert length(root_edits) == 12
    state = Runner.run(Scenario.deliveries(scenario, duplicates: 0.2), Executors.fake(), max_concurrency: 2)
    assert Enum.all?(verdicts(state), fn {_, v} -> v == :ok end)
    assert hd(Xsim.World.sources(state.world, "p0")) == List.last(root_edits)
  end

  test "a false-pass executor is caught by the breaking-edit oracle" do
    scenario = Scenario.from_cells(@cells, seed: 13, users: 4, edits: 0, breaking: 3)
    assert MapSet.size(scenario.broken) > 0
    honest = fn sources -> if MapSet.member?(scenario.broken, List.last(sources)), do: %{status: :error, out: "failed"}, else: Executors.fake().(sources) end
    lenient = fn sources -> Executors.fake().(sources) end
    deliveries = Scenario.deliveries(scenario, duplicates: 0.0)
    assert Invariants.breaking_edits_fail(Runner.run(deliveries, honest), scenario.broken) == :ok
    assert match?({:violations, _}, Invariants.breaking_edits_fail(Runner.run(deliveries, lenient), scenario.broken))
  end

  test "personas toggle demand, revert rewrites and fix breaking edits back without breaking an invariant" do
    personas = Xsim.Personas.parse("lurker=2,fickle=3,editor=2,breaker=2")
    scenario = Scenario.from_cells(@cells, seed: 17, users: 2, edits: 0, personas: personas)
    originals = Map.new(for {:post, id, _, source} <- scenario.posts, do: {id, source})
    assert Enum.any?(scenario.events, &match?({:unlike, _, "fickle" <> _}, &1))
    assert Enum.any?(scenario.events, fn event -> match?({:edit, _, _}, event) and originals[elem(event, 1)] == elem(event, 2) end)
    assert MapSet.size(scenario.broken) > 0
    honest = fn sources -> if MapSet.member?(scenario.broken, List.last(sources)), do: %{status: :error, out: "failed"}, else: Executors.fake().(sources) end

    states =
      for schedule <- 1..4 do
        state = Runner.run(Scenario.deliveries(scenario, schedule_seed: schedule, duplicates: 0.3, window: 10), honest, max_concurrency: 2)
        assert Enum.all?(verdicts(state, honest), fn {_, v} -> v == :ok end), inspect(verdicts(state, honest))
        assert Invariants.breaking_edits_fail(state, scenario.broken) == :ok
        assert Enum.all?(Map.keys(state.world.posts), &(Xsim.World.current_source(state.world.posts[&1]) == originals[&1]))
        state
      end

    assert states |> Enum.chunk_every(2, 1, :discard) |> Enum.all?(fn [a, b] -> Invariants.commute(a, b) == :ok end)
    assert_raise ArgumentError, fn -> Xsim.Personas.parse("troll=1") end
  end

  test "evicting withdrawn results keeps only wanted prefixes in memory and recomputes on renewed demand" do
    deliveries = [
      {0, {:post, "a", nil, "inl a = 1"}},
      {1, {:post, "b", "a", "inl b = a + 1"}},
      {2, {:like, "b", "u1"}},
      {3, {:unlike, "b", "u1"}},
      {4, {:like, "a", "u2"}},
      {5, {:like, "b", "u3"}}
    ]

    kept = Runner.run(deliveries, Executors.fake(), max_concurrency: 1)
    freed = Runner.run(deliveries, Executors.fake(), max_concurrency: 1, evict: true)
    assert Enum.all?(verdicts(freed), fn {_, v} -> v == :ok end), inspect(verdicts(freed))
    assert Map.has_key?(verdicts(freed), :unwanted_results_freed) and not Map.has_key?(verdicts(kept), :unwanted_results_freed)
    assert Invariants.commute(kept, freed) == :ok
    personas = Xsim.Personas.parse("fickle=4,editor=2,breaker=2")
    scenario = Scenario.from_cells(@cells, seed: 21, users: 3, edits: 2, churn: 4, personas: personas)

    evictions =
      for schedule <- 1..4 do
        deliveries = Scenario.deliveries(scenario, schedule_seed: schedule, duplicates: 0.3, window: 10)
        kept = Runner.run(deliveries, Executors.fake(), max_concurrency: 2)
        freed = Runner.run(deliveries, Executors.fake(), max_concurrency: 2, evict: true)
        assert Enum.all?(verdicts(freed), fn {_, v} -> v == :ok end), inspect(verdicts(freed))
        assert Invariants.commute(kept, freed) == :ok
        assert map_size(freed.results) <= map_size(kept.results)
        freed.evicted |> Map.values() |> Enum.sum()
      end

    assert Enum.sum(evictions) > 0
  end

  test "a breaking edit changes a whole numeric literal, never only the last digits of a float" do
    assert Scenario.break_source("square 3 |> _assert_eq 9") == "square 3 |> _assert_eq 10"
    assert Scenario.break_source("|> _assert_approx_eq None 7.3890560989306495") == "|> _assert_approx_eq None 8.3890560989306495"
    assert Scenario.break_source("|> _assert_eq 42  \n") == "|> _assert_eq 43  \n"
  end

  test "breakers and --breaking only pick tests whose source a break actually changes, and personas survive an empty thread" do
    unbreakable = "///- --test\n\nvalue () |> _assert_eq pair.1"
    assert Scenario.break_source(unbreakable) == unbreakable
    scenario = Scenario.from_cells(["inl value () = 1i32", unbreakable], seed: 3, users: 2, edits: 0, breaking: 2, personas: Xsim.Personas.parse("breaker=3"))
    assert MapSet.size(scenario.broken) == 0
    assert Enum.all?(for({:edit, _, source} <- scenario.events, do: source), &(&1 == unbreakable))
    assert {[], broken, _} = Xsim.Personas.events([], Xsim.Personas.parse("lurker=1,fickle=2,editor=1,breaker=1"), :rand.seed_s(:exsss, {1, 2, 3}))
    assert MapSet.size(broken) == 0
  end

  test "a Rust panic's OS thread id does not make two runs of one revision differ" do
    run = fn id -> %{status: :error, out: "thread '<unnamed>' (#{id}) panicked at C:\\Temp/spiral_kino/17919-#{id}/main.rs:71:9"} end
    assert Invariants.comparable(run.(52388)) == Invariants.comparable(run.(27552))
    refute Invariants.comparable(run.(1)) == Invariants.comparable(%{status: :error, out: "thread '<unnamed>' (1) panicked at C:\\Temp/spiral_kino/17919-1/main.rs:72:9"})
  end

  test "replies and edits that arrive before their post wait for it" do
    deliveries = [{2, {:edit, "p1", "inl b = 2\n"}}, {3, {:like, "p1", "u1"}}, {1, {:post, "p1", "p0", "inl b = 2"}}, {0, {:post, "p0", nil, "inl a = 1"}}]
    state = Runner.run(deliveries, Executors.fake())
    assert [{"p1", {_, %{status: :ok}}}] = Map.to_list(state.visible)
    assert state.world.buffered >= 2
  end

  test "the daemon memory sampler reads a process tree's working set" do
    assert {3, 1464} = Xsim.DaemonMemory.parse_sample("3 1464\r")
    assert nil == Xsim.DaemonMemory.parse_sample("noise")

    if match?({:win32, _}, :os.type()) do
      {:ok, sampler} = Xsim.DaemonMemory.start_tree(String.to_integer(System.pid()), 200)
      reading = Enum.find_value(1..150, fn _ -> Process.sleep(100); r = Xsim.DaemonMemory.peak(sampler); if r.samples > 0, do: r end)
      Xsim.DaemonMemory.stop(sampler)
      assert reading.procs >= 1 and reading.peak_mb > 10
    end
  end
end