defmodule Spiral.Cells.TargetsManifestParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.{Domain, Targets}

  defp oracle(manifest) do
    [_, name] = Regex.run(~r/^name = "([^"]+)"/m, manifest)
    {name, Regex.run(~r/^target = (.*)$/m, manifest, capture: :all_but_first) || []}
  end

  test "the Spiral manifest facts match the old name and target regexes on generated and hand-written manifests" do
    generated = [
      Domain.gleam_manifest("cell/main.spi", [], "erlang"),
      Domain.gleam_manifest("cell/main_real.spi", [%{name: "gleam_json", version: "3.0.1"}, %{name: "simplifile", version: nil}], "javascript")
    ]

    crafted = [
      "x = 1\nname = \"\"\nname = \"cells\"\r\ntarget = javascript\r\n",
      "name = \"a\"\n[dependencies]\n",
      "name = \"multi\nline\"\ntarget = erlang",
      "  name = \"indented\"\nname = \"b\"\n target = no\ntarget = \"erlang\"",
      "name = \"c\"\ntarget = "
    ]

    for manifest <- generated ++ crafted, do: assert(Targets.manifest_facts(manifest) == oracle(manifest), inspect(manifest))
  end

  test "the gleam lock path keys on the same target term as before" do
    manifest = Domain.gleam_manifest("cell/main.spi", [], "erlang")
    requirements = manifest |> String.split("\n") |> Enum.drop_while(&(&1 != "[dependencies]")) |> Enum.join("\n")
    target = Regex.run(~r/^target = (.*)$/m, manifest, capture: :all_but_first) || []
    key = :crypto.hash(:sha256, :erlang.term_to_binary({target, requirements})) |> Base.encode16(case: :lower) |> binary_part(0, 24)
    assert Path.basename(Targets.gleam_lock_path(manifest, [])) == "#{key}.toml"
  end
end
