# ABI aggregate return with two 64-bit fields

This fixture calls libc `lldiv`, whose C ABI returns `lldiv_t` by value. Rust receives a `#[repr(C)]` aggregate containing two `c_longlong` fields and Delphi receives an `Int64` record. The wrapper reconstructs the original numerator from quotient, denominator and remainder.

The numerator `5000000007` exceeds signed 32-bit range, so a narrowed field, wrong aggregate layout or incorrect return convention cannot pass accidentally.
