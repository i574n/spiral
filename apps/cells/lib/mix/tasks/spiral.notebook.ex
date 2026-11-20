defmodule Mix.Tasks.Spiral.Notebook do
  use Mix.Task

  @shortdoc "Run Spiral notebooks (.livemd, or a .spi with its _real.spir) and report their test blocks; --gate runs them memo-off into a scratch report dir and retires the compilers"

  @impl Mix.Task
  def run(args) do
    Mix.Task.run("loadpaths")

    case Spiral.Cells.Domain.boot_main(args) do
      0 -> :ok
      3 -> exit({:shutdown, 3})
      code -> exit({:shutdown, code})
    end
  end
end
