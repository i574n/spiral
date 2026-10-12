# Portable external ABI: signed 64-bit integer

This fixture proves one mature C ABI binding across C, Rust and Delphi. Spiral emits a call to libc `llabs` with the out-of-i32-range value `-5000000000i64` and an `i64` result. The generated Rust uses `i64`/`c_longlong`; Delphi uses `Int64`; all three executables return zero only when the exact 64-bit magnitude is preserved.

The contract is intentionally narrow. It does not claim unsigned 64-bit ABI values, variadics, platform-dependent `long`, floating-point ABI coverage or arbitrary foreign declarations.
