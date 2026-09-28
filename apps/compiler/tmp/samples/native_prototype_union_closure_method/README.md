# Prototype-resolved union closure method

This fixture proves that a real Spiral `prototype`/`instance` selection over a dense scalar union is fully resolved before portable code generation. The selected instance executes inside a closure that captures the union, and C, Rust and Delphi all return 42.

The Rust and Delphi residuals reuse the ordinary `Tuple9000`, `ClosureValue0` and `ClosureInvoke0` forms. No Rust trait or `impl`, Delphi class or virtual method, target-specific dictionary, or residual prototype marker is introduced.

The companion `native_prototype_union_closure_method_missing_instance` fixture proves that a missing instance is rejected by the Spiral type checker before any target output is created.
