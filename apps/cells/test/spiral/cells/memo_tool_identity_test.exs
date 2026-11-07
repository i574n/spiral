defmodule Spiral.Cells.MemoToolIdentityTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.Memo

  setup do
    dir = Path.join(System.tmp_dir!(), "memo-tool-identity-#{System.unique_integer([:positive])}")
    File.mkdir_p!(dir)
    previous = System.get_env("SPIRAL_ZIG")

    on_exit(fn ->
      if previous, do: System.put_env("SPIRAL_ZIG", previous), else: System.delete_env("SPIRAL_ZIG")
      File.rm_rf!(dir)
    end)

    %{dir: dir}
  end

  test "a cell's memo identity changes with the zig the environment selects", %{dir: dir} do
    old = Path.join(dir, "zig-old.exe")
    new = Path.join(dir, "zig-new.exe")
    File.write!(old, "old")
    File.write!(new, "newer")
    System.put_env("SPIRAL_ZIG", old)
    first = Memo.tool_identity([])
    System.put_env("SPIRAL_ZIG", new)
    refute Memo.tool_identity([]) == first
  end

  test "an explicit zig option wins over the environment, as Toolchain resolves it", %{dir: dir} do
    chosen = Path.join(dir, "zig-chosen.exe")
    File.write!(chosen, "chosen")
    System.put_env("SPIRAL_ZIG", Path.join(dir, "zig-env.exe"))
    assert Memo.tool_identity(zig: chosen) == Memo.tool_identity(zig: chosen)
    refute Memo.tool_identity(zig: chosen) == Memo.tool_identity([])
  end

  test "a scoop shim is keyed by the executable it points at", %{dir: dir} do
    shim = Path.join(dir, "zig.exe")
    File.write!(shim, "shim")
    first_target = Path.join(dir, "zig-0.17.exe")
    second_target = Path.join(dir, "zig-0.18-dev.exe")
    File.write!(first_target, "zig 0.17")
    File.write!(second_target, "zig 0.18-dev")
    System.put_env("SPIRAL_ZIG", shim)
    File.write!(Path.join(dir, "zig.shim"), "path = \"#{first_target}\"\n")
    first = Memo.tool_identity([])
    File.write!(Path.join(dir, "zig.shim"), "path = \"#{second_target}\"\n")
    refute Memo.tool_identity([]) == first
  end
end
