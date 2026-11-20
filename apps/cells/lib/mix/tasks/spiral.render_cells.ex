defmodule Mix.Tasks.Spiral.RenderCells do
  use Mix.Task
  alias Spiral.Cells.Domain

  @shortdoc "Render .livemd notebooks as the cell text the spiral CLI's `export` reads"

  @impl Mix.Task
  def run(args) do
    Mix.Task.run("loadpaths")
    Spiral.Cells.Domain.ensure!()
    {opts, _} = OptionParser.parse!(args, strict: [out_dir: :string, list: :string])
    out = opts[:out_dir] || Mix.raise("missing --out-dir")

    paths =
      (opts[:list] || Mix.raise("missing --list"))
      |> File.read!()
      |> String.split(~r/\r?\n/, trim: true)

    paths
    |> Enum.with_index(1)
    |> Enum.each(fn {path, n} ->
      dir = Path.join(out, Integer.to_string(n))
      File.mkdir_p!(dir)
      cells = Path.join(dir, Path.basename(path, ".livemd") <> ".cells")
      File.write!(cells, path |> File.read!() |> Domain.parse_livemd_doc() |> Domain.to_cell_text_doc())
    end)

    Mix.shell().info("#{length(paths)} notebooks rendered as cell text in #{out}")
  end
end
