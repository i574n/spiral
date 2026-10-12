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
    root_edits = for {:edit, "p0", _} <- scenario.events, do: :edit
    assert length(root_edits) == 12
    state = Runner.run(Scenario.deliveries(scenario, duplicates: 0.2), Executors.fake(), max_concurrency: 2)
    assert Enum.all?(verdicts(state), fn {_, v} -> v == :ok end)
    assert map_size(state.results) > length(@cells)
  end

  test "replies and edits that arrive before their post wait for it" do
    deliveries = [{2, {:edit, "p1", "inl b = 2\n"}}, {3, {:like, "p1", "u1"}}, {1, {:post, "p1", "p0", "inl b = 2"}}, {0, {:post, "p0", nil, "inl a = 1"}}]
    state = Runner.run(deliveries, Executors.fake())
    assert [{"p1", {_, %{status: :ok}}}] = Map.to_list(state.visible)
    assert state.world.buffered >= 2
  end
end
