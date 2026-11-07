defmodule Spiral.Cells.NotebookMetricsTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Notebook

  @report %{
    "tests" => [
      %{"name" => "hunt_sim", "mode" => "static", "targets" => []},
      %{"name" => "golden_seed", "mode" => "test", "memo" => "hit", "targets" => [%{"target" => "rust", "status" => "passed", "ms" => 812}, %{"target" => "c", "status" => "failed", "ms" => 95}]},
      %{"name" => "fresh", "mode" => "test", "targets" => [%{"target" => "zig", "status" => "passed", "ms" => nil}]}
    ]
  }

  test "metrics rows list every target of every test-mode block, keyed by the file stem" do
    assert Notebook.metrics_rows([{"C:/src/hunt_sim.spi", @report}]) == [
             ["hunt_sim", "golden_seed", "rust", "passed", 812, "hit"],
             ["hunt_sim", "golden_seed", "c", "failed", 95, "hit"],
             ["hunt_sim", "fresh", "zig", "passed", nil, ""]
           ]
  end

  @tag :tmp_dir
  test "write_metrics writes tests.tsv with the tibia column order", %{tmp_dir: dir} do
    Notebook.write_metrics(Path.join(dir, "ci-metrics"), [{"hunt_sim.spi", @report}])

    assert File.read!(Path.join([dir, "ci-metrics", "tests.tsv"])) ==
             "File\tTest\tTarget\tStatus\tMs\tMemo\nhunt_sim\tgolden_seed\trust\tpassed\t812\thit\nhunt_sim\tgolden_seed\tc\tfailed\t95\thit\nhunt_sim\tfresh\tzig\tpassed\t\t\n"
  end
end
