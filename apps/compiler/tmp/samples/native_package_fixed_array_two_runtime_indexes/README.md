# Package-local fixed arrays with two runtime indexes

This fixture proves that two fixed-size scalar arrays of the same residual type can be scalarized inside one package-owned function. Each runtime read receives a distinct synthetic getter (`ArrayGet9000` and `ArrayGet9001`). Both helpers remain private to `worker/fixed`, while `method0` remains the public package surface.

The positive path returns 42 in C, Rust and Delphi. The negative fixture places allocations in two different functions and must fail before lowering with `portable backend fixed arrays span multiple functions or owners`.

This is ordinary fixed-array parity. It does not add dynamic arrays, cross-owner helper transport, out-of-range behavior, `backend_switch`, or general interprocedural scalarization.
