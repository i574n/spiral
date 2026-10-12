defmodule Spiral.Kino.NotebookReportTest do
  use ExUnit.Case, async: false

  alias Spiral.Kino.{Document, Notebook, ProcessError}

  setup do
    %{dir: Spiral.Kino.TestHelpers.tmp_dir!("notebook_report")}
  end

  @spi """
  /// # demo
  inl one () = 1i32

  test one =
      one () |> _assert_eq 1i32

  test broken =
      one () |> _assert_eq 3i32

  test later ignore =
      never_compiled ()

  /// ## two
  inl two () = 2i32

  test two =
      two () |> _assert_eq 2i32
  """

  test "a .spi run reports each test block and a failing block fails the run", %{dir: dir} do
    path = Path.join(dir, "demo.spi")
    File.write!(path, @spi)
    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert {{:error, message}, report} =
             Notebook.run_report(path,
               compile: compile(agent),
               rustc: fn _ -> :ok end,
               execute: exit_when("_assert_eq 3i32", 1)
             )

    assert message =~ "exited 1"
    assert Map.take(report, ~w(discovered executed passed failed skipped unsupported filtered not_run)) ==
             %{"discovered" => 4, "executed" => 3, "passed" => 2, "failed" => 1, "skipped" => 1,
               "unsupported" => 0, "filtered" => 0, "not_run" => 0}

    assert Enum.map(report["tests"], &{&1["name"], &1["status"]}) ==
             [{"one", "passed"}, {"broken", "failed"}, {"later", "skipped"}, {"two", "passed"}]

    refute Enum.any?(Agent.get(agent, & &1), &(&1 =~ "never_compiled"))

    ipynb = JSON.decode!(File.read!(path <> ".ipynb"))
    assert ipynb["metadata"]["spiral_tests"]["failed"] == 1

    assert ipynb["cells"]
           |> Enum.flat_map(&List.wrap(&1["metadata"]["spiral_test"]))
           |> Enum.map(& &1["status"]) == ["passed", "failed", "skipped", "passed"]

    assert [file, total] = Notebook.summary_lines([{path, report}])
    assert "spiral-tests file " <> json = file
    assert %{"file" => ^path, "failed" => 1, "failed_tests" => ["broken"]} = JSON.decode!(json)
    assert "spiral-tests total " <> json = total
    assert %{"files" => 1, "discovered" => 4, "passed" => 2} = JSON.decode!(json)
  end

  test "a .spi compiles once per test block plus once for the whole file", %{dir: dir} do
    path = Path.join(dir, "demo.spi")
    File.write!(path, @spi)
    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert {:ok, %{"passed" => 3, "skipped" => 1}} =
             Notebook.run_report(path,
               compile: compile(agent),
               rustc: fn _ -> :ok end,
               execute: exit_when("never", 0)
             )

    sources = Agent.get(agent, & &1)
    assert length(sources) == 4
    whole = Enum.filter(sources, &(&1 =~ "inl two () = 2i32" and not (&1 =~ "_assert_eq")))
    assert [program] = whole
    assert program =~ "inl one () = 1i32"

    cells = Document.parse_spi(@spi, "")

    assert map_size(Notebook.evaluate(cells, root: dir, compile: compile(agent), rustc: fn _ -> :ok end, execute: exit_when("never", 0), plan: :tests).outputs) == 4
  end

  test "--test keeps the static test bodies above it (the lib's `open testing` prelude)", %{dir: dir} do
    path = Path.join(dir, "prelude.spi")

    File.write!(path, """
    /// # prelude
    test prelude static =
        open testing

    inl square x = x * x

    test square =
        square 3i32 |> _assert_eq 9i32

    test square_2 =
        square 4i32 |> _assert_eq 16i32
    """)

    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert {:ok, %{"passed" => 1, "filtered" => 2}} =
             Notebook.run_report(path,
               compile: compile(agent),
               rustc: fn _ -> :ok end,
               execute: exit_when("never", 0),
               tests: ["square_2"]
             )

    assert [source] = Agent.get(agent, & &1)
    assert source =~ "open testing"
    assert source =~ "inl square x = x * x"
    assert source =~ "square 4i32 |> _assert_eq 16i32"
    refute source =~ "square 3i32"
  end

  test "compile errors name main.spi, not the cell's temp dir, whatever the drive letter case" do
    assert {:error, %Spiral.Kino.SpiralError{message: message}} =
             Spiral.Kino.run("inl x () = y",
               compile: fn %{spi_path: spi} ->
                 shown = spi |> String.replace("\\", "/") |> String.upcase()
                 {:error, "FatalError: #{shown}:1:12: Unbound variable: y.\nfile:///#{shown}"}
               end
             )

    assert message == "FatalError: MAIN.SPI:1:12: Unbound variable: y.\nMAIN.SPI"
  end

  test "a .livemd run names its test cells after their headings", %{dir: dir} do
    path = Path.join(dir, "add.livemd")

    File.write!(path, """
    # add

    ```spiral
    inl add a b = a + b
    ```

    ## add one

    ```spiral
    ///- --test

    add 1i32 1i32
    ```
    """)

    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert {{:error, _}, report} =
             Notebook.run_report(path,
               compile: compile(agent),
               rustc: fn _ -> :ok end,
               execute: exit_when("add 1i32 1i32", 1),
               spi: false
             )

    assert [%{"name" => "add_one", "title" => "add one", "status" => "failed"}] = report["tests"]
  end

  test "an ignored cell is neither run nor a definition of later cells", %{dir: dir} do
    path = Path.join(dir, "ignored.dib")

    File.write!(path, """
    #!spiral

    ///- --ignore

    inl hidden () = 1i32

    #!spiral

    inl shown () = 2i32
    """)

    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert {:ok, %{"skipped" => 1, "discovered" => 1}} =
             Notebook.run_report(path,
               compile: compile(agent),
               rustc: fn _ -> :ok end,
               execute: exit_when("never", 0),
               spi: false
             )

    assert [source] = Agent.get(agent, & &1)
    assert source =~ "inl shown () = 2i32"
    refute source =~ "hidden"
  end

  test "a missing target tool is unsupported, other targets still run", %{dir: dir} do
    path = Path.join(dir, "targets.spi")

    File.write!(path, """
    inl one () = 1i32

    ///> lua
    ///> gleam
    test both =
        one ()

    ///> gleam
    test gleam_only =
        one ()
    """)

    {:ok, ran} = Agent.start_link(fn -> [] end)

    assert {:ok, report} =
             Notebook.run_report(path,
               compile: fn _ -> {:ok, "print(1)\n"} end,
               rustc: fn _ -> :ok end,
               execute: exit_when("never", 0),
               target: fn %{builder: builder} ->
                 Agent.update(ran, &(&1 ++ [builder.tool]))

                 if builder.tool == :gleam,
                   do: {:error, %ProcessError{message: "`gleam` was not found", reason: :tool_missing}},
                   else: {:ok, %{exit_status: 0, output: "1\n"}}
               end
             )

    assert Enum.map(report["tests"], &{&1["name"], &1["status"], &1["unavailable"]}) ==
             [{"both", "passed", ["gleam"]}, {"gleam_only", "unsupported", []}]

    assert %{"executed" => 1, "unsupported" => 1, "failed" => 0} = report
    assert :lua in Agent.get(ran, & &1)
  end

  test "--test runs only the named test with the definitions before it", %{dir: dir} do
    path = Path.join(dir, "demo.spi")
    File.write!(path, @spi)
    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert {:ok, report} =
             Notebook.run_report(path,
               compile: compile(agent),
               rustc: fn _ -> :ok end,
               execute: exit_when("never", 0),
               tests: ["two"]
             )

    assert [source] = Agent.get(agent, & &1)
    assert source =~ "inl one () = 1i32"
    assert source =~ "inl two () = 2i32"
    assert source =~ "two () |> _assert_eq 2i32"
    refute source =~ "_assert_eq 1i32"
    assert %{"discovered" => 4, "passed" => 1, "filtered" => 2, "skipped" => 1, "executed" => 1} = report

    assert {{:error, message}, _} =
             Notebook.run_report(path, compile: compile(agent), tests: ["nope"])

    assert message =~ "unknown test nope"
    assert message =~ "one, broken, later, two"
  end

  test "evaluate runs a document in memory and writes nothing", %{dir: dir} do
    doc = Document.parse_spi(@spi, "")
    {:ok, agent} = Agent.start_link(fn -> [] end)

    evaluation =
      Notebook.evaluate(doc,
        root: dir,
        compile: compile(agent),
        rustc: fn _ -> :ok end,
        execute: exit_when("_assert_eq 3i32", 1)
      )

    assert {:error, _} = evaluation.status
    assert %{"passed" => 2, "failed" => 1} = evaluation.report
    assert map_size(evaluation.outputs) == 5
    assert Enum.count(evaluation.verdicts, fn {_, v} -> v == :passed end) == 4
    assert File.ls!(dir) == []
  end

  defp compile(agent) do
    fn %{source: source} ->
      Agent.update(agent, &(&1 ++ [source]))
      {:ok, "fn main() {}\n"}
    end
  end

  defp exit_when(marker, status) do
    fn %{exe_path: exe} ->
      if File.read!(Path.join(Path.dirname(exe), "main.spi")) =~ marker,
        do: {:ok, %{exit_status: status, output: "assert\n", duration_ms: 1}},
        else: {:ok, %{exit_status: 0, output: "ok\n", duration_ms: 1}}
    end
  end
end
