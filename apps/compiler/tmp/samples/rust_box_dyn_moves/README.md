# Rust boxed trait objects move

A `Box<T>` type written as `Box<` followed by a type argument (lib/spiral's `rust.box t`) is Clone only when `T` is,
and never when `T` is a trait object (`dyn ..`, or the Fable alias `Dyn<..>` of `rust.dyn'`). Passing such a value to
a join point used to splice `v1.clone()`, which rustc rejects (E0599: `Box<dyn Fn() -> i32>` is not Clone); it now
moves. C computes the same value without macros; both exit with 22.