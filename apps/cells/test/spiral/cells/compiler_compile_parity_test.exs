defmodule Spiral.Cells.CompilerCompileParityTest do
  use ExUnit.Case, async: true

  alias Spiral.Cells.CompilerClient

  defp credit(queue) do
    case Integer.parse(queue) do
      {ms, ""} when ms >= 0 -> ms
      _ -> 0
    end
  end

  defp oracle("ok\t" <> rest) do
    case String.split(rest, "\t") do
      [revision, queue] -> {{:ok, revision}, credit(queue)}
      [revision] -> {{:ok, revision}, 0}
      _ -> {{:error, "unexpected compiler reply: ok\t#{rest}"}, 0}
    end
  end

  defp oracle("error\ttimeout"), do: {{:error, :timeout}, 0}
  defp oracle("error\ttimeout\t" <> queue), do: {{:error, :timeout}, credit(queue)}

  defp oracle("error\t" <> rest) do
    with [queue, message] <- String.split(rest, "\t", parts: 2),
         {ms, ""} when ms >= 0 <- Integer.parse(queue) do
      {{:error, message}, ms}
    else
      _ -> {{:error, rest}, 0}
    end
  end

  defp oracle(other), do: {{:error, "unexpected compiler reply: #{other}"}, 0}

  defp spiral(line) do
    Process.put(:spiral_cells_queue_ms, 0)
    result = CompilerClient.compile_result(line)
    {result, Process.get(:spiral_cells_queue_ms)}
  end

  test "the Spiral compile reply decode matches the old hand parse, queue credit included, on every reply shape" do
    lines = [
      "ok\tr1",
      "ok\tr1\t7",
      "ok\tr1\t7\textra",
      "ok\t",
      "ok\tr1\t",
      "ok\tr1\tx",
      "okay\tr1",
      "error",
      "error\t",
      "error\ttimeout",
      "error\ttimeout\t",
      "error\ttimeout\t12",
      "error\ttimeout\ta\tb",
      "error\t5\tno\tmain",
      "error\t5\t",
      "error\tbare text",
      "error\t-3\tmsg",
      "error\t5",
      "weird",
      ""
    ]

    for line <- lines, do: assert(spiral(line) == oracle(line), "line #{inspect(line)}")
  end
end
