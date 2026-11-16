defmodule Spiral.Cells.Html do
  @spec render(map(), (String.t() -> [{non_neg_integer(), non_neg_integer(), non_neg_integer(), String.t()}]), String.t()) :: String.t()
  def render(ipynb, tokenize, title) do
    body = Enum.map_join(ipynb["cells"] || [], "\n", &cell(&1, tokenize))
    head(title) <> body <> "\n</main>\n</body>\n</html>\n"
  end

  defp head(title), do: Spiral.Cells.Domain.html_head(title)

  defp cell(%{"cell_type" => "markdown", "source" => source}, _tokenize), do: markdown(join(source))

  defp cell(%{"cell_type" => "code"} = json, tokenize) do
    badge = Spiral.Cells.Domain.cell_head_html(JSON.encode!(json["metadata"] || %{}))
    source = join(json["source"] || [])
    outputs = Enum.map_join(json["outputs"] || [], "", &output/1)
    badge <> "<pre class=\"code\"><code>" <> highlight(source, tokenize) <> "</code></pre>\n" <> outputs
  end

  defp cell(_json, _tokenize), do: ""

  defp output(json), do: Spiral.Cells.Domain.output_html(JSON.encode!(json))

  @spec write(String.t(), keyword()) :: :ok
  def write(ipynb_path, opts \\ []) do
    ipynb = ipynb_path |> File.read!() |> JSON.decode!()
    title = ipynb_path |> Path.basename(".ipynb")
    tokenize = if spiral_kernel?(ipynb), do: compiler_tokenizer(opts), else: fn _ -> [] end
    File.write!(Path.rootname(ipynb_path) <> ".html", render(ipynb, tokenize, title))
    :ok
  end

  @doc false
  def spiral_kernel?(ipynb), do: get_in(ipynb, ["metadata", "kernelspec", "language"]) in [nil, "spiral"]

  @doc false
  def compiler_tokenizer(opts) do
    dotnet = Spiral.Cells.Toolchain.dotnet(opts)
    dll = Spiral.Cells.Toolchain.compiler_dll(opts)

    if is_binary(dotnet) and File.regular?(dll) do
      fn source ->
        path = Path.join(System.tmp_dir!(), "spiral-tokens-#{System.unique_integer([:positive])}.spi")
        File.write!(path, source)

        try do
          case System.cmd(dotnet, [dll, "tokens", path], stderr_to_stdout: true) do
            {out, 0} ->
              parse_tokens(out)

            {out, code} ->
              IO.puts(:stderr, "spiral.html: no colors, '#{dotnet} #{dll} tokens' exited #{code}: #{out |> String.slice(0, 300) |> String.trim()}")
              []
          end
        after
          File.rm(path)
        end
      end
    else
      IO.puts(:stderr, "spiral.html: no colors, dotnet=#{inspect(dotnet)} compiler=#{dll} (exists: #{File.regular?(dll)})")
      fn _ -> [] end
    end
  end

  @doc false
  def parse_tokens(out) do
    for row <- String.split(out, "\n", trim: true),
        [line, from, near_to, class] <- [String.split(row, "\t")],
        {line, ""} <- [Integer.parse(line)],
        {from, ""} <- [Integer.parse(from)],
        {near_to, ""} <- [Integer.parse(near_to)],
        do: {line, from, near_to, class}
  end

  @doc false
  def highlight(source, tokenize) do
    wire = Enum.map_join(tokenize.(source), "\n", fn {line, from, near_to, class} -> "#{line}\t#{from}\t#{near_to}\t#{class}" end)
    Spiral.Cells.Domain.highlighted(source, wire)
  end

  @doc false
  def markdown(text), do: Spiral.Cells.Domain.markdown_html(text)

  defp join(lines) when is_list(lines), do: Enum.join(lines)
  defp join(text) when is_binary(text), do: text

  @doc false
  def escape(text), do: Spiral.Cells.Domain.html_escape(text)
end
