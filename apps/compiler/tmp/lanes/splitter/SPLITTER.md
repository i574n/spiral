# Disposable Spiral compiler splitter

The authoritative inputs remain the three single F# compiler files. Generated shards, projects, restore assets, local-lift plans and assemblies are disposable build artifacts and must never be patched as source truth.

The Rust workspace is divided into eighteen small crates: typed model, source loading/profile detection, declaration scanner, symbol/DAG analysis, split planner, F# emitter, metrics, layer build executor, demand-driven gap scheduler, release authority, LOC accounting, local capture analysis, parametric lifting plan, bounded rewrite, ordered batch rewrite, recursive lift funnel, transactional publication and CLI. Every authored Rust file and crate remains below 1,000 lines.

## Source families

The same CLI supports three independently fingerprinted profiles:

```text
pre-hopac
portable-fork
hopac
```

The portable fork retains the Rust and Delphi backend source and is the only compiler family whose generated binaries are release authority. Hopac splitting and typecheck artifacts remain experimental and are rejected by the release-policy gate.

## Split policies

Pre-Hopac and the portable fork default to one safe top-level declaration group per shard. Hopac recursively refines nested modules, then packs declarations from the same module up to 1,000 lines. Type groups, compiler directives and multiline lexical regions remain indivisible. Oversized `let rec ... and ...` chains can now be atomized at binding boundaries while preserving recursive SCCs, and oversized terminal matches can be rewritten into bounded fallthrough handlers before a second lift hop.

Project references use the closure-safe symbol DAG rather than the old all-prior graph. The direct graph remains available for diagnostics. Restore assets are generated once and seeded to all projects; `.build-cache` survives shard regeneration. Emission does not rewrite byte-identical source or project files, and the layer executor skips reference assemblies that are newer than their source, project and dependency outputs.

## Local and parametric lifting

`spiral-split local-lift` classifies local binding groups, captures and SCCs inside oversized declarations. It distinguishes capture-free functions, captured functions and unsupported bindings such as values, mutable bindings, inline bindings and complex binders.

`spiral-split parametric-lift` turns that analysis into an executable transformation plan:

```text
LocalLiftPlan<Classified>
    -> capture propagation through the SCC DAG
        -> canonical parameter order
            -> Hoist intents
            -> AddParameter intents
            -> ThreadArgument intents
```

Captures required only by a callee are propagated to its callers. A component depending on an unsupported component is blocked rather than silently hoisted across an invalid scope boundary. Recursive SCC members share one parameter order.

Every `emit` writes both `local-lift.tsv` and `parametric-lift.tsv`. `spiral-split rewrite-owner` consumes one eligible component, while `rewrite-owner-batch` consumes several non-overlapping components from one owner. `rewrite-owner-funnel` recursively atomizes a selected local function, partitions its largest terminal match into bounded handlers when necessary, lifts those handlers, and then promotes the resulting helpers through a second owner boundary. Immutable local values become explicit captures rather than false hoist dependencies. The composed portable candidate reduces `peval` from 2,124 to 570 lines, `term` from 1,810 to 256 lines and emits 749 shards with a maximum of 989 lines. Function-value uses, overlapping spans and ambiguous lexical forms remain fail-closed. Output publication uses synced temporary files, atomic rename, readback fingerprints and explicit rollback.

## Cargo authority

Dependencies are vendored and Cargo is configured fail-closed and offline. Required gates are:

```text
cargo fmt --all -- --check
cargo check --workspace --all-targets --locked --offline
cargo test --workspace --locked --offline
cargo clippy --workspace --all-targets --locked --offline -- -D warnings
cargo build --workspace --release --locked --offline
```

## Release authority

The release-policy gate requires the portable Rust/Delphi source, runner, facades and 53 canonical compiler parts. It rejects generated `PartNNNN.dll`, `SpiralCompilerSplitRoot.dll`, build-cache assemblies, split caches and Cargo `target` trees. The upstream `Hopac.dll`, `Hopac.Core.dll`, and `Hopac.Platform.dll` may be retained only as compatibility/runtime dependencies (canonically in `compiler-session/lib`) and never count toward compiler authority.

The intended workflow is:

```text
patch one authoritative F# monolith
    -> analyze
    -> emit disposable shards
    -> seed restore assets
    -> build bounded DAG layers
    -> discard generated split source
    -> publish only validated portable Rust/Delphi compiler binaries
```
