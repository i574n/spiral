defmodule Spiral.Cells.TargetsTestNameTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Targets

  test "a step's test name reaches the child environment as SPIRAL_CELLS_TEST" do
    assert Targets.with_test_name([{"PATH", "p"}], test_name: "golden_seed") == [{"PATH", "p"}, {"SPIRAL_CELLS_TEST", "golden_seed"}]
    assert Targets.with_test_name([{"SPIRAL_CELLS_TEST", "old"}], test_name: "new") == [{"SPIRAL_CELLS_TEST", "new"}]
  end

  test "a step without a test name leaves the environment alone" do
    assert Targets.with_test_name([{"PATH", "p"}], []) == [{"PATH", "p"}]
    assert Targets.with_test_name([{"PATH", "p"}], test_name: nil) == [{"PATH", "p"}]
    assert Targets.with_test_name([{"PATH", "p"}], test_name: "") == [{"PATH", "p"}]
  end
end
