defmodule Spiral.Cells.NotebookTimeoutTest do
  use ExUnit.Case, async: true

  test "a timed-out test is counted apart from failures and does not count as executed" do
    counts = Spiral.Cells.Notebook.counts([%{"status" => "timed_out"}, %{"status" => "passed"}])
    assert counts["timed_out"] == 1
    assert counts["failed"] == 0
    assert counts["executed"] == 1
  end

  test "a run with only timed-out tests is VOID, never green" do
    results = [{"/n/a.spi", :ok, %{"timed_out" => 2}}, {"/n/b.spi", :ok, %{"timed_out" => 0}}]
    assert {{:void, message}, ["line"]} = Spiral.Cells.NotebookCli.void_result(results, ["line"])
    assert message =~ "/n/a.spi: VOID, 2 test(s) hit the cell timeout"
    refute message =~ "b.spi"
  end

  test "a VOID names each timed-out test and the budget it hit" do
    tests = [%{"name" => "slow", "status" => "timed_out", "timeout_ms" => 600_000}, %{"name" => "fine", "status" => "passed", "timeout_ms" => 600_000}]
    assert {{:void, message}, []} = Spiral.Cells.NotebookCli.void_result([{"/n/a.spi", :ok, %{"timed_out" => 1, "tests" => tests}}], [], fn -> "cpu 97%" end)
    assert message == "/n/a.spi: VOID, 1 test(s) hit the cell timeout (slow at 600000 ms; cpu 97%), so they are not a verdict; rerun with a wider --timeout"
  end

  test "counts keep memo hits and no-agree reasons" do
    counts = Spiral.Cells.Notebook.counts([%{"status" => "passed", "memo" => "hit"}, %{"status" => "failed", "no_agree" => "gleam floats"}, %{"status" => "prelude"}])
    assert {counts["discovered"], counts["preludes"], counts["memo_hits"], counts["no_agree_reasons"]} == {2, 1, 1, %{"gleam floats" => 1}}
  end

  test "a run with no timed-out tests stays ok" do
    assert {:ok, []} = Spiral.Cells.NotebookCli.void_result([{"/n/a.spi", :ok, %{"timed_out" => 0}}, {"/n/b.spi", :ok, nil}], [])
  end
end
