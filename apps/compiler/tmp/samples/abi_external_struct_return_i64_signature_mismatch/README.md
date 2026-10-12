# ABI aggregate i64 signature mismatch

This negative fixture passes an `i32` denominator to the `lldiv_t` wrapper, whose registered ABI contract requires two signed 64-bit arguments. Rust and Delphi lowering must reject argument 2 before writing target output.
