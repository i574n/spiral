# Package-owned type parity

This fixture keeps `Tuple0` in the implementation-owner module `types/record` and moves `method0` into the sibling package module `consumer/use`. The consumer function accepts `Tuple0` in its public signature and calls the owner helper `TupleSum0`, so both type use and callable use derive the same module dependency.

`portable-provenance.tsv` uses schema 2 rows:

```text
definition<TAB>method0<TAB>consumer/use
type<TAB>Tuple0<TAB>types/record
```

Rust emits `Tuple0` from `types_record` and imports it into `consumer_use`. Delphi emits the record in `SpiralTypesRecord` and places that unit in the consumer interface. Both native packages return 42.

The `invalid` project declares the type under a non-owner module and must fail with `SPIRAL_PROVENANCE_TYPE_RELOCATION_UNSUPPORTED`. The `missing` project names a type absent from the generated owner source and must fail with `SPIRAL_PROVENANCE_TYPE_NOT_FOUND`.

The current contract proves package ownership and cross-package consumption for an already-emitted non-recursive value type. It does not relocate type declarations, split recursive type families, or infer ownership without an explicit sidecar.
