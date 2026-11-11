defmodule Spiral.Cells.PhaseRowsTest do
  use ExUnit.Case, async: true

  test "a phase row carries the test name, backend and the queue / mount / compile / build / run / fused times" do
    rust = Spiral.Cells.Domain.phase_row("///> rust\n:# tree_rust =\n    1i32", "queue=9\nmount=1\ncompile=2\nrustc=3\nrun=4\nslot_wait=7")
    zig = Spiral.Cells.Domain.phase_row("///> zig\n:# tree_zig =", "compile=2\ntarget=11")
    assert rust == "tree_rust\trust\t9\t1\t2\t3\t4\t0"
    assert zig == "tree_zig\tzig\t0\t0\t2\t0\t0\t11"
  end
end
