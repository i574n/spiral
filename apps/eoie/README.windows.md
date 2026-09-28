# EOIE on Windows

Run the native executable from PowerShell:

```powershell
.\eoie.exe help
```

`eoie.exe` is the Windows build; Linux builds produce `eoie`. Both are ignored
build products. An original Linux binary may still exist in older local bundles.
`eoie.ps1` builds the native executable if it is missing, then forwards arguments
and the exit code.

## Build and test

Use Rust 1.88 or newer with the Windows MSVC toolchain and the Visual Studio C++
build tools. Cargo downloads the exact dependencies in `src/Cargo.lock` from
crates.io on the first build. `src/vendor` remains ignored and is not required.
Use `-Offline` only after fetching the locked dependencies into your Cargo cache.

```powershell
pwsh -NoProfile -File .\build.ps1 -Test
```

This builds the CLI, runs the native workspace tests, builds an optimized release,
and copies it to `eoie.exe`. It works from any current directory. Build output is
under `src/target`, replacing the old `/mnt/data/eoie-rust-target` setting.

Every workspace suite runs. Individual tests requiring optional compiler package
attestation and Plan IR interfaces are explicitly ignored by default. The patched
alpha418 single-flight host implements these interfaces. To include those tests,
set `EOIE_DOTNET` to its .NET host and supply its built `SpiralCompiler.dll`:

```powershell
pwsh -NoProfile -File .\build.ps1 -Test -CompilerContracts -SpiralCompiler C:\tools\SpiralCompiler.dll
```

`EOIE_SPIRAL_COMPILE` also selects a compiler. Discovery searches Windows `.exe`
and `.cmd` names on PATH and `%APPDATA%/eoie/spiral-compiler.path`, following
explicit `EOIE_CONFIG_HOME` and `XDG_CONFIG_HOME` overrides. The supplied Linux
compiler/toolchain payloads cannot run as Windows executables.

For native Spiral code generation and compiler configuration, see [README.md](README.md).

## Runtime behavior

- Reads, staged writes, replacement, copies, directory creation, and removal use
  a native Windows backend. It rejects junction/reparse ancestors, path traversal,
  alternate data streams, device names, and trailing-dot/space aliases. Directory
  handles deny delete sharing while operations use their paths.
- Bounded processes start suspended, enter a Windows Job Object, and then resume.
  Timeout and error cleanup terminate descendants as well as the immediate child.
  Processes run without opening console windows.
- ZIP creation, verification, and extraction run natively. Windows archives mark
  `eoie` and executable/script extensions executable in ZIP Unix metadata.
- POSIX file modes map to Windows's read-only attribute. Execute bits and Unix
  owner/group distinctions do not change Windows ACLs. Symlink commands require
  Windows Developer Mode or an account with the symlink privilege; failures are
  reported rather than replaced with a different kind of link.
- Use native programs in command plans, such as `cmd.exe` or `pwsh.exe`. Linux
  paths such as `/bin/sh` and Linux portable-toolchain receipts remain Linux inputs.

The saved workspace lease can expire independently of operating system support.
To begin a new work session in this bundle:

```powershell
.\eoie.exe agile begin . "Windows work session"
```

The port does not fabricate new attestations for the original Linux release.
Source changes can make its recorded hashes/evidence stale; resealing a release
requires the matching compiler and release verification workflow.

## Source and validation

Platform-specific Rust lives in `rust_std_fs_mutation/windows.rs`,
`rust_std_fs/windows.rs`, `rust_std_fs/portable.rs`, and
`eoie_process_streaming/windows.rs`. The matching embedded Rust in the `.spi`
sources is updated too. Retain these adapter files when regenerating Rust owners.

Windows regression tests cover Unicode/space paths, junction rejection, ancestor
locking, traversal/device-name rejection, staged replacement and rollback,
process output/exit status, descendant termination, stdout-consumer deadlines,
command receipts, and ZIP roundtrips/executable metadata. Linux-specific backends
remain behind their original platform conditions; Linux execution was not tested
in this Windows environment.
