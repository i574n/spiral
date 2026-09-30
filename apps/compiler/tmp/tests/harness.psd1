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
        @{ Pattern = 'native_recursive_tail_recursion'; Flags = '-include {shims}/native-recursive-tail-c-shim.h' }
        @{ Pattern = 'native_managed_scc_tail_recursion'; Flags = '-include {shims}/native-managed-scc-tail-c-shim.h' }
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
    # Backends a sample is compiled to, when not all four (Fsharp, C, Rust, Delphi). Contract and
    # megaproject samples are F# only regardless.
    Backends = @{
        'C,Rust,Delphi' = @(
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
        'C,Rust' = @(
            'samples/rust_emit_expr_macro'
            'samples/rust_global_item_macro'
        )
    }
}
