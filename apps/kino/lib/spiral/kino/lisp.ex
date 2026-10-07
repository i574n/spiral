defmodule Spiral.Kino.Lisp do
  @moduledoc """
  A cell whose first line is `///! lisp` holds Lisp forms (spiral/apps/lisp: S-expressions for Spiral, one top-level form
  per 280-character message). `expand/2` turns them into Spiral with apps/lisp/spl2spi.py: what precedes the marker line
  (the notebook runner's program puts earlier cells first) stays as it is, the `///` directive lines that follow it stay
  on top, so `///> rust`, `///- --timeout` etc. work as in any Spiral cell, and the rest is transpiled.
  """
  alias Spiral.Kino.Toolchain

  @marker "///! lisp"
  @spl2spi Path.expand("../../../../lisp/spl2spi.py", __DIR__)

  @spec lisp?(String.t()) :: boolean()
  def lisp?(code), do: code |> String.replace("\r\n", "\n") |> String.split("\n") |> Enum.any?(&(String.trim(&1) == @marker))

  @spec expand(String.t(), keyword()) :: String.t()
  def expand(code, opts \\ []) do
    if lisp?(code), do: transpile(code, opts), else: code
  end

  defp transpile(code, opts) do
    {before, [_marker | lines]} = code |> String.replace("\r\n", "\n") |> String.split("\n") |> Enum.split_while(&(String.trim(&1) != @marker))
    {directives, forms} = Enum.split_while(lines, &String.starts_with?(String.trim_leading(&1), "///"))
    dir = Path.join(System.tmp_dir!(), "spiral_kino_lisp_#{System.unique_integer([:positive])}")

    try do
      File.mkdir_p!(dir)
      spl = Path.join(dir, "cell.spl")
      spi = Path.join(dir, "cell.spi")
      File.write!(spl, Enum.join(forms, "\n"))
      python = Toolchain.python(opts) || raise "Spiral.Kino.Lisp: python was not found"

      case System.cmd(python, [opts[:spl2spi] || @spl2spi, spl, spi], stderr_to_stdout: true) do
        {_, 0} -> Enum.join(before ++ directives ++ [File.read!(spi)], "\n")
        {output, status} -> raise "Spiral.Kino.Lisp: spl2spi.py failed (exit #{status}): #{output}"
      end
    after
      File.rm_rf(dir)
    end
  end
end
