defmodule Xsim.Invariants do
  alias Xsim.World

  def check(state, baseline) do
    wanted = World.wanted(state.world)

    [
      {:sequential_equivalence, sequential_equivalence(state, wanted, baseline)},
      {:no_stale_results, no_stale(state, wanted)},
      {:one_compile_per_prefix, one_compile(state)},
      {:withdrawn_demand_hidden, withdrawn_hidden(state, wanted)}
    ]
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
    bad = for {key, n} <- state.starts, n - Map.get(state.cancelled, key, 0) > 1, do: key
    verdict(bad)
  end

  defp withdrawn_hidden(state, wanted) do
    bad = for {id, _} <- state.visible, not Map.has_key?(wanted, id), do: id
    verdict(bad)
  end

  defp verdict([]), do: :ok
  defp verdict(bad), do: {:violations, Enum.take(bad, 5)}

  def comparable(%{status: status, out: out}), do: {status, Regex.replace(~r/spiral_kino[\\\/][0-9]+-[0-9]+/, out, "spiral_kino/_")}
  def comparable(other), do: other
end
