defmodule Spiral.Kino.Directives do
  @spec prepare(String.t(), keyword()) :: %{
          code: String.t(),
          print_code: boolean(),
          timeout: pos_integer() | nil,
          generated_main: boolean(),
          packages: [String.t()]
        }
  def prepare(code, opts \\ []) do
    case decode(Spiral.Kino.Domain.prepare(code)) do
      {:ok, prepared} ->
        %{prepared | print_code: opts[:print_code] == true or prepared.print_code}

      {:error, kind, payload} ->
        raise ArgumentError, message(kind, payload)
    end
  end

  defp decode(<<"ok\n", rest::binary>>) do
    [print, timeout, generated, packages, code] = String.split(rest, "\n", parts: 5)

    {:ok,
     %{
       code: code,
       print_code: print == "1",
       timeout: if(timeout == "-", do: nil, else: String.to_integer(timeout)),
       generated_main: generated == "1",
       packages: if(packages == "", do: [], else: String.split(packages, "\t"))
     }}
  end

  defp decode(<<"error\n", rest::binary>>) do
    case String.split(rest, "\n", parts: 2) do
      [kind, payload] -> {:error, kind, payload}
      [kind] -> {:error, kind, ""}
    end
  end

  defp message("dib", _), do: "Spiral cell code must not contain lines starting with \"#!\""
  defp message("directive", line), do: "unknown Spiral directive: #{inspect(line)}"
  defp message("flag", flag), do: "unknown kernel flag #{flag}"

  defp message("timeout", ms),
    do: "expected --timeout to be a positive integer (ms), got: #{inspect(ms)}"

  defp message("builder", args), do: "builder arguments are not used: #{inspect(args)}"
  defp message("backend", other), do: "unknown Spiral backend #{inspect(other)}, expected rust"
end
