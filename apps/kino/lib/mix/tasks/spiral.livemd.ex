defmodule Mix.Tasks.Spiral.Livemd do
  use Mix.Task
  alias Spiral.Kino.Document

  @shortdoc "Convert .dib notebooks to .livemd (refused unless the .livemd keeps every cell and export)"

  # mix spiral.livemd <nb>.dib... writes <nb>.livemd next to each .dib. A conversion is written only when the .livemd
  # reads back as the same cells (kind and source) and exports the same .spi and .spir as the .dib; the refused ones
  # are listed at the end, with the first cell that differs.
  @impl Mix.Task
  def run(args) do
    Mix.Task.run("loadpaths")
    Spiral.Kino.Domain.ensure!()
    {_, paths} = OptionParser.parse!(args, strict: [])
    if paths == [], do: Mix.raise("usage: mix spiral.livemd <notebook.dib>...")

    case Enum.flat_map(paths, &convert/1) do
      [] -> :ok
      refused -> Mix.raise("not converted:\n" <> Enum.join(refused, "\n"))
    end
  end

  defp convert(path) do
    dib = path |> File.read!() |> Document.parse_dib()
    livemd = Document.to_livemd(dib)
    back = Document.parse_livemd(livemd)

    checks = [
      cells: cells(dib) == cells(back),
      spi: Document.to_spi(dib) == Document.to_spi(back),
      spir: Document.to_spir(dib) == Document.to_spir(back)
    ]

    case for({name, false} <- checks, do: name) do
      [] ->
        out = Path.rootname(path) <> ".livemd"
        File.write!(out, livemd)
        Mix.shell().info("#{out} (#{length(dib.cells)} cells)")
        []

      failed ->
        ["#{path}: would change #{Enum.join(failed, ", ")}#{first_difference(cells(dib), cells(back))}"]
    end
  end

  defp cells(%{cells: cells}), do: Enum.map(cells, &{&1.kind, String.trim(&1.source)})

  defp first_difference(left, right) do
    pairs = Enum.zip(left ++ List.duplicate(nil, max(0, length(right) - length(left))), right ++ List.duplicate(nil, max(0, length(left) - length(right))))

    case Enum.find_index(pairs, fn {a, b} -> a != b end) do
      nil ->
        ""

      i ->
        {a, b} = Enum.at(pairs, i)
        "; cell #{i}: dib #{inspect(a, limit: 6, printable_limit: 160)} vs livemd #{inspect(b, limit: 6, printable_limit: 160)}"
    end
  end
end
