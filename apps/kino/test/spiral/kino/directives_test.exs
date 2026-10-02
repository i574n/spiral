defmodule Spiral.Kino.DirectivesTest do
  use ExUnit.Case, async: true

  alias Spiral.Kino.Directives

  test "fsharp backend without flags leaves the code untouched" do
    code = "inl x = 1i32\nx\n"
    assert Directives.apply_options(code, backend: "fsharp") == code
    assert Directives.apply_options(code, []) == code
  end

  test "adds a builder line for non-default backends" do
    assert Directives.apply_options("1i32", backend: "rust", builder_args: "-d chrono") ==
             "///> rust -d chrono\n1i32"

    assert Directives.apply_options("1i32", backend: :lua) == "///> lua\n1i32"
  end

  test "supports several backends at once" do
    assert Directives.apply_options("1i32", backend: ["fsharp", "gleam", "lua"]) ==
             "///> gleam\n///> lua\n1i32"
  end

  test "does not duplicate a builder the code already declares" do
    code = "///> rust -d regex\n1i32"
    assert Directives.apply_options(code, backend: "rust", builder_args: "-d chrono") == code
  end

  test "inserts a ///- line when the code has none" do
    assert Directives.apply_options("1i32", print_code: true, trace: true) ==
             "///- --print-code --trace\n1i32"
  end

  test "folds flags into the user's first ///- line" do
    code = "// hi\n///- --timeout 5000\n\n1i32\n///- --other\n"

    assert Directives.apply_options(code, print_code: true) ==
             "// hi\n///- --timeout 5000 --print-code\n\n1i32\n///- --other\n"
  end

  test "does not repeat flags that are already present" do
    code = "///- --print-code --timeout 100\n1i32"
    assert Directives.apply_options(code, print_code: true) == code
  end

  test "kernel_args are merged too" do
    assert Directives.apply_options("1i32", kernel_args: "--package foo") ==
             "///- --package foo\n1i32"

    assert Directives.apply_options("1i32", kernel_args: "  ") == "1i32"
  end

  test "normalizes CRLF" do
    assert Directives.apply_options("a\r\nb", backend: "lua") == "///> lua\na\nb"
  end

  test "unknown backend raises" do
    assert_raise ArgumentError, ~r/unknown Spiral backend "cobol"/, fn ->
      Directives.apply_options("1i32", backend: "cobol")
    end
  end

  test "parse collects args, builders, and disabled lines" do
    assert Directives.parse("///- --print-code\n///> rust -d chrono\n////> lua\n1i32") ==
             %{args: "--print-code", builders: ["rust -d chrono"], disabled: ["////> lua"]}
  end

  test "parse ignores disabled directives" do
    assert %{args: nil, builders: [], disabled: ["////> rust", "//// --x"]} =
             Directives.parse("////> rust\n//// --x\n1i32")
  end
end
