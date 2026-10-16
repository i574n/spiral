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
- Same measurement rate: every probe watches health, experience and the clear every 100 ms. The vBot probe sampled every 10 s
  until 2026-10-14, which rounded vBot's clear times up by about 5 s and turned its lowest-health figures into snapshots.
- Same decision rate: a cap on actions does not equalize reaction time. vBot's HealBot macro runs every 100 ms; our
  probe decided every 250 ms in v1 and v2 and reacted later to damage bursts, so it now ticks every 100 ms too. The
  simulator's knight decides on its 100 ms tick (`hunting_pack.client_decision_ms`) behind the same 250 ms action
  witness (`readiness.action_gate`).
- Same login state: Canary keeps monsters off a freshly logged-in player for 10 s unless the player moves, auto-walks,
  turns, talks, uses an item or cancels an attack (starting an attack does not end it). Until 2026-10-15 14:17 our probe
  kept that protection and vBot and nExBot ended it, which decided PR-9 and half of PR-3a. Since then `parity.lua` makes
  one native turn 300 ms after login, outside the gate, for every competitor. Known remaining asymmetry: the policy
  probe acts from about 2.5 s after login, vBot at once; a test for a win should start every competitor's logic at the
  same moment.
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
| Spawn | 3 cyclops summoned by a GM standing at 1932,1352 with `/m cyclops,3,,2` (radius 2, so 1-5 tiles south of the knight at 1932,1349); no respawn. Corrected 2026-10-14 14:54: this row said "within 1 tile", which the harness never did |
| Parity | 250 ms action gap, 15x11 view, shared by every competitor |
| Healing | Potion below the simulator's profit-tuned threshold, the same for every competitor (100 from the corrected simulator); runs before 2026-10-13 15:00 are void: deaths dropped gear the reset did not restore |
| End | 675 experience (three kills at 225) or 200 s |
| Recorded | Clear time, potions, gold, deaths, lowest health, damage taken (from the kept logs) |
### Pre-registration PR-1 (written 2026-10-14 07:30, before any run)

| Item | Value |
| --- | --- |
| Question | Does the retreat policy use fewer potions than vBot in the cyclops clear? |
| Competitors | `spiral-retreat` (rules: heal below 160, step back from the nearest attacker at 2 attackers, ReachFirst targeting) vs `vbot` (vBot 4.8, TargetBot chase, HealBot potion below 160) |
| Scenario | Pack v1 cyclops clear, exactly as in the table above, both probes on the 100 ms watch that stops at the clear |
| Runs | 60 per competitor, alternating, one block (`run-arena.ps1 -Runs 60 -Competitors spiral-retreat,vbot`, results in `tibia-local/arena-results-cyclops-pr1.tsv`); a run that crashes is rerun once, then counted as missing |
| Primary metric | Potions per run, all runs (a death counts its potions too) |
| Test | Welch two-sided t-test, alpha 0.05; report the difference with its 95% interval |
| Secondary (descriptive only) | Damage taken, clear time, deaths, lowest health |
| Decision | Significant and negative: retreat uses fewer potions. Otherwise: no difference shown. No further runs are added to PR-1. |
| Analysis | `tibia-local/pr1-analysis.ps1`, written and validated on round v10 before any PR-1 result existed: Welch t with the Student quantile for its df, damage from logs matched one-to-one to result rows |
| Interruption (2026-10-14 09:36) | The host's memory reaper stopped the run after 22 complete pairs; the pair in progress wrote no row. It resumed with the same command and `-Runs 38` into the same file, so the count stays 60 each. Only row counts were read; nothing was computed. The resumed run copied a newer `apps/tibia` snapshot (simulator modules had changed), but `live.spi` compiles to byte-identical Lua from both snapshots (SHA-256 7FD3D538...93E5, the same `policy.lua` the probes load), and the vBot side predates PR-1's start (`probe-vbot-body.lua` last written 03:32, the vBot 4.8 sources under `otclient-src` 2026-10-12). |
| VOID (2026-10-14 10:29) | Stopped at 61 rows (31 retreat, 30 vBot). Mechanism: the vBot probe enables OTClient's bot for the character (`bot: Knight Sample_1511: enabled, config vBot_4.8` in the client's `config.otml`); nothing reset that setting, the vBot folder stayed installed, and the policy probe never disabled it, so every `spiral-*` run after a vBot run had vBot's HealBot and TargetBot running alongside our policy. Signatures: the server reports potions our policy never drank (13 potions against 6 heal notes in one run, the first potion before our first heal), and the parity gate counts more actions than our policy takes. A scan of every spiral log (`tibia-local/harness-check.ps1`) shows such foreign potions in almost every spiral run from 2026-10-13 11:48 on, and none in the three runs before. While diagnosing, the potion counts of four retreat-arm logs were read; the void rests on the mechanism, not on any comparison, and PR-1's rows are not pooled into anything. Replaced by PR-4. |
### Pre-registration PR-2 (written 2026-10-14 07:55, before any live mixed-camp run)

| Item | Value |
| --- | --- |
| Question | Does the simulator predict a live clear of a mixed camp (one cyclops, two fleeing trolls)? |
| Prediction | `hunting_pack.cyclops_and_two_trolls_on_the_arena_spot`, `cavebot_with_heal 160`, 200 simulated clears (seeds 5001-5200): 1.23 potions per clear (sd 0.93), 36.2 s per clear (sd 6.6 s), 0 deaths. Addendum 2026-10-14 08:31, still before any live run: the arena map grew from the client's +-7 window to the server map's radius 30, and the prediction is unchanged (the cavebot never leaves the window). Addendum 2026-10-14 10:42, still before any live run: recomputed after monster sight and the hunter record, 36.21 s (sd 6.59), 1.23 potions (sd 0.93), no deaths, and no troll escapes in 200 clears, so the flee-respawn suspect cannot explain a gap in this scenario |
| Live competitor | `spiral-policy` (rules, heal below 160, CurrentFirst targeting), the same knight and harness as pack v1 |
| Scenario | Arena spot, one cyclops and two trolls summoned like pack v1 (GM at 1932,1352, radius 2; corrected 2026-10-14 14:54 from "within 1 tile"); end at 285 experience (225 + 2 x 30) or 200 s |
| Runs | 20, one block, results in `tibia-local/arena-results-mixed-pr2.tsv` |
| Test | One-sample t of the live mean against the predicted mean, separately for potions and clear time, two-sided, alpha 0.05 (critical 2.09 at df 19) |
| Decision | Both within: the simulator predicts the mixed clear. Either outside: a fidelity gap, reported with its size; the known suspect is that the simulator respawns a troll that flees beyond 8 tiles, while live trolls flee and stay. |
| Harness (2026-10-14 14:54, before any PR-2 run) | Runs on the harness fixed for PR-4: rows with foreign potions or actions are excluded and listed (`-ExcludeForeign`), the policy Lua is the frozen PR-4 file. The 20 runs go in foreground chunks of 3 into the same file (the memory reaper only stops background shells), with nothing else running on this lane (2026-10-14 15:06) |
| RESULT (2026-10-14 15:46) | 20 runs, 0 harness failures, 0 deaths, every run cleared. Clear time holds: live 37.3 s (sd 7.8) vs predicted 36.2, t 0.62. Potions do not: live 0.55 per clear (sd 0.89) vs predicted 1.23, t -3.43. The same direction as PR-4's rules policy (the simulator lands about 10% too many hits on a standing knight, TIBIA-POTION-FIDELITY); the troll-escape suspect is out (no escapes predicted) |
| Analysis | `tibia-local/pr2-analysis.ps1` (written 2026-10-14 10:05, before any PR-2 run; exercised on round v6): one-sample t per metric with the Student quantile for n - 1, clear time over cleared runs only, deaths reported |

### Pre-registration PR-3 (written 2026-10-14 09:59, before any nExBot run)

| Item | Value |
| --- | --- |
| Question | Does the retreat policy use fewer potions than nExBot in the cyclops clear? |
| Competitors | `spiral-retreat` (as in PR-1) vs `nexbot` (nExBot 4.0.4 at 19632d4, network calls stubbed, TargetBot chase with the same arena targeting file as vBot, HealBot potion at health percent <= 30, which fires for health <= 159 of 515, the same as below 160) |
| Scenario | Pack v1 cyclops clear, as in PR-1 |
| Harness check | Before the block, at most 3 `nexbot` runs into `tibia-local/arena-results-cyclops-nexbot-check.tsv`, read only for: it attacks, it drinks, it clears or times out. Seeding may be fixed after them; these runs are never analyzed. |
| Runs | 30 per competitor, alternating, one block (`run-arena.ps1 -Runs 30 -Competitors spiral-retreat,nexbot`, results in `tibia-local/arena-results-cyclops-pr3.tsv`); a crash is rerun once, then counted as missing. 30, not 60, for the day's time budget: with the potions sd of earlier valid rounds (about 3), it detects about 2.2 potions (17%) at 80% power |
| Primary metric, test, secondary, decision | As in PR-1 |
| Analysis | `tibia-local/pr1-analysis.ps1 -Results <full path of arena-results-cyclops-pr3.tsv> -Baseline nexbot -Planned 30 -Label PR-3` |
| STATUS (2026-10-14 16:33) | Not run: nExBot crashed the client in all 3 check runs (0xC0000374 about 10 s after login; TIBIA-NEXBOT-CRASH). PR-3 stays registered as written for when nExBot runs |
| STATUS (2026-10-15 04:02) | Superseded by PR-3a: the check runs are spent, and nExBot runs only with the harness shims below |
### Pre-registration PR-3a, retreat vs nExBot (written 2026-10-15 04:02, before any PR-3a run; amends PR-3)

| Item | Value |
| --- | --- |
| Question | As PR-3: does the retreat policy use fewer potions than nExBot in the cyclops clear? |
| Harness shims (nExBot only, `run-policy-scenario.ps1 -Bot nExBot` and `probe-nexbot-body.lua`) | 1. Nested `dofile` inside the bot runs as pure Lua (`tibia-local/bot-lua-dofile.lua`: read, `loadstring`, `setfenv` to the bot's module environment); a missing file returns nothing instead of raising. The client's native dofile, and any error raised under nExBot's `pcall` around it, crash OTClient Redemption with 0xC0000374; nExBot's own `dofile("nExBot/targetbot/chase_controller.lua")` names a path that does not exist from the bot root. 2. The bot sandbox (`mods/game_bot/executor.lua`) also exposes getmetatable, rawset, rawget, rawequal, next, select, unpack and xpcall, which nExBot's event bus calls; vBot calls none of them. 3. `g_game.cancelFollow` does nothing while nothing is followed: Canary 3.6.1 clears the attack target on any follow packet (`Game::playerFollowCreature`) without telling the client, so nExBot's one cancel after its first attack left it standing next to a cyclops it never hit. 4. The probe counts nExBot's attack, cancel and movement calls (pass-through wrappers) |
| Seen before this registration | 16 diagnostic runs in `tibia-local/arena-results-cyclops-nexbot-diagnostic.tsv` while the shims were built (crashes, then no damage); one run with all shims: cleared, 86.1 s, 17 potions, no death. Not analyzed with PR-3a |
| Competitors | `spiral-retreat` (frozen PR-4 Lua) vs `nexbot` (as in PR-3, with the shims) |
| Scenario | Pack v1 cyclops clear, as in PR-4 |
| Runs | 20 per competitor, alternating, foreground chunks into `tibia-local/arena-results-cyclops-pr3a.tsv`; foreign-activity `spiral-*` rows excluded; a crash is rerun once, then missing. 20, not 30, for the night's time budget: with sd about 3 it detects about 2.7 potions at 80% power |
| Test | Potions per run, Welch two-sided, alpha 0.05, 95% interval (`pr1-analysis.ps1 -Treatment spiral-retreat -Baseline nexbot -Planned 20 -Label PR-3a -ExcludeForeign`) |
| Secondary (descriptive only) | Clear time, deaths, damage taken, nExBot's attack and cancel counts |
| Decision | Significant and negative: retreat uses fewer potions than nExBot. Otherwise: no difference shown. No runs are added |
| RESULT (2026-10-15 05:50) | 40 runs, 0 harness failures, 0 deaths, every run cleared. Retreat 12.20 potions (sd 3.94) vs nExBot 14.55 (sd 2.95), difference -2.35 (95% CI -4.58 .. -0.12), Welch t -2.14 (critical 2.03): significant, retreat uses fewer potions than nExBot. Narrow and single: retreat vs vBot was not significant in PR-4 (-1.10), and nExBot's mean is close to vBot's (14.00 in PR-4, 14.17 in PR-8). Descriptive: clear time 90.9 vs 88.4 s, damage taken 2030 vs 2421 (CI of the difference -748 .. -35; from the 16 and 18 of 20 logs the analysis matched to rows; all 20 retreat logs give 2110), lowest health 106.5 vs 95.4. The policy Lua compiled from live.spi on pack-1h after the block is byte-identical to the frozen file (7FD3D538...93E5). nExBot issued 3.2 attacks per run, no attack cancels, and the cancelFollow guard fired once in every run (without it, each run would have stood still next to its first target) |
| Addendum (2026-10-15 18:45, post-hoc, explanatory) | About half of the difference is the login-protection artifact found after PR-9: nExBot ends the knight's protection early (its probe saw one `talk` per run), taking 8.85 hits in the first 10 s against 3.45 for retreat; after 10 s nExBot still takes 4.7 more hits per clear (60.3 vs 55.6), about one potion, which no test has established. A fair re-test needs the PR-11 harness (protection ended alike) |
### Pre-registration PC-1, path check (written 2026-10-14 10:11, before any live run)

| Item | Value |
| --- | --- |
| Question | Does a cyclops walk around a wall the way the hunting-ground router predicts, where greedy one-tile steps get stuck? |
| Setup | Knight standing at server 1943,1338 (simulator 110,88), not attacking, bot disabled; one cyclops summoned next to 1948,1343 (simulator 115,93), on the other side of the room wall at x 1947 with the gap at 1948-1951 in row 1339 |
| Prediction | `terrain` routing on ArenaHunt from the logged start tile: 8-11 straight steps (9 from 1948,1343), arrival after steps x 702 ms (cyclops 650 ms on the 8%-slower arena ground). Greedy steps (the ArenaSpot model) never arrive from any of the 9 possible start tiles |
| Runs | 5 (`run-policy-scenario.ps1 -ProbeBody probe-path-body.lua -Monster cyclops -MonsterCount 1 -SpawnRadius 0 -SummonAt 1948,1343 -KnightAt 1943,1338`) |
| Decision | Arrives in every run with the predicted step count +-1: the router's path holds. Diagonal steps or a longer detour are reported with their count. Not arriving in 30 s: the router is wrong for this map |
| RESULT (2026-10-14 16:00) | 5 valid runs (3 earlier runs were harness failures: the probe read a nil position at login; fixed before the valid runs; `tibia-local/path-check-pc1.txt`). Every run arrives (14.9-17.0 s). In every run the cyclops first idles near its spawn for 10-12 s (0-7 wandering steps), then chases along exactly the router's path, north through the gap at x 1948 and west along y 1338: 9, 9, 9 and 8 steps from where the chase starts (predicted 9, 9, 9, 8; one run's start tile was not sampled). Greedy steps would never arrive: the router holds. Two new gaps: chase steps on row 1338 take about 455 ms against about 705 ms elsewhere (per-tile ground speed; the model uses one ground for the area), and monsters do not chase in the first ~10 s after the knight logs in |
### Pre-registration PR-4 (written 2026-10-14 10:39, before any PR-4 run; replaces the void PR-1)

| Item | Value |
| --- | --- |
| Questions | Primary: does the retreat policy use fewer potions than vBot? Secondary, named now: does retreat use fewer potions than our rules policy; does the simulator predict each Spiral policy's live clear? |
| Harness | Fixed 2026-10-14: the scenario writes the client's bot setting per competitor (disabled for `spiral-*`) and the policy probe disables the bot before login; every `spiral-*` row records foreign potions (server potions minus the policy's heal notes) and foreign actions (parity-gated actions minus the policy's own). One check run before PR-4: 14 potions, 14 heal notes, 0 foreign actions |
| Competitors | `spiral-policy` (rules, heal below 160, CurrentFirst), `spiral-retreat` (heal below 160, step back at 2 attackers, ReachFirst), `vbot` (as in PR-1); policy sources byte-identical to PR-1's (live.spi and policy.spi frozen) |
| Scenario | Pack v1 cyclops clear, as in PR-1 |
| Runs | 30 per competitor, alternating in that order, one block (`run-arena.ps1 -Runs 30 -Competitors spiral-policy,spiral-retreat,vbot`, results in `tibia-local/arena-results-cyclops-pr4.tsv`). A `spiral-*` row with foreign potions or foreign actions above 0 is a harness failure: excluded and listed, not rerun. A crash is rerun once, then missing. nExBot crashed the client in both PR-3 check runs (exit 0xC0000374 after login) and is not in this block |
| Primary test | Potions per run, retreat vs vBot, Welch two-sided, alpha 0.05, with the 95% interval (`pr1-analysis.ps1 -Baseline vbot -Planned 30 -Label PR-4`) |
| Secondary tests | Retreat vs rules potions, Welch (`pr1-analysis.ps1 -Treatment spiral-retreat -Baseline spiral-policy`); each Spiral policy against the simulator's current held-out prediction on the arena spot (100 clears, seeds 1001-1100): rules 13.23 potions (sd 2.52), 88.58 s (sd 12.63); retreat 9.09 potions (sd 1.83), 88.10 s (sd 12.86); no deaths (`pr2-analysis.ps1` one-sample t per metric) |
| Decision | As in PR-1 for each Welch test; a prediction holds when both one-sample tests are within the critical value. No runs are added after the block |
| Interruption (2026-10-14 10:58) | The host's memory reaper stopped the block after 2 complete triples (6 rows; a test suite was running alongside). It resumed with `-Runs 28` into the same file, nothing else running on this lane; only row counts and the harness columns were read |
| Frozen policy (2026-10-14 13:57) | A compiler install into the shared toolchain was announced mid-block, so from row 71 the scenario copies a frozen `policy.lua` instead of compiling `live.spi` per run; the file is byte-identical to the Lua every earlier run compiled (SHA-256 7FD3D538...93E5, printed in each run's log) |
| RESULT (2026-10-14 14:52) | 90 rows, 0 harness failures, 0 deaths, every run cleared. Primary: retreat 12.90 potions (sd 3.24) vs vBot 14.00 (sd 2.61), difference -1.10 (95% CI -2.62 .. 0.42), Welch t -1.45: no difference shown. Retreat vs rules: 12.90 vs 11.53 (sd 2.52), difference +1.37 (CI -0.13 .. 2.87), t 1.82: no difference shown, and the direction is against retreat. Predictions: rules clear time holds (87.6 vs 88.6 s, t -0.43) but potions do not (11.53 vs 13.23, t -3.69); retreat clear time holds (91.3 vs 88.1 s, t 1.33) but potions do not (12.90 vs 9.09, t 6.44). The simulator's retreat advantage does not exist live; its potion model is off in both directions (too many for rules, far too few for retreat). Descriptive: damage taken 2217 retreat, 2029 rules, 2397 vBot; clear time 91.3, 87.6, 92.7 s |
### Pre-registration PR-5, live random control (written 2026-10-14 10:46, before any run)

| Item | Value |
| --- | --- |
| Question | Where does chance play sit live, and does the simulator's random control predict it? |
| Competitor | `random-control` (`probe-random-body.lua`): every 100 ms it drinks a potion, engages the nearest monster (chase), steps in one of 8 directions, or stands, with equal odds; the same parity gate and harness checks as the Spiral competitors |
| Prediction | `hunting_pack.random_control` on the arena spot, 100 held-out clears capped at 200 s like the live timeout: 99 of 100 clear, 117.0 s per clear, 90.5 potions per run (sd 17.8), no deaths. The simulator's random control was corrected at 2026-10-14 10:46 to respect the 1 s potion cooldown before this prediction |
| Runs | 10, one block after PR-2 and PC-1 (`run-arena.ps1 -Runs 10 -Competitors random-control`, results in `tibia-local/arena-results-cyclops-pr5.tsv`); rows with foreign activity excluded as in PR-4 |
| Test | `pr2-analysis.ps1 -Competitor random-control -PredictedPotions 90.5 -PredictedSeconds 117.0 -Planned 10 -Label PR-5 -ExcludeForeign` (one-sample t, critical 2.26 at df 9) |
| Decision | Descriptive: the control's potions and clear time next to PR-4's competitors. Prediction holds when both one-sample tests are within the critical value |
| RESULT (2026-10-14 16:31) | 10 runs, 0 harness failures, 0 deaths, every run cleared. Potions 94.1 per clear (sd 7.5) against predicted 90.5 (t 1.53, holds); clear time 102.7 s (sd 12.0) against predicted 117.0 (t -3.75, gap). Next to PR-4 (11.5-14.0 potions) the control is far below every competitor. Likely cause of the time gap: live, once the knight attacks, the server keeps auto-attacking whatever the policy picks next, while the simulated control strikes only on the quarter of ticks where it picks engage. Addendum (2026-10-14 19:36, explanatory, after the result): the simulated control now keeps swinging once in reach; with the 10 s wake it predicts 103.4 s (live 102.7) and 81.1 potions (live 94.1), and the remaining potion gap points at the potion gate (TIBIA-POTION-FIDELITY) |
### Pre-registration PR-6, out-of-sample check of the monster wake delay (written 2026-10-14 17:13, before any run)

| Item | Value |
| --- | --- |
| Question | Does the simulator with the 10 s monster wake (`live_wake_ms`, a value taken from the PC-1 path check, not fitted to any clear) predict a clear it has never been compared with? |
| Scenario | Pack v1 with two cyclops instead of three (`/m cyclops,2,,2` by the GM at 1932,1352), end at 450 experience or 200 s |
| Competitor | `spiral-policy` (rules, heal below 160, CurrentFirst), frozen PR-4 Lua |
| Prediction (wake model) | `uniform_camp Cyclops` with size 2 on the arena spot, `waking_at (live_wake_ms ())`, 100 held-out clears: 8.25 potions (sd 2.42), 59.34 s (sd 10.09), no deaths |
| Alternative (no wake) | Same without the delay: 10.14 potions (sd 2.31), 58.80 s |
| Runs | 20, foreground chunks into `tibia-local/arena-results-cyclops2-pr6.tsv`; foreign-activity rows excluded |
| Test | `pr2-analysis.ps1 -PredictedPotions 8.25 -PredictedSeconds 59.34 -Planned 20 -Label PR-6 -ExcludeForeign`; the same for the no-wake numbers, reported alongside |
| Decision | The wake model holds when both its one-sample tests are within the critical value (2.09); the no-wake model's potion test is reported to show whether the data separate the two |
| RESULT (2026-10-14 18:00) | 20 runs, 0 harness failures, 0 deaths, every run cleared. Clear time holds (62.5 s vs 59.34, t 1.39). Potions fail for both models: live 4.85 (sd 1.27) vs 8.25 with the wake (t -12.0) and 10.14 without (t -18.7). Live the knight takes 30.7 hits per clear (32.9 damage each) against 43.4 simulated: the simulator overestimates how often adjacent cyclops land hits; with three cyclops (PR-4) that error was offset, so the wake delay alone does not explain the potion gap |
### Pre-registration PC-2, road speed check (written 2026-10-14 18:50, before any run)

| Item | Value |
| --- | --- |
| Question | Does the per-tile ground speed added after PC-1 predict a cyclops chase it was not fitted on? |
| Setup | Knight standing at 1943,1338 (simulator 110,88), bot disabled, not attacking; one cyclops summoned next to 1952,1338 (simulator 119,88), 9 tiles east on the same road (every tile of row 1338 from 1943 to 1954 is ground speed 100) |
| Metric | Mean duration of the cyclops's consecutive westward steps along row 1338 during its approach (`path t=` lines of `probe-path-body.lua`), pooled over runs |
| Prediction | `terrain.on_ground_at ArenaHunt` from a road tile: 438 ms per step. Alternative (one ground speed for the map): 702 ms |
| Runs | 5 (`run-policy-scenario.ps1 -ProbeBody probe-path-body.lua -Monster cyclops -MonsterCount 1 -SpawnRadius 0 -SummonAt 1952,1338 -KnightAt 1943,1338`) |
| Decision | The road model holds when the pooled mean is within 10% of 438 ms (394-482 ms) |
| RESULT (2026-10-14 18:58) | Holds. Pre-registered metric (westward steps on row 1338): 6 steps from run 1, mean 456 ms (453-459). In runs 2, 3 and 5 the summon placed the cyclops at 1950,1337 and it approached along row 1337, also road (speed 100); counting those, 24 road steps, mean 452 ms. Run 4 saw no monster in 30 s (summon failure, excluded). The uniform-ground alternative (702 ms) is far off; the model's 438 ms is 3-4% fast (`tibia-local/path-check-pc2.txt`) |
### Pre-registration PR-7, out-of-sample check of the occupancy-aware router (written 2026-10-14 23:29, before any run)

| Item | Value |
| --- | --- |
| Question | Does the simulator with the occupancy-aware router on the arena spot (`terrain.weighted_step`: Canary-style weights, straight 10, diagonal 25, other creatures as obstacles; adopted after PR-6 because live cyclops surround the knight and simulated ones queued behind each other) predict a clear it has never been compared with? |
| Scenario | Pack v1 with two cyclops (`/m cyclops,2,,2` by the GM at 1932,1352), end at 450 experience or 200 s |
| Competitor | `spiral-retreat` (heal below 160, step back at 2 attackers, ReachFirst), frozen PR-4 Lua (SHA-256 7FD3D538...93E5, copied, no compile) |
| Prediction (adopted model) | camp size 2 on the arena spot, `waking_at (live_wake_ms ())`, weighted router, 100 held-out clears: 4.67 potions per clear (sd 1.73), 59.70 s (sd 9.10), no deaths |
| Alternative (greedy steps on the spot, otherwise identical) | 3.49 potions (sd 1.42), 58.08 s |
| Runs | 20, foreground chunks into `tibia-local/arena-results-cyclops2-pr7.tsv`; foreign-activity rows excluded |
| Test | `pr2-analysis.ps1 -Competitor spiral-retreat -PredictedPotions 4.67 -PredictedSeconds 59.70 -Planned 20 -Label PR-7 -ExcludeForeign`; the alternative's numbers reported alongside |
| Decision | The adopted model holds when both its one-sample tests are within the critical value (2.09) |
| RESULT (2026-10-15 00:15) | Holds, narrowly. 20 runs, 0 harness failures, 0 deaths, every run cleared. Potions: live 5.45 per clear (sd 1.79) vs predicted 4.67, t 1.95 (critical 2.09); clear time 62.6 s vs 59.7, t 1.23. The greedy alternative fails (3.49 predicted, t 4.89). First out-of-sample potion prediction that holds; the live mean is still 0.8 potions above it |
### Pre-registration PC-3, a knight step delays the next swing (written 2026-10-15 06:24, before any PC-3 run)

| Item | Value |
| --- | --- |
| Question | Does a knight step make its next swing wait for the next 1 s think, as Canary's source says (`classicAttackSpeed = false`: the next swing is the player's next action task, `Player::onWalk` clears it, `Game::checkCreatures` calls `onAttacking` every 1000 ms) and as the opt-in camp rule `swinging_on_think` models? |
| Instrumentation | `probe-policy-body.lua` now stamps server texts and each retreat step with ms since the policy start (`@t+`); one smoke run (06:23, `arena-results-pc3-smoke.tsv`) checked the format and exercised the analysis; it is not PC-3 data |
| Runs | 5 `spiral-retreat` runs, cyclops clear as in PR-3a, into `tibia-local/arena-results-pc3.tsv` |
| Analysis | `tibia-local/pc3-analysis.ps1 -Logs <the 5 logs>`: consecutive landed knight hits (`due to your attack`), pairs with a kill between them excluded; residual = gap mod 2000 ms. Pairs with no step between them are the baseline; pairs with a knight step between them are the test. Missed swings are invisible but stay on the grid |
| Prediction | Baseline pairs on the 2000 ms grid (+-60 ms) at 90% or more; step-spanning pairs late by 60-1060 ms in at least half |
| Alternative (no rule) | Step-spanning pairs on the grid at about the baseline rate |
| Decision | The rule holds when both predictions hold; it fails when 80% or more of step-spanning pairs are on the grid. Known confound, reported not corrected: a target switch without a kill can also move the grid |
| RESULT (2026-10-15 06:37) | Holds. 5 runs (one did not clear: it retreated out of the fight, 23 retreats, 0 kills, the failure mode seen once in v6; its hits count). Baseline: 101 of 106 pairs on the grid (95.3%). Step-spanning: 31 of 36 late by 60-1060 ms (86.1%), 2 on the grid, 3 other. The delays cluster at 150-200 ms (median about 180 ms), not evenly over the think second: the swing mostly resumes sooner, likely through `hasExtraSwing` when a following cyclops moves next to the knight (`Creature::onCreatureMove`). The model's phase-0 think (about 500 ms on average) is the right direction and probably too long |
### Pre-registration PR-12, retreat vs nExBot on the fixed harness (written 2026-10-15 18:52, not yet run)

| Item | Value |
| --- | --- |
| Question | With login protection ended alike for both, does the retreat policy use fewer potions than nExBot in the cyclops clear? |
| Why | PR-3a found retreat 2.35 potions under nExBot (t -2.14), but about half of that is the login-protection artifact (nExBot talks after login); after the first 10 s nExBot still took 4.7 more hits per clear, about one potion, untested |
| Harness | As PR-11 (`parity.lua` ends the protection for every competitor at login) plus the nExBot shims of PR-3a; the policy probe skips floor-change tiles when it retreats (since 2026-10-15 12:45) |
| Competitors | `spiral-retreat` (heal below 160, retreat at 2, ReachFirst; frozen PR-4 Lua or live.spi if its compile is byte-identical, SHA-256 7FD3D538...93E5) vs `nexbot` (as in PR-3a) |
| Scenario | Pack v1 cyclops clear, as in PR-11 |
| Runs | 40 per competitor, alternating, foreground chunks into `tibia-local/arena-results-cyclops-pr12.tsv`; foreign-activity rows excluded; a crash is rerun once, then missing. With sd about 3 this detects about 1.9 potions at 80% power |
| Test | Potions per run, Welch two-sided, alpha 0.05, 95% interval (`pr1-analysis.ps1 -Treatment spiral-retreat -Baseline nexbot -Planned 40 -Label PR-12 -ExcludeForeign`) |
| Expectation, stated now | A smaller difference than PR-3a, likely not significant at this size |
| Secondary (descriptive only) | Clear time, deaths, damage taken, hits in the first 10 s, floor changes (any `,6` position) |
| Decision | Significant and negative: retreat uses fewer potions than nExBot. Significant and positive: nExBot uses fewer. Otherwise: no difference shown. No runs are added; no interim looks at potions |
### Pre-registration PR-11, rules vs vBot without the login-protection artifact (written 2026-10-15 14:21, before any PR-11 run)

| Item | Value |
| --- | --- |
| Question | With login protection ended the same way for both, does the Spiral rules policy use fewer potions than vBot in the cyclops clear? |
| Harness change | `tibia-local/parity.lua` (prepended to every probe) makes one native turn 300 ms after login, outside the parity gate, so Canary ends the 10 s login protection for every competitor alike. Check run (14:17-14:20, `arena-results-cyclops-pr11-check.tsv`, not analyzed): hits in the first 10 s 9 (rules) and 10 (vBot), against 1.6 and 9.1 per run in PR-9; 0 foreign actions |
| Competitors | `spiral-policy` (as in PR-9, frozen PR-4 Lua) vs `vbot` (as in PR-9) |
| Scenario | Pack v1 cyclops clear, as in PR-9, with the harness change |
| Runs | 50 per competitor, alternating, foreground chunks into `tibia-local/arena-results-cyclops-pr11.tsv`; foreign-activity rows excluded; a crash is rerun once, then missing |
| Test | Potions per run, Welch two-sided, alpha 0.05, 95% interval (`pr1-analysis.ps1 -Treatment spiral-policy -Baseline vbot -Planned 50 -Label PR-11 -ExcludeForeign`) |
| Expectation, stated now | No difference: after the first 10 s of PR-9 both took the same hits (60.1 vs 60.4) |
| Side prediction (2026-10-15 15:16, during the block, before any look at PR-11 data; not part of the pre-registration) | The live-mirroring model without a wake (`mirroring_the_live_arena |> waking_at 0`, no protection so no idle wandering), rules heal 160, 100 held-out clears: 15.63 potions (sd 2.88), 90.1 s, 72.4 hits, no deaths |
| Secondary (descriptive only) | Clear time, deaths, damage taken, hits in the first 10 s |
| Decision | Significant and negative: the rules policy uses fewer potions than vBot. Significant and positive: vBot uses fewer. Otherwise: no difference shown. No runs are added; no interim looks at potions |
| RESULT (2026-10-15 18:40) | No difference shown. 100 runs, 0 harness failures, 0 deaths, every run cleared. Rules 14.42 potions (sd 3.30) vs vBot 14.78 (sd 2.84), difference -0.36 (95% CI -1.58 .. 0.86), Welch t -0.58. Descriptive: clear time 88.3 vs 87.4 s, damage taken 2421 vs 2505, hits per clear 69.1 vs 69.2, hits in the first 10 s 9.6 vs 9.0. With the login protection ended alike, our rules policy and vBot are level; PR-9's win was the protection artifact. The side prediction (15.63 potions, 72.4 hits) is about 1.2 potions high (one-sample t about -2.6) |
### Pre-registration PR-10, out-of-sample check of the live-mirroring model (written 2026-10-15 12:57, before any run)

| Item | Value |
| --- | --- |
| Question | Does the live-mirroring model (`mirroring_the_live_arena`: wake, idle wandering, 2166 ms cyclops swings, swing after a step) predict a configuration it has never been compared with? |
| Competitor | `spiral-reach` (new in run-arena.ps1): the rules policy, heal below 160, ReachFirst targeting (prefer a monster already in reach), never retreats; frozen PR-4 Lua, whose targeting functions are the simulator's own `policy.spi` |
| Scenario | Pack v1 cyclops clear, as in PR-9 |
| Prediction (adopted model) | `tactic_with_order ReachFirst {160, 0, never_retreat}` on the arena spot with `mirroring_the_live_arena`, 100 held-out clears: 13.51 potions per clear (sd 3.14), 91.08 s, 63.8 hits taken, 1 death in 100 |
| Alternative (targeting makes no difference) | the CurrentFirst rules prediction, 12.74 potions, 90.74 s |
| Runs | 30, foreground chunks into `tibia-local/arena-results-cyclops-pr10.tsv`; foreign-activity rows excluded; a crash is rerun once, then missing |
| Test | `pr2-analysis.ps1 -Competitor spiral-reach -PredictedPotions 13.51 -PredictedSeconds 91.08 -Planned 30 -Label PR-10 -ExcludeForeign` (one-sample t, critical 2.05 at df 29); the alternative's potion t reported alongside |
| Decision | The model holds when both one-sample tests are within the critical value. With sd about 3.1 and 30 runs the test cannot separate 13.51 from 12.74 (standard error about 0.57); it is a calibration check, not a discrimination test |
| RESULT (2026-10-15 14:11) | Fails on potions. 30 runs, 0 harness failures, 0 deaths, every run cleared. Potions 12.30 (sd 2.73) vs predicted 13.51, t -2.43 (critical 2.05); clear time 89.1 s vs 91.1, t -0.86 (holds). The no-targeting-effect alternative fits (12.74, t -0.88). Live, our three policies drink alike (rules 12.46 in PR-9, ReachFirst 12.30, retreat 12.20 in PR-3a; damage 2110-2149 per clear), while the model spreads them over 11.8-13.5: it reacts too strongly to targeting and retreat |
### Pre-registration PR-9, rules vs vBot with enough runs (written 2026-10-15 08:13, before any PR-9 run)

| Item | Value |
| --- | --- |
| Question | Does the Spiral rules policy use fewer potions than vBot in the cyclops clear? |
| Why again | PR-4 (descriptive) and PR-8 (pre-registered) both point the same way (rules about 1.3 potions under vBot) with t near -1.5; each had 30 runs per side, enough only for about 1.9 potions. Pooling them after the fact gives t about -3.4, which is not a valid test; this block is |
| Competitors | `spiral-policy` (rules, heal below 160, CurrentFirst; frozen PR-4 Lua, SHA-256 7FD3D538...93E5, byte-identical to live.spi compiled on pack-1h) vs `vbot` (as in PR-4 and PR-8) |
| Scenario | Pack v1 cyclops clear, as in PR-4 |
| Runs | 50 per competitor, alternating, foreground chunks into `tibia-local/arena-results-cyclops-pr9.tsv`; foreign-activity rows excluded; a crash is rerun once, then missing. With sd about 3.3 and 2.7 this detects about 1.7 potions at 80% power |
| Test | Potions per run, Welch two-sided, alpha 0.05, 95% interval (`pr1-analysis.ps1 -Treatment spiral-policy -Baseline vbot -Planned 50 -Label PR-9 -ExcludeForeign`) |
| Secondary (descriptive only) | Clear time, deaths, damage taken; the live-mirroring model's rules prediction (12.74 potions, 90.7 s) next to the live mean, in-sample since PR-4 and PR-8 rules data shaped that model |
| Decision | Significant and negative: the rules policy uses fewer potions than vBot. Otherwise: no difference shown. No runs are added |
| RESULT (2026-10-15 12:42) | 100 runs, 0 harness failures, 0 deaths, every run cleared. Rules 12.46 potions (sd 3.07) vs vBot 14.66 (sd 2.71), difference -2.20 (95% CI -3.35 .. -1.05), Welch t -3.80 (critical 1.98): significant, the rules policy uses fewer potions than vBot. Descriptive: clear time 88.7 vs 87.9 s, lowest health 100.1 vs 100.0, damage taken 2145 vs 2479 (difference -334, CI -528 .. -140; 39 and 50 of 50 logs matched), so the saving is damage avoided, not healing. The live-mirroring model's rules prediction (12.74 potions, 90.7 s) sits within the live noise (in-sample) |
| Addendum (2026-10-15 14:20, post-hoc, explanatory) | The difference comes from the knight's login protection, not from hunting skill. Canary 3.6.1 ends a player's 10 s login protection on any own move, auto-walk, turn, speech, item use or attack cancel (`Game::playerMove`, `playerAutoWalk`, `playerTurn`, `playerSay`, `playerUseItem*`, cancel in `playerSetAttackedCreature`); starting an attack does not. Our probe only attacks in the first seconds and keeps the protection; vBot ends it. Hits taken in the first 10 s: vBot 9.14 per run, rules 1.58; vBot's whole excess is 7.2 hits per clear (69.2 vs 62.0). After the first 10 s the two are level (60.1 vs 60.4 hits). The verdict stands as computed, but it measures a scenario artifact: every run starts from a fresh login with cyclopes summoned next to the knight |
| Interim look (2026-10-15 10:37, disclosed) | At 25 of 50 pairs, a log query meant for a side question (do vBot's drinks get rejected?) pooled all logs since 00:23, so it printed potions per run for PR-8 and the PR-9 runs so far together. The run count stays 50 per side and nothing stops early, so the decision rule is unchanged; no further looks until the block ends |
### Pre-registration PR-8, rules vs vBot replication (written 2026-10-15 00:23, before any run)

| Item | Value |
| --- | --- |
| Question | Does the Spiral rules policy use fewer potions than vBot in the cyclops clear? Motivated by PR-4's descriptive, not pre-registered, numbers (rules 11.53, vBot 14.00 potions per clear): this is a fresh replication |
| Competitors | `spiral-policy` (rules, heal below 160, CurrentFirst; frozen PR-4 Lua) vs `vbot` (as in PR-4) |
| Scenario | Pack v1 cyclops clear, as in PR-4 |
| Runs | 30 per competitor, alternating, foreground chunks into `tibia-local/arena-results-cyclops-pr8.tsv`; foreign-activity rows excluded; a crash is rerun once, then missing. With PR-4's spreads (sd 2.5-2.6) this detects about 1.9 potions at 80% power |
| Test | Potions per run, Welch two-sided, alpha 0.05, 95% interval (`pr1-analysis.ps1 -Treatment spiral-policy -Baseline vbot -Planned 30 -Label PR-8 -ExcludeForeign`) |
| Secondary (descriptive only) | Clear time, deaths, damage taken |
| Decision | Significant and negative: the rules policy uses fewer potions than vBot. Otherwise: no difference shown. No runs are added |
| RESULT (2026-10-15 03:06) | 60 runs, 0 harness failures, 0 deaths, every run cleared. Rules 12.90 potions (sd 3.88) vs vBot 14.17 (sd 2.67), difference -1.27 (95% CI -2.99 .. 0.46), Welch t -1.47: no difference shown. PR-4's descriptive rules mean (11.53) did not replicate. Descriptive: clear time 92.6 vs 88.1 s, damage taken 2136 vs 2398 |
## Metrics

| Metric | Definition |
| --- | --- |
| XP/h | Experience per in-game hour |
| Profit/h | Loot value minus supplies, at a published price table |
| Deaths/h | Deaths per in-game hour |
| Score | XP/h subject to deaths/h at or below the best baseline's, reported with a confidence interval |

Every comparison is pre-registered: hypothesis, primary metric, test and run count are written down before the first run,
and the data is analysed once, after the last run. Interim looks are limited to counting completed runs. A comparison that
ends inconclusive is reported as such; a new comparison needs a new pre-registration.

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
- A death rarer than the training set can show is invisible to tuning. On the mixed camp, evolved rules saw 0 deaths in
  100 training clears and pushed the heal threshold down; held out they died twice, against the cavebot's once, and lost on
  cost. When deaths are near 1%, train on fresh seed blocks per generation (`search.evolve_vector_resampled`) or on several
  hundred seeds.
- Fix the number of runs before looking. The retreat policy 'beat' vBot after 20 runs (t -2.14) and 38 (t -2.36); 18 more
  runs brought it to t -1.89, a tie. Stopping when a result looks significant inflates claims.
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
