defmodule Spiral.Cells.Application do
  use Application

  @impl true
  def start(_type, _args) do
    Spiral.Cells.Domain.ensure!()
    Kino.SmartCell.register(Spiral.Cells.SmartCell)

    children = [
      {Task.Supervisor, name: Spiral.Cells.TaskSupervisor}
    ]

    Supervisor.start_link(children, strategy: :one_for_one, name: Spiral.Cells.Supervisor)
  end
end
