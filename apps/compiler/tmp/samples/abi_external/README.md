# External ABI fixture

This fixture proves that a runtime value can cross from Spiral into a registered foreign function and back into the generated program.

The C authority emits `spiral_abi_libc_abs(v0)`. The portable ABI registry resolves that symbolic call to libc `abs` through `extern "C"` plus `link_name` in Rust and a `cdecl external 'c'` declaration in Delphi. All three native binaries return exit code 42 for `abs(-42)`.

Names beginning with `spiral_abi_` must exist in the registry. The sibling negative fixture verifies that unknown bindings fail before a backend residue is committed.
