defmodule Spiral.Cells.Html do
  @palette %{
    "keyword" => "#c586c0",
    "variable" => "#9cdcfe",
    "symbol" => "#4fc1ff",
    "string" => "#ce9178",
    "number" => "#b5cea8",
    "number_suffix" => "#b5cea8",
    "operator" => "#d4d4d4",
    "unary_operator" => "#d4d4d4",
    "comment" => "#6a9955",
    "parenthesis" => "#ffd700",
    "type_variable" => "#4ec9b0",
    "escaped_char" => "#d7ba7d",
    "unescaped_char" => "#ce9178",
    "escaped_var" => "#d7ba7d"
  }

  @spec render(map(), (String.t() -> [{non_neg_integer(), non_neg_integer(), non_neg_integer(), String.t()}]), String.t()) :: String.t()
  def render(ipynb, tokenize, title) do
    body = Enum.map_join(ipynb["cells"] || [], "\n", &cell(&1, tokenize))
    head(title) <> body <> "\n</main>\n</body>\n</html>\n"
  end

  defp head(title) do
    token_css = Enum.map_join(@palette, "\n", fn {class, color} -> ".tok-#{class} { color: #{color}; }" end)

    """
    <!DOCTYPE html>
    <html lang="en">
    <head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>#{escape(title)}</title>
    <style>
    html { -webkit-text-size-adjust: 100%; text-size-adjust: 100%; }
    body { background-color: #1e1e1e; color: #d4d4d4; margin: 0; font: 15px/1.6 system-ui, sans-serif; overflow-wrap: anywhere; }
    main { max-width: 960px; margin: 0 auto; padding: 12px; }
    pre { background-color: #252526; padding: 10px; border-radius: 4px; overflow-x: auto; font: 13px/1.5 ui-monospace, Consolas, monospace; }
    pre.output { background-color: #181818; color: #bbb; border-left: 3px solid #444; }
    .badge { display: inline-block; font-size: 12px; padding: 0 6px; border-radius: 3px; margin-bottom: 4px; }
    .badge.passed { background-color: #23452a; color: #9fdc9f; }
    .badge.failed { background-color: #4a2323; color: #f0a0a0; }
    .badge.other { background-color: #333; color: #bbb; }
    a { color: #4fc1ff; }
    #{token_css}
    @media (max-width: 600px) { main { padding: 6px; } pre { font-size: 12px; } }
    </style>
    </head>
    <body>
    <main>
    """
  end

  defp cell(%{"cell_type" => "markdown", "source" => source}, _tokenize), do: markdown(join(source))

  defp cell(%{"cell_type" => "code"} = json, tokenize) do
    badge =
      case get_in(json, ["metadata", "spiral_test"]) do
        %{"name" => name, "status" => status} ->
          kind = if status in ["passed", "failed"], do: status, else: "other"
          "<span class=\"badge #{kind}\">test #{escape(name)}: #{escape(status)}</span>\n"

        _ ->
          ""
      end

    source = join(json["source"] || [])
    outputs = Enum.map_join(json["outputs"] || [], "", &output/1)
    badge <> "<pre class=\"code\"><code>" <> highlight(source, tokenize) <> "</code></pre>\n" <> outputs
  end

  defp cell(_json, _tokenize), do: ""

  defp output(%{"text" => text}), do: "<pre class=\"output\">" <> escape(join(text)) <> "</pre>\n"
  defp output(%{"data" => %{"text/plain" => text}}), do: "<pre class=\"output\">" <> escape(join(text)) <> "</pre>\n"
  defp output(_), do: ""

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
    lines = String.split(source, "\n")
    by_line = tokenize.(source) |> Enum.group_by(&elem(&1, 0))

    lines
    |> Enum.with_index()
    |> Enum.map_join("\n", fn {line, index} -> highlight_line(line, Map.get(by_line, index, [])) end)
  end

  defp highlight_line(line, tokens) do
    units = :unicode.characters_to_binary(line, :utf8, :utf16)
    length = div(byte_size(units), 2)

    {parts, at} =
      tokens
      |> Enum.sort_by(&elem(&1, 1))
      |> Enum.reduce({[], 0}, fn {_line, from, near_to, class}, {parts, at} ->
        if from < at or near_to > length or near_to < from do
          {parts, at}
        else
          gap = utf16_slice(units, at, from)
          token = utf16_slice(units, from, near_to)
          {[parts, escape(gap), "<span class=\"tok-", class, "\">", escape(token), "</span>"], near_to}
        end
      end)

    IO.iodata_to_binary([parts, escape(utf16_slice(units, at, length))])
  end

  defp utf16_slice(units, from, near_to) do
    case :unicode.characters_to_binary(binary_part(units, from * 2, (near_to - from) * 2), :utf16, :utf8) do
      text when is_binary(text) -> text
      _ -> ""
    end
  end

  @doc false
  def markdown(text) do
    {html, block} =
      text
      |> String.split("\n")
      |> Enum.reduce({[], :none}, fn line, {html, block} -> markdown_line(line, html, block) end)

    IO.iodata_to_binary([html, close(block)])
  end

  defp markdown_line(line, html, :code) do
    if String.starts_with?(line, "```"), do: {[html, "</code></pre>\n"], :none}, else: {[html, escape(line), "\n"], :code}
  end

  defp markdown_line(line, html, block) do
    cond do
      String.starts_with?(line, "```") -> {[html, close(block), "<pre><code>"], :code}
      String.trim(line) == "" -> {[html, close(block)], :none}
      heading = Regex.run(~r/^(\#{1,6}) (.*)$/, line) -> markdown_heading(heading, html, block)
      item = Regex.run(~r/^[-*] (.*)$/, line) -> markdown_item(item, html, block)
      block == :paragraph -> {[html, " ", inline(line)], :paragraph}
      true -> {[html, close(block), "<p>", inline(line)], :paragraph}
    end
  end

  defp markdown_heading([_, hashes, title], html, block) do
    tag = "h#{byte_size(hashes)}"
    {[html, close(block), "<", tag, ">", inline(title), "</", tag, ">\n"], :none}
  end

  defp markdown_item([_, text], html, :list), do: {[html, "<li>", inline(text), "</li>\n"], :list}
  defp markdown_item([_, text], html, block), do: {[html, close(block), "<ul>\n<li>", inline(text), "</li>\n"], :list}

  defp close(:none), do: ""
  defp close(:paragraph), do: "</p>\n"
  defp close(:list), do: "</ul>\n"
  defp close(:code), do: "</code></pre>\n"

  defp inline(text) do
    Regex.split(~r/(`[^`]*`|\[[^\]]*\]\([^)]*\))/, text, include_captures: true)
    |> Enum.map_join(fn
      "`" <> rest = piece when byte_size(piece) >= 2 -> "<code>" <> escape(String.trim_trailing(rest, "`")) <> "</code>"
      "[" <> _ = piece ->
        case Regex.run(~r/^\[([^\]]*)\]\(([^)]*)\)$/, piece) do
          [_, label, href] -> "<a href=\"" <> escape(href) <> "\">" <> escape(label) <> "</a>"
          _ -> escape(piece)
        end

      piece ->
        escape(piece)
    end)
  end

  defp join(lines) when is_list(lines), do: Enum.join(lines)
  defp join(text) when is_binary(text), do: text

  @doc false
  def escape(text) do
    text
    |> String.replace("&", "&amp;")
    |> String.replace("<", "&lt;")
    |> String.replace(">", "&gt;")
    |> String.replace("\"", "&quot;")
  end
end
