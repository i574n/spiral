defmodule Mix.Tasks.Spiral.CompilerDaemon do
  use Mix.Task

  @shortdoc "Keep one warm Spiral compiler on 127.0.0.1:13905, or SPIRAL_CELLS_COMPILER_PORT; --list shows the live ones"

  @impl Mix.Task
  def run(["--list"]) do
    Mix.Task.run("loadpaths")

    case Spiral.Cells.CompilerClient.live_daemons() do
      [] ->
        IO.puts("no compiler daemon is listening")

      daemons ->
        IO.puts("port\tpid\tstamp\tidle_min\tqueued\tretiring")
        Enum.each(daemons, fn d -> IO.puts("#{d.port}\t#{d.pid}\t#{d.stamp}\t#{d.idle_min}\t#{d.queued}\t#{d.retiring}") end)
    end
  end

  def run(_args) do
    Mix.Task.run("app.start")
    Spiral.Cells.CompilerDaemon.serve()
  end
end
