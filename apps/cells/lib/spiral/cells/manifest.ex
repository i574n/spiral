defmodule Spiral.Cells.Manifest do
  @moduledoc false

  @names ["spiral.toml", "package.spiproj"]

  @spec names() :: [String.t()]
  def names, do: @names

  @spec path(String.t()) :: String.t() | nil
  def path(dir) do
    @names |> Enum.map(&Path.join(dir, &1)) |> Enum.find(&File.regular?/1)
  end

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
  def declares_modules?(text), do: Regex.match?(~r/^\s*modules\s*=/m, text)

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
  def from_toml(text) do
    text
    |> String.replace("\r\n", "\n")
    |> String.split("\n")
    |> convert([])
    |> Enum.reverse()
    |> Enum.join("\n")
  end

  defp convert([], acc), do: acc

  defp convert([line | rest], acc) do
    trimmed = String.trim(line)

    cond do
      trimmed == "" or String.starts_with?(trimmed, "#") ->
        convert(rest, ["" | acc])

      not String.contains?(trimmed, "=") or String.starts_with?(trimmed, "=") ->
        convert(rest, [line | acc])

      true ->
        [key, value] = String.split(trimmed, "=", parts: 2)
        key = String.trim(key)
        value = String.trim(value)

        cond do
          String.starts_with?(value, "'''") -> block(key, String.slice(value, 3..-1//1), rest, acc)
          String.starts_with?(value, "[") -> list(key, value, rest, acc)
          true -> convert(rest, ["#{key}: #{unquoted(value)}" | acc])
        end
    end
  end

  defp block(key, first, rest, acc) do
    acc = [key <> ":" | acc]
    acc = if String.trim(first) != "", do: ["    " <> first | acc], else: acc
    {body, after_body} = Enum.split_while(rest, &(not String.ends_with?(String.trim(&1), "'''")))
    acc = Enum.reduce(body, acc, fn line, acc -> [if(String.trim(line) == "", do: "", else: "    " <> line) | acc] end)

    case after_body do
      [last | remaining] ->
        [before | _] = String.split(last, "'''")
        convert(remaining, if(String.trim(before) != "", do: ["    " <> before | acc], else: acc))

      [] ->
        acc
    end
  end

  defp list(key, value, rest, acc) do
    {collected, remaining} = collect(value, rest)
    items = collected |> String.trim() |> String.trim_leading("[") |> String.trim_trailing("]") |> String.split(",")
    items = items |> Enum.map(&unquoted/1) |> Enum.reject(&(&1 == ""))
    convert(remaining, Enum.reverse(Enum.map(items, &("    " <> &1))) ++ [key <> ":" | acc])
  end

  defp collect(value, rest) do
    if String.ends_with?(String.trim_trailing(value), "]") or rest == [] do
      {value, rest}
    else
      [next | remaining] = rest
      collect(value <> " " <> String.trim(next), remaining)
    end
  end

  defp unquoted(value) do
    value = String.trim(value)
    quoted = String.length(value) >= 2 and String.first(value) in ["\"", "'"] and String.last(value) == String.first(value)
    if quoted, do: String.slice(value, 1..-2//1), else: value
  end
end
