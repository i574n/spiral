defmodule Spiral.Kino.Application do
  use Application

  @impl true
  def start(_type, _args) do
    Spiral.Kino.Domain.ensure!()
    Kino.SmartCell.register(Spiral.Kino.SmartCell)

    children = [
      {Task.Supervisor, name: Spiral.Kino.TaskSupervisor}
    ]

    Supervisor.start_link(children, strategy: :one_for_one, name: Spiral.Kino.Supervisor)
  end
end
