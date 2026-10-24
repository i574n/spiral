defmodule Spiral.Cells.NotebookReportTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.{Document, Notebook, ProcessError}

  setup do
    %{dir: Spiral.Cells.TestHelpers.tmp_dir!("notebook_report")}
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

  test "the summary names why --accept refused a test" do
    refused = "the actual value (1, 2) is not a plain literal"

    report = %{
      "tests" => [
        %{"name" => "pinned", "status" => "failed", "accept_refused" => refused},
        %{"name" => "plain", "status" => "accepted"}
      ]
    }

    assert ["spiral-tests file " <> json, _total] = Notebook.summary_lines([{"pins.spi", report}])
    assert %{"accepted" => 1, "failed_tests" => ["pinned"], "accept_refused" => %{"pinned" => ^refused}} = JSON.decode!(json)
  end

  test "the summary names the failing targets of each failed test" do
    report = %{
      "tests" => [
        %{"name" => "split", "status" => "failed", "targets" => [%{"target" => "rust", "status" => "passed"}, %{"target" => "gleam", "status" => "failed"}]},
        %{"name" => "green", "status" => "passed", "targets" => [%{"target" => "rust", "status" => "passed"}]}
      ]
    }

    assert ["spiral-tests file " <> json, _total] = Notebook.summary_lines([{"split.spi", report}])
    assert %{"failed_targets" => %{"split" => ["gleam"]}} = JSON.decode!(json)
    refute Map.has_key?(JSON.decode!(json)["failed_targets"], "green")
  end

  test "the summary carries actual and expected of each failed _assert_eq" do
    report = %{
      "tests" => [
        %{"name" => "drift", "status" => "failed", "actual" => "(1, 2)", "expected" => "(1, 3)"},
        %{"name" => "crash", "status" => "failed"},
        %{"name" => "green", "status" => "passed"}
      ]
    }

    assert ["spiral-tests file " <> json, _total] = Notebook.summary_lines([{"drift.spi", report}])
    assert %{"mismatches" => %{"drift" => %{"actual" => "(1, 2)", "expected" => "(1, 3)"}} = mismatches} = JSON.decode!(json)
    assert map_size(mismatches) == 1
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

    assert {:ok, %{"passed" => 1, "filtered" => 1, "static" => 0, "preludes" => 1, "discovered" => 2}} =
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
    assert {:error, %Spiral.Cells.SpiralError{message: message}} =
             Spiral.Cells.run("inl x () = y",
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
    alias Spiral.Cells.NotebookCli, as: NotebookTask
    assert NotebookTask.output_path("C:/x/geometry.spi", output_dir: "C:/out") == Path.join("C:/out", "geometry.spi.ipynb")
    assert NotebookTask.output_path("C:/x/a.spi", output_dir: "C:/out", output_path: "C:/o.ipynb") == "C:/o.ipynb"
    assert NotebookTask.output_path("C:/x/a.spi", []) == nil
  end
  test "with several --path, --test names are matched per file and fail only when no file has them" do
    alias Spiral.Cells.NotebookCli, as: NotebookTask
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

  test "a --test with * selects every matching name, in one file or across several" do
    alias Spiral.Cells.NotebookCli, as: NotebookTask
    names = fn
      "a.spi" -> ["show_floats", "show", "format"]
      "b.spi" -> ["show_ints", "parse"]
    end

    assert NotebookTask.tests_by_path(["a.spi"], ["show*"], names) == {:ok, %{"a.spi" => ["show_floats", "show"]}}
    assert NotebookTask.tests_by_path(["a.spi", "b.spi"], ["show_*", "parse"], names) ==
             {:ok, %{"a.spi" => ["show_floats"], "b.spi" => ["show_ints", "parse"]}}
    assert {:error, message} = NotebookTask.tests_by_path(["a.spi", "b.spi"], ["zz*"], names)
    assert message =~ "unknown test zz*"
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
        do: {:error, "EJP0040 main.spi:4:5: Unification failure. Got: f64 Expected: i32"},
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
      if source =~ "f64", do: {:error, "main.spi:4:5: Unification failure."}, else: {:ok, "fn main() {}\n"}
    end

    {_, report} = Notebook.run_report(path, compile: codeless, rustc: fn _ -> :ok end, execute: exit_when("never", 0), tests: ["rejects_mixed", "rejects_any"])
    assert [%{"status" => "failed", "message" => message}, %{"status" => "passed"}] = Enum.filter(report["tests"], &(&1["status"] != "filtered"))
    assert message =~ "carries no error code"

    named = fn %{source: source} ->
      if source =~ "f64",
        do: {:error, "main.spi:4:5: ETY-TermError: Unification failure. Got: f64 Expected: i32"},
        else: {:ok, "fn main() {}\n"}
    end

    File.write!(path, String.replace(spi, "EJP0040", "ETY-TermError"))
    {_, report} = Notebook.run_report(path, compile: named, rustc: fn _ -> :ok end, execute: exit_when("never", 0), tests: ["rejects_mixed"])
    assert [%{"status" => "passed"}] = Enum.filter(report["tests"], &(&1["status"] != "filtered"))

    File.write!(path, String.replace(spi, "EJP0040", "ETY-Term"))
    {_, report} = Notebook.run_report(path, compile: named, rustc: fn _ -> :ok end, execute: exit_when("never", 0), tests: ["rejects_mixed"])
    assert [%{"status" => "failed"}] = Enum.filter(report["tests"], &(&1["status"] != "filtered"))
  end
  test "a `fails` test passes only when its error is reported inside its own body", %{dir: dir} do
    path = Path.join(dir, "outside.spi")
    File.write!(path, "inl broken () : i32 = 1f64\n\ntest uses_broken fails \"Unification failure\" =\n    broken ()\n")

    outside = fn %{source: source} ->
      if source =~ "broken ()", do: {:error, "main.spi:1:23: ETY-TermError: Unification failure."}, else: {:ok, "fn main() {}\n"}
    end

    {_, report} = Notebook.run_report(path, compile: outside, rustc: fn _ -> :ok end, execute: exit_when("never", 0))
    assert [%{"status" => "failed", "message" => message}] = report["tests"]
    assert message =~ "before the test body"

    inside = fn %{source: source} ->
      if source =~ "broken ()", do: {:error, "main.spi:4:5: ETY-TermError: Unification failure."}, else: {:ok, "fn main() {}\n"}
    end

    {_, report} = Notebook.run_report(path, compile: inside, rustc: fn _ -> :ok end, execute: exit_when("never", 0))
    assert [%{"status" => "passed"}] = report["tests"]
  end
  test "a `fails` text matches across the compiler's column padding and belongs to the memo key", %{dir: dir} do
    spi = """
    inl one () = 1i32

    test padded fails EJP0040 "Got: f64" =
        one () + 1f64
    """

    path = Path.join(dir, "padded.spi")
    File.write!(path, spi)
    {:ok, agent} = Agent.start_link(fn -> 0 end)

    compile = fn %{source: source} ->
      Agent.update(agent, &(&1 + 1))

      if source =~ "f64",
        do: {:error, "EJP0040 main.spi:4:5: Unification failure.\nGot:      f64\nExpected: i32"},
        else: {:ok, "fn main() {}\n"}
    end

    run = fn ->
      Agent.update(agent, fn _ -> 0 end)

      {_, report} =
        Notebook.run_report(path,
          compile: compile,
          rustc: fn _ -> :ok end,
          execute: exit_when("never", 0),
          memo: true,
          memo_dir: Path.join(dir, "memo")
        )

      {Enum.map(report["tests"], &{&1["name"], &1["status"], &1["memo"]}), Agent.get(agent, & &1)}
    end

    assert {[{"padded", "passed", "miss"}], compiles} = run.()
    assert compiles > 0
    assert {[{"padded", "passed", "hit"}], 0} = run.()

    File.write!(path, String.replace(spi, "Got: f64", "Got: i64"))
    assert {[{"padded", "failed", "miss"}], 1} = run.()
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
    test differ_allowed no_agree "gleam prints floats" =
        one () + 0i32

    ///> lua
    ///> gleam
    test differ_bare no_agree =
        one () + 0i32
    """

    assert Document.to_spi_tested(Document.parse_spi(spi, "")) == spi
    path = Path.join(dir, "agree.spi")
    File.write!(path, spi)

    target = fn %{builder: builder, source: source} ->
      printed = if source =~ "differ" and builder.tool == :gleam, do: "2\n", else: "String(\"__assert_eq { expected = 1.5707963267949 }\")\n"
      {:ok, %{exit_status: 0, output: printed}}
    end

    compile = fn %{source: source} -> {:ok, if(source =~ "+ 0i32", do: "differ\n", else: "same\n")} end
    {_, report} = Notebook.run_report(path, compile: compile, rustc: fn _ -> :ok end, execute: exit_when("never", 0), target: target)

    assert Enum.map(report["tests"], &{&1["name"], &1["status"]}) == [{"same", "passed"}, {"differ", "failed"}, {"differ_allowed", "passed"}, {"differ_bare", "failed"}]
    assert report["no_agree_reasons"] == %{"gleam prints floats" => 1}
    assert Enum.find(report["tests"], &(&1["name"] == "differ_bare"))["message"] =~ "no_agree needs a reason"
    assert Document.parse_spi(spi, "").cells |> Enum.any?(&(&1.source =~ ~s(///- --test --no-agree "gleam prints floats")))
    differ = Enum.find(report["tests"], &(&1["name"] == "differ"))
    assert differ["message"] =~ "targets disagree: lua printed \"__assert_eq { expected = 1.570796 }\", gleam printed \"2.0\""
    assert [%{"target" => "lua", "status" => "passed"}, %{"target" => "gleam", "status" => "disagrees"}] = differ["targets"]
  end
  test "a test that never ran says why", %{dir: dir} do
    path = Path.join(dir, "stopped.spi")
    File.write!(path, "inl one () = 1i32\n\ntest one =\n    one ()\n")
    previous = System.get_env("SPIRAL_CELLS_CELLS")
    System.put_env("SPIRAL_CELLS_CELLS", "serial")

    try do
      compile = fn %{source: source} ->
        if source =~ "inl main () : i32 = 0i32", do: {:error, "main.spi:1:1: broken prefix"}, else: {:ok, "fn main() {}\n"}
      end

      {{:error, _}, report} = Notebook.run_report(path, compile: compile, rustc: fn _ -> :ok end, execute: exit_when("never", 0), plan: :cells)
      assert [%{"status" => "not_run", "reason" => reason}] = report["tests"]
      assert reason =~ "the run stopped before this test: "
      assert reason =~ "broken prefix"
    after
      if previous, do: System.put_env("SPIRAL_CELLS_CELLS", previous), else: System.delete_env("SPIRAL_CELLS_CELLS")
    end
  end
  test "a build_only test builds every target, never runs, and reports built, not passed", %{dir: dir} do
    spi = """
    inl one () = 1i32

    test host_ui build_only =
        one ()

    ///> lua
    test lua_ui build_only =
        one ()

    test broken_ui build_only =
        does_not_compile ()

    test plain =
        one ()
    """

    assert Document.to_spi_tested(Document.parse_spi(spi, "")) == spi
    path = Path.join(dir, "build_only.spi")
    File.write!(path, spi)

    compile = fn %{source: source} ->
      if source =~ "does_not_compile", do: {:error, "main.spi:1:1: Unbound variable: does_not_compile."}, else: {:ok, "fn main() {}\n"}
    end

    execute = fn %{exe_path: exe} ->
      if File.read!(Path.join(Path.dirname(exe), "main.spi")) =~ "_ui", do: raise("a build_only test ran"), else: {:ok, %{exit_status: 0, output: "", duration_ms: 1}}
    end

    {_, report} =
      Notebook.run_report(path, compile: compile, rustc: fn _ -> :ok end, execute: execute, target: fn _ -> raise "a build_only target ran" end)

    assert Enum.map(report["tests"], &{&1["name"], &1["mode"], &1["status"]}) == [
             {"host_ui", "build_only", "built"},
             {"lua_ui", "build_only", "built"},
             {"broken_ui", "build_only", "failed"},
             {"plain", "test", "passed"}
           ]

    assert %{"built" => 2, "passed" => 1, "failed" => 1} = report
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

  test "a test body is one local scope: tuple patterns and let rec over its locals compile; static bodies stay top level", %{dir: dir} do
    path = Path.join(dir, "scoped.spi")

    File.write!(path, """
    /// # scoped
    test scoped static =
        open testing

    test spread =
        type pair_i32 = i32 * i32
        inl a, b = (1i32, 2i32 : pair_i32)
        inl seed = 3i32
        let rec go (n : i32) : i32 = if n <= 0i32 then seed else go (n - 1i32)
        a + b + go 2i32 |> _assert_eq 6i32
    """)

    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert {:ok, %{"passed" => 1}} =
             Notebook.run_report(path, compile: compile(agent), rustc: fn _ -> :ok end, execute: exit_when("never", 0), tests: ["spread"])

    assert [source] = Agent.get(agent, & &1)
    assert source =~ ~r/^open testing$/m
    assert source =~ "type pair_i32 = i32 * i32\ninl spiral_cells_test () =\n    inl a, b = (1i32, 2i32 : pair_i32)\n    inl seed = 3i32\n"
    assert source =~ "inl main () : i32 =\n    spiral_cells_test ()\n    0i32\n"
  end

  test "a test body that ends in anything but an assertion compiles once: its result is bound and main returns 0i32", %{dir: dir} do
    path = Path.join(dir, "endings.spi")

    File.write!(path, """
    test unit_end =
        if 1i32 <> 1i32 then failwith "never"

    test value_end =
        1i32 + 1i32
    """)

    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert {:ok, %{"passed" => 2}} =
             Notebook.run_report(path, compile: compile(agent), rustc: fn _ -> :ok end, execute: exit_when("never", 0))

    sources = Agent.get(agent, & &1)
    assert length(sources) == 2
    assert Enum.all?(sources, &(&1 =~ "inl main () : i32 =\n    inl _ = spiral_cells_test ()\n    0i32\n"))
  end

  test "a wgsl test returns its body's i32 as main's status; other targets still return 0i32", %{dir: dir} do
    path = Path.join(dir, "status.spi")

    File.write!(path, """
    ///> wgsl
    test on_gpu =
        inl ~x = 1i32
        if x = 2i32 then 0i32 else 1i32

    ///> c
    test on_c =
        1i32 + 1i32
    """)

    {:ok, agent} = Agent.start_link(fn -> [] end)

    Notebook.run_report(path, compile: compile(agent), target: fn _ -> {:ok, %{stdout: ""}} end)

    [gpu, c] = Agent.get(agent, & &1) |> Enum.sort_by(&String.contains?(&1, "1i32 + 1i32"))
    assert gpu =~ ~r/inl main \(\) : i32 =\n    spiral_cells_test \(\)\n*\z/
    refute gpu =~ "inl _ = spiral_cells_test ()"
    assert c =~ "inl main () : i32 =\n    inl _ = spiral_cells_test ()\n    0i32\n"
  end

  test "a static block of only opens is a prelude, not a discovered test; a static block with definitions stays static" do
    doc = Document.parse_spi("///> c\ntest base static =\n    open testing\n    open sm'_operators\n\ntest helpers static =\n    inl twice x = x + x\n\ntest one =\n    1i32 |> _assert_eq 1i32\n", "")
    assert ["prelude", "static", "test"] = Enum.map(Document.tests(doc), & &1.mode)
  end

  test "untargeted tests use the static prelude's targets, else default_target, else Zig; a default_target of rust or empty keeps the Rust host; the prelude itself never runs" do
    prelude = Document.parse_spi("///> c\ntest prelude static =\n    open testing\n\ntest one =\n    1i32 |> _assert_eq 1i32\n", "")
    assert [%{tool: :c}] = Notebook.default_builders(prelude.cells, [])
    assert [%{tool: :c}] = Notebook.default_builders(prelude.cells, default_target: "lua")

    plain = Document.parse_spi("test prelude static =\n    open testing\n\ntest one =\n    1i32 |> _assert_eq 1i32\n", "")
    assert [%{tool: :lua}] = Notebook.default_builders(plain.cells, default_target: "lua")
    assert Notebook.default_builders(plain.cells, default_target: "") == []
    assert [%{tool: :fsharp}] = Notebook.default_builders(plain.cells, default_target: "fsharp")
    assert [%{tool: :rust}] = Notebook.default_builders(plain.cells, default_target: "rust")
    assert [%{tool: :zig}] = Notebook.default_builders(plain.cells, default_target: nil)
  end

  test "zig cells run the self-hosted backend with a persistent global cache under the spiral-bin cache dir" do
    args = Spiral.Cells.Targets.zig_run_args("C:/tmp/cell/main.zig", bin_cache_dir: "C:/cache")
    assert ["run" | _] = args
    assert List.last(args) == "C:/tmp/cell/main.zig"
    assert Enum.drop_while(args, &(&1 != "--global-cache-dir")) |> Enum.at(1) == Path.join("C:/cache", "cells-zig-cache")
  end

  test "a package module named like a prefix of the notebook's stem stays in the test program", %{dir: dir} do
    File.write!(Path.join(dir, "package.spiproj"), "packages: |core-\nmodules:\n    pack\n")
    File.write!(Path.join(dir, "pack.spi"), "inl answer () = 42i32\n")
    path = Path.join(dir, "pack_sim.spi")
    File.write!(path, "///- --package .\ntest pack_sim static =\n    open testing\n\ntest uses_pack =\n    open pack\n    answer () |> _assert_eq 42i32\n")
    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert {:ok, %{"passed" => 1}} = Notebook.run_report(path, compile: compile(agent), rustc: fn _ -> :ok end, execute: exit_when("never", 0))
    assert [source | _] = Agent.get(agent, & &1) |> Enum.filter(&(&1 =~ "answer ()"))
    assert source =~ ~r/^open pack$/m
  end

  test "a .spi file's first ///- --timeout is the budget of its test blocks", %{dir: dir} do
    path = Path.join(dir, "slow.spi")
    File.write!(path, "///- --timeout 1800000\ninl one () = 1i32\n\ntest one =\n    one () |> _assert_eq 1i32\n\ntest two =\n    one () |> _assert_eq 1i32\n")
    {:ok, agent} = Agent.start_link(fn -> [] end)

    budget = fn %{source: source} ->
      left = Process.get(:spiral_cells_deadline) - System.monotonic_time(:millisecond)
      Agent.update(agent, &[{source =~ "two", left} | &1])
      {:ok, "fn main() {}\n"}
    end

    assert {:ok, %{"passed" => 2}} = Notebook.run_report(path, compile: budget, rustc: fn _ -> :ok end, execute: exit_when("never", 0))
    budgets = Agent.get(agent, & &1)
    assert length(budgets) >= 2
    assert Enum.all?(budgets, fn {_, left} -> left > 300_000 and left <= 1_800_000 end)

    File.write!(path, "inl one () = 1i32\n\ntest one =\n    one () |> _assert_eq 1i32\n")
    Agent.update(agent, fn _ -> [] end)
    assert {:ok, %{"passed" => 1}} = Notebook.run_report(path, compile: budget, rustc: fn _ -> :ok end, execute: exit_when("never", 0))
    assert Enum.all?(Agent.get(agent, & &1), fn {_, left} -> left <= 300_000 end)
  end

  test "a compile error points at the .spi line and column, not the throwaway main.spi", %{dir: dir} do
    path = Path.join(dir, "located.spi")
    File.write!(path, "inl one () = 1i32\n\ntest broken =\n    inl a = one ()\n    a + missing_name |> _assert_eq 1i32\n")

    compile = fn %{source: source} ->
      lines = String.split(source, "\n")
      line = Enum.find_index(lines, &(&1 =~ "missing_name")) + 1
      column = (lines |> Enum.at(line - 1) |> :binary.match("missing_name") |> elem(0)) + 1
      {:error, "main.spi:#{line}:#{column}: ETY-UnboundVariable: Unbound variable: missing_name."}
    end

    {_, report} = Notebook.run_report(path, compile: compile, rustc: fn _ -> :ok end, execute: exit_when("never", 0))
    assert [%{"name" => "broken", "message" => message}] = report["tests"]
    assert message =~ ~r/located\.spi:5:9 \(main\.spi:\d+:\d+\): ETY-UnboundVariable/
  end

  test "an ambiguous or unknown main.spi line stays as it is" do
    assert Spiral.Cells.SourceMap.remap("main.spi:2:1: oops", "x\ny\n", "y\nz\ny\n", "f.spi") == "main.spi:2:1: oops"
    assert Spiral.Cells.SourceMap.remap("main.spi:1:5: oops", "zzz\n", "a\n", "f.spi") == "main.spi:1:5: oops"
    assert Spiral.Cells.SourceMap.remap("main.spi:2:5: oops", "a\n    b\nc\n", "q\na\nb\nc\nb\n", "f.spi") == "f.spi:3:1 (main.spi:2:5): oops"
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

  test "a reference header mode names the target every other target is compared with", %{dir: dir} do
    spi = """
    /// # reference
    inl one () = 1i32

    ///> lua
    ///> gleam
    test differ reference gleam =
        one () + 0i32
    """

    assert Document.to_spi_tested(Document.parse_spi(spi, "")) == spi
    assert Document.parse_spi(spi, "").cells |> Enum.any?(&(&1.source =~ "///- --test --reference gleam"))
    path = Path.join(dir, "reference.spi")
    File.write!(path, spi)

    target = fn %{builder: builder} ->
      printed = if builder.tool == :gleam, do: "2\n", else: "1\n"
      {:ok, %{exit_status: 0, output: printed}}
    end

    compile = fn _ -> {:ok, "differ\n"} end
    {_, report} = Notebook.run_report(path, compile: compile, rustc: fn _ -> :ok end, execute: exit_when("never", 0), target: target)
    differ = Enum.find(report["tests"], &(&1["name"] == "differ"))
    assert differ["message"] =~ "targets disagree with the reference gleam: gleam printed \"2.0\", lua printed \"1.0\""
    assert Enum.find(differ["targets"], &(&1["target"] == "lua"))["status"] == "disagrees"
  end
end
