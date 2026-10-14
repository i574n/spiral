# hopacsota plan

Written 2026-10-13 23:15. hopacsota is the parallel compiler core that replaces gpt5parallel. It is started over
from single-flight's evaluator (the upstream shape) with the Hopac way taken fully, and every phase passes
gates a script can fail. This file is the contract. A change to a decision below goes into "Decision
changes" at the bottom, with the measurement that justified it, in the same change as the code. A decision
that changes without such an entry is drift. Revert it.

## Why gpt5parallel drifted (the failures this plan is built against)

Measured on gpt5parallel's side of `spiral_compiler.fs` (2026-10-13):

| Fact | Number |
|---|---|
| gpt5parallel-only lines / whole file | 159,083 / 186,186 |
| its PartEval vs single-flight's PartEval | 104,778 vs 2,967 lines |
| speed vs single-flight | 2.65x slower overall (interleaved A/B), 6.9x on runtime_bench |
| CPU in replay bookkeeping | about half: `jpRecordCurrentWorkOperation` 23%, `buildFreshApplyState` 18%, `jpStoreDeclaredLetContinuation` 8% |
| `ConcurrentDictionary` uses | 301 |
| `lock` / `Monitor` sites | about 88 |
| `Promise.Now.isFulfilled` / `IVar.Now.*` polls | 22 / 11 |
| `withNack*`, `Alt.prepare*`, `Proc`, `Latch`, `MVar`, `Lock`, `BoundedMb`, `Job.server`, `Scheduler.create` | 0 |

The fix classes in `lanes/gpt5parallel/FRONTIER.md` (58 numbered fixes):
- **Replay.** Re-running evaluation to resume it was wrong in nine ways: fixes 4, 14, 16, 23, 24, 34, 41, 42
  and 56, several of them silent miscompiles.
- **Placeholders.** A pending cell was read as if it were filled: fixes 8, 25, 44, 45, 46, 47 and 50.
- **Ordering.** Arguments or statements were permuted: fixes 18, 20 and 22.
- **Process-wide or shared mutable state.** Fixes 7, 12 and 30.
- **Telemetry on the hot path.** Fixes 6, 15, 32 and 39. Each committed value was SHA-256 hashed, and the
  diagnostic `.jsonl` grew to 7.5 GB.
- **Timing heuristics.** Fixes 9, 35, 48 and 58 killed or failed live builds.
- **Stack.** Fixes 19 and 21.

The root decision behind all of these: gpt5parallel made every evaluation step a resumable unit and recorded
steps in order to replay them. The record had to be locked, interned and hashed, and the replay had to be
right in every corner. hopacsota never records evaluation and never replays it.

## The technical core (read from single-flight's PartEval)

Three facts in single-flight make a join-point body a unit that can run on its own:

1. **A join-point body is evaluated in a fresh environment.** `EJoinPoint'` (`spiral_compiler.fs` ~163002-163015)
   builds a new `LangEnv` with `seq = ResizeArray()`, `cse = [Dictionary()]`, `unions = Map.empty` and
   `i = ref 0`. Closures (`closure_env`, ~162396) and type join points (~162572) do the same. Residual
   variable numbers are local to the body.
2. **Output names come from codegen, not from evaluation order.** Codegen names a method when its traversal
   first reaches it: `method (a,b)` with `method_names.[(method (a,b)).tag]` (~165176, the same in every
   backend). The order in which bodies finished does not reach the text.
3. **The cache key fixes the result.** A specialization is keyed by `(backend, body)` plus the hash-consed
   `(env_global_value, env_global_type)` (~162993-162995). Its result `(seq, ret_ty)` is determined by that
   key and by the global state listed below.

The caller of a join point needs only `ret_ty`. Single-flight takes it from the annotation when there is one,
and otherwise evaluates the body first (~162997-163022). Closures always carry `fun_ty`.

**Consequence.** A specialization whose return type is known (annotated method, closure, or a type join point
with its type known) can be evaluated by another job while the caller continues. One whose type is not known
has to be awaited, or evaluated in place by the first caller that needs it. If every shared table is filled
once per key and order-sensitive global effects are merged in a fixed order, the output does not depend on the
schedule. This is determinism by construction: no recording.

## Decisions

Each decision has an id. Code and reviews cite the id.

- **D1. Unit of parallelism = one specialization body** (method, closure or type join point), evaluated with
  single-flight's own code. Inside a body, evaluation is plain, direct-style F# recursion, at single-flight
  speed. Hopac is used only at specialization boundaries. Nothing inside a body is a job.
- **D2. No recording and no replay.** No identifier containing `replay`, `record`, `resume`, `snapshot` or
  `ledger` may appear in hopacsota code (gate G2).
- **D3. One fill-once cell per specialization key.** It is an `IVar<SpecResult>` held in a sharded table
  that is owned by its server jobs (`Job.iterateServer` per shard) and queried with `*<-=>-`, a request
  carrying a reply IVar. Each entry is created by its first claim and filled exactly once. The claim returns
  a capability: `Owner of Filler | Waiter of Promise<SpecResult>`. Only an `Owner` can fill, so the type
  system rules out "filled twice". There is no `ConcurrentDictionary` and no lock.
- **D4. A pending key that is waited on.**
  - A caller that needs `ret_ty` from a key it does not own blocks on that key's promise.
  - A cycle is a recursion. It raises single-flight's error, "Recursive join points must be annotated.", at
    the same trace position as single-flight.
  - **Detection.** Each `Owner` records its own key and its ancestor chain, the keys it is evaluating on its
    current path. Before blocking, a waiter adds an edge `waiter key -> awaited key` to the wait-for graph,
    which is owned by a server job. The server rejects any edge that closes a cycle.
  - **Which error wins.** If several jobs would raise, the reported error is the one single-flight would
    have raised: the one earliest in single-flight's depth-first evaluation order (D6).
- **D5. A local scheduler per compile.**
  - Created with `Scheduler.create`.
  - `MaxStackSize` is the same 1.5 GB that single-flight's `peval` thread uses.
  - `NumWorkers` comes from `SPIRAL_HOPACSOTA_WORKERS`, default `ProcessorCount`.
  - `TopLevelHandler` turns an unhandled exception into a structured compile failure.
  - `IdleHandler` counts idle transitions for the HUD.
  - The end-of-peval barrier is "the root promise is filled, then `Scheduler.wait`".
  - `Hopac.run` is called once, at the compile entry.
- **D6. Canonical order for order-sensitive effects.**
  - `globals` (peval's `global'`, ~162676, appends text in first-seen order and reaches the output) is
    recorded per specialization as an ordered list. It is merged afterwards by a depth-first walk of the
    specialization tree in single-flight's order: the order in which single-flight would have entered each
    child key while evaluating its parent.
  - Diagnostics and errors use the same order.
  - This is a deterministic fold over finished data, the same kind of thing as Bend's join slots: each child
    fills its own slot and the parent's order is fixed by the program. It is not a replay of evaluation.
- **D7. Idempotent caches stay caches.**
  - `backend_switch_validated` (~162354) holds the same value whoever fills it, so it is a fill-once table
    like D3.
  - The `backend_switch_validation_tags` counter starts at `1 <<< 30` and is local to each validation, so it
    stays as it is.
- **D8. Phantom types and units on day one, limited to:**
  - `int<varTag>`, `int<methodTag>`, `int<closureTag>` and `int<typeTag>` as F# units of measure. They cost
    nothing at run time and make it a compile error to mix a residual variable number with a method tag.
  - `SpecKey<'kind>` with `'kind` one of `MethodKey | ClosureKey | TypeKey` (empty marker types), so the
    three tables cannot be confused.
  - `TagSpace<'space>` with `'space` one of `Residual | Validation`, so a validation tag (`1 <<< 30`) cannot
    reach a residual. Today that is only a convention (`tmp/AGENTS.md`, BackendSwitch paragraph).
  - The `Owner`/`Waiter` capability of D3.

  Nothing else on day one. More phantom typing is a decision change with a reason.
- **D9. Structs and inlining where measured.** Keys, events and claims are `[<Struct>]` and the boundary
  helpers are `inline`. Each one is kept only if `hopac_speed_ab.ps1` shows it does not slow the build down;
  Hopac's own Internals note reports up to ~30% from inlining its internals.
- **D10. A layer, not a fork.**
  - hopacsota is its own mode: `-Mode hopacsota`, define `SPIRAL_CORE_HOPACSOTA`.
  - It reuses every single-flight section unchanged. Its code lives only in hopacsota layer sections, whose
    headers end in `Hopacsota`, plus hooks those sections call. The upstream-sync rule forbids `#if` inside
    sections that map to upstream files.
  - Where single-flight needs a seam (the join-point call in `EJoinPoint'`, `closure_convert`, the type join
    point, `global'`), the seam is a hook whose single-flight implementation is the current code, moved
    unchanged.
  - `pair-drift.ps1` learns the third core: a `Hopacsota` layer may change on its hopacsota side alone, and a
    change to a seam must keep single-flight's projection hash unchanged (`projection-hash.ps1`).
- **D11. gpt5parallel is reference only.** It keeps building and passing until hopacsota is promoted. No code
  is copied from it into hopacsota; ideas are taken from its FRONTIER.md fix list only.
- **D12. Bend 2 lessons that apply** (read: BendRT paper in full, BendTT pp. 1-6, and `term_wnf`,
  `compare_go`, `def_check`, `def_inst`, `memo`, `compile_book` and `emit_fork` in `bend2/`):
  - *One text, two readings.* Every fork site in Bend's emitted C runs sequentially (`seq`) or in parallel
    (`!seq`) from the same source. In hopacsota, the boundary hook reads a policy: `Inline` (single-flight
    order), `Deferred` (sequential worklist) or `Parallel` (a Hopac job). Bodies never change.
  - *A growth cap gives an error instead of a hang.* `def_inst` rejects a template key longer than 32 KB
    with "a ~ argument that stops growing". Spiral's `EJP0040` (`SPIRAL_IF_NESTING_LIMIT`) is the same
    idea. Keep it, as a deterministic counter. Never use a timer (gpt5parallel fixes 9, 35, 48 and 58).
  - *A memo per unit.* Bend's `memo_gc` clears its memo tables before each definition. hopacsota's
    per-body tables (cse, unions, numbering) are per-body values, never shared.
  - *Fixpoint over facts.* `compile_book` repeats its whole-program analysis until the fact count stops
    changing. That fits a later analysis pass, not peval.
  - *Effects outside the evaluator.* Bend's machine does no IO; effects are requests answered by an event
    loop. hopacsota's diagnostics and HUD events are data posted to a stream (D13). The evaluator never
    writes a file or the console.
  - *Report losses honestly.* The Bend paper publishes the benchmarks it loses (n-queens, symbolic
    regression on the GPU). Every hopacsota speed table lists every mega root, losses included.
  - *Divergence, on purpose.* BendRT has no work stealing. The program must fork equal halves, and the
    runtime runs in bulk-synchronous waves. Join-point specializations are irregular and cannot be made
    equal, so hopacsota keeps Hopac's per-worker scheduling and does not adopt Bend's cube.
- **D13. Diagnostics and tracing cost nothing when off.**
  - Events are `[<Struct>]` values posted to a `Stream.Src` only when a static readonly flag is set. The JIT
    folds the check away when the flag is off.
  - Errors are a typed `Diagnostic` union with a code, spans and notes, rendered by the rustc-style renderer
    that already exists (`RunawayUnrollDiagnostic`, ~162254).
  - A stall prints the wait-for graph of D4.
  - There is no hashing on any path and no JSONL unless a consumer asks for it.
- **D14. The HUD is a consumer.** It taps the event stream (`Stream.Src.tap`, then `debounce`/`buffer`) and
  shows per-worker current specialization, frontier size, filled count and blocked waiters. Removing it
  changes nothing in the compiler.
- **D15. The engine interface is portable** to the later self-hosted Spiral compiler (Gleam subjects, Rust
  crossbeam). The evaluator sees only: spawn, a fill-once cell (fill, read), a request/reply to a server, and
  choice over reads. Hopac features beyond that subset (nacks, `Latch`, `Stream`) stay inside the F# engine.

  | Engine operation | Hopac (F#) | Gleam | Rust |
  |---|---|---|---|
  | spawn | `Job.start` / `Job.queue` | `process.start` | `rayon::spawn` / crossbeam scope |
  | fill-once cell | `IVar` | a process holding the value + `Subject` replies | `OnceLock` + waker, or a oneshot channel |
  | server request/reply | `Job.iterateServer` + `*<-=>-` | actor + `process.call` | thread + crossbeam channel + oneshot reply |
  | choice over reads | `Alt.choose` / `<\|>`, left-biased | `process.select` (selector order) | `crossbeam::select!` with `biased` |
  | cancel a speculative job | `withNackJob` | monitor + kill | a cancellation flag polled at boundaries |

- **D16. Parallel evaluation is a requirement, not a hypothesis.** Codebases far larger than today's corpus
  are coming, and one evaluator thread cannot scale to them. A measurement can change *how* evaluation is
  parallel, never *whether*. A long span is shortened, in this order of preference:
  1. **Fork every body whose type is known.** Annotated methods, closures (always typed by `fun_ty`) and
     type join points run as jobs as soon as their key exists.
  2. **Speculate on unannotated bodies.** When a key is first seen, start its body at once, before any caller
     needs its type. Losers of a race are dropped (`withNackJob`; a blocked, unreachable job is just
     collected). The result is the same whoever finishes first (D3).
  3. **Return-type hints from the previous build.** Read them as a guess that lets the caller continue, and
     check the guess against the body's real type once the body finishes. A wrong guess re-runs the caller
     from its start, deterministically. This is a restart of a pure computation, not a replay of recorded
     steps (D2). It is measured before adoption.
  4. **Parallelism beside peval.** Parsing per file, type checking per package and codegen per method run in
     parallel too, and pipeline into peval: a package's evaluation starts as soon as its type check is done.

  Never: a placeholder type that callers read before it is filled. That was gpt5parallel's failure class
  (fixes 8, 25, 44-47, 50).

## Banned in hopacsota code (gate G2)

`ConcurrentDictionary`, `lock`, `Monitor.`, `Interlocked.` (except inside the engine module, one allowlisted
counter per use with its reason), `Promise.Now.`, `IVar.Now.`, `Hopac.run` (except at the compile entry),
`ThreadLocal` (Hopac jobs move between threads; single-flight's `DynamicIfNesting.depth` and
`RustGapTrace.validating` become per-body values passed in the environment), `Thread.Sleep`, `Stopwatch` or
`DateTime` in a decision (a timeout may only produce a report, never change a result), `SHA256`/hashing for
telemetry, `<~>`, `Alt.chooser`, `Alt.random`, `Job.Random` (choice must be left-biased and deterministic), and
the D2 identifiers. The allowlist lives in `scripts/hopacsota-lint.ps1`, one line per exception with its
reason.

## Shared state inventory (Phase 0 output, R2)

Every mutable thing reachable from single-flight's `peval`, and its hopacsota discipline. R2 completes this
table with the line of every access, so nothing is found later by a race.

| State | Where | Order-sensitive? | Discipline |
|---|---|---|---|
| `join_point_method` / `join_point_closure` / `join_point_type` | `peval` locals ~162349 | no (keyed) | D3 fill-once tables |
| per-body `HashConsTable` (keys) | `Utils.memoize ... HashConsTable()` | ids are counters | already locked (`sync_root`, ~7143); R2 checks whether an id reaches the output; if not, allowlist; if so, replace with structural keys |
| `backend_strings` | `peval` local, a `HashConsTable` | ids | as above |
| `backend_switch_validated` (+ `_hc`) | ~162354 | no | D7 fill-once |
| `globals` (`global'`, `GlobalsIndex`) | ~162676, ~162324 | **yes** | D6 per-spec list + canonical merge |
| `is_metavar` | ~162215 | R2 decides | R2 |
| `RustGapTrace.seen`, `.validating` | ~162332 | stderr only | per-body value + canonical merge of reports |
| `DynamicIfNesting.depth` | ~162315 (`ThreadLocal`) | no | per-body counter in `LangEnv` |
| `RunawayUnrollDiagnostic.sourceLines` | ~162255 (`ConcurrentDictionary`) | no | read-only file cache: load sources once before peval |
| top env: `nominals`, `prototypes_instances` | `PartEvalTopEnv`, immutable `Map`s | no | read-only during peval (R2 confirms) |
| compile-time `DHashMap` / `DHashSet` | `Data` values | n/a | cannot cross a join point (~161840-161841), so they stay inside one body; R2 checks BackendSwitch arms that touch them |
| which error is reported when several bodies fail | | **yes** | D4/D6 canonical order |

## Phases and gates

A phase starts only when the previous phase's gate numbers are written into this file's scoreboard (bottom).
Every gate is a command plus a number. "Looks fine" is not a gate.

### Phase 0: research and measurement (no hopacsota code)

- **R1. Read the rest of Bend 2.** BendTT §6-end, `bend.ts` `term_check` and `term_infer`, the checker
  benchmarks' method (`bench/checker`), and `comp.ts` `emit_match` and `emit_task`. Output: additions to D12.
  Every claim cites a file and function.
- **R2. Finish the shared state inventory.** Every row above gets the line of every access. Gate: no row
  without a line, and each "R2 decides" is decided.
- **R3. Measure the parallelism that exists.** This measurement steers the design (D16). It is not a go/no-go:
  parallel evaluation is a fixed requirement.
  - Instrument a Debug single-flight built from a copy (`build.ps1 -Mode single-flight -Configuration Debug
    -CoreSource <copy>`; the copy is never committed).
  - Per specialization, dump: key kind, annotated or not, self time (inclusive time minus its children's),
    the parent, and the children that were awaited (their type was needed) vs fire-and-forget (type
    known).
  - Run it on the 5 mega roots and apps/spiral.
  - Compute work W, span S (the longest chain of awaited dependencies plus self times), and the simulated
    time at 1, 2, 4 and 8 workers (greedy list scheduling over the dependency graph).
  - Also run it on a scaling corpus, since the targets are codebases far larger than today's samples:
    apps/spiral, all of lib/spiral as one build, and a generated program with N independent modules and a
    deep join-point graph (N = 10, 100, 1,000). Report how W, S and W/S grow with N.
  - **Rule:** where the span S is long, the output is a list of the dependency chains that make it long,
    with the shortening technique for each (D16). Never a recommendation to stop evaluating in parallel.
- **R4. Prove the order independence on single-flight before any thread exists.**
  - In the same Debug copy, evaluate each type-known specialization later from a worklist instead of
    immediately, with three policies: DFS (single-flight's order), BFS, and seeded random (3 seeds).
  - Run `-Suite all` per policy.
  - Gate: residual hashes identical across the policies on every row, or a list of each row that differs,
    with its cause. Each cause becomes a D6/D7 rule or an inventory row.
  - R4 is the cheapest test of determinism by construction. If it fails, the design changes before any
    Hopac code.

### Phase 1: the layer and the deferred worklist (single thread)

- `-Mode hopacsota` and `SPIRAL_CORE_HOPACSOTA` in `build.ps1`, `test.ps1`, `probe.ps1`, `env.ps1`,
  `projection-hash.ps1` and the core project. Use the same mode plumbing as gpt5parallel.
- The seam hooks of D10, with single-flight's code moved unchanged as the single-flight side.
  `projection-hash.ps1` proves single-flight's projection hash is unchanged.
- `scripts/hopacsota-lint.ps1` (G2) and the size budget (G1), run by `build.ps1 -Mode hopacsota`.
- The deferred policy: type-known specializations go to a single-threaded worklist; D3 tables, D6 merge,
  D8 types.
- New frontier fixtures, each written before its code with its oracle row blessed from single-flight:
  - `frontier_hopacsota_recursion_unannotated`, which must reproduce single-flight's "Recursive join points
    must be annotated." at the same position;
  - `frontier_hopacsota_mutual_pending`, two join points that call each other from separate branches;
  - `frontier_hopacsota_globals_order`, where globals are added from sibling bodies in an order that differs
    from completion order;
  - `frontier_hopacsota_two_errors`, two failing bodies where single-flight reports the first in its order.
- **Gate 1:**
  - G1 and G2 pass;
  - `-Suite all` has 0 differences against the oracle with the Inline policy and with the Deferred policy
    (DFS, BFS, 3 random seeds);
  - Inline-policy time ≤ 1.05x single-flight on `hopac_speed_ab.ps1` (interleaved A/B, mega roots).

### Phase 2: the Hopac engine

- The Parallel policy: a local scheduler (D5), owner jobs per specialization, D3 servers with sharded
  tables, the D4 wait-for server, and the D13 event stream (off by default).
- **Gate 2:**
  - 0 differences on `-Suite all` at `SPIRAL_HOPACSOTA_WORKERS` = 1, 2, 4 and 8;
  - `probe.ps1 -Repeat 5` at 8 workers gives identical residual hashes on the five mega roots and every
    frontier fixture;
  - 1-worker time ≤ 1.05x single-flight;
  - G1 and G2 pass.

### Phase 3: speedup

- Tune the granularity: below a measured body cost the policy runs the body inline. That is Hopac's `<*>`
  idea, "the runtime may run them sequentially", with the cutoff measured, never guessed.
- **Gate 3:**
  - the 8-worker speedup on the mega roots and apps/spiral is published as a full table (every root, losses
    included), against the R3 simulation;
  - success means at least half of R3's simulated speedup on 4 of 5 mega roots, and a speedup that grows with
    N on the scaling corpus. If either is missed, the next step is the next D16 technique for the chains the
    profile names. Phase 3 stays open until the gate passes.

### Phase 4: diagnostics and tracing (D13)

- **Gate 4:**
  - with tracing compiled in but off, time is within noise of a build without it (interleaved A/B, 3
    rounds);
  - every error single-flight can report renders with a code and span;
  - a stall prints the wait-for graph.

### Phase 5: the HUD (D14)

- **Gate 5:** with the HUD attached, residuals are unchanged and the slowdown is measured and published.

### Phase 6: promotion

- The promotion criterion from `tmp/AGENTS.md`, applied to hopacsota:
  - `-Suite all` with no `missing`;
  - native `DISAGREE` 0;
  - every row `ok`;
  - `apps/spiral` compiles;
  - plus Gate 2's determinism check.
- Then gpt5parallel's 159k lines are deleted. That deletion is the user's call, as a tracked-file
  deletion.

### Phase 7: the port contract (D15)

- Write the engine interface as a Spiral module signature that the self-hosted compiler implements on Gleam
  and on Rust. Gate: frontier fixtures compiled by a Spiral-hosted engine on one backend. That is a separate
  epic, planned when Phase 6 is done.

## Gates every phase runs

| Gate | Command | Pass |
|---|---|---|
| G1 size | `scripts/hopacsota-lint.ps1 -Size` | hopacsota layer sections + hooks ≤ 2x single-flight's PartEval (≤ 5,934 lines); no single section over 1,000 lines |
| G2 banned | `scripts/hopacsota-lint.ps1 -Banned` | 0 hits outside the allowlist |
| G3 oracle | `scripts/test.ps1 -Mode hopacsota -Suite <phase's suites>` | 0 differences |
| G4 determinism | `scripts/probe.ps1 <root> -Mode hopacsota -Repeat 5` at max workers | identical residual hashes |
| G5 speed | `hopac_speed_ab.ps1` (interleaved A/B with single-flight) | phase threshold; the table is kept in the scoreboard |
| G6 single-flight untouched | `scripts/projection-hash.ps1` | single-flight projection hash equal before and after |

## Process rules (against drift)

1. **A phase starts only when the previous gate's numbers are in the scoreboard.** Starting early is drift.
2. **No telemetry without a moved fixture.** The `tmp/AGENTS.md` rule carries over. A change that adds
   events or HUD lanes and moves no gate number is not progress.
3. **Every speed claim is an interleaved A/B on a quiet machine,** run alone (one heavy job at a time).
4. **Root cause before workaround.** A failing row gets a reduced `frontier_hopacsota_*` fixture first.
5. **A decision change is written before its code,** in "Decision changes" below, with the measurement.
6. **Backlog.** One eoie story per phase (`HOPACSOTA-P0` … `HOPACSOTA-P7`) carries the gate command and
   status. Progress is updated with gate numbers, never with prose.
7. **Every session that touches hopacsota reads this file first.** If the code disagrees with a decision,
   stop and fix the drift before adding anything.

## Scoreboard

| Phase | Gate | Date | Numbers | Run id |
|---|---|---|---|---|
| 0 | R1 | | | |
| 0 | R2 | | | |
| 0 | R3 | | | |
| 0 | R4 | | | |

## Decision changes

- **2026-10-13 23:2x, user: "why you're even considering dropping parallel evaluation? we need that for the
  abyssal codebases that'll come".** The first version of R3 made the measurement a go/no-go: below 1.5x
  simulated speedup, parallelism would move away from peval. That clause entered with this plan; it did not
  come from the user. It is removed. Added D16 (parallel evaluation is required; long spans are shortened by
  forking typed bodies, speculation, type hints, and parallel stages beside peval) and a scaling corpus in R3.
