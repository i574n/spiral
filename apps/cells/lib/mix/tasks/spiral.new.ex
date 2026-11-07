defmodule Mix.Tasks.Spiral.New do
  use Mix.Task

  @shortdoc "Scaffold a Spiral project (src/package.spiproj, a units starter with c, wgsl and lua tests) gated by mix spiral.notebook --gate"

  @impl Mix.Task
  def run(args) do
    {opts, paths, _} = OptionParser.parse(args, strict: [name: :string])

    case paths do
      [path] ->
        name = opts[:name] || path |> Path.expand() |> Path.basename()

        case Spiral.Cells.NewProject.create(path, name) do
          {:ok, files} ->
            Enum.each(files, &IO.puts("spiral.new / #{Path.join(path, &1)}"))
            IO.puts("spiral.new / gate: pwsh #{Path.join([path, "scripts", "gate.ps1"])}")
            IO.puts("spiral.new / epic: #{Spiral.Cells.NewProject.epic_command(name)}")

          {:error, refusal} ->
            Mix.raise("spiral.new / " <> Spiral.Cells.NewProject.refusal_text(refusal))
        end

      _ ->
        Mix.raise("usage: mix spiral.new <path> [--name <project>]")
    end
  end
end
