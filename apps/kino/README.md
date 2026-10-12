# Spiral.Kino

A [Livebook](https://livebook.dev) smart cell for [Spiral](https://github.com/mrakgr/The-Spiral-Language).
Write Spiral in the cell. The single-flight Spiral compiler emits Rust, `rustc` builds it,
and the cell shows program output, the `i32` result, and compile errors.

The OTP application is `:spiral_kino`. The Elixir modules are `Spiral.Kino` and
`Spiral.Kino.*`. The hex package this cell is built on is already named `kino`, so the
application name stays distinct from that dependency.

## Requirements

- Livebook **v0.19+** and Elixir **1.18+** (`kino ~> 0.19.1` uses the built-in `JSON` module).
- The single-flight `SpiralCompiler.dll` (a .NET program). The default path is
  `%LOCALAPPDATA%/spiral-bin/bin/single-flight/SpiralCompiler/Release/net11.0/SpiralCompiler.dll`.
- `dotnet` that can load that DLL. The cache copy under
  `%LOCALAPPDATA%/spiral-bin/toolchains/dotnet/dotnet.exe` is used when it is present.
- `rustc` (edition 2021).
- The Spiral core package (`core/package.spiproj`) from
  `spiral/deps/The-Spiral-Language/VS Code Plugin` (the fork spiral's `scripts/init.ps1` clones; polyglot's clone of it
  is the fallback). The cell links `|core-` and a
  one-module `console.write_line` implemented in the cell package.

## Usage

Add the package to a notebook's setup cell:

```elixir
Mix.install([
  {:spiral_kino, path: "C:/home/git/spiral/apps/kino"}
])
```

Then pick **+ Smart → Spiral**. The cell generates a call like this one:

```elixir
Spiral.Kino.eval!(
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
{:ok, result} = Spiral.Kino.run("1i32 + 2i32", timeout: 120_000)
result.value #=> "3"
```

## The cell

| Field | Effect |
| --- | --- |
| Timeout (s) | Wall-clock budget for compile, `rustc`, and the run together. When it expires, the process tree of the stage in progress is killed and the cell fails with `Spiral.Kino.TimeoutError`. |
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
| Parse or type error | `Spiral.Kino.SpiralError`. The message has the temp directory stripped. Positions such as `main.spi:5:12` refer to the wrapped `main.spi`. |
| Timeout | `Spiral.Kino.TimeoutError`. The process tree is already killed. |
| Compiler, `rustc`, or the cell binary failed to start, or the generated Rust still contains an emit marker (`__spiral_emit_rust`) | `Spiral.Kino.ProcessError`. |

## How it works

1. `Spiral.Kino.Directives` strips directives and `Spiral.Kino.Cell` wraps `main`.
2. A temp package is written (`package.spiproj`, `console.spi`, `main.spi`) under `System.tmp_dir()/spiral_kino`.
3. `dotnet SpiralCompiler.dll --backend Rust main.spi main.rs` runs with `SPIRAL_WORKSPACE_ROOT` and `SPIRAL_COMPILER_PACKAGE_DIR` set.
4. Statement-form `__spiral_emit_rust` calls (the former `Fable.Core.RustInterop.emitRustExpr` spelling too) are inlined, and `std::process::exit(main.join().unwrap())` is rewritten so the `i32` is printed as `SPIRAL_KINO_VALUE:<n>` and the process exits 0.
5. `rustc --edition 2021 -o cell.exe main.rs` builds the file, and the binary runs in that directory.
6. The temp directory is removed unless `keep_files: true`.

### Process handling (`Spiral.Kino.Runner`)

- The child runs in an Erlang port (`spawn_executable`, no shell). stdout and stderr are captured together, and the exit status is returned.
- The port is owned by a watcher under `Spiral.Kino.TaskSupervisor`. The watcher monitors the caller and is not linked to it.
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
| Core package directory | `:package_dir` | `SPIRAL_COMPILER_PACKAGE_DIR` | `spiral/deps/The-Spiral-Language/VS Code Plugin`, else `polyglot/deps/...` next to it |
| Package fallback root (a cell's `--package` path not found beside the notebook) | `:workspace_root` (`:polyglot_root`) | `SPIRAL_KINO_WORKSPACE_ROOT` (`SPIRAL_KINO_POLYGLOT_ROOT`), or `config :spiral_kino, workspace_root: ...` | this `spiral` checkout |
| Compiler daemon port | - | `SPIRAL_KINO_COMPILER_PORT` | `13905` |
| Compiler server memory cap (MB; 0: none) | - | `SPIRAL_KINO_DAEMON_MAX_MB` | `2500` |
| Compiles per compiler server (0: no limit) | - | `SPIRAL_KINO_DAEMON_MAX_COMPILES` | `0` |

By default a cell compiles through one shared, warm compiler: the first cell starts a detached
`mix spiral.compiler_daemon` on `127.0.0.1:13905` (or `SPIRAL_KINO_COMPILER_PORT`), and it keeps running after the
Livebook session ends so later sessions reuse it. `SPIRAL_KINO_COMPILER=process` opts out: each cell then starts its
own compiler process, and no daemon is started. Passing any of `:compiler_dll`, `:dotnet`, `:package_dir`,
`:workspace` or `:env` also compiles in a separate process. `SPIRAL_KINO_BRIDGE_TRACE=1` makes the daemon's socket
bridge log every request and response to `<socket>.trace` (off by default).
After each compile the daemon checks its .NET compiler server: past the memory cap (working set) or the compile
count it stops it, logs `compiler recycled after ...`, and the next compile starts a fresh one (a cold compile).
The daemon itself, its port and its queue stay up. Its code stamp is the md5 of the daemon module's code, so every
build of the same code (this app, an app that depends on it) shares one daemon instead of replacing it.

Editor highlighting is `config :spiral_kino, editor_language: "javascript"` (the default).
Livebook's editor has no Spiral mode. JavaScript highlights `//` comments, strings, numbers,
and `let`. Primes in identifiers (`am'.vec`) are read as string starts. `nil` turns highlighting off.

Each cell is a fresh process. Definitions are not shared between cells. `Spiral.Kino.Document` reads and
writes notebooks (`parse_livemd/1`, `to_livemd/1`, `to_cell_text/1`, `to_spi/1`, `to_spi_tested/1`, `parse_spi/2`).
`to_spi/1` keeps definitions, `open` lines, and the first `--package` directive, and it
drops `--test` cells. `parse_livemd/1` reads the smart cells `to_livemd/1` writes.
`to_spi_tested/1` keeps each `--test` cell as a `test <name> [static] [print_code] [ignore] =` block
(its `///>` targets above it, its body indented), named after the nearest heading; the compiler skips
these blocks. `parse_spi/2` reads a `.spi` and its `_real.spir` back into cells, one test cell per block,
so `run_notebook.ps1 --path x.spi` runs a source file as a notebook without writing over it. The `_real.spir` cells
go in after the same heading of the `.spi` (headings match by text; real cells come first within a section), so
`to_spi_tested/1` and `to_spir_tested/1` give both files back.
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
the `.spi` export (`--no-spi`: none, for a notebook whose export is F#) and `<ipynb stem>.html` through
`jupyter nbconvert --to html --HTMLExporter.theme=dark` with LF endings and cell ids renumbered 1..n (`<nb>.livemd.html`).
Without `jupyter` on `PATH` the html is skipped with a note.

On a fresh machine the script first provides what the route needs, each step only when its output is missing: the
.NET 11 SDK (`apps/compiler/tmp/scripts/install-dotnet.ps1`, into the spiral-bin cache) and the single-flight
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
so an assertion that exits 1 fails the test. A cell's `///>` lines are its whole target list (no Rust run beside them).
`///> zig` compiles the Zig backend and runs it with `zig run` (`SPIRAL_ZIG`, else `zig` on `PATH`). `///> wgsl` compiles
the WGSL backend, validates it with `naga` when found (`SPIRAL_NAGA`), and runs it with `spiral-wgsl <file>`:
`SPIRAL_WGSL_RUN`, else `<spiral-bin>/toolchains/wgsl-run/release/spiral-wgsl[.exe]`. The runner exits with the shader's
`main` status: 0 passes, 3 (no GPU adapter) is unsupported, any other code fails; no runner is unsupported, never a pass.
WGSL test bodies cannot print, so they end in an `i32` status expression.
A target whose tool is missing is skipped and listed in the test's `unavailable` while the others still run.
`--ignore` cells are skipped: not compiled, and not a definition of later cells.

stdout gets one `spiral-tests file {json}` line per source file (a `.spi` run covers `x.spi` and, for `--real` tests,
`x_real.spir`) and one `spiral-tests total {json}` line, each with `discovered`, `executed` (passed + failed), `passed`,
`failed`, `skipped`, `unsupported`, `filtered` (not selected by `--test`) and `not_run` (stopped before it ran); the file
lines also list `failed_tests`. The ipynb metadata holds the same counts and every test (`spiral_tests`), and each test
cell's metadata its own entry (`spiral_test`). A failed test fails the run (non-zero exit, no exports written); the plain
compile of the same `.spi` is unaffected because the compiler skips test blocks. `--path` may be repeated; with several,
`--output-dir <dir>` writes each notebook's `<name>.ipynb` there (`--output-path` takes a single `--path`). With several
`--path`, each `--test` name runs in the files that have it, files with none of them are skipped, and only a name no
file has is an error.

A `.spi` run plans one compile per test block plus one for the whole file (all definitions and real cells, its
output on the last definition cell), not one per definition cell: a `.spi` top level holds only definitions, so the
per-cell compiles showed nothing and cost a compile of the growing prefix each. `evaluate/2` takes `plan: :tests` for
that and defaults to `plan: :cells` (one compile per cell, each cell's output shown).

### Result memo

A step that succeeded is remembered on disk (`%LOCALAPPDATA%/spiral-bin/kino-results`, or `SPIRAL_KINO_MEMO_DIR`;
the newest 5000 entries are kept), keyed by everything that decides its result: the step's whole program (definitions
before it and its body) and real module, its `///>` targets, the compiler DLL (path, size, mtime), the core package and
every `--package` the program mounts (the sha256 of each `package.spiproj` and of the modules it lists, folders and path
dependencies included; files a project does not list are left out), the md5 of the Kino modules on the compile, run
and verdict path (not the editor or report ones), and the tool options (`print_code`, tool paths). A re-run recalls such a step
with its outputs instead of compiling, and the daemon is not even started when every step is recalled; failures,
timeouts and unsupported steps always run again. Editing one test changes only that test's program, so only it runs;
editing a definition reruns the steps after it. The report marks each run test `memo: hit|miss` and the
`spiral-tests` lines count `memo_hits`. `SPIRAL_KINO_MEMO=0` (or `memo: false`) turns it off; it is off when compile
or run stages are faked (`compile:`, `execute:`, ...) unless `memo: true` is passed. Target toolchains (rustc, gleam,
lua, ...) are not part of the key: after upgrading one, clear the directory.

`--test <name>` (repeatable, or a comma list; a name or a symbol) runs only those test cells. Each cell's program already holds the
definitions of the cells above it (packages, opens, definitions, static tests, real cells), so one compile per test
suffices; host-language cells don't run. An unknown name fails with the list of the notebook's tests. Filtered runs
write no exports.

`Spiral.Kino.Notebook.evaluate(doc, opts)` is the same evaluation in memory: no notebook file is read or written. It
returns `%{status, outputs, durations, verdicts, unavailable, report}` by cell index (`report` as in the ipynb metadata);
`opts` takes the run options plus `root:`, `path:` or `spiral_lib:` (the lib package to mount) and `tests:`.
`run_report/2` is `run/2` that also returns the report.

A cell's `///- --timeout <ms>` directive is its budget. It wins over the smart cell's `timeout` field (a smart cell
always passes one) and over the 300 s default.

### F# cells (`Spiral.Kino.FsiSession`, `Spiral.Kino.FsiChain`)

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
  (`SPIRAL_KINO_FORMATTING_DLL` overrides it with a dll), so `Formatter.ListExpansionLimit`, `Formatter.Register` and
  `x.ToDisplayString ()` behave as they did under .NET Interactive. Without it a shim stands in (`%A`).
  `x.Display ()` prints the value with its preferred formatter.
- A cell shows its stdout/stderr and, when its last line is a non-unit expression, the value (`it`). It fails on
  `error FS....` or `Stopped due to error`; positions read `input.fsx(line,col)` relative to the cell. Later cells still
  run.
- Budget: `///- --timeout <ms>` in the cell, else 300 s. A cell that times out kills the fsi process tree; the F# cells
  after it fail with `skipped: the F# session was killed ...` instead of running without their definitions.
- `SPIRAL_KINO_FSHARP=script` (or a `:host` callback) restores the older path: each F# cell re-runs all earlier ones as
  one `dotnet fsi --exec` script, and imports don't run.

## CI

dice's and alphabet's gh-pages workflows run every notebook through this route: their `build.ps1` notebook steps call
`spi/run_notebook.ps1 --path <nb>.livemd` (`--spi-path <nb>.spi`, or `--no-spi` for
the F# notebooks dice_fsharp and hangul). What a runner needs:

- Elixir >= 1.18 with a matching OTP (`erlef/setup-beam` with `elixir-version` set; `otp-version` + `gleam-version`
  alone install no Elixir), and Gleam >= 1.14: `mix compile` regenerates `src/spiral_kino/domain.gleam` from
  `spi/*.spi` with the Spiral compiler (`--backend Gleam`) and builds it with `gleam build`, against the
  `gleam_stdlib` that `manifest.toml` pins (1.0.5 needs Gleam 1.14). `src/` and `build/` are not committed.
- Nothing else for Kino itself: run_notebook.ps1 installs the .NET 11 SDK and builds the compiler into the spiral-bin
  cache (`~/.cache/spiral-bin` on Linux) when they are missing, and runs `mix deps.get` (see "Running a notebook from
  the command line"). CI's setup-dotnet .NET 9 is not enough for the compiler (net11.0). Set `SPIRAL_COMPILER_DLL` /
  `SPIRAL_DOTNET` / `SPIRAL_GLEAM` when the tools live elsewhere.
- `rustc` for Spiral cells; the `spiral` CLI (`workspace/target/release/spiral`, which the repos' init builds) for
  `///> rust -c/-d` cells, plus what those cells' programs need (NEAR sandbox for contract cells, pandoc/xelatex/
  hangulize for alphabet documents' app test); `dotnet` for F# cells (the cache's .NET 11 `fsi`).
- `jupyter` (nbconvert) for the html: polyglot's init installs it (`pip install -r requirements.txt`). Without it the
  ipynb is still written and the html is skipped with a note.
- The compiler daemon starts on 127.0.0.1:13905 (detached: on Unix in its own session via `setsid`); a runner ends it
  with the job. Two checkouts that share one loopback (WSL with mirrored networking next to a Windows dev daemon) need
  different `SPIRAL_KINO_COMPILER_PORT`s.
