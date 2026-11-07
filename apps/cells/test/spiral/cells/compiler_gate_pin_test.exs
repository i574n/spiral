defmodule Spiral.Cells.CompilerGatePinTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.CompilerDaemon

  defp build(dir, text) do
    build = Path.join(dir, "net11.0")
    File.mkdir_p!(build)
    dll = Path.join(build, "SpiralCompiler.dll")
    File.write!(dll, text)
    File.write!(Path.join(build, "SpiralCompilerCore.dll"), "core " <> text)
    File.write!(Path.join(build, "SpiralCompiler.deps.json"), "{}")
    dll
  end

  defp rebuild(dll, text) do
    {:ok, %{mtime: mtime}} = File.stat(dll, time: :posix)
    File.write!(dll, text)
    File.write!(Path.join(Path.dirname(dll), "SpiralCompilerCore.dll"), "core " <> text)
    File.touch!(dll, mtime + 5)
    File.touch!(Path.join(Path.dirname(dll), "SpiralCompilerCore.dll"), mtime + 5)
  end

  test "a gate keeps its pinned compiler when the installed DLL changes mid-session, and an ungated request picks up the new one" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("gate-pin")
    dll = build(dir, "v1")
    root = Path.join(dir, "pins")
    state = %{toolchain: [compiler_dll: dll]}

    pin = CompilerDaemon.gate_pin(dll, root)
    refute pin == dll
    assert File.read!(pin) == "v1"
    first = CompilerDaemon.dll_stamp(pin)
    assert CompilerDaemon.compiler_source(state, %{pin: pin}) == pin

    rebuild(dll, "v2 installed mid-gate")

    assert CompilerDaemon.compiler_source(state, %{pin: pin}) == pin
    assert CompilerDaemon.dll_stamp(pin) == first
    assert File.read!(pin) == "v1"
    assert CompilerDaemon.compiler_current?(%{dll_stamp: first}, CompilerDaemon.dll_stamp(pin))

    assert CompilerDaemon.compiler_source(state, %{}) == dll
    assert CompilerDaemon.compiler_source(state, %{pin: nil}) == dll
    refute CompilerDaemon.compiler_current?(%{dll_stamp: first}, CompilerDaemon.dll_stamp(dll))
  end

  test "a pin is reused by later gates, a new install gets a new pin, and the old pin stays until it is a day unused" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("gate-pin-prune")
    dll = build(dir, "v1")
    root = Path.join(dir, "pins")
    now = System.os_time(:second)

    first = CompilerDaemon.gate_pin(dll, root, now)
    assert CompilerDaemon.gate_pin(dll, root, now) == first

    rebuild(dll, "v2")
    second = CompilerDaemon.gate_pin(dll, root, now)
    refute second == first
    assert File.read!(second) == "v2"
    assert File.exists?(first)

    rebuild(dll, "v3")
    third = CompilerDaemon.gate_pin(dll, root, now + 2 * 86_400)
    assert File.read!(third) == "v3"
    refute File.exists?(first)
    refute File.exists?(second)
  end

  test "a pin that no longer exists falls back to the installed compiler, and a missing DLL gives no pin" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("gate-pin-missing")
    dll = build(dir, "v1")
    state = %{toolchain: [compiler_dll: dll]}
    assert CompilerDaemon.compiler_source(state, %{pin: Path.join(dir, "gone/SpiralCompiler.dll")}) == dll
    assert CompilerDaemon.gate_pin(Path.join(dir, "missing.dll"), Path.join(dir, "pins")) == nil
  end

  test "the notebook report names the pinned compiler of a gate, and an ungated report has no compiler field" do
    pin = "C:/tmp/spiral-cells-gate-pins/1793860000-12345/SpiralCompiler.dll"
    report = Spiral.Cells.Notebook.with_compiler_pin(%{"tests" => []}, pin)
    assert report["compiler"] == %{"pin" => pin, "stamp" => "1793860000-12345"}
    refute Map.has_key?(Spiral.Cells.Notebook.with_compiler_pin(%{"tests" => []}, nil), "compiler")
  end

  test "a process-mode gate passes no pin, since it compiles with its own process" do
    previous = System.get_env("SPIRAL_CELLS_COMPILER")
    System.put_env("SPIRAL_CELLS_COMPILER", "process")

    try do
      assert Mix.Tasks.Spiral.Notebook.pin_args() == []
    after
      if previous, do: System.put_env("SPIRAL_CELLS_COMPILER", previous), else: System.delete_env("SPIRAL_CELLS_COMPILER")
    end
  end
end
