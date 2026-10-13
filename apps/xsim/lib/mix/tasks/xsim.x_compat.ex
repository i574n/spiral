defmodule Mix.Tasks.Xsim.XCompat do
  use Mix.Task

  @shortdoc "Reports what X would rewrite or shorten in source files posted as threads"

  @impl true
  def run(paths) do
    if paths == [], do: Mix.raise("usage: mix xsim.x_compat FILE...")

    findings =
      Enum.flat_map(paths, fn path ->
        path |> File.read!() |> Xsim.XCompat.check(id: Path.basename(path)) |> Enum.map(&{path, &1})
      end)

    Enum.each(findings, fn {path, finding} -> Mix.shell().info(Xsim.XCompat.format(path, finding)) end)
    Mix.shell().info("x-compat: #{length(findings)} finding(s) in #{length(paths)} file(s)")
    if findings != [], do: exit({:shutdown, 1})
  end
end
