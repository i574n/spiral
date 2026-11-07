defmodule Mix.Tasks.Spiral.Targets do
  use Mix.Task

  @shortdoc "List test blocks that name no ///> target and would run on the implicit default backend; --check fails when any exist"

  @notebook_extensions ~w(.spi .livemd)
  @skipped_dirs ~w(deps target node_modules _build dist .git)

  @impl Mix.Task
  def run(args) do
    Mix.Task.run("loadpaths")
    Spiral.Cells.Domain.ensure!()
    {opts, roots, _} = OptionParser.parse(args, strict: [check: :boolean])
    files = Enum.flat_map(roots, &notebooks/1)

    found =
      for file <- files, names = Spiral.Cells.Notebook.untargeted_tests(file), names != [] do
        IO.puts("#{file}: #{length(names)} untargeted: #{Enum.join(names, ", ")}")
        length(names)
      end

    IO.puts("spiral.targets: #{length(files)} notebooks, #{Enum.sum(found)} untargeted tests in #{length(found)} files")
    if opts[:check] && found != [], do: Mix.raise("untargeted test blocks found")
  end

  @doc false
  def notebooks(root) do
    cond do
      File.regular?(root) -> if Path.extname(root) in @notebook_extensions, do: [root], else: []
      File.dir?(root) -> root |> File.ls!() |> Enum.reject(&(&1 in @skipped_dirs)) |> Enum.sort() |> Enum.flat_map(&notebooks(Path.join(root, &1)))
      true -> []
    end
  end
end
