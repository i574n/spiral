defmodule Spiral.Cells.CompilerPool do
  use GenServer

  alias Spiral.Cells.CompilerDaemon

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

  @spec settings(String.t() | nil) :: %{max_workers: pos_integer(), fair: boolean(), fair_single: boolean()}
  def settings(pool) do
    workers = Spiral.Cells.Domain.pool_max_workers(pool || "")
    fair = System.get_env("SPIRAL_CELLS_DAEMON_FAIR") != "0"
    %{max_workers: workers, fair: fair, fair_single: workers == 1 and pool not in [nil, "off", "0"] and fair}
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
       queue: Spiral.Cells.Domain.fair_empty(),
       served: 0,
       peak_workers: 1,
       free_reading: :none,
       gauging: false,
       refused_growth: 0
     }}
  end

  @impl true
  def handle_call({:compile, client, req}, from, state) do
    client = if state.fair, do: client, else: "fifo"

    {:noreply, dispatch(%{state | queue: Spiral.Cells.Domain.fair_push(state.queue, client, {from, req})})}
  end

  def handle_call(:stats, _from, state) do
    extra = state.workers -- [state.first]
    {:reply, %{workers: length(state.workers), idle: length(state.idle), queued: queued(state), served: state.served, peak_workers: state.peak_workers, extra_workers: extra, refused_growth: state.refused_growth, last_free_mb: last_free_mb(state.free_reading)}, state}
  end

  @impl true
  def handle_info({:done, worker}, state) do
    {:noreply, dispatch(%{state | idle: [worker | state.idle], served: state.served + 1})}
  end

  def handle_info({:free_mb, mb}, state) do
    {:noreply, dispatch(%{state | free_reading: {System.monotonic_time(:millisecond), mb}, gauging: false})}
  end

  def handle_info({:EXIT, pid, _reason}, state) do
    {:noreply, %{state | workers: List.delete(state.workers, pid), idle: List.delete(state.idle, pid)}}
  end

  def handle_info(_message, state), do: {:noreply, state}

  defp queued(state), do: Spiral.Cells.Domain.fair_len(state.queue)

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

  defp next(state) do
    case Spiral.Cells.Domain.fair_pop(state.queue) do
      {:ok, item, queue} -> {:ok, item, %{state | queue: queue}}
      :empty -> :empty
    end
  end

  defp grow(%{idle: [], start_worker: start} = state) when is_function(start, 0) do
    waiting = queued(state)

    {room, state} = if waiting > 0 and length(state.workers) < state.max_workers, do: room(state), else: {:not_needed, state}

    if room == :room do
      case start.() do
        {:ok, pid} ->
          workers = [pid | state.workers]
          %{state | workers: workers, idle: [pid], peak_workers: max(state.peak_workers, length(workers))}

        {:error, reason} ->
          IO.puts("compiler pool could not start a worker: #{inspect(reason)}")
          %{state | max_workers: length(state.workers)}
      end
    else
      if room == :no_room, do: %{state | refused_growth: state.refused_growth + 1}, else: state
    end
  end

  defp grow(state), do: state

  @free_reading_ttl_ms 10_000

  defp room(state) do
    now = System.monotonic_time(:millisecond)

    state =
      case state.free_reading do
        {at, _} when now - at < @free_reading_ttl_ms -> state
        _ -> gauge_free_mb(state)
      end

    free =
      case state.free_reading do
        {_, mb} when is_integer(mb) -> mb
        _ -> -1
      end

    case Spiral.Cells.Domain.room_verdict(state.free_reading != :none, free, server_mb() + reserve_mb()) do
      "room" -> {:room, state}
      "no_room" -> {:no_room, state}
      _ -> {:waiting_for_reading, state}
    end
  end

  defp gauge_free_mb(%{gauging: true} = state), do: state

  defp gauge_free_mb(state) do
    pool = self()
    gauge = state.free_mb

    Task.start(fn ->
      mb =
        try do
          gauge.()
        rescue
          _ -> nil
        catch
          _, _ -> nil
        end

      send(pool, {:free_mb, mb})
    end)

    %{state | gauging: true}
  end

  defp last_free_mb({_, mb}), do: mb
  defp last_free_mb(:none), do: nil

  defp server_mb, do: Spiral.Cells.Domain.count_or(System.get_env("SPIRAL_CELLS_DAEMON_SERVER_MB") || "", @default_server_mb)
  defp reserve_mb, do: Spiral.Cells.Domain.count_or(System.get_env("SPIRAL_CELLS_DAEMON_RESERVE_MB") || "", @default_reserve_mb)

  @doc false
  def free_mb do
    case :os.type() do
      {:win32, _} ->
        case System.cmd("pwsh", ["-NoProfile", "-NonInteractive", "-Command", "(Get-CimInstance Win32_OperatingSystem).FreePhysicalMemory"], stderr_to_stdout: true) do
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
            case Spiral.Cells.Domain.mem_available_mb(text) do
              -1 -> nil
              mb -> mb
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
