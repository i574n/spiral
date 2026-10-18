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

  test "an untargeted test step under the implicit default is marked to fail, a targeted one and a plain cell are not" do
    steps = [
      %{index: 0, cell_source: "///- --test\ntest one =\n    1i32 |> _assert_eq 1i32"},
      %{index: 1, cell_source: "///- --test\n///> c\ntest two =\n    1i32 |> _assert_eq 1i32"},
      %{index: 2, cell_source: "inl f () = 1i32"}
    ]

    [one, two, plain] = Notebook.with_builders(steps, [], true, %{0 => "one", 1 => "two"})
    assert one.untargeted == "one"
    refute Map.has_key?(two, :untargeted)
    refute Map.has_key?(plain, :untargeted)
    assert Notebook.untargeted_message("one") =~ "test one has no ///> target"

    [declared] = Notebook.with_builders(Enum.take(steps, 1), [], false, %{0 => "one"})
    refute Map.has_key?(declared, :untargeted)
  end

  @tag :tmp_dir
  test "untargeted test blocks of a .spi are found by name, and a static prelude covers them", %{tmp_dir: dir} do
    bare = Path.join(dir, "bare.spi")
    File.write!(bare, "inl f () = 1i32\n\ntest one =\n    f () |> _assert_eq 1i32\n\n///> rust\ntest two =\n    f () |> _assert_eq 1i32\n")
    covered = Path.join(dir, "covered.spi")
    File.write!(covered, "test covered static =\n    open testing\n\ntest three =\n    1i32 |> _assert_eq 1i32\n")
    saved = System.get_env("SPIRAL_CELLS_DEFAULT_TARGET")
    System.delete_env("SPIRAL_CELLS_DEFAULT_TARGET")

    try do
      assert Notebook.untargeted_tests(bare) == ["one"]
      assert Notebook.untargeted_tests(covered) == []
    after
      if saved, do: System.put_env("SPIRAL_CELLS_DEFAULT_TARGET", saved)
    end
  end
end
