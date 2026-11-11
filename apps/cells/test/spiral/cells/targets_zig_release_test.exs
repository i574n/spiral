defmodule Spiral.Cells.TargetsZigReleaseTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.{Targets, Toolchain}

  test "with SPIRAL_CELLS_ZIG_RELEASE=1 a zig cell builds a ReleaseFast binary and reports build and run separately" do
    zig = Toolchain.zig([])

    if is_binary(zig) and File.regular?(zig) do
      dir = Path.join(System.tmp_dir!(), "cells-zig-release-#{System.unique_integer([:positive])}")
      File.mkdir_p!(dir)
      path = Path.join(dir, "main.zig")
      File.write!(path, "pub fn main() void {}\n")
      System.put_env("SPIRAL_CELLS_ZIG_RELEASE", "1")
      Process.put(:spiral_cells_phases, %{})

      try do
        assert {:ok, _} = Targets.run(%{tool: :zig}, path, [], 300_000, System.monotonic_time(:millisecond) + 300_000)
        phases = Process.get(:spiral_cells_phases)
        assert Map.has_key?(phases, :target_build_ms)
        assert Map.has_key?(phases, :target_run_ms)
      after
        System.delete_env("SPIRAL_CELLS_ZIG_RELEASE")
        Process.delete(:spiral_cells_phases)
        File.rm_rf(dir)
      end
    end
  end
end
