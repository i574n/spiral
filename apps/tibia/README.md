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
  cavebot's time +15% on 100 training clears keep CurrentFirst targeting and step back from the nearest attacker (the live retreat competitor uses ReachFirst);
  on 100 held-out clears they use 852 potions and no deaths against the cavebot's 1309 and 1 death, at 91.8 s vs 88.6 s
  per clear: a third fewer potions for 4% more time, a trade inside the cap rather than dominance.
- A mixed camp on the arena spot (one cyclops, two trolls): the rules evolved for three cyclops (heal below 143 + 34
  per attacker, step back at one attacker) use 204 potions in 100 held-out clears at 40.8 s, against the cavebot tuned
  on this camp (heal below 70): 80 potions, 1 death, 37.9 s. Counting only attackers that stand and fight
  (`policy.temperate`: trolls flee, cyclops do not) cuts the same rules to 158 potions at 40.5 s. Rules evolved on this
  camp's training clears with the same budget, kind-blind or kind-aware, settle on a lower heal (74 and 76 potions,
  37.8 s) but die twice, so nothing dominates the tuned cavebot. With one cyclops nearly every potion is drunk while it
  is adjacent, which leaves kind-aware healing little to save.
- Golden seed 7 runs on WGSL with the same numbers as Rust.
- Live arena, cyclops clear (BENCHMARK pack v1, full gear restored before every run, same 250 ms action gate and 100 ms
  decision tick, heal below 160, no deaths in any round below):
  - Spiral rules and vBot tie: 6 of 6 clears each, 14.7 vs 14.8 potions. At heal below 120 they tie again (10 runs each:
    12.8 vs 13.2 potions, 84.4 vs 88.8 s, t below 1).
  - The simulator, given the arena spot's scanned terrain, predicts that clear at 85.0 s, 12.4 potions and no deaths.
  - Stepping back at two attackers saves 29% of potions in the simulator. Live, against the rules policy (23-24 runs each),
    it takes 19% less damage (2125 vs 2639, Welch t -4.20) and uses 19% fewer potions (12.6 vs 15.5, t -3.89) at the same
    clear time (88.6 vs 91.7 s), once the probe stopped leaving chase mode on.
  - Against vBot the retreat policy is level or slightly better, not yet a proven win: over three rounds (47 vs 42 runs) it
    uses 8% fewer potions (12.6 vs 13.7, Welch t -1.89) at the same clear time (90.7 vs 92.0 s), and in the two rounds where
    both probes measure identically it is 13.0 vs 13.6 (t -0.75). The first round alone looked significant (t -2.14); the
    later rounds regressed toward a tie. Its 19% saving over our own rules policy is solid.
  - Retreating with ReachFirst or CurrentFirst targeting makes no measurable difference live (18 runs each, every t below 0.8).
  - Earlier rounds measured harness faults, not policies: the forge inflating every monster, gear dropped on deaths and never
    restored, vBot's HealBot ignoring a closed backpack, our probe deciding every 250 ms, and the vBot probe sampling only every
    10 s, which rounded vBot's clear times up by about 5 s and made its lowest-health figures snapshots (fixed from v8 on).
  - Measured live and matching the model: a cyclops's diagonal step costs 3.0x a straight one (2109 vs 710 ms).
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
