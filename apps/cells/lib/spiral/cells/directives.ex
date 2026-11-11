defmodule Spiral.Cells.Directives do
  alias Spiral.Cells.Builders

  @spec prepare(String.t(), keyword()) :: %{
          code: String.t(),
          print_code: boolean(),
          timeout: pos_integer() | nil,
          generated_main: boolean(),
          no_value: boolean(),
          packages: [String.t()],
          builders: [map()]
        }
  def prepare(code, opts \\ []) do
    {builders, stripped} = Builders.split(code)

    case decode(Spiral.Cells.Domain.prepare(stripped)) do
      {:ok, prepared} ->
        prepared
        |> Map.put(:builders, builders)
        |> Map.put(:print_code, opts[:print_code] == true or prepared.print_code)

      {:error, kind, payload} ->
        raise ArgumentError, message(kind, payload)
    end
  end

  @spec scale_budget(pos_integer() | nil | :infinity) :: pos_integer() | nil | :infinity
  def scale_budget(ms) when is_integer(ms), do: max(1, round(ms * timeout_scale()))
  def scale_budget(other), do: other

  @spec timeout_scale() :: float()
  def timeout_scale do
    case Float.parse(System.get_env("SPIRAL_CELLS_TIMEOUT_SCALE") || "") do
      {scale, ""} when scale > 0 -> scale
      _ -> 1.0
    end
  end

  @spec scale_note() :: String.t()
  def scale_note do
    case timeout_scale() do
      scale when scale == 1.0 -> ""
      scale -> " (header and default budgets scaled by SPIRAL_CELLS_TIMEOUT_SCALE=#{scale})"
    end
  end

  @spec per_test_compile?() :: boolean()
  def per_test_compile?, do: System.get_env("SPIRAL_CELLS_PER_TEST") != "0"

  @main_from_expression "1"
  @main_from_definitions_only "2"

  defp decode(<<"ok\n", rest::binary>>) do
    [print, timeout, generated, packages, code] = String.split(rest, "\n", parts: 5)

    {:ok,
     %{
       code: code,
       print_code: print == "1",
       timeout: if(timeout == "-", do: nil, else: scale_budget(String.to_integer(timeout))),
       generated_main: generated in [@main_from_expression, @main_from_definitions_only],
       no_value: generated == @main_from_definitions_only,
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
