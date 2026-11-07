defmodule Spiral.Cells.BuildOnlyTest do
  use ExUnit.Case, async: false

  @moduletag timeout: 900_000

  alias Spiral.Cells.{NotebookCli, Targets, Toolchain}

  setup do
    %{dir: Spiral.Cells.TestHelpers.tmp_dir!("build_only")}
  end

  test "build-only skips every non-gleam target and host cell without calling them", %{dir: dir} do
    receipt = Path.join(dir, "receipt.txt")
    test_pid = self()

    called = fn _ ->
      send(test_pid, :ran)
      {:ok, %{exit_status: 0, output: "ran\n"}}
    end
    opts = [build_receipt: receipt, target: called, host: called]

    assert {:ok, %{stdout: ""}} = Targets.run(%{tool: :lua, deps: []}, Path.join(dir, "main.lua"), opts, 1_000, :infinity)
    assert {:ok, %{stdout: ""}} = Targets.host("pwsh", "Set-Content marker x", opts, 1_000, :infinity)
    refute_received :ran
    refute File.exists?(receipt)
  end

  test "a receipt with an ebin line is the result, a receipt without one is an error", %{dir: dir} do
    built = Path.join(dir, "built.txt")
    File.write!(built, "cells-build-only ebin=/p/build/dev/erlang/main/ebin\ncells-build-only entry=main\n")
    assert {:ok, ["cells-build-only ebin=/p/build/dev/erlang/main/ebin", "cells-build-only entry=main"]} = NotebookCli.build_only_result(built)
    refute File.exists?(built)

    assert {{:error, message}, []} = NotebookCli.build_only_result(Path.join(dir, "missing.txt"))
    assert message =~ "built no gleam cell"
  end

  test "build_only_receipt lists every ebin of the package in order and the entry module", %{dir: dir} do
    for app <- ["main", "gleam_stdlib"], do: File.mkdir_p!(Path.join(dir, "pkg/build/dev/erlang/#{app}/ebin"))
    receipt = Path.join(dir, "receipt.txt")

    assert {:ok, %{exit_status: 0, output: ""}} = Targets.build_only_receipt(Path.join(dir, "pkg"), "erlang", receipt)
    ebins = for app <- ["gleam_stdlib", "main"], do: "cells-build-only ebin=" <> String.replace(Path.join(dir, "pkg/build/dev/erlang/#{app}/ebin"), "\\", "/")
    package = "cells-build-only package=" <> String.replace(Path.join(dir, "pkg"), "\\", "/")
    expected = [package | ebins] ++ ["cells-build-only entry=main"]
    assert File.read!(receipt) |> String.downcase() |> String.split("\n", trim: true) == Enum.map(expected, &String.downcase/1)
  end

  test "a gleam program is built but not run, and the receipt runs it", %{dir: dir} do
    erl = Toolchain.erl([])
    gleam = Toolchain.gleam([])

    if is_nil(erl) or is_nil(gleam) do
      IO.puts("skipped: gleam or erl is not installed")
    else
      marker = Path.join(dir, "marker") |> String.replace("\\", "/")
      source = Path.join(dir, "pkg/src/main.gleam")
      File.mkdir_p!(Path.dirname(source))

      File.write!(source, """
      import gleam/dynamic.{type Dynamic}

      @external(erlang, "file", "write_file")
      fn write_file(path: String, data: String) -> Dynamic

      pub fn main() {
        write_file("#{marker}", "ran")
        Nil
      }
      """)

      receipt = Path.join(dir, "receipt.txt")
      builder = %{tool: :gleam, target: "erlang", deps: []}

      assert {:ok, %{stdout: ""}} = Targets.run(builder, source, [build_receipt: receipt, root: dir], 600_000, :infinity)
      refute File.exists?(marker)

      lines = File.read!(receipt) |> String.split("\n", trim: true)
      assert "cells-build-only entry=main" in lines
      ebins = for "cells-build-only ebin=" <> path <- lines, do: path
      assert ebins != []

      {_, 0} = System.cmd(erl, ["-noshell", "-pa" | ebins] ++ ["-eval", "main:main(), halt(0)."])
      assert File.read!(marker) == "ran"
    end
  end
end
