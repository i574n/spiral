# First source commit review — 2026-09-27

Scope: the EOIE source workspace and its supported single-flight compiler
integration. This is separate from certifying a distributable EOIE release.

## Verified on Windows

- Locked Cargo workspace tests, including all 17 optional compiler contracts:
  **76 passed, 0 failed, 0 ignored**. Registry dependencies are used; `vendor/`
  remains ignored. Build products and compiler scratch output remain ignored.
- The process Rust owner regenerates from its Spiral source through `spiral.ps1`.
  Earlier filesystem-action and process-budget policy migrations remain in Spiral.
- The native host typechecks the complete owning package, including modules after
  the input, without requiring `main`. EOIE's own Agile package check produced
  61 build attestations in one batch.
- Canonical Plan IR preserves string payload braces, rejects runtime-dependent
  operations, and enforces positive timeouts. The dedicated regression script
  exercises these cases and compiles and runs a specialized GADT through Rust.
- Git review excludes executables, archives, vendor, caches and build directories.
- The single-flight compiler builds cleanly. The changed Hopac host also builds
  cleanly against its cached core with output copying disabled because another
  process holds its published DLL. Hopac remains experimental.

The Windows/Linux CI matrix now builds the optional compiler and runs the
attestation regression script plus all EOIE contracts. Linux execution has not
been verified locally; the installed WSL probe did not finish starting.

## Remaining scope

`PORT-COMPILER-EXPORT-SURFACE` now has regeneration evidence for all 88 primary
Cargo owners: every source emits Rust and the isolated workspace passes locked,
offline `cargo check --workspace --all-targets`. Generated Rust remains committed
so ordinary builds do not depend on the compiler. Auxiliary probes and platform
adapters are checked as consumers rather than independently regenerated here.
The regenerated workspace also passes all **76 tests**, including the 17 optional
compiler contracts, builds a release executable and passes its schema smoke check.
Six export ABIs (I32, I32Binary, StringUnary, U64Unary, StringTuple5Unary and
U64String5) pass an external Rust consumer with three runtime tests and eight
rejection cases. The contracts cover UTF-8, input lifetime, tuple field order,
u64 width, duplicate markers and optimized-away parameters.

Regeneration exposed and fixed incorrect codec package imports, u64 string
lengths emitted as i32, and parameter names lost when used only by embedded
Rust expressions. The regeneration harness stages sources and products outside
the checkout and is included in the Windows/Linux CI matrix.
The review also fixed C line splitting that changed quoted `}new{` plan payloads;
adjacent block splitting now preserves strings and comments.

`PORT-STRICT-RELEASE` tracks a separately staged distribution, renewed hashes and
receipts, cold rebuild evidence and strict release validation. Historical Linux
evidence under `state/` does not certify this Windows source port. `generic`
archive success only verifies archive policy and cannot close this task.

The broader Rust compiler sweep after the return and closure fixes ran 136
fixtures: 113 emitted and ran natively, 23 rejected compilation and none timed
out. The five native build failures found before the return fix (fixed-array
getter and four SCC tail-return cases) now compile and run in focused C/Rust
tests; all agree with the C oracle. The fixed-array test also runs a negative
index to prove the final element fallback. Both managed-closure fixtures now
compile and return 42 after correcting their malformed package manifests; the
nested-closure output agrees with C. The managed tuple fixture also agrees with
C when both backends are selected. The seven-case C/Rust regression pass had no
build failures or oracle disagreements. Baselines remain unchanged, including
the newly verified native outputs. Twenty-six native examples recover compared
with the imported patch.

## Reproduction

Build the compiler with `apps/compiler/tmp/scripts/build.ps1 -Mode single-flight`, then run
`compiler-contracts/test-attestation.ps1` and the compiler's `scripts/test-rust-exports.ps1`.
Use `compiler-contracts/test-regeneration.ps1 -CargoCheck -Test -CompilerContracts`
to reproduce the isolated 88-owner regeneration and runtime validation.
Set `EOIE_DOTNET` to that compiler's .NET host
and `EOIE_SPIRAL_COMPILE` to its `SpiralCompiler.dll`, then run:

```powershell
pwsh apps/eoie/build.ps1 -Test -CompilerContracts
apps/eoie/eoie.exe agile check apps/eoie --compiler $env:EOIE_SPIRAL_COMPILE
```

Use `-Offline` only with a populated Cargo registry cache. See the README for
compiler relocation settings and generic versus strict bundle behavior.
