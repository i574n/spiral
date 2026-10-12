Code.require_file(Path.expand("spi/domain_compiler.ex", __DIR__))

defmodule Spiral.Kino.MixProject do
  use Mix.Project

  @version "0.1.0"

  def project do
    [
      app: :spiral_kino,
      version: @version,
      elixir: "~> 1.18",
      compilers: [:spiral_domain] ++ Mix.compilers(),
      start_permanent: Mix.env() == :prod,
      deps: deps(),
      description: "Spiral language smart cell for Livebook",
      docs: [main: "readme", extras: ["README.md"]]
    ]
  end

  def application do
    [
      mod: {Spiral.Kino.Application, []},
      extra_applications: [:logger]
    ]
  end

  defp deps do
    [
      {:kino, "~> 0.19.1"}
    ]
  end
end
