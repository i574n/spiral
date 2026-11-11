defmodule Spiral.Cells.CompilerPoolParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.CompilerClient

  defp free_reading(text) do
    case Integer.parse(text) do
      {mb, ""} -> mb
      _ -> nil
    end
  end

  defp oracle(line) do
    with "pool\t" <> rest <- line,
         [served, refused, peak, free] <- String.split(String.trim(rest), "\t"),
         {served, ""} <- Integer.parse(served),
         {refused, ""} <- Integer.parse(refused),
         {peak, ""} <- Integer.parse(peak) do
      [%{served: served, refused_growth: refused, peak_workers: peak, last_free_mb: free_reading(free)}]
    else
      _ -> []
    end
  end

  test "the Spiral pool decode matches the old hand parse on every reply shape the daemon sends and on malformed lines" do
    lines = [
      "pool\t12\t1\t3\t2048",
      "pool\t0\t0\t1\t-",
      "pool\t0\t0\t1\t",
      "pool\t5\t0\t2\tabc",
      "pool\t1\tx\t3\t5",
      "pool\t1\t2\t3",
      "pool\t1\t2\t3\t4\t5",
      "pool",
      "status\t1\t2",
      ""
    ]

    for line <- lines, trimmed = String.trim(line), do: assert(CompilerClient.pool_fields(trimmed) == oracle(trimmed), "line #{inspect(line)}")
  end

  test "a signed count is no longer read as a pool row, since the daemon only sends digits" do
    assert CompilerClient.pool_fields("pool\t-1\t0\t1\t-") == []
  end
end
