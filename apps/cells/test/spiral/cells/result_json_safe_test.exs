defmodule Spiral.Cells.ResultJsonSafeTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.Result

  test "an OEM-encoded byte in captured output becomes U+FFFD so the report still encodes" do
    oem = "agile notes " <> <<129>> <> " fixture"
    report = %{"file" => "notes_cli.spi", "failures" => [%{"test" => "lists_notes", "message" => oem}], "passed" => 3}
    assert_raise ErlangError, fn -> JSON.encode!(report) end
    encoded = JSON.encode!(Result.json_safe(report))
    assert encoded =~ "lists_notes"
    assert encoded =~ "agile notes � fixture"
  end

  test "valid UTF-8, numbers, atoms and structs pass through unchanged" do
    value = %{"name" => "agile notes ü", "n" => 3, "ok" => true, "kind" => :file, "at" => ~D[2026-11-09]}
    assert Result.json_safe(value) == value
  end

  test "a multi-byte character cut by tail truncation is replaced byte by byte, not dropped" do
    cut = binary_part("€", 1, 2)
    assert Result.json_safe(cut) == "��"
  end
end
