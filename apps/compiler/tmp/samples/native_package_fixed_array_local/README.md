# Package-owned local fixed array

This fixture proves that a fixed-size scalar array can be lowered inside a non-entry function and that the transformed function can be emitted in its declared package module. The array is scalarized locally; no array runtime or type crosses the package boundary.

Expected native exit code: 42.
