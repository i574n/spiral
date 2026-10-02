defmodule Spiral.Kino.NotebookTest do
  use ExUnit.Case, async: true

  import Spiral.Kino.TestHelpers

  alias Spiral.Kino.Notebook

  test "dib wraps the code in a single spiral cell" do
    assert Notebook.dib("///- --print-code\r\n1i32\n\n") ==
             """
             #!meta

             {"kernelInfo":{"defaultKernelName":"spiral","items":[{"name":"spiral"}]}}

             #!spiral

             ///- --print-code
             1i32
             """
  end

  test "dib rejects lines that would start a new cell" do
    assert_raise ArgumentError, fn -> Notebook.dib("1i32\n#!fsharp\n2") end
  end

  test "parses a value and stdout" do
    {:ok, outputs} = Notebook.parse_ipynb(File.read!(fixture("success.ipynb")))
    assert outputs == [{:value, "3"}, {:stdout, "hello from spiral\n"}]
  end

  test "parses --print-code output" do
    {:ok, outputs} = Notebook.parse_ipynb(File.read!(fixture("print_code.ipynb")))
    assert [{:value, "42"}, {:stdout, stdout}] = outputs
    assert stdout =~ "let rec closure0 () () : unit ="
    assert stdout =~ "method0()\n\nb\n"
  end

  test "parses a builder (lua) result" do
    {:ok, outputs} = Notebook.parse_ipynb(File.read!(fixture("lua.ipynb")))
    assert outputs == [{:value, ~s[String("from lua")\n]}]
  end

  test "parses and cleans a type error, dropping the kernel's own trace" do
    {:ok, outputs} = Notebook.parse_ipynb(File.read!(fixture("type_error.ipynb")))
    assert [{:error, %{name: "Error", message: message, details: details}}] = outputs

    assert message ==
             "typecheck error File main has a type error somewhere in its path.\n" <>
               "main.spi:5:12: Unification failure.\n" <>
               "Got:      i32\n" <>
               "Expected: string"

    assert details =~ "SpiralKernel.handleSubmitCode"
  end

  test "invalid json" do
    assert {:error, {:invalid_json, _}} = Notebook.parse_ipynb("<cell id=\"cell-0\">")
    assert {:error, :invalid_notebook} = Notebook.parse_ipynb("[]")
  end

  test "clean_error strips position prefixes of every error in a trace" do
    evalue =
      "System.Exception: SpiralKernel.handleSubmitCode / aggregateError:  (0,1)-(0,1) " <>
        "typecheck error Cannot apply a forall with a term.\n (0,1)-(0,1) typecheck error " <>
        "Error trace on line: 5, column: 22 in module: main.spi .\n    let rec loop a b n =\n" <>
        " / ex: System.Exception: ..."

    assert Notebook.clean_error(evalue) ==
             "typecheck error Cannot apply a forall with a term.\n" <>
               "typecheck error Error trace on line: 5, column: 22 in module: main.spi .\n" <>
               "    let rec loop a b n ="
  end

  test "clean_error falls back to the whole message" do
    assert Notebook.clean_error("Boom\r\nat /x/target/spiral_Eval/packages/abc123/main.spi:1:1") ==
             "Boom\nat main.spi:1:1"
  end
end
