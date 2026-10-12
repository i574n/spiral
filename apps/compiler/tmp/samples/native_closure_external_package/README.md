# Native closure external package

This fixture proves a real non-included Spiral package dependency. The root application declares `shared` in `packages:` and contains only the `main` module. The sibling package under `packages/shared` owns `transport` and `offset`.

The portable project packager namespaces dependency modules as `shared/transport` and `shared/offset`, then emits `shared_transport.rs` and `shared_offset.rs` for Rust and `SpiralSharedTransport.pas` and `SpiralSharedOffset.pas` for Delphi. The shared manifest records the package, module ownership and the cross-module dependency. Both native programs exit with code 42.

Compiler-directory or included packages such as `|core-` remain outside the native project graph. Nested non-included package dependencies remain deliberately rejected until they have a separate cycle and provenance authority.
