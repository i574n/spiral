defmodule Spiral.Cells.ManifestPathParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Manifest

  @home Path.expand("../../../../../..", __DIR__)

  defp old_path(dir) do
    ["spiral.toml", "package.spiproj"] |> Enum.map(&Path.join(dir, &1)) |> Enum.find(&File.regular?/1)
  end

  defp tracked_dirs do
    for repo <- File.ls!(@home), root = Path.join(@home, repo), File.exists?(Path.join(root, ".git")),
        {out, 0} = System.cmd("git", ["-C", root, "ls-files", "-z"]),
        rel <- String.split(out, <<0>>, trim: true),
        uniq: true,
        do: Path.join(root, Path.dirname(rel))
  end

  @edges ["", ".", "/", "no_such_dir", "spi", "spi/", "spi//", "spi\\", "mix.exs", "../cells", "../../apps/cells/spi"]

  @tag :sibling_repos
  test "Spiral's manifest_path finds the same file as the Elixir it replaces" do
    dirs = tracked_dirs()
    texts = Enum.flat_map(dirs, &[&1, &1 <> "/", String.replace(&1, "/", "\\") <> "\\"]) ++ @edges
    found = Enum.count(dirs, &(old_path(&1) != nil))
    differ = for dir <- texts, old_path(dir) != Manifest.path(dir), do: {dir, old_path(dir), Manifest.path(dir)}
    IO.puts("manifest path parity: #{length(texts)} dirs compared (#{found} hold a manifest), #{length(differ)} differ")
    assert length(dirs) > 100 and found > 5 and found < length(dirs)
    assert differ == [], "first difference: #{differ |> List.first() |> inspect()}"
  end
end
