defmodule Xsim.Personas do
  @kinds %{"lurker" => :lurker, "fickle" => :fickle, "editor" => :editor, "breaker" => :breaker}
  @toggles 5
  @rewrites 3

  def parse(nil), do: []

  def parse(text) do
    text
    |> String.split(",", trim: true)
    |> Enum.flat_map(fn entry ->
      with [name, count] <- String.split(String.trim(entry), "="),
           {:ok, kind} <- Map.fetch(@kinds, name),
           {n, ""} when n >= 0 <- Integer.parse(count) do
        List.duplicate(kind, n)
      else
        _ -> raise ArgumentError, "persona #{inspect(entry)} is not <#{Enum.join(Map.keys(@kinds), "|")}>=<count>"
      end
    end)
  end

  def events(_posts, [], rand), do: {[], MapSet.new(), rand}

  def events(posts, personas, rand) do
    {streams, broken, rand} =
      personas
      |> Enum.with_index(1)
      |> Enum.reduce({[], MapSet.new(), rand}, fn {kind, n}, {streams, broken, rand} ->
        {stream, more, rand} = act(kind, "#{kind}#{n}", posts, rand)
        {[stream | streams], MapSet.union(broken, more), rand}
      end)

    {round_robin(Enum.reverse(streams), []), broken, rand}
  end

  defp act(:lurker, user, posts, rand) do
    {liked, rand} =
      Enum.reduce(posts, {[], rand}, fn {:post, id, _, _}, {acc, rand} ->
        {roll, rand} = :rand.uniform_s(2, rand)
        if roll == 1, do: {[{:like, id, user} | acc], rand}, else: {acc, rand}
      end)

    {Enum.reverse(liked), MapSet.new(), rand}
  end

  defp act(:fickle, _user, [], rand), do: {[], MapSet.new(), rand}

  defp act(:fickle, user, posts, rand) do
    {{:post, id, _, _}, rand} = pick(posts, rand)
    toggles = for k <- 1..@toggles, do: if(rem(k, 2) == 1, do: {:like, id, user}, else: {:unlike, id, user})
    {toggles, MapSet.new(), rand}
  end

  defp act(:editor, user, posts, rand) do
    case Enum.reject(posts, fn {:post, _, _, source} -> test_cell?(source) end) do
      [] ->
        {[], MapSet.new(), rand}

      editable ->
        {{:post, id, _, source}, rand} = pick(editable, rand)
        rewrites = for k <- 1..@rewrites, do: {:edit, id, source <> String.duplicate(" ", k) <> "\n"}
        {[{:like, id, user} | rewrites] ++ [{:edit, id, source}], MapSet.new(), rand}
    end
  end

  defp act(:breaker, user, posts, rand) do
    case Enum.filter(posts, fn {:post, _, _, source} -> test_cell?(source) and Xsim.Scenario.break_source(source) != source end) do
      [] ->
        {[], MapSet.new(), rand}

      tests ->
        {{:post, id, _, source}, rand} = pick(tests, rand)
        broken = Xsim.Scenario.break_source(source)
        {[{:like, id, user}, {:edit, id, broken}, {:edit, id, source}], MapSet.new([broken]), rand}
    end
  end

  defp pick(items, rand) do
    {i, rand} = :rand.uniform_s(length(items), rand)
    {Enum.at(items, i - 1), rand}
  end

  defp test_cell?(source), do: String.contains?(source, "///- --test")

  defp round_robin(streams, acc) do
    case Enum.reject(streams, &(&1 == [])) do
      [] -> Enum.reverse(acc)
      live -> round_robin(Enum.map(live, &tl/1), Enum.reverse(Enum.map(live, &hd/1)) ++ acc)
    end
  end
end
