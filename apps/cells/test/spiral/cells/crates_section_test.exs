defmodule Spiral.Cells.CratesSectionTest do
  use ExUnit.Case, async: true
  alias Spiral.Cells.{Builders, Mounts}

  @tag :tmp_dir
  test "a package's crates: section becomes rust deps that the cell's own -d overrides", %{tmp_dir: dir} do
    File.write!(Path.join(dir, "package.spiproj"), "packages:\n    |core-\ncrates:\n    near-sdk={version='=5.11.0',features=['unit-testing']}\n    borsh=1.5\nmodules:\n    main\n")
    crates = Mounts.declared_crates(dir)
    assert crates == ["near-sdk={version='=5.11.0',features=['unit-testing']}", "borsh=1.5"]
    [rust, gleam] = Builders.with_crates([%{tool: :rust, deps: [%{name: "borsh", version: "1.6", raw: "borsh=1.6"}]}, %{tool: :gleam, deps: []}], crates)
    assert Enum.map(rust.deps, & &1.name) == ["borsh", "near-sdk"]
    assert hd(rust.deps).version == "1.6"
    assert gleam.deps == []
  end
end
