# Native source-package prototype record callback

This fixture proves that nominal `state_t` and `delta_t` declarations may live physically in the transitive `model/state` package while `shared/advance` specializes a prototype and transports the records through a closure callback.

The package graph is linear: root depends on `shared`, and `shared` depends on `model`. Prototype and instance selection disappear before C, Rust, and Delphi residual emission. The portable provenance sidecar assigns `Tuple0` to `model/state` and `method0` to `shared/advance`, allowing the package projector to verify physical ownership and imports.

The raw persistent-session gate is separate. Raw server identity must include the compiler package directory, workspace root, and selected .NET host so a server created under one semantic environment cannot be reused under another.
