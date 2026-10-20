defmodule Spiral.Cells.MemoTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.{Memo, SourceBlocks}

  defp bounds(program) do
    {:ok, bounds} = SourceBlocks.of_texts([], [program])
    bounds
  end

  setup do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("memo")
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
  test "a change to the compiler core re-keys even when the host DLL is untouched", %{package: package} do
    dll = Path.join(package, "SpiralCompiler.dll")
    core = Path.join(package, "SpiralCompilerCore.dll")
    File.write!(dll, "host")
    File.write!(core, "core one")
    step = %{program: "inl main () = 0i32\n", real: ""}
    key = fn -> Memo.key(Memo.context([memo: true, compiler_dll: dll], [step]), step, []) end
    before = key.()
    File.write!(core, "core two")
    refute key.() == before
  end
  test "a core change re-keys when the compiler path is spelled with backslashes (run_notebook.ps1 on Windows)", %{package: package} do
    dll = Path.join(package, "SpiralCompiler.dll")
    core = Path.join(package, "SpiralCompilerCore.dll")
    File.write!(dll, "host")
    File.write!(core, "core one")
    spelled = if match?({:win32, _}, :os.type()), do: String.replace(dll, "/", "\\"), else: dll
    step = %{program: "inl main () = 0i32\n", real: ""}
    key = fn -> Memo.key(Memo.context([memo: true, compiler_dll: spelled], [step]), step, []) end
    before = key.()
    File.write!(core, "core two")
    refute key.() == before
  end
  test "the compiler print is reused while the binaries' stamps hold, and recomputed when a same-size core changes", %{package: package} do
    dll = Path.join(package, "SpiralCompiler.dll")
    core = Path.join(package, "SpiralCompilerCore.dll")
    File.write!(dll, "host")
    File.write!(core, "core one")
    first = Memo.compiler_binaries_print(dll)
    assert Memo.compiler_binaries_print(dll) == first
    File.write!(core, "core two")
    refute Memo.compiler_binaries_print(dll) == first
  end

  test "the same compiler binaries key the same from another folder and with other timestamps", %{package: package} do
    step = %{program: "inl main () = 0i32\n", real: ""}
    key = fn dir -> Memo.key(Memo.context([memo: true, compiler_dll: Path.join(dir, "SpiralCompiler.dll")], [step]), step, []) end
    first = Path.join(package, "first")
    second = Path.join(package, "second")
    for dir <- [first, second] do
      File.mkdir_p!(dir)
      File.write!(Path.join(dir, "SpiralCompiler.dll"), "host")
      File.write!(Path.join(dir, "SpiralCompilerCore.dll"), "core")
    end
    File.touch!(Path.join(second, "SpiralCompilerCore.dll"), {{2026, 1, 2}, {3, 4, 5}})
    assert key.(first) == key.(second)
  end
  test "Cells's identity covers the modules that shape a result, not the editor or report ones" do
    modules = Memo.result_path_modules()
    assert Spiral.Cells.Targets in modules
    assert Spiral.Cells.Notebook in modules
    refute Spiral.Cells.SmartCell in modules
    refute Spiral.Cells.CompilerClient in modules
  end
  test "a target run is reused when the generated code is the same, whatever source edit produced it, and only successful runs are kept" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("code_memo")
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
    step = fn unused, used -> %{program: "open testing\ninl helper () = #{used}\ninl unused () = #{unused}\ninl spiral_cells_test () =\n    helper () |> _assert_eq 1i32\nspiral_cells_test ()\n0i32\n", real: ""} end
    key = fn s -> Memo.key(Memo.context([memo: true, memo_dir: Spiral.Cells.TestHelpers.tmp_dir!("reach")], [s]), s, []) end
    first = key.(step.("1i32", "1i32"))
    assert key.(step.("2i32", "1i32")) == first
    refute key.(step.("1i32", "3i32")) == first
    program = step.("2i32", "1i32").program
    assert Memo.reached_program(program, bounds(program)) =~ "inl helper"
    refute Memo.reached_program(program, bounds(program)) =~ "inl unused"
  end

  test "instances and comments do not hide a dependency: instances are always kept, // inside strings is not a comment" do
    program = "instance equable thing = fun a b => true\ninl url () = \"https://x//y\" |> fun _ => helper ()\ninl helper () = 1i32\ninl spiral_cells_test () = url ()\nspiral_cells_test ()\n"
    reached = Memo.reached_program(program, bounds(program))
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
  test "a test body bound to _ (no trailing assertion) is part of the key, so two such tests never share a result" do
    key = fn body ->
      step = %{program: "inl cols () = 1i32\ninl lines () = 2i32\ninl spiral_cells_test () =\n    #{body}\ninl _ = spiral_cells_test ()\n0i32\n", real: ""}
      Memo.key(Memo.context([memo: true, memo_dir: Spiral.Cells.TestHelpers.tmp_dir!("discard")], [step]), step, [])
    end

    refute key.("cols () |> console.write_line") == key.("lines () |> console.write_line")
    discarded = "inl f () = 1i32\ninl _ = f ()\n0i32\n"
    assert Memo.reached_program(discarded, bounds(discarded)) =~ "inl f () = 1i32"
  end
  test "the step keyed on the whole source changes with any definition, so an edit that only breaks unreached code still compiles once" do
    program = fn unused -> "inl helper () = 1i32\ninl unused () = #{unused}\ninl spiral_cells_test () = helper ()\nspiral_cells_test ()\n" end
    context = fn step -> Memo.context([memo: true, memo_dir: Spiral.Cells.TestHelpers.tmp_dir!("whole")], [step]) end
    reached = fn unused -> step = %{program: program.(unused), real: ""}; Memo.key(context.(step), step, []) end
    whole = fn unused -> step = %{program: program.(unused), real: "", whole_source_key: true}; Memo.key(context.(step), step, []) end
    assert reached.("1i32") == reached.("(")
    refute whole.("1i32") == whole.("(")
  end
  test "an unqualified name resolves in opened modules and modules the code opens; m.x only in module m", %{package: package} do
    File.write!(Path.join(package, "package.spiproj"), "packages:\n    |core-\nmodules:\n    listed-\n    sub/\n        inner\n    other\n    user\n")
    File.write!(Path.join(package, "other.spi"), "inl a () = 1i32\ninl slice () = 1i32\n")
    File.write!(Path.join(package, "user.spi"), "open other\ninl through () = slice ()\n")

    key_of = fn body ->
      step = %{program: "///- --package #{package}\n\n#{body}\n", real: ""}
      fn -> Memo.key(Memo.context([memo: true, memo_dir: Path.join(package, "memo")], [step]), step, []) end
    end

    edit_other = fn value -> File.write!(Path.join(package, "other.spi"), "inl a () = #{value}i32\ninl slice () = #{value}i32\n") end
    unqualified = key_of.("inl main () = a ()")
    opened = key_of.("open other\ninl main () = a ()")
    qualified = key_of.("inl main () = other.a ()")
    field = key_of.("inl main () = record.slice")
    through_module = key_of.("inl main () = user.through ()")
    before = Enum.map([unqualified, opened, qualified, field, through_module], & &1.())
    edit_other.(7)
    after_edit = Enum.map([unqualified, opened, qualified, field, through_module], & &1.())
    assert Enum.zip(before, after_edit) |> Enum.map(fn {b, a} -> b == a end) == [true, false, false, true, false]
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

  test "block boundaries come from the compiler: column-0 lines inside a triple-quoted string belong to its definition" do
    program = "inl text () =\n    \"\"\"\nnot a statement: inl fake () = 0i32\n\"\"\"\ninl spiral_cells_test () = 1i32\nspiral_cells_test ()\n"
    reached = Memo.reached_program(program, bounds(program))
    refute reached =~ "inl text"
    refute reached =~ "not a statement"
    assert reached =~ "inl spiral_cells_test"
  end

  test "directive and comment lines stay in the key while an unreached definition is dropped" do
    program = "///- --timeout 5000\n// note\ninl unused () = 2i32\ninl spiral_cells_test () = 1i32\nspiral_cells_test ()\n"
    reached = Memo.reached_program(program, bounds(program))
    assert reached =~ "///- --timeout 5000"
    refute reached =~ "inl unused"
  end

  test "without a compiler that lists source-blocks every key is the whole source" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("no_bounds")
    dll = Path.join(dir, "SpiralCompiler.dll")
    File.write!(dll, "not a compiler")
    step = fn unused -> %{program: "inl helper () = 1i32\ninl unused () = #{unused}\ninl spiral_cells_test () = helper ()\nspiral_cells_test ()\n", real: ""} end
    key = fn s -> Memo.key(Memo.context([memo: true, memo_dir: Path.join(dir, "memo"), compiler_dll: dll], [s]), s, []) end
    refute key.(step.("1i32")) == key.(step.("2i32"))
    assert Memo.reached_program("inl a () = 1i32\n", :unavailable) == "inl a () = 1i32\n"
  end

  test "source-block bounds are stored once and reused when the same compiler cannot answer later" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("bounds_cache")
    memo = Path.join(dir, "memo")
    step = %{program: "inl helper () = 1i32\ninl unused () = 2i32\ninl spiral_cells_test () = helper ()\nspiral_cells_test ()\n", real: ""}
    real_dll = Spiral.Cells.Toolchain.compiler_dll([])
    answered = Memo.context([memo: true, memo_dir: memo, compiler_dll: real_dll], [step])
    refute answered.bounds == :unavailable
    silent = Path.join(dir, "silent")
    File.mkdir_p!(silent)
    for name <- ["SpiralCompiler.dll", "SpiralCompilerCore.dll"], do: File.cp!(Path.join(Path.dirname(real_dll), name), Path.join(silent, name))
    refute SourceBlocks.available?(compiler_dll: Path.join(silent, "SpiralCompiler.dll"))
    reused = Memo.context([memo: true, memo_dir: memo, compiler_dll: Path.join(silent, "SpiralCompiler.dll")], [step])
    assert reused.bounds == answered.bounds
    assert Memo.key(reused, step, []) == Memo.key(answered, step, [])
  end
  test "bounds read once in this BEAM survive a cleared memo dir, so later notebooks skip the per-text memo reads" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("bounds_in_memory")
    memo = Path.join(dir, "memo")
    step = %{program: "inl kept () = 3i32\ninl dropped () = 4i32\ninl spiral_cells_test () = kept ()\nspiral_cells_test ()\n", real: ""}
    real_dll = Spiral.Cells.Toolchain.compiler_dll([])
    answered = Memo.context([memo: true, memo_dir: memo, compiler_dll: real_dll], [step])
    refute answered.bounds == :unavailable
    File.rm_rf!(memo)
    silent = Path.join(dir, "silent")
    File.mkdir_p!(silent)
    for name <- ["SpiralCompiler.dll", "SpiralCompilerCore.dll"], do: File.cp!(Path.join(Path.dirname(real_dll), name), Path.join(silent, name))
    reused = Memo.context([memo: true, memo_dir: memo, compiler_dll: Path.join(silent, "SpiralCompiler.dll")], [step])
    assert reused.bounds == answered.bounds
  end

  test "source-blocks rows group by input and skip headerless blocks" do
    rows = "1\t1\t2\t3\t4\tinl a () =\n1\t5\t0\t0\t6\t\n2\t1\t1\t1\t1\ttest x =\n"
    assert SourceBlocks.parse_rows(rows) == %{
             1 => [%{first: 1, header: 2, last_content: 3, last: 4, header_text: "inl a () ="}],
             2 => [%{first: 1, header: 1, last_content: 1, last: 1, header_text: "test x ="}]
           }
  end
end