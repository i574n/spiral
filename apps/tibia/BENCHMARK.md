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
  action and observation, for bots and agents alike. First version (2026-10-13, `C:\Users\i574n\tibia-local\parity.lua`):
  one action per 250 ms shared by every `g_game` action and `LocalPlayer.autoWalk`, and `g_map.getSpectators` returns
  only creatures on the 15x11 screen. It reports allowed and dropped actions per run. The gate answers only for itself:
  an admitted call returns true whatever the wrapped `g_game` call returns, so a probe can tell a dropped action from an
  admitted one.
- Same decision rate: a cap on actions does not equalize reaction time. vBot's HealBot macro runs every 100 ms; our
  probe decided every 250 ms in v1 and v2 and reacted later to damage bursts, so it now ticks every 100 ms too. The
  simulator's knight decides on its 100 ms tick (`hunting_pack.client_decision_ms`) behind the same 250 ms action
  witness (`readiness.action_gate`).
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

Pack v1, scenario "cyclops clear" (live through `tibia-local/run-arena.ps1`, simulated through
`hunting_pack.clear_run`):

| Part | Value |
| --- | --- |
| Server | Canary 3.6.1, data-canary, forge off (`forgeInfluencedLimit = 0`, `forgeFiendishLimit = 0`), rates 1.0 |
| Character | Knight Sample, level 30 (515 hp, 200 mana), axe 60, shield 11, steel axe, brass set, dwarven shield |
| Supplies | 100 health potions (266, heal 125-175); the whole inventory is deleted and re-inserted before every run |
| Spawn | 3 cyclops summoned within 1 tile of the knight; no respawn |
| Parity | 250 ms action gap, 15x11 view, shared by every competitor |
| Healing | Potion below the simulator's profit-tuned threshold, the same for every competitor (100 from the corrected simulator); runs before 2026-10-13 15:00 are void: deaths dropped gear the reset did not restore |
| End | 675 experience (three kills at 225) or 200 s |
| Recorded | Clear time, potions, gold, deaths, lowest health, damage taken (from the kept logs) |

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
- A baseline tuned to the edge of its range is not tuned. In the room-and-corridor scenario the cavebot's heal sweep (40-200)
  picked 200, and evolved rules 'won' by 81600 gp; with the sweep widened to 400 the cavebot tuned to 230 and the win
  vanished (-477181 vs -477431 gp). Sweeps now reach `hunting_pack.highest_tuned_heal`.
- Never compare against hand-picked baseline settings. A hand-picked cavebot "lost" 34 to 90; the same cavebot,
  tuned on the training seeds, tied at 90.
- Every design choice is also made on training seeds: kiting thresholds, network wiring, search budgets. In an early
  20-seed run, kiting lost on the training seeds but would have looked like a gain (1113 vs 1099) if picked on the
  held-out seeds.
- Training seeds must contain the rare events that decide the score. On the cyclops pack, 20 training seeds held no
  deaths, so every heal threshold tied and tuning picked one arbitrarily; 100 seeds hold 7 deaths and separate the
  thresholds (`pack_sim.spi`). The protocol constants live in `hunting_pack.spi` (`training_first`, `held_out_first`).
- That gap later closed for the right reason: once creature hits used Canary's blocks, deaths vanished at every
  threshold. A scenario that cannot separate policies is saturated, not solved; the cyclops pack is now judged on kills
  and profit together, and a policy beats the baseline only if it is at least as good on both and better on one
  (Pareto dominance). Training uses profit with the baseline's kills as a floor (`ProfitKeepingKills`).
- The arena world turns off Canary's forge (`forgeInfluencedLimit = 0`, `forgeFiendishLimit = 0`). With the default
  limits, almost every monster in the small world became influenced or fiendish, which raised cyclops hits from a
  34.7 mean to 61.8 and made runs incomparable.

## Publication

Published: harness, scenario specs, seeds, server build recipe, baseline configs, results. Not published: CipSoft
map, sprites or item data. The arena runs only on local OT servers.
