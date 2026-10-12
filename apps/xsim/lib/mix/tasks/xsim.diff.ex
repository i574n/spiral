defmodule Mix.Tasks.Xsim.Diff do
  use Mix.Task

  @shortdoc "Evaluate the first N cells of a .spi twice through Kino and show where the two results differ"

  @impl Mix.Task
  def run(args) do
    Mix.Task.run("app.start")
    {opts, _} = OptionParser.parse!(args, strict: [spi: :string, cells: :integer])
    spi = opts[:spi] || Mix.raise("missing --spi")
    doc = Spiral.Kino.Document.parse_spi(File.read!(spi), "")
    sources = for(%{kind: :spiral, source: s} <- doc.cells, do: s) |> Enum.take(opts[:cells] || 5)
    run_opts = [root: Path.dirname(Path.expand(spi)), spiral_lib: Path.dirname(Path.expand(spi))]
    eval = fn -> Spiral.Kino.Notebook.evaluate(%{cells: Enum.map(sources, &%{kind: :spiral, source: &1})}, run_opts) end
    a = eval.()
    b = eval.()
    last = length(sources) - 1
    IO.puts("XDIFF status a=#{inspect(a.status)} b=#{inspect(b.status)} verdict a=#{inspect(a.verdicts[last])} b=#{inspect(b.verdicts[last])}")

    for index <- 0..last, a.outputs[index] != b.outputs[index] do
      IO.puts("XDIFF cell #{index}\n  a=#{inspect(a.outputs[index], printable_limit: 600)}\n  b=#{inspect(b.outputs[index], printable_limit: 600)}")
    end

    IO.puts("XDIFF done identical=#{a.outputs == b.outputs}")
  end
end
