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

## Session 2026-09-28 (evening): splitter + hopac iteration

- Hopac fixes 18-20 (`lanes/hopac/FRONTIER.md`): join point parameters permuted against their arguments
  (`tuple_mixed`, `portable_composite`), tail calls lost for nominal returns
  (`native_managed_array_tail_recursion`), `if` conditions replayed ahead of earlier statements. All three
  verified on their fixtures and on frontier+smoke (8/8, 36/36, native 0 DISAGREE). A wide
  `-Suite examples,contracts -Native -Parallel 1` run was started to check for regressions (the first
  attempt at 2 workers was killed for low memory); read its result before calling fix 20 done.
- Splitter: stable gears and part numbers across emissions (`spiral-split-gears/src/gear_anchors.rs`,
  `SPIRAL_GEAR_ANCHORS`) and surface-aware dependent rebuilds in `scripts/gear-dev.ps1`. Adding a
  top-level `let` to the hopac core: 1 gear, 92 s end to end (was 75 gears, 1,056 s); removing two: 2 gears,
  103 s. The split compiler passes frontier+smoke (one `frontier_try_item` run hit the 15 s budget; the
  split gears are unoptimized, so they run close to it; 2 reruns passed). Details: `lanes/splitter/README.md`.
- The split loop is now the fast path for hopac edits: `pwsh scripts/gear-dev.ps1`, then
  `$env:SPIRAL_COMPILER_DLL = <printed path>; pwsh scripts/test.ps1 -Mode hopac ...`.
- Hopac runs rewrite in-tree sample outputs: before committing, rerun single-flight on the touched suites
  (`pwsh scripts/test.ps1 -Suite frontier,smoke,examples,contracts -Native`) so the committed outputs are
  single-flight's again.

## Session 2026-09-28 (night): both cores in one file

- `apps/compiler/spiral_compiler.fs` now holds both cores: 6 shared sections and 33 whole-section
  `#if SPIRAL_CORE_HOPAC` / `#else` pairs (rules in `AGENTS.md`, upstream strategy in `README.md`, "Upstream").
  The merge was generated and checked without a build: projecting single-flight gives the old file byte for
  byte, hopac gives the old hopac core up to whitespace-only lines (its notebook export put one after every
  declaration). `compiler/cores/hopac/` is gone; the pre-merge files and the one-shot merge script are in
  `<cache>/core-backups/20260928-203025/`. Single-flight builds from the merged file (0 warnings).
- **Not yet done**: the hopac build from the merged file (waits for the memory-heavy wide run), then hopac
  frontier+smoke to confirm the projection builds and behaves like before; the first `gear-dev` run after
  the merge rebuilds most gears once (shared sections now have single-flight's blank lines).
- **Unifying pairs** is where copying stops. Order: IR types (the `PartEval` type definitions: `Data`, `TyV`,
  `TypedOp`, join point keys), then codegens behind one small interface for fetching a method/closure body
  (dictionary vs `jpBodyCellAwait`), then the small pairs. Smallest by lines differing (single-flight-only /
  hopac-only, blank lines ignored): VSCTypes 4/2, RefCounting 5/6, WDiffPrepass 7/7, startParentWatcher 4/4,
  Graph 8/45, SpiralHub 15/16, SpiProj 18/17, CodegenDelphi 14/14, CodegenRust 21/23, Tokenize 17/35,
  HashConsing 0/23, PersistentVectorExtensions 0/146. Keep the shared text single-flight's, move hopac
  telemetry (`DiagJson.emit`) out of shared sections, and treat single-flight's own lines as behaviour
  changes for hopac (verify both builds and both lanes' tests per batch).
- Upstream: the i574n fork (`polyglot/deps/The-Spiral-Language`) is the sync pivot; record the fork commit the
  sections correspond to before the first sync (README, "Upstream"). `scripts/upstream.py` (status, import,
  export) moves edits between sections and the fork's files.
- Unified so far: `VSCTypes`, `HashConsing` (hopac's locked version for both), `PersistentVectorExtensions`
  (hopac's diagnostics helpers moved into a hopac-only `HopacRuntimeHelpers` section before it),
  `CodegenUtils` (hopac's superset), `RefCounting`, and the Rust and Delphi backends through a new
  `CodegenAdapter` section pair (before `CodegenRust`): union tag text, layout key matching, method key
  arguments, method/closure body lookup, memo tables and RefCounting's decrement table, each in the form
  its core needs. Sharing single-flight's Rust text gives hopac single-flight's union case tags
  (`case_tag`, where hopac used the case's position). Single-flight builds verified after each step; the
  hopac build is pending. 26 pairs left.
- `Tokenize` is a behaviour choice, not a merge: hopac's side changes triple-quoted strings (newline placed
  before a continuation line instead of after it, empty lines handled) and drops `inline` on the lexer
  state. Decide the triple-string semantics with a test fixture first (no sample uses `"""` today).
- `CodegenC` is shared too (single-flight's text through the adapter, plus hopac's
  `preservesDuplicateGlobalFragment` fix): 26 of 29 sampled programs give byte-identical C before and after,
  the other 3 are the same expected rejections. 25 pairs left.
- Left as pairs on purpose: `CodegenFsharp` (hopac's side carries ~560 lines of join point body resolution:
  owner materialization, replay drains, recovery; the adapter's simple await would bypass them),
  `CodegenCpp`/`CodegenPython` (real feature differences, e.g. hopac's typed macro control, union tag tables
  and object-dtype array literals in Python; no fixtures cover them), `Tokenize` (above).
- Lua and Gleam are shared too (single-flight's text, so hopac gets single-flight's newer Lua union payload
  handling); `#nowarn 40` moved above the prelude pair so hopac's build stops warning on the shared
  backends. All six native backends (C, Rust, Delphi, Lua, Gleam through the adapter; RefCounting) now have
  one copy. Pairs left (24): prelude, `spiral_compiler`, Utils, Tokenize, BlockParsing, HopacExtensions,
  BlockBundling, Infer, Prepass, PartEval, CodegenFsharp, CodegenAdapter (intended), CodegenCpp,
  CodegenPython, WDiff, WDiffPrepass, SpiProj, Graph, ServerUtils, SignalRSupervisor, new_server,
  startParentWatcher, SpiralHub, main; one hopac-only section (HopacRuntimeHelpers). Their differences
  are mostly hopac's concurrency/performance adaptations (`HopacExtensions.S.*` = `Array.*`,
  `ConcurrentQueue` for `ResizeArray`, a tag allocator for `dict'.Count`, `FastRuntimeFormat` for `sprintf`)
  plus a few real fixes to keep (e.g. hopac's `preservesDuplicateGlobalFragment` in `global`).
- The three single-flight "regressions" after the translator cut are translator-only features:
  `native_fptr_basic`/`native_fptr_reuse` need function pointers (`YFun .. FT_Pointer`), which upstream's C
  backend never had (only the C++/Cuda one: `typedef` + `FunPointerMethod{tag}`); `native_layout_stack_mutable`
  needs stack-mutable layouts, which the C and Rust backends reject by design. Like the 16 translator-only
  fixtures before, they are dropped (harness entries removed; delete the three directories once the running
  wide hopac run has finished). Porting function pointers to C/Rust/Delphi from the C++ backend is an
  option if native callbacks are wanted.
- IR plan (the codegen pairs): the IR types differ only systematically: union tags (`UnionTagId` vs
  `string`), layout keys (`LayoutFieldNameId` vs `string`), join point owners (`JpBodyOwnerIdentity` vs
  `string ConsedNode * E`, and the method key carries its range type), `ReFunction`'s annotation identity.
  Give single-flight tiny definitions of hopac's names (`UnionTagId = string`, `UnionTagIdOps.text = id`,
  `LayoutFieldNameIdOps.matchesText`, per-mode `method_body`/`closure_body`), then the IR types and the
  codegens can be shared text compiled by both.

## Session 2026-09-29: merged core verified on both lanes

- Hopac builds from the merged file (0 errors) and gives the same frontier 8/8, smoke 36/36, native 0
  `DISAGREE` as before the merge, with the unified sections and the shared Rust/Delphi/C backends. Single-
  flight: frontier, smoke and examples as before, minus the C closure `NATIVE-DIFF`s (fixed, below). The three
  translator-only fixtures are deleted. In-tree outputs restored with single-flight after the hopac runs.

## Session 2026-09-29: wide hopac run, C closure fix

- Wide hopac run after fixes 18-20 (`<cache>/runs/hopac-20260928-201051`, examples+contracts, 1 worker, 2h09):
  examples 413/461 parity (44 missing), contracts 585/607 (21 missing, 4 crashes), native 7 build
  failures (21 before), 0 `DISAGREE`. Against the post-fix-16 run: `tuple_mixed`, `portable_composite` and
  `native_managed_array_tail_recursion` now agree on C/Rust/Delphi; `managed_string_codepoints` compiles for
  Rust and Delphi (it stalled); several mega sub-packages flipped to parity. To check: 4 compiler crashes with
  a stack overflow (exit 0xC00000FD: `contract_atomic_carbon_microgrid_clearing`,
  `contract_region_safe_robotic_surgery`, mega `antimirov_certificate`, `minimization_witness`; fix 20 now
  evaluates compound `if` conditions directly, on the stack, which is a suspect); 4 `WRITE_ABORT` on
  `native_string_utf8_*` (hopac's residual is much smaller than the file on disk: 5 KB vs 28 KB);
  `native_cube_direct` now compiles but its C references an undeclared `v1`; stalls at the build budget
  (`frontier_fib`, `dynamic_array_growth_union_managed`, two contracts), possibly timing.
- **C closure use-after-free (upstream bug, fixed in the shared `CodegenC`)**: `ClosureMethodN` copied the
  captured values out of the closure, then `ClosureDecrefN(x)` freed the closure and, through it, captured
  arrays the body then read (`native_closure_array_capture` 40 instead of 42; `managed_capture`,
  `multimodule`, `transport` 38). The host's C rewriting used to hide it. The method now takes a reference
  to each captured value before releasing the closure and the body owns them. Upstream's `CodegenC.fs` has
  the same code: a pull request candidate (`scripts/upstream.py export`).

## Session 2026-09-29 (morning): method bodies losing statements, replay repeating calls

- **Fix 21** (compiler stack overflows in the BigStack spawn): `BigStack.StackBudget` measures the stack left
  with `GetCurrentThreadStackLimits`; 0 crashes in 5 runs of the crash-prone contracts.
- **Fix 22** (`lanes/hopac/FRONTIER.md`): `native_cube_direct`'s `return v1` and `native_string_utf8_*`'s
  `return v25` (the `WRITE_ABORT`s) were not fixes 18-20 but the cooperative time-slicing of declared method
  bodies: resume continues in the previous slice's block while the body is read from a fresh one. Declared
  bodies no longer time-slice (budget 2^24); `SPIRAL_JP_SLICE_OPS` brings slicing back for repro. Both
  fixtures now match single-flight; frontier+smoke 8/8, 36/36, native 0 DISAGREE, and no resumes at all.
  The wide run of it is incomplete (below).
- `scripts/test.ps1 -Parallel` now defaults from the machine (hopac ~3/8 of the CPUs, single-flight half,
  capped by free memory: 3 workers here); see `AGENTS.md`.
- **Replay repeating join point calls** (open, fix half done, UNCOMMITTED CORE EDITS, see below): hopac's `main`
  in `native_string_utf8_validate_source` called `utf8_validate_loop0` seven times (single-flight: twice).
  Repro: `samples/frontier_replay_repeat_call` (`inl a = sm.utf8_validate "abc"`; single-flight emits 1 call,
  hopac emitted 4). Not in `tests/harness.psd1` yet and has no committed outputs: add it, or run it with
  `spc`-style direct compiles. `SPIRAL_DEBUG_TERM_TRACE=core/sm.spi:135` shows every extra application
  coming from the replay driver alone (the direct evaluator never runs it): `runReplayDriver` →
  `tryApplyReplayDataWithContext` → `tryRunApplyAfterDefinitionAt` → `runApplyAfterDefinition`, once per
  driver tick, into the same block. The `CellShapeEApply` case of the driver (`EvalWorklist`, ~line 85060)
  re-applies whenever the cell is ready, with no "already applied" check, and reads the argument values
  through `tryTerm` thunks, which recompute (fresh `DV`s).
  In `spiral_compiler.fs` now (hopac-only `EvalReplayValueStore`, ~line 66380 and ~68540), built only as
  **Debug** (`bin/hopac/.../Debug`), Release not rebuilt:
  1. `tryRunApplyAfterDefinitionAt` / `tryRunDynamicJoinApplyAfterDefinitionAt` refuse nodes the direct
     evaluator owns (`isDirectNodeOwned`, fix 14's guard). Alone: 4 → 3 calls.
  2. A memo of completed replay apply steps per node, keyed by scope block (`installReplayScopeKey`, installed
     next to `installAnnotTestBranchAfterDefinition` as `LangEnv.seq`), function and argument. With it:
     repro 2 calls, `native_string_utf8_validate_source` 4 (was 7).
  3. A diagnostic row `eval_worklist_replay_apply_memo_miss` (same_scope/same_head/same_arg). The remaining
     miss: same scope, different function and argument (`DV`): the argument thunks re-emit. Remove the row
     once fixed.
  Next: make the `CellShapeEApply` driver case (and the whole-spine thunk at ~163570) not re-apply a node
  whose value the replay already committed (e.g. a committed-node set set by `putTermValue` after an apply
  and checked before applying; `putTerm` registrations must not overwrite it), then drop the memo if it is
  no longer needed. Verify with the repro, the utf8 fixture, frontier+smoke, then a wide run.
- **Wide run of fix 22 is incomplete**: stopped at the user's request. `<cache>/runs/hopac-20260929-071704`
  (`-Parallel 3`, Release = fix 22 only) reached 386 of ~1,154 jobs: ok 209, error 177, 0 timeouts, 0 crashes.
  An earlier 1-worker attempt (`hopac-20260929-065121`, 246 jobs) was stopped to switch to parallel. Rerun:
  `pwsh scripts/test.ps1 -Mode hopac -Suite examples,contracts -Native` (the default is now 3 workers here),
  after rebuilding Release (it will then include the unfinished replay edits above: finish or revert them
  first, or build fix 22 alone from a copy).
- In-tree `samples/` outputs were rewritten by the hopac runs: restore with single-flight
  (`pwsh scripts/test.ps1 -Suite frontier,smoke,examples,contracts -Native`) before committing.
- The two single-flight `REGRESSED` contract rows of the last restore run
  (`mega_omniledger_erp_kernel/negative_direct_marker_sync`,
  `mega_spiral_proves_spiral_relative_consistency/negative_application_argument_function_branch_mismatch`)
  are timeouts under load: compiled alone, both give the expected rejection in 7 s.
- `scripts/upstream.py export ... --since <repo-ref>` exports only the edits made since a commit of this repo,
  as the fork's files (README, "Upstream"); `--since cd17d19` gives the C closure fix for a pull request.
- `scripts/build.ps1` stamps the staged core copy, so building an older file with `-CoreSource` (a backup)
  is no longer a silent no-op.

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
4. **Hopac**: replay repeating join point calls (above), then the build-budget stalls and the `EJP0035`
   closure branch. (`tuple_mixed`, `portable_composite` and `native_managed_array_tail_recursion` were fixed
   by fixes 18 and 19.)
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
