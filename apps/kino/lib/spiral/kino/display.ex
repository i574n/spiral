defmodule Spiral.Kino.Display do
  alias Spiral.Kino.{Runner, Toolchain}

  @begin "SPIRAL_KINO_DISPLAY_BEGIN"
  @finish "SPIRAL_KINO_DISPLAY_END"
  @svg "image/svg+xml"
  @plot_timeout 60_000

  @type t :: %{mime: String.t(), data: String.t()}

  @spec begin_marker() :: String.t()
  def begin_marker, do: @begin

  @spec end_marker() :: String.t()
  def end_marker, do: @finish

  @spec extract(String.t()) :: {[t()], String.t()}
  def extract(stdout) when is_binary(stdout) do
    if String.contains?(stdout, @begin) do
      {displays, kept, open} =
        stdout
        |> String.replace("\r\n", "\n")
        |> String.split("\n")
        |> Enum.reduce({[], [], nil}, &collect/2)

      {Enum.reverse(displays), kept |> unclosed(open) |> Enum.reverse() |> Enum.join("\n")}
    else
      {[], stdout}
    end
  end

  defp unclosed(kept, nil), do: kept
  defp unclosed(kept, :mime), do: [@begin | kept]
  defp unclosed(kept, open), do: open.lines ++ [open.mime, @begin | kept]

  defp collect(@begin, {displays, kept, nil}), do: {displays, kept, :mime}
  defp collect(line, {displays, kept, nil}), do: {displays, [line | kept], nil}

  defp collect(mime, {displays, kept, :mime}),
    do: {displays, kept, %{mime: String.trim(mime), lines: []}}

  defp collect(@finish, {displays, kept, open}) do
    data = open.lines |> Enum.reverse() |> Enum.join("\n")
    {[%{mime: open.mime, data: data} | displays], kept, nil}
  end

  defp collect(line, {displays, kept, open}),
    do: {displays, kept, %{open | lines: [line | open.lines]}}

  @spec from_value(String.t() | nil, keyword()) :: {String.t() | nil, [t()]}
  def from_value(nil, _opts), do: {nil, []}

  def from_value(value, opts) do
    with {:ok, term} <- parse_debug(value),
         [_ | _] = plots <- line_plots(term),
         {:ok, svgs} <- render_all(plots, opts) do
      {nil, Enum.map(svgs, &%{mime: @svg, data: &1})}
    else
      _ -> {value, []}
    end
  end

  @spec line_plots(term()) :: [term()]
  def line_plots(term) do
    cond do
      line_plot?(term) -> [term]
      is_list(term) and term != [] and Enum.all?(term, &line_plot?/1) -> term
      true -> []
    end
  end

  defp line_plot?({:tuple, [caption, x_desc, y_desc, series]})
       when is_binary(caption) and is_binary(x_desc) and is_binary(y_desc) and is_list(series) do
    Enum.all?(series, &series?/1)
  end

  defp line_plot?(_), do: false

  defp series?({:tuple, [label, xs, ys]}) when is_binary(label) and is_list(xs) and is_list(ys),
    do: Enum.all?(xs, &is_number/1) and Enum.all?(ys, &is_number/1)

  defp series?(_), do: false

  @spec plot_json(term()) :: String.t()
  def plot_json({:tuple, [caption, x_desc, y_desc, series]}) do
    JSON.encode!([
      caption,
      x_desc,
      y_desc,
      Enum.map(series, fn {:tuple, [label, xs, ys]} -> [label, xs, ys] end)
    ])
  end

  defp render_all(plots, opts) do
    Enum.reduce_while(plots, {:ok, []}, fn plot, {:ok, acc} ->
      case render_svg(plot_json(plot), opts) do
        {:ok, svg} -> {:cont, {:ok, acc ++ [svg]}}
        error -> {:halt, error}
      end
    end)
  end

  @spec render_svg(String.t(), keyword()) :: {:ok, String.t()} | {:error, String.t()}
  def render_svg(json, opts) do
    case opts[:render_plot] do
      fun when is_function(fun, 1) -> fun.(json)
      _ -> run_plot(json, opts)
    end
  end

  defp run_plot(json, opts) do
    exe = Toolchain.plot(opts)

    if exe && File.regular?(exe) do
      dir = Path.join(System.tmp_dir!(), "spiral_kino_plot_#{System.unique_integer([:positive])}")
      File.mkdir_p!(dir)
      input = Path.join(dir, "plot.json")
      output = Path.join(dir, "plot.svg")

      try do
        File.write!(input, json)

        case Runner.run(exe, [input, output], timeout: @plot_timeout) do
          {:ok, %{exit_status: 0}} -> File.read(output) |> then(&with_reason(&1, output))
          {:ok, %{output: text}} -> {:error, text}
          {:error, reason} -> {:error, inspect(reason)}
        end
      after
        File.rm_rf(dir)
      end
    else
      {:error, "plot tool not found"}
    end
  end

  defp with_reason({:ok, svg}, _path), do: {:ok, svg}
  defp with_reason({:error, reason}, path), do: {:error, "#{path}: #{inspect(reason)}"}

  @spec parse_debug(String.t()) :: {:ok, term()} | :error
  def parse_debug(text) do
    case value(skip(text)) do
      {:ok, term, rest} -> if skip(rest) == "", do: {:ok, term}, else: :error
      :error -> :error
    end
  end

  defp skip(<<c, rest::binary>>) when c in [?\s, ?\t, ?\n, ?\r], do: skip(rest)
  defp skip(text), do: text

  defp value(<<?", rest::binary>>), do: string(rest, [])
  defp value(<<?[, rest::binary>>), do: items(skip(rest), ?], [], fn list -> list end)
  defp value(<<?(, rest::binary>>), do: items(skip(rest), ?), [], &{:tuple, &1})

  defp value(text) do
    case Regex.run(~r/^-?(?:\d+(?:\.\d+)?(?:e[-+]?\d+)?|inf|NaN)/, text) do
      [number] ->
        {:ok, number(number),
         binary_part(text, byte_size(number), byte_size(text) - byte_size(number))}

      nil ->
        named(text)
    end
  end

  defp number("inf"), do: :infinity
  defp number("-inf"), do: :neg_infinity
  defp number("NaN"), do: :nan
  defp number("-NaN"), do: :nan

  defp number(text) do
    case Integer.parse(text) do
      {int, ""} -> int
      _ -> text |> float_text() |> String.to_float()
    end
  end

  defp float_text(text) do
    text = if String.contains?(text, "."), do: text, else: String.replace(text, "e", ".0e")
    if String.contains?(text, "e") or String.contains?(text, "."), do: text, else: text <> ".0"
  end

  defp named(text) do
    case Regex.run(~r/^[A-Za-z_][A-Za-z0-9_]*/, text) do
      [name] ->
        rest = skip(binary_part(text, byte_size(name), byte_size(text) - byte_size(name)))
        named_body(name, rest)

      nil ->
        :error
    end
  end

  defp named_body("RefCell", <<?{, rest::binary>>) do
    with "value:" <> rest <- skip(rest),
         {:ok, inner, rest} <- value(skip(rest)),
         <<?}, rest::binary>> <- skip(rest) do
      {:ok, inner, rest}
    else
      _ -> :error
    end
  end

  defp named_body(name, <<?(, rest::binary>>),
    do: items(skip(rest), ?), [], &{:variant, name, &1})

  defp named_body(name, rest), do: {:ok, {:variant, name, []}, rest}

  defp items(<<close, rest::binary>>, close, acc, wrap), do: {:ok, wrap.(Enum.reverse(acc)), rest}

  defp items(text, close, acc, wrap) do
    case value(text) do
      {:ok, item, rest} ->
        case skip(rest) do
          <<?,, rest::binary>> -> items(skip(rest), close, [item | acc], wrap)
          <<^close, rest::binary>> -> {:ok, wrap.(Enum.reverse([item | acc])), rest}
          _ -> :error
        end

      :error ->
        :error
    end
  end

  defp string(<<?", rest::binary>>, acc),
    do: {:ok, acc |> Enum.reverse() |> IO.iodata_to_binary(), rest}

  defp string(<<?\\, ?u, ?{, rest::binary>>, acc), do: unicode_escape(rest, acc)
  defp string(<<?\\, c, rest::binary>>, acc), do: string(rest, [escape(c) | acc])
  defp string(<<c::utf8, rest::binary>>, acc), do: string(rest, [<<c::utf8>> | acc])
  defp string(_, _acc), do: :error

  defp escape(?n), do: "\n"
  defp escape(?r), do: "\r"
  defp escape(?t), do: "\t"
  defp escape(?0), do: <<0>>
  defp escape(c), do: <<c>>

  defp unicode_escape(text, acc) do
    case String.split(text, "}", parts: 2) do
      [hex, rest] ->
        case Integer.parse(hex, 16) do
          {code, ""} -> string(rest, [<<code::utf8>> | acc])
          _ -> :error
        end

      _ ->
        :error
    end
  end
end
