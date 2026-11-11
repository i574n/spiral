defmodule Spiral.Cells.MountTextParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Domain

  @root Path.expand("../../../../..", __DIR__)

  defp old_sibling_project(text), do: text |> then(&Regex.replace(~r/^packageDir:\s*.+$/m, &1, "packageDir: ..")) |> old_sibling_entries()

  defp old_relative?(item), do: String.starts_with?(item, ["./", "../", ".\\", "..\\"])

  defp old_sibling_entries(text) do
    Enum.reduce(old_package_entries(text), text, fn {item, declared}, acc ->
      if old_relative?(item) do
        suffix = String.replace_prefix(declared, item, "")
        String.replace(acc, ~r/^(\s+)#{Regex.escape(declared)}\s*$/m, "\\1#{old_basename(item)}#{suffix}")
      else
        acc
      end
    end)
  end

  defp old_package_entries(text) do
    {entries, _} =
      Enum.reduce(String.split(text, ~r/\r?\n/), {[], :out}, fn line, {entries, mode} ->
        cond do
          String.starts_with?(line, "packages:") -> {entries, :in}
          String.starts_with?(line, "modules:") -> {entries, :out}
          line != "" and not String.starts_with?(line, [" ", "\t"]) -> {entries, :out}
          mode == :in and old_entry(line) != nil -> {[old_entry(line) | entries], :in}
          true -> {entries, mode}
        end
      end)

    Enum.reverse(entries)
  end

  defp old_entry(line) do
    item = String.trim(line)

    cond do
      item == "" -> nil
      String.starts_with?(item, "|") -> nil
      true -> {item |> String.trim_trailing("-") |> String.trim_trailing("*"), item}
    end
  end

  defp old_basename(item), do: item |> String.replace("\\", "/") |> Path.basename()

  defp old_nested(names), do: Enum.find(names, &(&1 |> String.replace("\\", "/") |> Path.dirname() != "."))

  defp old_patch(body, old, new), do: if(String.contains?(body, old), do: {:ok, String.replace(body, old, new, global: false)}, else: :error)

  @skipped ["target", "_build", "deps", "node_modules", "tmp", "build"]

  defp manifests(dir) do
    case File.ls(dir) do
      {:ok, names} -> Enum.flat_map(Enum.sort(names), &manifest_entry(dir, &1))
      {:error, _} -> []
    end
  end

  defp manifest_entry(dir, name) do
    path = Path.join(dir, name)

    cond do
      name in ["package.spiproj", "spiral.toml"] -> [path]
      String.starts_with?(name, ".") or name in @skipped -> []
      match?({:ok, %File.Stat{type: :directory}}, File.lstat(path)) -> manifests(path)
      true -> []
    end
  end

  defp spiproj_text(file) do
    text = File.read!(file)
    if String.ends_with?(file, ".toml"), do: Domain.from_toml(text), else: text
  end

  test "the Spiral sibling project equals the Elixir one on every manifest of the repo" do
    files = manifests(@root)
    assert length(files) > 15
    differing = for file <- files, text = spiproj_text(file), Domain.mount_sibling_project(text) != old_sibling_project(text), do: file
    assert differing == []
  end

  test "the sibling project agrees on CRLF, an empty packageDir value and repeated relative entries" do
    cases = [
      "packageDir: ../lib\r\npackages:\r\n    ../a-\r\n    ./b*-\r\nmodules:\r\n    main\r\n",
      "packages:\n    ../x/y/\n    |core-\n    ../x/y/\nmodules:\n    ../x/y/\n    main\n",
      "packageDir:   ../../far  \npackages:\n\t..\\win\\pkg-\nmodules:\n    main\n"
    ]

    for text <- cases, do: assert(Domain.mount_sibling_project(text) == old_sibling_project(text), inspect(text))
  end

  test "a rewritten last line keeps the final newline that the Elixir regex swallowed" do
    for text <- ["packages:\n    ../x/y/\n", "packages:\n\t..\\win\\pkg-\n"] do
      assert Domain.mount_sibling_project(text) == old_sibling_project(text) <> "\n", inspect(text)
    end
  end

  test "the nested name and the first-occurrence patch agree with the Elixir ones" do
    for names <- [[], ["a.spi"], ["a.spi", "./b.spi", "sub/c.spi"], ["x\\y.spi"], ["c.spi", "d/e.spi", "f/g.spi"]] do
      assert Domain.mount_nested_name(names) == old_nested(names), inspect(names)
    end

    for {body, old, new} <- [{"a b a", "a", "x"}, {"abc", "z", "y"}, {"", "", "n"}, {"aaa", "aa", "b"}] do
      assert Domain.mount_patch_first(body, old, new) == old_patch(body, old, new), inspect({body, old, new})
    end
  end
end
