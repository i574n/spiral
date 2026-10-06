# Where to resume (2026-09-28)

State at hand-off, and the open work in priority order. Details live in the lane docs linked below.

## Session 2026-10-05 (night): Rust literal cache and path-qualified literals

- codegenRust's last pass, `cacheRustStringLiterals` (shared section, both cores), caches each `Rc::<str>::from("..")`
  in a `thread_local`. It matched the bare suffix only, so a literal that macro text spelled with its path
  (`std::rc::Rc::<str>::from("")`, eoie's `rust_std_string`) became `std::rc::{ thread_local!{..} LIT.with(..) }` and
  rustc rejected it (`expected identifier, found {`; 5 errors in eoie's command_spec.rs). Now a `std::rc::` or
  `::std::rc::` literal is replaced as a whole, its path kept inside the block (`static LIT: std::rc::Rc<str> = ..`), and
  a literal behind any other path (`crate::Rc::..`) or an identifier is left as written. Bare literals are cached as
  before (no existing output changes). Fixture `rust_string_literal_path` (C,Rust; exit 20; red with the previous
  compiler, rustc error above).
- Verified: single-flight `runs/single-flight-20261005-220235` (`-Suite all -Native`: +2 rows for the fixture, 0
  changed rows vs `-190408`, outputs 1052 identical + the fixture's 2), re-blessed by `-220955` (row for row, 1054/1054
  outputs identical; EXPECTED EE5D50A67221). Source 3CCCBD5D8346: projections single-flight 92e758a2, hopac daa4ca87.
  Hopac (rebuilt): `runs/hopac-20261005-223154` (frontier+smoke, `-Parallel 1`, 72/72 parity, 0 changed rows vs
  `-191036`) and `-223624` (78 Rust/string fixtures incl. the new one: all parity, DISAGREE 0, 0 changed rows vs
  `-192602`; the fixture's C and Rust residual hashes equal single-flight's).
- Tracked outputs elsewhere: eoie's `authority_state_domain/authority.rs` and `eoie_legacy_operations/operations.rs`
  hold `std::rc::Rc::<str>::from("")` from a compiler older than the cache pass (their bare literals are uncached too);
  if regenerated, this fix caches it like the others. eoie's `rust_std_string/model.spi` workaround (`.unwrap_or_default()`) can be reverted.

## Session 2026-10-05 (day): C forward declarations, Python NaN/concat, hopac start-up and parse speed

- C backend, recursive unions with closure fields: a `Fun` struct prints its range and domain types first, so a union
  among them named the `Fun` before its typedef (`union rec s = Cons : u64 * (() -> s)`: `unknown type name 'Fun0'`);
  and a function whose definition was still printing (its body prints the functions it calls first) was called before
  its definition (a closure calling the join point that creates it: `implicit declaration of function 'build0'`).
  CodegenC now emits a forward `typedef struct FunN FunN;` for a `Fun` named while its struct prints, and a prototype
  for a function called while its definition prints. Only programs that failed before change, plus the four scc
  samples whose shims hand-wrote those prototypes (their `main.c` gains the generated line; the two prototype-only
  shims are deleted and the two array scc shims keep only their `DynamicArrayReserve0` macro). Fixture `native_closure_union_rec` (all four backends, exit 70); `rust_static_closure_chain`'s C side now
  runs the real 80-link program (exit 40).
- CodegenPython: a NaN literal printed `float()` (= 0.0) and is now `float('nan')` (unreachable from source today:
  partial evaluation rejects a compile-time NaN; ts_float_nan builds its NaN with a macro). `StaticStringConcat`
  (`sm.concat`) had no Python arm: `ts_string_concat` Python now builds and agrees with C (was a blessed error).
  The other `ts_*` C++/Python gaps are upstream representation limits (C++ strings are `const char *` without a
  length, arrays bare pointers; Python ints are unbounded, strings index by code point) and stay as they are.
- Hopac start-up: every hopac row runs in a fresh process, which spent seconds JIT-compiling the compiler.
  `scripts/build.ps1` now ReadyToRun-compiles a Release build's managed dlls with the runtime's crossgen2 (from the
  NuGet cache, restored on first use; Hopac.dll crashes crossgen2 and stays IL, remembered in `<dll>.r2r-skip`).
  frontier_hello 6.0 -> 3.2 s per fresh process; with the parse fixes below the lib/spiral frontier samples
  (format_any_union, join_format_any, static_list_eq) went from 9-16 s to 7.4-8.9 s and the runaway rows from ~14 s
  to 6.5-7.3 s (`runs/hopac-20261005-083405`, `-Parallel 1`, frontier+smoke compiled in 299 s vs 554 s).
- Hopac parse of lib/spiral: the parsed-AST seed telemetry summed every block under a lock for each parsed block
  (O(blocks^2), threads spinning on the lock) and keyed blocks through `NativeCutoverStableRef.ref32` (a digest and a
  process-wide locked table per block): ~43% of parse CPU. Now a running aggregate keyed by the block's identity
  string. The tokenizer's `skip_string`/`chars_till_string` used the culture-aware `String.Compare` (~16% of parse
  CPU): ordinal now (shared section). The host skips the source-graph fingerprint (every .spi under the input and the
  package directory read and hashed) when a process compiles once: the CLI's single compile, `--plan-ir`, and one-job
  batches (every hopac `-FreshProcess` row).
- Tokenizer (both cores): `tokenize_line` appended each token with `PersistentVector.conj`, which copied the vector's
  tail array every time (over half of the tokenizer's CPU on lib/spiral); tokens now collect in a ResizeArray that
  becomes the line's vector once. Infer (both cores) renders hover texts only when `SPIRAL_HOVERS` is not `0`; the
  CLI host sets `0` (it has no language-server mode; the rendering was ~6% of a fresh single-flight compile). A fresh
  single-flight compile of frontier_format_any_union went from ~8.9 to ~5 s (ABBA, 4 pairs, identical outputs); hopac
  gains less (its parse is already parallel).
- Hopac `term_core_impl` split for the JIT: it was 225 KB of IL, past the JIT's 60 KB optimization limit, so every
  fresh process compiled it (twice) with MinOpts into 1.1 MB of machine code. Its long arms are now `let rec` local
  functions (`termArm*`: fsc's TLR lifts them to static methods and, unlike plain single-use locals, does not inline
  them back), and the EOp arms, which carried most of the match's decision tree, live in `termOpArms1..3`, split by Op
  case (each repeats the catch-all arm; arm bodies and their relative order unchanged). IL: term_core_impl 42 KB,
  termOpArms 21/42/56 KB; `DOTNET_JitDisasmSummary` reports "Tier-0 switched to FullOpts" for them. ABBA (4 pairs,
  both ReadyToRun, outputs identical in every pair): lean_cic -1.5 s (-14%), runaway -0.7 s (-15%), brzozowski
  -0.3 s, format_any_union and spiral_proves unchanged. The edit was generated mechanically (pure code motion); the
  single-flight projection is unchanged by it. `apps/spiral` on hopac (fresh process, ReadyToRun): 85 s with the split,
  93 s without, byte-identical `spiral.fsx` (1,932,564 B; 359-888 s on 10-01).
- TypeScript coverage: a sweep compiled every sample with a C oracle to TypeScript; 97 agree with C and now carry a
  TypeScript row (`tests/harness.psd1` `AlsoTypeScript`, appended in `test.ps1`'s New-Sample; frontier samples
  excluded). The others are C-only by design (libc ABI fixtures, the C dynamic-array shims' macros, the harness core's
  C-only `((uint8_t)!value)` byte macro, BackendSwitch fixtures without a TypeScript key). One real gap fixed: a string
  slice that fails (bounds, or inside a code point) exited 1 on TypeScript (a thrown RangeError) where C/Rust/Delphi
  exit 3 (abort / exit(3) / Halt(3)); the helper now exits 3 (`managed_string_invalid_utf8_slice`).
- Verified: single-flight `runs/single-flight-20261005-081420` (C/Python/fixture rows above changed, all explained)
  and `-085717` (0 changed vs `-081420`), re-blessed by `-091505`; then `-095511` (+93 TypeScript rows, all agree;
  only the 3 ts_* TypeScript residuals with the slice helper changed) re-blessed by `-100311` (row for row, 1048/1048
  outputs identical; EXPECTED 55DF84D84F0A); `-105157` (+4 multi-module TypeScript rows, scc shims without prototypes)
  re-blessed by `-110215` (EXPECTED 979A16B45F19); `-113449` (tokenizer + hovers) reproduces it (outputs identical); re-blessed on the final source by `-185124` (EXPECTED
  49DDCDFFABDB; its only differences from `-113449` are format_any_union/join_format_any F#/Rust variable renumbering from
  lib/spiral edits made at 12:31).
  Source 58D50F91F9AC: projections single-flight 6aae8632, hopac b867b6fb. Hopac `runs/hopac-20261005-083405` (frontier+smoke, 0 changed rows vs `-043523`), `-083905` (fixtures:
  every new/changed row's residual equals single-flight's), and with the split `-101039` (frontier+smoke incl. the new
  TypeScript smoke rows, 0 changed rows vs `-083405`), `-101617` (fixtures, 0 changed vs `-083905`) and `-101938`:
  `-Suite all -Native -Parallel 3`, 1279 rows, no missing/emitted/timeout, DISAGREE 0, 12 parity-residual-differs (the
  known BackendSwitch-numbering rows), compile time summed 2,280 s vs 7,020 s the night before. On 58D50F91F9AC:
  `-115035` (frontier+smoke) and `-115519` (fixtures), 0 changed rows vs the runs before; repeated on a quieter machine by
  `-191036`/`-191413` (0 changed; slowest frontier row 6.4 s against the 17.9 s deadline) and `-192602` (`-Suite all -Parallel 3`: 1283 rows, no
  missing/emitted/timeout, DISAGREE 0, 0 changed rows vs `-101938`; slowest frontier row 9.9 s).

- Open (hopac): under a saturated CPU the lib/spiral frontier samples (and a few small ones) can still hit the 17.9 s core
  deadline in `prepass_await_scheduled` (type checking done, partial evaluation not started): `runs/hopac-20261005-122158`
  had 16 such timeouts while other jobs held the machine at 100% CPU, where `-101938` an hour and a half earlier had none.
  The stall is before partial evaluation (prepass scheduling waits behind the loaded thread pool), so the next lever
  is the prepass/typecheck latency, not the evaluator.
## Session 2026-10-04/05: D1, D8, Python+Cuda kernel corelib

- Native Rust `failwith` panics (`std::panic::panic_any`); `fn main` maps a panicked main thread to exit 101.
- Per-branch CSE scope at preprocessor directives (`module CseDirectiveBarrier`, shared, before HopacExtensions): an
  `#if/#ifdef/#ifndef/#elif/#else/#endif` line in macro text prunes the block's CSE table back to what was bound before
  the region, at all 4 `push_typedop_no_rewrite (TyMacro ..)` sites (sf EMacro; hopac EMacro and the 2 replay thunks).
  Before, a value bound in the first `run_target` arm was reused by the other arms and after `#endif` (lib/spiral seq.dib
  cell 92: `v66` undefined in plain F#). Single-flight `runs/single-flight-20261004-235909`: 0 changed rows vs the oracle,
  mega compile times unchanged; hopac smoke and the new fixtures all parity; hopac frontier parity with residuals
  identical to before, but the 4 slowest frontier samples needed `-TimeoutSec 60` on a saturated CPU (stalls before
  partial evaluation, so load; rerun `-Mode hopac -Suite frontier` at the default budget on a quiet machine).
- Python+Cuda `kernels_aux`: the 0cb0fda0 corelib marks members `__host__ __device__` and guards `__host__`, and
  upstream's `Replace("__host__", "__device__")` turned that into `__device__ __device__` members and a second
  `#ifndef __device__` block (upstream has the same latent bug). The `__host__` guard is now dropped first, then
  `__host__ __device__` -> `__device__`. Only `*_auto.py` outputs change (residual hashes are of `main.py`). Not
  regressions, kept as upstream: the dropped device sync after `main` in Python/C++ (upstream e17b1cfc, CHANGELOG: the
  sync caused instability with a debugger), and polyglot Supervisor's C++ expectation containing `#pragma once` and
  `#include "main.hpp"` twice (it is the 4 CppHost files joined, each correct).
- `runtime/make_corelib.py` takes the upstream corelib path as an argument and writes only `runtime/corelib.cuh` (the
  diff goes to stdout); the host copies only `corelib.cuh`/`corelib.py`. `scripts/probe.ps1 -Backend Cpp|Python`.
- Rust `recursion_limit`: a closure that captures nothing is a `thread_local!` static, and a chain of them (closure k
  calls closure k+1, e.g. lib.dice's constant stream) nests std's lazy-initializer instances in rustc's monomorphization
  walk; the dice contract's wasm32 build stopped at the default limit (128) until it added `#![recursion_limit = "512"]`
  itself. codegenRust now emits that attribute when a program has more than 16 static closures (smallest power of two
  from 256 that is at least 4 per static closure + 64; skipped when a global already sets it). The chain alone does not
  overflow on x86_64 or wasm32 (80 and 200 links built), the surrounding call graph matters, hence a count, not a chain
  measure. Dice: its landed `.spi` compiles byte-identically with and without its own global (73 static closures ->
  512). Fixture `rust_static_closure_chain`.
- NEAR store collections move: `nonCloneRustType` covers `near_sdk::store::*` (Vector, LookupMap, IterableSet, ..., both
  spellings) and lib/spiral's native `near.vector` (`SpiralNearVec`), so a state record holding one is returned/passed
  without `.clone()` (rustc E0599). A contract's `new` can return its state: a dice variant exporting
  `dice_contract_new : () -> state` builds for wasm32 with the dice profile and keeps the 7 exports/19 imports (dice
  itself unchanged: it still uses `&mut Option<State>`, which is now optional). Fixture `rust_near_store_moves`.
- `ts_float_nan`/`ts_while_loop` have `CppHost`/`Python` keys now: their C++ and Python rows build and agree with C (the
  4 rows were blessed compile errors). ts_float_nan's C/TypeScript residuals renumber variables only (a value-level
  `!!!!BackendSwitch` evaluates every arm). The host's usage line lists all 9 backend ids.
- Seen, not fixed: the C backend can't declare a closure type inside a recursive union (`union rec s = Cons : u64 * (()
  -> s)`: `unknown type name 'Fun0'`); CodegenPython writes a NaN literal as `float()` (= 0.0; upstream too).
  Both fixed in the 2026-10-05 day session (above).
- Verified on source `3D4D537BCE75` (projections: single-flight `dd28476f`, hopac `0eccfd3a`):
  `runs/single-flight-20261005-010846` (all 1178 rows parity, DISAGREE 0), re-blessed by `-011934`, which reproduces it
  row for row with byte-identical outputs; hopac `runs/hopac-20261005-003930` (smoke 36/36, frontier parity except
  timeouts on a CPU-saturated machine) + `-010115` (those rows at `-TimeoutSec 60`: all parity) + `-005400` (new
  fixtures 32/32).
- Then verified on source `6AA9B2B3F775` (recursion_limit, NEAR store moves, fixtures; projections: single-flight
  `de9c11d6`, hopac `d060e0b1`): `runs/single-flight-20261005-031327` (1182 rows, DISAGREE 0, REGRESSED 0; changed rows
  only the 4 new and the 6 ts_float_nan/ts_while_loop rows above), re-blessed by `-033216`, which reproduces it row for
  row with byte-identical outputs. Hopac on `6AA9B2B3F775`: `runs/hopac-20261005-035940` (smoke 36/36; frontier parity
  except 4 timeouts at the 17.9 s core deadline, the usual slow rows under load) + `-041213` (new fixtures 44/44, DISAGREE 0).
- hopac-perf 01-04 (hopac-only: Op case table without per-case `MakeUnion`, value-keyed `EvalSiteCache`, fewer
  evaluator allocations, and the `memoCreditDecision` fix: it keyed a ConcurrentDictionary by an option, so `None`
  threw `ArgumentNullException` in Hopac workers; now `voption`) on top: source `67D56F303BA9`, single-flight projection
  unchanged (`de9c11d6`, so the bless above stands), hopac `50944649`. `runs/hopac-20261005-043523` (`-Parallel 1`):
  frontier 28/28 and smoke 36/36 parity, no timeouts. Against `-035940`, the 4 timeouts and the emitted
  frontier_static_list_eq row now return, with residuals identical to the `-TimeoutSec 60` run `-010115`. New fixtures
  `-044750`: 44/44 parity, DISAGREE 0, row for row equal to `-041213`. Mega and timing: hopac-perf3's private runs
  (`hopac-20261005-032257` base vs `-035558` patched, frontier,smoke,mega: 0 rows differ, compile_ms sum 808 -> 627 s,
  sequential under load; their ABBA timing is in `$CLAUDE_JOB_DIR/tmp/agents/hopac-perf3/LOG.md`).

## Session 2026-10-03: Python indexing and notebook error reporting

- Upstream `mrakgr/host_cpp_and_cuda_backend` at `0cb0fda07a76202db356849301615c5bf026c5a1` still calls `.item()` unconditionally. The shared Python backend now unboxes numeric CuPy/NumPy array elements while preserving foreign/container and object-array values. `python_foreign_array_index` passes on both monolithic compiler modes.
- Both compiler modes built successfully. Their Python suites each compiled/executed 12 of 15 rows; `ts_float_nan`, `ts_while_loop`, and `ts_string_concat` remain compile failures. This is not a clean full-suite result or a C parity run.
- Updated authoritative `apps/spiral/spiral.dib` and `lib/spiral/runtime.dib`, then exported `.spi`: CUDA/C++ failures propagate, `SPIRAL_JSON=1` requests a quiet JSON response, and failure shutdown exits 1. Polyglot `apps/spiral/Eval.dib` opts into the protocol; its `.fs` was exported too. Generated F# shutdown was executed and returned 1.
- Pending: rebuild the full CLI and run `python apps/spiral/test_json_protocol.py <rebuilt-executable>`. The old binary fails this regression test. The isolated full CLI compile timed out at 300 seconds; a smaller production CUDA runner probe was stopped after six minutes without output. Do not claim end-to-end JSON validation yet.
- Pre-edit copies, private compiler builds and test logs: `%LOCALAPPDATA%/spiral-bin/scratch/ci-tail-fix-20261003-030322`. Concurrent agent changes were retained; no shared CLI binary was replaced.

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

- eoie builds natively: `pwsh ../eoie/compiler-contracts/test-regeneration.ps1 -CargoCheck -Test -CompilerContracts`
  passes (88/88 owners, cargo check, all tests incl. the `--check`/`--plan-ir` ones) and so does
  `compiler-contracts/test-attestation.ps1`. The regenerated `.rs` are copied into `eoie/src` (the eoie repository) (uncommitted).
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
      2026-10-02: held twice with margin (`-Parallel 2`): `runs/hopac-20261002-111457` 11.3-11.7 s, and
      `runs/hopac-20261002-153006` 8.7-10.0 s (after the registration and union-tag changes; full parity, 0 missing,
      DISAGREE 0, compiled in 2,325 s vs 2,985 s that morning; 33 rows moved from parity-residual-differs to exact
      parity, 64 left). A third run at 18:27 on a throttled CPU (70% of nominal) put them at 15.2-15.9 s: the margin
      depends on machine conditions, so the deadline is still the weak point. The criterion's rows hold; switching
      the default lane is the user's call (hopac is still
      4-5x slower than single-flight on the mega roots: lean_cic 19.7 s, omniledger 22.2 s, spiral_proves_spiral
      43.6 s, brzozowski 3.9 s, zeta 7.2 s).
   2. **Warm processes (FRONTIER fix 57).** `-FreshProcess:$false` compiles a whole suite 12x faster (186 s vs
      2,295 s; each fresh process re-parses the core library, ~5 s). Done: the stale-watchdog ordinal, the
      per-build invalidation baseline, sequential/recovery reset, the terminal-failure latch reset. Blocking:
      join point work, cells and deadlines left by a build the host abandoned (it returns on the first type
      error) make the next build's join point workers hit `JpTerminalFailureRunningCutoverCancellation` (~75-100
      rows). Point resets did not help (store resets, request-tagged timings: both reverted). Next: a per-build
      session object owning the JP machinery's work items, cells, caches, deadlines and the latch, created per
      BuildFile request (the request ordinal exists in the Supervisor section).
      2026-10-02: `test.ps1 -WarmRecycle` (host: `SPIRAL_BATCH_RECYCLE_AFTER_ERROR=1` ends a batch with exit 4 after
      an error job; the worker resumes the rest in a fresh process): `-Suite all -Native -Parallel 2` compiled in
      1,032 s vs 2,985 s fresh (484 processes for 1089 jobs; warm examples compile in 0.2-0.4 s). Not byte-safe
      yet, so opt-in only. Two leaks across *successful* builds: (a) `tagged_union_*` match arms came out in another
      order — `UnionTagId` compared by intern slot, i.e. the process-wide first-seen order (fixed: ordinal text
      order, single-flight's; the 4 `tagged_union_*` samples now come out byte-identical to the committed
      single-flight outputs, warm and fresh, where hopac's had been `parity-residual-differs`); (b) the `while_*`
      samples stall on their 3rd-8th build in one process (any backend; 1-2 of 8 per round): main returns, then
      `jpAwaitCombinedQuiescence` (peval-main-orphan-check) waits on one operational node left `Running` with no job
      behind it — `JPMethod <anon> while_loop/main.spi:1:20-1:26` (the stall report now lists spawn leases and
      open nodes). Cause (traced with the absorbed exception, now printed outside quiet runs): the process-global
      `SemanticWorkLedgerAuthority` kept the earlier build's receipt for the same content-identified work unit;
      this build's receipt differed, so `jp_complete_work_item`'s retirement was rejected (`SemanticConflict
      (ReceiptConflict ...)`), the boundary absorbed it, the node never retired. Fixed: `resetEvaluationForBuild`
      empties the ledger (`SemanticWorkLedgerAuthority.resetForNewBuild`); 5 rounds x 8 warm builds clean.
      Still open: the in-process inline restart (`pevalWithInlineRestart`) starts a new peval without that reset.
      Caveat: the reset is safe when nothing from an earlier build is still running (a fresh process, `-WarmRecycle`).
      Fully warm, an abandoned error build's join point work is still in flight and the reset wipes its ledger
      credits under it; that may feed the cutover rows below rather than being independent of them.
      Full-suite results with both fixes: `-WarmRecycle` 1,018 s, examples all parity, 2 contracts rows missing
      (`brzozowski/antimirov_certificate` cutover cancellation; `canonical_form_certificate` "types of two branches
      of an union unbox do not match: symbol_ordering / bit_alphabet" — a warm-only wrong answer, cause not found);
      fully warm (`-FreshProcess:$false`) 396 s but 116 examples rows `JpTerminalFailureRunningCutoverCancellation`
      after abandoned error builds. Tried and reverted: the host waiting (up to 20 s) for the abandoned build's own
      BuildFile before the next job — 5,130 s and still 94 cutover rows, so the latch comes from work that outlives
      BuildFile itself.
      Single-flight oracle after the `>>=` error-channel fix (`runs/single-flight-20261002-141358`): 1088 parity +
      1 new, no REGRESSED, DISAGREE 0, every sample output byte-identical to the committed one (CR aside).
   3. **Race 34's general fix (a per-evaluation replay store).** Its faces fixed today: replay drawing from a
      direct block's variable counter, the type-aware op replay running unmarked (fix 56; the replay driver
      now marks its whole run). The general fix should also remove whole-subtree replay registration at every
      term entry (`registerReplayTermWithContext`: ~19% on the runaway fixture, ~32% inclusive on a mega root);
      its thunks capture the environment (`box s`), so registration cannot simply be deduplicated.
   4. **Mega-root speed.** The evaluator dominates a mega root now (the quiet metronome went from 11.8 s to
      0.7 s of CPU); next costs: telemetry producers still computed in quiet mode (keep each row's kind:
      `forceReplayDriverDrainPassTagged` decides on `snapshotKindCount`), `EvalVisitLedger.key` (a
      StableBindingId per visit), DiagSidecar hot-key counters (they feed retry triage).
      Profile 2026-10-02 (`probe.ps1 mega_lean_cic_bottom_up_kernel -Profile 30`, evaluator thread, inclusive):
      `registerReplayTermWithContext` 35.5% (item 3's whole-subtree registration at every term entry: the walk
      runs on the big stack already, so per-node stack probes are not the cost; the per-node puts are),
      `buildFreshApplyState` 23.3%, `ty` 17.4%, `enqueueParentCacheHandoff` 7.7% of which
      `fireParentCacheHandoffWake` 7.1% — mostly waiting on EvalWorklist's `gate` (its drain is only 1.3%).
      Tried and reverted: running the wake callbacks on a coalesced thread-pool drainer (lean_cic 25.8/28.4/26.9 s
      vs 29.8/48.4 s), but 1 of 3 runs emitted a different residual (49,387 bytes; the row had been 48,383 bytes,
      `b9503cd5f6292933`, in every run since 10-01 08:56): parent-replay timing decides emission order here, so
      the wake must stay synchronous until replay is per-evaluation (item 3).
      Done 2026-10-02 (timing-only, no causal-order change): ~60% of registration was allocation and the GC it
      triggered, not the puts: a fresh `Stack`/`List` per walk regrowing to large-object sizes, and the let/apply
      spine arrays re-collected for the rest of the chain at every nested entry (quadratic copying). Now the walk
      reuses a per-thread `EvalReplayRegistrationScratch`, and `evalReplayLetSpineOf`/`evalReplayApplyChainOf`
      build each chain's spine once (ConditionalWeakTable on the expression). lean_cic 17.7-20.7 s warm (24.1 and
      35.6 s on cold first runs), residual 48,383 bytes with one sha256 across 9 runs; registration 35.5% -> 16.2%
      of the evaluator thread, its GC parking 76% -> 17% of it. `runs/hopac-20261002-111457` (`-Suite all
      -Native -Parallel 2`): 1088 parity + the 1 known `new`, no `missing`/`emitted`/timeout, DISAGREE 0, mega
      residuals unchanged; summed compile time -9 to -17% per suite (lean_cic 28.7 s vs 47.8 s); the 4 runaway rows
      11.3-11.7 s (were 14.5-16.5 s against the 17 s deadline, with more workers then). The 11 brzozowski contract
      rows whose residual changed already differed between the two runs before (emission order; residual-differs
      in all four runs).
      Also 2026-10-02: `DiagSidecar.noteEjp0011Hot` tokenized every sidecar message to find EJP0011W (~3.5% of the
      evaluator thread); it now checks for the code first. Verification run `runs/hopac-20261002-182701`: no verdict
      or residual change vs `runs/hopac-20261002-153006`, but every timing was slower (3,410 s compiled, runaway rows
      15.2-15.9 s, lean_cic 20-29 s rising run over run on an idle machine): the laptop CPU reported 70% of nominal
      performance (Balanced scheme), so compare timings only within one session's conditions.
      Not a lever: GC configuration. `PollGC` shows as 52.8% of the evaluator thread's self time in the sampled
      profile, but that is mostly the sampler's own runtime suspension (EventPipe suspends threads like a GC does).
      lean_cic x3 per variant, all with the same residual: default 17.2-17.6 s; `DOTNET_GCgen0size` 256 MB
      18.5-20.3, 512 MB 18.4-19.0; +gcConcurrent=0 18.4-19.5; +workstation GC 18.6-19.1; +TieredPGO 21.1-30.9.
      Judge allocation fixes by wall time and by frames' inclusive shares, not by PollGC. `scripts/test.ps1` still
      sets the 256 MB gen0 (it helped before today's allocation fixes); compare a suite with and without it before
      dropping it.
      Mega roots, single-flight vs hopac (2026-10-01/02): brzozowski 2.0 vs 5.1-6.3 s, lean_cic 4.2 vs 30.9-47.8,
      omniledger 5.0 vs 33.3-33.8, spiral_proves_spiral 8.1 vs 51.8-64.7, zeta 2.3 vs 10.1-11.1.
   5. Before any commit: a single-flight restore run (hopac suites rewrite the tracked sample outputs).
   6. **Output convergence with single-flight (2026-10-02 evening).** Of the 65 rows whose hopac output differed
      (`parity-residual-differs`), about 48 are now byte-identical to single-flight's (53 while BackendSwitch
      evaluated every branch, reverted below; confirm the count on the next full suite). Causes fixed:
      - pair traversal was tail-first in `dataPostorderChildRelation` (join point call arguments and renamed globals
        came out reversed) and in hopac's `dyn` (`(0, 0)` and nested constructor arguments bound in reverse order);
      - single-flight's F# union declarations numbered cases by their index in the whole union while every use
        numbered them by position among the emitted cases (`US1_1` declared, `US1_0` used: the F# didn't compile for
        GADT-refined unions; single-flight fixed, outputs re-blessed);
      - a while condition deferred at the synchronous JP boundary was pushed with a placeholder type and used no
        variable number (`while_*`, `native_cube_*`);
      - `seq_apply`'s structural return check lacked records, so a closure returning a record stayed let-bound
        (`native_prototype_record_callback`);
      - `negative_programmed_endpoint_cross_codomain/package.spiproj` started with a YAML `---` line both cores
        rejected at 0:0.
      Tried and reverted: evaluating every `BackendSwitch` branch like single-flight (it converged
      `native_float_nan_is` and the format_any samples, but other-backend branches spawn async join point
      specializations: ~4 s more on formatting-heavy code, suite timeouts). Left: the 11 brzozowski contracts (one
      extra variable number on the recursive join point call path, and run-to-run variation from async JPs) and
      `native_float_nan_is` / format_any (the BackendSwitch numbering above).
   7. **Night of 2026-10-02: structure, backends, dead code** (verification: both builds clean; suites pending).
      - Onion steps 0-5 (restructuring the merged file layer by layer; the step inventory was a session note, not
        in the repo): `upstream.py` handles nested `#if` (Utils was cut at 6 lines);
        `scripts/projection-hash.ps1` hashes both cores' projections (a pure marker move must not change them);
        `module HopacExtensions` re-paired so no pair straddles it; the Utils pair split (its hopac side was 36k lines
        of hopac-only machinery, now a hopac-only region after a 61-line pair); the file header shared with hopac's
        8k-line preamble kernel as a hopac-only region; SpiProj unified (single-flight's text, both cores).
      - Dead code: 6.4k lines of hopac-only functions nothing referenced, removed to a fixed point (432, 118, 53, 27,
        11, 4, 1 definitions per round; functions only, since a module-level value may run for its side effect);
        two modules left empty were dropped. Single-flight's projection unchanged.
      - TypeScript backend: shared section `/// ## CodegenTypescript` (after CodegenLua), `.ts` in the host, a
        `C,TypeScript,Cpp,Python` harness set (`tests/harness.psd1`) with 14 `ts_*` fixtures; TypeScript runs on node
        through `tests/native-shims/run_main.mjs` (worker with a 1 GB stack); all 14 agree with the C oracle. Chars are
        UTF-8 bytes as in C.
      - C++/CUDA/Python synced to upstream `host_cpp_and_cuda_backend` 0cb0fda0: CodegenCpp and CodegenPython are
        now one shared section each (two pairs gone), CodegenUtils/CodegenAdapter updated, the backend is named
        `CppHost`, and `StackRefs`/`HeapRefs` layouts were ported into both cores (Layout/Op cases, Infer, PartEval,
        an error arm in every other backend). Native tiers: C++ (`tests/native-shims/cpp_native.py`, g++; nvcc only
        when `join_backend CudaHost` leaves a non-empty `.cu`); Python (`run_main.py`, numpy CPU fallback without a
        GPU). `lib/spiral/backend.spi` has `CppHost`/`TypeScript` keys.
        Status of the 14 `ts_*` fixtures (`runs/single-flight-20261004-235909`): C++ 8 compile and agree with C; 6 are
        blessed `error` rows, each an upstream limit of the C++ backend or of the core library, not a sync bug:
        `ts_array_union` (array length: arrays are bare pointers in C++), `ts_closure_return` (a plain function has no
        composable type: convert it to a closure), `ts_string_slice` (no native string slice), `ts_string_concat`
        (`StaticStringConcat` with 2 args, upstream CodegenCpp), `ts_float_nan` and `ts_while_loop` (the fixture's own
        `!!!!BackendSwitch` has no `CppHost` key; adding one is a fixture change). Python: 9 agree, 2 Known
        (`ts_int_wrap`: unbounded ints; `ts_string_slice`: code-point indexing), 3 blessed `error` (`ts_string_concat`
        as above; `ts_float_nan`, `ts_while_loop`: no `Python` key in that `!!!!BackendSwitch`). Plus `python_macro_annotations` (agrees) and
        `python_foreign_array_index` (Python only, no C oracle).
      - Later the same night: onion steps 2 (HopacExtensions unified: single-flight's top-level opens and `>>**` shared,
        hopac's nested module a hopac-only region) and 6 (BlockBundling residual: single-flight's text shared, hopac
        keeps 3 opens); single-flight's projection unchanged (`c5d4c508694feff8`). Verified 2026-10-03: hopac builds and
        `runs/hopac-20261003-050046` reproduces the whole oracle (every row parity, DISAGREE 0); 636 of 657 hopac `ok` rows
        are byte-identical to single-flight (brzozowski x10, format_any x4, native_float_nan_is x3, ts_float_nan x2,
        ts_array_union Python, and another session's new python_foreign_array_index differ).
      - Oracle re-blessed `single-flight-20261003-030150` (reproduced row for row by `-031154`): adds the 28 ts_* Cpp/Python
        rows. codegenRust translates lib/spiral's Fable Rust type aliases (`fableRustAliases`):
        reads `Fable.Core.Emit("R<$0>") ... type A<'T>` out of globals, drops F#-only globals, rewrites `A<x>` to `R<x>`.
      - `codegen_runtime_file` also looks in the workspace (`apps/compiler/runtime`, `deps/spiral/apps/compiler/runtime`):
        the notebook kernel and polyglot's Supervisor don't ship corelib.* next to their DLL (Supervisor.dib's Python
        test failed with "Cannot find the codegen runtime file corelib.py"). The single-flight supervisor answers
        BuildFile only after writing every file (a multi-file backend's caller compiles the siblings).
      - Notebooks: `spiral cpp --cpp-path` (spiral.dib `process_cpp`: g++ or `SPIRAL_CXX`, then runs the binary) behind
        Eval's `///> cpp` route; Supervisor.dib's Python/Cpp expectations are the multi-file outputs joined in file
        order. Lib cells on cpp need `CppHost` arms in lib/spiral (3 today vs 144 `Python` keys).
      - Host outputs are CRLF on Windows (codegen `AppendLine`); git normalizes them, but feed LF to Builder/Fable.
   History of the day: "Session 2026-10-01" above and FRONTIER.md's status lines.
1. **Done (FRONTIER fix 49): the 5 mega `brzozowski` rows with a wrong oracle**, blessed as `error`. Original notes: Cause, in *both*
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
