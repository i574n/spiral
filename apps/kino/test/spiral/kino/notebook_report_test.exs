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

    assert Enum.map(report["tests"], &Enum.map(&1["targets"], fn row -> {row["target"], row["status"]} end)) ==
             [[{"rust", "passed"}], [{"rust", "failed"}], [], [{"rust", "passed"}]]

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

  test "passing steps are recalled on an unchanged re-run; an edit re-runs only what it changed", %{dir: dir} do
    path = Path.join(dir, "memo.spi")
    File.write!(path, @spi)
    {:ok, agent} = Agent.start_link(fn -> [] end)

    run = fn ->
      Agent.update(agent, fn _ -> [] end)

      {status, report} =
        Notebook.run_report(path,
          compile: compile(agent),
          rustc: fn _ -> :ok end,
          execute: exit_when("_assert_eq 3i32", 1),
          memo: true,
          memo_dir: Path.join(dir, "memo")
        )

      ipynb = JSON.decode!(File.read!(path <> ".ipynb"))
      outputs = Enum.map(ipynb["cells"], &(&1["outputs"] || []))
      {status, report, outputs, length(Agent.get(agent, & &1))}
    end

    {{:error, _}, first, outputs, 4} = run.()
    assert first["memo_hits"] == 0
    assert Enum.map(first["tests"], &{&1["name"], &1["memo"]}) == [{"one", "miss"}, {"broken", "miss"}, {"later", nil}, {"two", "miss"}]

    {{:error, _}, second, ^outputs, 1} = run.()
    assert second["memo_hits"] == 2
    assert Enum.map(second["tests"], &{&1["name"], &1["status"], &1["memo"]}) ==
             [{"one", "passed", "hit"}, {"broken", "failed", "miss"}, {"later", "skipped", nil}, {"two", "passed", "hit"}]

    File.write!(path, String.replace(@spi, "two () |> _assert_eq 2i32", "two () + 0i32 |> _assert_eq 2i32"))
    {{:error, _}, third, _, 2} = run.()
    assert Enum.map(third["tests"], &{&1["name"], &1["memo"]}) == [{"one", "hit"}, {"broken", "miss"}, {"later", nil}, {"two", "miss"}]
  end

  test "--output-dir gives each --path its own ipynb; --output-path still wins" do
    alias Spiral.Kino.NotebookCli, as: NotebookTask
    assert NotebookTask.output_path("C:/x/geometry.spi", output_dir: "C:/out") == Path.join("C:/out", "geometry.spi.ipynb")
    assert NotebookTask.output_path("C:/x/a.spi", output_dir: "C:/out", output_path: "C:/o.ipynb") == "C:/o.ipynb"
    assert NotebookTask.output_path("C:/x/a.spi", []) == nil
  end
  test "with several --path, --test names are matched per file and fail only when no file has them" do
    alias Spiral.Kino.NotebookCli, as: NotebookTask
    names = fn
      "a.spi" -> ["one", "two"]
      "b.spi" -> ["three"]
    end

    assert NotebookTask.tests_by_path(["a.spi", "b.spi"], ["two", "three"], names) ==
             {:ok, %{"a.spi" => ["two"], "b.spi" => ["three"]}}

    assert NotebookTask.tests_by_path(["a.spi", "b.spi"], ["one"], names) == {:ok, %{"a.spi" => ["one"], "b.spi" => []}}
    assert {:error, message} = NotebookTask.tests_by_path(["a.spi", "b.spi"], ["one", "nope"], names)
    assert message =~ "unknown test nope"
    assert NotebookTask.tests_by_path(["a.spi"], ["nope"], names) == {:ok, %{"a.spi" => ["nope"]}}
  end
  test "a `fails` test passes only when the compile fails with its code and message", %{dir: dir} do
    spi = """
    inl one () = 1i32

    test rejects_mixed fails EJP0040 "Unification failure" =
        one () + 1f64

    test rejects_any fails "Unification failure" =
        one () + 2f64

    test wrong_message fails EJP0040 "Unbound variable" =
        one () + 3f64

    test compiles_anyway fails EJP0040 "Unification failure" =
        one ()
    """

    assert Document.to_spi_tested(Document.parse_spi(spi, "")) == spi
    path = Path.join(dir, "fails.spi")
    File.write!(path, spi)

    compile = fn %{source: source} ->
      if source =~ "f64",
        do: {:error, "EJP0040 main.spi:3:5: Unification failure. Got: f64 Expected: i32"},
        else: {:ok, "fn main() {}\n"}
    end

    {_, report} = Notebook.run_report(path, compile: compile, rustc: fn _ -> :ok end, execute: exit_when("never", 0))

    assert Enum.map(report["tests"], &{&1["name"], &1["mode"], &1["status"]}) == [
             {"rejects_mixed", "fails", "passed"},
             {"rejects_any", "fails", "passed"},
             {"wrong_message", "fails", "failed"},
             {"compiles_anyway", "fails", "failed"}
           ]

    codeless = fn %{source: source} ->
      if source =~ "f64", do: {:error, "main.spi:3:5: Unification failure."}, else: {:ok, "fn main() {}\n"}
    end

    {_, report} = Notebook.run_report(path, compile: codeless, rustc: fn _ -> :ok end, execute: exit_when("never", 0), tests: ["rejects_mixed", "rejects_any"])
    assert [%{"status" => "failed", "message" => message}, %{"status" => "passed"}] = Enum.filter(report["tests"], &(&1["status"] != "filtered"))
    assert message =~ "carries no error code"
  end
  test "every target of a test must agree with the first one unless the test says no_agree", %{dir: dir} do
    spi = """
    inl one () = 1i32

    ///> lua
    ///> gleam
    test same =
        one ()

    ///> lua
    ///> gleam
    test differ =
        one () + 0i32

    ///> lua
    ///> gleam
    test differ_allowed no_agree =
        one () + 0i32
    """

    assert Document.to_spi_tested(Document.parse_spi(spi, "")) == spi
    path = Path.join(dir, "agree.spi")
    File.write!(path, spi)

    target = fn %{builder: builder, source: source} ->
      printed = if source =~ "differ" and builder.tool == :gleam, do: "1.0\n", else: "1\n"
      {:ok, %{exit_status: 0, output: printed}}
    end

    compile = fn %{source: source} -> {:ok, if(source =~ "+ 0i32", do: "differ\n", else: "same\n")} end
    {_, report} = Notebook.run_report(path, compile: compile, rustc: fn _ -> :ok end, execute: exit_when("never", 0), target: target)

    assert Enum.map(report["tests"], &{&1["name"], &1["status"]}) == [{"same", "passed"}, {"differ", "failed"}, {"differ_allowed", "passed"}]
    differ = Enum.find(report["tests"], &(&1["name"] == "differ"))
    assert differ["message"] =~ "targets disagree: lua printed \"1\", gleam printed \"1.0\""
    assert [%{"target" => "lua", "status" => "passed"}, %{"target" => "gleam", "status" => "disagrees"}] = differ["targets"]
  end
  test "a test that never ran says why", %{dir: dir} do
    path = Path.join(dir, "stopped.spi")
    File.write!(path, "inl one () = 1i32\n\ntest one =\n    one ()\n")
    previous = System.get_env("SPIRAL_KINO_CELLS")
    System.put_env("SPIRAL_KINO_CELLS", "serial")

    try do
      compile = fn %{source: source} ->
        if source =~ "inl main () : i32 = 0i32", do: {:error, "main.spi:1:1: broken prefix"}, else: {:ok, "fn main() {}\n"}
      end

      {{:error, _}, report} = Notebook.run_report(path, compile: compile, rustc: fn _ -> :ok end, execute: exit_when("never", 0), plan: :cells)
      assert [%{"status" => "not_run", "reason" => reason}] = report["tests"]
      assert reason =~ "the run stopped before this test: "
      assert reason =~ "broken prefix"
    after
      if previous, do: System.put_env("SPIRAL_KINO_CELLS", previous), else: System.delete_env("SPIRAL_KINO_CELLS")
    end
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

    assert [both, gleam_only] = report["tests"]
    assert [%{"target" => "lua", "status" => "passed", "ms" => ms}, %{"target" => "gleam", "status" => "unsupported"}] = both["targets"]
    assert is_integer(ms)
    assert [%{"target" => "gleam", "status" => "unsupported"}] = gleam_only["targets"]
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
