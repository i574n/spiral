# dynamic_array_resize_union_managed

This fixture combines a managed union payload with a resizable dynamic array, an external alias, reserve, grow, shrink, regrow and repeated consumers.

The native programs must exit with code 0. The fixture observes `DynamicArrayRefCount0` immediately before the final consuming drop and encodes an expected baseline of exactly one live reference in the exit expression.

It guards the portable lowering boundary where dense-union normalization, dynamic-array rebinding, explicit clone/drop operations, tuple-field movement and backend-specific ownership intersect. Rust must preserve shared values through `Rc` clones without borrow-after-move residue. Delphi must retain the residual ownership graph without inventing additional conservative clones.
