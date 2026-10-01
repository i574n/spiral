# Hopac frontier

**Status 2026-10-01 17:53 (fixes 55-57):** `runs/hopac-20261001-171327` (`-Suite all -Native`, 3 workers,
fresh processes): frontier 20 + 4 `missing`, contracts 606 + 1 no-oracle, examples 453/453, mega 5/5,
DISAGREE 0, no `emitted` row; every residual hash equal to the 05:12 run's. The 4 `missing` are
`frontier_runaway_inline_recursion` (new, blessed `error`): hopac needs ~20 s to reach its `EJP0040` report,
past the frontier deadline, and the harness now scores a core's `BuildFile stalled` as a timeout. That is the
only gap left to the AGENTS.md promotion criterion. **apps/spiral compiles in the default async mode** (fix 55;
attempt 20 on this DLL: 576 s, 2,687,696 bytes, the same as attempts 17-19). Warm processes (fix 57) are an
experiment.

**Update 2026-10-01 06:50 (fix 54):** `runs/hopac-20261001-051209`: frontier 20/20 (with
`frontier_static_list_eq` on four backends), contracts 606 + 1 no-oracle, examples 453/453, mega 5/5,
DISAGREE 0; the single-flight restore run after it matches. apps/spiral on hopac: past every semantic wall,
attempt 14 then ground in the declared-body resume-snapshot pruning (NEXT.md); attempt 15 runs with
`SPIRAL_HOPAC_INLINE_JP=1` (`$CLAUDE_JOB_DIR/tmp/apps_spiral_hopac15_inline.txt`).

**Status 2026-10-01 04:00 (fixes 21-53):** `runs/hopac-20261001-025722` (`-Suite all -Native`, 2 workers)
against the oracle re-blessed on 2026-09-30 (three identical single-flight runs; the 5 mega brzozowski rows
are now `error`, fix 49):

| Suite | Jobs | Parity | Not parity |
|---|---:|---:|---|
| frontier | 16 | 16 | 0 |
| contracts | 607 | 606 | 1 no-oracle (a row that times out in both lanes; `-Bless` never records timeouts) |
| examples | 453 | 453 | 0 |
| mega | 5 | 5 | 0 |

Native: 359 ran, DISAGREE 0. Every oracle row is reproduced. The single-flight restore run right after
(`single-flight-20261001-035430`) matches it row for row.

**apps/spiral.** Single-flight builds it again (exit 0, 738 s, 2.79 MB of F#; the committed `spiral.fsx`
from 2025-12-30 is 2.79 MB too): the wall was a library bug, not either core (`sm'.span_from`, NEXT.md).
Hopac still fails on it (attempt 12: `EJP0011` at `listm'.try_item`, 1,025 re-entries). Reduced to
`samples/frontier_static_list_eq` (blessed from single-flight, 4 backends): hopac does not fold `=` between
two static lists. `if [ ' '; '/' ] = [] then 1 else 0` is `0` in single-flight; hopac emits a join point
for the failure continuation of `real_core.spir:208`'s `!!!!Unbox2(..., (fun () => false))` (method key
`<anon> @jp@real_core.spir:208:66-208:72`) and branches on its runtime result. A static `chars` list then
turns runtime, and `sm'.char_contains` → `listm'.exists'` → `try_item` unrolls forever. Neither core's
front end creates that `EJoinPoint` from a plain lambda, and both cores' static `Unbox2` branch is
`apply s (on_fail, DB)`; next, find where hopac's `apply` turns that closure into a join point (likely the
dynamic-join apply bridge, `installDynamicJoinApplyAfterDefinition`). `SPIRAL_HOPAC_INLINE_JP=1` (inline
join points from the first step) does not change this.

**Status 2026-09-30 18:00 (fixes 21-44):** `pwsh scripts/test.ps1 -Mode hopac -Suite all -Native`
(`<cache>/runs/hopac-20260930-171614`, 1,081 jobs, 3 workers, quiet):

| Suite | Jobs | Parity | Not parity |
|---|---:|---:|---|
| frontier | 16 | 12 | 4 new: the two fix-44 fixtures (F# compiles; C/Rust/Delphi rejected, `sm'.format` has no backend case for them), no oracle rows yet |
| contracts | 607 | 597 | 9 UNEXPECTED-OUTPUT, 1 no-oracle |
| examples | 453 | 422 | 12 UNEXPECTED-OUTPUT, 16 new, 3 NATIVE-DIFF |
| mega | 5 | 5 (brzozowski 6 s, zeta 10 s, omniledger 28 s, lean_cic 32 s, spiral_proves 51 s) | 0 |

Against the 12:26 run (fix 41): no verdict changed; the only new rows are the two frontier fixtures'.
Fixes 45-47 (`runs/hopac-20260930-193524`, 21:10): 61 rows `missing` with `BuildFile stalled` at ~18 s of a
20 s job budget, on a machine saturated by `gear-dev -Full`, two apps/spiral compiles and two agents
(compile phase 4,879 s against 2,053 s). Rerun of those 49 samples with 2 workers
(`runs/hopac-20260930-212855`): 113/113 ok, 0 verdict changes against 17:16. So 44-47 change no verdict;
suite timings are only meaningful on a quiet machine.
Compile phase 2,053 s, median job 4.1 s. Native: 359 ran, DISAGREE 0. The 21 UNEXPECTED-OUTPUT rows
are single-flight-identical "(expression)" outputs awaiting the re-bless (NEXT.md). `apps/spiral`: see
fix 44 (2 pending join points left, then a codegen wait on an unfilled cell; NEXT.md).

**Status 2026-09-30 (fixes 21-37):** `pwsh scripts/test.ps1 -Mode hopac -Suite all -Native`
(`<cache>/runs/hopac-20260930-050954`, 3 workers, `SPIRAL_DIAG_QUIET=1` from the harness):

| Suite | Jobs | Parity | Not parity |
|---|---:|---:|---|
| frontier | 8 | 8 (4 have no oracle row yet) | 0 |
| contracts | 607 | 597 | 9 UNEXPECTED-OUTPUT, 1 no-oracle |
| examples | 453 | 430 | 12 UNEXPECTED-OUTPUT, 8 new, 3 NATIVE-DIFF |
| mega | 5 | 5 (brzozowski 5 s, zeta 15 s, omniledger 38 s, lean_cic 64 s, spiral_proves 106 s) | 0 |

No `missing` row. The 21 UNEXPECTED-OUTPUT rows are F# outputs that end in an expression, which the host
now accepts. They need single-flight rebuilt with the same host and the oracle re-blessed. Native: 359
ran, 1 DISAGREE (Rust `managed_string_invalid_utf8_slice`, a shared `codegenRust` issue, fixed right after
this run: both lanes now DISAGREE 0). The NATIVE-DIFF rows are translator-era oracle values (NEXT.md). Compile phase 2,390 s, median job 4.2 s (`frontier_hello`
~3 s). Two known races can still flip a row: 34 (replay values per AST node) and 38 (multi-package
type checking).

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

21. **Compiler stack overflows inside the BigStack spawn.** Some contracts killed the compiler (exit
    0xC00000FD) in about 1 run of 3: `evalCoreWithBigStack` moves deep evaluation to a fresh big-stack
    thread when `EnsureSufficientExecutionStack` says the stack is short, but that probe only guarantees
    ~128 KB, and the spawn itself (a SHA-based `ContentDigest.ofText`, formatting) plus the parent's join
    loop sometimes needed more; the overflows were on Hopac scheduler workers. `BigStack.StackBudget` now
    measures the stack left by address, with the thread's exact limits from `GetCurrentThreadStackLimits`
    on Windows (any thread, Hopac workers included; threads of known size record their start elsewhere),
    and spawns once less than 2 MB (or a quarter of a smaller stack) is left. The three crash-prone
    contracts went from 1-2 crashes per 5-job run to none in 5 runs; frontier and smoke unchanged.

22. **Method bodies lost their statements after a cooperative yield.** `native_cube_direct` emitted
    `int32_t method0(){ return v1; }` and `native_string_utf8_validate_source` emitted
    `utf8_scalar_at_byte_offset1` as `return v25;` (hopac's residual 5 KB against 28 KB, the
    `WRITE_ABORT`s below). A declared method body (`JpVerifyDeclaredMethodBody`) ran in slices: after 256
    operations (96 for invocation-volatile effects), or every 64 (24) bindings of one `let` chain or apply
    spine, it yielded and was resumed later from a saved continuation. Resume is unsound in both of its
    styles:
    - *direct resume* continues in the environment the continuation saved, and so in the earlier slice's
      block (`LangEnv.seq`), while `run ()` reads the body back from the new slice's fresh block: the
      statements are lost and only the returned variable survives;
    - *prefix replay* re-evaluates the body from its root and re-emits the prefix. Sharing the block
      across slices (tried: one root block per work job) fixes direct resume but repeats the prefix here,
      a silent miscompile once a statement has an effect, so it was not kept.

    Neither fix 18, 19 nor 20 caused it (reverting all three, or building the pre-merge core, reproduces
    it); it was hidden while cube stalled. Declared bodies no longer time-slice: the default budget is
    2^24 operations with a checkpoint every 2^22 bindings. Both fixtures now match single-flight (cube
    byte for byte; utf8 exits 0, and its method bodies are identical). The resume path is kept, not
    fixed; `SPIRAL_JP_SLICE_OPS=<max>,<interval>` brings budgets back to reproduce its bugs:
    `SPIRAL_JP_SLICE_OPS=128,32` makes `native_string_utf8_validate_source` repeat a prefix, and
    `64,16` makes `native_cube_direct` stall.

Run after fixes 21-25 (2026-09-29, `-Suite frontier,smoke,examples,contracts -Native`, 3 workers,
`<cache>/runs/hopac-20260929-185749`; reaped for low memory at 1,011 of ~1,100 jobs, so there is no
`results.tsv`, only the per-worker files): on those 1,011 rows the compile status matches the oracle for 956,
against 937 in the fixes-18-20 run. 31 rows fixed: every `native_closure_*branch` row (C, Rust, Delphi),
`native_string_utf8_*` (fold, grapheme, scalar, normalization, with their `_invalid` variants),
`managed_string_codepoints` [C], the two contract crashes (fix 21),
`contract_partition_healing_cancellation_saga`, and the closure `NATIVE-DIFF`s (the C closure fix). 12 rows
went the other way: 10 build-budget stalls that each compile within budget when rerun alone (16-22 s for
the contracts: the run shared the machine with compiler builds and profiling), and 2 mega sub-packages whose
oracle is wrong (see "Resolved (2026-09-29)" below).

Wide run after fixes 18-20 (2026-09-29, `-Suite examples,contracts -Native -Parallel 1`): examples 413/461
parity, contracts 585/607, native 7 build failures (21 before), 0 `DISAGREE`; the three fixtures above and
`managed_string_codepoints` (Rust, Delphi) now pass. New: 4 compiler stack overflows (exit 0xC00000FD) in
contract and mega sub-packages (fix 21), 4 `WRITE_ABORT`s on `native_string_utf8_*` (hopac's residual 5 KB
against 28 KB) and `native_cube_direct`, which used to stall, finishing with statements missing (both fix
22).

23. **Replay repeated applications, out of order (silent miscompile once effects are involved).**
    `native_string_utf8_validate_source`'s `main` called `utf8_validate_loop0` seven times where
    single-flight calls it twice, and `samples/native_replay_repeat_call` (`inl a = sm.utf8_validate "abc"`)
    four times instead of once. `SPIRAL_DEBUG_TERM_TRACE=core/sm.spi:135` showed where they came from:
    - The replay driver runs nested inside direct evaluation (cooperative ticks, same thread) and applied
      the call through its apply-spine route (`runReplayDriver` → `tryApplyReplayDataWithContext` →
      `tryRunApplyAfterDefinitionAt`), into the block the direct evaluator was still building, ahead of
      the statements before it (the empty string's call landed before the other). The direct evaluator
      then applied it again, and its values are the ones used.
    - The driver applied again on every tick that reached the cell, re-reading the arguments through their
      thunks (fresh variables each time).

    Fix 14 guarded only the whole-spine thunks, and only by node. Now:
    - `term_core` counts the blocks it is building (`enterDirectScope`/`exitDirectScope`, by `LangEnv.seq`);
      the apply-spine route fails closed for a node the direct evaluator owns or a block it is building,
      like the thunks;
    - an application the replay completed is recorded per node and block (`rememberReplayAppliedValue`);
      the driver's `EApply` case and both whole-spine thunks reuse it instead of applying again;
    - completed apply steps are memoized per node, block, function and argument.

    Both fixtures now emit single-flight's calls (1 and 2).
24. **Replayed applications got their arguments in reverse (`Expected a string. Got: i32`).**
    `native_string_utf8_scalar_source_invalid` and `native_string_utf8_normalization_bounded_source` failed
    type checking inside `utf8_scalar_at_byte_offset`: `str` was bound to the `i32`. Reduced: `let f (str :
    string) (i : i32) = ...` called as `f "abc" 1i32` (with literal arguments; `inl ~s` variables took the
    direct path and worked). The three apply-spine registrations collect arguments walking the `EApply`
    chain from the outside, so `argNodeIds` held the last argument first; the whole-spine thunks iterated
    it backwards, but the driver's `EApply` case applied it forwards, i.e. `f 1i32 "abc"`. Spines now store
    arguments in application order (the thunks keep their own array). This was older than fixes 18-22.
    Fixture: `samples/native_literal_join_args`.

25. **Closures in runtime `if` branches (`EJP0035 ... JpClosureBodyCellPayload was never filled`).**
    `native_closure_branch` (`inl ~g = if flag then a else b` over two annotated lambdas) and the other
    `native_closure_*branch*` fixtures (12 rows). The run log showed two closure work units with the same
    `computation_key` and instantiation (`generation=0|tag=0|hkey=..`): closure tags come from each owner's own
    hash-cons table, and both lambdas' environments are equal, so both were `JPClosure tag=0`. The second
    producer failed with `PromiseProducerBindingConflictFailure`, and that failure also voided the first's
    success (`worklist_terminal_failure_precedes_late_success`), so neither body cell was filled. The closure
    key and instantiation now include the owner's source range and backend, as method keys include theirs.
    (The old note blamed a retry that never came; the retry was never needed.) `native_closure_branch`,
    `_captured_branch`, `_managed_captured_branch` and `_nested_branch` now give C byte-identical to
    single-flight's (exit 42).

26. **Contracts 3-5x slower than single-flight (reported as stalls under load).** On a quiet machine the
    Release compiler took 32 s for `contract_public_byzantine_key_rotation` (260 lines) and 24 s for
    `contract_higher_rank_hot_swap`, against single-flight's 7 and 9 s; under a parallel suite plus builds
    they took 114 s and 72 s and hit the build budget. With the changes below, even the unoptimized Debug
    build takes 28 s and 22 s (the ledger change alone: 38 → 28 s for byzantine), and Release 27 s and
    22 s (`contract_dependently_verified_federation` 19 s): 10-15%, so the rest of the gap is elsewhere. A sampled-thread-time trace (`dotnet-trace collect --profile
    dotnet-sampled-thread-time --format Speedscope`, summarized per frame) of the byzantine compile:
    evaluation proper (`term`/`apply`) ~21% of busy time; `DiagJson.emit` ~25%, of which re-parsing the JSON
    it emits (`jsonStringFieldByName`, `jsonHasField`, `enrichJsonLineWithProgressEta`) ~10%; the semantic
    work ledger ~12% (`SemanticWorkUnitKeyId.CompareTo` under `keysForScope`/`countsForScope`, which
    scanned every admitted work unit on each heartbeat and credit decision); SHA-256 digests
    (`ContentDigest.ofText`) ~9%; the console HUD ~7%. Changed so far:
    - `EvalCycleGuard`/`EvalStackDepthGuard` digested the whole evaluation path on every enter/exit
      (quadratic in depth); the digest is lazy now (nothing reads it on the hot path);
    - `RecursionTracker.enter` digested a chained lineage on every term evaluation and took a global lock;
      lazy and unchained now, and the lock is taken only for a new maximum depth;
    - the ledger keeps per-scope admitted/receipt counts and open-key sets, so `countsForScope` and
      `openKeysForScope` no longer scan (`Set.toList` keeps the credit digests' key order).

    Next: `DiagJson.emit` (build rows from typed fields instead of re-parsing emitted JSON; sample the
    per-commit handoff rows), then the HUD repaint rate.
30. **The lexer's cross-line state was process-wide (context-dependent parse errors).** After fix 29 the two
    mega roots still failed at a multi-line parameter annotation (`(transport : t ⏎ a b c)`, "Expected: )"),
    yet the same definitions compile alone. `TripleString.in_triple` and `MultiComment.depth` were module-level
    mutables; hopac tokenizes files in parallel, so one file's open `"""` string (these files have 110 and 27)
    leaked into lines of another file tokenized at the same time. Both are `ThreadLocal` now: a file's lines
    are tokenized in one synchronous call after `reset_lexical_state` (tokenize_replace maps sequentially).
    **The mega-root parse errors remain, though**: fixture `samples/frontier_macro_then_multiline_annotation`
    (12 lines: `inl g forall a b. ⏎ (e : eq ⏎ a b) : i32`, "Expected: )" at `a`) fails in hopac and
    compiles in single-flight, and the outcome is timing-dependent (the same input parsed 1 time in 5; 0 of 3
    with 1 or 8 workers while a suite ran). Strictly, the continuation `a` (column 8) is left of the application
    head `eq` (column 9), so `apply` (`blockParsingIndent (col d) (<)`) should stop there in both cores, and
    single-flight still accepts it. Deterministic form, no `forall` needed: `inl g (e : eq ⏎ i32 i32) : i32`
    with the second line indented less than `eq` parses in single-flight and fails in hopac; indented more,
    both parse. The parser text on that path is identical in both cores (`root_pattern_type`, `root_type`'s
    `apply`, `col`, `line_template`, `try_current_template`). Resolved by fix 31: both cores reject the
    block, and the difference is in how the build reacts to that.
31. **A parse error in an unused block failed only hopac builds (timing-dependent).** Neither core's
    parser was the cause (fix 30). Single-flight also fails to parse `inl g (e : eq ⏎ i32 i32)` with the
    continuation left of `eq`, and even `inl g (e : eq i32 i32)) )`. It leaves the block out of the module and
    builds the rest; only a use fails ("Unbound variable: g"), and a broken `main` fails as "Cannot find
    `main`" (`contract_parser_error`). The host ended a build as soon as a `ParserErrors` diagnostic for the
    entry arrived. Single-flight never publishes one during a batch build (only an empty
    `TokenizerErrors`; `SPIRAL_HOST_TRACE_DIAGNOSTICS=1` shows the stream). Hopac publishes them
    asynchronously, so its result depended on whether they arrived before `BuildFile` returned: that is the
    1-in-5 of fix 30, and the mega roots' "Expected: )". The host now keeps `ParserErrors` as detail for a
    later `FatalError` instead of ending the build (host `diagnosticFor`).
32. **Fixed latency and telemetry cost on every compile.** Two 500 ms graces waited for receipts that never
    arrive in a batch build: the terminal writer's artifact commit (`SPIRAL_ARTIFACT_COMMIT_GRACE_MS`) and
    the run-end receipt, which cannot arrive before the result it waits on (`SPIRAL_RUN_END_GRACE_MS`). Both
    default to 20 ms now. `DiagJson.emit` compacted and enriched every row (memory, progress/ETA and
    seq/consensus envelope, each re-parsing the JSON) before its filters dropped most of them; the filters
    read only the producer's own fields, so it now decides on the raw row and enriches only rows it writes.
    `scripts/test.ps1` also deletes the compiler's per-process `<timestamp>.jsonl` mirrors older than 12 h
    from `<cache>/core-src`: about 1 MB per hopac compile, they had filled the disk (13 GB) and killed a run.
33. **Type errors in a dependency package hung the build (`last_stage=typecheck_await_scheduled`).**
    `native_source_package_prototype_*` (9 rows) and two brzozowski `negative_*` sub-packages stalled after
    type checking had finished. The stall was fix 27's own error listing, run inside a started Hopac job.
    It read `fst tc.files.uids_file.[mid]` for every package state in `packages_infer`, and a reset state
    holds null slots (`Array.zeroCreate`). The `NullReferenceException` was swallowed by the job, so the
    fatal was never sent. The debug watchdog (`SPIRAL_DEBUG_TYPECHECK_WAIT`) had the same flaw and printed
    nothing, which first looked like "every promise is filled". The listing now skips empty slots, reads
    only the part of each result stream already available (`Promise.Now`, never blocking), and falls back
    to a fatal without details if it still throws; the watchdog reports its own failures. The first
    attempt (non-blocking reads only) still stalled. Probe note: `SPIRAL_BUILD_DEADLINE_MS` is an
    absolute Unix time in ms (the host sets it); use `SPIRAL_BUILD_BUDGET_MS` for a relative budget.
34. **Replay values shared between evaluations of the same node (open; partly fixed).**
    `mega_brzozowski_derivatives/antimirov_typed_slot_bound` compiled in one full run and failed in the
    next, inside `normalize forall alphabet {symbol_compare}`, with "The types of two branches of an union
    unbox do not match. Got: symbol_ordering And: tri_alphabet". A match got branch values from two
    specializations. The replay store (`EvalReplayValueStore`) keys term thunks, apply spines and apply
    contexts by AST node identity (`RuntimeHelpers.GetHashCode`), and the latest registration wins. A
    replay for one evaluation can therefore read a thunk captured by another evaluation of the same node,
    and identity hashes can also collide. Fix 23's applied-value memo was keyed by (node, scope block), so
    two applications of one node in one block (an inlined function called twice) shared a value. It is now
    keyed by the evaluation's own context object, and the whole-spine thunks use the context they
    captured. That alone did not cure it: the next run hit the same mismatch in `derivative_runtime_gadt`,
    and after fix 37 `antimirov_certificate` hits it every time (11 s, no longer a stall).
    The whole-spine thunks now also take simple heads and arguments (`EB`, `EV`, `ELit`, `ESymbol`) from
    their own captured environment instead of the shared per-node store (not yet run in a suite). The
    real fix is a per-evaluation store: register under (node, context) and look up with the context the
    replay runs for, in the replay driver too.
35. **The brzozowski sub-package stalls are load-induced slowness.** `finite_inventory_adversarial` compiles
    alone in 18 s (single-flight 1.6 s) and stalls at ~28 s in a 3-worker suite. In its sampled profile,
    evaluation (`term`) is 34% of busy time. The rest is overhead:
    - the terminal-flow reducer loop, 12.7%;
    - JSON emission and the HUD/file log, ~15%;
    - SHA-256 digests, 9%;
    - work-ledger counts and credit decisions, ~10%;
    - `DiagnosticClassifier`, 6%.

    Changed:
    - `SemanticWorkLedger` keeps `admittedCount`/`receiptCount`: F#'s `Map.Count` walks the tree, and
      every JP worker dequeue read it through `jpTryReserveObserverLane`.
    - Credit decisions are memoized per (immutable) ledger instance (`ConditionalWeakTable`). Each one had
      listed the open units, joined their names and hashed the text, and many observers asked between two
      mutations.
    - `DiagnosticClassifier.classifyFacts` is memoized by text. The replay driver classified the same
      reason strings on every pinned terminal cell, ~70 substring searches each.
    - `SPIRAL_DIAG_QUIET=1`, which `scripts/test.ps1` sets unless the caller did, turns off the pure
      diagnostic outputs. These are the `DiagJson.emit` rows (17% inclusive), the advanced console
      projections, and the live work-ledger heartbeat and projection-suite emissions. The last two still
      run their state observation. Durable terminal receipts, errors and results are unaffected. Direct
      compiles keep everything. Correction (fix 39): `emit`'s row filter also keeps the per-kind counters
      that `DiagJson.snapshotKindCount` feeds to ~150 replay/join retry decisions. The first quiet mode
      skipped it, so quiet and full runs could choose different paths. Quiet `emit` now still runs
      `shouldEmitJsonLine` on the raw row and drops only the envelope, enrichment and write.
36. **The two slow mega roots, profiled alone** (after fix 35, `SPIRAL_DIAG_QUIET=1`).
    `mega_lean_cic_bottom_up_kernel` takes 33 s alone, but 77-178 s in a suite. The 3-5x slowdown under
    load is beyond fair CPU sharing, so oversubscription is a suspect: every compile runs its own full
    Hopac worker pool. `mega_spiral_proves_spiral_relative_consistency` takes 151 s even alone. Changed:
    - `EvaluatorProducerRecord` is `[<ReferenceEquality>]`: 22.8% of lean_cic's CPU. The producer
      graph's `ConcurrentDictionary.AddOrUpdate` compare-and-swaps the prior value with
      `EqualityComparer.Default`, which compared records structurally, deep into boxed
      `Data`/`Ty`/`LangEnv` artifacts, on every replay registration. Each update mints a new record with a
      new revision, so content equality meant nothing.
    - `SemanticWorkCreditOutstanding` builds its open work-unit list and digest on first read, and so
      does the ledger snapshot's open-unit texts: ~36% of spiral_proves' CPU. With thousands of open
      units every credit decision mapped them all (`openWorkUnits`, 21%), joined their names and hashed
      the text, and most deciders only look at returned/outstanding.
    - `BuildFile` setup exceptions (`file_build`) now reach the host as a fatal instead of vanishing
      into the stall budget.
37. **spiral_proves after fix 36** (143 s alone, was 151 s). The credit digest was still forced on
    every call by `terminalFlowTerminationCreditDecisionFor` (the closed-world promotion gate and the
    fairness advance). It digested thousands of open units, ~44% of CPU with the text formatting. That
    function only needs the digest and the ledger snapshot when credit is returned, so both are lazy
    there now. In quiet mode, three more pure-telemetry costs are skipped:
    - the heartbeat thread polled in 1-5 ms sleeps (~7% busy); it now waits in 25 ms steps, with the
      same 250 ms cadence and ledger heartbeat;
    - the HUD ticker painted frames to a redirected stream;
    - the parent-cache handoff wake built proof-tuple JSON fields (4%) for a row that is dropped.

    Measured on the fix-36 build, mega suite with 3 workers: `SPIRAL_HOPAC_WORKERS=3` did not beat the
    default of one worker per core (lean_cic 178 s vs 139 s, same wall time). `lean_cic` is slow in the
    suite because it shares the CPU with the omniledger and spiral_proves roots, not because of
    scheduler oversubscription.
57. **Warm processes (one hopac process, many BuildFiles) — experiment, not the default yet.** AGENTS.md said
    the core serves one BuildFile per process; it serves several. The host's `--batch` already runs jobs one
    after another: four frontier fixtures in one process were byte-identical to single-flight, 2.7 s for the
    first and 0.2-0.6 s for the next (fresh processes: ~4-5 s each, mostly re-parsing the core library).
    `test.ps1 -Mode hopac -Suite all -Native -FreshProcess:$false`: compiled in 186 s instead of 2,295 s (12x),
    1,054 of 1,089 rows unchanged (`runs/hopac-20261001-132627`). What leaks between builds, and the state of
    each:
    - a request the host stopped waiting for (it returns on the first type error) stays pending, and its
      budget watchdog later published `BuildFile stalled ... for <that file>` into another file's build. Each
      request now has an ordinal and a watchdog publishes only while its request is the newest. (Completing
      the stale request instead made things worse: see the next item.);
    - the terminal-failure latch (`DiagJson.TerminalFailureExitLatch`, open -> requested -> committed) is
      process-wide by design: once a build requested a terminal failure, every later build's join point
      workers cancelled at their first operation (`JpTerminalFailureRunningCutoverCancellation`, 77 rows in
      `runs/hopac-20261001-135049`). Reset per BuildFile now unless the exit is committed (unverified);
    - the generation's invalidation count is cumulative and the sequential flag sticky: the write guard now
      counts only this build's invalidations, and the flag and the recovery state reset per build;
    - resetting the evaluation stores per build (the in-process restart's set) did not help and is not done.
    With the replay driver marked as replay code (fix 56's general form) the warm runs lose ~75 rows to
    `JpTerminalFailureRunningCutoverCancellation` even with the latch reset per build (`runs/hopac-20261001-
    145411`): the latch is set *during* the next build. Its only requester is the JP work hard-deadline
    watchdog (`TypedDiagJpWorkUnitHardDeadline...`, "expired progress lease ... mark process failure latch"):
    work left by a build the host gave up on keeps its deadline and expires inside a later build. The fresh
    suite is unaffected (`runs/hopac-20261001-140839`: parity). Tagging each work timing with its BuildFile
    request and retiring earlier requests' items quietly did not help (101 rows, `runs/hopac-20261001-
    155...`; reverted): the current build's own join point work also reaches its deadline, presumably blocked
    on cells or caches an earlier build left. So warm serving needs a per-build session for the JP machinery
    as a whole (work items, cells, caches, deadlines, the latch), not more point resets. Until then
    `-FreshProcess` stays on for hopac.
56. **The type-aware op replay ran unmarked as replay code (a duplicated statement).** After the morning's
    speedups, `native_closure_recursive_capture` [C, Rust] came out with `inl ~leaf = Leaf` boxed twice (a
    dead `Rc::new(UH0::UH0_0)` after the `Node`), most runs, even with one Hopac worker; slower runs (loud,
    or a loaded machine) usually missed it. `SPIRAL_DEBUG_PUSH=TyUnionBox` (new: prints every appended
    statement whose rendering starts with the text, its block and managed stack) showed the same box appended
    to the main block by two threads: the direct evaluator, and the replay driver
    (`forceReplayDriverDrainPassTagged` -> `runReplayDriver` -> `tryScheduleTypeAwareOpReplayWithContext` ->
    the `scheduleDyn` thunk -> `dyn`). Fix 41's guard (`replayEmitRefused`) refuses replay code that appends to
    a block the direct evaluator owns, but it only knows replay code by the thread's replay depth, and this
    entry point, unlike `tryTerm` and the apply replays, never called `enterReplay`. It does now (fails closed
    on refusal, inside its existing handler); 8/8 runs match single-flight, and `dynamic_array_nested`,
    `dynamic_array_union_nested` and this fixture are byte-identical to the oracle 5/5.

    Also: inline-JP mode's silent rows (3 contracts, `mega_lean_cic`) were the write loop restating the write
    guard without the precheck's recovery exclusion, so every recovery run passed the precheck and was refused
    at the write. Both now use one `ArtifactWriteDecision` (stable: written; unstable: only a replay-stable
    refresh of an existing output); the four compile, the contracts identical to single-flight.
55. **Declared-body snapshot pruning was quadratic (apps/spiral in the default async mode).** Attempt 14
    reached `main`'s return, then one JP work unit ground at under one core in
    `jpPruneUnreachableDeclaredResumeSnapshotsForJob`. Each prune scans every snapshot of every job (plus the
    global root tables), and it ran every 256 continuations, and every 64 once the global count passed
    1,024. With most snapshots still reachable, a prune freed little and the next full scan came 64
    continuations later: O(live x continuations). The trigger is now geometric (prune when the live count has
    doubled since the last prune left it, floor 1,024): amortised linear, memory within 2x the reachable set.

    **Result: hopac's default (async) mode compiles apps/spiral** — partial evaluation and codegen in 555 s
    (888 s on a loaded machine; attempts 16-18), the same 2,687,696-byte `spiral.fsx` on two runs, 0 errors
    when type-checked as .NET F#. Inline-JP mode: 879 s, 2,686,539 bytes. Single-flight: 2,791,987 bytes
    (hopac's ~104 KB smaller output is task 37). The write was still refused, which led to:
    - **watchdog misfire.** One join point body evaluated for 2 minutes; the JP watchdog only counted slice
      progress and terminal admissions as progress, so it called that a stall (`EJP0030`, progress age 90 s),
      invalidated the generation and requested sequential mode, a "cooperative abort so the outer retry can
      recover" — but the native-authority cutover forbids that retry. The run finished anyway, and the write
      guard then refused output from an "unstable" run (`seq=1 inv=1`). The watchdog now also counts
      evaluation steps (`EvalProgress.steps`, one increment per `EvalCycleGuard.enter`): only waiting with
      nothing evaluating is a stall; runaway evaluation is the `EJP0040` guard's and the build deadline's;
    - **write guard read the old file.** A stable run was refused when its output shrank against whatever file
      was on disk (`tiny`/`shrinkHard`: old > 2,048 B and new < 2,048 B, or a shrink of >= 8 KB). That made
      the result depend on the previous output: inline mode's correct unrolled `frontier_static_list_eq` C
      (542 B, single-flight's loop is 2,640 B) failed `WRITE_ABORT`. Size checks now apply only to unstable
      runs. A refused write says why in the `FatalError` (`= note: not written: spiral.fsx (2687696 bytes):
      the run was unstable (... reasons: [gen=1] jp_watchdog EJP0030 ...); kept at
      %TEMP%/spiral-rejected/spiral.fsx`), so a quiet run's output can still be checked.

    Diagnostics in the same batch:
    - a runaway inline recursion now gets a rustc-style report in both cores (`RunawayUnrollDiagnostic`,
      the same module in each core's section): `error[EJP0040]`, `-->` span with the source line and a caret,
      the repeating cycle with counts, the entry path, why (inline recursion on a runtime value) and the fix
      (join point, or a static bound). Both cores count dynamic-`if` nesting (`SPIRAL_IF_NESTING_LIMIT`,
      default 1,000). Single-flight's guard was broken (its counter was local to `term`, so a new one per
      call); hopac's depth lives in `LangEnv.dynamicIfDepth`, because a declared application suspends and
      resumes as a new work unit, so nothing on the thread survives a level. `EJP0040` is registered in
      `DiagnosticClassifier` as terminal (never retried). Hopac's `EJP0011` messages carry the same report.
      The default was 5,000 at first: single-flight then took 12 s on the fixture (the runtime scanning a
      10,000-frame stack on every GC; 3.7 s at 1,000) and timed out under suite load. apps/spiral compiles at
      1,000 with byte-identical output;
    - hopac reached the limit slowly: 50 levels 5.7 s, 200 9.6 s, 800 78 s (quadratic). Profile of the
      evaluator thread: ~25% building proof-tuple JSON for diagnostic rows that quiet mode drops
      (`forceReplayDriverDrainPassTagged` -> `pendingGraphProofTupleJsonFields`, and the replay tick's
      `classifyFacts` over both texts), ~15% rendering terminal-contract rows once the global term-cycle fuse
      has tripped, both now skipped when quiet; `EvalCycleGuard.nodeCount` filtered the whole path into a new
      list on every node entry, and a leaf re-entered after its exit always scanned all of it (now an identity
      map on the path, O(log depth)). 800 levels: 78 s -> 18 s; 1,000: 19.7 s, linear at ~15 ms a level, still
      over hopac's frontier deadline (task: per-application overhead);
    - general per-node costs found on the way (none changes a result): `InternedTextIdOps.intern` hashed
      `ContentDigest.ofText` on every call, inside the global intern lock, though the digest is a function of
      (kind, text) — now once per slot (~15% of the evaluator thread; sites and shapes are interned on every
      node entry); the visit ledger compacted the evaluation trace (up to 4,096 frames) on every visit for a
      row it emits once per bucket — now only for an emitted row or a trip; the producer graph compared each
      node's dependency path structurally on every re-registration — `evaluatorDependencyAppendUniquePath`
      returns the prior path itself when it adds nothing, so identity now answers (this was the hottest frame
      of apps/spiral's evaluator); quiet runs beat the progress metronome at 1 s instead of 250 ms (each beat
      ~65 ms of CPU: a quarter core on a mega root, the busiest thread of the process);
    - **race 34, the variable-numbering face**: under suite load, 10 `dynamic_array_*nested*` rows came out
      with one variable number skipped (`v4` missing, 592 vs 590 B), rows identical in the three runs before;
      standalone the same DLL matched the oracle 5/5. Replay code may not append to a block the direct
      evaluator owns (`replayEmitRefused`, fix 41), but `ty_to_data` and the dynamic-join replay placeholder
      drew from that block's variable counter before any such check, so a refused replay still used up a
      number. Both draws now refuse first (fail closed, as `push_typedop` does). Under load (two mega compiles
      in the background) `dynamic_array_nested` gave 10/10 oracle outputs;
    - the host renders a `TracedError` as `TracedError: <message>` and the trace frames indented below it (it
      printed the F# record with `%A`: quotes, escaped newlines, `trace = [...]`), so a report reaches the
      terminal as written; `EJP0040` is raised without trace or `Compiler: par` envelope in both cores (the
      report carries the cycle and the entry path), so both print the same report;
    - hopac no longer prints the 50-row `[spiral_hud_final]` block to stderr in quiet mode;
    - incomplete artifact persistence now sends a `FatalError` with the reason (it filled `res None` alone:
      "no code and no diagnostic arrived");
    - recovery state is typed (`PevalStallProbe.PevalRecoveryState`, cause carried into the stall message
      as `recovery=entered(...)`).
54. **`VarIs` called every static union a variable (apps/spiral's last hopac-only wall).** Hopac's
    `EOp(VarIs)` descended into unions and pairs and answered true for any `DSymbol`, which every union case
    name is. So `real_core.spir`'s structural `=` (`if heap_union_is a && var_is a && var_is b then
    (join body()) : bool else body()`) took the `join` branch on static lists and emitted a runtime call
    for `[ ' '; '/' ] = []` instead of folding it to `false`. `sm'.trim_end`'s
    `if chars = [] then trim_chars () else chars` then made a static `chars` runtime, and
    `sm'.char_contains` → `listm'.exists'` → `try_item` unrolled forever (`EJP0011`, 1,025 re-entries;
    `samples/frontier_static_list_eq`). The rule is now the language's (single-flight's): `DV` or
    `DNominal(DV, _)`, plus a join-point placeholder (top level or under its nominal), which stands for a
    pending runtime value. The old descent was a migration-era guard against placeholder pattern misses,
    which fixes 44-53 handle now. Fixture: 7.3 s, 1,029 bytes (single-flight's size); the bare equality
    folds to `0` as in single-flight.
53. **Recovery entered midway restarts peval inline from scratch.** Fixes 44-52 patched the evaluation
    that entered recovery in place, and each patch exposed the next leftover of its asynchronous phase:
    orphaned cells built on placeholders, then (after fix 45's clear-and-rerun) closures whose owner table
    was gone at codegen (attempts 8, 9), then replay frames pinned as terminal that abort the final
    `jp_wait` (`dynamic_join_apply_blocked`, `replay_child_schedule_repeat_blocked`; fix 52's reset did
    not hold, the driver re-pins while draining). Now `evalOnBigStack` records whether this peval started
    in recovery; if recovery was entered during it, the root raises `PevalInlineRestart` (on success and on
    a root pattern-miss escape). The hopac `build_many` call site catches it, resets
    `EvalReplayValueStore` (`resetForFreshPeval`: the producer graph with every artifact projection,
    deferrals, parent handoffs, direct-scope tracking, replay apply caches), the worklist, terminal
    contracts, the cycle fuse and specialization caps, and runs a fresh peval: fresh tables, recovery on
    from the first step (methods `RecomputeSuspect`, closures inline), so nothing is spawned or orphaned.
    At most two restarts. `read_link`: exit 0 in 163 s, 187,528 bytes, 26 methods, 12 closures, no
    placeholder. Cost: a program that enters recovery is evaluated twice.
52. **(Superseded by 53.)** Cleared pinned terminal contracts after a recovered root value.
51. **The build-level retry is closed after the native authority cutover.** An `EJP0008` raised for
    orphaned cells came back as `NativeBuildBoundaryError(LegacyFallbackForbidden|reason=retry_after_
    native_authority_kernel|...)`: `attempt_build` surfaces retryable codes as typed failures by design.
    Hence fix 53's restart at the `peval` call site instead.
50. **Orphaned cells recomputed in place when their inputs allow it.** Attempt 8 (Release, fixes 44-48)
    failed after 762 s: `EJP0014 ... CODEGEN JP MISSING BODY DICT BLOCKED closure0 ... dict=0`, a closure
    whose owner had no body table at codegen, after fix 45's clear-and-rerun of `main` (state from the
    abandoned attempt can survive into the rerun). Each owned method/closure cell now registers an inline
    recompute (`jp_orphan_recompute`, keyed by the cell; methods share `recomputeInline` with the
    `RecomputeSuspect` path, closures register their `run`), and peval's root recomputes orphaned cells in
    place, round by round, before falling back to the clear-and-rerun. On `read_link` the orphan
    (`<anon>@sm'_real.spir:276`) pattern-misses again on every in-place recompute: its captured environment
    holds placeholder values from before recovery, so only a rerun of its parents fixes it, and the
    fallback does (exit 0, 187,564 bytes). The missing closure table of attempt 8 did not reproduce there.
    The clean general answer is a restart of the whole peval from a fresh generation once recovery starts;
    to do.
49. **A sub-package entry whose `main` fails to parse compiled its dependency's program (both cores).**
    The entry's `inl main` block failed to parse (a backtick type application in top-down code) and was
    dropped without a message; `BuildFile` then took the `main` that the entry's `open main` brought in
    from the dependency. Five mega brzozowski rows recorded that program as their oracle. Both cores now
    fail the build (`Cannot find main ...: the file does not define it, and it has errors`, then
    `path:line:col` per error) when the entry does not define `main` itself and has tokenizer or parser
    errors; hopac reads the bundles without blocking (fix 33). NEXT.md item 1 for the oracle side.

**apps/spiral attempt 7 (21:00, split Debug build, fixes 44-48): evaluation reached the root.** At 2,041 s
the heartbeat recorded `progress_pct=100`, `root_complete_receipts=1`, `terminal_signals=2`; then nothing
moved (5% CPU) and from 34 to 56 min the heartbeat requested a "no work" hard abort 49 times
(`compile_progress_plateau_abort`, `route_to_no_work_abort`) until the 60 min budget killed it. The
requests are observer-only by design (`forceProcessExitDirect` queues a request; the terminal reducer owns
the physical exit; only a stalled metronome or failed-closed deadman arms a physical failsafe), so the
real question is what is stuck after root completion: codegen, the writer, or the terminal protocol.
Next: attempt 8 on the Release monolith with a stack dump shortly after root completion.

48. **Visit budget tripped on legitimate recursion during inline recovery (apps/spiral attempt 6).**
    Attempt 6 (fixes 44-47, under a 99%-loaded machine) failed after 643 s with `EvalVisitBudgetFailure`.
    In forced-sequential mode a keyed term/type re-entry (`reKey > 1`: the same node key twice on the
    current evaluation path, i.e. recursion such as `run` → `루프` → `run`) seeds a replay prefetch and
    charges `EvalVisitLedger`, which counts a revisit as productive only if semantic facts, work receipts
    or the cell revision advanced. Inline recovery evaluates join points without work receipts, so
    ordinary recursion reads as unproductive and exhausts the budget. Placeholder recovery requests
    sequential mode, so it turned this replay heuristic on. Both prefetch guards (term and type) now skip
    while `PevalStallProbe.placeholderRecoveryEntered`; single-flight has no such guard either.
47. **Late completion after a generation was retired (apps/spiral, 36 min in).** Attempt 5 (fixes 44-45b)
    ran for 36 min and then failed with `FatalError: specialization completion requires registration`. A
    cache invalidation (`JpGenerationScopeCacheInvalidation`) retires every specialization registration up to
    its generation (`JpSpecializationWorklistAuthority.retireGeneration`) while work items of that generation
    can still be running; the first one to finish hit `invalidOp` in `prepareCompletion`. It now records the
    late completion (`jp_specialization_late_completion_after_generation_retired`) and completes.
46. **Codegen waits on a pending cell are bounded.** `requireResolvedMethodCell`/`...ClosureCell` blocked in
    `run (IVar.read ivar)` without limit, outside the build budget (fix 45's hang ran 28 min past a 120 s
    budget). They now wait `SPIRAL_CODEGEN_PENDING_CELL_WAIT_MS` (default 30,000) and then fail with
    `EJP0014: codegen JP body cell still pending ... (orphaned cell, no producer left): method<N> body=.. key=..`.
45. **Orphaned join-point cells: codegen waited forever (`read_link`).** Repro: a `main` matching on
    `file_system.read_link ".."` (`$CLAUDE_JOB_DIR/tmp/readlink_loud.ps1`; single-flight overflows the
    stack on it). Hopac finished partial evaluation, then `codegenFsharp` blocked in
    `run (IVar.read ivar)` (`CodegenJpMethodBodyCellPending`, no timeout, outside the build budget) on a
    cell nobody would fill: its work unit had pattern-missed before recovery started and was retired as a
    stable replay sentinel, and after recovery nothing called that key again (its parent's body was
    already complete). Fix:
    - after `main` returns, peval waits for JP quiescence and counts pending method and closure cells. If
      any remain, it marks a suspect (inline recovery), clears the JP specialization tables (method,
      closure, completed/pending memos, declared interfaces; `LoopSpecializationGuard.reset`) and reruns
      `main` (max 3 attempts in total, with the pattern-miss retry of fix 44);
    - in recovery mode closure bodies run inline too (they had no inline path: always spawned work, which
      could again be retired with its cell pending).

    The repro compiles (exit 0, 187,564 bytes, 26 methods, 12 closures, no placeholder in the output;
    114 s in loud mode). Codegen's unbounded wait on a pending cell is still there: next, fail closed
    with the key once the graph is quiescent, and bring codegen under the build budget.
44. **Matching on a join point's pending result (apps/spiral's stall).** The second and third attempts
    named the pending join points: 96 of them, 44 at `trace.spi:302` (the `join` around the trace line) and
    the rest in `listm`, `sm'_real.spir:276`, `parsing`. Reduced to two fixtures that fail only in hopac:
    - `frontier_format_any_union`: `"x: " ++#? Some 1i32` in `main` (FatalError
      `PatternMissBreakthroughEscapeTransport`);
    - `frontier_join_format_any`: the same inside a `join` (spins until the 60 s stasis cancel, then the
      build stalls). `env.spi:90`'s catch-all target branch does exactly this.

    Mechanism: `++#?` calls `format_real`, a top-level join point. Its first call claims the cell, spawns
    the body as JP work and returns a typed placeholder (`jp_method_synchronous_boundary_deferred`,
    "continue term evaluation then dereference placeholder"). The caller then matches on that placeholder
    (`.JPMethodUnknownRet(par)`), which can never succeed while the callee is pending. The pattern miss
    raises a requeue signal: in `main` nothing catches it (fatal); in a JP work unit the requeued body gets
    the same placeholder back and spins, and a nested `join ""` in `format_real` was retired as control-only
    work with its cell unfilled.

    Fix (5 parts, `jpPlaceholderPatternMissEntersRecovery`):
    - a pattern miss (or type-pattern miss) whose scrutinee mentions a JP placeholder marks a
      `SuspectCache` entry. That switches JP methods to the existing inline recompute paths (pending-cell
      bypass, `RecomputeSuspect`), which evaluate the callee directly as single-flight does, for the rest of
      the build;
    - shared pending cells are bypassed too while suspects are active (they still deferred to a
      placeholder);
    - both inline paths now publish their body as a ready cell (`IVar(JpMethodBodyCellReadyPayload ..)`):
      codegen reads JP method bodies from that table (`EJP0014 ... body cell not ready` otherwise);
    - `peval`'s root retries `main` (max 3) on the escape once recovery is on: it waits for JP quiescence,
      resets the worklist and the terminal contracts the abandoned attempt pinned
      (`EvalWorklist.resetTerminalContractsForRootRetry`), and reruns;
    - the sequential request that recovery makes is not "unstable" for the output write guard
      (`PevalStallProbe.placeholderRecoveryEntered`, reset per build); without this the result was
      computed and then refused (`WRITE_ABORT ... seq=1 unstable=true`).

    Both fixtures now compile in ~7 s, and the trace-state repro (`get_trace_state_or_init`, formerly 3
    pending join points and a stall) in 11 s. Cost: after the first placeholder miss the build evaluates
    join points inline, so a build that hits it loses hopac's parallelism for its remainder.

    apps/spiral, fourth attempt (16:48, 25 min): stalled with 2 pending join points instead of 96, both
    `run@file_system.spi:701` (`read_link`'s `run` join point, which takes the `let rec 루프` and is called
    back by it: mutual recursion across two join points). Next rung: a fixture for that shape.
43. **apps/spiral, first attempt (2026-09-30 14:24, fix-41 build).** Script: a scratch copy of
    `apps/spiral/spiral.spi` with an absolute `packageDir` (the compiler writes next to its source; the
    committed `spiral.fsx` stays untouched). Type checking passed and partial evaluation started. After
    ~17 min (1,550 CPU-s, 3.9 GB) CPU stopped advancing. A stack dump showed every thread idle: the
    evaluator's big-stack thread was in a synchronous `Hopac.run` waiting for a job that never completes;
    JP workers, the replay driver and the thread pool were all parked. That is a pending join-point
    specialization at a scale the fixtures don't reach. The stall message now also carries
    `peval={pending_join_points=N [names]}`: `peval` installs a probe over its `join_point_method` table
    (`PevalStallProbe`). Second attempt with a 25-min budget, to read which join points are pending.
42. **Parent-cache wake runs the replay driver off the evaluator thread.** The handoff wake ran
    `replayDriverCooperativeTickFromGlobalFuseId` inline on every value commit, including the direct
    evaluator's registrations: ~57% of `mega_spiral_proves`' evaluator thread. It now schedules one
    coalesced tick on a Hopac worker (a flag absorbs further wakes and is cleared before the tick runs). This
    is safe to run concurrently only because of fix 41's emit guard. Clean timings, alone:
    - `lean_cic` 27 → 22-23 s;
    - `spiral_proves` unchanged, 33-36 s;
    - `omniledger` unchanged, 20 s;
    - outputs identical to the clean baseline.

    The first measurement of this change (and fix 40's) ran with a build's GC settings still set; see
    fix 39. **Reverted:** the suite run of it (`hopac-20260930-134136`) had the same parity but two
    brzozowski rows (`compiler_probe_generic_matcher_state`, `minimization_witness`) failed with race 34's
    union-unbox type mismatch. That race used to hit about one row every few runs. Replay running
    concurrently with the direct evaluator widens the per-node store's overwrite window (fix 34), so this
    waits for a per-evaluation replay store.
41. **Replay duplicated calls under load (nondeterministic output).** About 20 residuals changed between
    two suite runs of the same build. Compiled alone, a churning fixture was stable (5/5). With three heavy
    compiles in the background, `dynamic_array_function_boundary` [C] produced
    `v1->refc++; int32_t v3; v3 = method0(v1, v2);` before `return method0(v1, v2);` in 1 of 6 runs. That is
    fix 23's duplicated application, a silent miscompile for effectful calls. The replay driver runs on a
    Hopac worker while the direct evaluator builds the block. The whole-spine thunks only checked
    `isDirectNodeOwned` on their own node, a check-then-act that loses to timing. They now also refuse
    while the target block is being built (`isDirectScopeActive (box s.seq)`), as
    `tryRunApplyAfterDefinitionAt` already did. The same load repro: 10/10 identical outputs.
    The next suite still produced the duplicate. The guard was then widened to blocks a direct
    evaluation ever built (a weak table), not only active ones, and that suite still produced it too.
    The duplicate came from another path: generic re-evaluation thunks.
    `EJoinPoint'`/`EUnbox`/`EAnnot`/`ENominal`/`EPatternMiss` registrations store
    `putTerm nodeId (fun () -> term s expr)`, and forcing one re-runs the whole expression into the captured
    block. The invariant is now enforced where statements are emitted. Replay code runs with a thread-local
    replay depth: thunks forced by `tryTermDetailed`, `tryApplyReplayDataWithContext` and
    `tryDynamicJoinApplyReplayDataWithContext`. Each block records the replay depth its direct evaluation
    started at. `push_typedop` and `push_typedop_no_rewrite` refuse (`replay_emit_into_direct_block`, fail
    closed) to append to a block started at a shallower depth than the current replay. A join-point body
    that a replay evaluates in a fresh block is started at the replay's depth, so it stays allowed.
    Result: the fixture is clean in suite runs. Two suites of the same build (`hopac-20260930-114913`,
    `-122633`) differ in 14 residuals (was 20-23 between runs); all `dynamic_array*` rows are stable now.
    What remains:
    - 11 brzozowski sub-packages differ only in variable numbering, even compiled alone (`v21`/`v19`).
      Ids come from the shared counter `s.i`, and replay work that is later refused or abandoned
      consumes ids. That is benign; making it byte-deterministic needs canonical renumbering per method
      before codegen.
    - `native_closure_recursive_capture` [C, Rust] and `native_float_pow_pi` [C] vary only under suite
      load (8/8 identical under synthetic load, 3/3 alone). Their native results agree in both suites.
39. **Digests and per-term bookkeeping (2026-09-30).** Profiled with `scripts/probe.ps1 -Profile`. Changed:
    - `ContentDigest.ofText` (every work unit, receipt and minted ref) used SHA-256 over UTF-8, with
      string concatenations and a memo whose key hashing cost as much. It was the top self-time frame, at
      19-25% of `mega_lean_cic`. It is now a fast non-cryptographic 256-bit hash (four seeded 64-bit
      lanes, MurmurHash3 `fmix64` finish), same 64-hex-digit format. The digests only identify things
      within one compile. `ContentDigest.hash64`/`hex256` replace SHA-256 in the other hot identity
      refs: `NonZeroRef.digestCandidate`, `terminalFlowLegacyMintedRefOf`, `durableJsonLineRef`. The SHA-1
      short names that may reach generated code are unchanged.
    - Replay task work units are memoized per (task id, key). Admit, open check and completion each
      rebuilt one.
    - Credit decisions are decided from counts plus an O(1) emptiness check, and list open keys lazily.
    - `EvalStackDepthGuard` keeps plain string keys with a count map. Each term evaluation had
      interned its key and scanned the whole key path.
    - Quiet runs keep no JSONL file mirror. Its writes and `Flush(true)` were ~4%.

    - Second round, same fix:
      - `jsonStringFieldByName`/`jsonHasField` use `IndexOf`: `Split` copied the rest of the row per
        field read.
      - The row classifications (`jsonTelemetryDetailForKind`, `jsonTelemetryTextSignals`) are memoized
        per kind text.
      - `nativePromiseFailureClosedNow` reads the latch before the clock and without the tick lock.
      - `NativeCutoverStableRef` uses the fast hash.
      - Node keys are built by concatenation.

    Alone, before → after: `mega_lean_cic` 46-63 → 20-28 s; `mega_spiral_proves` 80 → 33-38 s (151 s before
    fix 36). Suite compile phase 2,142 → 2,001 s with identical parity. Hopac's times vary a lot between
    identical runs (omniledger 26-51 s), and so does its output: ~20 residuals differ between two runs of
    one build. So compare repeated probes, not single runs.

    Where a large compile's main thread goes now (`scripts/profile-thread.py`, busiest thread, inclusive):
    - `registerReplayTermWithContext` ~50%: registering replay thunks for each evaluated term;
    - about 21% of that is replay-driver ticks that `putTermValue`'s parent-cache handoff runs inline;
    - the replay driver itself (`runReplayDriver`) 19%;
    - type evaluation (`ty`) 15%.

    **Tried and reverted (fix 40 attempt):** registration-time `putTermValue`/`putTypeValue` without the
    handoff wake made `lean_cic` slower (27 → 43 s) and changed `omniledger`'s output. **That measurement is
    invalid:** the probes ran in a shell that had `DOTNET_gcServer=0` and `DOTNET_GCConserveMemory=9` set for
    the preceding core build, and a compiler inheriting them is 2-4x slower. `build.ps1` now sets them for
    its own build only. Fix 40 deserves a clean re-test. Those wakes drive
    replay progress, so replay is load-bearing even while the direct evaluator runs. The remaining cost
    is in the replay design itself (per-task ledger transactions on immutable maps, pinned-cell
    bookkeeping, re-registration of subtrees), not in telemetry.
38. **Resolved 2026-09-30: diagnostics lost between the core and the host (`typecheck_await_scheduled`
    stalls).** Root cause, in both cores' `new_server`: the client error stream was
    `AsyncSeq.unfoldAsync` over `event.Publish |> Async.AwaitEvent`. `AwaitEvent` subscribes for one event
    and unsubscribes, so any diagnostic raised before the host pulled the next element was dropped.
    After a burst of parser errors that was often the `FatalError`, and the host then waited for a result
    that had already been sent. It is an unbounded `System.Threading.Channels` queue now. The stall message
    also carries a diagnostics ledger and the type-check probe (AGENTS.md, "The loop"). The investigation
    that led there:
    Up to four Up to four
    brzozowski `negative_*` sub-packages stall at 28 s in suite runs. Their oracle rows are rejections,
    so they count as parity, but they cost the full budget. `negative_antimirov_slot_shape` is the
    reproducer. Alone, it sometimes answers in 3 s with single-flight's own errors ("Unbound type
    variable: antimirov_origin_slot", a fixture quirk: parity) and sometimes stalls. Both happened with
    `DOTNET_ThreadPool_ForceMinWorkerThreads=64`, so a larger thread pool is not the fix (a host
    `SetMinThreads` floor was tried and reverted). Run through `Start-Process` with redirected output,
    3 of 3 answered; run through a PowerShell pipe, most stalled. In stalled runs even the
    `SPIRAL_DEBUG_TYPECHECK_WAIT` watchdog (a `Task.Delay` continuation) never prints, and the
    `file_build` setup guard reports no exception. So thread-pool threads are blocked, or the
    process's stderr writes block.

    Later the same day, with the compile run under a PowerShell pipe (3 of 3 stalled):
    - A `dotnet-stack` dump 12 s in shows **every thread idle**: Hopac workers in `Scheduler.UnsafeWait`,
      thread-pool workers parked, main in `compileOne` waiting for the build result. So it is neither
      starvation nor blocked console writes: something the host waits on is never signalled.
    - The watchdog also appends to `%TEMP%\spiral-typecheck-wait-<pid>.txt` now, since its stderr lines
      never showed. At 6 s it wrote `entry input=true output=true`: **type checking finished**, and the
      build had taken the error branch, which sends the fatal (`Ch.send errors.fatal`) and emits no
      further stage. That is why `last_stage` stays `typecheck_await_scheduled`.
    - With `SPIRAL_HOST_TRACE_DIAGNOSTICS=1` the same run answered: a burst of `ParserErrors` and
      `PackageErrors` diagnostics, then `FatalError`, then the host's "type error somewhere in its path".

    So the lost signal is between the core's `errors.fatal` send and the host's `DiagnosticRouter`
    (`startDiagnosticPump`, `Accept`, the `fatalGraceMs` continuation and `TrySetResult`). Suspects: the
    fatal handled while no build is `active`, or the pump behind on the parser-error burst when the build
    task wins. A strong candidate: `fatal` is `start (Ch.send errors.fatal x)`, a rendezvous that completes
    only when a receiver takes it. If the core's merge of the error channels is itself blocked handing an
    earlier diagnostic of the burst to the host's `AsyncSeq` pump, every Hopac worker just waits: the
    all-idle dump. Check where `errors.fatal` is consumed and whether the host pump can stop pulling. Next: log each `Accept` with the router's `active` state to a temp file (the trace changes
    timing), or make the core's fatal also fill the BuildFile result IVar with `None`, which the host
    already turns into a waited-for diagnostic.
29. **Triple-quoted strings broke block structure (`Failed to parse this token` in mega roots).**
    `mega_omniledger_erp_kernel` (110 `"""` strings) and `mega_spiral_proves_spiral_relative_consistency` (27)
    failed to parse far below their strings. Hopac's tokenizer gave every empty line inside an open `"""`
    string a `TokText "\n"` token at column 0, and the block splitter starts a new top-level block at a line
    whose first token is at column 0, cutting the enclosing definition in two. It also put each line's
    newline before the next line's text, which dropped the newline before the closing line. `string_triple_line`
    and `tokenize` now match single-flight's (hopac keeps its ordinal search for `"""`).

    Same batch, from a profile of `native_cube_frame_direct` (21 s alone; examples have a 15 s budget):
    idle join point workers rescanned every queue every 2 ms (the fail-safe timeout of a one-waiter
    `AutoResetEvent`), ~22% of the compile's CPU. The timeout is 20 ms now, and a worker that takes an item
    wakes the next while work remains. The hopac host turns off tier-0 PGO (one compile per process;
    `frontier_hello` 8.1 → 7.5 s). A `frontier_hello` compile spends ~3.6 s before `BuildFile` starts, ~2 s in
    partial evaluation and ~1.2 s after codegen (the two 500 ms grace periods).
28. **A nominal around a function could not be dyn'd (`Expected an annotated function into runtime data`).**
    `mega_brzozowski_derivatives/antimirov_typed_slot_bound`: `nominal cap alphabet = regex alphabet -> ...`
    built as `cap (fun left right => ..)`. Hopac's `dyn` rejected every `DNominal(DFunction ..)`;
    single-flight dyns the nominal's contents, closure-converting the annotated function. The special case
    is gone, and the fixture compiles (`"brzozowski-antimirov-typed-slot-bound-green"`).

    Same batch (one build): more of fix 26's profile, taken with stderr redirected as the harness runs it (no
    HUD): the ledger keeps running cost sums (`project`), a global open set (`openKeys`) and an unclassified
    counter (`unclassifiedOpenCount`, 7.6%); replay-tick proof fields are memoized per (event, reason) (their
    text classification was ~4%); `ContentDigest.ofText` uses the static `SHA256.HashData` and memoizes texts
    up to 512 chars (bounded), since telemetry digests the same short texts repeatedly (it was 11.8%). The host
    no longer fails an F# compile whose script ends in an expression (`method0(v0, v1)`, a literal): the
    entry binding is only a label, recorded as `(expression)`.
27. **Multi-package type-check "stalls" were an unreported rejection.** `BuildFile` now collects the typer's
    errors from every package before failing (both cores). With the current build the
    `native_source_package_prototype_*` fixtures fail in 6 s instead of hanging at
    `typecheck_await_scheduled`, and the error is visible: the nested package `shared` sees no `+.`/`=.`.
    Which change ended the hang is not pinned down (this and fix 26 landed in the same builds). Single-flight
    rejects these fixtures the same way (all their packages use `|core-`, the real core, which has no `+.`),
    and the oracle expects the rejection: hopac is at parity.
    `SPIRAL_DEBUG_TYPECHECK_WAIT=<seconds>` prints the unfilled type-check promises if a hang comes back.

    Stalls after fixes 22-25 (Debug build, direct compiles): `frontier_fib`,
    `native_string_utf8_grapheme_bounded_source` and `_canonical_equal_bounded_source` now match
    single-flight byte for byte; `native_cube_frame_direct`, `_terminal_stream_direct` and
    `_flush_delay_direct` compile (exit 42; up to variable numbering, hopac's C has one extra copy of a
    three-`double` tuple). `contract_dependently_verified_federation` compiles but takes 45 s (single-flight
    7 s, the contract timeout is 30 s); `contract_higher_rank_hot_swap` and
    `contract_public_byzantine_key_rotation` still exceed 40 s (single-flight 7-9 s).

    With fixes 22-24 (Debug build, direct compiles, C): both utf8 fixtures above, `native_string_utf8_validate_source`,
    `managed_string_codepoints`, `native_cube_direct`, `order_nojoin` and the two new fixtures (`native_replay_repeat_call`, `native_literal_join_args`) give
    C byte-identical to single-flight's, with the same exit codes.

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
  the token and returns `Error []`.

  **Resolved (2026-09-29): hopac is right, the oracle is wrong.** These files are top-down (`.spi`) and use
  `` f `t () `` in terms, which the parser rejects in top-down code (same parser text in both cores). Each
  sub-package's own module is `main` and it `open`s its dependency's module, also `main`. Single-flight,
  even in a fresh process, compiles such an entry file into the *dependency's* program: its output is the
  parent's `"brzozowski-kernel-ready"` (hash `82c913d798038335`), and 5 oracle rows record exactly that
  (`compiler_probe_generic_inventory_pack`, `generic_indexed_alphabet_authority`,
  `indexed_closure_certificate`, `indexed_dfa_probe`, `indexed_dfa_state_cardinality`). Hopac parses the
  sub-package's file and reports the genuine error; it only "passes" on the runs where it also resolves
  `main` to the dependency. Decision needed (not hopac work): fix the five fixtures (bottom-up `.spir`, or
  no backtick application), and make a failed entry module an error instead of a silent fallback to a
  same-named dependency module, then re-bless those rows.
- 9 closure failures inside branches (`native_closure_*branch*`) were a bare `NullReferenceException`.
  They now report `EJP0035: join point body cell (JpClosureBodyCellPayload) was never filled`. The
  producer's partial-step control exception takes the
  (Resolved by fix 25: the two closures shared one promise identity.) Old analysis: the
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
