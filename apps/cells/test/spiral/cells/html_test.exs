defmodule Spiral.Cells.HtmlTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Html

  test "code is colored by the compiler's semantic token classes and escaped" do
    tokenize = fn "inl x = 1 < 2" -> [{0, 0, 3, "keyword"}, {0, 4, 5, "variable"}, {0, 8, 9, "number"}, {0, 10, 11, "operator"}, {0, 12, 13, "number"}] end

    assert Html.highlight("inl x = 1 < 2", tokenize) ==
             "<span class=\"tok-keyword\">inl</span> <span class=\"tok-variable\">x</span> = <span class=\"tok-number\">1</span> <span class=\"tok-operator\">&lt;</span> <span class=\"tok-number\">2</span>"
  end

  test "token offsets are UTF-16 units like the compiler's, so non-ASCII text before a token keeps it aligned" do
    tokenize = fn _ -> [{0, 0, 3, "string"}, {0, 4, 5, "variable"}, {0, 6, 10, "string"}, {0, 11, 12, "variable"}] end
    assert Html.highlight("\"é\" x \"😀\" y", tokenize) ==
             "<span class=\"tok-string\">&quot;é&quot;</span> <span class=\"tok-variable\">x</span> <span class=\"tok-string\">&quot;😀&quot;</span> <span class=\"tok-variable\">y</span>"
  end

  test "lines without tokens stay plain and overlapping or out-of-range tokens are ignored" do
    tokenize = fn _ -> [{0, 0, 1, "keyword"}, {0, 0, 2, "variable"}, {1, 0, 99, "string"}] end
    assert Html.highlight("ab\ncd", tokenize) == "<span class=\"tok-keyword\">a</span>b\ncd"
  end

  test "markdown cells render headings, paragraphs, lists, code fences, inline code and links" do
    assert Html.markdown("# Title\n\nSome `code` and [a link](x.html).\n\n- one\n- two <b>\n\n```\nlet x = 1 < 2\n```") ==
             "<h1>Title</h1>\n<p>Some <code>code</code> and <a href=\"x.html\">a link</a>.</p>\n<ul>\n<li>one</li>\n<li>two &lt;b&gt;</li>\n</ul>\n<pre><code>let x = 1 &lt; 2\n</code></pre>\n"
  end

  test "only Spiral notebooks get the compiler's coloring" do
    assert Html.spiral_kernel?(%{"metadata" => %{"kernelspec" => %{"language" => "spiral"}}})
    assert Html.spiral_kernel?(%{"cells" => []})
    refute Html.spiral_kernel?(%{"metadata" => %{"kernelspec" => %{"language" => "pwsh"}}})
  end

  @tag :tmp_dir
  test "mix spiral.html writes the page beside a PowerShell notebook without coloring it", %{tmp_dir: dir} do
    ipynb = Path.join(dir, "setup.livemd.ipynb")
    notebook = %{"metadata" => %{"kernelspec" => %{"language" => "pwsh"}}, "cells" => [%{"cell_type" => "code", "source" => ["Get-Date"], "outputs" => []}]}
    File.write!(ipynb, JSON.encode!(notebook))
    ExUnit.CaptureIO.capture_io(fn -> Mix.Tasks.Spiral.Html.run([ipynb]) end)
    page = File.read!(Path.join(dir, "setup.livemd.html"))
    assert page =~ ~s(<pre class="code"><code>Get-Date</code></pre>)
  end

  test "a page has the mobile viewport, test badges and outputs" do
    ipynb = %{
      "cells" => [
        %{"cell_type" => "markdown", "source" => ["## Cell"]},
        %{"cell_type" => "code", "source" => ["1i32"], "outputs" => [%{"output_type" => "stream", "text" => ["1\n"]}], "metadata" => %{"spiral_test" => %{"name" => "one", "status" => "passed"}}}
      ]
    }

    page = Html.render(ipynb, fn _ -> [] end, "math.spi")
    assert page =~ ~s(<meta name="viewport" content="width=device-width, initial-scale=1">)
    assert page =~ "<title>math.spi</title>"
    assert page =~ "<h2>Cell</h2>"
    assert page =~ ~s(<span class="badge passed">test one: passed</span>)
    assert page =~ ~s(<pre class="output">1\n</pre>)
  end
end
