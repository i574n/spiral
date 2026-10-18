defmodule Spiral.Cells.SourceMap do
  @location ~r/\bmain\.spi:(\d+):(\d+)/

  @spec remap(String.t(), String.t(), String.t(), String.t()) :: String.t()
  def remap(message, program, source, source_path) do
    program_lines = lines(program)
    source_lines = lines(source)

    Regex.replace(@location, message, fn whole, line, column ->
      case locate(String.to_integer(line), String.to_integer(column), program_lines, source_lines) do
        {source_line, source_column} -> "#{source_path}:#{source_line}:#{source_column} (#{whole})"
        nil -> whole
      end
    end)
  end

  @spec locate(pos_integer(), pos_integer(), [String.t()], [String.t()]) :: {pos_integer(), pos_integer()} | nil
  def locate(line, column, program_lines, source_lines) do
    with text when is_binary(text) <- Enum.at(program_lines, line - 1),
         trimmed when trimmed != "" <- String.trim(text),
         [index] <- best_matches(line, program_lines, source_lines, trimmed) do
      found = Enum.at(source_lines, index)
      {index + 1, max(column - indent(text) + indent(found), 1)}
    else
      _ -> nil
    end
  end

  defp best_matches(line, program_lines, source_lines, trimmed) do
    candidates = for {text, index} <- Enum.with_index(source_lines), String.trim(text) == trimmed, do: index

    case candidates do
      [_] -> candidates
      [] -> []
      _ -> narrow(candidates, line, program_lines, source_lines)
    end
  end

  defp narrow(candidates, line, program_lines, source_lines) do
    score = fn at ->
      Enum.count(-4..4, fn offset ->
        near = line_at(source_lines, at + offset)
        offset != 0 and near not in [nil, ""] and near == line_at(program_lines, line - 1 + offset)
      end)
    end

    scored = Enum.map(candidates, &{&1, score.(&1)})
    best = scored |> Enum.map(&elem(&1, 1)) |> Enum.max()
    for {index, ^best} <- scored, do: index
  end

  defp line_at(_lines, index) when index < 0, do: nil

  defp line_at(lines, index) do
    case Enum.at(lines, index) do
      nil -> nil
      text -> String.trim(text)
    end
  end

  defp indent(text), do: String.length(text) - String.length(String.trim_leading(text))

  defp lines(text), do: text |> String.replace("\r\n", "\n") |> String.split("\n")
end
