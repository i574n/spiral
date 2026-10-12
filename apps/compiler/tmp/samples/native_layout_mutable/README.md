# Native heap-mutable layout

This fixture exercises the first mutable heap-layout slice shared by the portable Rust and Delphi backends.

The Spiral source creates a two-field scalar `mut` layout, replaces the whole record, indexes both fields, and returns 7. The C residual is retained as `source.c`; Rust and Delphi canonical outputs must compile warning-clean and exit with the same code.

Rust uses `Rc<RefCell<_>>`. Delphi uses an explicitly reference-counted class with create, assign, indexed getters, and final drop.

Not covered: managed fields, nested/composable layouts, layout references, or stack layouts.