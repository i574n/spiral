# Prior art

## mrakgr's poker campaign (`C:\home\git\Spiral-s-ML-Library`, 654 commits, 2024-05 to 2025-12)

Goal: a strong heads-up no-limit hold'em agent trained entirely on the GPU, with games, network and training in one
GPU-resident Spiral loop. Spiral itself began (2017) to make a deep-learning library feasible.

What worked: Leduc and NL hold'em as GPU kernels with unions and closures, the typed staged graph with memory planning,
deterministic multi-block kernels (2024-10-11), tabular CFR on Leduc.

Why it failed, from the code and commit log:

1. The models could not learn hold'em. The CFR path hashed states through an untrained projection into 4,096 buckets;
   the CEM path evolved one linear layer with a population of 4; backpropagation was never wired into training.
   Commit `63ed6ed` (2024-10-14), after a 32-minute run against a calling station: "It's a failure."
2. No search at play time, which every superhuman HUNL system except AlphaHoldem uses.
3. Outcome-sampling variance over histories up to 128 actions.
4. No benchmark: judged against random players and a calling station, never exploitability (Leduc) or Slumbot.
5. Every layer new at once: language, compiler, kernels, training method, later a new approximator (Hopfield
   dictionaries, abandoned 2025-11-16).
6. One consumer GPU, then Sundays only. He moved to stock-trading tools in 2025-12 and, through 2026-02-05 (166 more
   commits, head `80d6a1a`), to synthetic market generators (activity-based price-volume GBM); `ml/`, `game/`, `hd/`
   and `corebase/` are unchanged since `d352f3c`, so the graph code studied here is current.

Lesson for this app: benchmark from day one, one novelty at a time, populations and methods sized to the problem.

## TritCritNet (bundles in `Downloads`, 2026-02-22 to 2026-06-18)

The start date is inferred from the bundle version stamp (`bundle_tritcritnet_v20260222-alpha650`, the same naming as
`eoie_v20260114`); the earliest surviving bundle is alpha650, written 2026-06-03. It started as a "CPU-native ternary criticality router" (Mamba, BitNet b1.58 and Titans ideas, W43/zeta/Lenia synthetic
curricula), was rescoped on 2026-06-03 into an EOIE critic ("a dependency of prioritization, not truth"), then
accumulated gating modules. Its learners solved self-made table-shaped tasks; its scores were often literals; it never
had an external benchmark. Mirror image of mrakgr: discipline without a yardstick.

Kept here: the oracle / baseline / random-control panel with independent held-out windows (BENCHMARK.md, Promotion),
and ternary weights (MODELING.md). Dropped: the W43, zeta and Lenia curricula.

## Candidate targets considered

| Target | Record | Why not first |
| --- | --- | --- |
| HUNL poker | AlphaHoldem about +111 mbb/hand and ReBeL about +45 mbb/hand vs Slumbot | 3-6 months, R$7-20k, hard domain, needs poker expertise |
| 2048 | 625,377 average, 72% reach 32768 (Guei) | Kept as the later credibility anchor (PLAN.md) |
| Tetris 10x20 | 51M lines (CBMPI), 35M (cross-entropy / BCTS) | Old benchmark, very expensive evaluations |
| Craftax | Craftax-1B challenge; most methods make little progress on full Craftax | Needs autodiff and PPO first; possible public anchor for the arena |

## Gemini chat on WoW/Tibia (`Downloads/chat.txt`)

Checked 2026-10-12. True: WoW Forever (launch 2026-11-04, level 60), Turtle WoW, Stormforge and Project Ascension
closed after Blizzard actions in 2026, `wow_messages` crate. False or stale: DirectX 12 in Legion (it arrived in BfA),
"QUIC-ready" netcode, "Data Boat Columns", Tibia NPC "structured windows", an LLM solving 469. Its WoW plans are out of
reach for a GPU-less laptop and legally unpublishable; its useful claim is that a discrete grid suits agents.

## Sources

- AlphaHoldem: https://ojs.aaai.org/index.php/AAAI/article/view/20394
- ReBeL: https://proceedings.neurips.cc/paper/2020/hash/c61f571dbd2fb949d3fe5ae1608dd48b-Abstract.html
- Optimistic TD learning for 2048: https://arxiv.org/pdf/2111.11090
- Tetris in machine learning (survey): https://arxiv.org/pdf/1905.01652
- Craftax: https://arxiv.org/pdf/2402.16801
- Bend 2: https://github.com/bendlang/bend
- Canary release with OTClient Redemption: https://newreleases.io/project/github/opentibiabr/canary/release/v3.6.1
- TFS 1.6 announcement: https://otland.net/threads/the-forgotten-server-1-6.289173/
- nExBot (mirror): https://verifico.duckdns.org/mCodex/nExBot
- RunPod vs Vast.ai 2026: https://www.spheron.network/blog/runpod-vs-vastai-2026/
