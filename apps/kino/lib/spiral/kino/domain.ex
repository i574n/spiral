defmodule Spiral.Kino.Domain do
  @compile {:no_warn_undefined, :spiral_kino@domain}
  @beams Path.expand("../../../build/dev/erlang", __DIR__)

  def ensure! do
    for name <- ["spiral_kino", "gleam_stdlib"] do
      Code.append_path(Path.join([@beams, name, "ebin"]))
    end

    unless Code.ensure_loaded?(:spiral_kino@domain) do
      raise "spiral_kino domain beam is missing from #{@beams}"
    end

    :ok
  end

  def prepare(code) do
    ensure!()
    :spiral_kino@domain.prepare(code)
  end

  def patch_rust(rust, show) do
    ensure!()
    :spiral_kino@domain.patch_rust(rust, show)
  end

  def split_output(output) do
    ensure!()
    :spiral_kino@domain.split_output(output)
  end

  def unit_result(output) do
    ensure!()
    :spiral_kino@domain.unit_result(output)
  end

  def package_project(includes) do
    ensure!()
    :spiral_kino@domain.package_project(includes)
  end

  def parse_dib(text) do
    ensure!()
    :spiral_kino@domain.parse_dib(text)
  end

  def to_spi(text) do
    ensure!()
    :spiral_kino@domain.to_spi(text)
  end

  def to_spir(text) do
    ensure!()
    :spiral_kino@domain.to_spir(text)
  end

  def plan(wire) do
    ensure!()
    :spiral_kino@domain.plan(wire)
  end

  # Every length on the wire is a byte count, as in the domain's byte-offset text helpers (spi/text.spi).
  def decode_plan(wire) do
    case String.split(wire, "\n", parts: 2) do
      [count, rest] -> decode_steps(String.to_integer(count), rest, [])
      [count] -> decode_steps(String.to_integer(count), "", [])
    end
  end

  defp decode_steps(0, _rest, acc), do: Enum.reverse(acc)

  defp decode_steps(n, rest, acc) do
    [index_text, timeout, len_text, after_len] = String.split(rest, "\n", parts: 4)
    len = String.to_integer(len_text)
    <<program::binary-size(len), rest::binary>> = after_len
    [real_len_text, after_real_len] = String.split(rest, "\n", parts: 2)
    real_len = String.to_integer(real_len_text)
    <<real::binary-size(real_len), rest::binary>> = after_real_len

    decode_steps(n - 1, rest, [
      %{index: String.to_integer(index_text), timeout: timeout, program: program, real: real}
      | acc
    ])
  end

  def encode_cells(cells) do
    body = Enum.map_join(cells, "", &encode_cell/1)
    Integer.to_string(length(cells)) <> "\n" <> body
  end

  def decode_cells(wire) do
    [count_text, rest] = String.split(wire, "\n", parts: 2)
    decode_n(String.to_integer(count_text), rest, [])
  end

  defp encode_cell(%{kind: :code, language: language, source: source}) do
    field("code/" <> language, source)
  end

  defp encode_cell(%{kind: kind, source: source}) when is_atom(kind) do
    field(Atom.to_string(kind), source)
  end

  defp field(kind, source) do
    kind <> "\n" <> Integer.to_string(byte_size(source)) <> "\n" <> source
  end

  defp decode_n(0, _rest, acc), do: Enum.reverse(acc)

  defp decode_n(n, rest, acc) do
    [kind, len_text, after_len] = String.split(rest, "\n", parts: 3)
    len = String.to_integer(len_text)
    <<source::binary-size(len), rest::binary>> = after_len

    decode_n(n - 1, rest, [
      cell(kind, source) | acc
    ])
  end

  defp cell("code/" <> language, source), do: %{kind: :code, language: language, source: source}
  defp cell("markdown", source), do: %{kind: :markdown, source: source}
  defp cell("spiral", source), do: %{kind: :spiral, source: source}
  defp cell("fsharp", source), do: %{kind: :fsharp, source: source}
  defp cell("import", source), do: %{kind: :import, source: source}
end
