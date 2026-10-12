# Native heap layout

This fixture exercises the first immutable heap-layout slice shared by the portable Rust and Delphi backends.

The Spiral source lowers `LayoutToHeap` into a two-field scalar layout, indexes it, and returns 19. The C residual is retained as `source.c`; Rust and Delphi canonical outputs must compile warning-clean and exit with the same code.

Covered: heap allocation, scalar fields, indexed reads, final release.

Not covered: managed fields, nested/composable layouts, layout references, stack layouts, or mutation.