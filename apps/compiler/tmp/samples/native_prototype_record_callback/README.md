# Native prototype record callback

This focused Spiral fixture mirrors the mature `shift` pattern used by the physics samples: a prototype with a related type, a nominal record state, and a real callback boundary.

The `derive` closure captures a scalar bias, receives the current state record, returns a related `delta` record, and is invoked through `join`. The compile-time `shift` instance consumes that related record and updates the state. C, Rust, and Delphi must all exit with code 42.

The residual must reuse the existing tuple/record and closure machinery. No prototype, instance dictionary, Rust trait or impl, Delphi class, virtual dispatch, or target-specific receiver transport may survive specialization.
