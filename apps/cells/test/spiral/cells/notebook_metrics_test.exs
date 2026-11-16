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

  @tag :tmp_dir
  test "metrics rows list every target of every test-mode block, keyed by the file stem", %{tmp_dir: dir} do
    Notebook.write_metrics(dir, [{"C:/src/hunt_sim.spi", @report}])
    assert File.read!(Path.join(dir, "tests.tsv")) |> String.split("\n") |> Enum.drop(1) |> Enum.take(3) ==
             ["hunt_sim\tgolden_seed\trust\tpassed\t812\thit", "hunt_sim\tgolden_seed\tc\tfailed\t95\thit", "hunt_sim\tfresh\tzig\tpassed\t\t"]
  end

  @tag :tmp_dir
  test "write_metrics writes tests.tsv with the tibia column order", %{tmp_dir: dir} do
    Notebook.write_metrics(Path.join(dir, "ci-metrics"), [{"hunt_sim.spi", @report}])

    assert File.read!(Path.join([dir, "ci-metrics", "tests.tsv"])) ==
             "File\tTest\tTarget\tStatus\tMs\tMemo\nhunt_sim\tgolden_seed\trust\tpassed\t812\thit\nhunt_sim\tgolden_seed\tc\tfailed\t95\thit\nhunt_sim\tfresh\tzig\tpassed\t\t\n"
  end
end
