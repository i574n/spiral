defmodule Spiral.Cells.NotebookGateArgsTest do
  use ExUnit.Case, async: true

  alias Mix.Tasks.Spiral.Notebook

  test "the gate turns memo and html off and sends reports to a scratch dir" do
    assert Notebook.gate_args(["--gate", "--path", "a.spi"], "scratch") ==
             ["--path", "a.spi", "--no-memo", "--no-html", "--output-dir", "scratch"]
  end

  test "the gate keeps a report location the caller chose" do
    assert Notebook.gate_args(["--gate", "--path", "a.spi", "--output-dir", "mine"], "scratch") ==
             ["--path", "a.spi", "--output-dir", "mine", "--no-memo", "--no-html"]

    assert Notebook.gate_args(["--path", "a.spi", "--output-path", "a.ipynb", "--gate"], "scratch") ==
             ["--path", "a.spi", "--output-path", "a.ipynb", "--no-memo", "--no-html"]
  end
end
