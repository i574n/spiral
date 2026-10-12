# Dynamic array reserve from zero

Positive Spiral-bin fixture for Rust, Delphi and the C oracle.

The program starts with a zero-length dynamic `i32` array, reserves capacity without changing logical length, verifies that a smaller reserve request does not shrink capacity, grows to three elements, writes values, shrinks to zero and grows again. The regrown elements must be default-initialized rather than exposing stale values.

Rust uses `Vec::reserve_exact`, `Vec::resize` and `Vec::capacity` behind `Rc<RefCell<_>>`. Delphi uses its explicit reference-counted resizable array class with separate logical length and physical capacity. The C residual is validated with `scripts/dynamic-array-reserve-zero-c-shim.h`.