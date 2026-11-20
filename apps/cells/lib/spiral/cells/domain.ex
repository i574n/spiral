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
    prepare: 1, prepare_run: 2, memo_context: 2, memo_code_result: 3, memo_whole_keys: 1, memo_result_path_modules: 0, memo_tool_identity: 1, memo_on: 1, tables_ensure: 2, cells_root: 0, tool: 2, tool_lean: 1, display_render_values: 2, display_from_value: 2, result_new: 1, json_safe: 1, builders_split: 1, builders_commands: 1, builders_host_rust: 1, builders_backend: 1, builders_ext: 1, builders_dispatch: 2, builders_argv: 2, scale_budget: 1, scale_note: 0, timeout_scale: 0, per_test_compile: 0, static_opens_sibling: 2, patch_rust: 2, verdict_counts: 1, counts_map: 1, shown_stdout: 3, assemble_core: 1, extract: 1, empty_message: 1, join_host: 2, first_line: 1, void_text: 4, source_blocks_of_texts: 3, host_has: 3, fair_empty: 0, slots_new: 1, slots_acquire: 2, slots_release: 2, slots_down: 2, slots_status: 1, slots_run: 3, slots_start: 1, slots_status_of: 1, slots_jobs_limit: 0, guard_start: 0, dll_tag: 1, working_set_mb: 1, port_env: 3, dll_stamp: 1, shadow_dll: 2, gate_pin: 3, fair_push: 3, fair_pop: 1, fair_len: 1, memo_fetch: 2, memo_store: 3, memo_dir: 1, memo_glob: 2, memo_tool_stamp: 1, memo_compiler_binaries_print: 1, memo_kino_identity: 1, source_split_blocks: 2,
    result_fields: 1, summary_fields: 1, output_html: 1, cell_head_html: 1, headroom_text: 2, sorted_render: 1, summary_lines_json: 2, metrics_tsv: 1, reached_program: 2, block_shape: 2, cell_weight: 2, cell_budget_lines: 2, cell_budget_over_lines: 1, cell_budget_findings: 4, cell_budget_kind_rows: 2, cell_budget_kinds_line: 1, cell_budget_nominals: 1, tool_path: 3, mount_dependencies: 3, mount_package_items: 1, memo_tree_print: 4, memo_package_indexes: 4, memo_packages_print: 4, memo_key: 3, memo_hash: 1, memo_reached_program: 2, make_symlink: 2, make_symlink_result: 2, mount_plan_shadow: 4, mount_plan_patched: 5, notebook_collect: 2, report_rows: 3, process_error: 4, timeout_error: 3, cells_spiral_error: 3, mark_accepted: 2, report_counts: 1, no_agree_report: 2, compile_outcome: 2, add_phase: 2, with_missing: 2, pascal_choice: 4, line_directive: 2, shown_map: 2, disagreement: 4, add_wait: 2, budget_remaining: 2, write_package: 6, source_mtime_of: 2, disagree_result: 3, charge_queue: 0, record_target: 3, host_key: 1, host_steps: 2, fsi_steps: 2, await_port_file: 3, kill_pidfile: 1, rustc_args: 4, compile_unit_first: 3, compiler_open: 6, memo_enabled: 4, daemon_listen: 3, boot_main: 1, run_cwd_choice: 5, memo_module_files: 2, memo_source_bounds: 6, memo_rows_of_texts: 3, mounts_newest: 1, mounts_key: 1, mounts_forward: 1, mounts_closure: 3, mounts_imports: 3, run_outcome: 5, with_lock: 3, pid_alive: 1, status_reply: 1, from_toml: 1, source_remap: 4,
    lisp_transpile: 2, parse_livemd: 1, to_livemd: 1, decode_cells: 1, encode_cells: 1, elixir_inspect: 1, expected_label: 2, cet_early: 3, cet_ok: 2, cet_nocode: 3, cet_other: 2, compile_compiled_text: 2, compile_failed_text: 3, not_run_reason_text: 1, ipynb_text: 5, markdown_html: 1, json_canonical: 1, builder_present: 1, builder_failure_trace: 1, builder_split_term: 1, host_language: 1,
    host_extension: 1, is_cl_compiler: 1, mount_sibling_project: 1, gleam_strip_warnings: 1, split_output: 1, unit_result: 1,
    package_project: 1, parse_dib: 1, to_spi: 1, to_spir: 1, to_spi_tested: 1, to_spir_tested: 1, from_spi_bounded: 4,
    target_backend: 1, target_extension: 1, from_spi: 2, target_gaps: 1, test_index: 1, plan_tests: 1, fails_expectation: 1, agreement: 1, reference_target: 1, expectation: 1, body_head: 1, body_floor: 2, directive_flag: 2, directive_word: 2, no_agree_reason: 1, bare_no_agree: 1, compile_error_verdict: 4, canonical_unions: 1, canonical_collections: 1, shown_lines: 1, main_span: 1, type_lines: 1, clean_paths: 2, package_dir_of: 1, with_real_main: 1, package_dir_value: 1, mount_name_of: 1, fsi_failed: 1, canon_package_paths: 1, canon_package_flags: 2, unknown_tests: 3, test_state: 3, fsi_reply_text: 3, fsi_reply_value: 2, fsi_cut_output: 2, fsi_after_marker: 1, accept_mismatch: 1, accept_passed_before: 1, accept_rewrite: 5, livemd_cells: 1, livemd_markdown: 1, value_result: 2, plan: 1, compile_reply: 1,
    block_facts: 2, pool_reply: 1, hello_reply: 1, gleam_warm_dir: 3, gleam_lock_path: 2, gleam_keep_lock: 2, gleam_cell_sources: 3, gleam_build_only_receipt: 3,
    opened_names: 1, package_paths: 1, strip_comments: 1, shim_path: 1, phase_row: 3, module_entries: 1, compile_exchange: 10, unix_spawn_script: 2, up_step_wire: 4, daemon_accept: 2, compile_result_reply: 2, count_or: 2, idle_window: 2, pressure_window: 1, memory_pressed: 2, recycle_why: 4, banner_text: 4, dll_stamp_text: 4, slot_of: 5, prunable: 2, pin_stale: 2, forwarded: 1, status_wire: 6, pool_wire: 4, compiler_session: 6, python_patched: 1, mem_available_mb: 1, mem_available_kb: 1, slots_limit: 2, default_slots: 1, pool_max_workers: 1, room_verdict: 3, guard_limit_bytes: 2, over_limit: 2, directive_timeout: 1, project_name_ok: 1, plot_jsons: 1, html_escape: 1, html_head: 1, highlighted: 2, file_number: 1, cells_module: 1, session_lost: 1, native_path: 2, clock_text: 3, log_tail: 1, tasklist_kb: 2, vm_rss_kb: 1, owner_text: 1, tool_spelling: 2, live_status: 1, pool_summary: 2, root_spelling: 1, root_key: 2,start_process_line: 2, default_shell_launcher: 1, launcher_line: 2, start_cmd_text: 2, spawn_script: 5, runtime_file: 2, warm_port_name: 2, foreign_toolchain_text: 1, ping_wire: 1, shown_text: 1, banner_dll_wire: 1, retire_daemon: 1, builder_route: 2, retired_skip_error: 2, builder_argv: 2, zig_args: 6, c_args: 4, python_warnings: 1, env_with_test_name: 2, env_without_cupy: 1, tool_env: 2, runner_capture_ok: 3, runner_command_line: 3, runner_read_tail: 2, runner_remove_capture: 2, runner_resolve: 1, runner_kill_tree: 1, notebook_package_text: 3, mount_entries: 5, mounts_share: 4, select_tests: 2, cli_livemd_target: 4, cli_output_path: 3, trial_notebook: 2, test_names: 1, prepare_term: 1, runner_loop: 7, own_main_code: 1, show_value_main: 1, parse_dib_doc: 1, parse_spi_doc: 2, parse_spi_bounded_doc: 4, parse_livemd_doc: 1, to_livemd_doc: 1, to_cell_text_doc: 1, to_spir_doc: 1, to_spi_doc: 1, to_spi_tested_doc: 1, to_spir_tested_doc: 1, tests_doc: 1, target_gaps_doc: 1, stream: 2, phase_key: 1, source_of: 2, builder_failed_text: 2, c_exe_path: 2, cell_timeout_text: 4, daemon_command: 4, temp_sweep: 0, html_write: 4, cell_text: 1, cell_source: 3, accept_sites: 2
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

  def manifest_read(dir) do
    ensure!()

    case :spiral_cells@domain.manifest_path(dir) do
      "" ->
        {:error, :enoent}

      _file ->
        dotnet = Spiral.Cells.Domain.tool("dotnet", [])
        dll = Spiral.Cells.Domain.tool("compiler_dll", [])
        has_cap = is_binary(dotnet) and File.regular?(dll) and host_has(dotnet, dll, "resolve-manifest")
        {:ok, :spiral_cells@domain.manifest_read_text(dir, dotnet || "", dll, has_cap)}
    end
  end

  def manifest_exists(dir) do
    ensure!()
    :spiral_cells@domain.manifest_path(dir) != ""
  end

  def manifest_read!(dir) do
    case manifest_read(dir) do
      {:ok, text} -> text
      {:error, reason} -> raise File.Error, reason: reason, action: "read manifest in", path: dir
    end
  end

  def manifest_names, do: ["spiral.toml", "package.spiproj"]

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
end
