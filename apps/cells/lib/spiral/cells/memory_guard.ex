defmodule Spiral.Cells.MemoryGuard do
  @default_megabytes 2048
  @period_ms 100
  @megabyte 1_048_576

  def start(halt \\ &System.halt/1) do
    limit = limit_bytes(System.get_env("SPIRAL_CELLS_MAX_MB"))

    cond do
      limit == 0 -> :disabled
      Process.whereis(__MODULE__) -> :running
      true -> register(spawn(fn -> watch(limit, halt) end))
    end
  end

  def limit_bytes(nil), do: @default_megabytes * @megabyte

  def limit_bytes(text) do
    case Integer.parse(String.trim(text)) do
      {megabytes, ""} when megabytes >= 0 -> megabytes * @megabyte
      _ -> @default_megabytes * @megabyte
    end
  end

  def over_limit?(total, limit), do: limit > 0 and total > limit

  def report(total, limit) do
    holders =
      Process.list()
      |> Enum.map(&{binary_bytes(&1), &1})
      |> Enum.sort(:desc)
      |> Enum.take(5)
      |> Enum.flat_map(&holder_line/1)

    Enum.join(
      [
        "spiral cells memory guard: this VM uses #{div(total, @megabyte)} MB, over its #{div(limit, @megabyte)} MB " <>
          "limit (SPIRAL_CELLS_MAX_MB, 0 turns the guard off); halting before it fills swap. Top binary holders:"
        | holders
      ],
      "\n"
    )
  end

  defp register(pid) do
    try do
      Process.register(pid, __MODULE__)
      :started
    rescue
      ArgumentError ->
        Process.exit(pid, :kill)
        :running
    end
  end

  defp watch(limit, halt) do
    total = :erlang.memory(:total)

    if over_limit?(total, limit) do
      IO.puts(:stderr, report(total, limit))
      halt.(137)
    else
      Process.sleep(@period_ms)
      watch(limit, halt)
    end
  end

  defp holder_line({bytes, pid}) do
    case Process.info(pid, [:registered_name, :initial_call, :current_stacktrace, :message_queue_len]) do
      nil -> []
      info -> ["  #{inspect(pid)} #{div(bytes, @megabyte)} MB in binaries #{inspect(info, limit: 40, printable_limit: 200)}"]
    end
  end

  defp binary_bytes(pid) do
    case Process.info(pid, :binary) do
      {:binary, binaries} -> binaries |> Enum.map(fn {_, size, _} -> size end) |> Enum.sum()
      nil -> 0
    end
  end
end
