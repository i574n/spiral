# Portable ABI signature mismatch negative

The registered `strlen` binding requires one borrowed managed UTF-8 string. This fixture intentionally passes an `i32`; Rust and Delphi lowering must reject it before native compilation and leave no residue.
