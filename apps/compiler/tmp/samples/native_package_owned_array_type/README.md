# Package-owned managed array

`types/record` owns the dynamic `Array0` runtime alias and a `Tuple0` that carries the array plus a scalar bias. `consumer/use` owns `method0`, consumes the record, drops the managed array and returns 42.

The focused gate proves C, Rust and Delphi execution, owner-preserving type provenance, public Rust array lifecycle helpers, Delphi interface visibility, relocation rejection and missing-type rejection. General type relocation and recursive package-owned families remain unsupported.
