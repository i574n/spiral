# apps/tibia

A typed Tibia-rules simulator in Spiral, compiled to Rust (CPU) and WGSL (GPU) from one source, used to train agents
that are measured against the best open-source Tibia bots on a public, reproducible benchmark: the **OT Agent Arena**.

Status 2026-10-13: twelve `.spi` modules (geometry, vitality, coins, rng, cooldowns, damage, combat, creatures, policy,
wire, hunt, hunt_sim) plus `live.spi` (the Lua entry). Every module has a WGSL test next to its Rust and C tests;
`policy.spi` also runs on Lua. Fidelity comes from Canary's source and live runs:
- **Combat:** truncated-normal melee roll, defense and armor blocks, fight-mode attack factor.
- **Creatures:** armor, defense, flee health and step durations, from data-canary and Canary's step formula.
- **Live comparison:** about 9.3 damage per landed hit live vs 10.7 in the model, not yet significant.

`hunt_sim.spi` runs 5-minute hunts with fleeing and chasing. Results:
- A chasing policy gets 343 kills vs 21 for a standing one over 20 seeds.
- The evolved policy ties a cavebot tuned on the same 20 training seeds: 90 vs 90 on held-out seeds, so no
  promotion. With 6 training seeds it overfit (31); against a hand-picked cavebot it looked like a win (90 vs 34).
  The two-threshold policy is saturated; next are policy features (TIBIA-POLICY-FEATURES).
- Golden seed 7 runs on WGSL with the same numbers as Rust.
- The C rows wait on C-SELF-TAIL-LOOP: C recursion overflows the stack at `-O0`.

The same `policy.spi` drives a live Knight inside OTClient: Lua compiled by Spiral, off-screen and muted, through
`C:\Users\i574n\tibia-local\run-policy-scenario.ps1`. It got its first verified kill on 2026-10-13. The local Canary
3.6.1 world and the probes are in `C:\Users\i574n\tibia-local`.

## Decisions

| Decision | Choice | Why |
| --- | --- | --- |
| Domain | Tibia on our own OT server, never retail | Grid world, discrete actions, dense rewards: a far easier learning problem than poker; bots on official servers are banned |
| Protocol / server | Canary 3.6.1 (`opentibiabr/canary`, 2026-07-01, client 15.11, GPL-2.0), latest of everything | Actively maintained, prebuilt Windows release, ships the global map (`otservbr.otbm`); TFS 1.6 (2024) and 1.4.2 (2022) are stale |
| Client | OTClient Redemption 4.1 (`opentibiabr/otclient`, 2026-08-15) | Open C++20 engine with Lua modules, protocols up to 15.24 including Canary's, prebuilt Windows releases, LuaJIT is Lua 5.1 like Spiral's Lua backend |
| Live harness | OTClient to the end; our policy runs inside it as Lua from Spiral's Lua backend | The bots only run inside OTClient, so a client of our own would break parity; training runs in the simulator, so the live client never has to scale (decided 2026-10-13, replacing a planned headless client) |
| Execution | Rust on CPU, WGSL on GPU, no CUDA | The laptop has no GPU; rented GPUs run WGSL through wgpu/Vulkan; integer simulation and table math need no tensor cores |
| Starting point | mrakgr's `Spiral-s-ML-Library` graph code (`C:\home\git\Spiral-s-ML-Library`, `ml/`) | A staged, typed tensor graph with compile-time size inference and memory planning, ensembles, CEM, sampling kernels |
| Modeling bar | The five `apps/compiler/tmp/samples/mega_*` samples | GADT typestate, verified-only existentials, indexed sizes, usage vectors, compile-time planning |
| Claim | "Best on the published OT Agent Arena" | No public Tibia-agent leaderboard exists, so we publish the benchmark and invite bot authors |
| Credibility anchor (later) | 2048 record (Guei: 625,377 average, 72% reach 32768) | Same framework, an undisputed external number |

## Documents

- [PLAN.md](PLAN.md): phases, exit criteria, stop rules, costs.
- [BENCHMARK.md](BENCHMARK.md): the OT Agent Arena (fidelity, baselines, scenarios, metrics, publication).
- [MODELING.md](MODELING.md): how the mega samples' patterns upgrade the graph code, the game-domain types, compiler gaps.
- [PRIOR_ART.md](PRIOR_ART.md): what mrakgr's poker work, TritCritNet and the other candidates taught us, with sources.
- [WORKFLOW.md](WORKFLOW.md): the source-first workflow Tibia dogfoods, and the gates before Tibia work starts.

## Ground rules

- One novelty at a time, each with its own benchmark: fidelity before training, training before scale.
- CPU and GPU runs of the same seed must agree bit for bit (integer simulation, counter-based RNG).
- Every claim names its baseline, its control (random policy) and its budget; nothing is promoted on rhetoric.
- CipSoft-derived data (map, sprites, items) stays local; the arena publishes code, scenario specs and seeds.
