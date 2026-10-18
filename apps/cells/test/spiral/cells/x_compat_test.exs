defmodule Spiral.Cells.XCompatTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.{NotebookCli, XCompat}

  test "rewrites name what X turns into hashtags, mentions, cashtags and t.co links, with line and column" do
    findings = XCompat.rewrites("inl a = 1\ninl b = x.io + #tag @someone $abc\n")
    assert Enum.map(findings, &{&1.kind, &1.line, &1.column, &1.text}) == [
             {:hashtag, 2, 16, "#tag"},
             {:mention, 2, 21, "@someone"},
             {:cashtag, 2, 30, "$abc"}
           ]

    assert [%{kind: :autolink, text: "cell.ai"}] = XCompat.rewrites("inl c = cell.ai")
    assert XCompat.x_weight("go cell.ai") == 3 + 23
    assert XCompat.weight("가") == 2
  end

  test "edition 3 is read from the nearest package.spiproj and only then does a run print x-compat warnings" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("x_compat")
    nested = Path.join(dir, "sub")
    File.mkdir_p!(nested)
    path = Path.join(nested, "post.spi")
    File.write!(path, "inl tag = #trending\n")

    File.write!(Path.join(dir, "package.spiproj"), "packages: |core-\nmodules:\n    post\n")
    refute XCompat.edition3?(path)
    assert NotebookCli.x_compat_lines([path], []) == []
    assert [line] = NotebookCli.x_compat_lines([path], x_compat: true)
    assert line =~ ~r/^x-compat .*post\.spi:1:11: hashtag: #trending/

    File.write!(Path.join(dir, "package.spiproj"), "edition: 3\npackages: |core-\nmodules:\n    post\n")
    assert XCompat.edition3?(path)
    assert [_] = NotebookCli.x_compat_lines([path], [])
  end

  test "the CI report lists findings and a summary and never fails" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("x_compat_report")
    File.write!(Path.join(dir, "a.spi"), "inl a = #tag\n")
    File.write!(Path.join(dir, "b.spi"), "inl b = 1\n")
    Mix.shell(Mix.Shell.Process)

    try do
      Mix.Tasks.Spiral.XCompat.run([dir])
      assert_received {:mix_shell, :info, [finding]}
      assert finding =~ "a.spi:1:9: hashtag: #tag"
      assert_received {:mix_shell, :info, ["x-compat report: 1 finding(s) in 2 file(s) (hashtag 1)"]}
    after
      Mix.shell(Mix.Shell.IO)
    end
  end
end
