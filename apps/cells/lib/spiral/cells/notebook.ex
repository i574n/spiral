defmodule Spiral.Cells.Notebook do
  alias Spiral.Cells.{Builders, Directives, Document, Memo, ProcessError, Result, SpiralError, Targets, TimeoutError, Toolchain}

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

  defp with_no_agree_reasons(report, cells) do
    rows =
      Enum.map(report["tests"], fn row ->
        case Spiral.Cells.Domain.no_agree_reason(cell_text(cells, row["index"])) do
          "R" <> reason -> Map.put(row, "no_agree", reason)
          _ -> row
        end
      end)

    report |> Map.merge(counts(rows)) |> Map.put("tests", rows)
  end

  defp cell_text(cells, index) do
    case Enum.at(cells, index) do
      %{source: source} when is_binary(source) -> source
      _ -> ""
    end
  end

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


  defp report(tests, selected, %{verdicts: verdicts, unavailable: unavailable, memo: memo} = ran) do
    targets = Map.get(ran, :targets, %{})
    budgets = Map.get(ran, :budgets, %{})

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
        |> with_mismatch(Map.get(verdicts, test.index))
        |> with_budget(Map.get(budgets, test.index))
      end)

    counts(rows) |> Map.put("tests", rows)
  end

  @doc false
  def counts(rows) do
    wire = Enum.map_join(rows, "\n", &Enum.join([&1["status"] || "", &1["memo"] || "", &1["no_agree"] || ""], "\t"))

    wire
    |> Spiral.Cells.Domain.verdict_counts()
    |> String.split("\n", trim: true)
    |> Enum.reduce(%{"no_agree_reasons" => %{}}, fn line, acc ->
      case String.split(line, "\t") do
        ["no_agree", reason, n] -> put_in(acc, ["no_agree_reasons", reason], String.to_integer(n))
        [key, n] -> Map.put(acc, key, String.to_integer(n))
      end
    end)
  end

  defp with_mismatch(row, {:failed, message}) when is_binary(message) do
    case Spiral.Cells.Accept.mismatch(message) do
      {:ok, actual, expected} -> row |> Map.put("actual", actual) |> Map.put("expected", expected)
      :none -> row
    end
  end

  defp with_mismatch(row, _verdict), do: row

  defp with_budget(row, nil), do: row

  defp with_budget(row, budget) do
    slowest = row["targets"] |> Enum.map(&(&1["ms"] || 0)) |> Enum.max(fn -> 0 end)
    row |> Map.put("timeout_ms", budget) |> Map.put("slowest_ms", slowest)
  end


  defp headroom_warn do
    case Float.parse(System.get_env("SPIRAL_CELLS_HEADROOM_WARN") || "") do
      {threshold, ""} when threshold > 0 -> threshold
      _ -> 0.5
    end
  end

  defp not_run_reason({:error, message}), do: "the run stopped before this test: " <> first_line(message)
  defp not_run_reason(_status), do: "no step ran for this cell"

  defp target_rows(targets) do
    Enum.map(targets, fn row -> %{"target" => row.target, "status" => row.status, "ms" => row.ms} end)
  end

  defp test_state(test, selected, verdict) do
    {kind, text} = verdict_kind(verdict)
    filtered = selected != nil and not MapSet.member?(selected, test.index)
    state = Spiral.Cells.Domain.test_state(test.mode, filtered, kind)
    {state, if(state in ~w(failed unsupported timed_out), do: first_line(text))}
  end

  defp verdict_kind({kind, text}), do: {Atom.to_string(kind) <> "!", text}
  defp verdict_kind(kind), do: {to_string(kind), nil}

  defp first_line(text), do: text |> String.split("\n", parts: 2) |> hd()


  @doc false
  def write_metrics(dir, reports) do
    File.mkdir_p!(dir)
    wire = JSON.encode!(Spiral.Cells.Result.json_safe(Enum.map(reports, fn {path, report} -> %{"stem" => Path.basename(path, Path.extname(path)), "tests" => report["tests"]} end)))
    File.write!(Path.join(dir, "tests.tsv"), Spiral.Cells.Domain.metrics_tsv(wire))
  end

  @spec summary_lines([{String.t(), map()}]) :: [String.t()]
  def summary_lines(reports) do
    wire = JSON.encode!(Spiral.Cells.Result.json_safe(Enum.map(reports, fn {path, report} -> %{"path" => path, "tests" => report["tests"]} end)))
    wire |> Spiral.Cells.Domain.summary_lines_json(Float.to_string(headroom_warn() * 1.0)) |> String.split("\n")
  end

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
    spiral = Spiral.Cells.Toolchain.spiral(opts)
    dir = Path.join(System.tmp_dir!(), "spiral_cells_fs_#{System.unique_integer([:positive])}")
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
      %{kind: :spiral, source: source} = cell -> %{cell | source: Spiral.Cells.Lisp.expand(source, opts)}
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
          %{index => error_output(message)}

        _ ->
          outputs
      end

    File.mkdir_p!(Path.dirname(output_path))
    File.write!(output_path, JSON.encode!(ipynb(doc, outputs, durations, report) |> pool_metadata(pool_before, pool_after) |> Spiral.Cells.Result.json_safe()))
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
    results = Spiral.Cells.Accept.accept_sites(path, failures)

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

  defp mark_accepted(evaluation, outcome) do
    accepted = for {name, {:accepted, _, _}} <- outcome, do: name
    sites = Map.new(for {name, {:accepted, before_line, after_line}} <- outcome, do: {name, %{"before" => before_line, "after" => after_line}})
    refused = Map.new(for {name, {:refused, reason}} <- outcome, do: {name, reason})

    rows =
      Enum.map(evaluation.report["tests"], fn row ->
        cond do
          row["name"] in accepted and row["status"] == "failed" -> row |> Map.put("status", "accepted") |> Map.put("accepted_site", sites[row["name"]])
          Map.has_key?(refused, row["name"]) -> row |> Map.put("status", "failed") |> Map.put("accept_refused", refused[row["name"]])
          true -> row
        end
      end)

    accepted_indices = for %{"status" => "accepted", "index" => index} <- rows, do: index
    remaining = for {index, {:failed, _}} <- evaluation.verdicts, index not in accepted_indices, do: index
    status = if accepted_indices != [] and remaining == [], do: :ok, else: evaluation.status
    %{evaluation | status: status, report: Map.merge(evaluation.report, counts(rows)) |> Map.put("tests", rows)}
  end

  @spec write_html(String.t()) :: :ok | {:error, String.t()}
  def write_html(ipynb), do: Spiral.Cells.Html.write(ipynb)

  @doc false
  def untargeted_tests(path) do
    path = Path.expand(path)
    doc = parse(path, File.read!(path))

    for {index, name} <- Enum.sort(test_cell_names(doc)),
        %{source: source} = Enum.at(doc.cells, index),
        Builders.commands(source) == [],
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
      ".livemd" -> Document.parse_livemd(text)
      ".spi" when bounded ->
        warn_target_gaps(path, text)
        Document.parse_spi(text, real_sibling(path), {test_bounds(path), test_bounds(Path.rootname(path) <> "_real.spir")})

      ".spi" ->
        warn_target_gaps(path, text)
        Document.parse_spi(text, real_sibling(path))
      _ -> Document.parse_dib(text)
    end
  end

  defp warn_target_gaps(path, text) do
    for {line, target} <- Document.target_gaps(text) do
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
           dotnet when is_binary(dotnet) <- Toolchain.dotnet(opts),
           dll when is_binary(dll) <- Toolchain.compiler_dll(opts),
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

  defp empty_message(path) do
    "livebook did not run #{path}: no spiral cells"
  end

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

    budgets = Map.new(spiral, &{&1.index, opts[:timeout] || Directives.scale_budget(positive_int(Map.get(&1, :timeout)) || @default_timeout)})
    memo = Memo.context(opts, spiral)
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

        %{collect(recalled, ran) | memo: flags} |> Map.put(:budgets, budgets) |> Map.put(:whole_memo_keys, Memo.whole_keys?(memo))

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

  defp memo_key(_memo, %{untargeted: _}), do: nil
  defp memo_key(_memo, %{builder_error: _}), do: nil

  defp memo_key(memo, step) do
    lines =
      case Map.fetch(step, :builders) do
        {:ok, builders} -> builders
        :error -> Builders.commands(step.cell_source)
      end
      |> Enum.map(& &1.raw)

    Memo.key(memo, step, lines ++ expectation_key(expectation(step.cell_source)))
  rescue
    _ -> nil
  end

  defp expectation_key(nil), do: []
  defp expectation_key(%{code: code, substring: substring}), do: ["--fails #{code} #{inspect(substring)}"]

  defp remember(%{memo: {memo, key}}, {:ok, _outputs, _unavailable} = result, targets), do: Memo.store(memo, key, %{result: result, targets: targets})
  defp remember(%{memo: {memo, key}}, {:ok, _outputs} = result, targets), do: Memo.store(memo, key, %{result: result, targets: targets})
  defp remember(%{memo: {memo, key}}, {:built, _outputs} = result, targets), do: Memo.store(memo, key, %{result: result, targets: targets})
  defp remember(_step, _result, _targets), do: :ok

  defp plan(wire, :tests), do: Spiral.Cells.Domain.plan_tests(wire)
  defp plan(wire, _cells), do: Spiral.Cells.Domain.plan(wire)

  defp static_prelude?(source), do: Spiral.Cells.Domain.directive_flag(source, "--test static")

  @runnable_modes ["test", "fails", "build_only"]

  defp test_cell_names(doc), do: for(%{mode: mode} = test <- Document.tests(doc), mode in @runnable_modes, into: %{}, do: {test.index, test.name})

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
    {:ok, Builders.commands(source)}
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
        collect([{step.index, {:error, error_output(text), text}, nil}], acc)
    end)
  end

  defp cell_concurrency do
    case Integer.parse(System.get_env("SPIRAL_CELLS_CELL_CONCURRENCY") || "") do
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

        {:timed_out, outputs, message} ->
          acc
          |> put_in([:outputs, index], outputs)
          |> put_in([:verdicts, index], {:timed_out, message})

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
    |> Spiral.Cells.FsiChain.run(
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

  defp run_step(%{untargeted: name} = step, _opts, _root) do
    message = untargeted_message(name)
    [{step.index, {:error, error_output(message), message}, nil}]
  end

  defp run_step(%{builder_error: reason} = step, _opts, _root) do
    message = "test #{step[:test_name] || "cell #{step.index}"}: #{reason}"
    [{step.index, {:error, error_output(message), message}, nil}]
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

  defp fsi_steps(_cells, false), do: []

  defp fsi_steps(cells, true) do
    case cells
         |> Enum.with_index()
         |> Enum.flat_map(fn
           {%{kind: :import, source: source}, index} ->
             [%{index: index, kind: :import, source: source}]

           {cell, index} ->
             if fsharp?(cell) and not Spiral.Cells.FsiChain.ignored?(cell.source),
               do: [%{index: index, kind: :fsharp, source: cell.source}],
               else: []
         end) do
      [] -> []
      [first | _] = fs_cells -> [%{index: first.index, timeout: "-", kind: :fsi, cells: fs_cells}]
    end
  end

  defp fsharp?(cell), do: match?({:fsharp, _}, Targets.host_key(cell))

  defp dispatch_step(%{kind: :host} = step, opts, root) do
    {result, _waited} = Spiral.Cells.Slots.run(fn -> dispatch_host(step, opts, root) end)
    result
  end

  defp dispatch_step(step, opts, root), do: dispatch_spiral(step, opts, root)

  defp dispatch_host(%{language: language, source: source}, opts, root) do
    timeout = opts[:timeout] || Directives.scale_budget(@default_timeout)
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

        {:error, %TimeoutError{} = error} ->
          timed_out(error)

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
    timeout = opts[:timeout] || Directives.scale_budget(positive_int(step.timeout) || @default_timeout)

    source_path = opts[:path]

    try do
      opts =
        opts
        |> run_opts(root, timeout)
        |> Keyword.put(:builders, Map.get_lazy(step, :builders, fn -> Builders.commands(step.cell_source) end))
        |> Keyword.put(:real, Map.get(step, :real, ""))
        |> Keyword.put(:agree, agreement?(step.cell_source))
        |> Keyword.put(:reference, reference_target(step.cell_source))
        |> Keyword.put(:test_cell, Spiral.Cells.Domain.directive_flag(step.cell_source, "--test"))
        |> Keyword.put(:build_only, build_only?(step.cell_source))
        |> Keyword.put(:test_name, Map.get(step, :test_name))
        |> Keyword.put(:test_source, source_path)

      ran = if Spiral.Cells.Domain.bare_no_agree(step.cell_source), do: :bare_no_agree, else: step.program |> Spiral.Cells.run(opts) |> in_source(source_path) |> tap(fn _ -> Process.put(:spiral_cells_ran_at, System.monotonic_time(:millisecond)) end)

      cond do
        ran == :bare_no_agree ->
          text = "no_agree needs a reason: write `test name no_agree \"why the targets differ\" =` (cell: `///- --test --no-agree \"why\"`)"
          {:error, error_output(text), text}

        build_only?(step.cell_source) -> built(ran)
        expected = expectation(step.cell_source) -> expected_compile_error(Map.put(expected, :body_head, body_head(step.cell_source)), ran)
        true -> verdict(ran)
      end
    rescue
      error ->
        text = Exception.message(error)
        {:error, error_output(text), text}
    end
  end

  defp in_source({:error, %SpiralError{message: message, details: program} = error}, path) when is_binary(program) and is_binary(path) do
    case File.read(path) do
      {:ok, source} -> {:error, %{error | message: Spiral.Cells.SourceMap.remap(message, program, source, path)}}
      _ -> {:error, error}
    end
  end

  defp in_source(ran, _path), do: ran

  defp agreement?(source), do: Spiral.Cells.Domain.directive_flag(source, "--test") and not Spiral.Cells.Domain.directive_flag(source, "--no-agree")

  defp build_only?(source), do: Spiral.Cells.Domain.directive_flag(source, "--build-only")

  defp reference_target(source) do
    case Spiral.Cells.Domain.directive_word(source, "--reference") do
      "" -> nil
      target -> target
    end
  end

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

      {:error, %TimeoutError{} = error} ->
        timed_out(error)

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
    case source |> Spiral.Cells.Domain.fails_expectation() |> String.split("\t", parts: 2) do
      [code, substring] -> %{code: if(code == "", do: nil, else: code), substring: substring}
      _ -> nil
    end
  end

  defp expected_label(%{code: nil, substring: substring}), do: inspect(substring)
  defp expected_label(%{code: code, substring: substring}), do: "#{code} #{inspect(substring)}"

  defp expected_compile_error(expected, {:error, %SpiralError{message: message} = error}) do
    floor = body_floor(error.details, Map.get(expected, :body_head))

    case Spiral.Cells.Domain.compile_error_verdict(message, expected.code || "", expected.substring, floor || -1) do
      "early" ->
        text = "the expected error #{expected_label(expected)} is reported only before the test body (which starts at program line #{floor + 1}), so it does not prove this test:\n#{message}"
        {:error, error_output(text), text}

      "ok" ->
        text = "failed to compile as expected (#{expected_label(expected)}): #{first_line(message)}\n"
        {:ok, [stream("stdout", text)], []}

      "nocode" ->
        text = "the diagnostic matches #{inspect(expected.substring)} but carries no error code (expected #{expected.code}):\n#{message}"
        {:error, error_output(text), text}

      _ ->
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
    {:unsupported, [stream("stderr", text)], text}
  end

  defp timed_out(error) do
    text = "timed out, a VOID result and not a verdict: " <> error_text(error)
    {:timed_out, [stream("stderr", text)], text}
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
        if Spiral.Cells.Manifest.exists?(candidate), do: Path.expand(candidate)
      end)
    end) || spiral_lib_from_env(System.get_env("SPIRAL_LIB"))
  end

  defp lib_root_itself(dir) do
    expanded = Path.expand(dir)
    if String.ends_with?(String.replace(expanded, "\\", "/"), "/lib/spiral") and Spiral.Cells.Manifest.exists?(expanded), do: expanded
  end

  @doc false
  def spiral_lib_from_env(value) do
    case value do
      dir when is_binary(dir) and dir != "" ->
        if Spiral.Cells.Manifest.exists?(dir), do: Path.expand(dir)

      _ ->
        nil
    end
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

        keep_phase_row(cell, Map.get(durations, index), Map.get(tests, index))

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

  defp pool_metadata(json, %{} = before, %{} = after_run) do
    put_in(json, ["metadata", "compiler_pool"], %{
      "served" => after_run.served - before.served,
      "refused_growth" => after_run.refused_growth - before.refused_growth,
      "peak_workers" => after_run.peak_workers,
      "last_free_mb" => after_run.last_free_mb
    })
  end

  defp pool_metadata(json, _before, _after_run), do: json

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

  defp keep_phase_row(cell, {_ms, phases}, test) when map_size(phases) > 0 do
    case System.get_env("SPIRAL_CELLS_PHASE_ROWS") do
      path when is_binary(path) and path != "" ->
        source = if test, do: ":# #{test["name"]} =\n" <> source_of(cell), else: source_of(cell)
        wire = Enum.map_join([{:host_ms, System.get_env("SPIRAL_CELLS_HOST") || elem(:inet.gethostname(), 1)} | Map.to_list(phases)], "\n", fn {key, value} -> "#{phase_key(key)}=#{value}" end)
        File.write!(path, Spiral.Cells.Domain.phase_row(not File.exists?(path), source, wire) <> "\n", [:append])

      _ ->
        :ok
    end
  end

  defp keep_phase_row(_cell, _duration, _test), do: :ok

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
