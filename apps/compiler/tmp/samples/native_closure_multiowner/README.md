# Native closure multi-owner package

This project proves explicit definition provenance across three Spiral modules.

`transport` owns the callable transport function, `offset` owns a join-point function and the shared generated runtime, and `main` creates a managed-string closure. The `offset` function calls the explicitly owned `transport` function, proving a sibling module dependency instead of relying on the default owner. `portable-provenance.tsv` is an adjacent typed sidecar that maps emitted public symbols to declared library modules without inferring ownership from anonymous method numbers.

The Rust package emits `transport.rs` and `offset.rs`, imports `transport` from the owner module and records `dependency=offset module=transport`. The Delphi package emits `SpiralTransport.pas` and `SpiralOffset.pas`, with the sibling dependency in the implementation `uses` clause to avoid an interface cycle. Both linked programs exit with code 42.
