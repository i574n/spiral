defmodule Spiral.Kino.Document do
  alias Spiral.Kino.SmartCell

  @break_markdown ~s|<!-- livebook:{"break_markdown":true} -->|

  @spec parse_dib(String.t()) :: %{cells: [map()]}
  def parse_dib(text) when is_binary(text) do
    %{cells: Spiral.Kino.Domain.decode_cells(Spiral.Kino.Domain.parse_dib(text))}
  end

  @spec parse_livemd(String.t()) :: %{cells: [map()]}
  def parse_livemd(text) when is_binary(text) do
    text = String.replace(text, "\r\n", "\n")

    cells =
      # A fence opens and closes at the start of a line (as in Markdown): a ``` inside a cell (a Spiral string
      # holding a fence, benchmark.dib) does not end it.
      Regex.split(~r/(^<!-- livebook:\{"spiral_code":"[^"]+"\} -->\n\n```[^\n]*\n.*?^```[ \t]*(?:\n|\z)|^```(?:elixir|fsharp|spiral)\n.*?^```[ \t]*(?:\n|\z))/sm, text, include_captures: true)
      |> Enum.flat_map(&livemd_part/1)

    %{cells: cells}
  end

  @spec to_livemd(%{cells: [map()]}) :: String.t()
  def to_livemd(%{cells: cells}) do
    {parts, _} =
      cells
      |> Enum.map(&canonical/1)
      |> Enum.map_reduce(nil, fn cell, prev ->
        part =
          if text_cell?(prev) and text_cell?(cell),
            do: @break_markdown <> "\n\n" <> render_cell(cell),
            else: render_cell(cell)

        {part, cell}
      end)

    parts
    |> Enum.join("\n\n")
    |> newline()
  end

  # A cell's source as parse_livemd reads it back (a code cell without trailing newlines, markdown trimmed), so the
  # rendered .livemd always round-trips: a Spiral source ending in "\n" was written into the smart-cell attrs with it
  # and read back without it (rust/testing.livemd after a scripted sync).
  defp canonical(%{kind: :markdown, source: source} = cell), do: %{cell | source: String.trim(source)}
  defp canonical(%{kind: :import} = cell), do: cell
  defp canonical(%{source: source} = cell), do: %{cell | source: String.trim_trailing(source, "\n")}

  defp text_cell?(%{kind: kind}) when kind in [:markdown, :import], do: true
  defp text_cell?(_), do: false

  # The cells in the .dib format the spiral CLI's dib-export reads: `#!<kind>` on its own line, then the cell, up to the
  # next `#!` line (trimmed). The F# export goes through it (Notebook): `spiral dib-export <nb>.dib fs` wraps the cells
  # in the module a `# Name (Namespace)` heading declares and indents them.
  @spec to_dib(%{cells: [map()]}) :: String.t()
  def to_dib(%{cells: cells}) do
    cells |> Enum.map_join("\n\n", &dib_cell/1) |> newline()
  end

  defp dib_cell(%{kind: :import, source: source}), do: "#!import #{source}"
  defp dib_cell(%{kind: :code, language: language, source: source}), do: "#!#{language}\n\n#{source}"
  defp dib_cell(%{kind: kind, source: source}), do: "#!#{kind}\n\n#{source}"

  @spec to_spir(%{cells: [map()]}) :: String.t()
  def to_spir(%{cells: cells}) do
    Spiral.Kino.Domain.to_spir(Spiral.Kino.Domain.encode_cells(cells))
  end

  @spec to_spi(%{cells: [map()]}) :: String.t()
  def to_spi(%{cells: cells}) do
    Spiral.Kino.Domain.to_spi(Spiral.Kino.Domain.encode_cells(cells))
  end

  defp livemd_part(part) do
    cond do
      # a host code cell (pwsh, mermaid, ...): its language rides in the annotation, the fence holds the source
      match?([_, _], Regex.run(~r/\A<!-- livebook:\{"spiral_code":"([^"]+)"\} -->/, part)) ->
        [_, language] = Regex.run(~r/\A<!-- livebook:\{"spiral_code":"([^"]+)"\} -->/, part)
        body = part |> String.replace(~r/\A<!-- livebook:[^\n]*\n\n/, "") |> fence_body()
        [%{kind: :code, language: language, source: body}]

      String.starts_with?(part, "```elixir") ->
        case eval_source(part) do
          nil -> markdown_part(part)
          source -> [%{kind: :spiral, source: source}]
        end

      String.starts_with?(part, "```fsharp") ->
        [%{kind: :fsharp, source: fence_body(part)}]

      String.starts_with?(part, "```spiral") ->
        [%{kind: :spiral, source: fence_body(part)}]

      true ->
        markdown_part(part)
    end
  end

  defp markdown_part(part) do
    part
    |> String.split(@break_markdown)
    |> Enum.flat_map(fn chunk ->
      source =
        chunk
        |> String.replace(~r/<!-- livebook:.*?-->\n?/s, "")
        |> String.trim()

      case Regex.run(~r/\A`#!import ([^`\n]+)`\z/, source) do
        [_, path] -> [%{kind: :import, source: path}]
        nil when source == "" -> []
        nil -> [%{kind: :markdown, source: source}]
      end
    end)
  end

  defp fence_body(part) do
    part
    |> String.replace(~r/\A```[a-z]+\n/, "")
    |> String.replace(~r/```\n?\z/, "")
    |> String.trim_trailing("\n")
  end

  defp eval_source(part) do
    code = fence_body(part)

    with {:ok, ast} <- Code.string_to_quoted(code),
         {{:., _, [{:__aliases__, _, [:Spiral, :Kino]}, :eval!]}, _, [sigil | _]} <- ast,
         {source, _} when is_binary(source) <- Code.eval_quoted(sigil) do
      String.trim_trailing(source, "\n")
    else
      _ -> nil
    end
  end

  defp render_cell(%{kind: :markdown, source: source}), do: source

  defp render_cell(%{kind: :spiral, source: source}) do
    print_code = String.contains?(source, "--print-code")

    elixir =
      SmartCell.to_source(%{
        "source" => source,
        "timeout" => 300,
        "print_code" => print_code
      })

    attrs =
      JSON.encode!(%{
        attrs: %{print_code: print_code, source: source, timeout: 300},
        chunks: nil,
        kind: "Elixir.Spiral.Kino.SmartCell",
        livebook_object: "smart_cell"
      })

    "<!-- livebook:#{attrs} -->\n\n```elixir\n#{elixir}\n```"
  end

  defp render_cell(%{kind: :fsharp, source: source}), do: "```fsharp\n#{source}\n```"
  defp render_cell(%{kind: :import, source: source}), do: "`#!import #{source}`"

  defp render_cell(%{kind: :code, language: language, source: source}) do
    "<!-- livebook:{\"spiral_code\":\"#{language}\"} -->\n\n```#{language}\n#{source}\n```"
  end

  defp newline(text) do
    if String.ends_with?(text, "\n"), do: text, else: text <> "\n"
  end
end
