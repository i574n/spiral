defmodule Mix.Tasks.Spiral.Dib do
  use Mix.Task

  @shortdoc "Run a Spiral .dib or .livemd notebook through Livebook"

  @impl Mix.Task
  def run(args) do
    Mix.Task.run("loadpaths")
    Spiral.Kino.Domain.ensure!()

    {opts, _} =
      OptionParser.parse!(args,
        strict: [
          path: :string,
          output_path: :string,
          spi_path: :string,
          export_only: :boolean,
          html: :boolean,
          spi: :boolean
        ]
      )

    path = opts[:path] || Mix.raise("missing --path")

    # Like `spiral dib`: a successful run also writes <ipynb>.html through jupyter nbconvert (--no-html skips it).
    case Spiral.Kino.Notebook.run(path,
           output_path: opts[:output_path],
           spi_path: opts[:spi_path],
           export_only: opts[:export_only] == true,
           html: opts[:html] != false,
           spi: opts[:spi] != false
         ) do
      :ok -> :ok
      {:error, message} -> Mix.raise(message)
    end
  end
end
