defmodule Spiral.Cells.BuilderOutputParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Domain

  @home Path.expand("../../../../../..", __DIR__)

  @prefixes ["", "  ", "\n", " ", "　 ", "noise line\n", "\e[31mred error\e[0m\n", "Build FAILED\r\n", "warn: x\n\n", "\e[1;32m\e[0m"]
  @results [
    "",
    ~S({"output":"hi"}),
    ~S({"output":"  "}),
    ~S({"output":null}),
    ~S({"command_result":"{\"output\":\"inner\"}"}),
    ~S({"command_result":{"output":"obj"}}),
    ~S({"command_result":"not json","output":"outer"}),
    ~S({"command_result":""}),
    ~S(prefix {"output":"tail"}),
    ~S({"other":1}),
    ~S({"output":"a"} trailing),
    ~S([{"output":"x"}]),
    ~S({"output":"x"}{"output":"y"}),
    ~S({"output":"dup","output":"second"}),
    "{\"output\":\"café error\"}",
    ~S({"output":"line1\nline2 failed"}),
    "{\"output\":\"x\"}\r{\"output\":\"y\"}"
  ]
  @suffixes ["", "\n", "\r\n", "  \n\n", "\v", " ", "\nmore error text", "\n{\"output\":\"last\"}", "\n\e[0m"]

  defp present(output) do
    trimmed = String.trim(output)
    field = output_field(trimmed)
    trace = trace_text(trimmed)

    cond do
      is_binary(field) and String.trim(field) != "" -> String.trim(field)
      trace != "" -> trace
      is_binary(field) -> ""
      true -> trimmed
    end
  end

  defp failure_trace(output) do
    field = output_field(output)
    trace = trace_text(output)

    cond do
      is_binary(field) and String.trim(field) != "" -> nil
      trace == "" -> nil
      failure?(trace) -> trace
      true -> nil
    end
  end

  defp failure?(trace) do
    down = String.downcase(trace)
    String.contains?(down, "error") or String.contains?(down, "failed")
  end

  defp output_field(text) do
    case result_map(text) || result_map_line(text) do
      nil -> nil
      map -> shown_output(map)
    end
  end

  defp trace_text(text) do
    text
    |> String.replace(~r/\e\[[0-9;]*m/, "")
    |> String.split(~r/\r?\n/)
    |> Enum.reject(fn line ->
      trimmed = String.trim(line)
      trimmed == "" or result_map(trimmed) != nil
    end)
    |> Enum.join("\n")
    |> String.trim()
  end

  defp result_map(text) when is_binary(text) do
    case decode_result(text) do
      nil ->
        case Regex.run(~r/(\{.*\})\s*$/, text) do
          [_, candidate] -> decode_result(candidate)
          _ -> nil
        end

      map ->
        map
    end
  end

  defp result_map_line(text) do
    text
    |> String.split(~r/\r?\n/)
    |> Enum.reverse()
    |> Enum.find_value(&result_map/1)
  end

  defp decode_result(text) do
    case json_map(text) do
      nil -> nil
      map -> if Map.has_key?(map, "output") or Map.has_key?(map, "command_result"), do: map
    end
  end

  defp shown_output(map) do
    inner = command_result(map)

    cond do
      is_binary(inner["output"]) -> inner["output"]
      is_binary(map["output"]) -> map["output"]
      true -> nil
    end
  end

  defp command_result(%{"command_result" => text}) when is_binary(text), do: json_map(text) || %{}
  defp command_result(%{"command_result" => map}) when is_map(map), do: map
  defp command_result(_), do: %{}

  defp json_map(text) when is_binary(text) and text != "" do
    case JSON.decode(text) do
      {:ok, map} when is_map(map) -> map
      _ -> nil
    end
  end

  defp json_map(_), do: nil

  defp tracked(pattern) do
    for repo <- File.ls!(@home), dir = Path.join(@home, repo), File.exists?(Path.join(dir, ".git")),
        {out, 0} = System.cmd("git", ["-C", dir, "ls-files", "-z", "--", pattern]),
        rel <- String.split(out, <<0>>, trim: true),
        file = Path.join(dir, rel),
        File.regular?(file),
        do: file
  end

  defp corpus do
    synthetic = for p <- @prefixes, r <- @results, s <- @suffixes, do: p <> r <> s
    files = tracked("*.json") |> Enum.filter(&(File.stat!(&1).size <= 65_536))
    tracked = Enum.flat_map(files, fn f -> text = File.read!(f); [text, "log line\n" <> text, text <> "\nerror: tail"] end)
    synthetic ++ tracked
  end

  test "the Spiral builder output presenter matches the Elixir one over synthetic and tracked outputs" do
    texts = corpus()
    assert length(texts) > 1500, "corpus too small (#{length(texts)} texts)"
    differing = Enum.reject(texts, &(present(&1) == Domain.builder_present(&1)))
    failing = Enum.reject(texts, &((failure_trace(&1) || "") == Domain.builder_failure_trace(&1)))
    shown = texts |> Enum.map(&present/1) |> Enum.uniq() |> length()
    IO.puts("builder output parity: #{length(texts)} texts compared (#{shown} distinct shown), #{length(differing)} present differ, #{length(failing)} failure traces differ")
    assert differing == [], "first differing present: #{differing |> List.first() |> inspect(printable_limit: 200)}"
    assert failing == [], "first differing failure trace: #{failing |> List.first() |> inspect(printable_limit: 200)}"
  end
end
