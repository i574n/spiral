defmodule Spiral.Kino.Notebook do
  alias Spiral.Kino.{Builders, Document, Result, Targets}

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
    :node,
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

  @spec run(String.t(), keyword()) :: :ok | {:error, String.t()}
  def run(path, opts \\ []) when is_binary(path) do
    path = Path.expand(path)
    opts = Keyword.put(opts, :path, path)
    text = File.read!(path)
    doc = path |> parse(text) |> expand_lisp(opts)

    if opts[:export_only] do
      write_exports(path, doc, opts)
      :ok
    else
      run_cells(path, doc, opts)
    end
  end

  defp write_exports(path, doc, opts) do
    if opts[:spi] != false, do: File.write!(opts[:spi_path] || Path.rootname(path) <> ".spi", Document.to_spi(doc))
    if opts[:spir_path], do: File.write!(opts[:spir_path], Document.to_spir(doc))
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

    {status, outputs, durations} =
      if Enum.any?(doc.cells, &runnable?/1) do
        try do
          execute(doc, opts, root)
        rescue
          error -> {{:error, Exception.message(error)}, %{}, %{}}
        end
      else
        {{:error, empty_message(path)}, %{}, %{}}
      end

    outputs =
      case status do
        {:error, message} when outputs == %{} ->
          index = Enum.find_index(doc.cells, &(&1.kind != :markdown)) || 0
          %{index => error_output(message)}

        _ ->
          outputs
      end

    File.write!(output_path, JSON.encode!(ipynb(doc, outputs, durations)))

    case status do
      :ok ->
        write_exports(path, doc, opts)

        if opts[:html], do: write_html(output_path), else: :ok

      {:error, message} ->
        {:error, message}
    end
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
    if Path.extname(path) == ".livemd",
      do: Document.parse_livemd(text),
      else: Document.parse_dib(text)
  end

  defp runnable?(%{kind: :spiral}), do: true
  defp runnable?(%{kind: :import}), do: true
  defp runnable?(cell), do: Targets.host_key(cell) != nil

  defp empty_message(path) do
    "livebook did not run #{path}: no spiral cells"
  end

  defp execute(doc, opts, root) do
    workspace = Spiral.Kino.workspace_root(opts)
    cells = Enum.map(doc.cells, &canon_cell(&1, root, workspace))
    lib = find_spiral_lib(opts[:path]) || "-"

    spiral =
      cells
      |> Spiral.Kino.Domain.encode_cells()
      |> then(&(lib <> "\n" <> &1))
      |> Spiral.Kino.Domain.plan()
      |> Spiral.Kino.Domain.decode_plan()
      |> Enum.map(&attach_source(&1, cells))

    fsi? = fsi_session?(opts)
    steps = Enum.sort_by(spiral ++ host_steps(cells, fsi?) ++ fsi_steps(cells, fsi?), & &1.index)

    case if(spiral == [], do: :ok, else: ensure_compiler(opts)) do
      :ok ->
        {outputs, durations, status} =
          if System.get_env("SPIRAL_KINO_CELLS") == "serial" do
            run_serial(steps, opts, root)
          else
            run_parallel(steps, opts, root)
          end

        {status, outputs, durations}

      {:error, message} ->
        {{:error, message}, %{}, %{}}
    end
  end

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

  defp run_serial(steps, opts, root) do
    Enum.reduce_while(steps, {%{}, %{}, :ok}, fn step, {outputs, durations, :ok} ->
      case collect(run_step(step, opts, root), {outputs, durations, :ok}) do
        {_, _, :ok} = acc -> {:cont, acc}
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
    |> Enum.reduce({%{}, %{}, :ok}, fn
      {{:ok, entries}, _step}, acc ->
        collect(entries, acc)

      {{:exit, reason}, step}, {acc, durations, status} ->
        text = Exception.format_exit(reason)
        {Map.put(acc, step.index, error_output(text)), durations, keep_error(status, text)}
    end)
  end

  defp cell_concurrency do
    case Integer.parse(System.get_env("SPIRAL_KINO_CELL_CONCURRENCY") || "") do
      {n, ""} when n > 0 -> n
      _ -> 4
    end
  end

  defp collect(entries, acc) do
    Enum.reduce(entries, acc, fn
      {index, {:ok, outputs}, ms}, {acc, durations, status} ->
        {Map.put(acc, index, outputs), Map.put(durations, index, ms), status}

      {index, {:error, outputs, message}, ms}, {acc, durations, status} ->
        {Map.put(acc, index, outputs), Map.put(durations, index, ms), keep_error(status, message)}
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
    result = dispatch_step(step, opts, root)

    [
      {step.index, result,
       {System.monotonic_time(:millisecond) - started, Spiral.Kino.last_phases()}}
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

      case Spiral.Kino.run(step.program, opts) do
        {:ok, %Result{exit_status: status} = result} when status in [nil, 0] ->
          {:ok, success_output(result)}

        {:ok, %Result{} = result} ->
          text = "cell exited #{result.exit_status}\n#{result.stdout}"
          {:error, error_output(text), text}

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

  defp ipynb(doc, outputs, durations) do
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
        }
      },
      "cells" => cells
    }
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
