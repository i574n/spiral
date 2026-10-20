defmodule Spiral.Cells.NotebookSpiralLibTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Notebook

  @tag :tmp_dir
  test "a repo cloned beside spiral finds lib/spiral through the sibling layout", %{tmp_dir: dir} do
    lib = Path.join([dir, "spiral", "lib", "spiral"])
    File.mkdir_p!(lib)
    File.write!(Path.join(lib, "package.spiproj"), "modules:\n")
    engine = Path.join([dir, "blog", "engine"])
    File.mkdir_p!(engine)

    assert Notebook.find_spiral_lib(Path.join(engine, "html.spi")) == Path.expand(lib)
  end

  @tag :tmp_dir
  test "a closer deps/spiral wins over the sibling layout", %{tmp_dir: dir} do
    sibling = Path.join([dir, "spiral", "lib", "spiral"])
    own = Path.join([dir, "tibia", "deps", "spiral", "lib", "spiral"])
    for lib <- [sibling, own], do: (File.mkdir_p!(lib); File.write!(Path.join(lib, "package.spiproj"), "modules:\n"))
    src = Path.join([dir, "tibia", "src"])
    File.mkdir_p!(src)

    assert Notebook.find_spiral_lib(Path.join(src, "combat.spi")) == Path.expand(own)
  end

  @tag :tmp_dir
  test "a project outside any spiral layout falls back to a SPIRAL_LIB holding a package", %{tmp_dir: dir} do
    env_lib = Path.join([dir, "elsewhere", "lib"])
    File.mkdir_p!(env_lib)
    assert Notebook.spiral_lib_from_env(env_lib) == nil
    File.write!(Path.join(env_lib, "package.spiproj"), "modules:\n")

    assert Notebook.spiral_lib_from_env(env_lib) == Path.expand(env_lib)
    assert Notebook.spiral_lib_from_env("") == nil
    assert Notebook.spiral_lib_from_env(nil) == nil
  end
end
