defmodule Spiral.Cells.ResultUnionTest do
  use ExUnit.Case, async: true
  alias Spiral.Cells.Result

  test "from_outputs folds values, streams and html the way the Elixir fold did" do
    outputs = [{:value, "a"}, {:stdout, "x\ny"}, {:stderr, "é!"}, {:value, "bc"}, {:html, "<p>"}, {:display, %{}}]
    r = Result.from_outputs(outputs, exit_status: 0)
    assert {r.value, r.stdout, r.html, r.exit_status, r.outputs} == {"a\nbc", "x\nyé!", ["<p>"], 0, outputs}
  end

  test "a run with no value keeps value nil and an empty stdout" do
    r = Result.from_outputs([{:html, "1"}, {:html, "2:3"}], [])
    assert {r.value, r.stdout, r.html} == {nil, "", ["1", "2:3"]}
  end

  test "the wire round-trips text holding the separator and multibyte characters" do
    wire = Result.outputs_wire([{:value, "k:v\n\t"}, {:stdout, "ação"}])
    assert Result.fields_of(Spiral.Cells.Domain.result_fields(wire)) == {"k:v\n\t", "ação", []}
  end
end
