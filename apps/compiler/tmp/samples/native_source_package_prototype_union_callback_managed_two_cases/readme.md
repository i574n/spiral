# Managed union callback with two String cases

This source-real package is the bounded authority for a capture-free closure that branches between two distinct managed union cases:

- `Text : string`
- `Note : string`

The positive gate proves C, Rust and Delphi return 42, Rust and Delphi lower both managed fields, clones are selected by the active tag for a concrete destination, and every source/target owner drops only its active payload.

The negative fixture keeps a clone without a concrete destination rejected. Managed captures, nested managed unions, multiple managed fields inside one case and general alias analysis remain outside this authority.

Canonical normalized backend snapshots live under `snapshots/`; root sidecars are compiler-generated source outputs and may be refreshed by source compilation.

Run:

```text
spiral/scripts/portable-managed-union-two-cases-gate.sh
```
