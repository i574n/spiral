# Workflow

Tibia is the dogfood project for the new source-first workflow. Tooling improves first; the Tibia goal advances only
where the road is clean. Every friction found becomes an eoie backlog item before it is worked around.

## Old and new

| | Folder workflow (compiler samples) | Source-first workflow (lib/spiral since 2026-10-12) |
| --- | --- | --- |
| Unit | `samples/<name>/` folder: `package.spiproj`, `main.spi`, emitted outputs next to it | One `.spi` per module with `test name [static] [print_code] [ignore] =` blocks |
| Negatives | One `negative_*` folder per forgery (Brzozowski: 31) | Not expressible yet |
| Expectations | Cache-only `EXPECTED.tsv`, per-backend lists in `tests/harness.psd1` | Exit code only: a test passes when every `///>` target exits 0 |
| Runner | `apps/compiler/tmp/scripts/test.ps1` | `apps/kino/spi/run_notebook.ps1 --path x.spi [--test name]`, report lines `spiral-tests file/total {json}` |
| Editor | none | Zed tasks "run test at cursor" / "run file tests" (`apps/zed/tasks/test-at-row.ps1`) |
| Backlog | prose and TSVs | `eoie agile` on `i574n.github/docs/backlog` |

## Rules for apps/tibia

- Modules are `.spi` files with test blocks; no sample folders.
- Until inline expectations exist, a test asserts inside its body and fails through a non-zero exit.
- A missing workflow feature is added to the tooling (Kino, compiler, eoie), not imitated in Tibia code.
- Every backlog item names the claim or milestone it serves. An item reached through a dependency chain or a keyword
  search is checked against BENCHMARK.md and PLAN.md before work starts; one that serves no claim is dropped, not done.
- A compiler rejection is a defect only if the language means to accept the program. A documented boundary (for example,
  existentials are compile-time only) becomes a negative test with its expected diagnostic, not a bug repro.
- Runs go through the Kino daemon with its memory cap (`SPIRAL_KINO_DAEMON_MAX_MB`, default 2500).
- Heavy work (compiler builds, full suites, server runs) waits for a free heavy slot; one at a time on the 16 GB machine.

## Gates before Tibia work starts

| Gate | Backlog item | Why it must come first |
| --- | --- | --- |
| CI green after the `.spi` migration | CI-AFTER-SPI-MIGRATION, CI-SPIRAL-WASM-NATIVE | Dogfood measurements need a green baseline |
| Expected-diagnostic test blocks | TEST-EXPECT-DIAGNOSTIC (done 2026-10-12) | `test x fails "message" =` passes only when the body fails to compile with that diagnostic; used in vitality.spi and policy.spi |
| Inline expected output | TEST-EXPECT-PERSIST (done 2026-10-12) | `--accept` rewrites a failing `_assert_eq` literal; it stops at the first failing assertion and refuses repeated literals (KINO-ACCEPT-RERUN), so pin with unique placeholders and re-run until nothing is accepted |
| Compiler owns test-block boundaries | SOURCE-BOUNDARY-AUTHORITY | Kino's line heuristics are the parser Tibia would depend on |
| Typed planning fields | EOIE-AGILE-TYPED-FIELDS (done 2026-10-12) | Tibia's backlog is written once, with typed estimates |
| Kino `wgsl` target | KINO-WGSL-TARGET (done 2026-10-12) | `///> wgsl` runs spiral-wgsl and fails on a non-zero exit; `///> zig` runs `zig run`; WGSL/Zig tests end in an i32 status because lib `testing` prints strings |
| WGSL arrays and unions | WGSL-NULLARY-UNIONS, WGSL-PAYLOAD-UNIONS, WGSL-RECORD-JOIN-POINTS (done 2026-10-12/13), WGSL-STORAGE-ARRAYS (85%) | PLAN.md P0; every apps/tibia module now has a `///> wgsl` test, hunt_sim's golden seed runs on the GPU |
