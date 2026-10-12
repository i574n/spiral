# Native closure recursive capture

This parity fixture captures an acyclic recursive Spiral union inside a closure, invokes the same closure twice after the source binding is released, and returns 42 from `(sum branch + 19) + (sum branch + 19)`.

The mature C/C++ ownership contract is the semantic authority. Rust retains the recursive root through `Rc`; Delphi preserves the original clone/consume sequence through explicit `ClosureValueClone` and `ClosureValueDrop` helpers backed by the existing recursive class ownership runtime. No backend-specific syntax appears in the Spiral source.
