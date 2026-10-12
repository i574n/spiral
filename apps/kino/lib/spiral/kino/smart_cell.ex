defmodule Spiral.Kino.SmartCell do
  use Kino.JS
  use Kino.JS.Live
  use Kino.SmartCell, name: "Spiral"

  @default_timeout_s 300
  @default_source """
  inl square x = x * x

  console.write_line "Hello from Spiral!"
  square 7i32
  """

  @impl true
  def init(attrs, ctx) do
    fields = %{
      "timeout" => valid_timeout(attrs["timeout"]),
      "print_code" => attrs["print_code"] == true
    }

    source = attrs["source"] || @default_source
    ctx = assign(ctx, fields: fields, source: source)

    {:ok, ctx,
     editor: [
       source: source,
       language: Application.get_env(:spiral_kino, :editor_language, "javascript"),
       placement: :bottom
     ]}
  end

  @impl true
  def handle_connect(ctx) do
    {:ok, %{fields: ctx.assigns.fields}, ctx}
  end

  @impl true
  def handle_event("update_field", %{"field" => field, "value" => value}, ctx) do
    fields = Map.put(ctx.assigns.fields, field, normalize(field, value))
    broadcast_event(ctx, "update", %{"fields" => fields})
    {:noreply, assign(ctx, fields: fields)}
  end

  @impl true
  def handle_editor_change(source, ctx) do
    {:ok, assign(ctx, source: source)}
  end

  @impl true
  def to_attrs(ctx) do
    Map.put(ctx.assigns.fields, "source", ctx.assigns.source)
  end

  @impl true
  def to_source(attrs) do
    source = attrs["source"] || ""

    if String.trim(source) == "" do
      ""
    else
      opts = source_opts(attrs)

      args =
        [
          string_literal(source)
          | Enum.map(opts, fn {key, value} -> "#{key}: #{literal(value)}" end)
        ]
        |> Enum.map_join(",\n", &indent/1)

      ("Spiral.Kino.eval!(\n" <> args <> "\n)")
      |> Code.format_string!()
      |> IO.iodata_to_binary()
    end
  end

  defp source_opts(attrs) do
    [
      timeout: valid_timeout(attrs["timeout"]) * 1000,
      print_code: if(attrs["print_code"] == true, do: true)
    ]
    |> Enum.reject(fn {_key, value} -> is_nil(value) end)
  end

  defp string_literal(source) do
    if String.contains?(source, ~s(""")) or String.contains?(source, "\r") do
      literal(source)
    else
      body =
        source
        |> String.split("\n")
        |> then(fn lines ->
          if List.last(lines) == "", do: Enum.drop(lines, -1), else: lines
        end)
        |> Enum.map_join("\n", fn
          "" -> ""
          line -> "  " <> line
        end)

      ~s(~S""") <> "\n" <> body <> "\n" <> ~s(  """)
    end
  end

  defp indent(text) do
    case String.split(text, "\n", parts: 2) do
      [first] -> "  " <> first
      [first, rest] -> "  " <> first <> "\n" <> rest
    end
  end

  defp literal(value) when is_binary(value),
    do: inspect(value, printable_limit: :infinity, limit: :infinity)

  defp literal(value), do: inspect(value)

  defp normalize("timeout", value), do: valid_timeout(value)
  defp normalize("print_code", value), do: value == true
  defp normalize(_field, value) when is_binary(value), do: value
  defp normalize(_field, _value), do: ""

  defp valid_timeout(value) when is_integer(value) and value > 0, do: value

  defp valid_timeout(value) when is_binary(value) do
    case Integer.parse(String.trim(value)) do
      {n, ""} when n > 0 -> n
      _ -> @default_timeout_s
    end
  end

  defp valid_timeout(value) when is_float(value) and value > 0, do: max(round(value), 1)
  defp valid_timeout(_), do: @default_timeout_s

  asset "main.js" do
    """
    export function init(ctx, payload) {
      ctx.importCSS("main.css");

      ctx.root.innerHTML = `
        <div class="app">
          <div class="header">
            <span class="title">Spiral</span>
            <label class="field">
              <span>Timeout (s)</span>
              <input type="number" min="1" step="1" name="timeout" />
            </label>
            <label class="field checkbox">
              <input type="checkbox" name="print_code" />
              <span>Show generated Rust</span>
            </label>
          </div>
        </div>
      `;

      const inputs = {
        timeout: ctx.root.querySelector("input[name=timeout]"),
        print_code: ctx.root.querySelector("input[name=print_code]"),
      };

      function render(fields) {
        inputs.timeout.value = fields.timeout;
        inputs.print_code.checked = fields.print_code;
      }

      render(payload.fields);

      function push(field) {
        const input = inputs[field];
        const value = input.type === "checkbox" ? input.checked : input.value;
        ctx.pushEvent("update_field", { field, value });
      }

      for (const field of Object.keys(inputs)) {
        inputs[field].addEventListener("change", () => push(field));
      }

      ctx.handleEvent("update", ({ fields }) => render(fields));

      ctx.handleSync(() => {
        const active = document.activeElement;
        if (active && ctx.root.contains(active)) {
          active.dispatchEvent(new Event("change"));
        }
      });
    }
    """
  end

  asset "main.css" do
    """
    .app {
      font-family: Inter, system-ui, sans-serif;
      font-size: 0.875rem;
    }

    .header {
      display: flex;
      flex-wrap: wrap;
      align-items: center;
      gap: 0.75rem 1.25rem;
      padding: 0.5rem 0.75rem;
      border: 1px solid #e1e8f0;
      border-bottom: none;
      border-radius: 0.5rem 0.5rem 0 0;
      background-color: #f8fafc;
      color: #445668;
    }

    .title {
      font-weight: 600;
      color: #0d18a6;
    }

    .field {
      display: flex;
      align-items: center;
      gap: 0.4rem;
    }

    .field input[type=number] {
      width: 5rem;
      padding: 0.25rem 0.5rem;
      border: 1px solid #e1e8f0;
      border-radius: 0.375rem;
      background-color: white;
      font-size: 0.875rem;
      color: #445668;
    }
    """
  end
end
