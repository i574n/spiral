defmodule Xsim.Runner do
  alias Xsim.World

  defstruct world: nil,
            tasks: %{},
            queue: [],
            results: %{},
            starts: %{},
            cancels: 0,
            visible: %{},
            refs: %{},
            cancelled: %{},
            evicted: %{},
            evicting: false,
            peak_results: 0,
            post_key: %{},
            owner: %{},
            peak_inflight: 0,
            peak_beam_mb: 0

  def run(deliveries, executor, opts \\ []) do
    limit = Keyword.get(opts, :max_concurrency, 4)
    naive = Keyword.get(opts, :naive_visibility, false)
    evict = Keyword.get(opts, :evict, false)
    faults = %{cancel: Keyword.get(opts, :cancel, true), rerun: Keyword.get(opts, :rerun_completed, false), evict: evict}
    state = %__MODULE__{world: World.new(), evicting: evict}

    state =
      Enum.reduce(deliveries, state, fn delivery, state ->
        state = %{state | world: World.apply_delivery(state.world, delivery)}
        state |> reconcile(executor, limit, faults) |> harvest(0, naive)
      end)

    state |> drain(executor, limit, naive) |> settle()
  end

  defp reconcile(state, executor, limit, faults) do
    {dirty, world} = World.take_dirty(state.world)
    state = Enum.reduce(dirty, %{state | world: world}, &retarget(&2, &1, faults))
    state = if faults.rerun, do: requeue_completed(state), else: state
    state = start_queued(state, executor, limit)
    beam_mb = div(:erlang.memory(:total), 1_048_576)
    %{state | peak_inflight: max(state.peak_inflight, map_size(state.tasks)), peak_beam_mb: max(state.peak_beam_mb, beam_mb), peak_results: max(state.peak_results, map_size(state.results))}
  end

  defp retarget(state, id, faults) do
    old = state.post_key[id]
    new = World.wanted_key(state.world, id)

    if old == new do
      state
    else
      state = %{state | post_key: if(new, do: Map.put(state.post_key, id, new), else: Map.delete(state.post_key, id))}
      state |> release(old, faults) |> acquire(new, id)
    end
  end

  defp release(state, nil, _faults), do: state

  defp release(state, key, faults) do
    count = state.refs[key] - 1

    if count > 0 do
      %{state | refs: Map.put(state.refs, key, count)}
    else
      state = %{state | refs: Map.delete(state.refs, key), queue: List.delete(state.queue, key)}
      state = if faults.evict, do: evict(state, key), else: state

      case {faults.cancel, state.tasks[key]} do
        {true, %{task: task}} ->
          Task.shutdown(task, :brutal_kill)
          %{state | tasks: Map.delete(state.tasks, key), cancels: state.cancels + 1, cancelled: Map.update(state.cancelled, key, 1, &(&1 + 1))}

        _ ->
          state
      end
    end
  end

  defp evict(state, key) do
    if Map.has_key?(state.results, key),
      do: %{state | results: Map.delete(state.results, key), evicted: Map.update(state.evicted, key, 1, &(&1 + 1))},
      else: state
  end

  defp acquire(state, nil, _id), do: state

  defp acquire(state, key, id) do
    count = Map.get(state.refs, key, 0) + 1
    state = %{state | refs: Map.put(state.refs, key, count), owner: Map.put(state.owner, key, id)}

    if count == 1 and not Map.has_key?(state.results, key) and not Map.has_key?(state.tasks, key) and key not in state.queue do
      %{state | queue: state.queue ++ [key]}
    else
      state
    end
  end

  defp requeue_completed(state) do
    again = for {key, _} <- state.refs, Map.has_key?(state.results, key), not Map.has_key?(state.tasks, key), key not in state.queue, do: key
    %{state | queue: state.queue ++ again}
  end

  defp start_queued(%{queue: []} = state, _executor, _limit), do: state

  defp start_queued(state, _executor, limit) when map_size(state.tasks) >= limit, do: state

  defp start_queued(%{queue: [key | rest]} = state, executor, limit) do
    owner = state.owner[key]
    sources = World.sources(state.world, owner)
    task = Task.async(fn -> executor.(sources) end)

    state = %{
      state
      | queue: rest,
        tasks: Map.put(state.tasks, key, %{task: task, owners: [owner]}),
        starts: Map.update(state.starts, key, 1, &(&1 + 1))
    }

    start_queued(state, executor, limit)
  end

  defp harvest(state, timeout, naive) do
    tasks = Map.values(state.tasks) |> Enum.map(& &1.task)
    finished = Task.yield_many(tasks, timeout)

    Enum.reduce(finished, state, fn
      {task, {:ok, result}}, state ->
        {key, entry} = Enum.find(state.tasks, fn {_, e} -> e.task.ref == task.ref end)
        state = %{state | tasks: Map.delete(state.tasks, key), results: Map.put(state.results, key, result)}
        if naive, do: %{state | visible: Enum.reduce(entry.owners, state.visible, &Map.put(&2, &1, {key, result}))}, else: state

      {_task, nil}, state ->
        state

      {task, {:exit, reason}}, state ->
        {key, _} = Enum.find(state.tasks, fn {_, e} -> e.task.ref == task.ref end)
        %{state | tasks: Map.delete(state.tasks, key), results: Map.put(state.results, key, %{status: :crash, out: inspect(reason)})}
    end)
  end

  defp drain(state, executor, limit, naive) do
    state = reconcile(state, executor, limit, %{cancel: true, rerun: false, evict: state.evicting})

    if map_size(state.tasks) == 0 and state.queue == [] do
      state
    else
      state |> harvest(5, naive) |> drain(executor, limit, naive)
    end
  end

  defp settle(state) do
    if state.visible == %{} do
      visible = for {id, key} <- World.wanted(state.world), Map.has_key?(state.results, key), into: %{}, do: {id, {key, state.results[key]}}
      %{state | visible: visible}
    else
      state
    end
  end
end
