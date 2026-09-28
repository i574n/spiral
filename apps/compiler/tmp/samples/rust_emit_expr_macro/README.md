# Rust emit-expression macro

This fixture preserves the generic `rust.emit_expr` residual shape used by `lib/spiral/rust/rust.spi`.

`main.spi` is the portable semantic mirror and returns 43 on C, Rust and Delphi. `source.c` is the retained C-shaped interop residual: it stores a Rust expression template in a string and calls `Fable.Core.RustInterop.emitRustExpr` with a `TupleCreate2` argument pack. The Rust lowerer substitutes `$0` and `$1`, removes the transport-only string, decodes the base64 payload and emits:

```rust
v0.wrapping_mul(v1).wrapping_add(3)
```

The focused gate compiles the direct residual with warnings denied and also compiles the Spiral mirror through both portable backends. This is target-specific macro evidence; it is not counted as a Delphi macro capability.
