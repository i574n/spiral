defmodule Spiral.Cells.AcceptTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.{Accept, Notebook}

  @spi """
  inl one () = 1i32

  test one =
      one ()
      |> _assert_eq 2i32

  test other =
      one () |> _assert_eq 2i32
  """

  test "accept_sites names the line it rewrote, before and after" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("accept_sites")
    path = Path.join(dir, "sites.spi")
    File.write!(path, @spi)
    assert [{"one", {:ok, "|> _assert_eq 2i32", "|> _assert_eq 1i32"}}] =
             Accept.accept_sites(path, [{"one", "__assert_eq { actual = 1; expected = 2 }"}])
    assert File.read!(path) == String.replace(@spi, "    |> _assert_eq 2i32", "    |> _assert_eq 1i32")
  end

  test "a printed mismatch rewrites only its own test's literal, keeping the suffix" do
    assert {:ok, "1", "2"} = Accept.mismatch("cell exited 101\n__assert_eq { actual = 1; expected = 2 }\n")
    assert Accept.mismatch("cell exited 1") == :none
    assert {:ok, text} = Accept.rewrite(@spi, "one", "2", "1")
    assert text == String.replace(@spi, "    |> _assert_eq 2i32", "    |> _assert_eq 1i32")
    assert {:error, "no test block named nope"} = Accept.rewrite(@spi, "nope", "2", "1")
    assert {:error, "the failing _assert_eq (number 1 in the test body) is not the literal 3"} = Accept.rewrite(@spi, "one", "3", "1")
    assert {:error, "the actual value { a = 1 } is not a plain literal"} = Accept.rewrite(@spi, "one", "2", "{ a = 1 }")
  end

  test "--accept persists the actual values and the run passes; without it the file is untouched and the run fails" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("accept")
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

  test "--accept re-runs an accepted test until every assertion holds, picking repeated literals by position" do
    dir = Spiral.Cells.TestHelpers.tmp_dir!("accept_rounds")
    path = Path.join(dir, "rounds.spi")

    File.write!(path, """
    test stats =
        5i32 |> _assert_eq 5i32
        3i32 |> _assert_eq 5i32
        8i32 |> _assert_eq 9i32
    """)

    actuals = [5, 3, 8]

    execute = fn %{exe_path: exe} ->
      expected =
        Regex.scan(~r/_assert_eq (\d+)i32/, File.read!(Path.join(Path.dirname(exe), "main.spi")))
        |> Enum.map(fn [_, n] -> String.to_integer(n) end)

      {lines, status} =
        Enum.zip(actuals, expected)
        |> Enum.reduce_while({[], 0}, fn {actual, wanted}, {lines, _} ->
          if actual == wanted,
            do: {:cont, {lines ++ ["__assert_eq { expected = #{wanted} }"], 0}},
            else: {:halt, {lines ++ ["__assert_eq { actual = #{actual}; expected = #{wanted} }"], 101}}
        end)

      {:ok, %{exit_status: status, output: Enum.join(lines, "\n") <> "\n", duration_ms: 1}}
    end

    stubs = [compile: fn _ -> {:ok, "fn main() {}\n"} end, rustc: fn _ -> :ok end, execute: execute]

    assert {:ok, %{"accepted" => 1, "failed" => 0}} = Notebook.run_report(path, [accept: true] ++ stubs)
    assert File.read!(path) =~ "    5i32 |> _assert_eq 5i32\n    3i32 |> _assert_eq 3i32\n    8i32 |> _assert_eq 8i32\n"
    assert {:ok, %{"passed" => 1}} = Notebook.run_report(path, stubs)
  end

  test "a flat tuple of plain literals is rewritten element by element, keeping each suffix" do
    spi = """
    test claims =
        (a, b, c, d) |> _assert_eq (0i32, 0u32, "x, y", false)
    """

    message = "__assert_eq { actual = (3, 4, \"x, z\", true); expected = (0, 0, \"x, y\", false) }\n"
    assert {:ok, actual, expected} = Accept.mismatch(message)
    assert {:ok, text} = Accept.rewrite(spi, "claims", expected, actual)
    assert text == String.replace(spi, "(0i32, 0u32, \"x, y\", false)", "(3i32, 4u32, \"x, z\", true)")

    assert {:error, "the failing _assert_eq (number 1 in the test body) is not the tuple (0, 1, \"x, y\", false)"} =
             Accept.rewrite(spi, "claims", "(0, 1, \"x, y\", false)", actual)

    assert {:error, "the actual value ((1, 2), 3) is not a flat tuple of plain literals" <> _} =
             Accept.rewrite(spi, "claims", expected, "((1, 2), 3)")
  end

  test "a literal that a loop asserts several times is refused, never guessed" do
    assert Accept.passed_before("__assert_eq { expected = 2 }\n__assert_eq { expected = 2 }\n__assert_eq { actual = 1; expected = 2 }\n") == 2
    assert {:error, "the failing _assert_eq is number 3 but the test body writes 1" <> _} = Accept.rewrite(@spi, "one", "2", "1", 2)
  end

  test "a failure printed before the passing lines (C prints it twice) still binds to its own assert, never to an equal literal elsewhere" do
    spi = """
    test pinned =
        g.first |> _assert_eq 110i32
        evolved |> _assert_eq 948i32
        cavebot |> _assert_eq 1099i32
    """

    first = "builder failed (exit 1)\n\n__assert_eq { actual = 1099; expected = 948 }\n__assert_eq { expected = 110 }\n__assert_eq { actual = 1099; expected = 948 }\n"
    assert {:ok, "1099", "948"} = Accept.mismatch(first)
    assert {:ok, once} = Accept.rewrite(spi, "pinned", "948", "1099", Accept.passed_before(first))
    assert once =~ "evolved |> _assert_eq 1099i32\n    cavebot |> _assert_eq 1099i32"

    second = "builder failed (exit 1)\n\n__assert_eq { actual = 995; expected = 1099 }\n__assert_eq { expected = 110 }\n__assert_eq { expected = 1099 }\n__assert_eq { actual = 995; expected = 1099 }\n"
    assert {:ok, twice} = Accept.rewrite(once, "pinned", "1099", "995", Accept.passed_before(second))
    assert twice =~ "evolved |> _assert_eq 1099i32\n    cavebot |> _assert_eq 995i32"
  end
end