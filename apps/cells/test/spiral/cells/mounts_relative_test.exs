defmodule Spiral.Cells.MountsRelativeTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Mounts

  setup do
    root = Spiral.Cells.TestHelpers.tmp_dir!("mounts_relative")
    lib = Path.join(root, "deps/spiral/lib/spiral")
    src = Path.join(root, "src")
    app = Path.join(root, "apps/arena")
    for dir <- [lib, src, app], do: File.mkdir_p!(dir)
    File.write!(Path.join(lib, "package.spiproj"), "packages:\n    |core-\nmodules:\n    sm-\n")
    File.write!(Path.join(src, "package.spiproj"), "packages:\n    |core-\nmodules:\n    shared-\n")
    File.write!(Path.join(app, "package.spiproj"), "packageDir: ../../deps/spiral/lib\npackages:\n    |core-\n    spiral-\n    ../../src-\nmodules:\n    lua-\n")
    %{root: root, app: app}
  end

  test "a relative entry resolves from the spiproj directory, a plain one from packageDir", %{root: root, app: app} do
    targets = Map.new(Mounts.declared_dependencies(app), &{&1.name, &1.target})
    assert targets["spiral"] == Path.expand(Path.join(root, "deps/spiral/lib/spiral"))
    assert targets["src"] == Path.expand(Path.join(root, "src"))
  end

  test "the dependency closure finds the relative sibling", %{app: app} do
    names = Mounts.dependency_closure([{app, "arena"}]) |> Enum.map(&elem(&1, 1))
    assert "src" in names
    assert "spiral" in names
  end

  test "a package with a relative sibling shares the mounted deps, so it is shadowed", %{app: app} do
    assert Mounts.share_mounted_deps?(app, ["arena", "spiral", "src"])
    refute Mounts.share_mounted_deps?(app, ["arena", "spiral"])
  end
end
