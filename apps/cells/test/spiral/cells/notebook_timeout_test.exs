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
    assert {{:error, message}, ["line"]} = Spiral.Cells.NotebookCli.void_result(results, ["line"])
    assert message =~ "/n/a.spi: VOID, 2 test(s) hit the cell timeout"
    refute message =~ "b.spi"
  end

  test "a run with no timed-out tests stays ok" do
    assert {:ok, []} = Spiral.Cells.NotebookCli.void_result([{"/n/a.spi", :ok, %{"timed_out" => 0}}, {"/n/b.spi", :ok, nil}], [])
  end
end
