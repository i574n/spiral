defmodule Mix.Tasks.Spiral.CellsServer do
  use Mix.Task

  @shortdoc "Keep one warm Cells VM serving spiral.notebook runs (one at a time) on a loopback port"

  @impl Mix.Task
  def run(_args) do
    Mix.Task.run("loadpaths")
    Spiral.Cells.Domain.ensure!()
    Spiral.Cells.Server.serve()
  end
end
