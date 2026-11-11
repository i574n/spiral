defmodule Spiral.Cells.CompilerBannerParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.{CompilerClient, CompilerDaemon}

  defp ping_oracle("spiral-cells\t1\t" <> rest) do
    case String.split(rest, "\t") do
      [pid, stamp | _] ->
        case Integer.parse(stamp) do
          {stamp, ""} -> {:ok, stamp, String.to_integer(pid)}
          _ -> {:occupied, "unreadable banner"}
        end

      _ ->
        {:occupied, "unreadable banner"}
    end
  end

  defp ping_oracle(other), do: {:occupied, String.trim(other)}

  defp dll_oracle("spiral-cells\t1\t" <> rest) do
    case String.split(String.trim(rest), "\t") do
      [_pid, _stamp, tag | _] -> {:dll, tag}
      _ -> :legacy
    end
  end

  defp dll_oracle(_other), do: :other

  defp dll(line) do
    case CompilerClient.banner(line) do
      {"banner", _pid, _stamp, tag} -> {:dll, tag}
      {"other", _, _, _} -> :other
      _ -> :legacy
    end
  end

  @lines [
    "spiral-cells\t1\t4120\t1794300000\tbun-1.4.4",
    "spiral-cells\t1\t4120\t1794300000\ttag\textra",
    "spiral-cells\t1\t4120\t1794300000",
    "spiral-cells\t1\t4120",
    "spiral-cells\t1\t",
    "spiral-cells\t1",
    "spiral-cells\t2\t4120\t1794300000\ttag",
    "status\t1\t2",
    "hello",
    ""
  ]

  test "the Spiral banner decode matches the old ping and toolchain-tag parses on every banner shape" do
    for line <- [CompilerDaemon.banner() | @lines], trimmed = String.trim(line) do
      assert CompilerClient.ping_result(trimmed) == ping_oracle(trimmed), "ping #{inspect(line)}"
      assert dll(trimmed) == dll_oracle(trimmed), "dll #{inspect(line)}"
    end
  end

  test "a banner with a non-numeric pid or stamp reads as unreadable instead of raising" do
    assert CompilerClient.ping_result("spiral-cells\t1\tx\t5\ttag") == {:occupied, "unreadable banner"}
    assert CompilerClient.ping_result("spiral-cells\t1\t77\tx") == {:occupied, "unreadable banner"}
  end
end
