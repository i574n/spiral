# Captured closure branch

This fixture is compiled from `main.spi` and exercises an ordinary runtime branch between two closures that capture the same scalar layout.

The portable lowering merges the two generated closure structs into one value representation with the original captured field plus a synthetic branch discriminator. C, Rust and Delphi must all exit with code 42.

`invalid.c` changes the second closure capture from `int32_t` to `int64_t`. The lowering must reject that source instead of guessing an environment conversion.
