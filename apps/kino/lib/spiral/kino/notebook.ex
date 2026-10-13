defmodule Spiral.Kino.Notebook do
  alias Spiral.Kino.{Builders, Document, Memo, ProcessError, Result, SpiralError, Targets}

  @default_timeout 300_000
  @run_keys [
    :compile,
    :rustc,
    :execute,
    :target,
    :host,
    :spiral,
    :python,
    :lua,
    :pwsh,
    :cc,
    :dcc,
    :keep_files,
    :compiler_dll,
    :dotnet,
    :rustc_bin,
    :workspace,
    :package_dir,
    :workspace_root,
    :polyglot_root,
    :env,
    :print_code,
    :plot,
    :render_plot
  ]
  @lib_rels [
    "deps/polyglot/deps/spiral/lib/spiral",
    "deps/spiral/lib/spiral",
    "lib/spiral",
    "polyglot/deps/spiral/lib/spiral"
  ]

  @type status :: :ok | {:error, String.t()}
  @type verdict :: :passed | {:failed, String.t()} | {:unsupported, String.t()}
  @type evaluation :: %{
          status: status(),
          outputs: %{non_neg_integer() => [map()]},
          durations: %{non_neg_integer() => {non_neg_integer(), map()}},
          verdicts: %{non_neg_integer() => verdict()},
          unavailable: %{non_neg_integer() => [String.t()]},
          report: map()
        }

  @spec run(String.t(), keyword()) :: status()
  def run(path, opts \\ []) when is_binary(path) do
    {status, _report} = run_report(path, opts)
    status
  end

  @spec run_report(String.t(), keyword()) :: {status(), map() | nil}
  def run_report(path, opts \\ []) when is_binary(path) do
    path = Path.expand(path)
    opts = Keyword.put(opts, :path, path)
    opts = if Path.extname(path) == ".spi" and !opts[:spi_path], do: Keyword.put(opts, :spi, false), else: opts
    opts = if Path.extname(path) == ".spi", do: Keyword.put_new(opts, :plan, :tests), else: opts
    text = File.read!(path)
    parsed = parse(path, text)
    if opts[:livemd_path], do: File.write!(opts[:livemd_path], Document.to_livemd(parsed))
    doc = expand_lisp(parsed, opts)

    if opts[:export_only] do
      write_exports(path, doc, opts)
      {:ok, nil}
    else
      run_cells(path, doc, opts)
    end
  end

  @spec test_names(String.t()) :: [String.t()]
  def test_names(path) do
    path = Path.expand(path)

    path
    |> parse(File.read!(path))
    |> Document.tests()
    |> Enum.flat_map(&[&1.name, &1.symbol])
    |> Enum.uniq()
  end

  @spec evaluate(%{cells: [map()]}, keyword()) :: evaluation()
  def evaluate(%{cells: cells} = doc, opts \\ []) do
    root = opts[:root] || if(opts[:path], do: Path.dirname(opts[:path]), else: File.cwd!())
    tests = Document.tests(doc)

    ran =
      case select_tests(tests, opts[:tests]) do
        {:error, message} ->
          %{no_runs() | status: {:error, message}}

        {:ok, selected} ->
          if Enum.any?(cells, &runnable?/1) do
            try do
              execute(doc, opts, root, selected)
            rescue
              error -> %{no_runs() | status: {:error, Exception.message(error)}}
            end
          else
            %{no_runs() | status: {:error, empty_message(opts[:path] || "the notebook")}}
          end
      end

    selected = selected_indices(tests, opts[:tests])

    %{
      status: ran.status,
      outputs: ran.outputs,
      durations: ran.durations,
      verdicts: ran.verdicts,
      unavailable: ran.unavailable,
      memo: ran.memo,
      targets: ran.targets,
      report: report(tests, selected, ran)
    }
  end

  defp select_tests(_tests, nil), do: {:ok, nil}
  defp select_tests(_tests, []), do: {:ok, nil}

  defp select_tests(tests, names) do
    known = tests |> Enum.map(& &1.name) |> Enum.uniq()

    symbols = Enum.map(tests, & &1.symbol)

    case Enum.reject(names, &(&1 in known or &1 in symbols)) do
      [] ->
        {:ok, selected_indices(tests, names)}

      unknown ->
        {:error,
         "unknown test #{Enum.join(unknown, ", ")}; the notebook has: " <>
           if(known == [], do: "no tests", else: Enum.join(known, ", "))}
    end
  end

  defp selected_indices(_tests, names) when names in [nil, []], do: nil

  defp selected_indices(tests, names) do
    tests |> Enum.filter(&(&1.name in names or &1.symbol in names)) |> MapSet.new(& &1.index)
  end

  @report_counts ~w(discovered executed passed failed accepted built skipped unsupported filtered not_run memo_hits)

  defp report(tests, selected, %{verdicts: verdicts, unavailable: unavailable, memo: memo} = ran) do
    targets = Map.get(ran, :targets, %{})

    rows =
      Enum.map(tests, fn test ->
        {state, message} = test_state(test, selected, Map.get(verdicts, test.index))

        %{
          "index" => test.index,
          "name" => test.name,
          "symbol" => test.symbol,
          "title" => test.title,
          "mode" => test.mode,
          "realm" => test.realm,
          "status" => state,
          "unavailable" => Map.get(unavailable, test.index, []),
          "targets" => target_rows(Map.get(targets, test.index, []))
        }
        |> then(&if(memo[test.index], do: Map.put(&1, "memo", Atom.to_string(memo[test.index])), else: &1))
        |> then(&if(state == "not_run", do: Map.put(&1, "reason", not_run_reason(ran.status)), else: &1))
        |> then(&if(message, do: Map.put(&1, "message", message), else: &1))
      end)

    counts(rows) |> Map.put("tests", rows)
  end

  @doc false
  def counts(rows) do
    by = Enum.frequencies_by(rows, & &1["status"])
    count = &Map.get(by, &1, 0)

    %{
      "discovered" => length(rows),
      "executed" => count.("passed") + count.("failed") + count.("accepted") + count.("built"),
      "built" => count.("built"),
      "accepted" => count.("accepted"),
      "passed" => count.("passed"),
      "failed" => count.("failed"),
      "skipped" => count.("skipped"),
      "unsupported" => count.("unsupported"),
      "filtered" => count.("filtered"),
      "not_run" => count.("not_run"),
      "memo_hits" => Enum.count(rows, &(&1["memo"] == "hit"))
    }
  end

  defp not_run_reason({:error, message}), do: "the run stopped before this test: " <> first_line(message)
  defp not_run_reason(_status), do: "no step ran for this cell"

  defp target_rows(targets) do
    Enum.map(targets, fn row -> %{"target" => row.target, "status" => row.status, "ms" => row.ms} end)
  end

  defp test_state(%{mode: "ignore"}, _selected, _verdict), do: {"skipped", nil}

  defp test_state(test, selected, verdict) do
    cond do
      selected != nil and not MapSet.member?(selected, test.index) -> {"filtered", nil}
      verdict == :passed -> {"passed", nil}
      verdict == :built -> {"built", nil}
      match?({:failed, _}, verdict) -> {"failed", first_line(elem(verdict, 1))}
      match?({:unsupported, _}, verdict) -> {"unsupported", first_line(elem(verdict, 1))}
      true -> {"not_run", nil}
    end
  end

  defp first_line(text), do: text |> String.split("\n", parts: 2) |> hd()

  @spec summary_lines([{String.t(), map()}]) :: [String.t()]
  def summary_lines(reports) do
    files =
      Enum.flat_map(reports, fn {path, report} ->
        report["tests"]
        |> Enum.group_by(&source_file(path, &1["realm"]))
        |> Enum.sort()
        |> Enum.map(fn {file, rows} ->
          counts(rows)
          |> Map.put("file", file)
          |> Map.put("failed_tests", for(row <- rows, row["status"] == "failed", do: row["name"]))
        end)
        |> case do
          [] -> [counts([]) |> Map.put("file", path) |> Map.put("failed_tests", [])]
          lines -> lines
        end
      end)

    total =
      Enum.reduce(files, Map.new(@report_counts, &{&1, 0}), fn file, acc ->
        Map.new(acc, fn {key, n} -> {key, n + file[key]} end)
      end)
      |> Map.put("files", length(files))

    Enum.map(files, &("spiral-tests file " <> JSON.encode!(&1))) ++
      ["spiral-tests total " <> JSON.encode!(total)]
  end

  defp source_file(path, "real") do
    if Path.extname(path) == ".spi", do: Path.rootname(path) <> "_real.spir", else: path
  end

  defp source_file(path, _realm), do: path

  defp write_exports(path, doc, opts) do
    {to_spi, to_spir} =
      if opts[:with_tests],
        do: {&Document.to_spi_tested/1, &Document.to_spir_tested/1},
        else: {&Document.to_spi/1, &Document.to_spir/1}

    if opts[:spi] != false, do: File.write!(opts[:spi_path] || Path.rootname(path) <> ".spi", to_spi.(doc))
    if opts[:spir_path], do: File.write!(opts[:spir_path], to_spir.(doc))
    if opts[:fs_path], do: write_fs(doc, opts)
  end

  defp write_fs(doc, opts) do
    spiral = Spiral.Kino.Toolchain.spiral(opts)
    dir = Path.join(System.tmp_dir!(), "spiral_kino_fs_#{System.unique_integer([:positive])}")
    cells = Path.join(dir, Path.basename(opts[:fs_path], ".fs") <> ".cells")

    try do
      File.mkdir_p!(dir)
      File.write!(cells, Document.to_cell_text(doc))

      case cli_export(spiral || "spiral", cells, "fs") do
        {_, 0} -> File.cp!(Path.rootname(cells) <> ".fs", opts[:fs_path])
        {output, status} -> raise "spiral export fs failed (exit #{status}): #{output}"
      end
    after
      File.rm_rf(dir)
    end
  end

  defp cli_export(spiral, path, kind) do
    case System.cmd(spiral, ["export", path, kind], stderr_to_stdout: true) do
      {output, status} when status != 0 ->
        if output =~ "unrecognized subcommand",
          do: System.cmd(spiral, ["dib-export", path, kind], stderr_to_stdout: true),
          else: {output, status}

      result ->
        result
    end
  end

  defp expand_lisp(%{cells: cells} = doc, opts) do
    %{doc | cells: Enum.map(cells, fn
      %{kind: :spiral, source: source} = cell -> %{cell | source: Spiral.Kino.Lisp.expand(source, opts)}
      cell -> cell
    end)}
  end

  defp run_cells(path, doc, opts) do
    output_path = opts[:output_path] || path <> ".ipynb"
    root = opts[:root] || Path.dirname(path)
    evaluation = evaluate(doc, Keyword.put(opts, :root, root)) |> accept_mismatches(path, opts)
    %{status: status, outputs: outputs, durations: durations, report: report} = evaluation

    outputs =
      case status do
        {:error, message} when outputs == %{} ->
          index = Enum.find_index(doc.cells, &(&1.kind != :markdown)) || 0
          %{index => error_output(message)}

        _ ->
          outputs
      end

    File.write!(output_path, JSON.encode!(ipynb(doc, outputs, durations, report)))

    result =
      case status do
        :ok ->
          if opts[:tests] in [nil, []], do: write_exports(path, doc, opts)

          if opts[:html], do: write_html(output_path), else: :ok

        {:error, message} ->
          {:error, message}
      end

    {result, report}
  end

  defp accept_mismatches(evaluation, path, opts) do
    failures =
      for %{"status" => "failed", "index" => index, "name" => name} <- evaluation.report["tests"],
          {:failed, message} <- [Map.get(evaluation.verdicts, index)],
          do: {name, message}

    if opts[:accept] && Path.extname(path) == ".spi" && failures != [] do
      case Spiral.Kino.Accept.accept(path, failures) do
        results when is_list(results) -> mark_accepted(evaluation, results)
        _ -> evaluation
      end
    else
      evaluation
    end
  end

  defp mark_accepted(evaluation, results) do
    accepted = for {name, :ok} <- results, do: name
    refused = Map.new(for {name, {:error, reason}} <- results, do: {name, reason})

    rows =
      Enum.map(evaluation.report["tests"], fn row ->
        cond do
          row["name"] in accepted and row["status"] == "failed" -> Map.put(row, "status", "accepted")
          Map.has_key?(refused, row["name"]) -> Map.put(row, "accept_refused", refused[row["name"]])
          true -> row
        end
      end)

    accepted_indices = for %{"status" => "accepted", "index" => index} <- rows, do: index
    remaining = for {index, {:failed, _}} <- evaluation.verdicts, index not in accepted_indices, do: index
    status = if accepted_indices != [] and remaining == [], do: :ok, else: evaluation.status
    %{evaluation | status: status, report: Map.merge(evaluation.report, counts(rows)) |> Map.put("tests", rows)}
  end

  @spec write_html(String.t()) :: :ok | {:error, String.t()}
  def write_html(ipynb) do
    case System.find_executable("jupyter") do
      nil ->
        IO.puts(:stderr, "spiral.notebook: jupyter is not on PATH; skipping the html for #{ipynb}")
        :ok

      jupyter ->
        args = ["nbconvert", ipynb, "--to", "html", "--HTMLExporter.theme=dark"]

        case System.cmd(jupyter, args, stderr_to_stdout: true) do
          {_, 0} ->
            html = Path.rootname(ipynb) <> ".html"
            File.write!(html, html |> File.read!() |> normalize_html())
            :ok

          {out, status} ->
            {:error, "jupyter nbconvert failed (exit #{status})\n#{out}"}
        end
    end
  end

  @doc false
  def normalize_html(text) do
    [first | rest] =
      Regex.split(~r/(?<=id="cell-id=)[a-fA-F0-9]{8}/, String.replace(text, "\r\n", "\n"))

    rest
    |> Enum.with_index(1)
    |> Enum.reduce([first], fn {part, n}, acc -> [acc, Integer.to_string(n), part] end)
    |> IO.iodata_to_binary()
  end

  defp parse(path, text) do
    case Path.extname(path) do
      ".livemd" -> Document.parse_livemd(text)
      ".spi" -> Document.parse_spi(text, real_sibling(path))
      _ -> Document.parse_dib(text)
    end
  end

  defp real_sibling(spi) do
    spir = Path.rootname(spi) <> "_real.spir"
    if File.regular?(spir), do: File.read!(spir), else: ""
  end

  defp runnable?(%{kind: :spiral}), do: true
  defp runnable?(%{kind: :import}), do: true
  defp runnable?(cell), do: Targets.host_key(cell) != nil

  defp empty_message(path) do
    "livebook did not run #{path}: no spiral cells"
  end

  defp execute(doc, opts, root, selected) do
    workspace = Spiral.Kino.workspace_root(opts)
    cells = Enum.map(doc.cells, &canon_cell(&1, root, workspace))
    lib = opts[:spiral_lib] || (opts[:path] && find_spiral_lib(opts[:path])) || "-"

    spiral =
      cells
      |> Spiral.Kino.Domain.encode_cells()
      |> then(&(lib <> "\n" <> &1))
      |> plan(opts[:plan])
      |> Spiral.Kino.Domain.decode_plan()
      |> Enum.map(&attach_source(&1, cells))
      |> only_selected(selected)

    memo = Memo.context(opts, spiral)
    {spiral, recalled} = recall(spiral, memo)

    fsi? = fsi_session?(opts)

    hosts =
      if selected == nil, do: host_steps(cells, fsi?) ++ fsi_steps(cells, fsi?), else: []

    steps = Enum.sort_by(spiral ++ hosts, & &1.index)

    case if(spiral == [], do: :ok, else: ensure_compiler(opts)) do
      :ok ->
        ran =
          if System.get_env("SPIRAL_KINO_CELLS") == "serial" do
            run_serial(steps, opts, root)
          else
            run_parallel(steps, opts, root)
          end

        flags =
          Map.new(recalled, &{elem(&1, 0), :hit})
          |> Map.merge(for(%{memo: _} = step <- spiral, into: %{}, do: {step.index, :miss}))

        %{collect(recalled, ran) | memo: flags}

      {:error, message} ->
        %{no_runs() | status: {:error, message}}
    end
  end

  defp recall(steps, nil), do: {steps, []}

  defp recall(steps, memo) do
    Enum.reduce(steps, {[], []}, fn step, {left, recalled} ->
      case memo_key(memo, step) do
        nil ->
          {left ++ [step], recalled}

        key ->
          started = System.monotonic_time(:millisecond)

          case Memo.fetch(memo, key) do
            {:ok, %{result: result} = value} ->
              ms = {System.monotonic_time(:millisecond) - started, %{}, Map.get(value, :targets, [])}
              {left, recalled ++ [{step.index, result, ms}]}

            _ ->
              {left ++ [Map.put(step, :memo, {memo, key})], recalled}
          end
      end
    end)
  end

  defp memo_key(memo, step) do
    lines =
      case Map.fetch(step, :builders) do
        {:ok, builders} -> builders
        :error -> Builders.commands(step.cell_source)
      end
      |> Enum.map(& &1.raw)

    Memo.key(memo, step, lines)
  rescue
    _ -> nil
  end

  defp remember(%{memo: {memo, key}}, {:ok, _outputs, _unavailable} = result, targets), do: Memo.store(memo, key, %{result: result, targets: targets})
  defp remember(%{memo: {memo, key}}, {:ok, _outputs} = result, targets), do: Memo.store(memo, key, %{result: result, targets: targets})
  defp remember(%{memo: {memo, key}}, {:built, _outputs} = result, targets), do: Memo.store(memo, key, %{result: result, targets: targets})
  defp remember(_step, _result, _targets), do: :ok

  defp plan(wire, :tests), do: Spiral.Kino.Domain.plan_tests(wire)
  defp plan(wire, _cells), do: Spiral.Kino.Domain.plan(wire)

  defp only_selected(steps, nil), do: steps
  defp only_selected(steps, selected), do: Enum.filter(steps, &MapSet.member?(selected, &1.index))

  defp ensure_compiler(opts) do
    if shared_boot?(opts) do
      case Spiral.Kino.CompilerClient.ensure() do
        :ok -> :ok
        {:error, error} -> {:error, error_text(error)}
      end
    else
      :ok
    end
  end

  defp shared_boot?(opts) do
    System.get_env("SPIRAL_KINO_COMPILER") != "process" and opts[:compile] == nil and
      opts[:compiler_dll] == nil and opts[:dotnet] == nil and opts[:package_dir] == nil and
      opts[:workspace] == nil and opts[:env] == nil
  end

  defp no_runs, do: %{outputs: %{}, durations: %{}, status: :ok, verdicts: %{}, unavailable: %{}, memo: %{}, targets: %{}}

  defp run_serial(steps, opts, root) do
    Enum.reduce_while(steps, no_runs(), fn step, acc ->
      case collect(run_step(step, opts, root), acc) do
        %{status: :ok} = acc -> {:cont, acc}
        acc -> {:halt, acc}
      end
    end)
  end

  defp run_parallel(steps, opts, root) do
    steps
    |> Task.async_stream(&run_step(&1, opts, root),
      max_concurrency: max(min(length(steps), cell_concurrency()), 1),
      ordered: true,
      timeout: :infinity
    )
    |> Enum.zip(steps)
    |> Enum.reduce(no_runs(), fn
      {{:ok, entries}, _step}, acc ->
        collect(entries, acc)

      {{:exit, reason}, step}, acc ->
        text = Exception.format_exit(reason)
        collect([{step.index, {:error, error_output(text), text}, nil}], acc)
    end)
  end

  defp cell_concurrency do
    case Integer.parse(System.get_env("SPIRAL_KINO_CELL_CONCURRENCY") || "") do
      {n, ""} when n > 0 -> n
      _ -> 4
    end
  end

  defp collect(entries, acc) do
    Enum.reduce(entries, acc, fn {index, result, ms}, acc ->
      acc =
        case ms do
          {elapsed, phases, [_ | _] = targets} ->
            acc |> put_in([:durations, index], {elapsed, phases}) |> put_in([:targets, index], targets)

          {elapsed, phases, []} ->
            put_in(acc, [:durations, index], {elapsed, phases})

          nil ->
            acc

          ms ->
            put_in(acc, [:durations, index], ms)
        end

      case result do
        {:ok, outputs} ->
          acc |> put_in([:outputs, index], outputs) |> put_in([:verdicts, index], :passed)

        {:built, outputs} ->
          acc |> put_in([:outputs, index], outputs) |> put_in([:verdicts, index], :built)

        {:ok, outputs, []} ->
          acc |> put_in([:outputs, index], outputs) |> put_in([:verdicts, index], :passed)

        {:ok, outputs, unavailable} ->
          acc
          |> put_in([:outputs, index], outputs)
          |> put_in([:verdicts, index], :passed)
          |> put_in([:unavailable, index], unavailable)

        {:unsupported, outputs, message} ->
          acc
          |> put_in([:outputs, index], outputs)
          |> put_in([:verdicts, index], {:unsupported, message})

        {:error, outputs, message} ->
          %{
            acc
            | outputs: Map.put(acc.outputs, index, outputs),
              verdicts: Map.put(acc.verdicts, index, {:failed, message}),
              status: keep_error(acc.status, message)
          }
      end
    end)
  end

  defp keep_error(:ok, message), do: {:error, message}
  defp keep_error(status, _message), do: status

  defp run_step(%{kind: :fsi} = step, opts, root) do
    step.cells
    |> Spiral.Kino.FsiChain.run(
      root: root,
      timeout: opts[:timeout],
      session: fsi_session_opts(opts)
    )
    |> Enum.map(fn
      {index, {:ok, %{stdout: stdout, value: value}}, ms} ->
        {index, {:ok, success_output(%Result{stdout: stdout, value: value, exit_status: 0})},
         {ms, %{}}}

      {index, {:error, text}, ms} ->
        {index, {:error, error_output(text), text}, {ms, %{}}}
    end)
  end

  defp run_step(step, opts, root) do
    started = System.monotonic_time(:millisecond)
    Process.delete(:spiral_kino_last_phases)
    Process.delete(:spiral_kino_last_targets)
    result = dispatch_step(step, opts, root)
    targets = Spiral.Kino.last_targets()
    remember(step, result, targets)

    [
      {step.index, result,
       {System.monotonic_time(:millisecond) - started, Spiral.Kino.last_phases(), targets}}
    ]
  end

  defp fsi_session?(opts) do
    opts[:host] == nil and System.get_env("SPIRAL_KINO_FSHARP") != "script"
  end

  defp fsi_session_opts(opts) do
    Keyword.take(opts, [:dotnet, :formatting_dll])
  end

  defp fsi_steps(_cells, false), do: []

  defp fsi_steps(cells, true) do
    case cells
         |> Enum.with_index()
         |> Enum.flat_map(fn
           {%{kind: :import, source: source}, index} ->
             [%{index: index, kind: :import, source: source}]

           {cell, index} ->
             if fsharp?(cell) and not Spiral.Kino.FsiChain.ignored?(cell.source),
               do: [%{index: index, kind: :fsharp, source: cell.source}],
               else: []
         end) do
      [] -> []
      [first | _] = fs_cells -> [%{index: first.index, timeout: "-", kind: :fsi, cells: fs_cells}]
    end
  end

  defp fsharp?(cell), do: match?({:fsharp, _}, Targets.host_key(cell))

  defp dispatch_step(%{kind: :host} = step, opts, root) do
    {result, _waited} = Spiral.Kino.Slots.run(fn -> dispatch_host(step, opts, root) end)
    result
  end

  defp dispatch_step(step, opts, root), do: dispatch_spiral(step, opts, root)

  defp dispatch_host(%{language: language, source: source}, opts, root) do
    timeout = opts[:timeout] || @default_timeout
    started = System.monotonic_time(:millisecond)

    deadline =
      case timeout do
        :infinity -> :infinity
        ms -> started + ms
      end

    try do
      case Targets.host(language, source, run_opts(opts, root, timeout), timeout, deadline) do
        {:ok, %{stdout: stdout}} ->
          {:ok, success_output(%Result{stdout: stdout, exit_status: 0})}

        {:error, %ProcessError{reason: :tool_missing} = error} ->
          unsupported(error)

        {:error, error} ->
          text = error_text(error)
          {:error, error_output(text), text}
      end
    rescue
      error ->
        text = Exception.message(error)
        {:error, error_output(text), text}
    end
  end

  defp dispatch_spiral(step, opts, root) do
    timeout = opts[:timeout] || positive_int(step.timeout) || @default_timeout

    try do
      opts =
        opts
        |> run_opts(root, timeout)
        |> Keyword.put(:builders, Builders.commands(step.cell_source))
        |> Keyword.put(:real, Map.get(step, :real, ""))
        |> Keyword.put(:agree, agreement?(step.cell_source))
        |> Keyword.put(:test_cell, Regex.match?(~r/^\/\/\/- [^\n]*--test\b/m, step.cell_source))
        |> Keyword.put(:build_only, build_only?(step.cell_source))

      ran = Spiral.Kino.run(step.program, opts)

      cond do
        build_only?(step.cell_source) -> built(ran)
        expected = expectation(step.cell_source) -> expected_compile_error(expected, ran)
        true -> verdict(ran)
      end
    rescue
      error ->
        text = Exception.message(error)
        {:error, error_output(text), text}
    end
  end

  defp agreement?(source) do
    Regex.match?(~r/^\/\/\/- [^\n]*--test\b/m, source) and not Regex.match?(~r/^\/\/\/- [^\n]*--no-agree\b/m, source)
  end

  defp build_only?(source), do: Regex.match?(~r/^\/\/\/- [^\n]*--build-only\b/m, source)

  defp built({:ok, %Result{exit_status: status}}) when status in [nil, 0] do
    {:built, [stream("stdout", "built every target; not run (build_only)\n")]}
  end

  defp built(ran), do: verdict(ran)

  defp verdict(ran) do
    case ran do
      {:ok, %Result{exit_status: status} = result} when status in [nil, 0] ->
        {:ok, success_output(result), result.unavailable}

      {:error, %ProcessError{reason: :tool_missing} = error} ->
        unsupported(error)

      {:ok, %Result{} = result} ->
        text = "cell exited #{result.exit_status}\n#{result.stdout}"
        {:error, error_output(text), text}

      {:error, error} ->
        text = error_text(error)
        {:error, error_output(text), text}
    end
  end

  @doc false
  def expectation(source) do
    with [_, clause] <- Regex.run(~r/^\/\/\/- [^\n]*--fails\s+(.*?)\s*$/m, source),
         [_, code, substring] <- Regex.run(~r/\A(?:(\S+)\s+)?"(.*)"\z/, clause) do
      %{code: if(code == "", do: nil, else: code), substring: substring}
    else
      _ -> nil
    end
  end

  defp expected_label(%{code: nil, substring: substring}), do: inspect(substring)
  defp expected_label(%{code: code, substring: substring}), do: "#{code} #{inspect(substring)}"

  @diagnostic_code ~r/\bE[A-Z]{2,4}\d{4}\b/

  defp expected_compile_error(expected, {:error, %SpiralError{message: message}}) do
    has_text = String.contains?(message, expected.substring)
    has_code = expected.code == nil or String.contains?(message, expected.code)

    cond do
      has_text and has_code ->
        text = "failed to compile as expected (#{expected_label(expected)}): #{first_line(message)}\n"
        {:ok, [stream("stdout", text)], []}

      has_text and not Regex.match?(@diagnostic_code, message) ->
        text = "the diagnostic matches #{inspect(expected.substring)} but carries no error code (expected #{expected.code}):\n#{message}"
        {:error, error_output(text), text}

      true ->
        text = "expected a compile error #{expected_label(expected)}, got a different one:\n#{message}"
        {:error, error_output(text), text}
    end
  end

  defp expected_compile_error(_expected, {:error, %ProcessError{reason: :tool_missing} = error}), do: unsupported(error)

  defp expected_compile_error(expected, {:ok, %Result{}}) do
    text = "expected a compile error #{expected_label(expected)}, but the program compiled"
    {:error, error_output(text), text}
  end

  defp expected_compile_error(expected, {:error, error}) do
    text = "expected a compile error #{expected_label(expected)}, but it failed past compiling:\n#{error_text(error)}"
    {:error, error_output(text), text}
  end

  defp unsupported(error) do    text = "unsupported on this machine: " <> error_text(error)
    {:unsupported, [stream("stderr", text)], text}
  end

  defp run_opts(opts, root, timeout) do
    opts
    |> Keyword.take(@run_keys)
    |> Keyword.put(:root, root)
    |> Keyword.put(:timeout, timeout)
  end

  defp attach_source(step, cells) do
    source =
      case Enum.at(cells, step.index) do
        %{kind: :spiral, source: source} -> source
        _ -> ""
      end

    Map.merge(step, %{kind: :spiral, cell_source: source})
  end

  defp host_steps(cells, fsi?) do
    {_, steps} =
      cells
      |> Enum.with_index()
      |> Enum.reduce({%{}, []}, fn {cell, index}, {acc, steps} ->
        case Targets.host_key(cell) do
          nil ->
            {acc, steps}

          {:fsharp, _} when fsi? ->
            {acc, steps}

          {key, language} ->
            source = join_host(Map.get(acc, key, ""), cell.source)
            step = %{index: index, timeout: "-", kind: :host, language: language, source: source}
            {Map.put(acc, key, source), steps ++ [step]}
        end
      end)

    steps
  end

  defp join_host("", next), do: next
  defp join_host(prev, next), do: prev <> "\n\n" <> next

  defp canon_cell(%{kind: :spiral, source: source} = cell, root, workspace) do
    %{cell | source: canon_source(source, root, workspace)}
  end

  defp canon_cell(cell, _root, _workspace), do: cell

  defp canon_source(source, root, workspace) do
    source
    |> String.split("\n")
    |> Enum.map_join("\n", &canon_line(&1, root, workspace))
  end

  defp canon_line(line, root, workspace) do
    trimmed = String.trim_leading(line)

    case trimmed do
      "///- " <> rest ->
        prefix = String.slice(line, 0, String.length(line) - String.length(trimmed))
        flags = rest |> String.split() |> canon_flags([], root, workspace) |> Enum.join(" ")
        prefix <> "///- " <> flags

      _ ->
        line
    end
  end

  defp canon_flags([], acc, _root, _workspace), do: Enum.reverse(acc)

  defp canon_flags(["--package", path | rest], acc, root, workspace) do
    canon_flags(
      rest,
      [Spiral.Kino.package_path(path, root, workspace), "--package" | acc],
      root,
      workspace
    )
  end

  defp canon_flags([token | rest], acc, root, workspace) do
    canon_flags(rest, [token | acc], root, workspace)
  end

  defp positive_int(nil), do: nil
  defp positive_int("-"), do: nil

  defp positive_int(text) do
    case Integer.parse(to_string(text)) do
      {n, ""} when n > 0 -> n
      _ -> nil
    end
  end

  defp find_spiral_lib(path) do
    path
    |> Path.dirname()
    |> ancestors()
    |> Enum.find_value(fn dir ->
      Enum.find_value(@lib_rels, fn rel ->
        candidate = Path.join(dir, rel)
        if File.regular?(Path.join(candidate, "package.spiproj")), do: Path.expand(candidate)
      end)
    end)
  end

  defp ancestors(dir) do
    dir = Path.expand(dir)
    parent = Path.dirname(dir)
    if parent == dir, do: [dir], else: [dir | ancestors(parent)]
  end

  defp success_output(result) do
    stdout =
      if result.stdout in [nil, ""], do: [], else: [stream("stdout", result.stdout)]

    value =
      if result.value in [nil, ""] do
        []
      else
        [
          %{
            "output_type" => "execute_result",
            "execution_count" => 1,
            "metadata" => %{},
            "data" => %{"text/plain" => jupyter_lines(result.value)}
          }
        ]
      end

    stdout ++ Enum.map(result.displays, &display_output/1) ++ value
  end

  @doc false
  def display_output(%{mime: mime, data: data}) do
    %{"output_type" => "display_data", "metadata" => %{}, "data" => %{mime => jupyter_lines(data)}}
  end

  defp error_output(text) do
    [
      %{
        "output_type" => "error",
        "ename" => "SpiralError",
        "evalue" => text |> String.split("\n") |> hd(),
        "traceback" => jupyter_lines(text)
      }
    ]
  end

  defp stream(name, text) do
    %{"output_type" => "stream", "name" => name, "text" => jupyter_lines(text)}
  end

  defp error_text(error) do
    if is_exception(error), do: Exception.message(error), else: inspect(error)
  end

  defp ipynb(doc, outputs, durations, report) do
    tests = Map.new(report["tests"], &{&1["index"], &1})

    {cells, _} =
      doc.cells
      |> Enum.with_index()
      |> Enum.map_reduce(1, fn {cell, index}, n ->
        ran = Map.has_key?(outputs, index)

        json =
          cell_json(
            cell,
            Map.get(outputs, index, []),
            if(ran, do: n, else: nil),
            Map.get(durations, index)
          )
          |> test_metadata(Map.get(tests, index))

        {json, if(ran, do: n + 1, else: n)}
      end)

    %{
      "nbformat" => 4,
      "nbformat_minor" => 5,
      "metadata" => %{
        "kernelspec" => %{
          "display_name" => "Spiral",
          "language" => "spiral",
          "name" => "spiral"
        },
        "spiral_tests" => report
      },
      "cells" => cells
    }
  end

  defp test_metadata(json, nil), do: json

  defp test_metadata(json, test) do
    put_in(json, ["metadata", "spiral_test"], Map.take(test, ["name", "symbol", "title", "status", "mode", "realm", "targets"]))
  end

  defp cell_json(%{kind: :markdown, source: source}, _outputs, _count, _duration) do
    %{"cell_type" => "markdown", "metadata" => %{}, "source" => jupyter_lines(source)}
  end

  defp cell_json(cell, outputs, count, duration) do
    outputs =
      Enum.map(outputs, fn
        %{"output_type" => "execute_result"} = output -> %{output | "execution_count" => count}
        other -> other
      end)

    metadata = %{"language" => language(cell)}

    metadata =
      case duration do
        {ms, phases} when is_integer(ms) and map_size(phases) > 0 ->
          metadata
          |> Map.put("duration_ms", ms)
          |> Map.put("phases_ms", Map.new(phases, fn {key, value} -> {phase_key(key), value} end))

        {ms, _phases} when is_integer(ms) ->
          Map.put(metadata, "duration_ms", ms)

        _ ->
          metadata
      end

    %{
      "cell_type" => "code",
      "metadata" => metadata,
      "execution_count" => count,
      "source" => jupyter_lines(source_of(cell)),
      "outputs" => outputs
    }
  end

  defp phase_key(key), do: key |> Atom.to_string() |> String.replace_suffix("_ms", "")

  defp source_of(%{kind: :import, source: source}), do: "#!import " <> source
  defp source_of(%{source: source}), do: source

  defp language(%{kind: :fsharp}), do: "fsharp"
  defp language(%{kind: :import}), do: "fsharp"
  defp language(%{kind: :code, language: language}), do: language
  defp language(_), do: "spiral"

  defp jupyter_lines(""), do: [""]

  defp jupyter_lines(text) do
    text = String.replace(text, "\r\n", "\n")
    lines = String.split(text, "\n")

    lines =
      if String.ends_with?(text, "\n"), do: Enum.drop(lines, -1), else: lines

    case lines do
      [] ->
        [""]

      _ ->
        {init, [last]} = Enum.split(lines, -1)

        Enum.map(init, &(&1 <> "\n")) ++
          if(String.ends_with?(text, "\n"), do: [last <> "\n"], else: [last])
    end
  end
end
