defmodule Spiral.Cells.MemoDepsTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Memo

  setup do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("memo_deps")
    dep = Path.join(dir, "dep")
    app = Path.join(dir, "app")
    File.mkdir_p!(dep)
    File.mkdir_p!(app)
    File.write!(Path.join(dep, "package.spiproj"), "packages:\n    |core-\nmodules:\n    used-\n    other-\n")
    File.write!(Path.join(dep, "used.spi"), "inl u () = 1i32\n")
    File.write!(Path.join(dep, "other.spi"), "inl o () = 2i32\n")
    File.write!(Path.join(app, "package.spiproj"), "packageDir: ..\npackages:\n    |core-\n    dep-\nmodules:\n    helper-\n")
    File.write!(Path.join(app, "helper.spi"), "inl h () = 0i32\n")
    step = %{program: "///- --package #{app}\n\ninl main () = used.u ()\n", real: ""}
    key = fn -> Memo.key(Memo.context([memo: true, memo_dir: Path.join(dir, "memo")], [step]), step, []) end
    %{dep: dep, key: key}
  end

  test "editing a dependency module the program never reaches keeps the key", %{dep: dep, key: key} do
    before = key.()
    File.write!(Path.join(dep, "other.spi"), "inl o () = 3i32\n")
    assert key.() == before
  end

  test "editing the dependency block the program calls changes the key", %{dep: dep, key: key} do
    before = key.()
    File.write!(Path.join(dep, "used.spi"), "inl u () = 4i32\n")
    refute key.() == before
  end
end
