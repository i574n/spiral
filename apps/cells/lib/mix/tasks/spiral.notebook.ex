defmodule Mix.Tasks.Spiral.Notebook do
  use Mix.Task

  @shortdoc "Run Spiral notebooks (.livemd, or a .spi with its _real.spir) and report their test blocks; --gate runs them memo-off into a scratch report dir and retires the compilers"

  @impl Mix.Task
  def run(args) do
    Mix.Task.run("loadpaths")
    Spiral.Cells.MemoryGuard.start()
    Spiral.Cells.Domain.ensure!()
    gate? = "--gate" in args
    gate_report_dir = Path.join(System.tmp_dir!(), "spiral-cells-gate-#{System.unique_integer([:positive])}")
    args = if gate?, do: gate_args(args, gate_report_dir), else: args
    {status, lines} =
      case Spiral.Cells.Server.try_execute(args) do
        {:served, reply} -> reply
        :unavailable -> Spiral.Cells.NotebookCli.execute(args)
      end
    Enum.each(lines, &IO.puts/1)

    cond do
      gate? ->
        File.rm_rf!(gate_report_dir)
        Spiral.Cells.CompilerClient.shutdown()

      System.get_env("SPIRAL_CELLS_WARM") != "0" and System.get_env("SPIRAL_CELLS_COMPILER") != "process" ->
        Spiral.Cells.CompilerClient.prestart()

      true ->
        :ok
    end

    case status do
      :ok -> :ok
      {:error, message} -> Mix.raise(message)
    end
  end

  @doc false
  def gate_args(args, report_dir) do
    args = Enum.reject(args, &(&1 == "--gate")) ++ ["--no-memo", "--no-html"]
    if Enum.any?(args, &(&1 in ["--output-dir", "--output-path"])), do: args, else: args ++ ["--output-dir", report_dir]
  end
end
