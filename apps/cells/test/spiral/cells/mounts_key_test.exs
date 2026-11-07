defmodule Spiral.Cells.MountsKeyTest do
  use ExUnit.Case, async: true
  alias Spiral.Cells.Mounts

  setup do
    package = Spiral.Cells.TestHelpers.tmp_dir!("keyed_mount")
    manifest = Path.join(package, "package.spiproj")
    File.write!(manifest, "packageDir: ../somewhere\nmodules:\n    probe\n")
    File.write!(Path.join(package, "probe.spi"), "inl answer () = 1i32\n")
    %{entries: [%{name: "probe", kind: :shadow, target: package}], package: package, manifest: manifest}
  end

  test "an unchanged package reuses its mount", %{entries: entries} do
    assert {:ok, first} = Mounts.ensure(entries)
    assert {:ok, ^first} = Mounts.ensure(entries)
  end

  test "a source edit gets a new mount even when the manifest keeps its mtime", %{entries: entries, package: package, manifest: manifest} do
    {:ok, %{mtime: kept}} = File.stat(manifest, time: :posix)
    assert {:ok, before} = Mounts.ensure(entries)
    File.write!(Path.join(package, "probe.spi"), "inl answer () = 22i32\n")
    File.touch!(manifest, kept)
    assert {:ok, after_edit} = Mounts.ensure(entries)
    refute before == after_edit
  end

  test "a new sibling module gets a new mount even when the manifest keeps its mtime", %{entries: entries, package: package, manifest: manifest} do
    {:ok, %{mtime: kept}} = File.stat(manifest, time: :posix)
    assert {:ok, before} = Mounts.ensure(entries)
    File.write!(Path.join(package, "terms.spi"), "inl term () = 2i32\n")
    File.touch!(manifest, kept)
    assert {:ok, after_add} = Mounts.ensure(entries)
    refute before == after_add
    assert File.exists?(Path.join([after_add, "probe", "terms.spi"]))
  end
end
