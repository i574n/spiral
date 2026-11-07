defmodule Spiral.Cells.TempSweepTest do
  use ExUnit.Case, async: true
  alias Spiral.Cells.TempSweep

  test "only run dirs older than the age limit are removed, with their contents" do
    root = Spiral.Cells.TestHelpers.tmp_dir!("temp_sweep")
    old = Path.join(root, "1-old")
    fresh = Path.join(root, "2-fresh")
    File.mkdir_p!(Path.join(old, "sub"))
    File.write!(Path.join([old, "sub", "main.spi"]), "x")
    File.mkdir_p!(fresh)
    now = System.os_time(:second)
    File.touch!(old, now - 2 * 86_400)
    assert TempSweep.sweep(root, 86_400, now) == [old]
    refute File.exists?(old)
    assert File.dir?(fresh)
  end

  test "files beside the run dirs are left alone" do
    root = Spiral.Cells.TestHelpers.tmp_dir!("temp_sweep_files")
    file = Path.join(root, "note.txt")
    File.write!(file, "keep")
    File.touch!(file, 0)
    assert TempSweep.sweep(root, 1, System.os_time(:second)) == []
    assert File.regular?(file)
  end

  test "a missing root sweeps nothing" do
    missing = Path.join(System.tmp_dir!(), "spiral-cells-no-root-#{System.unique_integer([:positive])}")
    assert TempSweep.sweep(missing, 1, 0) == []
  end
end
