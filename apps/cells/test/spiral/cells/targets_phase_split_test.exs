defmodule Spiral.Cells.TargetsPhaseSplitTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.{Targets, Toolchain}

  test "a C cell reports its native build and its run as separate phases" do
    cc = Toolchain.cc([])

    if is_binary(cc) and File.regular?(cc) do
      dir = Path.join(System.tmp_dir!(), "cells-phase-split-#{System.unique_integer([:positive])}")
      File.mkdir_p!(dir)
      path = Path.join(dir, "main.c")
      File.write!(path, "int main(void) { return 0; }\n")
      Process.put(:spiral_cells_phases, %{})

      try do
        assert {:ok, _} = Targets.run(%{tool: :c}, path, [], 120_000, System.monotonic_time(:millisecond) + 120_000)
        phases = Process.get(:spiral_cells_phases)
        assert Map.has_key?(phases, :target_build_ms)
        assert Map.has_key?(phases, :target_run_ms)
      after
        Process.delete(:spiral_cells_phases)
        File.rm_rf(dir)
      end
    end
  end
end
