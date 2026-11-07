defmodule Spiral.Cells.NotebookLivemdTargetTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.NotebookCli

  test "--livemd writes the Livebook copy beside the source, or into --output-dir" do
    assert NotebookCli.livemd_target("lib/math.spi", livemd: true) == "lib/math.spi.livemd"
    assert NotebookCli.livemd_target("lib/math.spi", livemd: true, output_dir: "out") == Path.join("out", "math.spi.livemd")
    assert NotebookCli.livemd_target("lib/math.spi", livemd: true, output_path: "target/notebooks/math.spi.ipynb") == "target/notebooks/math.spi.livemd"
  end

  test "without --livemd no Livebook copy is written" do
    assert NotebookCli.livemd_target("lib/math.spi", []) == nil
    assert NotebookCli.livemd_target("lib/math.spi", output_dir: "out") == nil
  end
end
