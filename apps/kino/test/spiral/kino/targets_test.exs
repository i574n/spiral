defmodule Spiral.Kino.TargetsTest do
  use ExUnit.Case, async: false

  alias Spiral.Kino.{ProcessError, Targets, Toolchain}

  defp deadline, do: System.monotonic_time(:millisecond) + 30_000

  defp run_target(output) do
    Targets.run(
      %{tool: :lua},
      "unused",
      [target: fn _ -> {:ok, %{exit_status: 0, output: output, duration_ms: 1}} end],
      30_000,
      deadline()
    )
  end

  test "command_result output is kept and a trace line is dropped" do
    inner = JSON.encode!(%{"code" => "return 1", "extension" => "lua", "output" => "printed"})
    outer = "12:44:21 spiral.main / { args = [] }\n" <> JSON.encode!(%{"command_result" => inner})

    assert {:ok, %{stdout: "printed"}} = run_target(outer)
  end

  test "an empty command_result output does not fall back to the generated code" do
    inner = JSON.encode!(%{"code" => "return 1", "extension" => "lua", "output" => ""})
    outer = JSON.encode!(%{"command_result" => inner})

    assert {:ok, %{stdout: ""}} = run_target(outer)
  end

  test "a top-level output field is the cell stdout" do
    text =
      JSON.encode!(%{
        "extension" => "rs",
        "code" => "fn main() {}",
        "code_path" => "main.rs",
        "output" => "hello"
      })

    assert {:ok, %{stdout: "hello"}} = run_target(text)
  end

  test "plain builder text stays as stdout" do
    assert {:ok, %{stdout: "contract"}} = run_target("contract\n")
  end

  test "a trace stays when the json output is empty" do
    inner = JSON.encode!(%{"code" => "return 1", "extension" => "lua", "output" => ""})

    outer =
      "1" <>
        <<0x1B>> <>
        "[91mw" <>
        <<0x1B>> <>
        "[39m spiral.process_lua / note / kept\n" <>
        JSON.encode!(%{"command_result" => inner})

    assert {:ok, %{stdout: "1w spiral.process_lua / note / kept"}} = run_target(outer)
  end

  test "a c cell's process exit is the value" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("c-cell")
    path = Path.join(dir, "main.c")
    File.write!(path, "int main(void) { return 7; }\n")

    assert {:ok, %{stdout: "", value: "7"}} =
             Targets.run(%{tool: :c}, path, [], 30_000, deadline())
  end

  test "an empty spiral result with an error trace fails the cell" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("spiral-error")

    fake =
      cc!(dir, "fake", ~S"""
      #include <stdio.h>
      int main(void) {
        printf("1c spiral.process_rust / cargo error / edition2024\n");
        printf("{\"extension\":\"rs\",\"code\":\"\",\"output\":\"\"}\n");
        return 0;
      }
      """)

    lua = Path.join(dir, "main.lua")
    File.write!(lua, "return 1\n")

    assert {:error, %ProcessError{message: message}} =
             Targets.run(%{tool: :lua}, lua, [spiral: fake], 30_000, deadline())

    assert message =~ "edition2024"
    refute message =~ "extension"
  end

  test "a cpp executable's exit code is the value" do
    dir = Spiral.Kino.TestHelpers.tmp_dir!("cpp-cell")
    path = Path.join(dir, "main.cpp")
    File.write!(path, "int main() { return 7; }\n")
    _built = cc!(dir, "main.cpp.out", "int main(void) { return 7; }\n")
    fake = cc!(dir, "spiral-fake", "int main(void) { return 0; }\n")

    assert {:ok, %{stdout: "", value: "7"}} =
             Targets.run(%{tool: :cpp}, path, [spiral: fake], 30_000, deadline())
  end

  defp cc!(dir, name, source) do
    cc = Toolchain.cc([])
    assert is_binary(cc)
    src = Path.join(dir, name <> ".c")
    exe = Path.join(dir, name <> if(match?({:win32, _}, :os.type()), do: ".exe", else: ""))
    File.write!(src, source)
    {output, status} = System.cmd(cc, ["-o", exe, src], stderr_to_stdout: true)
    assert status == 0, output
    exe
  end
end
