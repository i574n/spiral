defmodule Spiral.Kino.FsiSessionTest do
  use ExUnit.Case, async: false

  alias Spiral.Kino.{FsiChain, FsiSession, Notebook, Runner, Toolchain}

  # A cold `dotnet fsi` takes 15-25 s to start on this box; budgets are load-tolerant.
  @moduletag timeout: 600_000

  setup do
    dotnet = Toolchain.dotnet([])

    if is_binary(dotnet) and (File.regular?(dotnet) or System.find_executable(dotnet)) do
      %{dir: Spiral.Kino.TestHelpers.tmp_dir!("fsi")}
    else
      {:skip, "dotnet is not installed"}
    end
  end

  test "each submission is its own fsi interaction: types are redefined, values, errors and unicode are per cell" do
    {:ok, s} = FsiSession.start()

    try do
      assert {:ok, %{output: "", value: nil}} =
               FsiSession.submit(s, "type US0 = A | B\nlet x = A")

      # The same type name again, in a later submission (an accumulated script fails here with a duplicate type).
      assert {:ok, %{output: "y=C 3 x=A"}} =
               FsiSession.submit(s, "type US0 = C of int\nlet y = C 3\nprintfn \"y=%A x=%A\" y x")

      assert {:ok, %{value: "3"}} = FsiSession.submit(s, "1 + 2")
      # A unit expression and a definition-only cell show no value.
      assert {:ok, %{value: nil}} = FsiSession.submit(s, "printfn \"\"")
      assert {:ok, %{value: nil}} = FsiSession.submit(s, "let z = 1")

      assert {:ok, %{output: "0 22283 국어"}} =
               FsiSession.submit(
                 s,
                 "let rec 루프 n = if n > 0 then 루프 (n - 1) else n\nprintfn \"%d %d %s\" (루프 3) (int '國') \"국어\""
               )

      assert {:error, %{reason: :failed, output: compile}} =
               FsiSession.submit(s, "let a = 1\nundefinedThing + 1", label: "cell.fsx")

      # Positions are relative to the submission, under its label.
      assert compile =~ "cell.fsx(2,1): error FS0039"

      assert {:error, %{reason: :failed, output: thrown}} =
               FsiSession.submit(s, "let f () : int = failwith \"boom\"\nf ()")

      assert thrown =~ "System.Exception: boom"
      assert thrown =~ "Stopped due to error"

      # The session survives failed submissions.
      assert {:ok, %{value: "4"}} = FsiSession.submit(s, "z + 3")

      # polyglot's Notebooks.dib sets Formatter.ListExpansionLimit; values are shown the way dotnet-repl registers them
      # for an fsharp/spiral notebook: `%120A`.
      assert {:ok, _} = FsiSession.submit(s, "Formatter.ListExpansionLimit <- 3")

      assert {:ok, %{value: "[1; 2; 3; 4; 5; 6; 7; 8; 9; 10]"}} =
               FsiSession.submit(s, "[1 .. 10]")

      assert {:ok, %{value: "Some (1006, [5; 4; 3; 2])"}} =
               FsiSession.submit(s, "Some (1006, [ 5; 4; 3; 2 ])")

      # ToDisplayString on an inline generic and Display on a registered type, as polyglot's Testing.dib uses them.
      assert {:ok, %{output: shown}} =
               FsiSession.submit(s, """
               let inline show actual = printfn $"{actual.ToDisplayString ()}"
               show [ 1; 2 ]
               type Shown (x: int) =
                   member _.Text = sprintf "shown %d" x
               Formatter.Register<Shown> ((fun (x : Shown) -> x.Text), "text/html")
               Shown(7).Display () |> ignore
               """)

      # dotnet-repl's default mime type is text/plain, so Display shows `%120A` (the html formatter is not preferred).
      assert shown =~ "[1; 2]"
      assert shown =~ "Shown"
    after
      FsiSession.stop(s)
    end
  end

  test "a submission past its budget kills the fsi process tree and ends the session" do
    {:ok, s} = FsiSession.start()
    os_pid = FsiSession.os_pid(s)
    assert Runner.os_pid_alive?(os_pid)

    assert {:error, %{reason: :timeout}} =
             FsiSession.submit(s, "System.Threading.Thread.Sleep 60000", timeout: 2_000)

    refute FsiSession.alive?(s)
    assert Spiral.Kino.TestHelpers.wait_until(fn -> not Runner.os_pid_alive?(os_pid) end)
    assert {:error, %{reason: :closed}} = FsiSession.submit(s, "1")
  end

  test "imports resolve against the importing file, then the notebook; other kernels' cells are noted",
       %{dir: dir} do
    lib = Path.join(dir, "lib")
    File.mkdir_p!(Path.join(lib, "sub"))
    File.write!(Path.join(lib, "sub/a.fsx"), "let a = 1\n")

    File.write!(Path.join(lib, "nb.dib"), """
    #!fsharp

    let before = 0

    #!fsharp

    #!import sub/a.fsx
    let after = a + 1

    #!spiral

    inl x = 1
    """)

    assert {:ok, parts} =
             FsiChain.submissions(%{index: 0, kind: :import, source: "lib/nb.dib"}, dir)

    assert [
             %{label: "nb.dib[1]", code: "let before = 0"},
             %{label: "a.fsx", code: "let a = 1\n"},
             %{label: "nb.dib[3]", code: "let after = a + 1"},
             {:note, note}
           ] = parts

    assert note =~ "spiral cell skipped"

    assert {:error, message} =
             FsiChain.submissions(%{index: 0, kind: :import, source: "missing.fsx"}, dir)

    assert message =~ "missing.fsx was not found"
  end

  test "a notebook's F# cells and imports run in order on one session", %{dir: dir} do
    File.write!(Path.join(dir, "first.fsx"), "type US0 = First of int\nlet first = First 1\n")

    File.write!(
      Path.join(dir, "second.fsx"),
      "type US0 = Second of string\nlet second = Second \"two\"\n"
    )

    File.write!(Path.join(dir, "helpers.dib"), """
    #!fsharp

    #!import first.fsx
    type First_US0 = US0
    #!import second.fsx
    """)

    path = Path.join(dir, "nb.dib")

    File.write!(path, """
    #!markdown

    # F# session

    #!fsharp

    #!import helpers.dib

    #!fsharp

    printfn "%A %A" first second
    (first : First_US0)

    #!fsharp

    undefinedThing

    #!fsharp

    printfn "still running"

    #!fsharp

    ///- --ignore

    printfn "ignored"

    #!fsharp

    ///- --timeout 3000

    System.Threading.Thread.Sleep 60000

    #!fsharp

    printfn "never"
    """)

    out = Path.join(dir, "nb.ipynb")

    assert {:error, message} =
             Notebook.run(path, output_path: out, spi_path: Path.join(dir, "nb.spi"))

    assert message =~ "error FS0039"

    cells = out |> File.read!() |> JSON.decode!() |> Map.fetch!("cells")
    code = Enum.filter(cells, &(&1["cell_type"] == "code"))
    texts = Enum.map(code, &cell_text/1)

    assert [import, shown, failed, running, ignored, timed_out, skipped] = texts
    assert Enum.all?(code, &(&1["metadata"]["language"] == "fsharp"))
    refute import =~ "error"
    assert shown =~ ~s(First 1 Second "two")
    assert shown =~ "First 1"
    assert failed =~ "input.fsx(1,1): error FS0039"
    assert running =~ "still running"
    # `///- --ignore` cells are skipped, as the .dib route's runner skips them.
    assert ignored == ""
    assert Enum.at(code, 4)["execution_count"] == nil
    assert timed_out =~ "timed out after 3s"
    assert skipped =~ "skipped: the F# session was killed when cell"
  end

  defp cell_text(cell) do
    Enum.map_join(cell["outputs"], "\n", fn
      %{"text" => text} -> Enum.join(text)
      %{"data" => %{"text/plain" => text}} -> Enum.join(text)
      %{"traceback" => text} -> Enum.join(text)
    end)
  end
end
