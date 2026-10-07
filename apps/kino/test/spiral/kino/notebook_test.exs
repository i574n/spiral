defmodule Spiral.Kino.NotebookTest do
  use ExUnit.Case, async: false

  alias Spiral.Kino.Notebook

  setup do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("notebook")
    %{dir: dir}
  end

  test "spiral cells accumulate, tests keep opens, and spi is written only when they pass", %{
    dir: dir
  } do
    path = Path.join(dir, "demo.dib")

    File.write!(path, """
    #!markdown

    # demo

    #!spiral

    ///- --test static

    open testing

    #!spiral

    inl value () = 1i32

    #!spiral

    ///- --test

    value ()
    """)

    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert :ok =
             Notebook.run(path,
               compile: compile(agent),
               rustc: &rustc_ok/1,
               execute: run_value("ok\n"),
               spi_path: Path.join(dir, "demo.spi")
             )

    sources = Agent.get(agent, & &1)
    assert length(sources) == 3

    test_cell =
      Enum.find(
        sources,
        &(String.contains?(&1, "open testing") and not String.contains?(&1, "inl value"))
      )

    def_cell =
      Enum.find(sources, fn source ->
        String.contains?(source, "inl value () = 1i32") and not calls?(source, "value ()")
      end)

    use_cell = Enum.find(sources, &calls?(&1, "value ()"))
    assert test_cell
    assert "inl value () = 1i32" in lines(def_cell)
    assert "open testing" in lines(def_cell)
    assert "inl value () = 1i32" in lines(use_cell)
    assert "open testing" in lines(use_cell)

    spi = File.read!(Path.join(dir, "demo.spi"))
    assert spi =~ "inl value () = 1i32"
    refute spi =~ "open testing"
    refute calls?(spi, "value ()")

    ipynb = (path <> ".ipynb") |> File.read!() |> JSON.decode!()
    assert ipynb["nbformat"] == 4
    assert Enum.count(ipynb["cells"], &(&1["cell_type"] == "code")) == 3

    assert Enum.all?(ipynb["cells"], fn cell ->
             cell["cell_type"] == "markdown" or
               (cell["outputs"] != [] and
                  is_integer(cell["metadata"]["duration_ms"]) and
                  cell["metadata"]["duration_ms"] >= 0)
           end)
  end

  test "a failing cell still writes the ipynb and does not write spi", %{dir: dir} do
    path = Path.join(dir, "bad.dib")

    File.write!(path, """
    #!spiral

    inl value () = 1i32

    #!spiral

    ///- --test

    bad_call ()
    """)

    spi = Path.join(dir, "bad.spi")

    assert {:error, message} =
             Notebook.run(path,
               compile: fn _ -> {:ok, "fn main() {}\n"} end,
               rustc: &rustc_ok/1,
               execute: fn %{exe_path: exe} ->
                 if File.read!(Path.join(Path.dirname(exe), "main.spi")) =~ "bad_call" do
                   {:ok, %{exit_status: 1, output: "assert failed\n", duration_ms: 1}}
                 else
                   {:ok, %{exit_status: 0, output: "ok\n", duration_ms: 1}}
                 end
               end,
               spi_path: spi
             )

    assert message =~ "exited 1"
    refute File.exists?(spi)
    ipynb = JSON.decode!(File.read!(path <> ".ipynb"))

    assert Enum.any?(
             ipynb["cells"],
             &Enum.any?(&1["outputs"] || [], fn output -> output["ename"] == "SpiralError" end)
           )
  end

  test "a livemd notebook is accepted", %{dir: dir} do
    path = Path.join(dir, "demo.livemd")

    File.write!(path, """
    # demo

    ```spiral
    inl value () = 1i32
    ```
    """)

    assert :ok =
             Notebook.run(path,
               compile: fn %{source: source} ->
                 assert source =~ "inl value () = 1i32"
                 {:ok, "fn main() {}\n"}
               end,
               rustc: &rustc_ok/1,
               execute: run_value("SPIRAL_KINO_VALUE:1\n"),
               spi_path: Path.join(dir, "from_livemd.spi")
             )

    assert File.read!(Path.join(dir, "from_livemd.spi")) =~ "inl value () = 1i32"
    assert File.exists?(path <> ".ipynb")
  end

  test "spi: false writes no .spi export", %{dir: dir} do
    path = Path.join(dir, "no_spi.livemd")
    File.write!(path, "# no spi\n\n```spiral\ninl value () = 1i32\n```\n")

    assert :ok =
             Notebook.run(path,
               compile: fn _ -> {:ok, "fn main() {}\n"} end,
               rustc: &rustc_ok/1,
               execute: run_value("SPIRAL_KINO_VALUE:1\n"),
               spi: false
             )

    assert File.exists?(path <> ".ipynb")
    refute File.exists?(Path.join(dir, "no_spi.spi"))
  end

  test "an fsharp notebook runs through the host callback", %{dir: dir} do
    path = Path.join(dir, "fs.dib")

    File.write!(path, """
    #!fsharp

    let value = 1

    #!fsharp

    value + 1
    """)

    spi = Path.join(dir, "fs.spi")
    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert :ok =
             Notebook.run(path,
               host: fn %{language: "fsharp", source: source} ->
                 Agent.update(agent, &(&1 ++ [source]))
                 {:ok, %{exit_status: 0, output: "ok\n", duration_ms: 1}}
               end,
               spi_path: spi
             )

    sources = Agent.get(agent, & &1)
    assert length(sources) == 2
    assert "let value = 1" in sources
    assert Enum.any?(sources, &(&1 =~ "let value = 1" and &1 =~ "value + 1"))
    assert File.exists?(spi)
    refute File.read!(spi) =~ "let value"
    assert File.exists?(path <> ".ipynb")
  end

  test "host cells share the job slots instead of all starting at once", %{dir: dir} do
    path = Path.join(dir, "many.dib")
    count = Spiral.Kino.Slots.limit() + 3
    File.write!(path, Enum.map_join(1..count, "\n", &"#!fsharp\n\nlet v#{&1} = #{&1}\n"))
    {:ok, gauge} = Agent.start_link(fn -> {0, 0} end)

    assert :ok =
             Notebook.run(path,
               host: fn _ ->
                 Agent.update(gauge, fn {now, peak} -> {now + 1, max(peak, now + 1)} end)
                 Process.sleep(150)
                 Agent.update(gauge, fn {now, peak} -> {now - 1, peak} end)
                 {:ok, %{exit_status: 0, output: "", duration_ms: 1}}
               end,
               spi_path: Path.join(dir, "many.spi")
             )

    {0, peak} = Agent.get(gauge, & &1)
    assert peak <= Spiral.Kino.Slots.limit()
  end

  test "rust contract flags reach the target from the cell that wrote them", %{dir: dir} do
    path = Path.join(dir, "flags.dib")

    File.write!(path, """
    #!spiral

    inl prior () = 1i32

    #!spiral

    ///> rust -cd near-token

    inl value () = 2i32
    """)

    {:ok, agent} = Agent.start_link(fn -> [] end)
    parent = self()

    assert :ok =
             Notebook.run(path,
               compile: fn %{source: source, backend: backend} ->
                 Agent.update(agent, &(&1 ++ [{backend, source}]))
                 {:ok, "fn main() {}\n"}
               end,
               rustc: &rustc_ok/1,
               execute: run_value("ok\n"),
               target: fn %{builder: builder, source: source} ->
                 assert builder.tool == :rust
                 assert builder.contract == ""
                 assert [%{name: "near-token", version: "*"}] = builder.deps
                 refute source =~ "///>"
                 send(parent, :targeted)
                 {:ok, %{exit_status: 0, output: "near\n", duration_ms: 1}}
               end,
               spi_path: Path.join(dir, "flags.spi")
             )

    assert_received :targeted
    sources = Agent.get(agent, & &1)
    assert length(sources) == 2

    assert Enum.all?(sources, fn {backend, source} ->
             backend == "Rust" and not (source =~ "///>")
           end)

    assert Enum.any?(sources, fn {_backend, source} ->
             source =~ "inl prior () = 1i32" and not (source =~ "inl value")
           end)

    assert Enum.any?(sources, fn {_backend, source} ->
             source =~ "inl prior () = 1i32" and source =~ "inl value () = 2i32"
           end)
  end

  test "a package missing beside the notebook is loaded from the polyglot root", %{dir: dir} do
    notebook = Path.join(dir, "contract")
    File.mkdir_p!(notebook)
    workspace = Path.join(dir, "polyglot")
    package = Path.join(workspace, "vendor/pkg")
    File.mkdir_p!(package)

    File.write!(
      Path.join(package, "package.spiproj"),
      "packageDir: .\npackages:\n    |core-\nmodules:\n    lib\n"
    )

    path = Path.join(notebook, "note.dib")

    File.write!(path, """
    #!spiral

    ///- --package vendor/pkg

    inl value () = 1i32
    """)

    assert :ok =
             Notebook.run(path,
               polyglot_root: workspace,
               compile: fn %{spi_path: spi} ->
                 proj = File.read!(Path.join(Path.dirname(spi), "package.spiproj"))
                 assert proj =~ "pkg-"
                 {:ok, "fn main() {}\n"}
               end,
               rustc: &rustc_ok/1,
               execute: run_value("ok\n"),
               spi_path: Path.join(dir, "note.spi")
             )
  end

  test "the spiral lib package is mounted once", %{dir: dir} do
    lib = Path.join(dir, "deps/polyglot/deps/spiral/lib/spiral")
    File.mkdir_p!(lib)
    File.write!(Path.join(lib, "package.spiproj"), "packages:\n    |core-\nmodules:\n")
    path = Path.join(dir, "note.dib")

    File.write!(path, """
    #!spiral

    ///- --package #{lib}

    inl value () = 1i32
    """)

    assert :ok =
             Notebook.run(path,
               compile: fn %{spi_path: spi} ->
                 proj = File.read!(Path.join(Path.dirname(spi), "package.spiproj"))
                 assert proj =~ "spiral-"
                 refute proj =~ "spiral-\n    spiral-"
                 {:ok, "fn main() {}\n"}
               end,
               rustc: &rustc_ok/1,
               execute: run_value("ok\n"),
               spi_path: Path.join(dir, "note.spi")
             )
  end

  test "a //> _ cell is not compiled and its body is still exported", %{dir: dir} do
    path = Path.join(dir, "skip.dib")

    File.write!(path, """
    #!spiral

    inl value () = 1i32

    #!spiral

    ///> _

    not_spiral_emitter
    """)

    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert :ok =
             Notebook.run(path,
               compile: compile(agent),
               rustc: &rustc_ok/1,
               execute: run_value("ok\n"),
               spi_path: Path.join(dir, "skip.spi")
             )

    sources = Agent.get(agent, & &1)
    assert length(sources) == 1
    assert Enum.at(sources, 0) =~ "inl value () = 1i32"
    refute Enum.at(sources, 0) =~ "not_spiral_emitter"

    spi = File.read!(Path.join(dir, "skip.spi"))
    # Like `spiral dib-export`, the export keeps the cell verbatim, directive line included.
    assert spi == "inl value () = 1i32\n\n///> _\n\nnot_spiral_emitter\n"
  end

  test "cells compile together", %{dir: dir} do
    path = Path.join(dir, "parallel.dib")

    File.write!(path, """
    #!spiral

    inl left () = 1i32

    #!spiral

    inl right () = 2i32
    """)

    {:ok, agent} = Agent.start_link(fn -> [] end)

    compile = fn _ctx ->
      started = System.monotonic_time(:millisecond)
      Process.sleep(200)
      Agent.update(agent, &(&1 ++ [{started, System.monotonic_time(:millisecond)}]))
      {:ok, "fn main() {}\n"}
    end

    assert :ok =
             Notebook.run(path,
               compile: compile,
               rustc: &rustc_ok/1,
               execute: run_value("ok\n"),
               spi_path: Path.join(dir, "parallel.spi")
             )

    [{left, left_done}, {right, right_done}] = Agent.get(agent, & &1) |> Enum.sort()
    assert left < right_done and right < left_done
  end

  # The old .dib kernel committed every cell but a non-static test: a `--test static` cell's definitions reach the cells
  # after it (physics' pedal_coast, parsing's FParsec bindings).
  test "a --test static cell's definitions reach later cells; a --test cell's do not", %{dir: dir} do
    path = Path.join(dir, "static.dib")

    File.write!(path, """
    #!spiral

    ///- --test static

    inl kept () = 1i32

    #!spiral

    ///- --test

    inl dropped () = 2i32
    kept ()

    #!spiral

    ///- --test

    kept () + 1i32
    """)

    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert :ok =
             Notebook.run(path,
               compile: compile(agent),
               rustc: &rustc_ok/1,
               execute: run_value("ok\n"),
               spi: false
             )

    last = agent |> Agent.get(& &1) |> Enum.find(&calls?(&1, "kept () + 1i32"))
    assert "inl kept () = 1i32" in lines(last)
    refute "inl dropped () = 2i32" in lines(last)
  end

  # `--real` cells are real-segment code (the old kernel's <module>_real.spir): they never go into a top-down program;
  # every later cell gets them as main_real.spir (`main_real*-` before main), and a real cell runs as that module with
  # its trailing expression as `spiral_kino_real`, called from main.
  test "--real cells become the main_real module", %{dir: dir} do
    path = Path.join(dir, "real.dib")

    File.write!(path, """
    #!spiral

    ///- --real

    inl twice_real (x : i32) : i32 = x + x

    #!spiral

    inl twice (x : i32) : i32 = real twice_real x

    #!spiral

    ///- --real --test

    inl y = twice_real 2i32
    y

    #!spiral

    ///- --test

    twice 21i32
    """)

    {:ok, agent} = Agent.start_link(fn -> [] end)

    compile = fn %{spi_path: spi, source: source} ->
      dir = Path.dirname(spi)
      real = Path.join(dir, "main_real.spir")
      proj = File.read!(Path.join(dir, "package.spiproj"))
      real_text = if File.regular?(real), do: File.read!(real)
      Agent.update(agent, &(&1 ++ [{source, real_text, proj}]))
      {:ok, "fn main() {}\n"}
    end

    assert :ok =
             Notebook.run(path,
               compile: compile,
               rustc: &rustc_ok/1,
               execute: run_value("ok\n"),
               spi: false
             )

    runs = Agent.get(agent, & &1)
    # the definitions-only real cell is an empty program here (no lib package header), so it compiles nothing
    assert length(runs) == 3

    for {source, real, proj} <- runs do
      refute source =~ "inl twice_real", "a real definition reached a top-down program"
      assert real =~ "inl twice_real (x : i32) : i32 = x + x"
      assert proj =~ ~r/^    main_real\*-\n    main$/m
    end

    {real_test, real, _} = Enum.find(runs, fn {source, _, _} -> source =~ "spiral_kino_real" end)
    assert real_test =~ "real spiral_kino_real ()"

    # the trailing value bindings and the expression: the real entry (the old kernel wrapped them as its main)
    assert real =~ "inl spiral_kino_real () =\n    inl y = twice_real 2i32\n    y"

    {_, real, _} = Enum.find(runs, fn {source, _, _} -> calls?(source, "twice 21i32") end)
    refute real =~ "inl y = twice_real 2i32", "a real test's code reached a later cell"
  end

  # leptos (206 cells) started every cell at once: all of them waited behind the one compiler with their 300 s budgets
  # running, and the whole notebook timed out. At most SPIRAL_KINO_CELL_CONCURRENCY (default 4) cells run at a time.
  test "at most four cells run at a time", %{dir: dir} do
    path = Path.join(dir, "many_cells.dib")
    File.write!(path, Enum.map_join(1..10, "\n", &"#!spiral\n\ninl f#{&1} () = #{&1}i32\n"))
    {:ok, agent} = Agent.start_link(fn -> {0, 0} end)

    compile = fn _ctx ->
      Agent.update(agent, fn {now, top} -> {now + 1, max(top, now + 1)} end)
      Process.sleep(100)
      Agent.update(agent, fn {now, top} -> {now - 1, top} end)
      {:ok, "fn main() {}\n"}
    end

    assert :ok =
             Notebook.run(path,
               compile: compile,
               rustc: &rustc_ok/1,
               execute: run_value("ok\n"),
               spi: false
             )

    {0, top} = Agent.get(agent, & &1)
    assert top in 2..4
  end

  defp lines(source), do: String.split(source, "\n")
  defp calls?(source, line), do: Enum.any?(lines(source), &(String.trim(&1) == line))

  defp compile(agent) do
    fn %{source: source} ->
      Agent.update(agent, &(&1 ++ [source]))
      {:ok, "fn main() {}\n"}
    end
  end

  test "html like the old route: LF endings and nbconvert's random cell ids renumbered 1..n" do
    html =
      ~s(<div id="cell-id=a1b2c3d4" class="x">\r\n<div id="cell-id=DEADBEEF">\r\n<p id="cell-id=zz">)

    assert Notebook.normalize_html(html) ==
             ~s(<div id="cell-id=1" class="x">\n<div id="cell-id=2">\n<p id="cell-id=zz">)
  end

  defp rustc_ok(_ctx), do: :ok

  defp run_value(output),
    do: fn _ctx -> {:ok, %{exit_status: 0, output: output, duration_ms: 1}} end
end
