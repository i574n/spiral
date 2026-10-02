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
- `File main has a type error somewhere in its path.` now lists the typer's errors of every package, not just
  the entry's (both cores' `BuildFile`): an error in a dependency used to come with no detail at all.
- `scripts/test.ps1 -Parallel` now defaults from the machine (hopac ~3/8 of the CPUs, single-flight half,
  capped by free memory: 3 workers here); see `AGENTS.md`.
- **Fixes 23 and 24** (`lanes/hopac/FRONTIER.md`): replay no longer repeats applications into a block the
  direct evaluator is building, nor re-applies one it already applied (repro
  `samples/native_replay_repeat_call`: 1 call like single-flight, was 4; utf8 fixture 2, was 7); and replayed
  applications get their arguments in order (`Expected a string. Got: i32` in two utf8 fixtures, reduced to
  `f "abc" 1i32`). Verified on Debug builds with direct compiles; suite results below.
- **Batch (late 2026-09-29)**: fix 28 (nominal-wrapped functions dyn like single-flight), more ledger and
  digest performance work, host accepts F# scripts ending in an expression; then one `-Suite all -Native`
  hopac run (results in FRONTIER.md when it lands). The `native_source_package_prototype_*` rows are parity:
  the oracle expects the rejection, and single-flight rejects them too (their nested packages use `+.`, which
  only the harness core defines).
- **Evening 2026-09-29**: fix 25 (closures in runtime `if` branches, the `EJP0035` wall: two closures shared
  one promise identity) and fix 26 (performance: lazy path/lineage digests, incremental work-ledger counts,
  `Environment.ProcessId`; profile and numbers in FRONTIER.md). A `frontier,smoke,examples,contracts -Native`
  run of fixes 21-25 reached 1,011 of ~1,100 jobs before a low-memory reap: 956 match the oracle (937 in the
  fixes-18-20 run on the same rows), 31 rows fixed, no real regressions (the 10 load-induced stalls pass
  alone; 2 rows are the mega fixture/oracle problem). Profiling tools: `dotnet-trace`/`dotnet-stack`
  installed with `--tool-path` in the session scratch (reinstall the same way, not globally).
- **Wide run of fix 22 is incomplete** (superseded by the run above): stopped at the user's request. `<cache>/runs/hopac-20260929-071704`
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

## Session 2026-09-30 (night): batched hopac fixes 31-33

- Full run `<cache>/runs/hopac-20260929-231443` (fixes 22-30 + perf): contracts 590/607 parity (was 578),
  examples 430/453 (was 409), mega 2/5, native 1 DISAGREE (Rust `managed_string_invalid_utf8_slice`,
  pre-existing). Seven contracts that stalled before now compile. Left: 20 UNEXPECTED-OUTPUT from the
  host's "(expression)" entry (single-flight rebuild + re-bless), 5 mega parse errors, 6 brzozowski
  sub-packages and `mega_lean_cic` stalling in partial evaluation (single-flight: 1.5-8 s).
- Fixes 31 (host keeps `ParserErrors` as detail instead of ending the build, like single-flight), 32
  (500 ms graces → 20 ms, `DiagJson.emit` filters before enriching; jsonl mirror pruning in `test.ps1`),
  33 (dependency type errors hung `BuildFile`), in FRONTIER.md. Release built with 31-32 and the first
  half of 33: `frontier_hello` 3.9-4.6 s (was ~8), fix 31 verified; the prototype rows still stalled,
  hence the null-slot half of 33, which is **not built yet**. Next full run: `<cache>/runs/hopac-20260930-00*`.
- Full run `<cache>/runs/hopac-20260930-002911` (fixes 31, 32, first half of 33): contracts 591, examples 430,
  frontier 8/8, mega 3/5 (`lean_cic` compiles in 77 s, was a 178 s stall), compile phase 2,719 s (was
  3,046 s), native 1 DISAGREE (same row). Missing: only 8 rows. Seven are partial-evaluation slowness: five
  brzozowski sub-packages at ~28 s (single-flight 1.5-3.7 s), and the omniledger and spiral_proves roots
  at 178 s, which parse now. The eighth is `antimirov_typed_slot_bound`, replay values shared between
  evaluations (fix 34, partial).
- Full run `<cache>/runs/hopac-20260930-013153` (fixes 33b, 34 memo key): contracts 591, examples 426,
  mega 2/5. Slower overall (3,085 s), because trace analyses ran alongside it. Four `native_cube_*_direct`
  [C] rows stalled at 17.9 s (load, or the fix 34 memo key: check alone). `derivative_runtime_gadt` hit
  the fix-34 union-unbox mismatch, hence the second half of 34. Batch 35 (perf, `SPIRAL_DIAG_QUIET`) and
  34b were being built next.
- Build of 34b + 35 (quiet mode, ledger counters, credit/classifier memos): `frontier_hello` 2.7-3.3 s,
  brzozowski `antimirov_typed_slot_bound`/`derivative_runtime_gadt`/`finite_inventory_adversarial`
  12-14 s at 3 workers (were 23-28 s), `native_cube_frame_direct` [C] 5.4 s (its suite stalls were
  load). Full run `<cache>/runs/hopac-20260930-02*` started with it.
- Open: `mega_brzozowski_derivatives/negative_raw_regex_not_positioned_bound` still stalls at
  `typecheck_await_scheduled` (parity: expected rejection, but 28 s). A direct compile with
  `SPIRAL_DEBUG_TYPECHECK_WAIT=8` printed nothing although `file_build` emits that stage right before the
  watchdog. Either the watchdog's `states` list (`packages_infer`) throws, which would also abort
  `file_build`, or stderr is lost at the forced exit. Wrap the start of `file_build` in a try that sends
  the exception as a fatal.
- Full run `<cache>/runs/hopac-20260930-024800` (fixes 34b + 35): contracts 596/607, examples 430/453,
  frontier 8/8, mega 3/5, compile phase 2,438 s. Real misses: `spiral_proves`, `lean_cic` (load-dependent),
  brzozowski `antimirov_certificate`. The rest is the host "(expression)" re-bless and new fixtures.
- Fixes 36-37 (FRONTIER.md): producer records compared by reference, lazy credit digests and snapshots,
  quiet-mode HUD/heartbeat/handoff savings, `file_build` setup guard. `spiral_proves` alone: 151 → 65 s.
  `SPIRAL_HOPAC_WORKERS=3` measured no better than the default. Full run `<cache>/runs/hopac-20260930-0413*`.
- Estimate (2026-09-30, 04:00), how far hopac is from compiling everything single-flight does: ~700/1000.
  Suite parity is ~97%, but the tail is the hard part:
  - mega roots take minutes against seconds;
  - the replay store keys values per AST node, not per evaluation (fix 34: timing-dependent wrong values);
  - `apps/spiral`, the promotion criterion, has not been attempted since the early lanes.
- Full run `<cache>/runs/hopac-20260930-041329` (fix 37): **mega 5/5** for the first time (lean_cic 43 s,
  omniledger 52 s, spiral_proves 149 s of its 180 s budget), contracts 596/607, examples 430/453, frontier
  8/8, native 1 DISAGREE (Rust `managed_string_invalid_utf8_slice`). The only real miss:
  `mega_brzozowski_derivatives/antimirov_certificate`, the fix-34 replay mix-up, which is a race: alone it
  compiles, at 1 or 8 workers. Everything else "missing" is the host "(expression)" re-bless and new
  fixtures.
- Race 38 is narrowed down (FRONTIER.md): type checking finishes and the fatal is sent, but the host never
  turns it into a result. The loss is between `errors.fatal` and the host's `DiagnosticRouter`. The
  watchdog now also writes `%TEMP%\spiral-typecheck-wait-<pid>.txt`.
- Two races left, both in FRONTIER.md: 34 (replay values per AST node, not per evaluation: wrong-type
  branch values now and then) and 38 (multi-package type checking sometimes never answers; parity rows,
  28 s each).
- Estimate after this session: ~750/1000. Parity is ~99% of the suite rows, but the remaining work is the
  hard kind:
  - the two races;
  - speed: mega roots 40-150 s against 1-8 s in single-flight;
  - `apps/spiral`, the promotion criterion, not attempted yet.
- **Final run of the session** `<cache>/runs/hopac-20260930-050954`: frontier 8/8, contracts 597, examples 430,
  mega 5/5, **no `missing` rows** (FRONTIER.md status table). Then single-flight was rebuilt with the
  current host, and a full `-Suite all -Native` run (`<cache>/runs/single-flight-20260930-055401`) restored
  the in-tree outputs.
- That single-flight run: contracts 597 parity, examples 430, frontier 4 + 4 new, mega 5/5. There are no
  `REGRESSED` rows and the same 3 NATIVE-DIFF rows (the Rust `managed_string_invalid_utf8_slice` DISAGREE is in
  both lanes: a single-flight Rust backend issue). **The same 21 UNEXPECTED-OUTPUT rows as hopac**, all
  `entry=(expression)`: the host now accepts F# scripts ending in an expression, in both lanes.
  Re-blessing the oracle (`pwsh scripts/test.ps1 -Suite all -Native -Bless`, single-flight) turns them into
  parity. Review first: they are
  `contract_arithmetic`, `contract_record`, `branch_select`, `dynamic_array_{bool,f64,function_boundary,
  record,return,runtime_length}`, `gadt_specialized_case_rank`, `portable_composite`, `record_value`,
  `recursive_union_mutual`, `tuple_mixed`, 4 `mega_brzozowski_derivatives/compiler_probe_*`, and 3 mega
  `negative_*` sub-packages. Those last seven are mega fixtures whose "negative" programs single-flight
  compiles; oracle rows the earlier host only rejected by accident.
- Git state: the working tree has single-flight's outputs. The **index** (staged by the user) still holds
  94 sample outputs from an earlier hopac run. For example, the staged `dynamic_array_function_boundary/main.c`
  has the duplicated `method0` call of the replay bug fixed in fix 23. `git diff -- samples` shows them;
  restage the working tree's versions before committing.
- Next targets: build fix 33's second half and fix 34; profile `mega_brzozowski_derivatives/finite_inventory_adversarial`
  (hopac >28 s in partial evaluation); stack-dump `mega_lean_cic_bottom_up_kernel` (>172 s).

## Session 2026-09-30 (day): stability and speed toward apps/spiral

- **Fix 38 resolved**: both cores' `new_server` dropped diagnostics raised between two pulls of the client
  stream (`Async.AwaitEvent`), often the `FatalError` after a burst of parser errors. The stream is a
  `Channel` queue now. The brzozowski negatives answer in 2.5 s instead of stalling.
- **Fix 39, speed**:
  - fast non-cryptographic 256-bit `ContentDigest` (was SHA-256 per work unit and receipt), and
    `hash64`/`hex256` for the other identity refs;
  - memoized replay work units; count-based credit decisions; string key paths; `IndexOf` field reads;
    memoized row classification.

  Mega roots alone: lean_cic 46-63 → 20-28 s, spiral_proves 80 → 33-38 s. Suite compile phase ~2,000 s
  (2,390 s this morning). Registration-time handoff removal was tried and reverted (it slowed replay).
- **Fix 41, silent duplicate calls under load**: replay code re-ran applications and whole expressions
  into blocks the direct evaluator was building. That was the ~20 residuals that changed between identical
  runs. Replay code now runs with a thread-local depth, and `push_typedop` refuses to append to a block
  started outside the current replay (`replay_emit_into_direct_block`, fail closed).
- **Tools**: `scripts/probe.ps1` (one fixture: `-Repeat`, `-Stacks`, `-Profile`), `scripts/profile-summary.py`,
  `scripts/profile-thread.py`, and the diagnostics ledger in stall messages. Debug builds are not faster
  than Release.
- **Race 34 is now the limiter**: making the replay driver run concurrently (fix 42, 20% faster on
  lean_cic) doubled its hits, so it was reverted. Next step (design in FRONTIER.md fix 34): key replay
  entries by (node, evaluation context). Whole-spine thunks can use their captured `s` right away; the
  driver's cells need the context carried from the registration that created them (parent cells,
  parent-continuation handoffs).
- Measuring: never run probes in a shell that still has the build's GC variables set (`build.ps1` scopes
  them now). They made the compiler 2-4x slower and invalidated two experiments (fix 40 needs a clean
  re-test).
- Quiet mode (`SPIRAL_DIAG_QUIET`) must keep `shouldEmitJsonLine`'s kind counters: ~150 retry decisions
  read them (`snapshotKindCount`).
- Rust `string_slice` exits 3 on a split code point like C/Delphi: native DISAGREE 0 in both lanes.
- **apps/spiral with hopac** (scratch copy, `$CLAUDE_JOB_DIR/tmp/apps_spiral_build.ps1`): type checking
  passes; partial evaluation stalled with 96 pending join points. Cause and fix 44 in FRONTIER.md: code
  matched on a join point's pending placeholder result (`++#?` → `format_real`). With fix 44 the fourth
  attempt (25 min) stalled with only 2 pending, both `run@file_system.spi:701`: `read_link`'s `run` join
  point and its `let rec 루프` call each other (mutual recursion across two join points), which the
  inline recursion guard only covers within one work unit.
  Reduced (`$CLAUDE_JOB_DIR/tmp/trace_repro.ps1 -Body`): a `main` that matches on
  `file_system.read_link "C:/nonexistent_dir_x" |> resultm.map_error' sm'.format |> resultm.unbox`.
  Single-flight overflows the stack on it (exit 0xC00000FD in 11 s): very likely the same wall as
  single-flight's apps/spiral overflow. Hopac finishes partial evaluation and then hangs in codegen,
  past its 120 s build budget (the watchdog does not cover codegen): `codegenFsharp`'s
  `requireResolvedMethodCell` finds `CodegenJpMethodBodyCellPending` and blocks in
  `run (Hopac.IVar.read ivar)` on a cell nobody will fill (the JP graph is already quiescent). Two fixes,
  in order:
  1. codegen: a cell still pending after peval's quiescence has no producer; fail closed with the key
     (EJP0014) instead of waiting forever, and extend the build budget to codegen;
  2. find why `run`'s cell stays unfilled: `루프` is itself a join point (`let rec ... forall`), so
     `run` → `루프` → `run` crosses two work units and the second `run` call defers to a placeholder
     of a cell whose owner is waiting on it; or the owner was retired as control-only replay work (seen
     in fix 44's trace) without filling it. Once fixed, add the repro as `samples/frontier_read_link`
     (after single-flight stops overflowing on it, or as a hopac-only frontier row).
- **Evening results (2026-09-30)**, logs under `$CLAUDE_JOB_DIR/tmp/`:
  - hopac fixes 44-47: no verdict change (FRONTIER status; the full run's 61 stalls were machine load);
  - single-flight with the restored peval thread (`runs/single-flight-20260930-210053`): identical to the
    18:02 run on all 1,081 rows (verdicts, residual hashes, exit codes, stdout); one consistent timeout
    (`mega_lean_cic.../negative_programmed_endpoint_cross_codomain`, 30 s, no oracle row);
  - oracle re-blessed from single-flight (`-Bless` never records timeout rows now: machine-dependent);
    the oracle before the bless is backed up at `$CLAUDE_JOB_DIR/tmp/EXPECTED.before-bless.tsv`;
  - single-flight apps/spiral ran 32 min without overflowing, then hit the 30 min budget: rerun with
    a larger budget to see whether it finishes;
  - hopac apps/spiral attempt 7 on the split build with fix 48 (`apps_spiral_hopac7.txt`).
  Fix 48 is only in the split build: rebuild the monolith (`build.ps1 -Mode hopac`) before the next suite.
- **Night 2026-10-01, outcome.** Single-flight builds apps/spiral again (exit 0, 738 s, 2.79 MB) after the
  `sm'.span_from` library fix below. Hopac: suite at full parity on fixes 49-53 (FRONTIER status table);
  its last apps/spiral-specific wall was fix 54 (`VarIs` called every static union a variable;
  `samples/frontier_static_list_eq`, blessed). Attempt 13 with fix 54 ran 25 min and ended with "BuildFile
  returned no code and no diagnostic arrived": most likely `PevalInlineRestart` escaping after its two
  restarts; that now surfaces as an EJP0014 build error with the reason (rebuild + rerun to read it).
  `SPIRAL_HOPAC_INLINE_JP=1` evaluates hopac's join points inline from the start (diagnostic switch).
  Attempt 14 (06:10, fix 54 + restart-limit message): at 24 min `main` had returned and the root waited in
  `awaitJpQuiescence`; one JP work unit was still grinding in the asynchronous declared-body machinery
  (`resume_declared_apply` → `jpStoreDeclaredApplyContinuation` → `jpMaybePruneDeclaredResumeSnapshots` →
  `jpPruneUnreachableDeclaredResumeSnapshotsForJob`, a concurrent-dictionary walk per stored continuation:
  likely quadratic), at under one core. Next for hopac apps/spiral: make that pruning incremental (or run
  apps/spiral with `SPIRAL_HOPAC_INLINE_JP=1`, which skips the declared-body slicing, and compare).
  Stacks: `$CLAUDE_JOB_DIR/tmp/attempt14_stacks.txt` was not written; rerun `dotnet-stack report`.
- **Night 2026-10-01: apps/spiral now fails the same way in both cores.** Hopac attempt 10 (fixes 44-53,
  fresh inline peval restart) failed after 624 s with `EJP0011: re-entrant term evaluation cycle` at
  `listm'.spi:33` (`inl rec try_item`, 1,025 re-entries, depth 7,240), reached from `main` through
  `trace.spi:221` (`trace`). An inline recursion whose index is a runtime value unrolls forever (one
  dynamic `if` per level); single-flight's 80-min stack overflow is the same `if_ → term_scope' → term`
  cycle (~75,000 deep). `listm'.try_item_` (`let rec`, a join point) is the runtime-safe variant. The
  three-call `trace` repro compiles in single-flight now (80 s), so the trigger is specific to
  apps/spiral's calls. Diagnostics added: single-flight `SPIRAL_IF_NESTING_LIMIT` (default 5,000) turns
  the runaway into a traced type error; hopac's `legacy_build_retry_rejected` wrapper now keeps the
  evaluation trace as text.
  **Root cause (03:30): a library change, not the compilers.** The guard's full trace in single-flight:
  `run` → `runtime.execute_with_options` → `split_command` → `runtime.split_args` → parsing combinators
  → `p_char`'s error message → `sm'.span_from`. Commit `c656f5e` (2026-01-01, two days after the last
  successful `spiral.fsx`) changed `span_from` from a `let rec` join point to
  `inl rec body ... and inl 루프 i = join_body_unit body i i`, which inlines whenever the *index* is static;
  the parser starts at a literal 0 and the string is runtime, so it unrolled forever (both cores, as the
  language says). `lib/spiral/sm'.spi`: `span_from` and `index_of_char_from` now decide on the bound
  (`join_body_unit body len i`, as `replicate` does). `runtime.split_args (dyn "a b")` alone: guard trip
  in 68 s before, compiles now (123 s, 650 KB). (The `try_item` frames of the first traces were a
  compacted-trace artefact plus `exists'`'s own divergence on runtime lists, which apps/spiral does not
  hit.)
- **Single-flight's apps/spiral stack overflow was a regression, now fixed** (2026-09-30 evening).
  Commit 1eb2ecf (2026-09-27) replaced the 1.5 GB thread single-flight ran `peval` + codegen on (upstream:
  256 MB, `Supervisor.fs:505-509`) with an inline call, leaving its comment orphaned; `peval` then ran on a
  1.5 MB Hopac worker stack. `read_link` overflowed at ~240 frames: finite depth, from `term` frames of
  ~7-10 KB, join point bodies evaluated inline, and `BackendSwitch` evaluating every backend's branch
  (2 MB was already enough for the repro). The thread is back (`#else` Supervisor, `file_build`); the
  repro compiles in 30 s (192,400 bytes, 26 methods, 12 closures, the same counts as hopac). The next
  single-flight `-Suite all -Native` run is its regression check. Diagnosis logs:
  `$CLAUDE_JOB_DIR/tmp/cases/sf_readlink`.
- **Splitter**: stale anchors collapsed the plan 137 → 9 gears (README "Anchor collapse"). Deployed: the
  splitter falls back to a fresh plan on a collapse (`SPIRAL_GEAR_ANCHOR_MAX_MERGE`), and gear-dev refuses
  to sync a collapsed plan. `gear-dev -Full` re-planned to 144 gears. Open: the root fix in
  `spiral-split-plan` (keep straddling shards from forming), the FS2014 Debug naming collision (repro in
  `$CLAUDE_JOB_DIR/tmp/splitdiag/repro`, not reported upstream).
- **Oracle re-blessed (2026-09-30 22:05)** from single-flight (`runs/single-flight-20260930-214014`), after
  three single-flight runs (18:02, 21:00, 21:40) agreed on all 1,081 rows (compile, residual hash, native,
  exit, stdout). 1,155 → 1,174 rows: 20 added (the new examples and frontier fixtures, including
  `frontier_format_any_union`, `frontier_join_format_any`, `native_replay_repeat_call`,
  `native_literal_join_args`); 21 `error → ok` (the "(expression)" F# outputs); 361 refreshed residual
  hashes (158 C, 100 Rust, 98 Delphi, 5 F#: translator-era and pre-fix hashes; no native, exit or stdout
  value changed); the 3 native improvements (`managed_string_invalid_utf8_slice` Rust/Delphi exit 3,
  `dynamic_array_bounds_negative` Delphi). The oracle holds no timeout row (`-Bless` skips them; one old
  entry removed). Not changed by this: the 5 mega `brzozowski` rows whose oracle is the parent package's
  program (FRONTIER.md, "Resolved (2026-09-29)") still record that program; fixing them is item 1 below.
  Backup of the previous oracle: `$CLAUDE_JOB_DIR/tmp/EXPECTED.before-bless.tsv`.

## Session 2026-10-01 (morning): hopac compiles apps/spiral in its default mode

Details: `lanes/hopac/FRONTIER.md` fix 55.
- **apps/spiral, hopac default (async) mode: partial evaluation and codegen in 555 s**, the same 2,687,696
  bytes on two runs, 0 errors type-checked as .NET F# (`$CLAUDE_JOB_DIR/tmp/spiral.hopac-default.fsx`).
  It needed the snapshot-prune trigger made geometric (it ground for hours), the JP watchdog to count
  evaluation steps as progress (it aborted a busy 2-minute join point body, then the write guard refused the
  "unstable" run) and the write guard to stop judging stable runs by the size of the file already on disk.
  Inline-JP mode (`SPIRAL_HOPAC_INLINE_JP=1`) also builds it (879 s); its 7 suite gaps of the morning are closed
  (the write loop's own `unstable`, FRONTIER fix 56), but async is faster and stays the default.
- Hopac's output is ~104 KB smaller than single-flight's only because single-flight's variable numbers run to
  `v146264` (hopac numbers per method); same line and token counts. Method signatures differ in the order of
  captured variables, and the comparison base (`spiral.sf.fsx`, 03:48) predates the `listm'.exists'` change.
- Runaway inline recursion: a rustc-style `error[EJP0040]` in both cores (span, repeating cycle, entry path,
  why, fix), registered as terminal; `samples/frontier_runaway_inline_recursion`; `SPIRAL_IF_NESTING_LIMIT`
  default 1,000. Hopac evaluates ~15-20 ms per inline level, so it needs ~20 s to report (task: per-application
  overhead); quiet-mode telemetry and a quadratic cycle-guard count are already out of that path.
- Splitter: a same-source `gear-dev` rerun after an anchor fallback crashed (`Part3817 is outside the plan`);
  fixed in `output_reset.rs` (README "Same-source rerun"), and `-Full` now starts from an empty `.out` (it built
  against the previous plan's same-named gears: FS0193). 141/141 gears build.

## Open, in order

0. **Handoff 2026-10-01 21:00 — hopac meets the promotion criterion** (AGENTS.md):
   `runs/hopac-20261001-194016` reproduces every oracle row (no `missing`, no `emitted`, DISAGREE 0) and
   apps/spiral compiles in the default async mode (359 s, 2,687,696 bytes, 0 type errors). The single-flight
   run after it (20:50) is at full parity and the tracked sample outputs equal HEAD. Today's fixes: FRONTIER.md
   55-58. Pending work, in order (nothing else is in flight; the session's task list is closed):
   1. **Confirm the margin, then decide the default.** The 4 `frontier_runaway_inline_recursion` rows report
      `EJP0040` in 14.5-16.5 s under suite load against the 17 s core deadline. Repeat
      `pwsh scripts/test.ps1 -Mode hopac -Suite all -Native` two or three times; if they hold, switch the
      default lane per AGENTS.md "Promotion criterion". If they flap: the remaining per-level cost is replay
      registration (item 3), CSE lookups through the scope chain, and GC scans of the deep stack (the harness
      already sets `DOTNET_GCgen0size=0x10000000`).
   2. **Warm processes (FRONTIER fix 57).** `-FreshProcess:$false` compiles a whole suite 12x faster (186 s vs
      2,295 s; each fresh process re-parses the core library, ~5 s). Done: the stale-watchdog ordinal, the
      per-build invalidation baseline, sequential/recovery reset, the terminal-failure latch reset. Blocking:
      join point work, cells and deadlines left by a build the host abandoned (it returns on the first type
      error) make the next build's join point workers hit `JpTerminalFailureRunningCutoverCancellation` (~75-100
      rows). Point resets did not help (store resets, request-tagged timings: both reverted). Next: a per-build
      session object owning the JP machinery's work items, cells, caches, deadlines and the latch, created per
      BuildFile request (the request ordinal exists in the Supervisor section).
   3. **Race 34's general fix (a per-evaluation replay store).** Its faces fixed today: replay drawing from a
      direct block's variable counter, the type-aware op replay running unmarked (fix 56; the replay driver
      now marks its whole run). The general fix should also remove whole-subtree replay registration at every
      term entry (`registerReplayTermWithContext`: ~19% on the runaway fixture, ~32% inclusive on a mega root);
      its thunks capture the environment (`box s`), so registration cannot simply be deduplicated.
   4. **Mega-root speed.** The evaluator dominates a mega root now (the quiet metronome went from 11.8 s to
      0.7 s of CPU); next costs: telemetry producers still computed in quiet mode (keep each row's kind:
      `forceReplayDriverDrainPassTagged` decides on `snapshotKindCount`), `EvalVisitLedger.key` (a
      StableBindingId per visit), DiagSidecar hot-key counters (they feed retry triage).
   5. Before any commit: a single-flight restore run (hopac suites rewrite the tracked sample outputs).
   History of the day: "Session 2026-10-01" above and FRONTIER.md's status lines.1. **Done (FRONTIER fix 49): the 5 mega `brzozowski` rows with a wrong oracle**, blessed as `error`. Original notes: Cause, in *both*
   cores: the entry's `inl main` block fails to parse (a backtick type application on the next line, which
   top-down code rejects) and is dropped without a message; `BuildFile` then finds the `main` that the
   entry's `open main` brought in from the dependency (single-flight `file_build` fold + `Map.tryFind "main"`;
   hopac the same at its `BuildFile`). Hopac's earlier "errors" on these rows came from the host or stall
   messages. Patched in both cores (not yet built): when the entry does not define `main` itself and has
   tokenizer/parser errors, the build fails with `Cannot find main ... the file does not define it, and it
   has errors` plus `path:line:col` per error. Decision: these five are invalid programs and a valid
   rewrite (`inl v : T = f ()` for each `` f `T () ``, `assert_static false` for `failwith`) partially
   evaluates for >10 min (contracts timeout 30 s), so their oracle becomes `error`. Verify: full
   single-flight run changes exactly these five rows; bless them with `-Filter`; hopac matches. Patches,
   repro and the fixture rewrite: `$CLAUDE_JOB_DIR/tmp/entryfix/`. Also worth a look: two "negative"
   mega rows (`negative_nondefeq_authority_not_scoped_pi_authority`,
   `negative_recursive_beta_false_ready_domain_retag`) compile only because their negative block is a
   parse error that gets dropped.
2. **Rust libraries and exports for eoie**: `lanes/single-flight/RUST_LIBRARY_PLAN.md`. Then delete
   `compiler/host/PortableBackends.fs` and everything that calls it (the host still runs its
   `lowerPortableBackend`/`tryLowerPortableSource` on C and F# output; verify that is a no-op for the
   remaining fixtures before removing it).
3. **Split compiler rebuild**: the core gained top-level declarations, so the split plan moved.
   `pwsh scripts/gear-dev.ps1 -Force` (~20 min at `-MaxNodes 2`), then
   `$env:SPIRAL_COMPILER_DLL = <printed path>; pwsh scripts/test.ps1 -Mode hopac -Suite frontier,smoke -Native`.
   Then continue the user's goal: iterate on the splitter/hopac until every sample compiles with hopac.
4. **Hopac**: the build-budget stalls. They fall into two groups:
   - **Diagnosed (2026-09-29, late):** with the fatal message now listing every package's errors, these
     "stalls" report instead: hopac rejects `+.`/`=.` inside the nested package
     (`packages/shared/advance.spi:12:31: Unbound term variable: +.`, `consume.spi:16:43: ... =.`). Those
     operators come from the harness core `samples/core` (`operators-`); The-Spiral-Language's core
     (`SPIRAL_COMPILER_PACKAGE_DIR`, `deps/polyglot/.../VS Code Plugin/core`) has neither, and every
     package in these fixtures uses `|core-` (the real core). Single-flight rejects them the same way (a
     fresh compile: `Unbound variable: +.` in `shared`), and the oracle expects the rejection, so hopac is at
     parity; whether the fixtures should use the harness core (`core-`) is a fixture question. (Earlier
     builds hung at `typecheck_await_scheduled` instead of reporting; which change ended that is not pinned
     down.) The notes below are the earlier analysis.
   - Type checking never finishes (`last_stage=typecheck_await_scheduled`) for multi-package programs:
     every `native_source_package_prototype_*` fixture and 4 mega `negative_*` sub-packages. The
     prototype isn't the cause: `native_source_package_prototype_record_callback` with a plain
     function instead still stalls. `main` → `shared` → `model` (each also on `|core-`) is enough.
     A plain type error in `shared` is reported correctly by hopac (`FatalError ... type error
     somewhere in its path`, 5 s). The reduced variant (in `shared/advance.spi`: `open model.state`, then
     `inl run () : i32 =` building a `state_t`, destructuring it with `inl (state_t s) = initial` and adding
     its fields) is rejected by single-flight in 5 s and stalls hopac, while the original fixture compiles in
     single-flight. Hopac compiles the same package graph with valid bodies (`open model.state` alone, a
     `state_t` built and unused, a `match initial with | state_t s => ..`), and the destructuring
     `inl (state_t s) = initial` compiles in a single-file program in both cores. So the stall needs the
     destructuring of an imported nominal inside a dependency package. Next: instrument which package's
     type-check stream `BuildFile` waits on (`tc.files.uids_file.[mid]`: `a.state`, and the prepass `b`)
     at the stall; a typechecker exception swallowed inside a Hopac stream would leave that promise unfilled.
   - Partial evaluation (`partial_evaluation_started`): the cube and utf8 fixtures, `frontier_fib`, and
     contract and mega sub-packages. Recheck these after fixes 22-25, since some cleared.
   The mega sub-packages that "parse order-dependently" are a fixture problem, not hopac: see
   FRONTIER.md ("Resolved (2026-09-29)") for the 5 oracle rows single-flight compiled from the wrong
   `main`. (`tuple_mixed`, `portable_composite` and `native_managed_array_tail_recursion` were fixed
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
