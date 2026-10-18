defmodule Mix.Tasks.Spiral.Html do
  use Mix.Task

  @shortdoc "Render .ipynb files to .html beside them (Spiral code cells colored by the compiler's tokens)"

  @impl Mix.Task
  def run(paths) do
    Mix.Task.run("loadpaths")
    if paths == [], do: Mix.raise("usage: mix spiral.html <file.ipynb>...")

    for path <- paths do
      :ok = Spiral.Cells.Html.write(Path.expand(path))
      IO.puts("spiral.html: #{Path.rootname(path)}.html")
    end
  end
end
