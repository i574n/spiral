defmodule Spiral.Cells.Document do
  alias Spiral.Cells.SmartCell

  @break_markdown ~s|<!-- livebook:{"break_markdown":true} -->|

  @spec parse_dib(String.t()) :: %{cells: [map()]}
  def parse_dib(text) when is_binary(text) do
    %{cells: Spiral.Cells.Domain.decode_cells(Spiral.Cells.Domain.parse_dib(text))}
  end

  @spec parse_spi(String.t(), String.t()) :: %{cells: [map()]}
  def parse_spi(spi, spir) when is_binary(spi) and is_binary(spir) do
    %{cells: Spiral.Cells.Domain.decode_cells(Spiral.Cells.Domain.from_spi(spi, spir))}
  end

  @spec parse_spi(String.t(), String.t(), {String.t(), String.t()}) :: %{cells: [map()]}
  def parse_spi(spi, spir, {spi_bounds, spir_bounds}) when is_binary(spi) and is_binary(spir) do
    %{cells: Spiral.Cells.Domain.decode_cells(Spiral.Cells.Domain.from_spi_bounded(spi, spir, spi_bounds, spir_bounds))}
  end

  @spec target_gaps(String.t()) :: [{pos_integer(), String.t()}]
  def target_gaps(spi) when is_binary(spi) do
    spi
    |> Spiral.Cells.Domain.target_gaps()
    |> String.split("\n", trim: true)
    |> Enum.map(fn row ->
      [line, target] = String.split(row, "\t", parts: 2)
      {String.to_integer(line), target}
    end)
  end

  @spec parse_livemd(String.t()) :: %{cells: [map()]}
  def parse_livemd(text) when is_binary(text) do
    %{cells: text |> Spiral.Cells.Domain.livemd_cells() |> livemd_rows() |> Enum.flat_map(&livemd_cell/1)}
  end

  defp livemd_rows(""), do: []

  defp livemd_rows(wire) do
    {kind, rest} = livemd_field(wire)
    {language, rest} = livemd_field(rest)
    {source, rest} = livemd_field(rest)
    [{kind, language, source} | livemd_rows(rest)]
  end

  defp livemd_field(wire) do
    [n, rest] = String.split(wire, ":", parts: 2)
    size = String.to_integer(n)
    <<field::binary-size(^size), rest::binary>> = rest
    {field, rest}
  end

  defp livemd_cell({"code", language, source}), do: [%{kind: :code, language: language, source: source}]
  defp livemd_cell({"elixir", part, body}), do: if(source = eval_source(body), do: [%{kind: :spiral, source: source}], else: livemd_markdown(part))
  defp livemd_cell({"import", _, source}), do: [%{kind: :import, source: source}]
  defp livemd_cell({kind, _, source}) when kind in ["fsharp", "spiral", "markdown"], do: [%{kind: String.to_atom(kind), source: source}]

  defp livemd_markdown(part), do: part |> Spiral.Cells.Domain.livemd_markdown() |> livemd_rows() |> Enum.flat_map(&livemd_cell/1)

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

  defp canonical(%{kind: :markdown, source: source} = cell), do: %{cell | source: String.trim(source)}
  defp canonical(%{kind: :import} = cell), do: cell
  defp canonical(%{source: source} = cell), do: %{cell | source: String.trim_trailing(source, "\n")}

  defp text_cell?(%{kind: kind}) when kind in [:markdown, :import], do: true
  defp text_cell?(_), do: false

  @spec to_cell_text(%{cells: [map()]}) :: String.t()
  def to_cell_text(%{cells: cells}) do
    cells |> Enum.map_join("\n\n", &text_cell/1) |> newline()
  end

  defp text_cell(%{kind: :import, source: source}), do: "#!import #{source}"
  defp text_cell(%{kind: :code, language: language, source: source}), do: "#!#{language}\n\n#{source}"
  defp text_cell(%{kind: kind, source: source}), do: "#!#{kind}\n\n#{source}"

  @spec to_spir(%{cells: [map()]}) :: String.t()
  def to_spir(%{cells: cells}) do
    Spiral.Cells.Domain.to_spir(Spiral.Cells.Domain.encode_cells(cells))
  end

  @spec to_spi(%{cells: [map()]}) :: String.t()
  def to_spi(%{cells: cells}) do
    Spiral.Cells.Domain.to_spi(Spiral.Cells.Domain.encode_cells(cells))
  end

  @spec to_spi_tested(%{cells: [map()]}) :: String.t()
  def to_spi_tested(%{cells: cells}) do
    Spiral.Cells.Domain.to_spi_tested(Spiral.Cells.Domain.encode_cells(cells))
  end

  @spec to_spir_tested(%{cells: [map()]}) :: String.t()
  def to_spir_tested(%{cells: cells}) do
    Spiral.Cells.Domain.to_spir_tested(Spiral.Cells.Domain.encode_cells(cells))
  end

  @spec tests(%{cells: [map()]}) :: [
          %{index: non_neg_integer(), name: String.t(), mode: String.t(), realm: String.t(), symbol: String.t(), title: String.t()}
        ]
  def tests(%{cells: cells}) do
    cells
    |> Spiral.Cells.Domain.encode_cells()
    |> Spiral.Cells.Domain.test_index()
    |> String.split("\n", trim: true)
    |> Enum.map(fn row ->
      [index, name, mode, realm, symbol, title] = String.split(row, "\t", parts: 6)
      %{index: String.to_integer(index), name: name, mode: mode, realm: realm, symbol: symbol, title: title}
    end)
    |> Enum.sort_by(& &1.index)
  end

  defp eval_source(code) do
    with {:ok, ast} <- Code.string_to_quoted(code),
         {{:., _, [{:__aliases__, _, [:Spiral, :Cells]}, :eval!]}, _, [sigil | _]} <- ast,
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
        kind: "Elixir.Spiral.Cells.SmartCell",
        livebook_object: "smart_cell"
      })
      |> String.replace("-->", "--\\u003e")

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
