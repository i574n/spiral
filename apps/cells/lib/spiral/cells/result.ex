defmodule Spiral.Cells.Result do
  defstruct value: nil,
            stdout: "",
            html: [],
            displays: [],
            outputs: [],
            source: "",
            exit_status: nil,
            duration_ms: nil,
            phases: %{},
            log: "",
            unavailable: []

  @type t :: %__MODULE__{
          value: String.t() | nil,
          stdout: String.t(),
          html: [String.t()],
          displays: [Spiral.Cells.Display.t()],
          outputs: [term()],
          source: String.t(),
          exit_status: integer() | nil,
          duration_ms: non_neg_integer() | nil,
          phases: %{optional(atom()) => non_neg_integer()},
          log: String.t(),
          unavailable: [String.t()]
        }

  def from_outputs(outputs, fields) do
    %__MODULE__{
      value:
        outputs
        |> Enum.flat_map(fn
          {:value, value} -> [value]
          _ -> []
        end)
        |> case do
          [] -> nil
          values -> Enum.join(values, "\n")
        end,
      stdout:
        Enum.map_join(outputs, fn
          {name, text} when name in [:stdout, :stderr] -> text
          _ -> ""
        end),
      html:
        Enum.flat_map(outputs, fn
          {:html, html} -> [html]
          _ -> []
        end),
      outputs: outputs
    }
    |> struct!(fields)
  end
end

defimpl Kino.Render, for: Spiral.Cells.Result do
  def to_livebook(%Spiral.Cells.Result{value: nil}) do
    Kino.Text.new("(no value)", style: [color: "#888"]) |> Kino.Render.to_livebook()
  end

  def to_livebook(%Spiral.Cells.Result{value: value}) do
    Kino.Text.new(value, terminal: true) |> Kino.Render.to_livebook()
  end
end

defmodule Spiral.Cells.SpiralError do
  defexception [:message, :details, :result]
end

defmodule Spiral.Cells.TimeoutError do
  defexception [:message, :timeout, :output]
end

defmodule Spiral.Cells.ProcessError do
  defexception [:message, :exit_status, :output, :reason]
end
