defmodule Spiral.CellBudgetRuledTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.{CellBudget, CellBudgetRuled}

  defp w(text), do: CellBudget.cell_weight(text, CellBudget.default_profile())
  defp ruled(block), do: CellBudgetRuled.ruled_weight(block, CellBudget.default_profile())

  test "rule 2: a multi-line header is not counted, the body is" do
    block = ":= f (a : i32) (b : i32) : i32 =\n    a + b"
    assert ruled(block) == w("    a + b")
  end

  test "rule 2: a one-line definition counts only what follows its =" do
    assert ruled(":= g (x : i32) : i32 = x + 1") == w("x + 1")
  end

  test "rule 1: a flat dispatch counts its match line plus its longest arm" do
    block = ":= name (c : color) : string =\n    ?= c ?|\n    | Red => \"red\"\n    | Green => \"green\""
    assert ruled(block) == w("?= c ?|") + w("| Green => \"green\"")
  end

  test "rule 1 counter-example: an arm with a binding counts the whole body" do
    body = "    ?= c ?|\n    | Red => := x = 1\n    | Green => \"green\""
    assert ruled(":= name (c : color) : string =\n" <> body) == w(body)
  end

  test "rule 1: a flat backend_switch counts its switch line plus its longest arm" do
    block =
      ":= format (d : date) : string =\n    backend_switch {\n        Gleam = \\ () => format_gleam d\n" <>
        "        Rust = \\ () => format_rust d\n        Python = \\ () => format_python_long_name d\n    }"

    assert ruled(block) == w("backend_switch {") + w("Python = \\ () => format_python_long_name d")
  end

  test "rule 1 counter-example: a backend_switch with a multi-line arm counts the whole body" do
    body = "    backend_switch {\n        Gleam = \\ () =>\n            format_gleam d\n        Rust = \\ () => format_rust d\n    }"
    assert ruled(":= format (d : date) : string =\n" <> body) == w(body)
    nested = "    backend_switch {\n        Gleam = \\ () => ? d ?> a |: b\n        Rust = \\ () => format_rust d\n    }"
    assert ruled(":= format (d : date) : string =\n" <> nested) == w(nested)
  end

  test "data: a type declaration and a constant record literal are exempt" do
    assert ruled(":| color =\n    | Red\n    | Green") == 0
    record = ":= family_root () : row =\n    { name = \"invoice\"; lines = [ Line 1i32; Line 2i32 ]; total = 10i32 }"
    assert ruled(record) == 0
  end

  test "data counter-example: a literal with a function call is measured" do
    body = "    { name = \"invoice\"; total = sum_of lines }"
    assert ruled(":= family_root () : row =\n" <> body) == w(body)
  end

  test "data counter-example: a paren-adjacent call is measured too" do
    body = "    { name = \"invoice\"; total = sum_of(lines) }"
    assert ruled(":= family_root () : row =\n" <> body) == w(body)
  end

  test "data: nominal constructors declared with :! build data, other calls stay code" do
    body = "    { module = module_id \"generated_x\"; tag = tag_name \"Invoice\"; kind = Signed }"
    block = ":= family_root () : row =\n" <> body
    assert CellBudgetRuled.ruled_weight(block, CellBudget.default_profile(), ["module_id", "tag_name"]) == 0
    assert ruled(block) == w(body)
    assert CellBudgetRuled.ruled_weight(block, CellBudget.default_profile(), ["module_id"]) == w(body)
  end

  test "declared nominals are the :! names of a source" do
    source = ":! module_id = string\n:! amount_data = ()\n:! definition_name form = string\n:| kind =\n    | A\n:= f () = 1\n"
    assert CellBudgetRuled.declared_nominals(source) == ["module_id", "amount_data", "definition_name"]
  end

  test "a documented definition gets the rules, its doc lines are not measured" do
    block = "/// ### case_name\n/// the case name\n:= g (x : i32) : i32 = x + 1"
    assert ruled(block) == w("x + 1")
    assert ruled("/// a color\n:| color =\n    | Red") == 0
  end

  test "a test marker line before a test block keeps it unruled" do
    block = "///> rust\n:# a_test =\n    testing.expect !+ \"x\""
    assert ruled(block) == w(block)
  end

  test "templates: literal-only text counts its heaviest piece" do
    block = ":= header () : string =\n    \"use x;\"\n    ++# \"fn main() {}\""
    assert ruled(block) == max(w("\"use x;\""), w("\"fn main() {}\""))
  end

  test "templates counter-example: interpolated logic is measured whole" do
    body = "    \"use \" ++# name ++# \";\""
    assert ruled(":= header (name : string) : string =\n" <> body) == w(body)
  end

  test "test blocks are measured unruled" do
    block = ":# a_test =\n    testing.expect !+ \"x\""
    assert ruled(block) == w(block)
  end
end
