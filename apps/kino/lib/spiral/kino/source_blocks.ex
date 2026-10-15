defmodule Spiral.Kino.SourceBlocks do
  alias Spiral.Kino.{CompilerDaemon, Toolchain}

  @inputs_per_call 150

  @type block :: %{first: pos_integer(), header: pos_integer(), last_content: pos_integer(), last: pos_integer(), header_text: String.t()}

  @spec available?(keyword()) :: boolean()
  def available?(opts) do
    case host(opts) do
      {:ok, _dotnet, _dll} -> true
      :unavailable -> false
    end
  end

  @spec of_texts(keyword(), [String.t()]) :: {:ok, %{String.t() => [block()]}} | :unavailable
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

  @spec split(String.t(), [block()]) :: [%{header_text: String.t(), lines: [String.t()]}]
  def split(text, blocks) do
    lines = text |> String.replace("\r\n", "\n") |> String.split("\n") |> List.to_tuple()

    for %{header: header, last: last, header_text: header_text} <- blocks do
      %{header_text: header_text, lines: for(row <- header..min(last, tuple_size(lines))//1, do: elem(lines, row - 1))}
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
          by_input = out |> File.read!() |> parse_rows()
          {:ok, Map.new(indexed, fn {text, i} -> {text, Map.get(by_input, i, [])} end)}

        _ ->
          :unavailable
      end
    rescue
      _ -> :unavailable
    after
      File.rm_rf(dir)
    end
  end

  @doc false
  def parse_rows(tsv) do
    tsv
    |> String.split("\n", trim: true)
    |> Enum.map(&String.split(&1, "\t", parts: 6))
    |> Enum.flat_map(fn
      [input, first, header, last_content, last, header_text] when header != "0" ->
        [{String.to_integer(input), %{first: String.to_integer(first), header: String.to_integer(header), last_content: String.to_integer(last_content), last: String.to_integer(last), header_text: header_text}}]

      _ ->
        []
    end)
    |> Enum.group_by(&elem(&1, 0), &elem(&1, 1))
  end
end
