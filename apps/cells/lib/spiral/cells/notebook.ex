defmodule Spiral.Cells.Notebook do
  alias Spiral.Cells.{Domain, ProcessError, SpiralError, Targets, TimeoutError}

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
    :env,
    :print_code,
    :plot,
    :render_plot,
    :build_receipt,
    :compiler_pin
  ]
  @lib_rels [
    "deps/spiral/lib/spiral",
    "lib/spiral",
    "spiral/lib/spiral"
  ]

  @type status :: :ok | {:error, String.t()}
  @type verdict :: :passed | {:failed, String.t()} | {:unsupported, String.t()} | {:timed_out, String.t()}
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
    parsed = parse(path, text, compiler_bounds?(opts))
    if opts[:livemd_path], do: File.write!(opts[:livemd_path], Domain.to_livemd_doc(parsed))
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
    |> Domain.tests_doc()
    |> Enum.flat_map(&[&1.name, &1.symbol])
    |> Enum.uniq()
  end

  @spec evaluate(%{cells: [map()]}, keyword()) :: evaluation()
  def evaluate(%{cells: cells} = doc, opts \\ []) do
    root = opts[:root] || if(opts[:path], do: Path.dirname(opts[:path]), else: File.cwd!())
    tests = Domain.tests_doc(doc)

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
            %{no_runs() | status: {:error, Spiral.Cells.Domain.empty_message(opts[:path] || "the notebook")}}
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
      report:
        report(tests, selected, ran)
        |> with_no_agree_reasons(cells)
        |> with_compiler_pin(opts[:compiler_pin])
        |> with_whole_memo_keys(Map.get(ran, :whole_memo_keys, false))
    }
  end

  @doc false
  def with_compiler_pin(report, pin) when is_binary(pin) and pin != "",
    do: Map.put(report, "compiler", %{"pin" => pin, "stamp" => Path.basename(Path.dirname(pin))})

  def with_compiler_pin(report, _pin), do: report

  @doc false
  def with_whole_memo_keys(report, true), do: Map.put(report, "memo_keys", "whole")
  def with_whole_memo_keys(report, _whole), do: report

  defp with_no_agree_reasons(report, cells), do: Spiral.Cells.Domain.no_agree_report(report, cells)

  defp select_tests(_tests, names) when names in [nil, []], do: {:ok, nil}

  defp select_tests(tests, names) do
    wire = &Enum.map_join(tests, "\n", &1)

    case Spiral.Cells.Domain.unknown_tests(wire.(& &1.name), wire.(& &1.symbol), Enum.join(names, "\n")) do
      "" -> {:ok, selected_indices(tests, names)}
      message -> {:error, message}
    end
  end

  defp selected_indices(_tests, names) when names in [nil, []], do: nil

  defp selected_indices(tests, names) do
    tests |> Enum.filter(&(&1.name in names or &1.symbol in names)) |> MapSet.new(& &1.index)
  end


  defp report(tests, selected, ran) do
    rows = Spiral.Cells.Domain.report_rows(tests, selected, ran)
    counts(rows) |> Map.put("tests", rows)
  end

  @doc false
  def counts(rows), do: Spiral.Cells.Domain.report_counts(rows)


  defp headroom_warn do
    case Float.parse(System.get_env("SPIRAL_CELLS_HEADROOM_WARN") || "") do
      {threshold, ""} when threshold > 0 -> threshold
      _ -> 0.5
    end
  end



  @doc false
  def write_metrics(dir, reports) do
    File.mkdir_p!(dir)
    wire = JSON.encode!(Domain.json_safe(Enum.map(reports, fn {path, report} -> %{"stem" => Path.basename(path, Path.extname(path)), "tests" => report["tests"]} end)))
    File.write!(Path.join(dir, "tests.tsv"), Spiral.Cells.Domain.metrics_tsv(wire))
  end

  @spec summary_lines([{String.t(), map()}]) :: [String.t()]
  def summary_lines(reports) do
    wire = JSON.encode!(Domain.json_safe(Enum.map(reports, fn {path, report} -> %{"path" => path, "tests" => report["tests"]} end)))
    wire |> Spiral.Cells.Domain.summary_lines_json(Float.to_string(headroom_warn() * 1.0)) |> String.split("\n")
  end

  defp write_exports(path, doc, opts) do
    {to_spi, to_spir} =
      if opts[:with_tests],
        do: {&Domain.to_spi_tested_doc/1, &Domain.to_spir_tested_doc/1},
        else: {&Domain.to_spi_doc/1, &Domain.to_spir_doc/1}

    if opts[:spi] != false, do: File.write!(opts[:spi_path] || Path.rootname(path) <> ".spi", to_spi.(doc))
    if opts[:spir_path], do: File.write!(opts[:spir_path], to_spir.(doc))
    if opts[:fs_path], do: write_fs(doc, opts)
  end

  defp write_fs(doc, opts) do
    spiral = Spiral.Cells.Domain.tool("spiral", opts)
    dir = Path.join(System.tmp_dir!(), "spiral_cells_fs_#{System.unique_integer([:positive])}")
    cells = Path.join(dir, Path.basename(opts[:fs_path], ".fs") <> ".cells")

    try do
      File.mkdir_p!(dir)
      File.write!(cells, Domain.to_cell_text_doc(doc))

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
      %{kind: :spiral, source: source} = cell -> %{cell | source: Spiral.Cells.Domain.lisp_transpile(source, Spiral.Cells.Domain.tool("spl2spi", opts) || "")}
      cell -> cell
    end)}
  end

  defp run_cells(path, doc, opts) do
    output_path = opts[:output_path] || path <> ".ipynb"
    root = opts[:root] || Path.dirname(path)
    pool_before = Spiral.Cells.CompilerClient.pool_stats()
    evaluation = evaluate(doc, Keyword.put(opts, :root, root)) |> accept_mismatches(path, opts)
    pool_after = Spiral.Cells.CompilerClient.pool_stats()
    %{status: status, outputs: outputs, durations: durations, report: report} = evaluation

    outputs =
      case status do
        {:error, message} when outputs == %{} ->
          index = Enum.find_index(doc.cells, &(&1.kind != :markdown)) || 0
          %{index => {:error, message}}

        _ ->
          outputs
      end

    File.mkdir_p!(Path.dirname(output_path))

    tests = Map.new(report["tests"], &{&1["index"], &1})

    doc.cells
    |> Enum.with_index()
    |> Enum.each(fn {cell, index} -> keep_phase_row(cell, Map.get(durations, index), Map.get(tests, index)) end)

    pool = compiler_pool(pool_before, pool_after)
    safe_outputs = Map.new(outputs, fn {index, raw} -> {index, sanitize_output(raw)} end)
    File.write!(output_path, Spiral.Cells.Domain.ipynb_text(Spiral.Cells.Domain.encode_cells(doc.cells), safe_outputs, durations, report, pool))
    if opts[:html], do: write_html(output_path)

    result =
      case status do
        :ok ->
          if opts[:tests] in [nil, []], do: write_exports(path, doc, opts)
          :ok

        {:error, message} ->
          {:error, message}
      end

    {result, report}
  end

  @accept_rounds 25

  defp accept_mismatches(evaluation, path, opts) do
    failures = failures_with_output(evaluation)

    if opts[:accept] && Path.extname(path) == ".spi" && failures != [] do
      mark_accepted(evaluation, settle_accepts(path, opts, failures, 1, %{}))
    else
      evaluation
    end
  end

  defp failures_with_output(evaluation) do
    for %{"status" => "failed", "index" => index, "name" => name} <- evaluation.report["tests"],
        {:failed, message} <- [Map.get(evaluation.verdicts, index)],
        do: {name, message}
  end

  defp settle_accepts(path, opts, failures, round, outcome) do
    results = Spiral.Cells.Domain.accept_sites(path, failures)

    outcome =
      Enum.reduce(results, outcome, fn
        {name, {:ok, before_line, after_line}}, acc -> Map.put(acc, name, {:accepted, before_line, after_line})
        {name, {:error, reason}}, acc -> Map.put(acc, name, {:refused, reason})
      end)

    accepted_now = for {name, {:ok, _, _}} <- results, do: name

    cond do
      accepted_now == [] ->
        outcome

      round >= @accept_rounds ->
        Enum.reduce(accepted_now, outcome, &Map.put(&2, &1, {:refused, "still failing after #{@accept_rounds} accept rounds"}))

      true ->
        doc = expand_lisp(parse(path, File.read!(path)), opts)
        rerun = evaluate(doc, Keyword.put(opts, :tests, accepted_now))

        case failures_with_output(rerun) do
          [] -> outcome
          again -> settle_accepts(path, opts, again, round + 1, outcome)
        end
    end
  end

  defp mark_accepted(evaluation, outcome), do: Spiral.Cells.Domain.mark_accepted(evaluation, outcome)

  @spec write_html(String.t()) :: :ok | {:error, String.t()}
  def write_html(ipynb) do
    Spiral.Cells.Domain.html_write(ipynb, Path.rootname(ipynb) <> ".html", Spiral.Cells.Domain.tool("dotnet", []) || "", Spiral.Cells.Domain.tool("compiler_dll", []) || "")
    :ok
  end

  @doc false
  def untargeted_tests(path) do
    path = Path.expand(path)
    doc = parse(path, File.read!(path))

    for {index, name} <- Enum.sort(test_cell_names(doc)),
        %{source: source} = Enum.at(doc.cells, index),
        Domain.builders_commands(source) == [],
        do: name
  end

  @doc false
  def refuse_retired_skip!(path, text) do
    case Spiral.Cells.Domain.retired_skip_error(path, text) do
      "" -> :ok
      message -> raise ArgumentError, message
    end
  end

  defp parse(path, text, bounded \\ false) do
    refuse_retired_skip!(path, text)

    case Path.extname(path) do
      ".livemd" -> Domain.parse_livemd_doc(text)
      ".spi" when bounded ->
        warn_target_gaps(path, text)
        Domain.parse_spi_bounded_doc(text, real_sibling(path), test_bounds(path), test_bounds(Path.rootname(path) <> "_real.spir"))

      ".spi" ->
        warn_target_gaps(path, text)
        Domain.parse_spi_doc(text, real_sibling(path))
      _ -> Domain.parse_dib_doc(text)
    end
  end

  defp warn_target_gaps(path, text) do
    for {line, target} <- Domain.target_gaps_doc(text) do
      IO.puts(:stderr, "warning: #{path}:#{line}: a doc comment above ended the cell that #{target} targets, so this code runs untargeted; repeat the target line after the doc comment")
    end
  end

  @stubbed_runs [:compile, :rustc, :execute, :target, :host]

  defp compiler_bounds?(opts), do: not Enum.any?(@stubbed_runs, &(Keyword.get(opts, &1) != nil))

  @doc false
  def test_bounds(path, opts \\ []) do
    out = Path.join(System.tmp_dir!(), "spiral-test-blocks-#{System.unique_integer([:positive])}.tsv")

    try do
      with true <- File.regular?(path),
           dotnet when is_binary(dotnet) <- Domain.tool("dotnet", opts),
           dll when is_binary(dll) <- Domain.tool("compiler_dll", opts),
           true <- File.regular?(dll),
           {_, 0} <- System.cmd(dotnet, [dll, "--test-blocks", path, out], stderr_to_stdout: true),
           {:ok, rows} <- File.read(out) do
        rows
      else
        _ -> ""
      end
    after
      File.rm(out)
    end
  end

  defp real_sibling(spi) do
    spir = Path.rootname(spi) <> "_real.spir"
    if File.regular?(spir), do: File.read!(spir), else: ""
  end

  defp runnable?(%{kind: :spiral}), do: true
  defp runnable?(%{kind: :import}), do: true
  defp runnable?(cell), do: Targets.host_key(cell) != nil

  defp execute(doc, opts, root, selected) do
    workspace = Spiral.Cells.workspace_root(opts)
    cells = Enum.map(doc.cells, &canon_cell(&1, root, workspace))
    lib = resolve_lib(opts)

    spiral =
      cells
      |> Spiral.Cells.Domain.encode_cells()
      |> then(&(lib <> "\n" <> &1))
      |> plan(opts[:plan])
      |> Spiral.Cells.Domain.decode_plan()
      |> Enum.map(&attach_source(&1, cells))
      |> only_selected(selected)
      |> Enum.reject(&static_prelude?(&1.cell_source))
      |> with_builders(test_cell_names(doc))
      |> keyed_on_the_whole_source()

    budgets = Map.new(spiral, &{&1.index, opts[:timeout] || Domain.scale_budget(positive_int(Map.get(&1, :timeout)) || @default_timeout)})
    memo = Domain.memo_context(opts, spiral)
    {spiral, recalled} = recall(spiral, memo)

    fsi? = fsi_session?(opts)

    hosts =
      if selected == nil, do: host_steps(cells, fsi?) ++ fsi_steps(cells, fsi?), else: []

    steps = Enum.sort_by(spiral ++ hosts, & &1.index)

    case if(spiral == [], do: :ok, else: ensure_compiler(opts)) do
      :ok ->
        ran =
          if System.get_env("SPIRAL_CELLS_CELLS") == "serial" do
            run_serial(steps, opts, root)
          else
            run_parallel(steps, opts, root)
          end

        flags =
          Map.new(recalled, &{elem(&1, 0), :hit})
          |> Map.merge(for(%{memo: _} = step <- spiral, into: %{}, do: {step.index, :miss}))

        %{collect(recalled, ran) | memo: flags} |> Map.put(:budgets, budgets) |> Map.put(:whole_memo_keys, Domain.memo_whole_keys(memo))

      {:error, message} ->
        %{no_runs() | status: {:error, message}}
    end
  end

  defp keyed_on_the_whole_source([]), do: []
  defp keyed_on_the_whole_source(steps), do: List.update_at(steps, -1, &Map.put(&1, :whole_source_key, true))
  defp recall(steps, nil), do: {steps, []}

  defp recall(steps, memo) do
    Enum.reduce(steps, {[], []}, fn step, {left, recalled} ->
      case memo_key(memo, step) do
        nil ->
          {left ++ [step], recalled}

        key ->
          started = System.monotonic_time(:millisecond)

          case Domain.memo_fetch(memo.dir, key) do
            {:ok, %{result: result} = value} ->
              ms = {System.monotonic_time(:millisecond) - started, %{}, Map.get(value, :targets, [])}
              {left, recalled ++ [{step.index, result, ms}]}

            _ ->
              {left ++ [Map.put(step, :memo, {memo, key})], recalled}
          end
      end
    end)
  end

  defp memo_key(_memo, %{untargeted: _}), do: nil
  defp memo_key(_memo, %{builder_error: _}), do: nil

  defp memo_key(memo, step) do
    lines =
      case Map.fetch(step, :builders) do
        {:ok, builders} -> builders
        :error -> Domain.builders_commands(step.cell_source)
      end
      |> Enum.map(& &1.raw)

    Domain.memo_key(memo, step, lines ++ expectation_key(expectation(step.cell_source)))
  rescue
    _ -> nil
  end

  defp expectation_key(nil), do: []
  defp expectation_key(%{code: code, substring: substring}), do: ["--fails #{code} #{inspect(substring)}"]

  defp remember(%{memo: {memo, key}}, {:ok, _outputs, _unavailable} = result, targets), do: Domain.memo_store(memo.dir, key, %{result: result, targets: targets})
  defp remember(%{memo: {memo, key}}, {:ok, _outputs} = result, targets), do: Domain.memo_store(memo.dir, key, %{result: result, targets: targets})
  defp remember(%{memo: {memo, key}}, {:built, _outputs} = result, targets), do: Domain.memo_store(memo.dir, key, %{result: result, targets: targets})
  defp remember(_step, _result, _targets), do: :ok

  defp plan(wire, :tests), do: Spiral.Cells.Domain.plan_tests(wire)
  defp plan(wire, _cells), do: Spiral.Cells.Domain.plan(wire)

  defp static_prelude?(source), do: Spiral.Cells.Domain.directive_flag(source, "--test static")

  @runnable_modes ["test", "fails", "build_only"]

  defp test_cell_names(doc), do: for(%{mode: mode} = test <- Domain.tests_doc(doc), mode in @runnable_modes, into: %{}, do: {test.index, test.name})

  @doc false
  def with_builders(steps, test_names) do
    Enum.map(steps, fn step ->
      case step_commands(step.cell_source) do
        {:error, message} ->
          step |> Map.put(:builders, []) |> put_test_name(test_names) |> Map.put(:builder_error, message)

        {:ok, []} ->
          step |> Map.put(:builders, []) |> put_test_name(test_names) |> mark_untargeted()

        {:ok, own} ->
          step |> Map.put(:builders, own) |> put_test_name(test_names)
      end
    end)
  end

  defp step_commands(source) do
    {:ok, Domain.builders_commands(source)}
  rescue
    error in ArgumentError -> {:error, Exception.message(error)}
  end

  defp put_test_name(step, test_names) do
    case Map.fetch(test_names, step.index) do
      {:ok, name} -> Map.put(step, :test_name, name)
      :error -> step
    end
  end

  defp mark_untargeted(%{test_name: name} = step), do: Map.put(step, :untargeted, name)

  defp mark_untargeted(step), do: Map.merge(step, %{program: "", real: ""})


  @doc false
  def untargeted_message(name), do: "NoTestTarget: test #{name} names no target: add a ///> <lang> line to it"
  defp only_selected(steps, nil), do: steps
  defp only_selected(steps, selected), do: Enum.filter(steps, &MapSet.member?(selected, &1.index))

  defp ensure_compiler(opts) do
    if shared_boot?(opts) do
      case Spiral.Cells.CompilerClient.ensure() do
        :ok -> :ok
        {:error, error} -> {:error, error_text(error)}
      end
    else
      :ok
    end
  end

  defp shared_boot?(opts) do
    System.get_env("SPIRAL_CELLS_COMPILER") != "process" and opts[:compile] == nil and
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
        collect([{step.index, {:error, {:error, text}, text}, nil}], acc)
    end)
  end

  defp cell_concurrency do
    case Integer.parse(System.get_env("SPIRAL_CELLS_CELL_CONCURRENCY") || "") do
      {n, ""} when n > 0 -> n
      _ -> 4
    end
  end

  defp collect(entries, acc), do: Spiral.Cells.Domain.notebook_collect(entries, acc)

  defp run_step(%{kind: :fsi} = step, opts, root) do
    step.cells
    |> Spiral.Cells.FsiChain.run(
      root: root,
      timeout: opts[:timeout],
      session: fsi_session_opts(opts)
    )
    |> Enum.map(fn
      {index, {:ok, %{stdout: stdout, value: value}}, ms} ->
        {index, {:ok, %{stdout: stdout, value: value, exit_status: 0}},
         {ms, %{}}}

      {index, {:error, text}, ms} ->
        {index, {:error, {:error, text}, text}, {ms, %{}}}
    end)
  end

  defp run_step(%{untargeted: name} = step, _opts, _root) do
    message = untargeted_message(name)
    [{step.index, {:error, {:error, message}, message}, nil}]
  end

  defp run_step(%{builder_error: reason} = step, _opts, _root) do
    message = "test #{step[:test_name] || "cell #{step.index}"}: #{reason}"
    [{step.index, {:error, {:error, message}, message}, nil}]
  end

  defp run_step(step, opts, root) do
    started = System.monotonic_time(:millisecond)
    Enum.each([:spiral_cells_last_phases, :spiral_cells_ran_at], &Process.delete/1)
    Process.delete(:spiral_cells_last_targets)
    result = step |> dispatch_step(opts, root) |> tap(fn _ -> Process.put(:spiral_cells_compared_ms, System.monotonic_time(:millisecond) - Process.get(:spiral_cells_ran_at, System.monotonic_time(:millisecond))) end)
    targets = Spiral.Cells.last_targets()
    remember(step, result, targets)

    [
      {step.index, result,
       {System.monotonic_time(:millisecond) - started, then(Spiral.Cells.last_phases(), &if(map_size(&1) > 0, do: Map.put(&1, :compare_ms, Process.get(:spiral_cells_compared_ms, 0)), else: &1)), targets}}
    ]
  end

  defp fsi_session?(opts) do
    opts[:host] == nil and System.get_env("SPIRAL_CELLS_FSHARP") != "script"
  end

  defp fsi_session_opts(opts) do
    Keyword.take(opts, [:dotnet, :formatting_dll])
  end

  defp fsi_steps(cells, enabled), do: Spiral.Cells.Domain.fsi_steps(cells, enabled)

  defp dispatch_step(%{kind: :host} = step, opts, root) do
    {result, _waited} = Spiral.Cells.Domain.slots_run(fn -> dispatch_host(step, opts, root) end, nil, nil)
    result
  end

  defp dispatch_step(step, opts, root), do: dispatch_spiral(step, opts, root)

  defp dispatch_host(%{language: language, source: source}, opts, root) do
    timeout = opts[:timeout] || Domain.scale_budget(@default_timeout)
    started = System.monotonic_time(:millisecond)

    deadline =
      case timeout do
        :infinity -> :infinity
        ms -> started + ms
      end

    try do
      case Targets.host(language, source, run_opts(opts, root, timeout), timeout, deadline) do
        {:ok, %{stdout: stdout}} ->
          {:ok, %{stdout: stdout, exit_status: 0}}

        {:error, %ProcessError{reason: :tool_missing} = error} ->
          unsupported(error)

        {:error, %TimeoutError{} = error} ->
          timed_out(error)

        {:error, error} ->
          text = error_text(error)
          {:error, {:error, text}, text}
      end
    rescue
      error ->
        text = Exception.message(error)
        {:error, {:error, text}, text}
    end
  end

  defp dispatch_spiral(step, opts, root) do
    timeout = opts[:timeout] || Domain.scale_budget(positive_int(step.timeout) || @default_timeout)

    source_path = opts[:path]

    try do
      opts =
        opts
        |> run_opts(root, timeout)
        |> Keyword.put(:builders, Map.get_lazy(step, :builders, fn -> Domain.builders_commands(step.cell_source) end))
        |> Keyword.put(:real, Map.get(step, :real, ""))
        |> Keyword.put(:agree, Spiral.Cells.Domain.agreement(step.cell_source))
        |> Keyword.put(:reference, Spiral.Cells.Domain.reference_target(step.cell_source))
        |> Keyword.put(:test_cell, Spiral.Cells.Domain.directive_flag(step.cell_source, "--test"))
        |> Keyword.put(:build_only, build_only?(step.cell_source))
        |> Keyword.put(:test_name, Map.get(step, :test_name))
        |> Keyword.put(:test_source, source_path)

      ran = if Spiral.Cells.Domain.bare_no_agree(step.cell_source), do: :bare_no_agree, else: step.program |> Spiral.Cells.run(opts) |> in_source(source_path) |> tap(fn _ -> Process.put(:spiral_cells_ran_at, System.monotonic_time(:millisecond)) end)

      cond do
        ran == :bare_no_agree ->
          text = "no_agree needs a reason: write `test name no_agree \"why the targets differ\" =` (cell: `///- --test --no-agree \"why\"`)"
          {:error, {:error, text}, text}

        build_only?(step.cell_source) -> built(ran)
        expected = expectation(step.cell_source) -> expected_compile_error(Map.put(expected, :body_head, body_head(step.cell_source)), ran)
        true -> verdict(ran)
      end
    rescue
      error ->
        text = Exception.message(error)
        {:error, {:error, text}, text}
    end
  end

  defp in_source({:error, %SpiralError{message: message, details: program} = error}, path) when is_binary(program) and is_binary(path) do
    case File.read(path) do
      {:ok, source} -> {:error, %{error | message: Spiral.Cells.Domain.source_remap(message, program, source, path)}}
      _ -> {:error, error}
    end
  end

  defp in_source(ran, _path), do: ran

  defp build_only?(source), do: Spiral.Cells.Domain.directive_flag(source, "--build-only")

  defp built({:ok, %{exit_status: status, outputs: _}}) when status in [nil, 0] do
    {:built, [Spiral.Cells.Domain.stream("stdout", "built every target; not run (build_only)\n")]}
  end

  defp built(ran), do: verdict(ran)

  defp verdict(ran) do
    case ran do
      {:ok, %{exit_status: status, outputs: _} = result} when status in [nil, 0] ->
        {:ok, result, result.unavailable}

      {:error, %ProcessError{reason: :tool_missing} = error} ->
        unsupported(error)

      {:error, %TimeoutError{} = error} ->
        timed_out(error)

      {:ok, %{exit_status: _, outputs: _} = result} ->
        text = "cell exited #{result.exit_status}\n#{result.stdout}"
        {:error, {:error, text}, text}

      {:error, error} ->
        text = error_text(error)
        {:error, {:error, text}, text}
    end
  end

  @doc false
  def expectation(source), do: Spiral.Cells.Domain.expectation(source)

  defp expected_compile_error(expected, {:error, %SpiralError{} = error}), do: Spiral.Cells.Domain.compile_outcome(expected, error)

  defp expected_compile_error(_expected, {:error, %ProcessError{reason: :tool_missing} = error}), do: unsupported(error)

  defp expected_compile_error(expected, {:ok, %{exit_status: _, outputs: _}}) do
    text = Spiral.Cells.Domain.compile_compiled_text(expected.code || "", expected.substring)
    {:error, {:error, text}, text}
  end

  defp expected_compile_error(expected, {:error, error}) do
    text = Spiral.Cells.Domain.compile_failed_text(expected.code || "", expected.substring, error_text(error))
    {:error, {:error, text}, text}
  end

  @doc false
  def body_head(cell_source) do
    case Spiral.Cells.Domain.body_head(cell_source) do
      "" -> nil
      head -> head
    end
  end

  @doc false
  def body_floor(program, head) when is_binary(program) and is_binary(head) do
    case Spiral.Cells.Domain.body_floor(program, head) do
      -1 -> nil
      index -> index
    end
  end

  def body_floor(_program, _head), do: nil

  defp unsupported(error) do
    text = "unsupported on this machine: " <> error_text(error)
    {:unsupported, [Spiral.Cells.Domain.stream("stderr", text)], text}
  end

  defp timed_out(error) do
    text = "timed out, a VOID result and not a verdict: " <> error_text(error)
    {:timed_out, [Spiral.Cells.Domain.stream("stderr", text)], text}
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

  defp host_steps(cells, fsi?), do: Spiral.Cells.Domain.host_steps(cells, fsi?)

  defp canon_cell(%{kind: :spiral, source: source} = cell, root, workspace) do
    %{cell | source: canon_source(source, root, workspace)}
  end

  defp canon_cell(cell, _root, _workspace), do: cell

  defp canon_source(source, root, workspace) do
    resolved =
      source
      |> Spiral.Cells.Domain.canon_package_paths()
      |> String.split("\n", trim: true)
      |> Enum.map_join("\n", &Spiral.Cells.package_path(&1, root, workspace))

    Spiral.Cells.Domain.canon_package_flags(source, resolved)
  end

  defp positive_int(nil), do: nil
  defp positive_int("-"), do: nil

  defp positive_int(text) do
    case Integer.parse(to_string(text)) do
      {n, ""} when n > 0 -> n
      _ -> nil
    end
  end

  @doc false
  def resolve_lib(opts) do
    opts[:spiral_lib] || spiral_lib_from_env(System.get_env("SPIRAL_CELLS_LIB")) || (opts[:path] && find_spiral_lib(opts[:path])) || "-"
  end
  @doc false
  def find_spiral_lib(path) do
    path
    |> Path.dirname()
    |> ancestors()
    |> Enum.find_value(fn dir ->
      lib_root_itself(dir) ||
      Enum.find_value(@lib_rels, fn rel ->
        candidate = Path.join(dir, rel)
        if Spiral.Cells.Domain.manifest_exists(candidate), do: Path.expand(candidate)
      end)
    end) || spiral_lib_from_env(System.get_env("SPIRAL_LIB"))
  end

  defp lib_root_itself(dir) do
    expanded = Path.expand(dir)
    if String.ends_with?(String.replace(expanded, "\\", "/"), "/lib/spiral") and Spiral.Cells.Domain.manifest_exists(expanded), do: expanded
  end

  @doc false
  def spiral_lib_from_env(value) do
    case value do
      dir when is_binary(dir) and dir != "" ->
        if Spiral.Cells.Domain.manifest_exists(dir), do: Path.expand(dir)

      _ ->
        nil
    end
  end

  defp ancestors(dir) do
    dir = Path.expand(dir)
    parent = Path.dirname(dir)
    if parent == dir, do: [dir], else: [dir | ancestors(parent)]
  end


  defp error_text(error) do
    if is_exception(error), do: Exception.message(error), else: inspect(error)
  end

  defp compiler_pool(%{} = before, %{} = after_run) do
    %{
      "served" => after_run.served - before.served,
      "refused_growth" => after_run.refused_growth - before.refused_growth,
      "peak_workers" => after_run.peak_workers,
      "last_free_mb" => after_run.last_free_mb
    }
  end

  defp compiler_pool(_before, _after_run), do: nil

  defp sanitize_output(%{exit_status: _, outputs: _} = r), do: %{r | stdout: Domain.json_safe(r.stdout), value: Domain.json_safe(r.value), displays: Domain.json_safe(r.displays)}
  defp sanitize_output({:error, text}), do: {:error, Domain.json_safe(text)}
  defp sanitize_output(other), do: Domain.json_safe(other)


  defp keep_phase_row(cell, {_ms, phases}, test) when map_size(phases) > 0 do
    case System.get_env("SPIRAL_CELLS_PHASE_ROWS") do
      path when is_binary(path) and path != "" ->
        cell_source = Spiral.Cells.Domain.source_of(Atom.to_string(cell.kind), cell.source)
        source = if test, do: ":# #{test["name"]} =\n" <> cell_source, else: cell_source
        wire = Enum.map_join([{:host_ms, System.get_env("SPIRAL_CELLS_HOST") || elem(:inet.gethostname(), 1)} | Map.to_list(phases)], "\n", fn {key, value} -> "#{Spiral.Cells.Domain.phase_key(Atom.to_string(key))}=#{value}" end)
        File.write!(path, Spiral.Cells.Domain.phase_row(not File.exists?(path), source, wire) <> "\n", [:append])

      _ ->
        :ok
    end
  end

  defp keep_phase_row(_cell, _duration, _test), do: :ok

end
