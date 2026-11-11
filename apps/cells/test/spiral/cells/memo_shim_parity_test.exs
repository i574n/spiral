defmodule Spiral.Cells.MemoShimParityTest do
  use ExUnit.Case, async: true

  defp oracle(text) do
    case Regex.run(~r/^\s*path\s*=\s*"?([^"\r\n]+)"?\s*$/m, text) do
      [_, target] -> "1\t" <> target
      _ -> "0\t"
    end
  end

  test "the Spiral shim path matches the old path regex on every shim shape" do
    shims = [
      "path = \"C:/tools/bin/cl.exe\"\n",
      "path = C:/tools/bin/cl.exe\r\n",
      "x = 1\n\n  path=plain  \n",
      "path = \"x\" # comment\npath = y\n",
      "path = \"\"\npath = \"z\"",
      "path = \"a \"  \n",
      "pathx = 1\npath = ok",
      "\tpath\t=\t\"tab\"\t",
      "nopath = z",
      "path =",
      "",
      "path = a\"b"
    ]

    for shim <- shims, do: assert(Spiral.Cells.Domain.shim_path(shim) == oracle(shim), inspect(shim))
  end
end
