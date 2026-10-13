defmodule Spiral.Kino.MemoTest do
  use ExUnit.Case, async: true

  alias Spiral.Kino.Memo

  setup do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("memo")
    package = Path.join(dir, "pkg")
    File.mkdir_p!(Path.join(package, "sub"))
    File.write!(Path.join(package, "package.spiproj"), "packages:\n    |core-\nmodules:\n    listed-\n    sub/\n        inner\n")
    File.write!(Path.join(package, "listed.spi"), "inl a () = 1i32\n")
    File.write!(Path.join(package, "sub/inner.spi"), "inl b () = 2i32\n")
    File.write!(Path.join(package, "unlisted.spi"), "inl c () = 3i32\n")
    step = %{program: "///- --package #{package}\n\ninl main () = 0i32\n", real: ""}
    key = fn -> Memo.key(Memo.context([memo: true, memo_dir: Path.join(dir, "memo")], [step]), step, []) end
    %{package: package, key: key}
  end

  test "editing a package file the project does not list keeps the key", %{package: package, key: key} do
    before = key.()
    File.write!(Path.join(package, "unlisted.spi"), "inl c () = 4i32\n")
    assert key.() == before
  end

  test "editing a listed module, a module in a listed folder, or the project changes the key", %{package: package, key: key} do
    first = key.()
    File.write!(Path.join(package, "listed.spi"), "inl a () = 5i32\n")
    second = key.()
    refute second == first
    File.write!(Path.join(package, "sub/inner.spi"), "inl b () = 6i32\n")
    third = key.()
    refute third == second
    File.write!(Path.join(package, "package.spiproj"), "packages:\n    |core-\nmodules:\n    listed-\n")
    refute key.() == third
  end

  test "the listed modules are read from package.spiproj, folders included", %{package: package} do
    project = File.read!(Path.join(package, "package.spiproj"))
    assert Enum.map(Memo.module_files(package, project), &Path.relative_to(&1, package)) == ["listed.spi", "sub/inner.spi"]
  end

  test "nested folders resolve like lib/spiral's leptos/svg and near/wallet/src", %{package: package} do
    File.mkdir_p!(Path.join(package, "a/b/c"))
    File.write!(Path.join(package, "a/b/c/deep.spi"), "")
    File.write!(Path.join(package, "a/top.spi"), "")
    File.write!(Path.join(package, "after.spi"), "")
    project = "modules:\n    a/\n        b/\n            c/\n                deep\n        top\n    after\n"
    assert Enum.map(Memo.module_files(package, project), &Path.relative_to(&1, package)) == ["a/b/c/deep.spi", "a/top.spi", "after.spi"]
  end

  test "every module the spiral library lists resolves to a file" do
    lib = Path.expand("../../../../../lib/spiral", __DIR__)
    project = File.read!(Path.join(lib, "package.spiproj"))
    entries =
      project
      |> String.replace("\r\n", "\n")
      |> String.split("\n")
      |> Enum.drop_while(&(String.trim(&1) != "modules:"))
      |> Enum.drop(1)
      |> Enum.map(&String.trim/1)
      |> Enum.reject(&(&1 == "" or String.ends_with?(&1, "/")))
      |> Enum.map(&(&1 |> String.trim_trailing("-") |> String.trim_trailing("*")))

    resolved = lib |> Memo.module_files(project) |> Enum.map(&Path.rootname(Path.basename(&1)))
    assert entries != []
    assert Enum.reject(entries, &(&1 in resolved)) == []
  end

  test "the compiler path keys the same however it is spelled (wrapper env vs default)", %{package: package} do
    dll = Path.join(package, "SpiralCompiler.dll")
    File.write!(dll, "dll")
    step = %{program: "inl main () = 0i32\n", real: ""}
    key = fn spelled -> Memo.key(Memo.context([memo: true, compiler_dll: spelled], [step]), step, []) end
    windows = String.replace(dll, "/", "\\")
    assert key.(dll) == key.(if(match?({:win32, _}, :os.type()), do: String.upcase(windows), else: dll))
  end
  test "Kino's identity covers the modules that shape a result, not the editor or report ones" do
    modules = Memo.result_path_modules()
    assert Spiral.Kino.Targets in modules
    assert Spiral.Kino.Notebook in modules
    refute Spiral.Kino.SmartCell in modules
    refute Spiral.Kino.CompilerClient in modules
  end
end
