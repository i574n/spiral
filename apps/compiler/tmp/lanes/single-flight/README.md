# Single-flight lane

The stable compiler: the sequential evaluator plus the portable Rust and Delphi backends.

- Core: `apps/compiler/spiral_compiler.fs`, the repo's main compiler source (its typed-IR C backend is the
  semantic oracle).
- Backends: `compiler/host/PortableBackends.fs` lowers C residuals to Rust (`Rc`, `RefCell`, native
  `Option`) and Delphi/FPC (`AnsiString`, reference-counted classes). See `PORTABLE_BACKENDS.md`.
- Proof: `pwsh scripts/test.ps1 -Suite examples -Native` builds and runs every C/Rust/Delphi residual;
  Rust and Delphi must agree with C (`oracle` column). `<cache>/scoreboards/single-flight.tsv` is the last recorded run.
- Known wall: compiling the full `apps/spiral` app overflows the stack.

## Known gap: rejected programs report no diagnostic

159 of the 162 negative contract cases (`samples/contract_*`, e.g. `contract_illegal_transition`) are
rejected with `BuildFile returned no code and no diagnostic arrived`: the program is refused, but the
type error never reaches the `--batch` result. The oracle therefore only checks *that* these programs are
rejected, not *why*. Surfacing the diagnostic in the host would turn them into real negative tests.

## Deferred: Rust backend fixes

The Rust lowering has known bugs, listed with reasons in `tests/harness.psd1` (`Known`) (SCC tail-loop `E0308`,
`fixed_array_runtime_index`, `dynamic_array_tuple_managed`). Fix them in `PortableBackends.fs`, run
`pwsh scripts/test.ps1 -Suite examples -Native`, remove its `Known` entry once the sample
builds and agrees with C, then `-Bless`.
