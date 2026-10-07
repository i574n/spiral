# Spiral Brzozowski derivatives mega-sample

Regular expressions over nominal finite alphabets, matched by Brzozowski derivatives. The interesting parts are proved
by Spiral's type checker instead of tested, and the same source compiles to C, Rust, Delphi and F# and runs on all
four. It is core-free (no standard library): `main.spi` is 2,801 non-blank lines with 36 unions, 34 nominals, 263
`forall` and 34 `exists`; with `runtime_workload.spi`, `runtime_interned.spi` and the 66 sub-packages it is 8,837
non-blank lines of Spiral in 77 files.

## What the type checker proves

- **GADT typestate.** A matcher is `bit_matcher_state phase`: `BitMatcherRaw` only builds a `bit_matcher_state
  matcher_raw`, `BitMatcherDecided` only a `bit_matcher_state matcher_decided`, and `decide_bit_match` is the one way
  from the first to the second. Reading a result off an undecided matcher does not type-check
  (`negative_derivative_runtime_phase_use`, `negative_phase_use`).
- **Verified-only existentials.** Sealed derivative programs, generic matcher states and inventory packs are
  `exists`-packed only after their witnesses check; raw packings are rejected (`negative_raw_generic_state_seal`,
  `negative_seal_unverified_derivative`, `negative_raw_inventory_bypass`, ...).
- **Higher-ranked capabilities.** Batch predicates are `forall`-quantified programs that cannot capture a specific
  alphabet (`negative_hkt_batch_predicate_specific`, `negative_hkt_requires_capability_capture`).
- **Length-indexed vectors and DFA rows.** Finite symbol vectors and DFA transition rows carry their length in the
  type; a truncated canonical vector or a short row is a type error (`negative_truncated_canonical_vector`,
  `negative_indexed_row_length`).
- **Antimirov support bound.** `antimirov_typed_slot_bound` carries a position-tree GADT whose shape has one origin slot
  per character position; every partial derivative resolves to a typed root/origin slot, and a forged tree of the same
  cardinality is rejected (`negative_antimirov_slot_shape`, `negative_antimirov_support_assignment_count`).
- **Minimization and closure certificates** (`minimization_witness`, `indexed_closure_certificate`,
  `canonical_form_certificate`), checked against forgeries (`negative_forge_*`).
- **A minimized DFA with an exact compiled core** (`indexed_dfa_state_cardinality`). The compiler minimizes the DFA
  (`static_minimize_states`: bisimulation over the static derivatives) and seals the result in length-indexed vectors:
  closure states and representatives each have their own count index, every closure state maps to a representative
  index (quotient coverage) and every representative to a closure index (origins), states and transition rows share
  one count, and the compiled core is a start index, an acceptance vector and a total transition matrix whose targets
  are `finite_symbol_index representative_count`. A short row, a missing state or a target past the last
  representative is a type error (`negative_indexed_dfa_*`). `indexed_dfa_witness_contracts` seals the partition,
  constructive-minimality (a distinguishing word for every pair of representatives, found by the compiler and checked
  against the direct-language matcher, not against derivatives) and exact transition soundness witnesses.
- **The inventory-indexed model** (`inventory_indexed_model`, run by `proof_suite`): an alphabet-erased regex and DFA
  whose characters are indices into an exact symbol vector; its closed DFA (start index, acceptance vector, total
  matrix) is replayed state by state and transition by transition against the production semantics.

The finite-alphabet checks (inventory order, cardinality, authority) are `inl` functions, so the compiler decides them:
a certificate or an `exists` package built under them is built under a compile-time branch. The indexed DFA closure
(`indexed_dfa_closure`), the minimization and the inventory model's replays are computed during compilation too: they
use main's `static_*` twins (minimization, bisimulation, distinguishing words, the direct-language oracle, `accepts`,
`reference_accepts`, the raw closure, the input corpus), because an `inl rec` check over the run-time result of a
`let rec` join point never terminates. `indexed_closure_certificate`, `indexed_dfa_witness_contracts` and `proof_suite`'s
inventory contract compile to no run-time code: every check in them was discharged by the compiler. (Elsewhere an
`assert_static` whose argument is a run-time value becomes a run-time check: `failwith` in the emitted code.)

## What runs

`runtime_workload.spi` and `runtime_interned.spi` match inputs generated at run time (an LCG seed, so nothing is known to
the compiler) with four engines written in the sample:

| engine | how | run-time work per symbol |
| --- | --- | --- |
| derivative matcher | `main.accepts`: one canonical derivative (normalize, derive, normalize) per symbol | builds and compares regex trees |
| interned + memoized | `runtime_interned.spi`: regex nodes hash-consed into `i32` arrays (a node is its number; the smart constructors normalize as they build), each derivative computed once per (node, symbol) and cached: a DFA built lazily at run time | after warm-up, two array reads |
| staged DFA | the same derivatives as `inl` functions (`static_*` in `main.spi`), run by the compiler on the known regex: `staged_accepts` enumerates the reachable derivatives and emits a loop over an `i32` state with constant transitions | one `match` and one `if`-chain over constants |
| backtracking | a textbook recursive matcher (continuation stack, greedy star), for comparison | backtracks; exponential on `(0\|00)*1` against `0^n` |

The interned engine's boundary is typed (it interns a `regex bit_alphabet` and matches a `linear_input bit_alphabet`),
and its matcher handles nodes and symbol positions as the nominals `interned_regex` and `bit_slot`, which only the store
and the alphabet match hand out (erased in the output: the C differs from an all-`i32` version only in two function
names). Inside the store a node is an untyped `i32` whose invariants (kinds 0-5, children numbered below their parent)
hold by construction, not by type; `runtime_bench` checks the engine against the other three on every backend.

Two compiled cores also run: `indexed_dfa_state_cardinality` runs the core of the DFA it minimized at compile time
((0|1)*0: 2 states; (0|00)*1: 5 derivatives, 3 states) on runtime_bench's inputs and checks every answer against the
run-time derivative matcher (and a ternary regex on two inputs); `inventory_closed_dfa_runtime` runs the inventory
model's closed DFAs (bit, ternary, and a* over a two-slot inventory of a three-value alphabet) on every input of length
<= 2 against the derivative matcher and checks that a symbol outside the inventory is reported as such. Both run the
core as an `i32` state dispatched through if-chains of the core's constants (a run-time GADT index trips a compiler
bug, see Open).

The staged DFAs the compiler finds: 2 states for `(0|1)*0`, 16 for `(0|1)*1(0|1)(0|1)(0|1)` (the minimal DFA of
"fourth from the end is 1" has 2^4), 5 for `(0|00)*1` (counted in the emitted C). No regex exists in the staged
programs at run time.

`runtime_bench` runs all four on 200 random 32-bit inputs per regex plus `0^n` / `0^n 1` for n = 1..16 and exits 0
only if they return the same counts and those match what Rust's `regex` crate returns on the same inputs (93, 97, 16).
It is in the suite's native tier on C, Rust and Delphi (C is the oracle; Rust and Delphi must agree), with
`runtime_native` (the GADT typestate on the native backends: `decide_bit_match`, then `bit_match_value`),
`indexed_dfa_state_cardinality` and `inventory_closed_dfa_runtime`.

### Timings (measured 2026-10-06 on this machine; nothing here is estimated)

`bench.ps1 -Repeat 11 -RegexCrate`, 14:10-14:13: an i7-4810MQ (4 cores, 8 threads, 16 GB) shared with other jobs (CPU
load 60%, 5.5 GB free at the start). Every program was built with the suite's flags (gcc 15.2 `-O2`, rustc 1.88 nightly
`opt-level=2`, fpc 3.2.2 `-O2`, .NET 10 Release) and run 11 times round-robin (every target once per round, so load
changes hit all of them alike); the cells are the **median / minimum wall time of the whole process** in ms, process
start included. Two workloads, the same inputs for every engine:

- *random*: 2,000 random 32-bit inputs against `(0|1)*0` and again against `(0|1)*1(0|1)(0|1)(0|1)` (accepted: 997
  and 985);
- *zero runs*: `0^n` and `0^n 1` for n = 1..26 against `(0|00)*1` (accepted: 26).

| program | C | Rust | Delphi | F# |
| --- | --- | --- | --- | --- |
| process start (`runtime_native`: six matches) | 11 / 8 | 13 / 8 | 27 / 21 | 135 / 99 |
| random, derivative matcher | 1,350 / 1,040 | 1,472 / 1,154 | 1,056 / 687 | 584 / 496 |
| random, backtracking | 235 / 182 | 261 / 181 | 141 / 81 | 332 / 234 |
| random, **interned + memoized** | **41 / 21** | 55 / 31 | 100 / 70 | 153 / 112 |
| random, **staged DFA** | **40 / 22** | 62 / 32 | 53 / 33 | 162 / 86 |
| zero runs, derivative matcher | 22 / 14 | 28 / 17 | 41 / 23 | 115 / 78 |
| zero runs, backtracking | 1,476 / 1,015 | 1,824 / 1,356 | 855 / 628 | 651 / 460 |
| zero runs, interned + memoized | 13 / 10 | 14 / 10 | 32 / 20 | 125 / 80 |
| zero runs, staged DFA | 14 / 10 | 16 / 11 | 32 / 22 | 120 / 87 |
| Rust `regex` crate 1.13, random / zero runs | | 15 / 12 and 14 / 10 | | |

What the numbers say, and what they do not:

- **Interning and memoizing** the derivatives turns the run-time derivative matcher's 1,350 ms (C) into 41 ms, the
  same as the staged DFA whose states the compiler enumerated (40 ms): both are now process start plus generating the
  128,000 random symbols as reference-counted input lists. The interned engine takes its regex at run time; the staged
  one needs it at compile time. Rust's `regex` crate on the same inputs (15 ms) reads them from a byte buffer instead,
  so that is not a like-for-like engine comparison.
- The derivative matcher allocates and reference-counts a regex tree per symbol in C and Rust (malloc/free and
  increments/decrements; `Rc` and `.clone()`), and F# gets the .NET garbage collector: F# runs it 2.3x faster than C.
  With interned nodes there is nothing to allocate per symbol and C is the fastest backend again (41 ms against F#'s
  153 ms, of which ~135 ms is process start).
- On the **zero runs** the backtracking matcher explores every split of `0^n` into `0` and `00` (Fibonacci(n) paths)
  before it rejects: 1.5 s in C against 13-22 ms for the three derivative engines. On the easy random workload the
  backtracker is faster than run-time derivatives without memoization (235 ms against 1,350 ms).
- Earlier passes the same day (lane F, 11:30 and 12:37, at 100% CPU load) ranked the original engines the same way with higher
  medians (the 11:30 pass: 1.3-3.8x these; the 12:37 pass up to 7x on the short programs); this table replaces them. Every result file is in `<cache>/bench/brzozowski/`.
## Layout

- `main.spi`: the library: alphabets, regexes, derivatives (run-time and compile-time), canonicalization, finite
  closure, the indexed DFA, certificates and the typestate.
- `runtime_workload.spi`: the run-time workloads, the backtracking matcher and the staged DFA.
- `runtime_interned.spi`: the interned + memoized engine and its workloads.
- 27 positive sub-packages: certificates, probes of the indexed model, `indexed_dfa_state_cardinality` (the minimized
  DFA, its compiled core and the witness modules), `indexed_dfa_witness_contracts` (runs those witness modules),
  `inventory_closed_dfa_runtime`, `proof_suite` (main's proof suite and the inventory-indexed model contract),
  `runtime_smoke`, `runtime_native`, `runtime_bench` and eight `bench_*` timing programs (one engine and one workload
  each); `inventory_indexed_model` is a module package without a `main`.
- 31 `negative_*` sub-packages: programs the type checker must reject, one per forgery or misuse.
- 8 `compiler_probe_*` sub-packages: compiler boundaries (GADT runtime ranks, existential helpers, recursive indexed
  definitions) kept as regression fixtures.
- `bench.ps1` and `regex_crate_bench.rs`: the timing harness below.

## Results (spiral compiler, single-flight)

`test.ps1 -Suite contracts,mega -Filter mega_brzozowski_derivatives -Native -Parallel 2` (2026-10-06 14:38, then a
`-Bless` run at 14:40 that reproduced it row for row: verdicts, residual hashes, native results; again at 16:37/16:40
after the interned engine got its nominals, which changed only `runtime_bench`'s C residual): 78 rows.

- The root and all 26 positive sub-packages with a `main` compile (to F#; the suite compiles F# rows, it does not run
  them), `indexed_dfa_state_cardinality` for the first time.
- All 31 `negative_*` sub-packages are rejected: 30 with the same error as before (two of them for the wrong reason,
  Open), and `negative_exact_rows_not_soundness_witness` now with its intended one (exact rows are not a soundness
  witness; before: `Unbound variable`, because its helper failed to parse).
- 7 of the 8 `compiler_probe_*` sub-packages compile; `compiler_probe_gadt_uninhabited_payload_runtime` still stops at a
  compile-time pattern miss on a GADT branch whose payload is uninhabited (FOR-D).
- Native tier: `runtime_native`, `runtime_bench`, `indexed_dfa_state_cardinality` and `inventory_closed_dfa_runtime`
  built and run on C, Rust and Delphi, all exit 0; Rust and Delphi agree with C (12 runs, DISAGREE 0).
- Changed rows against the 12:52 oracle, all explained: `runtime_bench` residuals (the interned engine joined it),
  `proof_suite` (it gates the inventory contract again; its string is the contract's), `indexed_dfa_state_cardinality`
  (compiles), 10 new rows (the new packages and the cardinality program's native rows).
- Run by hand and green: every new program on all four backends (F# through `dotnet fsi`), `proof_suite` and
  `indexed_dfa_witness_contracts` through `dotnet fsi`; a deliberately wrong expected count in the cardinality program
  makes it exit 1 (checked once on C). Outside the suite's backends, `runtime_bench`, `indexed_dfa_state_cardinality`
  and `inventory_closed_dfa_runtime` also build and exit 0 on C++ (g++ -O2) and TypeScript (bun); on Python the
  cardinality and inventory programs exit 0, `runtime_bench` stops at RecursionError (Python emits self tail calls as
  recursion: FOR-D `python_self_tail_call_depth`) and `runtime_native` at a NameError (D31's GADT case naming, still in
  the Python backend: FOR-D).
- The Hopac core reproduced F's 68 rows at 13:10 (it needs 37-52 s for `runtime_bench` and `bench_staged`, over the
  contracts suite's 30 s, so `tests/harness.psd1` `Timeouts` gives the runtime programs 180 s; the new ones get the
  same). In hopac mode every row changed or added on 2026-10-06 afternoon reproduces the oracle too: `hopac-20261006-153721`
  (the new programs, 16 rows) and `hopac-20261006-165156` (`runtime_bench` x4, 59-67 s each).
`runtime_native` exposed a compiler bug on the way: a GADT-indexed union keeps only its inhabited cases
(`bit_matcher_state matcher_decided` has just `BitMatcherDecided`, tag 1), and the C/C++ backends numbered the emitted
cases by position while every use went by tag (fixed 2026-10-06). The Rust backend names the variants by tag
(`enum US5 { US5_1(..) }`) and was never affected.
## Reproduce

From `apps/compiler/tmp`:

```powershell
# the sample's rows in the suite: every sub-package compiled to F#, runtime_native/runtime_bench also built and run on C, Rust, Delphi
pwsh scripts/test.ps1 -Mode single-flight -Suite contracts,mega -Filter mega_brzozowski_derivatives -Native
# one program on one backend (writes main.rs next to main.spi)
pwsh scripts/probe.ps1 mega_brzozowski_derivatives/runtime_bench -Mode single-flight -Backend Rust
rustc -C opt-level=2 --edition 2024 samples/mega_brzozowski_derivatives/runtime_bench/main.rs -o bench.exe; ./bench.exe; $LASTEXITCODE
# the timings (compiles and builds every bench_* program, then times them round-robin)
pwsh samples/mega_brzozowski_derivatives/bench.ps1 -Repeat 11 -RegexCrate
```

## Open

- **A run-time GADT index** (a `finite_symbol_index n` that is a run-time value, e.g. the state of a `let rec` loop over
  the closed DFA) stops partial evaluation with a pattern miss on the uninhabited `finite_symbol_index
  finite_length_zero` case (FOR-D, `compiler_probe_gadt_uninhabited_payload_runtime`). The compiled cores run on an
  `i32` state instead; the typed indices exist only during compilation.
- **Compiler workarounds in the sample** (each a FOR-D with a repro under `samples/`): binding annotations instead of
  explicit type application (``f `T ()`` does not parse) and one-line `match` scrutinees
  (`match_multiline_scrutinee`); a symbol equality captured as a function before a GADT match instead of the
  `symbol_compare` constraint (`gadt_match_loses_constraint`); the semantic partition witness carries the bisimulation
  capability so its `alphabet` parameter is not phantom (`nominal_phantom_parameter`); `static_*` twins wherever an
  `inl rec` would walk a run-time list, since such a mistake is an endless compile, not an EJP0040 report
  (`runaway_inline_match_recursion`).
- **Negatives rejected for the wrong reason**: `negative_forge_constructive_minimality_witness` and
  `negative_inventory_length_mix` fail with `Unbound variable` (the root's names are not visible through
  `indexed_dfa_state_cardinality-` / `inventory_indexed_model-`: `open` does not re-export). With the names visible the
  first would compile (a nominal constructor is public, so a "forged" witness of consistent shape type-checks); the
  second would show the intended length mismatch.
- **Existentials are compile-time only** (every backend: "Existentials are not supported at runtime"). A branch-built
  `exists shape` works when the compiler decides the branch (`normalization_derivation_pack` on a known regex in
  `canonical_form_certificate`) and is rejected when the branch is a run-time one ("Cannot dyn an existential into a
  runtime var"); that, not F# emission, was the old "exists shape" item. `proof_suite` failed this way until the
  alphabet checks became compile-time.
- A nominal pattern around a union case (`| bit_alphabet BitZero =>`) silently drops the enclosing definition (FOR-D,
  `samples/nominal_union_case_pattern`); the sample binds the payload first (`InputCons (bit_alphabet symbol, rest)`).
- Derivative/normalization theorems are trusted, not exported to an external checker.