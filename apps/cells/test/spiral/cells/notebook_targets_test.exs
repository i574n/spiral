defmodule Spiral.Cells.NotebookTargetsTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.Notebook

  test "an untargeted test step fails whatever the defaults, a targeted one and a plain cell do not" do
    steps = [
      %{index: 0, cell_source: "///- --test\ntest one =\n    1i32 |> _assert_eq 1i32"},
      %{index: 1, cell_source: "///- --test\n///> c\ntest two =\n    1i32 |> _assert_eq 1i32"},
      %{index: 2, cell_source: "inl f () = 1i32"}
    ]

    defaults = Spiral.Cells.Builders.commands("///> rust")
    [one, two, plain] = Notebook.with_builders(steps, defaults, %{0 => "one", 1 => "two"})
    assert one.untargeted == "one"
    refute Map.has_key?(two, :untargeted)
    refute Map.has_key?(plain, :untargeted)
    assert Notebook.untargeted_message("one") == "NoTestTarget: test one names no target: add a ///> <lang> line to it"
  end

  @tag :tmp_dir
  test "untargeted test blocks of a .spi are found by name, and a static prelude no longer covers them", %{tmp_dir: dir} do
    bare = Path.join(dir, "bare.spi")
    File.write!(bare, "inl f () = 1i32\n\ntest one =\n    f () |> _assert_eq 1i32\n\n///> rust\ntest two =\n    f () |> _assert_eq 1i32\n")
    prelude = Path.join(dir, "prelude.spi")
    File.write!(prelude, "///> rust\ntest prelude static =\n    open testing\n\ntest three =\n    1i32 |> _assert_eq 1i32\n")

    assert Notebook.untargeted_tests(bare) == ["one"]
    assert Notebook.untargeted_tests(prelude) == ["three"]
  end

  test "an unknown ///> backend fails only its own step, and the other steps keep their builders" do
    steps = [
      %{index: 0, cell_source: "///- --test\n///> nope\ntest bad =\n    1i32 |> _assert_eq 1i32"},
      %{index: 1, cell_source: "///- --test\n///> c\ntest good =\n    1i32 |> _assert_eq 1i32"}
    ]

    [bad, good] = Notebook.with_builders(steps, [], %{0 => "bad", 1 => "good"})
    assert bad.builder_error =~ ~s(unknown Spiral backend "nope")
    refute Map.has_key?(good, :builder_error)
    assert Enum.map(good.builders, & &1.tool) == [:c]
  end

  test "a test's own target is taken as written, without the defaults' crates" do
    defaults = Spiral.Cells.Builders.commands("///> rust -d serde_json -d chrono")
    steps = [%{index: 0, cell_source: "///- --test\n///> rust -d serde_json\ntest one =\n    1i32 |> _assert_eq 1i32"}]
    [one] = Notebook.with_builders(steps, defaults, %{0 => "one"})
    assert Enum.map(hd(one.builders).deps, & &1.name) == ["serde_json"]
  end
end
