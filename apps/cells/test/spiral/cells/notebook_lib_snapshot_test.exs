defmodule Spiral.Cells.NotebookLibSnapshotTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.Notebook

  setup do
    previous = System.get_env("SPIRAL_CELLS_LIB")
    on_exit(fn -> if previous, do: System.put_env("SPIRAL_CELLS_LIB", previous), else: System.delete_env("SPIRAL_CELLS_LIB") end)
    :ok
  end

  defp package(dir) do
    File.mkdir_p!(dir)
    File.write!(Path.join(dir, "package.spiproj"), "modules:\n")
    Path.expand(dir)
  end

  @tag :tmp_dir
  test "an explicit SPIRAL_CELLS_LIB snapshot wins over the ancestor lib", %{tmp_dir: dir} do
    live = package(Path.join([dir, "spiral", "lib", "spiral"]))
    snapshot = package(Path.join([dir, "snapshot", "lib", "spiral"]))
    file = Path.join([dir, "blog", "engine", "html.spi"])

    System.delete_env("SPIRAL_CELLS_LIB")
    assert Notebook.resolve_lib(path: file) == live

    System.put_env("SPIRAL_CELLS_LIB", snapshot)
    assert Notebook.resolve_lib(path: file) == snapshot
  end

  @tag :tmp_dir
  test "an explicit spiral_lib option still wins, and a snapshot without a package is ignored", %{tmp_dir: dir} do
    live = package(Path.join([dir, "spiral", "lib", "spiral"]))
    chosen = package(Path.join([dir, "chosen"]))
    empty = Path.join([dir, "empty"])
    File.mkdir_p!(empty)
    file = Path.join([dir, "blog", "engine", "html.spi"])

    System.put_env("SPIRAL_CELLS_LIB", empty)
    assert Notebook.resolve_lib(path: file) == live
    assert Notebook.resolve_lib(path: file, spiral_lib: chosen) == chosen
  end
end