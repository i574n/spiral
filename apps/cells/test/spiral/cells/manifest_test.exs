defmodule Spiral.Cells.ManifestTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Manifest

  @toml """
  edition = 3
  packageDir = '../deps/spiral/lib'
  packages = ['|core-', 'spiral-']
  modules = '''
  fiscal_paths
      corpus
  '''
  """

  test "a spiral.toml without a module list takes the compiler's derived manifest, and falls back without one" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("manifest-derived")
    File.write!(Path.join(dir, "spiral.toml"), "edition = 3\nprelude = ['base']\n")
    derived = "edition: 3\nmodules:\n    base-\n    other\n"
    assert Manifest.read(dir, resolve: fn ^dir -> derived end) == {:ok, derived}
    assert {:ok, text} = Manifest.read(dir, resolve: fn _ -> nil end)
    assert text =~ "edition: 3"

    File.write!(Path.join(dir, "spiral.toml"), @toml)
    assert Manifest.read(dir, resolve: fn _ -> flunk("a declared module list needs no resolver") end) == {:ok, Manifest.from_toml(@toml)}
  end

  test "a spiral.toml reads as the spiproj text the parsers expect" do
    assert Manifest.from_toml(@toml) ==
             Enum.join(
               [
                 "edition: 3",
                 "packageDir: ../deps/spiral/lib",
                 "packages:",
                 "    |core-",
                 "    spiral-",
                 "modules:",
                 "    fiscal_paths",
                 "        corpus",
                 ""
               ],
               "\n"
             )
  end

  test "a list may span lines and a blank or comment line stays blank" do
    assert Manifest.from_toml("# note\nnotes = [\n  'serde',\n  \"regex\"\n]\n") ==
             Enum.join(["", "notes:", "    serde", "    regex", ""], "\n")
  end

  @tag :tmp_dir
  test "spiral.toml is preferred, and a spiproj alone still reads", %{tmp_dir: dir} do
    refute Manifest.exists?(dir)
    File.write!(Path.join(dir, "package.spiproj"), "packageDir: a\n")
    assert Manifest.read!(dir) == "packageDir: a\n"
    File.write!(Path.join(dir, "spiral.toml"), "packageDir = 'b'\n")
    assert Manifest.path(dir) == Path.join(dir, "spiral.toml")
    assert Manifest.read!(dir) in ["packageDir: b\n", "packageDir: b\nmodules:\n\n"]
  end

  test "a derived manifest is resolved once per directory state, and a failed resolve is not kept" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("manifest-cached")
    File.write!(Path.join(dir, "a.spi"), "inl a = 1\n")
    me = self()
    resolver = fn d -> send(me, {:resolved, d}); "modules:\n    a\n" end

    assert Manifest.cached(dir, resolver) == "modules:\n    a\n"
    assert Manifest.cached(dir, resolver) == "modules:\n    a\n"
    assert_received {:resolved, _}
    refute_received {:resolved, _}

    File.write!(Path.join(dir, "b.spi"), "inl b = 2\n")
    assert Manifest.cached(dir, resolver) == "modules:\n    a\n"
    assert_received {:resolved, _}

    failing = fn d -> send(me, {:failed, d}); nil end
    File.write!(Path.join(dir, "c.spi"), "inl c = 3\n")
    assert Manifest.cached(dir, failing) == nil
    assert Manifest.cached(dir, failing) == nil
    assert_received {:failed, _}
    assert_received {:failed, _}
  end
end
