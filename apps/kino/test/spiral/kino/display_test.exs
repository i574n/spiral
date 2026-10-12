defmodule Spiral.Kino.DisplayTest do
  use ExUnit.Case, async: false

  alias Spiral.Kino.{Display, Notebook, Result}

  @rust "fn spiral_main() -> i32 {\n    0\n}\nfn main() {\n    std::process::exit(spiral_main());\n}\n"
  @svg "<svg xmlns=\"http://www.w3.org/2000/svg\"><rect/></svg>"
  @plot ~S|("square", "x", "y", RefCell { value: [("square", RefCell { value: [-1.0, 0.0, 1e-7] }, RefCell { value: [1.0, 0.0, 1.5e2] })] })|

  defp fake_svg(json), do: {:ok, "<svg>" <> json <> "</svg>"}

  test "display blocks leave stdout and keep their mime and lines" do
    stdout =
      "before\nSPIRAL_KINO_DISPLAY_BEGIN\nimage/svg+xml\n<svg>\n</svg>\nSPIRAL_KINO_DISPLAY_END\nafter\n"

    assert {[%{mime: "image/svg+xml", data: "<svg>\n</svg>"}], "before\nafter\n"} =
             Display.extract(stdout)

    assert {[%{mime: "text/html", data: "<b>x</b>"}], "a"} =
             Display.extract(
               "a\r\nSPIRAL_KINO_DISPLAY_BEGIN\r\ntext/html\r\n<b>x</b>\r\nSPIRAL_KINO_DISPLAY_END"
             )

    assert {[], "plain\r\ntext"} = Display.extract("plain\r\ntext")

    assert {[], "x\nSPIRAL_KINO_DISPLAY_BEGIN\ntext/html\nhalf"} =
             Display.extract("x\nSPIRAL_KINO_DISPLAY_BEGIN\ntext/html\nhalf")
  end

  test "Rust Debug values parse into terms" do
    assert {:ok, {:tuple, ["a\"b\n", 1, -2.5, [1.0e-7, 150.0]]}} =
             Display.parse_debug(~S|("a\"b\n", 1, -2.5, [1e-7, 1.5e2])|)

    assert {:ok, [{:tuple, ["é"]}]} = Display.parse_debug(~S|RefCell { value: [("\u{e9}",)] }|)
    assert {:ok, {:variant, "Some", [3]}} = Display.parse_debug("Some(3)")
    assert {:ok, [:nan, :infinity, :neg_infinity]} = Display.parse_debug("[NaN, inf, -inf]")
    assert :error = Display.parse_debug("(1, 2")
    assert :error = Display.parse_debug("[1] trailing")
  end

  test "a line plot value becomes an svg display; other values stay values" do
    assert {nil, [%{mime: "image/svg+xml", data: svg}]} =
             Display.from_value(@plot, render_plot: &fake_svg/1)

    assert svg ==
             ~S|<svg>["square","x","y",[["square",[-1.0,0.0,1.0e-7],[1.0,0.0,150.0]]]]</svg>|

    assert {nil, [_, _]} = Display.from_value("[#{@plot}, #{@plot}]", render_plot: &fake_svg/1)
    assert {"(1, 2)", []} = Display.from_value("(1, 2)", render_plot: &fake_svg/1)
    assert {"[]", []} = Display.from_value("[]", render_plot: &fake_svg/1)

    nan_plot = ~S|("c", "x", "y", [("s", [0.0], [NaN])])|
    assert {^nan_plot, []} = Display.from_value(nan_plot, render_plot: &fake_svg/1)

    assert {@plot, []} =
             Display.from_value(@plot, render_plot: fn _ -> {:error, "no plot tool"} end)

    assert {nil, []} = Display.from_value(nil, [])
  end

  test "a host Rust cell's plot value and display blocks reach the result" do
    output =
      "SPIRAL_KINO_DISPLAY_BEGIN\nimage/svg+xml\n#{@svg}\nSPIRAL_KINO_DISPLAY_END\nline\nSPIRAL_KINO_VALUE:#{@plot}\n"

    assert {:ok, %Result{value: nil, stdout: "line", displays: displays}} =
             Spiral.Kino.run("1i32",
               compile: fn _ -> {:ok, @rust} end,
               rustc: fn _ -> :ok end,
               execute: fn _ -> {:ok, %{exit_status: 0, output: output, duration_ms: 1}} end,
               render_plot: &fake_svg/1
             )

    assert [%{mime: "image/svg+xml", data: @svg}, %{mime: "image/svg+xml", data: "<svg>[" <> _}] =
             displays
  end

  test "displays render as Kino outputs and as display_data in the ipynb" do
    assert %Kino.Image{mime_type: "image/svg+xml"} =
             Spiral.Kino.display_kino(%{mime: "image/svg+xml", data: @svg})

    assert %Kino.JS{module: Kino.HTML} =
             Spiral.Kino.display_kino(%{mime: "text/html", data: "<b>x</b>"})

    assert %{"output_type" => "display_data", "data" => %{"image/svg+xml" => [_ | _]}} =
             Notebook.display_output(%{mime: "image/svg+xml", data: "<svg>\n</svg>"})
  end

  test "a notebook cell's display lands in the ipynb" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("display")
    path = Path.join(dir, "plots.dib")

    File.write!(path, """
    #!spiral

    ///- --test

    1i32
    """)

    output = "SPIRAL_KINO_DISPLAY_BEGIN\nimage/svg+xml\n#{@svg}\nSPIRAL_KINO_DISPLAY_END\n"

    assert :ok =
             Notebook.run(path,
               compile: fn _ -> {:ok, @rust} end,
               rustc: fn _ -> :ok end,
               execute: fn _ -> {:ok, %{exit_status: 0, output: output, duration_ms: 1}} end,
               spi_path: Path.join(dir, "plots.spi"),
               html: false
             )

    ipynb = (path <> ".ipynb") |> File.read!() |> JSON.decode!()
    [cell] = Enum.filter(ipynb["cells"], &(&1["cell_type"] == "code"))

    assert [%{"output_type" => "display_data", "data" => %{"image/svg+xml" => lines}}] =
             Enum.filter(cell["outputs"], &(&1["output_type"] == "display_data"))

    assert Enum.join(lines) == @svg
  end
end
