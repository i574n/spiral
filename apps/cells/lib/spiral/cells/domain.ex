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
    prepare: 1, static_opens_sibling: 2, patch_rust: 2, verdict_counts: 1, void_text: 4, source_input_rows: 2, source_split_blocks: 2,
    result_fields: 1, summary_fields: 1, output_html: 1, cell_head_html: 1, headroom_text: 2, sorted_render: 1, summary_lines_json: 2, metrics_tsv: 1, reached_program: 2, block_shape: 2, cell_weight: 2, cell_budget_lines: 2, cell_budget_over_lines: 1, status_reply: 1, from_toml: 1, source_remap: 4,
    markdown_html: 1, json_canonical: 1, builder_present: 1, builder_failure_trace: 1, builder_split: 1, host_language: 1,
    host_extension: 1, is_cl_compiler: 1, mount_sibling_project: 1, gleam_strip_warnings: 1, split_output: 1, unit_result: 1,
    package_project: 1, parse_dib: 1, to_spi: 1, to_spir: 1, to_spi_tested: 1, to_spir_tested: 1, from_spi_bounded: 4,
    target_backend: 1, target_extension: 1, from_spi: 2, target_gaps: 1, test_index: 1, plan_tests: 1, fails_expectation: 1, body_head: 1, body_floor: 2, directive_flag: 2, directive_word: 2, no_agree_reason: 1, bare_no_agree: 1, compile_error_verdict: 4, canonical_unions: 1, canonical_collections: 1, shown_lines: 1, main_span: 1, type_lines: 1, clean_paths: 2, package_dir_of: 1, with_real_main: 1, package_dir_value: 1, mount_name_of: 1, fsi_failed: 1, canon_package_paths: 1, canon_package_flags: 2, unknown_tests: 3, test_state: 3, fsi_reply_text: 3, fsi_reply_value: 2, fsi_cut_output: 2, fsi_after_marker: 1, accept_mismatch: 1, accept_passed_before: 1, accept_rewrite: 5, livemd_cells: 1, livemd_markdown: 1, value_result: 2, plan: 1, compile_reply: 1,
    block_facts: 2, pool_reply: 1, hello_reply: 1, gleam_manifest_facts: 1,
    opened_names: 1, package_paths: 1, strip_comments: 1, shim_path: 1, phase_row: 3, module_entries: 1, compile_exchange: 10, compile_request: 1, compile_reply_line: 3, count_or: 2, idle_window: 2, pressure_window: 1, memory_pressed: 2, recycle_why: 4, banner_text: 4, dll_stamp_text: 4, slot_of: 5, prunable: 2, pin_stale: 2, forwarded: 1, status_wire: 6, pool_wire: 4, compiler_session: 6, python_patched: 1, mem_available_mb: 1, directive_timeout: 1, project_name_ok: 1, plot_jsons: 1, html_escape: 1, html_head: 1, highlighted: 2, file_number: 1, cells_module: 1, session_lost: 1, native_path: 2, clock_text: 3, log_tail: 1, tasklist_kb: 2, vm_rss_kb: 1, owner_text: 1, tool_spelling: 2, live_status: 1, pool_summary: 2, root_spelling: 1, root_key: 2, start_process_line: 2, launcher_line: 2, start_cmd_text: 2, spawn_script: 5, runtime_file: 2, warm_port_name: 2, foreign_toolchain_text: 1, ping_wire: 1, shown_text: 1, banner_dll_wire: 1, retire_daemon: 1, builder_route: 2, retired_skip_error: 2, builder_argv: 2, zig_args: 6, c_args: 4, python_warnings: 1, builder_failed_text: 2, c_exe_path: 2, cell_timeout_text: 4, daemon_command: 4
  ]

  for {name, arity} <- @passthrough do
    args = Macro.generate_arguments(arity, __MODULE__)

    def unquote(name)(unquote_splicing(args)) do
      ensure!()
      :spiral_cells@domain.unquote(name)(unquote_splicing(args))
    end
  end

  def declares_modules(text) do
    ensure!()
    :spiral_cells@domain.declares_modules(text) in [true, "true"]
  end

  def i574n_dialect(text) do
    ensure!()
    :spiral_cells@domain.i574n_dialect(text) in [true, "true"]
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
