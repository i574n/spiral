defmodule Spiral.Cells.Memo do
  alias Spiral.Cells.{SourceBlocks, Toolchain}

  @format 1
  @keep_entries 5_000
  @prune_every_ms 600_000
  @tool_opts [:print_code, :plot, :render_plot, :spiral, :python, :lua, :pwsh, :cc, :dcc, :rustc_bin, :patches]
  @stub_opts [:compile, :rustc, :execute, :target, :host, :build_receipt]

  @spec whole_keys?(map() | nil) :: boolean()
  def whole_keys?(%{bounds: :unavailable}), do: true
  def whole_keys?(_context), do: false

  @spec context(keyword(), [map()]) :: map() | nil
  def context(opts, steps) do
    if enabled?(opts) do
      binaries = compiler_binaries_print(Toolchain.compiler_dll(opts))
      bounds = source_bounds(opts, steps, binaries)

      %{
        dir: dir(opts),
        base: %{
          format: @format,
          compiler: {binaries, opts |> core_dir() |> tree_print(bounds)},
          kino: kino_identity(),
          tools: tool_identity(opts)
        },
        packages: package_prints(steps, bounds),
        bounds: bounds
      }
    end
  end

  @resolved_tools [:rustc, :cc, :dcc, :fpc, :zig, :gleam, :erl, :bun, :python, :lua, :wgsl_run, :naga, :pwsh, :dotnet, :spiral, :plot]

  @doc false
  @spec tool_identity(keyword()) :: term()
  def tool_identity(opts) do
    {lean, lean_args} = Toolchain.lean(opts)
    {Keyword.take(opts, @tool_opts), {:lean, tool_stamp(lean), lean_args}, for(tool <- @resolved_tools, do: {tool, tool_stamp(apply(Toolchain, tool, [opts]))})}
  end

  defp tool_stamp(nil), do: nil

  defp tool_stamp(path) do
    real = shim_target(path) || path

    case File.stat(real, time: :posix) do
      {:ok, %File.Stat{size: size, mtime: mtime}} -> {real, size, mtime}
      _ -> {real, :missing}
    end
  end

  defp shim_target(path) do
    shim = Path.rootname(path) <> ".shim"

    with true <- File.regular?(shim),
         {:ok, text} <- File.read(shim),
         "1\t" <> target <- Spiral.Cells.Domain.shim_path(text) do
      target
    else
      _ -> nil
    end
  end

  @spec enabled?(keyword()) :: boolean()
  def enabled?(opts) do
    case opts[:memo] do
      true -> true
      false -> false
      _ -> System.get_env("SPIRAL_CELLS_MEMO") != "0" and not Enum.any?(@stub_opts, &(Keyword.get(opts, &1) != nil))
    end
  end

  @spec key(map(), map(), [String.t()]) :: String.t()
  def key(context, step, builder_lines) do
    whole = Map.get(step, :whole_source_key, false) or context.bounds == :unavailable
    program = if whole, do: step.program, else: reached_program(step.program, context.bounds)
    packages = Enum.map(package_paths(step.program), &{&1, package_print_for(Map.get(context.packages, &1), program, whole)})

    base = if Spiral.Cells.Directives.per_test_compile?(), do: {context.base, :per_test, Map.get(step, :test_name)}, else: context.base

    {base, program, Map.get(step, :real, ""), builder_lines, packages}
    |> :erlang.term_to_binary()
    |> then(&:crypto.hash(:sha256, &1))
    |> Base.encode16(case: :lower)
  end

  @code_format 1

  @spec code_result(keyword(), term(), (-> term())) :: {term(), :hit | :miss | :off}
  def code_result(opts, code_parts, run) do
    if enabled?(opts) do
      context = %{dir: dir(opts)}

      key =
        {@code_format, kino_identity(), tool_identity(opts), code_parts}
        |> :erlang.term_to_binary()
        |> then(&:crypto.hash(:sha256, &1))
        |> Base.encode16(case: :lower)

      case fetch(context, key) do
        {:ok, {:code_result, result}} ->
          {result, :hit}

        _ ->
          result = run.()
          if match?({:ok, %{}}, result), do: store(context, key, {:code_result, result})
          {result, :miss}
      end
    else
      {run.(), :off}
    end
  end
  @spec fetch(map(), String.t()) :: {:ok, term()} | :miss
  def fetch(context, key) do
    path = entry(context, key)

    with {:ok, binary} <- File.read(path),
         {@format, value} <- safe_decode(binary) do
      _ = File.touch(path)
      {:ok, value}
    else
      _ -> :miss
    end
  end

  @spec store(map(), String.t(), term()) :: :ok
  def store(context, key, value) do
    path = entry(context, key)
    tmp = path <> ".#{System.unique_integer([:positive])}.tmp"

    with :ok <- File.mkdir_p(Path.dirname(path)),
         :ok <- File.write(tmp, :erlang.term_to_binary({@format, value})),
         :ok <- File.rename(tmp, path) do
      prune(context)
    else
      _ ->
        File.rm(tmp)
        :ok
    end
  end

  defp safe_decode(binary) do
    :erlang.binary_to_term(binary, [:safe])
  rescue
    _ -> :corrupt
  end

  defp entry(context, key), do: Path.join([context.dir, binary_part(key, 0, 2), key <> ".etf"])

  defp dir(opts) do
    opts[:memo_dir] || System.get_env("SPIRAL_CELLS_MEMO_DIR") ||
      Path.join(System.get_env("LOCALAPPDATA") || Path.join(System.user_home!(), ".cache"), "spiral-bin/cells-results")
  end

  defp prune(context) do
    now = System.monotonic_time(:millisecond)
    last = :persistent_term.get({__MODULE__, :pruned, context.dir}, nil)

    if last == nil or now - last > @prune_every_ms do
      :persistent_term.put({__MODULE__, :pruned, context.dir}, now)

      context.dir
      |> glob("*/*.etf")
      |> Enum.map(&{&1, mtime(&1)})
      |> Enum.sort_by(&elem(&1, 1), :desc)
      |> Enum.drop(@keep_entries)
      |> Enum.each(&File.rm(elem(&1, 0)))
    end

    :ok
  end

  @doc false
  @spec glob(String.t(), String.t()) :: [String.t()]
  def glob(dir, pattern), do: dir |> String.replace("\\", "/") |> Path.join(pattern) |> Path.wildcard()

  defp mtime(path) do
    case File.stat(path, time: :posix) do
      {:ok, %{mtime: mtime}} -> mtime
      _ -> 0
    end
  end

  # TODO: KINO-HOT-PATHS move memo keys to Spiral once the per-notebook costs left after the binaries cache are profiled
  @doc false
  def compiler_binaries_print(dll) do
    dir = Path.dirname(dll)

    entries =
      [Path.basename(dll) | dir |> glob("SpiralCompiler*.dll") |> Enum.map(&Path.basename/1)]
      |> Enum.uniq_by(&String.downcase/1)
      |> Enum.map(&{String.downcase(&1), Path.join(dir, &1)})
      |> Enum.sort()

    stamps = Enum.map(entries, fn {name, path} -> {name, file_stamp(path)} end)
    cache_key = {__MODULE__, :compiler_binaries, dir, stamps}

    case :persistent_term.get(cache_key, nil) do
      nil ->
        print = Enum.map(entries, fn {name, path} -> {name, content_hash(path)} end)
        :persistent_term.put(cache_key, print)
        print

      print ->
        print
    end
  end

  @stamp_head_bytes 65_536

  defp file_stamp(path) do
    with {:ok, %{size: size, mtime: mtime}} <- File.stat(path, time: :posix),
         {:ok, head} when is_binary(head) <- File.open(path, [:read, :binary], &IO.binread(&1, @stamp_head_bytes)) do
      {size, mtime, :crypto.hash(:sha256, head)}
    else
      _ -> :missing
    end
  end

  defp content_hash(path) do
    case File.read(path) do
      {:ok, binary} -> :crypto.hash(:sha256, binary)
      _ -> :missing
    end
  end

  defp core_dir(opts), do: opts |> Toolchain.package_dir() |> Path.join("core")

  defp source_bounds(opts, steps, binaries) do
    programs = for step <- steps, not Map.get(step, :whole_source_key, false), do: step.program
    dirs = [core_dir(opts) | Enum.flat_map(steps, &package_paths(&1.program))]
    files = dirs |> Enum.flat_map(&tree_files(&1, MapSet.new())) |> Enum.uniq()
    texts = Enum.uniq(programs ++ for(file <- files, {:ok, text} <- [File.read(file)], do: text))
    store_context = %{dir: dir(opts)}
    keyed = Enum.map(texts, &{&1, bounds_key(binaries, &1)})

    {known, unknown} =
      Enum.reduce(keyed, {%{}, []}, fn {text, key}, {known, unknown} ->
        case remembered_bounds(store_context, key) do
          {:ok, {:source_rows, spans}} -> {Map.put(known, text, spans), unknown}
          _ -> {known, [{text, key} | unknown]}
        end
      end)

    if unknown == [] do
      known
    else
      case SourceBlocks.of_texts(opts, Enum.map(unknown, &elem(&1, 0))) do
        {:ok, spans} ->
          Enum.each(unknown, fn {text, key} ->
            store(store_context, key, {:source_rows, Map.get(spans, text, "")})
            :ets.insert(bounds_table(), {key, Map.get(spans, text, "")})
          end)
          Map.merge(known, spans)

        :unavailable ->
          :unavailable
      end
    end
  end

  @bounds_table :spiral_cells_memo_bounds

  defp remembered_bounds(store_context, key) do
    table = bounds_table()

    case :ets.lookup(table, key) do
      [{^key, spans}] ->
        {:ok, {:source_rows, spans}}

      [] ->
        case fetch(store_context, key) do
          {:ok, {:source_rows, spans}} = hit ->
            :ets.insert(table, {key, spans})
            hit

          other ->
            other
        end
    end
  end

  defp bounds_table do
    Spiral.Cells.Tables.ensure(@bounds_table, [:set])
  end

  defp bounds_key(binaries, text) do
    {:source_rows, binaries, text}
    |> :erlang.term_to_binary()
    |> then(&:crypto.hash(:sha256, &1))
    |> Base.encode16(case: :lower)
  end

  defp tree_files(dir, seen) do
    dir = Path.expand(dir)

    with false <- MapSet.member?(seen, dir),
         {:ok, project} <- Spiral.Cells.Manifest.read(dir) do
      module_files(dir, project) ++ Enum.flat_map(Spiral.Cells.Mounts.declared_dependencies(dir), &tree_files(&1.target, MapSet.put(seen, dir)))
    else
      _ -> []
    end
  end

  @result_path_modules [
    Spiral.Cells,
    Spiral.Cells.Builders,
    Spiral.Cells.Cell,
    Spiral.Cells.Directives,
    Spiral.Cells.Display,
    Spiral.Cells.Domain,
    Spiral.Cells.Memo,
    Spiral.Cells.Mounts,
    Spiral.Cells.Notebook,
    Spiral.Cells.Result,
    Spiral.Cells.Runner,
    Spiral.Cells.SourceBlocks,
    Spiral.Cells.Targets,
    Spiral.Cells.Toolchain,
    :spiral_cells@domain
  ]

  @doc false
  def result_path_modules, do: @result_path_modules

  defp kino_identity do
    case :persistent_term.get({__MODULE__, :kino}, nil) do
      nil ->
        print =
          @result_path_modules
          |> Enum.filter(&Code.ensure_loaded?/1)
          |> Enum.map(&{&1, &1.module_info(:md5)})
          |> :erlang.term_to_binary()
          |> then(&:crypto.hash(:sha256, &1))

        :persistent_term.put({__MODULE__, :kino}, print)
        print

      print ->
        print
    end
  end

  defp package_prints(steps, bounds) do
    steps
    |> Enum.flat_map(&package_paths(&1.program))
    |> Enum.uniq()
    |> Map.new(&{&1, package_index(&1, bounds)})
  end

  defp package_index(dir, :unavailable), do: tree_print(dir, :unavailable)

  defp package_index(dir, bounds) do
    dir = Path.expand(dir)

    case Spiral.Cells.Manifest.read(dir) do
      {:ok, project} ->
        modules =
          for {file, opened} <- module_entries(dir, project) do
            module = file |> Path.relative_to(dir) |> String.replace("\\", "/")
            compiled = file |> read_source() |> compiled_blocks(bounds)
            text = Enum.map_join(compiled, "\n", &Enum.join(&1.lines, "\n"))
            %{module: module, scope: module |> Path.rootname() |> String.replace("/", "."), opened: opened, compiled: compiled, opens: opened_names(text)}
          end

        blocks =
          for module <- modules,
              block <- module.compiled |> shaped_blocks() |> with_stable_ids(module.module) do
            Map.put(block, :scope, module.scope)
          end

        deps = for dep <- Spiral.Cells.Mounts.declared_dependencies(dir), do: {dep.name, package_index(dep.target, bounds)}

        %{
          project: project,
          deps: deps,
          opened: for(module <- modules, module.opened, do: module.scope),
          scope_opens: Map.new(modules, &{&1.scope, &1.opens}),
          blocks: Map.new(blocks, &{&1.id, &1}),
          by_name: Enum.reduce(blocks, %{}, fn block, acc -> Enum.reduce(block.names, acc, &Map.update(&2, &1, [block.id], fn ids -> [block.id | ids] end)) end),
          operators: for(block <- blocks, op <- block.operators, do: {op, block.id}),
          always: for(block <- blocks, block.kind != :definition or block.instance, do: block.id)
        }

      _ ->
        :missing
    end
  end

  defp with_stable_ids(blocks, module) do
    {identified, _seen} =
      Enum.map_reduce(blocks, %{}, fn block, seen ->
        print = :crypto.hash(:sha256, block.text)
        identity = if block.kind == :definition, do: block.names, else: print
        occurrence = Map.get(seen, identity, 0)
        {Map.merge(block, %{id: {module, identity, occurrence}, print: print}), Map.put(seen, identity, occurrence + 1)}
      end)

    identified
  end
  defp read_source(file) do
    case File.read(file) do
      {:ok, source} -> source
      _ -> ""
    end
  end

  defp compiled_blocks(text, bounds) do
    case Map.fetch(bounds, text) do
      {:ok, rows} -> SourceBlocks.split(text, rows)
      :error -> [%{header_text: "", lines: String.split(text, "\n")}]
    end
  end

  defp package_print_for(%{blocks: blocks} = index, _program, true) do
    {index.project, full_deps_print(index.deps), blocks |> Map.keys() |> Enum.sort() |> Enum.map(&{&1, blocks[&1].print})}
  end

  defp package_print_for(index, program, false), do: reached_package_print(index, program)
  defp package_print_for(other, _program, true), do: other

  defp full_deps_print(deps), do: for({name, dep} <- deps, do: {name, package_print_for(dep, "", true)})

  defp reached_package_print(%{blocks: _} = index, program) do
    code = Spiral.Cells.Domain.strip_comments(program)
    {unqualified, qualified} = references(code, [])
    in_scope = index.opened ++ opened_names(code)
    from_operators = for {op, id} <- index.operators, String.contains?(program, op), do: id
    seeds = resolve_references(index, unqualified, qualified, in_scope) ++ from_operators ++ index.always
    reached = reach_package_blocks(seeds, index, MapSet.new())
    reached_text = Enum.map_join(reached, "\n", &index.blocks[&1].text)
    deps = for {name, dep} <- index.deps, do: {name, reached_package_print(dep, program <> "\n" <> reached_text)}
    {index.project, deps, reached |> Enum.sort() |> Enum.map(&{&1, index.blocks[&1].print})}
  end

  defp reached_package_print(other, _program), do: other

  defp reach_package_blocks([], _index, reached), do: reached

  defp reach_package_blocks([id | rest], index, reached) do
    if MapSet.member?(reached, id) do
      reach_package_blocks(rest, index, reached)
    else
      block = index.blocks[id]
      in_scope = [block.scope | index.opened] ++ Map.get(index.scope_opens, block.scope, [])
      named = resolve_references(index, block.unqualified, block.qualified, in_scope)
      by_operator = for {op, other} <- index.operators, String.contains?(block.code, op), do: other
      reach_package_blocks(named ++ by_operator ++ rest, index, MapSet.put(reached, id))
    end
  end

  @doc false
  def opened_names(code), do: code |> Spiral.Cells.Domain.opened_names() |> String.split(" ", trim: true)

  defp references(code, names) do
    {_kind, _names, _operators, _tokens, _instance, unqualified, qualified} = block_facts("", code)
    {Enum.reject(unqualified, &(&1 in names)), qualified}
  end

  defp resolve_references(index, unqualified, qualified, in_scope) do
    by_scope = fn ids, accept -> Enum.filter(ids, &accept.(index.blocks[&1].scope)) end
    visible = fn scope -> Enum.any?(in_scope, &scope_named?(scope, &1)) end

    Enum.flat_map(unqualified, &by_scope.(Map.get(index.by_name, &1, []), visible)) ++
      Enum.flat_map(qualified, fn {module, name} -> by_scope.(Map.get(index.by_name, name, []), &scope_named?(&1, module)) end)
  end

  defp scope_named?(scope, name), do: scope == name or String.ends_with?(scope, "." <> name)
  @doc false
  def reached_program(program, :unavailable), do: program

  def reached_program(program, bounds) do
    case Map.fetch(bounds, program) do
      {:ok, rows} -> Spiral.Cells.Domain.reached_program(program, rows)
      :error -> program
    end
  end

  defp shaped_blocks(blocks) do
    Enum.map(blocks, fn %{header_text: header, lines: block_lines} ->
      code = block_lines |> Enum.join("\n") |> Spiral.Cells.Domain.strip_comments()
      {kind, names, operators, tokens, instance, unqualified, qualified} = block_facts(header, code)
      %{text: Enum.join(block_lines, "\n"), code: code, kind: kind, names: names, operators: operators, tokens: tokens, unqualified: unqualified, qualified: qualified, instance: instance}
    end)
  end

  @doc false
  def block_shape(header, code) do
    [kind, names, operators] = header |> Spiral.Cells.Domain.block_shape(code) |> String.split("\t")
    {String.to_existing_atom(kind), String.split(names, " ", trim: true), String.split(operators, " ", trim: true)}
  end

  @doc false
  def block_facts(header, code) do
    [kind, names, operators, tokens, instance, unqualified, qualified] = header |> Spiral.Cells.Domain.block_facts(code) |> String.split("\t")
    pairs = for pair <- String.split(qualified, " ", trim: true), [module, name] = String.split(pair, "|"), do: {module, name}
    {String.to_existing_atom(kind), String.split(names, " ", trim: true), String.split(operators, " ", trim: true), String.split(tokens, " ", trim: true), instance == "instance", String.split(unqualified, " ", trim: true), pairs}
  end

  @doc false
  def package_paths(program), do: program |> Spiral.Cells.Domain.package_paths() |> String.split(" ", trim: true)

  defp tree_print(dir, bounds), do: package_print(dir, MapSet.new(), bounds)

  defp package_print(dir, seen, bounds) do
    dir = Path.expand(dir)

    if MapSet.member?(seen, dir) do
      :seen
    else
      seen = MapSet.put(seen, dir)

      case Spiral.Cells.Manifest.read(dir) do
        {:ok, project} ->
          files = Enum.map(module_files(dir, project), &{&1, content_print(&1, bounds)})
          deps = for dep <- Spiral.Cells.Mounts.declared_dependencies(dir), do: {dep.name, package_print(dep.target, seen, bounds)}
          :crypto.hash(:sha256, :erlang.term_to_binary({project, files, deps}))

        _ ->
          :missing
      end
    end
  end

  @doc false
  def module_files(dir, project), do: dir |> module_entries(project) |> Enum.map(&elem(&1, 0))

  defp module_entries(dir, project) do
    project
    |> section("modules")
    |> Enum.reduce({[], []}, fn {indent, entry}, {files, folders} ->
      folders = Enum.drop_while(folders, fn {level, _name} -> level >= indent end)
      path = folders |> Enum.reverse() |> Enum.map(&elem(&1, 1))

      if String.ends_with?(entry, "/") do
        {files, [{indent, String.trim_trailing(entry, "/")} | folders]}
      else
        name = entry |> String.trim_trailing("-") |> String.trim_trailing("*")
        opened = String.ends_with?(entry, "-") or String.ends_with?(entry, "*")
        {files ++ Enum.map(candidates(dir, Path.join(path ++ [name])), &{&1, opened}), folders}
      end
    end)
    |> elem(0)
  end
  defp candidates(dir, name) do
    [".spi", ".spir"] |> Enum.map(&Path.join(dir, name <> &1)) |> Enum.filter(&File.regular?/1)
  end

  defp section(project, name) do
    project
    |> String.replace("\r\n", "\n")
    |> String.split("\n")
    |> Enum.drop_while(&(String.trim(&1) != name <> ":"))
    |> Enum.drop(1)
    |> Enum.take_while(&(&1 == "" or String.starts_with?(&1, " ")))
    |> Enum.reject(&(String.trim(&1) == ""))
    |> Enum.map(&{String.length(&1) - String.length(String.trim_leading(&1)), String.trim(&1)})
  end

  defp content_print(path, :unavailable) do
    case File.read(path) do
      {:ok, text} -> :crypto.hash(:sha256, text)
      _ -> :missing
    end
  end

  defp content_print(path, bounds) do
    case File.read(path) do
      {:ok, text} -> :crypto.hash(:sha256, :erlang.term_to_binary(Enum.map(compiled_blocks(text, bounds), & &1.lines)))
      _ -> :missing
    end
  end
end
