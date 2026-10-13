defmodule Spiral.Kino.AcceptTest do
  use ExUnit.Case, async: false

  alias Spiral.Kino.{Accept, Notebook}

  @spi """
  inl one () = 1i32

  test one =
      one ()
      |> _assert_eq 2i32

  test other =
      one () |> _assert_eq 2i32
  """

  test "a printed mismatch rewrites only its own test's literal, keeping the suffix" do
    assert {:ok, "1", "2"} = Accept.mismatch("cell exited 101\n__assert_eq { actual = 1; expected = 2 }\n")
    assert Accept.mismatch("cell exited 1") == :none
    assert {:ok, text} = Accept.rewrite(@spi, "one", "2", "1")
    assert text == String.replace(@spi, "    |> _assert_eq 2i32", "    |> _assert_eq 1i32")
    assert {:error, "no test block named nope"} = Accept.rewrite(@spi, "nope", "2", "1")
    assert {:error, "no _assert_eq 3 literal in the test body"} = Accept.rewrite(@spi, "one", "3", "1")
    assert {:error, "the actual value { a = 1 } is not a plain literal"} = Accept.rewrite(@spi, "one", "2", "{ a = 1 }")
  end

  test "--accept persists the actual values and the run passes; without it the file is untouched and the run fails" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("accept")
    path = Path.join(dir, "accept.spi")
    File.write!(path, @spi)

    execute = fn %{exe_path: exe} ->
      if File.read!(Path.join(Path.dirname(exe), "main.spi")) =~ "_assert_eq 2i32",
        do: {:ok, %{exit_status: 101, output: "__assert_eq { actual = 1; expected = 2 }\n", duration_ms: 1}},
        else: {:ok, %{exit_status: 0, output: "", duration_ms: 1}}
    end

    stubs = [compile: fn _ -> {:ok, "fn main() {}\n"} end, rustc: fn _ -> :ok end, execute: execute]

    assert {{:error, _}, report} = Notebook.run_report(path, stubs)
    assert %{"failed" => 2, "accepted" => 0} = report
    assert File.read!(path) == @spi

    assert {:ok, report} = Notebook.run_report(path, [accept: true] ++ stubs)
    assert %{"failed" => 0, "accepted" => 2} = report
    assert File.read!(path) == String.replace(@spi, "_assert_eq 2i32", "_assert_eq 1i32")

    assert {:ok, %{"passed" => 2, "accepted" => 0}} = Notebook.run_report(path, stubs)
  end
end
