# Rust `json`/`borsh` take self

near-workspaces' `ExecutionFinalResult::json(self)`/`::borsh(self)` (and reqwest's `Response::json(self)`) move their
receiver. A spliced variable that is used again is cloned before `.json()`/`.borsh()`, like before the other methods
that take `self`; the last use moves. Before, `v1.json()` then `v1.borsh()` was rustc's E0382. C computes the same
value without macros; both exit with 22.