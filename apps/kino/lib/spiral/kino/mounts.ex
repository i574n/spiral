defmodule Spiral.Kino.Mounts do
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

    path = Path.join(base, "spiral-bin/kino-mounts")
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
    case Spiral.Kino.FileLock.with_lock(dir <> ".lock", fn -> build(dir, entries) end, 180_000) do
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
        deps = local_package_names(text)
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
          if entry.kind == :shadow,
            do: "\t#{mtime(Path.join(entry.target, "package.spiproj"))}",
            else: ""

        "#{entry.name}\t#{entry.kind}\t#{forward(entry.target)}#{stamp}"
      end)
      |> then(&("v2\n" <> &1))

    :crypto.hash(:sha256, payload) |> Base.encode16(case: :lower) |> binary_part(0, 16)
  end

  defp shadow(link, target) do
    File.mkdir_p!(link)
    text = File.read!(Path.join(target, "package.spiproj"))
    rewritten = Regex.replace(~r/^packageDir:\s*.+$/m, text, "packageDir: ..")
    File.write!(Path.join(link, "package.spiproj"), rewritten)
    File.write!(Path.join(link, "spiral_kino_shadow"), "")

    case File.ls(target) do
      {:ok, names} ->
        Enum.reduce_while(names, :ok, fn name, :ok ->
          if name == "package.spiproj" do
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
      File.regular?(Path.join(path, "spiral_kino_shadow")) -> remove_shadow(path)
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

  defp local_package_names(text) do
    {names, _mode} =
      Enum.reduce(String.split(text, ~r/\r?\n/), {[], :out}, fn line, {names, mode} ->
        cond do
          String.starts_with?(line, "packages:") ->
            {names, :in}

          String.starts_with?(line, "modules:") ->
            {names, :out}

          mode == :in and package_name(line) != nil ->
            {[package_name(line) | names], :in}

          true ->
            {names, mode}
        end
      end)

    Enum.reverse(names)
  end

  defp package_name(line) do
    item = String.trim(line)

    cond do
      item == "" -> nil
      String.starts_with?(item, "|") -> nil
      true -> String.trim_trailing(item, "-")
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
