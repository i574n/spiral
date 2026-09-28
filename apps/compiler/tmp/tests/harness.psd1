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
        @{ Id = 'samples/native_recursive_tail_recursion'; Backend = 'Rust'; Reason = 'SCC tail-loop lowering leaves a value in statement position (E0308); regression in the latest PortableBackends' }
        @{ Id = 'samples/native_managed_scc_tail_recursion'; Backend = 'Rust'; Reason = 'SCC tail-loop lowering leaves a value in statement position (E0308); regression in the latest PortableBackends' }
        @{ Id = 'samples/native_managed_array_scc_tail_recursion'; Backend = 'Rust'; Reason = 'SCC tail-loop lowering leaves a value in statement position (E0308); regression in the latest PortableBackends' }
        @{ Id = 'samples/native_managed_array_scc3_tail_recursion'; Backend = 'Rust'; Reason = 'SCC tail-loop lowering leaves a value in statement position (E0308); regression in the latest PortableBackends' }
        @{ Id = 'samples/fixed_array_runtime_index'; Backend = 'Rust'; Reason = 'mismatched types (E0308) in the current Rust lowering' }
        @{ Id = 'samples/native_cube_flush_delay_direct'; Backend = 'C'; Reason = 'POSIX-only residual (poll.h); native C runs only on Linux' }
        @{ Id = 'samples/native_cube_monotonic_delay_direct'; Backend = 'C'; Reason = 'POSIX-only residual (poll.h/clock_gettime); native C runs only on Linux' }
        @{ Id = 'samples/abi_external_i64'; Backend = 'Delphi'; Reason = 'Windows FPC is 32-bit (i386-win32) while gcc/rustc build 64-bit; 64-bit ABI parity needs ppcrossx64' }
        @{ Id = 'samples/abi_external_struct_argument'; Backend = 'Delphi'; Reason = 'Windows FPC is 32-bit (i386-win32); struct-by-value ABI differs from the 64-bit C oracle' }
        @{ Id = 'samples/abi_external_struct_return_i64'; Backend = 'Delphi'; Reason = 'Windows FPC is 32-bit (i386-win32); 64-bit struct return ABI differs from the 64-bit C oracle' }
        @{ Id = 'samples/dynamic_array_resize_union_managed'; Backend = 'Rust'; Reason = 'C oracle crashes under the Windows heap (0xC0000374) with the resize-union shim; Rust/Delphi run clean' }
        @{ Id = 'samples/dynamic_array_resize_union_managed'; Backend = 'Delphi'; Reason = 'C oracle crashes under the Windows heap (0xC0000374) with the resize-union shim; Rust/Delphi run clean' }
        @{ Id = 'samples/dynamic_array_tuple_managed'; Backend = 'Rust'; Reason = 'Rust exits 2 where the C oracle exits 0; unexplained, needs investigation' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Rust'; Reason = 'C residual has no bounds check (exits 0); Rust panics as the fixture intends' }
        @{ Id = 'samples/dynamic_array_bounds_negative'; Backend = 'Delphi'; Reason = 'C residual has no bounds check (exits 0); Delphi raises a range error as the fixture intends' }
        @{ Id = 'samples/native_layout_heap'; Backend = 'Rust'; Reason = 'typed layout lowering fails ("typed layout ... appeared before its local root") although main.rs/main.pas goldens exist; bottom-up fixture newly run by the harness' }
        @{ Id = 'samples/native_layout_heap'; Backend = 'Delphi'; Reason = 'typed layout lowering fails ("typed layout ... appeared before its local root") although main.rs/main.pas goldens exist; bottom-up fixture newly run by the harness' }
        @{ Id = 'samples/native_layout_mutable'; Backend = 'Rust'; Reason = 'typed layout lowering fails ("typed layout ... appeared before its local root") although main.rs/main.pas goldens exist; bottom-up fixture newly run by the harness' }
        @{ Id = 'samples/native_layout_mutable'; Backend = 'Delphi'; Reason = 'typed layout lowering fails ("typed layout ... appeared before its local root") although main.rs/main.pas goldens exist; bottom-up fixture newly run by the harness' }
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
}
