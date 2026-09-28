# Native managed captured closure branch

This fixture selects at runtime between two ordinary closures that have the same managed capture layout. Each closure captures one generated Spiral `String`; the first computes `length("abc") + 39`, while the second computes `length("wxyz") + 39 - 1`. Both paths return 42.

The portable lowering merges the two closure implementations into one callable representation with a synthetic `variant` field. Because the capture signatures are identical, the primary lifecycle can safely release the selected string environment after invocation. Rust uses `Rc<str>` and Delphi uses `UnicodeString`; neither backend receives a target-specific fixture workaround.

`invalid.c` changes the second capture from `String *` to `Array0 *`. It must fail with the exact incompatible-layout diagnostic instead of coercing two managed environments.

The `.spi` file is the semantic source mirror. The authoritative round gate lowers the preserved source-shaped C residual because the facade source session can exceed the bounded execution window; no manually invented target output is used.

Expected process exit code: `42`.
