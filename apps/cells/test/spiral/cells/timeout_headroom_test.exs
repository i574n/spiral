defmodule Spiral.Cells.TimeoutHeadroomTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.Notebook

  defp report(slowest, budget) do
    row = %{
      "index" => 0,
      "name" => "slow",
      "mode" => "test",
      "realm" => "spi",
      "status" => "passed",
      "targets" => [%{"target" => "rust", "status" => "passed", "ms" => slowest}],
      "timeout_ms" => budget,
      "slowest_ms" => slowest
    }

    Notebook.counts([row]) |> Map.put("tests", [row])
  end

  test "a file line reports its slowest cell against that cell's budget" do
    assert ["spiral-tests file " <> json, _total] = Notebook.summary_lines([{"fast.spi", report(30_000, 300_000)}])
    file = JSON.decode!(json)
    assert file["slowest_ms"] == 30_000
    assert file["timeout_ms"] == 300_000
    assert file["headroom"] == 0.1
  end

  test "a file past the warning threshold gets one headroom line" do
    previous = System.get_env("SPIRAL_CELLS_HEADROOM_WARN")
    on_exit(fn -> if previous, do: System.put_env("SPIRAL_CELLS_HEADROOM_WARN", previous), else: System.delete_env("SPIRAL_CELLS_HEADROOM_WARN") end)
    System.delete_env("SPIRAL_CELLS_HEADROOM_WARN")
    assert [_file, "spiral-tests headroom " <> json, _total] = Notebook.summary_lines([{"slow.spi", report(240_000, 300_000)}])
    assert JSON.decode!(json)["headroom"] == 0.8
  end
end
