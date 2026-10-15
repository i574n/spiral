# gpt5parallel lane

The gpt5parallel core (the `#if SPIRAL_CORE_GPT5PARALLEL` side of `apps/compiler/spiral_compiler.fs`) is the parallel evolution of the Spiral
compiler. It becomes the main core (`apps/compiler/spiral_compiler.fs`) once it meets the promotion
criterion in `AGENTS.md`; until then single-flight is the main core and the oracle.

Current status and the next fixture to fix: [FRONTIER.md](FRONTIER.md). Per-fixture results:
`<cache>/scoreboards/gpt5parallel.tsv` (written by `scripts/test.ps1 -Mode gpt5parallel -Record`).

The core builds on its own in ~4-5 min (host-only changes ~35 s) with `scripts/build.ps1 -Mode gpt5parallel`,
and fixtures run in seconds with `scripts/test.ps1 -Mode gpt5parallel -Suite frontier`. Compile the full
`apps/spiral` app only after the ladder in `AGENTS.md` is green.

## Run logs

The gpt5parallel core writes a `<timestamp>.jsonl` log (HUD frames, projections, captured exceptions; 4-60 MB)
next to the source it was compiled from. `scripts/build.ps1` compiles a staged copy, so these logs land
in `<cache>/core-src/gpt5parallel/`, never in the tree. Per-job stderr is in
`<cache>/runs/gpt5parallel-<stamp>/worker*.log`. Find the real failure with
`Select-String '"kind":"runtime_exception_captured"' <log>.jsonl`; the rest is telemetry.
