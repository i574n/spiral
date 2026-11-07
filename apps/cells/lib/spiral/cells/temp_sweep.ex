defmodule Spiral.Cells.TempSweep do
  @moduledoc false

  @max_age_s 24 * 3600

  @spec root() :: String.t()
  def root, do: Path.join(System.tmp_dir!(), "spiral_cells")

  @spec sweep(String.t(), non_neg_integer(), integer()) :: [String.t()]
  def sweep(root \\ root(), max_age_s \\ @max_age_s, now \\ System.os_time(:second)) do
    case File.ls(root) do
      {:ok, names} ->
        for name <- Enum.sort(names),
            path = Path.join(root, name),
            older?(path, now - max_age_s),
            match?({:ok, _}, File.rm_rf(path)),
            do: path

      _ ->
        []
    end
  end

  defp older?(path, cutoff) do
    case File.stat(path, time: :posix) do
      {:ok, %{type: :directory, mtime: mtime}} -> mtime < cutoff
      _ -> false
    end
  end
end
