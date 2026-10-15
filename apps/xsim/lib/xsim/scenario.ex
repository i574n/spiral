defmodule Xsim.Scenario do
  defstruct seed: 1, posts: [], events: [], broken: MapSet.new()

  @type event ::
          {:post, String.t(), String.t() | nil, String.t()}
          | {:edit, String.t(), String.t()}
          | {:like, String.t(), String.t()}
          | {:unlike, String.t(), String.t()}
          | {:delete, String.t()}

  def from_corpus(threads, opts \\ []) do
    scenarios =
      threads
      |> Enum.with_index()
      |> Enum.map(fn {cells, k} -> from_cells(cells, Keyword.merge(opts, prefix: "f#{k}", seed: Keyword.get(opts, :seed, 1) + k)) end)

    events = scenarios |> Enum.map(& &1.events) |> interleave([])
    broken = scenarios |> Enum.map(& &1.broken) |> Enum.reduce(MapSet.new(), &MapSet.union/2)
    %__MODULE__{seed: Keyword.get(opts, :seed, 1), posts: Enum.flat_map(scenarios, & &1.posts), events: events, broken: broken}
  end

  defp interleave(lists, acc) do
    case Enum.reject(lists, &(&1 == [])) do
      [] -> Enum.reverse(acc)
      live -> interleave(Enum.map(live, &tl/1), Enum.reverse(Enum.map(live, &hd/1)) ++ acc)
    end
  end

  def from_cells(cells, opts \\ []) do
    seed = Keyword.get(opts, :seed, 1)
    users = Keyword.get(opts, :users, 8)
    edits = Keyword.get(opts, :edits, 3)
    rand = :rand.seed_s(:exsss, {seed, seed * 7 + 1, seed * 13 + 3})

    {posts, _, _} =
      Enum.reduce(cells, {[], nil, 0}, fn source, {acc, trunk, n} ->
        id = "#{Keyword.get(opts, :prefix, "")}p#{n}"
        test? = String.starts_with?(String.trim_leading(source), "///- --test")
        parent = trunk
        next_trunk = if test? and Keyword.get(opts, :branch_tests, false), do: trunk, else: id
        {[{:post, id, parent, source} | acc], next_trunk, n + 1}
      end)

    posts = Enum.reverse(posts)
    ids = Enum.map(posts, fn {:post, id, _, _} -> id end)
    {likes, rand} = likes(ids, users, rand)
    {unlikes, rand} = unlikes(likes, rand)
    {edit_events, rand} = edits(posts, edits, rand)
    {breaking, rand} = breaking_edits(posts, Keyword.get(opts, :breaking, 0), rand)
    {persona_events, persona_broken, _rand} = Xsim.Personas.events(posts, Keyword.get(opts, :personas, []), rand)
    churn = churn(posts, Keyword.get(opts, :churn, 0))
    interactions = weave(likes ++ edit_events ++ breaking ++ unlikes ++ persona_events, churn)
    broken = MapSet.union(MapSet.new(for {:edit, _, source} <- breaking, do: source), persona_broken)
    %__MODULE__{seed: seed, posts: posts, events: posts ++ interactions, broken: broken}
  end

  defp churn(_posts, 0), do: []
  defp churn([], _count), do: []

  defp churn([{:post, root, _, source} | _], count) do
    for k <- 1..count, do: {:edit, root, source <> String.duplicate("\n", rem(k, 3) + 1)}
  end

  defp weave(events, []), do: events

  defp weave(events, churn) do
    step = max(div(length(events), length(churn) + 1), 1)
    {woven, rest} = Enum.reduce(Enum.with_index(events), {[], churn}, fn
      {event, i}, {acc, [edit | more]} when rem(i + 1, step) == 0 -> {[edit, event | acc], more}
      {event, _}, {acc, rest} -> {[event | acc], rest}
    end)
    Enum.reverse(acc_rest(woven, rest))
  end

  defp acc_rest(woven, rest), do: Enum.reverse(rest) ++ woven

  defp likes(ids, users, rand) do
    Enum.reduce(ids, {[], rand}, fn id, {acc, rand} ->
      {k, rand} = :rand.uniform_s(users, rand)
      who = for u <- 1..k, do: {:like, id, "u#{u}"}
      {Enum.reverse(who, acc), rand}
    end)
    |> then(fn {acc, rand} -> {Enum.reverse(acc), rand} end)
  end

  defp unlikes(likes, rand) do
    Enum.reduce(likes, {[], rand}, fn {:like, id, user}, {acc, rand} ->
      {roll, rand} = :rand.uniform_s(10, rand)
      if roll == 1, do: {[{:unlike, id, user} | acc], rand}, else: {acc, rand}
    end)
    |> then(fn {acc, rand} -> {Enum.reverse(acc), rand} end)
  end

  defp edits(posts, count, rand) do
    editable = Enum.filter(posts, fn {:post, _, _, source} -> not String.contains?(source, "///- --test") end)

    Enum.reduce(1..max(count, 1)//1, {[], rand}, fn _, {acc, rand} ->
      if editable == [] or count == 0 do
        {acc, rand}
      else
        {i, rand} = :rand.uniform_s(length(editable), rand)
        {:post, id, _, source} = Enum.at(editable, i - 1)
        {acc ++ [{:edit, id, source <> "\n"}], rand}
      end
    end)
  end

  defp breaking_edits(posts, count, rand) do
    tests = Enum.filter(posts, fn {:post, _, _, source} -> String.contains?(source, "///- --test") and break_source(source) != source end)

    Enum.reduce(1..max(count, 1)//1, {[], rand}, fn _, {acc, rand} ->
      if tests == [] or count == 0 do
        {acc, rand}
      else
        {i, rand} = :rand.uniform_s(length(tests), rand)
        {:post, id, _, source} = Enum.at(tests, i - 1)
        {acc ++ [{:edit, id, break_source(source)}], rand}
      end
    end)
  end

  def break_source(source) do
    Regex.replace(~r/(?<![\d.])(\d+)((?:\.\d+)?\s*)$/, source, fn _, whole, rest -> Integer.to_string(String.to_integer(whole) + 1) <> rest end)
  end

  def deliveries(%__MODULE__{events: events}, opts \\ []) do
    seed = Keyword.get(opts, :schedule_seed, 1)
    duplicates = Keyword.get(opts, :duplicates, 0.1)
    window = Keyword.get(opts, :window, 6)
    rand = :rand.seed_s(:exsss, {seed, seed * 31 + 5, seed * 17 + 11})
    numbered = Enum.with_index(events, fn event, i -> {i, event} end)

    {keyed, rand} =
      Enum.reduce(numbered, {[], rand}, fn {i, event}, {acc, rand} ->
        {jitter, rand} = :rand.uniform_s(window, rand)
        {roll, rand} = :rand.uniform_s(1000, rand)
        copies = if roll <= duplicates * 1000, do: 2, else: 1
        {Enum.reverse(for(c <- 1..copies, do: {i + jitter + c, i, event}), acc), rand}
      end)

    _ = rand
    keyed |> Enum.sort() |> Enum.map(fn {_, i, event} -> {i, event} end)
  end
end
