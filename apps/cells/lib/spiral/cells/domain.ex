defmodule Spiral.Cells.Domain do
  @compile {:no_warn_undefined, :spiral_cells@domain}
  @beams Path.expand("../../../build/dev/erlang", __DIR__)

  def ensure! do
    for name <- ["spiral_cells", "gleam_stdlib", "gleam_erlang"], do: Code.append_path(Path.join([@beams, name, "ebin"]))

    unless Code.ensure_loaded?(:spiral_cells@domain) do
      raise "spiral_cells domain beam is missing from #{@beams}"
    end

    :ok
  end

  @passthrough [
    prepare: 1, patch_rust: 2, verdict_counts: 1, void_text: 4, source_input_rows: 2, source_split_blocks: 2,
    result_fields: 1, reached_program: 2, from_toml: 1, declares_modules: 1, i574n_dialect: 1, source_remap: 4,
    markdown_html: 1, json_canonical: 1, builder_present: 1, builder_failure_trace: 1, builder_split: 1, host_language: 1,
    host_extension: 1, is_cl_compiler: 1, mount_sibling_project: 1, gleam_strip_warnings: 1, split_output: 1, unit_result: 1,
    package_project: 1, parse_dib: 1, to_spi: 1, to_spir: 1, to_spi_tested: 1, to_spir_tested: 1, from_spi_bounded: 4,
    target_backend: 1, target_extension: 1, from_spi: 2, target_gaps: 1, test_index: 1, plan_tests: 1, plan: 1
  ]

  for {name, arity} <- @passthrough do
    args = Macro.generate_arguments(arity, __MODULE__)

    def unquote(name)(unquote_splicing(args)) do
      ensure!()
      :spiral_cells@domain.unquote(name)(unquote_splicing(args))
    end
  end

  def manifest_path(dir) do
    ensure!()

    case :spiral_cells@domain.manifest_path(dir) do
      "" -> nil
      file -> file
    end
  end

  def mount_patch_first(body, old, new) do
    ensure!()

    case :spiral_cells@domain.mount_patch_first(body, old, new) do
      "K" <> patched -> {:ok, patched}
      "E" -> :error
    end
  end

  def mount_nested_name(names) do
    ensure!()

    case :spiral_cells@domain.mount_nested_name(Enum.join(names, "\n")) do
      "" -> nil
      name -> name
    end
  end

  def gleam_manifest(path, deps, target) do
    ensure!()
    main = if String.contains?(Path.basename(path), "_real"), do: "main_real", else: "main"
    fields = [main, target | Enum.flat_map(deps, fn %{name: name, version: version} -> [name, if(is_nil(version), do: "-", else: "+" <> version)] end)]
    :spiral_cells@domain.gleam_manifest(Enum.map_join(fields, &"#{byte_size(&1)}:#{&1}"))
  end

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
    <<program::binary-size(^len), rest::binary>> = after_len
    [real_len_text, after_real_len] = String.split(rest, "\n", parts: 2)
    real_len = String.to_integer(real_len_text)
    <<real::binary-size(^real_len), rest::binary>> = after_real_len

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
    <<source::binary-size(^len), rest::binary>> = after_len

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
