defmodule Spiral.Cells.Builders do
  @spec split(String.t()) :: {[map()], String.t()}
  def split(code) when is_binary(code) do
    case Spiral.Cells.Domain.builder_split(code) do
      "E" <> message -> raise ArgumentError, message
      "K" <> wire -> wire |> wire_fields([]) |> decode_split()
    end
  end

  defp wire_fields("", acc), do: Enum.reverse(acc)

  defp wire_fields(wire, acc) do
    [len, rest] = :binary.split(wire, ":")
    n = String.to_integer(len)
    <<field::binary-size(^n), rest::binary>> = rest
    wire_fields(rest, [field | acc])
  end

  defp decode_split([body, count | fields]) do
    {builders, []} = Enum.map_reduce(List.duplicate(nil, String.to_integer(count)), fields, fn _, left -> decode_builder(left) end)
    {builders, body}
  end

  defp decode_builder([tool, raw, contract, wasm, cleanup, target, env, count | rest]) do
    {deps, rest} = Enum.split(rest, 3 * String.to_integer(count))
    deps = deps |> Enum.chunk_every(3) |> Enum.map(&wire_dep/1)
    builder = %{tool: String.to_atom(tool), raw: raw, contract: wire_opt(contract), wasm: wire_opt(wasm), deps: deps}
    {Map.merge(builder, %{cleanup: wire_flag(cleanup), target: wire_opt(target), env: wire_opt(env)}), rest}
  end

  defp wire_dep([name, version, raw]), do: %{name: name, version: wire_opt(version), raw: raw}

  defp wire_opt("-"), do: nil
  defp wire_opt("+" <> value), do: value

  defp wire_flag("-"), do: nil
  defp wire_flag("t"), do: true
  defp wire_flag("f"), do: false

  @spec commands(String.t()) :: [map()]
  def commands(code) when is_binary(code) do
    {commands, _body} = split(code)
    commands
  end

  @spec host_rust?(map()) :: boolean()
  def host_rust?(%{tool: :rust, contract: nil, wasm: nil, deps: [], cleanup: cleanup}) do
    cleanup != false
  end

  def host_rust?(_), do: false

  @spec backend(map()) :: String.t()
  def backend(%{tool: tool}), do: tool |> Atom.to_string() |> Spiral.Cells.Domain.target_backend() |> known_target(tool)

  @spec ext(map()) :: String.t()
  def ext(%{tool: tool}), do: tool |> Atom.to_string() |> Spiral.Cells.Domain.target_extension() |> known_target(tool)

  defp known_target("", tool), do: raise(ArgumentError, "no Spiral target for #{inspect(tool)}")
  defp known_target(value, _tool), do: value

  @spec dispatch(map(), String.t()) ::
          {:spiral, [String.t()]}
          | {:fsi, String.t()}
          | {:python, String.t()}
          | {:bun, String.t()}
          | {:cc, String.t()}
          | {:dcc, String.t()}
          | {:gleam, String.t(), [map()]}
          | {:zig, String.t()}
          | {:lean, String.t()}
          | {:wgsl, String.t()}
  def dispatch(builder, path) do
    case builder |> raw_of() |> Spiral.Cells.Domain.builder_route(path) |> String.split("\n") do
      ["spiral" | argv] -> {:spiral, argv}
      ["gleam"] -> {:gleam, path, Map.get(builder, :deps, [])}
      ["E" <> message] -> raise ArgumentError, message
      [route] -> {String.to_atom(route), path}
    end
  end

  @spec argv(map(), String.t()) :: [String.t()]
  def argv(builder, path) do
    case builder |> raw_of() |> Spiral.Cells.Domain.builder_argv(path) do
      "E" <> message -> raise ArgumentError, message
      wire -> String.split(wire, "\n")
    end
  end

  defp raw_of(builder), do: Map.get(builder, :raw) || Atom.to_string(builder.tool)
end
