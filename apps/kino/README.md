# Spiral.Kino

A [Livebook](https://livebook.dev) smart cell for [Spiral](https://github.com/mrakgr/The-Spiral-Language).
Write Spiral code in the cell. It gets compiled and run, and the program output, the
value of the last expression and any compile errors show up in the cell.

The OTP application is `:spiral_kino`. The Elixir modules are `Spiral.Kino` and
`Spiral.Kino.*`. The hex package this cell is built on is already named `kino`, so the
application name stays distinct from that dependency.

## Requirements

- Livebook **v0.19+**. Kino minor versions track Livebook minor versions, and this
  package uses `kino ~> 0.19.1`. Elixir **1.18+** is required for the built-in `JSON`
  module.
- A polyglot checkout with its local .NET tools restored (`dotnet tool restore` in the
  polyglot root). Cells run through the polyglot fork of `dotnet repl` (pinned in
  `polyglot/.config/dotnet-tools.json`), which hosts the Spiral .NET Interactive kernel.
  The global/upstream `dotnet-repl` has no `spiral` kernel.
- `dotnet` on `PATH`. Builder backends need their own toolchains: cargo for Rust,
  node for TypeScript, python for Python/CUDA, gleam, lua, and so on.

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
{:ok, result} = Spiral.Kino.run("1i32 + 2i32", backend: "fsharp", timeout: 120_000)
result.value  #=> "3"
```

## The cell

| Field | Effect |
| --- | --- |
| Backend | `F#` (default): the code is compiled to F# and evaluated in .NET Interactive, and the value of the last expression is shown. The others add a `///>` builder line: `rust`, `typescript`, `python` (these three go F# → Fable), `cuda` (Python + CUDA), `cpp`, `gleam`, `lua`. |
| Builder args | Appended to the `///>` line, e.g. `-d chrono regex` for Rust crates. |
| Timeout (s) | Hard wall-clock limit for the whole run: startup + compile + run. When it expires, the whole process tree is killed and the cell fails with `Spiral.Kino.TimeoutError`. |
| Show generated code | Adds `--print-code`. The generated code is printed before the program output. |

The code can also carry kernel directives directly. These are the semantics of
`polyglot/apps/spiral/Eval.fs`:

- `///- <args>`: kernel arguments, e.g. `--timeout N` (ms, compile + eval inside the
  kernel), `--print-code`, `--trace`, `--real`, `--cache`, `--package NAME`. **Only the
  first `///-` line is read.** The cell therefore folds its options into your first
  `///-` line, or inserts one, and never adds a second line.
- `///> <builder> [args]`: every such line is used, so one cell can target several
  backends. If your code already has a builder line for the backend chosen in the form,
  no duplicate is added.
- `////> ...`: a disabled directive (a comment).
- The kernel wraps the last top-level expression(s) into `main`. You write plain cell
  code, like in a `.dib` `#!spiral` cell.

Errors:

| Situation | Raised |
| --- | --- |
| Compile (parse/type) error, or an exception while evaluating | `Spiral.Kino.SpiralError`. The message is the compiler's, with the temp package path stripped. Positions such as `main.spi:5:12` refer to the kernel's *wrapped* `main.spi`, not to editor lines. Any stdout printed before the error is still shown. |
| Timeout | `Spiral.Kino.TimeoutError` (the process tree is already killed). |
| `dotnet repl` failed, nonzero exit, no or invalid notebook output, no Spiral kernel | `Spiral.Kino.ProcessError`, with a log tail and a hint. |

## How it works

1. The form options are merged into the code (`Spiral.Kino.Directives`).
2. The code is written as a one-cell `.dib` into a temp directory
   (`Spiral.Kino.Notebook.dib/1`).
3. `dotnet repl --run cell.dib --output-path cell.dib.ipynb --exit-after-run` runs with
   the polyglot root as the working directory, so the local tool manifest picks the
   fork with the Spiral kernel.
4. The outputs are read from the `.ipynb` (`Spiral.Kino.Notebook.parse_ipynb/1`):
   - stdout streams become cell output;
   - the `dni-plaintext` value becomes the cell result;
   - other HTML is rendered with `Kino.HTML`;
   - `error` outputs are raised.
5. The temp directory is removed (unless `keep_files: true`).

### Process handling (`Spiral.Kino.Runner`)

- The child runs in an Erlang port (`spawn_executable`, no shell, so there are no quoting
  issues). stdout and stderr are both captured, merged in write order, and the exit status
  is returned.
- The port is owned by a watcher process under `Spiral.Kino.TaskSupervisor`. The watcher
  is **not linked** to the evaluating process; it monitors it instead.
- On timeout, and also when the caller dies (Livebook *Stop* or re-evaluation kills the
  evaluator), the watcher kills the whole tree. On Windows it uses
  `taskkill /T /F /PID <pid>`; on Unix it walks the tree with `pgrep -P` and sends
  `SIGKILL`.
- On a graceful shutdown of the Livebook runtime (the app's supervisor stops), the
  watcher also kills the tree. This path is implemented but not covered by a test.
- Limitations:
  - The tree is found through parent PIDs. A grandchild whose parent already exited
    can't be found that way. The Spiral toolchain doesn't currently detach processes like
    that.
  - If the runtime VM is killed abruptly (e.g. the BEAM OS process is terminated),
    nothing is left to clean up, and running children survive on Windows.

  A Windows Job Object or a Unix cgroup/process group would close both gaps.
- The Unix kill path (`pgrep`/`kill`) is written but has only been exercised on
  Windows.

### Configuration

| What | How |
| --- | --- |
| polyglot root | Resolved in this order: the `:polyglot_root` option, then `config :spiral_kino, polyglot_root: ...`, then the `SPIRAL_KINO_POLYGLOT_ROOT` env var, then the `polyglot` checkout next to this `spiral` checkout (`spiral/apps/kino/lib/spiral/../../../../../polyglot`). |
| `dotnet` executable | `:dotnet` option; defaults to `PATH`. |
| Editor highlighting | `config :spiral_kino, editor_language: "javascript"` (the default). Livebook's CodeMirror editor has no ML/F# mode. JavaScript is the closest available: it highlights `//` comments, the `///` directives, strings, numbers and `let`/`if`/`then`/`else`. Primes in identifiers (`am'.vec`) are read as string starts. Use `nil` for no highlighting. |

## Trade-offs and alternatives

- **Why `dotnet repl` and not a direct compiler CLI?** The prebuilt
  `polyglot/apps/spiral/dist/Supervisor.exe` has a
  `--build-file in.spi out.{fsx,py,lua,gleam,cpp}` mode, which would be faster: no
  .NET Interactive, and the output program runs directly. However, the current binary
  embeds the in-development (Hopac) compiler. It stalls on a trivial snippet: it warns
  about a blocking call inside a Hopac job and never finishes. (Outside the workspace it
  also logs workspace-root warnings, but it falls back to its build-time path.) The
  `dotnet repl` route works today and keeps
  the exact kernel semantics: directives, builders, value display. The cost is about
  15–20 s of cold start per cell. If `Supervisor --build-file` becomes reliable, a second
  engine can go behind the same `:command` hook.
- **Each cell is independent.** Every run is a fresh kernel process, so definitions are
  not shared between Spiral cells, unlike consecutive `#!spiral` cells in a `.dib`.
- **Side effects outside the temp directory.** The Spiral kernel persists each compiled
  cell under `polyglot/target/spiral_Eval/packages/<hash>/`. This is the kernel's normal
  behaviour, the same as when running `.dib` notebooks.
- **Erlang on Windows:** if Livebook (or `mix`) is started from a shell where another
  Erlang comes first on `PATH` (e.g. Chocolatey's), the VM may fail to boot with
  "corrupt atom table". Put the right OTP first.

## Development

```
mix deps.get
mix compile --warnings-as-errors
mix test
```

The tests don't need .NET. A fake `dotnet repl` (an escript) replays real `.ipynb`
outputs captured from the Spiral kernel (`test/fixtures`). The runner tests use real
process trees: an escript that starts a grandchild BEAM. They check that a timeout, and
also killing the caller, leave no process alive.
