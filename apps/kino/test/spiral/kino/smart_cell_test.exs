defmodule Spiral.Kino.SmartCellTest do
  use ExUnit.Case, async: true

  import Kino.Test

  alias Spiral.Kino.SmartCell

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
    test "default backend, only the timeout is emitted" do
      source = SmartCell.to_source(%{"source" => "1i32 + 2\n", "timeout" => 60})

      assert source ==
               Enum.join(
                 [
                   "Spiral.Kino.eval!(",
                   ~s(  ~S"""),
                   "  1i32 + 2",
                   ~s(  """,),
                   "  timeout: 60000",
                   ")"
                 ],
                 "\n"
               )

      assert eval_source(source) == {"1i32 + 2\n", [timeout: 60_000]}
    end

    test "all options" do
      attrs = %{
        "source" => "console.write_line \"hi\"\n",
        "backend" => "rust",
        "builder_args" => " -d chrono ",
        "timeout" => "120",
        "print_code" => true
      }

      assert eval_source(SmartCell.to_source(attrs)) ==
               {"console.write_line \"hi\"\n",
                [backend: "rust", builder_args: "-d chrono", timeout: 120_000, print_code: true]}
    end

    test "builder args are dropped for the default backend; bad values fall back" do
      attrs = %{
        "source" => "x",
        "backend" => "nope",
        "builder_args" => "-d x",
        "timeout" => "abc"
      }

      assert eval_source(SmartCell.to_source(attrs)) == {"x\n", [timeout: 300_000]}
    end

    test "empty source generates no code" do
      assert SmartCell.to_source(%{"source" => "  \n"}) == ""
      assert SmartCell.to_source(%{}) == ""
    end

    test "round-trips tricky code exactly (heredoc path)" do
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

    test "round-trips code containing triple quotes and CR (escaped path)" do
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
          "backend" => "lua",
          "timeout" => 30
        })

      assert Code.format_string!(source) |> IO.iodata_to_binary() == source
    end
  end

  describe "cell lifecycle" do
    test "starts with defaults and a sample program" do
      {kino, source} = start_smart_cell!(SmartCell, %{})

      assert source =~ "Spiral.Kino.eval!("
      assert source =~ "square 7i32"

      assert %{fields: fields, backends: backends} = connect(kino)

      assert fields == %{
               "backend" => "fsharp",
               "builder_args" => "",
               "timeout" => 300,
               "print_code" => false
             }

      assert Enum.map(backends, & &1.id) == Spiral.Kino.Directives.backend_ids()
    end

    test "restores attrs, reacts to UI events and editor changes" do
      attrs = %{"source" => "1i32", "backend" => "lua", "timeout" => 10}
      {kino, _source} = start_smart_cell!(SmartCell, attrs)

      push_event(kino, "update_field", %{"field" => "backend", "value" => "gleam"})
      assert_broadcast_event(kino, "update", %{"fields" => %{"backend" => "gleam"}})
      assert_smart_cell_update(kino, %{"backend" => "gleam", "source" => "1i32"}, source)
      assert source =~ ~s(backend: "gleam")

      push_event(kino, "update_field", %{"field" => "timeout", "value" => "42"})
      assert_smart_cell_update(kino, %{"timeout" => 42}, source)
      assert source =~ "timeout: 42000"

      push_event(kino, "update_field", %{"field" => "print_code", "value" => true})
      assert_smart_cell_update(kino, %{"print_code" => true}, source)
      assert source =~ "print_code: true"

      push_smart_cell_editor_source(kino, "2i32")
      assert_smart_cell_update(kino, %{"source" => "2i32"}, source)
      assert source =~ "  2i32\n"
    end
  end
end
