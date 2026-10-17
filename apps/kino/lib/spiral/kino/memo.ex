defmodule Spiral.Kino.Memo do
  alias Spiral.Kino.{SourceBlocks, Toolchain}

  @format 1
  @keep_entries 5_000
  @prune_every_ms 600_000
  @tool_opts [:print_code, :plot, :render_plot, :spiral, :python, :lua, :pwsh, :cc, :dcc, :rustc_bin]
  @stub_opts [:compile, :rustc, :execute, :target, :host]

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
          tools: Keyword.take(opts, @tool_opts)
        },
        packages: package_prints(steps, bounds),
        bounds: bounds
      }
    end
  end

  @spec enabled?(keyword()) :: boolean()
  def enabled?(opts) do
    case opts[:memo] do
      true -> true
      false -> false
      _ -> System.get_env("SPIRAL_KINO_MEMO") != "0" and not Enum.any?(@stub_opts, &Keyword.has_key?(opts, &1))
    end
  end

  @spec key(map(), map(), [String.t()]) :: String.t()
  def key(context, step, builder_lines) do
    whole = Map.get(step, :whole_source_key, false) or context.bounds == :unavailable
    program = if whole, do: step.program, else: reached_program(step.program, context.bounds)
    packages = Enum.map(package_paths(step.program), &{&1, package_print_for(Map.get(context.packages, &1), program, whole)})

    {context.base, program, Map.get(step, :real, ""), builder_lines, packages}
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
        {@code_format, kino_identity(), Keyword.take(opts, @tool_opts), code_parts}
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
    opts[:memo_dir] || System.get_env("SPIRAL_KINO_MEMO_DIR") ||
      Path.join(System.get_env("LOCALAPPDATA") || Path.join(System.user_home!(), ".cache"), "spiral-bin/kino-results")
  end

  defp prune(context) do
    now = System.monotonic_time(:millisecond)
    last = :persistent_term.get({__MODULE__, :pruned, context.dir}, nil)

    if last == nil or now - last > @prune_every_ms do
      :persistent_term.put({__MODULE__, :pruned, context.dir}, now)

      context.dir
      |> Path.join("*/*.etf")
      |> Path.wildcard()
      |> Enum.map(&{&1, mtime(&1)})
      |> Enum.sort_by(&elem(&1, 1), :desc)
      |> Enum.drop(@keep_entries)
      |> Enum.each(&File.rm(elem(&1, 0)))
    end

    :ok
  end

  defp mtime(path) do
    case File.stat(path, time: :posix) do
      {:ok, %{mtime: mtime}} -> mtime
      _ -> 0
    end
  end

  @doc false
  def compiler_binaries_print(dll) do
    dir = Path.dirname(dll)

    [Path.basename(dll) | dir |> Path.join("SpiralCompiler*.dll") |> Path.wildcard() |> Enum.map(&Path.basename/1)]
    |> Enum.map(&String.downcase/1)
    |> Enum.uniq()
    |> Enum.sort()
    |> Enum.map(&{&1, content_hash(Path.join(dir, &1))})
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
        case fetch(store_context, key) do
          {:ok, {:source_blocks, spans}} -> {Map.put(known, text, spans), unknown}
          _ -> {known, [{text, key} | unknown]}
        end
      end)

    if unknown == [] do
      known
    else
      case SourceBlocks.of_texts(opts, Enum.map(unknown, &elem(&1, 0))) do
        {:ok, spans} ->
          Enum.each(unknown, fn {text, key} -> store(store_context, key, {:source_blocks, Map.get(spans, text, [])}) end)
          Map.merge(known, spans)

        :unavailable ->
          :unavailable
      end
    end
  end

  defp bounds_key(binaries, text) do
    {:source_blocks, binaries, text}
    |> :erlang.term_to_binary()
    |> then(&:crypto.hash(:sha256, &1))
    |> Base.encode16(case: :lower)
  end

  defp tree_files(dir, seen) do
    dir = Path.expand(dir)

    with false <- MapSet.member?(seen, dir),
         {:ok, project} <- File.read(Path.join(dir, "package.spiproj")) do
      module_files(dir, project) ++ Enum.flat_map(Spiral.Kino.Mounts.declared_dependencies(dir), &tree_files(&1.target, MapSet.put(seen, dir)))
    else
      _ -> []
    end
  end

  @result_path_modules [
    Spiral.Kino,
    Spiral.Kino.Builders,
    Spiral.Kino.Cell,
    Spiral.Kino.Directives,
    Spiral.Kino.Display,
    Spiral.Kino.Domain,
    Spiral.Kino.Memo,
    Spiral.Kino.Mounts,
    Spiral.Kino.Notebook,
    Spiral.Kino.Result,
    Spiral.Kino.Runner,
    Spiral.Kino.SourceBlocks,
    Spiral.Kino.Targets,
    Spiral.Kino.Toolchain,
    :spiral_kino@domain
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

    case File.read(Path.join(dir, "package.spiproj")) do
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

        deps = for dep <- Spiral.Kino.Mounts.declared_dependencies(dir), do: {dep.name, tree_print(dep.target, bounds)}

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

  @test_header ~r/^test(?![\w'])/u

  defp compiled_blocks(text, bounds) do
    case Map.fetch(bounds, text) do
      {:ok, spans} -> text |> SourceBlocks.split(spans) |> Enum.reject(&Regex.match?(@test_header, &1.header_text))
      :error -> [%{header_text: "", lines: String.split(text, "\n")}]
    end
  end

  defp package_print_for(%{blocks: blocks} = index, _program, true) do
    {index.project, index.deps, blocks |> Map.keys() |> Enum.sort() |> Enum.map(&{&1, blocks[&1].print})}
  end

  defp package_print_for(index, program, false), do: reached_package_print(index, program)
  defp package_print_for(other, _program, true), do: other
  defp reached_package_print(%{blocks: _} = index, program) do
    code = program |> String.split("\n") |> Enum.map_join("\n", &strip_line_comment/1)
    {unqualified, qualified} = references(code, [])
    in_scope = index.opened ++ opened_names(code)
    from_operators = for {op, id} <- index.operators, String.contains?(program, op), do: id
    seeds = resolve_references(index, unqualified, qualified, in_scope) ++ from_operators ++ index.always
    reached = reach_package_blocks(seeds, index, MapSet.new())
    {index.project, index.deps, reached |> Enum.sort() |> Enum.map(&{&1, index.blocks[&1].print})}
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

  @identifier ~r/[A-Za-z_][\w']*/u
  @qualified_name ~r/[A-Za-z_][\w']*(?:\.[A-Za-z_][\w']*)+/u
  @open_statement ~r/\bopen\s+([A-Za-z_][\w']*(?:\.[A-Za-z_][\w']*)*)/u

  defp opened_names(code), do: @open_statement |> Regex.scan(code, capture: :all_but_first) |> List.flatten() |> Enum.uniq()

  defp references(code, names) do
    qualified =
      @qualified_name
      |> Regex.scan(code)
      |> List.flatten()
      |> Enum.uniq()
      |> Enum.map(fn token ->
        parts = String.split(token, ".")
        {Enum.join(Enum.drop(parts, -1), "."), List.last(parts)}
      end)

    heads = Regex.replace(@qualified_name, code, fn token -> token |> String.split(".") |> hd() end)
    unqualified = @identifier |> Regex.scan(heads) |> List.flatten() |> Enum.uniq() |> Enum.reject(&(&1 in names))
    {unqualified, qualified}
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
      {:ok, spans} ->
        unreached = program |> SourceBlocks.split(spans) |> shaped_blocks() |> unreached_definitions()
        dropped = for {%{header: header, last: last}, i} <- Enum.with_index(spans), MapSet.member?(unreached, i), row <- header..last//1, into: MapSet.new(), do: row

        program
        |> String.replace("\r\n", "\n")
        |> String.split("\n")
        |> Enum.with_index(1)
        |> Enum.reject(fn {_line, row} -> MapSet.member?(dropped, row) end)
        |> Enum.map_join("\n", &elem(&1, 0))

      :error ->
        program
    end
  end

  defp unreached_definitions(blocks) do
    indexed = Enum.with_index(blocks)

    by_name =
      Enum.reduce(indexed, %{}, fn {block, i}, acc ->
        Enum.reduce(block.names, acc, &Map.update(&2, &1, [i], fn xs -> [i | xs] end))
      end)

    operators = for {block, i} <- indexed, op <- block.operators, do: {op, i}
    roots = for {block, i} <- indexed, block.kind != :definition or block.instance or "main" in block.names, do: i
    reached = reach_blocks(roots, blocks, by_name, operators, MapSet.new())

    for {block, i} <- indexed, block.kind == :definition, not MapSet.member?(reached, i), into: MapSet.new(), do: i
  end

  defp reach_blocks([], _blocks, _by_name, _operators, reached), do: reached

  defp reach_blocks([i | rest], blocks, by_name, operators, reached) do
    if MapSet.member?(reached, i) do
      reach_blocks(rest, blocks, by_name, operators, reached)
    else
      block = Enum.at(blocks, i)
      named = Enum.flat_map(block.tokens, &Map.get(by_name, &1, []))
      by_operator = for {op, j} <- operators, String.contains?(block.code, op), do: j
      reach_blocks(named ++ by_operator ++ rest, blocks, by_name, operators, MapSet.put(reached, i))
    end
  end

  defp shaped_blocks(blocks) do
    Enum.map(blocks, fn %{header_text: header, lines: block_lines} ->
      code = block_lines |> Enum.map(&strip_line_comment/1) |> Enum.join("\n")
      {kind, names, operators} = block_shape(header, code)
      tokens = @identifier |> Regex.scan(code) |> List.flatten() |> Enum.uniq() |> Enum.reject(&(&1 in names))
      {unqualified, qualified} = references(code, names)
      %{text: Enum.join(block_lines, "\n"), code: code, kind: kind, names: names, operators: operators, tokens: tokens, unqualified: unqualified, qualified: qualified, instance: Regex.match?(~r/^instance\s/, header)}
    end)
  end

  defp block_shape(header, code) do
    cond do
      match = Regex.run(~r/^(?:and\s+)?(?:inl|let|inm|inb)(?:\s+rec)?\s+\(([^)\s]+)\)/, header) ->
        {:definition, ["(" <> Enum.at(match, 1) <> ")"], [Enum.at(match, 1)]}

      match = Regex.run(~r/^(?:and\s+)?(?:inl|let|inm|inb)(?:\s+rec)?\s+([^\s(:=]+)/u, header) ->
        if Enum.at(match, 1) in ["_", "()"], do: {:other, [], []}, else: {:definition, [Enum.at(match, 1)], []}

      match = Regex.run(~r/^(?:and\s+)?(?:type|union|nominal|prototype)(?:\s+rec)?\s+([^\s=]+)/u, header) ->
        cases = ~r/\|\s*([A-Z][\w']*)/u |> Regex.scan(code, capture: :all_but_first) |> List.flatten()
        {:definition, [Enum.at(match, 1) | cases], []}

      match = Regex.run(~r/^instance\s+(\S+)/u, header) ->
        {:definition, [Enum.at(match, 1)], []}

      true ->
        {:other, [], []}
    end
  end

  defp strip_line_comment(line), do: line |> String.to_charlist() |> strip_chars(false, [])

  defp strip_chars([], _in_string, acc), do: acc |> Enum.reverse() |> List.to_string()
  defp strip_chars([?\\, char | rest], true, acc), do: strip_chars(rest, true, [char, ?\\ | acc])
  defp strip_chars([?" | rest], in_string, acc), do: strip_chars(rest, not in_string, [?" | acc])
  defp strip_chars([?/, ?/ | _rest], false, acc), do: strip_chars([], false, acc)
  defp strip_chars([char | rest], in_string, acc), do: strip_chars(rest, in_string, [char | acc])
  @doc false
  def package_paths(program) do
    ~r/^\/\/\/- (.*)$/m
    |> Regex.scan(program)
    |> Enum.flat_map(fn [_, flags] ->
      ~r/--package\s+(\S+)/ |> Regex.scan(flags) |> Enum.map(fn [_, path] -> path end)
    end)
  end

  defp tree_print(dir, bounds), do: package_print(dir, MapSet.new(), bounds)

  defp package_print(dir, seen, bounds) do
    dir = Path.expand(dir)

    if MapSet.member?(seen, dir) do
      :seen
    else
      seen = MapSet.put(seen, dir)

      case File.read(Path.join(dir, "package.spiproj")) do
        {:ok, project} ->
          files = Enum.map(module_files(dir, project), &{&1, content_print(&1, bounds)})
          deps = for dep <- Spiral.Kino.Mounts.declared_dependencies(dir), do: {dep.name, package_print(dep.target, seen, bounds)}
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
