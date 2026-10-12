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
- Runs go through the Kino daemon with its memory cap (`SPIRAL_KINO_DAEMON_MAX_MB`, default 2500).
- Heavy work (compiler builds, full suites, server runs) waits for a free heavy slot; one at a time on the 16 GB machine.

## Gates before Tibia work starts

| Gate | Backlog item | Why it must come first |
| --- | --- | --- |
| CI green after the `.spi` migration | CI-AFTER-SPI-MIGRATION, CI-SPIRAL-WASM-NATIVE | Dogfood measurements need a green baseline |
| Expected-diagnostic test blocks | SELF-CHECKING-SAMPLES (negatives), to be split out | Tibia's types-first rule needs "must not compile" tests |
| Inline expected output | TEST-EXPECT-PERSIST | Otherwise every Tibia test is rewritten once it lands |
| Compiler owns test-block boundaries | SOURCE-BOUNDARY-AUTHORITY | Kino's line heuristics are the parser Tibia would depend on |
| Typed planning fields | EOIE-AGILE-TYPED-FIELDS | Tibia's backlog is written once, with typed estimates |
| Kino `wgsl` target | KINO-WGSL-TARGET (done 2026-10-12) | `///> wgsl` runs spiral-wgsl and fails on a non-zero exit; `///> zig` runs `zig run`; WGSL/Zig tests end in an i32 status because lib `testing` prints strings |
| WGSL arrays and unions | WGSL-BACKEND | PLAN.md P0; dogfood work, can start while the gates above close |
