# Native closure multimodule

This fixture proves that a managed-string closure crosses a package boundary derived from the real Spiral `package.spiproj` module order. `transport.spi` owns `apply`; `main.spi` creates the closure and calls `transport.apply`. The portable project packager emits `transport.rs` plus a Rust binary, and `SpiralTransport.pas` plus a Delphi program. Both linked programs exit with code 42.

The current residual does not preserve function-to-source provenance. Until it does, the last non-entry module owns the flattened implementation; the module graph and this limitation are written into `spiral-module-graph.tsv`.
