# Portable target items and metadata

This fixture transports backend-specific top-level item bodies through ordinary Spiral strings while carrying target-neutral item metadata separately. No fixture name is embedded in the compiler.

The item body marker remains:

```text
SPIRAL_TARGET_GLOBAL_<TARGET>_<POSITION>_<IDENTITY>_B64:<UTF-8 payload encoded as Base64>
```

The generic metadata marker is:

```text
SPIRAL_ITEM_METADATA_TEST_<IDENTITY>
```

Portable lowering joins metadata to an item by identity. Rust projects `TEST` as a real `#[test]` attribute. Delphi emits the explicit no-op comment `// spiral-item-metadata: test` before the corresponding procedure. Missing identities and conflicting item declarations fail before an output file is committed.

The Rust gate compiles both the normal binary and a `rustc --test` harness, then executes the exact generated test. The C authority remains valid and executable while retaining the neutral transport markers.
