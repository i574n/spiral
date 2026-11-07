defmodule Spiral.Cells.NotebookTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.Notebook

  setup do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("notebook")
    %{dir: dir}
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
               execute: run_value("SPIRAL_CELLS_VALUE:1\n"),
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
               execute: run_value("SPIRAL_CELLS_VALUE:1\n"),
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
    count = Spiral.Cells.Slots.limit() + 3
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
    assert peak <= Spiral.Cells.Slots.limit()
  end

  defp lines(source), do: String.split(source, "\n")
  defp calls?(source, line), do: Enum.any?(lines(source), &(String.trim(&1) == line))

  defp compile(agent) do
    fn %{source: source} ->
      Agent.update(agent, &(&1 ++ [source]))
      {:ok, "fn main() {}\n"}
    end
  end

  defp rustc_ok(_ctx), do: :ok

  defp run_value(output),
    do: fn _ctx -> {:ok, %{exit_status: 0, output: output, duration_ms: 1}} end

  test "spi test blocks see the static prelude and earlier definitions, and the prelude alone never compiles", %{
    dir: dir
  } do
    path = Path.join(dir, "demo.spi")

    File.write!(path, """
    /// # demo
    ///> rust
    test demo static =
        open testing

    inl value () = 1i32

    ///> rust
    test value_is_one =
        value ()
    """)

    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert :ok =
             Notebook.run(path,
               compile: compile(agent),
               rustc: &rustc_ok/1,
               execute: run_value("ok\n")
             )

    sources = Agent.get(agent, & &1)
    refute Enum.any?(sources, &(String.contains?(&1, "open testing") and not String.contains?(&1, "inl value")))

    use_cell = Enum.find(sources, &calls?(&1, "value ()"))
    assert "inl value () = 1i32" in lines(use_cell)
    assert "open testing" in lines(use_cell)

    ipynb = (path <> ".ipynb") |> File.read!() |> JSON.decode!()
    assert ipynb["nbformat"] == 4
  end

  test "spi test-block flags reach the target: a ///> rust -cd line sets the contract and deps of its block only", %{dir: dir} do
    path = Path.join(dir, "flags.spi")

    File.write!(path, """
    /// # flags
    inl prior () = 1i32

    inl value () = 2i32

    ///> rust -cd near-token
    test value_is_two =
        value ()
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
               end
             )

    assert_received :targeted
    assert Enum.any?(Agent.get(agent, & &1), fn {backend, source} ->
             backend == "Rust" and source =~ "inl prior () = 1i32" and source =~ "inl value () = 2i32" and not (source =~ "///>")
           end)
  end

  test "a .spi whose --package is missing beside it is loaded from the workspace root", %{dir: dir} do
    notebook = Path.join(dir, "contract")
    File.mkdir_p!(notebook)
    workspace = Path.join(dir, "polyglot")
    package = Path.join(workspace, "vendor/pkg")
    File.mkdir_p!(package)
    File.write!(Path.join(package, "package.spiproj"), "packageDir: .\npackages:\n    |core-\nmodules:\n    lib\n")
    path = Path.join(notebook, "note.spi")
    File.write!(path, "///- --package vendor/pkg\ninl value () = 1i32\n\ntest value_is_one =\n    value ()\n")

    assert :ok =
             Notebook.run(path,
               workspace_root: workspace,
               compile: fn %{spi_path: spi} ->
                 assert File.read!(Path.join(Path.dirname(spi), "package.spiproj")) =~ "pkg-"
                 {:ok, "fn main() {}\n"}
               end,
               rustc: &rustc_ok/1,
               execute: run_value("ok\n")
             )
  end

  test "spi: the spiral lib package is mounted once", %{dir: dir} do
    lib = Path.join(dir, "spiral")
    File.mkdir_p!(lib)
    File.write!(Path.join(lib, "package.spiproj"), "packages:\n    |core-\nmodules:\n")
    path = Path.join(dir, "mounted.spi")
    File.write!(path, "///- --package #{lib}\ninl value () = 1i32\n\ntest value_is_one =\n    value ()\n")

    assert :ok =
             Notebook.run(path,
               compile: fn %{spi_path: spi} ->
                 proj = File.read!(Path.join(Path.dirname(spi), "package.spiproj"))
                 assert proj =~ "spiral-"
                 refute proj =~ "spiral-\n    spiral-"
                 {:ok, "fn main() {}\n"}
               end,
               rustc: &rustc_ok/1,
               execute: run_value("ok\n")
             )
  end

  test "spi: a ///> _ block is not compiled", %{dir: dir} do
    path = Path.join(dir, "skip.spi")
    File.write!(path, "inl value () = 1i32\n\n///> _\ntest not_compiled =\n    not_spiral_emitter\n\ntest compiled =\n    value ()\n")
    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert :ok = Notebook.run(path, compile: compile(agent), rustc: &rustc_ok/1, execute: run_value("ok\n"))

    sources = Agent.get(agent, & &1)
    assert Enum.any?(sources, &(&1 =~ "inl value () = 1i32"))
    refute Enum.any?(sources, &(&1 =~ "not_spiral_emitter"))
  end

  test "spi: test blocks compile together", %{dir: dir} do
    path = Path.join(dir, "together.spi")
    File.write!(path, "inl left () = 1i32\n\ninl right () = 2i32\n\ntest left_is_one =\n    left ()\n\ntest right_is_two =\n    right ()\n")
    parent = self()

    compile = fn %{source: source} ->
      side = if calls?(source, "left ()"), do: :left, else: :right
      send(parent, {side, :started, System.monotonic_time()})
      Process.sleep(200)
      send(parent, {side, :done, System.monotonic_time()})
      {:ok, "fn main() {}\n"}
    end

    assert :ok = Notebook.run(path, compile: compile, rustc: &rustc_ok/1, execute: run_value("ok\n"))
    assert_received {:left, :started, left}
    assert_received {:right, :started, right}
    assert_received {:left, :done, left_done}
    assert_received {:right, :done, right_done}
    assert left < right_done and right < left_done
  end

  test "spi: a static test block's definitions reach later blocks; a plain test block's do not", %{dir: dir} do
    path = Path.join(dir, "reach.spi")
    File.write!(path, "test kept static =\n    inl kept () = 1i32\n\ntest dropped =\n    inl dropped () = 2i32\n    dropped ()\n\ntest uses_kept =\n    kept ()\n")
    {:ok, agent} = Agent.start_link(fn -> [] end)

    assert :ok = Notebook.run(path, compile: compile(agent), rustc: &rustc_ok/1, execute: run_value("ok\n"))

    last = Agent.get(agent, & &1) |> Enum.find(&calls?(&1, "kept ()"))
    assert "inl kept () = 1i32" in lines(last)
    refute "inl dropped () = 2i32" in lines(last)
  end

  test "spi: at most four test blocks run at a time", %{dir: dir} do
    path = Path.join(dir, "many.spi")
    File.write!(path, Enum.map_join(1..10, "\n", &"inl f#{&1} () = #{&1}i32\n\ntest f#{&1}_runs =\n    f#{&1} ()\n"))
    {:ok, counter} = Agent.start_link(fn -> {0, 0} end)

    compile = fn _ ->
      Agent.update(counter, fn {now, top} -> {now + 1, max(top, now + 1)} end)
      Process.sleep(100)
      Agent.update(counter, fn {now, top} -> {now - 1, top} end)
      {:ok, "fn main() {}\n"}
    end

    assert :ok = Notebook.run(path, compile: compile, rustc: &rustc_ok/1, execute: run_value("ok\n"))
    {_, top} = Agent.get(counter, & &1)
    assert top in 2..4
  end

  test "spi: a _real.spir sibling becomes the main_real module", %{dir: dir} do
    path = Path.join(dir, "real.spi")
    File.write!(path, "inl twice (x : i32) : i32 = real twice_real x\n\ntest twice_runs =\n    twice 21i32\n")
    File.write!(Path.join(dir, "real_real.spir"), "inl twice_real (x : i32) : i32 = x + x\n\ntest twice_real_runs =\n    inl y = twice_real 2i32\n    y\n")
    {:ok, agent} = Agent.start_link(fn -> [] end)

    compile = fn %{spi_path: spi, source: source} ->
      dir = Path.dirname(spi)
      real = Path.join(dir, "main_real.spir")
      proj = File.read!(Path.join(dir, "package.spiproj"))
      real_text = if File.regular?(real), do: File.read!(real)
      Agent.update(agent, &(&1 ++ [{source, real_text, proj}]))
      {:ok, "fn main() {}\n"}
    end

    assert :ok = Notebook.run(path, compile: compile, rustc: &rustc_ok/1, execute: run_value("ok\n"))
    runs = Agent.get(agent, & &1)
    assert length(runs) == 3

    for {source, real, proj} <- runs do
      refute source =~ "inl twice_real", "a real definition reached a top-down program"
      assert real =~ "inl twice_real (x : i32) : i32 = x + x"
      assert proj =~ ~r/^    main_real\*-\n    main$/m
    end

    {real_test, real, _} = Enum.find(runs, fn {source, _, _} -> source =~ "spiral_cells_real" end)
    assert real_test =~ "real spiral_cells_real ()"
    assert real =~ "inl spiral_cells_real () =\n    inl y = twice_real 2i32\n    y"
    {_, real, _} = Enum.find(runs, fn {source, _, _} -> calls?(source, "twice 21i32") end)
    refute real =~ "inl y = twice_real 2i32", "a real test's code reached a later block"
  end
end
