defmodule Mix.Tasks.Spiral.CellBudget do
  use Mix.Task

  @shortdoc "Reports what a renderer would rewrite in Spiral sources and which definitions exceed the cell budget; --check fails on the latter"

  @extensions [".spi", ".spir", ".livemd"]
  @skipped ["target", "node_modules", "deps", "bin", "obj", "_build", ".git", ".history"]

  @impl true
  def run(args) do
    {options, paths} = OptionParser.parse!(args, strict: [check: :boolean])
    files = paths |> Enum.flat_map(&sources/1) |> Enum.uniq()

    findings =
      for file <- files, {profile, source} <- [{Spiral.Cells.CellBudget.profile_for(file), File.read!(file)}],
          finding <- Spiral.Cells.CellBudget.rewrites(source, profile) ++ Spiral.Cells.CellBudget.over_budget(source, profile) do
        Mix.shell().info(Spiral.Cells.CellBudget.format(file, finding))
        finding
      end

    by_kind = findings |> Enum.frequencies_by(& &1.kind) |> Enum.sort() |> Enum.map_join(", ", fn {kind, n} -> "#{kind} #{n}" end)
    Mix.shell().info("cell-budget report: #{length(findings)} finding(s) in #{length(files)} file(s)" <> if(by_kind == "", do: "", else: " (#{by_kind})"))
    over_budget = Enum.count(findings, &(&1.kind == :over_budget))
    if options[:check] && over_budget > 0, do: Mix.raise("cell-budget: #{over_budget} definition(s) over the cell budget; split them")
  end

  defp sources(path) do
    cond do
      File.dir?(path) ->
        root = String.replace(path, "\\", "/")

        root
        |> Path.join("**/*")
        |> Path.wildcard()
        |> Enum.filter(&(Path.extname(&1) in @extensions))
        |> Enum.reject(&(&1 |> Path.relative_to(root) |> Path.split() |> Enum.any?(fn part -> part in @skipped end)))
        |> Enum.sort()

      File.regular?(path) -> [path]
      true -> []
    end
  end
end