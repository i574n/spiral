# EOIE source workspace

This directory is the source workspace extracted from the EOIE bundle. Generated
Rust is checked in so a normal build does not require a Spiral compiler. Rust
adapters beside the generated owners implement operating-system facilities.

## Build

Install Rust 1.88 or newer and PowerShell 7. Windows also needs the MSVC C++ build
tools; Linux needs a native C linker. From any directory:

```powershell
pwsh -NoProfile -File apps/eoie/build.ps1 -Test
pwsh -NoProfile -File apps/eoie/eoie.ps1 help
```

Cargo downloads registry dependencies using the committed `src/Cargo.lock`.
`src/vendor/` stays ignored and is not part of the build. After one successful
fetch/build, `build.ps1 -Test -Offline` uses the Cargo cache. When invoking Cargo
directly, change to `apps/eoie/src` first so it discovers `.cargo/config.toml`.

`-Test` runs every workspace suite, including native regression tests. Tests that
require the optional `--check`/`--plan-ir` compiler are explicitly marked ignored.
Run them with `-Test -CompilerContracts -SpiralCompiler <compiler-path>` using
the patched single-flight host described below. Ordinary runtime builds remain
compiler-independent.

Build products (`eoie`, `eoie.exe`, `src/target`, compiler C residuals and sidecars)
are ignored. Keep `.spi`, `.spiproj`, generated `.rs`, adapters, tests, Cargo
manifests and the lockfile. Files under `state/` include historical Linux release
evidence; they do not certify the current Windows build.

## Native Spiral compiler

The current supported lane is **single-flight**. Hopac remains experimental.
Build alpha418 once using its own portable scripts:

```powershell
$compiler = 'apps/compiler/tmp'
pwsh "$compiler/scripts/install-dotnet.ps1" # only if .NET 11 is absent
pwsh "$compiler/scripts/build.ps1" -Mode single-flight
pwsh apps/eoie/spiral.ps1 -CompilerBundle $compiler `
  -InputPath apps/eoie/src/eoie_fs_actions/main.spi `
  -OutputPath apps/eoie/src/eoie_fs_actions/fs_actions.rs
```

`spiral.ps1` supports `-Backend Rust|C|Fsharp|Delphi`, `-TimeoutSec`, and
`-SourceRoot`. It copies Spiral sources into a unique compiler cache directory
before compilation, preventing the core from leaving C residuals in the checkout.
It publishes the requested output only after a successful bounded compile.

Set `EOIE_SPIRAL_BUNDLE` or pass `-CompilerBundle` after moving the compiler.
Without either, the script uses the current sibling alpha418 directory.
The compiler's `SPIRAL_BIN_CACHE_DIR` and `SPIRAL_DOTNET` select its cache and SDK.
The same scripts run on Windows and Linux; CI is configured to test runtime builds
on both. This review was executed on Windows.

EOIE's process library also accepts a native `SpiralCompiler.dll` through
`EOIE_SPIRAL_COMPILE`. Set `EOIE_DOTNET` (or `SPIRAL_DOTNET`) to the matching .NET
host, and `EOIE_SPIRAL_BUNDLE` for core-package resolution. Native code generation
omits the legacy timeout flag and is supervised by EOIE's process timeout.
The patched native host implements package-wide `--check` without requiring
`main`, and bounded `--plan-ir` for unconditional compiled `RustPlanOp` markers.
Runtime-dependent plans are rejected. All seventeen optional EOIE integration
contracts can run against this host; Hopac package attestation remains unsupported.
Run `compiler-contracts/test-attestation.ps1` for package rejection,
plan payload, timeout, and native GADT regression coverage.

The compiler host validates six Rust export ABIs: `RustExportI32`,
`RustExportI32Binary`, `RustExportStringUnary`, `RustExportU64Unary`,
`RustExportStringTuple5Unary`, and `RustExportU64String5`. Unary string and u64
exports accept a borrowed string; tuple exports return five owned `Rc<str>` values.
Exports require exactly one `RustLibrary` marker and a retained join point with
the exact argument and result types. Unknown markers, duplicate names, missing
targets and signatures changed by optimization are rejected.

Run the compiler's `apps/compiler/tmp/scripts/test-rust-exports.ps1` for an external Rust
consumer and negative ABI contracts. `compiler-contracts/test-regeneration.ps1`
regenerates the primary target of all 88 Cargo workspace members in an isolated
cache copy. Use `-CargoCheck -Test -CompilerContracts` to check all targets, run
the workspace contracts and build a release executable from those regenerated
owners. Use `-EoieRoot` after relocating EOIE, `-Filter` for selected members,
and `-Offline` with a populated registry cache. Auxiliary probes and operating
system adapters remain consumers in this check. It never replaces checkout Rust.

## Generic versus strict bundles

| Profile | What passing means |
| --- | --- |
| `generic` | A nonempty tree can be represented by the archive policy: normalized unique paths, no symlinks/special entries, canonical manifest and bounded extraction. It does not attest EOIE source, executable identity or release evidence. |
| `eoie` (strict) | The historical EOIE release layout, source/package census, growth limits, current evidence, ratings, receipts and executable/archive contracts also pass. |
| `auto` | Selects `eoie` only when the complete historical signature exists (`eoie`, `state/package.spiproj`, `state/core.spi`, `src/Cargo.toml`); otherwise selects `generic`. It is not a release certification switch. |

Use explicit `eoie` for release gates. A source checkout has docs, scripts and
tests and lacks a certified release payload, so it is not expected to pass that
packaging gate. Generic success must never be substituted for strict release
approval. Do not run `bundle create` over a live checkout: it prunes release
transients and includes files that Git ignores. Stage a distribution separately.

The first source commit is checked through locked builds, tests and Git hygiene.
Producing a newly certified EOIE release still requires compatible compiler
attestation, fresh release evidence and cold rebuilds. These remain tracked in
the `PORT-*` agile tasks, alongside the fixes completed in this review.

## Work planning

```powershell
pwsh apps/eoie/eoie.ps1 agile begin apps/eoie 'Continue portable source review'
pwsh apps/eoie/eoie.ps1 agile list apps/eoie
```

See [README.windows.md](README.windows.md) for Windows filesystem and process details.
See [FIRST-COMMIT-REVIEW.md](FIRST-COMMIT-REVIEW.md) for validation and remaining release scope.
