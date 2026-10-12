# Package-local mixed fixed arrays

This fixture proves that two fixed arrays with different scalar element types can be scalarized inside one owner function. `Array0` carries `int32_t`; `Array1` carries `bool`. Runtime-index getters must remain private and type-correct in Rust and implementation-only in Delphi. C, Rust and Delphi return 42.
