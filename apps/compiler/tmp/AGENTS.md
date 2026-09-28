# Working on the Spiral compiler

Rules for humans and LLM sessions (browser sandbox or local Windows) that change the compiler.

## Two lanes, one harness

| | single-flight | hopac |
|---|---|---|
| What it is | the compiler that works today: sequential evaluator, F#/C/Rust/Delphi | the parallel Hopac evaluator: full parity on frontier+smoke, ~92% on examples+contracts |
| Source of truth | `apps/compiler/spiral_compiler.fs` (the repo's main core) + `compiler/host/PortableBackends.fs` | `compiler/cores/hopac/spiral_compiler.fs` |
| Role in tests | **oracle**: its results are `<cache>/baseline/EXPECTED.tsv` (`-Bless`) | **candidate**: scored by how much of the oracle it reproduces |
| Known wall | `apps/spiral` overflows the stack | ~27 partial-evaluation stalls, closures created in runtime `if` branches (`EJP0035`), and an order-dependent parse of backtick type application (see `lanes/hopac/FRONTIER.md`). Single-flight's features since the shared base `12f52a1` are ported. |
| Scoreboard | `<cache>/scoreboards/single-flight.tsv` | `<cache>/scoreboards/hopac.tsv` (`-Record`) |

Switching lanes is only a build/test argument: `-Mode single-flight` or `-Mode hopac`. Both binaries
live side by side in the cache, so the same fixture can be compared across modes in seconds.

## The loop

```powershell
pwsh scripts/build.ps1 -Mode hopac                        # core edit: ~3.5 min; host edit: ~35 s
pwsh scripts/test.ps1 -Mode hopac -Suite frontier         # seconds per fixture, low timeouts
pwsh scripts/test.ps1 -Mode hopac -Suite frontier,smoke   # widen once the frontier is green
pwsh scripts/test.ps1 -Mode hopac -Suite all -Record      # full scoreboard, written to lanes/hopac/
```

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
which the core reports `BuildFile stalled: ... last_stage=<stage>` as an `error` row instead of hanging.
Override with `-TimeoutSec` only for deliberate profiling.

Hopac knobs (environment): `SPIRAL_HOPAC_WORKERS` and `SPIRAL_DOP` (set both to 1 for deterministic
runs), `SPIRAL_BUILD_DEADLINE_MS` / `SPIRAL_BUILD_BUDGET_MS` (stall watchdog; the host sets the deadline,
otherwise 15 min), `SPIRAL_LEGACY_JOIN_HEURISTICS=1` (old EJP0019/EJP0021 join loop),
`SPIRAL_DEBUG_UNBOX=1` (trace union unboxes), `SPIRAL_ARTIFACT_COMMIT_GRACE_MS` (500),
`SPIRAL_RUN_END_GRACE_MS` (500), `SPIRAL_CODEGEN_STACK_MB` (512). Debugging workflow:
`lanes/hopac/FRONTIER.md`, "The fast loop".

In hopac mode every job runs in its own compiler process (`-FreshProcess`, on by default there), because
the Hopac core currently serves only one `BuildFile` per process. Serving many builds from one warm
process, as single-flight does, is itself a hopac milestone: once it works, run with `-FreshProcess:$false`.

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

Backend work (Rust, Delphi) happens in `compiler/host/PortableBackends.fs` and is proven by
`pwsh scripts/test.ps1 -Suite examples -Native`: C is the semantic oracle, Rust and Delphi must match its
exit code and stdout (`oracle` column). Add a fixture under `samples/<name>` for any new construct and
commit the outputs the compiler writes next to it. Changes to the single-flight core must keep `-Suite all -Native` free of `REGRESSED`,
`NATIVE-DIFF` and `DISAGREE`, then refresh the oracle with `-Bless`.

## Rules

- The compiler writes its output next to its source (`samples/<name>/main.c`, ...), replacing the previous
  one. There is exactly one copy of each output and it is committed: `git diff samples` after a run is
  the check that outputs changed. Never edit outputs by hand; a hopac run rewrites them with hopac's
  output, so restore them (`git restore samples`) or rerun single-flight before committing. One
  `scripts/test.ps1` run at a time (it holds `<cache>/test.lock`).
- `-Bless` only in single-flight mode, only after reviewing every changed row of the baseline.
- Other generated results never go into the tree (the oracle, scoreboards, receipts, snapshots); hand-written
  harness tables live in `tests/harness.psd1`. `|core-` resolves to The-Spiral-Language's core through
  the repo's `deps/polyglot` link (`Get-SpiralPackageDir`); do not copy it here.
- Keep both cores building against the same host. If the host needs a core-specific path, guard it with
  `SPIRAL_CORE_SINGLE_FLIGHT` / `SPIRAL_CORE_HOPAC` (see `directProjectCompileFsharp`).
- This directory holds sources, fixtures and docs only. Build output, toolchains, native binaries, run logs
  and the flat dependency directory stay in the cache directory; `.gitignore` catches in-tree builds.
- There is one copy of each core: single-flight is `apps/compiler/spiral_compiler.fs`, hopac is
  `compiler/cores/hopac/spiral_compiler.fs`. Keep LF line endings (never `WriteAllLines` on either).
- Porting between cores: both descend from commit `12f52a1`; diff a core against
  `git show 12f52a1:apps/compiler/spiral_compiler.fs` to see its own changes (`lanes/hopac/FRONTIER.md`).

## Promotion criterion

Hopac replaces single-flight as the default when `-Suite all` shows no `missing` rows, all native
columns agree, every row returns (`ok`, not `emitted`), and `apps/spiral` compiles. Until then
single-flight stays the oracle and the lane that ships Rust/Delphi output.
