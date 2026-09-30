# Hopac frontier

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
      compiles keep everything.
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
38. **Open: multi-package type checking races (`typecheck_await_scheduled` stalls).** Up to four
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
