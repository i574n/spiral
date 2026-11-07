defmodule Spiral.Cells.Manifest do
  @moduledoc false

  @names ["spiral.toml", "package.spiproj"]

  @spec names() :: [String.t()]
  def names, do: @names

  @spec path(String.t()) :: String.t() | nil
  def path(dir), do: Spiral.Cells.Domain.manifest_path(dir)

  @spec exists?(String.t()) :: boolean()
  def exists?(dir), do: path(dir) != nil

  @spec read(String.t(), keyword()) :: {:ok, String.t()} | {:error, File.posix()}
  def read(dir, opts \\ []) do
    case path(dir) do
      nil ->
        {:error, :enoent}

      file ->
        with {:ok, text} <- File.read(file) do
          cond do
            not String.ends_with?(file, ".toml") -> {:ok, text}
            declares_modules?(text) -> {:ok, from_toml(text)}
            true -> {:ok, Keyword.get(opts, :resolve, &resolve/1).(dir) || from_toml(text)}
          end
        end
    end
  end

  @spec declares_modules?(String.t()) :: boolean()
  def declares_modules?(text), do: Spiral.Cells.Domain.declares_modules(text)

  defp resolve(dir) do
    with dotnet when is_binary(dotnet) <- Spiral.Cells.Toolchain.dotnet([]),
         dll when is_binary(dll) <- Spiral.Cells.Toolchain.compiler_dll([]),
         true <- File.regular?(dll),
         true <- "resolve-manifest" in Spiral.Cells.CompilerDaemon.host_capabilities(dotnet, dll),
         {out, 0} <- System.cmd(dotnet, [dll, "--resolve-manifest", dir]) do
      out
    else
      _ -> nil
    end
  end

  @spec read!(String.t()) :: String.t()
  def read!(dir) do
    case read(dir) do
      {:ok, text} -> text
      {:error, reason} -> raise File.Error, reason: reason, action: "read manifest in", path: dir
    end
  end

  @spec from_toml(String.t()) :: String.t()
  def from_toml(text), do: Spiral.Cells.Domain.from_toml(text)
end
