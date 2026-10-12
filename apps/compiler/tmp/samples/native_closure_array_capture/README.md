# Native closure array capture

This parity fixture captures a Spiral array inside a closure, invokes it after the source variable is released, and returns 42 from `length items + 40`.

The C backend is the semantic authority. Rust must preserve the captured array through `Rc<RefCell<Vec<_>>>`; Delphi must preserve it through a reference-counted dynamic array. No backend-specific syntax appears in the Spiral source.
