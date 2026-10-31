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
    assert Manifest.from_toml("# note\ncrates = [\n  'serde',\n  \"regex\"\n]\n") ==
             Enum.join(["", "crates:", "    serde", "    regex", ""], "\n")
  end

  @tag :tmp_dir
  test "spiral.toml is preferred, and a spiproj alone still reads", %{tmp_dir: dir} do
    refute Manifest.exists?(dir)
    File.write!(Path.join(dir, "package.spiproj"), "packageDir: a\n")
    assert Manifest.read!(dir) == "packageDir: a\n"
    File.write!(Path.join(dir, "spiral.toml"), "packageDir = 'b'\n")
    assert Manifest.path(dir) == Path.join(dir, "spiral.toml")
    assert Manifest.read!(dir) == "packageDir: b\n"
  end
end
