# Working on the Spiral compiler

Rules for humans and LLM sessions (browser sandbox or local Windows) that change the compiler.

## Two lanes, one harness

| | single-flight | hopac |
|---|---|---|
| What it is | the compiler that works today: sequential evaluator, F#/C/Rust/Delphi | the parallel Hopac evaluator: every oracle row of `-Suite all` reproduced (2026-10-01 20:19), 10-30x slower than single-flight on the mega roots |
| Source of truth | `apps/compiler/spiral_compiler.fs`: shared sections, and the `#else` side of each section pair | the same file: the `#if SPIRAL_CORE_HOPAC` side of each section pair |
| Role in tests | **oracle**: its results are `<cache>/baseline/EXPECTED.tsv` (`-Bless`) | **candidate**: scored by how much of the oracle it reproduces |
| Known wall | `apps/spiral` overflowed the stack until 2026-09-30: commit 1eb2ecf had dropped the 1.5 GB thread `peval` runs on (restored; NEXT.md) | speed (~15 ms per inline application; the core library re-parsed by every fresh process) and race 34's general fix (a per-evaluation replay store). `apps/spiral` compiles since 2026-10-01 (359 s, 0 type errors, the same 874 methods/closures as single-flight; FRONTIER.md fixes 55, 58). Single-flight's features since the shared base `12f52a1` are ported. |
| Scoreboard | `<cache>/scoreboards/single-flight.tsv` | `<cache>/scoreboards/hopac.tsv` (`-Record`) |

Switching lanes is only a build/test argument: `-Mode single-flight` or `-Mode hopac`. Both binaries
live side by side in the cache, so the same fixture can be compared across modes in seconds.

## The loop

**Iterate on the split build** (`scripts/gear-dev.ps1`, lanes/splitter/README.md): it rebuilds only the
gears an edit touched (1 of 144 for a `peval` edit; under 2 min on a quiet machine, emit included) and runs
from its own directory, so it works while a suite holds the monolith's DLL. Keep the monolith
(`build.ps1`, Release) for timing measurements and the final suite runs: the gears are a Debug build
(~1.5x slower to run). After many edits, or when gear-dev says the anchored plan collapsed (exit 3), run
`gear-dev -Full` once (~25-60 min, one-off).

```powershell
pwsh scripts/gear-dev.ps1                                 # core edit: rebuilds the touched gears
$env:SPIRAL_COMPILER_DLL = "<cache>/gear-dev/hopac/host/.out/bin/Debug/net11.0/SpiralCompiler.dll"
pwsh scripts/probe.ps1 <sample>                           # probe/test/apps runs use that DLL while it is set
pwsh scripts/build.ps1 -Mode hopac                        # the Release monolith: timings, final suites (~3.5-5 min)
pwsh scripts/test.ps1 -Mode hopac -Suite frontier         # seconds per fixture, low timeouts
pwsh scripts/test.ps1 -Mode hopac -Suite frontier,smoke   # widen once the frontier is green
pwsh scripts/test.ps1 -Mode hopac -Suite all -Record      # full scoreboard, written to lanes/hopac/
```

For one fixture, skip the suite: `pwsh scripts/probe.ps1 <sample> [-Mode single-flight] [-Backend C]`
compiles `samples/<sample>` directly and prints exit code, time and the first result line per run.
- `-Repeat 5` exposes races: the outcomes line flags runs that differ.
- `-Stacks 12` takes a `dotnet-stack` dump if the compiler is still running after 12 s: hangs.
- `-Profile 40` records a 40 s sampled-thread profile and prints its hottest frames: slowness. For the
  evaluator's own thread, `python scripts/profile-thread.py <run.speedscope.json> [threads] [rows]` prints
  inclusive time per frame on the busiest thread(s).

Logs go to `<cache>/probes/<sample>/`. A stalled hopac build now reports, in its `BuildFile stalled`
message, the diagnostics sent and delivered during the build (`diagnostics={fatal_sent=..,delivered_..}`)
and the entry's type-check promises (`typecheck={entry_input=.. entry_output=..}`). A stall after
`fatal_sent`, or with type checking done, is a lost result, not slow evaluation.

`-Parallel` defaults to what the machine can take: about 3/8 of the logical CPUs in hopac mode (a hopac job
keeps 2-3 cores busy), half in single-flight, both capped at one worker per 1.5 GB of free memory. On an
8-CPU machine a hopac `examples,contracts -Native` run takes 3 workers; don't drop to 1 unless memory is
short.

Compile statuses: `ok` (returned code), `emitted` (the core wrote the residual during the run but the
compile never returned; the expected next Hopac milestone after the current hangs), `error`, `timeout`,
`crash`. Baseline verdicts: `parity`, `emitted-parity`, `*-residual-differs`, `FIXED` (oracle had no
result, this run produced one), `no-oracle` (neither did), `missing` (hopac) / `REGRESSED` (single-flight)
when an expected result or an expected rejection is not reproduced, `UNEXPECTED-OUTPUT` (code for a
program the oracle rejects), `NATIVE-DIFF`. A hang or crash never matches an expected rejection.

Timeouts are deliberately small (frontier/examples/smoke 20 s, contracts 30 s, mega 180 s): once the
core library is warm, a small sample compiles in well under a second in single-flight, so anything slower
is a hang. A fresh hopac process needs ~5-7 s for a frontier fixture (up to ~11 s under parallel load,
hence 20 s rather than 15), and the host gives the core a deadline 3 s before the job timeout, after
which the core reports `BuildFile stalled: ... last_stage=<stage>` instead of hanging. The harness scores that
report as a `timeout` (with the stall message as its detail), so it never matches an expected rejection.
Override with `-TimeoutSec` only for deliberate profiling.

Hopac knobs (environment): `SPIRAL_HOPAC_WORKERS` and `SPIRAL_DOP` (set both to 1 for deterministic
runs), `SPIRAL_BUILD_DEADLINE_MS` / `SPIRAL_BUILD_BUDGET_MS` (stall watchdog; the host sets the deadline,
otherwise 15 min), `SPIRAL_LEGACY_JOIN_HEURISTICS=1` (old EJP0019/EJP0021 join loop),
`SPIRAL_DEBUG_UNBOX=1` (trace union unboxes), `SPIRAL_ARTIFACT_COMMIT_GRACE_MS` (20),
`SPIRAL_RUN_END_GRACE_MS` (20), `SPIRAL_CODEGEN_STACK_MB` (512), `SPIRAL_JP_SLICE_OPS=<max>,<interval>`
(time-slice declared method bodies again, e.g. `256,64`; off by default because resuming a slice is
unsound, FRONTIER.md fix 22), `SPIRAL_DIAG_QUIET=1` (skip the diagnostic JSONL rows and console projections, ~20% of a compile;
`scripts/test.ps1` sets it unless already set, so set `0` to keep them in a suite run; it also sets `DOTNET_GCgen0size=0x10000000`, a 256 MB gen0 budget: deep evaluation stacks make every gen0 collection costly),
`SPIRAL_DEBUG_TYPECHECK_WAIT=<seconds>` (if type checking is still pending
after that long, print every package's unfilled type-check promises to stderr),
`SPIRAL_HOPAC_INLINE_JP=1` (evaluate join points inline from the start; builds apps/spiral too),
`SPIRAL_DEBUG_PUSH=<text>` (print every statement partial evaluation appends whose rendering starts with the
text, e.g. `TyUnionBox`, with its block and managed stack: finds which path emitted a duplicated statement). Debugging workflow: `lanes/hopac/FRONTIER.md`, "The fast loop".

Both cores: `SPIRAL_IF_NESTING_LIMIT=<n>` (default 1,000): dynamic `if` branches nested on one evaluation
path before partial evaluation stops with `error[EJP0040]`, a rustc-style report of the runaway inline
recursion (span, repeating cycle, entry path, the join-point fix). A quiet build whose output the hopac write
guard refuses says why in its `FatalError` and keeps the text in `%TEMP%/spiral-rejected/`.

In hopac mode a worker serves jobs from one warm compiler process and recycles it after a failure
(`-WarmRecycle`, the default there since 2026-10-08). Some per-build join point state still leaks into the
next build (FRONTIER.md fix 57), and it only ever shows up as a failure: an error or timeout in a process that
already served a build is not recorded, the host exits 4 and the job runs again first in a fresh process, whose
verdict counts. `-Suite all` on one DLL: 782 s vs 1,834 s with a fresh process per job, all 2,014 rows identical
(status, residual hash, verdict); 106 of the 605 deferred failures succeeded fresh. `-FreshProcess` restores a
process per job; `-FreshProcess:$false` keeps one process without recycling (~12x faster, ~100 contaminated rows).

## Advancing the hopac lane

Stop running the full `apps/spiral` build to measure progress: it takes dozens of minutes and reports
one edge case at a time. Climb this ladder instead, and only move up when the rung is green:

1. `samples/frontier_hello` — one runtime value. Must return (not just emit) and exit.
2. `samples/frontier_fib` — `let rec` join point recursion.
3. `samples/frontier_try_item` — verbatim `listm'.try_item`, the site of the `3006.jsonl` failure
   (`PartEvalTypeError … Got: ? … Compiler: par`, `EvalReplayTyReturn (YMetavar …)`).
4. `-Suite smoke`, then `-Suite examples` (all backend fixtures, including Rust/Delphi through C).
5. `-Suite contracts`, then `-Suite mega`.
6. Only then the full `apps/spiral` build (see `lanes/hopac/README.md`).

When a larger sample fails, cut the smallest reproduction into a new `samples/frontier_<name>` fixture
(`packages: |core-` gives the standard library) and fix that. `lanes/hopac/FRONTIER.md` is the current
status; update it with the scoreboard in the same change.

Prefer fixing root causes over adding telemetry: the Hopac core already emits ~20 k diagnostic rows per
run. A change that adds projections, ledgers or HUD lanes without moving a fixture is not progress.

## Advancing the single-flight lane

Backend work happens in the core's own generators (`codegenRust`, `codegenDelphi`, next to
`codegenFsharp`/`CodegenC` in `apps/compiler/spiral_compiler.fs`; no backend is translated from another's
output) and is proven by
`pwsh scripts/test.ps1 -Suite examples -Native`: C is the semantic oracle, Rust and Delphi must match its
exit code and stdout (`oracle` column). Add a fixture under `samples/<name>` for any new construct and
commit the outputs the compiler writes next to it. Changes to the single-flight core must keep `-Suite all -Native` free of `REGRESSED`,
`NATIVE-DIFF` and `DISAGREE`, then refresh the oracle with `-Bless`.

`!!!!BackendSwitch` evaluates every arm, in key order, on every backend, in both cores. The current backend's arm produces the value; every other arm is evaluated only for its type, which must equal the current arm's, so a mismatch is a compile error on every backend (the cross-target check Kotlin Multiplatform does for `expect`/`actual`) and compile-time state (hash maps the arms touch) is the same whichever backend is built. That validation is hermetic: it pushes into a throwaway statement list and allocates variables from its own counter starting at 1 <<< 30 (`backend_switch_validation_tags`), so no tag it uses can reach the residual (a `v1073741824` in an output would be a leak) and a backend's residual numbering does not depend on the other backends' arms. Each (backend, arm closure) pair is validated once per build: single-flight keys `backend_switch_validated` by the closure's `RData`, hopac keeps the same cache in a `ConcurrentDictionary` cleared with the join point dictionaries. Before 2026-10-12 single-flight validated with the shared counter, so its numbering skipped the tags of discarded arms, and hopac skipped validation (`backend_switch_validate_all` was off since 2026-10-02 for speed): the cores emitted different text for every BackendSwitch sample (83 rows) and hopac did not type check other arms at all. Proof: single-flight-20261012-021057, hopac-20261012-030055 and restore single-flight-20261012-041719 (3,768 rows each): the 83 rows whose emitted text differed across the cores now match (cross-core residual differences 0, behaviour differences 0, hopac missing 0), the restore reproduces its rung row for row; blessed 2026-10-12 05:07 with a reproduction run (0 differences). The hopac rung took 76 min against 54.5 min before: validating every arm costs about 40% under full-suite load.

A top-level block whose first token is `test` (`test name [static] [print_code] [ignore] =` and an indented body, with optional `///>` target lines above it) is a test block: both `BlockParsing` sections skip it (`blockParsingIsTest`), so it never reaches a module and costs nothing in a build. Kino runs it: `parse_spi` turns each block into a test cell whose program is the file up to the block plus the body. All 370 lib/spiral tests live in their `.spi` this way; the lib loaded as a package compiles to the same C with and without them.

Rust array create fills each slot with Default. Rc of str and Rc of dyn Fn do not implement Default, and a blanket derive would reject heaps that never call default. codegenRust emits impl Default for a heap, a mutable heap, or a union only when every field has a default expression. A function element is a dummy closure. hopac-20261011-062126 (compiled 146.6 s, native 180.0 s) and restore single-flight-20261011-062732 (compiled 44.5 s, native 189.5 s) each ran the C and Rust examples suite: oracle agree 367, DISAGREE 0, 10 baseline C build-fails, broken 0, script exit 0. The 33 array samples that rustc rejected with E0599 before this impl agree. The restore Rust residuals match single-flight-20261011-060851.

Rust closures that come from a named inl binding emit `{stem}_c{tag}` (`closure_apply` binds `f` and emits `fn f_c0`). The `_c` keeps that name off a method `{stem}_{tag}`. Anonymous closures stay `closure{n}`. Other backends still emit `closure{n}`. Both cores record the binding name on the function body during prepass. single-flight-20261011-070642 (compiled 60.7 s, native 204.3 s), hopac-20261011-071623 (compiled 135.3 s, native 190.5 s), and restore single-flight-20261011-072251 (compiled 50.2 s, native 172.7 s) each ran the C and Rust examples suite: oracle agree 367, DISAGREE 0, 10 baseline C build-fails, broken 0, script exit 0. The restore Rust residuals match single-flight-20261011-070642.

Kotlin, Swift and TypeScript closures use the same readable name: `{stem}_c{tag}` when the closure comes from a named `inl` binding (`fun f_c0` / `func f_c0` / `function f_c0`), `closure{n}` otherwise. All three call `codegenClosureBody` and take its returned source name exactly the way the Rust section above already proved, and the tag is that backend's own closure memo index, so a nameless closure still gets a number. Kotlin/Swift prove it through their `closure_names` memo (the same `generatedClosureName` helper), TypeScript through its `closure` join point. single-flight-20261011-073934, hopac-20261011-095228 (compiled 129.6 s, native 1,463.6 s), and restore single-flight-20261011-101905 (compiled 75.0 s, native 1,408.6 s) each ran `-Backend C,Kotlin,Swift,TypeScript -Suite examples -Native`: 1052 ran, 10 build-fail, oracle agree 609, DISAGREE 0, hopac `missing` 0, `regressed` 0, broken 0, script exit 0. The restore run reproduces single-flight-20261011-073934 row for row (0 of 1,092 rows differ). Not blessed.

The Zig, Lean, Bend, Gleam, Lua, Wasm and Delphi closures use the same readable name: `{stem}_c{tag}` when the closure comes from a named `inl` binding (`fn f_c0` / `partial def f_c0` / `def f_c0` / `pub fn f_c0` / `function f_c0` / `func $f_c0` / `Tf_c0`), `closure{n}` otherwise. All seven call `codegenClosureBody` and take its returned source name exactly the way the sections above already proved, and the tag is that backend's own closure memo index, so a nameless closure still gets a number. Each proves it through a `closure_names` memo (the same `generatedClosureName` helper). Gleam lowercases the name because its function names must be lowercase. single-flight-20261011-122112, hopac-20261011-123041, and restore single-flight-20261011-124049 each ran `-Backend C,Delphi,Zig,Lean,Bend,Gleam,Lua,Wasm -Suite examples -Native`: 1650 jobs, 12 build-fail, oracle agree 1140, DISAGREE 0, hopac `missing` 0, `regressed` 0, broken 0, script exit 0. The 16 `native_closure_*`/`ts_closure_*` rows per backend are the only change from the closure rename. The restore run reproduces single-flight-20261011-122112 row for row (0 of 1,650 rows differ). Not blessed.

The F# (both cores) and Python closures use the same readable name: `{stem}_c{tag}` when the closure comes from a named `inl` binding (`let rec f_c0` / `def f_c0`), `closure{n}` (F#, anonymous) or `Closure{n}` (Python, anonymous) otherwise. F# proves it through a `closure_names` memo (hopac `ConcurrentDictionary`, single-flight `Dictionary`) filled at the closure join point from `closureSourceName` (`JpBodyOwnerIdentity.body jp_body` in hopac, `snd jp_body` in single-flight, the same expression each core's `codegenClosureBody` already uses); the emit and the `JPClosure` call site read it. Python carries a `name` field on its `ClosureRec` taken from the source name `codegenClosureBody` already returns (it dropped with `_` before), used in the `def` and the call site. Python is natively compared to C; F# is not (`test.ps1` excludes `Fsharp` from the native jobs at line 518), so the F# side is compile-checked by the suite and its generated `.fsx` is run by hand: the 16 closure samples `dotnet fsi` exit 0. single-flight-20261011-140929, hopac-20261011-141813, and restore single-flight-20261011-142157 each ran `-Backend C,Fsharp,Python -Suite examples -Native`: 814 jobs, 41 error, 1 timeout, oracle agree 19, DISAGREE 0, hopac `missing` 0, `regressed` 0, broken 0, script exit 0. The only residual changes are the closure names: F# `portable_convert_parse` (`closure1` -> `ok_c1`, `closure3` -> `error_c3`, the tracked `.fsx` diff) and the Python rows `portable_convert_parse`, `ts_closure_capture`, `ts_closure_return`, all of which still agree with C. The restore run reproduces single-flight-20261011-140929 row for row (0 of 814 rows differ). Not blessed.

The C closures use the same readable name: `{stem}_c{tag}` when the closure comes from a named `inl` binding (`int32_t f_c0`; `closure{n}` otherwise). `codegenClosureBody` already returned the source name (the C section dropped it with `_` before); `ClosureRecC` now carries a `name` field and the closure body function is `generatedClosureName x.name x.tag`. The env struct `Closure{i}`, the factory `ClosureCreate{i}` and the two decrefs stay tag-keyed, exactly as Zig keeps `ClosureEnv{tag}`/`closureCreate{tag}`. single-flight-20261011-152506, hopac-20261011-153643, and restore single-flight-20261011-154343 each ran `-Backend C,Rust,Delphi,Python -Suite examples -Native`: 1276 jobs, 1196 native ran, 12 build-fail, oracle agree 745, DISAGREE 0, hopac `missing` 0, `regressed` 0, broken 0, script exit 0. The only residual changes are the C closure body names on the 99 `samples/*/main.c` that define a closure (e.g. `closure_apply` `ClosureMethod0` -> `f_c0`, `closure_curry` -> `closure1`); every backend still agrees with C. The restore run reproduces single-flight-20261011-152506 row for row (0 of 1276 rows differ). Not blessed.

The Gleam backend (`codegenGleam`, shared section, both cores) keys `TyConv` on the source primitive instead of the target alone: an int-to-int conversion now wraps to the target width (`spiral_wrap_signed`/`spiral_wrap_unsigned`, matching C's narrowing cast) instead of `float.truncate`, which type-errored when the source was already an Int (the u64 narrowing `!!!!Conv` to i32 emitted `float.truncate(v3)` and Gleam rejected it: Expected type Float, found Int); float-to-float is the identity; bool sources convert. Lua's `TyConv` already guarded on `from_float`, so only Gleam had the bug. `samples/native_closure_union_rec` (a recursive union with closure fields whose u64 sum narrows to i32) joins the Gleam list in `tests/harness.psd1` and now runs exit 70, agreeing with C; it was a `build-fail` before. single-flight-20261011-161408 and its restore single-flight-20261011-163104 each ran `-Backend C,Gleam -Suite examples -Native`: 609 jobs, 579 ok, 29 error, 1 timeout, 569 native ran, 10 build-fail, oracle agree 126, DISAGREE 0, broken 0, script exit 0; the restore reproduces the first run row for row (0 of 609 rows differ). hopac-20261011-162530 ran the same suite: 609 jobs, 579 ok, 30 error, 0 timeout, 569 native ran, 10 build-fail, oracle agree 126, DISAGREE 0, hopac `missing` 0, `regressed` 0, script exit 0; no Gleam row differs from single-flight (the only cross-core differences are the pre-existing C residual hashes, the format_any/float_nan/utf8 block). The only new output is the untracked `samples/native_closure_union_rec/main.gleam`; every other Gleam output is byte-identical. Not blessed.

`samples/native_float_infinity` joins the Gleam list in `tests/harness.psd1` with a `Known` entry, because BEAM floats are never infinite or NaN: matching a `0x7FF0000000000000` float bit-pattern against `<<X:64/float>>` fails (`nomatch`), the same bytes fed to `erlang:binary_to_term` raise `badarg`, and `math:pow(2.0,1024.0)` raises `badarith`, so `!!!!Infinity` has no Gleam residual that compiles and the emitted file stops at `Unknown variable` (1,272 bytes, `main.gleam` still written). The row scores `known` on both cores (its C row runs exit 0). `litGleam`'s `infinityf`/`nanf` emission is deliberately unchanged: a clean fix there would make the residual a Spiral compile error instead of a `build-fail`, and the row is meant to be masked by the table entry, not to stop compiling. `native_float_nan_is` and `ts_float_nan` pick Gleam through their `!!!!BackendSwitch` arms, so they stay off the Gleam list as they do for Zig, Lean and Wasm. single-flight-20261011-174150, hopac-20261011-174720 and restore single-flight-20261011-175313 each ran `-Backend C,Gleam -Suite examples -Native`: 610 jobs, 580 ok, 569 native ran, 11 build-fail, oracle agree 126, `known` 1, DISAGREE 0, hopac `missing` 0, broken 0, script exit 0; the restore reproduces single-flight-20261011-174150 row for row (0 of 610 rows differ). The only new output is the untracked `samples/native_float_infinity/main.gleam`. Not blessed.

Gleam union matches (`codegenGleam`'s `TyUnionUnbox`, shared section) are always exhaustive. A match with a fallback emits it as `_ ->`. A match without one emits no `_` arm when it names every case of a single scrutinee's union, and otherwise `_ -> panic as "spiral: union case ruled out by partial evaluation"`: partial evaluation already ruled the missing cases out, as in a second `match` inside an enclosing `| _ =>` branch. Before, such a match emitted only the remaining arms, which Gleam rejects as inexhaustive, or, with one remaining case (a single-case union returned by an `inl`, or a union narrowed to one case), repeated that case's body as a `_ ->` arm whose pattern variables are unbound there (Gleam: Unknown variable). Both came from compiling `apps/kino/spi/document.spi`. Bend had the narrowed shape as a codegen error (`A union unbox misses a case and has no fallback`) and now emits the ruled-out case as `IO.die(<result>, 3, "")`. Every other backend already handled both shapes. `samples/gleam_match_narrowed` (exit 61) and `samples/gleam_match_single_case` (exit 49) reproduce them on the Gleam, Lua, Bend, Lean, Wasm, Kotlin, Swift and Zig lists, and every backend agrees with C.

The Gleam prelude emits each helper with the operation that needs it, and only `spiral_halt` and the `erlangMath` functions stay Erlang-only. `spiral_math_pow` (float `Pow`) is `float.power`, which panics outside the real domain where Erlang's `math:pow` raised `badarith`, so it builds for the JavaScript target too. Integer `Pow` gets `spiral_int_power`, string length gets `spiral_string_length` alone, and index and slice get `spiral_halt` with their helpers. Before, `spiralIntegers` bundled `@external(erlang, "math", "pow") pub fn spiral_math_pow` into every program that wrapped an integer, and `gleam build --target javascript` rejects a public function without a JavaScript implementation. That broke `lib/spiral/near/wallet` in CI ("Unsupported target"). Its regenerated `near_wallet.gleam` now builds for JavaScript, and a float `**` probe returns the same values on both targets (`2 ** 3`, `4 ** 0.5`, `-2 ** 3`). The Erlang-only externals that remain are `erlangMath` (log, exp, tanh, sqrt, sin, cos), `spiral_halt` (exit code 3 on a bad index or slice, which C's oracle rows need), and arrays and refs (process dictionary, `make_ref`). No JavaScript-target Gleam project in the repo reaches them.

`DeadPureLetElision` (shared section, both cores) also drops a dead `Dyn` (`inl ~x = ...` whose value only another backend's `!!!!BackendSwitch` arm used) and a dead `if`, union unbox or int switch whose branches contain only pure statements (`pureBranchingOp`). Across `samples/*/main.c`, `gcc -O0 -c -Wall` set-but-unused warnings went from 46 in 12 files to 31 in 2. `samples/folder_index_module` keeps `v0 = 0`, which comes from a macro (`$'0'`): macro text is opaque, so the pass never treats it as pure. `samples/mega_omniledger_erp_kernel/runtime_native` keeps its warnings for two reasons. Several are components of multi-destination lets (`v640..v648` from one `if`), and a let-level pass cannot drop one component without changing the destination's shape on every backend. The single-variable chains (`v24 = v23 + 1ll`) have no printed use in any backend, and the reference that keeps them live has not been found.

Ladder for the three changes above: single-flight-20261012-115551, hopac-20261012-122842 and restore single-flight-20261012-133540 (`-Suite all -Native`, six FOR-D repros filtered out). Each run had 3,793 rows, native 2,745 ran, 11 build-fail, oracle agree 2,278, DISAGREE 0, baseline parity 3,651, `parity-residual-differs` 118, new 24, no `regressed` or `missing`. Hopac and the restore match the first rung row for row (0 of 3,793 rows differ, residual hashes included).

The 118 changed residuals:
- Gleam (94): prelude helpers dropped or moved; `frontier_try_item` also loses its dead `Dyn` lets.
- Dead `Dyn` lets dropped (17): `frontier_try_item` on F#, Rust, Delphi, Zig, Wasm, Lean, Bend and Lua, plus 9 C rows (`frontier_try_item`, `ebpf_minkey`, `python_macro_annotations` and six `rust_*`).
- `mega_brzozowski_derivatives/indexed_dfa_state_cardinality` (5): dead pure unboxes dropped on C, Rust, Delphi, Zig and Wasm, with backend temporaries renumbered.
- `mega_omniledger_erp_kernel` F# (2): dead pure unboxes dropped.

Blessed 2026-10-12 18:17 from single-flight-20261012-174720, which ran on the main cache with the laddered binaries. It reproduces the ladder's restore rung on every row's compile, residual, native, exit, stdout and oracle, except 29 rows (Calyx 9, Wgsl 20): they are `no-toolchain` in the dev cache and ran in the main cache, agreeing with C, with identical residuals. The `EXPECTED.tsv` delta is exactly the 118 residual-only changes and the 24 new rows; no row was removed and nothing else changed. `-Bless` skips timed-out rows: they keep their previous oracle entry. Two earlier attempts were stopped under memory pressure: in the first, every compile timed out. A compile that times out leaves its output file empty (`abi_external/main.c`), so restore outputs after a stopped run.

The host takes `--default-int i8|i16|i32|i64|u8|u16|u32|u64` and `--default-float f32|f64` anywhere on its command line, in every mode (`--backend`, `--batch`, `--server`, `build-file`). They set `SPIRAL_DEFAULT_INT` / `SPIRAL_DEFAULT_FLOAT` for the process. `startupParse` (shared section, both cores) takes its defaults from those variables before falling back to `i32` and `f64`, so every `DefaultEnv` the host creates sees the same defaults. The defaults decide the `int`/`float`/`uint` type names and unsuffixed literals: with `--default-int i64 --default-float f32`, `inl ~x : float = 1.5` and `inl ~n : int = 3` emit `float32 = 1.5f` and `int64 = 3L`. An unknown value exits 2 with the allowed list.

The Zig backend (`codegenZig`, `--backend Zig` / `.zig`, 2026-10-06) is being brought up toward the hub role: a sample
gets a Zig row when `tests/harness.psd1`'s `Zig` list names it (C is its oracle, like Rust's and Delphi's). The native
tier builds it with `zig build-exe -O ReleaseFast --stack 1073741824` (~2 s; Zig's self-hosted `-fno-llvm` linker ignores `--stack` and leaves 16 MB, ReleaseSafe takes ~16 s) since the prelude writes through the OS directly and replaces the default panic handler (std.Io.Threaded and the debug-info readers were 302 of 307 LLVM functions; cube: 0.15 s run vs C 1.34 s). Not
supported yet: value-level `!!!!BackendSwitch` records without a `Zig` key, lib/spiral (no Zig arms), stack mutable
layouts, C-only macros. Every program gets a 1 GB main stack from the linker (`--stack`; deep mutual recursion, as Rust).

The Lean 4 backend (`codegenLean`, `--backend Lean` / `.lean`, 2026-10-07) emits one `mutual` block of `partial def`s
in `IO` do-notation: every local is a `let mut`, self tail calls become `repeat`/`continue`, `!!!!While` a `repeat` with
`break`, and `main : IO UInt32` returns the program's i32. A sample gets a Lean row when `tests/harness.psd1`'s `Lean`
list names it; the native tier runs it with `lean +leanprover/lean4:v4.35.0-rc4 --run` (elaboration ~2 s; stable 4.34.1 was ~7 s; the toolchain comes from elan,
`SPIRAL_LEAN` or `ELAN_HOME`). Arrays are `IO.Ref (Array α)` (aliased like C's), unions `inductive U<tag>`, heap
layouts `structure H<tag>`, mutable layouts `IO.Ref M<tag>`, closures partially applied `closure<tag>` defs, strings
indexed and sliced by UTF-8 byte (`String.Pos.Raw`). `lean --run` prints elaboration errors on stdout, so the
generated file turns the linters off and the harness scores a `.lean:<line>:<col>: error` as a build failure. Not
supported yet: stack layouts, C-only macros, value-level `!!!!BackendSwitch` records without a `Lean` key.

The WebAssembly backend (`codegenWasm`, `--backend Wasm` / `.wat`, 2026-10-08) emits one WAT text module that the native tier
runs with `wasmtime run -W max-wasm-stack=1073741824` (WASI `fd_write`/`proc_exit` only). A sample gets a Wasm row when
`tests/harness.psd1`'s `Wasm` list names it (C is its oracle). Scalars map to the four value types (sub-word ints narrowed
after arithmetic, unsigned ops `_u`, float to int with `trunc_sat`); join points are funcs, self tail calls `loop`/`br`,
`!!!!While` `block`/`loop`. Unions, heap and heap mutable layouts, arrays and closures are i32 pointers into linear memory (a
bump allocator, never freed): a union is `[tag][8-byte slots]`, an array `[len][stride 8 x fields]`, a closure
`[table index][captures]` called through `call_indirect`. Strings are `[len][utf-8 bytes]`; the prelude has concat, eq,
slice (exit 3 on bad bounds or a cut UTF-8 sequence), int/bool/char to string, strtol-like parsing, and software
exp/log/sin/cos/tanh/pow/atan2 (~1 ulp; WASM has no such instructions). String order is `$str_cmp` (unsigned bytes, then
length, C's `strcmp` on UTF-8), and `<`/`<=`/`>`/`>=` on strings compare its result with 0 (`samples/string_ord`, exit 0
like C; a `$str_cmp` forced to return 0 exits 1). Only the prelude functions a program calls are
emitted (`call $name`, transitively). Not supported yet: stack mutable layouts, C-syntax macros in samples.

The WGSL backend (`codegenWgsl`, `--backend Wgsl` / `.wgsl`, 2026-10-10) emits one compute shader. The native tier runs it with `spiral-wgsl` (wgpu 24, `tests/native-shims/wgsl-run`, `SPIRAL_WGSL_RUN` or the cache `toolchains/wgsl-run/release` binary): bind group 0 binding 0 is a read-write storage buffer `SpiralIo { code: i32, pad0..2: u32 }`, entry point `main` writes the program's i32, and the runner exits with that code and prints nothing. No adapter, including the fallback adapter, is `wgsl error: no WebGPU adapter` and exit 3 (`no-toolchain`). A validation error is exit 2 (`build-fail`). A sample gets a Wgsl row when `tests/harness.psd1`'s `Wgsl` list names it (C is its oracle). Scalars are i32, u32, f32, and bool; char shares i32. Join points are functions, and parameters are copied into `var`s because WGSL arguments are immutable. Self-tail calls become `loop`/`continue`. A value-returning loop is followed by a dead `return` of zero, because the validator treats fallthrough after a loop that never breaks as a valueless return. `!!!!While` is `loop` with `break`. Shift counts are `u32` (`>>` on i32 stays arithmetic). Tuple returns are flattened structs (`SpiralTupleN`), projected field by field at the call. Macros are emitted as text, so a `Wgsl` arm of `!a = !b` is an assignment and `break`/`continue` macros work inside a loop. Not supported yet: f64, i64/u64, sub-word integers, unions, arrays, strings, closures, heap references, globals, failwith, recursion that is not a self-tail call, and `!!!!BackendSwitch` records without a `Wgsl` key.

The Calyx backend (`codegenCalyx`, `--backend Calyx` / `.futil`, 2026-10-10) emits one component per join point for the integer subset. The native tier runs it with cider (`cargo +1.90 -p cider`, `SPIRAL_CIDER` or the cache `toolchains/calyx-src/target/release` binary) and converts the binary memory dump with auxin (`-f cider -t json`). `component main` writes the program's i32 into `@external spiral_io`, a `comb_mem_d1(32, 1, 1)`, and the runner exits with that code and prints nothing. A sample gets a Calyx row when `tests/harness.psd1`'s `Calyx` list names it (C is its oracle). Locals are `std_reg` cells, one group per assignment. Signedness matters for comparisons, division, remainder, and arithmetic right shift; add, subtract, and multiply use the two's-complement primitives. Self-tail calls are a `while` on a go register. Not supported yet: f32/f64, i64/u64, tuples, macros, strings, unions, arrays, closures, heap references, globals, failwith, and recursion that is not a self-tail call.

The Kotlin backend (`codegenKotlin`, `--backend Kotlin` / `.kt`, 2026-10-10) emits top-level functions and exits through `System.exit` of main's i32, printing nothing. The native tier compiles every Kotlin row of a run in one warm JVM before the native lanes start: `tests/native-shims/kotlin-server/KotlinServer.java` (launched from source on Temurin JDK 25, the Kotlin 2.4.21 lib jars on its classpath from `SPIRAL_KOTLINC`, Scoop `~/scoop/apps/kotlin/current` or the cache `toolchains/kotlinc`) reads `source<TAB>classes` lines and calls `K2JVMCompiler` in process with `-no-stdlib -no-reflect` against `kotlin-stdlib.jar`; each lane then runs `java -cp kotlin-stdlib.jar;classes MainKt`. A Kotlin row went from about 22 s (a cold JVM and compiler per file plus `-include-runtime`) to a median of 285 ms (single-flight-20261012-050734), and a full single-flight suite from about 50 to about 26 minutes. A sample gets a Kotlin row when `tests/harness.psd1`'s `Kotlin` list names it (C is its oracle; 246 rows). Scalars: i8/i16/i32/i64 are `Byte`/`Short`/`Int`/`Long`, the unsigned ones `UByte`/`UShort`/`UInt`/`ULong`, f32/f64 `Float`/`Double`, char shares `Int`. Small-integer arithmetic is computed as `Int` and narrowed back (`toByte`, `toShort`, `toUByte`, `toUShort`), matching C's promotion and store; shifts widen to `Int`, `Int.shr` is arithmetic and a `UInt` shift count is converted to `Int`; bitwise ops are the infix `and`/`or`/`xor`, `inv`, `shl`, `shr`. Strings are UTF-8 bytes: length, index (the sign-extended byte, C's signed char) and slice go through `spiralStringLength`/`spiralStringIndex`/`spiralStringSlice`; concat is `+`, equality and order `==` and `<`. Arrays are `Array<T>`; create fills the element's zero; index and update are unchecked like C, with `Int` index and length. Stack unions are a sealed interface plus one case class per case (fields `f0`, `f1`, ...), matched on `tag` and cast; a local's zero is the first case built from zeros. Heap and mutable layouts are classes (a mutable cell is the same object in a callee); a closure is a local function wrapped in a lambda; tuple returns are flattened `SpiralTupleN` classes. Join points are functions; self-tail calls are `while (true)` / `continue` with a dead `return` of zero; `!!!!While` is `while (true)` with `break`; macros are emitted as text, so a `Kotlin` arm of `!a = !b` is an assignment and `break`/`continue` macros work inside a loop. `failwith` prints to stderr and exits 1 (`System.err.println`, `System.exit(1)`), matching C's `EXIT_FAILURE`. Coverage is any nesting of those layouts, unions, arrays, tuples and closures that the harness list exercises. Proof: single-flight-20261011-034849 (Kotlin 245 of 246 agree; `mut_f32_text`'s hung-output DISAGREE agreed on rerun single-flight-20261011-042021), hopac-20261011-042553 (agree 492 with Swift, DISAGREE 0; its NATIVE-DIFF was `managed_string_invalid_utf8_slice` C timing out while abort waited on WerFault, fixed by the runner setting SEM_NOGPFAULTERRORBOX before native children: rerun hopac-20261011-045709 exits 3 in 0.4 s), restore single-flight-20261011-045745 (Kotlin 246 agree, Swift 246 agree, DISAGREE 0). Not supported yet: recursive unions, array elements that are more than one value, a closure that calls itself, a function type other than a plain arrow, a recursive layout, a stack layout, a ref layout, globals, and `!!!!BackendSwitch` records without a `Kotlin` key.

The OpenQASM 3 backend (`codegenOpenQasm`, `--backend OpenQasm` / `.qasm`, 2026-10-10) emits the classical subset: `OPENQASM 3.0;`, one `def` per join point, and `output int[32] spiral_io` assigned from main (or `0` when main is unit). The program prints nothing. The native tier runs `tests/native-shims/openqasm-run/run.py` with `python` (`SPIRAL_PYTHON`). That simulator wraps `int[32]` and `uint[32]`, divides and takes remainder toward zero, shifts signed values arithmetically and unsigned values logically (the count keeps its low 5 bits), rounds `float[32]` after every operation, and exits with `spiral_io`. Stderr containing `qasm error:` is a build failure. A sample gets an OpenQasm row when `tests/harness.psd1`'s `OpenQasm` list names it (C is its oracle). The list is the 16 non-tuple names from the Kotlin set plus `samples/tuple_pair`, `samples/ebpf_nest3`, `samples/ebpf_tacc`, `samples/ebpf_t2` and `samples/ebpf_t3`. Scalars are `int[32]`, `uint[32]`, `float[32]`, and `bool`; char shares `int[32]`. Self-tail calls are `while (true)` / `continue`, with a dead `return` of zero after the loop. `!!!!While` is `while (true)` with `break`. Binary operators are parenthesized. Bool converted to an integer is `(if cond { 1 } else { 0 })`. Tuple support is a deliberate extension beyond standard OpenQASM 3, which has no tuple or multi-value type; the local simulator accepts it, so the emitted code is not portable OpenQASM. A tuple domain flattens to one parameter per element and a tuple return is flattened: a `def` returns `(T1, T2, ...)`, a call destructures with `v0, v1 = f(...)`, a nested tuple flattens recursively, and a tuple-returning self-tail loop's dead return is `return 0, 0, ...;`. Macros are emitted as text, so an `OpenQasm` arm of `!a = !b` is an assignment and `break` / `continue` macros work inside a loop. single-flight-20261011-125450, hopac-20261011-130419, and restore single-flight-20261011-130704 each ran `-Backend C,OpenQasm -Suite examples -Native`: 504 jobs, 10 build-fail, 21 OpenQasm rows all agree with C, DISAGREE 0, hopac `missing` 0, broken 0, script exit 0. The restore run reproduces single-flight-20261011-125450 row for row (0 of 504 rows differ). Not supported yet: f64, i64/u64, NaN and infinity, strings, unions, arrays, closures, heap references, globals, failwith, recursion that is not a self-tail call, and `!!!!BackendSwitch` records without an `OpenQasm` key.

The Swift backend (`codegenSwift`, `--backend Swift` / `.swift`, 2026-10-10) emits top-level functions and exits through `exit` of main's i32, printing nothing. The native tier is Windows `swiftc` 6.4 (`SPIRAL_SWIFTC`, or `%LOCALAPPDATA%\Programs\Swift\Toolchains\6.4.0+Asserts\usr\bin\swiftc.exe`): `-O -sdk` against the 6.4 `Windows.sdk` (`SPIRAL_SWIFT_SDK`, or `Platforms\6.4.0\Windows.platform\Developer\SDKs\Windows.sdk`), then the exe with `swiftCore.dll` on `PATH` (`SPIRAL_SWIFT_RUNTIME`, or `Runtimes\6.4.0\usr\bin`); `import CRT` provides `exit`. A sample gets a Swift row when `tests/harness.psd1`'s `Swift` list names it (C is its oracle; the same 246 samples as Kotlin). Scalars: `Int8`/`Int16`/`Int32`/`Int64`, `UInt8`/`UInt16`/`UInt32`/`UInt64`, `Float`/`Double`, char shares `Int32`. Integer add, subtract and multiply wrap (`&+`, `&-`, `&*`), `/` and `%` are plain, `<<`/`>>` take an `Int32` count; conversions are `Double(_:)`, `Int64(_:)`, `Int32(_:)` toward zero, and so on. Strings are UTF-8 bytes: length is `utf8.count`, index sign-extends with `Int8(bitPattern:)` (C's signed char), slice decodes the byte range, concat is `+`, equality and order `==` and `<`. Arrays use `Array(repeating:count:)` with unchecked index and update (`Int` index, `Int32` length). Stack unions are a protocol plus one struct per case (labels `f0`, `f1`, ...), matched on `tag` and cast with `as!`; heap and mutable layouts are classes (closure fields take an `@escaping` initializer); closures are inner closures; tuple returns are Swift tuples read with `.0`, `.1`. Join points are functions whose parameters have no external label (`_ p0`), so calls stay positional; self-tail calls are `while true` / `continue` with a dead `return` of zero; `!!!!While` is `while true` with `break`; macros are emitted as text. `failwith` writes its message with `fputs` and exits 1. Proof: the Kotlin runs above, where Swift agreed on all 246 rows in each. Not supported yet: recursive unions, array elements that are more than one value, a closure that calls itself, a function type other than a plain arrow, a recursive layout, a stack layout, a ref layout, globals, and `!!!!BackendSwitch` records without a `Swift` key.

The eBPF backend (`codegenEbpf`, `--backend Ebpf` / `.ebpf`, 2026-10-10) is a C profile. The native tier compiles it with the Windows C compiler (`gcc -std=c11 -O2 -w -x c`, the same `cc` as the C oracle) and runs the exe; it does not load a kernel program. Every program has a 64-slot array map (`spiral_map_lookup`, `spiral_map_update`; a full map rejects new keys and still overwrites existing ones). Self-tail calls and `!!!!While` are `for` loops capped at `SPIRAL_LOOP_CAP` (16777216), and a capped loop's dead return is the type's zero (`0`, `0u`, `0.0f`, `false`, `(SpiralTuple0){0}`). A sample gets an Ebpf row when `tests/harness.psd1`'s `Ebpf` list names it (C is its oracle): the Kotlin v1 set plus the `ebpf_*` samples, which cover map edge cases (negative and `INT32_MIN` keys, a stored 0, a full map), toward-zero division and remainder, arithmetic and logical shifts by runtime counts, unsigned wrap, f32 ordering and division, int/float casts, bool logic, `!!!!NEQ` (emitted as `!=`), nested tuples flattened into one struct, and several self-tail methods in one program. Scalars are `int32_t`, `uint32_t`, `float` and `bool`; char shares `int32_t` and, not being a `number`, only supports equality. Tuple returns are flattened structs (`SpiralTupleN`). `int main` returns main's i32 and prints nothing. Proof: hopac-20261010-164510 and single-flight-20261010-164532 agree 47 with DISAGREE 0; in the 3774-row ladder single-flight-20261011-204644 all 51 Ebpf rows agree. Not supported yet: f64, i64/u64, NaN and infinity, strings, unions, arrays, closures, heap references, globals, failwith, recursion that is not a self-tail call, a kernel verifier, and `!!!!BackendSwitch` records without an `Ebpf` key.

## Rules

- The compiler writes its output next to its source (`samples/<name>/main.c`, ...), replacing the previous
  one. There is exactly one copy of each output and it is committed: `git diff samples` after a run is
  the check that outputs changed. Never edit outputs by hand; a hopac run rewrites them with hopac's
  output, so restore them (`git restore samples`) or rerun single-flight before committing. One
  `scripts/test.ps1` run at a time (it holds a named mutex per cache dir; a dead run abandons it).
- `-Bless` only in single-flight mode, only after reviewing every changed row of the baseline. Re-blessing
  is the agent's call (don't ask the user): bless when there is no `REGRESSED`/`DISAGREE` and every other
  changed row is explained, and only if the `-Bless` run reproduces the preceding single-flight run row for
  row (same verdicts and residual hashes). The oracle lives in the cache, never in the tree.
- Other generated results never go into the tree (the oracle, scoreboards, receipts, snapshots); hand-written
  harness tables live in `tests/harness.psd1`. `|core-` resolves to The-Spiral-Language's core in
  the fork that `scripts/init.ps1` clones to the repo's `deps/The-Spiral-Language` (polyglot's clone is the fallback;
  `Get-SpiralPackageDir`); do not copy it here.
- Keep both cores building against the same host. If the host needs a core-specific path, guard it with
  `SPIRAL_CORE_SINGLE_FLIGHT` / `SPIRAL_CORE_HOPAC` (see `directProjectCompileFsharp`).
- This directory holds sources, fixtures and docs only. Build output, toolchains, native binaries, run logs
  and the flat dependency directory stay in the cache directory; `.gitignore` catches in-tree builds.
- Both cores are one file, `apps/compiler/spiral_compiler.fs` (merged 2026-09-28). It is split into sections
  at its `/// ## Name` headers, one per upstream module. A section both cores share appears once; a section
  that differs appears whole, twice:
  `#if SPIRAL_CORE_HOPAC` (hopac's) `#else` (single-flight's) `#endif`, markers at column 0. The core project
  defines `SPIRAL_CORE_HOPAC` in hopac mode; `Get-SpiralCoreProjection` (scripts/env.ps1) writes one core
  without the pairs, which is what the splitter reads. Keep LF line endings (never `WriteAllLines`).
- Edit a shared section once, for both cores. Unifying a pair (one section serving both) is the way to stop
  copying changes between cores: make the shared text single-flight's (the upstream-facing view), and move
  what hopac needs into hooks defined in an earlier hopac-only section. Never put `#if` inside a section
  that maps to an upstream file: the upstream sync replaces those sections wholesale (README, "Upstream").
- Verify a change to a pair or a shared section with both builds (`build.ps1 -Mode single-flight` and
  `-Mode hopac`) and each lane's tests.

## Promotion criterion

Hopac replaces single-flight as the default when `-Suite all` shows no `missing` rows, all native
columns agree, every row returns (`ok`, not `emitted`), and `apps/spiral` compiles. Until then
single-flight stays the oracle and the lane that ships Rust/Delphi output.

Status 2026-10-01 20:19 (`runs/hopac-20261001-194016`): **met** for the first time: no `missing` row, native
columns agree (`DISAGREE` 0), no row is `emitted`, `apps/spiral` compiles (359 s). One margin is thin: the 4
`frontier_runaway_inline_recursion` rows reach their `EJP0040` report in 14.5-16.5 s under suite load, against
the 17 s core deadline (FRONTIER.md fix 58). Before switching the default, repeat the suite a few times.

Status 2026-10-02 16:10 (`runs/hopac-20261002-153006`): still met, and the margin held in two more runs (11.3-11.7 s,
then 8.7-10.0 s; 15.2-15.9 s in a third on a throttled CPU, so it still depends on machine load); full parity, 33 more rows byte-identical to single-flight (union arms ordered by case name, not
intern order). Hopac remains 4-5x slower than single-flight on the mega roots (NEXT.md item 1).

Status 2026-10-05 10:48 (`runs/hopac-20261005-101938`, `-Parallel 3`, ReadyToRun build with the term_core_impl split): met;
1279 rows, no `missing`/`emitted`/timeout, DISAGREE 0, 12 rows `parity-residual-differs` (format_any x4, native_float_nan_is x3,
ts_float_nan x4, rust_emit_tuple_args: BackendSwitch numbering). The slowest frontier rows now take 8-13 s under that load against
the 17.9 s deadline (9-16 s before; frontier_hello ~2 s per fresh process instead of ~6-7 s), compile time summed over the
suite 2,280 s vs 7,020 s the night before.

Status 2026-10-11 21:26 (`runs/hopac-20261011-195057`, `-Suite all -Native`, the hopac rung of the closure void-cast ladder):
suite dimensions met — 3774 rows (contracts 669, examples 3052, frontier 48, mega 5), no `missing`/`emitted`, DISAGREE 0,
baseline `missing|regressed` 0, native 2749 ran / 13 build-fail / oracle agree 2284, script exit 0; `apps/spiral` was not
rebuilt in this run, so the full promotion criterion is not claimed. Measured against the single-flight rung around it
(`single-flight-20261011-190603` before, `single-flight-20261011-204644` restoring after), 84 of 3774 rows differ across the
cores: 83 only in the emitted-text hash (32 samples over 13 backends — portable_math_rounding 11, portable_console_lines 11,
portable_convert_parse 9), and 1 in compile status (`runaway_inline_match_recursion`, timeout before vs error under load after,
non-ok in both); compile, native, exit and stdout are otherwise identical, and the restore reproduced its rung row for row
(0 of 3774), so the emitted-output store is core-independent for this change. The hopac lane took 54.5 min against single-flight's
34.8 and 39.4 min in the two flanking rungs.
