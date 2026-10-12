defmodule Spiral.Kino.Memo do
  alias Spiral.Kino.Toolchain

  @format 1
  @keep_entries 5_000
  @prune_every_ms 600_000
  @tool_opts [:print_code, :plot, :render_plot, :spiral, :python, :lua, :pwsh, :cc, :dcc, :rustc_bin]
  @stub_opts [:compile, :rustc, :execute, :target, :host]

  @spec context(keyword(), [map()]) :: map() | nil
  def context(opts, steps) do
    if enabled?(opts) do
      %{
        dir: dir(opts),
        base: %{
          format: @format,
          compiler: compiler_identity(opts),
          kino: kino_identity(),
          tools: Keyword.take(opts, @tool_opts)
        },
        packages: package_prints(steps, opts)
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
    packages = Enum.map(package_paths(step.program), &{&1, Map.get(context.packages, &1)})

    {context.base, step.program, Map.get(step, :real, ""), builder_lines, packages}
    |> :erlang.term_to_binary()
    |> then(&:crypto.hash(:sha256, &1))
    |> Base.encode16(case: :lower)
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

  defp compiler_identity(opts) do
    dll = Toolchain.compiler_dll(opts)
    {dll, file_print(dll), Toolchain.package_dir(opts) |> Path.join("core") |> tree_print()}
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

  defp package_prints(steps, _opts) do
    steps
    |> Enum.flat_map(&package_paths(&1.program))
    |> Enum.uniq()
    |> Map.new(&{&1, tree_print(&1)})
  end

  @doc false
  def package_paths(program) do
    ~r/^\/\/\/- (.*)$/m
    |> Regex.scan(program)
    |> Enum.flat_map(fn [_, flags] ->
      ~r/--package\s+(\S+)/ |> Regex.scan(flags) |> Enum.map(fn [_, path] -> path end)
    end)
  end

  defp tree_print(dir), do: package_print(dir, MapSet.new())

  defp package_print(dir, seen) do
    dir = Path.expand(dir)

    if MapSet.member?(seen, dir) do
      :seen
    else
      seen = MapSet.put(seen, dir)

      case File.read(Path.join(dir, "package.spiproj")) do
        {:ok, project} ->
          files = Enum.map(module_files(dir, project), &{&1, content_print(&1)})
          deps = for dep <- package_dependencies(project), do: {dep, package_print(Path.join(dir, dep), seen)}
          :crypto.hash(:sha256, :erlang.term_to_binary({project, files, deps}))

        _ ->
          :missing
      end
    end
  end

  @doc false
  def module_files(dir, project) do
    project
    |> section("modules")
    |> Enum.reduce({[], []}, fn {indent, entry}, {files, folders} ->
      folders = Enum.drop_while(folders, fn {level, _name} -> level >= indent end)
      path = folders |> Enum.reverse() |> Enum.map(&elem(&1, 1))

      if String.ends_with?(entry, "/") do
        {files, [{indent, String.trim_trailing(entry, "/")} | folders]}
      else
        name = entry |> String.trim_trailing("-") |> String.trim_trailing("*")
        {files ++ candidates(dir, Path.join(path ++ [name])), folders}
      end
    end)
    |> elem(0)
  end
  defp candidates(dir, name) do
    [".spi", ".spir"] |> Enum.map(&Path.join(dir, name <> &1)) |> Enum.filter(&File.regular?/1)
  end

  defp package_dependencies(project) do
    project
    |> section("packages")
    |> Enum.map(fn {_indent, entry} -> entry |> String.trim_trailing("-") |> String.trim_trailing("*") end)
    |> Enum.reject(&String.starts_with?(&1, "|"))
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

  defp content_print(path) do
    case File.read(path) do
      {:ok, text} -> :crypto.hash(:sha256, text)
      _ -> :missing
    end
  end

  defp file_print(path) do
    case File.stat(path, time: :posix) do
      {:ok, %{size: size, mtime: mtime}} -> {size, mtime}
      _ -> :missing
    end
  end
end
