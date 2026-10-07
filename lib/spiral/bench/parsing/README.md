# split_args / parsing benchmark

Measures `lib/spiral/parsing` the way its real consumer uses it: `runtime.split_args`, which the spiral CLI
(`apps/spiral/spiral.spi`) calls for every process it starts (`runtime.execute_with_options`). It compares that against
the FParsec-backed `split_args` at the top of `parsing.livemd` (`## fparsec`, the same combinator frontend over FParsec).

Implementations (one Spiral program per backend):

| impl      | source                                                                   | backends             |
|-----------|--------------------------------------------------------------------------|----------------------|
| `fparsec` | `fparsec.spi`: copy of parsing.livemd's `## fparsec` frontend + split_args   | F# only              |
| `pure`    | `pure_split.spi`: the same grammar on the pure-Spiral `parsing` library  | F#, native Rust      |
| `runtime` | `runtime.split_args` (lib/spiral/runtime.spi), the CLI's                 | F#, native Rust      |

`pure` and `fparsec` are the same grammar and must give identical results (the script lists any case where they
don't). `runtime` adds an escaped-quote delimiter branch (`\"...\"`), so some of its results differ by design.

Inputs (`harness.spi`, a runtime array so nothing is constant-folded): runtime.livemd's split_args test cases (`t01`..`t12`),
real CLI command lines (`cli_*`), and generated scaling inputs: `cli_x1/x4/x16` (a CLI line repeated 1/4/16 times:
many arguments) and `quoted_64/256/1024` (one quoted argument of N chars: per-character string building). ns/call that
grows faster than the length ratio between x1/x4/x16 or 64/256/1024 means quadratic behaviour.

Each case: calibrate iterations to ~50 ms per batch, report the best of 5 batches (ns/call), plus a `RESULT` line with
the parsed arguments for behaviour checks.

## Run

```powershell
pwsh lib/spiral/bench/parsing/bench.ps1 -Label before                  # F# + native Rust
pwsh lib/spiral/bench/parsing/bench.ps1 -Label after -Compare before   # also diff results/timings vs `before`
pwsh lib/spiral/bench/parsing/bench.ps1 -Label x -Backends Fsharp -Cells  # + compile time of each parsing.livemd test cell
```

- Compiles `main.spi` (one entry for every backend; the FParsec reference only exists on F#) with the compiler of the
  polyglot spiral bundle (as `lib.ps1`'s `BuildSpiral`), or with a wrapper script passed as `-Spc`; each compile's
  wall time (including ~15 s of compiler start-up) is recorded in `compile.tsv`.
- F#: the generated `bench.fs` is built as a Release net9.0 exe with the FParsec 2.0.0-beta2 package.
- Rust: the generated `main.rs` is built with `cargo +nightly-2025-11-01 build --release` (thin LTO).
- dotnet/cargo builds run under `Invoke-Heavy` (a machine-wide memory mutex) when a script defining it is passed as
  `-Heavy`; `-MemoryWait` instead just waits for `-MinFreeMB` (2500) of free memory.
- `TRACE_LEVEL=Info` while running, i.e. traces off as in normal CLI use (`Verbose` would time console output).

Outputs (gitignored), under `bench/parsing/target/<Label>/`: `summary.tsv` (ns/call per impl and case, ratios vs
FParsec), `results.tsv` (parsed arguments), `compile.tsv` (compile seconds and generated lines), `fsharp/`, `rust/`,
`cells/`, and `compare_<other>.tsv` with `-Compare`.

Native Rust caveat: a unit-returning `let rec` loop written `if i < n then (...; loop (i + 1))` (implicit `else ()`)
compiles to `loop { if c { ...; continue; } }` with no exit, i.e. it spins forever after the last iteration. The harness
writes the exit branch explicitly (`if i >= n then () else ...`).
