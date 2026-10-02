defmodule Spiral.Kino.Directives do
  @backends [
    {"fsharp", nil, "F# (default, evaluated in .NET Interactive)"},
    {"rust", "rust", "Rust (F# → Fable → cargo run)"},
    {"typescript", "typescript", "TypeScript (F# → Fable)"},
    {"python", "python", "Python (F# → Fable)"},
    {"cuda", "cuda", "Python + CUDA (native Spiral backend)"},
    {"cpp", "cpp", "C++ + CUDA (native Spiral backend)"},
    {"gleam", "gleam", "Gleam"},
    {"lua", "lua", "Lua"}
  ]

  def backends, do: @backends

  def backend_ids, do: Enum.map(@backends, &elem(&1, 0))

  @type parsed :: %{
          args: String.t() | nil,
          builders: [String.t()],
          disabled: [String.t()]
        }

  @spec parse(String.t()) :: parsed()
  def parse(code) do
    lines = lines(code)

    %{
      args: Enum.find_value(lines, &arg_line/1),
      builders: Enum.flat_map(lines, &List.wrap(builder_line(&1))),
      disabled: Enum.filter(lines, &String.starts_with?(&1, "////"))
    }
  end

  @spec apply_options(String.t(), keyword()) :: String.t()
  def apply_options(code, opts) do
    code = String.replace(code, "\r\n", "\n")
    parsed = parse(code)

    flags =
      [
        opts[:print_code] && "--print-code",
        opts[:trace] && "--trace",
        blank_to_nil(opts[:kernel_args])
      ]
      |> Enum.filter(& &1)

    builder_lines =
      opts
      |> Keyword.get(:backend)
      |> List.wrap()
      |> Enum.map(&to_string/1)
      |> Enum.uniq()
      |> Enum.flat_map(fn id ->
        case builder_for!(id) do
          nil -> []
          command -> [String.trim("#{command} #{opts[:builder_args]}")]
        end
      end)
      |> Enum.reject(fn line ->
        command = first_word(line)
        Enum.any?(parsed.builders, &(first_word(&1) == command))
      end)
      |> Enum.map(&("///> " <> &1))

    code = merge_args(code, parsed.args, flags)

    case builder_lines do
      [] -> code
      lines -> Enum.join(lines, "\n") <> "\n" <> code
    end
  end

  defp merge_args(code, _existing, []), do: code

  defp merge_args(code, nil, flags) do
    "///- " <> Enum.join(flags, " ") <> "\n" <> code
  end

  defp merge_args(code, existing, flags) do
    missing = Enum.reject(flags, &flag_present?(existing, &1))

    if missing == [] do
      code
    else
      merged = String.trim("#{existing} #{Enum.join(missing, " ")}")
      {before, [_first | rest]} = code |> lines() |> Enum.split_while(&(arg_line(&1) == nil))
      Enum.join(before ++ ["///- " <> merged | rest], "\n")
    end
  end

  defp flag_present?(existing, flag) do
    existing |> String.split() |> then(&(String.split(flag) -- &1 == []))
  end

  defp builder_for!(id) do
    case List.keyfind(@backends, id, 0) do
      {_, command, _} ->
        command

      nil ->
        raise ArgumentError,
              "unknown Spiral backend #{inspect(id)}, expected one of: " <>
                Enum.join(backend_ids(), ", ")
    end
  end

  defp lines(code), do: code |> String.replace("\r\n", "\n") |> String.split("\n")

  defp arg_line("///- " <> args), do: String.trim(args)
  defp arg_line(_), do: nil

  defp builder_line("///> " <> builder), do: String.trim(builder)
  defp builder_line(_), do: nil

  defp first_word(line), do: line |> String.split(" ", parts: 2) |> hd()

  defp blank_to_nil(nil), do: nil

  defp blank_to_nil(value) do
    case String.trim(to_string(value)) do
      "" -> nil
      value -> value
    end
  end
end
