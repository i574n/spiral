# Rust string literal spelled with a path

codegenRust's last pass (`cacheRustStringLiterals`) builds every string literal `Rc::<str>::from("...")` once per thread
and clones it. Macro text may spell the same literal with its path, as lib code that does not rely on the residual's
`use std::rc::Rc` does: `std::rc::Rc::<str>::from("")`. The pass used to rewrite only the `Rc::<str>::from(..)` suffix,
leaving `std::rc::{ thread_local!{..} LIT.with(..) }`, which rustc rejects (`expected identifier, found {`; seen in
eoie's command_spec.rs). Now `std::rc::` / `::std::rc::` literals are cached as a whole (the path kept inside the
block) and a literal behind any other path (`crate::Rc::..`) or identifier is left as written.

`main.spi` mixes the three path spellings, a bare `Rc::<str>::from` in a macro, a Spiral literal and an empty literal
inside a closure; Rust sums their lengths plus 3 and exits with 20. The C row (a `BackendSwitch` constant) is the oracle.
