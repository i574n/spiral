defmodule Spiral.Cells.UnitFirstTest do
  use ExUnit.Case, async: false

  alias Spiral.Cells.Result

  defp counting_compile(accept) do
    parent = self()

    fn %{backend: "Rust", source: source} ->
      send(parent, {:compiled, source})
      if accept.(source), do: {:ok, "fn main() {}\n"}, else: {:error, "Got: ()\nExpected: i32"}
    end
  end

  defp compiles do
    receive do
      {:compiled, source} -> [source | compiles()]
    after
      0 -> []
    end
  end

  defp run_ok(_ctx), do: {:ok, %{exit_status: 0, output: "", duration_ms: 4}}

  test "a unit-result --test cell reaches the compiler once, already ended by 0i32" do
    assert {:ok, %Result{exit_status: 0}} =
             Spiral.Cells.run("///> rust\n_assert_eq 1i32 1i32",
               test_cell: true,
               compile: counting_compile(&String.ends_with?(&1, "0i32\n")),
               rustc: fn _ -> :ok end,
               execute: &run_ok/1,
               target: fn _ -> raise "target" end
             )

    assert [source] = compiles()
    assert String.ends_with?(source, "0i32\n")
  end

  test "when the ended program does not compile, the cell compiles as written and reports that error" do
    assert {:error, _} =
             Spiral.Cells.run("///> rust\nbroken",
               test_cell: true,
               compile: fn %{backend: "Rust"} -> {:error, "unbound broken"} end,
               rustc: fn _ -> :ok end,
               execute: &run_ok/1,
               target: fn _ -> raise "target" end
             )
  end
end
