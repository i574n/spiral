defmodule Xsim.World do
  defstruct seen: MapSet.new(),
            posts: %{},
            pending: [],
            demand: %{},
            clock: %{},
            keys: %{},
            children: %{},
            dirty: MapSet.new(),
            frames: %{},
            framed: 0,
            duplicates: 0,
            buffered: 0

  def new, do: %__MODULE__{}

  def apply_delivery(%__MODULE__{} = world, {index, event}) do
    if MapSet.member?(world.seen, index) do
      %{world | duplicates: world.duplicates + 1}
    else
      world = %{world | seen: MapSet.put(world.seen, index)}

      case apply_event(world, index, event) do
        {:applied, world} -> drain(world)
        :waiting -> %{world | pending: [{index, event} | world.pending], buffered: world.buffered + 1}
      end
    end
  end

  defp drain(world) do
    attempt =
      Enum.find_value(world.pending, fn {index, event} = item ->
        case apply_event(world, index, event) do
          {:applied, next} -> {item, next}
          :waiting -> nil
        end
      end)

    case attempt do
      nil -> world
      {item, next} -> drain(%{next | pending: List.delete(next.pending, item)})
    end
  end

  defp apply_event(world, index, {:post, id, parent, source}) do
    if parent == nil or Map.has_key?(world.posts, parent) do
      world = %{
        world
        | posts: Map.put(world.posts, id, %{parent: parent, revisions: %{index => source}, deleted: false}),
          children: if(parent, do: Map.update(world.children, parent, [id], &[id | &1]), else: world.children)
      }

      {:applied, rekey(world, id)}
    else
      :waiting
    end
  end

  defp apply_event(world, index, {:frame, id, parent, k, n, body}) do
    entry = Map.get(world.frames, id, %{parts: %{}, first: index})
    entry = %{entry | parts: Map.put(entry.parts, k, {k, n, body}), first: min(entry.first, index)}

    if map_size(entry.parts) == n do
      world = %{world | frames: Map.delete(world.frames, id), framed: world.framed + 1}
      post = {:post, id, parent, Xsim.Frames.rebuild(Map.values(entry.parts))}

      case apply_event(world, entry.first, post) do
        {:applied, world} -> {:applied, world}
        :waiting -> {:applied, %{world | pending: [{entry.first, post} | world.pending], buffered: world.buffered + 1}}
      end
    else
      {:applied, %{world | frames: Map.put(world.frames, id, entry)}}
    end
  end

  defp apply_event(world, index, {:edit, id, source}) do
    with_post(world, id, fn world, post -> rekey(%{world | posts: Map.put(world.posts, id, %{post | revisions: Map.put(post.revisions, index, source)})}, id) end)
  end

  defp apply_event(world, _index, {:delete, id}) do
    with_post(world, id, fn world, post -> touch(%{world | posts: Map.put(world.posts, id, %{post | deleted: true})}, id) end)
  end

  defp apply_event(world, index, {kind, id, user}) when kind in [:like, :unlike] do
    if Map.has_key?(world.posts, id) do
      case Map.get(world.clock, {id, user}) do
        {seen, _} when seen > index ->
          {:applied, world}

        _ ->
          users = Map.get(world.demand, id, MapSet.new())
          users = if kind == :like, do: MapSet.put(users, user), else: MapSet.delete(users, user)
          world = %{world | demand: Map.put(world.demand, id, users), clock: Map.put(world.clock, {id, user}, {index, kind})}
          {:applied, touch(world, id)}
      end
    else
      :waiting
    end
  end

  defp with_post(world, id, f) do
    case Map.fetch(world.posts, id) do
      {:ok, post} -> {:applied, f.(world, post)}
      :error -> :waiting
    end
  end

  defp touch(world, id), do: %{world | dirty: MapSet.put(world.dirty, id)}

  defp rekey(world, id) do
    post = Map.fetch!(world.posts, id)
    parent_key = if post.parent, do: Map.fetch!(world.keys, post.parent), else: ""
    key = :crypto.hash(:sha256, [parent_key, 0, current_source(post)]) |> Base.encode16(case: :lower) |> binary_part(0, 16)
    world = touch(%{world | keys: Map.put(world.keys, id, key)}, id)
    Enum.reduce(Map.get(world.children, id, []), world, &rekey(&2, &1))
  end

  def current_source(post), do: post.revisions |> Enum.max_by(&elem(&1, 0)) |> elem(1)

  def chain(world, id), do: chain(world, id, [])

  defp chain(_world, nil, acc), do: acc

  defp chain(world, id, acc) do
    post = Map.fetch!(world.posts, id)
    chain(world, post.parent, [{id, current_source(post)} | acc])
  end

  def sources(world, id), do: world |> chain(id) |> Enum.map(&elem(&1, 1))

  def wanted_key(world, id) do
    with users when users != nil <- world.demand[id],
         true <- MapSet.size(users) > 0,
         %{deleted: false} <- world.posts[id] do
      world.keys[id]
    else
      _ -> nil
    end
  end

  def wanted(world) do
    for {id, _} <- world.demand, key = wanted_key(world, id), key != nil, into: %{}, do: {id, key}
  end

  def take_dirty(world), do: {MapSet.to_list(world.dirty), %{world | dirty: MapSet.new()}}
end
