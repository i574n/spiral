defmodule Spiral.Cells.Mounts do
  @skip MapSet.new([
          "target",
          "node_modules",
          "build",
          "dist",
          ".git",
          "deps",
          "playwright-report",
          "test-results"
        ])

  @spec root() :: String.t()
  def root do
    base =
      System.get_env("LOCALAPPDATA") ||
        Path.join(System.user_home!(), ".cache")

    path = Path.join(base, "spiral-bin/cells-mounts")
    File.mkdir_p!(path)
    path
  end

  @spec ensure([map()]) :: {:ok, String.t()} | {:error, String.t()}
  def ensure(entries) when is_list(entries) do
    dir = Path.join(root(), key(entries))

    if File.regular?(Path.join(dir, "ready")) do
      {:ok, forward(dir)}
    else
      build_locked(dir, entries)
    end
  end

  defp build_locked(dir, entries) do
    case Spiral.Cells.FileLock.with_lock(dir <> ".lock", fn -> build(dir, entries) end, 180_000) do
      :ok -> {:ok, forward(dir)}
      {:error, reason} when is_binary(reason) -> {:error, reason}
      {:error, reason} -> {:error, "could not mount packages: #{inspect(reason)}"}
    end
  end

  @spec remove!(String.t()) :: :ok
  def remove!(dir) do
    if File.dir?(dir) do
      case File.ls(dir) do
        {:ok, names} -> Enum.each(names, &remove_child(Path.join(dir, &1)))
        _ -> :ok
      end

      File.rm_rf(dir)
    end

    :ok
  end

  @spec newest(String.t()) :: non_neg_integer()
  def newest(dir), do: walk(dir, 0)

  @spec share_mounted_deps?(String.t(), [String.t()]) :: boolean()
  def share_mounted_deps?(target, sibling_names) do
    text = File.read!(Path.join(target, "package.spiproj"))

    case Regex.run(~r/^packageDir:\s*(.+)$/m, text) do
      [_, _dir] ->
        deps = local_package_names(text) |> Enum.map(&mount_name/1)
        deps != [] and Enum.all?(deps, &(&1 in sibling_names))

      _ ->
        false
    end
  end

  defp build(dir, entries) do
    if File.regular?(Path.join(dir, "ready")) do
      :ok
    else
      remove!(dir)
      File.mkdir_p!(dir)

      Enum.reduce_while(entries, :ok, fn entry, :ok ->
        link = Path.join(dir, entry.name)

        placed =
          case entry.kind do
            :link -> make_link(link, entry.target)
            :shadow -> shadow(link, entry.target)
            :patched -> patched(link, entry.target, entry.patches, entry.package_dir)
          end

        case placed do
          :ok -> {:cont, :ok}
          {:error, message} -> {:halt, {:error, message}}
        end
      end)
      |> case do
        :ok ->
          File.write!(Path.join(dir, "ready"), "")
          :ok

        error ->
          error
      end
    end
  end

  defp key(entries) do
    payload =
      entries
      |> Enum.sort_by(& &1.name)
      |> Enum.map_join("\n", fn entry ->
        stamp =
          case entry.kind do
            :shadow -> "\t#{mtime(Path.join(entry.target, "package.spiproj"))}"
            :patched -> "\t#{mtime(Path.join(entry.target, "package.spiproj"))}\t#{patches_digest({entry.package_dir, entry.patches})}"
            :link -> ""
          end

        "#{entry.name}\t#{entry.kind}\t#{forward(entry.target)}#{stamp}"
      end)
      |> then(&("v2\n" <> &1))

    :crypto.hash(:sha256, payload) |> Base.encode16(case: :lower) |> binary_part(0, 16)
  end

  defp patches_digest(patches) do
    :crypto.hash(:sha256, :erlang.term_to_binary(patches)) |> Base.encode16(case: :lower) |> binary_part(0, 16)
  end

  defp patched(link, target, patches, package_dir) do
    patched_names = patches |> Enum.map(&elem(&1, 0)) |> MapSet.new()

    with :ok <- top_level_only(patched_names),
         :ok <- shadow(link, target, patched_names, package_dir) do
      Enum.reduce_while(patches, :ok, fn {file, old, new}, :ok ->
        text = File.read!(Path.join(target, file))

        if String.contains?(text, old) do
          File.write!(Path.join(link, file), String.replace(text, old, new, global: false))
          {:cont, :ok}
        else
          {:halt, {:error, "patch for #{file} does not apply: #{inspect(old)} is not in #{Path.join(target, file)}"}}
        end
      end)
    end
  end

  defp top_level_only(names) do
    case Enum.find(names, &(Path.dirname(&1) != ".")) do
      nil -> :ok
      nested -> {:error, "patch target #{nested} is nested; patched mounts take top-level package files only"}
    end
  end

  defp project_for_mount(text, _target, :siblings), do: text |> then(&Regex.replace(~r/^packageDir:\s*.+$/m, &1, "packageDir: ..")) |> sibling_entries()

  defp project_for_mount(text, target, :absolute) do
    Regex.replace(~r/^packageDir:\s*(.+)$/m, text, fn _, dir -> "packageDir: " <> (dir |> String.trim() |> Path.expand(target)) end)
  end

  defp shadow(link, target, skipped \\ MapSet.new(), package_dir \\ :siblings) do
    File.mkdir_p!(link)
    text = File.read!(Path.join(target, "package.spiproj"))
    rewritten = project_for_mount(text, target, package_dir)
    File.write!(Path.join(link, "package.spiproj"), rewritten)
    File.write!(Path.join(link, "spiral_cells_shadow"), "")

    case File.ls(target) do
      {:ok, names} ->
        Enum.reduce_while(names, :ok, fn name, :ok ->
          if name == "package.spiproj" or MapSet.member?(skipped, name) do
            {:cont, :ok}
          else
            case make_link(Path.join(link, name), Path.join(target, name)) do
              :ok -> {:cont, :ok}
              {:error, message} -> {:halt, {:error, message}}
            end
          end
        end)

      {:error, reason} ->
        {:error, "could not read #{target}: #{inspect(reason)}"}
    end
  end

  defp make_link(link, target) do
    case :os.type() do
      {:win32, _} ->
        if File.regular?(target) do
          link_file(link, target)
        else
          {out, status} =
            System.cmd("cmd", ["/c", "mklink", "/J", win_path(link), win_path(target)])

          if status == 0, do: :ok, else: {:error, "could not link #{link}: #{String.trim(out)}"}
        end

      _ ->
        case File.ln_s(target, link) do
          :ok -> :ok
          {:error, reason} -> {:error, "could not link #{link}: #{inspect(reason)}"}
        end
    end
  end

  defp link_file(link, target) do
    {_, status} =
      System.cmd("cmd", ["/c", "mklink", win_path(link), win_path(target)],
        stderr_to_stdout: true
      )

    cond do
      status == 0 ->
        :ok

      elem(
        System.cmd("cmd", ["/c", "mklink", "/H", win_path(link), win_path(target)],
          stderr_to_stdout: true
        ),
        1
      ) == 0 ->
        :ok

      true ->
        case File.cp(target, link) do
          :ok -> :ok
          {:error, reason} -> {:error, "could not link #{link}: #{inspect(reason)}"}
        end
    end
  end

  defp remove_child(path) do
    cond do
      File.regular?(Path.join(path, "spiral_cells_shadow")) -> remove_shadow(path)
      File.dir?(path) -> rmdir_junction(path)
      true -> File.rm(path)
    end
  end

  defp remove_shadow(link) do
    case File.ls(link) do
      {:ok, names} ->
        Enum.each(names, fn name ->
          child = Path.join(link, name)
          if File.dir?(child), do: rmdir_junction(child), else: File.rm(child)
        end)

      _ ->
        :ok
    end

    File.rm_rf(link)
  end

  defp rmdir_junction(link) do
    case :os.type() do
      {:win32, _} ->
        link = win_path(link)
        if File.dir?(link), do: System.cmd("cmd", ["/c", "rmdir", link])

      _ ->
        File.rm(link)
    end
  end

  defp walk(dir, acc) do
    case File.ls(dir) do
      {:ok, names} ->
        Enum.reduce(names, acc, fn name, acc ->
          path = Path.join(dir, name)

          cond do
            File.regular?(path) and source?(name) -> max(acc, mtime(path))
            File.dir?(path) and name not in @skip -> walk(path, acc)
            true -> acc
          end
        end)

      _ ->
        acc
    end
  end

  defp source?(name) do
    name == "package.spiproj" or String.ends_with?(name, ".spi") or
      String.ends_with?(name, ".spir")
  end

  defp mtime(path) do
    case File.stat(path, time: :posix) do
      {:ok, %{mtime: mtime}} -> mtime
      _ -> 0
    end
  end

  defp local_package_names(text), do: Enum.map(package_entries(text), &elem(&1, 0))

  @spec declared_dependencies(String.t()) :: [%{name: String.t(), target: String.t(), import: String.t()}]
  def declared_dependencies(dir) do
    case File.read(Path.join(dir, "package.spiproj")) do
      {:ok, text} ->
        base = package_base(dir, text)

        for {item, declared} <- package_entries(text) do
          name = Path.basename(item)
          suffix = String.replace_prefix(declared, item, "")
          target = if relative_entry?(item), do: Path.expand(item, dir), else: Path.expand(item, base)
          %{name: name, target: target, import: name <> suffix}
        end

      _ ->
        []
    end
  end

  @spec declared_crates(String.t()) :: [String.t()]
  def declared_crates(dir) do
    case File.read(Path.join(dir, "package.spiproj")) do
      {:ok, text} ->
        {crates, _mode} =
          Enum.reduce(String.split(text, ~r/\r?\n/), {[], :out}, fn line, {crates, mode} ->
            cond do
              String.starts_with?(line, "crates:") -> {crates, :in}
              line != "" and not String.starts_with?(line, [" ", "\t"]) -> {crates, :out}
              mode == :in and String.trim(line) != "" -> {[String.trim(line) | crates], :in}
              true -> {crates, mode}
            end
          end)

        Enum.reverse(crates)

      _ ->
        []
    end
  end

  @spec mount_name(String.t()) :: String.t()
  def mount_name(target) do
    name = target |> Path.basename() |> String.downcase() |> String.replace(~r/[^a-z0-9_]/, "_")
    if name =~ ~r/^[0-9]/, do: "_" <> name, else: name
  end

  @spec dependency_closure([{String.t(), String.t()}]) :: [{String.t(), String.t()}]
  def dependency_closure(targets) do
    named = MapSet.new(targets, &elem(&1, 1))
    closure(Enum.map(targets, &elem(&1, 0)), named, [])
  end

  @spec qualified_imports([{String.t(), String.t()}]) :: [String.t()]
  def qualified_imports(targets) do
    named = MapSet.new(targets, &elem(&1, 1))

    targets
    |> Enum.flat_map(fn {target, _name} -> declared_dependencies(target) end)
    |> Enum.reject(&MapSet.member?(named, &1.name))
    |> Enum.map(& &1.import)
    |> Enum.uniq()
  end

  defp closure([], _named, found), do: Enum.reverse(found)

  defp closure([dir | rest], named, found) do
    {named, found, queue} =
      Enum.reduce(declared_dependencies(dir), {named, found, rest}, fn dependency, {named, found, queue} ->
        if MapSet.member?(named, dependency.name) or
             not File.regular?(Path.join(dependency.target, "package.spiproj")) do
          {named, found, queue}
        else
          {MapSet.put(named, dependency.name), [{dependency.target, dependency.name} | found],
           queue ++ [dependency.target]}
        end
      end)

    closure(queue, named, found)
  end

  defp relative_entry?(item), do: String.starts_with?(item, ["./", "../", ".\\", "..\\"])

  defp sibling_entries(text) do
    Enum.reduce(package_entries(text), text, fn {item, declared}, acc ->
      if relative_entry?(item) do
        suffix = String.replace_prefix(declared, item, "")
        String.replace(acc, ~r/^(\s+)#{Regex.escape(declared)}\s*$/m, "\\1#{Path.basename(item)}#{suffix}")
      else
        acc
      end
    end)
  end

  defp package_base(dir, text) do
    case Regex.run(~r/^packageDir:\s*(.+?)\s*$/m, text) do
      [_, packages] -> Path.expand(packages, dir)
      _ -> Path.expand("..", dir)
    end
  end

  defp package_entries(text) do
    {entries, _mode} =
      Enum.reduce(String.split(text, ~r/\r?\n/), {[], :out}, fn line, {entries, mode} ->
        cond do
          String.starts_with?(line, "packages:") ->
            {entries, :in}

          String.starts_with?(line, "modules:") ->
            {entries, :out}

          line != "" and not String.starts_with?(line, [" ", "\t"]) ->
            {entries, :out}

          mode == :in and package_entry(line) != nil ->
            {[package_entry(line) | entries], :in}

          true ->
            {entries, mode}
        end
      end)

    Enum.reverse(entries)
  end

  defp package_entry(line) do
    item = String.trim(line)

    cond do
      item == "" -> nil
      String.starts_with?(item, "|") -> nil
      true -> {item |> String.trim_trailing("-") |> String.trim_trailing("*"), item}
    end
  end

  defp forward(path) do
    path = String.replace(path, "\\", "/")

    case String.split(path, ":", parts: 2) do
      [drive, rest] when byte_size(drive) == 1 -> String.downcase(drive) <> ":" <> rest
      _ -> path
    end
  end

  defp win_path(path), do: String.replace(path, "/", "\\")
end
