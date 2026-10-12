# ABI external struct return

Calls libc `div`, whose C ABI returns `div_t` by value. Rust receives a `#[repr(C)]` struct and Delphi receives a record, then each wrapper packs quotient and remainder into the scalar value 32. Spiral subtracts 32, so all native executables must exit zero.
