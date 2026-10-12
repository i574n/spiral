# Plan

Estimates are forecasts made 2026-10-12, not measurements. Prices: RTX 4090 about US$0.34-0.50/h on Vast.ai,
USD/BRL about 5.21 (BCB PTAX, 2026-09-28).

## Phases

| Phase | Work | Where | Exit criterion | Forecast |
| --- | --- | --- | --- | --- |
| P0 Compiler: WGSL data | Arrays as storage buffers, then unions as tagged structs, in `codegenWgsl` | laptop | `samples/` fixtures with arrays and unions agree with C on the Wgsl row (`tests/harness.psd1`) | 1-2 weeks |
| P1 Local world | Canary 3.6.1 (`canary-windows-cmake-release.zip`, map `otservbr.otbm`) + OTClient Redemption 4.1 (`otclient-windows-solution-opengl.zip`) + MariaDB, all prebuilt: no C++ build; the client needs the official 15.x client assets | laptop | Log in, walk, kill a creature: met 2026-10-12 with scripted off-screen OTClient probes (`C:\Users\i574n\tibia-local`) on the small `data-canary` datapack | 1-2 days |
| P2 Typed rules | Hunt subset of Canary's rules as Spiral: grid and floors, creatures (melee, ranged, flee), cooldown groups, HP/mana, potions, loot, death penalty | laptop | Same seed gives bit-identical traces on Rust and WGSL; negative tests reject illegal states | 2-3 weeks |
| P3 Fidelity | Diff the simulator against Canary: deterministic mechanics exactly, RNG mechanics through a seeded Canary build or distribution tests of its formulas | laptop | Fidelity report per mechanic in BENCHMARK.md terms, every gap named | 2-3 weeks |
| P4 Baselines | Headless protocol bot client (Rust or Spiral); nExBot, vBot and the OTCv8 bot module run with author-tuned configs; a scripted cavebot; a random policy; parity enforcement (BENCHMARK.md) | laptop | Baseline table on the frozen scenario pack, with confidence intervals | 3-4 weeks (includes about a week of wall-clock evaluation, BENCHMARK.md "Evaluation cost") |
| P5 Agent | Port the graph code (MODELING.md), train with CEM (population 64-256, not 4) on the simulator, deploy through the headless client | laptop, then rented 4090 | Agent beats every baseline on the pack under the declared budget, random control stays at chance | 3-6 weeks |
| P6 Arena release | Publish scenario specs, server build recipe, seeds, harness, baseline results; invite bot authors | - | Public repo and results page | 1-2 weeks |
| Later | 2048 record attempt on the same framework (n-tuple TD + expectimax) | rented 4090 | Average > 625,377 and >= 72% reaching 32768 over a confidence interval | 6-10 weeks |

Total to P6: about 3.5-4.5 months.

## Stop rules

- P0 is the gate for everything GPU: without arrays in WGSL there is no simulator on the GPU. If it stalls, P2-P5 run
  CPU-only and the GPU becomes a later speedup, not a blocker.
- P5: no gain over the best baseline after about 300 rented GPU-hours, or after the CPU-only agent plateaus below the
  scripted cavebot, means stop and re-plan (scenario design or method), not more compute.
- Any scenario where the scripted cavebot already reaches the respawn cap on XP/h leaves the pack: nothing can beat it there.

## Cost

| Item | Forecast |
| --- | --- |
| P0-P4 | R$0 (laptop) |
| P5 scale-out, 100-500 RTX 4090 hours | about R$180-1,300 |
| 2048 record attempt, 100-500 RTX 4090 hours | about R$180-1,300 |

Rental: Vast.ai (CLI and API cover create, ssh, copy, destroy; prepaid balance is the hard spending cap), RunPod as the
fallback. API keys live in environment variables or the Windows credential store, never in a repo. Each rental gets a
wall-clock limit, a watcher and auto-destroy on idle. Budget tranches (e.g. R$1,000) are approved by the user before
any rented hour. First rented hour checks that the host exposes Vulkan to the container (wgpu needs it).

## Order of work inside a phase

1. Write the types and the negative packages first (what must not compile).
2. Then the CPU path and its fixtures.
3. Then the WGSL path, checked bit for bit against the CPU path.
4. Then measurements, recorded with date, machine, load and command.
