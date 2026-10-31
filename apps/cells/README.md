# Spiral.Cells

A [Livebook](https://livebook.dev) smart cell for [Spiral](https://github.com/mrakgr/The-Spiral-Language).
Write Spiral in the cell. The single-flight Spiral compiler emits Rust, `rustc` builds it,
and the cell shows program output, the `i32` result, and compile errors.

The OTP application is `:spiral_cells`. The Elixir modules are `Spiral.Cells` and
`Spiral.Cells.*`. The hex package this cell is built on is already named `kino`, so the
application name stays distinct from that dependency.

## Requirements

- Livebook **v0.19+** and Elixir **1.18+** (`kino ~> 0.19.1` uses the built-in `JSON` module).
- The single-flight `SpiralCompiler.dll` (a .NET program). The default path is
  `%LOCALAPPDATA%/spiral-bin/bin/single-flight/SpiralCompiler/Release/net11.0/SpiralCompiler.dll`.
- `dotnet` that can load that DLL. The cache copy under
  `%LOCALAPPDATA%/spiral-bin/toolchains/dotnet/dotnet.exe` is used when it is present.
- `rustc` (edition 2021).
- The Spiral core package (`core/package.spiproj`) from
  `spiral/deps/The-Spiral-Language/VS Code Plugin` (the fork spiral's `scripts/init.ps1` clones). The cell links `|core-` and a
  one-module `console.write_line` implemented in the cell package.

## Usage

Add the package to a notebook's setup cell:

```elixir
Mix.install([
  {:spiral_cells, path: "C:/home/git/spiral/apps/cells"}
])
```

Then pick **+ Smart → Spiral**. The cell generates a call like this one:

```elixir
Spiral.Cells.eval!(
  ~S"""
  inl square x = x * x

  console.write_line "Hello from Spiral!"
  square 7i32
  """,
  timeout: 300000
)
```

The cell prints `Hello from Spiral!` and shows `49`. See
[`notebooks/spiral.livemd`](notebooks/spiral.livemd) for a sample notebook.

From plain Elixir:

```elixir
{:ok, result} = Spiral.Cells.run("1i32 + 2i32", timeout: 120_000)
result.value #=> "3"
```

## The cell

| Field | Effect |
| --- | --- |
| Timeout (s) | Wall-clock budget for compile, `rustc`, and the run together. When it expires, the process tree of the stage in progress is killed and the cell fails with `Spiral.Cells.TimeoutError`. |
| Show generated Rust | Adds the patched Rust source in front of the program output. |

The last top-level expression is wrapped as `inl main () : i32 =`. A body whose type is `()`
is compiled once more with `0i32` appended, and that run shows output with no value.
An `inl main` / `let main` you wrote is left as it is, and its `i32` is the cell value.
`console.write_line` prints a string and a newline.

Kernel directives in the source:

- `///- --print-code` and `///- --timeout <ms>` on the **first** `///-` line. A later `///-` line is ignored. A timeout passed to `run/2` or `eval!/2` wins over `--timeout`.
- `///- --package <path>` links that directory into the cell (the directory name becomes an included package). The path is relative to the `:root` option, or to the working directory when `:root` is omitted. `offset.add_one` is how an included package's `offset` module is called.
- `///- --test` and `///- --test static` mark a notebook cell as a test. The flag is removed before compile.
- `///> rust` is accepted and dropped. `///> rust <args>` raises. Any other `///>` backend raises.
- `////...` is dropped.
- A line starting with `#!` raises.

## Errors

| Situation | Raised |
| --- | --- |
| Parse or type error | `Spiral.Cells.SpiralError`. The message has the temp directory stripped. Positions such as `main.spi:5:12` refer to the wrapped `main.spi`. |
| Timeout | `Spiral.Cells.TimeoutError`. The process tree is already killed. |
| Compiler, `rustc`, or the cell binary failed to start, or the generated Rust still contains an emit marker (`__spiral_emit_rust`) | `Spiral.Cells.ProcessError`. |

## How it works

1. `Spiral.Cells.Directives` strips directives and `Spiral.Cells.Cell` wraps `main`.
2. A temp package is written (`package.spiproj`, `console.spi`, `main.spi`) under `System.tmp_dir()/spiral_cells`.
3. `dotnet SpiralCompiler.dll --backend Rust main.spi main.rs` runs with `SPIRAL_WORKSPACE_ROOT` and `SPIRAL_COMPILER_PACKAGE_DIR` set.
4. Statement-form `__spiral_emit_rust` calls (the former `Fable.Core.RustInterop.emitRustExpr` spelling too) are inlined, and `std::process::exit(main.join().unwrap())` is rewritten so the `i32` is printed as `SPIRAL_CELLS_VALUE:<n>` and the process exits 0.
5. `rustc --edition 2021 -o cell.exe main.rs` builds the file, and the binary runs in that directory.
6. The temp directory is removed unless `keep_files: true`.

### Process handling (`Spiral.Cells.Runner`)

- The child runs in an Erlang port (`spawn_executable`, no shell). stdout and stderr are captured together, and the exit status is returned.
- On Windows the port loses the whole output of a child that prints and exits at once: 4–10% of runs at 24 concurrent runs, and a 3 s wait does not bring it back. There the child runs as `cmd /d /v:off /s /c "> <temp file> 2>&1 <program> <args>"`, and the output is read from the file after exit. The exit status passes through unchanged, crash codes included. Arguments containing `"`, `%` or a newline cannot be quoted safely for cmd, so those runs use the direct port.
- The port is owned by a watcher under `Spiral.Cells.TaskSupervisor`. The watcher monitors the caller and is not linked to it.
- On timeout, and when the caller dies (Livebook *Stop* or re-evaluation), the watcher kills the process tree. On Windows it uses `taskkill /T /F /PID`. On Unix it walks children with `pgrep -P` and sends `SIGKILL`.
- A grandchild whose parent has already exited is not found by that walk. An abrupt BEAM kill leaves the children running on Windows.
- Tests exercise the Windows `taskkill` path. The Unix `pgrep` / `kill` path is the same watcher with a different tree walk.

### Configuration

Resolved in this order for each setting: the `run/2` option, then the environment variable, then the default.

| Setting | Option | Environment | Default |
| --- | --- | --- | --- |
| Compiler DLL | `:compiler_dll` | `SPIRAL_COMPILER_DLL` | `%LOCALAPPDATA%/spiral-bin/bin/single-flight/SpiralCompiler/Release/net11.0/SpiralCompiler.dll` |
| `dotnet` | `:dotnet` | `SPIRAL_DOTNET` | cache `toolchains/dotnet/dotnet.exe`, then `dotnet` on `PATH` |
| `rustc` | `:rustc_bin` | `SPIRAL_RUSTC` | `rustc` on `PATH` |
| Workspace root | `:workspace` | `SPIRAL_WORKSPACE_ROOT` | `spiral/apps/compiler/tmp` next to this app |
| Core package directory | `:package_dir` | `SPIRAL_COMPILER_PACKAGE_DIR` | `spiral/deps/The-Spiral-Language/VS Code Plugin` |
| Package fallback root (a cell's `--package` path not found beside the notebook) | `:workspace_root` | `SPIRAL_CELLS_WORKSPACE_ROOT`, or `config :spiral_cells, workspace_root: ...` | this `spiral` checkout |
| Compiler daemon port | - | `SPIRAL_CELLS_COMPILER_PORT` | `13905` |
| Compiler server memory cap (MB; 0: none) | - | `SPIRAL_CELLS_DAEMON_MAX_MB` | `2500` |
| Compiles per compiler server (0: no limit) | - | `SPIRAL_CELLS_DAEMON_MAX_COMPILES` | `0` |
| Compiler servers per daemon (`off`, `N`, `auto` = 3) | - | `SPIRAL_CELLS_DAEMON_POOL` | `auto` |
| Free memory one more compiler server needs (MB) | - | `SPIRAL_CELLS_DAEMON_SERVER_MB` + `SPIRAL_CELLS_DAEMON_RESERVE_MB` | `1000` + `1500` |
| Fair turns per client (`0`: first come first served) | - | `SPIRAL_CELLS_DAEMON_FAIR` | `1` |

By default a cell compiles through one shared, warm daemon: the first cell starts it detached, straight from the
compiled code (`elixir -pa _build/<env>/lib/*/ebin -e Spiral.Cells.CompilerDaemon.serve_app()`, so it never waits for
mix's build lock; `mix spiral.compiler_daemon` when nothing is compiled), on `127.0.0.1:13905` (or `SPIRAL_CELLS_COMPILER_PORT`), and it keeps running after the
Livebook session ends so later sessions reuse it. `SPIRAL_CELLS_COMPILER=process` opts out: each cell then starts its
own compiler process, and no daemon is started. Passing any of `:compiler_dll`, `:dotnet`, `:package_dir`,
`:workspace` or `:env` also compiles in a separate process. The compiler runs as
`SpiralCompiler.dll --server-tcp <socket> --stall-seconds N`: it listens on loopback TCP itself and its own watchdog answers
`compiler stalled` when a compile makes no CPU progress. A compiler whose `--capabilities` does not list `server-tcp` is refused.
After each compile the daemon checks its .NET compiler server: past the memory cap (working set) or the compile
count it stops it, logs `compiler recycled after ...`, and the next compile starts a fresh one (a cold compile).
The daemon itself, its port and its queue stay up. The compiler server runs from a shadow copy of the compiler's directory
(`%TEMP%/spiral-cells-compiler/<mtime>-<size>`), so rebuilding the compiler never fails on a locked DLL; before each compile
the daemon compares the DLL's mtime and size with the copy it runs and restarts the server on a new build. Its code stamp is the md5 of the daemon module's code, so every
build of the same code (this app, an app that depends on it) shares one daemon instead of replacing it.
The daemon runs up to 3 compiler servers (`SPIRAL_CELLS_DAEMON_POOL`): a request waits in its client's queue (a client is
one BEAM), clients take turns, and a new server starts only when a request is waiting, every server is busy and free
memory covers `SPIRAL_CELLS_DAEMON_SERVER_MB` plus `SPIRAL_CELLS_DAEMON_RESERVE_MB`; with several servers each one
recycles at `max(SPIRAL_CELLS_DAEMON_MAX_MB / servers, 1200)` MB. Measured with 3 sessions of 6 lib compiles: one
server 60-69 s, the pool 41-49 s (queue p50 26.5 s -> 10 s) at about 1.1 GB. Retiring waits for queued and running
compiles and stops every server. The daemon log (`kino-<port>.log`) has a `received`, `started` and finish line per
request; a relaunch rotates it to `.prev.log` once the retiring daemon lets go of the file.

Editor highlighting is `config :spiral_cells, editor_language: "javascript"` (the default).
Livebook's editor has no Spiral mode. JavaScript highlights `//` comments, strings, numbers,
and `let`. Primes in identifiers (`am'.vec`) are read as string starts. `nil` turns highlighting off.

Each cell is a fresh process. Definitions are not shared between cells. `Spiral.Cells.Document` reads and
writes notebooks (`parse_livemd/1`, `to_livemd/1`, `to_cell_text/1`, `to_spi/1`, `to_spi_tested/1`, `parse_spi/2`).
`to_spi/1` keeps definitions, `open` lines, and the first `--package` directive, and it
drops `--test` cells. `parse_livemd/1` reads the smart cells `to_livemd/1` writes.
`to_spi_tested/1` keeps each `--test` cell as a `test <name> [static] [print_code] [ignore] =` block
(its `///>` targets above it, its body indented), named after the nearest heading; the compiler skips
these blocks. `parse_spi/2` reads a `.spi` and its `_real.spir` back into cells, one test cell per block,
so `run_notebook.ps1 --path x.spi` runs a source file as a notebook without writing over it. The `_real.spir` cells
go in after the same heading of the `.spi` (headings match by text; real cells come first within a section), so
`to_spi_tested/1` and `to_spir_tested/1` give both files back.
`parse_spi/3` also takes the compiler's test-block bounds for the `.spi` and the `_real.spir` (rows of name, header row, first and last body row): a test body then runs to the row the compiler's tokenizer ends it at, so a column-0 continuation line of a `"""` string or a `(* *)` comment stays in the test.
`///` doc runs come back as markdown cells, and a `#### name (test)` heading is added only where a test's
name would not follow from the heading above it, so `--path x.spi --livemd-path x.livemd --export-only`
writes a Livebook view of the file and `--path x.livemd --export-only --with-tests --spi-path x.spi`
writes it back byte for byte.

On Windows, if another Erlang comes first on `PATH` (Chocolatey's `erl` does), the VM can
fail at boot with "corrupt atom table". Put the OTP that matches this Elixir first.
Scoop Erlang and Elixir are the pair this package is tested with.

## Development

```
mix deps.get
mix compile --warnings-as-errors
mix test
```

`mix test` includes two live compiles when the compiler DLL, the core package, `dotnet`,
and `rustc` are all present. The other tests fake those three stages.
The runner tests use real process trees.

## Running a notebook from the command line

`pwsh spi/run_notebook.ps1 --path <nb.livemd> [--output-path <ipynb>] [--spi-path <spi>] [--export-only] [--no-html] [--no-spi] [--test <name>[,<name>]] [--output-dir <dir>]`
(`mix spiral.notebook` behind it) runs every cell. It writes `<nb>.livemd.ipynb` (or `--output-path`); on success it also writes
the `.spi` export (`--no-spi`: none, for a notebook whose export is F#) and `<ipynb stem>.html` (`<nb>.livemd.html`),
which `Spiral.Cells.Html` renders from the ipynb itself: markdown cells, code cells colored by the compiler's semantic
token classes (`SpiralCompiler tokens <file>`, the classes the editor gets; plain text when the installed compiler lacks the
verb), outputs and a test badge per test cell, with a mobile viewport. No Python or jupyter is involved.
`mix spiral.html <ipynb>...` renders any ipynb the same way (`scripts/core.ps1`'s PowerShell notebooks use it); only a notebook
whose kernelspec language is `spiral` is colored. `--livemd`
also writes a Livebook copy next to the ipynb (`<ipynb stem>.livemd`), so a gh-pages clone can open the notebooks.

`run_notebook.ps1` first tries the warm daemon (`SPIRAL_CELLS_COMPILER_PORT`, else 13905): it sends its arguments as a
`notebook` request and prints the daemon's `spiral-tests` lines and exit code, so no `mix` or BEAM starts. The daemon
refuses (`stale`) when it serves another Cells checkout, or when Cells's sources or beams changed since it started (then
it retires itself after the reply); the script then runs `mix spiral.notebook` as before, which afterwards launches a
daemon in the background when none listens, for the next run. `SPIRAL_CELLS_WARM=0` skips the warm daemon;
`SPIRAL_CELLS_MEMO=0` is passed on as `--no-memo`.

On a fresh machine the script first provides what the route needs, each step only when its output is missing: the
.NET 11 SDK (`apps/compiler/scripts/install-dotnet.ps1`, into the spiral-bin cache) and the single-flight
`SpiralCompiler.dll` (`scripts/build.ps1 -Mode single-flight`), then `mix local.hex`/`local.rebar --if-missing` and
`mix deps.get` when `deps/kino` is absent. It passes the resolved `SPIRAL_DOTNET`, `SPIRAL_COMPILER_DLL` and
`SPIRAL_COMPILER_PACKAGE_DIR` on to mix.

### Test report

Every run reports the notebook's test cells (`--test`, `--test static`, `--ignore`; in a `.spi`, its `test` blocks).
`Document.tests/1` names them the way `to_spi_tested/1` does, so a report names a `.spi` test by its `test <name>` header.
A test has three names. Its identity (`name`) is the `test <name>` header, derived from the nearest heading: ASCII
letters and digits lowercased, letters of the Latin, Greek, Cyrillic, Armenian, Hebrew, Arabic, Hangul, kana and CJK
blocks kept (lowercased by Unicode rules), everything else a `_` separator, so `### Сложение` gives `test сложение`
and headings in other scripts no longer collapse to one name. Its `title` is the heading text itself. Its `symbol` is
safe for any backend or shell: the identity when that is ASCII, otherwise `test_` and each non-ASCII code point as
`u<hex>_` (`test_u52a0_u6cd5_` for `加法`). Pure-ASCII headings name tests exactly as before.
A test's verdict is its cell's own evaluation result: it passed when every target it ran succeeded (compile, build, exit 0),
failed on a compile error, a non-zero exit or a timeout, and is unsupported when none of its `///>` targets has its tool on
this machine (`` `lua` was not found``, `gleam`, `gcc`, ...; a missing compiler, `dotnet` or core package is a failure).
A native target (`///> c`, `cpp`, `delphi`) passes only when its program exits 0: the exit code is no value channel,
so an assertion that exits 1 fails the test. `///> c` is built like the compiler matrix builds its C rows:
`gcc -std=c11 -O2 -w -fwrapv [-include <notebook dir>/c-shim.h] -o cell main.c -lm` (`cl /O2` with MSVC). The Rust host is built like the matrix's Rust rows too: `rustc +1.99.0 -C opt-level=2 -A warnings --edition 2024`
(`+1.99.0` only when `rustc` is rustup's proxy). `///> delphi` uses `dcc32` (`SPIRAL_DCC`) when present, else Free Pascal
the way the matrix builds its Delphi rows: `fpc -Px86_64 -O2 -Mdelphi` (`SPIRAL_FPC`, `fpc` on PATH, or scoop's freepascal).
`///> lean` runs the `--backend Lean` output with `lean --run` on the matrix's toolchain `leanprover/lean4:v4.35.0`:
`SPIRAL_LEAN` (an elan proxy, given `+leanprover/lean4:v4.35.0`), else that toolchain's own `lean` under `ELAN_HOME`,
`~/.elan` or scoop's elan, else `lean` on PATH with `+leanprover/lean4:v4.35.0`.
A cell's `///>` lines are its whole target list (no Rust run beside them).
A test without `///>` lines runs on its file's default targets: the `///>` lines of the file's `static` prelude test
(`///> c` above `test prelude static =`), else `SPIRAL_CELLS_DEFAULT_TARGET` (or `default_target:`, e.g. `fsharp`).
A test with its own `///>` lines keeps them and also inherits the `-d` crates of the default target with the same tool
(`///> rust -d serde_json` on the prelude gives every `///> rust` test of the file `serde_json`).
With none of those, a test without `///>` lines fails with `test <name> has no ///> target` instead of running on Zig,
the default every other cell still gets; `mix spiral.targets <paths> [--check]` lists such tests without running anything.
`SPIRAL_CELLS_DEFAULT_TARGET=rust` keeps the Rust host (an empty variable is unset on Windows); `default_target: ""` does too.
The `static` prelude itself is never compiled or run: its `open`s and types reach every later test, which compiles them,
and its row says `static` (counted in `static`, not in `executed`). A static block whose body is only `open` lines
(after its `///` lines) is the file's prelude, not a test: its row says `prelude`, it is counted in `preludes`, and it is
left out of `discovered`, which then counts real tests only. A static block that defines something stays `static`.
`///> zig` compiles the Zig backend and runs it with `zig run` (`SPIRAL_ZIG`, else `zig` on `PATH`), on the self-hosted
x86_64 backend (`-fno-llvm`, about 2 s for a new cell against about 9 s through LLVM; `SPIRAL_CELLS_ZIG_LLVM=1` forces LLVM)
with a global cache kept in the spiral-bin cache directory (`cells-zig-cache`). `///> wgsl` compiles
the WGSL backend, validates it with `naga` when found (`SPIRAL_NAGA`), and runs it with `spiral-wgsl <file>`:
`SPIRAL_WGSL_RUN`, else `<spiral-bin>/toolchains/wgsl-run/release/spiral-wgsl[.exe]`. The runner exits with the shader's
`main` status: 0 passes, 3 (no GPU adapter) is unsupported, any other code fails; no runner is unsupported, never a pass.
WGSL test bodies cannot print, so they end in an `i32` status expression.
A target whose tool is missing is skipped and listed in the test's `unavailable` while the others still run.
`--ignore` cells are skipped: not compiled, and not a definition of later cells.

stdout gets one `spiral-tests file {json}` line per source file (a `.spi` run covers `x.spi` and, for `--real` tests,
`x_real.spir`) and one `spiral-tests total {json}` line, each with `discovered`, `executed` (passed + failed), `passed`,
`failed`, `skipped`, `unsupported`, `filtered` (not selected by `--test`) and `not_run` (stopped before it ran); the file
lines also list `failed_tests`. Each test row lists its `targets`: one `{target, status, ms}` per `///>` line (`rust` for the
default host), `status` being `passed`, `failed`, `unsupported` or `not_run` (after an earlier target failed), `ms` the
target's compile plus run time; a recalled test shows the targets of the run it was recalled from. The ipynb metadata holds the same counts and every test (`spiral_tests`), and each test
cell's metadata its own entry (`spiral_test`). A failed test fails the run (non-zero exit, no exports written); the plain
compile of the same `.spi` is unaffected because the compiler skips test blocks. A test body is compiled as one local
scope (`inl spiral_cells_test () = <body>`), so tuple patterns (`inl a, b = ...`) and a `let rec`
over the body's own locals work; `static` bodies stay top level, since they hold the shared `open`s and types. Main then
returns `0i32` after the call: `spiral_cells_test ()` when the body ends in an `_assert`, else `inl _ = spiral_cells_test ()`,
which takes a unit or a value alike. A test therefore compiles once; before, a body ending in another unit expression
or in a value was compiled a second time after the first compile failed (physics.spi: 58 compile requests for 39 tests
before, 40 after). A test with a `///> wgsl` line is the exception: its main ends in `spiral_cells_test ()`, so the body's
`i32` is the status every target of that test exits with. Until 2026-10-20 the wgsl body's status was bound to `_` and
main returned `0i32`, so every `///> wgsl` test passed.
`--path` may be repeated; with several,
`--output-dir <dir>` writes each notebook's `<name>.ipynb` there (`--output-path` takes a single `--path`). With several
`--path`, each `--test` name runs in the files that have it, files with none of them are skipped, and only a name no
file has is an error. `--gate` runs the files memo-off without html, writes their notebooks to a scratch directory it
deletes afterwards (unless `--output-dir`/`--output-path` is given) and retires the compilers at the end. `--metrics <dir>`
writes `<dir>/tests.tsv` with one row per target of every test-mode block (`File`, `Test`, `Target`, `Status`, `Ms`,
`Memo`; `File` is the source's stem), the columns tibia's `scripts/build.ps1` writes to `target/ci-metrics`.

A `.spi` run plans one compile per test block plus one for the whole file (all definitions and real cells, its
output on the last definition cell), not one per definition cell: a `.spi` top level holds only definitions, so the
per-cell compiles showed nothing and cost a compile of the growing prefix each. `evaluate/2` takes `plan: :tests` for
that and defaults to `plan: :cells` (one compile per cell, each cell's output shown).

### Expected compile errors

`test rejects_mixed_units fails EJP0040 "Unification failure" =` (the code is optional: `fails "Unification failure"`)
passes only when compiling the definitions before it plus its body fails with a diagnostic that contains the message and,
when given, the code. A program that compiles, a different diagnostic, or a failure after compiling fails the test; a
matching message without any `E...` code fails too and says so. In a notebook the cell carries
`///- --test --fails EJP0040 "Unification failure"`; the report's `mode` is `fails`. A code is a prefix and either a
number or the diagnostic's case name (`EJP0040`, `ETY-TermError`) and must match whole: `ETY-Term` does not match
`ETY-TermError`. The type checker names its codes after the error case, so
`test rejects_mixed_units fails ETY-TermError "Unification failure" =` pins both.
The matching diagnostic must also be located in the test's own body (at or after the program line that holds the body's
first line): a definition before the block that fails with the same message makes the test fail with
`reported only before the test body`, so a broken module can no longer make an unrelated negative pass.

### Build-only tests

`test x build_only =` (a cell's `///- --build-only`) compiles and builds every listed target but never runs it: the Rust
host is built with `rustc`, Gleam targets with `gleam build`, `c` with the C compiler, the others are compiled only. Such a
test reports `built` (its own count, inside `executed` but not `passed`); a compile or build failure fails it. It is for
tests that cannot run headless yet (the Lustre UI tests, which need a DOM).

### Agreeing targets

A test with several `///>` targets passes only when every target passes and prints the same as the first one that
printed anything. Before comparing, each target's stdout is normalized: blank lines and outer spaces dropped, the Lua
runner's `String("...")` wrapping undone, double quotes dropped (string quoting differs per backend), ANSI colors, Gleam compile warnings, F# `main.fsx(L,C): warning FSnnnn:` lines, trace lines (`hh:mm:ss
Nx module / ...`) and `at ...` stack frames dropped, union constructors written one way (`US0_Some(v0=1)`,
`US1_Some 1`, `Us0Some(1)` all become `Some(1)`; `US0_None()`, `US0_None` and `None()` become `None`), arrays and tuples written one way (`[|0; 2|]`, numpy's
`[0 2]` and `[0, 2]` all become `[0, 2]`; `[||]` becomes `[]`; `struct (a, b)` becomes `(a, b)`), F# numeric suffixes (`3un`) and
whitespace runs folded, a last line `0` (the main status some runners print) dropped, and every
number written with at most 6 decimals (`+1.570796`, `1.5707963267949` and `1.570796` agree). A target that printed
nothing is not compared. Otherwise it fails with `targets disagree: lua printed
"1", gleam printed "1.0"` and the differing target's row says `disagrees`. `test name no_agree "reason" =` (a cell's
`///- --no-agree "reason"`) keeps only the pass rule; the reason is required (a bare `no_agree` fails the test without
running it), each test row carries it as `no_agree`, and the report counts the opt-outs per reason in `no_agree_reasons`,
so they cannot grow silently. Cells that are not tests, and `print_code` tests, are not compared.
The lib's `_assert_*` helpers print through `sm'.show`, which already writes records, tuples, unions and arrays the same
way on every backend, so for them the union and collection rules only matter for values printed natively (`#?`, `#?*`).

### Accepting actual values

`--accept` (`.spi` only) rewrites the expected literal of each failed test whose output holds
`__assert_eq { actual = A; expected = E }`: inside that test's block, the failing `_assert_eq E` literal becomes `A`, its
type suffix kept (`_assert_eq 5i32` -> `_assert_eq 4i32`), under a `<file>.accept.lock`. The literal rewritten is the failing
assert's own: with `k` passing `__assert_eq { expected = ... }` lines in the output, it is the `k+1`-th `_assert_eq` written in the
test's block, and it must be the literal `E` (otherwise the test is refused), so equal literals elsewhere are never touched. A flat
tuple of plain literals is rewritten element by element, each element keeping its own suffix
(`_assert_eq (0i32, 0u32)` -> `_assert_eq (3i32, 4u32)`); a nested tuple is refused, since it prints flattened. An accepted test is run again, and accepted again, until it passes or fails in a way that cannot be
accepted (at most 25 rounds), so every assertion of the test is pinned in one run. Such tests report `accepted` (counted in
`executed` and `accepted`), and the run passes when nothing else failed. A test fails, with `accept_refused` saying why,
when its block has no matching literal, two on one line, a literal that ran more often than it is written (a loop or a
helper), an actual value that is neither a plain literal nor a flat tuple of them, or a later failure that is no mismatch. Each
`spiral-tests file` summary line carries those reasons as `accept_refused` (test name -> reason). Without the flag a mismatch
fails and the file is not touched.

### X compatibility

Edition-3 sources are meant to survive being posted on X. When the nearest `package.spiproj` above a notebook says
`edition: 3` (or `--x-compat` is passed), a run prints one `x-compat <file>:<line>:<col>: <kind>: <text> (<hint>)` line per
thing X would rewrite: `#` before a letter (hashtag), `@` before a name (mention), `$` before letters (cashtag) and text
X would autolink as a domain (`cell.ai`, `listm.map`; shortened to a 23-character t.co link). These are warnings: the run's
result does not change. `mix spiral.x_compat <file or dir>...` is the CI report over `.spi`, `.spir` and `.livemd`
files: every finding plus a summary line, always exit 0. The checker is `Spiral.Cells.XCompat` (IANA TLD list in
`priv/tlds.txt`, twitter-text weights); the `x` repository's `apps/sim` (formerly `apps/xsim`) uses it for its thread frames and per-post limits.

### Target audit

`mix test --only target_audit` (left out of the default run; it compiles and runs for real, so run it inside the heavy
gate) gives every runner a deliberately failing test and a passing twin: the Rust host, `c`, `cpp`, `delphi`, `fsharp`,
`python`, `cuda`, `typescript`, `lua`, `gleam`, `gleam -t javascript`, `zig` and `wgsl`. The failing one must fail with
its assertion text and the twin pass, or both be unsupported (a missing tool); a failing test that passes fails the audit.
Erlang Gleam targets are built and run by Cells itself: `gleam build` in the cell's own `gleam/` package with the CLI's
dependencies, then the built `main:main()` under `erl` (so Gleam's own warnings never mix into the program output); `-t
javascript` test cells the same way, run with `bun`; other `-t javascript` cells only build through the CLI.

### Result memo

A step that succeeded is remembered on disk (`%LOCALAPPDATA%/spiral-bin/cells-results`, or `SPIRAL_CELLS_MEMO_DIR`;
the newest 5000 entries are kept), keyed by everything that decides its result: the step's whole program (definitions
before it and its body) and real module, its `///>` targets, the compiler DLL (path, size, mtime), the core package and
every `--package` the program mounts (the sha256 of each `package.spiproj` and of the modules it lists, folders and path
dependencies included; files a project does not list are left out; a module's `test` blocks and `///` lines are left out too,
since the compiler skips them, so a notebook that is also a module of the package it mounts keeps its other tests' entries
when one test or its accepted literal changes), the md5 of the Cells modules on the compile, run
and verdict path (not the editor or report ones), and the tool options (`print_code`, tool paths). A re-run recalls such a step
with its outputs instead of compiling, and the daemon is not even started when every step is recalled; failures,
timeouts and unsupported steps always run again. Editing one test changes only that test's program, so only it runs;
editing a definition reruns the steps after it. The report marks each run test `memo: hit|miss` and the
`spiral-tests` lines count `memo_hits`. `SPIRAL_CELLS_MEMO=0` (or `memo: false`) turns it off; it is off when compile
or run stages are faked (`compile:`, `execute:`, ...) unless `memo: true` is passed. Target toolchains (rustc, gleam,
lua, ...) are not part of the key: after upgrading one, clear the directory.

`--test <name>` (repeatable, or a comma list; a name or a symbol) runs only those test cells. Each cell's program already holds the
definitions of the cells above it (packages, opens, definitions, static tests, real cells), so one compile per test
suffices; host-language cells don't run. An unknown name fails with the list of the notebook's tests. Filtered runs
write no exports.

`Spiral.Cells.Notebook.evaluate(doc, opts)` is the same evaluation in memory: no notebook file is read or written. It
returns `%{status, outputs, durations, verdicts, unavailable, report}` by cell index (`report` as in the ipynb metadata);
`opts` takes the run options plus `root:`, `path:` or `spiral_lib:` (the lib package to mount) and `tests:`.
`run_report/2` is `run/2` that also returns the report.

A cell's `///- --timeout <ms>` directive is its budget. It wins over the smart cell's `timeout` field (a smart cell
always passes one) and over the 300 s default. The first Spiral cell's `--timeout` (in a `.spi`, the file's first `///-` line)
is also the budget of every test cell without its own and of the whole-file run.

### F# cells (`Spiral.Cells.FsiSession`, `Spiral.Cells.FsiChain`)

A notebook's F# cells and `#!import` cells run in order on one long-lived `dotnet fsi --quiet` per notebook, each as its
own submission, like .NET Interactive's F# kernel did. A later submission may redefine a type of an earlier
one (polyglot's `Notebooks.livemd` imports `.fsx` files that each define `US0`). Spiral cells still run in parallel beside
the F# chain.

- `#!import <file>.fs|.fsx` submits the file's text. `#!import <nb>.livemd` runs that notebook's F# cells and its own
  imports, each as a submission (its Spiral cells are skipped with a note). A relative path resolves against the
  importing file's directory, then the notebook's. A mid-cell `#!import` splits the cell; the lines after it are the
  next submission.
- fsi's working directory is the notebook's directory (relative `#r` paths resolve against it).
- The session first opens what the .NET Interactive F# kernel opens (`System`, `System.IO`, `System.Text`,
  `Microsoft.DotNet.Interactive.Formatting`) and references that `Formatter` from its NuGet package
  (`SPIRAL_CELLS_FORMATTING_DLL` overrides it with a dll), so `Formatter.ListExpansionLimit`, `Formatter.Register` and
  `x.ToDisplayString ()` behave as they did under .NET Interactive. Without it a shim stands in (`%A`).
  `x.Display ()` prints the value with its preferred formatter.
- A cell shows its stdout/stderr and, when its last line is a non-unit expression, the value (`it`). It fails on
  `error FS....` or `Stopped due to error`; positions read `input.fsx(line,col)` relative to the cell. Later cells still
  run.
- Budget: `///- --timeout <ms>` in the cell, else 300 s. A cell that times out kills the fsi process tree; the F# cells
  after it fail with `skipped: the F# session was killed ...` instead of running without their definitions.
- `SPIRAL_CELLS_FSHARP=script` (or a `:host` callback) restores the older path: each F# cell re-runs all earlier ones as
  one `dotnet fsi --exec` script, and imports don't run.

## CI

dice's and alphabet's gh-pages workflows run every notebook through this route: their `build.ps1` notebook steps call
`spi/run_notebook.ps1 --path <nb>.livemd` (`--spi-path <nb>.spi`, or `--no-spi` for
the F# notebooks dice_fsharp and hangul). What a runner needs:

- Elixir >= 1.18 with a matching OTP (`erlef/setup-beam` with `elixir-version` set; `otp-version` + `gleam-version`
  alone install no Elixir), and Gleam >= 1.14: `mix compile` regenerates `src/spiral_cells/domain.gleam` from
  `spi/*.spi` with the Spiral compiler (`--backend Gleam`) and builds it with `gleam build`, against the
  `gleam_stdlib` that `manifest.toml` pins (1.0.5 needs Gleam 1.14). `src/` and `build/` are not committed.
- Nothing else for Cells itself: run_notebook.ps1 installs the .NET 11 SDK and builds the compiler into the spiral-bin
  cache (`~/.cache/spiral-bin` on Linux) when they are missing, and runs `mix deps.get` (see "Running a notebook from
  the command line"). CI's setup-dotnet .NET 9 is not enough for the compiler (net11.0). Set `SPIRAL_COMPILER_DLL` /
  `SPIRAL_DOTNET` / `SPIRAL_GLEAM` when the tools live elsewhere.
- `rustc` for Spiral cells; the `spiral` CLI (`workspace/target/release/spiral`, which the repos' init builds) for
  `///> rust -c/-d` cells, plus what those cells' programs need (NEAR sandbox for contract cells, pandoc/xelatex/
  hangulize for alphabet documents' app test); `dotnet` for F# cells (the cache's .NET 11 `fsi`).
- The compiler daemon starts on 127.0.0.1:13905 (detached: on Unix in its own session via `setsid`); a runner ends it
  with the job. Two checkouts that share one loopback (WSL with mirrored networking next to a Windows dev daemon) need
  different `SPIRAL_CELLS_COMPILER_PORT`s.
