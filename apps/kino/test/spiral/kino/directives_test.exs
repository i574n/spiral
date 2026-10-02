defmodule Spiral.Kino.DirectivesTest do
  use ExUnit.Case, async: true

  alias Spiral.Kino.Directives

  test "wraps the last expression in main and leaves the function above it" do
    %{code: code, generated_main: true, print_code: false} =
      Directives.prepare("""
      inl square x = x * x

      console.write_line "Hello from Spiral!"
      square 7i32
      """)

    assert code ==
             """
             inl square x = x * x

             inl main () : i32 =
                 console.write_line "Hello from Spiral!"
                 square 7i32
             """
  end

  test "an existing main is the program" do
    source = "inl main () : i32 = 1i32\n"
    assert %{code: ^source, generated_main: false} = Directives.prepare(source)
  end

  test "a bare expression becomes main" do
    assert %{code: "inl main () : i32 =\n    1i32 + 2i32\n"} = Directives.prepare("1i32 + 2i32")
  end

  test "--print-code and --timeout are read from the first ///- line" do
    assert %{print_code: true, timeout: 5_000, code: "inl main () : i32 =\n    1i32\n"} =
             Directives.prepare("///- --print-code --timeout 5000\n1i32")
  end

  test "a later ///- line is dropped" do
    assert %{timeout: 5, code: code} =
             Directives.prepare("///- --timeout 5\n1i32\n///- --timeout 9\n")

    refute code =~ "--timeout"
  end

  test "rust builder lines are dropped and other backends raise" do
    assert %{code: "inl main () : i32 =\n    1i32\n"} = Directives.prepare("///> rust\n1i32")

    assert_raise ArgumentError, ~r/builder arguments are not used/, fn ->
      Directives.prepare("///> rust -d chrono\n1i32")
    end

    assert_raise ArgumentError, ~r/unknown Spiral backend "lua"/, fn ->
      Directives.prepare("///> lua\n1i32")
    end
  end

  test "disabled and unknown directives" do
    assert %{code: "inl main () : i32 =\n    1i32\n"} = Directives.prepare("////> lua\n1i32")

    assert_raise ArgumentError, ~r/unknown Spiral directive/, fn ->
      Directives.prepare("/// nope\n1i32")
    end

    assert_raise ArgumentError, ~r/unknown kernel flag --trace/, fn ->
      Directives.prepare("///- --trace\n1i32")
    end
  end

  test "package imports are kept and test flags are not code" do
    assert %{packages: ["../dice"], code: "inl main () : i32 =\n    1i32\n"} =
             Directives.prepare("///- --package ../dice --test\n1i32")
  end

  test "cell code must not contain a dib cell marker" do
    assert_raise ArgumentError, ~r/#!/, fn -> Directives.prepare("1i32\n#!fsharp\n") end
  end
end
