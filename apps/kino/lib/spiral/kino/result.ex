defmodule Spiral.Kino.Result do
  defstruct value: nil,
            stdout: "",
            html: [],
            outputs: [],
            source: "",
            exit_status: nil,
            duration_ms: nil,
            log: ""

  @type t :: %__MODULE__{
          value: String.t() | nil,
          stdout: String.t(),
          html: [String.t()],
          outputs: [Spiral.Kino.Notebook.output()],
          source: String.t(),
          exit_status: integer() | nil,
          duration_ms: non_neg_integer() | nil,
          log: String.t()
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

defimpl Kino.Render, for: Spiral.Kino.Result do
  def to_livebook(%Spiral.Kino.Result{value: nil}) do
    Kino.Text.new("(no value)", style: [color: "#888"]) |> Kino.Render.to_livebook()
  end

  def to_livebook(%Spiral.Kino.Result{value: value}) do
    Kino.Text.new(value, terminal: true) |> Kino.Render.to_livebook()
  end
end

defmodule Spiral.Kino.SpiralError do
  defexception [:message, :details, :result]
end

defmodule Spiral.Kino.TimeoutError do
  defexception [:message, :timeout, :output]
end

defmodule Spiral.Kino.ProcessError do
  defexception [:message, :exit_status, :output]
end
