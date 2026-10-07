defmodule Mix.Tasks.Spiral.RenderDib do
  use Mix.Task
  alias Spiral.Kino.Document

  @shortdoc "Render .livemd notebooks as .dib files (the format the spiral CLI's dib-export reads)"

  # mix spiral.render_dib --out-dir <dir> --list <file>   (the notebooks' paths, one per line: a long list of paths through
  # mix.bat and cmd mangles quotes and hits the command line limit)
  # Each notebook is written as <dir>/<n>/<name>.dib (n = its position, 1-based), so two notebooks with one name don't
  # collide. apps/spiral/build.ps1 compares the previous and the new CLI's dib-export on these (since D27 the repos
  # hold no .dib files).
  @impl Mix.Task
  def run(args) do
    Mix.Task.run("loadpaths")
    Spiral.Kino.Domain.ensure!()
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
      dib = Path.join(dir, Path.basename(path, ".livemd") <> ".dib")
      File.write!(dib, path |> File.read!() |> Document.parse_livemd() |> Document.to_dib())
    end)

    Mix.shell().info("#{length(paths)} notebooks rendered as .dib in #{out}")
  end
end
