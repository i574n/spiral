# Dynamic array resize alias

Positive Spiral-bin fixture for Rust, Delphi and the C oracle.

The program allocates four `i32` values, aliases the array across residual function calls, shrinks the logical length to two, grows it back to four without losing the shared backing store, writes through the alias and observes both logical length and capacity.

Rust lowers the array to `Rc<RefCell<Vec<i32>>>`. Delphi uses an explicit reference-counted class with separate `Length`, `Capacity` and backing `Data`. The C residual is validated with `scripts/dynamic-array-resize-c-shim.h`, which models the bounded capacity-four oracle used by this fixture.
