# Managed Array union closure

This source-real authority keeps a tagged union and its scoring function in `support.spi`, returns either `Empty` or `Values (array i32)` from one capture-free branching closure, and executes C, Rust and Delphi with result 42.

The concrete-copy fixture reconstructs the destination by active tag. The `Values` branch clones only the managed array; the empty branch constructs a typed empty array placeholder. Both source and destination remain independent owners and are released symmetrically.

Rust package projection exports fields of public structs so the entry module can inspect the tag and active payload, matching ordinary C struct and Delphi record visibility. This does not claim nested managed records, multiple managed fields in one case, arbitrary aliasing, or direct backend registration.

Immutable source-output snapshots live under `snapshots/`. Root sidecars remain compiler-generated working outputs.
