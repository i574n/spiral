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
    {value, stdout, html} = outputs |> outputs_wire() |> Spiral.Cells.Domain.result_fields() |> fields_of()
    %__MODULE__{value: value, stdout: stdout, html: html, outputs: outputs} |> struct!(fields)
  end

  @tags %{value: "v", stdout: "o", stderr: "e", html: "h"}

  @doc false
  def outputs_wire(outputs) do
    Enum.map_join(outputs, fn
      {name, text} when is_map_key(@tags, name) -> field(@tags[name], to_string(text))
      _ -> ""
    end)
  end

  @doc false
  def fields_of(wire) do
    {first, value, rest} = take_field(wire)
    {"o", stdout, rest} = take_field(rest)
    {if(first == "v", do: value), stdout, html_fields(rest, [])}
  end

  defp field(tag, text), do: tag <> Integer.to_string(byte_size(text)) <> ":" <> text

  @doc false
  def take_field(<<tag::binary-size(1), rest::binary>>) do
    {size, ":" <> rest} = Integer.parse(rest)
    <<body::binary-size(^size), tail::binary>> = rest
    {tag, body, tail}
  end

  defp html_fields("", acc), do: Enum.reverse(acc)

  defp html_fields(wire, acc) do
    {"h", html, rest} = take_field(wire)
    html_fields(rest, [html | acc])
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
