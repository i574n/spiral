defmodule Spiral.Cells.TablesTest do
  use ExUnit.Case, async: true

  test "a table created from a process that exits stays usable" do
    name = :spiral_cells_tables_test_owner
    task = Task.async(fn -> Spiral.Cells.Tables.ensure(name, [:set]) end)
    assert Task.await(task) == name
    refute Process.alive?(task.pid)
    assert :ets.insert(name, {:key, 1})
    assert :ets.lookup(name, :key) == [{:key, 1}]
  end

  test "concurrent callers share one table" do
    name = :spiral_cells_tables_test_race
    results = 1..16 |> Enum.map(fn _ -> Task.async(fn -> Spiral.Cells.Tables.ensure(name, [:set]) end) end) |> Enum.map(&Task.await/1)
    assert Enum.uniq(results) == [name]
    assert :ets.update_counter(name, :n, 1, {:n, 0}) == 1
  end
end