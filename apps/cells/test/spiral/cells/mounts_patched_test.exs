defmodule Spiral.Cells.MountsPatchedTest do
  use ExUnit.Case, async: true
  alias Spiral.Cells.Mounts

  setup do
    package = Spiral.Cells.TestHelpers.tmp_dir!("patched_mount")
    File.write!(Path.join(package, "package.spiproj"), "packageDir: ../somewhere\nmodules:\n    trial\n")
    File.write!(Path.join(package, "trial.spi"), "inl answer () = 1i32\n")
    File.write!(Path.join(package, "other.spi"), "inl other () = 3i32\n")
    %{package: package}
  end

  test "a patched mount rewrites only its copy, keeps the source, and gets its own key", %{package: package} do
    patched = [%{name: "trial", kind: :patched, target: package, patches: [{"trial.spi", "1i32", "2i32"}], package_dir: :siblings}]
    plain = [%{name: "trial", kind: :shadow, target: package}]

    assert {:ok, patched_dir} = Mounts.ensure(patched)
    assert {:ok, plain_dir} = Mounts.ensure(plain)
    refute patched_dir == plain_dir
    assert File.read!(Path.join([patched_dir, "trial", "trial.spi"])) == "inl answer () = 2i32\n"
    assert File.read!(Path.join(package, "trial.spi")) == "inl answer () = 1i32\n"
    assert File.read!(Path.join([patched_dir, "trial", "other.spi"])) == "inl other () = 3i32\n"
    assert File.read!(Path.join([patched_dir, "trial", "package.spiproj"])) =~ "packageDir: ..\n"
  end

  test "a patched package that does not share mounted deps keeps its packageDir, made absolute", %{package: package} do
    entries = [%{name: "trial", kind: :patched, target: package, patches: [{"trial.spi", "1i32", "4i32"}], package_dir: :absolute}]
    assert {:ok, dir} = Mounts.ensure(entries)
    assert File.read!(Path.join([dir, "trial", "package.spiproj"])) =~ "packageDir: " <> Path.expand("../somewhere", package)
  end

  test "a patch whose old text is absent is refused instead of mounting the unpatched file", %{package: package} do
    entries = [%{name: "trial", kind: :patched, target: package, patches: [{"trial.spi", "9i32", "2i32"}], package_dir: :siblings}]
    assert {:error, message} = Mounts.ensure(entries)
    assert message =~ "does not apply"
  end

  test "--patch reads a JSON spec whose files resolve against the spec's folder" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("patch_spec")
    spec = Path.join(dir, "patch.json")
    File.write!(spec, JSON.encode!([%{"file" => "pkg/trial.spi", "old" => "1i32", "new" => "2i32 | x"}]))
    assert [{file, "1i32", "2i32 | x"}] = Spiral.Cells.NotebookCli.patches(patch: spec)
    assert file == Path.expand(Path.join([dir, "pkg", "trial.spi"]))
  end
end
