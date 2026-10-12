# Rust union with a non-Clone payload

A case carrying `Box<dyn Fn() -> i32>` (no `Clone`): the generated enum doesn't `#[derive(Clone)]`. The stack union
then moves (no `.clone()` at its uses), its `match` takes the value and binds the field without a clone; the heap
union stays behind its `Rc` and binds the field by reference. C returns the same value; both exit with 49.
