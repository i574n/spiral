defmodule Spiral.Cells.GleamProjectParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.{Builders, Domain, Targets}

  @home Path.expand("../../../../../..", __DIR__)

  @versions [nil, "*", ">=3.0.0", "\">=3.0.0\"", "\\\">=1.0\\\"", "\"\"\"", "", "1.0 and <2.0", "café", "a\tb", "x\u0001y", "\"\#{"]
  @names ["gleam_json", "envoy", "gleam_stdlib", "simplifile", "café_pkg"]
  @paths ["x/gleam/src/main.gleam", "y/gleam_real/src/main_real.gleam", "main_real.gleam", "a\\b_real\\main.gleam"]
  @targets ["erlang", "javascript", "weird \"t\""]

  @warning_pieces [
    "warning: Unused variable",
    "  ┌─ src/main.gleam:3:7",
    "  │",
    "3 │   let x = 1",
    "12 │ x",
    "  │       ^ This variable is never used",
    "",
    "Hint: You can ignore it with an underscore: `_x`.",
    "\tindented",
    "│ bar",
    "ok line",
    "__assert_eq { expected = 2 }",
    "warning:no space",
    "3│ tight"
  ]

  defp tracked(pattern) do
    for repo <- File.ls!(@home), dir = Path.join(@home, repo), File.exists?(Path.join(dir, ".git")),
        {out, 0} = System.cmd("git", ["-C", dir, "ls-files", "-z", "--", pattern]),
        rel <- String.split(out, <<0>>, trim: true),
        file = Path.join(dir, rel),
        File.regular?(file),
        do: file
  end

  defp real_deps do
    tracked("*.spi")
    |> Enum.map(&File.read!/1)
    |> Enum.filter(&String.valid?/1)
    |> Enum.flat_map(fn text ->
      try do
        {builders, _} = Builders.split(text)
        for %{tool: :gleam, deps: deps} <- builders, do: deps
      rescue
        ArgumentError -> []
      end
    end)
  end

  test "the Spiral gleam manifest and warning filter match the Elixir ones" do
    synthetic = for name <- @names, version <- @versions, do: [%{name: name, version: version}]
    dep_sets = [[] | real_deps()] ++ synthetic ++ [Enum.flat_map(synthetic, & &1)]
    cases = for deps <- dep_sets, path <- @paths, target <- @targets, do: {path, deps, target}
    manifests = Enum.reject(cases, fn {path, deps, target} -> Targets.gleam_manifest(path, deps, target) == Domain.gleam_manifest(path, deps, target) end)
    outputs = for a <- @warning_pieces, b <- @warning_pieces, c <- @warning_pieces, do: Enum.join([a, b, c, "tail"], "\n")
    outputs = outputs ++ Enum.map(outputs, &String.replace(&1, "\n", "\r\n"))
    stripped = Enum.reject(outputs, &(Targets.strip_gleam_warnings(&1) == Domain.gleam_strip_warnings(&1)))
    IO.puts("gleam project parity: #{length(cases)} manifests (#{length(dep_sets)} dep sets), #{length(outputs)} outputs compared, #{length(manifests)} manifests differ, #{length(stripped)} outputs differ")
    assert length(cases) > 500 and length(outputs) > 5000
    assert manifests == [], "first differing manifest: #{manifests |> List.first() |> inspect()}"
    assert stripped == [], "first differing output: #{stripped |> List.first() |> inspect()}"
  end
end
