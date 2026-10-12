defmodule Mix.Tasks.Spiral.Edit do
  use Mix.Task
  alias Spiral.Kino.Document

  @shortdoc "Replace a text in one cell of a .livemd notebook (the cell is re-rendered, its smart-cell attributes too)"

  @impl Mix.Task
  def run(args) do
    Mix.Task.run("loadpaths")
    Spiral.Kino.Domain.ensure!()
    {opts, _} = OptionParser.parse!(args, strict: [path: :string, old: :string, new: :string])
    path = opts[:path] || Mix.raise("missing --path")
    old = (opts[:old] || Mix.raise("missing --old")) |> File.read!() |> String.replace("\r\n", "\n")
    new = (opts[:new] || Mix.raise("missing --new")) |> File.read!() |> String.replace("\r\n", "\n")
    if old == "", do: Mix.raise("--old is empty")

    doc = path |> File.read!() |> Document.parse_livemd()
    hits = Enum.map(doc.cells, &occurrences(&1.source, old))

    case Enum.sum(hits) do
      1 ->
        cells = Enum.map(doc.cells, &%{&1 | source: String.replace(&1.source, old, new)})
        File.write!(path, Document.to_livemd(%{doc | cells: cells}))
        Mix.shell().info("#{path}: cell #{Enum.find_index(hits, &(&1 == 1))} edited")

      n ->
        Mix.raise("#{path}: the --old text occurs #{n} times across the cells (exactly 1 needed)")
    end
  end

  defp occurrences(text, part), do: length(String.split(text, part)) - 1
end
