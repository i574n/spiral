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
    builder = %{tool: String.to_existing_atom(tool), raw: raw, contract: wire_opt(contract), wasm: wire_opt(wasm), deps: deps}
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

  @spec default() :: map()
  def default do
    blank(:rust, "rust")
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
  def dispatch(%{tool: :fsharp}, path), do: {:fsi, path}

  def dispatch(%{tool: :python, deps: [], env: nil}, path), do: {:python, path}

  def dispatch(%{tool: :typescript}, path), do: {:bun, path}

  def dispatch(%{tool: :c}, path), do: {:cc, path}

  def dispatch(%{tool: :pascal}, path), do: {:dcc, path}

  def dispatch(%{tool: :gleam, target: target} = builder, path) when target in [nil, "erlang"],
    do: {:gleam, path, builder.deps}

  def dispatch(%{tool: :zig}, path), do: {:zig, path}

  def dispatch(%{tool: :lean}, path), do: {:lean, path}

  def dispatch(%{tool: :wgsl}, path), do: {:wgsl, path}

  def dispatch(builder, path), do: {:spiral, argv(builder, path)}

  @spec argv(map(), String.t()) :: [String.t()]
  def argv(%{tool: :rust} = builder, path) do
    ["rust", "--rs-path", path] ++
      value_arg("contract", builder.contract) ++
      value_arg("wasm", builder.wasm) ++
      dep_args(builder.deps) ++
      cleanup_args(builder)
  end

  def argv(%{tool: tool} = builder, path) when tool in [:python, :cuda] do
    ["cuda", "--py-path", path] ++ env_args(builder) ++ dep_args(builder.deps)
  end

  def argv(%{tool: :cpp}, path), do: ["cpp", "--cpp-path", path]

  def argv(%{tool: :gleam} = builder, path) do
    ["gleam", "--gleam-path", path] ++ target_args(builder) ++ dep_args(builder.deps)
  end

  def argv(%{tool: :lua}, path), do: ["lua", "--lua-path", path]


  defp blank(tool, raw) do
    %{
      tool: tool,
      raw: raw,
      contract: nil,
      wasm: nil,
      deps: [],
      cleanup: nil,
      target: nil,
      env: nil
    }
  end

  defp value_arg(_name, nil), do: []
  defp value_arg(name, ""), do: ["--#{name}="]
  defp value_arg(name, value), do: ["--#{name}=#{value}"]

  defp dep_args(deps), do: Enum.flat_map(deps, fn dep -> ["--deps", dep_arg(dep)] end)

  defp dep_arg(%{raw: raw, name: name, version: version}) when is_binary(version) do
    if String.contains?(raw, "=") and not String.contains?(raw, ["\"", "'"]) and
         not String.starts_with?(version, "{"),
       do: "#{name}='#{version}'",
       else: raw
  end

  defp dep_arg(%{raw: raw}), do: raw

  defp cleanup_args(%{cleanup: false}), do: ["--cleanup"]
  defp cleanup_args(_), do: []

  defp target_args(%{target: nil}), do: []
  defp target_args(%{target: target}), do: ["--target", target]

  defp env_args(%{env: nil}), do: []
  defp env_args(%{env: env}), do: ["--env", env]
end
