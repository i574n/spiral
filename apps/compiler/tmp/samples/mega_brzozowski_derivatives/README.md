# Spiral Brzozowski derivatives mega-sample

Current codebase-relative SOTA: **895/1000** (external theorem trust 125/230; see `ledgers/SOTA_RATINGS.tsv`).

This fifth mega-sample implements Brzozowski derivatives over nominal finite alphabets with canonicalization, finite closure/minimization, generic GADT typestate, verified-only existentials, higher-ranked capability programs, length-indexed finite symbol vectors/DFA rows, structural Antimirov provenance, suffix-independent derivative witnesses, a typed Antimirov support-slot bound and an independent direct F# semantic oracle.

The current Antimirov bound no longer relies only on a value-level `support <= positions+1` counter. `antimirov_typed_slot_bound/` carries an explicit `antimirov_position_tree alphabet shape` GADT whose shape has one `OriginSlot` path for every `RegexChar` position. The finite support universe is `SupportSlotRoot | SupportSlotOrigin (antimirov_origin_slot shape)`. The certificate proves the typed tree reconstructs the normalized source, its leaf budget equals `regex_position_count`, the actual support is distinct, and every residual resolves to one typed root/origin slot. A same-cardinality forged tree is rejected.

A branch-built `exists shape` tree constructor remains a rejected compiler boundary: it typechecks but F# emission attempts to dyn the existential. The promoted surface therefore accepts the tree witness explicitly and verifies it. Recursive `inl rec` over runtime recursive data is not an acceptable staging form: the sealed predecessor typechecks but stack-overflows prepass. The promoted exact-DFA route uses local runtime `let rec` join points while keeping indexed proofs/matrix data statically captured, and now emits/executes.

The earlier near-1000 codebase-relative closure claim is retired. Internally constructive DFA/minimality is now stronger still: the finite-inventory path carries exact symbol and state cardinalities into an alphabet-erased compiled core with an exact start index, acceptance vector and total in-closure transition matrix, followed by a replay-verified existential typestate. The current dynamic backend cannot yet codegen that deepest finite-index GADT surface, so backend breadth, derivative/normalization theorem trust, Antimirov elaboration and broader finite-domain generality remain materially open. `ledgers/SOTA_RUBRIC.tsv` is the scoring authority; absence of a known counterexample is not completion credit.

## Layout

This sample was developed on its own lane, so it keeps its handoff material next to its source instead of in the workspace-wide root documents.

- `main.spi`, `package.spiproj` and the sibling package directories: the sample itself, its proof suite, compiler probes and `negative_*` fixtures.
- `docs/`: `RESUME.md`, `ROADMAP.md`, `COT.md`, `RELEASE_REPORT.md`, `ARCHITECTURE.md` and `COMPILER_COMPATIBILITY.md` for this sample.
- `ledgers/`: `SOTA_RUBRIC.tsv`, `SOTA_RATINGS.tsv`, `AGILE_PRIORITY.tsv`, `agile.tsv`, `BENCHMARK_CURRENT.tsv`, `BENCHMARK.tsv`, `RATING_DELTA_GATE.tsv`, `loc-language.tsv`, `ratings.jnl` and the lane's `agile_eoie.md`.
- `state/`: the lane's typed state modules (`toolchain_identity.spi` pins the accepted compiler companion) and lifecycle matrices. They are reference copies; the workspace state package in the root `state/` does not compile them.

Related workspace paths: `proof-export/brzozowski-derivative/` (Lean export and custody verifier), `tools/brzozowski-proof-replay/` (proof replay tool), `patches/brzozowski-*.patch.spi` and `patches/companion-gadt-local-tag-candidate.spi`.
