defmodule Spiral.Cells.ManifestDeclaresParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Manifest

  @home Path.expand("../../../../../..", __DIR__)

  @edges [
    "modules=",
    "  modules =",
    "\tmodules\n=",
    "x\n\n  \nmodules =",
    "submodules = 1",
    "modules_x = 1",
    " modules : a",
    "# modules = a",
    "modules",
    "\v modules =",
    "a modules =",
    "\r\nmodules =",
    "MODULES =",
    "modules\u00a0=",
    "\u00a0modules =",
    "x = 1\r\n  modules\r\n  =",
    "",
    "\n",
    "modules =\n",
    "edition = 3\nmodules = '''\nmain\n'''"
  ]

  defp tracked(pattern) do
    for repo <- File.ls!(@home), dir = Path.join(@home, repo), File.exists?(Path.join(dir, ".git")),
        {out, 0} = System.cmd("git", ["-C", dir, "ls-files", "-z", "--", pattern]),
        rel <- String.split(out, <<0>>, trim: true),
        file = Path.join(dir, rel),
        File.regular?(file),
        do: file
  end

  test "Manifest.declares_modules? answers what the old line regex answered over every tracked manifest and the edges" do
    manifests = Enum.map(tracked("*.toml") ++ tracked("*.spiproj"), &File.read!/1)
    texts = manifests ++ Enum.flat_map(manifests, &[String.replace(&1, "modules", "  modules"), String.replace(&1, "\n", "\r\n")]) ++ @edges
    differing = Enum.reject(texts, &(Manifest.declares_modules?(&1) == Regex.match?(~r/^\s*modules\s*=/m, &1)))
    declared = Enum.count(texts, &Regex.match?(~r/^\s*modules\s*=/m, &1))
    IO.puts("manifest declares parity: #{length(texts)} texts compared (#{declared} declare modules), #{length(differing)} differ")
    assert length(manifests) > 20 and declared > 5 and declared < length(texts)
    assert differing == [], "first differing: #{differing |> List.first() |> inspect()}"
  end
end