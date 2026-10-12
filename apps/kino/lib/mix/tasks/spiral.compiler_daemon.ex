defmodule Mix.Tasks.Spiral.CompilerDaemon do
  use Mix.Task

  @shortdoc "Keep one warm Spiral compiler on 127.0.0.1:13905, or SPIRAL_KINO_COMPILER_PORT"

  @impl Mix.Task
  def run(_args) do
    Mix.Task.run("app.start")
    Spiral.Kino.CompilerDaemon.serve()
  end
end
