defmodule Spiral.Kino.TargetAuditTest do
  use ExUnit.Case, async: false

  alias Spiral.Kino.{Document, Notebook}

  @moduletag :target_audit
  @moduletag timeout: 3_600_000

  @lib Path.expand("../../../../../lib/spiral", __DIR__)

  @targets [
    {"rust_host", nil},
    {"c", "c"},
    {"cpp", "cpp"},
    {"delphi", "delphi"},
    {"fsharp", "fsharp"},
    {"python", "python"},
    {"cuda", "cuda"},
    {"typescript", "typescript"},
    {"lua", "lua"},
    {"gleam", "gleam"},
    {"gleam_javascript", "gleam -t javascript"},
    {"zig", "zig"},
    {"lean", "lean"},
    {"wgsl", "wgsl"}
  ]

  defp block(name, nil, body), do: "test #{name} =\n    #{body}\n"
  defp block(name, target, body), do: "///> #{target}\ntest #{name} =\n    #{body}\n"

  defp bodies(name) when name in ["cpp", "gleam_javascript"] do
    {~s(if dyn 1i32 <> 2i32 then failwith "__assert_eq { actual = 1; expected = 2 }"), ~s(if dyn 2i32 <> 2i32 then failwith "__assert_eq { actual = 2; expected = 2 }")}
  end

  defp bodies("wgsl"), do: {"1i32", "0i32"}

  defp bodies(_name), do: {"1i32 |> _assert_eq 2i32", "2i32 |> _assert_eq 2i32"}

  defp audit_source do
    tests =
      Enum.flat_map(@targets, fn {name, target} ->
        {failing, passing} = bodies(name)
        [block("#{name}_fails", target, failing), block("#{name}_passes", target, passing)]
      end)

    Enum.join(["/// # target audit\ntest target_audit static =\n    open testing\n" | tests], "\n")
  end

  test "every target fails a failing assertion with its text and passes its twin, or is unsupported; never a false pass" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("target_audit")
    doc = Document.parse_spi(audit_source(), "")
    evaluation = Notebook.evaluate(doc, spiral_lib: @lib, root: dir, plan: :tests, memo: false, timeout: 900_000)
    rows = Map.new(evaluation.report["tests"], &{&1["name"], &1})

    verdicts =
      for {name, _target} <- @targets do
        failing = rows["#{name}_fails"]
        passing = rows["#{name}_passes"]
        message = case Map.get(evaluation.verdicts, failing["index"]) do
          {:failed, text} -> text
          {:unsupported, text} -> text
          _ -> ""
        end

        verdict =
          cond do
            failing["status"] == "passed" -> :false_pass
            failing["status"] == "unsupported" and passing["status"] in ["unsupported", "passed"] -> :unsupported
            failing["status"] == "failed" and passing["status"] == "passed" and (message =~ "actual = 1" or name == "wgsl") -> :ok
            failing["status"] == "failed" and passing["status"] == "passed" -> :failed_without_assertion_text
            true -> {:twin_not_passing, passing["status"], passing["message"]}
          end

        IO.puts("target audit #{name}: failing=#{failing["status"]} passing=#{passing["status"]} -> #{inspect(verdict)} #{String.slice(message, 0, 160) |> String.replace("\n", " ")}")
        {name, verdict}
      end

    assert Enum.filter(verdicts, fn {_, verdict} -> verdict == :false_pass end) == []
    assert Enum.reject(verdicts, fn {_, verdict} -> verdict in [:ok, :unsupported] end) == []
  end
end
