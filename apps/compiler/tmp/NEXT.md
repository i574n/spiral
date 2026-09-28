# Where to resume (2026-09-28)

State at hand-off, and the open work in priority order. Details live in the lane docs linked below.

## Done in the last session

- Rust and Delphi are native backends in both cores (`codegenRust`, `codegenDelphi`, next to `codegenFsharp`).
  Neither core asks for C and translates it. Single-flight examples: Rust 103/104 and Delphi 102/102 agree
  with C natively; hopac frontier+smoke: Rust 11/11, Delphi 11/11. See `lanes/single-flight/README.md`.
- Compiler outputs live only next to their sources and are committed; a run replaces them and
  `git diff samples` shows what changed. `scripts/test.ps1` holds `<cache>/test.lock`.
- C-isms removed from the fixtures: `samples/core/operators.spi` uses built-in ops; per-backend code goes
  through `!!!!BackendSwitch`; C-runtime fixtures (`dynamic_array_*`, `abi_external_*`) are C-only in
  `tests/harness.psd1`; the 16 translator-only fixtures are deleted; stale `Known` entries pruned.
- Split compiler (`scripts/gear-dev.ps1`): plans stay stable across body edits (planning weights), the host
  links against surface copies of the gears, module-level `do`s run through `GearRoot.initialize`.
  See `lanes/splitter/README.md`.
- Hopac fix 16 (replayed `if` branches, `while_control`) and fix 17 (native backends ported); see
  `lanes/hopac/FRONTIER.md`.

## Session 2026-09-28 (late): eoie on the native backend, translator deleted

- eoie builds natively: `pwsh apps/eoie/compiler-contracts/test-regeneration.ps1 -CargoCheck -Test -CompilerContracts`
  passes (88/88 owners, cargo check, all tests incl. the `--check`/`--plan-ir` ones) and so does
  `compiler-contracts/test-attestation.ps1`. The regenerated `.rs` are copied into `apps/eoie/src` (uncommitted).
  Source fixes and the translator behaviours eoie relied on: `lanes/single-flight/RUST_LIBRARY_PLAN.md`, "Progress".
- Core (`apps/compiler/spiral_compiler.fs`): a failed type check's fatal now lists the package's typer errors;
  `codegenRust` emits `#![...]` globals before its `use`s (also in hopac); `params` renamed (reserved in F#).
- **Deleted**: `compiler/host/{PortableBackends,PortableUnionNormalizer,TuplePrune}.fs`, the older translator
  inside `Program.fs`, the typed-source path, C/F# output rewriting, `restoreC`, `--lower-portable*`,
  `lanes/single-flight/PORTABLE_BACKENDS.md`. Host builds clean (single-flight).
- **Unverified at hand-off**: `pwsh scripts/test.ps1 -Mode single-flight -Suite all -Native` was started after
  the cut and not reviewed. Rerun it; list output changes against the snapshot
  `%LOCALAPPDATA%\spiral-bin\samples-before-translator-cut.tsv` (path<TAB>sha256 of every sample output before
  the cut) or with `git diff samples`. Changed C/F# outputs show what the deleted lowering did; fixtures that
  only worked through the typed-source path will now go through the core. Triage (keep only useful ones),
  then bless (item 1 below).
- Result of that run (`<cache>/runs/single-flight-20260928-074405`): frontier 8/8, mega 5/5, contracts 606/606
  parity. REGRESSED: `native_fptr_basic` [C], `native_fptr_reuse` [C], `native_layout_stack_mutable`
  [Rust, Delphi] ("no code and no diagnostic"; most likely the deleted typed-source path compiled them, so
  check whether the core accepts these programs at all). NATIVE-DIFF [C]: six `native_closure_*` fixtures
  (C output changed now that it is no longer rewritten; check they still agree natively). Plus the two
  expected improvements listed in item 1. Do not bless before these are triaged.
- Not done: hopac build (it has the unbuilt Export port, `params` rename and inner-attribute hoist; do one
  build + `-Suite frontier`); `--plan-ir` is still eoie-specific host code (move its parser into eoie, plan
  doc); `rewriteRustEmitExpr` stays for `lib/spiral`'s Fable `emitRustExpr`; a failing *dependency*
  package still yields "no code and no diagnostic"; `"""` strings are unsafe for code (process-wide
  tokenizer flag); eoie's state receipts (`state/cold_proof.spi`, `differential_catalog.spi`,
  `runtime_drift.spi`) pin hashes/sizes of edited files, but `eoie status` already failed at HEAD
  ("missing evidence root"), so they could not be refreshed here.

## Open, in order

1. **Re-bless the oracle.** Every Rust/Delphi row of `<cache>/baseline/EXPECTED.tsv` still holds translator-era
   hashes and exit codes. Run `pwsh scripts/test.ps1 -Suite all -Native`, check there is no `REGRESSED`,
   `NATIVE-DIFF` or `DISAGREE` beyond the rows below, then rerun it with `-Bless`. Then commit the refreshed
   `samples/**/main.*` outputs that run wrote. (Slow: ~30 min.)
   Expected differences, all improvements: `managed_string_invalid_utf8_slice` (Delphi now exits 3 like C),
   `dynamic_array_bounds_negative` (Delphi exits 0 like C; Rust panics, a `Known` row).
2. **Rust libraries and exports for eoie**: `lanes/single-flight/RUST_LIBRARY_PLAN.md`. Then delete
   `compiler/host/PortableBackends.fs` and everything that calls it (the host still runs its
   `lowerPortableBackend`/`tryLowerPortableSource` on C and F# output; verify that is a no-op for the
   remaining fixtures before removing it).
3. **Split compiler rebuild**: the core gained top-level declarations, so the split plan moved.
   `pwsh scripts/gear-dev.ps1 -Force` (~20 min at `-MaxNodes 2`), then
   `$env:SPIRAL_COMPILER_DLL = <printed path>; pwsh scripts/test.ps1 -Mode hopac -Suite frontier,smoke -Native`.
   Then continue the user's goal: iterate on the splitter/hopac until every sample compiles with hopac.
4. **Hopac silent miscompiles** (`lanes/hopac/FRONTIER.md`, "Beyond smoke"): `tuple_mixed` and
   `portable_composite` (tuple elements permuted across a join point, `method1(v3, v2, v1)`),
   `native_managed_array_tail_recursion`. Then the ~25 build-budget stalls and the `EJP0035` closure branch.
5. **Mutual tail recursion in the native backends**: self tail calls are loops; a strongly connected group
   of methods that tail-call each other still recurses (covered by a 1 GB / 256 MB stack for now). Merge
   each group into one looping function with a state tag.
6. **Delphi memory**: FPC 3.2 classes are not reference-counted, so heap unions, mutable layouts and
   closures are never freed. Options: interfaces (ARC) or the `array of record` trick for mutable layouts.

## Workflow notes

- Rust/Delphi outputs are judged natively against C (`oracle` column); C is kept generic, as one backend
  among others (it is maintained upstream by Spiral's author).
- One `scripts/test.ps1` run at a time; a hopac run rewrites the committed outputs with hopac's, so rerun
  single-flight (or `git restore samples`) before committing.
- Don't poll background jobs with sleeps; memory-killed jobs are retried after freeing leftover `dotnet`
  build processes (`dotnet build-server shutdown`, orphaned `dotnet build`).
