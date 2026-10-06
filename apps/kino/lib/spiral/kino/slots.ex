defmodule Spiral.Kino.Slots do
  use GenServer

  @name __MODULE__

  @spec limit() :: pos_integer()
  def limit do
    case System.get_env("SPIRAL_KINO_JOBS") do
      value when value in [nil, ""] ->
        Application.get_env(:spiral_kino, :jobs) || default_limit()

      text ->
        case Integer.parse(String.trim(text)) do
          {number, ""} when number > 0 ->
            number

          _ ->
            raise ArgumentError,
                  "SPIRAL_KINO_JOBS must be a positive integer, got: #{inspect(text)}"
        end
    end
  end

  defp default_limit, do: max(1, min(4, div(System.schedulers_online(), 2)))

  @spec run((-> result), keyword()) :: {result, non_neg_integer()} when result: term()
  def run(fun, opts \\ []) when is_function(fun, 0) do
    server = Keyword.get_lazy(opts, :server, &ensure/0)
    started = System.monotonic_time(:millisecond)
    ref = GenServer.call(server, {:acquire, self()}, :infinity)
    waited = System.monotonic_time(:millisecond) - started

    try do
      if on_wait = opts[:on_wait], do: on_wait.(waited)
      {fun.(), waited}
    after
      GenServer.cast(server, {:release, ref})
    end
  end

  @spec start_link(keyword()) :: GenServer.on_start()
  def start_link(opts \\ []) do
    GenServer.start_link(
      __MODULE__,
      Keyword.get(opts, :limit, limit()),
      Keyword.take(opts, [:name])
    )
  end

  @spec ensure() :: pid()
  def ensure do
    case Process.whereis(@name) do
      nil ->
        case GenServer.start(__MODULE__, limit(), name: @name) do
          {:ok, pid} -> pid
          {:error, {:already_started, pid}} -> pid
        end

      pid ->
        pid
    end
  end

  @impl true
  def init(limit) when is_integer(limit) and limit > 0 do
    {:ok, %{limit: limit, held: %{}, waiting: :queue.new()}}
  end

  @impl true
  def handle_call({:acquire, owner}, from, state) do
    mref = Process.monitor(owner)

    if map_size(state.held) < state.limit and :queue.is_empty(state.waiting) do
      {:reply, mref, %{state | held: Map.put(state.held, mref, owner)}}
    else
      {:noreply, %{state | waiting: :queue.in({from, owner, mref}, state.waiting)}}
    end
  end

  def handle_call(:status, _from, state) do
    {:reply,
     %{limit: state.limit, held: map_size(state.held), waiting: :queue.len(state.waiting)}, state}
  end

  @impl true
  def handle_cast({:release, ref}, state) do
    case Map.pop(state.held, ref) do
      {nil, _held} ->
        {:noreply, state}

      {_owner, held} ->
        Process.demonitor(ref, [:flush])
        {:noreply, next(%{state | held: held})}
    end
  end

  @impl true
  def handle_info({:DOWN, ref, :process, _pid, _reason}, state) do
    if Map.has_key?(state.held, ref) do
      {:noreply, next(%{state | held: Map.delete(state.held, ref)})}
    else
      waiting = :queue.filter(fn {_from, _owner, mref} -> mref != ref end, state.waiting)
      {:noreply, %{state | waiting: waiting}}
    end
  end

  def handle_info(_message, state), do: {:noreply, state}

  defp next(state) do
    if map_size(state.held) < state.limit do
      case :queue.out(state.waiting) do
        {{:value, {from, owner, mref}}, waiting} ->
          GenServer.reply(from, mref)
          next(%{state | held: Map.put(state.held, mref, owner), waiting: waiting})

        {:empty, _} ->
          state
      end
    else
      state
    end
  end
end
