defmodule Mix.Tasks.Spiral.Html do
  use Mix.Task

  @shortdoc "Render .ipynb files to .html beside them (Spiral code cells colored by the compiler's tokens)"

  @impl Mix.Task
  def run(paths) do
    Mix.Task.run("loadpaths")
    if paths == [], do: Mix.raise("usage: mix spiral.html <file.ipynb>...")

    for path <- paths do
      expanded = Path.expand(path)
      Spiral.Cells.Domain.html_write(expanded, Path.rootname(expanded) <> ".html", Spiral.Cells.Domain.tool("dotnet", []) || "", Spiral.Cells.Domain.tool("compiler_dll", []) || "")
      IO.puts("spiral.html: #{Path.rootname(path)}.html")
    end
  end
end
