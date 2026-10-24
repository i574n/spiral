defmodule Mix.Tasks.Spiral.XCompat do
  use Mix.Task

  @shortdoc "Reports what X would rewrite in Spiral sources; always exits 0"

  @extensions [".spi", ".spir", ".livemd"]

  @impl true
  def run(args) do
    files = args |> Enum.flat_map(&sources/1) |> Enum.uniq()

    findings =
      for file <- files, finding <- file |> File.read!() |> Spiral.Cells.XCompat.rewrites(Spiral.Cells.XCompat.profile_for(file)) do
        Mix.shell().info(Spiral.Cells.XCompat.format(file, finding))
        finding
      end

    by_kind = findings |> Enum.frequencies_by(& &1.kind) |> Enum.sort() |> Enum.map_join(", ", fn {kind, n} -> "#{kind} #{n}" end)
    Mix.shell().info("x-compat report: #{length(findings)} finding(s) in #{length(files)} file(s)" <> if(by_kind == "", do: "", else: " (#{by_kind})"))
  end

  defp sources(path) do
    cond do
      File.dir?(path) -> path |> String.replace("\\", "/") |> Path.join("**/*") |> Path.wildcard() |> Enum.filter(&(Path.extname(&1) in @extensions)) |> Enum.sort()
      File.regular?(path) -> [path]
      true -> []
    end
  end
end