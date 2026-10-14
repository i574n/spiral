defmodule Xsim.Invariants do
  alias Xsim.World

  def check(state, baseline) do
    wanted = World.wanted(state.world)

    [
      {:sequential_equivalence, sequential_equivalence(state, wanted, baseline)},
      {:no_stale_results, no_stale(state, wanted)},
      {:one_compile_per_prefix, one_compile(state)},
      {:withdrawn_demand_hidden, withdrawn_hidden(state, wanted)}
    ] ++ if(state.evicting, do: [{:unwanted_results_freed, unwanted_freed(state, wanted)}], else: [])
  end

  def breaking_edits_fail(state, broken) do
    bad =
      for {id, {_key, result}} <- state.visible,
          post = state.world.posts[id],
          MapSet.member?(broken, World.current_source(post)),
          comparable(result) |> elem(0) == :ok,
          do: id

    verdict(bad)
  end

  def commute(a, b) do

    va = Map.new(a.visible, fn {id, {_key, result}} -> {id, comparable(result)} end)
    vb = Map.new(b.visible, fn {id, {_key, result}} -> {id, comparable(result)} end)
    if va == vb, do: :ok, else: {:violations, Enum.take(for({id, r} <- va, vb[id] != r, do: id), 5)}
  end

  defp sequential_equivalence(state, wanted, baseline) do
    bad =
      for {id, {key, result}} <- state.visible, wanted[id] == key, comparable(baseline.(World.sources(state.world, id))) != comparable(result), do: id

    verdict(bad)
  end

  defp no_stale(state, wanted) do
    bad = for {id, {key, _}} <- state.visible, wanted[id] != key, do: id
    verdict(bad)
  end

  defp one_compile(state) do
    bad = for {key, n} <- state.starts, n - Map.get(state.cancelled, key, 0) - Map.get(state.evicted, key, 0) > 1, do: key
    verdict(bad)
  end

  defp unwanted_freed(state, wanted) do
    live = MapSet.new(Map.values(wanted))
    verdict(for {key, _} <- state.results, not MapSet.member?(live, key), do: key)
  end

  defp withdrawn_hidden(state, wanted) do
    bad = for {id, _} <- state.visible, not Map.has_key?(wanted, id), do: id
    verdict(bad)
  end

  defp verdict([]), do: :ok
  defp verdict(bad), do: {:violations, Enum.take(bad, 5)}

  def comparable(%{status: status, out: out}) do
    out = Regex.replace(~r/spiral_kino[\\\/][0-9]+-[0-9]+/, out, "spiral_kino/_")
    {status, Regex.replace(~r/(thread '[^']*') \([0-9]+\) panicked/, out, "\\1 (_) panicked")}
  end
  def comparable(other), do: other
end
