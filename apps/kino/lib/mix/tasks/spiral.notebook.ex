defmodule Mix.Tasks.Spiral.Notebook do
  use Mix.Task

  @shortdoc "Run Spiral notebooks (.livemd, or a .spi with its _real.spir) and report their test blocks"

  @impl Mix.Task
  def run(args) do
    Mix.Task.run("loadpaths")
    Spiral.Kino.Domain.ensure!()
    {status, lines} = Spiral.Kino.NotebookCli.execute(args)
    Enum.each(lines, &IO.puts/1)

    if System.get_env("SPIRAL_KINO_WARM") != "0" and System.get_env("SPIRAL_KINO_COMPILER") != "process" do
      Spiral.Kino.CompilerClient.prestart()
    end

    case status do
      :ok -> :ok
      {:error, message} -> Mix.raise(message)
    end
  end
end
