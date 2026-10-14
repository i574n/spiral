# apps/tibia

A typed Tibia-rules simulator in Spiral, compiled to Rust (CPU) and WGSL (GPU) from one source, used to train agents
that are measured against the best open-source Tibia bots on a public, reproducible benchmark: the **OT Agent Arena**.

Status 2026-10-13: 23 `.spi` files.
- **Rules:** geometry, vitality, coins, rng, cooldowns, damage, combat, creatures, wire.
- **Typed domain** (MODELING.md): quantity (phantom units), readiness (GADT witnesses), vocations (vocation-indexed
  spells), catalog (existential spawns), views (HKT `mapped` and `counted`), terrain (layouts, incl. the scanned arena spot).
- **Decisions:** policy, network (integer neural policy), search (evolution).
- **Simulators and entries:** hunt with its hunt_sim tests, hunting_pack (the multi-creature simulator) with its pack_sim
  tests, and `live.spi` (the Lua entry for OTClient).

Tests name their targets with a reason: C as the oracle, WGSL for the GPU path, Lua for the live client, and Rust only
for the training host. Fidelity comes from Canary's source and live runs:
- **Combat:** truncated-normal melee roll, defense and armor blocks, fight-mode attack factor.
- **Creatures:** armor, defense, flee health and step durations, from data-canary and Canary's step formula.
- **Live comparison:** the knight's hits on trolls land 9.35 live vs 9.37 in the model (kill hits capped at remaining health);
  cyclops hits on the knight land 33.6 live vs 34.97 in the model (forge off, full gear).

`hunt_sim.spi` runs 5-minute hunts with fleeing and chasing. Results:
- A chasing policy gets 356 kills vs 34 for a standing one over 20 seeds.
- In `pack_sim.spi`'s three-troll pack, finishing the current target first gets 368 kills; fighting whatever is in reach
  gets 61 kills and 422 escapes. The live client switched to that order and killed all three
  trolls, where the old order killed one.
- Cyclops pack, with Canary's mechanics as measured live: truncated-normal hits through the knight's shield (one block
  charge per second, at most two) and armor, a 650 ms knight step, diagonal steps x3, chase steps measured live at the base step time, ground 8% slower than grass on the arena spot,
  one client action per 250 ms (a typed readiness witness), death checked before the knight's turn, and tile occupancy
  (`terrain.spi`: no two creatures share a tile, steps go around taken tiles). Clean live runs (full gear) average 33.6 per landed hit,
  max 86, against the model's 34.97 and 86. The hunt is booked as
  gold, 50 gp potions and 14000 gp per death, on 100 training and 100 held-out seeds. Healing below 130 dies; 170 and
  above tie at 950 kills. On kills and profit together nothing dominates the cavebot tuned to heal below 160 (955 kills,
  -454093 gp) except, by 600 gp, the network warm-started from it (955 kills, -453493 gp); kiting earns far more
  (-165523 gp) but kills less (899).
- Terrain is the lever: in a one-tile corridor the same cavebot clears three cyclops with 6.5 potions and no deaths, against
  15.3 potions and 3 deaths in 20 clears in the open field (`pack_sim.spi`). In a room with a corridor, retreating into
  the corridor when two cyclops reach the knight (ReachFirst targeting) halves potions and removes deaths in a clear; in a
  respawning hunt, rules evolved on 100 training seeds (ReachFirst, heal below 223 + 3 per attacker, step back at three
  attackers) dominate the fully tuned cavebot on 100 held-out seeds: 946 kills and -288217 gp against 942 and -477181.
- On the live arena spot's scanned terrain (`terrain.ArenaSpot`), rules evolved for the cheapest clear within the tuned
  cavebot's time +15% on 100 training clears choose ReachFirst targeting and stepping back from the nearest attacker;
  on 100 held-out clears they use 852 potions and no deaths against the cavebot's 1309 and 1 death, at 91.8 s vs 88.6 s
  per clear: a third fewer potions for 4% more time, a trade inside the cap rather than dominance.
- Golden seed 7 runs on WGSL with the same numbers as Rust.
- Live arena, cyclops clear (BENCHMARK pack v1, full gear restored before every run, same 250 ms action gate and 100 ms
  decision tick, heal below 160): Spiral rules and vBot tie, 6 of 6 clears each, 87.9 +- 14.3 s vs 90.0 +- 8.9 s, 14.7 vs
  14.8 potions, no deaths. The simulator, given the arena spot's scanned terrain, predicts that clear at 85.0 s, 12.4
  potions and no deaths. Stepping back at two attackers saves 29% of potions in the simulator. Live it first saved nothing (16 runs each:
  13.8 vs 14.4 potions, vBot 14.1) because the probe left chase mode on and the server walked the knight back to its target;
  with that fixed (v6, 23-24 runs each) it takes 19% less damage (2125 vs 2639, Welch t -4.20) and uses 19% fewer potions
  (12.6 vs 15.5, t -3.89) at the same clear time (88.6 vs 91.7 s): the simulator's direction at about two thirds of its
  size, and the first live win of a simulator-designed policy. One retreat run in 24 lost the fight. Earlier rounds measured harness faults, not policies: the forge inflating every monster, gear
  dropped on deaths and never restored, vBot's HealBot ignoring a closed backpack, and our probe deciding every 250 ms.
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
