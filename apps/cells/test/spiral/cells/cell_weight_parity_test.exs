defmodule Spiral.Cells.CellWeightParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.CellBudget

  @home Path.expand("../../../../../..", __DIR__)

  defp tracked_spi do
    for repo <- File.ls!(@home), dir = Path.join(@home, repo), File.exists?(Path.join(dir, ".git")),
        {out, 0} = System.cmd("git", ["-C", dir, "ls-files", "-z", "--", "*.spi"]),
        rel <- String.split(out, <<0>>, trim: true),
        file = Path.join(dir, rel),
        File.regular?(file),
        do: file
  end

  defp texts do
    case System.get_env("SPIRAL_CELL_WEIGHT_PARITY_CASES") do
      nil -> for file <- tracked_spi(), {_row, block} <- file |> File.read!() |> CellBudget.top_level_blocks(), do: {file, block}
      path -> for [file, _header, code] <- path |> File.read!() |> JSON.decode!(), do: {file, code}
    end
  end

  @tag timeout: 900_000
  test "the Spiral cell weight matches the host weight on every block of every tracked .spi" do
    cases = texts()
    differ = for {file, text} <- cases, (host = CellBudget.host_cell_weight(text)) != (spiral = CellBudget.cell_weight(text)), do: {file, host, spiral, String.slice(text, 0, 120)}
    IO.puts("cell weight parity: #{length(cases)} texts, #{length(differ)} differ")
    assert length(cases) > 1000
    assert differ == [], "first difference: #{differ |> List.first() |> inspect(printable_limit: 400)}"
  end
end
