defmodule Spiral.Kino.LispTest do
  use ExUnit.Case, async: true
  alias Spiral.Kino.Lisp

  test "a ///! lisp cell becomes Spiral, its directive lines kept on top" do
    code = "///! lisp\n///> rust\n; a comment\n(inl main () i32 (if (= 1i64 1i64) 0i32 1i32))\n"
    expanded = Lisp.expand(code)
    assert String.starts_with?(expanded, "///> rust\n")
    assert expanded =~ "inl main () : i32 ="
    assert expanded =~ "if 1i64 = 1i64 then 0i32 else 1i32"
  end

  test "other cells are left alone" do
    assert Lisp.expand("inl main () = 0i32\n") == "inl main () = 0i32\n"
    refute Lisp.lisp?("// ///! lisp\n")
  end

  test "what precedes the marker (earlier cells of a notebook program) stays" do
    expanded = Lisp.expand("inl helper () = 1i32
///! lisp
(inl main () i32 0i32)
")
    assert String.starts_with?(expanded, "inl helper () = 1i32\n")
    assert expanded =~ "inl main () : i32 ="
  end
end
