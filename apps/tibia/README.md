# apps/tibia

A typed Tibia-rules simulator in Spiral, compiled to Rust (CPU) and WGSL (GPU) from one source, used to train agents
that are measured against the best open-source Tibia bots on a public, reproducible benchmark: the **OT Agent Arena**.

Status 2026-10-12: ten `.spi` modules with 66 test blocks (geometry, vitality, coins, rng, cooldowns, damage,
creatures, wire, hunt, hunt_sim), Rust + C on every rules test, WGSL status tests in 7 of 10 modules and one Zig test; all
pass through `apps/kino/spi/run_notebook.ps1` (cold run about 4-7 min under load, unchanged re-run 8.7 s with Kino's
result memo). `hunt_sim.spi` compares policies (scripted, tuned, random control, an evolution-strategy search) on Troll
and Cyclops scenarios built from `creatures.spi` and `damage.spi`. Local
Canary 3.6.1 world and scripted off-screen OTClient probes in `C:\Users\i574n\tibia-local` (`world.ps1`, `run-probe.ps1`).

## Decisions

| Decision | Choice | Why |
| --- | --- | --- |
| Domain | Tibia on our own OT server, never retail | Grid world, discrete actions, dense rewards: a far easier learning problem than poker; bots on official servers are banned |
| Protocol / server | Canary 3.6.1 (`opentibiabr/canary`, 2026-07-01, client 15.11, GPL-2.0), latest of everything | Actively maintained, prebuilt Windows release, ships the global map (`otservbr.otbm`); TFS 1.6 (2024) and 1.4.2 (2022) are stale |
| Client | OTClient Redemption 4.1 (`opentibiabr/otclient`, 2026-08-15) | Open C++20 engine with Lua modules, protocols up to 15.24 including Canary's, prebuilt Windows releases, LuaJIT is Lua 5.1 like Spiral's Lua backend |
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
