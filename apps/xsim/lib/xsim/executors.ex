defmodule Xsim.Executors do
  def fake(fault \\ :none) do
    leak = :ets.new(:xsim_leak, [:public, :set])

    fn sources ->
      digest = :crypto.hash(:sha256, Enum.join(sources, "\u0000")) |> Base.encode16(case: :lower) |> binary_part(0, 12)
      Process.sleep(rem(:erlang.phash2(digest), 7))

      case fault do
        :none ->
          %{status: :ok, out: digest}

        :leak ->
          previous = case :ets.lookup(leak, :last) do
            [{:last, value}] -> value
            [] -> ""
          end

          :ets.insert(leak, {:last, digest})
          %{status: :ok, out: digest <> previous}

        :flaky ->
          %{status: :ok, out: digest <> Integer.to_string(:rand.uniform(2))}
      end
    end
  end

  def memo_tally, do: :counters.new(2, [:atomics])

  def memo_counts(tally), do: %{hit: :counters.get(tally, 1), miss: :counters.get(tally, 2)}

  def kino(opts \\ []) do
    {tally, opts} = Keyword.pop(opts, :memo_tally)

    fn sources ->
      doc = %{cells: Enum.map(sources, &%{kind: :spiral, source: &1})}
      last = length(sources) - 1

      case apply(Spiral.Kino.Notebook, :evaluate, [doc, opts]) do
        %{status: status, outputs: outputs} = result ->
          if tally, do: count_memo(tally, Map.get(result, :memo, %{}))
          verdict = result |> Map.get(:verdicts, %{}) |> Map.get(last)
          %{status: status_of(status), out: inspect({status, verdict, Map.get(outputs, last)}, limit: :infinity, printable_limit: 4096)}

        other ->
          %{status: :unexpected, out: inspect(other)}
      end
    end
  end

  defp count_memo(tally, flags) do
    for {_index, flag} <- flags do
      case flag do
        :hit -> :counters.add(tally, 1, 1)
        :miss -> :counters.add(tally, 2, 1)
        _ -> :ok
      end
    end
  end

  defp status_of(:ok), do: :ok
  defp status_of(_), do: :error
end
