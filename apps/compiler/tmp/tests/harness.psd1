# Hand-written tables for scripts/test.ps1. Generated results (the single-flight oracle, scoreboards)
# live in the cache directory, not here.
@{
    # Broad, fast coverage: one sample directory per entry.
    Smoke = @(
        'samples/hello'
        'samples/arithmetic_branch'
        'samples/function_call'
        'samples/tail_loop'
        'samples/record_value'
        'samples/tagged_union_scalar'
        'samples/recursive_union_list'
        'samples/native_closure_capture'
        'samples/managed_string_concat'
        'samples/dynamic_array_string_resize'
        'samples/frontier_fib'
        'samples/frontier_try_item'
        'samples/contract_gadt'
        'samples/contract_existential'
        'samples/contract_illegal_transition'
    )

    # Diagnosed failures: reported as `known` instead of failing a run.
    Known = @(
        @{ Id = 'samples/ts_int_wrap'; Backend = 'Python'; Reason = 'upstream CodegenPython: Python ints are unbounded, so fixed-width wrapping differs from C (exits 1 at the first wrap check)' }
        @{ Id = 'samples/ts_string_slice'; Backend = 'Python'; Reason = 'upstream CodegenPython: strings index by code point, C/Rust/TypeScript by UTF-8 byte' }
        @{ Id = 'samples/native_cube_flush_delay_direct'; Backend = 'C'; Reason = 'POSIX-only residual (poll.h); native C runs only on Linux' }
        @{ Id = 'samples/native_cube_monotonic_delay_direct'; Backend = 'C'; Reason = 'POSIX-only residual (poll.h/clock_gettime); native C runs only on Linux' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Rust'; Reason = 'C residual has no bounds check (exits 0); Rust panics as the fixture intends' }
    )

    # The megaproject roots (the mega suite); their sub-packages belong to the contracts suite.
    Mega = @(
        @{ Name = 'ERP'; Title = 'OmniLedger ERP kernel'; Source = 'samples/mega_omniledger_erp_kernel/main.spi' }
        @{ Name = 'Zeta'; Title = 'Structural factorization laboratory'; Source = 'samples/mega_zeta_structural_laboratory/main.spi' }
        @{ Name = 'CIC'; Title = 'Lean CIC bottom-up kernel'; Source = 'samples/mega_lean_cic_bottom_up_kernel/main.spi' }
        @{ Name = 'Self'; Title = 'Spiral proves Spiral relative-consistency laboratory'; Source = 'samples/mega_spiral_proves_spiral_relative_consistency/main.spi' }
        @{ Name = 'Brzozowski'; Title = 'Brzozowski derivative matcher'; Source = 'samples/mega_brzozowski_derivatives/main.spi' }
    )

    # Per-sample job timeouts (seconds) over the suite's, for programs that are slow to compile but not hangs: the
    # Brzozowski runtime programs compile in 1-3 s single-flight and take more than the contracts suite's 30 s in hopac
    # (2026-10-06: runtime_bench, bench_derivative and bench_staged timed out at 28 s; proof_suite took 26 s).
    Timeouts = @{
        'samples/mega_brzozowski_derivatives/runtime_bench' = 180
        'samples/mega_brzozowski_derivatives/proof_suite' = 180
        'samples/mega_brzozowski_derivatives/bench_derivative' = 180
        'samples/mega_brzozowski_derivatives/bench_backtrack' = 180
        'samples/mega_brzozowski_derivatives/bench_staged' = 180
        'samples/mega_brzozowski_derivatives/bench_zero_runs_derivative' = 180
        'samples/mega_brzozowski_derivatives/bench_zero_runs_backtrack' = 180
        'samples/mega_brzozowski_derivatives/bench_zero_runs_staged' = 180
        'samples/mega_brzozowski_derivatives/bench_interned' = 180
        'samples/mega_brzozowski_derivatives/bench_zero_runs_interned' = 180
        'samples/mega_brzozowski_derivatives/indexed_dfa_state_cardinality' = 180
        'samples/mega_brzozowski_derivatives/indexed_dfa_witness_contracts' = 180
        'samples/mega_brzozowski_derivatives/inventory_closed_dfa_runtime' = 180
        # The older megas' all_terminals / runtime_native packages evaluate dozens of root programs (lane G, 2026-10-06).
        'samples/mega_omniledger_erp_kernel/all_terminals' = 180
        'samples/mega_zeta_structural_laboratory/all_terminals' = 180
        'samples/mega_lean_cic_bottom_up_kernel/all_terminals' = 180
        'samples/mega_spiral_proves_spiral_relative_consistency/all_terminals' = 180
        'samples/mega_zeta_structural_laboratory/runtime_native' = 180
        'samples/mega_omniledger_erp_kernel/runtime_native' = 180
        'samples/mega_lean_cic_bottom_up_kernel/runtime_native' = 180
        'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native' = 180
    }

    # Extra C compiler flags per sample name, first matching wildcard wins ({shims} = tests/native-shims).
    # A c-shim.h inside a sample directory is force-included automatically.
    CFlags = @(
        @{ Pattern = 'native_float_*'; Flags = '-lm' }
        @{ Pattern = 'abi_external_callback'; Flags = '-include {shims}/abi-external-callback-c-shim.h' }
        @{ Pattern = 'abi_external_struct_argument'; Flags = '-include {shims}/abi-external-struct-argument-c-shim.h -lm' }
        @{ Pattern = 'abi_external_struct_return_i64'; Flags = '-include {shims}/abi-external-struct-return-i64-c-shim.h' }
        @{ Pattern = 'abi_external_struct_return'; Flags = '-include {shims}/abi-external-struct-return-c-shim.h' }
        @{ Pattern = 'abi_external_const_buffer'; Flags = '-include {shims}/abi-external-const-buffer-c-shim.h' }
        @{ Pattern = 'abi_external_mutable_buffer'; Flags = '-include {shims}/abi-external-mutable-buffer-c-shim.h' }
        @{ Pattern = 'abi_external_string'; Flags = '-include {shims}/abi-external-string-c-shim.h' }
        @{ Pattern = 'abi_external'; Flags = '-Dspiral_abi_libc_abs=abs' }
        @{ Pattern = 'abi_external_i64'; Flags = '-Dspiral_abi_libc_llabs=llabs' }
        @{ Pattern = 'native_managed_array_scc_tail_recursion'; Flags = '-include {shims}/native-managed-array-scc-tail-c-shim.h' }
        @{ Pattern = 'native_managed_array_scc3_tail_recursion'; Flags = '-include {shims}/native-managed-array-scc3-tail-c-shim.h' }
        @{ Pattern = 'native_package_owned_array_type'; Flags = '-include {shims}/portable-array-refcount-c-shim.h' }
        @{ Pattern = 'dynamic_array_resize_union_managed'; Flags = '-include {shims}/dynamic-array-resize-union-managed-c-shim.h' }
        @{ Pattern = 'dynamic_array_string_resize'; Flags = '-include {shims}/dynamic-array-resize-union-managed-c-shim.h' }
        @{ Pattern = 'dynamic_array_string_union'; Flags = '-include {shims}/dynamic-array-resize-union-managed-c-shim.h' }
        @{ Pattern = 'dynamic_array_reserve_zero'; Flags = '-include {shims}/dynamic-array-reserve-zero-c-shim.h' }
        @{ Pattern = 'dynamic_array_resize_alias'; Flags = '-include {shims}/dynamic-array-resize-c-shim.h' }
        @{ Pattern = 'dynamic_array_resize_nested'; Flags = '-include {shims}/dynamic-array-resize-nested-c-shim.h' }
        @{ Pattern = 'dynamic_array_*'; Flags = '-include {shims}/dynamic-array-geometric-growth-c-shim.h' }
    )
    # Samples that also get a TypeScript row: every C-oracle sample whose TypeScript build agreed with C in the
    # 2026-10-05 sweep (the rest are C-only by design: ABI/libc fixtures, C dynamic-array shims, the harness core's C-only
    # byte macro, or a BackendSwitch without a TypeScript key).
    AlsoTypeScript = @(
        'samples/arithmetic_branch'
        'samples/backend_smoke'
        'samples/branch_select'
        'samples/dynamic_array_bool'
        'samples/dynamic_array_f64'
        'samples/dynamic_array_function_boundary'
        'samples/dynamic_array_mutable_alias'
        'samples/dynamic_array_nested'
        'samples/dynamic_array_record'
        'samples/dynamic_array_record_shared_alias'
        'samples/dynamic_array_return'
        'samples/dynamic_array_runtime_length'
        'samples/dynamic_array_shared_alias'
        'samples/dynamic_array_union'
        'samples/dynamic_array_union_nested'
        'samples/dynamic_array_union_nested_shared_alias'
        'samples/dynamic_array_union_shared_alias'
        'samples/expression_precedence'
        'samples/fixed_array_runtime_index'
        'samples/fixed_array_runtime_update'
        'samples/fixed_array_scalar'
        'samples/float_math'
        'samples/function_call'
        'samples/item_metadata_missing_target'
        'samples/lua_while_union_pair'
        'samples/managed_string_array'
        'samples/managed_string_builder'
        'samples/managed_string_codepoints'
        'samples/managed_string_concat'
        'samples/managed_string_empty_slice'
        'samples/managed_string_index'
        'samples/managed_string_invalid_utf8_slice'
        'samples/managed_string_record'
        'samples/managed_string_recursive'
        'samples/managed_string_runtime'
        'samples/managed_string_runtime_choice'
        'samples/managed_string_shared_calls'
        'samples/managed_string_slice'
        'samples/managed_string_union'
        'samples/managed_string_utf8_boundaries'
        'samples/multiline_comment'
        'samples/multiline_triple_string'
        'samples/native_bitwise_scalar'
        'samples/native_closure_array_capture'
        'samples/native_closure_branch'
        'samples/native_closure_capture'
        'samples/native_closure_captured_branch'
        'samples/native_closure_managed_capture'
        'samples/native_closure_managed_captured_branch'
        'samples/native_closure_managed_reuse'
        'samples/native_closure_multimodule'
        'samples/native_closure_multiowner'
        'samples/native_closure_nested_branch'
        'samples/native_closure_return'
        'samples/native_closure_reuse'
        'samples/native_closure_union_capture_method'
        'samples/native_closure_union_rec'
        'samples/native_float_infinity'
        'samples/native_float_math_family'
        'samples/native_float_pow_pi'
        'samples/native_float_sqrt'
        'samples/native_literal_join_args'
        'samples/native_managed_array_tail_recursion'
        'samples/native_managed_scc_tail_recursion'
        'samples/native_managed_tail_recursion'
        'samples/native_multimodule'
        'samples/native_prototype_record_callback'
        'samples/native_prototype_union_closure_method'
        'samples/native_recursive_tail_recursion'
        'samples/native_string_utf8_fold_source_invalid'
        'samples/native_string_utf8_grapheme_bounded_source_invalid'
        'samples/native_string_utf8_scalar_source_invalid'
        'samples/native_string_utf8_validate_source_invalid'
        'samples/native_tail_recursion'
        'samples/nested_tuple'
        'samples/portable_composite'
        'samples/predicate_call'
        'samples/record_value'
        'samples/recursive_union_list'
        'samples/recursive_union_managed'
        'samples/recursive_union_mutual'
        'samples/recursive_union_terminal_ownership'
        'samples/recursive_union_tree_shared'
        'samples/rust_emit_expr_macro'
        'samples/rust_global_item_macro'
        'samples/rust_static_closure_chain'
        'samples/rust_target_globals'
        'samples/static_string'
        'samples/tagged_union_enum'
        'samples/tagged_union_heterogeneous'
        'samples/tagged_union_scalar'
        'samples/tagged_union_three_case'
        'samples/tail_loop'
        'samples/target_global_conflict'
        'samples/tuple_mixed'
        'samples/tuple_pair'
        'samples/unsigned_mod'
    )

    # Backends a sample is compiled to, when not all four (Fsharp, C, Rust, Delphi). Contract and
    # megaproject samples are F# only, except the megaproject sub-packages listed here (runtime fixtures).
    Backends = @{
        # The Brzozowski matchers on every native backend, exit code as the verdict (C is the oracle as usual): runtime_native
        # (the typestate and a dozen matches), runtime_bench (derivatives, backtracking, the staged DFA and interned nodes
        # with memoized derivatives must agree), indexed_dfa_state_cardinality (the compile-time minimized DFA's compiled
        # core against run-time derivatives), inventory_closed_dfa_runtime (the inventory model's closed-DFA core).
        'Fsharp,C,Rust,Delphi' = @(
            'samples/mega_brzozowski_derivatives/indexed_dfa_state_cardinality'
            'samples/mega_brzozowski_derivatives/inventory_closed_dfa_runtime'
            'samples/mega_brzozowski_derivatives/runtime_bench'
            'samples/mega_brzozowski_derivatives/runtime_native'
            # Zeta, CIC and Self on the native backends: root contract + all_terminals, every check now a core-free op.
            'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
            # ERP: the 24 of its unreached programs that build without F# macros (real run-time code).
            'samples/mega_omniledger_erp_kernel/runtime_native'
            'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
            'samples/mega_zeta_structural_laboratory/runtime_native'
        )
        'C,Rust,Delphi' = @(
            # lane G's FOR-D, fixed in #79 (lane X): a non-i32, non-unit main is rejected by C, Rust and Delphi alike.
            'samples/native_main_return_type'
            'samples/arithmetic_branch'
            # hopac fix 24 (replayed arguments reversed); F# fails in both cores on the host's terminal check.
            'samples/native_literal_join_args'
            'samples/dynamic_array_bounds_negative'
            'samples/expression_precedence'
            'samples/float_math'
            'samples/function_call'
            'samples/managed_string_array'
            'samples/managed_string_builder'
            'samples/managed_string_codepoints'
            'samples/managed_string_concat'
            'samples/managed_string_empty_slice'
            'samples/managed_string_index'
            'samples/managed_string_invalid_utf8_slice'
            'samples/managed_string_record'
            'samples/managed_string_recursive'
            'samples/managed_string_runtime'
            'samples/managed_string_runtime_choice'
            'samples/managed_string_shared_calls'
            'samples/managed_string_slice'
            'samples/managed_string_union'
            'samples/managed_string_utf8_boundaries'
            'samples/native_bitwise_scalar'
            'samples/native_closure_array_capture'
            'samples/native_closure_branch'
            'samples/native_closure_capture'
            'samples/native_closure_captured_branch'
            'samples/native_closure_diamond_package'
            'samples/native_closure_external_package'
            'samples/native_closure_managed_capture'
            'samples/native_closure_managed_captured_branch'
            'samples/native_closure_managed_reuse'
            'samples/native_closure_nested_branch'
            'samples/native_closure_recursive_capture'
            'samples/native_closure_return'
            'samples/native_closure_reuse'
            'samples/native_closure_transitive_package'
            'samples/native_closure_transport'
            'samples/native_closure_union_capture_method'
            'samples/native_float_infinity'
            'samples/native_float_math_family'
            'samples/native_float_nan_is'
            'samples/native_float_pow_pi'
            'samples/native_float_sqrt'
            'samples/native_layout_heap'
            'samples/native_managed_array_tail_recursion'
            'samples/native_managed_scc_tail_recursion'
            'samples/native_managed_tail_recursion'
            'samples/native_managed_union_array_closure'
            'samples/native_managed_union_capture_record'
            'samples/native_managed_union_record_closure'
            'samples/native_multimodule'
            'samples/native_package_owned_array_failure'
            'samples/native_package_owned_array_transitive'
            'samples/native_package_owned_array_type'
            'samples/native_package_owned_managed_type'
            'samples/native_package_owned_type'
            'samples/native_package_prototype_record_callback'
            'samples/native_prototype_record_callback'
            'samples/native_prototype_union_closure_method'
            'samples/native_recursive_tail_recursion'
            'samples/native_source_package_prototype_record_callback'
            'samples/native_source_package_prototype_union_callback'
            'samples/native_source_package_prototype_union_callback_managed_single_owner'
            'samples/native_source_package_prototype_union_callback_managed_two_cases'
            'samples/native_tail_recursion'
            'samples/nested_tuple'
            'samples/predicate_call'
            'samples/recursive_union_terminal_ownership'
            'samples/rust_target_globals'
            'samples/static_string'
            'samples/tail_loop'
            'samples/tuple_pair'
            'samples/unsigned_mod'
        )
        'C' = @(
        # FOR-D repro (lane F): a nominal pattern around a union case drops the definition silently; do not bless its error.
        'samples/nominal_union_case_pattern'
        # FOR-D repro (lane F): inl recursion through a run-time match never reaches EJP0040; times out until fixed.
        'samples/runaway_inline_match_recursion'
        # FOR-D repro (lane F): a multi-line match scrutinee does not parse; do not bless its error.
        'samples/match_multiline_scrutinee'
        # FOR-D repro (lane G): a nominal's phantom type parameter is filled with the wrong type during partial
        # evaluation ("Type error in nominal constructor"); do not bless its error.
        'samples/nominal_phantom_parameter'
        # FOR-D repro (lane G): a type application continued on the next line inside a parameter annotation drops the
        # definition without a diagnostic; do not bless its error.
        'samples/multiline_type_application_dropped'
        # FOR-D repro (lane G): a GADT constructor pattern loses the enclosing function's constraint on the element
        # type ("Metavariable's constraints must be a subset of the forall var"); do not bless its error.
        'samples/gadt_match_loses_constraint'
        # FOR-D repro (lane G, a missing feature): an existential that reaches run time cannot be unpacked ("Cannot dyn
        # an existential into a runtime var"); do not bless its error.
        'samples/runtime_existential_unpack'
        # lane D: an inbuilt op's argument may be an application (lane C's FOR-D).
        'samples/op_args_application'
        # lane D: a folder's index module (lib/lib): lib.member from the folder; and the ambiguous negative (expected: error).
        'samples/folder_index_module'
        'samples/folder_index_module_ambiguous'
        # lane X: an empty `match` is a parse error the type-error report must name (lane H's FOR-D; expected: error).
        'samples/empty_match_parse_error'
        'samples/abi_external'
        'samples/abi_external_buffer_length_negative'
        'samples/abi_external_buffer_ownership_negative'
        'samples/abi_external_callback'
        'samples/abi_external_callback_dynamic_negative'
        'samples/abi_external_const_buffer'
        'samples/abi_external_i64'
        'samples/abi_external_mutable_buffer'
        'samples/abi_external_signature_mismatch'
        'samples/abi_external_string'
        'samples/abi_external_struct_argument'
        'samples/abi_external_struct_return'
        'samples/abi_external_struct_return_i64'
        'samples/abi_external_struct_return_i64_signature_mismatch'
        'samples/abi_external_unknown'
        'samples/dynamic_array_geometric_growth'
        'samples/dynamic_array_growth_union_managed'
        'samples/dynamic_array_growth_union_nested'
        'samples/dynamic_array_reserve_zero'
        'samples/dynamic_array_resize_alias'
        'samples/dynamic_array_resize_nested'
        'samples/dynamic_array_resize_union_managed'
        'samples/dynamic_array_string_resize'
        'samples/dynamic_array_string_union'
        'samples/dynamic_array_tuple_managed'
        'samples/native_managed_array_scc_tail_recursion'
        'samples/native_managed_array_scc3_tail_recursion'
            'samples/item_metadata_missing_target'
            'samples/native_closure_multimodule'
            'samples/native_closure_multiowner'
            'samples/native_cube_direct'
            'samples/native_cube_flush_delay_direct'
            'samples/native_cube_frame_direct'
            'samples/native_cube_frame_reuse_direct'
            'samples/native_cube_monotonic_delay_direct'
            'samples/native_cube_multiframe_direct'
            'samples/native_cube_paced_stream_direct'
            'samples/native_cube_terminal_stream_direct'
            'samples/native_managed_union_record_two_managed'
            'samples/native_package_closure_array_failure'
            'samples/native_package_closure_managed_branch'
            'samples/native_package_closure_managed_failure'
            'samples/native_package_fixed_array_local'
            'samples/native_package_fixed_array_mixed_runtime_write'
            'samples/native_package_fixed_array_mixed_types'
            'samples/native_package_fixed_array_numeric_widths'
            'samples/native_package_fixed_array_runtime_index'
            'samples/native_package_fixed_array_two_runtime_indexes'
            'samples/native_string_utf8_canonical_equal_bounded_source'
            'samples/native_string_utf8_fold_source'
            'samples/native_string_utf8_fold_source_invalid'
            'samples/native_string_utf8_grapheme_bounded_source'
            'samples/native_string_utf8_grapheme_bounded_source_invalid'
            'samples/native_string_utf8_normalization_bounded_source'
            'samples/native_string_utf8_scalar_source'
            'samples/native_string_utf8_scalar_source_invalid'
            'samples/native_string_utf8_validate_source'
            'samples/native_string_utf8_validate_source_invalid'
            # hopac fix 23 (replay repeated a join point call); C only like the utf8 fixtures above: single-flight's
            # Rust and Delphi for sm.utf8 code do not build (`found v7`, `uint8_t`).
            'samples/native_replay_repeat_call'
            'samples/target_global_conflict'
        )
        'Fsharp' = @(
            'samples/contract_atomic_flash_loan_clearing'
            'samples/contract_branch_indexed_quantum_merge'
            'samples/contract_capability_aligned_request_federation'
            'samples/contract_dependently_verified_federation'
            'samples/contract_dkg_ssle_epoch_leader'
            'samples/contract_effectful_forall_bottom'
            'samples/contract_gadt'
            'samples/contract_higher_rank_hot_swap'
            'samples/contract_keyed_reconciliation'
            'samples/contract_open_interpreter_deployment'
            'samples/contract_pbft_view_change_commit'
            'samples/contract_railway_interlocking_flank_release'
            'samples/contract_rank2_existential_migration'
            'samples/contract_region_indexed_variant_merge'
            'samples/contract_result_indexed_optimizer_families'
            'samples/contract_result_indexed_query_interpreters'
            'samples/contract_scope_lifecycle_disposal'
            'samples/contract_suspense_owner_cancellation'
            'samples/contract_trust_boundary_forall_failwith'
            'samples/contract_trust_boundary_forall_host_splice'
            'samples/contract_ui_scope_tree_teardown'
            'samples/contract_vickrey_sealed_bid_settlement'
            'samples/contract_zk_rollup_data_availability_finality'
            'samples/gadt_specialized_case_rank'
            'samples/hello'
            'samples/mega_brzozowski_derivatives'
            'samples/mega_lean_cic_bottom_up_kernel'
            'samples/mega_omniledger_erp_kernel'
            'samples/mega_spiral_proves_spiral_relative_consistency'
            'samples/mega_zeta_structural_laboratory'
        )
        # lane X (#82): lib/spiral on Zig; C and Delphi have no lib arms, so no C oracle (the Zig row runs, oracle no-c).
        'Fsharp,Rust' = @(
            'samples/zig_lib_console'
        )
        'C,Rust' = @(
            'samples/rust_box_dyn_moves'
            'samples/rust_consuming_json'
            'samples/rust_emit_expr_macro'
            'samples/rust_emit_tuple_args'
            'samples/rust_global_item_macro'
            'samples/rust_macro_reuse_clone'
            'samples/rust_near_store_moves'
            'samples/rust_static_closure_chain'
            'samples/rust_string_literal_path'
            'samples/rust_union_non_clone_payload'
        )
        # Portable fixtures for the newer backends (TypeScript; C++ host via g++ and Python on the CPU path, both from
        # upstream's CodegenCpp/CodegenPython): the C row of the same sample is the oracle (exit code + stdout).
        'Python' = @(
            'samples/python_foreign_array_index'
        )
        'C,Python' = @(
            'samples/python_macro_annotations'
        )
        'C,TypeScript,Cpp,Python' = @(
            # lane G's FOR-D, fixed in lane X's #73: a 5,000-deep self tail call loops on every backend (Python looped by
            # recursion until then: RecursionError past ~1,000 frames).
            'samples/python_self_tail_call_depth'
            'samples/ts_int_wrap'
            'samples/ts_union_recursive'
            'samples/ts_union_scalar'
            'samples/ts_closure_capture'
            'samples/ts_closure_return'
            'samples/ts_tail_loop'
            'samples/ts_string_slice'
            'samples/ts_string_concat'
            'samples/ts_tuple_mixed'
            'samples/ts_layout_heap'
            'samples/ts_layout_mutable'
            'samples/ts_while_loop'
            'samples/ts_array_union'
            'samples/ts_float_nan'
        )
        # lane W: the portable Printf (%s, %d, %%, several arguments) and type-checked op arguments (`*x`, `if`) print the
        # same bytes on every backend that runs here (C is the oracle; F# compiles; Lua and Gleam checked by the cube).
        'Fsharp,C,Rust,Delphi,TypeScript,Python' = @(
            'samples/printf_portable'
            'samples/op_args_deref_if'
        )
    }
    # Zig (#82, lane X): samples that also get a Zig row (test.ps1 Add-ZigBackend); C is the oracle. Brought up 2026-10-06 from
    # a probe of every example with a C residual: these agree with C (the rest: C-only macros/shims, value-level backend
    # switches without a Zig key, packages the probe could not resolve, C-only casts in macros like the utf8 fixtures).
    Zig = @(
        'samples/zig_lib_console'
        'samples/printf_portable'
        'samples/op_args_deref_if'
        'samples/backend_smoke'
        'samples/branch_select'
        'samples/dynamic_array_bool'
        'samples/dynamic_array_f64'
        'samples/dynamic_array_function_boundary'
        'samples/dynamic_array_mutable_alias'
        'samples/dynamic_array_nested'
        'samples/dynamic_array_record'
        'samples/dynamic_array_record_shared_alias'
        'samples/dynamic_array_return'
        'samples/dynamic_array_runtime_length'
        'samples/dynamic_array_shared_alias'
        'samples/dynamic_array_union'
        'samples/dynamic_array_union_nested'
        'samples/dynamic_array_union_nested_shared_alias'
        'samples/dynamic_array_union_shared_alias'
        'samples/expression_precedence'
        'samples/fixed_array_runtime_index'
        'samples/fixed_array_runtime_update'
        'samples/fixed_array_scalar'
        'samples/float_math'
        'samples/folder_index_module'
        'samples/frontier_fib'
        'samples/frontier_hello'
        'samples/frontier_macro_then_multiline_annotation'
        'samples/frontier_static_list_eq'
        'samples/frontier_try_item'
        'samples/function_call'
        'samples/item_metadata_missing_target'
        'samples/lua_while_union_pair'
        'samples/managed_string_array'
        'samples/managed_string_builder'
        'samples/managed_string_codepoints'
        'samples/managed_string_concat'
        'samples/managed_string_empty_slice'
        'samples/managed_string_index'
        'samples/managed_string_invalid_utf8_slice'
        'samples/managed_string_record'
        'samples/managed_string_recursive'
        'samples/managed_string_runtime'
        'samples/managed_string_runtime_choice'
        'samples/managed_string_shared_calls'
        'samples/managed_string_slice'
        'samples/managed_string_union'
        'samples/managed_string_utf8_boundaries'
        'samples/multiline_comment'
        'samples/multiline_triple_string'
        'samples/native_bitwise_scalar'
        'samples/native_closure_array_capture'
        'samples/native_closure_branch'
        'samples/native_closure_capture'
        'samples/native_closure_captured_branch'
        'samples/native_closure_managed_capture'
        'samples/native_closure_managed_captured_branch'
        'samples/native_closure_managed_reuse'
        'samples/native_closure_multimodule'
        'samples/native_closure_multiowner'
        'samples/native_closure_nested_branch'
        'samples/native_closure_recursive_capture'
        'samples/native_closure_return'
        'samples/native_closure_reuse'
        'samples/native_closure_transport'
        'samples/native_closure_union_capture_method'
        'samples/native_closure_union_rec'
        'samples/native_cube_direct'
        'samples/native_float_infinity'
        'samples/native_float_math_family'
        'samples/native_float_pow_pi'
        'samples/native_float_sqrt'
        'samples/native_literal_join_args'
        'samples/native_managed_array_tail_recursion'
        'samples/native_managed_scc_tail_recursion'
        'samples/native_managed_tail_recursion'
        'samples/native_managed_union_array_closure'
        'samples/native_managed_union_capture_record'
        'samples/native_managed_union_record_closure'
        'samples/native_managed_union_record_two_managed'
        'samples/native_multimodule'
        'samples/native_package_fixed_array_local'
        'samples/native_package_fixed_array_mixed_runtime_write'
        'samples/native_package_fixed_array_mixed_types'
        'samples/native_package_fixed_array_numeric_widths'
        'samples/native_package_fixed_array_runtime_index'
        'samples/native_package_fixed_array_two_runtime_indexes'
        'samples/native_package_owned_array_failure'
        'samples/native_package_owned_array_transitive'
        'samples/native_package_owned_array_type'
        'samples/native_package_owned_managed_type'
        'samples/native_package_owned_type'
        'samples/native_prototype_record_callback'
        'samples/native_prototype_union_closure_method'
        'samples/native_recursive_tail_recursion'
        'samples/native_tail_recursion'
        'samples/nested_tuple'
        'samples/nominal_union_case_pattern'
        'samples/op_args_application'
        'samples/portable_composite'
        'samples/predicate_call'
        'samples/python_self_tail_call_depth'
        'samples/record_value'
        'samples/recursive_union_list'
        'samples/recursive_union_managed'
        'samples/recursive_union_mutual'
        'samples/recursive_union_terminal_ownership'
        'samples/recursive_union_tree_shared'
        'samples/rust_emit_expr_macro'
        'samples/rust_global_item_macro'
        'samples/rust_static_closure_chain'
        'samples/rust_target_globals'
        'samples/static_string'
        'samples/tagged_union_enum'
        'samples/tagged_union_heterogeneous'
        'samples/tagged_union_scalar'
        'samples/tagged_union_three_case'
        'samples/tail_loop'
        'samples/target_global_conflict'
        'samples/ts_array_union'
        'samples/ts_closure_capture'
        'samples/ts_closure_return'
        'samples/ts_int_wrap'
        'samples/ts_string_concat'
        'samples/ts_string_slice'
        'samples/ts_tail_loop'
        'samples/ts_tuple_mixed'
        'samples/ts_union_recursive'
        'samples/ts_union_scalar'
        'samples/tuple_mixed'
        'samples/tuple_pair'
        'samples/unsigned_mod'
    )
}
