defmodule Xsim.MixProject do
  use Mix.Project

  def project do
    [
      app: :xsim,
      version: "0.1.0",
      elixir: "~> 1.18",
      start_permanent: Mix.env() == :prod,
      deps: [{:spiral_kino, path: "../kino"}],
      description: "Deterministic X-like event simulator that battle-tests Kino"
    ]
  end

  def application do
    [extra_applications: [:logger, :crypto]]
  end
end
