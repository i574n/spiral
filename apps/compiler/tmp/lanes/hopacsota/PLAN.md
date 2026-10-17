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
| CPU in replay bookkeeping | about half (the three functions below) |
| `ConcurrentDictionary` uses | 301 |
| `lock` / `Monitor` sites | about 88 |
| `Promise.Now.isFulfilled` / `IVar.Now.*` polls | 22 / 11 |
| `withNack*`, `Alt.prepare*`, `Proc`, `Latch`, `MVar`, `Lock`, `BoundedMb`, `Job.server`, `Scheduler.create` | 0 |

The replay bookkeeping: `jpRecordCurrentWorkOperation` 23%, `buildFreshApplyState` 18%,
`jpStoreDeclaredLetContinuation` 8%.

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

Four facts in single-flight. The first three make a join-point body a unit that can run on its own; the
fourth says when its shared state is final:

1. **A join-point body is evaluated in a fresh environment.** `EJoinPoint'` (`spiral_compiler.fs` ~163002-163015)
   builds a new `LangEnv` with `seq = ResizeArray()`, `cse = [Dictionary()]`, `unions = Map.empty` and
   `i = ref 0`. Closures (`closure_env`, ~162396) and type join points (~162572) do the same. Residual
   variable numbers are local to the body.
2. **Output names come from codegen, not from evaluation order.** Codegen names a method when its traversal
   first reaches it: `method (a,b)` with `method_names.[(method (a,b)).tag]` (single-flight's F# codegen
   ~166398; ~165223 is gpt5parallel's copy; the same in every backend). The order in which bodies finished
   does not reach the text.
3. **The cache key fixes a successful result.** A specialization is keyed by `(backend, body)` plus the
   hash-consed `(env_global_value, env_global_type)` (~162993-162995). A successful result `(seq, ret_ty)` is
   determined by that key and by the shared state in the inventory below. A failure is not: a body inherits
   context from the caller that first evaluates it, outside the key (`trace`, `inline_depth`, the dynamic-if
   depth, the BackendSwitch validating flag, the stack depth; inventory entries of those names). That context
   decides whether and where `EJP0011`/`EJP0040` fire, the trace each residual statement stores (read only by
   codegen errors), and whether RUST-GAP reports are printed. D3 and D6 fix it to the canonical caller (P1).
4. **Codegen is not a read-only phase.** `PartEvalResult.ty_to_data` and `nominal_apply` (~164584-164585) close
   over the evaluator; codegen calls them and can fill `join_point_type`, build `Union`s and evaluate `TTerm`
   bodies, and every backend appends to `globals`. Peval's shared state stays live until codegen ends (P5).

The caller of a join point needs only `ret_ty`. Single-flight takes it from the annotation when there is one,
and otherwise evaluates the body first (~162997-163022). Closures always carry `fun_ty`.

**Consequence.** A specialization whose return type is known (annotated method, closure, or a type join point
with its type known) can be evaluated by another job while the caller continues. One whose type is not known
has to be awaited, or evaluated in place by the first caller that needs it. If every shared table is filled
once per key, order-sensitive global effects are merged in a fixed order, and a body that would fail or print
differently under another caller's context is evaluated again in the canonical caller's context, the output
does not depend on the schedule. This is determinism by construction: no recording.

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
  - **The owner's context is relative (P1).** An owner that runs a body as a fork or a speculation, not inline
    in its caller, evaluates it with a relative context: its own frame as the trace, `inline_depth` and the
    dynamic-if depth 0, not validating. Its `SpecResult` records the maximum relative depths it reached. D6
    decides at the merge whether the body is evaluated again with the canonical caller's context.
  - **Three tables, one discipline.** `join_point_method`, `join_point_closure` and `join_point_type` are all
    D3 tables. `join_point_type` stays one during codegen, which can still fill it (core fact 4, P5); a union
    built in a type join point is compared by reference, so two fills of one key would make two unequal types.
  - The per-family `HashConsTable` that interns keys keeps its lock (shared code, allowlisted in G2): its ids
    reach key equality only, never text or order (inventory).
- **D4. A pending key that is waited on.**
  - A caller that needs `ret_ty` from a key it does not own blocks on that key's promise.
  - A cycle is a recursion, and single-flight has three pending cases (P3). Each happens only when the
    awaited key is on the waiter's own ancestor chain; any other pending key is awaited:
    - a method key: single-flight's error "Recursive join points must be annotated." (~163000), at the same
      trace position as single-flight; an annotated method is not pending, its type is the annotation.
      Checked 2026-10-14: the typechecker's fill pass annotates every join point with its inferred type
      (`RawAnnot(r, RawJoinPoint ..., annot r x)`, ~50402), so from type-checked source every method key
      carries an annotation and that error is unreachable. hopacsota keeps it as a defensive compiler
      error; it needs no waiter rule;
    - a type join point: "Type join points must not be unboxed during their definition." (~162576), except
      inside `ty_is_uninhabited`, which swallows that error and reads the type as inhabited (~162555);
    - a closure: no error; the recursion returns the key (~162425-162426), since `fun_ty` is known.
  - **Detection.** Each `Owner` records its own key and its ancestor chain, the keys it is evaluating on its
    current path. Before blocking, a waiter adds an edge `waiter key -> awaited key` to the wait-for graph,
    which is owned by a server job. The server rejects any edge that closes a cycle.
  - **Which error wins.** If several jobs would raise, the reported error is the one single-flight would
    have raised: the one earliest in single-flight's depth-first evaluation order (D6).
- **D5. A local scheduler per compile.**
  - Created with `Scheduler.create`.
  - `MaxStackSize` is the same 1.5 GB that single-flight's `peval` thread uses. A job starts on a fresh stack,
    where single-flight runs a body nested inside its callers, so the stack check behind `EJP0011`
    (`TryEnsureSufficientExecutionStack`, ~49283) can pass in hopacsota where single-flight stopped. D6's
    restart covers the `inline_depth` limit, not the stack; R4 reports any corpus row that hits the stack check.
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
  - Diagnostics and errors use the same order, and so do the evaluator's other ordered effects: `PrintStatic`
    and `PrintRaw` stdout (~164373-164375) and RUST-GAP reports (~162346). They become D13 events.
  - A BackendSwitch validation is a child node too (P2): its ordered effects are merged at the position where
    single-flight first ran it, whichever body ran it first under hopacsota (D7).
  - Codegen-time globals (core fact 4) are merged in codegen's traversal order (P5).
  - Effects are classed by merge law. A commutative one (maximum depths, HUD counts) merges in any order; only
    an ordered one (globals, diagnostics, stdout, RUST-GAP) needs the walk.
  - **The canonical-context check (P1).** At a child's merge position the canonical caller's context is known.
    The child is evaluated again in place, with that context, when the caller's `inline_depth` or dynamic-if
    depth plus the child's recorded maximum crosses its limit (`EJP0011` at 10,000, `EJP0040` at
    `SPIRAL_IF_NESTING_LIMIT`), when a codegen error needs the child's absolute trace, or when the canonical
    caller was validating (RUST-GAP reports are suppressed there). This is a deterministic restart of a pure
    evaluation, as D16.3, not a replay (D2). R4 counts how often it triggers; if it is frequent, the fork
    boundaries move, the rule does not.
  - This is a deterministic fold over finished data, the same kind of thing as Bend's join slots: each child
    fills its own slot and the parent's order is fixed by the program. It is not a replay of evaluation.
  - Measured 2026-10-15 (R4i, scoreboard): the tree's nodes are the fill-once memos whose miss can emit
    globals. There are exactly four: method, closure and type join points (`join_point_type`), and
    `backend_switch_validated` (D7). Each gets a list on its first evaluation and a reference on every hit,
    and the walk expands a node at its first reference. A merge that rewrites a list also rebuilds that
    list's membership index (`GlobalsIndex`), and evaluation after the walk (codegen-time `ty_to_data`,
    `nominal_apply`) adds no references. With that, dfs, bfs and random orders give single-flight's output
    byte for byte on apps/spiral and the full suite.
- **D7. A cache is idempotent only together with its effects (P2).**
  - `backend_switch_validated` (~162354) holds, per `(backend, arm closure)` key, the arm's type plus the
    ordered effect list of the validation that filled it: globals added (a switch nested in a validated arm
    validates the build backend's arm, which passes the `global'` test at ~164405), static prints, and the join
    point keys it filled. It is a fill-once table like D3. A later visit takes the type and adds nothing; the
    effects reach the output once, through D6, at the validation's first position in single-flight's order.
  - An arm closure that captures a mutable compile-time HashMap or HashSet has no key (~163443) and is
    evaluated on every visit, inside the body that holds the map.
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

  R1 additions (2026-10-14 00:57; read: BendTT pp. 7-10, `bend.ts` `term_infer`, `term_check`, `def_inst`,
  `book_valid`'s header, `comp.ts` `emit_task`, `emit_jump`, `emit_fork`, `emit_match`, `monk_step`,
  `err_post`, and the checker bench method in `gates/perf.ts` and `bend2/docs/gen_pins.ts`). Paths are under
  `%LOCALAPPDATA%\spiral-bin\toolchains\bend`. Applies:
  - *The first caller decides, and Bend gets away with it because it checks in sequence.* `def_inst`
    (`bend.ts` 3739-3775) mints a template instance on its first call and checks it there with the caller's
    depth: `z = (lhs.z ?? 0) + 1`, capped at 64 (3761-3763). The header of `term_check` (3230-3233) and
    `book_valid` (3799-3802) say the same: "minted and checked by its first live call". Single-flight's join
    point bodies inherit `trace`, `inline_depth` and the if-nesting depth the same way. That is fine for a
    sequential checker and not for hopacsota: P1 (adopted; D3, D6).
  - *A pending entry is a cycle only in a sequential checker.* `def_inst` stores the instance bodiless before
    checking it (3768), and a later call that finds `v === null` fails with "a decreasing self-call"
    (3771-3772). Single-flight does the same with its join point dict (163018 then 163000). In hopacsota a
    pending key that is not on the caller's own ancestor chain is waited on: P3 (adopted; D4).
  - *Ids by first-reach count are deterministic only in sequence.* Bend numbers instances by `is.size`
    (`def_inst` 3765), tables by `FL.tabs.size` (`comp.ts` `emit_tab` 2646) and spun segments by
    `FL.spun.size` (`emit_native` 2195). hopacsota mints no id at fill time; names stay codegen's (core fact
    2). G2 adds: no `Count`/`size` of a shared table used as an id in hopacsota code.
  - *Accounting rides alongside and merges by a law.* `term_check`'s header: "resource accounting rides
    alongside the type judgment, it does not steer it" (`bend.ts` 3217-3218). Usage merges with `uses_add`
    (`term_infer` App 3403, `term_check` Let 3550) and at a match with `pmap_union(..., quant_join)` (3658),
    both order-free. hopacsota classifies each per-spec effect by its merge law: a commutative one (P1's
    maximum depths, HUD counts) merges in any order; only an ordered one (globals, diagnostics, stdout,
    RUST-GAP) needs the D6 canonical walk.
  - *A result is first-order data.* "a checked term returns first-order: ... no closure survives"
    (`term_check` header, 3219-3222). A `SpecResult` holds data only (`TypedBind []`, `Ty`, the effect lists).
    Single-flight's `PartEvalResult` hands codegen two closures over live evaluator state (P5, adopted; D16).
  - *The first error in a fixed order.* `book_valid` "throws the first Err" and checks the events in book
    order (`bend.ts` 3779-3781, 3804-3819). That is D4's rule. Bend's GPU runtime does not do this: see the
    last item.
  - *Errors carry expected, observed and a note.* Every `Err(book, ctx, expected, observed, span, def, note)`
    in `term_infer`/`term_check`; `term_check_kind` catches an error and rethrows it with a note and a better
    span (3467-3475); BendTT p. 7-8 prints "expected / observed / Context / Location". D13's `Diagnostic`
    gets `expected` and `observed` fields besides code, spans and notes.
  - *Fork what can fork; deal leaves out while the frontier grows.* The compiler marks each function
    fork-free or not ("A segment may fork if one it reaches does", `comp.ts` comment above `compile_book`,
    2762). The bit is `!forky.has(s.fid)` (2853), where `forky` is the set of segments that fork, closed over
    references (`graph_close`, 2834-2836); `fid_nofk` reads it (3584), so it means "cannot reach a fork".
    `emit_jump` turns a call to a fork-free function into a task only under `!DEVICE && !seq &&
    fid_nofk(fid)` (2076-2079), and `monk_step` lets "a growing lane skip a fork-free one" (4446-4448, 4460)
    and deals fork-free tasks out to other lanes' rings (4474-4476). For Phase 3: mark a specialization body
    that reaches no join point as a leaf (statically from `E`, or from R3's dump), start the bodies that reach
    join points first while the frontier is narrow, and queue leaves to be dealt out, or run them inline below
    the measured cost cutoff. R3 measures the leaf share and its self time before this is used.
  - *A task is first-order data with a slot and a count.* `emit_task` (2066-2070) builds
    `task_node(e, seg, cont, idx, rem)`: function id, captured words, the continuation, the slot it fills and
    the number of children still out. `emit_fork` (2537-2565) makes one join task with `rem = calls.length`
    and one kid per call aimed at its slot; `FID_EXIT` delivers with `task_deliver(e.mem, cont, idx, rv, n)`
    (4430). D6's "each child fills its own slot" is this, and D15's portable engine can carry it as data.
  - *Each branch gets its own copy of the scope's mutable state.* `emit_match` emits every arm with
    `{ ...sc, uses: new Map(sc.uses), spares: sc.spares.slice() }` (2701). Single-flight does the same per
    branch (new `seq`, pushed `cse`: 163188, 163219, 163242). Branches stay inside one body (D1).
  - *A claim is about the code that runs.* BendTT p. 8: the theorem `consistent` is about `Book.check`, the
    function `main` runs, "no model stands between the two", and the parts outside the proof (the parser, the
    TypeScript translation) are named. R4 and Gate 2 run the real core (a Debug copy, then the Release
    build), never a model, and every gate row names what it does not cover.
  - *The bench method* (`gates/perf.ts` header 1-20 and `chk_run` 279-297; `gen_pins.ts` header 1-20,
    `runtime_check` 222-228, `checker_rows` 318-346, `pin_write` 159-168). A timed run also checks its result
    (exit 0 and `ALL PROOFS CHECK`; runtime outputs against the pin, 351-354), or it is not a time. Three
    runs per cell: the gate takes the minimum (296), a new pin takes the median (328-331). A cell passes at
    1.15x its pin or under (header 15-16, `fits` 346-347). The second compile is timed, so the cold compiler
    service is not (header 5-8). A timeout is written `>300s`, never dropped (339-340). A pin file is stamped
    with date, commit and command, and a column carried forward unmeasured says so (`--keep`, 368-369). The
    script "writes nothing it did not measure in the same run" and times each cell alone on a quiet machine;
    only builds are pooled (`gen_pins.ts` 6-8). For G5, `hopac_speed_ab.ps1`: drop a timing whose residual
    hash differs from single-flight's; name the statistic (minimum for the gate, median for a published
    table); say warm or cold (the core library is parsed again by every fresh process); keep a timeout as a
    `>N s` row; stamp every table with date, commit and command.

  Read and not applied:
  - *Termination by a decreasing measure* (BendTT §6.4 p. 7, Theorem 5; `term_descend` 3235-3274 and the
    descent check in `term_infer` infer-ref 3329-3337). Spiral does not check `inl` recursion statically, so
    `EJP0040`/`EJP0011` stay deterministic counters. A static descent check would be a language change, not
    part of hopacsota.
  - *Affinity* (BendTT §7 pp. 7-8: a closure is called at most once; `uses_close` 3478-3488). Spiral's
    evaluator copies compile-time values freely; the evaluator's sharing problem is mutable state, not use
    counts.
  - *No mutual recursion; merge it into one definition with a selector* (BendTT §7 p. 8). Spiral keeps
    mutually recursive join points (annotated); `frontier_hopacsota_mutual_pending` tests them.
  - *First error wins by a race on the device.* `err_post` is a compare-and-swap on one cell (`comp.ts`
    3694-3696); the host aborts at the first error (3709-3711). That breaks D4, so it is not adopted. What is
    kept: workers poll the error cell at loop boundaries (`WL_SPIN` and `err_spun`, 3389), the D15 Rust
    row's "flag polled at boundaries". In hopacsota a known error may cancel only the jobs ordered after it
    in D6 order; an earlier job can still fail first.
  - BendTT §9-10 (related work, conclusion: intensional equality, no semantic model yet): nothing for
    hopacsota.
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
  | fill-once cell | `IVar` | a process holding the value, `Subject` replies | `OnceLock` + waker, or oneshot |
  | server request/reply | `Job.iterateServer` + `*<-=>-` | actor + `process.call` | thread + channel + oneshot reply |
  | choice over reads | `Alt.choose` / `<\|>`, left-biased | `process.select` (selector order) | `select!`, `biased` |
  | cancel a speculative job | `withNackJob` | monitor + kill | a cancellation flag polled at boundaries |

- **D16. Parallel evaluation is a requirement, not a hypothesis.** Codebases far larger than today's corpus
  are coming, and one evaluator thread cannot scale to them. A measurement can change *how* evaluation is
  parallel, never *whether*. A long span is shortened, in this order of preference:
  1. **Fork every body whose type is known.** Annotated methods, closures (always typed by `fun_ty`) and
     type join points run as jobs as soon as their key exists, with the relative context of D3 and the
     canonical-context check of D6 (P1). Bodies that reach no join point are leaves (D12, Bend's `fid_nofk`):
     start the forking bodies first while the frontier is narrow, and queue leaves or run them inline below
     the measured cost cutoff (Phase 3).
  2. **Speculate on unannotated bodies.** When a key is first seen, start its body at once, before any caller
     needs its type. Losers of a race are dropped (`withNackJob`; a blocked, unreachable job is just
     collected). The result is the same whoever finishes first (D3).
  3. **Return-type hints from the previous build.** Read them as a guess that lets the caller continue, and
     check the guess against the body's real type once the body finishes. A wrong guess re-runs the caller
     from its start, deterministically. This is a restart of a pure computation, not a replay of recorded
     steps (D2). It is measured before adoption.
  4. **Parallelism beside peval.** Parsing per file, type checking per package and codegen per method run in
     parallel too, and pipeline into peval: a package's evaluation starts as soon as its type check is done.
     Codegen per method has a precondition (P5): codegen still fills `join_point_type` and appends globals
     (core fact 4), so it runs against the D3 table and its globals merge by D6 in codegen's traversal order.

  Never: a placeholder type that callers read before it is filled. That was gpt5parallel's failure class
  (fixes 8, 25, 44-47, 50).

## Banned in hopacsota code (gate G2)

`ConcurrentDictionary`, `lock`, `Monitor.`, `Interlocked.` (except inside the engine module, one allowlisted
counter per use with its reason), `Promise.Now.`, `IVar.Now.`, `Hopac.run` (except at the compile entry),
`ThreadLocal` (Hopac jobs move between threads; single-flight's `DynamicIfNesting.depth` and
`RustGapTrace.validating` become per-body values passed in the environment), `Thread.Sleep`, `Stopwatch` or
`DateTime` in a decision (a timeout may only produce a report, never change a result), `SHA256`/hashing for
telemetry, `<~>`, `Alt.chooser`, `Alt.random`, `Job.Random` (choice must be left-biased and deterministic),
`Stream.mapPipelined*` (it hung in 25-45% of runs at any parallelism above 1 in Hopac 0.5.1, 2026-10-17; use
`conCollect`), and the D2 identifiers. The allowlist lives in `scripts/hopacsota-lint.ps1`, one line per exception with its
reason.

## Shared state inventory (Phase 0 output, R2)

Every mutable thing reachable from single-flight's `peval`, and its hopacsota discipline. R2 completes this
inventory with the line of every access, so nothing is found later by a race.

R2 (2026-10-14 00:40-00:54) read single-flight's PartEval whole (`#else` side 161624, section 161625-164591,
`#endif` 164592), the shared sections it calls (HashConsing 7106-7232, Utils 7315-7363, `CseDirectiveBarrier`
45787-45816, `InlineDepth` 49256-49287), the build entry that calls it (185730-185799) and every single-flight
codegen section (the projection without the `#if SPIRAL_CORE_GPT5PARALLEL` sides: 27,232 lines). Line numbers
are `spiral_compiler.fs` as of that read. "Per-body" means created inside one join point body evaluation (or a
call inside it) and never reachable from another body. "Shared" means reachable from more than one body.
Every `<-` in 161625-164591 is covered by an entry below (34 lines; a write to a call-local `mutable` is covered
by its creation line in the call-local entry). The disciplines include P1-P5 as adopted 2026-10-14 01:44.

One entry per piece of state: where it is created and whether it is per-body or shared; the lines that read or
write it; whether it is order-sensitive, that is, whether it reaches the output; the hopacsota discipline.

- `join_point_method`
  - Where: `peval` local 162349, shared; per family `(backend', body)` a `Dictionary<key, (seq option, ret_ty option,
    jp_name)>` made by `Utils.memoize` 162993 (`memoize` 7336-7342: `TryGetValue` then `TryAdd`, not atomic)
  - Lines: key built 162994-162995; read 162998-163000 (pending + unannotated = "Recursive join points must be
    annotated.", 163000); write pending 163018, filled 163020; returned 164588; codegen reads by key only: 166681,
    166755 (`codegenMethodBody`). No single-flight code iterates `.Keys`/`.Values` of any join point dict (grep of the
    projection: 12 hits, all create/lookup)
  - Order-sensitive: no: dict order never reaches text; codegen names methods in its own traversal order (`jp` memo,
    `dict.Count`, 166332-166339)
  - Discipline: D3 fill-once; the pending entry with an annotation is already a "type known" cell (163018)
- `join_point_closure`
  - Where: `peval` local 162350, shared; per family `(s.backend, body)` 162417
  - Lines: key 162418-162419; read 162425-162426 (a pending closure is not an error: recursion returns the key); write
    pending 162431, filled 162433; type check after the body 162450; returned 164588; codegen 166694, 166759
  - Order-sensitive: no
  - Discipline: D3 fill-once; closures never wait (type from `fun_ty`, 162413-162416)
- `join_point_type`
  - Where: `peval` local 162351, shared; per `body` 162572
  - Lines: key 162573; read 162574-162576 (pending = "Type join points must not be unboxed during their definition.",
    162576); write pending 162594, filled 162596; also reached after peval through `ty_to_data`/`nominal_apply`
    (164584-164585) from codegen, e.g. 166310, 166390, 172691, 172745, 176918
  - Order-sensitive: no, but load-bearing for type equality: a union made in a type join point is shared by reference
    (row `Union`)
  - Discipline: D3 fill-once; codegen-time fills must use the same table (P5; D3)
- per-family `HashConsTable` (join point keys)
  - Where: one per `(backend, body)` family, created in the memoize factories 162417, 162572, 162993; shared by every
    specialization of that body, so concurrent keys of one body contend on one lock
  - Lines: `Add` 7172-7198 under `lock sync_root` (7143, 7173); called via `data_to_rdata` 161822 (from 162418, 162994)
    and 162419, 162573, 162995; tag reads: `Equals`/`CompareTo` by tag 7125-7134, `rdata_free_vars` 161924-161929 (dedup
    by tag within one tree)
  - Order-sensitive: **decided: no.** Ids reach equality only. Proof greps over the single-flight projection: (1) no
    `%A`/`%O`/`ToString` of a `JoinPointKey`, `RData` or `TypedOp` reaches emitted text; the `%A` sites in codegen
    errors print `Ty`/`Op`, where the only `ConsedNode` is a nominal from the per-build table filled in `Map.iter` order
    before peval (185739-185741); (2) no `Map`/`Set`/sort keyed by a consed value (the only `Set.ofSeq`, 171050, is over
    strings); (3) no equality between nodes of two tables: every key is compared inside its own family's dict, and
    codegen's memo key `((backend, body), key)` (166398-166399) includes the family. All `.tag` uses in single-flight
    codegen (330 hits) are codegen-local records (`MethodRec*`, `UnionRec*`, `LayoutRec*`, tag = `dict.Count`)
  - Discipline: allowlist the shared `HashConsTable` lock (it is not hopacsota code); keys stay consed. Weak handles: a
    collected node re-added gets a new tag; keys are kept alive by their dict, so no effect
- `backend_strings`
  - Where: `peval` local `HashConsTable` 162352, shared
  - Lines: `Add` 162992 (backend-annotated join point), 163447 (validation env), 164581 (root env: first add, tag 0);
    reads of `.node` 163431, 163458, 163463-163465, 164394, 164405; codegen 166762
  - Order-sensitive: no (same proof as the row above)
  - Discipline: allowlist with it
- `backend_switch_validated` + `backend_switch_validated_hc`
  - Where: `peval` locals 162354, 162355, shared
  - Lines: key built 163443 (`data_to_rdata` into the one shared `_hc`; a capture of a mutable HashMap/HashSet raises,
    the `try` makes the key `None`); read 163445; write 163451
  - Order-sensitive: **yes, through side effects** of the first validation (row `globals`, row stdout): the validation's
    effects (D7 as amended, P2)
  - Discipline: D7: fill-once; the value is the type plus the validation's ordered effect list (P2)
- `backend_switch_validation_tags`
  - Where: `peval` local function 162356; one fresh `ref (1 <<< 30)` per validation 163447, per-validation
  - Lines: written through `ty_to_data` 162366 / `rename_global_term` 161859 inside the validation env
  - Order-sensitive: no (validation `seq` is discarded)
  - Discipline: stays as is (D7)
- `globals` list
  - Where: root env 164582, then the same instance is passed into every body env: 162408 (`closure_env`), 162591 (type
    join point), 163014 (method), and into validation envs (163447 keeps it); shared
  - Lines: appended by `global'` 162676-162685 (called only from 164409, guarded by `s.backend.node = env.backend`
    164405, which is also true inside a validation of the current backend's arm nested in another backend's validation);
    returned 164588; codegen appends and prints: 166346-166351, 166715 (F#), and the other backends' `global'`/print
    sites 167300-167301, 167829, 167965, 168372, 168587, 168988, 169105, 169444, 170393-170398, 171035, 171230-171235,
    172632, 172644, 175819-175820, 176331, 176676, 177652, 178619, 179335
  - Order-sensitive: **yes**: first-seen order is the order of the emitted prelude; `preserves_duplicate_fragment` text
    (162681-162684) is appended on every visit
  - Discipline: D6 per-spec ordered list + canonical merge; the merge applies the same dedup rule (first occurrence,
    fragments kept); a validation's globals merge as a child node at its first position (D6, D7, P2)
- `GlobalsIndex`
  - Where: module-level `ConditionalWeakTable<ResizeArray<string>, HashSet<string>>` 162325, keyed by the shared
    `globals` instance
  - Lines: `get` 162326 (copies the list on first use), called 162680 on every `term` call; `Add` 162685
  - Order-sensitive: yes (dedup decides what reaches the text)
  - Discipline: per-spec index of the per-spec list (D6); the CWT goes away with the shared list
- `is_metavar`
  - Where: `HashSet` local to each `is_unify` call 162215; per-call
  - Lines: `Add` 162237; writes go through `store_ty` 162211 into the current scope's `env_stack_type`; callers 162634
    (`TTypecase`), 163398 (`ETypecase`); a failed partial unification leaves stores that the next arm's `is_unify`
    overwrites for its own metavars, all inside one body
  - Order-sensitive: **decided: no**
  - Discipline: per-body value (call-local); nothing to share
- `RustGapTrace`
  - Where: module statics: `enabled` 162333 (read-only), `validating` `ThreadLocal<int>` 162336, `seen`
    `HashSet<string>` 162337 (process-wide: in a warm server process it also dedups across builds)
  - Lines: `enabled` read 163160; `report` 162338-162346 called 163161; `validating` read 162339, write 163448, 163453;
    `seen.Add` + `eprintfn` 162346
  - Order-sensitive: stderr only, order-sensitive and suppressed by the first caller's `validating` (a body first
    entered inside a validation never reports)
  - Discipline: per-body flag in the env + canonical merge of reports (D6/D13); a forked body starts not validating and
    the canonical caller's flag is applied at the merge (D6, P1)
- `DynamicIfNesting.depth`
  - Where: module static `ThreadLocal<int>` 162320; `limit` 162316-162319 read-only (env var)
  - Lines: read 162750; write 162760, 162762 (`try/finally`); `limit` read 162751, 162756, 162758; not reset at a join
    point body: the count runs through nested bodies on the evaluating path
  - Order-sensitive: only in failure (`EJP0040`, 162753-162759)
  - Discipline: per-body value in the env; a forked body starts at 0 and records its maximum, and the merge re-runs the
    body in place with the canonical caller's depth when the sum crosses the limit (D6, P1); a counter that simply
    started at 0 would move where EJP0040 fires
- `inline_depth` + the physical stack
  - Where: `LangEnv.inline_depth` 161794, root 164572; inherited by bodies 162398, 162581, 163004
  - Lines: `InlineDepthOps.ensure_stack` 162672 (`RuntimeHelpers.TryEnsureSufficientExecutionStack`, 49283), `enter`
    162712 (limit 10,000, 49274, 49286)
  - Order-sensitive: only in failure (`EJP0011`); the stack check depends on the thread and on how deep the caller
    already is
  - Discipline: relative value with the same merge check (D6, P1); the stack check becomes the D5 `MaxStackSize`
    question: a job starts on a fresh stack where single-flight is nested in its callers
- `trace` (caller context)
  - Where: `LangEnv.trace` 161793, immutable list; inherited by bodies 162397, 162580 (`r :: s.trace`), 163003
  - Lines: stored in every residual statement: `TyLet(_, d.trace, _)` 162377, 162384, `TyLocalReturnData` 162007; read
    by codegen error rendering 166380-166382 (all backends), errors 161818, EJP0040 frames 162752, RUST-GAP frames
    162341-162345
  - Order-sensitive: only in error text, but there it is the **first caller's** chain
  - Discipline: a forked body records traces relative to its own frame; a codegen error that needs the absolute trace
    re-runs the body in place with the canonical caller's context (D6, P1)
- `RunawayUnrollDiagnostic.sourceLines`
  - Where: module static `ConcurrentDictionary` 162255
  - Lines: `GetOrAdd` + `File.ReadAllLines` 162257, from `render` (called 162754)
  - Order-sensitive: no
  - Discipline: read-only file cache filled before peval (D13: the evaluator does no file IO)
- `CseDirectiveBarrier.regions`
  - Where: module static `ConditionalWeakTable<obj, obj>` 45795, keyed by one body's CSE table
  - Lines: `TryGetValue` 45804, `Remove` 45811, `AddOrUpdate` 45815; mutates the CSE table: `Remove` 45799, `Clear`
    45816; called from `EMacro` 163163-163164
  - Order-sensitive: yes, inside one body: it decides which CSE entries are reused, which changes the residual
  - Discipline: per-body value (keys are per-body tables; the CWT may stay, it is thread-safe and never shared across
    bodies)
- CSE tables (`cse`)
  - Where: `LangEnv.cse` 161796; created per scope 162400, 162503, 162526, 162583, 162775, 163006, 163188, 163219,
    163242, 163321, 163328, 163447; per-body
  - Lines: `cse_tryfind` 162016-162021 (from 162380, 162770, 163316); `cse_add` 162024 (from 162385); direct `Add`
    162777, 163329; `Count` 164392; pruned by the row above
  - Order-sensitive: yes, within the body
  - Discipline: per-body value
- `seq` (residual statements)
  - Where: `LangEnv.seq` 161795; created 162399, 162503, 162525, 162582, 163005, 163188, 163219, 163242, 163321, 163330,
    163447; root `null` 164573; per-body
  - Lines: `Add` 162007, 162377, 162384; last-element rewrite 162010; `ToArray` 162013
  - Order-sensitive: yes (it is the output)
  - Discipline: per-body value
- `i` (residual variable counter)
  - Where: `LangEnv.i` 161798; `ref 0` per body 162402, 162585, 163008, root 164576, codegen helpers 164584-164585;
    shared by every `{s with ...}` copy inside one body
  - Lines: write 161859, 162366; read 164395, 164402
  - Order-sensitive: yes: `v{i}` names
  - Discipline: per-body value; evaluating a child body never touches the caller's counter (each body env has its own
    `ref 0`, the `rename_global_term` 163016/162593/162428 runs on the child env)
- `env_stack_term` / `env_stack_type` arrays
  - Where: created per body or application 162405-162406, 162536-162537, 162588-162589, 162657-162658, 162696-162697,
    162718-162719, 163011-163012, root 164579-164580; per-body
  - Lines: `store_term` 162208 (from 163179, 163340, 163344, 163349, 163365, 163386), `store_ty` 162211 (from 162237,
    163349); `[0] <-` 162430, 162539, 162660, 162699, 162721; read `vt` 162199, `v` 162202
  - Order-sensitive: yes, within the body
  - Discipline: per-body value
- `env_global_term` / `env_global_type` arrays
  - Where: built 162565, 162569-162570, 162892, 162896, 162989-162990, renamed copy 161870; captured in
    `DFunction`/`DForall`/`YTypeFunction` and passed between bodies through join point keys
  - Lines: never written after creation (no `<-` on them in 161625-164591)
  - Order-sensitive: n/a
  - Discipline: read-only
- `Union` (`H` wrapper)
  - Where: built in `ty` `TUnion` 162610-162629 (`tags` `Dictionary` 162611 written 162625, `tag_cases` 162612/162626,
    `mutable is_degenerate` 162613/162624); `H` 161652-161660 compares by **reference** (161658), hashes structurally
    (161653)
  - Lines: reads `tags` 162485, 164377; `tag_cases` 163306-163312; `cases` 162550, 163184, 163193, 163723; `layout`
    164285, 164323; identity compares 162235, 163257, 163264, 163284 and every `Ty` equality
  - Order-sensitive: no for the text; yes for type equality: two evaluations of one union are different types unless
    they come from one type join point fill (comment 161714)
  - Discipline: frozen after construction, published through the D3 fill (the `IVar` fill is the memory barrier);
    `join_point_type` must be fill-once, never "first writer wins per thread"
- prepass ref cells inside `E`
  - Where: `ERecursiveFun'` `body.Value` 162981, `ERecursiveForall'` 162984, `ERecursive a.Value` 162985
  - Lines: read only; no write in 161625-164591
  - Order-sensitive: n/a
  - Discipline: read-only
- top env: `nominals`, `prototypes_instances`
  - Where: `PartEvalTopEnv` 161807-161812: **`Dictionary`**, not `Map`; built per build before peval:
    `prototypes_instances` copied 185737, `nominals` filled 185738-185742 through a fresh `HashConsTable` (185739) in
    `Map.iter` order
  - Lines: read 162668 (`nominals`), 163170, 164356 (`prototypes_instances`); never written during peval
  - Order-sensitive: no
  - Discipline: read-only during peval (confirmed)
- compile-time `DHashMap` / `DHashSet`
  - Where: `Data` values created 164489 (`OrderedDictionary` + `bool ref`), 164472 (`HashSet`); per-body
  - Lines: map writes 164496, 164501, 164506, 164514; `is_writable` write 164492; reads 164510, 164518, 164523-164524;
    set ops 164475, 164479, 164483, 164487; iteration (insertion order) 161885-161886, 161944-161945, 161959-161960,
    161975-161976; crossing a join point: mutable refused 161840-161841, 161867-161868, 161909; an immutable map crosses
    as a copy 161863-161866 that shares the `is_writable` cell (only ever `false`, so the only possible write, 164492,
    stores the value it already has); `data_free_vars_replace` makes a new cell 161907
  - Order-sensitive: yes, within the body
  - Discipline: **decided:** they stay inside one body. BackendSwitch arms touching them: arms run in record key order
    (`Map.iter` 163428); an arm closure that captures a mutable map/set gets no cache key (163443 `try` → `None`) and is
    evaluated on every visit, in the body that holds the map, so its mutations never cross a body and the D7 cache never
    skips them. Per-body value
- stdout: `PrintStatic` / `PrintRaw`
  - Where: `printfn` in the evaluator 164373, 164374, 164375
  - Lines: written on every evaluation, including inside validations (skipped on a D7 cache hit)
  - Order-sensitive: **yes** (console order)
  - Discipline: event in the D13 stream, merged in D6 order; contradicts D13 today
- `trace Verbose` logging
  - Where: 164397-164402 (reads `s.cse` 164392, `s.i` 164395)
  - Lines: Lib trace sink
  - Order-sensitive: no (diagnostic log)
  - Discipline: D13 event, off by default
- peval result used by codegen
  - Where: `PartEvalResult` 162242-162248, built 164584-164588: `ty_to_data` and `nominal_apply` close over the root env
    and the `join_point_type` table
  - Lines: codegen calls them throughout (e.g. 166310, 166325, 166390, 167161, 172691, 172745, 172759, 176918); they can
    fill `join_point_type`, build new `Union`s and evaluate `TTerm` bodies (`term_real_nominal` 162502-162504) after
    peval returned
  - Order-sensitive: as their rows
  - Discipline: codegen is not a read-only phase: `join_point_type` stays the D3 table during codegen and codegen-time
    globals merge by D6 in codegen's traversal order (P5)
- which error is reported when several bodies fail
  - Where: `PartEvalTypeError` 161815, raised by `raise_type_error` 161818 (and `failwith` "Compiler error" sites);
    first raise wins on the one thread; caught 162555 (swallowed by `ty_is_uninhabited`, so a pending type join point
    counts as inhabited), 163443 (swallowed into a `None` key), 185783 (`BuildErrorTrace`)
  - Lines: the raise and catch lines under Where
  - Order-sensitive: **yes**
  - Discipline: D4/D6 canonical order; D4 names all three pending cases (P3)
- call-local scratch
  - Where: memo `Dictionary`/`HashSet`/`ResizeArray`/`mutable` locals: 161823-161824, 161851, 161864, 161874-161875,
    161892, 161905, 161921-161922, 161936, 161951, 161966, 162454, 162474-162475 (`dirty`), 162775, 163241 (`case_ty`),
    163420-163421 (`t`, `d`), 163470, 163475, 164436, 164466, 164542
  - Lines: written and read only inside the call that made them
  - Order-sensitive: no
  - Discipline: per-call value
- static read-only config
  - Where: `DynamicIfNesting.limit` 162316, `RustGapTrace.enabled` 162333, `InlineDepthOps.limit` 49274,
    `CseDirectiveBarrier.directive` 45793-45794
  - Lines: read only
  - Order-sensitive: no
  - Discipline: read-only

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
  - Deferred bodies run with D3's relative context, and the run reports how often D6's canonical-context
    restart triggers, by cause (depth limit, absolute trace for a codegen error, validating caller). This is
    the measurement behind P1; a high count moves fork boundaries (D6).
  - The run also lists every row where the stack-based `EJP0011` check fires (D5): a fresh job stack can pass
    where single-flight's nested stack stopped.
  - R4 is the cheapest test of determinism by construction. If it fails, the design changes before any
    Hopac code.

### Phase 1: the layer and the deferred worklist (single thread)

- Starting point (2026-10-15): R4's gate is met. The R4i copy (job scratch `hopacsota-p0/r4_deferred.ps1`)
  gives byte-identical output under DFS, BFS and random:11 on apps/spiral and on every `-Suite all` row, with
  0 depth or dynamic-if restarts. Phase 1 carries its merge over unchanged: a list per key for the four
  global-emitting memos (method, closure and type join points, `backend_switch_validated`), a reference on
  every hit, expansion at the first reference in depth-first order, the `GlobalsIndex` rebuilt after the
  merge, and no references once the session closes.
- `frontier_hopacsota_globals_order` covers the two cases R4 found: a nominal stub first emitted while
  validating another backend's arm, and a type join point hit by a deferred body before the caller that
  single-flight evaluated it under.
- `-Mode hopacsota` and `SPIRAL_CORE_HOPACSOTA` in `build.ps1`, `test.ps1`, `probe.ps1`, `env.ps1`,
  `projection-hash.ps1` and the core project. Use the same mode plumbing as gpt5parallel.
- The seam hooks of D10, with single-flight's code moved unchanged as the single-flight side.
  `projection-hash.ps1` proves single-flight's projection hash is unchanged.
- `scripts/hopacsota-lint.ps1` (G2) and the size budget (G1), run by `build.ps1 -Mode hopacsota`.
- The deferred policy: type-known specializations go to a single-threaded worklist; D3 tables, D6 merge,
  D8 types.
- New frontier fixtures, each written before its code with its oracle row blessed from single-flight:
  - `frontier_hopacsota_recursion_inferred`, a self-recursive `let rec` without a written annotation whose
    pending recursive call returns the inferred type without waiting (single-flight: exit 0; it replaces the
    `recursion_unannotated` draft, whose error D4 shows is unreachable);
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

- Entry analysis (2026-10-16, after Gate 1): the four memos (`join_point_method`, `join_point_closure`, `join_point_type`, `backend_switch_validated`) are single-flight `Dictionary`s read with `Utils.memoize` (`TryGetValue` then `TryAdd`) and a separate pending write, so two bodies running at once can both miss one key. D3's fill-once claim therefore has to replace that check-then-act at each of the four sites, and the claim is a Hopac server request, which only a job can make: the bodies that reach it run as jobs, so the evaluator around the four sites becomes job-shaped in the layer (G1's budget of 2x PartEval is sized for that). The seam call sites from Phase 1 stay; the first grain is the claim seam per memo kind with the single-thread table behind it (G3 at 1 worker), then the server table and N workers.
- Grain 1 design (2026-10-16 19:33, read from single-flight's PartEval on pack-1z). The four sites share one shape: `Utils.memoize`
  creates the per-body table (`join_point_closure` keyed by `(s.backend, body)`, `join_point_type` by `body`,
  `join_point_method` by `(backend', body)`), `hc_table.Add` interns the specialization key, `TryGetValue` decides,
  a pending value is written (`None` for closures, `(None, annot, name)` for methods, `None` for types), and the
  deferred body fills it. `backend_switch_validated` has no pending state (`ContainsKey` then a write after
  `apply`). Grain 1 replaces each decide-and-mark with one `PartEvalSeams.claim kind table key` returning
  `Hit value | Pending | Owner`: `Pending` keeps today's error per kind ("Recursive join points must be
  annotated", "Type join points must not be unboxed during their definition"; a closure's pending entry is a hit), and
  `Owner` runs today's body path. Single-flight's side is today's code inlined, so its projection changes only by the
  four calls (G6 `-Seams`). Shared mutable state the claim does not cover and that Phase 2 must also own: the per-body
  `HashConsTable`s (`hc_table.Add` is check-then-act), the outer `Utils.memoize` (two bodies can create two inner
  tables), `backend_strings.Add`, `backend_switch_validated_hc` and the `RustGapTrace.validating` counter. Proof
  for grain 1: G3 on every policy at 1 worker (0 cells vs the single-flight run), apps/spiral byte-identical, G1/G2.
- Grain 1 result (2026-10-17 00:15, staged as the job's tmp/night/pack-b/claim-seam.ps1, not in the tree):
  `PartEvalSeams.claim` (`Found of 'v | Owner`) on both seam sides, used at the type, closure and method sites;
  the method site keeps its `(None, annot, jp_name)` write before the body, because annotated recursion resolves
  through that pending entry. Both cores and the hopacsota mode build; G6: 11 added single-flight lines, all seam
  calls; G3 on `-Suite all` compile-only (6,906 rows): single-flight with the claim equals the pack-1y bless and
  hopacsota inline and random:23 equal it, except one F# error row whose diagnostic blocks come in a different
  order from run to run (host diagnostics, not partial evaluation). `backend_switch_validated` keeps a plain lookup.
- Grain 2 design (2026-10-17 02:42, read from single-flight's PartEval with grain 1 applied). The three claim sites have
  three final writes and one early write (`backend_switch_validated` has no pending state): closure `dict.[key] <- Some(domain_data, seq)`, type
  `dict.[key] <- Some ret_ty`, method `dict.[key] <- (Some seq, Some ty, jp_name)`, and the method's
  `(None, annot, jp_name)` before its body, which is how annotated recursion reads its own type (D4: an
  annotated method is not pending). Grain 2 turns those writes into seams and gives `Claim` its waiting case,
  still at one worker: `Claim<'v> = Found of 'v | Owner | Waiting of Pending<'v>` on both seam sides
  (single-flight never builds `Waiting`); `PartEvalSeams.fill hopacsota dict key value` replaces the three
  final writes and `PartEvalSeams.announce` the method's annotation write; each claim site gains
  `| PartEvalSeams.Waiting pending -> PartEvalSeams.await hopacsota pending s` with D4's ancestor rule inside
  `await` (a key on the waiter's own chain keeps today's per-kind result: the method error, the type error, a
  closure's key hit). Single-flight's projection changes only by seam calls (G6). On hopacsota the table stays
  the per-body `Dictionary` under the single-thread policies and becomes the D3 shard server under
  `parallel`; the proof is G3 with `parallel` at `SPIRAL_HOPACSOTA_WORKERS=1` equal to `inline`, then
  Gate 2's 2, 4 and 8 workers once the bodies that reach `await` run as jobs.
- Grain 2 split (2026-10-17 12:10, main). **2a** (in the tree, G3 below): `PartEvalSeams.fill` replaces the three final
  writes and `PartEvalSeams.announce` the method's `(None, annot, jp_name)` write, plain writes on every policy today
  (G6: 4 added single-flight lines, all seam calls; G1 142, G2 0). Measured before choosing 2b's shape: under every
  single-thread policy a pending entry is only ever read by its owner's own chain (unannotated methods and type
  join points are never deferred, and a deferred closure's pending entry is a hit), so `Waiting` cannot arise there.
  **2b** therefore puts the wait inside `claim` instead of adding `Waiting` arms at the three sites:
  under `parallel`, `claim` on a key owned by a non-ancestor blocks on that key's fill and returns `Found`.
  `announce` publishes the annotation so annotated recursion and concurrent callers read it without waiting (D4).
  D4's ancestor rule stays in `claim`: a key on the caller's own chain returns its pending entry as today.
  The sites keep their shape, so 2b adds no PartEval lines.
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
| G1 size | `scripts/hopacsota-lint.ps1 -Size` | layer + hooks ≤ 5,934 lines (2x PartEval); no section > 1,000 |
| G2 banned | `scripts/hopacsota-lint.ps1 -Banned` | 0 hits outside the allowlist |
| G3 oracle | `scripts/test.ps1 -Mode hopacsota -Suite <phase's suites>` | 0 differences |
| G4 determinism | `scripts/probe.ps1 <root> -Mode hopacsota -Repeat 5` at max workers | identical residual hashes |
| G5 speed | `hopac_speed_ab.ps1` (interleaved A/B with single-flight) | phase threshold; table kept in the scoreboard |
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
| 0 | R1 | 2026-10-14 00:57 | BendTT pp. 7-10 read; 12 functions + checker bench; D12 +12 applied, 5 not | read only |
| 0 | R2 | 2026-10-14 00:54 | 31 entries, 0 without a line, 3/3 decided, 34/34 writes; P1-P5 | see notes |
| 0 | R3 | 2026-10-14 07:52 | apps/spiral W/S 2.80 (8 workers 2.76x); mega roots W/S 1.00; scaling corpus N=1000 blocked by a typecheck stack overflow (fixed in source) | see notes |
| 0 | R4 | 2026-10-14 12:08 | -Suite all 4098 rows, 5 policies, 0 differ; apps/spiral 636 methods + 579 closures deferred, output differs only in global order (55-58 lines) | see notes |
| 1 | Gate 1 | 2026-10-16 11:18 | G1 131 lines, G2 0; -Suite all compile-only 6,758 rows: single-flight with seams = pack-1u oracle (0 cells), hopacsota inline/dfs/bfs/random:11/23/37 0 cells each; apps/spiral F# and Rust byte-identical under all 7; inline A/B 0.996 sum, 1.007 median, mega roots <= 1.031 | single-flight-20261016-104801, hopacsota-20261016-105126..110811 (job tmp/hopacsota-p1) |

Scoreboard notes:
- Phase 1 Gate 1 (2026-10-16): seams via `PartEvalSeams` (`/// ## PartEvalSeamsHopacsota` / `/// ## PartEvalSeams` pair before PartEval; job script `tmp/hopacsota-p1/seams.ps1`): session start, closure and annotated-method body deferral (type-known bodies only), key lists and hit markers for the four global-emitting memos, compile-time prints (`PrintStatic`, `PrintRaw`) as markers, root drain. D4's first-error rule: a failing deferred body or root leaves a fail marker at its position and the first one on the depth-first walk is raised; `frontier_hopacsota_two_errors` failed `random:23` before that rule and passes after it. Deferral is real: a PrintStatic probe printed `first,second,inner` (bfs) and `second,first,inner` (random:23) before prints became markers, `first,inner,second` (single-flight's order) after. Still open in Phase 1's structure: D3's Owner/Waiter capability shape and D8's phantom keys, which carry weight only with Phase 2's engine; `frontier_hopacsota_globals_order` does not yet pin R4's two concrete cases (apps/spiral does).
- R1: functions read: `term_infer`, `term_check`, `term_descend`, `term_check_kind`, `def_inst`, the
  `book_valid` header; `emit_task`, `emit_jump`, `emit_fork`, `emit_match`, `monk_step`, `err_post`; bench:
  `gates/perf.ts`, `bend2/docs/gen_pins.ts`. Every D12 addition cites a file and function or a page.
- R2: "R2 decides" resolved: `is_metavar` is per-call; `HashConsTable` ids never reach output (allowlist);
  compile-time maps stay in one body. The `<-` lines of PartEval are covered 34 of 34. P1-P5 were proposed
  00:54 and adopted 01:44. Read of `spiral_compiler.fs`, 186,347 lines: HEAD `d94dc380` plus the main
  thread's uncommitted edits (+165/-4, all at line 164909 or later); single-flight projection 27,232 lines.
  PartEval lines (161624-164592) are the same in HEAD; codegen lines from 164909 on are working-tree numbers
  and shift when those edits land.

- R3 (apps/spiral, 2026-10-14 07:52): 1,656 specializations (579 closures, 711 methods, 366 type join points), peval W 58.0 s, S 20.7 s, W/S 2.80; simulated 1.70x at 2 workers, 2.30x at 4, 2.76x at 8; compile 94 s; the span is three single bodies: the root body 8.6 s self, annotated method#639 7.3 s, method#283 4.7 s; so with D1 (a body is never split) 8 workers cap near 2.8x: beyond that needs parallelism inside a body, a candidate decision change for after R4 (proposed, not adopted).
- R4 (2026-10-14 11:19-12:08, R4 DLL in the night cache, `-Suite all` compile-only from a copied
  apps/compiler/tmp tree): dfs, bfs, random:11, random:23 and random:37 give identical compile status and
  residual hash on all 4,098 rows. Each policy has the same 3,582 ok and 516 error; 53 rows fail only in the
  copied tree (package paths), identically under every policy. The suite does not exercise deferral much
  (5 mega roots: 24 deferred methods, 3 roots compile to a trivial program), so apps/spiral is the real
  test. With `SPIRAL_R4_REPORT`, every policy defers 636 methods and 579 closures, max queue 1,215
  (bfs/random), 0 depth or dynamic-if restarts, 0 stack stops; validating callers 899 (dfs) / 604 (bfs) /
  605 (random:11); relative-trace bodies 1,203 under bfs/random. The outputs (953,638 bytes each) differ
  in 55 (bfs) and 58 (random:11) lines, all in lines 3-60, the global type declaration header; the lines
  are the same multiset, and every method and closure body and name after line 60 is byte-identical. So
  the only order-dependent effect is the order of globals, the case D6's depth-first merge exists for;
  R4 confirms D6 as required and finds no other cause. Next: apply D6's merge to the R4 copy and require
  0 differing lines on apps/spiral.
- R4 + D6 merge (2026-10-14 15:5x): with per-deferral global lists merged depth-first, apps/spiral's peval
  globals are the same 60 lines under every policy but still in a different order (clap_Command 3rd under
  dfs, 10th under bfs). Cause: a memoized join-point body runs at its first evaluation-time caller, and under
  bfs that can be a different caller than dfs's first one in depth-first order, so its globals sit at the
  wrong position. D6 refined: globals belong to the body (its key), every call site including memo hits
  records a reference, and the merge expands a key's globals at its first reference in depth-first order.
  Next: per-key global lists with reference markers on memo hits in the R4 copy.
- Key-level D6 tried (2026-10-14 17:1x): dfs peval globals unchanged, bfs order still differs at the same
  globals, and dfs's output gained a second `type Box` from codegen. So join-point memo order is not the
  whole story (suspect: globals from inlined code inside deferred bodies, which have no key), and the merged
  list interacts with codegen's dedup. Open; scripts in the job's tmp/hopacsota-p0.
- D6 closed on apps/spiral (2026-10-15 02:4x): dfs, bfs and random:11 compile apps/spiral to byte-identical
  F# (18,180 lines), equal line for line to the installed single-flight compiler. Three causes, each found by
  dumping the per-list globals tree and logging every `global'` call for one moved global:
  1. The second `type Box` was a stale `GlobalsIndex`: the merge cleared and refilled the root list, but its
     membership set kept the old contents, so codegen-time evaluation (`ty_to_data`, `nominal_apply` on the
     root env) re-appended key-list globals. Any merge that rewrites a globals list rebuilds its index.
  2. Every memo whose miss can emit globals needs a list per key and a marker on every hit. Four exist: method,
     closure and type join points (`join_point_type`), and the BackendSwitch validation cache
     (`backend_switch_validated`). Markers are ignored once the session closes (codegen-time evaluation).
  3. The nominal stubs (`type X = class end`) mostly appear while validating another backend's arm: a type
     join point first evaluated under Rust or Gleam validation runs `fsharp_global`'s Fsharp arm, whose
     `global` goes into the real list. Single-flight emits them at the first evaluation in its depth-first
     order, which is what the keyed merge reproduces.
  Suite (4,143 rows, copied tree): dfs, bfs and random:11 agree on every row's compile status and residual
  hash; dfs differs from the installed pack-1g oracle only in the 53 rows that fail in the copied tree
  (package paths).
  Side finding: apps/spiral's F# output starts with two Rust lines (`thread_local!`, `#[test]`) from
  lib/spiral/rust/testing.spi `run_tests'`, whose `global` calls are not behind a Rust switch.
- R3 scaling corpus (2026-10-14): generated N independent modules x 6 join-point levels
  (`r3_scaling_corpus.ps1`); plain compile N=10 3.0 s, N=100 4.8 s, N=1000 stack overflow in the
  typechecker (one frame pair per sequential `let`, between 1,000 and 2,000 lets in one body). Fixed in
  source: `infer` and its deferred `fill` jobs run on a 256 MB thread; W/S for N=1000 waits for that build.
- R3 (mega roots, 2026-10-14 07:50): the five mega roots compiled to F# with the R3 build, outputs byte-identical to the committed ones; W/S = 1.00 on all five (0-491 type join points, 2 method join points, root body 86-98% of peval), peval 28-672 ms of 2.5-8.2 s compiles: the mega roots inline almost everything, so join-point forking finds nothing there and parse/type check/codegen dominate (D16.4); apps/spiral running next.

## Decision changes

- **2026-10-17 14:1x, grain 2b design (lane hopacsota-2b-design, notes 8-13 on HOPACSOTA-P2), adopted as the plan for 2b, not yet coded.**
  - **D5 (engine shape):** bodies run direct-style on dedicated 1.5 GB-stack threads; the root stays on peval's thread. A per-build control scheduler (`Scheduler.create`, 1 worker, killed at the end) runs only the servers (D3 shard table, worklist, D4 wait-for graph). Bodies reach it through one blocking bridge, `Scheduler.run control job`, from non-worker threads only; it is the single allowlisted G2 exception. Rejected: job-shaped claim sites (every caller up the `ty`/`term` recursion would turn into a Job, against D1/G1), and blocking the server workers (deadlocks once all of them wait). Restart-on-wait stays only as the rare conflict fallback.
  - **D3 (ready-based claim):** claim waits until an entry is usable, not until it is filled. A closure never waits, a method waits for its announced annotation, and a type join point and `backend_switch_validated` wait for the fill. So claim takes a ready predicate per site, and at 1 thread no wait can happen. An owner that unwinds without filling (an error swallowed in `ty_is_uninhabited` or the bsv `try`) publishes `Abandoned`.
  - **D4:** a deferred body inherits an immutable snapshot of its parent's ancestor chain at the defer point. A wait-for cycle, or a foreign claimant seeing an abandoned key, triggers a deterministic restart of the whole peval under `inline`, counted by cause; nonzero counts on apps/spiral move the next grain to arbitration by canonical position.
  - **Shared state:**
    - The Session's `.Count`-based markers and shared Dictionaries move into the D3 cell and per-body registries, merged at Finish.
    - The three outer `Utils.memoize` tables need a `PartEvalSeams.family` seam.
    - `uninhabited_nesting` needs one seam line.
    - `DynamicIfNesting`/`RustGapTrace.validating` need nothing, because a direct-style body never changes thread and Defer resets both.
    - RUST-GAP runs with 1 body thread until it becomes a D13 event.
    - Body identity comes from one allowlisted `ThreadLocal<BodyContext>` in the engine.
  - **Size:** about 8-10 single-flight seam lines and a 350-500-line `PartEvalEngineHopacsota` section (~650 against the 5,934 budget). The first number to measure is claims per body, since a claim miss is a cross-thread round trip.
  - **G2** now also bans `Scheduler.run`, `ThreadStatic`, `ManualResetEvent*`, `SemaphoreSlim`, `SpinLock`, `Mutex` and `new Thread` (lint updated; 0 hits today). Each engine use gets one allowlist line.
  - **First grain 2b-1:** the full engine at `SPIRAL_HOPACSOTA_WORKERS=1`. Proof: G1/G2, G6 `-Seams`, and G3 compile-only with `parallel@1`, `inline` and `random:23`, each 0 cells against the bless; apps/spiral F#/Rust byte-identical; and G5 within 1.05x, printing claims, bridge calls and cache hits. **2b-2:** Gate 2 at 2/4/8 workers, plus probe `-Repeat 5` at 8 workers, with conflict counts per run.

- **2026-10-17, study lane measurements absorbed by main (lab/hopacsota-hopac-depth, lab/hopacsota-lf-scheduling).**
  These were measured under build load and should be rerun on an idle machine before Gate 3 cites them; none
  of them reverses a decision.
  - **D5:** a per-build scheduler costs 2.2 ms (`Scheduler.create`, one fork-join, `Scheduler.kill`), so every
    build gets its own scheduler and kills it at the end. That rules out the cross-build leak class of
    gpt5parallel fix 57.
  - **D3:** a key lookup costs 447 ns through `ConcurrentDictionary`, 931 ns through `MVar` and 1,221 ns
    through an owner server job, small next to a join-point body, so D3 keeps the server-owned table (and the
    G2 ban).
  - **Fork-join:** `Latch` (272 µs) and `conCollect` (275 µs) are about twice as fast as counting with
    `IVar` plus `Interlocked` (540 µs), so fork-join uses `Latch`. The D6 merge's order-preserving parallel
    map uses `conCollect` (2.5x sequential on per-method codegen).
  - **D16.2 speculation:** `withNackJob` delivered the loser's cancellation in 2,000 of 2,000 races, but only
    when the loser is the left alternative; otherwise the loser is never started.
  - **Phase 3 worklist order:** in an LF-style simulation, longest-remaining-chain first lands within 4% of
    the optimum and leaves first is up to 33% slower. A shape-only cost estimate is enough for a first build,
    and the level breadth caps useful workers. Measured on generated method call graphs (a stand-in for the key
    graph): typical sample 2 levels, breadth 2; mega brzozowski 7-9 levels, breadth 4-17, size-weighted bound
    3.6-4.9x; omniledger inlines into one `main`, so method grain finds nothing there (R3, D16.4).
  - **Shared state inventory:** the GADT hang fix (2026-10-17) added `uninhabited_nesting`, a per-compile
    budget for nested `ty_is_uninhabited` calls (a ref cell in single-flight, `ThreadLocal` in gpt5parallel).
    Under the parallel policy it becomes a per-body value passed in the environment, like
    `DynamicIfNesting.depth`, and a deferred body starts it at 0.

- **2026-10-16 08:51, main: G6 compares projections modulo whitespace.** The R4 edit list (job scratch `hopacsota-p0/r4_deferred.ps1`) has twelve seam sites; ten are one-line hooks (memo hit markers, key lists, depth notes, session start, root drain), but the two deferred bodies (closure, annotated method) are 20-40 line blocks that must become an `evaluate` closure handed to the seam, which re-indents them. `projection-hash.ps1 -Seams` therefore diffs with whitespace ignored (`git diff -w`) and also accepts added lines that are only closing punctuation (`)`); every other added line must still call `PartEvalSeams.`. The `/// ## PartEvalSeams` section itself (the single-flight side of the seam pair: inline no-ops) is stripped from both projections before the diff, and `Get-SpiralCoreProjection` resolves `SPIRAL_CORE_HOPACSOTA` blocks like gpt5parallel ones (single-flight and gpt5parallel keep their `#else` side). The single-flight oracle staying identical (full-suite review, no row differs) remains the semantic half of G6.
- **2026-10-13 23:2x, user: "why you're even considering dropping parallel evaluation? we need that for the
  abyssal codebases that'll come".** The first version of R3 made the measurement a go/no-go: below 1.5x
  simulated speedup, parallelism would move away from peval. That clause entered with this plan; it did not
  come from the user. It is removed. Added D16 (parallel evaluation is required; long spans are shortened by
  forking typed bodies, speculation, type hints, and parallel stages beside peval) and a scaling corpus in R3.
- **2026-10-14 00:54, R2, proposed (not adopted; the decisions above are unchanged).** Five findings from the
  shared state inventory that contradict or extend a decision. Each needs a measurement or a user call before
  it is adopted.
  - **P1. The key does not fix the result when a body fails (core fact 3, D3, D4, D6).** A body evaluation
    inherits caller context that is not part of the key: `trace` (163003, 162580, 162397), `inline_depth`
    (163004, 162581, 162398), `DynamicIfNesting.depth` (a `ThreadLocal` that is not reset at a body,
    162750-162762), `RustGapTrace.validating` (162336, 163448) and the physical stack depth
    (`TryEnsureSufficientExecutionStack`, 49283, checked at 162672). Single-flight evaluates a key with its
    first caller's context in depth-first order. Under D3 the first claimant owns the key, and with forks or
    speculation the first claimant is not always single-flight's first caller. Effects: whether and where
    `EJP0011`/`EJP0040` fire, the trace stored in every residual statement (`TyLet(_, d.trace, _)`, 162377,
    shown by codegen errors 166380-166382), and whether RUST-GAP reports are suppressed. Successful residual
    text is not affected: in the single-flight projection's codegen (164592-185063) the stored trace is read
    only by `raise_codegen_error'` (164670) and passed through unchanged by `DeadPureLetElision`
    (164924-164970); a grep for any other use of `trace`, `#line`, `.path` or a range in emitted text finds 0.
    The inventory's old row "DynamicIfNesting.depth: per-body counter in `LangEnv`" would
    change when EJP0040 fires if the counter starts at 0. Proposal: evaluate a forked body with a relative
    context (its own frame as the trace, depths 0, not validating) and record its maximum relative depths;
    at the D6 merge, when the canonical caller's depth plus the body's maximum crosses a limit, or a codegen
    error needs the absolute trace, or the canonical caller was validating, evaluate that body again in place
    with the canonical caller's context. That is a deterministic restart of a pure evaluation (as D16.3), not
    a replay. R4's BFS and random policies change the first caller, so they measure how often this happens on
    the corpus.
  - **P2. The BackendSwitch validation cache has side effects (D7).** D7 says `backend_switch_validated` holds
    the same value whoever fills it. Its value is a type, but the first validation also has effects that a
    cache hit skips: (a) `global'` (164405-164409) runs inside a validation whenever the validated arm, or a
    switch nested in it, runs the current backend's arm (a nested switch validates every other arm with
    `s.backend` set to that arm's backend, 163447, so the build backend's arm passes the 164405 test); the
    global goes into the one shared list (163447 keeps `globals`), at a position set by whichever body
    validated first; (b) `PrintStatic`/`PrintRaw` stdout (164373-164375); (c) join point fills for the arm's
    backend. This path follows from the code; no corpus sample was run to show it (R2 runs nothing).
    Proposal: the cache value is the type plus the validation's ordered effect list, and the D6 merge treats a
    validation as a child node at the position where single-flight first ran it.
  - **P3. D4 covers only method recursion.** A pending type join point raises "Type join points must not be
    unboxed during their definition." (162576), and `ty_is_uninhabited` swallows that error (162555), so a
    pending type join point reads as inhabited there. A pending closure is not an error at all (162425-162426:
    recursion returns the key). Proposal: D4 names all three; the error (or the swallow) happens only when the
    awaited key is on the waiter's own ancestor chain; any other pending key is awaited.
  - **P4. The plan's inventory said the top env is immutable `Map`s.** It is two `Dictionary`s copied per build
    before peval (161809-161810, 185737-185742) and never written during peval. The discipline (read-only) is
    unchanged; only the fact is corrected in the table.
  - **P5. Peval state is not frozen when codegen runs (D16.4).** `PartEvalResult.ty_to_data` and
    `nominal_apply` (164584-164585) close over the root env; codegen calls them throughout (e.g. 166310,
    172691, 176918), and they can fill `join_point_type`, build new `Union` instances and evaluate `TTerm`
    bodies. Codegen also appends to the shared `globals` list (166351 and every backend's `global'`). Codegen
    per method in parallel (D16.4) therefore needs the D3 `join_point_type` table during codegen and a D6
    merge of codegen-time globals in codegen's traversal order.

- **2026-10-14 01:44, P1-P5 decided (main thread, under the user's standing rule to make open technical calls).**
  - **P1 adopted.** A forked or speculative body runs with a relative context (its own frame as the trace,
    depths 0, not validating) and records its maximum relative depths. At the D6 merge, if the canonical
    caller's depth plus the body's maximum crosses a limit, or a codegen error needs the absolute trace, or the
    canonical caller was validating, the body is evaluated again in place with the canonical caller's context.
    This is a deterministic restart of a pure evaluation (D16.3), not a replay (D2). R4 counts how often it
    triggers on the corpus; if it is frequent, fork boundaries move, the rule does not.
  - **P2 adopted.** The validation cache value is the type plus the validation's ordered effect list (globals,
    static prints, join point keys it filled). The D6 merge treats a validation as a child node at the
    position where single-flight first ran it. D7 is amended: a cache is idempotent only together with its
    effect list.
  - **P3 adopted.** D4 covers all three pending cases: a method key (the annotation error), a type join point
    (the unbox-during-definition error and its swallow in `ty_is_uninhabited`), and a closure (recursion
    returns the key, no error). The error or the swallow happens only when the awaited key is on the waiter's
    own ancestor chain; any other pending key is awaited.
  - **P4 adopted** as a fact correction; discipline unchanged (read-only during peval).
  - **P5 adopted.** Codegen is not a read-only phase: join_point_type stays a D3 fill-once table during
    codegen, and codegen-time globals are merged by D6 in codegen's traversal order. This is a precondition
    for D16.4 (codegen per method in parallel).
