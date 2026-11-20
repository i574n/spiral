defmodule Spiral.Cells.CellBudgetTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.NotebookCli

  test "the nearest manifest's dialect decides the run's cell-budget warnings, and only upstream opts out" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("cell_budget")
    nested = Path.join(dir, "sub")
    File.mkdir_p!(nested)
    path = Path.join(nested, "post.spi")
    File.write!(path, "inl tag = #trending\n")

    File.write!(Path.join(dir, "package.spiproj"), "dialect: upstream\npackages: |core-\nmodules:\n    post\n")
    assert NotebookCli.cell_budget_lines([path], []) == []
    assert [line] = NotebookCli.cell_budget_lines([path], cell_budget: true)
    assert line =~ ~r/^cell-budget .*post\.spi:1:11: hashtag: #trending/

    for manifest <- ["packages: |core-\nmodules:\n    post\n", "edition: 3\nmodules:\n    post\n", "dialect: i574n\nmodules:\n    post\n"] do
      File.write!(Path.join(dir, "package.spiproj"), manifest)
      assert [_] = NotebookCli.cell_budget_lines([path], [])
    end

    File.rm!(Path.join(dir, "package.spiproj"))
    File.write!(Path.join(dir, "spiral.toml"), "dialect = 'upstream'\n")
    assert NotebookCli.cell_budget_lines([path], []) == []
  end
end
