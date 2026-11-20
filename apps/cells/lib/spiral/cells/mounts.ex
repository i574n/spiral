defmodule Spiral.Cells.Mounts do
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
      {:ok, Spiral.Cells.Domain.mounts_forward(dir)}
    else
      build_locked(dir, entries)
    end
  end

  defp build_locked(dir, entries) do
    case Spiral.Cells.Domain.with_lock(dir <> ".lock", fn -> build(dir, entries) end, 180_000) do
      :ok -> {:ok, Spiral.Cells.Domain.mounts_forward(dir)}
      {:error, reason} when is_binary(reason) -> {:error, reason}
      {:error, :lock_timeout} -> {:error, Spiral.Cells.Domain.timeout_error("waited 180 s on the mount lock #{dir}.lock, held by a live build", 180_000, nil)}
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
  def newest(dir), do: Spiral.Cells.Domain.mounts_newest(dir)

  @spec share_mounted_deps?(String.t(), [String.t()]) :: boolean()
  def share_mounted_deps?(target, sibling_names), do: Spiral.Cells.Domain.mounts_share(target, sibling_names, Spiral.Cells.Domain.tool("dotnet", []) || "", Spiral.Cells.Domain.tool("compiler_dll", []) || "")

  defp build(dir, entries) do
    if File.regular?(Path.join(dir, "ready")) do
      :ok
    else
      remove!(dir)
      File.mkdir_p!(dir)

      Enum.reduce_while(entries, :ok, fn entry, :ok ->
        case place(dir, entry) do
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

  defp place(dir, entry) do
    link = Path.join(dir, entry.name)

    case entry.kind do
      :link ->
        make_link(link, entry.target)

      :shadow ->
        plan_links(Spiral.Cells.Domain.mount_plan_shadow(link, entry.target, Spiral.Cells.Domain.manifest_read!(entry.target), false))

      :patched ->
        plan_links(Spiral.Cells.Domain.mount_plan_patched(link, entry.target, Spiral.Cells.Domain.manifest_read!(entry.target), entry.patches, entry.package_dir == :absolute))
    end
  end

  defp plan_links({:ok, links}) do
    Enum.reduce_while(links, :ok, fn {link, target}, :ok ->
      case make_link(link, target) do
        :ok -> {:cont, :ok}
        error -> {:halt, error}
      end
    end)
  end

  defp plan_links({:error, message}), do: {:error, message}

  defp key(entries), do: Spiral.Cells.Domain.mounts_key(entries)

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
        case Spiral.Cells.Domain.make_symlink_result(target, link) do
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

  @spec declared_dependencies(String.t()) :: [%{name: String.t(), target: String.t(), import: String.t()}]
  def declared_dependencies(dir) do
    for {name, target, import} <- Spiral.Cells.Domain.mount_dependencies(dir, Spiral.Cells.Domain.tool("dotnet", []) || "", Spiral.Cells.Domain.tool("compiler_dll", []) || ""),
        do: %{name: name, target: target, import: import}
  end

  @spec mount_name(String.t()) :: String.t()
  def mount_name(target) do
    target |> Path.basename() |> String.downcase() |> Spiral.Cells.Domain.mount_name_of()
  end

  @spec dependency_closure([{String.t(), String.t()}]) :: [{String.t(), String.t()}]
  def dependency_closure(targets), do: Spiral.Cells.Domain.mounts_closure(targets, Spiral.Cells.Domain.tool("dotnet", []) || "", Spiral.Cells.Domain.tool("compiler_dll", []) || "")

  @spec qualified_imports([{String.t(), String.t()}]) :: [String.t()]
  def qualified_imports(targets), do: Spiral.Cells.Domain.mounts_imports(targets, Spiral.Cells.Domain.tool("dotnet", []) || "", Spiral.Cells.Domain.tool("compiler_dll", []) || "")

  defp win_path(path), do: String.replace(path, "/", "\\")
end
