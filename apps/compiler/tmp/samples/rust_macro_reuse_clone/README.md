# Rust macro splice of a reused non-Copy variable

A macro names its variables (it is target code), so a splice in a moving position leaves the variable moved:
`!v.into_iter()`, `match !o { .. }`, a call argument `f(!v)`, an `emitRustExpr` argument (`$0.into_iter()`), a
closure capture used by the next call, and a self-tail loop that passes the variable on. codegenRust tracks which
variables the rest of the function still uses (later statements, enclosing blocks, the rest of a loop, a closure's
captures) and clones such a splice; the last use stays a move. A `&mut self` method (`!w.push(4)`) keeps the
variable itself, so the later `!w.len()` sees the push. Before, rustc rejected the residual (E0382). C returns the
same value; both exit with 35.
