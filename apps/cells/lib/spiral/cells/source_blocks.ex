defmodule Spiral.Cells.SourceBlocks do
  alias Spiral.Cells.{CompilerDaemon, Toolchain}

  @inputs_per_call 150

  @spec available?(keyword()) :: boolean()
  def available?(opts) do
    case host(opts) do
      {:ok, _dotnet, _dll} -> true
      :unavailable -> false
    end
  end

  @spec of_texts(keyword(), [String.t()]) :: {:ok, %{String.t() => String.t()}} | :unavailable
  def of_texts(opts, texts) do
    texts = Enum.uniq(texts)

    with {:ok, dotnet, dll} <- host(opts) do
      texts
      |> Enum.chunk_every(@inputs_per_call)
      |> Enum.reduce_while({:ok, %{}}, fn chunk, {:ok, acc} ->
        case run(dotnet, dll, chunk) do
          {:ok, spans} -> {:cont, {:ok, Map.merge(acc, spans)}}
          :unavailable -> {:halt, :unavailable}
        end
      end)
    end
  end

  @spec split(String.t(), String.t()) :: [%{header_text: String.t(), lines: [String.t()]}]
  def split(text, rows), do: text |> Spiral.Cells.Domain.source_split_blocks(rows) |> blocks([])

  defp blocks("", acc), do: acc |> Enum.map(&%{&1 | lines: Enum.reverse(&1.lines)}) |> Enum.reverse()

  defp blocks(wire, acc) do
    case Spiral.Cells.Result.take_field(wire) do
      {"b", header_text, rest} -> blocks(rest, [%{header_text: header_text, lines: []} | acc])
      {"l", line, rest} -> blocks(rest, [%{hd(acc) | lines: [line | hd(acc).lines]} | tl(acc)])
    end
  end

  defp host(opts) do
    with dotnet when is_binary(dotnet) <- Toolchain.dotnet(opts),
         dll when is_binary(dll) <- Toolchain.compiler_dll(opts),
         true <- File.regular?(dll),
         true <- "source-blocks" in CompilerDaemon.host_capabilities(dotnet, dll) do
      {:ok, dotnet, dll}
    else
      _ -> :unavailable
    end
  end

  defp run(dotnet, dll, texts) do
    dir = Path.join(System.tmp_dir!(), "spiral-source-blocks-#{System.unique_integer([:positive])}")

    try do
      File.mkdir_p!(dir)
      indexed = Enum.with_index(texts, 1)
      inputs = for {text, i} <- indexed, do: tap(Path.join(dir, "#{i}.spi"), &File.write!(&1, text))
      out = Path.join(dir, "blocks.tsv")

      case System.cmd(dotnet, [dll, "--source-blocks", out | inputs], stderr_to_stdout: true) do
        {_, 0} ->
          tsv = File.read!(out)
          {:ok, Map.new(indexed, fn {text, i} -> {text, Spiral.Cells.Domain.source_input_rows(tsv, Integer.to_string(i))} end)}

        _ ->
          :unavailable
      end
    rescue
      _ -> :unavailable
    after
      File.rm_rf(dir)
    end
  end

end
