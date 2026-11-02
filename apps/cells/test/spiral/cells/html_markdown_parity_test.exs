defmodule Spiral.Cells.HtmlMarkdownParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.{Domain, Html}

  @home Path.expand("../../../../../..", __DIR__)

  defp tracked(pattern) do
    for repo <- File.ls!(@home), dir = Path.join(@home, repo), File.exists?(Path.join(dir, ".git")),
        {out, 0} = System.cmd("git", ["-C", dir, "ls-files", "-z", "--", pattern]),
        rel <- String.split(out, <<0>>, trim: true),
        file = Path.join(dir, rel),
        File.regular?(file),
        do: file
  end

  defp markdown_files, do: tracked("*.md")

  defp doc_texts do
    tracked("*.spi")
    |> Enum.filter(&(String.contains?(&1, "/spiral/lib/spiral/") or Regex.match?(~r{/spiral/apps/[^/]+/spi/}, &1)))
    |> Enum.map(fn file ->
      file |> File.read!() |> String.split("\n") |> Enum.filter(&String.starts_with?(&1, "///")) |> Enum.map_join("\n", &String.replace_prefix(&1, "/// ", ""))
    end)
    |> Enum.reject(&(&1 == ""))
  end

  test "the Spiral markdown renders exactly what the Elixir one renders over every tracked markdown and doc text" do
    texts = Enum.map(markdown_files(), &File.read!/1) ++ doc_texts()
    assert length(texts) > 100, "corpus too small (#{length(texts)} texts)"
    differing = Enum.reject(texts, &(Html.markdown(&1) == Domain.markdown_html(&1)))
    IO.puts("html markdown parity: #{length(texts)} texts compared, #{length(differing)} differ")
    assert differing == [], "first differing text starts: #{differing |> List.first() |> to_string() |> String.slice(0, 120) |> inspect()}"
  end
end