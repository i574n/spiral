# Splitter lane

`splitter/` is the `spiral-split` Rust workspace (82 small crates). It turns one
monolithic compiler core into many small F# projects ("shards", grouped into "gears" and dependency
layers) that `dotnet` can build in parallel and incrementally: after an edit only the affected gears and
their dependents rebuild. It supports three source profiles: `pre-hopac`, `portable-fork`
(single-flight) and `hopac`.

## When to use it

- **Locally (Windows/Linux):** not for clean builds. `scripts/build.ps1 -Mode hopac` compiles the 13 MB
  core as one project in ~4-4.5 min, and host-only edits rebuild in ~35-50 s. No split layout measured
  so far beats that on an 8-core machine (see "Build benchmarks" below). The remaining upside is
  incremental rebuilds after a local edit, which needs incremental emission first (a re-emit takes
  90-300 s and rewrites every part).
- **Browser sandbox:** when a single tool call cannot run a 4 min build, split the core and build it
  gear by gear across calls; every completed layer is checkpointed, so a timed-out call resumes instead
  of restarting.

## Parallelism metrics

`spiral-split bench`, `chain` and `gear-bench` report the shape of a split without emitting it:

| metric | meaning |
|---|---|
| `declaration_critical_path_lines` | floor: the heaviest dependency chain of individual declarations. No shard packing can beat it. |
| `critical_path_lines` | the heaviest chain through the shard graph, counting `PROJECT_OVERHEAD_LINES` (2,400 lines, ~3 s of dotnet per project) per shard |
| `work_parallelism` | total lines / critical path: the speedup with unlimited cores |
| `speedup_vs_monolith_unbounded` (`gear-bench`) | monolith lines / gear critical path including per-project overhead |

`chain` prints the declaration chain with the witness symbol of every link, then the shard chain. On
the current hopac core (174k lines) the declaration floor is **35,016 lines**, 32 declarations: the HUD →
`DiagJson.emit` → `EvalWorklist` (4,361) → `BigStack` (4,168) → `peval` (21,123) → `supervisor_server`
(2,719).

Measured 2026-09-27:
- **Shard packing.** Module-aware packing is now a timeline greedy (`critical_path_module_groups`). A
  declaration joins its module's open shard only if nothing depends on that shard yet and the shard's
  finish stays within the declaration's latest finish. This took the shard critical path from 126,653
  lines to **39,044**, within 12% of the floor.
- **Gear packing.** `GearPacking::Timeline` is the new default; `SPIRAL_GEAR_PACKING=layer` restores the
  old layer packing. The gear build is overhead-bound, though: with ~3 s of dotnet per project, the
  modelled speedup of the 194-gear plan stays below 1x against the monolith.

## Build benchmarks

`pwsh scripts/bench-split.ps1` emits the core and builds it three ways: `monolith`, `parts` (every Part
file in one F# project, topologically ordered) and `grouped` (parts concatenated into larger files). All
three use the same flags (`--test:GraphBasedChecking --test:ParallelOptimization --test:ParallelIlxGen`),
so graph-based checking can type-check independent files in parallel. `--times` output feeds the
per-phase table; receipts go to `<cache>/split-bench/<mode>/bench.tsv`.

Hopac core, 2026-09-27, 8 logical cores, wall seconds per `fsc` phase:

| variant | files | parse | typecheck | optimize | IL gen | write | `dotnet build` | summed check CPU |
|---|---|---|---|---|---|---|---|---|
| monolith | 1 | 8 | 100 | 66 | 22 | 13 | **219** | 99 |
| parts | 3,107 | 9 | 137 | 87 | 48 | 23 | 326 | 1,194 |
| grouped (cap 12k) | 920 | 7 | 152 | 68 | 34 | 16 | 287 | 386 |

An earlier ad-hoc run of the same three layouts gave 257 / 320 / 267 s of `fsc` time (typecheck 110 /
151 / 118 s). Run-to-run noise on this machine is about ±30 s, but the ordering never changed.

The split core now compiles as one project with **0 errors**, but it is not faster:
- **Only typecheck parallelizes.** Optimization, IL generation and writing stay about 130-140 s whatever
  the layout; optimization is dominated by the 21k-line `peval` files.
- **Each file costs a fixed ~0.2 s of checking.** The 2,073 parts under 60 lines alone cost 594 s of
  check CPU (median 23 `open`s each), and the file graph takes ~20 s to build before checking starts. So
  splitting finer buys parallelism but multiplies name-resolution work. Grouping cuts check CPU about 3x,
  but concatenating parts lengthens the dependency chain, so typecheck wall time never beat the monolith
  in any run.

What would change the verdict: emitting qualified references instead of `open`s (an emitter-wide
change), splitting `peval` at the source level, or incremental emission so an edit rebuilds only the
affected gears.

## Incremental gear builds (2026-09-27)

The multi-project build compiles end to end on the hopac core: 194 gears plus `GearRoot`, 0 errors, in
~11 min. It needs the dependency directory (`SPIRAL_ASSEMBLY_ROOT`, from `Get-SpiralLibDir`) and
`--assembly-overlay-root <cache>/bin/hopac/SpiralCompilerRuntimeCompat/Release/net11.0` for
`Supervisor.dll`. Its one failure was a let-bound anonymous record passed to a union case declared in
another gear: F# gives each assembly its own anonymous types. The core now builds that record in place.

With `ProduceReferenceAssembly` on, an implementation-only edit inside `peval` rebuilds 7 of 195
projects:

| rebuild | time |
|---|---|
| `GearRoot`, nothing changed | 108 s (MSBuild evaluating and checking 195 projects) |
| `GearRoot`, body edit in `peval` | 152 s |
| only the edited gear (`-p:BuildProjectReferences=false`) | **60 s** |
| the monolithic hopac core, for comparison | 250-400 s |

`gears` on the hopac core took 139 s, of which 82 s were two
analyses rescanning whole declarations per binding (`caller_contracts`, `higher_order_array_returns`;
quadratic on the 1.7 MB `peval`). With per-declaration indexes (`BindingIndex`, `binding_scopes`) and
per-(provider, symbol) caches it takes **39 s**, with byte-identical output.

## The edit loop: `scripts/gear-dev.ps1` (2026-09-27)

```powershell
pwsh scripts/gear-dev.ps1                  # emit, rebuild changed gears, build the split host
$env:SPIRAL_COMPILER_DLL = "<cache>/gear-dev/hopac/host/.out/bin/Debug/net11.0/SpiralCompiler.dll"
pwsh scripts/test.ps1 -Mode hopac -Suite frontier,smoke -Native
```

It emits into `<cache>/gear-dev/<mode>/emit` and copies only the files whose content changed into
`build/`, so MSBuild's timestamps stay meaningful. It then rebuilds the gears owning a changed part,
following public-surface changes (below) to their dependents; past 8 dirty gears it hands the whole graph to
MSBuild (`-MaxNodes`, default 2, since gear builds are memory heavy). Finally it builds a copy of
`compiler/host` against the gears: `qualified-rewrites.tsv` moves dissolved nested-module paths, and
`open spiral_compiler` becomes one `open` per part in source order.

With the split compiler, frontier 8/8 and smoke 38/38 match the monolith's baseline. Native: 36 ran,
0 build failures, 0 oracle disagreements.

A body-only edit in `term_core` (the `peval` gear, the largest), measured on the earlier 168-gear plan
(the current plan has 141 gears; `peval` is still one gear of its own):

| step | time |
|---|---|
| emit (always from scratch) | 41 s |
| the one owning gear | ~41 s |
| script overhead (sync, discovery, surface hash) | ~8 s |
| host (up to date, gears copied) | 1 s |
| **total** | **92 s** |

For comparison, the monolithic hopac build takes 206 s. A renumbering edit rebuilds most of the 141 gears
through MSBuild instead, roughly a full build: 15-30 min at `-MaxNodes 2`.

F# reference assemblies are not stable across body edits: one changed string literal rewrote 1.67 MB of
a 2.8 MB reference assembly, because the metadata heaps shift and the MVID follows the whole compilation.
So gear-dev does not compare reference assemblies byte for byte. It hashes their IL surface (types,
members, signature blobs, type and assembly references) and keeps a `surface/` copy that changes only
when that hash does. Dependents rebuild only on a surface change, and the host compiles against the
`surface/` copies, never against the gears' implementation assemblies.

Three things differ between a split and a monolithic core, and gear-dev accounts for each:
- **Module-level `do`s.** A library runs a file's initialization only once one of its values is read.
  A `do` alone in a part, and the core has 24 of them (hook installations, the operator table), would
  never run. Such parts get a `spiral_split_initialize` value, and `GearRoot.initialize ()` reads those
  values in source order. The host copy calls it right after `configureHopacFromEnvironment ()`.
  Verified directly: with the operator table filled by its original `do` (without it every `!!!!Op` is
  "not found"), the split compiler passes frontier 8/8 and smoke 38/38.
- **Resumed emission.** The gear passes rewrite `Part*.fs` in place, and they are not idempotent. An
  output directory holding `gears.tsv` is therefore always re-emitted from the source, never resumed.
- **Interrupted compiles.** A build killed mid-write (e.g. for low memory) leaves a 0-byte assembly that
  MSBuild trusts as up to date, so gear-dev deletes it and rebuilds that gear. A graph build that stops
  part way drops the full-build stamp, so the next run rebuilds the gears it never reached.

**Plan stability.** Part numbers and gears are only worth caching if an ordinary edit leaves them
alone. At first it didn't: a 6-line fix inside the replay worklist changed 3,373 files and rebuilt 133
gears (911 s). Both planners bound a simulated, line-weighted critical path of the whole core. With
exact line counts, lines added to one body on that path moved every later "latest finish", and with it
groups and gears far downstream. Greedy capacity packing added to this, since it leaves many gears just
under `max_lines`.

The planners now weigh declarations and gear components with `planning_lines`: rounded up to a multiple
of 64 up to 1,024 lines, then to buckets 12.5% apart. The shard planner uses these weights for its
schedule and keeps exact counts for capacity; the gear planner uses them for both. Their slack is
relative to the weighted critical path, a half for shards and a whole for gears, so rounding up does not
fragment the plan. On the hopac core that gives 3,760 shards and 141 gears.

Measured with 6 synthetic 5-line body edits (in `term_core`, the replay worklist, `EvalReplayValueStore`,
the HUD near the top, the operator table and the JP CPU clock near the end): each changed exactly 1
part and 0 gear projects. Before the change, the same edit in the worklist changed 3,373 files.

The first build of the new plan exposed two latent problems that the old grouping had masked, both
fixed:
- `generated_dependency`'s code projection took the char literal `'"'` for the start of a string and
  blanked the file up to the next quote. That hid a second `type NativeReplayKey`, so the name looked
  unique and a reference was qualified to the wrong type. It now uses the shared lexer's
  `character_literal_starts` (regression test included).
- One core function (`terminalFlowFairnessReleaseBasisRef`) had its inline SRTP kind inferred only from a
  later use in the same file; split into another part it defaulted to `obj` (FS0071). It is annotated.

Adding or removing a top-level declaration still renumbers every later part and costs about a full
build. gear-dev refuses to start one: past 8 dirty gears it stops before syncing anything, prints the
estimate, and `-Force` goes ahead. For such edits the monolith (`scripts/build.ps1 -Mode hopac`, ~4 min)
is the faster check.

## Commands

```powershell
pwsh scripts/build-splitter.ps1                       # builds spiral-split into <cache>/splitter-target
pwsh scripts/build-splitter.ps1 -Test                 # cargo test --workspace
$split = "<cache>/splitter-target/release/spiral-split"
& $split analyze compiler/cores/hopac/spiral_compiler.fs
& $split gears compiler/cores/hopac/spiral_compiler.fs <cache>/gears-hopac --threads 8
& $split gear-build <cache>/gears-hopac --dotnet <dotnet> --threads 4
& $split bench compiler/cores/hopac/spiral_compiler.fs     # shard metrics, incl. critical paths
& $split chain compiler/cores/hopac/spiral_compiler.fs     # the heaviest declaration and shard chains
& $split gear-bench compiler/cores/hopac/spiral_compiler.fs  # gear plan shape, no emission
pwsh scripts/bench-split.ps1                          # time monolith vs split single-project builds
pwsh scripts/gear-dev.ps1 [-Mode hopac] [-Full] [-Force] [-MaxNodes 2]   # the edit loop, see above
```

Generated shards, gears and assemblies are disposable build products; the monolith stays the only
source of truth, and it is never edited through the split tree.

## Current numbers (Windows, 2026-09-26)

`spiral-split analyze` on the alpha3006 Hopac core (13.0 MB, 174,899 lines), ~18 s: 10,728 declarations,
2,152 shards, 70 dependency layers, widest layer 321, estimated parallelism ~31x, 92% of the dense
reference edges removed. Ten groups exceed the 1,000-line cap; the largest is `peval` at 21,062 lines
(1.6 MB) as one indivisible declaration group, which bounds any parallel build of this core. The next
two are `EvalWorklist` (4,361 lines) and `BigStack` (4,154 lines).

## Test status (2026-09-28)

`pwsh scripts/build-splitter.ps1 -Test` (`cargo test --workspace --no-fail-fast`): Windows
556 passed, 11 failed (all 11 pre-existing; the CLI tests that read the single-flight core now look
declarations up by heading, since indices shift with every declaration added to the core); Linux (WSL Ubuntu, 2026-09-27) the same 4 logic failures only.

- Both platforms, in the lift/annotation passes: `late_non_call_use_rolls_back_component_and_dependents`
  (`spiral-split-lift-funnel`: the `alias = bad` component is not rolled back),
  `hoists_single_captured_helper`, `annotates_untyped_header_from_recursive_group_witness`,
  `leaves_untyped_function_parameter_without_group_witness`. These shipped failing in the source bundle.
- Windows only, 7 process-capture tests (`kills_descendant_tree_without_waiting_for_pipe_close`,
  `post_term_kill_is_bounded`, `concurrent_timeout_paths_are_bounded`, ...): they assume Unix process
  groups and signals, so `gear-build` timeouts are only trustworthy on Linux for now.

## Design

`SPLITTER.md` describes the scan → link → plan → gears → emit pipeline.
