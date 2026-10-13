# OT Agent Arena

A reproducible benchmark for agents that play Tibia (Canary 3.6.1, client 15.11) on a local OT server. The arena is the result we
publish; topping it is meaningful only because the baselines are tuned by their own authors, not by us.

## Three layers

| Layer | Measured against | Accuracy |
| --- | --- | --- |
| 1. Fidelity | Canary 3.6.1 as the oracle | Deterministic mechanics bit-exact; RNG mechanics through a seeded local Canary build, or distribution tests against Canary's damage and loot formulas |
| 2. Agent strength | Open-source bots (below), a scripted cavebot, a random policy | Frozen scenario pack, same server build, character, hunt and seeds; confidence intervals |
| 3. Public anchor (optional) | Craftax-Classic with the same agent architecture | Academic leaderboard; shows the agent is not overfit to our scenarios |

## Baselines

| Baseline | Source | Configuration |
| --- | --- | --- |
| nExBot | `github.com/mCodex/nExBot` (pushed 2026-09-01): Lua bot for OTClientV8 and opentibiabr OTClient; GitHub detects no license file (a mirror's README says MIT) | Author or community config per scenario |
| vBot | Ships inside `OTCv8/otclientv8` as the bot module's default config (`modules/game_bot/default_configs/vBot_4.8`); repository license `NOASSERTION` (custom LICENSE file); OTClientV8 stops at protocol 11.x, but OTClient Redemption 4.1 ships the same bot as `mods/game_bot` with `default_configs/vBot_4.8` and `cavebot_1.3`, so vBot runs on Canary's protocol | Its default config, tuned per scenario |
| Scripted cavebot | Ours: heal below X% HP, attack nearest, walk waypoints | Fixed thresholds, published |
| Random policy | Ours: uniform over legal actions | The control; anything that "learns" must leave it behind |

P4 checks before any baseline is used: the canonical repository, its author and license, that it runs against
Canary's protocol on the client we pair it with, and that its terms allow publishing results.

Bot authors may submit configs; the best submitted config per scenario becomes that scenario's baseline.

## Parity

Every competitor, ours included, plays under the same conditions, so a win cannot come from speed or extra sight:

- Same information: the client screen (15x11 tiles), even though the protocol sends 18x14; no server-side state.
- Same client: OTClient Redemption 4.1 for every competitor. The bots only run inside it, so our agent runs inside it too,
  as Lua compiled from the same Spiral source as the simulator.
- Same action-rate cap and the same 15x11 view, enforced by one harness layer inside OTClient that wraps every `g_game`
  action and observation, for bots and agents alike.
- Same character, equipment, supplies, scenario and seeds.
- Same server build and tick timing; no client-side speed hacks.

## Scenarios

A scenario is: server build hash, map region, spawn set, character (vocation, level, skills, equipment, supplies),
start position, seed, time budget. The pack is frozen and versioned; a change is a new pack version.

Scenario design must avoid saturation. On many hunts XP/h is capped by respawn rate, so a script and a perfect
player tie. Keep scenarios where decisions matter:

- mixed spawns (target choice, pulling, separating),
- danger (death is likely with poor healing or positioning),
- resource limits (mana, potions, capacity, a supply budget),
- route choice (several areas with different yield and risk).

A scenario where the scripted cavebot reaches the respawn cap is removed.

## Metrics

| Metric | Definition |
| --- | --- |
| XP/h | Experience per in-game hour |
| Profit/h | Loot value minus supplies, at a published price table |
| Deaths/h | Deaths per in-game hour |
| Score | XP/h subject to deaths/h at or below the best baseline's, reported with a confidence interval |

Runs are repeated across seeds until the interval separates the agent from the best baseline or the budget ends.

## Evaluation cost

The open-source bots run only inside a real OTClient against a real Canary server, so their runs take wall-clock time. Our
simulator runs faster than real time, but arena results always come from the real server so every competitor is
measured the same way.

| Quantity | Starting assumption (to measure in P4) |
| --- | --- |
| Scenario length | 30 in-game minutes |
| Runs per scenario per competitor | 10 seeds to start, more until the interval separates |
| Competitors | 5 (three bots, scripted cavebot, agent; random policy in the simulator only) |
| Parallel client+server pairs on the 16 GB laptop | 2-3 (measure memory per pair first) |

Example: 6 scenarios x 5 competitors x 10 seeds x 0.5 h = 150 hours of play, about 2-3 days at 2-3 pairs in
parallel per full pass. A second pass for tighter intervals doubles it. Rented CPU instances can run more pairs if
the laptop becomes the bottleneck.

## Promotion

From TritCritNet's control panel: an agent is promoted only when it beats the best baseline, the random policy stays at
its level (no luck), and the result reproduces on independent seed windows, all under a declared compute budget.

Tuning rules, from the first simulator runs (2026-10-13, `apps/tibia/hunt_sim.spi`):
- The agent and every baseline are tuned on the same training seeds and scored on held-out seeds.
- Use at least 20 training seeds. An evolution search on 6 seeds overfit: it scored 31 on held-out seeds where a
  cavebot scored 34.
- Never compare against hand-picked baseline settings. A hand-picked cavebot "lost" 34 to 90; the same cavebot,
  tuned on the training seeds, tied at 90.

## Publication

Published: harness, scenario specs, seeds, server build recipe, baseline configs, results. Not published: CipSoft
map, sprites or item data. The arena runs only on local OT servers.
