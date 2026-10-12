# Closure captures a dense scalar union

This fixture compiles one ordinary Spiral union through C, Rust and Delphi, captures the union by value inside a closure, invokes the generated closure method through `join`, and returns 42.

The portable lowering accepts only dense unions whose payloads are primitive scalars. A companion negative residual proves that a union carrying `String *` is rejected instead of being routed through the copy-only closure environment.
