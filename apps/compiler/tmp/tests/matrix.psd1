@{
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

    FsharpContracts = @(
        'samples/contract_effectful_forall_bottom'
        'samples/mega_omniledger_erp_kernel/all_terminals'
    )

    Fast = @{
        BudgetSeconds = 600
        MatureRuns = 5
        MaxTimeoutShare = 0.2
        RecentCostRuns = 7
    }

    Known = @(
        @{ Id = 'samples/mega_brzozowski_derivatives/runtime_bench'; Backend = 'Lua'; Reason = 'exact 64-bit integers (spiral_w64 helpers) make it agree with C, but its Lua run takes about 17.4 s against the 20 s row timeout, so under suite load it would time out and break baseline reproduction' }
        @{ Id = 'samples/native_cube_flush_delay_direct'; Backend = 'C'; Platform = 'Windows'; Reason = 'POSIX-only residual (poll.h); native C runs only on Linux' }
        @{ Id = 'samples/native_cube_monotonic_delay_direct'; Backend = 'C'; Platform = 'Windows'; Reason = 'POSIX-only residual (poll.h/clock_gettime); native C runs only on Linux' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Rust'; Oracle = 'C'; Reason = 'C residual has no bounds check (exits 0); Rust panics as the fixture intends' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Zig'; Oracle = 'C'; Reason = 'C residual has no bounds check (exits 0); Zig traps the index (exit 3) as the fixture intends' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Gleam'; Oracle = 'C'; Reason = 'C residual has no bounds check (exits 0); Gleam''s checked SpiralArray index halts with 3 as the fixture intends' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Lean'; Oracle = 'C'; Reason = 'C residual has no bounds check (exits 0); Lean''s checked index exits 3 as the fixture intends' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Bend'; Oracle = 'C'; Reason = 'C residual has no bounds check (exits 0); Bend''s checked array cell exits 3 as the fixture intends' }
        @{ Id = 'samples/lua_wide_integers'; Backend = 'Bend'; Reason = 'pairs i64 with f64, and Bend 2 has F32 only, so it fails on Float64T before the w64 path (BEND-BACKEND)' }
        @{ Id = 'samples/portable_console_lines'; Backend = 'Bend'; Reason = 'console.write_line lowers to a unit macro, which the Bend backend does not support yet (BEND-BACKEND)' }
        @{ Id = 'samples/union_i64_text'; Backend = 'Bend'; Reason = 'bend2 rejects the emitted union of i64 text (SOME PROOFS FAIL: expected Data, observed Type), a codegen gap (BEND-BACKEND)' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'C'; Oracle = 'Zig'; Reason = 'C indexes unchecked (reads 0); the Zig oracle traps the index with exit 3 as the fixture intends' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Delphi'; Oracle = 'Zig'; Reason = 'Delphi indexes unchecked (reads 0); the Zig oracle traps the index with exit 3 as the fixture intends' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Wasm'; Oracle = 'Zig'; Reason = 'the Wasm array index is unchecked (reads 0); the Zig oracle traps the index with exit 3 as the fixture intends' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Kotlin'; Oracle = 'Zig'; Reason = 'Kotlin indexes unchecked like C (reads 0); the Zig oracle traps the index with exit 3 as the fixture intends' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Lua'; Oracle = 'Zig'; Reason = 'the Lua array index is unchecked (reads 0); the Zig oracle traps the index with exit 3 as the fixture intends' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Rust'; Oracle = 'Zig'; Reason = 'Rust checks the index too but panics with exit 1 where the Zig oracle traps with exit 3; both reject the index as the fixture intends' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Wgsl'; Oracle = 'Zig'; Reason = 'WGSL robust buffer access makes the out-of-bounds read unchecked (exits 0 like C); the Zig oracle traps the index with exit 3 as the fixture intends' }
        @{ Id = 'samples/native_float_infinity'; Backend = 'Gleam'; Reason = 'BEAM floats are never infinite or NaN: a 0x7FF0000000000000 float bit-pattern match fails and binary_to_term raises badarg, so !!!!Infinity has no Gleam residual that compiles' }
        @{ Id = 'samples/while_control'; Backend = 'Fsharp'; Reason = 'F# has no break or continue statements, and the sample''s break''/continue'' are raw break/continue macros' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/all_terminals'; Backend = 'Fsharp'; Platform = 'Windows'; Reason = 'the F# residual starts /usr/bin/sync (POSIX-only), so it exits 1 on Windows, and its run sits near the 60 s fsi budget' }
        @{ Id = 'samples/mega_omniledger_erp_kernel'; Backend = 'Fsharp'; Platform = 'Windows'; Reason = 'its F# macros spawn /bin/sh (main.fsx:14): exit 1 on Windows, 0 on Linux; the row has no oracle row, so the entry only marks it platform-bound for ci-classify' }
    )

    Mega = @(
        @{ Name = 'ERP'; Title = 'OmniLedger ERP kernel'; Source = 'samples/mega_omniledger_erp_kernel/main.spi' }
        @{ Name = 'Zeta'; Title = 'Structural factorization laboratory'; Source = 'samples/mega_zeta_structural_laboratory/main.spi' }
        @{ Name = 'CIC'; Title = 'Lean CIC bottom-up kernel'; Source = 'samples/mega_lean_cic_bottom_up_kernel/main.spi' }
        @{ Name = 'Self'; Title = 'Spiral proves Spiral relative-consistency laboratory'; Source = 'samples/mega_spiral_proves_spiral_relative_consistency/main.spi' }
        @{ Name = 'Brzozowski'; Title = 'Brzozowski derivative matcher'; Source = 'samples/mega_brzozowski_derivatives/main.spi' }
    )

    Timeouts = @{
        'samples/runaway_inline_match_recursion' = 120
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
        'samples/mega_omniledger_erp_kernel/all_terminals' = 180
        'samples/mega_zeta_structural_laboratory/all_terminals' = 180
        'samples/mega_lean_cic_bottom_up_kernel/all_terminals' = 180
        'samples/mega_spiral_proves_spiral_relative_consistency/all_terminals' = 180
        'samples/mega_zeta_structural_laboratory/runtime_native' = 180
        'samples/mega_omniledger_erp_kernel/runtime_native' = 180
        'samples/mega_lean_cic_bottom_up_kernel/runtime_native' = 180
        'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native' = 180
    }

    ZigShims = @(
        @{ Pattern = 'abi_external_buffer_length_negative'; Shim = 'abi-external-mutable-buffer-zig-shim.zig' }
        @{ Pattern = 'abi_external_callback'; Shim = 'abi-external-callback-zig-shim.zig' }
        @{ Pattern = 'abi_external_struct_argument'; Shim = 'abi-external-struct-argument-zig-shim.zig' }
        @{ Pattern = 'abi_external_struct_return_i64'; Shim = 'abi-external-struct-return-i64-zig-shim.zig' }
        @{ Pattern = 'abi_external_struct_return'; Shim = 'abi-external-struct-return-zig-shim.zig' }
        @{ Pattern = 'abi_external_const_buffer'; Shim = 'abi-external-const-buffer-zig-shim.zig' }
        @{ Pattern = 'abi_external_mutable_buffer'; Shim = 'abi-external-mutable-buffer-zig-shim.zig' }
        @{ Pattern = 'abi_external_string'; Shim = 'abi-external-string-zig-shim.zig' }
        @{ Pattern = 'abi_external'; Shim = 'abi-external-zig-shim.zig' }
        @{ Pattern = 'abi_external_i64'; Shim = 'abi-external-i64-zig-shim.zig' }
    )

    CFlags = @(
        @{ Pattern = 'native_float_*'; Flags = '-lm' }
        @{ Pattern = 'abi_external_buffer_length_negative'; Flags = '-include {shims}/abi-external-mutable-buffer-c-shim.h' }
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
    AlsoTypeScript = @(
        'samples/frontier_gadt_growing_index'
        'samples/macro_splice_before_quote'
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
        'samples/array_bool', 'samples/array_cell', 'samples/array_closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/array_create_reads_zero', 'samples/array_f32', 'samples/array_f64', 'samples/array_fun', 'samples/array_heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/array_heap_f32', 'samples/array_heap_heap', 'samples/array_heap_heap_heap', 'samples/array_heap_heap_pair', 'samples/array_heap_mix', 'samples/array_heap_pair_heaps', 'samples/array_heap_triple_heaps', 'samples/array_heap_union_heap_pair_heaps', 'samples/array_heap_union_heap_union_heap_pair_heaps', 'samples/array_i16', 'samples/array_i32', 'samples/array_i64', 'samples/array_i64_at1', 'samples/array_i8', 'samples/array_mut', 'samples/array_mut_f32', 'samples/array_mut_heap_heap', 'samples/array_mut_heap_heap_pair', 'samples/array_mut_heap_union_heap_pair_heaps', 'samples/array_mut_heap_union_heap_union_heap_pair_heaps', 'samples/array_mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/array_mut_pair', 'samples/array_mut_pair_heaps', 'samples/array_mut_triple_heaps', 'samples/array_text', 'samples/array_text_at1', 'samples/array_u16', 'samples/array_u32', 'samples/array_u64', 'samples/array_u8', 'samples/array_union', 'samples/array_union_heap_heap', 'samples/array_union_heap_pair_heaps', 'samples/array_union_heap_union_heap_pair_heaps', 'samples/array_union_pair_heaps', 'samples/array_union_text', 'samples/array_union_triple_heaps', 'samples/array_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/array2_heap_union_heap_union_heap_pair_heaps', 'samples/array3_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/c_deep_list_decref', 'samples/c_gadt_union_array', 'samples/c_self_tail_loop_heap', 'samples/closure_apply', 'samples/closure_array', 'samples/closure_curry', 'samples/closure_depth', 'samples/closure_f32_heap', 'samples/closure_heap', 'samples/closure_heap_heap', 'samples/closure_heap_heap_heap', 'samples/closure_heap_pair_heaps', 'samples/closure_heap_union_heap_pair_heaps', 'samples/closure_heap_union_heap_union_heap_pair_heaps', 'samples/closure_heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/closure_mut', 'samples/closure_mut_pair', 'samples/closure_pair', 'samples/closure_pair_array', 'samples/closure_pair_bool', 'samples/closure_pair_cell', 'samples/closure_pair_f32', 'samples/closure_pair_f64', 'samples/closure_pair_fun', 'samples/closure_pair_heap', 'samples/closure_pair_heaps', 'samples/closure_pair_i64', 'samples/closure_pair_i8', 'samples/closure_pair_mix', 'samples/closure_pair_slot', 'samples/closure_pair_text', 'samples/closure_pair_union', 'samples/closure_pair_union_heap', 'samples/closure_real', 'samples/closure_return', 'samples/closure_return_heap', 'samples/closure_return_text', 'samples/closure_text', 'samples/closure_text_pair', 'samples/closure_triple', 'samples/closure_triple_heaps', 'samples/closure_u32_flag', 'samples/closure_union', 'samples/closure_union_heap_heap', 'samples/closure_union_heap_pair_heaps', 'samples/closure_union_heap_union_heap_pair_heaps', 'samples/closure_union_mix', 'samples/closure_union_pair_heaps', 'samples/closure_union_triple_heaps', 'samples/closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/closure_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/ebpf_arith', 'samples/ebpf_bacc', 'samples/ebpf_bits', 'samples/ebpf_bool', 'samples/ebpf_cast', 'samples/ebpf_char', 'samples/ebpf_conv', 'samples/ebpf_div', 'samples/ebpf_facc', 'samples/ebpf_fdiv', 'samples/ebpf_float', 'samples/ebpf_flt', 'samples/ebpf_ineq', 'samples/ebpf_neq', 'samples/ebpf_nest3', 'samples/ebpf_sh31', 'samples/ebpf_shift', 'samples/ebpf_snot', 'samples/ebpf_t2', 'samples/ebpf_t3', 'samples/ebpf_tacc', 'samples/ebpf_tworec', 'samples/ebpf_uacc', 'samples/ebpf_uadd', 'samples/ebpf_umul', 'samples/f64_scalar', 'samples/failwith_exit', 'samples/folder_index_module', 'samples/frontier_fib', 'samples/frontier_hello', 'samples/frontier_macro_then_multiline_annotation', 'samples/frontier_try_item', 'samples/gadt_lazy_payload', 'samples/gadt_match_loses_constraint', 'samples/gleam_match_narrowed', 'samples/gleam_match_single_case', 'samples/heap_array', 'samples/heap_array_f32', 'samples/heap_array_n', 'samples/heap_bool', 'samples/heap_bool_text', 'samples/heap_closure', 'samples/heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/heap_f32_n', 'samples/heap_f32_text', 'samples/heap_f32_u32', 'samples/heap_f64s', 'samples/heap_fun', 'samples/heap_heap', 'samples/heap_heap_heap', 'samples/heap_heap_pair_heaps', 'samples/heap_i16_text', 'samples/heap_i64_real', 'samples/heap_i64_text', 'samples/heap_i8', 'samples/heap_i8_text', 'samples/heap_mut_cell', 'samples/heap_nest', 'samples/heap_pair', 'samples/heap_pair_heaps', 'samples/heap_pair_mix', 'samples/heap_real', 'samples/heap_real_text', 'samples/heap_slot', 'samples/heap_text', 'samples/heap_text_eq', 'samples/heap_text_pair', 'samples/heap_texts', 'samples/heap_texts_flag', 'samples/heap_triple', 'samples/heap_triple_heaps', 'samples/heap_u16_text', 'samples/heap_u32_flag', 'samples/heap_u32_text', 'samples/heap_u64_text', 'samples/heap_u8_text', 'samples/heap_union', 'samples/heap_union_heap_pair_heaps', 'samples/heap_union_heap_union_heap_pair_heaps', 'samples/heap_union_pair_heaps', 'samples/heap_union_triple_heaps', 'samples/heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/i64_scalar', 'samples/lua_wide_integers', 'samples/match_multiline_scrutinee', 'samples/method_array', 'samples/method_depth', 'samples/method_heap', 'samples/method_i8', 'samples/method_mut', 'samples/method_mut_pair', 'samples/method_pair_cell', 'samples/method_pair_f64', 'samples/method_pair_fun', 'samples/method_pair_heap', 'samples/method_pair_mix', 'samples/method_pair_slot', 'samples/method_pair_text', 'samples/method_pair_union', 'samples/method_pair_union_heap', 'samples/method_real', 'samples/method_return', 'samples/method_text', 'samples/method_text_pair', 'samples/method_union', 'samples/method_union_mix', 'samples/multiline_type_application_dropped', 'samples/mut_f32_text', 'samples/mut_heap_heap', 'samples/mut_heap_heap_heap', 'samples/mut_heap_heap_pair', 'samples/mut_heap_union_heap_pair_heaps', 'samples/mut_heap_union_heap_union_heap_pair_heaps', 'samples/mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/mut_i64_text', 'samples/mut_pair', 'samples/mut_pair_heaps', 'samples/mut_real_text', 'samples/mut_text', 'samples/mut_text_pair', 'samples/mut_triple_heaps', 'samples/mut_u32_text', 'samples/mutable_alias_method_branch', 'samples/native_closure_diamond_package', 'samples/native_closure_external_package', 'samples/native_closure_recursive_capture', 'samples/native_closure_transitive_package', 'samples/native_closure_transport', 'samples/native_cube_direct', 'samples/native_layout_heap', 'samples/native_layout_mutable', 'samples/native_managed_union_array_closure', 'samples/native_managed_union_capture_record', 'samples/native_managed_union_record_closure', 'samples/native_managed_union_record_two_managed', 'samples/native_package_fixed_array_local', 'samples/native_package_fixed_array_mixed_runtime_write', 'samples/native_package_fixed_array_mixed_types', 'samples/native_package_fixed_array_numeric_widths', 'samples/native_package_fixed_array_runtime_index', 'samples/native_package_fixed_array_two_runtime_indexes', 'samples/native_package_owned_array_failure', 'samples/native_package_owned_array_transitive', 'samples/native_package_owned_array_type', 'samples/native_package_owned_managed_type', 'samples/native_package_owned_type', 'samples/native_package_prototype_record_callback', 'samples/native_replay_repeat_call', 'samples/native_source_package_prototype_record_callback', 'samples/native_source_package_prototype_union_callback', 'samples/native_source_package_prototype_union_callback_managed_single_owner', 'samples/native_source_package_prototype_union_callback_managed_two_cases', 'samples/native_string_utf8_canonical_equal_bounded_source', 'samples/native_string_utf8_fold_source', 'samples/native_string_utf8_grapheme_bounded_source', 'samples/native_string_utf8_normalization_bounded_source', 'samples/native_string_utf8_scalar_source', 'samples/native_string_utf8_validate_source', 'samples/nominal_phantom_parameter', 'samples/nominal_record_field_order', 'samples/nominal_union_case_pattern', 'samples/op_args_application', 'samples/package_default_int_i64', 'samples/qualified_union_case_pattern', 'samples/recur_sum', 'samples/recursive_union_multi_case', 'samples/small_int_ops', 'samples/small_int_scalar', 'samples/string_eq', 'samples/string_ord', 'samples/string_utf8', 'samples/typecheck_long_let_body', 'samples/union_array', 'samples/union_array_mix', 'samples/union_bool', 'samples/union_call', 'samples/union_case_record_field_order', 'samples/union_cell_mix', 'samples/union_f32_text', 'samples/union_f64s', 'samples/union_fun_mix', 'samples/union_heap', 'samples/union_heap_heap', 'samples/union_heap_heap_heap', 'samples/union_heap_pair_heaps', 'samples/union_heap_union_heap_pair_heaps', 'samples/union_i64_text', 'samples/union_i8', 'samples/union_i8_text', 'samples/union_mut', 'samples/union_nested', 'samples/union_option', 'samples/union_pair', 'samples/union_pair_heaps', 'samples/union_pair_mix', 'samples/union_real', 'samples/union_real_mix', 'samples/union_text', 'samples/union_text_pair', 'samples/union_texts', 'samples/union_texts_flag', 'samples/union_triple_heaps', 'samples/union_triple_mix', 'samples/union_u32_flag', 'samples/union_u32_text', 'samples/union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/union3_heap_union_heap_union_heap_pair_heaps', 'samples/upstream_type_if', 'samples/wgsl_array_scalar', 'samples/wgsl_array_tuple', 'samples/wgsl_gadt_payload_union', 'samples/wgsl_nullary_union', 'samples/wgsl_payload_union', 'samples/wgsl_record_loop', 'samples/wgsl_tail_call_in_match', 'samples/wgsl_unit_self_loop'
        'samples/frontier_format_any_union'
        'samples/frontier_hopacsota_globals_order'
        'samples/frontier_hopacsota_mutual_pending'
        'samples/frontier_hopacsota_recursion_inferred'
        'samples/frontier_join_format_any'
        'samples/frontier_static_list_eq'
        'samples/mega_brzozowski_derivatives/indexed_dfa_state_cardinality'
        'samples/mega_brzozowski_derivatives/inventory_closed_dfa_runtime'
        'samples/mega_brzozowski_derivatives/runtime_bench'
        'samples/mega_brzozowski_derivatives/runtime_native'
        'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
        'samples/mega_omniledger_erp_kernel/runtime_native'
        'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
        'samples/mega_zeta_structural_laboratory/runtime_native'
    )

    ExpectedErrors = @(
        @{ Id = 'samples/routes_negative_missing_param'; Contains = 'the route /articles/:slug/comments does not name exactly' }
        @{ Id = 'samples/routes_negative_extra_param'; Contains = 'the route /articles/:slug/comments/:id/:extra does not name exactly' }
        @{ Id = 'samples/routes_negative_wrong_name'; Contains = 'the route /articles/:slugx/comments/:id does not name exactly' }
        @{ Id = 'samples/conversation_negative_orphan_result'; Contains = 'Expected: transcript no_pending' }
        @{ Id = 'samples/conversation_negative_unanswered_call'; Contains = 'Expected: transcript no_pending' }
        @{ Id = 'samples/reactors_negative_port_type'; Contains = 'Expected: {init : f64; react : f64 -> {time : i64; micro : i32} -> signal i64' }
        @{ Id = 'samples/frontier_hopacsota_two_errors'; Contains = 'first body fails' }
        @{ Id = 'samples/frontier_hopacsota_deferred_validation_mismatch'; Contains = 'The backend switch needs to have the same type for all of its branches.' }
        @{ Id = 'samples/gadt_growing_index_runtime'; Contains = 'has no finite layout' }
        @{ Id = 'samples/backend_switch_missing_arm_negative'; Contains = 'reaches a lib/spiral backend_switch that has no arm for the' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_alphabet_mix'; Contains = 'Got: (tri_alphabet : *) Expected: (bit_alphabet : *)' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_antimirov_support_assignment_count'; Contains = 'Unification failure. Got: antimirov_support_slot_assignment' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_exact_rows_not_soundness_witness'; Contains = 'Unification failure. Got: indexed_dfa_exact_transition_rows bit_alphabet' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_finite_index_out_of_range'; Contains = 'Got: finite_symbol_index finite_length_zero Expected: finite_symbol_index (finite_length_succ _)' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_hkt_batch_predicate_specific'; Contains = 'Got: forall alphabet. matcher_program alphabet -> bool Expected: matcher_program bit_alphabet -> bool' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_hkt_requires_capability_capture'; Contains = 'Got: forall alphabet. matcher_case alphabet' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_indexed_descriptor_local_cardinality'; Contains = 'Got: finite_symbol_vector bit_alphabet _ Expected: finite_symbol_vector bit_alphabet (finite_length_succ' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_indexed_dfa_quotient_coverage_count'; Contains = 'Unification failure. Got: indexed_dfa_quotient_coverage' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_indexed_dfa_representative_origin_count'; Contains = 'Unification failure. Got: indexed_dfa_representative_origins' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_indexed_row_length'; Contains = 'Got: indexed_dfa_transition_vector bit_alphabet (finite_length_succ finite_length_zero)' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_missing_alphabet_symbols'; Contains = 'lone_alphabet does not have the prototype finite_alphabet' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_missing_compare'; Contains = 'orphan_alphabet does not have the prototype symbol_compare' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_missing_finite_inventory_witness'; Contains = 'lone_alphabet does not have the prototype finite_alphabet' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_missing_rank_lookup'; Contains = 'paired_alphabet does not have the prototype finite_alphabet' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_phase_use'; Contains = 'Got: bit_matcher_state matcher_decided Expected: bit_matcher_state matcher_raw' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_raw_generic_state_seal'; Contains = 'Got: matcher_state bit_alphabet matcher_decided Expected: matcher_state bit_alphabet matcher_raw' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_raw_indexed_not_structural_support_bound'; Contains = 'Unification failure. Got: antimirov_support_vector bit_alphabet' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_raw_inventory_bypass'; Contains = 'Got: certified_alphabet_inventory bit_alphabet Expected: symbol_list bit_alphabet' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_raw_quotient_not_semantic_witness'; Contains = 'Unification failure. Got: indexed_dfa_quotient_coverage' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_raw_regex_not_positioned_bound'; Contains = 'Got: regex bit_alphabet Expected: antimirov_positioned_regex _ bit_alphabet' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_raw_representatives_not_minimality_witness'; Contains = 'Unification failure. Got: indexed_dfa_state_vector bit_alphabet' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_truncated_canonical_vector'; Contains = 'Unification failure. Got: finite_symbol_vector bit_alphabet (finite_length_succ finite_length_zero)' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_derivative_skip_normalization'; Contains = 'derivative_normalized Expected: derivative_pipeline' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_seal_unverified_derivative'; Contains = 'derivative_verified Expected: derivative_pipeline' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_derivative_runtime_phase_use'; Contains = 'derivative_runtime_checked Expected: derivative_runtime_state' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_inventory_length_mix'; Contains = 'finite_symbol_vector tri_alphabet' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_antimirov_slot_shape'; Contains = 'antimirov_origin_slot position_shape_' }
        @{ Id = 'samples/mega_brzozowski_derivatives/negative_derivative_program_missing_symbols'; Contains = 'law_only_alphabet does not have the prototype finite_alphabet' }
        @{ Id = 'samples/missing_core_negative'; Contains = 'Unbound term variable: +.' }
        @{ Id = 'samples/multiline_comment_unterminated'; Contains = 'Unterminated multiline comment' }
        @{ Id = 'samples/multiline_triple_string_unterminated'; Contains = 'Unterminated triple-quoted string' }
        @{ Id = 'samples/multiline_triple_string_under_indented'; Contains = 'indented less than its closing quotes' }
        @{ Id = 'samples/native_fptr_capture_negative'; Contains = 'Function pointers shouldn''t have any runtime free variables' }
        @{ Id = 'samples/native_layout_stack_mutable_string_negative'; Contains = 'support stack mutable layout types' }
        @{ Id = 'samples/native_prototype_union_closure_method_missing_instance'; Contains = 'does not have the prototype score' }
        @{ Id = 'samples/union_case_ambiguity_negative'; Contains = 'ETY-UnionCaseAmbiguous: The union case Hit is defined by more than one opened module' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_atomic_defeq_sort_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term empty_ctx bool_sort Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_capture'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term (ctx_extend empty_ctx bool_sort) bool_sort Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_context_sort_indexed_membership_sort_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_meta_open_membership empty_ctx (universe_sort universe_one) (corrected_cic_meta_states_open empty_ctx bool_sort (corrected_cic_meta_states_open empty_ctx (universe_sort universe_one) (corrected_cic_meta_states_solved empty_ctx bool_sort corrected_cic_meta_states_empty))) (corrected_cic_meta_states_open empty_ctx bool_sort (corrected_cic_meta_states_solved empty_ctx (universe_sort universe_one) (corrected_cic_meta_states_solved empty_ctx bool_sort corrected_cic_meta_states_empty))) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_conversion_constraint_sort_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term empty_ctx (universe_sort universe_one) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_dependent_cross_pair'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_bool_dependent_result corrected_cic_bool_false_index Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_dependent_pi_domain_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: binder empty_ctx bool_sort Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_dependent_result_type'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term empty_ctx bool_sort Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_general_dependent_application_argument_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term empty_ctx bool_sort Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_general_dependent_lambda_binder_body_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term (ctx_extend empty_ctx bool_sort) (universe_sort universe_one) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_general_pi_binder_body_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term (ctx_extend empty_ctx bool_sort) (universe_sort universe_one) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_indexed_dependent_application_result_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_indexed_dependent_application (corrected_cic_substituted_codomain corrected_cic_identity_codomain_code corrected_cic_closed_type_code_bool) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_indexed_unary_constructor_application_result_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_indexed_dependent_application (corrected_cic_substituted_codomain corrected_cic_unary_constructor_codomain_code corrected_cic_closed_type_code_bool) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_intrinsic_constraint_raw_relation'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_scoped_pi_dependent_application_intrinsic_acceptance ctx domain Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_iota_indexed_action_reduction_cross_category'; Contains = 'ETY-TermError: Unification failure. Got: cic_verified_inductive_iota_contractum_action cic_verified_inductive_iota_recursive_conclusion_category Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_iota_indexed_conclusion_cross_category'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_generic_identity_beta_step empty_ctx bool_sort Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_iota_indexed_recursor_component_cross_category'; Contains = 'ETY-TermError: Unification failure. Got: cic_verified_inductive_iota_indexed_witness cic_verified_inductive_iota_recursive_conclusion_category Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_legacy_application_codomain_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term empty_ctx (function_sort bool_sort bool_sort) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_legacy_let_codomain_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term (ctx_extend empty_ctx bool_sort) bool_sort Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_membership_identity_authority_not_scalar'; Contains = 'ETY-TermError: Unification failure. Got: exists identity. corrected_cic_typed_meta_id identity * corrected_cic_typed_meta_identity_decision identity expected Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_meta_assignment_future_dependency'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_meta_solved_membership empty_ctx bool_sort (corrected_cic_meta_states_solved empty_ctx bool_sort corrected_cic_meta_states_empty) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_meta_authority_forged_solved'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_meta_authority (corrected_cic_meta_states_open empty_ctx bool_sort corrected_cic_meta_states_empty) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_nondefeq_authority_not_intrinsic_application'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_scoped_application_intrinsic_defeq _ empty_ctx bool_sort Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_nondefeq_authority_not_scoped_pi_authority'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_scoped_pi_term_authority ctx domain Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_nondefeq_not_defeq_pair_authority'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_structural_defeq_pair_authority ctx sort Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_ordinary_identity_beta_source_sort_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_ordinary_identity_whnf_step empty_ctx (universe_sort universe_one) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_ordinary_identity_beta_target_sort_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_ordinary_identity_whnf_step empty_ctx (universe_sort universe_one) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_programmed_dependent_application_result_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_programmed_dependent_application (corrected_cic_substituted_codomain corrected_cic_unary_constructor_codomain_code corrected_cic_closed_type_code_bool) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_programmed_endpoint_cross_codomain'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_programmed_dependent_application (corrected_cic_substituted_codomain corrected_cic_identity_codomain_code corrected_cic_closed_type_code_sort_zero) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_recursive_codomain_application_depth_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_recursive_codomain_program (corrected_cic_recursive_codomain_unary (corrected_cic_recursive_codomain_unary corrected_cic_recursive_codomain_identity)) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_scalar_decision_authority_not_intrinsic'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_scoped_pi_dependent_application_intrinsic_defeq empty_ctx (universe_sort universe_one) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_scalar_defeq_cannot_be_pair_authority'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_structural_defeq_pair_authority empty_ctx bool_sort Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_scoped_application_obstruction_not_intrinsic'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_scoped_application_intrinsic_defeq empty_ctx bool_sort bool_sort Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_total_substitution_domain_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term (ctx_extend empty_ctx bool_sort) (function_sort bool_sort bool_sort) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_two_meta_assignment_sort_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term empty_ctx (universe_sort universe_one) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_two_meta_duplicate_first_assignment'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_meta_open_membership empty_ctx bool_sort (corrected_cic_meta_states_open empty_ctx bool_sort (corrected_cic_meta_states_open empty_ctx (universe_sort universe_one) (corrected_cic_meta_states_open empty_ctx bool_sort corrected_cic_meta_states_empty))) (corrected_cic_meta_states_open empty_ctx bool_sort (corrected_cic_meta_states_open empty_ctx (universe_sort universe_one) (corrected_cic_meta_states_solved empty_ctx bool_sort corrected_cic_meta_states_empty))) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_two_meta_second_self_reference'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_meta_solved_membership empty_ctx bool_sort (corrected_cic_meta_states_solved empty_ctx bool_sort (corrected_cic_meta_states_open empty_ctx (universe_sort universe_one) (corrected_cic_meta_states_open empty_ctx bool_sort corrected_cic_meta_states_empty))) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_typed_meta_identity_decision_not_scalar'; Contains = 'ETY-TermError: Unification failure. Got: i64 Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_unification_assignment_sort_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term empty_ctx (universe_sort universe_one) Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_unification_constraint_context_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term (ctx_extend empty_ctx bool_sort) bool_sort Expected: ' }
        @{ Id = 'samples/mega_lean_cic_bottom_up_kernel/negative_whnf_sort_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: corrected_cic_term empty_ctx (universe_sort universe_one) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_closed_fact_input_wrong_history'; Contains = 'ETY-TermError: Unification failure. Got: typed_fx_hashed_statement_closed_history typed_fx_hashed_statement_history_empty typed_fx_statement_stream_position_zero Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_competing_successor_fence_wrong_after'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_competing_successor_fence_receipt (nat_succ nat_zero) (nat_succ (nat_succ nat_zero)) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_cross_process_fence_restart_wrong_after'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_cross_process_fence_restart_receipt (nat_succ (nat_succ nat_zero)) (nat_succ (nat_succ (nat_succ nat_zero))) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_direct_marker_sync'; Contains = 'ETY-TermError: Unification failure. Got: typed_fx_statement_durable_commit typed_fx_statement_durable_data_synced Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_equal_hash_collision'; Contains = 'ETY-TermError: Unification failure. Got: typed_fx_statement_payload_hash_not_equal typed_fx_statement_payload_hash_changed typed_fx_statement_payload_hash_primary Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_erp_step_detached_result'; Contains = 'ETY-TermError: Unification failure. Got: erp_op requisition_drafted budget_reserved _ Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_event_payload_codec_cross_family'; Contains = 'ETY-TermError: Unification failure. Got: erp_plan approvals_collected purchase_order_issued Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_external_crash_recovery_receipt_version_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_event_commit_tree (nat_succ (nat_succ (nat_succ (nat_succ nat_zero)))) requisition_drafted goods_partially_received Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_fact_derived_observation_cross_outcome'; Contains = 'ETY-TermError: Unification failure. Got: typed_fx_hashed_statement_identity_collision typed_fx_statement_command_identity_primary typed_fx_statement_payload_hash_primary (typed_fx_hashed_statement_history_more typed_fx_statement_command_identity_primary typed_fx_statement_aggregate_identity_primary typed_fx_statement_payload_hash_primary typed_fx_hashed_statement_history_empty) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_four_owner_lineage_cannot_force_nat_two'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_fence_history (nat_succ (nat_succ nat_zero)) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_multiprocess_fenced_commit_wrong_endpoint'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_multiprocess_fenced_commit_receipt (nat_succ nat_zero) (nat_succ (nat_succ (nat_succ (nat_succ nat_zero)))) (nat_succ (nat_succ (nat_succ (nat_succ nat_zero)))) requisition_drafted goods_partially_received Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_multiprocess_fenced_physical_append_wrong_endpoint'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_multiprocess_fenced_physical_append_receipt (nat_succ nat_zero) (nat_succ (nat_succ (nat_succ (nat_succ nat_zero)))) (nat_succ (nat_succ (nat_succ (nat_succ nat_zero)))) requisition_drafted goods_partially_received Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_net_intercompany_detached_mirrors'; Contains = 'ETY-TermError: Unification failure. Got: opposed_mirror_pair company_a ''a usd po_1001 Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_p2p_commit_tree_skipped_middle'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_unit_event budget_reserved purchase_order_issued Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_p2p_four_event_wrong_version'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_event_store (nat_succ (nat_succ (nat_succ nat_zero))) requisition_drafted goods_partially_received Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_p2p_outbox_detached_message'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_unit_event requisition_drafted budget_reserved Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_p2p_three_event_skipped_middle'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_event_store (nat_succ nat_zero) budget_reserved purchase_order_issued Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_p2p_three_event_wrong_version'; Contains = 'ETY-TermError: Unification failure. Got: nat_add (nat_succ (nat_succ nat_zero)) (nat_succ nat_zero) (nat_succ (nat_succ (nat_succ nat_zero))) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_p2p_three_event_wrong_version_sum'; Contains = 'ETY-TermError: Unification failure. Got: nat_add (nat_succ nat_zero) (nat_succ nat_zero) (nat_succ (nat_succ nat_zero)) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_p2p_two_event_wrong_final_stage'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_unit_event budget_reserved budget_reserved Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_p2p_unit_commit_cross_stage'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_unit_event requisition_drafted requisition_drafted Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_p2p_unit_outbox_detached_message'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_unit_event requisition_drafted budget_reserved Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_physical_lineage_existential_wrong_fixed_depth'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_fence_history (nat_succ (nat_succ (nat_succ nat_zero))) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_physical_owner_payload_not_fence_scalar'; Contains = 'ETY-TermError: Unification failure. Got: i64 Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_physical_selection_cannot_force_fixed_depth'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_fence_history (nat_succ (nat_succ nat_zero)) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_reapply'; Contains = 'ETY-TermError: Unification failure. Got: typed_fx_statement_command typed_fx_statement_command_fresh Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_recorded_hash_changed_caller_collision'; Contains = 'ETY-TermError: Unification failure. Got: typed_fx_statement_payload_hash_not_equal typed_fx_statement_payload_hash_changed typed_fx_statement_payload_hash_primary Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_recoverable_fenced_lock_receipt_owner_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_fence_owner (nat_succ (nat_succ nat_zero)) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_recursive_recovery_receipt_version_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_reopened_recovery_authority (nat_succ (nat_succ (nat_succ nat_zero))) requisition_drafted purchase_order_issued Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_recursive_takeover_program_wrong_endpoint'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_fence_takeover_program (nat_succ nat_zero) (nat_succ (nat_succ (nat_succ (nat_succ nat_zero)))) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_recursive_wal_recovery_receipt_version_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_event_commit_tree (nat_succ (nat_succ (nat_succ (nat_succ nat_zero)))) requisition_drafted goods_partially_received Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_specialized_observation_wrong_history'; Contains = 'ETY-TermError: Unification failure. Got: typed_fx_hashed_statement_closed_position_fact typed_fx_hashed_statement_history_empty typed_fx_statement_stream_position_zero Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_three_owner_fenced_lock_receipt_fence_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_fence_history (nat_succ (nat_succ nat_zero)) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_three_owner_fenced_lock_receipt_stale_b_source_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_stale_fence (nat_succ (nat_succ nat_zero)) (nat_succ (nat_succ (nat_succ nat_zero))) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_three_owner_lineage_cannot_force_nat_four'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_fence_history (nat_succ (nat_succ (nat_succ (nat_succ nat_zero)))) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_top_collision_wrong_identity'; Contains = 'ETY-TermError: Unification failure. Got: typed_fx_hashed_statement_identity_collision typed_fx_statement_command_identity_secondary typed_fx_statement_payload_hash_changed (typed_fx_hashed_statement_history_more typed_fx_statement_command_identity_secondary typed_fx_statement_aggregate_identity_primary typed_fx_statement_payload_hash_primary (typed_fx_hashed_statement_history_more typed_fx_statement_command_identity_primary typed_fx_statement_aggregate_identity_primary typed_fx_statement_payload_hash_primary typed_fx_hashed_statement_history_empty)) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_top_membership_wrong_identity'; Contains = 'ETY-TermError: Unification failure. Got: typed_fx_hashed_statement_history_contains typed_fx_statement_command_identity_secondary typed_fx_statement_aggregate_identity_primary typed_fx_statement_payload_hash_primary (typed_fx_hashed_statement_history_more typed_fx_statement_command_identity_secondary typed_fx_statement_aggregate_identity_primary typed_fx_statement_payload_hash_primary (typed_fx_hashed_statement_history_more typed_fx_statement_command_identity_primary typed_fx_statement_aggregate_identity_primary typed_fx_statement_payload_hash_primary typed_fx_hashed_statement_history_empty)) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_two_owner_lineage_cannot_force_nat_three'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_fence_history (nat_succ (nat_succ (nat_succ nat_zero))) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_two_takeover_program_wrong_endpoint'; Contains = 'ETY-TermError: Unification failure. Got: erp_p2p_fence_takeover_program (nat_succ (nat_succ (nat_succ nat_zero))) (nat_succ (nat_succ (nat_succ (nat_succ nat_zero)))) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_unified_evidence_observation_wrong_history'; Contains = 'ETY-TermError: Unification failure. Got: typed_fx_hashed_statement_closed_fact_observation (typed_fx_hashed_statement_history_more typed_fx_statement_command_identity_primary typed_fx_statement_aggregate_identity_primary typed_fx_statement_payload_hash_primary typed_fx_hashed_statement_history_empty) (typed_fx_statement_stream_position_next typed_fx_statement_stream_position_zero) Expected: ' }
        @{ Id = 'samples/mega_omniledger_erp_kernel/negative_unit_event_multistep_plan'; Contains = 'ETY-TermError: Unification failure. Got: erp_plan approvals_collected approvals_collected Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_alpha_capture'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_all_unused (exact_linear_free_context_extend exact_linear_free_context_empty _) (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_application_argument_choice_substitution_keeps_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_application_argument_function_branch_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type (exact_linear_tensor_type exact_linear_unit_type exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_application_argument_substitution_keeps_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_application_function_substitution_keeps_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type (exact_linear_tensor_type exact_linear_unit_type exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_beta_step_target_type_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_choice_substitution_keeps_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_close_nonempty'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term exact_linear_free_context_empty usage exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_application_argument_identity_congruence_target_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term exact_linear_free_context_empty exact_linear_indexed_usage_empty (exact_linear_arrow_type exact_linear_unit_type exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_application_argument_tensor_beta_target_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term exact_linear_free_context_empty exact_linear_indexed_usage_empty (exact_linear_arrow_type (exact_linear_tensor_type exact_linear_unit_type exact_linear_unit_type) exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_application_function_identity_congruence_target_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_identity_beta_relation (exact_linear_arrow_type exact_linear_unit_type exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_atomic_tensor_beta_target_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_atomic_reduction (exact_linear_tensor_type exact_linear_unit_type exact_linear_unit_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_beta_relation_result_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_beta_relation (exact_linear_tensor_type exact_linear_unit_type exact_linear_unit_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_bool_identity_progress_target_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_identity_beta_relation exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_bool_multistep_tail_outcome_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_bool_normalization exact_linear_closed_bool_true_normal Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_bool_nested_right_beta_result_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type (exact_linear_tensor_type exact_linear_bool_type exact_linear_unit_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_bool_normalization_outcome_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_bool_normalization exact_linear_closed_bool_false_normal Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_bool_normalization_progress_source_type_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_progress exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_bool_program_outcome_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_bool_program exact_linear_closed_bool_true_normal Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_bool_progress_continuation_outcome_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_bool_normalization exact_linear_closed_bool_true_normal Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_bool_recursive_guard_outcome_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_bool_program exact_linear_closed_bool_false_normal Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_bool_right_beta_result_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type (exact_linear_tensor_type exact_linear_bool_type exact_linear_unit_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_bool_tensor_identity_progress_target_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_identity_beta_relation exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_higher_order_identity_progress_target_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_identity_beta_relation exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_identity_beta_reduction_result_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_identity_beta_relation exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_normalizing_fragment_false_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_normalizing_fragment exact_linear_false_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_normalizing_progress_authority_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_normalizing_fragment exact_linear_false_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_progress_from_reduction_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_identity_beta_relation exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_source_code_bool_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_value_source exact_linear_indexed_closed_source_bool_true exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_tensor_identity_progress_target_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_identity_beta_relation exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_tensor_left_general_congruence_target_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_reduction exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_indexed_usage_empty exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_tensor_left_identity_congruence_target_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_identity_beta_relation exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_tensor_right_conditional_congruence_target_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_reduction exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_indexed_usage_empty exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_tensor_right_general_congruence_target_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_reduction exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_indexed_usage_empty exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_tensor_right_identity_congruence_target_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_tensor_value_type_not_false_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_value exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_false_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_closed_unit_identity_progress_value_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_conditional_guard_step_requires_bool'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_small_step exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_indexed_usage_empty exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_conditional_step_target_type_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_small_step exact_linear_free_context_empty _ exact_linear_indexed_usage_empty exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_context_strengthening_removes_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_context_strengthening (exact_linear_free_context_extend exact_linear_free_context_empty _) (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty) exact_linear_free_context_empty exact_linear_indexed_usage_empty Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_false_elimination_requires_false'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_false_has_canonical_value'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_value exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_general_conditional_guard_target_usage_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_usage_merge exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_indexed_usage_empty exact_linear_indexed_usage_empty Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_generic_conditional_false_preserves_domain'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_recursive_beta_derivation exact_linear_bool_type exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_identity_beta_raw_term_wrapper'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_lambda_outer_choice_substitution_keeps_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type (exact_linear_arrow_type exact_linear_bool_type (exact_linear_tensor_type exact_linear_unit_type exact_linear_bool_type)) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_lambda_outer_substitution_keeps_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type (exact_linear_arrow_type exact_linear_bool_type (exact_linear_tensor_type exact_linear_unit_type exact_linear_bool_type)) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_linked_multistep_requires_normalization'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_bool_normalization exact_linear_closed_bool_false_normal Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_nested_tensor_right_choice_substitution_keeps_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type (exact_linear_tensor_type exact_linear_bool_type exact_linear_unit_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_open_application_beta_cross_wrapper_identity'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution_strengthening (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) exact_linear_unit_type exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_open_application_beta_target_type_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_bool_type) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_open_conditional_beta_cross_wrapper_tensor'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution_strengthening (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty _) _) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_free_context_extend exact_linear_free_context_empty _) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) _ (exact_linear_tensor_type _ exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_open_conditional_beta_target_type_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_bool_type) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_open_identity_beta_cross_type'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_open_identity_beta_cross_wrapper_application'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) exact_linear_unit_type * exact_linear_indexed_usage_merge (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_open_lambda_beta_cross_wrapper_tensor'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution_strengthening (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty _) _) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_free_context_extend exact_linear_free_context_empty _) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) _ (exact_linear_tensor_type _ exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_open_lambda_beta_target_type_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) (exact_linear_arrow_type exact_linear_unit_type (exact_linear_tensor_type exact_linear_unit_type exact_linear_unit_type)) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_open_tensor_beta_cross_wrapper_conditional'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution_strengthening (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_bool_type) exact_linear_bool_type) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_bool_type) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) exact_linear_bool_type exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_open_tensor_beta_target_type_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) (exact_linear_tensor_type exact_linear_unit_type exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_ready_tensor_tail_wrong_argument_domain'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_value_source ''a exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_ready_unit_tensor_bool_argument'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_value_source ''a exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_beta_application_identity_cannot_change_result'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_recursive_beta_derivation exact_linear_bool_type exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_beta_composite_domain_wrong_argument'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_beta_derivation_domain_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_beta_derivation_result_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_recursive_beta_derivation exact_linear_bool_type (exact_linear_tensor_type exact_linear_bool_type exact_linear_unit_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_beta_domain_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_beta_false_ready_domain_retag'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_recursive_beta_derivation exact_linear_unit_type exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_beta_open_body_result_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_recursive_beta_derivation exact_linear_bool_type (exact_linear_tensor_type exact_linear_bool_type exact_linear_unit_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_beta_ready_opened_not_source_progress'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_source_progress exact_linear_indexed_closed_source_unit result_ty Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_beta_result_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_recursive_beta_derivation exact_linear_bool_type (exact_linear_tensor_type exact_linear_bool_type exact_linear_unit_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_beta_source_argument_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term exact_linear_free_context_empty exact_linear_indexed_usage_empty exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_closed_bool_substitution_keeps_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type (exact_linear_tensor_type exact_linear_unit_type exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_open_bool_application_function_keeps_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type (exact_linear_tensor_type exact_linear_unit_type exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_open_bool_endpoint_usage_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) (exact_linear_tensor_type exact_linear_unit_type exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_open_bool_substitution_reuses_selected'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_open_typed_application_argument_domain_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_open_typed_substitution_strengthening_drops_replacement'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution_strengthening (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) exact_linear_unit_type (exact_linear_tensor_type exact_linear_unit_type exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_open_typed_substitution_strengthening_lambda_drops_replacement'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution_strengthening (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) exact_linear_unit_type (exact_linear_arrow_type exact_linear_unit_type (exact_linear_tensor_type exact_linear_unit_type exact_linear_unit_type)) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_recursive_open_typed_substitution_type_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_bool_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_source_progress_ready_identity_requires_identity_function'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_closed_ready_beta_or_neutral (exact_linear_indexed_closed_source_application_ready_identity exact_linear_unit_type exact_linear_indexed_closed_source_unit) exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_substitution_keeps_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_tensor_branch_choice_substitution_keeps_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type (exact_linear_tensor_type exact_linear_unit_type exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_tensor_right_choice_substitution_keeps_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type (exact_linear_tensor_type exact_linear_bool_type exact_linear_unit_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_tensor_substitution_keeps_used'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_recursive_open_typed_substitution (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_unused (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty)) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) exact_linear_unit_type (exact_linear_tensor_type exact_linear_unit_type exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_term_strengthening_drops_preserved'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_term_strengthening (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) (exact_linear_tensor_type exact_linear_unit_type exact_linear_bool_type) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_unified_reduction_preservation_target_type_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_reduction (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_bool_type) _ (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_used_used_merge'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_usage_merge (exact_linear_free_context_extend exact_linear_free_context_empty _) (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) Expected: ' }
        @{ Id = 'samples/mega_spiral_proves_spiral_relative_consistency/negative_variable_strengthening_drops_preserved'; Contains = 'ETY-TermError: Unification failure. Got: exact_linear_indexed_variable_strengthening (exact_linear_free_context_extend (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) exact_linear_unit_type) meta_zero (exact_linear_indexed_usage_used (exact_linear_indexed_usage_unused exact_linear_indexed_usage_empty)) (exact_linear_free_context_extend exact_linear_free_context_empty exact_linear_unit_type) meta_zero (exact_linear_indexed_usage_used exact_linear_indexed_usage_empty) exact_linear_unit_type Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_accessible_child_one_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_predecessor_accessibility positional_one Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_accessible_child_step_prime_predecessor_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_predecessor (positional_one_bit positional_one) positional_one Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_accessible_child_unit_direct_wrong_root'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_nat (positional_one_bit positional_one) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_accessible_composite_completion_wrong_root'; Contains = 'ETY-TermError: Unification failure. Got: certified_interval_positive_positional_complete_factorization_tree (positional_zero_bit (positional_one_bit positional_one)) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_accessible_step_prime_predecessor_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_predecessor (positional_one_bit positional_one) positional_one Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_accessible_step_prime_tree_wrong_root'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_nat (positional_zero_bit (positional_zero_bit positional_one)) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_child_recursion_authority_child_accessibility_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_nat (positional_one_bit positional_one) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_child_recursion_authority_wrong_root'; Contains = 'ETY-TermError: Unification failure. Got: certified_interval_positive_positional_child_recursion_authority (positional_zero_bit positional_one) (positional_one_bit positional_one) (z_nat_succ z_nat_zero) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_complete_descent_fold_missing_division'; Contains = 'ETY-TermError: Unification failure. Got: certified_interval_positive_positional_recursive_descent (positional_zero_bit (positional_zero_bit (positional_one_bit positional_one))) positional_zero Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_complete_reconstruction_prime_four'; Contains = 'ETY-TermError: Unification failure. Got: exists length. positive_positional_nat (positional_zero_bit (positional_zero_bit positional_one)) * positive_positional_factor_candidate_nonunit (positional_zero_bit (positional_zero_bit positional_one)) * certified_interval_positive_positional_all_rejected (positional_zero_bit (positional_zero_bit positional_one)) (positional_zero_bit (positional_zero_bit positional_one)) length * string Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_composite_recursion_authority_wrong_root'; Contains = 'ETY-TermError: Unification failure. Got: certified_interval_positive_positional_factor_membership divisor (positional_zero_bit (positional_zero_bit positional_one)) length Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_descent_unavailable_divisor_blocked_equal_root'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_equal (positional_zero_bit (positional_zero_bit (positional_one_bit positional_one))) (positional_zero_bit (positional_zero_bit (positional_one_bit positional_one))) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_forged_interval'; Contains = 'ETY-TermError: Unification failure. Got: certified_positive_positional_candidate_interval positional_one z_nat_zero Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_intrinsic_prime_four'; Contains = 'ETY-TermError: Unification failure. Got: certified_interval_positive_positional_all_rejected _ (positional_zero_bit positional_one) z_nat_zero Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_intrinsic_prime_one'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_factor_candidate_nonunit (positional_zero_bit positional_one) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_membership_accessibility_authority_candidate_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: certified_interval_positive_positional_factor_membership positional_one (positional_one_bit positional_one) (z_nat_succ z_nat_zero) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_membership_accessibility_candidate_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: certified_interval_positive_positional_factor_membership positional_one (positional_one_bit positional_one) (z_nat_succ z_nat_zero) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_membership_accessible_child_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_nat (positional_one_bit positional_one) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_membership_candidate_value_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_nat (positional_one_bit positional_one) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_membership_descent_wrong_root'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_predecessor (positional_one_bit positional_one) (positional_zero_bit positional_one) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_membership_recursion_authority_wrong_root'; Contains = 'ETY-TermError: Unification failure. Got: certified_interval_positive_positional_factor_membership (positional_zero_bit positional_one) (positional_zero_bit (positional_zero_bit positional_one)) (z_nat_succ z_nat_zero) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_membership_strict_path_identity'; Contains = 'ETY-TermError: Unification failure. Got: certified_interval_positive_positional_factor_membership (positional_zero_bit (positional_zero_bit (positional_one_bit positional_one))) (positional_zero_bit (positional_zero_bit (positional_one_bit positional_one))) length Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_mixed_second_prime_strict_separation_cannot_reverse'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_less second_factor singleton_factor Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_mixed_singleton_prime_power_wrong_root'; Contains = 'ETY-TermError: Unification failure. Got: certified_arithmetic_prime_power _ _ positional_one Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_mixed_strict_separation_not_divisibility_obligation'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_exact_factor_decision root second_factor Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_multi_prime_nf_not_prime_power'; Contains = 'ETY-TermError: Unification failure. Got: exists factor count product. certified_arithmetic_prime_power factor count product * positive_positional_multiply product positional_one root Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_positive_exponent_equality_wrong_length'; Contains = 'ETY-TermError: Unification failure. Got: certified_arithmetic_positive_exponent_equal (z_nat_succ z_nat_zero) (z_nat_succ (z_nat_succ z_nat_zero)) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_predecessor_accessibility_parallel_less'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_less positional_one (positional_zero_bit positional_one) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_predecessor_accessibility_parallel_value'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_predecessor (positional_zero_bit positional_one) positional_one Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_prime_power_leaf_nonfactor_not_product_nonfactor'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_nonfactor_certificate product external Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_prime_product_split_found_not_rejection'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_nonfactor_certificate product external Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_prime_product_split_previous_nonfactor_not_base_nonfactor'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_nonfactor_certificate factor external Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_quotient_accessible_parent_root_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: certified_interval_positive_positional_complete_factorization_tree (positional_one_bit positional_one) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_quotient_recursion_authority_wrong_root'; Contains = 'ETY-TermError: Unification failure. Got: value_synthesized_structural_division (positional_zero_bit (positional_zero_bit positional_one)) divisor quotient positional_zero Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_sealed_composite_children_direct_forged_divisor'; Contains = 'ETY-TermError: Unification failure. Got: certified_interval_positive_positional_factor_membership (positional_zero_bit (positional_zero_bit (positional_one_bit positional_one))) (positional_zero_bit (positional_zero_bit (positional_one_bit positional_one))) length Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_sealed_composite_children_wrong_divisor'; Contains = 'ETY-TermError: Unification failure. Got: certified_interval_positive_positional_sealed_composite_children (positional_zero_bit (positional_zero_bit (positional_one_bit positional_one))) (positional_one_bit (positional_zero_bit (positional_zero_bit positional_one))) (positional_zero_bit positional_one) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_sealed_composite_children_wrong_root'; Contains = 'ETY-TermError: Unification failure. Got: certified_interval_positive_positional_sealed_composite_children (positional_zero_bit (positional_one_bit (positional_zero_bit (positional_zero_bit positional_one)))) (positional_zero_bit (positional_one_bit positional_one)) (positional_zero_bit positional_one) Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_structural_division_quotient_projection_mismatch'; Contains = 'ETY-TermError: Unification failure. Got: value_synthesized_structural_division (positional_zero_bit positional_one) (positional_zero_bit positional_one) positional_one positional_zero Expected: ' }
        @{ Id = 'samples/mega_zeta_structural_laboratory/negative_zero_remainder'; Contains = 'ETY-TermError: Unification failure. Got: positive_positional_nat positional_zero Expected: ' }
        @{ Id = 'samples/contract_ack_before_publish'; Contains = 'Unification failure. Got: event_box published Expected: event_box persisted' }
        @{ Id = 'samples/contract_missing_endpoint_capability'; Contains = 'Unification failure. Got: session present present Expected: session present missing' }
        @{ Id = 'samples/contract_scoped_resource_escape'; Contains = 'The main function should not have a forall' }
        @{ Id = 'samples/empty_match_parse_error'; Contains = 'Unexpected end of block past this token' }
        @{ Id = 'samples/contract_balanced_as_constant'; Contains = 'Unification failure. Got: oracle constant Expected: oracle balanced' }
        @{ Id = 'samples/contract_block_inside_phrasing'; Contains = 'Unification failure. Got: child flow Expected: child phrasing' }
        @{ Id = 'samples/contract_branch_as_value'; Contains = 'Unification failure. Got: ir_op branch_result Expected: ir_op value' }
        @{ Id = 'samples/contract_broken_degree_associativity'; Contains = 'Unification failure. Got: n_add n_two n_two n_four Expected: n_add n_two n_two n_three' }
        @{ Id = 'samples/contract_bypass_validation_evidence'; Contains = 'Unification failure. Got: validation_evidence ready Expected: validation_evidence pending' }
        @{ Id = 'samples/contract_call_unfiltered_reads'; Contains = 'Unification failure. Got: readset sample_a hg38 aligned Expected: readset ''a ''b filtered' }
        @{ Id = 'samples/contract_call_unnormalized_likelihood'; Contains = 'Unification failure. Got: likelihoods sample_a hg38 chr1 model_v2 normalized Expected: likelihoods sample_a hg38 chr1 model_v2 raw' }
        @{ Id = 'samples/contract_call_variants_on_raw_reads'; Contains = 'Unification failure. Got: readset donor_a hg38 aligned Expected: readset donor_a hg38 raw' }
        @{ Id = 'samples/contract_cannot_regain_admin'; Contains = 'Unification failure. Got: capability publish_only Expected: capability admin' }
        @{ Id = 'samples/contract_cnot_on_single_qubit'; Contains = 'Unification failure. Got: qregister (succ (succ zero)) Expected: qregister (succ zero)' }
        @{ Id = 'samples/contract_commit_before_effect_drain'; Contains = 'Unification failure. Got: effect_batch app_scope epoch1 drained Expected: effect_batch app_scope epoch1 pending' }
        @{ Id = 'samples/contract_commit_without_all_prepared'; Contains = 'Unification failure. Got: transaction ready missing open_phase Expected: transaction ready ready open_phase' }
        @{ Id = 'samples/contract_compensation_before_commit'; Contains = 'Unification failure. Got: receipt draft sent committed Expected: receipt _ _ pending' }
        @{ Id = 'samples/contract_cross_abi_polyglot_lowering'; Contains = 'Unification failure. Got: backend_capability backend_fsharp abi_net11 memory_gc capability_managed available Expected: backend_capability backend_fsharp abi_cuda memory_gc capability_managed available' }
        @{ Id = 'samples/contract_cross_auction_vickrey_winner'; Contains = 'Unification failure. Got: winner auction_501 bidder_a lot_gpu_9 currency_usdc Expected: winner auction_502 bidder_a lot_gpu_9 currency_usdc' }
        @{ Id = 'samples/contract_cross_backend_probe'; Contains = 'Unification failure. Got: v36b_probe v36b_zone_orbit v36b_epoch_21 v36b_root_green v36b_backend_wasm v36b_probed Expected: v36b_probe v36b_zone_orbit v36b_epoch_21 v36b_root_green v36b_backend_cuda v36b_probed' }
        @{ Id = 'samples/contract_cross_branch_quantum_correction'; Contains = 'Unification failure. Got: classical_bit program_a epoch_4 branch_zero measured Expected: classical_bit program_a epoch_4 branch_one measured' }
        @{ Id = 'samples/contract_cross_build_trio_inheritance'; Contains = 'Unification failure. Got: haplotype father hg38 chr1 paternal_phase Expected: haplotype father hg19 chr1 paternal_phase' }
        @{ Id = 'samples/contract_cross_contig_variant_merge'; Contains = 'Unification failure. Got: callset donor_a hg38 chr1 Expected: callset donor_a hg38 chr2' }
        @{ Id = 'samples/contract_cross_epoch_hidden_quorum'; Contains = 'Unification failure. Got: v36_share v36_tenant_blue v36_epoch_13 v36_root_b v36_lane_gamma v36_quorum_ready Expected: v36_share v36_tenant_blue v36_epoch_12 v36_root_b v36_lane_gamma v36_quorum_ready' }
        @{ Id = 'samples/contract_cross_epoch_peer_receipt'; Contains = 'Unification failure. Got: healed_output transfer_a manifest_a peer_b host_b epoch_0 payload_a digest_a accepted Expected: healed_output transfer_a manifest_a peer_b host_b epoch_1 payload_a digest_a accepted' }
        @{ Id = 'samples/contract_cross_kind_handoff'; Contains = 'Unification failure. Got: promise term_kind filled Expected: promise ty_kind filled' }
        @{ Id = 'samples/contract_cross_lane_compensation'; Contains = 'Unification failure. Got: lane_compensation lane_bank settlement_batch_a branch_epoch_1 branch_compensated Expected: lane_compensation lane_carbon settlement_batch_a branch_epoch_1 branch_compensated' }
        @{ Id = 'samples/contract_cross_lineage_teleport_correction'; Contains = 'Unification failure. Got: classical_bits lineage_a outcome_01 Expected: classical_bits lineage_b outcome_01' }
        @{ Id = 'samples/contract_cross_manifest_mesh_commit'; Contains = 'Unification failure. Got: peer_output transfer_a manifest_stale peer_c payload_a digest_a accepted Expected: peer_output transfer_a manifest_a peer_c payload_a digest_a accepted' }
        @{ Id = 'samples/contract_cross_operation_idempotency_key'; Contains = 'Unification failure. Got: request authorize string Expected: request query string' }
        @{ Id = 'samples/contract_cross_owner_ancilla_release'; Contains = 'Unification failure. Got: loan owner_a Expected: loan owner_b' }
        @{ Id = 'samples/contract_cross_pool_flash_repayment'; Contains = 'Unification failure. Got: repayment_receipt pool_alpha borrower_7 usdc block_19000000 Expected: repayment_receipt pool_beta borrower_7 usdc block_19000000' }
        @{ Id = 'samples/contract_cross_root_therapy_publication'; Contains = 'Unification failure. Got: observer_checkpoint registry_root_a observer_b observed Expected: observer_checkpoint registry_root_b observer_b observed' }
        @{ Id = 'samples/contract_cross_route_flank_lock'; Contains = 'Unification failure. Got: flank_lock flank_9 route_north train_77 epoch_5 Expected: flank_lock flank_9 route_south train_77 epoch_5' }
        @{ Id = 'samples/contract_cross_scope_subscription'; Contains = 'Unification failure. Got: signal scope_b i32 Expected: signal scope_a i32' }
        @{ Id = 'samples/contract_cross_wave_compensation_after_partition'; Contains = 'Unification failure. Got: mh_compensation lane_payment replay_batch_a recovery_wave_1 mh_compensated Expected: mh_compensation lane_shipping replay_batch_a recovery_wave_1 mh_compensated' }
        @{ Id = 'samples/contract_dirty_ancilla_oracle'; Contains = 'Unification failure. Got: ancilla clean Expected: ancilla dirty' }
        @{ Id = 'samples/contract_double_owner_close'; Contains = 'Unification failure. Got: owner _ owner_open Expected: owner term_kind owner_closed' }
        @{ Id = 'samples/contract_duplicate_approver_quorum'; Contains = 'Unification failure. Got: distinct approver_a approver_a Expected: distinct approver_a approver_b' }
        @{ Id = 'samples/contract_duplicate_erasure_shard'; Contains = 'Unification failure. Got: distinct_witness shard_a shard_a distinct Expected: distinct_witness shard_a shard_b distinct' }
        @{ Id = 'samples/contract_duplicate_gossip_observer'; Contains = 'Unification failure. Got: distinct_observers observer_a observer_a distinct Expected: distinct_observers observer_a observer_b distinct' }
        @{ Id = 'samples/contract_duplicate_measurement_branch'; Contains = 'Unification failure. Got: branch_result lineage_a one Expected: branch_result lineage_a zero' }
        @{ Id = 'samples/contract_duplicate_microgrid_participant'; Contains = 'Unification failure. Got: prepare_vote participant_bank settlement_batch_a epoch_77 prepared Expected: prepare_vote participant_grid settlement_batch_a epoch_77 prepared' }
        @{ Id = 'samples/contract_duplicate_public_signer_quorum'; Contains = 'Unification failure. Got: distinct signer_a signer_a Expected: distinct signer_a signer_b' }
        @{ Id = 'samples/contract_duplicate_quantum_branch'; Contains = 'Unification failure. Got: qtoken lineage_a right_branch Expected: qtoken lineage_a left_branch' }
        @{ Id = 'samples/contract_duplicate_recursive_quorum'; Contains = 'Unification failure. Got: approval_quorum missing missing Expected: approval_quorum present missing' }
        @{ Id = 'samples/contract_event_before_hydration'; Contains = 'Unification failure. Got: view server cold Expected: view browser hydrated' }
        @{ Id = 'samples/contract_exhausted_privacy_budget'; Contains = 'Unification failure. Got: privacy_budget client_a budget_a available Expected: privacy_budget client_a budget_a spent' }
        @{ Id = 'samples/contract_existential_artifact_mismatch'; Contains = 'Unification failure. Got: attestation tenant_orbit epoch_42 root_new backend_gpu schema_v4 artifact_validated Expected: attestation tenant_orbit epoch_42 root_new backend_cpu schema_v3 artifact_validated' }
        @{ Id = 'samples/contract_expired_deadline'; Contains = 'Unification failure. Got: deadline epoch_42 fresh Expected: deadline epoch_42 expired' }
        @{ Id = 'samples/contract_federation_mixed_epoch'; Contains = 'Unification failure. Got: v36_share v36_tenant_blue v36_epoch_13 v36_root_b v36_lane_beta v36_quorum_ready Expected: v36_share v36_tenant_blue v36_epoch_12 v36_root_b v36_lane_beta v36_quorum_ready' }
        @{ Id = 'samples/contract_foreign_executor_receipt'; Contains = 'Unification failure. Got: drain_receipt scope_a epoch1 executor_a drained Expected: drain_receipt scope_a epoch1 executor_b drained' }
        @{ Id = 'samples/contract_foreign_signer_genome_dashboard'; Contains = 'Unification failure. Got: resource _ _ signer_b digest_a sample_a hg38 chr1 live Expected: resource app_scope epoch1 signer_a digest_a sample_a hg38 chr1 live' }
        @{ Id = 'samples/contract_foreign_suspense_cancel_token'; Contains = 'Unification failure. Got: cancel_token app_scope epoch1 owner_a fresh Expected: cancel_token app_scope epoch1 owner_b fresh' }
        @{ Id = 'samples/contract_gapped_genome_interval_merge'; Contains = 'Unification failure. Got: segment hg38 chr1 i1 i3 Expected: segment hg38 chr1 i2 i3' }
        @{ Id = 'samples/contract_hott_broken_associator_pentagon'; Contains = 'Unification failure. Got: associator_2cell space_x point_a point_e path_p path_q path_r path_s vertex_5 vertex_4 edge_54_alt Expected: associator_2cell space_x point_a point_e path_p path_q path_r path_s vertex_5 vertex_4 edge_54' }
        @{ Id = 'samples/contract_hott_broken_braided_hexagon'; Contains = 'Unification failure. Got: braiding_2cell monoidal_x object_a object_b object_c vertex_5 vertex_6 edge_56_stale Expected: braiding_2cell monoidal_x object_a object_b object_c vertex_5 vertex_6 edge_56' }
        @{ Id = 'samples/contract_hott_incoherent_cube_edge'; Contains = 'Unification failure. Got: dependent_square family_f space_x b d f h fb fd ff fh edge_bd edge_fh edge_bf_wrong edge_dh po_bd po_fh po_bf po_dh right Expected: dependent_square family_f space_x b d f h fb fd ff fh edge_bd edge_fh edge_bf edge_dh po_bd po_fh po_bf po_dh right' }
        @{ Id = 'samples/contract_hott_torus_noncommuting_algebra'; Contains = 'Unification failure. Got: automorphism_composition motive_p fiber_base auto_y_wrong auto_x compose_yx Expected: automorphism_composition motive_p fiber_base auto_y auto_x compose_yx' }
        @{ Id = 'samples/contract_hott_truncation_into_untruncated_target'; Contains = 'Unification failure. Got: sethood target_set target_level_one Expected: sethood target_set target_level_set' }
        @{ Id = 'samples/contract_hott_univalence_wrong_transport_path'; Contains = 'Unification failure. Got: ua_transport family_p universe_u type_a type_c equiv_ac ua_ac_other fiber_a fiber_c transport_ac Expected: ua_transport family_p universe_u type_a type_c equiv_ac ua_ac fiber_a fiber_c transport_ac' }
        @{ Id = 'samples/contract_hydrate_checksum_mismatch'; Contains = 'Unification failure. Got: client_checksum checksum_a Expected: client_checksum checksum_b' }
        @{ Id = 'samples/contract_illegal_indexed_bind'; Contains = 'Unification failure. Got: document loaded Expected: document idle' }
        @{ Id = 'samples/contract_illegal_parallel_effect'; Contains = 'Unification failure. Got: task serial string Expected: task parallel string' }
        @{ Id = 'samples/contract_illegal_plan_adjacency'; Contains = 'Unification failure. Got: fiscal_op (phase production schema_v4 signed normal) (phase production schema_v4 authorized contingency) Expected: fiscal_op (phase production schema_v4 signed contingency) (phase production schema_v4 authorized contingency)' }
        @{ Id = 'samples/contract_illegal_scheduler_admission'; Contains = 'Unification failure. Got: receipt committed Expected: receipt pending' }
        @{ Id = 'samples/contract_illegal_schema_query'; Contains = 'Unification failure. Got: field schema_v4 string Expected: field schema_v5 string' }
        @{ Id = 'samples/contract_illegal_transition'; Contains = 'Unification failure. Got: document authorized Expected: document draft' }
        @{ Id = 'samples/contract_incomplete_builder'; Contains = 'Unification failure. Got: nfe_builder (builder_state present present present) Expected: nfe_builder (builder_state present missing present)' }
        @{ Id = 'samples/contract_incomplete_disposal_batch'; Contains = 'Unification failure. Got: disposal app_scope key_c disposed Expected: disposal app_scope key_b disposed' }
        @{ Id = 'samples/contract_incomplete_scope_tree_teardown'; Contains = 'Unification failure. Got: disposal app_scope child_b disposed Expected: disposal app_scope child_a disposed' }
        @{ Id = 'samples/contract_incomplete_shard_barrier'; Contains = 'Unification failure. Got: barrier present present present Expected: barrier present present missing' }
        @{ Id = 'samples/contract_insufficient_quorum'; Contains = 'Unification failure. Got: quorum q1 Expected: quorum q2' }
        @{ Id = 'samples/contract_invalid_applicative_map'; Contains = 'Unification failure. Got: validation (string * i32) Expected: validation i32' }
        @{ Id = 'samples/contract_invalid_dag_dependency'; Contains = 'Unification failure. Got: string Expected: i32' }
        @{ Id = 'samples/contract_invalid_genome_overlap'; Contains = 'Unification failure. Got: kmer hg38 chr1 overlap_a finish Expected: kmer hg38 chr1 overlap_c finish' }
        @{ Id = 'samples/contract_invalid_manifest_edge'; Contains = 'Unification failure. Got: node _ _ _ draft authorized Expected: node publish_id serial publish_cap validated authorized' }
        @{ Id = 'samples/contract_invalid_recursive_plan_append'; Contains = 'Unification failure. Got: operation s1 s3 Expected: operation s2 s3' }
        @{ Id = 'samples/contract_invalid_saga_compensation'; Contains = 'Unification failure. Got: backward signed draft Expected: backward authorized signed' }
        @{ Id = 'samples/contract_invalid_schema_iso'; Contains = 'Unification failure. Got: migration v6 v5 Expected: migration v5 v6' }
        @{ Id = 'samples/contract_invalid_total_saga'; Contains = 'Unification failure. Got: forward draft authorized Expected: forward draft signed' }
        @{ Id = 'samples/contract_meiosis_on_haploid'; Contains = 'Unification failure. Got: genome haploid Expected: genome diploid' }
        @{ Id = 'samples/contract_misaligned_request_capability'; Contains = 'Unification failure. Got: capability_token writer Expected: capability_token (reader * writer)' }
        @{ Id = 'samples/contract_misaligned_rollup_root'; Contains = 'Unification failure. Got: availability_certificate batch_700 epoch_31 root_poseidon_7 Expected: availability_certificate batch_700 epoch_31 root_poseidon_8' }
        @{ Id = 'samples/contract_misaligned_serialized_row'; Contains = 'Unification failure. Got: row draft validated idempotent Expected: row validated authorized idempotent' }
        @{ Id = 'samples/contract_mismatched_authority_identity'; Contains = 'Unification failure. Got: receipt publish_id validated authorized Expected: receipt validate_id draft validated' }
        @{ Id = 'samples/contract_mismatched_cohort_calibration'; Contains = 'Unification failure. Got: release_permit cohort_a calibration_a authorized Expected: release_permit cohort_b calibration_b authorized' }
        @{ Id = 'samples/contract_mismatched_execution_certificate'; Contains = 'Unification failure. Got: receipt compiler_v2 source_hash_a publish_node validated authorized committed Expected: receipt compiler_v2 source_hash_b publish_node validated authorized committed' }
        @{ Id = 'samples/contract_mismatched_fanout_reducer'; Contains = 'Unification failure. Got: shard total i32 Expected: shard issuer string' }
        @{ Id = 'samples/contract_mismatched_job_handler'; Contains = 'Unification failure. Got: validation_evidence ready -> string Expected: receipt committed -> string' }
        @{ Id = 'samples/contract_mismatched_receipt'; Contains = 'Unification failure. Got: receipt publish_nfe string Expected: receipt query_status string' }
        @{ Id = 'samples/contract_mismatched_reference_allele'; Contains = 'Unification failure. Got: variant hg38 chr1 pos100 allele_c allele_t raw Expected: variant hg38 chr1 pos100 allele_a allele_t raw' }
        @{ Id = 'samples/contract_mismatched_risk_route'; Contains = 'Unification failure. Got: authorization low Expected: authorization high' }
        @{ Id = 'samples/contract_mismatched_selective_risk'; Contains = 'Unification failure. Got: review high string Expected: review low string' }
        @{ Id = 'samples/contract_missing_deployment_interpreter'; Contains = 'The higher order type instance bill does not have the prototype interpret.' }
        @{ Id = 'samples/contract_missing_query_interpreter'; Contains = 'The higher order type instance remote does not have the prototype run_query.' }
        @{ Id = 'samples/contract_missing_quota_capability'; Contains = 'Unification failure. Got: session present present present Expected: session present present missing' }
        @{ Id = 'samples/contract_missing_route_parameter'; Contains = 'Unification failure. Got: route_params user_params Expected: route_params no_params' }
        @{ Id = 'samples/contract_mixed_epoch_root_quorum'; Contains = 'Unification failure. Got: root_vote signer_b _ root_digest epoch1 verified Expected: root_vote signer_b key_b root_digest epoch0 verified' }
        @{ Id = 'samples/contract_mixed_phase_set'; Contains = 'Unification failure. Got: phase_block sample_a hg38 chr1 pos1 ''a phase_set_a Expected: phase_block sample_a hg38 chr1 pos1 pos2 phase_set_b' }
        @{ Id = 'samples/contract_non_polymorphic_emitter'; Contains = 'Unification failure. Got: forall a b e. operation a b e -> row a b e Expected: operation draft validated idempotent -> row draft validated idempotent' }
        @{ Id = 'samples/contract_old_key_after_rotation'; Contains = 'Unification failure. Got: public_key _ _ _ active Expected: public_key signer_a key_old epoch0 retired' }
        @{ Id = 'samples/contract_out_of_order_ssr_chunk'; Contains = 'Unification failure. Got: chunk app_scope i0 i2 Expected: chunk app_scope i1 i2' }
        @{ Id = 'samples/contract_overlapping_quantum_partition'; Contains = 'Unification failure. Got: qregister lineage_a right_slots coherent Expected: qregister lineage_a left_slots coherent' }
        @{ Id = 'samples/contract_parser_error'; Contains = 'Expected one of: inl, let, open, unary operator' }
        @{ Id = 'samples/contract_provenance_confusion'; Contains = 'Unification failure. Got: step source_a draft validated Expected: step source_b draft validated' }
        @{ Id = 'samples/contract_pure_forall_uninhabited'; Contains = 'Unification failure. Got: a Expected: ()' }
        @{ Id = 'samples/contract_quantum_budget_underflow'; Contains = 'Unification failure. Got: budget (succ ''a) Expected: budget zero' }
        @{ Id = 'samples/contract_qubit_scope_escape'; Contains = 'Unification failure. Got: qubit region_b coherent Expected: qubit region coherent' }
        @{ Id = 'samples/contract_receive_before_send'; Contains = 'Unification failure. Got: session sent Expected: session idle' }
        @{ Id = 'samples/contract_recombine_unphased_genotype'; Contains = 'Unification failure. Got: genotype unphased Expected: genotype phased' }
        @{ Id = 'samples/contract_render_after_dispose'; Contains = 'Unification failure. Got: resource component_scope disposed Expected: resource _ live' }
        @{ Id = 'samples/contract_render_stale_reactive_memo'; Contains = 'Unification failure. Got: memo app_scope epoch1 clean i32 Expected: memo app_scope epoch0 dirty i32' }
        @{ Id = 'samples/contract_resource_budget_exhausted'; Contains = 'Unification failure. Got: budget (succ _) Expected: budget zero' }
        @{ Id = 'samples/contract_retired_key_in_public_quorum'; Contains = 'Unification failure. Got: public_statement transfer_a manifest_good peer_a key_a_old round_29 authenticated Expected: public_statement transfer_a manifest_good peer_a key_a_new round_29 authenticated' }
        @{ Id = 'samples/contract_reuse_quantum_continuation'; Contains = 'Unification failure. Got: qcontinuation lineage_a epoch0 ''a ''b fresh Expected: qcontinuation lineage_a epoch0 epoch1 owner_a used' }
        @{ Id = 'samples/contract_reversed_genome_interval'; Contains = 'Unification failure. Got: lt (succ zero) zero Expected: lt zero (succ zero)' }
        @{ Id = 'samples/contract_rna_base_in_dna_codon'; Contains = 'Unification failure. Got: nucleotide dna Expected: nucleotide rna' }
        @{ Id = 'samples/contract_self_targeting_cnot'; Contains = 'Unification failure. Got: distinct slot0 slot0 Expected: distinct slot0 slot1' }
        @{ Id = 'samples/contract_shared_budget_double_allocation'; Contains = 'Unification failure. Got: nat_add nat_two nat_one nat_three Expected: nat_add nat_two nat_two nat_three' }
        @{ Id = 'samples/contract_stale_cache_key'; Contains = 'Unification failure. Got: result Expected: string' }
        @{ Id = 'samples/contract_stale_chain_genome_stream'; Contains = 'Unification failure. Got: resource _ _ _ _ _ digest_b live Expected: resource app_scope epoch1 sample_a hg38 chr1 digest_a live' }
        @{ Id = 'samples/contract_stale_dom_commit_ticket'; Contains = 'Unification failure. Got: commit_ticket scope_a epoch1 host_a current Expected: commit_ticket scope_a epoch0 host_a current' }
        @{ Id = 'samples/contract_stale_epoch_completion'; Contains = 'Unification failure. Got: completion worker_a epoch_1 Expected: completion worker_a epoch_2' }
        @{ Id = 'samples/contract_stale_epoch_lease'; Contains = 'Unification failure. Got: authority epoch_one Expected: authority epoch_two' }
        @{ Id = 'samples/contract_stale_host_epoch_commit'; Contains = 'Unification failure. Got: effect_drain root_scope generation_7 drained Expected: effect_drain root_scope generation_6 drained' }
        @{ Id = 'samples/contract_stale_manifest_chunk_resume'; Contains = 'Unification failure. Got: chunk_receipt transfer_a manifest_v1 chunk_2 digest_2 receiver_a journal_a accepted Expected: chunk_receipt transfer_a manifest_v2 chunk_2 digest_2 receiver_a journal_a accepted' }
        @{ Id = 'samples/contract_stale_membership_byzantine_commit'; Contains = 'Unification failure. Got: byzantine_commit transfer_a manifest_good round_28 epoch_0 committed Expected: byzantine_commit transfer_a manifest_good round_28 epoch_1 committed' }
        @{ Id = 'samples/contract_stale_pbft_view_certificate'; Contains = 'Unification failure. Got: new_view_certificate view_8 epoch_11 request_42 Expected: new_view_certificate view_7 epoch_11 request_42' }
        @{ Id = 'samples/contract_stale_quantum_epoch'; Contains = 'Unification failure. Got: qstate (succ zero) Expected: qstate zero' }
        @{ Id = 'samples/contract_stale_quantum_loan_release'; Contains = 'Unification failure. Got: qloan lineage_a epoch1 owner_a slot0 live Expected: qloan lineage_a epoch0 owner_a slot0 live' }
        @{ Id = 'samples/contract_stale_root_genome_dashboard'; Contains = 'Unification failure. Got: dashboard _ _ root_a mounted Expected: dashboard scope_a epoch1 root_b mounted' }
        @{ Id = 'samples/contract_stale_ssle_epoch_ticket'; Contains = 'Unification failure. Got: ssle_ticket validator_17 committee_9 epoch_22 Expected: ssle_ticket validator_17 committee_9 epoch_21' }
        @{ Id = 'samples/contract_stale_surgery_epoch_commit'; Contains = 'Unification failure. Got: effect_drain room_a epoch_44 drained Expected: effect_drain room_a epoch_43 drained' }
        @{ Id = 'samples/contract_subject_reduction_wrong_target'; Contains = 'Unification failure. Got: typed_reduction_chain empty_ctx bool_sort target_false target_false Expected: typed_reduction_chain empty_ctx bool_sort target_true target_false' }
        @{ Id = 'samples/contract_submit_handler_as_click'; Contains = 'Unification failure. Got: event_capability browser click Expected: event_capability browser submit' }
        @{ Id = 'samples/contract_transcribe_coding_strand'; Contains = 'Unification failure. Got: dna_strand coding five_to_three Expected: dna_strand template three_to_five' }
        @{ Id = 'samples/contract_type_error'; Contains = 'Unification failure. Got: i32 Expected: string' }
        @{ Id = 'samples/contract_uncalibrated_genotype_likelihood'; Contains = 'Unification failure. Got: readset sample_a hg38 chr1 calibrated Expected: readset sample_a hg38 chr1 aligned' }
        @{ Id = 'samples/contract_uncommitted_publish'; Contains = 'Unification failure. Got: status_receipt committed Expected: status_receipt pending' }
        @{ Id = 'samples/contract_uncommitted_receipt'; Contains = 'Unification failure. Got: receipt authorization_evidence committed Expected: receipt authorization_evidence pending' }
        @{ Id = 'samples/contract_uncompensated_non_idempotent'; Contains = 'Unification failure. Got: compensation_proof requires_compensation Expected: compensation_proof no_compensation' }
        @{ Id = 'samples/contract_uncompute_with_foreign_garbage'; Contains = 'Unification failure. Got: garbage owner_a computed Expected: garbage owner_b computed' }
        @{ Id = 'samples/contract_unitary_after_measurement'; Contains = 'Unification failure. Got: qstate measured (succ zero) Expected: qstate coherent (succ zero)' }
        @{ Id = 'samples/contract_unrooted_byzantine_evidence'; Contains = 'Unification failure. Got: inclusion_proof leaf_0 snapshot_digest_fork merkle_root_30 authenticated Expected: inclusion_proof leaf_0 snapshot_digest_30 merkle_root_30 authenticated' }
        @{ Id = 'samples/contract_unsafe_retry'; Contains = 'Unification failure. Got: request non_retryable string Expected: request retryable string' }
        @{ Id = 'samples/contract_unsealed_genome_dashboard'; Contains = 'Unification failure. Got: callset_authority sealed sample_a hg38 chr1 Expected: callset_authority unsealed sample_a hg38 chr1' }
        @{ Id = 'samples/contract_wrong_adjoint_program'; Contains = 'Unification failure. Got: adjoint_proof program_a verified Expected: adjoint_proof program_b verified' }
        @{ Id = 'samples/contract_wrong_environment_capability'; Contains = 'Unification failure. Got: document (phase homologation schema_v4 signed) Expected: document (phase production schema_v4 signed)' }
        @{ Id = 'samples/contract_wrong_key_disposal'; Contains = 'Unification failure. Got: disposal app_scope removed_b disposed Expected: disposal app_scope removed_c disposed' }
        @{ Id = 'samples/contract_wrong_key_reconciliation'; Contains = 'Unification failure. Got: keyed_child item_key i32 Expected: keyed_child foreign_key i32' }
        @{ Id = 'samples/contract_wrong_reference_build'; Contains = 'Unification failure. Got: variant hg19 chr1 normalized Expected: variant hg38 chr1 normalized' }
        @{ Id = 'samples/contract_wrong_registry_predecessor'; Contains = 'Unification failure. Got: root_link root0 root1 epoch0 epoch1 verified Expected: root_link root2 root1 epoch0 epoch1 verified' }
        @{ Id = 'samples/contract_wrong_robot_frame'; Contains = 'Unification failure. Got: safety_envelope robot_a map_a frame_map start_a goal_a certified Expected: safety_envelope robot_a map_a frame_camera start_a goal_a certified' }
        @{ Id = 'samples/contract_wrong_role_query'; Contains = 'Unification failure. Got: query operator schema_v5 string Expected: query auditor schema_v5 string' }
        @{ Id = 'samples/contract_wrong_runtime_event'; Contains = 'Unification failure. Got: runtime_event validate_node draft validated Expected: runtime_event publish_node validated authorized' }
        @{ Id = 'samples/contract_wrong_schema_codec'; Contains = 'Unification failure. Got: document schema_v4 Expected: document schema_v5' }
        @{ Id = 'samples/contract_wrong_target_codec'; Contains = 'Unification failure. Got: document v6 Expected: document v5' }
        @{ Id = 'samples/contract_wrong_timeout_witness'; Contains = 'Unification failure. Got: timeout_witness job_a Expected: timeout_witness job_b' }
        @{ Id = 'samples/contract_wrong_transparency_root'; Contains = 'Unification failure. Got: inclusion_witness log_a root_a leaf_a index_7 verified Expected: inclusion_witness log_a root_b leaf_a index_7 verified' }
        @{ Id = 'samples/contract_zero_retry_budget'; Contains = 'Unification failure. Got: budget (succ _) Expected: budget zero' }
    )

    Backends = @{
        'Fsharp,C,Rust,Delphi' = @(
            'samples/managed_string_array'
            'samples/managed_string_builder'
            'samples/managed_string_codepoints'
            'samples/managed_string_concat'
            'samples/managed_string_empty_slice'
            'samples/managed_string_index'
            'samples/managed_string_record'
            'samples/managed_string_recursive'
            'samples/managed_string_runtime'
            'samples/managed_string_runtime_choice'
            'samples/managed_string_shared_calls'
            'samples/managed_string_slice'
            'samples/managed_string_union'
            'samples/mega_brzozowski_derivatives/indexed_dfa_state_cardinality'
            'samples/mega_brzozowski_derivatives/inventory_closed_dfa_runtime'
            'samples/mega_brzozowski_derivatives/runtime_bench'
            'samples/mega_brzozowski_derivatives/runtime_native'
            'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
            'samples/mega_omniledger_erp_kernel/runtime_native'
            'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
            'samples/mega_zeta_structural_laboratory/runtime_native'
            'samples/managed_string_invalid_utf8_slice'
            'samples/managed_string_utf8_boundaries'
        )
        'C,Rust,Delphi' = @(
            'samples/native_main_return_type'
            'samples/arithmetic_branch'
            'samples/native_literal_join_args'
            'samples/dynamic_array_bounds_negative'
            'samples/expression_precedence'
            'samples/float_math'
            'samples/function_call'
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
            'samples/lua_paren_statement'
            'samples/ebpf_map'
            'samples/ebpf_map_full'
            'samples/ebpf_nested'
            'samples/ebpf_unit'
            'samples/ebpf_key'
            'samples/ebpf_minkey'
            'samples/runaway_inline_match_recursion'
            'samples/runtime_existential_unpack'
            'samples/folder_index_module_ambiguous'
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
            'samples/native_cube_flush_delay_direct'
            'samples/native_cube_monotonic_delay_direct'
            'samples/native_package_closure_array_failure'
            'samples/native_package_closure_managed_branch'
            'samples/native_package_closure_managed_failure'
        )
        'C,Delphi' = @(
            'samples/delphi_uses_units'
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
            'samples/c_deep_list_decref'
            'samples/c_self_tail_loop_heap'
            'samples/folder_index_module'
            'samples/gadt_match_loses_constraint'
            'samples/item_metadata_missing_target'
            'samples/match_multiline_scrutinee'
            'samples/multiline_type_application_dropped'
            'samples/native_closure_multimodule'
            'samples/native_closure_multiowner'
            'samples/native_cube_direct'
            'samples/native_cube_frame_direct'
            'samples/native_cube_frame_reuse_direct'
            'samples/native_cube_multiframe_direct'
            'samples/native_cube_paced_stream_direct'
            'samples/native_cube_terminal_stream_direct'
            'samples/native_managed_union_record_two_managed'
            'samples/native_package_fixed_array_local'
            'samples/native_package_fixed_array_mixed_runtime_write'
            'samples/native_package_fixed_array_mixed_types'
            'samples/native_package_fixed_array_numeric_widths'
            'samples/native_package_fixed_array_runtime_index'
            'samples/native_package_fixed_array_two_runtime_indexes'
            'samples/native_replay_repeat_call'
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
            'samples/nominal_phantom_parameter'
            'samples/nominal_union_case_pattern'
            'samples/op_args_application'
            'samples/target_global_conflict'
        )
        'Python' = @(
            'samples/python_foreign_array_index'
        )
        'C,Python' = @(
            'samples/python_macro_annotations'
        )
        'Fsharp,C,Rust,Delphi,TypeScript,Cpp,Python' = @(
            'samples/portable_math_rounding'
        )
        'Fsharp,C,Rust,Delphi,TypeScript,Python' = @(
            'samples/portable_convert_parse'
            'samples/portable_console_lines'
            'samples/printf_portable'
            'samples/op_args_deref_if'
        )
        'C,Rust,TypeScript,Cpp,Python' = @(
            'samples/python_self_tail_call_depth'
            'samples/ts_array_union'
            'samples/ts_closure_capture'
            'samples/ts_closure_return'
            'samples/ts_float_nan'
            'samples/ts_int_wrap'
            'samples/ts_layout_heap'
            'samples/ts_layout_mutable'
            'samples/ts_string_concat'
            'samples/ts_string_slice'
            'samples/ts_tail_loop'
            'samples/ts_tuple_mixed'
            'samples/ts_union_recursive'
            'samples/ts_union_scalar'
            'samples/ts_while_loop'
        )
    }
    Gleam = @(
        'samples/portable_math_rounding'
        'samples/frontier_gadt_growing_index'
        'samples/macro_splice_before_quote'
        'samples/zig_exit_wide'
            'samples/portable_console_lines'
            'samples/portable_convert_parse'
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
        'samples/folder_index_module'
        'samples/frontier_fib'
        'samples/frontier_hello'
        'samples/frontier_macro_then_multiline_annotation'
        'samples/frontier_static_list_eq'
        'samples/frontier_try_item'
        'samples/function_call'
        'samples/gleam_match_narrowed'
        'samples/gleam_match_single_case'
        'samples/item_metadata_missing_target'
        'samples/lua_while_union_pair'
        'samples/managed_string_array'
        'samples/managed_string_builder'
        'samples/managed_string_concat'
        'samples/managed_string_empty_slice'
        'samples/managed_string_index'
        'samples/managed_string_record'
        'samples/managed_string_recursive'
        'samples/managed_string_runtime'
        'samples/managed_string_runtime_choice'
        'samples/managed_string_shared_calls'
        'samples/managed_string_slice'
        'samples/managed_string_union'
        'samples/multiline_comment'
        'samples/multiline_triple_string'
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
        'samples/op_args_deref_if'
        'samples/portable_composite'
        'samples/predicate_call'
        'samples/printf_portable'
        'samples/python_self_tail_call_depth'
        'samples/record_value'
        'samples/recursive_union_list'
        'samples/recursive_union_managed'
        'samples/recursive_union_mutual'
        'samples/recursive_union_terminal_ownership'
        'samples/recursive_union_tree_shared'
        'samples/rust_emit_expr_macro'
        'samples/rust_global_item_macro'
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
        'samples/ts_string_concat'
        'samples/ts_string_slice'
        'samples/ts_tail_loop'
        'samples/ts_tuple_mixed'
        'samples/ts_union_recursive'
        'samples/ts_union_scalar'
        'samples/tuple_mixed'
        'samples/tuple_pair'
        'samples/unsigned_mod'
        'samples/array_bool', 'samples/array_cell', 'samples/array_closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/array_f32', 'samples/array_f64', 'samples/array_fun', 'samples/array_heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/array_heap_f32', 'samples/array_heap_heap', 'samples/array_heap_heap_heap', 'samples/array_heap_heap_pair', 'samples/array_heap_mix', 'samples/array_heap_pair_heaps', 'samples/array_heap_triple_heaps', 'samples/array_heap_union_heap_pair_heaps', 'samples/array_heap_union_heap_union_heap_pair_heaps', 'samples/array_i16', 'samples/array_i32', 'samples/array_i64', 'samples/array_i64_at1', 'samples/array_i8', 'samples/array_mut', 'samples/array_mut_f32', 'samples/array_mut_heap_heap', 'samples/array_mut_heap_heap_pair', 'samples/array_mut_heap_union_heap_pair_heaps', 'samples/array_mut_heap_union_heap_union_heap_pair_heaps', 'samples/array_mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/array_mut_pair', 'samples/array_mut_pair_heaps', 'samples/array_mut_triple_heaps', 'samples/array_text', 'samples/array_text_at1', 'samples/array_u16', 'samples/array_u32', 'samples/array_u64', 'samples/array_u8', 'samples/array_union', 'samples/array_union_heap_heap', 'samples/array_union_heap_pair_heaps', 'samples/array_union_heap_union_heap_pair_heaps', 'samples/array_union_pair_heaps', 'samples/array_union_text', 'samples/array_union_triple_heaps', 'samples/array_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/array2_heap_union_heap_union_heap_pair_heaps', 'samples/array3_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/c_deep_list_decref', 'samples/c_gadt_union_array', 'samples/c_self_tail_loop_heap', 'samples/closure_apply', 'samples/closure_array', 'samples/closure_curry', 'samples/closure_depth', 'samples/closure_f32_heap', 'samples/closure_heap', 'samples/closure_heap_heap', 'samples/closure_heap_heap_heap', 'samples/closure_heap_pair_heaps', 'samples/closure_heap_union_heap_pair_heaps', 'samples/closure_heap_union_heap_union_heap_pair_heaps', 'samples/closure_heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/closure_mut', 'samples/closure_mut_pair', 'samples/closure_pair', 'samples/closure_pair_array', 'samples/closure_pair_bool', 'samples/closure_pair_cell', 'samples/closure_pair_f32', 'samples/closure_pair_f64', 'samples/closure_pair_fun', 'samples/closure_pair_heap', 'samples/closure_pair_heaps', 'samples/closure_pair_i64', 'samples/closure_pair_i8', 'samples/closure_pair_mix', 'samples/closure_pair_slot', 'samples/closure_pair_text', 'samples/closure_pair_union', 'samples/closure_pair_union_heap', 'samples/closure_real', 'samples/closure_return', 'samples/closure_return_heap', 'samples/closure_return_text', 'samples/closure_text', 'samples/closure_text_pair', 'samples/closure_triple', 'samples/closure_triple_heaps', 'samples/closure_u32_flag', 'samples/closure_union', 'samples/closure_union_heap_heap', 'samples/closure_union_heap_pair_heaps', 'samples/closure_union_heap_union_heap_pair_heaps', 'samples/closure_union_mix', 'samples/closure_union_pair_heaps', 'samples/closure_union_triple_heaps', 'samples/closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/closure_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/ebpf_arith', 'samples/ebpf_bacc', 'samples/ebpf_bits', 'samples/ebpf_bool', 'samples/ebpf_cast', 'samples/ebpf_char', 'samples/ebpf_conv', 'samples/ebpf_div', 'samples/ebpf_facc', 'samples/ebpf_fdiv', 'samples/ebpf_float', 'samples/ebpf_flt', 'samples/ebpf_ineq', 'samples/ebpf_neq', 'samples/ebpf_nest3', 'samples/ebpf_sh31', 'samples/ebpf_shift', 'samples/ebpf_snot', 'samples/ebpf_t2', 'samples/ebpf_t3', 'samples/ebpf_tacc', 'samples/ebpf_tworec', 'samples/ebpf_uacc', 'samples/ebpf_uadd', 'samples/ebpf_umul', 'samples/f64_scalar', 'samples/failwith_exit', 'samples/gadt_lazy_payload', 'samples/gadt_match_loses_constraint', 'samples/heap_array', 'samples/heap_array_f32', 'samples/heap_array_n', 'samples/heap_bool', 'samples/heap_bool_text', 'samples/heap_closure', 'samples/heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/heap_f32_n', 'samples/heap_f32_text', 'samples/heap_f32_u32', 'samples/heap_f64s', 'samples/heap_fun', 'samples/heap_heap', 'samples/heap_heap_heap', 'samples/heap_heap_pair_heaps', 'samples/heap_i16_text', 'samples/heap_i64_real', 'samples/heap_i64_text', 'samples/heap_i8', 'samples/heap_i8_text', 'samples/heap_mut_cell', 'samples/heap_nest', 'samples/heap_pair', 'samples/heap_pair_heaps', 'samples/heap_pair_mix', 'samples/heap_real', 'samples/heap_real_text', 'samples/heap_slot', 'samples/heap_text', 'samples/heap_text_eq', 'samples/heap_text_pair', 'samples/heap_texts', 'samples/heap_texts_flag', 'samples/heap_triple', 'samples/heap_triple_heaps', 'samples/heap_u16_text', 'samples/heap_u32_flag', 'samples/heap_u32_text', 'samples/heap_u64_text', 'samples/heap_u8_text', 'samples/heap_union', 'samples/heap_union_heap_pair_heaps', 'samples/heap_union_heap_union_heap_pair_heaps', 'samples/heap_union_pair_heaps', 'samples/heap_union_triple_heaps', 'samples/heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/i64_scalar', 'samples/managed_string_utf8_boundaries', 'samples/match_multiline_scrutinee', 'samples/method_array', 'samples/method_depth', 'samples/method_heap', 'samples/method_i8', 'samples/method_mut', 'samples/method_mut_pair', 'samples/method_pair_cell', 'samples/method_pair_f64', 'samples/method_pair_fun', 'samples/method_pair_heap', 'samples/method_pair_mix', 'samples/method_pair_slot', 'samples/method_pair_text', 'samples/method_pair_union', 'samples/method_pair_union_heap', 'samples/method_real', 'samples/method_return', 'samples/method_text', 'samples/method_text_pair', 'samples/method_union', 'samples/method_union_mix', 'samples/multiline_type_application_dropped', 'samples/mut_f32_text', 'samples/mut_heap_heap', 'samples/mut_heap_heap_heap', 'samples/mut_heap_heap_pair', 'samples/mut_heap_union_heap_pair_heaps', 'samples/mut_heap_union_heap_union_heap_pair_heaps', 'samples/mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/mut_i64_text', 'samples/mut_pair', 'samples/mut_pair_heaps', 'samples/mut_real_text', 'samples/mut_text', 'samples/mut_text_pair', 'samples/mut_triple_heaps', 'samples/mut_u32_text', 'samples/mutable_alias_method_branch', 'samples/native_bitwise_scalar', 'samples/native_closure_diamond_package', 'samples/native_closure_external_package', 'samples/native_closure_transitive_package', 'samples/native_float_pow_pi', 'samples/native_layout_heap', 'samples/native_layout_mutable', 'samples/native_package_prototype_record_callback', 'samples/native_source_package_prototype_record_callback', 'samples/native_source_package_prototype_union_callback', 'samples/native_source_package_prototype_union_callback_managed_single_owner', 'samples/native_source_package_prototype_union_callback_managed_two_cases', 'samples/nominal_phantom_parameter', 'samples/nominal_record_field_order', 'samples/package_default_int_i64', 'samples/qualified_union_case_pattern', 'samples/recur_sum', 'samples/recursive_union_multi_case', 'samples/rust_static_closure_chain', 'samples/small_int_ops', 'samples/small_int_scalar', 'samples/string_eq', 'samples/string_utf8', 'samples/ts_int_wrap', 'samples/ts_layout_heap', 'samples/ts_layout_mutable', 'samples/typecheck_long_let_body', 'samples/union_array', 'samples/union_array_mix', 'samples/union_bool', 'samples/union_call', 'samples/union_case_record_field_order', 'samples/union_cell_mix', 'samples/union_f32_text', 'samples/union_f64s', 'samples/union_fun_mix', 'samples/union_heap', 'samples/union_heap_heap', 'samples/union_heap_heap_heap', 'samples/union_heap_pair_heaps', 'samples/union_heap_union_heap_pair_heaps', 'samples/union_i64_text', 'samples/union_i8', 'samples/union_i8_text', 'samples/union_mut', 'samples/union_nested', 'samples/union_option', 'samples/union_pair', 'samples/union_pair_heaps', 'samples/union_pair_mix', 'samples/union_real', 'samples/union_real_mix', 'samples/union_text', 'samples/union_text_pair', 'samples/union_texts', 'samples/union_texts_flag', 'samples/union_triple_heaps', 'samples/union_triple_mix', 'samples/union_u32_flag', 'samples/union_u32_text', 'samples/union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/union3_heap_union_heap_union_heap_pair_heaps', 'samples/upstream_type_if', 'samples/wgsl_array_scalar', 'samples/wgsl_array_tuple', 'samples/wgsl_record_loop', 'samples/wgsl_tail_call_in_match', 'samples/wgsl_unit_self_loop'
        'samples/array_create_reads_zero'
        'samples/frontier_format_any_union'
        'samples/frontier_hopacsota_globals_order'
        'samples/frontier_hopacsota_mutual_pending'
        'samples/frontier_hopacsota_recursion_inferred'
        'samples/frontier_join_format_any'
        'samples/mega_brzozowski_derivatives/indexed_dfa_state_cardinality'
        'samples/mega_brzozowski_derivatives/inventory_closed_dfa_runtime'
        'samples/mega_brzozowski_derivatives/runtime_bench'
        'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
        'samples/mega_omniledger_erp_kernel/runtime_native'
        'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
        'samples/mega_zeta_structural_laboratory/runtime_native'
        'samples/native_replay_repeat_call'
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
        'samples/wgsl_nullary_union'
        'samples/wgsl_payload_union'
        'samples/lua_wide_integers'
        'samples/managed_string_codepoints'
        'samples/mega_brzozowski_derivatives/runtime_native'
        'samples/string_ord'
        'samples/wgsl_gadt_payload_union'
    )
    Python = @(
        'samples/c_deep_list_decref'
        'samples/c_self_tail_loop_heap'
        'samples/frontier_gadt_growing_index'
        'samples/frontier_hopacsota_mutual_pending'
        'samples/frontier_hopacsota_recursion_inferred'
        'samples/macro_splice_before_quote'
        'samples/zig_exit_wide'
        'samples/arithmetic_branch', 'samples/array_bool', 'samples/array_cell', 'samples/array_closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/array_create_reads_zero', 'samples/array_f32', 'samples/array_f64', 'samples/array_fun', 'samples/array_heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/array_heap_f32', 'samples/array_heap_heap', 'samples/array_heap_heap_heap', 'samples/array_heap_heap_pair', 'samples/array_heap_mix', 'samples/array_heap_pair_heaps', 'samples/array_heap_triple_heaps', 'samples/array_heap_union_heap_pair_heaps', 'samples/array_heap_union_heap_union_heap_pair_heaps', 'samples/array_i16', 'samples/array_i32', 'samples/array_i64', 'samples/array_i64_at1', 'samples/array_i8', 'samples/array_mut', 'samples/array_mut_f32', 'samples/array_mut_heap_heap', 'samples/array_mut_heap_heap_pair', 'samples/array_mut_heap_union_heap_pair_heaps', 'samples/array_mut_heap_union_heap_union_heap_pair_heaps', 'samples/array_mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/array_mut_pair', 'samples/array_mut_pair_heaps', 'samples/array_mut_triple_heaps', 'samples/array_text', 'samples/array_text_at1', 'samples/array_u16', 'samples/array_u32', 'samples/array_u64', 'samples/array_u8', 'samples/array_union', 'samples/array_union_heap_heap', 'samples/array_union_heap_pair_heaps', 'samples/array_union_heap_union_heap_pair_heaps', 'samples/array_union_pair_heaps', 'samples/array_union_text', 'samples/array_union_triple_heaps', 'samples/array_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/array2_heap_union_heap_union_heap_pair_heaps', 'samples/array3_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/backend_smoke', 'samples/branch_select', 'samples/c_gadt_union_array', 'samples/closure_apply', 'samples/closure_array', 'samples/closure_curry', 'samples/closure_depth', 'samples/closure_f32_heap', 'samples/closure_heap', 'samples/closure_heap_heap', 'samples/closure_heap_heap_heap', 'samples/closure_heap_pair_heaps', 'samples/closure_heap_union_heap_pair_heaps', 'samples/closure_heap_union_heap_union_heap_pair_heaps', 'samples/closure_heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/closure_mut', 'samples/closure_mut_pair', 'samples/closure_pair', 'samples/closure_pair_array', 'samples/closure_pair_bool', 'samples/closure_pair_cell', 'samples/closure_pair_f32', 'samples/closure_pair_f64', 'samples/closure_pair_fun', 'samples/closure_pair_heap', 'samples/closure_pair_heaps', 'samples/closure_pair_i64', 'samples/closure_pair_i8', 'samples/closure_pair_mix', 'samples/closure_pair_slot', 'samples/closure_pair_text', 'samples/closure_pair_union', 'samples/closure_pair_union_heap', 'samples/closure_real', 'samples/closure_return', 'samples/closure_return_heap', 'samples/closure_return_text', 'samples/closure_text', 'samples/closure_text_pair', 'samples/closure_triple', 'samples/closure_triple_heaps', 'samples/closure_u32_flag', 'samples/closure_union', 'samples/closure_union_heap_heap', 'samples/closure_union_heap_pair_heaps', 'samples/closure_union_heap_union_heap_pair_heaps', 'samples/closure_union_mix', 'samples/closure_union_pair_heaps', 'samples/closure_union_triple_heaps', 'samples/closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/closure_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/dynamic_array_bool', 'samples/dynamic_array_f64', 'samples/dynamic_array_function_boundary', 'samples/dynamic_array_mutable_alias', 'samples/dynamic_array_nested', 'samples/dynamic_array_record', 'samples/dynamic_array_record_shared_alias', 'samples/dynamic_array_return', 'samples/dynamic_array_runtime_length', 'samples/dynamic_array_shared_alias', 'samples/dynamic_array_union', 'samples/dynamic_array_union_nested', 'samples/dynamic_array_union_nested_shared_alias', 'samples/dynamic_array_union_shared_alias', 'samples/ebpf_arith', 'samples/ebpf_bacc', 'samples/ebpf_bits', 'samples/ebpf_bool', 'samples/ebpf_cast', 'samples/ebpf_char', 'samples/ebpf_conv', 'samples/ebpf_div', 'samples/ebpf_facc', 'samples/ebpf_fdiv', 'samples/ebpf_float', 'samples/ebpf_flt', 'samples/ebpf_ineq', 'samples/ebpf_neq', 'samples/ebpf_nest3', 'samples/ebpf_sh31', 'samples/ebpf_shift', 'samples/ebpf_snot', 'samples/ebpf_t2', 'samples/ebpf_t3', 'samples/ebpf_tacc', 'samples/ebpf_tworec', 'samples/ebpf_uacc', 'samples/ebpf_uadd', 'samples/ebpf_umul', 'samples/expression_precedence', 'samples/f64_scalar', 'samples/failwith_exit', 'samples/fixed_array_runtime_index', 'samples/fixed_array_runtime_update', 'samples/fixed_array_scalar', 'samples/float_math', 'samples/folder_index_module', 'samples/frontier_fib', 'samples/frontier_format_any_union', 'samples/frontier_hello', 'samples/frontier_join_format_any', 'samples/frontier_macro_then_multiline_annotation', 'samples/frontier_static_list_eq', 'samples/frontier_try_item', 'samples/function_call', 'samples/gadt_lazy_payload', 'samples/gadt_match_loses_constraint', 'samples/gleam_match_narrowed', 'samples/gleam_match_single_case', 'samples/heap_array', 'samples/heap_array_f32', 'samples/heap_array_n', 'samples/heap_bool', 'samples/heap_bool_text', 'samples/heap_closure', 'samples/heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/heap_f32_n', 'samples/heap_f32_text', 'samples/heap_f32_u32', 'samples/heap_f64s', 'samples/heap_fun', 'samples/heap_heap', 'samples/heap_heap_heap', 'samples/heap_heap_pair_heaps', 'samples/heap_i16_text', 'samples/heap_i64_real', 'samples/heap_i64_text', 'samples/heap_i8', 'samples/heap_i8_text', 'samples/heap_mut_cell', 'samples/heap_nest', 'samples/heap_pair', 'samples/heap_pair_heaps', 'samples/heap_pair_mix', 'samples/heap_real', 'samples/heap_real_text', 'samples/heap_slot', 'samples/heap_text', 'samples/heap_text_eq', 'samples/heap_text_pair', 'samples/heap_texts', 'samples/heap_texts_flag', 'samples/heap_triple', 'samples/heap_triple_heaps', 'samples/heap_u16_text', 'samples/heap_u32_flag', 'samples/heap_u32_text', 'samples/heap_u64_text', 'samples/heap_u8_text', 'samples/heap_union', 'samples/heap_union_heap_pair_heaps', 'samples/heap_union_heap_union_heap_pair_heaps', 'samples/heap_union_pair_heaps', 'samples/heap_union_triple_heaps', 'samples/heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/i64_scalar', 'samples/item_metadata_missing_target', 'samples/lua_while_union_pair', 'samples/lua_wide_integers', 'samples/managed_string_array', 'samples/managed_string_builder', 'samples/managed_string_codepoints', 'samples/managed_string_concat', 'samples/managed_string_empty_slice', 'samples/managed_string_index', 'samples/managed_string_invalid_utf8_slice', 'samples/managed_string_record', 'samples/managed_string_recursive', 'samples/managed_string_runtime', 'samples/managed_string_runtime_choice', 'samples/managed_string_shared_calls', 'samples/managed_string_slice', 'samples/managed_string_union', 'samples/managed_string_utf8_boundaries', 'samples/match_multiline_scrutinee', 'samples/mega_brzozowski_derivatives/indexed_dfa_state_cardinality', 'samples/mega_brzozowski_derivatives/inventory_closed_dfa_runtime', 'samples/mega_brzozowski_derivatives/runtime_bench', 'samples/mega_brzozowski_derivatives/runtime_native', 'samples/mega_lean_cic_bottom_up_kernel/runtime_native', 'samples/mega_omniledger_erp_kernel/runtime_native', 'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native', 'samples/mega_zeta_structural_laboratory/runtime_native', 'samples/method_array', 'samples/method_depth', 'samples/method_heap', 'samples/method_i8', 'samples/method_mut', 'samples/method_mut_pair', 'samples/method_pair_cell', 'samples/method_pair_f64', 'samples/method_pair_fun', 'samples/method_pair_heap', 'samples/method_pair_mix', 'samples/method_pair_slot', 'samples/method_pair_text', 'samples/method_pair_union', 'samples/method_pair_union_heap', 'samples/method_real', 'samples/method_return', 'samples/method_text', 'samples/method_text_pair', 'samples/method_union', 'samples/method_union_mix', 'samples/multiline_comment', 'samples/multiline_triple_string', 'samples/multiline_type_application_dropped', 'samples/mut_f32_text', 'samples/mut_heap_heap', 'samples/mut_heap_heap_heap', 'samples/mut_heap_heap_pair', 'samples/mut_heap_union_heap_pair_heaps', 'samples/mut_heap_union_heap_union_heap_pair_heaps', 'samples/mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/mut_i64_text', 'samples/mut_pair', 'samples/mut_pair_heaps', 'samples/mut_real_text', 'samples/mut_text', 'samples/mut_text_pair', 'samples/mut_triple_heaps', 'samples/mut_u32_text', 'samples/mutable_alias_method_branch', 'samples/native_bitwise_scalar', 'samples/native_closure_array_capture', 'samples/native_closure_branch', 'samples/native_closure_capture', 'samples/native_closure_captured_branch', 'samples/native_closure_diamond_package', 'samples/native_closure_external_package', 'samples/native_closure_managed_capture', 'samples/native_closure_managed_captured_branch', 'samples/native_closure_managed_reuse', 'samples/native_closure_multimodule', 'samples/native_closure_multiowner', 'samples/native_closure_nested_branch', 'samples/native_closure_recursive_capture', 'samples/native_closure_return', 'samples/native_closure_reuse', 'samples/native_closure_transitive_package', 'samples/native_closure_transport', 'samples/native_closure_union_capture_method', 'samples/native_closure_union_rec', 'samples/native_cube_direct', 'samples/native_float_infinity', 'samples/native_float_math_family', 'samples/native_float_pow_pi', 'samples/native_float_sqrt', 'samples/native_layout_heap', 'samples/native_layout_mutable', 'samples/native_literal_join_args', 'samples/native_managed_array_tail_recursion', 'samples/native_managed_scc_tail_recursion', 'samples/native_managed_tail_recursion', 'samples/native_managed_union_array_closure', 'samples/native_managed_union_capture_record', 'samples/native_managed_union_record_closure', 'samples/native_managed_union_record_two_managed', 'samples/native_multimodule', 'samples/native_package_fixed_array_local', 'samples/native_package_fixed_array_mixed_runtime_write', 'samples/native_package_fixed_array_mixed_types', 'samples/native_package_fixed_array_numeric_widths', 'samples/native_package_fixed_array_runtime_index', 'samples/native_package_fixed_array_two_runtime_indexes', 'samples/native_package_owned_array_failure', 'samples/native_package_owned_array_transitive', 'samples/native_package_owned_array_type', 'samples/native_package_owned_managed_type', 'samples/native_package_owned_type', 'samples/native_package_prototype_record_callback', 'samples/native_prototype_record_callback', 'samples/native_prototype_union_closure_method', 'samples/native_recursive_tail_recursion', 'samples/native_replay_repeat_call', 'samples/native_source_package_prototype_record_callback', 'samples/native_source_package_prototype_union_callback', 'samples/native_source_package_prototype_union_callback_managed_single_owner', 'samples/native_source_package_prototype_union_callback_managed_two_cases', 'samples/native_string_utf8_canonical_equal_bounded_source', 'samples/native_string_utf8_fold_source', 'samples/native_string_utf8_fold_source_invalid', 'samples/native_string_utf8_grapheme_bounded_source', 'samples/native_string_utf8_grapheme_bounded_source_invalid', 'samples/native_string_utf8_normalization_bounded_source', 'samples/native_string_utf8_scalar_source', 'samples/native_string_utf8_scalar_source_invalid', 'samples/native_string_utf8_validate_source', 'samples/native_string_utf8_validate_source_invalid', 'samples/native_tail_recursion', 'samples/nested_tuple', 'samples/nominal_phantom_parameter', 'samples/nominal_record_field_order', 'samples/nominal_union_case_pattern', 'samples/op_args_application', 'samples/package_default_int_i64', 'samples/portable_composite', 'samples/predicate_call', 'samples/qualified_union_case_pattern', 'samples/record_value', 'samples/recur_sum', 'samples/recursive_union_list', 'samples/recursive_union_managed', 'samples/recursive_union_multi_case', 'samples/recursive_union_mutual', 'samples/recursive_union_terminal_ownership', 'samples/recursive_union_tree_shared', 'samples/rust_emit_expr_macro', 'samples/rust_global_item_macro', 'samples/rust_static_closure_chain', 'samples/rust_target_globals', 'samples/small_int_ops', 'samples/small_int_scalar', 'samples/static_string', 'samples/string_eq', 'samples/string_ord', 'samples/string_utf8', 'samples/tagged_union_enum', 'samples/tagged_union_heterogeneous', 'samples/tagged_union_scalar', 'samples/tagged_union_three_case', 'samples/tail_loop', 'samples/target_global_conflict', 'samples/tuple_mixed', 'samples/tuple_pair', 'samples/typecheck_long_let_body', 'samples/union_array', 'samples/union_array_mix', 'samples/union_bool', 'samples/union_call', 'samples/union_case_record_field_order', 'samples/union_cell_mix', 'samples/union_f32_text', 'samples/union_f64s', 'samples/union_fun_mix', 'samples/union_heap', 'samples/union_heap_heap', 'samples/union_heap_heap_heap', 'samples/union_heap_pair_heaps', 'samples/union_heap_union_heap_pair_heaps', 'samples/union_i64_text', 'samples/union_i8', 'samples/union_i8_text', 'samples/union_mut', 'samples/union_nested', 'samples/union_option', 'samples/union_pair', 'samples/union_pair_heaps', 'samples/union_pair_mix', 'samples/union_real', 'samples/union_real_mix', 'samples/union_text', 'samples/union_text_pair', 'samples/union_texts', 'samples/union_texts_flag', 'samples/union_triple_heaps', 'samples/union_triple_mix', 'samples/union_u32_flag', 'samples/union_u32_text', 'samples/union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/union3_heap_union_heap_union_heap_pair_heaps', 'samples/unsigned_mod', 'samples/upstream_type_if', 'samples/wgsl_array_scalar', 'samples/wgsl_array_tuple', 'samples/wgsl_gadt_payload_union', 'samples/wgsl_nullary_union', 'samples/wgsl_payload_union', 'samples/wgsl_record_loop', 'samples/wgsl_tail_call_in_match', 'samples/wgsl_unit_self_loop'
    )
    Lua = @(
        'samples/ebpf_conv'
        'samples/native_prototype_record_callback'
        'samples/native_package_prototype_record_callback'
        'samples/native_source_package_prototype_record_callback'
        'samples/c_deep_list_decref'
        'samples/frontier_gadt_growing_index'
        'samples/zig_exit_wide'
        'samples/lua_paren_statement'
        'samples/macro_splice_before_quote'
        'samples/portable_convert_parse'
        'samples/array_bool',
        'samples/array_cell',
        'samples/array_closure_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/array_create_reads_zero',
        'samples/array_f32',
        'samples/array_f64',
        'samples/array_fun',
        'samples/array_heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/array_heap_f32',
        'samples/array_heap_heap',
        'samples/array_heap_heap_heap',
        'samples/array_heap_heap_pair',
        'samples/array_heap_mix',
        'samples/array_heap_pair_heaps',
        'samples/array_heap_triple_heaps',
        'samples/array_heap_union_heap_pair_heaps',
        'samples/array_heap_union_heap_union_heap_pair_heaps',
        'samples/array_i16',
        'samples/array_i32',
        'samples/array_i64',
        'samples/array_i64_at1',
        'samples/array_i8',
        'samples/array_mut',
        'samples/array_mut_f32',
        'samples/array_mut_heap_heap',
        'samples/array_mut_heap_heap_pair',
        'samples/array_mut_heap_union_heap_pair_heaps',
        'samples/array_mut_heap_union_heap_union_heap_pair_heaps',
        'samples/array_mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/array_mut_pair',
        'samples/array_mut_pair_heaps',
        'samples/array_mut_triple_heaps',
        'samples/array_text',
        'samples/array_text_at1',
        'samples/array_u16',
        'samples/array_u32',
        'samples/array_u64',
        'samples/array_u8',
        'samples/array_union',
        'samples/array_union_heap_heap',
        'samples/array_union_heap_pair_heaps',
        'samples/array_union_heap_union_heap_pair_heaps',
        'samples/array_union_pair_heaps',
        'samples/array_union_text',
        'samples/array_union_triple_heaps',
        'samples/array_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/array2_heap_union_heap_union_heap_pair_heaps',
        'samples/array3_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/c_gadt_union_array',
        'samples/closure_apply',
        'samples/closure_array',
        'samples/closure_curry',
        'samples/closure_depth',
        'samples/closure_f32_heap',
        'samples/closure_heap',
        'samples/closure_heap_heap',
        'samples/closure_heap_heap_heap',
        'samples/closure_heap_pair_heaps',
        'samples/closure_heap_union_heap_pair_heaps',
        'samples/closure_heap_union_heap_union_heap_pair_heaps',
        'samples/closure_heap_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/closure_mut',
        'samples/closure_mut_pair',
        'samples/closure_pair',
        'samples/closure_pair_array',
        'samples/closure_pair_bool',
        'samples/closure_pair_cell',
        'samples/closure_pair_f32',
        'samples/closure_pair_f64',
        'samples/closure_pair_fun',
        'samples/closure_pair_heap',
        'samples/closure_pair_heaps',
        'samples/closure_pair_i64',
        'samples/closure_pair_i8',
        'samples/closure_pair_mix',
        'samples/closure_pair_slot',
        'samples/closure_pair_text',
        'samples/closure_pair_union',
        'samples/closure_pair_union_heap',
        'samples/closure_real',
        'samples/closure_return',
        'samples/closure_return_heap',
        'samples/closure_return_text',
        'samples/closure_text',
        'samples/closure_text_pair',
        'samples/closure_triple',
        'samples/closure_triple_heaps',
        'samples/closure_u32_flag',
        'samples/closure_union',
        'samples/closure_union_heap_heap',
        'samples/closure_union_heap_pair_heaps',
        'samples/closure_union_heap_union_heap_pair_heaps',
        'samples/closure_union_mix',
        'samples/closure_union_pair_heaps',
        'samples/closure_union_triple_heaps',
        'samples/closure_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/closure_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/ebpf_arith',
        'samples/ebpf_bacc',
        'samples/ebpf_bits',
        'samples/ebpf_bool',
        'samples/ebpf_cast',
        'samples/ebpf_char',
        'samples/ebpf_div',
        'samples/ebpf_facc',
        'samples/ebpf_fdiv',
        'samples/ebpf_float',
        'samples/ebpf_flt',
        'samples/ebpf_ineq',
        'samples/ebpf_neq',
        'samples/ebpf_nest3',
        'samples/ebpf_sh31',
        'samples/ebpf_shift',
        'samples/ebpf_snot',
        'samples/ebpf_t2',
        'samples/ebpf_t3',
        'samples/ebpf_tacc',
        'samples/ebpf_tworec',
        'samples/ebpf_uacc',
        'samples/ebpf_uadd',
        'samples/ebpf_umul',
        'samples/f64_scalar',
        'samples/failwith_exit',
        'samples/gadt_lazy_payload',
        'samples/gadt_match_loses_constraint',
        'samples/heap_array',
        'samples/heap_array_f32',
        'samples/heap_array_n',
        'samples/heap_bool',
        'samples/heap_bool_text',
        'samples/heap_closure',
        'samples/heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/heap_f32_n',
        'samples/heap_f32_text',
        'samples/heap_f32_u32',
        'samples/heap_f64s',
        'samples/heap_fun',
        'samples/heap_heap',
        'samples/heap_heap_heap',
        'samples/heap_heap_pair_heaps',
        'samples/heap_i16_text',
        'samples/heap_i64_real',
        'samples/heap_i64_text',
        'samples/heap_i8',
        'samples/heap_i8_text',
        'samples/heap_mut_cell',
        'samples/heap_nest',
        'samples/heap_pair',
        'samples/heap_pair_heaps',
        'samples/heap_pair_mix',
        'samples/heap_real',
        'samples/heap_real_text',
        'samples/heap_slot',
        'samples/heap_text',
        'samples/heap_text_eq',
        'samples/heap_text_pair',
        'samples/heap_texts',
        'samples/heap_texts_flag',
        'samples/heap_triple',
        'samples/heap_triple_heaps',
        'samples/heap_u16_text',
        'samples/heap_u32_flag',
        'samples/heap_u32_text',
        'samples/heap_u64_text',
        'samples/heap_u8_text',
        'samples/heap_union',
        'samples/heap_union_heap_pair_heaps',
        'samples/heap_union_heap_union_heap_pair_heaps',
        'samples/heap_union_pair_heaps',
        'samples/heap_union_triple_heaps',
        'samples/heap_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/i64_scalar',
        'samples/managed_string_builder',
        'samples/managed_string_concat',
        'samples/managed_string_empty_slice',
        'samples/managed_string_utf8_boundaries',
        'samples/match_multiline_scrutinee',
        'samples/method_array',
        'samples/method_depth',
        'samples/method_heap',
        'samples/method_i8',
        'samples/method_mut',
        'samples/method_mut_pair',
        'samples/method_pair_cell',
        'samples/method_pair_f64',
        'samples/method_pair_fun',
        'samples/method_pair_heap',
        'samples/method_pair_mix',
        'samples/method_pair_slot',
        'samples/method_pair_text',
        'samples/method_pair_union',
        'samples/method_pair_union_heap',
        'samples/method_real',
        'samples/method_return',
        'samples/method_text',
        'samples/method_text_pair',
        'samples/method_union',
        'samples/method_union_mix',
        'samples/multiline_type_application_dropped',
        'samples/mut_f32_text',
        'samples/mut_heap_heap',
        'samples/mut_heap_heap_heap',
        'samples/mut_heap_heap_pair',
        'samples/mut_heap_union_heap_pair_heaps',
        'samples/mut_heap_union_heap_union_heap_pair_heaps',
        'samples/mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/mut_i64_text',
        'samples/mut_pair',
        'samples/mut_pair_heaps',
        'samples/mut_real_text',
        'samples/mut_text',
        'samples/mut_text_pair',
        'samples/mut_triple_heaps',
        'samples/mut_u32_text',
        'samples/native_bitwise_scalar',
        'samples/native_closure_diamond_package',
        'samples/native_closure_external_package',
        'samples/native_closure_transitive_package',
        'samples/native_float_infinity',
        'samples/native_replay_repeat_call',
        'samples/native_source_package_prototype_union_callback',
        'samples/native_source_package_prototype_union_callback_managed_single_owner',
        'samples/native_source_package_prototype_union_callback_managed_two_cases',
        'samples/native_string_utf8_canonical_equal_bounded_source',
        'samples/native_string_utf8_fold_source',
        'samples/native_string_utf8_fold_source_invalid',
        'samples/native_string_utf8_grapheme_bounded_source',
        'samples/native_string_utf8_grapheme_bounded_source_invalid',
        'samples/native_string_utf8_normalization_bounded_source',
        'samples/native_string_utf8_scalar_source',
        'samples/native_string_utf8_scalar_source_invalid',
        'samples/native_string_utf8_validate_source',
        'samples/native_string_utf8_validate_source_invalid',
        'samples/nominal_phantom_parameter',
        'samples/nominal_record_field_order',
        'samples/qualified_union_case_pattern',
        'samples/recur_sum',
        'samples/recursive_union_multi_case',
        'samples/small_int_ops',
        'samples/small_int_scalar',
        'samples/string_eq',
        'samples/string_ord',
        'samples/string_utf8',
        'samples/ts_string_concat',
        'samples/union_array',
        'samples/union_array_mix',
        'samples/union_bool',
        'samples/union_call',
        'samples/union_case_record_field_order',
        'samples/union_cell_mix',
        'samples/union_f32_text',
        'samples/union_f64s',
        'samples/union_fun_mix',
        'samples/union_heap',
        'samples/union_heap_heap',
        'samples/union_heap_heap_heap',
        'samples/union_heap_pair_heaps',
        'samples/union_heap_union_heap_pair_heaps',
        'samples/union_i64_text',
        'samples/union_i8',
        'samples/union_i8_text',
        'samples/union_mut',
        'samples/union_nested',
        'samples/union_option',
        'samples/union_pair',
        'samples/union_pair_heaps',
        'samples/union_pair_mix',
        'samples/union_real',
        'samples/union_real_mix',
        'samples/union_text',
        'samples/union_text_pair',
        'samples/union_texts',
        'samples/union_texts_flag',
        'samples/union_triple_heaps',
        'samples/union_triple_mix',
        'samples/union_u32_flag',
        'samples/union_u32_text',
        'samples/union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/union3_heap_union_heap_union_heap_pair_heaps',
        'samples/upstream_type_if',
        'samples/wgsl_array_scalar',
        'samples/wgsl_array_tuple',
        'samples/wgsl_gadt_payload_union',
        'samples/wgsl_nullary_union',
        'samples/wgsl_payload_union',
        'samples/wgsl_record_loop',
        'samples/wgsl_tail_call_in_match',
        'samples/wgsl_unit_self_loop'
        'samples/lua_wide_integers'
        'samples/ts_int_wrap'
        'samples/mega_brzozowski_derivatives/indexed_dfa_state_cardinality'
        'samples/gleam_match_narrowed'
        'samples/gleam_match_single_case'
        'samples/portable_console_lines'
        'samples/portable_math_rounding'
        'samples/arithmetic_branch'
        'samples/backend_smoke'
        'samples/branch_select'
        'samples/dynamic_array_bool'
        'samples/dynamic_array_bounds_negative'
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
        'samples/managed_string_codepoints'
        'samples/managed_string_index'
        'samples/managed_string_record'
        'samples/managed_string_recursive'
        'samples/managed_string_runtime'
        'samples/managed_string_runtime_choice'
        'samples/managed_string_shared_calls'
        'samples/managed_string_slice'
        'samples/managed_string_union'
        'samples/mega_brzozowski_derivatives/inventory_closed_dfa_runtime'
        'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
        'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
        'samples/mega_zeta_structural_laboratory/runtime_native'
        'samples/multiline_comment'
        'samples/multiline_triple_string'
        'samples/mutable_alias_method_branch'
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
        'samples/native_float_math_family'
        'samples/native_float_pow_pi'
        'samples/native_float_sqrt'
        'samples/native_layout_heap'
        'samples/native_layout_mutable'
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
        'samples/native_prototype_union_closure_method'
        'samples/native_recursive_tail_recursion'
        'samples/native_tail_recursion'
        'samples/nested_tuple'
        'samples/nominal_union_case_pattern'
        'samples/op_args_application'
        'samples/op_args_deref_if'
        'samples/portable_composite'
        'samples/predicate_call'
        'samples/printf_portable'
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
        'samples/ts_layout_heap'
        'samples/ts_layout_mutable'
        'samples/ts_string_slice'
        'samples/ts_tail_loop'
        'samples/ts_tuple_mixed'
        'samples/ts_union_recursive'
        'samples/ts_union_scalar'
        'samples/tuple_mixed'
        'samples/tuple_pair'
        'samples/unsigned_mod'
        'samples/c_self_tail_loop_heap'
        'samples/frontier_format_any_union'
        'samples/frontier_hopacsota_globals_order'
        'samples/frontier_hopacsota_mutual_pending'
        'samples/frontier_hopacsota_recursion_inferred'
        'samples/frontier_join_format_any'
        'samples/mega_brzozowski_derivatives/runtime_native'
        'samples/mega_omniledger_erp_kernel/runtime_native'
        'samples/package_default_int_i64'
        'samples/typecheck_long_let_body'
    )
    Bend = @(
        'samples/arithmetic_branch'
        'samples/array_bool'
        'samples/array_cell'
        'samples/array_closure_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/array_create_reads_zero'
        'samples/array_f32'
        'samples/array_heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/array_heap_f32'
        'samples/array_heap_heap'
        'samples/array_heap_heap_heap'
        'samples/array_heap_heap_pair'
        'samples/array_heap_mix'
        'samples/array_heap_pair_heaps'
        'samples/array_heap_triple_heaps'
        'samples/array_heap_union_heap_pair_heaps'
        'samples/array_heap_union_heap_union_heap_pair_heaps'
        'samples/array_i16'
        'samples/array_i32'
        'samples/array_i64'
        'samples/array_i64_at1'
        'samples/array_i8'
        'samples/array_text'
        'samples/array_text_at1'
        'samples/array_u16'
        'samples/array_u32'
        'samples/array_u64'
        'samples/array_u8'
        'samples/array_union'
        'samples/array_union_heap_heap'
        'samples/array_union_heap_pair_heaps'
        'samples/array_union_heap_union_heap_pair_heaps'
        'samples/array_union_pair_heaps'
        'samples/array_union_text'
        'samples/array_union_triple_heaps'
        'samples/array_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/array2_heap_union_heap_union_heap_pair_heaps'
        'samples/array3_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/backend_smoke'
        'samples/branch_select'
        'samples/c_deep_list_decref'
        'samples/c_gadt_union_array'
        'samples/c_self_tail_loop_heap'
        'samples/closure_apply'
        'samples/closure_array'
        'samples/closure_curry'
        'samples/closure_depth'
        'samples/closure_f32_heap'
        'samples/closure_heap'
        'samples/closure_heap_heap'
        'samples/closure_heap_heap_heap'
        'samples/closure_heap_pair_heaps'
        'samples/closure_heap_union_heap_pair_heaps'
        'samples/closure_heap_union_heap_union_heap_pair_heaps'
        'samples/closure_heap_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/closure_mut'
        'samples/closure_mut_pair'
        'samples/closure_pair'
        'samples/closure_pair_array'
        'samples/closure_pair_bool'
        'samples/closure_pair_cell'
        'samples/closure_pair_f32'
        'samples/closure_pair_fun'
        'samples/closure_pair_heap'
        'samples/closure_pair_heaps'
        'samples/closure_pair_i64'
        'samples/closure_pair_i8'
        'samples/closure_pair_mix'
        'samples/closure_pair_slot'
        'samples/closure_pair_text'
        'samples/closure_pair_union'
        'samples/closure_pair_union_heap'
        'samples/closure_return'
        'samples/closure_return_heap'
        'samples/closure_return_text'
        'samples/closure_text'
        'samples/closure_text_pair'
        'samples/closure_triple'
        'samples/closure_triple_heaps'
        'samples/closure_u32_flag'
        'samples/closure_union'
        'samples/closure_union_heap_heap'
        'samples/closure_union_heap_pair_heaps'
        'samples/closure_union_heap_union_heap_pair_heaps'
        'samples/closure_union_mix'
        'samples/closure_union_pair_heaps'
        'samples/closure_union_triple_heaps'
        'samples/closure_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/closure_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/dynamic_array_bool'
        'samples/dynamic_array_bounds_negative'
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
        'samples/ebpf_arith'
        'samples/ebpf_bacc'
        'samples/ebpf_bits'
        'samples/ebpf_bool'
        'samples/ebpf_cast'
        'samples/ebpf_char'
        'samples/ebpf_conv'
        'samples/ebpf_div'
        'samples/ebpf_facc'
        'samples/ebpf_fdiv'
        'samples/ebpf_float'
        'samples/ebpf_flt'
        'samples/ebpf_ineq'
        'samples/ebpf_key'
        'samples/ebpf_map'
        'samples/ebpf_minkey'
        'samples/ebpf_neq'
        'samples/ebpf_nest3'
        'samples/ebpf_sh31'
        'samples/ebpf_shift'
        'samples/ebpf_snot'
        'samples/ebpf_t2'
        'samples/ebpf_t3'
        'samples/ebpf_tacc'
        'samples/ebpf_tworec'
        'samples/ebpf_uacc'
        'samples/ebpf_uadd'
        'samples/ebpf_umul'
        'samples/ebpf_unit'
        'samples/failwith_exit'
        'samples/fixed_array_runtime_index'
        'samples/fixed_array_runtime_update'
        'samples/fixed_array_scalar'
        'samples/float_math'
        'samples/folder_index_module'
        'samples/frontier_fib'
        'samples/frontier_gadt_growing_index'
        'samples/frontier_hello'
        'samples/frontier_hopacsota_mutual_pending'
        'samples/frontier_hopacsota_recursion_inferred'
        'samples/frontier_macro_then_multiline_annotation'
        'samples/frontier_static_list_eq'
        'samples/frontier_try_item'
        'samples/function_call'
        'samples/gadt_lazy_payload'
        'samples/gadt_match_loses_constraint'
        'samples/gleam_match_narrowed'
        'samples/gleam_match_single_case'
        'samples/heap_array'
        'samples/heap_array_f32'
        'samples/heap_array_n'
        'samples/heap_bool'
        'samples/heap_bool_text'
        'samples/heap_closure'
        'samples/heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/heap_f32_n'
        'samples/heap_f32_text'
        'samples/heap_f32_u32'
        'samples/heap_fun'
        'samples/heap_heap'
        'samples/heap_heap_heap'
        'samples/heap_heap_pair_heaps'
        'samples/heap_i16_text'
        'samples/heap_i64_text'
        'samples/heap_i8'
        'samples/heap_i8_text'
        'samples/heap_mut_cell'
        'samples/heap_nest'
        'samples/heap_pair'
        'samples/heap_pair_heaps'
        'samples/heap_pair_mix'
        'samples/heap_slot'
        'samples/heap_text'
        'samples/heap_text_eq'
        'samples/heap_text_pair'
        'samples/heap_texts'
        'samples/heap_texts_flag'
        'samples/heap_triple'
        'samples/heap_triple_heaps'
        'samples/heap_u16_text'
        'samples/heap_u32_flag'
        'samples/heap_u32_text'
        'samples/heap_u64_text'
        'samples/heap_u8_text'
        'samples/heap_union'
        'samples/heap_union_heap_pair_heaps'
        'samples/heap_union_heap_union_heap_pair_heaps'
        'samples/heap_union_pair_heaps'
        'samples/heap_union_triple_heaps'
        'samples/heap_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/i64_scalar'
        'samples/item_metadata_missing_target'
        'samples/lua_while_union_pair'
        'samples/lua_wide_integers'
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
        'samples/match_multiline_scrutinee'
        'samples/mega_brzozowski_derivatives/inventory_closed_dfa_runtime'
        'samples/mega_brzozowski_derivatives/runtime_native'
        'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
        'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
        'samples/mega_zeta_structural_laboratory/runtime_native'
        'samples/method_array'
        'samples/method_depth'
        'samples/method_heap'
        'samples/method_i8'
        'samples/method_mut'
        'samples/method_mut_pair'
        'samples/method_pair_cell'
        'samples/method_pair_fun'
        'samples/method_pair_heap'
        'samples/method_pair_mix'
        'samples/method_pair_slot'
        'samples/method_pair_text'
        'samples/method_pair_union'
        'samples/method_pair_union_heap'
        'samples/method_return'
        'samples/method_text'
        'samples/method_text_pair'
        'samples/method_union'
        'samples/method_union_mix'
        'samples/multiline_comment'
        'samples/multiline_triple_string'
        'samples/multiline_type_application_dropped'
        'samples/mut_f32_text'
        'samples/mut_heap_heap'
        'samples/mut_heap_heap_heap'
        'samples/mut_heap_heap_pair'
        'samples/mut_heap_union_heap_pair_heaps'
        'samples/mut_heap_union_heap_union_heap_pair_heaps'
        'samples/mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/mut_i64_text'
        'samples/mut_pair'
        'samples/mut_pair_heaps'
        'samples/mut_text'
        'samples/mut_text_pair'
        'samples/mut_triple_heaps'
        'samples/mut_u32_text'
        'samples/mutable_alias_method_branch'
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
        'samples/native_closure_multimodule'
        'samples/native_closure_multiowner'
        'samples/native_closure_nested_branch'
        'samples/native_closure_recursive_capture'
        'samples/native_closure_return'
        'samples/native_closure_reuse'
        'samples/native_closure_transitive_package'
        'samples/native_closure_transport'
        'samples/native_closure_union_capture_method'
        'samples/native_closure_union_rec'
        'samples/native_cube_direct'
        'samples/native_layout_heap'
        'samples/native_layout_mutable'
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
        'samples/native_package_prototype_record_callback'
        'samples/native_prototype_record_callback'
        'samples/native_prototype_union_closure_method'
        'samples/native_recursive_tail_recursion'
        'samples/native_replay_repeat_call'
        'samples/native_source_package_prototype_record_callback'
        'samples/native_source_package_prototype_union_callback'
        'samples/native_source_package_prototype_union_callback_managed_single_owner'
        'samples/native_source_package_prototype_union_callback_managed_two_cases'
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
        'samples/native_tail_recursion'
        'samples/nested_tuple'
        'samples/nominal_phantom_parameter'
        'samples/nominal_record_field_order'
        'samples/nominal_union_case_pattern'
        'samples/op_args_application'
        'samples/op_args_deref_if'
        'samples/portable_composite'
        'samples/portable_console_lines'
        'samples/predicate_call'
        'samples/printf_portable'
        'samples/python_macro_annotations'
        'samples/python_self_tail_call_depth'
        'samples/qualified_union_case_no_payload'
        'samples/qualified_union_case_pattern'
        'samples/record_value'
        'samples/recur_sum'
        'samples/recursive_union_list'
        'samples/recursive_union_managed'
        'samples/recursive_union_multi_case'
        'samples/recursive_union_mutual'
        'samples/recursive_union_terminal_ownership'
        'samples/recursive_union_tree_shared'
        'samples/rust_box_dyn_moves'
        'samples/rust_consuming_json'
        'samples/rust_emit_expr_macro'
        'samples/rust_emit_tuple_args'
        'samples/rust_global_item_macro'
        'samples/rust_macro_reuse_clone'
        'samples/rust_near_store_moves'
        'samples/rust_string_literal_path'
        'samples/rust_target_globals'
        'samples/rust_union_non_clone_payload'
        'samples/small_int_ops'
        'samples/small_int_scalar'
        'samples/static_string'
        'samples/string_eq'
        'samples/string_ord'
        'samples/string_utf8'
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
        'samples/ts_layout_heap'
        'samples/ts_layout_mutable'
        'samples/ts_string_concat'
        'samples/ts_string_slice'
        'samples/ts_tail_loop'
        'samples/ts_tuple_mixed'
        'samples/ts_union_recursive'
        'samples/ts_union_scalar'
        'samples/tuple_mixed'
        'samples/tuple_pair'
        'samples/typecheck_long_let_body'
        'samples/union_array'
        'samples/union_array_mix'
        'samples/union_bool'
        'samples/union_call'
        'samples/union_case_record_field_order'
        'samples/union_cell_mix'
        'samples/union_f32_text'
        'samples/union_fun_mix'
        'samples/union_heap'
        'samples/union_heap_heap'
        'samples/union_heap_heap_heap'
        'samples/union_heap_pair_heaps'
        'samples/union_heap_union_heap_pair_heaps'
        'samples/union_i64_text'
        'samples/union_i8'
        'samples/union_i8_text'
        'samples/union_mut'
        'samples/union_nested'
        'samples/union_option'
        'samples/union_pair'
        'samples/union_pair_heaps'
        'samples/union_pair_mix'
        'samples/union_text'
        'samples/union_text_pair'
        'samples/union_texts'
        'samples/union_texts_flag'
        'samples/union_triple_heaps'
        'samples/union_triple_mix'
        'samples/union_u32_flag'
        'samples/union_u32_text'
        'samples/union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/union3_heap_union_heap_union_heap_pair_heaps'
        'samples/unsigned_mod'
        'samples/upstream_type_if'
        'samples/wgsl_array_scalar'
        'samples/wgsl_array_tuple'
        'samples/wgsl_gadt_payload_union'
        'samples/wgsl_nullary_union'
        'samples/wgsl_payload_union'
        'samples/wgsl_record_loop'
        'samples/wgsl_tail_call_in_match'
        'samples/wgsl_unit_self_loop'
        'samples/native_float_math_f32'
    )
    Lean = @(
        'samples/frontier_gadt_growing_index'
        'samples/macro_splice_before_quote'
        'samples/zig_exit_wide'
        'samples/native_string_utf8_canonical_equal_bounded_source'
        'samples/gleam_match_narrowed'
        'samples/gleam_match_single_case'
        'samples/portable_console_lines'
        'samples/portable_math_rounding'
        'samples/arithmetic_branch'
        'samples/backend_smoke'
        'samples/branch_select'
        'samples/dynamic_array_bool'
        'samples/dynamic_array_bounds_negative'
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
        'samples/op_args_deref_if'
        'samples/portable_composite'
        'samples/predicate_call'
        'samples/printf_portable'
        'samples/python_self_tail_call_depth'
        'samples/record_value'
        'samples/recursive_union_list'
        'samples/recursive_union_managed'
        'samples/recursive_union_mutual'
        'samples/recursive_union_terminal_ownership'
        'samples/recursive_union_tree_shared'
        'samples/rust_emit_expr_macro'
        'samples/rust_global_item_macro'
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
        'samples/while_control'
        'samples/while_loop'
        'samples/array_bool', 'samples/array_cell', 'samples/array_closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/array_create_reads_zero', 'samples/array_f32', 'samples/array_f64', 'samples/array_fun', 'samples/array_heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/array_heap_f32', 'samples/array_heap_heap', 'samples/array_heap_heap_heap', 'samples/array_heap_heap_pair', 'samples/array_heap_mix', 'samples/array_heap_pair_heaps', 'samples/array_heap_triple_heaps', 'samples/array_heap_union_heap_pair_heaps', 'samples/array_heap_union_heap_union_heap_pair_heaps', 'samples/array_i16', 'samples/array_i32', 'samples/array_i64', 'samples/array_i64_at1', 'samples/array_i8', 'samples/array_mut', 'samples/array_mut_f32', 'samples/array_mut_heap_heap', 'samples/array_mut_heap_heap_pair', 'samples/array_mut_heap_union_heap_pair_heaps', 'samples/array_mut_heap_union_heap_union_heap_pair_heaps', 'samples/array_mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/array_mut_pair', 'samples/array_mut_pair_heaps', 'samples/array_mut_triple_heaps', 'samples/array_text', 'samples/array_text_at1', 'samples/array_u16', 'samples/array_u32', 'samples/array_u64', 'samples/array_u8', 'samples/array_union', 'samples/array_union_heap_heap', 'samples/array_union_heap_pair_heaps', 'samples/array_union_heap_union_heap_pair_heaps', 'samples/array_union_pair_heaps', 'samples/array_union_text', 'samples/array_union_triple_heaps', 'samples/c_gadt_union_array', 'samples/closure_apply', 'samples/closure_array', 'samples/closure_curry', 'samples/closure_depth', 'samples/closure_f32_heap', 'samples/closure_heap', 'samples/closure_heap_heap', 'samples/closure_heap_heap_heap', 'samples/closure_heap_pair_heaps', 'samples/closure_heap_union_heap_pair_heaps', 'samples/closure_heap_union_heap_union_heap_pair_heaps', 'samples/closure_heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/closure_mut', 'samples/closure_mut_pair', 'samples/closure_pair', 'samples/closure_pair_array', 'samples/closure_pair_bool', 'samples/closure_pair_cell', 'samples/closure_pair_f32', 'samples/closure_pair_f64', 'samples/closure_pair_fun', 'samples/closure_pair_heap', 'samples/closure_pair_heaps', 'samples/closure_pair_i64', 'samples/closure_pair_i8', 'samples/closure_pair_mix', 'samples/closure_pair_slot', 'samples/closure_pair_text', 'samples/closure_pair_union', 'samples/closure_pair_union_heap', 'samples/closure_real', 'samples/closure_return', 'samples/closure_return_heap', 'samples/closure_return_text', 'samples/closure_text', 'samples/closure_text_pair', 'samples/closure_triple', 'samples/closure_triple_heaps', 'samples/closure_u32_flag', 'samples/closure_union', 'samples/closure_union_heap_heap', 'samples/closure_union_heap_pair_heaps', 'samples/closure_union_heap_union_heap_pair_heaps', 'samples/closure_union_mix', 'samples/closure_union_pair_heaps', 'samples/closure_union_triple_heaps', 'samples/closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/closure_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/ebpf_arith', 'samples/ebpf_bacc', 'samples/ebpf_bits', 'samples/ebpf_bool', 'samples/ebpf_char', 'samples/ebpf_conv', 'samples/ebpf_div', 'samples/ebpf_facc', 'samples/ebpf_fdiv', 'samples/ebpf_float', 'samples/ebpf_flt', 'samples/ebpf_ineq', 'samples/ebpf_neq', 'samples/ebpf_nest3', 'samples/ebpf_sh31', 'samples/ebpf_shift', 'samples/ebpf_snot', 'samples/ebpf_t2', 'samples/ebpf_t3', 'samples/ebpf_tacc', 'samples/ebpf_tworec', 'samples/ebpf_uacc', 'samples/ebpf_uadd', 'samples/ebpf_umul', 'samples/failwith_exit', 'samples/heap_bool', 'samples/heap_bool_text', 'samples/heap_closure', 'samples/heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/heap_f32_n', 'samples/heap_f32_text', 'samples/heap_f32_u32', 'samples/heap_fun', 'samples/heap_heap', 'samples/heap_heap_heap', 'samples/heap_heap_pair_heaps', 'samples/heap_i16_text', 'samples/heap_i64_real', 'samples/heap_i64_text', 'samples/heap_i8', 'samples/heap_i8_text', 'samples/heap_nest', 'samples/heap_pair', 'samples/heap_pair_heaps', 'samples/heap_pair_mix', 'samples/heap_real', 'samples/heap_real_text', 'samples/heap_slot', 'samples/heap_text', 'samples/heap_text_eq', 'samples/heap_text_pair', 'samples/heap_triple', 'samples/heap_triple_heaps', 'samples/heap_u16_text', 'samples/heap_u32_flag', 'samples/heap_u32_text', 'samples/heap_u64_text', 'samples/heap_u8_text', 'samples/heap_union', 'samples/heap_union_heap_pair_heaps', 'samples/heap_union_heap_union_heap_pair_heaps', 'samples/heap_union_pair_heaps', 'samples/heap_union_triple_heaps', 'samples/heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/i64_scalar', 'samples/lua_wide_integers', 'samples/match_multiline_scrutinee', 'samples/method_array', 'samples/method_depth', 'samples/method_heap', 'samples/method_i8', 'samples/method_mut', 'samples/method_mut_pair', 'samples/method_pair_cell', 'samples/method_pair_f64', 'samples/method_pair_fun', 'samples/method_pair_heap', 'samples/method_pair_mix', 'samples/method_pair_slot', 'samples/method_pair_text', 'samples/method_pair_union', 'samples/method_pair_union_heap', 'samples/method_real', 'samples/method_return', 'samples/method_text', 'samples/method_text_pair', 'samples/method_union', 'samples/method_union_mix', 'samples/multiline_type_application_dropped', 'samples/mut_f32_text', 'samples/mut_heap_heap', 'samples/mut_heap_heap_heap', 'samples/mut_heap_heap_pair', 'samples/mut_heap_union_heap_pair_heaps', 'samples/mut_heap_union_heap_union_heap_pair_heaps', 'samples/mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/mut_i64_text', 'samples/mut_pair', 'samples/mut_pair_heaps', 'samples/mut_real_text', 'samples/mut_text', 'samples/mut_text_pair', 'samples/mut_triple_heaps', 'samples/mut_u32_text', 'samples/mutable_alias_method_branch', 'samples/native_closure_diamond_package', 'samples/native_closure_external_package', 'samples/native_closure_transitive_package', 'samples/native_layout_heap', 'samples/native_layout_mutable', 'samples/native_package_prototype_record_callback', 'samples/native_replay_repeat_call', 'samples/native_source_package_prototype_record_callback', 'samples/native_source_package_prototype_union_callback', 'samples/native_source_package_prototype_union_callback_managed_single_owner', 'samples/native_source_package_prototype_union_callback_managed_two_cases', 'samples/native_string_utf8_fold_source', 'samples/native_string_utf8_fold_source_invalid', 'samples/native_string_utf8_grapheme_bounded_source', 'samples/native_string_utf8_grapheme_bounded_source_invalid', 'samples/native_string_utf8_normalization_bounded_source', 'samples/native_string_utf8_scalar_source', 'samples/native_string_utf8_scalar_source_invalid', 'samples/native_string_utf8_validate_source', 'samples/native_string_utf8_validate_source_invalid', 'samples/nominal_phantom_parameter', 'samples/nominal_record_field_order', 'samples/package_default_int_i64', 'samples/qualified_union_case_pattern', 'samples/recur_sum', 'samples/recursive_union_multi_case', 'samples/small_int_ops', 'samples/small_int_scalar', 'samples/string_eq', 'samples/string_ord', 'samples/string_utf8', 'samples/ts_layout_heap', 'samples/ts_layout_mutable', 'samples/union_array', 'samples/union_array_mix', 'samples/union_bool', 'samples/union_call', 'samples/union_case_record_field_order', 'samples/union_cell_mix', 'samples/union_f32_text', 'samples/union_f64s', 'samples/union_fun_mix', 'samples/union_heap', 'samples/union_heap_heap', 'samples/union_heap_heap_heap', 'samples/union_heap_pair_heaps', 'samples/union_heap_union_heap_pair_heaps', 'samples/union_i64_text', 'samples/union_i8', 'samples/union_i8_text', 'samples/union_nested', 'samples/union_option', 'samples/union_pair', 'samples/union_pair_heaps', 'samples/union_pair_mix', 'samples/union_real', 'samples/union_real_mix', 'samples/union_text', 'samples/union_text_pair', 'samples/union_texts', 'samples/union_texts_flag', 'samples/union_triple_heaps', 'samples/union_triple_mix', 'samples/union_u32_flag', 'samples/union_u32_text', 'samples/union3_all_heap_union_heap_union_heap_pair_heaps', 'samples/union3_both_heap_union_heap_union_heap_pair_heaps', 'samples/union3_heap_union_heap_union_heap_pair_heaps', 'samples/upstream_type_if', 'samples/wgsl_array_scalar', 'samples/wgsl_array_tuple', 'samples/wgsl_gadt_payload_union', 'samples/wgsl_nullary_union', 'samples/wgsl_payload_union', 'samples/wgsl_record_loop', 'samples/wgsl_tail_call_in_match', 'samples/wgsl_unit_self_loop'
        'samples/array_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/array2_heap_union_heap_union_heap_pair_heaps'
        'samples/array3_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/frontier_format_any_union'
        'samples/frontier_hopacsota_mutual_pending'
        'samples/frontier_hopacsota_recursion_inferred'
        'samples/frontier_join_format_any'
        'samples/gadt_lazy_payload'
        'samples/gadt_match_loses_constraint'
        'samples/heap_array'
        'samples/heap_array_f32'
        'samples/heap_array_n'
        'samples/heap_f64s'
        'samples/heap_texts'
        'samples/heap_texts_flag'
        'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
        'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
        'samples/mega_zeta_structural_laboratory/runtime_native'
        'samples/native_cube_frame_direct'
        'samples/ebpf_cast'
        'samples/f64_scalar'
        'samples/heap_mut_cell'
        'samples/mega_brzozowski_derivatives/indexed_dfa_state_cardinality'
        'samples/mega_brzozowski_derivatives/inventory_closed_dfa_runtime'
        'samples/mega_brzozowski_derivatives/runtime_native'
        'samples/native_cube_multiframe_direct'
        'samples/native_cube_paced_stream_direct'
        'samples/native_cube_terminal_stream_direct'
        'samples/union_mut'
        'samples/portable_convert_parse'
        'samples/c_deep_list_decref'
        'samples/c_self_tail_loop_heap'
        'samples/native_cube_frame_reuse_direct'
        'samples/native_float_nan_is'
        'samples/qualified_union_case_no_payload'
        'samples/ts_float_nan'
        'samples/ts_while_loop'
        'samples/typecheck_long_let_body'
        'samples/wgsl_parallel_lanes'
        'samples/native_closure_union_rec'
        'samples/rust_static_closure_chain'
    )
    Wasm = @(
        'samples/frontier_gadt_growing_index'
        'samples/zig_exit_wide'
            'samples/portable_math_rounding'
        'samples/array_bool',
        'samples/array_cell',
        'samples/array_closure_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/array_create_reads_zero',
        'samples/array_f32',
        'samples/array_f64',
        'samples/array_fun',
        'samples/array_heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/array_heap_f32',
        'samples/array_heap_heap',
        'samples/array_heap_heap_heap',
        'samples/array_heap_heap_pair',
        'samples/array_heap_mix',
        'samples/array_heap_pair_heaps',
        'samples/array_heap_triple_heaps',
        'samples/array_heap_union_heap_union_heap_pair_heaps',
        'samples/array_i16',
        'samples/array_i32',
        'samples/array_i64',
        'samples/array_i8',
        'samples/array_mut_f32',
        'samples/array_mut_heap_heap',
        'samples/array_mut_heap_union_heap_pair_heaps',
        'samples/array_mut_heap_union_heap_union_heap_pair_heaps',
        'samples/array_mut_pair',
        'samples/array_text',
        'samples/array_text_at1',
        'samples/array_u16',
        'samples/array_u8',
        'samples/array_union',
        'samples/array_union_heap_heap',
        'samples/array_union_heap_pair_heaps',
        'samples/array_union_heap_union_heap_pair_heaps',
        'samples/array_union_pair_heaps',
        'samples/array_union_text',
        'samples/array_union_triple_heaps',
        'samples/array3_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/c_gadt_union_array',
        'samples/c_self_tail_loop_heap',
        'samples/closure_array',
        'samples/closure_curry',
        'samples/closure_depth',
        'samples/closure_heap',
        'samples/closure_heap_heap',
        'samples/closure_heap_pair_heaps',
        'samples/closure_heap_union_heap_union_heap_pair_heaps',
        'samples/closure_mut_pair',
        'samples/closure_pair',
        'samples/closure_pair_array',
        'samples/closure_pair_cell',
        'samples/closure_pair_f32',
        'samples/closure_pair_f64',
        'samples/closure_pair_heap',
        'samples/closure_pair_heaps',
        'samples/closure_pair_i64',
        'samples/closure_pair_mix',
        'samples/closure_pair_text',
        'samples/closure_pair_union',
        'samples/closure_pair_union_heap',
        'samples/closure_real',
        'samples/closure_return',
        'samples/closure_return_heap',
        'samples/closure_return_text',
        'samples/closure_text',
        'samples/closure_text_pair',
        'samples/closure_triple',
        'samples/closure_triple_heaps',
        'samples/closure_u32_flag',
        'samples/closure_union',
        'samples/closure_union_heap_heap',
        'samples/closure_union_heap_pair_heaps',
        'samples/closure_union_heap_union_heap_pair_heaps',
        'samples/closure_union_mix',
        'samples/closure_union_triple_heaps',
        'samples/closure_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/closure_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/ebpf_bacc',
        'samples/ebpf_bits',
        'samples/ebpf_bool',
        'samples/ebpf_char',
        'samples/ebpf_conv',
        'samples/ebpf_div',
        'samples/ebpf_facc',
        'samples/ebpf_fdiv',
        'samples/ebpf_flt',
        'samples/ebpf_ineq',
        'samples/ebpf_neq',
        'samples/ebpf_nest3',
        'samples/ebpf_sh31',
        'samples/ebpf_shift',
        'samples/ebpf_snot',
        'samples/ebpf_t2',
        'samples/ebpf_t3',
        'samples/ebpf_tacc',
        'samples/ebpf_tworec',
        'samples/ebpf_uacc',
        'samples/ebpf_uadd',
        'samples/ebpf_umul',
        'samples/f64_scalar',
        'samples/failwith_exit',
        'samples/gadt_lazy_payload',
        'samples/gadt_match_loses_constraint',
        'samples/heap_array',
        'samples/heap_array_f32',
        'samples/heap_array_n',
        'samples/heap_bool_text',
        'samples/heap_closure',
        'samples/heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/heap_f32_n',
        'samples/heap_f32_text',
        'samples/heap_f32_u32',
        'samples/heap_f64s',
        'samples/heap_fun',
        'samples/heap_heap',
        'samples/heap_heap_heap',
        'samples/heap_heap_pair_heaps',
        'samples/heap_i16_text',
        'samples/heap_i64_real',
        'samples/heap_i64_text',
        'samples/heap_i8',
        'samples/heap_i8_text',
        'samples/heap_mut_cell',
        'samples/heap_nest',
        'samples/heap_pair',
        'samples/heap_pair_heaps',
        'samples/heap_pair_mix',
        'samples/heap_real',
        'samples/heap_real_text',
        'samples/heap_slot',
        'samples/heap_text',
        'samples/heap_text_eq',
        'samples/heap_text_pair',
        'samples/heap_texts',
        'samples/heap_texts_flag',
        'samples/heap_triple',
        'samples/heap_triple_heaps',
        'samples/heap_u16_text',
        'samples/heap_u32_flag',
        'samples/heap_u32_text',
        'samples/heap_u8_text',
        'samples/heap_union',
        'samples/heap_union_heap_pair_heaps',
        'samples/heap_union_heap_union_heap_pair_heaps',
        'samples/heap_union_pair_heaps',
        'samples/heap_union_triple_heaps',
        'samples/heap_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/i64_scalar',
        'samples/lua_wide_integers',
        'samples/match_multiline_scrutinee',
        'samples/method_array',
        'samples/method_depth',
        'samples/method_heap',
        'samples/method_i8',
        'samples/method_mut',
        'samples/method_mut_pair',
        'samples/method_pair_cell',
        'samples/method_pair_f64',
        'samples/method_pair_fun',
        'samples/method_pair_heap',
        'samples/method_pair_mix',
        'samples/method_pair_slot',
        'samples/method_pair_text',
        'samples/method_pair_union',
        'samples/method_pair_union_heap',
        'samples/method_real',
        'samples/method_return',
        'samples/method_text',
        'samples/method_text_pair',
        'samples/method_union',
        'samples/method_union_mix',
        'samples/multiline_type_application_dropped',
        'samples/mut_f32_text',
        'samples/mut_heap_heap',
        'samples/mut_heap_heap_heap',
        'samples/mut_heap_heap_pair',
        'samples/mut_heap_union_heap_pair_heaps',
        'samples/mut_heap_union_heap_union_heap_pair_heaps',
        'samples/mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/mut_i64_text',
        'samples/mut_pair',
        'samples/mut_pair_heaps',
        'samples/mut_text',
        'samples/mut_text_pair',
        'samples/mut_triple_heaps',
        'samples/mut_u32_text',
        'samples/native_closure_diamond_package',
        'samples/native_closure_external_package',
        'samples/native_closure_transitive_package',
        'samples/native_package_prototype_record_callback',
        'samples/native_source_package_prototype_record_callback',
        'samples/native_source_package_prototype_union_callback',
        'samples/native_source_package_prototype_union_callback_managed_single_owner',
        'samples/native_source_package_prototype_union_callback_managed_two_cases',
        'samples/nominal_phantom_parameter',
        'samples/nominal_record_field_order',
        'samples/recur_sum',
        'samples/small_int_ops',
        'samples/small_int_scalar',
        'samples/string_eq',
        'samples/string_utf8',
        'samples/typecheck_long_let_body',
        'samples/union_array',
        'samples/union_bool',
        'samples/union_call',
        'samples/union_case_record_field_order',
        'samples/union_cell_mix',
        'samples/union_f32_text',
        'samples/union_f64s',
        'samples/union_fun_mix',
        'samples/union_heap',
        'samples/union_heap_heap',
        'samples/union_heap_heap_heap',
        'samples/union_heap_pair_heaps',
        'samples/union_heap_union_heap_pair_heaps',
        'samples/union_i64_text',
        'samples/union_i8',
        'samples/union_i8_text',
        'samples/union_mut',
        'samples/union_nested',
        'samples/union_option',
        'samples/union_pair',
        'samples/union_pair_heaps',
        'samples/union_pair_mix',
        'samples/union_real',
        'samples/union_real_mix',
        'samples/union_text',
        'samples/union_text_pair',
        'samples/union_texts',
        'samples/union_texts_flag',
        'samples/union_triple_heaps',
        'samples/union_triple_mix',
        'samples/union_u32_flag',
        'samples/union_u32_text',
        'samples/union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/union3_heap_union_heap_union_heap_pair_heaps',
        'samples/upstream_type_if',
        'samples/wgsl_array_scalar',
        'samples/wgsl_array_tuple',
        'samples/wgsl_gadt_payload_union',
        'samples/wgsl_nullary_union',
        'samples/wgsl_payload_union',
        'samples/wgsl_unit_self_loop'
            'samples/native_float_pow_pi'
            'samples/native_float_math_family'
            'samples/portable_convert_parse'
            'samples/arithmetic_branch'
            'samples/backend_smoke'
            'samples/branch_select'
            'samples/dynamic_array_bool'
            'samples/dynamic_array_bounds_negative'
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
            'samples/fixed_array_runtime_index'
            'samples/fixed_array_runtime_update'
            'samples/fixed_array_scalar'
            'samples/float_math'
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
            'samples/mega_brzozowski_derivatives/indexed_dfa_state_cardinality'
            'samples/mega_brzozowski_derivatives/inventory_closed_dfa_runtime'
            'samples/mega_brzozowski_derivatives/runtime_bench'
            'samples/mega_brzozowski_derivatives/runtime_native'
            'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
            'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
            'samples/mega_zeta_structural_laboratory/runtime_native'
            'samples/multiline_comment'
            'samples/multiline_triple_string'
            'samples/mutable_alias_method_branch'
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
            'samples/native_float_sqrt'
            'samples/native_layout_heap'
            'samples/native_layout_mutable'
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
            'samples/op_args_deref_if'
            'samples/portable_composite'
            'samples/portable_console_lines'
            'samples/predicate_call'
            'samples/printf_portable'
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
            'samples/string_ord'
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
            'samples/ts_layout_heap'
            'samples/ts_layout_mutable'
            'samples/ts_string_concat'
            'samples/ts_string_slice'
            'samples/ts_tail_loop'
            'samples/ts_tuple_mixed'
            'samples/ts_union_recursive'
            'samples/ts_union_scalar'
            'samples/tuple_mixed'
            'samples/tuple_pair'
            'samples/unsigned_mod'
            'samples/zig_lib_console'
        'samples/gleam_match_narrowed'
        'samples/gleam_match_single_case'
        'samples/array_heap_union_heap_pair_heaps'
        'samples/array_i64_at1'
        'samples/array_mut'
        'samples/array_mut_heap_heap_pair'
        'samples/array_mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/array_mut_pair_heaps'
        'samples/array_mut_triple_heaps'
        'samples/array_u32'
        'samples/array_u64'
        'samples/array_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/array2_heap_union_heap_union_heap_pair_heaps'
        'samples/c_deep_list_decref'
        'samples/closure_apply'
        'samples/closure_f32_heap'
        'samples/closure_heap_heap_heap'
        'samples/closure_heap_union_heap_pair_heaps'
        'samples/closure_heap_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/closure_mut'
        'samples/closure_pair_bool'
        'samples/closure_pair_fun'
        'samples/closure_pair_i8'
        'samples/closure_pair_slot'
        'samples/closure_union_pair_heaps'
        'samples/ebpf_arith'
        'samples/ebpf_cast'
        'samples/ebpf_float'
        'samples/frontier_hopacsota_mutual_pending'
        'samples/frontier_hopacsota_recursion_inferred'
        'samples/heap_bool'
        'samples/heap_u64_text'
        'samples/mut_real_text'
        'samples/native_replay_repeat_call'
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
        'samples/package_default_int_i64'
        'samples/qualified_union_case_pattern'
        'samples/recursive_union_multi_case'
        'samples/union_array_mix'
        'samples/wgsl_record_loop'
        'samples/wgsl_tail_call_in_match'
        'samples/qualified_union_case_no_payload'
    )
    Wgsl = @(
        'samples/i64_scalar'
        'samples/array_i64'
        'samples/array_i64_at1'
        'samples/array_u64'
        'samples/ts_int_wrap'
        'samples/small_int_scalar'
        'samples/small_int_ops'
        'samples/array_i8'
        'samples/union_i8'
        'samples/method_i8'
        'samples/array_u8'
        'samples/array_i16'
        'samples/array_u16'
        'samples/backend_smoke'
        'samples/arithmetic_branch'
        'samples/branch_select'
        'samples/function_call'
        'samples/tail_loop'
        'samples/predicate_call'
        'samples/unsigned_mod'
        'samples/float_math'
        'samples/native_bitwise_scalar'
        'samples/native_tail_recursion'
        'samples/expression_precedence'
        'samples/while_loop'
        'samples/while_control'
        'samples/ts_while_loop'
        'samples/ts_tail_loop'
        'samples/python_self_tail_call_depth'
        'samples/tuple_pair'
        'samples/tuple_mixed'
        'samples/nested_tuple'
        'samples/ts_tuple_mixed'
        'samples/wgsl_nullary_union'
        'samples/wgsl_payload_union'
        'samples/wgsl_gadt_payload_union'
        'samples/wgsl_record_loop'
        'samples/gleam_match_single_case'
        'samples/gleam_match_narrowed'
        'samples/wgsl_array_scalar'
        'samples/fixed_array_scalar'
        'samples/fixed_array_runtime_index'
        'samples/fixed_array_runtime_update'
        'samples/array_union'
        'samples/wgsl_array_tuple'
        'samples/wgsl_unit_self_loop'
        'samples/array_i32'
        'samples/array_u32'
        'samples/ts_union_scalar'
        'samples/union_option'
        'samples/union_bool'
        'samples/union_nested'
        'samples/union_pair'
        'samples/method_union'
        'samples/union_array'
        'samples/method_array'
        'samples/array_bool'
        'samples/method_pair_union'
        'samples/method_pair_slot'
        'samples/union_array_mix'
        'samples/array_f32'
        'samples/wgsl_tail_call_in_match'
        'samples/wgsl_parallel_lanes'
        'samples/match_multiline_scrutinee'
        'samples/nominal_union_case_pattern'
        'samples/op_args_application'
        'samples/tagged_union_enum'
        'samples/union_case_record_field_order'
        'samples/qualified_union_case_no_payload'
        'samples/qualified_union_case_pattern'
        'samples/tagged_union_heterogeneous'
        'samples/tagged_union_scalar'
        'samples/tagged_union_three_case'
        'samples/ebpf_arith'
        'samples/ebpf_bacc'
        'samples/ebpf_bits'
        'samples/ebpf_bool'
        'samples/ebpf_cast'
        'samples/ebpf_char'
        'samples/ebpf_conv'
        'samples/ebpf_div'
        'samples/ebpf_facc'
        'samples/ebpf_fdiv'
        'samples/ebpf_float'
        'samples/ebpf_flt'
        'samples/ebpf_ineq'
        'samples/ebpf_neq'
        'samples/ebpf_nest3'
        'samples/ebpf_sh31'
        'samples/ebpf_shift'
        'samples/ebpf_snot'
        'samples/ebpf_t2'
        'samples/ebpf_t3'
        'samples/ebpf_tacc'
        'samples/ebpf_tworec'
        'samples/ebpf_uacc'
        'samples/ebpf_uadd'
        'samples/ebpf_umul'
        'samples/array_create_reads_zero'
        'samples/c_gadt_union_array'
        'samples/c_self_tail_loop_heap'
        'samples/dynamic_array_bool'
        'samples/dynamic_array_bounds_negative'
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
        'samples/folder_index_module'
        'samples/frontier_gadt_growing_index'
        'samples/frontier_hello'
        'samples/frontier_hopacsota_recursion_inferred'
        'samples/frontier_macro_then_multiline_annotation'
        'samples/frontier_static_list_eq'
        'samples/frontier_try_item'
        'samples/gadt_lazy_payload'
        'samples/gadt_match_loses_constraint'
        'samples/macro_splice_before_quote'
        'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
        'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
        'samples/mega_zeta_structural_laboratory/runtime_native'
        'samples/multiline_comment'
        'samples/multiline_type_application_dropped'
        'samples/native_cube_direct'
        'samples/native_managed_array_tail_recursion'
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
        'samples/nominal_phantom_parameter'
        'samples/nominal_record_field_order'
        'samples/record_value'
        'samples/rust_emit_expr_macro'
        'samples/rust_global_item_macro'
        'samples/ts_array_union'
        'samples/typecheck_long_let_body'
        'samples/upstream_type_if'
        'samples/zig_exit_wide'
    )
    Calyx = @(
        'samples/backend_smoke'
        'samples/arithmetic_branch'
        'samples/branch_select'
        'samples/function_call'
        'samples/predicate_call'
        'samples/native_bitwise_scalar'
        'samples/tail_loop'
        'samples/python_self_tail_call_depth'
        'samples/unsigned_mod'
        'samples/ts_tail_loop'
        'samples/ebpf_shift'
        'samples/ebpf_bool'
        'samples/ebpf_bits'
        'samples/ebpf_umul'
        'samples/ebpf_uacc'
        'samples/ebpf_bacc'
        'samples/ebpf_char'
        'samples/ebpf_sh31'
        'samples/ebpf_uadd'
        'samples/ebpf_tworec'
        'samples/ebpf_snot'
        'samples/ebpf_arith'
        'samples/ebpf_div'
        'samples/tuple_pair'
        'samples/nested_tuple'
        'samples/ebpf_tacc'
        'samples/ebpf_t2'
        'samples/ebpf_t3'
        'samples/frontier_gadt_growing_index'
        'samples/frontier_hello'
        'samples/frontier_hopacsota_recursion_inferred'
        'samples/frontier_macro_then_multiline_annotation'
        'samples/frontier_static_list_eq'
        'samples/frontier_try_item'
        'samples/gadt_lazy_payload'
        'samples/gadt_match_loses_constraint'
        'samples/match_multiline_scrutinee'
        'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
        'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
        'samples/mega_zeta_structural_laboratory/runtime_native'
        'samples/method_i8'
        'samples/multiline_comment'
        'samples/multiline_type_application_dropped'
        'samples/native_cube_direct'
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
        'samples/nominal_phantom_parameter'
        'samples/nominal_record_field_order'
        'samples/op_args_application'
        'samples/qualified_union_case_pattern'
        'samples/rust_emit_expr_macro'
        'samples/rust_global_item_macro'
        'samples/typecheck_long_let_body'
        'samples/union_case_record_field_order'
        'samples/upstream_type_if'
        'samples/zig_exit_wide'
        'samples/i64_scalar'
        'samples/ts_int_wrap'
        'samples/small_int_ops'
        'samples/small_int_scalar'
        'samples/package_default_int_i64'
    )
    Kotlin = @(
        'samples/frontier_format_any_union'
        'samples/frontier_join_format_any'
        'samples/frontier_hopacsota_globals_order'
        'samples/frontier_gadt_growing_index'
        'samples/frontier_hopacsota_mutual_pending'
        'samples/frontier_hopacsota_recursion_inferred'
        'samples/macro_splice_before_quote'
        'samples/zig_exit_wide'
        'samples/backend_smoke'
        'samples/arithmetic_branch'
        'samples/branch_select'
        'samples/function_call'
        'samples/gleam_match_narrowed'
        'samples/gleam_match_single_case'
        'samples/predicate_call'
        'samples/native_bitwise_scalar'
        'samples/tail_loop'
        'samples/python_self_tail_call_depth'
        'samples/unsigned_mod'
        'samples/float_math'
        'samples/tuple_pair'
        'samples/tuple_mixed'
        'samples/nested_tuple'
        'samples/ts_tuple_mixed'
        'samples/expression_precedence'
        'samples/native_tail_recursion'
        'samples/while_loop'
        'samples/while_control'
        'samples/ts_while_loop'
        'samples/ts_tail_loop'
        'samples/f64_scalar'
        'samples/i64_scalar'
        'samples/small_int_scalar'
        'samples/small_int_ops'
        'samples/failwith_exit'
        'samples/string_utf8'
        'samples/string_eq'
        'samples/string_ord'
        'samples/array_i32'
        'samples/array_u32'
        'samples/ts_union_scalar'
        'samples/union_option'
        'samples/union_bool'
        'samples/union_nested'
        'samples/union_pair'
        'samples/union_text'
        'samples/union_real'
        'samples/native_closure_capture'
        'samples/closure_apply'
        'samples/closure_curry'
        'samples/recur_sum'
        'samples/native_layout_heap'
        'samples/native_layout_mutable'
        'samples/mutable_alias_method_branch'
        'samples/heap_text'
        'samples/heap_nest'
        'samples/heap_closure'
        'samples/union_call'
        'samples/array_cell'
        'samples/closure_pair'
        'samples/union_heap'
        'samples/heap_union'
        'samples/closure_union'
        'samples/array_union'
        'samples/method_union'
        'samples/array_text'
        'samples/heap_array'
        'samples/union_array'
        'samples/array_fun'
        'samples/array_f64'
        'samples/closure_text'
        'samples/method_text'
        'samples/method_array'
        'samples/method_heap'
        'samples/closure_heap'
        'samples/heap_real'
        'samples/closure_array'
        'samples/method_mut'
        'samples/array_bool'
        'samples/array_i8'
        'samples/array_mut'
        'samples/closure_mut'
        'samples/union_i8'
        'samples/union_mut'
        'samples/mut_text'
        'samples/heap_i8'
        'samples/method_i8'
        'samples/union_f64s'
        'samples/heap_f64s'
        'samples/union_texts'
        'samples/heap_bool'
        'samples/closure_real'
        'samples/method_real'
        'samples/heap_texts'
        'samples/closure_pair_f64'
        'samples/method_pair_f64'
        'samples/closure_pair_text'
        'samples/method_pair_text'
        'samples/closure_pair_i8'
        'samples/closure_pair_heap'
        'samples/method_pair_heap'
        'samples/closure_pair_union'
        'samples/method_pair_union'
        'samples/closure_pair_mix'
        'samples/method_pair_mix'
        'samples/closure_pair_slot'
        'samples/method_pair_slot'
        'samples/closure_pair_cell'
        'samples/method_pair_cell'
        'samples/closure_pair_bool'
        'samples/closure_pair_array'
        'samples/closure_triple'
        'samples/closure_pair_union_heap'
        'samples/method_pair_union_heap'
        'samples/closure_return'
        'samples/method_return'
        'samples/closure_return_text'
        'samples/closure_return_heap'
        'samples/closure_pair_fun'
        'samples/union_pair_mix'
        'samples/union_triple_mix'
        'samples/union_fun_mix'
        'samples/union_cell_mix'
        'samples/union_real_mix'
        'samples/union_array_mix'
        'samples/closure_union_mix'
        'samples/method_union_mix'
        'samples/method_pair_fun'
        'samples/heap_pair'
        'samples/heap_pair_mix'
        'samples/heap_triple'
        'samples/mut_pair'
        'samples/heap_fun'
        'samples/heap_slot'
        'samples/heap_real_text'
        'samples/array_heap_mix'
        'samples/closure_depth'
        'samples/array_mut_pair'
        'samples/heap_i8_text'
        'samples/closure_mut_pair'
        'samples/method_mut_pair'
        'samples/heap_array_n'
        'samples/method_depth'
        'samples/union_i8_text'
        'samples/heap_texts_flag'
        'samples/mut_real_text'
        'samples/union_texts_flag'
        'samples/heap_f32_n'
        'samples/heap_i64_text'
        'samples/array_f32'
        'samples/array_i64'
        'samples/union_i64_text'
        'samples/closure_pair_i64'
        'samples/heap_u64_text'
        'samples/array_u64'
        'samples/mut_i64_text'
        'samples/heap_f32_text'
        'samples/heap_array_f32'
        'samples/union_f32_text'
        'samples/array_u8'
        'samples/array_i16'
        'samples/array_u16'
        'samples/mut_f32_text'
        'samples/array_i64_at1'
        'samples/array_heap_f32'
        'samples/closure_pair_f32'
        'samples/heap_i16_text'
        'samples/array_mut_f32'
        'samples/heap_bool_text'
        'samples/heap_text_pair'
        'samples/closure_f32_heap'
        'samples/array_text_at1'
        'samples/union_text_pair'
        'samples/mut_text_pair'
        'samples/heap_u16_text'
        'samples/heap_u8_text'
        'samples/closure_text_pair'
        'samples/heap_u32_text'
        'samples/union_u32_text'
        'samples/method_text_pair'
        'samples/heap_f32_u32'
        'samples/heap_u32_flag'
        'samples/union_u32_flag'
        'samples/heap_text_eq'
        'samples/mut_u32_text'
        'samples/closure_u32_flag'
        'samples/array_union_text'
        'samples/heap_i64_real'
        'samples/heap_heap'
        'samples/heap_mut_cell'
        'samples/closure_heap_heap'
        'samples/union_heap_heap'
        'samples/array_heap_heap'
        'samples/mut_heap_heap'
        'samples/closure_union_heap_heap'
        'samples/array_union_heap_heap'
        'samples/heap_heap_heap'
        'samples/closure_heap_heap_heap'
        'samples/union_heap_heap_heap'
        'samples/array_heap_heap_heap'
        'samples/mut_heap_heap_heap'
        'samples/array_mut_heap_heap'
        'samples/heap_pair_heaps'
        'samples/union_pair_heaps'
        'samples/closure_pair_heaps'
        'samples/mut_pair_heaps'
        'samples/array_heap_pair_heaps'
        'samples/array_mut_pair_heaps'
        'samples/closure_union_pair_heaps'
        'samples/heap_union_pair_heaps'
        'samples/array_union_pair_heaps'
        'samples/heap_triple_heaps'
        'samples/closure_triple_heaps'
        'samples/union_triple_heaps'
        'samples/mut_triple_heaps'
        'samples/array_heap_triple_heaps'
        'samples/array_mut_triple_heaps'
        'samples/closure_union_triple_heaps'
        'samples/heap_union_triple_heaps'
        'samples/array_union_triple_heaps'
        'samples/heap_heap_pair_heaps'
        'samples/closure_heap_pair_heaps'
        'samples/union_heap_pair_heaps'
        'samples/array_heap_heap_pair'
        'samples/mut_heap_heap_pair'
        'samples/array_mut_heap_heap_pair'
        'samples/heap_union_heap_pair_heaps'
        'samples/array_union_heap_pair_heaps'
        'samples/closure_union_heap_pair_heaps'
        'samples/mut_heap_union_heap_pair_heaps'
        'samples/array_mut_heap_union_heap_pair_heaps'
        'samples/array_heap_union_heap_pair_heaps'
        'samples/closure_heap_union_heap_pair_heaps'
        'samples/union_heap_union_heap_pair_heaps'
        'samples/array_union_heap_union_heap_pair_heaps'
        'samples/closure_union_heap_union_heap_pair_heaps'
        'samples/heap_union_heap_union_heap_pair_heaps'
        'samples/mut_heap_union_heap_union_heap_pair_heaps'
        'samples/array_mut_heap_union_heap_union_heap_pair_heaps'
        'samples/closure_heap_union_heap_union_heap_pair_heaps'
        'samples/array_heap_union_heap_union_heap_pair_heaps'
        'samples/array2_heap_union_heap_union_heap_pair_heaps'
        'samples/union3_heap_union_heap_union_heap_pair_heaps'
        'samples/union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/array_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/closure_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/heap_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/array_mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/closure_heap_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/array3_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/closure_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/array_closure_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/array_heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/array_create_reads_zero', 'samples/c_gadt_union_array', 'samples/c_self_tail_loop_heap', 'samples/dynamic_array_bool', 'samples/dynamic_array_f64', 'samples/dynamic_array_function_boundary', 'samples/dynamic_array_mutable_alias', 'samples/dynamic_array_nested', 'samples/dynamic_array_runtime_length', 'samples/dynamic_array_shared_alias', 'samples/dynamic_array_union', 'samples/dynamic_array_union_nested', 'samples/dynamic_array_union_nested_shared_alias', 'samples/dynamic_array_union_shared_alias', 'samples/ebpf_arith', 'samples/ebpf_bacc', 'samples/ebpf_bits', 'samples/ebpf_bool', 'samples/ebpf_cast', 'samples/ebpf_char', 'samples/ebpf_conv', 'samples/ebpf_div', 'samples/ebpf_facc', 'samples/ebpf_fdiv', 'samples/ebpf_float', 'samples/ebpf_flt', 'samples/ebpf_ineq', 'samples/ebpf_neq', 'samples/ebpf_nest3', 'samples/ebpf_sh31', 'samples/ebpf_shift', 'samples/ebpf_snot', 'samples/ebpf_t2', 'samples/ebpf_t3', 'samples/ebpf_tacc', 'samples/ebpf_tworec', 'samples/ebpf_uacc', 'samples/ebpf_uadd', 'samples/ebpf_umul', 'samples/fixed_array_runtime_index', 'samples/fixed_array_runtime_update', 'samples/fixed_array_scalar', 'samples/folder_index_module', 'samples/frontier_fib', 'samples/frontier_hello', 'samples/frontier_macro_then_multiline_annotation', 'samples/frontier_try_item', 'samples/gadt_lazy_payload', 'samples/gadt_match_loses_constraint', 'samples/item_metadata_missing_target', 'samples/managed_string_array', 'samples/managed_string_builder', 'samples/managed_string_codepoints', 'samples/managed_string_concat', 'samples/managed_string_empty_slice', 'samples/managed_string_index', 'samples/managed_string_invalid_utf8_slice', 'samples/managed_string_runtime', 'samples/managed_string_runtime_choice', 'samples/managed_string_shared_calls', 'samples/managed_string_slice', 'samples/managed_string_union', 'samples/managed_string_utf8_boundaries', 'samples/match_multiline_scrutinee', 'samples/multiline_comment', 'samples/multiline_triple_string', 'samples/multiline_type_application_dropped', 'samples/native_closure_array_capture', 'samples/native_closure_branch', 'samples/native_closure_captured_branch', 'samples/native_closure_diamond_package', 'samples/native_closure_external_package', 'samples/native_closure_managed_capture', 'samples/native_closure_managed_captured_branch', 'samples/native_closure_managed_reuse', 'samples/native_closure_multimodule', 'samples/native_closure_multiowner', 'samples/native_closure_nested_branch', 'samples/native_closure_return', 'samples/native_closure_reuse', 'samples/native_closure_transitive_package', 'samples/native_closure_transport', 'samples/native_closure_union_capture_method', 'samples/native_closure_union_rec', 'samples/native_cube_direct', 'samples/native_float_infinity', 'samples/native_literal_join_args', 'samples/native_managed_tail_recursion', 'samples/native_managed_union_array_closure', 'samples/native_managed_union_capture_record', 'samples/native_managed_union_record_closure', 'samples/native_managed_union_record_two_managed', 'samples/native_multimodule', 'samples/native_package_fixed_array_local', 'samples/native_package_fixed_array_mixed_runtime_write', 'samples/native_package_fixed_array_mixed_types', 'samples/native_package_fixed_array_numeric_widths', 'samples/native_package_fixed_array_runtime_index', 'samples/native_package_fixed_array_two_runtime_indexes', 'samples/native_package_owned_array_failure', 'samples/native_package_owned_array_transitive', 'samples/native_package_owned_array_type', 'samples/native_package_owned_managed_type', 'samples/native_package_owned_type', 'samples/native_package_prototype_record_callback', 'samples/native_prototype_record_callback', 'samples/native_prototype_union_closure_method', 'samples/native_source_package_prototype_record_callback', 'samples/native_source_package_prototype_union_callback', 'samples/native_source_package_prototype_union_callback_managed_single_owner', 'samples/native_source_package_prototype_union_callback_managed_two_cases', 'samples/nominal_phantom_parameter', 'samples/nominal_record_field_order', 'samples/nominal_union_case_pattern', 'samples/op_args_application', 'samples/package_default_int_i64', 'samples/qualified_union_case_pattern', 'samples/rust_emit_expr_macro', 'samples/rust_global_item_macro', 'samples/rust_static_closure_chain', 'samples/rust_target_globals', 'samples/static_string', 'samples/tagged_union_enum', 'samples/tagged_union_heterogeneous', 'samples/tagged_union_scalar', 'samples/tagged_union_three_case', 'samples/target_global_conflict', 'samples/ts_array_union', 'samples/ts_closure_capture', 'samples/ts_closure_return', 'samples/ts_int_wrap', 'samples/ts_layout_heap', 'samples/ts_layout_mutable', 'samples/ts_string_concat', 'samples/ts_string_slice', 'samples/typecheck_long_let_body', 'samples/union_case_record_field_order', 'samples/upstream_type_if', 'samples/wgsl_array_scalar', 'samples/wgsl_gadt_payload_union', 'samples/wgsl_tail_call_in_match'
        'samples/c_deep_list_decref'
        'samples/dynamic_array_bounds_negative'
        'samples/dynamic_array_record'
        'samples/dynamic_array_record_shared_alias'
        'samples/dynamic_array_return'
        'samples/frontier_static_list_eq'
        'samples/lua_while_union_pair'
        'samples/managed_string_record'
        'samples/managed_string_recursive'
        'samples/mega_brzozowski_derivatives/indexed_dfa_state_cardinality'
        'samples/mega_brzozowski_derivatives/inventory_closed_dfa_runtime'
        'samples/mega_brzozowski_derivatives/runtime_native'
        'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
        'samples/mega_omniledger_erp_kernel/runtime_native'
        'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
        'samples/mega_zeta_structural_laboratory/runtime_native'
        'samples/native_closure_recursive_capture'
        'samples/native_float_math_family'
        'samples/native_float_pow_pi'
        'samples/native_float_sqrt'
        'samples/native_managed_array_tail_recursion'
        'samples/native_managed_scc_tail_recursion'
        'samples/native_recursive_tail_recursion'
        'samples/portable_composite'
        'samples/record_value'
        'samples/recursive_union_list'
        'samples/recursive_union_managed'
        'samples/recursive_union_multi_case'
        'samples/recursive_union_mutual'
        'samples/recursive_union_terminal_ownership'
        'samples/recursive_union_tree_shared'
        'samples/ts_union_recursive'
        'samples/wgsl_array_tuple'
        'samples/wgsl_nullary_union'
        'samples/wgsl_payload_union'
        'samples/wgsl_record_loop'
        'samples/printf_portable'
        'samples/op_args_deref_if'
        'samples/wgsl_unit_self_loop'
        'samples/mega_brzozowski_derivatives/runtime_bench'
        'samples/lua_wide_integers'
        'samples/native_replay_repeat_call'
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
        'samples/portable_console_lines'
        'samples/portable_convert_parse'
        'samples/portable_math_rounding'
    )
    Swift = @(
        'samples/frontier_format_any_union'
        'samples/frontier_join_format_any'
        'samples/frontier_hopacsota_globals_order'
        'samples/frontier_gadt_growing_index'
        'samples/frontier_hopacsota_mutual_pending'
        'samples/frontier_hopacsota_recursion_inferred'
        'samples/macro_splice_before_quote'
        'samples/zig_exit_wide'
        'samples/backend_smoke'
        'samples/arithmetic_branch'
        'samples/branch_select'
        'samples/function_call'
        'samples/gleam_match_narrowed'
        'samples/gleam_match_single_case'
        'samples/predicate_call'
        'samples/native_bitwise_scalar'
        'samples/tail_loop'
        'samples/python_self_tail_call_depth'
        'samples/unsigned_mod'
        'samples/float_math'
        'samples/tuple_pair'
        'samples/tuple_mixed'
        'samples/nested_tuple'
        'samples/ts_tuple_mixed'
        'samples/expression_precedence'
        'samples/native_tail_recursion'
        'samples/while_loop'
        'samples/while_control'
        'samples/ts_while_loop'
        'samples/ts_tail_loop'
        'samples/f64_scalar'
        'samples/i64_scalar'
        'samples/small_int_scalar'
        'samples/small_int_ops'
        'samples/failwith_exit'
        'samples/string_utf8'
        'samples/string_eq'
        'samples/string_ord'
        'samples/array_i32'
        'samples/array_u32'
        'samples/ts_union_scalar'
        'samples/union_option'
        'samples/union_bool'
        'samples/union_nested'
        'samples/union_pair'
        'samples/union_text'
        'samples/union_real'
        'samples/native_closure_capture'
        'samples/closure_apply'
        'samples/closure_curry'
        'samples/recur_sum'
        'samples/native_layout_heap'
        'samples/native_layout_mutable'
        'samples/mutable_alias_method_branch'
        'samples/heap_text'
        'samples/heap_nest'
        'samples/heap_closure'
        'samples/union_call'
        'samples/array_cell'
        'samples/closure_pair'
        'samples/union_heap'
        'samples/heap_union'
        'samples/closure_union'
        'samples/array_union'
        'samples/method_union'
        'samples/array_text'
        'samples/heap_array'
        'samples/union_array'
        'samples/array_fun'
        'samples/array_f64'
        'samples/closure_text'
        'samples/method_text'
        'samples/method_array'
        'samples/method_heap'
        'samples/closure_heap'
        'samples/heap_real'
        'samples/closure_array'
        'samples/method_mut'
        'samples/array_bool'
        'samples/array_i8'
        'samples/array_mut'
        'samples/closure_mut'
        'samples/union_i8'
        'samples/union_mut'
        'samples/mut_text'
        'samples/heap_i8'
        'samples/method_i8'
        'samples/union_f64s'
        'samples/heap_f64s'
        'samples/union_texts'
        'samples/heap_bool'
        'samples/closure_real'
        'samples/method_real'
        'samples/heap_texts'
        'samples/closure_pair_f64'
        'samples/method_pair_f64'
        'samples/closure_pair_text'
        'samples/method_pair_text'
        'samples/closure_pair_i8'
        'samples/closure_pair_heap'
        'samples/method_pair_heap'
        'samples/closure_pair_union'
        'samples/method_pair_union'
        'samples/closure_pair_mix'
        'samples/method_pair_mix'
        'samples/closure_pair_slot'
        'samples/method_pair_slot'
        'samples/closure_pair_cell'
        'samples/method_pair_cell'
        'samples/closure_pair_bool'
        'samples/closure_pair_array'
        'samples/closure_triple'
        'samples/closure_pair_union_heap'
        'samples/method_pair_union_heap'
        'samples/closure_return'
        'samples/method_return'
        'samples/closure_return_text'
        'samples/closure_return_heap'
        'samples/closure_pair_fun'
        'samples/union_pair_mix'
        'samples/union_triple_mix'
        'samples/union_fun_mix'
        'samples/union_cell_mix'
        'samples/union_real_mix'
        'samples/union_array_mix'
        'samples/closure_union_mix'
        'samples/method_union_mix'
        'samples/method_pair_fun'
        'samples/heap_pair'
        'samples/heap_pair_mix'
        'samples/heap_triple'
        'samples/mut_pair'
        'samples/heap_fun'
        'samples/heap_slot'
        'samples/heap_real_text'
        'samples/array_heap_mix'
        'samples/closure_depth'
        'samples/array_mut_pair'
        'samples/heap_i8_text'
        'samples/closure_mut_pair'
        'samples/method_mut_pair'
        'samples/heap_array_n'
        'samples/method_depth'
        'samples/union_i8_text'
        'samples/heap_texts_flag'
        'samples/mut_real_text'
        'samples/union_texts_flag'
        'samples/heap_f32_n'
        'samples/heap_i64_text'
        'samples/array_f32'
        'samples/array_i64'
        'samples/union_i64_text'
        'samples/closure_pair_i64'
        'samples/heap_u64_text'
        'samples/array_u64'
        'samples/mut_i64_text'
        'samples/heap_f32_text'
        'samples/heap_array_f32'
        'samples/union_f32_text'
        'samples/array_u8'
        'samples/array_i16'
        'samples/array_u16'
        'samples/mut_f32_text'
        'samples/array_i64_at1'
        'samples/array_heap_f32'
        'samples/closure_pair_f32'
        'samples/heap_i16_text'
        'samples/array_mut_f32'
        'samples/heap_bool_text'
        'samples/heap_text_pair'
        'samples/closure_f32_heap'
        'samples/array_text_at1'
        'samples/union_text_pair'
        'samples/mut_text_pair'
        'samples/heap_u16_text'
        'samples/heap_u8_text'
        'samples/closure_text_pair'
        'samples/heap_u32_text'
        'samples/union_u32_text'
        'samples/method_text_pair'
        'samples/heap_f32_u32'
        'samples/heap_u32_flag'
        'samples/union_u32_flag'
        'samples/heap_text_eq'
        'samples/mut_u32_text'
        'samples/closure_u32_flag'
        'samples/array_union_text'
        'samples/heap_i64_real'
        'samples/heap_heap'
        'samples/heap_mut_cell'
        'samples/closure_heap_heap'
        'samples/union_heap_heap'
        'samples/array_heap_heap'
        'samples/mut_heap_heap'
        'samples/closure_union_heap_heap'
        'samples/array_union_heap_heap'
        'samples/heap_heap_heap'
        'samples/closure_heap_heap_heap'
        'samples/union_heap_heap_heap'
        'samples/array_heap_heap_heap'
        'samples/mut_heap_heap_heap'
        'samples/array_mut_heap_heap'
        'samples/heap_pair_heaps'
        'samples/union_pair_heaps'
        'samples/closure_pair_heaps'
        'samples/mut_pair_heaps'
        'samples/array_heap_pair_heaps'
        'samples/array_mut_pair_heaps'
        'samples/closure_union_pair_heaps'
        'samples/heap_union_pair_heaps'
        'samples/array_union_pair_heaps'
        'samples/heap_triple_heaps'
        'samples/closure_triple_heaps'
        'samples/union_triple_heaps'
        'samples/mut_triple_heaps'
        'samples/array_heap_triple_heaps'
        'samples/array_mut_triple_heaps'
        'samples/closure_union_triple_heaps'
        'samples/heap_union_triple_heaps'
        'samples/array_union_triple_heaps'
        'samples/heap_heap_pair_heaps'
        'samples/closure_heap_pair_heaps'
        'samples/union_heap_pair_heaps'
        'samples/array_heap_heap_pair'
        'samples/mut_heap_heap_pair'
        'samples/array_mut_heap_heap_pair'
        'samples/heap_union_heap_pair_heaps'
        'samples/array_union_heap_pair_heaps'
        'samples/closure_union_heap_pair_heaps'
        'samples/mut_heap_union_heap_pair_heaps'
        'samples/array_mut_heap_union_heap_pair_heaps'
        'samples/array_heap_union_heap_pair_heaps'
        'samples/closure_heap_union_heap_pair_heaps'
        'samples/union_heap_union_heap_pair_heaps'
        'samples/array_union_heap_union_heap_pair_heaps'
        'samples/closure_union_heap_union_heap_pair_heaps'
        'samples/heap_union_heap_union_heap_pair_heaps'
        'samples/mut_heap_union_heap_union_heap_pair_heaps'
        'samples/array_mut_heap_union_heap_union_heap_pair_heaps'
        'samples/closure_heap_union_heap_union_heap_pair_heaps'
        'samples/array_heap_union_heap_union_heap_pair_heaps'
        'samples/array2_heap_union_heap_union_heap_pair_heaps'
        'samples/union3_heap_union_heap_union_heap_pair_heaps'
        'samples/union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/array_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/closure_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/heap_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/array_mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/closure_heap_union3_both_heap_union_heap_union_heap_pair_heaps'
        'samples/union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/array3_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/closure_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/array_closure_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/array_heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps'
        'samples/array_create_reads_zero', 'samples/c_gadt_union_array', 'samples/c_self_tail_loop_heap', 'samples/ebpf_bacc', 'samples/ebpf_bits', 'samples/ebpf_bool', 'samples/ebpf_div', 'samples/ebpf_facc', 'samples/ebpf_fdiv', 'samples/ebpf_float', 'samples/ebpf_flt', 'samples/ebpf_ineq', 'samples/ebpf_neq', 'samples/ebpf_nest3', 'samples/ebpf_sh31', 'samples/ebpf_shift', 'samples/ebpf_snot', 'samples/ebpf_t2', 'samples/ebpf_t3', 'samples/ebpf_tacc', 'samples/ebpf_tworec', 'samples/ebpf_uacc', 'samples/ebpf_uadd', 'samples/ebpf_umul', 'samples/fixed_array_runtime_index', 'samples/fixed_array_runtime_update', 'samples/fixed_array_scalar', 'samples/folder_index_module', 'samples/frontier_fib', 'samples/frontier_hello', 'samples/frontier_macro_then_multiline_annotation', 'samples/frontier_try_item', 'samples/gadt_lazy_payload', 'samples/gadt_match_loses_constraint', 'samples/item_metadata_missing_target', 'samples/managed_string_array', 'samples/managed_string_builder', 'samples/managed_string_codepoints', 'samples/managed_string_concat', 'samples/managed_string_empty_slice', 'samples/managed_string_index', 'samples/managed_string_invalid_utf8_slice', 'samples/managed_string_runtime', 'samples/managed_string_runtime_choice', 'samples/managed_string_shared_calls', 'samples/managed_string_slice', 'samples/managed_string_union', 'samples/managed_string_utf8_boundaries', 'samples/match_multiline_scrutinee', 'samples/multiline_comment', 'samples/multiline_triple_string', 'samples/multiline_type_application_dropped', 'samples/native_closure_reuse', 'samples/native_cube_direct', 'samples/native_float_infinity', 'samples/native_multimodule', 'samples/native_package_fixed_array_local', 'samples/native_package_fixed_array_mixed_runtime_write', 'samples/native_package_fixed_array_mixed_types', 'samples/native_package_fixed_array_numeric_widths', 'samples/native_package_fixed_array_runtime_index', 'samples/native_package_fixed_array_two_runtime_indexes', 'samples/native_package_owned_array_failure', 'samples/native_package_owned_array_transitive', 'samples/native_package_owned_array_type', 'samples/native_package_owned_managed_type', 'samples/native_package_owned_type', 'samples/nominal_phantom_parameter', 'samples/nominal_record_field_order', 'samples/nominal_union_case_pattern', 'samples/op_args_application', 'samples/package_default_int_i64', 'samples/qualified_union_case_pattern', 'samples/rust_emit_expr_macro', 'samples/rust_global_item_macro', 'samples/rust_static_closure_chain', 'samples/rust_target_globals', 'samples/static_string', 'samples/tagged_union_enum', 'samples/tagged_union_heterogeneous', 'samples/tagged_union_scalar', 'samples/tagged_union_three_case', 'samples/target_global_conflict', 'samples/ts_closure_capture', 'samples/ts_layout_heap', 'samples/ts_layout_mutable', 'samples/typecheck_long_let_body', 'samples/union_case_record_field_order', 'samples/upstream_type_if', 'samples/wgsl_array_scalar', 'samples/wgsl_gadt_payload_union', 'samples/wgsl_tail_call_in_match'
        'samples/dynamic_array_mutable_alias', 'samples/dynamic_array_union_shared_alias', 'samples/dynamic_array_union_nested_shared_alias'
        'samples/c_deep_list_decref'
        'samples/ebpf_cast'
        'samples/ebpf_char'
        'samples/ebpf_conv'
        'samples/frontier_static_list_eq'
        'samples/lua_while_union_pair'
        'samples/managed_string_record'
        'samples/managed_string_recursive'
        'samples/mega_brzozowski_derivatives/indexed_dfa_state_cardinality'
        'samples/mega_brzozowski_derivatives/inventory_closed_dfa_runtime'
        'samples/mega_brzozowski_derivatives/runtime_native'
        'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
        'samples/mega_omniledger_erp_kernel/runtime_native'
        'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
        'samples/mega_zeta_structural_laboratory/runtime_native'
        'samples/native_closure_array_capture'
        'samples/native_closure_branch'
        'samples/native_closure_captured_branch'
        'samples/native_closure_diamond_package'
        'samples/native_closure_external_package'
        'samples/native_closure_managed_capture'
        'samples/native_closure_managed_captured_branch'
        'samples/native_closure_managed_reuse'
        'samples/native_closure_multimodule'
        'samples/native_closure_multiowner'
        'samples/native_closure_nested_branch'
        'samples/native_closure_recursive_capture'
        'samples/native_closure_return'
        'samples/native_closure_transitive_package'
        'samples/native_closure_transport'
        'samples/native_closure_union_capture_method'
        'samples/native_closure_union_rec'
        'samples/native_package_prototype_record_callback'
        'samples/native_prototype_record_callback'
        'samples/native_prototype_union_closure_method'
        'samples/native_recursive_tail_recursion'
        'samples/native_source_package_prototype_record_callback'
        'samples/native_source_package_prototype_union_callback'
        'samples/native_source_package_prototype_union_callback_managed_single_owner'
        'samples/native_source_package_prototype_union_callback_managed_two_cases'
        'samples/portable_composite'
        'samples/record_value'
        'samples/recursive_union_list'
        'samples/recursive_union_managed'
        'samples/recursive_union_multi_case'
        'samples/recursive_union_mutual'
        'samples/recursive_union_terminal_ownership'
        'samples/recursive_union_tree_shared'
        'samples/ts_array_union'
        'samples/ts_closure_return'
        'samples/ts_int_wrap'
        'samples/ts_string_concat'
        'samples/ts_string_slice'
        'samples/ts_union_recursive'
        'samples/wgsl_array_tuple'
        'samples/wgsl_nullary_union'
        'samples/wgsl_payload_union'
        'samples/wgsl_record_loop'
        'samples/dynamic_array_bool'
        'samples/dynamic_array_f64'
        'samples/dynamic_array_function_boundary'
        'samples/dynamic_array_nested'
        'samples/dynamic_array_record'
        'samples/dynamic_array_record_shared_alias'
        'samples/dynamic_array_return'
        'samples/dynamic_array_runtime_length'
        'samples/dynamic_array_shared_alias'
        'samples/dynamic_array_union'
        'samples/dynamic_array_union_nested'
        'samples/ebpf_arith'
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
        'samples/printf_portable'
        'samples/op_args_deref_if'
        'samples/wgsl_unit_self_loop'
        'samples/mega_brzozowski_derivatives/runtime_bench'
        'samples/lua_wide_integers'
        'samples/native_replay_repeat_call'
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
        'samples/portable_console_lines'
        'samples/portable_convert_parse'
        'samples/portable_math_rounding'
    )
    OpenQasm = @(
        'samples/backend_smoke'
        'samples/arithmetic_branch'
        'samples/branch_select'
        'samples/function_call'
        'samples/predicate_call'
        'samples/native_bitwise_scalar'
        'samples/tail_loop'
        'samples/python_self_tail_call_depth'
        'samples/unsigned_mod'
        'samples/float_math'
        'samples/expression_precedence'
        'samples/native_tail_recursion'
        'samples/while_loop'
        'samples/while_control'
        'samples/ts_while_loop'
        'samples/ts_tail_loop'
        'samples/tuple_pair'
        'samples/ebpf_nest3'
        'samples/ebpf_tacc'
        'samples/ebpf_t2'
        'samples/ebpf_t3'
        'samples/tuple_mixed'
        'samples/nested_tuple'
        'samples/ts_tuple_mixed'
        'samples/recur_sum'
        'samples/i64_scalar'
        'samples/f64_scalar'
        'samples/method_real'
        'samples/method_pair_f64'
        'samples/native_float_sqrt'
        'samples/native_float_pow_pi'
        'samples/ebpf_arith'
        'samples/ebpf_bacc'
        'samples/ebpf_bits'
        'samples/ebpf_bool'
        'samples/ebpf_cast'
        'samples/ebpf_char'
        'samples/ebpf_conv'
        'samples/ebpf_div'
        'samples/ebpf_facc'
        'samples/ebpf_fdiv'
        'samples/ebpf_float'
        'samples/ebpf_flt'
        'samples/ebpf_ineq'
        'samples/ebpf_neq'
        'samples/ebpf_snot'
        'samples/ebpf_tworec'
        'samples/ebpf_uacc'
        'samples/ebpf_uadd'
        'samples/ebpf_umul'
        'samples/folder_index_module'
        'samples/frontier_fib'
        'samples/frontier_gadt_growing_index'
        'samples/frontier_hello'
        'samples/frontier_hopacsota_mutual_pending'
        'samples/frontier_hopacsota_recursion_inferred'
        'samples/frontier_macro_then_multiline_annotation'
        'samples/frontier_static_list_eq'
        'samples/frontier_try_item'
        'samples/gadt_lazy_payload'
        'samples/gadt_match_loses_constraint'
        'samples/macro_splice_before_quote'
        'samples/match_multiline_scrutinee'
        'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
        'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
        'samples/mega_zeta_structural_laboratory/runtime_native'
        'samples/multiline_comment'
        'samples/multiline_type_application_dropped'
        'samples/native_cube_direct'
        'samples/native_float_infinity'
        'samples/native_float_nan_is'
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
        'samples/nominal_phantom_parameter'
        'samples/nominal_record_field_order'
        'samples/op_args_application'
        'samples/package_default_int_i64'
        'samples/qualified_union_case_pattern'
        'samples/rust_emit_expr_macro'
        'samples/rust_global_item_macro'
        'samples/ts_float_nan'
        'samples/typecheck_long_let_body'
        'samples/union_case_record_field_order'
        'samples/upstream_type_if'
        'samples/zig_exit_wide'
        'samples/method_i8'
        'samples/small_int_ops'
        'samples/small_int_scalar'
        'samples/ts_int_wrap'
        'samples/native_float_math_family'
    )
    Ebpf = @(
        'samples/backend_smoke'
        'samples/arithmetic_branch'
        'samples/branch_select'
        'samples/function_call'
        'samples/predicate_call'
        'samples/native_bitwise_scalar'
        'samples/tail_loop'
        'samples/python_self_tail_call_depth'
        'samples/unsigned_mod'
        'samples/float_math'
        'samples/tuple_pair'
        'samples/tuple_mixed'
        'samples/nested_tuple'
        'samples/ts_tuple_mixed'
        'samples/expression_precedence'
        'samples/native_tail_recursion'
        'samples/while_loop'
        'samples/while_control'
        'samples/ts_while_loop'
        'samples/ts_tail_loop'
        'samples/ebpf_map'
        'samples/ebpf_map_full'
        'samples/ebpf_arith'
        'samples/ebpf_nested'
        'samples/ebpf_float'
        'samples/ebpf_conv'
        'samples/ebpf_unit'
        'samples/ebpf_shift'
        'samples/ebpf_bool'
        'samples/ebpf_cast'
        'samples/ebpf_div'
        'samples/ebpf_bits'
        'samples/ebpf_key'
        'samples/ebpf_umul'
        'samples/ebpf_neq'
        'samples/ebpf_facc'
        'samples/ebpf_uacc'
        'samples/ebpf_bacc'
        'samples/ebpf_char'
        'samples/ebpf_sh31'
        'samples/ebpf_flt'
        'samples/ebpf_minkey'
        'samples/ebpf_nest3'
        'samples/ebpf_uadd'
        'samples/ebpf_fdiv'
        'samples/ebpf_tacc'
        'samples/ebpf_t2'
        'samples/ebpf_ineq'
        'samples/ebpf_tworec'
        'samples/ebpf_t3'
        'samples/ebpf_snot'
        'samples/i64_scalar'
        'samples/method_i8'
        'samples/small_int_ops'
        'samples/small_int_scalar'
    )
    Zig = @(
        'samples/abi_external'
        'samples/abi_external_i64'
        'samples/abi_external_callback'
        'samples/abi_external_struct_argument'
        'samples/abi_external_struct_return'
        'samples/abi_external_struct_return_i64'
        'samples/abi_external_const_buffer'
        'samples/abi_external_mutable_buffer'
        'samples/abi_external_string'
        'samples/ebpf_key'
        'samples/ebpf_map'
        'samples/ebpf_minkey'
        'samples/ebpf_unit'
        'samples/ebpf_map_full'
        'samples/ebpf_nested'
        'samples/lua_paren_statement'
        'samples/frontier_gadt_growing_index'
        'samples/macro_splice_before_quote'
        'samples/gleam_match_narrowed'
        'samples/zig_exit_wide'
        'samples/array_bool',
        'samples/array_cell',
        'samples/array_closure_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/array_create_reads_zero',
        'samples/array_f32',
        'samples/array_f64',
        'samples/array_fun',
        'samples/array_heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/array_heap_f32',
        'samples/array_heap_heap',
        'samples/array_heap_heap_heap',
        'samples/array_heap_heap_pair',
        'samples/array_heap_mix',
        'samples/array_heap_pair_heaps',
        'samples/array_heap_triple_heaps',
        'samples/array_heap_union_heap_pair_heaps',
        'samples/array_heap_union_heap_union_heap_pair_heaps',
        'samples/array_i16',
        'samples/array_i32',
        'samples/array_i64',
        'samples/array_i64_at1',
        'samples/array_i8',
        'samples/array_mut',
        'samples/array_mut_f32',
        'samples/array_mut_heap_heap',
        'samples/array_mut_heap_heap_pair',
        'samples/array_mut_heap_union_heap_pair_heaps',
        'samples/array_mut_heap_union_heap_union_heap_pair_heaps',
        'samples/array_mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/array_mut_pair',
        'samples/array_mut_pair_heaps',
        'samples/array_mut_triple_heaps',
        'samples/array_text',
        'samples/array_text_at1',
        'samples/array_u16',
        'samples/array_u32',
        'samples/array_u64',
        'samples/array_u8',
        'samples/array_union',
        'samples/array_union_heap_heap',
        'samples/array_union_heap_pair_heaps',
        'samples/array_union_heap_union_heap_pair_heaps',
        'samples/array_union_pair_heaps',
        'samples/array_union_text',
        'samples/array_union_triple_heaps',
        'samples/array_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/array2_heap_union_heap_union_heap_pair_heaps',
        'samples/array3_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/c_deep_list_decref',
        'samples/c_gadt_union_array',
        'samples/c_self_tail_loop_heap',
        'samples/closure_apply',
        'samples/closure_array',
        'samples/closure_curry',
        'samples/closure_depth',
        'samples/closure_f32_heap',
        'samples/closure_heap',
        'samples/closure_heap_heap',
        'samples/closure_heap_heap_heap',
        'samples/closure_heap_pair_heaps',
        'samples/closure_heap_union_heap_pair_heaps',
        'samples/closure_heap_union_heap_union_heap_pair_heaps',
        'samples/closure_heap_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/closure_mut',
        'samples/closure_mut_pair',
        'samples/closure_pair',
        'samples/closure_pair_array',
        'samples/closure_pair_bool',
        'samples/closure_pair_cell',
        'samples/closure_pair_f32',
        'samples/closure_pair_f64',
        'samples/closure_pair_fun',
        'samples/closure_pair_heap',
        'samples/closure_pair_heaps',
        'samples/closure_pair_i64',
        'samples/closure_pair_i8',
        'samples/closure_pair_mix',
        'samples/closure_pair_slot',
        'samples/closure_pair_text',
        'samples/closure_pair_union',
        'samples/closure_pair_union_heap',
        'samples/closure_real',
        'samples/closure_return',
        'samples/closure_return_heap',
        'samples/closure_return_text',
        'samples/closure_text',
        'samples/closure_text_pair',
        'samples/closure_triple',
        'samples/closure_triple_heaps',
        'samples/closure_u32_flag',
        'samples/closure_union',
        'samples/closure_union_heap_heap',
        'samples/closure_union_heap_pair_heaps',
        'samples/closure_union_heap_union_heap_pair_heaps',
        'samples/closure_union_mix',
        'samples/closure_union_pair_heaps',
        'samples/closure_union_triple_heaps',
        'samples/closure_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/closure_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/ebpf_arith',
        'samples/ebpf_bacc',
        'samples/ebpf_bits',
        'samples/ebpf_bool',
        'samples/ebpf_cast',
        'samples/ebpf_char',
        'samples/ebpf_conv',
        'samples/ebpf_div',
        'samples/ebpf_facc',
        'samples/ebpf_fdiv',
        'samples/ebpf_float',
        'samples/ebpf_flt',
        'samples/ebpf_ineq',
        'samples/ebpf_neq',
        'samples/ebpf_nest3',
        'samples/ebpf_sh31',
        'samples/ebpf_shift',
        'samples/ebpf_snot',
        'samples/ebpf_t2',
        'samples/ebpf_t3',
        'samples/ebpf_tacc',
        'samples/ebpf_tworec',
        'samples/ebpf_uacc',
        'samples/ebpf_uadd',
        'samples/ebpf_umul',
        'samples/f64_scalar',
        'samples/failwith_exit',
        'samples/gadt_lazy_payload',
        'samples/gadt_match_loses_constraint',
        'samples/heap_array',
        'samples/heap_array_f32',
        'samples/heap_array_n',
        'samples/heap_bool',
        'samples/heap_bool_text',
        'samples/heap_closure',
        'samples/heap_closure_union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/heap_f32_n',
        'samples/heap_f32_text',
        'samples/heap_f32_u32',
        'samples/heap_f64s',
        'samples/heap_fun',
        'samples/heap_heap',
        'samples/heap_heap_heap',
        'samples/heap_heap_pair_heaps',
        'samples/heap_i16_text',
        'samples/heap_i64_real',
        'samples/heap_i64_text',
        'samples/heap_i8',
        'samples/heap_i8_text',
        'samples/heap_mut_cell',
        'samples/heap_nest',
        'samples/heap_pair',
        'samples/heap_pair_heaps',
        'samples/heap_pair_mix',
        'samples/heap_real',
        'samples/heap_real_text',
        'samples/heap_slot',
        'samples/heap_text',
        'samples/heap_text_eq',
        'samples/heap_text_pair',
        'samples/heap_texts',
        'samples/heap_texts_flag',
        'samples/heap_triple',
        'samples/heap_triple_heaps',
        'samples/heap_u16_text',
        'samples/heap_u32_flag',
        'samples/heap_u32_text',
        'samples/heap_u64_text',
        'samples/heap_u8_text',
        'samples/heap_union',
        'samples/heap_union_heap_pair_heaps',
        'samples/heap_union_heap_union_heap_pair_heaps',
        'samples/heap_union_pair_heaps',
        'samples/heap_union_triple_heaps',
        'samples/heap_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/i64_scalar',
        'samples/match_multiline_scrutinee',
        'samples/method_array',
        'samples/method_depth',
        'samples/method_heap',
        'samples/method_i8',
        'samples/method_mut',
        'samples/method_mut_pair',
        'samples/method_pair_cell',
        'samples/method_pair_f64',
        'samples/method_pair_fun',
        'samples/method_pair_heap',
        'samples/method_pair_mix',
        'samples/method_pair_slot',
        'samples/method_pair_text',
        'samples/method_pair_union',
        'samples/method_pair_union_heap',
        'samples/method_real',
        'samples/method_return',
        'samples/method_text',
        'samples/method_text_pair',
        'samples/method_union',
        'samples/method_union_mix',
        'samples/multiline_type_application_dropped',
        'samples/mut_f32_text',
        'samples/mut_heap_heap',
        'samples/mut_heap_heap_heap',
        'samples/mut_heap_heap_pair',
        'samples/mut_heap_union_heap_pair_heaps',
        'samples/mut_heap_union_heap_union_heap_pair_heaps',
        'samples/mut_heap_union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/mut_i64_text',
        'samples/mut_pair',
        'samples/mut_pair_heaps',
        'samples/mut_real_text',
        'samples/mut_text',
        'samples/mut_text_pair',
        'samples/mut_triple_heaps',
        'samples/mut_u32_text',
        'samples/mutable_alias_method_branch',
        'samples/native_closure_diamond_package',
        'samples/native_closure_external_package',
        'samples/native_closure_transitive_package',
        'samples/native_float_nan_is',
        'samples/native_layout_heap',
        'samples/native_layout_mutable',
        'samples/native_package_prototype_record_callback',
        'samples/native_replay_repeat_call',
        'samples/native_source_package_prototype_record_callback',
        'samples/native_source_package_prototype_union_callback',
        'samples/native_source_package_prototype_union_callback_managed_single_owner',
        'samples/native_source_package_prototype_union_callback_managed_two_cases',
        'samples/native_string_utf8_canonical_equal_bounded_source',
        'samples/native_string_utf8_fold_source',
        'samples/native_string_utf8_fold_source_invalid',
        'samples/native_string_utf8_grapheme_bounded_source',
        'samples/native_string_utf8_grapheme_bounded_source_invalid',
        'samples/native_string_utf8_normalization_bounded_source',
        'samples/native_string_utf8_scalar_source',
        'samples/native_string_utf8_scalar_source_invalid',
        'samples/native_string_utf8_validate_source',
        'samples/native_string_utf8_validate_source_invalid',
        'samples/nominal_phantom_parameter',
        'samples/nominal_record_field_order',
        'samples/qualified_union_case_pattern',
        'samples/recur_sum',
        'samples/recursive_union_multi_case',
        'samples/small_int_ops',
        'samples/small_int_scalar',
        'samples/string_eq',
        'samples/string_ord',
        'samples/string_utf8',
        'samples/ts_layout_heap',
        'samples/ts_layout_mutable',
        'samples/typecheck_long_let_body',
        'samples/union_array',
        'samples/union_array_mix',
        'samples/union_bool',
        'samples/union_call',
        'samples/union_case_record_field_order',
        'samples/union_cell_mix',
        'samples/union_f32_text',
        'samples/union_f64s',
        'samples/union_fun_mix',
        'samples/union_heap',
        'samples/union_heap_heap',
        'samples/union_heap_heap_heap',
        'samples/union_heap_pair_heaps',
        'samples/union_heap_union_heap_pair_heaps',
        'samples/union_i64_text',
        'samples/union_i8',
        'samples/union_i8_text',
        'samples/union_mut',
        'samples/union_nested',
        'samples/union_option',
        'samples/union_pair',
        'samples/union_pair_heaps',
        'samples/union_pair_mix',
        'samples/union_real',
        'samples/union_real_mix',
        'samples/union_text',
        'samples/union_text_pair',
        'samples/union_texts',
        'samples/union_texts_flag',
        'samples/union_triple_heaps',
        'samples/union_triple_mix',
        'samples/union_u32_flag',
        'samples/union_u32_text',
        'samples/union3_all_heap_union_heap_union_heap_pair_heaps',
        'samples/union3_both_heap_union_heap_union_heap_pair_heaps',
        'samples/union3_heap_union_heap_union_heap_pair_heaps',
        'samples/upstream_type_if',
        'samples/wgsl_array_scalar',
        'samples/wgsl_array_tuple',
        'samples/wgsl_gadt_payload_union',
        'samples/wgsl_nullary_union',
        'samples/wgsl_payload_union',
        'samples/wgsl_record_loop',
        'samples/wgsl_tail_call_in_match',
        'samples/wgsl_unit_self_loop'
        'samples/lua_wide_integers'
        'samples/gleam_match_single_case'
        'samples/portable_console_lines'
        'samples/portable_math_rounding'
        'samples/zig_lib_console'
        'samples/dynamic_array_bounds_negative'
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
        'samples/arithmetic_branch'
        'samples/mega_brzozowski_derivatives/indexed_dfa_state_cardinality'
        'samples/mega_brzozowski_derivatives/inventory_closed_dfa_runtime'
        'samples/mega_brzozowski_derivatives/runtime_bench'
        'samples/mega_brzozowski_derivatives/runtime_native'
        'samples/mega_lean_cic_bottom_up_kernel/runtime_native'
        'samples/mega_omniledger_erp_kernel/runtime_native'
        'samples/mega_spiral_proves_spiral_relative_consistency/runtime_native'
        'samples/mega_zeta_structural_laboratory/runtime_native'
        'samples/frontier_format_any_union'
        'samples/frontier_hopacsota_globals_order'
        'samples/frontier_hopacsota_mutual_pending'
        'samples/frontier_hopacsota_recursion_inferred'
        'samples/frontier_join_format_any'
        'samples/native_cube_frame_direct'
        'samples/native_cube_frame_reuse_direct'
        'samples/native_cube_multiframe_direct'
        'samples/native_cube_paced_stream_direct'
        'samples/native_cube_terminal_stream_direct'
        'samples/package_default_int_i64'
        'samples/portable_convert_parse'
        'samples/while_control'
        'samples/while_loop'
        'samples/ts_float_nan'
        'samples/ts_while_loop'
    )
}
