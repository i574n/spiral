# Native heap reference layout

This fixture proves local scalar `heap_refs` semantics in the typed residual bridge. Rust uses one `Rc` object with `Cell` fields, Delphi uses one class instance, and aliases observe the same mutable storage. The final result is 42 and ownership remains local to `main`.
