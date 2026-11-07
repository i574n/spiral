defmodule Spiral.Cells.RustupProxyTest do
  use ExUnit.Case, async: true

  @flags ["-C", "opt-level=2", "-A", "warnings", "--edition", "2024", "-o", "main.exe", "main.rs"]

  test "a rustc inside a rustup toolchain directory runs as itself, with no toolchain argument" do
    direct = "C:/Users/x/scoop/persist/rustup/.rustup/toolchains/nightly-2026-10-18-x86_64-pc-windows-msvc/bin/rustc.exe"
    assert Spiral.Cells.rustc_args(direct, "main.rs", "main.exe") == @flags
  end

  test "a rustc with rustup beside it is rustup's proxy and gets the pinned toolchain" do
    dir = Path.join(System.tmp_dir!(), "rustup-beside-#{System.unique_integer([:positive])}")
    File.mkdir_p!(dir)
    on_exit(fn -> File.rm_rf!(dir) end)
    File.write!(Path.join(dir, "rustup.exe"), "")
    File.write!(Path.join(dir, "rustc.exe"), "")
    assert ["+" <> _ | rest] = Spiral.Cells.rustc_args(Path.join(dir, "rustc.exe"), "main.rs", "main.exe")
    assert rest == @flags
  end
end
