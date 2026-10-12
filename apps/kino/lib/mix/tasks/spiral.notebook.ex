defmodule Mix.Tasks.Spiral.Notebook do
  use Mix.Task

  @shortdoc "Run Spiral notebooks (.livemd, or a .spi with its _real.spir) and report their test blocks"

  @impl Mix.Task
  def run(args) do
    Mix.Task.run("loadpaths")
    Spiral.Kino.Domain.ensure!()

    {opts, _} =
      OptionParser.parse!(args,
        strict: [
          path: :keep,
          output_path: :string,
          spi_path: :string,
          spir_path: :string,
          fs_path: :string,
          livemd_path: :string,
          export_only: :boolean,
          with_tests: :boolean,
          html: :boolean,
          spi: :boolean,
          test: :keep
        ]
      )

    paths = Keyword.get_values(opts, :path)
    if paths == [], do: Mix.raise("missing --path")

    if length(paths) > 1 and Enum.any?([:output_path, :spi_path, :spir_path, :fs_path, :livemd_path], &opts[&1]) do
      Mix.raise("--output-path, --spi-path, --spir-path, --fs-path and --livemd-path take a single --path")
    end

    tests =
      opts
      |> Keyword.get_values(:test)
      |> Enum.flat_map(&String.split(&1, ",", trim: true))
      |> Enum.map(&String.trim/1)
      |> Enum.reject(&(&1 == ""))

    results =
      Enum.map(paths, fn path ->
        {status, report} =
          Spiral.Kino.Notebook.run_report(path,
            output_path: opts[:output_path],
            spi_path: opts[:spi_path],
            spir_path: opts[:spir_path],
            fs_path: opts[:fs_path],
            livemd_path: opts[:livemd_path],
            export_only: opts[:export_only] == true,
            with_tests: opts[:with_tests] == true,
            html: opts[:html] != false,
            spi: opts[:spi] != false,
            tests: tests
          )

        {Path.expand(path), status, report}
      end)

    reports = for {path, _status, report} <- results, report != nil, do: {path, report}
    if reports != [], do: Enum.each(Spiral.Kino.Notebook.summary_lines(reports), &IO.puts/1)

    case for({path, {:error, message}, _report} <- results, do: "#{path}: #{message}") do
      [] -> :ok
      failures -> Mix.raise(Enum.join(failures, "\n"))
    end
  end
end
