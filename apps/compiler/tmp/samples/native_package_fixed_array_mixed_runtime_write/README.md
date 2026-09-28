# Package-local mixed fixed arrays with bounded computed writes

This fixture proves that two fixed-size arrays with different scalar element types can be scalarized inside one package-owned function while accepting runtime-indexed writes only under an immediate, explicit bound proof.

The `int32_t` write computes its value from a private runtime read plus an owner-local scalar. The `bool` write computes its value from another private runtime read. Each write value is first materialized into one typed local, then the selected scalar slot receives that local. This preserves exactly-once evaluation while avoiding public setters and dynamic-array runtime dependencies.

Runtime reads remain private typed getters. The generated Rust and Delphi snapshots assert one materialization per computed write and reuse that materialized value across every bounded branch.

`negative-unbounded-write.c` removes the bound proof. `negative-wrong-bound.c` enumerates the wrong valid-index set. Both must be rejected before package emission.

The fixture does not define out-of-range behavior, interprocedural scalarization, escaped arrays, helper relocation, effectful expressions, or backend-switch behavior.
