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
    x_compat: :boolean,
    metrics: :string,
    livemd: :boolean,
    patch: :keep,
    probe: :string,
    target: :keep
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
    paths = Keyword.get_values(opts, :path) ++ probe_paths(opts)
    tests = test_names(opts)

    cond do
      paths == [] ->
        {{:error, "missing --path or --probe"}, []}

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

  @doc false
  def patches(opts) do
    for spec <- Keyword.get_values(opts, :patch),
        %{"file" => file, "old" => old, "new" => new} <- JSON.decode!(File.read!(spec)),
        do: {Path.expand(file, Path.dirname(Path.expand(spec))), old, new}
  end

  @doc false
  def probe_paths(opts) do
    case opts[:probe] do
      nil ->
        []

      main ->
        main = Path.expand(main)
        source = File.read!(main)
        package = Path.dirname(main)
        header = if File.exists?(Path.join(package, "package.spiproj")), do: "///- --package #{package}\n\n", else: ""
        dir = Path.join(System.tmp_dir!(), "spiral-probe-#{:erlang.phash2({main, source})}")
        File.mkdir_p!(dir)
        path = Path.join(dir, "probe.spi")
        File.write!(path, header <> probe_notebook(source, Keyword.get_values(opts, :target)))
        [path]
    end
  end

  @doc false
  def probe_notebook(main_text, targets) do
    directives = Enum.map_join(targets, "", &"///> #{String.downcase(&1)}\n")
    String.trim_trailing(main_text, "\n") <> "\n\n" <> directives <> "test probe =\n    main ()\n"
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
            livemd_path: opts[:livemd_path] || livemd_target(path, opts),
            export_only: opts[:export_only] == true,
            with_tests: opts[:with_tests] == true,
            html: opts[:html] != false,
            spi: opts[:spi] != false,
            tests: filters[path],
            memo: opts[:memo],
            accept: opts[:accept] == true,
            patches: patches(opts)
          )

        {Path.expand(path), status, report}
      end)

    reports = for {path, _status, report} <- results, report != nil, do: {path, report}
    if opts[:metrics], do: Notebook.write_metrics(opts[:metrics], reports)
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
        finding <- path |> File.read!() |> Spiral.Cells.XCompat.rewrites(Spiral.Cells.XCompat.profile_for(path)),
        do: "x-compat " <> Spiral.Cells.XCompat.format(Path.expand(path), finding)
  end

  @doc false
  def tests_by_path(paths, [], _names), do: {:ok, Map.new(paths, &{&1, []})}
  def tests_by_path([path], tests, names) do
    if Enum.any?(tests, &pattern?/1), do: tests_by_known_names([path], tests, names), else: {:ok, %{path => tests}}
  end

  def tests_by_path(paths, tests, names), do: tests_by_known_names(paths, tests, names)

  defp tests_by_known_names(paths, tests, names) do
    known = Map.new(paths, &{&1, names.(&1)})

    case Enum.reject(tests, fn test -> Enum.any?(known, fn {_path, in_file} -> Enum.any?(in_file, &test_matches?(test, &1)) end) end) do
      [] -> {:ok, Map.new(known, fn {path, in_file} -> {path, Enum.filter(in_file, fn name -> Enum.any?(tests, &test_matches?(&1, name)) end)} end)}
      unknown -> {:error, "unknown test #{Enum.join(unknown, ", ")}: no --path has it"}
    end
  end

  defp pattern?(test), do: String.contains?(test, "*")

  defp test_matches?(test, name) do
    if pattern?(test) do
      body = test |> String.split("*") |> Enum.map_join(".*", &Regex.escape/1)
      Regex.match?(Regex.compile!("\\A" <> body <> "\\z"), name)
    else
      test == name
    end
  end

  @doc false
  def livemd_target(path, opts) do
    cond do
      opts[:livemd] != true -> nil
      opts[:output_path] -> Path.rootname(opts[:output_path]) <> ".livemd"
      opts[:output_dir] -> Path.join(opts[:output_dir], Path.basename(path) <> ".livemd")
      true -> path <> ".livemd"
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
