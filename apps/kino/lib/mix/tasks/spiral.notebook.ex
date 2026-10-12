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
          output_dir: :string,
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
    if opts[:output_dir], do: File.mkdir_p!(opts[:output_dir])
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

    filters =
      case tests_by_path(paths, tests, &Spiral.Kino.Notebook.test_names/1) do
        {:ok, filters} -> filters
        {:error, message} -> Mix.raise(message)
      end

    results =
      paths
      |> Enum.reject(&(tests != [] and filters[&1] == []))
      |> Enum.map(fn path ->
        {status, report} =
          Spiral.Kino.Notebook.run_report(path,
            output_path: output_path(path, opts),
            spi_path: opts[:spi_path],
            spir_path: opts[:spir_path],
            fs_path: opts[:fs_path],
            livemd_path: opts[:livemd_path],
            export_only: opts[:export_only] == true,
            with_tests: opts[:with_tests] == true,
            html: opts[:html] != false,
            spi: opts[:spi] != false,
            tests: filters[path]
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

  @doc false
  def tests_by_path(paths, [], _names), do: {:ok, Map.new(paths, &{&1, []})}
  def tests_by_path([path], tests, _names), do: {:ok, %{path => tests}}

  def tests_by_path(paths, tests, names) do
    known = Map.new(paths, &{&1, names.(&1)})

    case Enum.reject(tests, fn test -> Enum.any?(known, fn {_path, in_file} -> test in in_file end) end) do
      [] -> {:ok, Map.new(known, fn {path, in_file} -> {path, Enum.filter(tests, &(&1 in in_file))} end)}
      unknown -> {:error, "unknown test #{Enum.join(unknown, ", ")}: no --path has it"}
    end
  end
  @doc false
  def output_path(path, opts) do
    cond do
      opts[:output_path] -> opts[:output_path]
      opts[:output_dir] -> Path.join(opts[:output_dir], Path.basename(path) <> ".ipynb")
      true -> nil
    end
  end
end
