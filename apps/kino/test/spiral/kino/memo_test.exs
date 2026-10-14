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
    step = %{program: "///- --package #{package}\n\ninl main () = listed.a () + sub.inner.b ()\n", real: ""}
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

  test "a listed module that is also the notebook keeps the key when only its tests or doc lines change", %{package: package, key: key} do
    listed = Path.join(package, "listed.spi")
    File.write!(listed, "/// # listed\ninl a () = 1i32\n\ntest a =\n    a () |> _assert_eq 2i32\n")
    first = key.()
    File.write!(listed, "/// # listed, accepted\ninl a () = 1i32\n\ntest a =\n    a () |> _assert_eq 1i32\n\ntest b =\n    a () |> _assert_eq 1i32\n")
    assert key.() == first
    File.write!(listed, "/// # listed\ninl a () = 7i32\n\ntest a =\n    a () |> _assert_eq 1i32\n")
    refute key.() == first
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
  test "a target run is reused when the generated code is the same, whatever source edit produced it, and only successful runs are kept" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("code_memo")
    opts = [memo: true, memo_dir: dir]
    counter = :counters.new(1, [])
    run = fn result -> fn -> :counters.add(counter, 1, 1); result end end
    chunk = {:ok, %{target: "rust", stdout: "49\n", exit_status: 0}}

    assert {^chunk, :miss} = Memo.code_result(opts, ["rust", "fn main() {}"], run.(chunk))
    assert {^chunk, :hit} = Memo.code_result(opts, ["rust", "fn main() {}"], run.(chunk))
    assert {^chunk, :miss} = Memo.code_result(opts, ["rust", "fn main() { 1; }"], run.(chunk))
    assert {{:error, :boom}, :miss} = Memo.code_result(opts, ["rust", "broken"], run.({:error, :boom}))
    assert {{:error, :boom}, :miss} = Memo.code_result(opts, ["rust", "broken"], run.({:error, :boom}))
    assert {^chunk, :off} = Memo.code_result([memo: false, memo_dir: dir], ["rust", "fn main() {}"], run.(chunk))
    assert :counters.get(counter, 1) == 5
  end
  test "a definition the program never reaches can change without changing the key; a reached one changes it" do
    step = fn unused, used -> %{program: "open testing\ninl helper () = #{used}\ninl unused () = #{unused}\ninl spiral_kino_test () =\n    helper () |> _assert_eq 1i32\nspiral_kino_test ()\n0i32\n", real: ""} end
    key = fn s -> Memo.key(Memo.context([memo: true, memo_dir: Spiral.Kino.TestHelpers.tmp_dir!("reach")], [s]), s, []) end
    first = key.(step.("1i32", "1i32"))
    assert key.(step.("2i32", "1i32")) == first
    refute key.(step.("1i32", "3i32")) == first
    assert Memo.reached_program(step.("2i32", "1i32").program) =~ "inl helper"
    refute Memo.reached_program(step.("2i32", "1i32").program) =~ "inl unused"
  end

  test "instances and comments do not hide a dependency: instances are always kept, // inside strings is not a comment" do
    program = "instance equable thing = fun a b => true\ninl url () = \"https://x//y\" |> fun _ => helper ()\ninl helper () = 1i32\ninl spiral_kino_test () = url ()\nspiral_kino_test ()\n"
    reached = Memo.reached_program(program)
    assert reached =~ "instance equable"
    assert reached =~ "inl helper"
  end

  test "a package definition the program never reaches keeps the key; a reached one and any instance change it", %{package: package} do
    File.write!(Path.join(package, "package.spiproj"), "packages:\n    |core-\nmodules:\n    listed-\n    sub/\n        inner\n    other\n    implicit\n")
    File.write!(Path.join(package, "other.spi"), "inl o () = 1i32\n")
    File.write!(Path.join(package, "implicit.spi"), "instance equable thing = fun x y => true\n")
    step = %{program: "///- --package #{package}\n\ninl main () = a ()\n", real: ""}
    key = fn -> Memo.key(Memo.context([memo: true, memo_dir: Path.join(package, "memo")], [step]), step, []) end
    first = key.()
    File.write!(Path.join(package, "other.spi"), "inl o () = 2i32\n")
    File.write!(Path.join(package, "sub/inner.spi"), "inl b () = 9i32\n")
    assert key.() == first
    File.write!(Path.join(package, "listed.spi"), "inl a () = 8i32\n")
    second = key.()
    refute second == first
    File.write!(Path.join(package, "implicit.spi"), "instance equable thing = fun x y => false\n")
    refute key.() == second
  end
  test "the step keyed on the whole source changes with any definition, so an edit that only breaks unreached code still compiles once" do
    program = fn unused -> "inl helper () = 1i32\ninl unused () = #{unused}\ninl spiral_kino_test () = helper ()\nspiral_kino_test ()\n" end
    context = fn step -> Memo.context([memo: true, memo_dir: Spiral.Kino.TestHelpers.tmp_dir!("whole")], [step]) end
    reached = fn unused -> step = %{program: program.(unused), real: ""}; Memo.key(context.(step), step, []) end
    whole = fn unused -> step = %{program: program.(unused), real: "", whole_source_key: true}; Memo.key(context.(step), step, []) end
    assert reached.("1i32") == reached.("(")
    refute whole.("1i32") == whole.("(")
  end
  test "inserting an unreached definition between reached ones in a package module keeps the key", %{package: package} do
    File.write!(Path.join(package, "listed.spi"), "inl a () = 1i32\ninl z () = a ()\n")
    step = %{program: "///- --package #{package}\n\ninl main () = z ()\n", real: ""}
    key = fn -> Memo.key(Memo.context([memo: true, memo_dir: Path.join(package, "memo")], [step]), step, []) end
    first = key.()
    File.write!(Path.join(package, "listed.spi"), "inl a () = 1i32\ninl inserted () = (\ninl z () = a ()\n")
    assert key.() == first
    File.write!(Path.join(package, "listed.spi"), "inl a () = 2i32\ninl inserted () = (\ninl z () = a ()\n")
    refute key.() == first
  end
end
