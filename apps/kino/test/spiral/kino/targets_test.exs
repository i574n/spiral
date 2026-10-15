defmodule Spiral.Kino.TargetsTest do
  use ExUnit.Case, async: false

  alias Spiral.Kino.{ProcessError, Targets, Toolchain}

  defp deadline, do: System.monotonic_time(:millisecond) + 30_000

  defp run_target(output) do
    Targets.run(
      %{tool: :lua},
      "unused",
      [target: fn _ -> {:ok, %{exit_status: 0, output: output, duration_ms: 1}} end],
      30_000,
      deadline()
    )
  end

  test "python and cuda targets never print CuPy's missing CUDA_PATH warning" do
    assert {"PYTHONWARNINGS", "default,ignore:CUDA path could not be detected:UserWarning"} =
             [{"PYTHONWARNINGS", "default"}] |> Targets.without_cupy_cuda_path_warning() |> List.keyfind("PYTHONWARNINGS", 0)

    case Toolchain.python([]) do
      nil ->
        :ok

      python ->
        warn = "import warnings; warnings.warn('CUDA path could not be detected. Set CUDA_PATH environment variable if CuPy fails to load.'); print('ok')"
        {out, 0} = System.cmd(python, ["-c", warn], env: Targets.without_cupy_cuda_path_warning([]), stderr_to_stdout: true)
        assert String.trim(out) == "ok"
    end
  end

  test "gcc builds C with the compiler harness flags and links libm last" do
    assert Targets.c_args("C:/mingw/bin/gcc.exe", "main.c", "cell.exe", nil) ==
             ["-std=c11", "-O2", "-w", "-fwrapv", "-o", "cell.exe", "main.c", "-lm"]
  end

  test "Delphi cells build with dcc32 when present, else with fpc in Delphi mode like the compiler harness" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("delphi-compiler")
    dcc = Path.join(dir, "dcc32.exe")
    fpc = Path.join(dir, "fpc.exe")
    File.write!(fpc, "")
    assert {^fpc, "fpc", ["-O2", "-Mdelphi"]} = Targets.delphi_compiler(dcc: dcc, fpc: fpc)
    File.write!(dcc, "")
    assert {^dcc, "dcc32", []} = Targets.delphi_compiler(dcc: dcc, fpc: fpc)
  end

  test "a c-shim.h next to the notebook is force-included like the harness's own shim" do
    dir = Path.join(System.tmp_dir!(), "kino_c_shim_#{System.unique_integer([:positive])}")
    File.mkdir_p!(dir)
    shim = Path.join(dir, "c-shim.h")
    File.write!(shim, "#define SHIMMED 1\n")

    try do
      assert Targets.c_args("gcc", "main.c", "cell", dir) ==
               ["-std=c11", "-O2", "-w", "-fwrapv", "-include", shim, "-o", "cell", "main.c", "-lm"]
    after
      File.rm_rf(dir)
    end
  end

  test "cl builds C optimized with its own flag spelling" do
    assert Targets.c_args("C:/msvc/cl.exe", "main.c", "cell.exe", nil) == ["/nologo", "/O2", "/Fe:cell.exe", "main.c"]
  end

  test "command_result output is kept and a trace line is dropped" do
    inner = JSON.encode!(%{"code" => "return 1", "extension" => "lua", "output" => "printed"})
    outer = "12:44:21 spiral.main / { args = [] }\n" <> JSON.encode!(%{"command_result" => inner})

    assert {:ok, %{stdout: "printed"}} = run_target(outer)
  end

  test "an empty command_result output does not fall back to the generated code" do
    inner = JSON.encode!(%{"code" => "return 1", "extension" => "lua", "output" => ""})
    outer = JSON.encode!(%{"command_result" => inner})

    assert {:ok, %{stdout: ""}} = run_target(outer)
  end

  test "a top-level output field is the cell stdout" do
    text =
      JSON.encode!(%{
        "extension" => "rs",
        "code" => "fn main() {}",
        "code_path" => "main.rs",
        "output" => "hello"
      })

    assert {:ok, %{stdout: "hello"}} = run_target(text)
  end

  test "an F# cell runs from the notebook's directory (cwd and __SOURCE_DIRECTORY__)" do
    if is_binary(Toolchain.dotnet([])) do
      root = Path.join(System.tmp_dir!(), "spiral_kino_root_#{System.unique_integer([:positive])}")
      cell = Path.join(System.tmp_dir!(), "spiral_kino_cell_#{System.unique_integer([:positive])}")
      File.mkdir_p!(root)
      File.mkdir_p!(cell)
      path = Path.join(cell, "main.fsx")

      File.write!(
        path,
        "printfn \"%s|%s\" (System.IO.Path.GetFileName __SOURCE_DIRECTORY__) (System.IO.Path.GetFileName (System.IO.Directory.GetCurrentDirectory()))\n"
      )

      try do
        name = Path.basename(root)
        expected = "#{name}|#{name}"
        assert {:ok, %{stdout: ^expected}} = Targets.run(%{tool: :fsharp}, path, [root: root], 120_000, deadline())
      after
        File.rm_rf(root)
        File.rm_rf(cell)
      end
    end
  end

  test "plain builder text stays as stdout" do
    assert {:ok, %{stdout: "contract"}} = run_target("contract\n")
  end

  test "a trace stays when the json output is empty" do
    inner = JSON.encode!(%{"code" => "return 1", "extension" => "lua", "output" => ""})

    outer =
      "1" <>
        <<0x1B>> <>
        "[91mw" <>
        <<0x1B>> <>
        "[39m spiral.process_lua / note / kept\n" <>
        JSON.encode!(%{"command_result" => inner})

    assert {:ok, %{stdout: "1w spiral.process_lua / note / kept"}} = run_target(outer)
  end

  test "an empty spiral result with an error trace fails the cell" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("spiral-error")

    fake =
      cc!(dir, "fake", ~S"""
      #include <stdio.h>
      int main(void) {
        printf("1c spiral.process_rust / cargo error / edition2024\n");
        printf("{\"extension\":\"rs\",\"code\":\"\",\"output\":\"\"}\n");
        return 0;
      }
      """)

    lua = Path.join(dir, "main.lua")
    File.write!(lua, "return 1\n")

    assert {:error, %ProcessError{message: message}} =
             Targets.run(%{tool: :lua}, lua, [spiral: fake], 30_000, deadline())

    assert message =~ "edition2024"
    refute message =~ "extension"
  end

  test "a cpp executable that exits non-zero fails the cell; exit 0 passes it" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("cpp-cell")
    path = Path.join(dir, "main.cpp")
    File.write!(path, "int main() { return 7; }\n")
    _built = cc!(dir, "main.cpp.out", "int main(void) { return 7; }\n")
    fake = cc!(dir, "spiral-fake", "int main(void) { return 0; }\n")

    assert {:error, %ProcessError{exit_status: 7}} =
             Targets.run(%{tool: :cpp}, path, [spiral: fake], 30_000, deadline())

    _built = cc!(dir, "main.cpp.out", "int main(void) { return 0; }\n")
    assert {:ok, %{stdout: ""} = ran} = Targets.run(%{tool: :cpp}, path, [spiral: fake], 30_000, deadline())
    refute Map.has_key?(ran, :value)
  end

  test "a C cell whose assertion fails is a failure, not a value" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("c-cell")
    failing = Path.join(dir, "failing.c")

    File.write!(failing, """
    #include <stdio.h>
    int main(void) { printf("__assert_eq { actual = 7; expected = 8 }\\n"); return 1; }
    """)

    assert {:error, %ProcessError{exit_status: 1, message: message}} =
             Targets.run(%{tool: :c}, failing, [], 60_000, deadline())

    assert message =~ "actual = 7; expected = 8"

    passing = Path.join(dir, "passing.c")
    File.write!(passing, "#include <stdio.h>\nint main(void) { printf(\"ok\\n\"); return 0; }\n")
    assert {:ok, %{stdout: "ok"}} = Targets.run(%{tool: :c}, passing, [], 60_000, deadline())
  end

  test "zig runs its program; wgsl runs the shader: exit 0 passes, 3 (no adapter) or no runner is unsupported, others fail" do
    assert [%{tool: :zig}, %{tool: :wgsl}] = Spiral.Kino.Builders.commands("///> zig\n///> wgsl\nx")
    assert Spiral.Kino.Builders.backend(%{tool: :zig}) == "Zig"
    assert [%{tool: :lean}] = Spiral.Kino.Builders.commands("///> lean\nx")
    assert {Spiral.Kino.Builders.backend(%{tool: :lean}), Spiral.Kino.Builders.ext(%{tool: :lean})} == {"Lean", ".lean"}
    assert Spiral.Kino.Builders.backend(%{tool: :wgsl}) == "Wgsl"
    dir = Spiral.Kino.TestHelpers.tmp_dir!("zig-wgsl")
    missing = Path.join(dir, "no-tool.exe")

    assert {:error, %ProcessError{reason: :tool_missing}} =
             Targets.run(%{tool: :zig}, Path.join(dir, "main.zig"), [zig: missing], 30_000, deadline())

    runner =
      cc!(dir, "spiral-wgsl-stub", """
      #include <stdio.h>
      int main(int argc, char **argv) { FILE *f = fopen(argv[1], "r"); int c = fgetc(f); fclose(f); printf("ran\\n"); return c - '0'; }
      """)

    shader = fn status ->
      path = Path.join(dir, "shader#{status}.wgsl")
      File.write!(path, "#{status}")
      path
    end

    assert {:ok, %{stdout: "ran"}} = Targets.run(%{tool: :wgsl}, shader.(0), [wgsl_run: runner, naga: nil], 30_000, deadline())
    assert {:error, %ProcessError{exit_status: 1, reason: nil}} = Targets.run(%{tool: :wgsl}, shader.(1), [wgsl_run: runner, naga: nil], 30_000, deadline())
    assert {:error, %ProcessError{exit_status: 2, reason: nil}} = Targets.run(%{tool: :wgsl}, shader.(2), [wgsl_run: runner, naga: nil], 30_000, deadline())
    assert {:error, %ProcessError{exit_status: 3, reason: :tool_missing}} = Targets.run(%{tool: :wgsl}, shader.(3), [wgsl_run: runner, naga: nil], 30_000, deadline())
    assert {:error, %ProcessError{reason: :tool_missing}} = Targets.run(%{tool: :wgsl}, shader.(0), [wgsl_run: missing, naga: nil], 30_000, deadline())
  end
  test "an erlang gleam target is run by Kino in its own package with the CLI's dependencies" do
    [builder] = Spiral.Kino.Builders.commands("///> gleam -d gleam_community_maths=\\\">=2.0.0\\\"")
    assert {:gleam, "x/gleam/src/main.gleam", [%{name: "gleam_community_maths"}]} = Spiral.Kino.Builders.dispatch(builder, "x/gleam/src/main.gleam")
    manifest = Targets.gleam_manifest("x/gleam/src/main.gleam", builder.deps)
    assert manifest =~ ~s(name = "main"\ntarget = "erlang")
    assert manifest =~ ~s(gleam_stdlib = "0.57.0")
    assert manifest =~ ~s(gleam_community_maths = ">=2.0.0")
    [js] = Spiral.Kino.Builders.commands("///> gleam -t javascript")
    assert {:spiral, _} = Spiral.Kino.Builders.dispatch(js, "main.gleam")
  end
  test "gleam compile warnings are not program output" do
    output = """
    warning: Unused function argument
       ┌─ C:\\x\\gleam\\src\\main.gleam:88:17
       │
    88 │ pub fn closure0(capt: Nil) -> fn(Int) -> Us0 {
       │                 ^^^^ This argument is never used

    Hint: You can ignore it with an underscore: `_capt`.

    __assert_eq { expected = 2 }
    """

    assert Targets.strip_gleam_warnings(output) == "__assert_eq { expected = 2 }\n"
  end
  test "a spiral rust builder waits for the spiral rust lock" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("rust-lock")
    lock = Path.join(dir, "rust.lock")
    File.write!(lock, System.pid())
    missing = Path.join(dir, "no-spiral.exe")

    task =
      Task.async(fn ->
        Targets.run(
          %{tool: :rust, contract: nil, wasm: nil, deps: [], cleanup: nil},
          Path.join(dir, "main.rs"),
          [spiral: missing, rust_lock: lock],
          30_000,
          deadline()
        )
      end)

    assert Task.yield(task, 500) == nil
    File.rm!(lock)
    assert {:error, %ProcessError{message: message}} = Task.await(task, 10_000)
    assert message =~ "was not found"
  end

  defp cc!(dir, name, source) do
    cc = Toolchain.cc([])
    assert is_binary(cc)
    src = Path.join(dir, name <> ".c")
    exe = Path.join(dir, name <> if(match?({:win32, _}, :os.type()), do: ".exe", else: ""))
    File.write!(src, source)
    {output, status} = System.cmd(cc, ["-o", exe, src], stderr_to_stdout: true)
    assert status == 0, output
    exe
  end
end
