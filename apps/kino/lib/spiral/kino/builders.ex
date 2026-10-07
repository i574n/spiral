defmodule Spiral.Kino.Builders do
  @tools %{
    "rust" => :rust,
    "fsharp" => :fsharp,
    "fs" => :fsharp,
    "typescript" => :typescript,
    "ts" => :typescript,
    "python" => :python,
    "py" => :python,
    "cuda" => :cuda,
    "cpp" => :cpp,
    "gleam" => :gleam,
    "lua" => :lua,
    "c" => :c,
    "delphi" => :delphi,
    "_" => :skip
  }

  @expected "rust, fsharp, typescript, python, cuda, cpp, gleam, lua, c, or delphi"

  @rust_flags %{
    long: %{
      "contract" => {:optional, :contract},
      "wasm" => {:optional, :wasm},
      "deps" => :deps,
      "cleanup" => :cleanup
    },
    short: %{
      "c" => {:optional, :contract},
      "w" => {:optional, :wasm},
      "d" => :deps,
      "l" => :cleanup
    }
  }

  @gleam_flags %{
    long: %{"target" => {:one, :target}, "deps" => :deps},
    short: %{"t" => {:one, :target}, "d" => :deps}
  }

  @cuda_flags %{
    long: %{"env" => {:one, :env}, "deps" => :deps},
    short: %{"e" => {:one, :env}, "d" => :deps}
  }

  @dep_flags %{
    long: %{"deps" => :deps},
    short: %{"d" => :deps}
  }

  @no_flags %{long: %{}, short: %{}}

  @spec split(String.t()) :: {[map()], String.t()}
  def split(code) when is_binary(code) do
    code = String.replace(code, "\r\n", "\n")

    {lines, commands} =
      Enum.map_reduce(String.split(code, "\n"), [], fn line, acc ->
        case take_line(line) do
          :keep -> {line, acc}
          {:command, command} -> {nil, acc ++ [command]}
        end
      end)

    body = lines |> Enum.reject(&is_nil/1) |> Enum.join("\n")
    {commands, body}
  end

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
  def backend(%{tool: tool}) do
    case tool do
      :rust -> "Rust"
      :fsharp -> "Fsharp"
      :typescript -> "TypeScript"
      :python -> "Python + Cuda"
      :cuda -> "Python + Cuda"
      :cpp -> "Cpp + Cuda"
      :gleam -> "Gleam"
      :lua -> "Lua"
      :c -> "C"
      :delphi -> "Delphi"
    end
  end

  @spec ext(map()) :: String.t()
  def ext(%{tool: tool}) do
    case tool do
      :rust -> ".rs"
      :fsharp -> ".fsx"
      :typescript -> ".ts"
      :python -> ".py"
      :cuda -> ".py"
      :cpp -> ".cpp"
      :gleam -> ".gleam"
      :lua -> ".lua"
      :c -> ".c"
      :delphi -> ".pas"
    end
  end

  @spec dispatch(map(), String.t()) ::
          {:spiral, [String.t()]}
          | {:fsi, String.t()}
          | {:python, String.t()}
          | {:bun, String.t()}
          | {:cc, String.t()}
          | {:dcc, String.t()}
  def dispatch(%{tool: :fsharp}, path), do: {:fsi, path}

  def dispatch(%{tool: :python, deps: [], env: nil}, path), do: {:python, path}

  # The native TypeScript backend's output runs under bun (it runs .ts directly and installs imported packages itself).
  def dispatch(%{tool: :typescript}, path), do: {:bun, path}

  def dispatch(%{tool: :c}, path), do: {:cc, path}

  def dispatch(%{tool: :delphi}, path), do: {:dcc, path}

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

  defp take_line(line) do
    trimmed = String.trim_leading(line)

    cond do
      String.starts_with?(trimmed, "////") ->
        :keep

      String.starts_with?(trimmed, "///>") ->
        rest = trimmed |> String.replace_prefix("///>", "") |> String.trim()
        {:command, parse_command!(rest)}

      true ->
        :keep
    end
  end

  defp parse_command!("_") do
    %{tool: :skip, raw: "_"}
  end

  defp parse_command!(rest) do
    case tokenize(rest) do
      [] ->
        unknown_backend("")

      ["_" | args] ->
        if args == [] do
          %{tool: :skip, raw: "_"}
        else
          raise ArgumentError, "builder _ takes no arguments"
        end

      [tool | args] ->
        case Map.fetch(@tools, String.downcase(tool)) do
          {:ok, :skip} ->
            %{tool: :skip, raw: "_"}

          {:ok, kind} ->
            parse_args(kind, args, rest)

          :error ->
            unknown_backend(tool)
        end
    end
  end

  defp unknown_backend(tool) do
    raise ArgumentError, "unknown Spiral backend #{inspect(tool)}, expected #{@expected}"
  end

  defp parse_args(tool, tokens, raw) do
    parse_tokens(flags(tool), tokens, blank(tool, raw))
  end

  defp parse_tokens(_spec, [], acc), do: acc

  defp parse_tokens(spec, [token | rest], acc) do
    cond do
      String.starts_with?(token, "--") ->
        {acc, rest} = parse_long(spec, token, rest, acc)
        parse_tokens(spec, rest, acc)

      String.starts_with?(token, "-") and token != "-" ->
        {acc, rest} = parse_short(spec, token, rest, acc)
        parse_tokens(spec, rest, acc)

      true ->
        raise ArgumentError, "unexpected builder argument #{inspect(token)}"
    end
  end

  defp parse_long(spec, token, rest, acc) do
    body = String.replace_prefix(token, "--", "")

    {name, inline} =
      case String.split(body, "=", parts: 2) do
        [name, value] -> {name, {:eq, value}}
        [name] -> {name, :none}
      end

    case Map.fetch(spec.long, name) do
      {:ok, kind} -> apply_flag(kind, inline, rest, acc, "--" <> name)
      :error -> raise ArgumentError, "unknown builder flag #{inspect("--" <> name)}"
    end
  end

  defp parse_short(spec, token, rest, acc) do
    body = String.replace_prefix(token, "-", "")

    case String.split(body, "=", parts: 2) do
      [letters, value] ->
        case String.graphemes(letters) do
          [letter] ->
            kind = short_kind!(spec, letter)
            apply_flag(kind, {:eq, value}, rest, acc, "-" <> letter)

          _ ->
            raise ArgumentError, "unknown builder flag #{inspect(token)}"
        end

      [letters] ->
        parse_cluster(spec, String.graphemes(letters), rest, acc)
    end
  end

  defp parse_cluster(_spec, [], rest, acc), do: {acc, rest}

  defp parse_cluster(spec, [letter | letters], rest, acc) do
    kind = short_kind!(spec, letter)

    cond do
      consuming?(kind) and letters != [] ->
        raise ArgumentError,
              "builder flag -#{letter} must be the last flag in -#{letter}#{Enum.join(letters)}"

      consuming?(kind) ->
        apply_flag(kind, :none, rest, acc, "-" <> letter)

      true ->
        {acc, _} = apply_flag(kind, cluster_inline(kind), [], acc, "-" <> letter)
        parse_cluster(spec, letters, rest, acc)
    end
  end

  defp short_kind!(spec, letter) do
    case Map.fetch(spec.short, letter) do
      {:ok, kind} -> kind
      :error -> raise ArgumentError, "unknown builder flag #{inspect("-" <> letter)}"
    end
  end

  defp apply_flag({:optional, field}, {:eq, value}, rest, acc, _flag) do
    {Map.put(acc, field, value), rest}
  end

  defp apply_flag({:optional, field}, :none, [next | rest], acc, _flag) do
    if flag_token?(next) do
      {Map.put(acc, field, ""), [next | rest]}
    else
      {Map.put(acc, field, next), rest}
    end
  end

  defp apply_flag({:optional, field}, :none, [], acc, _flag) do
    {Map.put(acc, field, ""), []}
  end

  defp apply_flag({:one, field}, {:eq, value}, rest, acc, _flag) do
    {Map.put(acc, field, value), rest}
  end

  defp apply_flag({:one, field}, :none, [next | rest], acc, flag) do
    if flag_token?(next) do
      raise ArgumentError, "expected a value for #{flag}"
    else
      {Map.put(acc, field, next), rest}
    end
  end

  defp apply_flag({:one, _field}, :none, [], _acc, flag) do
    raise ArgumentError, "expected a value for #{flag}"
  end

  defp apply_flag(:deps, {:eq, value}, rest, acc, _flag) do
    {Map.update!(acc, :deps, &(&1 ++ [parse_dep(value)])), rest}
  end

  defp apply_flag(:deps, :none, rest, acc, flag) do
    {taken, left} = Enum.split_while(rest, &(not flag_token?(&1)))

    if taken == [] do
      raise ArgumentError, "expected a dependency name for #{flag}"
    else
      {Map.update!(acc, :deps, fn deps -> deps ++ Enum.map(taken, &parse_dep/1) end), left}
    end
  end

  defp apply_flag(:cleanup, {:eq, value}, rest, acc, flag) do
    {Map.put(acc, :cleanup, parse_bool(value, flag)), rest}
  end

  defp apply_flag(:cleanup, :none, ["true" | rest], acc, _flag) do
    {Map.put(acc, :cleanup, true), rest}
  end

  defp apply_flag(:cleanup, :none, ["false" | rest], acc, _flag) do
    {Map.put(acc, :cleanup, false), rest}
  end

  defp apply_flag(:cleanup, :none, rest, acc, _flag) do
    {Map.put(acc, :cleanup, false), rest}
  end

  defp consuming?({:one, _}), do: true
  defp consuming?(:deps), do: true
  defp consuming?(_), do: false

  defp cluster_inline({:optional, _}), do: {:eq, ""}
  defp cluster_inline(:cleanup), do: {:eq, "false"}

  defp flag_token?("-" <> rest) when rest != "", do: true
  defp flag_token?(_), do: false

  defp parse_bool("true", _flag), do: true
  defp parse_bool("false", _flag), do: false

  defp parse_bool(other, flag) do
    raise ArgumentError, "expected true or false for #{flag}, got: #{inspect(other)}"
  end

  defp parse_dep(token) do
    cond do
      String.contains?(token, "=") ->
        [name, version] = String.split(token, "=", parts: 2)
        %{name: name, version: unquote_value(version), raw: token}

      String.ends_with?(token, "]") ->
        %{name: token, version: nil, raw: token}

      true ->
        %{name: token, version: "*", raw: token}
    end
  end

  defp unquote_value(value) do
    cond do
      quoted?(value, "\"") -> String.slice(value, 1..-2//1)
      quoted?(value, "'") -> String.slice(value, 1..-2//1)
      true -> value
    end
  end

  defp quoted?(value, mark) do
    String.starts_with?(value, mark) and String.ends_with?(value, mark) and byte_size(value) >= 2
  end

  defp tokenize(text), do: tokenize(String.graphemes(text), [], nil, [])

  defp tokenize([], [], nil, tokens), do: Enum.reverse(tokens)
  defp tokenize([], current, nil, tokens), do: Enum.reverse([join(current) | tokens])

  defp tokenize([], _current, _quote, _tokens) do
    raise ArgumentError, "unterminated quote in builder arguments"
  end

  defp tokenize([ws | rest], [], nil, tokens) when ws in [" ", "\t"] do
    tokenize(rest, [], nil, tokens)
  end

  defp tokenize([ws | rest], current, nil, tokens) when ws in [" ", "\t"] do
    tokenize(rest, [], nil, [join(current) | tokens])
  end

  defp tokenize(["\\", quote | rest], current, nil, tokens) when quote in ["\"", "'"] do
    tokenize(rest, [quote | current], nil, tokens)
  end

  defp tokenize([quote | rest], current, nil, tokens) when quote in ["\"", "'"] do
    tokenize(rest, current, quote, tokens)
  end

  defp tokenize(["\\", quote | rest], current, quote, tokens) do
    tokenize(rest, [quote | current], quote, tokens)
  end

  defp tokenize([quote | rest], current, quote, tokens) do
    tokenize(rest, current, nil, tokens)
  end

  defp tokenize([char | rest], current, quote, tokens) do
    tokenize(rest, [char | current], quote, tokens)
  end

  defp join(chars), do: chars |> Enum.reverse() |> Enum.join()

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

  defp flags(:rust), do: @rust_flags
  defp flags(:gleam), do: @gleam_flags
  defp flags(tool) when tool in [:python, :cuda], do: @cuda_flags
  defp flags(:typescript), do: @dep_flags
  defp flags(_tool), do: @no_flags

  defp value_arg(_name, nil), do: []
  defp value_arg(name, ""), do: ["--#{name}="]
  defp value_arg(name, value), do: ["--#{name}=#{value}"]

  defp dep_args(deps), do: Enum.flat_map(deps, fn dep -> ["--deps", dep_arg(dep)] end)

  # The CLI writes a `name=version` dep into Cargo.toml as is, but the builder line's quotes are gone after tokenizing
  # (`pyo3='=0.26.0'` -> `pyo3==0.26.0`, invalid TOML: polyglot/lib/math): the version goes back in a TOML literal string.
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
