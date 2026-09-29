# Hopac frontier

Status as of 2026-09-27, measured on Windows with
`pwsh scripts/test.ps1 -Mode hopac -Suite frontier,smoke -Native -Record` (46 jobs, one process per job,
20 s per job, 2 in parallel). Full rows: `<cache>/scoreboards/hopac.tsv`.

| Suite | Jobs | ok | error | timeout | Parity with single-flight |
|---|---:|---:|---:|---:|---|
| frontier | 12 | 12 | 0 | 0 | 12 / 12 |
| smoke | 34 | 32 | 2 | 0 | 34 / 34 (both errors are rejections single-flight also reports) |

Native: 36 runs, 0 build failures, 24 agree with C, 0 disagree. A trivial program compiles in ~5-7 s in
a fresh process. Wider suites: see "Beyond smoke" below.

Earlier the same day the record was 0 ok and 41 timeouts; later, with errors instead of timeouts, 11 ok.

## The fast loop

```powershell
pwsh scripts/build.ps1 -Mode hopac                                    # core edit: ~4 min
$env:SPIRAL_HOPAC_WORKERS = 1; $env:SPIRAL_DOP = 1                    # deterministic: one Hopac worker
pwsh scripts/test.ps1 -Mode hopac -Suite frontier -Filter frontier_fib -Backend C -Parallel 1
```

With one worker, bugs that were nondeterministic at 8 workers reproduce on every run, and a build that
deadlocks at 1 worker is blocking a Hopac worker on something that needs the scheduler. For a hang, take
a stack dump of the stuck process: `dotnet tool install dotnet-stack --tool-path <cache>/tools`, then
`dotnet-stack report -p <pid>`. For slowness, take several dumps a few hundred ms apart and count the
innermost frames. For a wrong result, cut a 5-line program and compare with single-flight (see how
`frontier_try_item` was reduced to `match Cons (a, Nil) with | Cons (x, _) => ...` below).
`SPIRAL_DEBUG_UNBOX=1` prints each union unbox's case, operand classification and value shape.

For body-only edits there is a faster loop: `scripts/gear-dev.ps1` builds the core as 141 gear assemblies
and rebuilds only the gear owning the edit (~90 s for an edit in `peval`, against ~200-400 s for the
monolith). Point the tests at it with `SPIRAL_COMPILER_DLL`. A body edit keeps the split plan (measured
over 6 edits across the core), and since the gear anchors and surface rules (2026-09-28) so does adding
or removing a top-level declaration: one `let` added is 1 gear and 92 s end to end, against 1,056 s
before (see the splitter README). The split loop is now the faster one for every kind of edit. The split
compiler gives the same frontier and smoke results as the monolith. Details are in
`lanes/splitter/README.md`.

## Root causes fixed (core: hopac's side of `apps/compiler/spiral_compiler.fs`; before 2026-09-28 `compiler/cores/hopac/spiral_compiler.fs`)

In the order they were found; each was confirmed with a stack dump or a reduced program.

1. **Durable log writes deadlocked the evaluator.** Every durable JSONL row waited synchronously for a
   Hopac actor, and the evaluator writes rows from Hopac workers: with one worker every build deadlocked,
   with N workers builds stalled at random. The writer is now a lock-serialized synchronous append.
2. **`BuildFile`'s body ran on a Hopac worker** and joined the big-stack evaluator thread, which itself runs
   Hopac jobs. The body now runs on its own thread (256 MB stack) and the job awaits it as a task.
3. **Codegen memo tables were rebuilt on every call.** `and method key = jp (...) key` (46 definitions,
   every backend) created a fresh memo dictionary per call, so recursive join points recursed forever
   (fib) and every method was emitted again as `method0` (the "duplicate definitions"). Eta-reduced to
   `and method : _ -> T = jp (...)` as in single-flight.
4. **Replay re-executed parents that were still running.** A child committing its value scheduled a
   replay of its parent even while the parent's direct evaluation was on the stack; the replay appended
   the parent's statements to the same sequence again (`let v0 = 42` twice, `main` twice). Parents whose
   evaluation is active in `term_core` no longer get that handoff.
5. **Errors never reached the host.** Typed build errors went to the sidecar log only ("no code and no
   diagnostic"); `errors.traced` is sent again.
6. **Logging enumerated every process on the machine** (`Process.GetCurrentProcess()` memory fields on
   each JSONL row); stack samples put most of partial evaluation there. Cached for 250 ms.
7. **Parallel maps with shared counters.** `rename_global_term` renamed join point arguments with a
   parallel map that increments `s.i`: `add x y` compiled as `x + x`. All 82 `A.*` calls in the partial
   evaluator are sequential now (as are codegen's), like single-flight's `Array.map`.
8. **Type join points returned placeholders on first use.** The first requester scheduled the type
   computation asynchronously and returned `JPTypeRecPlaceholder` at once, so `Cons (a, Nil)` was built as
   a raw nominal pair instead of a union and every later unbox missed (`frontier_try_item`, the GADT and
   existential contracts), and placeholders reached codegen (`tagged_union_scalar`). The type is now
   computed inline; other threads wait for it; same-thread recursion still breaks with a placeholder.
9. **Timing heuristics killed live builds** (`EJP0019`/`EJP0021` from the big-stack join loop, after a
   few seconds). The join now waits for the evaluator like single-flight, under any host (including
   polyglot's Supervisor), and the `BuildFile` watchdog alone reports real stalls, with their stage. The
   watchdog is always armed: the host's deadline, else `SPIRAL_BUILD_BUDGET_MS`, else 15 minutes.
   `SPIRAL_LEGACY_JOIN_HEURISTICS=1` restores the old slice loop.
10. Smaller: runtime `StaticStringConcat` ported from single-flight (C backend); WriteGuard accepts new
    small files; run-end and artifact-commit waits are bounded (500 ms each); codegen runs on a large
    stack; the `dyn` literal rule restored; codegen helpers sequential.
11. **Single-flight delta ported.** Both cores descend from commit `12f52a1` (2025-12-10); single-flight's
    changes since then are 679 lines in 112 hunks. A textual merge does not work: diff3 gives 57
    misaligned conflicts, and `patch` applies only 15-20 hunks at fuzz ≤ 1. So the delta was ported
    semantically, keeping hopac a superset of single-flight:
    - ops `StdoutFlush` and `MonotonicDelayMs` (registered for the parser by reflection over `Op`);
    - UTF-8 byte semantics for string length, index and slice in the evaluator, plus C `StringSlice`
      with a boundary check;
    - C `Sin`/`Cos`/`Pow` via `math.h`, and C/C++ lowering of the two new ops;
    - union box/unbox case indices taken from the union's case order;
    - nominal-union `dyn`;
    - `preservesDuplicateGlobalFragment` for the global dedup in all six backends;
    - `SPIRAL_COMPILER_PACKAGE_DIR`;
    - a `Check`-backend skip and a missing-`main` fatal error in `BuildFile`.

    Not ported: single-flight's parser combinator refactors, cross-assembly factories, `[<NoComparison>]`
    changes and `>>=*` promise binds. They are refactors with no fixture that depends on them.
    To port a future change, diff `compiler/cores/single-flight/spiral_compiler.fs` against
    `git show 12f52a1:apps/compiler/spiral_compiler.fs`.
12. **CSE table race.** Hopac jobs that evaluate in the same scope share its CSE tables.
    `push_typedop` did lookup-then-`Add` unguarded, and a lost race threw `An item with the same key has
    already been added. Key: TyOp (Dyn, ...)`.
    - The tables are now `ConcurrentDictionary`, so reads are lock-free.
    - `push_typedop` serializes lookup, insert and the matching `seq` entry per scope.
    - A first version locked every read. That serialized lookups through the outer scopes and cost about
      20% of compile time (median frontier+smoke compile 7.7 s → 9.4 s).
    - The scope's `seq` (`ResizeArray`) is still appended to unguarded outside `push_typedop`.
13. **`while` over a join point whose return type is still pending.** The run-to-run `EJP0010 ... single
    join point` rejections of `while_loop` came in two shapes, both around the placeholder
    `DSymbol "JPMethodUnknownRet(..)"` used while the method body is still being evaluated elsewhere:
    - The call is bound to the placeholder, and `seq_apply`'s reference check cannot fuse
      `TyLet x; TyLocalReturnData x` into one `TyLocalReturnOp`.
    - A retried evaluation of the condition leaves the first attempt's `TyLet placeholder <- call` in the
      scope's `seq` in front of the retry's `TyLocalReturnOp call`, so the call is emitted twice.

    `While` now drops the stale placeholder-bound call and fuses the first shape; its existing force-read
    of the method cell then resolves the real `bool`.
14. **Replay re-ran effectful applications (silent miscompile).** Even when `while_loop` compiled, about 3 runs
    in 8 emitted its body once *before* the loop as well; the exit code happened to agree. The cause was
    found with `SPIRAL_DEBUG_TERM_TRACE=samples/while_loop/main.spi:2`, which logs every `term` evaluation of
    an application on a source line with its stack and scope:
    - Replay registration stores a whole-spine thunk per application that re-applies the function in the
      captured scope.
    - When the replay driver's orphan drain forced that thunk, the whole `while'` application ran a second
      time, while the direct evaluator was running it or after it had finished.

    Thunks now refuse nodes the direct evaluator owns: it is active on them (`isDirectNodeActive`) or has
    completed them (`markDirectNodeCompleted`). They fail closed, so the direct result stands. `While`/`Do`/
    `Indent` arguments are also no longer registered as replay children of the parent scope. Afterwards
    `while_loop` gives the same residual on 8 of 8 runs.
15. **Diagnostics.**
    - Unexpected .NET exceptions (NullReference, InvalidOperation, KeyNotFound, ...) now carry their
      innermost compiler frames in the `FatalError` text.
    - Codegen reads join-point body cells through `jpBodyCellAwait`, which waits up to 3 s for a producer
      still running and otherwise fails with `EJP0035 ... never filled`, instead of the null that
      `IVar.Now.get` returns.
    - The `while` rejection prints the binds it got.

16. **`if` branches replayed into the enclosing block (silent miscompile).** `while_control` returned −12
    instead of 0 on C and Delphi on some runs. The C had a `break;` right after the condition, before the
    `if`, and the loop left on its first pass. `SPIRAL_DEBUG_TERM_TRACE=while_control/main.spi:7` (now
    also logging macro terms and macro replay thunks) showed the extra `break` coming from the replay
    driver: `runReplayDriver` → `tryApplyReplayDataWithContext` → `runApplyAfterDefinition`. It ran on a
    join-point promise's resumption loop or a parent-cache handoff wake, before the direct evaluator
    reached the branch.
    - Registering an `EIfThenElse` also registered both branch subtrees as replay children, with the
      scope *around* the `if` as their context. A runtime `if` runs each branch in a scope of its own, so
      a branch application replayed from there emitted its statements into the enclosing block. This is
      the path fix 14 did not cover, since it guarded only whole-spine thunks.
    - Only the condition is registered now, in both registration switches; the branches are left to the
      direct handler, as `While`/`Do`/`Indent` arguments are. The worklist also no longer probes the
      branches of a runtime (`DV`) condition, or of an `if` the direct evaluator owns.
    - `while_control`: 12 of 12 runs correct, against about 1 in 4 wrong before. In the wide run
      `DISAGREE` went from 1 to 0 and examples gained 7 rows (see "Beyond smoke").

17. **Native Rust and Delphi backends.** `codegenRust` and `codegenDelphi` were ported from the
    single-flight core. Join-point bodies come through `jpBodyCellAwait`, like the Gleam and Lua backends,
    and union and layout keys are `UnionTagId`/`LayoutFieldNameId`. Rust and Delphi are no longer
    translated from hopac's C, so the translator-specific failures above (`continue` outside a loop,
    duplicate identifiers in the Rust/Delphi versions of hopac's C) no longer apply as such.
    Frontier and smoke: Rust 11/11 and Delphi 11/11 agree with C.

18. **Join point parameters permuted against their arguments (silent miscompile).** `tuple_mixed` and
    `portable_composite` computed −6 instead of 0: `method1(v3, v2, v1)` passed an `int32` where the
    method's first parameter was a `bool`. `data_to_rdata` numbers a join point's call arguments while
    walking pairs tail-first (`dataPostorderChildRelation`, which other hopac code relies on), and
    `rdata_free_vars` listed the method's parameters walking pairs head-first, as single-flight does for
    both. Parameters are now ordered by their argument index, which is correct whatever the walk order.

19. **Tail calls lost: the last `if` of a method let-bound (stack overflow).**
    `native_managed_array_tail_recursion` overflowed the stack on C (exit 217 on Delphi): hopac emitted
    `let v5 = if .. else method1(..) in v5`, so the self call was no longer in tail position and C kept
    the refcount decrements after it. `seq_apply` fuses a block's last `TyLet x` with a return of `x` only
    when both are the same object (`Object.ReferenceEquals`); replay rebuilds wrapper values, and for an
    `array` (a nominal) the return was a new `DNominal` around the same `DV`. It now compares variable ids
    through nominals and pairs. The output is now identical to single-flight's.

20. **`if` condition evaluated before the preceding statements (silent miscompile, ordering).**
    `set a 0 13` followed by `if index a 0 = 13` emitted the read (four times) before the `set`, then
    again after it. Fix 16 left the `if` condition registered as a replay child when the term is entered,
    which walks ahead of evaluation; the replay driver then evaluated a condition that emits code in the
    enclosing block, early. Only atom conditions (variable, literal, symbol) are registered now; others
    are left to the direct evaluator, as the branches are. Reduced case and fix verified; nested reads in
    other ops (`index a 0 + 1`) were never affected.

Host (`compiler/host/Program.fs`): `SPIRAL_HOPAC_WORKERS` / `SPIRAL_DOP` determinism knobs, and an
absolute build deadline (`SPIRAL_BUILD_DEADLINE_MS`, 3 s before the job timeout).

## Beyond smoke

`pwsh scripts/test.ps1 -Mode hopac -Suite examples,contracts -Native` (1,154 jobs, ~75 min), 2026-09-28
after fix 16:

| Suite | Jobs | ok | error | crash | Parity | missing |
|---|---:|---:|---:|---:|---:|---:|
| examples | 547 | 421 | 126 | 0 | 493 | 50 |
| contracts | 607 | 167 | 439 | 1 | 587 | 19 |

Native: 373 runs, 205 agree with C, 21 build failures, 0 `DISAGREE`. Most `error` rows are rejections
that single-flight also reports (the contracts are mostly negative cases). Against the run before fix 16,
examples gained 7 rows. The 6 contract rows that went the other way are flaky: each also fails on the
pre-fix compiler, or passes on a rerun, as it sits at the ~25 s build budget.

Silent miscompiles still open (compile, run, wrong answer): `tuple_mixed` and `portable_composite` on C
(−6 instead of 0). Tuple elements are permuted across a join point (`method1(v3, v2, v1)`), so `bias`
receives `ok`. Also `native_managed_array_tail_recursion` on C (stack overflow) and Delphi (exit 217), and
`dynamic_array_tuple_managed` on Rust (0 instead of 2).

**Silent miscompiles first** (worse than any error). Both are resolved now:
- `managed_string_recursive` gave a different answer than C (`DISAGREE`). Since fix 14 (replay no longer
  re-runs applications) it agrees on C, Rust and Delphi, 4 of 4 runs.
- `rust_target_globals` got Delphi code although single-flight rejected the program
  (`UNEXPECTED-OUTPUT`). The oracle was wrong: the shared host inserted Delphi target globals after
  `{$mode objfpc}{$H+}\n`, but some Delphi lowerings end that line with `AppendLine`, which writes CRLF on
  Windows, so single-flight's output never matched. The insertion normalizes to LF now, single-flight
  emits the Delphi that the fixture's README describes, the row is re-blessed, and hopac has parity.

The 96 rows without parity, by cause:

- 27 stall in partial evaluation (`native_cube_*`, `managed_string_codepoints`). Not a parked join:
  `native_cube_direct` (53 lines) runs 116 s with the evaluator busy in direct evaluation
  (`tryDirectDeclaredResume` → `putTermValue`) until the watchdog stops it, so an evaluation loop, most
  likely a wrong static/runtime decision that unrolls forever (as the union-unbox bug did). Much of its
  CPU goes to telemetry: every committed value emits a handoff row whose envelope is SHA-256 hashed.
- ~25 were features only the single-flight core had. Fix 11 ported them. On the 2026-09-27 rerun these now
  pass on every backend: `managed_string_slice`, `managed_string_utf8_boundaries` and
  `native_float_math_family`. `managed_string_empty_slice` passes on C, and `native_float_pow_pi` and
  `while_control` gained backends. The `native_cube_*delay*` fixtures parse now and join the
  evaluation-loop stalls below.
- `Failed to parse this token` on backtick type application (`indexed_dfa_probe`,
  `generic_indexed_alphabet_authority`, `compiler_probe_generic_inventory_pack`) is **order-dependent**:
  - it fails on every run with `SPIRAL_HOPAC_WORKERS=1`, and in about 1 run in 3 with 8 workers;
  - single-flight parses the same file;
  - the parser and its combinators are identical in both cores, and the tokenizers differ only in
    triple-quoted strings, which these files don't use.

  The failure matches the file being parsed with `is_top_down=true`, where `` `x `` in a term consumes
  the token and returns `Error []`. Next: dump the token stream and `is_top_down` for line 68 of
  `indexed_dfa_probe/main.spi` from both cores.
- 9 closure failures inside branches (`native_closure_*branch*`) were a bare `NullReferenceException`.
  They now report `EJP0035: join point body cell (JpClosureBodyCellPayload) was never filled`. The
  producer's partial-step control exception takes the
  `jp_closure_body_control_deferred_without_failure_fill` path, which keeps the promise pending for a
  later retry. Nothing retries a closure created in a runtime `if` branch, so codegen finds the cell
  empty.
- ~20 native build failures, mostly Rust/Delphi lowering of hopac's C (`continue` outside a loop,
  duplicate identifiers): hopac's C is shaped differently from single-flight's in a few constructs.
- 4 WriteGuard refusals (`WRITE_ABORT`), 5 crashes (one inside a Hopac worker). The refusals are real
  symptoms, not guard noise. For `native_package_fixed_array_*`, hopac emitted an 11-line, 154-byte
  `main.c` where single-flight's is 2,329 bytes; the residual collapsed and the guard refused to shrink
  the file.

## Next step

In this order, each with `SPIRAL_HOPAC_WORKERS=1`, a stack dump, and a reduced program compared with
single-flight:

1. ~~`managed_string_recursive` and `rust_target_globals`~~ (resolved, see above).
2. `native_closure_captured_branch` for the closure `NullReferenceException`s. Lead: method join points
   have the same deferred-placeholder design (`JpMethodDeferredFromOwnedProducer`) that fix 8 removed for
   type join points. 2026-09-28: a direct compile (`--backend Fsharp`, `SPIRAL_HOPAC_WORKERS=1`) hangs
   for good. `dotnet-stack` shows codegen blocked in `requireResolvedClosureCell` on
   `CodegenJpClosureBodyCellPending` (`run (IVar.read ivar)`), all Hopac workers idle: the closure's
   producer job (`startHopacJob (jp_start_named_with_metadata .. run)` in the closure specialization) ended
   without filling its cell, most likely through the `JpPromiseProducerPreservePendingWithoutFailureFill`
   branch, which re-raises and leaves the promise pending. The run's `.jsonl` (in
   `<cache>/core-src/hopac/`, one per compile, 7.5 GB accumulated) has no producer event for it; the
   emission policy thins them out. Next: log that branch's exception type unconditionally, then decide
   what should retry or fail the cell. (A direct compile has no build deadline unless
   `SPIRAL_BUILD_DEADLINE_MS` is set.)
3. `native_cube_direct` for the evaluation loops.
4. Port the single-flight-only features, then `-Suite mega`, `-FreshProcess:$false`, and `apps/spiral`.
