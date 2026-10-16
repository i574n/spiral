# Plan

Estimates are forecasts made 2026-10-12, not measurements. Prices: RTX 4090 about US$0.34-0.50/h on Vast.ai,
USD/BRL about 5.21 (BCB PTAX, 2026-09-28).

## Phases

| Phase | Work | Where | Exit criterion | Forecast |
| --- | --- | --- | --- | --- |
| P0 Compiler: WGSL data | Arrays as storage buffers, then unions as tagged structs, in `codegenWgsl` | laptop | `samples/` fixtures with arrays and unions agree with C on the Wgsl row (`tests/harness.psd1`) | 1-2 weeks |
| P1 Local world | Canary 3.6.1 (`canary-windows-cmake-release.zip`, map `otservbr.otbm`) + OTClient Redemption 4.1 (`otclient-windows-solution-opengl.zip`) + MariaDB, all prebuilt: no C++ build; the client needs the official 15.x client assets | laptop | Log in, walk, kill a creature: log in and walk met 2026-10-12 with scripted off-screen OTClient probes (`C:\Users\i574n\tibia-local`) on the small `data-canary` datapack; hits on trolls and a cave rat and a kill (a skeleton, experience +52) verified 2026-10-13; the 2026-10-12 "kill" had counted a creature leaving view | 1-2 days |
| P2 Typed rules | Hunt subset of Canary's rules as Spiral: grid and floors, creatures (melee, ranged, flee), cooldown groups, HP/mana, potions, loot, death penalty | laptop | Same seed gives bit-identical traces on Rust and WGSL; negative tests reject illegal states | 2-3 weeks |
| P3 Fidelity | Diff the simulator against Canary: deterministic mechanics exactly, RNG mechanics through a seeded Canary build or distribution tests of its formulas | laptop | Fidelity report per mechanic in BENCHMARK.md terms, every gap named | 2-3 weeks |
| P4 Baselines | OTClient harness layer (rate cap and 15x11 view for every competitor, BENCHMARK.md "Parity"); nExBot, vBot and the OTCv8 bot module run with author-tuned configs; a scripted cavebot; a random policy | laptop | Baseline table on the frozen scenario pack, with confidence intervals | 3-4 weeks (includes about a week of wall-clock evaluation, BENCHMARK.md "Evaluation cost") |
| P5 Agent | Port the graph code (MODELING.md), train with CEM (population 64-256, not 4) on the simulator, deploy inside OTClient as Lua from the same Spiral source | laptop, then rented 4090 | Agent beats every baseline on the pack under the declared budget, random control stays at chance | 3-6 weeks |
| P6 Arena release | Publish scenario specs, server build recipe, seeds, harness, baseline results; invite bot authors | - | Public repo and results page | 1-2 weeks |
| Later | 2048 record attempt on the same framework (n-tuple TD + expectimax) | rented 4090 | Average > 625,377 and >= 72% reaching 32768 over a confidence interval | 6-10 weeks |

Total to P6: about 3.5-4.5 months.

## Where each phase stands (2026-10-14)

| Phase | State |
| --- | --- |
| P0 | Met for the simulator: arrays, unions and records run on WGSL, and the multi-creature simulator is bit-exact against C (`gpu_sim.spi`). Parallel lanes installed 2026-10-14: one seed per GPU thread, bit-exact with C, ~4 s fixed per launch then ~0.23 ms per arena clear (7x one C core); worth it from ~4000 clears per launch; large lane counts run in 1024-lane chunks since pack-1e. |
| P1 | Met: login, walk, kills, potions, summons and resets all scripted off-screen; the server map is readable (`tibia-local/otbm-walkability.py`). |
| P2 | Met for the hunt subset: melee, blocks and block charges, fleeing, cooldowns, potions, loot, death costs, terrain and occupancy; bit-identical C and WGSL traces; negative tests for illegal states and protocol misuse. Ranged creatures and mana are not modeled yet. |
| P3 | Mostly met: every modeled mechanic has a source or a live measurement (README "Fidelity"); the clean live check (PR-4, 2026-10-14) confirms clear times for both Spiral policies but not potion use: the simulator predicts 13.2 and 9.1 potions where live uses 11.5 and 12.9 (TIBIA-POTION-FIDELITY). Open: the fleeing-troll respawn rule (PR-2 tests it). |
| P4 | Partly met: vBot runs under the parity layer with seeded configs; a scripted rules policy and a retreat policy compete; pre-registered comparisons with fixed run counts (BENCHMARK.md PR-4 done: retreat vs vBot no difference shown; PR-1 void: vBot ran alongside our policy in every spiral run since 2026-10-13 11:48, now fixed in the harness and checked per run). nExBot 4.0.4 runs since 2026-10-15 with three harness shims (pure-Lua nested dofile, fuller bot sandbox, cancelFollow guarded against Canary's follow packet clearing the attack); PR-3a: retreat used fewer potions than nExBot (t -2.14), about half of it from the login-protection artifact. PR-9 showed rules beating vBot (t -3.80) only through that artifact; with the protection ended for every competitor in the parity layer, PR-11 shows them level (t -0.58). The OTCv8 bot module is not set up yet. |
| P5 | Stop rule reached for the current scenarios: learned policies (an integer network, a 12-gene scored policy, evolution with fresh seeds) tie or trail tuned threshold rules everywhere tried. Per the stop rule this means re-planning the scenario design, not more compute. First re-plan done 2026-10-14: a respawning hunting ground on the real map with shortest-path movement. The timer-aware sweeping rule beats every fixed route at a 60 s respawn (not at 30 s), including one evolved on training seeds, and with six cyclops the tuned sweeping cavebot leads. Second re-plan the same day: two knights; moving together on one shared rule is within 1% of rules evolved for the pair, so the stop rule holds there too. What is left: scenarios where information is hidden (unseen spawns, other players), or a richer action set (spells, mana, ranged monsters). |
| P6 | Not started. |

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
