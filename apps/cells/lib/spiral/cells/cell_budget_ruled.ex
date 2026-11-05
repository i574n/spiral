defmodule Spiral.Cells.CellBudgetRuled do
  @moduledoc false
  alias Spiral.Cells.CellBudget

  @hint "measured with the GRANULAR rules (a one-line-arm match counts its longest arm, the header is excluded, a " <>
          "literal-only template counts its heaviest piece); split this body"

  def over_budget(source, profile \\ CellBudget.default_profile()) do
    source
    |> CellBudget.top_level_blocks()
    |> Enum.with_index(1)
    |> Enum.flat_map(fn {{row, block}, cell} ->
      weight = ruled_weight(block, profile)
      limit = limit(cell, profile)
      if weight > limit, do: [%{kind: :over_budget, line: row, column: 1, text: "weight #{weight} > #{limit}", hint: @hint}], else: []
    end)
  end

  @type_heads [":|", ":==", ":!", "type ", "union ", "nominal "]
  @string_literal ~r/"(?:[^"\\]|\\.)*"/
  @logic ["?= ", " ? ", "?> ", ":= ", "\\ ", "fun ", "|>", "<|"]

  def ruled_weight(block, profile) do
    lines = block |> String.split("\n") |> undocumented()
    code = Enum.join(lines, "\n")

    cond do
      String.starts_with?(code, @type_heads) ->
        0

      true ->
        case split_header(lines) do
          {:ok, body} -> body_weight(body, profile)
          :error -> CellBudget.cell_weight(block, profile)
        end
    end
  end

  defp undocumented(lines) do
    case Enum.drop_while(lines, &(String.starts_with?(&1, "///") and not String.starts_with?(&1, "///>"))) do
      [] -> lines
      rest -> rest
    end
  end

  defp body_weight(body, profile) do
    text = Enum.join(body, "\n")

    cond do
      data_literal?(text) ->
        0

      template?(text) ->
        @string_literal |> Regex.scan(text) |> Enum.map(fn [piece] -> CellBudget.cell_weight(piece, profile) end) |> Enum.max()

      true ->
        case flat_dispatch(body) do
          {:ok, match_line, arms} -> CellBudget.cell_weight(match_line, profile) + Enum.max(Enum.map(arms, &CellBudget.cell_weight(&1, profile)))
          :error -> CellBudget.cell_weight(text, profile)
        end
    end
  end

  def data_literal?(text) do
    bare = Regex.replace(@string_literal, text, "\"\"") |> String.trim()

    String.starts_with?(bare, ["{", "[", "(", ";["]) and not String.contains?(bare, @logic) and
      not Regex.match?(~r/(?<![\w.'"])[a-z_][\w']*[ \t]+(?![=:;,\]\})|\s])/, bare) and
      not Regex.match?(~r/(?<![\w.'"])[a-z_][\w']*\(/, bare)
  end

  def template?(text) do
    bare = Regex.replace(@string_literal, text, "")
    Regex.match?(@string_literal, text) and String.trim(String.replace(bare, ["++#", "^^", "(", ")"], "")) == ""
  end

  defp limit(cell, profile) do
    header = String.replace(profile.header, "{block}", Integer.to_string(cell)) <> profile.header_separator
    profile.weight_limit - CellBudget.cell_weight(header, profile)
  end

  defp split_header([first | rest]) do
    cond do
      String.starts_with?(first, ["///", ":#"]) -> :error
      String.ends_with?(String.trim_trailing(first), " =") -> {:ok, rest}
      Regex.match?(~r/ = \S/, first) and not String.starts_with?(first, " ") -> {:ok, [first |> String.split(" = ", parts: 2) |> List.last()] ++ rest}
      true ->
        case Enum.split_while(rest, &(String.trim(&1) != "=")) do
          {_params, ["" <> _eq | body]} -> {:ok, body}
          _ -> :error
        end
    end
  end

  defp flat_dispatch([match_line | arms]) do
    trimmed = String.trim(match_line)
    arm_lines = Enum.map(arms, &String.trim/1) |> Enum.reject(&(&1 == ""))

    if String.starts_with?(trimmed, "?= ") and String.ends_with?(trimmed, "?|") and arm_lines != [] and
         Enum.all?(Enum.zip(arms |> Enum.reject(&(String.trim(&1) == "")), arm_lines), fn {raw, arm} ->
           String.starts_with?(arm, "| ") and String.length(raw) <= 120 and
             not String.contains?(arm, ["?= ", " ? ", "?> ", ":= ", "\\ ", "fun "])
         end),
       do: {:ok, trimmed, arm_lines},
       else: :error
  end

  defp flat_dispatch(_), do: :error
end
