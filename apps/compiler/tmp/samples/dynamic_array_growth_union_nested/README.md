# Nested managed-growth ownership fixture

This fixture proves that a union can carry a fixed outer array whose elements are independently managed, resizable inner arrays.

Inside the union match it reserves the left inner array geometrically, shrinks and regrows the right inner array, writes through the surviving alias and observes both values after the outer union ownership has been consumed.

The portable backends must preserve the following contracts:

- the left inner capacity grows from two to four for a reserve request of three;
- shrinking the right inner array clears truncated storage before regrowth;
- the fixed outer container clones managed elements on set and clone;
- dropping one outer alias decrements child ownership without nil-ing shared slots;
- C, Rust and Delphi all return exit code zero.

The fixture was promoted from a deterministic type-error probe in v31 to a positive native parity gate in v32.