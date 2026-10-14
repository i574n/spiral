# Modeling

The bar is set by the five mega samples in `apps/compiler/tmp/samples` (surveyed 2026-10-12). The starting code is
mrakgr's graph library (`Spiral-s-ML-Library`, `ml/layers.spi`, `ml/cem.spi`, `ml/models.spi`).

## The mega samples

| Sample | Patterns worth reusing | Size |
| --- | --- | --- |
| `mega_brzozowski_derivatives` | GADT typestate (`raw -> decided`), existentials sealed only after their witness checks, length-indexed vectors and DFA rows, compile-time construction and minimization (`static_*` twins) emitted as a flat `i32` state machine, higher-ranked capabilities, native runs on C/Rust/Delphi, timing against Rust's `regex` crate | 77 files, 31 negatives |
| `mega_omniledger_erp_kernel` | Lifecycle typestate `erp_op from to result`, composable `erp_plan` with an existential middle, units in types (`money currency scale`, `quantity item uom`), `opposed_mirror_pair` conservation, `distinct3` quorum, FX routes composed through a middle currency | 47 files, 44 negatives |
| `mega_spiral_proves_spiral_relative_consistency` | Exact usage vectors (every variable used exactly once), context-indexed terms | 93 files, 90 negatives |
| `mega_zeta_structural_laboratory` | Binary type-level naturals, certified division, well-founded recursion through accessibility | 50 files, 47 negatives |
| `mega_lean_cic_bottom_up_kernel` | Definitional equality, metavariables, strict positivity | 43 files, 40 negatives |

## Graph code upgrades

His graph is already staged: sizes, partitions and memory plans are computed at compile time and only kernels run.

| His component | Upgrade |
| --- | --- |
| `get_dim` and size asserts | Today `graph t` types carry only the rank (`tensor (int * int * int) t`); sizes are compile-time values checked by `assert` during partial evaluation (`get_dim_pair`), so mismatches already fail before run time. Moving sizes into types (his corebase `sa dim el` already does it with type literals and `real_core.type_lit_to_lit`, through prototype instances) buys earlier errors at type-check, in the editor, and negative tests; size arithmetic (`modup`, products) then needs type-level operations, where zeta's binary naturals are the model |
| Planning pipeline | Typestate `graph raw -> graph planned -> graph frozen`; running an unplanned graph does not type-check |
| Existentials over intermediate types | Seal a node only after its shape witness checks; raw packing is a negative package |
| Storage reuse | Usage vectors: a workspace region is live once per step, weight gradients are written only by the training path |
| Game-to-tensor pickler | Encodes a typed per-agent view (below), so the input layout is checked by types |
| Kernel emission | Brzozowski's staged-DFA pattern: the compiler computes the plan and emits a flat loop over constants, to Rust and WGSL |
| CEM (`ml/cem.spi`) | Same algorithm, population 64-256 instead of 4 |
| Policy weights | Optional ternary weights {-1, 0, +1} packed 2 bits each (from TritCritNet): add/subtract instead of multiply, less memory traffic on CPU and WGSL |

Not ported: his CFR tables, CUDA-specific primitives (`corecuda`), heap closures on the device.

## Game-domain types

- `position` (x, y, z) with z in 0..15, `direction`, `creature_id`, `item_id`.
- Unions for damage types, conditions (burning, poisoned, paralyzed, ...), vocations, spell cooldown groups.
- Money with gold/platinum/crystal conversion as typed routes (ERP's `settlement_fx_route`).
- Loot, trades and supplies as mirror pairs, so value is never created by accident (ERP's `opposed_mirror_pair`).
- Character phase typestate: `idle -> hunting -> looting -> depositing`, plans composed like `erp_plan`.
- A typed per-agent view: only tiles on the agent's screen, so agents cannot read server state.
- Invariants as negative packages: HP above max, mana below zero, an item in two containers, a move through a wall.

## Typed domain in use (2026-10-13)

These replace the PhantomData simulations used in the Rust apps. Each module has negative tests (programs that must
not compile), C rows and a WGSL row, and the simulator uses them:

| Pattern | Module | What it rules out |
| --- | --- | --- |
| Phantom units (`nominal amount unit = i32`) | `quantity.spi` | Adding hitpoints to milliseconds; gold passed as health; `hunting_pack` keeps the player's health as `amount hitpoints` |
| GADT witnesses (`ready attack_group`, `ready healing_group`, `ready action_slot`) | `readiness.spi` | A Strike without an attack-readiness proof; a healing proof authorizing a strike; a potion or retreat step without a slot from the 250 ms parity gate (`action_gate`), so the simulator cannot act faster than the live client. Its first run found that the cooldown model shared one own-cooldown across spells (fixed, TIBIA-COOLDOWN-PER-SPELL) |
| GADT typestate (`vitality alive`, `vitality dead`) | `vitality.spi` | Healing a slain creature |
| Existential catalog (`entry = exists k. spawn k`) | `catalog.spi` | A troll spawn holding cyclops data; scenarios mix kinds (`hunting_pack` camps) |
| HKT prototype (`mapped f` over `f : * -> *`) | `views.spi` | Running the policy on a container without `mapped`; the same `decide_all` decides one observation (live client) or four lanes (GPU batch) |
| HKT prototypes `mapped` and `counted` over `one`, `lanes` and `trio` | `views.spi`, `hunting_pack.spi` | The pack holds its foes as `views.trio foe`; attacker counts and occupancy are `views.counted` folds, the same code that counts lanes on the GPU batch view |
| Distinct array nominals (`weights`, `inputs` over `a i32 i32`) and a `brain` union (`Rules adaptive` or `Network weights`) | `network.spi`, `hunting_pack.spi` | Feeding an observation where weights belong; a tactic that is neither a rule set nor a network; a weight addressed by raw index (`feature`/`output` unions and a `hidden` nominal name every slot, and an output passed as a feature is rejected). The typed slots replaced index arithmetic that had already produced one wrong slot |
| Unit-indexed objective GADT (`Kills :: objective kill_score`; `Profit`, `ProfitKeepingKills floor`, `CheapClearWithin limit :: objective gold_coins`; `measured` returns `amount unit`), a `respawn_rule` union (`Respawning`, `Clearing`), hunt and clear ledgers, gold as `amount gold_coins` | `hunting_pack.spi`, `quantity.spi` | Adding a kill score to a gold amount (`kills_and_gold_do_not_add` fails to compile); tuning against one objective and scoring against another; adding potion counts to gold without pricing them (`quantity.scaled` keeps the unit); scalarizing kills and gold by accident |
| Typed `gear` record (`armor`, `defense` from Canary's formula and the item data) | `combat.spi` | Creature hits that ignore the defender's equipment |
| `layout` union (`OpenField`, `EastCorridor`) with a pure `blocked` function and occupancy closures | `terrain.spi`, `hunting_pack.spi` | Two creatures on one tile; steps through walls; a map stored as a heap array that WGSL and C loops would have to carry |

Limits found so far:
- Constructors are public, so a witness can be forged by calling `AttackReady` directly. Unforgeable witnesses need
  module-private constructors.
- Record update is structural: `{p with player_health = quantity.ms 150}` type-checks and makes a new record type.
  The unit error appears only where a `pack` is expected. State whose field types must not change should be a
  `nominal`, not a type alias.
- Existentials are compile-time only, by design. Mixed packs therefore choose their kinds statically (`camp`), and
  the kind dispatch resolves during compilation.

## Compiler gaps that block this

| Gap | Source | Effect |
| --- | --- | --- |
| WGSL storage arrays still lack bounds checks (unions, payload unions and record loops landed 2026-10-12/13) | WGSL-STORAGE-ARRAYS | Array-heavy GPU simulation waits for it; every Tibia module already has a WGSL test |
| Existentials are compile-time only on every backend | Brzozowski README, Open; by design (2026-10-13) | Fine for the staged graph; run-time state must be erased to plain integers |
| Constructors cannot be module-private | `readiness.spi` | GADT witnesses are a convention, not a guarantee |
| Record update needs a variable: `{(f x) with level = 1}` is a parse error | `hunting_pack.hunter_of` | A throwaway binding before every update of a computed record |
| C `create` leaves arrays uninitialized while Rust fills `Default` | C-ARRAY-CREATE-INIT; `network.filled` | Programs that read before writing differ across backends |

## Proofs (optional)

Bend 2 (`bendlang/bend`: dependent types, laws and proofs, targets C/Metal/CUDA/JS, no WGSL, young) or the existing
Lean backend could state rule invariants as theorems for the pure rules module. Adopt only if a proof catches a bug the
bit-exact diff tests miss. Spiral's Bend backend already targets Bend 2: the native tier runs
`toolchains/bend/bend2/main.ts` (`apps/compiler/tmp/scripts/env.ps1`, `BendMain`). Not yet checked: whether that
checkout matches the current `bendlang/bend` and whether the backend can emit `LAWS.bend` / `PROOF.bend`.
