defmodule Spiral.Kino.SmartCellTest do
  use ExUnit.Case, async: true

  import Kino.Test

  alias Spiral.Kino.SmartCell

  @wait 5_000

  setup :configure_livebook_bridge

  defp eval_source(source) do
    ast =
      source
      |> Code.string_to_quoted!()
      |> Macro.prewalk(fn
        {{:., _, [{:__aliases__, _, [:Spiral, :Kino]}, :eval!]}, meta, args} ->
          {{:., meta, [{:__aliases__, meta, [:Kernel]}, :then]}, meta,
           [args, {:&, meta, [{:&, meta, [1]}]}]}

        other ->
          other
      end)

    {[code | rest], _} = Code.eval_quoted(ast)
    {code, List.flatten(rest)}
  end

  describe "to_source/1" do
    test "emits the timeout" do
      source = SmartCell.to_source(%{"source" => "1i32 + 2\n", "timeout" => 60})

      assert eval_source(source) == {"1i32 + 2\n", [timeout: 60_000]}
    end

    test "print_code is emitted only when set" do
      attrs = %{
        "source" => "console.write_line \"hi\"\n",
        "timeout" => "120",
        "print_code" => true
      }

      assert eval_source(SmartCell.to_source(attrs)) ==
               {"console.write_line \"hi\"\n", [timeout: 120_000, print_code: true]}
    end

    test "a bad timeout falls back to 300 seconds" do
      assert eval_source(SmartCell.to_source(%{"source" => "x", "timeout" => "abc"})) ==
               {"x\n", [timeout: 300_000]}
    end

    test "empty source generates no code" do
      assert SmartCell.to_source(%{"source" => "  \n"}) == ""
      assert SmartCell.to_source(%{}) == ""
    end

    test "round-trips tricky code exactly" do
      code =
        Enum.join(
          [
            ~S|inl f x = $"interp #{x} \n \\ \" '"|,
            "    indented   ",
            "",
            "\ttab",
            ~S|  ~S"""not at line start"""|,
            "end with backslash \\",
            ""
          ],
          "\n"
        )

      heredoc_code = String.replace(code, ~s("""), ~s(""))
      assert SmartCell.to_source(%{"source" => heredoc_code}) =~ ~s(~S""")
      assert {^heredoc_code, _} = eval_source(SmartCell.to_source(%{"source" => heredoc_code}))
    end

    test "round-trips code containing triple quotes and CR" do
      code = ~s(inl s = """x"""\r\n#{"\#{y}"} \\ end)
      source = SmartCell.to_source(%{"source" => code})
      refute source =~ ~s(~S""")
      assert {^code, _} = eval_source(source)
    end

    test "code without a trailing newline gets exactly one" do
      assert {"a\nb\n", _} = eval_source(SmartCell.to_source(%{"source" => "a\nb"}))
    end

    test "generated source is formatted Elixir" do
      source =
        SmartCell.to_source(%{
          "source" => "inl x = 1i32\n\nx\n",
          "timeout" => 30,
          "print_code" => true
        })

      assert Code.format_string!(source) |> IO.iodata_to_binary() == source
    end
  end

  describe "cell lifecycle" do
    test "starts with the sample program" do
      {kino, source} = start_smart_cell!(SmartCell, %{})

      assert source =~ "Spiral.Kino.eval!("
      assert source =~ "square 7i32"
      assert %{fields: fields} = connect(kino, nil, @wait)

      assert fields == %{
               "timeout" => 300,
               "print_code" => false
             }
    end

    test "restores attrs and follows the editor" do
      attrs = %{"source" => "1i32", "timeout" => 10, "print_code" => true}
      {kino, _source} = start_smart_cell!(SmartCell, attrs)

      push_event(kino, "update_field", %{"field" => "timeout", "value" => "42"})
      assert_smart_cell_update(kino, %{"timeout" => 42}, source, @wait)
      assert source =~ "timeout: 42000"

      push_event(kino, "update_field", %{"field" => "print_code", "value" => false})
      assert_smart_cell_update(kino, %{"print_code" => false}, source, @wait)
      refute source =~ "print_code"

      push_smart_cell_editor_source(kino, "2i32")
      assert_smart_cell_update(kino, %{"source" => "2i32"}, source, @wait)
      assert source =~ "  2i32\n"
    end
  end
end
