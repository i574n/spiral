defmodule Spiral.Kino.CompilerPool do
  use GenServer

  alias Spiral.Kino.CompilerDaemon

  @default_server_mb 1_000
  @default_reserve_mb 1_500

  @type option ::
          {:first, pid()}
          | {:max_workers, pos_integer()}
          | {:fair, boolean()}
          | {:start_worker, (-> {:ok, pid()} | {:error, term()})}
          | {:free_mb, (-> non_neg_integer() | nil)}

  @spec start_link([option()]) :: GenServer.on_start()
  def start_link(opts), do: GenServer.start_link(__MODULE__, opts)

  @spec compile(GenServer.server(), String.t(), map()) :: term()
  def compile(pool, client, req), do: GenServer.call(pool, {:compile, client, req}, :infinity)

  @spec stats(GenServer.server()) :: map()
  def stats(pool), do: GenServer.call(pool, :stats)

  @default_max_workers 3

  @spec settings(String.t() | nil) :: %{max_workers: pos_integer(), fair: boolean(), fair_single: boolean()}
  def settings(pool) do
    workers = max_workers(pool)
    fair = System.get_env("SPIRAL_KINO_DAEMON_FAIR") != "0"
    %{max_workers: workers, fair: fair, fair_single: workers == 1 and pool not in [nil, "off", "0"] and fair}
  end

  defp max_workers(nil), do: 1
  defp max_workers("off"), do: 1
  defp max_workers("auto"), do: @default_max_workers

  defp max_workers(text) do
    case Integer.parse(text) do
      {n, ""} when n >= 1 -> n
      _ -> 1
    end
  end

  @impl true
  def init(opts) do
    Process.flag(:trap_exit, true)

    {:ok,
     %{
       first: Keyword.fetch!(opts, :first),
       idle: [Keyword.fetch!(opts, :first)],
       workers: [Keyword.fetch!(opts, :first)],
       max_workers: Keyword.get(opts, :max_workers, 1),
       fair: Keyword.get(opts, :fair, true),
       start_worker: Keyword.get(opts, :start_worker),
       free_mb: Keyword.get(opts, :free_mb, &free_mb/0),
       queues: %{},
       order: [],
       served: 0,
       peak_workers: 1
     }}
  end

  @impl true
  def handle_call({:compile, client, req}, from, state) do
    client = if state.fair, do: client, else: "fifo"

    queues = Map.update(state.queues, client, :queue.in({from, req}, :queue.new()), &:queue.in({from, req}, &1))
    order = if client in state.order, do: state.order, else: state.order ++ [client]
    {:noreply, dispatch(%{state | queues: queues, order: order})}
  end

  def handle_call(:stats, _from, state) do
    extra = state.workers -- [state.first]
    {:reply, %{workers: length(state.workers), idle: length(state.idle), queued: queued(state), served: state.served, peak_workers: state.peak_workers, extra_workers: extra}, state}
  end

  @impl true
  def handle_info({:done, worker}, state) do
    {:noreply, dispatch(%{state | idle: [worker | state.idle], served: state.served + 1})}
  end

  def handle_info({:EXIT, pid, _reason}, state) do
    {:noreply, %{state | workers: List.delete(state.workers, pid), idle: List.delete(state.idle, pid)}}
  end

  def handle_info(_message, state), do: {:noreply, state}

  defp queued(state), do: state.queues |> Map.values() |> Enum.map(&:queue.len/1) |> Enum.sum()

  defp dispatch(state) do
    state = grow(state)

    case {state.idle, next(state)} do
      {[worker | idle], {:ok, {from, req}, state}} ->
        pool = self()

        spawn_link(fn ->
          reply =
            try do
              GenServer.call(worker, {:compile, req}, :infinity)
            catch
              :exit, reason -> {:error, "compiler worker failed: #{inspect(reason)}"}
            end

          GenServer.reply(from, reply)
          send(pool, {:done, worker})
        end)

        dispatch(%{state | idle: idle})

      _ ->
        state
    end
  end

  defp next(%{order: []}), do: :empty

  defp next(%{order: [client | rest]} = state) do
    case :queue.out(Map.get(state.queues, client, :queue.new())) do
      {{:value, item}, left} ->
        queues = if :queue.is_empty(left), do: Map.delete(state.queues, client), else: Map.put(state.queues, client, left)
        order = if :queue.is_empty(left), do: rest, else: rest ++ [client]
        {:ok, item, %{state | queues: queues, order: order}}

      {:empty, _} ->
        next(%{state | order: rest, queues: Map.delete(state.queues, client)})
    end
  end

  defp grow(%{idle: [], start_worker: start} = state) when is_function(start, 0) do
    waiting = queued(state)

    if waiting > 0 and length(state.workers) < state.max_workers and room?(state) do
      case start.() do
        {:ok, pid} ->
          workers = [pid | state.workers]
          %{state | workers: workers, idle: [pid], peak_workers: max(state.peak_workers, length(workers))}

        {:error, reason} ->
          IO.puts("compiler pool could not start a worker: #{inspect(reason)}")
          %{state | max_workers: length(state.workers)}
      end
    else
      state
    end
  end

  defp grow(state), do: state

  defp room?(state) do
    case cached_free_mb(state.free_mb) do
      nil -> true
      free -> free >= server_mb() + reserve_mb()
    end
  end

  defp cached_free_mb(probe) do
    now = System.monotonic_time(:millisecond)

    case Process.get(:spiral_kino_free_mb) do
      {at, mb} when now - at < 10_000 -> mb
      _ ->
        mb = probe.()
        Process.put(:spiral_kino_free_mb, {now, mb})
        mb
    end
  end

  defp server_mb, do: env_mb("SPIRAL_KINO_DAEMON_SERVER_MB", @default_server_mb)
  defp reserve_mb, do: env_mb("SPIRAL_KINO_DAEMON_RESERVE_MB", @default_reserve_mb)

  defp env_mb(name, default) do
    case Integer.parse(System.get_env(name) || "") do
      {n, ""} when n >= 0 -> n
      _ -> default
    end
  end

  @doc false
  def free_mb do
    case :os.type() do
      {:win32, _} ->
        case System.cmd("powershell", ["-NoProfile", "-Command", "(Get-CimInstance Win32_OperatingSystem).FreePhysicalMemory"], stderr_to_stdout: true) do
          {text, 0} ->
            case Integer.parse(String.trim(text)) do
              {kb, _} -> div(kb, 1024)
              _ -> nil
            end

          _ ->
            nil
        end

      _ ->
        case File.read("/proc/meminfo") do
          {:ok, text} ->
            case Regex.run(~r/MemAvailable:\s+(\d+) kB/, text) do
              [_, kb] -> div(String.to_integer(kb), 1024)
              _ -> nil
            end

          _ ->
            nil
        end
    end
  rescue
    _ -> nil
  end

  @doc false
  def worker_starter(toolchain, limits) do
    fn -> CompilerDaemon.start_link([port: 0, worker: true, limits: limits] ++ toolchain) end
  end
end
