# Rust global item macro

This fixture proves the generic `RustGlobal(StringLit(...))` transport used by the Rust library surface. The payload contributes an ordinary helper and a `#[cfg(test)]` module without adding fixture names or target-specific cases to the shared parser.

The direct Rust artifact exits with 47. Its test harness executes the injected `#[test]` function. The Spiral mirror returns the same value through C, Rust and Delphi; Delphi does not receive Rust syntax.

Prune markers are part of the transport contract: balanced `SPIRAL_PRUNE_BEGIN:<id>` and `SPIRAL_PRUNE_END:<id>` blocks may remove generation-only scaffolding before injection. Unbalanced or duplicate markers are rejected.
