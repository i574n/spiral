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
  `polyglot/deps/The-Spiral-Language/VS Code Plugin`. The cell links `|core-` and a
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
| Compiler, `rustc`, or the cell binary failed to start, or the generated Rust still contains `emitRustExpr` | `Spiral.Kino.ProcessError`. |

## How it works

1. `Spiral.Kino.Directives` strips directives and `Spiral.Kino.Cell` wraps `main`.
2. A temp package is written (`package.spiproj`, `console.spi`, `main.spi`) under `System.tmp_dir()/spiral_kino`.
3. `dotnet SpiralCompiler.dll --backend Rust main.spi main.rs` runs with `SPIRAL_WORKSPACE_ROOT` and `SPIRAL_COMPILER_PACKAGE_DIR` set.
4. Statement-form `emitRustExpr` calls are inlined, and `std::process::exit(main.join().unwrap())` is rewritten so the `i32` is printed as `SPIRAL_KINO_VALUE:<n>` and the process exits 0.
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
| Core package directory | `:package_dir` | `SPIRAL_COMPILER_PACKAGE_DIR` | `<polyglot root>/deps/The-Spiral-Language/VS Code Plugin` |
| Polyglot root | `:polyglot_root` | `SPIRAL_KINO_POLYGLOT_ROOT`, or `config :spiral_kino, polyglot_root: ...` | the `polyglot` checkout next to this `spiral` checkout |

Editor highlighting is `config :spiral_kino, editor_language: "javascript"` (the default).
Livebook's editor has no Spiral mode. JavaScript highlights `//` comments, strings, numbers,
and `let`. Primes in identifiers (`am'.vec`) are read as string starts. `nil` turns highlighting off.

Each cell is a fresh process. Definitions are not shared between cells. A `.dib` notebook
is converted with `Spiral.Kino.Document`: `parse_dib/1`, `to_livemd/1`, and `to_spi/1`.
`to_spi/1` keeps definitions, `open` lines, and the first `--package` directive, and it
drops `--test` cells. `parse_livemd/1` reads the smart cells `to_livemd/1` writes.

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
