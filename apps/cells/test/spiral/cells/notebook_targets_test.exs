defmodule Spiral.Cells.NotebookTargetsTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.Notebook

  test "untargeted blocks are implicit only without a static prelude or a declared default" do
    plain = [%{kind: :spiral, source: "test a =\n    1 |> _assert_eq 1"}]
    prelude = [%{kind: :spiral, source: "///- --test static\n///> c\nopen testing"} | plain]
    saved = System.get_env("SPIRAL_CELLS_DEFAULT_TARGET")
    System.delete_env("SPIRAL_CELLS_DEFAULT_TARGET")

    try do
      assert Notebook.implicit_default?(plain, [])
      refute Notebook.implicit_default?(plain, default_target: "lua")
      refute Notebook.implicit_default?(plain, default_target: "")
      refute Notebook.implicit_default?(prelude, [])
    after
      if saved, do: System.put_env("SPIRAL_CELLS_DEFAULT_TARGET", saved)
    end
  end
end
