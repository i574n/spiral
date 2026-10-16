# apps/tibia

A typed Tibia-rules simulator in Spiral, compiled to C, Rust and WGSL (GPU) from one source, used to train agents that
are measured against the best open-source Tibia bots on a public, reproducible benchmark: the **OT Agent Arena**.

## Status 2026-10-14

24 `.spi` files.
- **Rules:** geometry, vitality, coins, rng, cooldowns, damage, combat, creatures, wire.
- **Typed domain** (MODELING.md): quantity (phantom units), readiness (GADT witnesses), vocations (vocation-indexed
  spells), catalog (existential spawns), views (HKT `mapped` and `counted`), terrain (layouts, incl. the scanned arena spot).
- **Decisions:** policy, network (integer neural policy), search (evolution).
- **Simulators and entries:** hunt with its hunt_sim tests, hunting_pack (the multi-creature simulator) with its pack_sim
  and gpu_sim tests, and `live.spi` (the Lua entry for OTClient).

Tests name their targets with a reason: C as the oracle, WGSL for the GPU path, Lua for the live client, and Rust only
where a test needs the training host.

## Findings so far

Correction 2026-10-14: every live `spiral-*` run from 2026-10-13 11:48 until the fix ran with vBot's HealBot and TargetBot active alongside our policy (a bot setting the vBot probe left enabled; BENCHMARK.md, PR-1). The findings below come from the re-measurement on the fixed harness (PR-4, 30 runs per competitor, every run checked for foreign actions); the earlier live claims are withdrawn.

1. **The simulator predicts live clear times and, mostly, potion use.** Clear times matched in every live check.
   Potions took four corrections, each measured live or read from Canary's source: login protection keeps monsters off
   a fresh knight for 10 s; a simulator bug fielded three cyclops in small camps; monsters surround the knight instead
   of queueing (occupancy-aware routing, PR-7 holds out of sample); and monsters wander while the knight is protected,
   so every clear starts from a different geometry (before, every seed replayed one), with the cyclops swing pace
   measured at 2166 ms (`mirroring_the_live_arena`). Potions per unit of damage were always right; the misses were in
   hits taken. Against pooled live means the model now sits within the noise for rules and retreat at two and three
   cyclops (in-sample). Its out-of-sample check failed in one direction (PR-10): it predicted that preferring a monster
   already in reach costs 0.8 potions, and live it costs nothing (12.3 vs 12.5 for rules). Live, our policies drink
   alike; the model still reacts too strongly to targeting and retreat.2. **The policy designed in the simulator does not win live.** Stepping back when two cyclops reach the knight saved
   about 4 potions per clear in the first simulator; with monsters surrounding the knight as they do live, the saving
   shrinks to about 1 potion (5%), and live it uses 1.4 more than the plain rules (t 1.8, not significant).
   The earlier live win came from runs with vBot healing alongside.
3. **Our rules policy is level with vBot.** With enough runs (PR-9, 50 each, pre-registered) the
   Spiral rules policy drinks 12.5 potions per cyclops clear against vBot's 14.7 (difference -2.2, t -3.8), but the
   whole difference sits in the first 10 s: Canary ends a fresh login's protection when the player moves, turns, talks
   or uses an item, which vBot does and our probe does not, so vBot takes 9.1 hits in that window against our 1.6. After
   it the two take the same hits (60.1 vs 60.4). Re-tested with the protection ended for both (PR-11, 50 each): 14.4 vs
   14.8 potions, no difference shown (t -0.6), identical hits (69.1 vs 69.2). Our three policies drink alike live (rules
   12.5, ReachFirst 12.3, retreat 12.2). Against nExBot the retreat policy was narrowly better (12.2 vs 14.6 potions,
   PR-3a, t -2.14), but about half of that is the same login rule (nExBot talks right after login); a fair re-test is
   open. nExBot runs only with three harness shims (BENCHMARK.md PR-3a).
4. **Learning wins little at this level of detail.** In every scenario tried (open field, corridor, room,
   arena spot, mixed cyclops and trolls, potion budgets, respawning hunts) tuned threshold rules match or beat neural
   and scored learned policies. On a respawning hunting ground the rule that sweeps to the next spawn due beats every fixed
   route at a 60 s respawn, the evolved one included, but not at 30 s. With more
   monsters than the knight can fight at once, the tuned sweeping cavebot leads and the retreat rules trade experience
   for cost, and two knights coordinate best by simply following one shared rule together.

## Fidelity

Every mechanic comes from Canary's source or a live measurement, and the model is checked against both:

| Mechanic | Model | Live |
| --- | --- | --- |
| Knight's hits on trolls (kill hits capped at remaining health) | 9.37 per landed hit | 9.35 |
| Cyclops hits on the knight (truncated normal, then shield and armor blocks; one block charge per second, two at most) | 34.97 per landed hit, max 86 | 33.6, max 86 (forge off, full gear) |
| Knight step | 650 ms | about 650 ms (client speed 117) |
| Cyclops straight step, chasing or not | base step | 701-715 ms |
| Diagonal step | 3x straight | 3.0x (2109 vs 710 ms) |
| Ground speed | arena spot: 8% slower than grass; hunting ground: per tile from the server map (arena ground 160, road 100; a step costs the speed of the tile it starts from) | cyclops steps at the spot; PC-1: about 705 ms from arena ground and 455 ms from road (model 702 and 438); PC-2, pre-registered after the change: 452 ms per road step over 24 steps |
| Arena terrain | the server map (canary.otbm with appearances.dat), radius 30 around the spot | agrees with the live client scan on 251 of 252 cells |
| Client actions | one per 250 ms (a typed readiness witness) | the same gate wraps every competitor |
| Turn order | death checked before the knight acts | a knight killed by a hit cannot drink in the same tick |
| Tile occupancy | no two creatures share a tile; steps go around taken tiles | as in Canary |
| Pathing | arena spot: occupancy-aware routing with Canary's step weights (straight 10, diagonal 25, other creatures as obstacles), so monsters detour around each other; hunting ground: shortest path with straight steps only | Canary's A* (diagonal 25 vs straight 10); checked live (PC-1): a cyclops behind a wall takes exactly the router's straight-step path in all 5 runs, after idling 10-12 s |
| Monster wake | monsters neither move nor strike for the first 10 s of a live-mirroring scenario (`waking_at (live_wake_ms ())`); Canary's login protection (`isLoginProtected` blocks monster targeting) | the path check saw cyclops idle 10-12 s after the knight logs in; live, the standing knight takes 1.8 hits in its first 10 s against 7.9 simulated without the delay |
| Monster sight | a monster follows only a knight within 11 tiles on both axes on its floor; otherwise it idles | Canary's viewport (8 + 3, 6 + 5) |
| Monster idle walk | `wandering_while_idle`: until it targets the knight, a monster takes a random free cardinal step once 1000 ms have passed since its last move | Canary `Monster::doRandomStep`; PC-1 saw cyclops wander 0-7 steps during the 10 s login protection |
| Monster swing period | `meleeing_every (live_creature_strike_ms ())`: 2166 ms between swings of an adjacent cyclops | single-cyclops live runs: 28 of 30 gaps between landed hits are one swing, mean 2166 ms (Canary's 100 ms creature check runs a few ms late per cycle) |
| Knight swing after a step | `swinging_like_canary`: a step cancels the pending swing; it resumes at the next think or the next knight or target move once due | Canary `Player::onWalk`, `hasExtraSwing`; PC-3: 31 of 36 swing gaps spanning a step come late, mostly by 150-200 ms |
| Monster first swing | `meleeing_every_once_targeted`: a cyclops's first swing waits one swing period after it can target the knight | Canary: a monster's `attackTicks` starts at 0 when it acquires a target; live, the first hit lands about 3.4 s after login, simulated before at 0.2 s. Scored best against the six live potion means (sum of squared t 13.5 vs 16.7, none beyond 2) |

Live-mirroring model (2026-10-15): `mirroring_the_live_arena` turns on the four rules above that only matter live (wake,
idle walk, swing period, swing after a step), and `live_retreat_tactic` steps exactly like the live probe. Before it, every
seed replayed one geometry (fixed spawns, monsters frozen while the knight is protected), and the simulated knight escaped
along the corridor that the live knight rarely reaches; live, the retreating knight sits cornered in the dead-end pocket at
1936,1349 for 43% of the clear. Healing was never the gap: potions per 1000 hp of damage are about 5.8 live and simulated.
Against pooled live means (in-sample, these data shaped the rules): 3 cyclops rules 12.74 vs 12.22 potions, retreat 11.77 vs
12.62; 2 cyclops rules 4.83 vs 4.85, retreat 5.09 vs 5.45; every clear time within 2 s. The 3-cyclops ranking of retreat vs
rules is still off by about 1.4 potions (borderline). Under this model a lower heal threshold or a better standing tile saves
at most 0.3 potions per clear, so no live-runnable change to the rules policy is predicted to show live.
The 10 s wake and the idle walk describe the harness before 2026-10-15 14:17, when our probe kept the login protection. Since then the parity layer ends the protection for every competitor at login, so the matching scenario is `mirroring_the_live_arena |> waking_at 0` (no wake, so no idle walk); its first prediction (rules 15.6 potions, 72 hits) ran about 5% high (PR-11: 14.4, 69).

The multi-creature simulator is bit-exact on WGSL too (`gpu_sim.spi`: a full troll hunt, five arena-spot cyclops
clears, and a five-minute hunting-ground hunt with the shortest-path router and its scratch arrays). With parallel lanes (one seed per GPU thread, 2026-10-14) every lane matches C exactly; a launch costs about 4 s of fixed setup, then about 0.23 ms per arena clear against 1.6 ms on one C core, so the GPU pays off from about 4000 clears per launch. Large lane counts now run in chunks of 1024 (the 16384-lane hang, WGSL-LANES-LARGE-DISPATCH-HANG, is fixed in the pack-1e compiler).

## Simulator results

Protocol: everything is tuned on training seeds and judged on held-out seeds; the seed blocks are typed, so tuning on
held-out seeds does not compile. Claims are Pareto dominance on (kills, profit) or a cost within a stated time cap.
Profit books gold looted, 50 gp per potion and 14000 gp per death. The control is a random policy (each decision tick it drinks, engages, steps to a random tile or stands, with equal odds; once engaged the server keeps swinging, as live): on held-out seeds it earns 47610 experience on the hunting ground at -1.15 million gp, and clears the arena spot in 103 s with 79 potions per clear (one potion per second at most, as the server allows), far below every rule.

- **Targeting** (three-troll pack, 20 seeds): finishing the current target first gets 330 kills; fighting whatever is in
  reach gets 75 kills and 381 escapes. The live client switched to that order and killed all three trolls, where the old
  order killed one. A chasing policy gets 356 kills against 34 for a standing one (`hunt_sim.spi`).
- **Cyclops pack, open field** (100 training and 100 held-out seeds): healing below 130 dies; 170 and above tie at 950
  kills. Only the network warm-started from the cavebot tuned to heal below 160 dominates it, by 1550 gp at the same 955
  kills. Kiting now walks the knight out of the cyclops' sight (monsters see 11 tiles), so they stop following and it
  kills only 300.
- **Terrain is the lever.** In a one-tile corridor the same cavebot clears three cyclops with 6.5 potions and no
  deaths, against 15.3 potions and 3 deaths in 20 clears in the open field. In a room with a corridor, rules evolved
  on 100 training seeds (ReachFirst, heal below 223 + 3 per attacker, step back at three attackers) dominate the fully
  tuned cavebot on 100 held-out seeds: 946 kills and -288217 gp against 942 and -477181.
- **Arena spot** (the server map, radius 30, monsters routing around each other): rules evolved for the cheapest clear
  within the tuned cavebot's time +15% choose ReachFirst targeting, heal below 96 + 8 per attacker and stepping back as
  soon as one monster reaches the knight. On 100 held-out clears they use 1069 potions against the tuned cavebot's 1702
  (heal below 90), with no deaths for either, at 90.9 against 90.1 s per clear: cheaper, slightly slower, not dominant.
- **Mixed camp** (one cyclops, two trolls, arena spot): the cavebot tuned on this camp (heal below 80) uses 85 potions
  in 100 held-out clears at 37.7 s. Rules evolved on this camp without knowing kinds use 74 potions at 37.6 s with no
  deaths, dominating it; kind-aware rules use 68 but die once. Rules evolved for three cyclops use 190 potions; counting
  only attackers that stand and fight (`policy.temperate`: trolls flee, cyclops do not) cuts them to 135.
- **Hunting ground** (two cyclops and four trolls respawning every 60 s, the server map around the arena, five-minute
  hunts, 100 held-out seeds): greedy one-tile steps stick behind walls there, so knight and monsters route with a
  shortest-path search (straight steps only: a diagonal costs three straight ones, and Canary's A* agrees), and every
  step costs what the server's ground under it says (roads, speed 100, are 1.6 times faster than the arena ground,
  speed 160; measured live in PC-1, confirmed by the pre-registered PC-2). With the cavebot's heal tuned on training seeds (100), standing at the start earns
  89020 experience; a hand-drawn route 109700, a loop by the spawns 112470, a route evolved on training seeds with roads
  (a two-point shuttle between 121,86 and 117,102) 118720, and sweeping to the nearest live or next-due spawn 119760. The rule that reads respawn
  timers leads at this 60 s respawn and ties at 120 s, but at 30 s the fixed routes beat it (hand route 133170, shuttle
  133200, sweeper 126980): which walker is best depends on the respawn time.
- **Six cyclops on the hunting ground** (more than the knight can fight at once; 100 held-out hunts, each cavebot's heal
  tuned on training seeds): standing (heal below 110) earns 121050; sweeping the spawns (heal below 190) earns the most,
  138900, with no deaths at -254055 gp; on the standing cavebot's lower heal the sweeper dies 30 times along the fast
  roads. Stepping back at two attackers while sweeping (the live retreat rules) earns 127200 at -150159: about 8% less
  experience for 41% lower cost, a choice of objective rather than a better policy.
- **Two knights on the six-cyclops ground** (100 held-out hunts, party experience): the second knight acts through the
  same code (the simulator swaps which knight is acting), and monsters chase and strike the nearer one. Both knights
  sweeping together earn 259350 at -180187 gp; splitting the ground into two territories earns less (248550) at 30%
  more cost (-233638), because each knight then faces the cyclops alone. Rules evolved for the duo (heal below 117 + 6
  per attacker, never retreat) reach 261750 at -180890: within 1%, so one shared rule already captures the
  coordination.
- **Learned policies:** a 12-gene scored policy (heal, retreat, targeting weights, step weights) whose start genome
  reproduces the evolved rules found nothing better in 640 evaluations. With a 6-potion budget it clears 5.6% faster at
  the same deaths and potions, below the 5% cost bar. A respawning hunt with a potion budget does not separate policies
  either: above about 40 potions the budget never binds; below it the only decision that matters is when to leave,
  which a one-number rule captures.

## Live arena

PR-4 (2026-10-14, fixed harness): cyclops clear, BENCHMARK pack v1, full gear restored before every run, the same 250 ms
action gate and 100 ms decision tick for every competitor, heal below 160, 30 runs each, alternating, every run cleared,
no deaths, no harness failures. These runs predate the login-protection fix: vBot ended its protection at login and our probes did not, so the vBot row carries about 7 extra hits per clear (BENCHMARK.md PR-9 addendum; level on the fixed harness, PR-11).

| Competitor | Potions | Clear time | Damage taken |
| --- | --- | --- | --- |
| Spiral rules | 11.5 (sd 2.5) | 87.6 s | 2029 |
| Spiral retreat (designed in the simulator) | 12.9 (sd 3.2) | 91.3 s | 2217 |
| vBot 4.8 | 14.0 (sd 2.6) | 92.7 s | 2397 |

Pre-registered tests: retreat vs vBot, no difference shown (t -1.45); retreat vs rules, no difference shown (t 1.82).
Rules vs vBot, pre-registered as a fresh replication (PR-8, 30 runs each): 12.9 vs 14.2 potions, no difference shown (t -1.47); PR-4's 11.5 for the rules did not replicate. Rules vs vBot with 50 runs each (PR-9, 2026-10-15): 12.5 vs 14.7 potions, significant (t -3.80), clear time 88.7 vs 87.9 s, damage taken 2145 vs 2479; the whole difference comes from vBot ending its login protection in the first 10 s (BENCHMARK.md PR-9 addendum). With the protection ended for both (PR-11, 50 runs each): 14.4 vs 14.8 potions, no difference shown (t -0.58). Retreat vs nExBot 4.0.4 (PR-3a, 20 runs each, 2026-10-15): 12.2 vs 14.6 potions, significant (t -2.14), clear time 90.9 vs 88.4 s, damage taken 2030 vs 2421 (16 and 18 of 20 logs matched), no deaths. The random control (PR-5, 10 runs: drink, engage, random step or stand with equal odds) clears in 102.7 s with 94.1 potions, far below every competitor.

The earlier table, kept as a record of the faulty harness:
Measured with vBot's HealBot and TargetBot running alongside every `spiral-*` competitor (see the correction above); kept as a record until PR-4 replaces it. Cyclops clear, BENCHMARK pack v1: full gear restored before every run, the same 250 ms action gate and 100 ms decision
tick for every competitor, heal below 160 unless stated, no deaths in any round below.

| Comparison | Runs | Potions | Result |
| --- | --- | --- | --- |
| Spiral rules vs vBot | 6 / 6 | 14.7 vs 14.8 | tie |
| Spiral rules vs vBot, heal below 120 | 10 / 10 | 12.8 vs 13.2 | tie (t below 1) |
| Retreat vs Spiral rules | 23-24 each | 12.6 vs 15.5 | **retreat wins**: t -3.89; damage 2125 vs 2639, t -4.20; same clear time |
| Retreat with ReachFirst vs CurrentFirst targeting | 18 / 18 | 12.7 vs 13.4 | no difference (every t below 0.8) |
| Retreat vs vBot, pooled over three rounds | 47 / 42 | 12.6 vs 13.7 | level or slightly better: t -1.89; same clear time (90.7 vs 92.0 s) |

The first retreat-vs-vBot round alone looked significant (t -2.14); later rounds regressed toward a tie, which is why
comparisons are now pre-registered with a fixed run count.

Rounds before these measured harness faults rather than policies (and these rounds themselves carry the last one found, vBot left enabled during our runs): the forge inflating every monster, gear dropped on
deaths and never restored, vBot's HealBot ignoring a closed backpack, our probe deciding every 250 ms, the probe
leaving chase mode on during retreats, and the vBot probe sampling only every 10 s, which rounded vBot's clear times up
by about 5 s.

The live world, probes and arena scripts are in `C:\Users\i574n\tibia-local` (Canary 3.6.1, OTClient Redemption 4.1,
run off-screen and muted).

## Documents

- [PLAN.md](PLAN.md): phases, exit criteria, stop rules, costs.
- [BENCHMARK.md](BENCHMARK.md): the OT Agent Arena (fidelity, baselines, scenarios, metrics, pre-registrations, publication).
- [MODELING.md](MODELING.md): the game-domain types and what each one rules out, compiler gaps.
- [PRIOR_ART.md](PRIOR_ART.md): what mrakgr's poker work, TritCritNet and the other candidates taught us, with sources.
- [WORKFLOW.md](WORKFLOW.md): the source-first workflow Tibia dogfoods, and the gates before Tibia work starts.

## Ground rules

- One novelty at a time, each with its own benchmark: fidelity before training, training before scale.
- CPU and GPU runs of the same seed must agree bit for bit (integer simulation, counter-based RNG).
- Every claim names its baseline, its control (random policy) and its budget; nothing is promoted on rhetoric.
- CipSoft-derived data (map, sprites, items) stays local; the arena publishes code, scenario specs and seeds.
