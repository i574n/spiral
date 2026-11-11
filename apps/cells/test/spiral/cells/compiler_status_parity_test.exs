defmodule Spiral.Cells.CompilerStatusParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.CompilerClient

  @nil_row %{pid: nil, stamp: nil, idle_min: nil, queued: nil, retiring: nil, owner: nil}

  defp oracle("status\t" <> rest) do
    case String.split(String.trim(rest), "\t") do
      [pid, stamp, idle, queued, retiring | owner] ->
        %{pid: pid, stamp: stamp, idle_min: idle, queued: queued, retiring: retiring, owner: Enum.join(owner, " ")}

      _ ->
        @nil_row
    end
  end

  defp oracle(_), do: @nil_row

  test "the Spiral status decode matches the old hand parse on every reply shape the daemon and older daemons send" do
    lines = [
      "status\t4120\t1794300000\t3\t0\tfalse\tmicroblog lane",
      "status\t4120\t1794300000\t3\t2\t1794300123\t",
      "status\t4120\t1794300000\t0\t0\tfalse",
      "status\t4120\t1794300000\t0\t0\tfalse\ta\tb\tc",
      "status\t4120\t1794300000\t0\t0",
      "status",
      "status\t",
      "spiral-cells\t1\t4120\t1794300000",
      "ok\tabc",
      ""
    ]

    for line <- lines, do: assert(CompilerClient.status_fields(line) == oracle(line), "line #{inspect(line)}")
  end

  test "an empty pid field reads as a daemon that did not answer" do
    assert CompilerClient.status_fields("status\t\t1\t0\t0\tfalse\tx") == @nil_row
  end
end
