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

## Compiler gaps that block this

| Gap | Source | Effect |
| --- | --- | --- |
| WGSL has no arrays, unions, i64/u64, sub-word ints, globals, strings, closures | `apps/compiler/tmp/AGENTS.md`, WGSL backend section | No simulator on the GPU until arrays and unions land (PLAN.md P0) |
| Existentials are compile-time only on every backend | Brzozowski README, Open | Fine for the staged graph; run-time state must be erased to plain integers |
| A run-time GADT index stops partial evaluation (`compiler_probe_gadt_uninhabited_payload_runtime`) | Brzozowski README, Open | Typed indices exist only during compilation; compiled cores run on `i32` state |
| Prototypes are barely exercised (2 in Brzozowski, 0 in the others) | survey 2026-10-12 | "One source, CPU and GPU" through prototypes is unproven at this scale; the P2 rules module is its first real test |

## Proofs (optional)

Bend 2 (`bendlang/bend`: dependent types, laws and proofs, targets C/Metal/CUDA/JS, no WGSL, young) or the existing
Lean backend could state rule invariants as theorems for the pure rules module. Adopt only if a proof catches a bug the
bit-exact diff tests miss. Spiral's Bend backend already targets Bend 2: the native tier runs
`toolchains/bend/bend2/main.ts` (`apps/compiler/tmp/scripts/env.ps1`, `BendMain`). Not yet checked: whether that
checkout matches the current `bendlang/bend` and whether the backend can emit `LAWS.bend` / `PROOF.bend`.
