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

The Zig backend (`codegenZig`, `--backend Zig` / `.zig`, 2026-10-06) is being brought up toward the hub role: a sample
gets a Zig row when `tests/harness.psd1`'s `Zig` list names it (C is its oracle, like Rust's and Delphi's). The native
tier builds it with `zig build-exe -O ReleaseFast --stack 1073741824` (~2 s; Zig's self-hosted `-fno-llvm` linker ignores `--stack` and leaves 16 MB, ReleaseSafe takes ~16 s) since the prelude writes through the OS directly and replaces the default panic handler (std.Io.Threaded and the debug-info readers were 302 of 307 LLVM functions; cube: 0.15 s run vs C 1.34 s). Not
supported yet: value-level `!!!!BackendSwitch` records without a `Zig` key, lib/spiral (no Zig arms), stack mutable
layouts, C-only macros. Every program gets a 1 GB main stack from the linker (`--stack`; deep mutual recursion, as Rust).

The Lean 4 backend (`codegenLean`, `--backend Lean` / `.lean`, 2026-10-07) emits one `mutual` block of `partial def`s
in `IO` do-notation: every local is a `let mut`, self tail calls become `repeat`/`continue`, `!!!!While` a `repeat` with
`break`, and `main : IO UInt32` returns the program's i32. A sample gets a Lean row when `tests/harness.psd1`'s `Lean`
list names it; the native tier runs it with `lean --run` (elaboration ~7 s; the toolchain comes from elan,
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
exp/log/sin/cos/tanh/pow/atan2 (~1 ulp; WASM has no such instructions). Only the prelude functions a program calls are
emitted (`call $name`, transitively). Not supported yet: stack mutable layouts, ordering strings, C-syntax macros in samples.

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
