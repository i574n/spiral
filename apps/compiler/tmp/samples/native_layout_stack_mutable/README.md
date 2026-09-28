# Stack-mutable scalar layout

This fixture proves the first typed residual bridge for layout forms that the C backend cannot represent.

The source remains ordinary Spiral bottom-up code. For Rust and Delphi, the public compiler recognizes the typed `LayoutToStackMutable`, ordered scalar field writes, multiple `LayoutIndex` value snapshots and the terminal scalar addition before requesting a C residual. It emits a native stack record, preserves snapshot semantics locally, and returns 15 from `7 + 8`.

The C backend still rejects the same source with its exact historical diagnostic and leaves no residue. That negative remains intentional: the new bridge does not pretend C gained stack-mutable layouts.

Forms outside the typed scalar contract continue through the established residual pipeline or fail explicitly. This keeps the bridge narrow and prevents target-specific fixture workarounds from leaking into the compiler.
