# Package-local fixed array with runtime index

This fixture proves that a fixed-size scalar array can be scalarized inside the package-owned `worker/fixed` routine while a bounded runtime index is served by a synthetic getter that remains private to the owner module.

The C authority creates three values, reads the element selected by `index`, adds the first element and returns 42. Rust and Delphi must emit the same module graph without exporting `ArrayGet9000` or carrying dynamic-array runtime across the package boundary.
