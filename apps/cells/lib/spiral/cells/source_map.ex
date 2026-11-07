defmodule Spiral.Cells.SourceMap do
  @spec remap(String.t(), String.t(), String.t(), String.t()) :: String.t()
  def remap(message, program, source, source_path), do: Spiral.Cells.Domain.source_remap(message, program, source, source_path)
end
