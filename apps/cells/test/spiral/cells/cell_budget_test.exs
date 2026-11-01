defmodule Spiral.Cells.CellBudgetTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.{NotebookCli, CellBudget}

  test "rewrites name what a renderer turns into hashtags, mentions, cashtags and t.co links, with line and column" do
    findings = CellBudget.rewrites("inl a = 1\ninl b = x.io + #tag @someone $abc\n")
    assert Enum.map(findings, &{&1.kind, &1.line, &1.column, &1.text}) == [
             {:hashtag, 2, 16, "#tag"},
             {:mention, 2, 21, "@someone"},
             {:cashtag, 2, 30, "$abc"}
           ]

    assert [%{kind: :autolink, text: "cell.ai"}] = CellBudget.rewrites("inl c = cell.ai")
    assert CellBudget.cell_weight("go cell.ai") == 3 + 23
    assert CellBudget.weight("가") == 2
  end

  test "edition 3 is read from the nearest package.spiproj and only then does a run print cell-budget warnings" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("cell_budget")
    nested = Path.join(dir, "sub")
    File.mkdir_p!(nested)
    path = Path.join(nested, "post.spi")
    File.write!(path, "inl tag = #trending\n")

    File.write!(Path.join(dir, "package.spiproj"), "packages: |core-\nmodules:\n    post\n")
    refute CellBudget.edition3?(path)
    assert NotebookCli.cell_budget_lines([path], []) == []
    assert [line] = NotebookCli.cell_budget_lines([path], cell_budget: true)
    assert line =~ ~r/^cell-budget .*post\.spi:1:11: hashtag: #trending/

    File.write!(Path.join(dir, "package.spiproj"), "edition: 3\npackages: |core-\nmodules:\n    post\n")
    assert CellBudget.edition3?(path)
    assert [_] = NotebookCli.cell_budget_lines([path], [])
  end

  test "the CI report lists findings and a summary and never fails" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("cell_budget_report")
    File.write!(Path.join(dir, "a.spi"), "inl a = #tag\n")
    File.write!(Path.join(dir, "b.spi"), "inl b = 1\n")
    Mix.shell(Mix.Shell.Process)

    try do
      Mix.Tasks.Spiral.CellBudget.run([dir])
      assert_received {:mix_shell, :info, [finding]}
      assert finding =~ "a.spi:1:9: hashtag: #tag"
      assert_received {:mix_shell, :info, ["cell-budget report: 1 finding(s) in 2 file(s) (hashtag 1)"]}
    after
      Mix.shell(Mix.Shell.IO)
    end
  end

  test "a top-level definition over the cell budget is over_budget, and --check fails only then" do
    long = "inl long = \"" <> String.duplicate("a", 280) <> "\"\n"
    source = "inl a = 1\n\ninl b =\n\n    2\n\n" <> long
    assert Enum.map(CellBudget.top_level_blocks(source), &elem(&1, 0)) == [1, 3, 7]
    assert [%{kind: :over_budget, line: 7, column: 1, text: "weight 293 > 273"}] = CellBudget.over_budget(source)
    assert CellBudget.over_budget("inl a = 1\n") == []

    dir = Spiral.Cells.TestHelpers.tmp_dir!("cell_budget_over_budget")
    File.write!(Path.join(dir, "short.spi"), "inl a = 1\n")
    File.mkdir_p!(Path.join(dir, "target"))
    linked = Path.join(dir, "linked")

    case File.ln_s(dir, linked) do
      :ok -> assert {:ok, %{type: :symlink}} = File.lstat(linked)
      {:error, _} -> :ok
    end
    File.write!(Path.join(dir, "target/long.spi"), long)
    Mix.shell(Mix.Shell.Process)

    try do
      Mix.Tasks.Spiral.CellBudget.run(["--check", dir])
      assert_received {:mix_shell, :info, ["cell-budget report: 0 finding(s) in 1 file(s)"]}
      File.write!(Path.join(dir, "long.spi"), long)
      assert_raise Mix.Error, ~r/1 definition\(s\) over the cell budget/, fn -> Mix.Tasks.Spiral.CellBudget.run(["--check", dir]) end
      Mix.Tasks.Spiral.CellBudget.run([dir])
    after
      Mix.shell(Mix.Shell.IO)
    end
  end

  test "the built-in profile reports a known top-level domain dot as an autolink" do
    assert [%{kind: :autolink}] = CellBudget.rewrites("inl c = cell.ai")
  end
end