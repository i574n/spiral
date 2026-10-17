defmodule Spiral.Cells.NotebookCli do
  alias Spiral.Cells.Notebook

  @switches [
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
    test: :keep,
    memo: :boolean,
    accept: :boolean,
    x_compat: :boolean
  ]

  @single_path_options [:output_path, :spi_path, :spir_path, :fs_path, :livemd_path]

  @spec execute([String.t()]) :: {:ok | {:error, String.t()}, [String.t()]}
  def execute(args) do
    case OptionParser.parse(args, strict: @switches) do
      {opts, _rest, []} -> execute_parsed(opts)
      {_opts, _rest, invalid} -> {{:error, "unknown or invalid options: #{inspect(invalid)}"}, []}
    end
  end

  defp execute_parsed(opts) do
    paths = Keyword.get_values(opts, :path)
    tests = test_names(opts)

    cond do
      paths == [] ->
        {{:error, "missing --path"}, []}

      length(paths) > 1 and Enum.any?(@single_path_options, &opts[&1]) ->
        {{:error, "--output-path, --spi-path, --spir-path, --fs-path and --livemd-path take a single --path"}, []}

      true ->
        if opts[:output_dir], do: File.mkdir_p!(opts[:output_dir])

        case tests_by_path(paths, tests, &Notebook.test_names/1) do
          {:ok, filters} -> run_paths(paths, tests, filters, opts)
          {:error, message} -> {{:error, message}, []}
        end
    end
  end

  defp test_names(opts) do
    opts
    |> Keyword.get_values(:test)
    |> Enum.flat_map(&String.split(&1, ",", trim: true))
    |> Enum.map(&String.trim/1)
    |> Enum.reject(&(&1 == ""))
  end

  defp run_paths(paths, tests, filters, opts) do
    results =
      paths
      |> Enum.reject(&(tests != [] and filters[&1] == []))
      |> Enum.map(fn path ->
        {status, report} =
          Notebook.run_report(path,
            output_path: output_path(path, opts),
            spi_path: opts[:spi_path],
            spir_path: opts[:spir_path],
            fs_path: opts[:fs_path],
            livemd_path: opts[:livemd_path],
            export_only: opts[:export_only] == true,
            with_tests: opts[:with_tests] == true,
            html: opts[:html] != false,
            spi: opts[:spi] != false,
            tests: filters[path],
            memo: opts[:memo],
            accept: opts[:accept] == true
          )

        {Path.expand(path), status, report}
      end)

    reports = for {path, _status, report} <- results, report != nil, do: {path, report}
    lines = x_compat_lines(paths, opts) ++ if(reports == [], do: [], else: Notebook.summary_lines(reports))

    case for({path, {:error, message}, _report} <- results, do: "#{path}: #{message}") do
      [] -> {:ok, lines}
      failures -> {{:error, Enum.join(failures, "\n")}, lines}
    end
  end

  @doc false
  def x_compat_lines(paths, opts) do
    for path <- paths,
        opts[:x_compat] == true or Spiral.Cells.XCompat.edition3?(path),
        finding <- path |> File.read!() |> Spiral.Cells.XCompat.rewrites(),
        do: "x-compat " <> Spiral.Cells.XCompat.format(Path.expand(path), finding)
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
