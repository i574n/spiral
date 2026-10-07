defmodule Spiral.Kino.Cell do
  @external_resource Path.expand("console.spi", __DIR__)
  @console File.read!(Path.expand("console.spi", __DIR__))

  @spec console_source() :: String.t()
  def console_source, do: @console

  @spec package_project([String.t()]) :: String.t()
  def package_project(includes \\ []) do
    Spiral.Kino.Domain.package_project(Enum.join(includes, "\n"))
  end

  @spec patch_rust(String.t(), boolean()) :: String.t()
  def patch_rust(rust, show_value) do
    Spiral.Kino.Domain.patch_rust(rust, if(show_value, do: "1", else: "0"))
  end

  # The compiler's Python entry exits with main's i32 (`sys.exit`, as C and Rust programs return it); a cell shows main's
  # value instead, so Kino runs the entry that prints it (nothing for unit), whichever entry the compiler wrote.
  @python_entry "if __name__ == '__main__': result = main(); None if result is None else print(result)"

  @spec patch_python(String.t()) :: String.t()
  def patch_python(python) do
    Regex.replace(~r/^if __name__ == '__main__':.*$/m, python, fn _ -> @python_entry end, global: false)
  end

  @spec split_output(String.t()) :: {String.t() | nil, String.t()}
  def split_output(output) do
    case Spiral.Kino.Domain.split_output(output) do
      <<"0\n", stdout::binary>> ->
        {nil, stdout}

      <<"1\n", rest::binary>> ->
        case String.split(rest, "\n", parts: 2) do
          [value, stdout] -> {value, stdout}
          [value] -> {value, ""}
        end
    end
  end

  @spec unit_result?(String.t()) :: boolean()
  def unit_result?(output) do
    Spiral.Kino.Domain.unit_result(output) == "1"
  end
end
