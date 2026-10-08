# Patched crates

A cargo tool we need changed, without carrying a fork: a pinned upstream release from crates.io plus a patch,
built locally. The Rust counterpart of `patch-package` in Node.

```
patched-crates/
  install.ps1                 generic installer: pwsh install.ps1 <crate>
  <crate>/crate.psd1          pinned Version + Sha256 of the crates.io archive
  <crate>/<version>.patch     unified diff against that exact release
```

`install.ps1 <crate>` downloads `https://crates.io/api/v1/crates/<crate>/<version>/download`, refuses it unless the
sha256 matches the pin, applies the patch (fails loudly when it no longer applies), runs
`cargo install --path . --locked --force`, and writes a stamp to `$CARGO_HOME/bin/.patched-crates/<crate>` holding
crate, version, archive hash and patch hash. A matching stamp skips the whole thing, so callers run it unconditionally.

## Current crates

- `cargo-outdated` 0.19.0: virtual workspaces whose members live outside the workspace directory
  (`workspace/Cargo.toml` with `members = ["../apps/x"]`, the layout polyglot and spiral use to keep the repo root free
  of Cargo). Upstream fails with "failed to load manifest for workspace member": it mirrors manifests into a temp
  project by slicing paths at the workspace root and only collects packages under it. The patch adds
  `ElaborateWorkspace::tree_root` (the deepest directory holding the workspace root and every member) and mirrors
  relative to it, so `workspace/` and `apps/x` keep their relative paths. With members inside the root, `tree_root` is the
  workspace root and behavior is upstream's. Replaces the old i574n fork, whose cargo 0.82 can no longer parse
  `edition2024` members and whose stub-crate approach reported mostly `Removed` rows.

## Moving to a new upstream version

```powershell
$v = '0.20.0'
Invoke-WebRequest "https://crates.io/api/v1/crates/cargo-outdated/$v/download" -OutFile co.crate
(Get-FileHash co.crate).Hash
tar -xzf co.crate; cd "cargo-outdated-$v"; git init -q; git add -A; git commit -qm upstream
git -c core.autocrlf=false apply --3way ../cargo-outdated/0.19.0.patch
cargo build --release
git -c core.autocrlf=false diff > "../cargo-outdated/$v.patch"
```

Then update `crate.psd1` and delete the old patch. A patch that builds can still report wrong rows, so check the output
against stock upstream: copy spiral's manifests (and the source files they name) into a layout with `Cargo.toml` at the
root, run stock `cargo outdated -w` there and the patched one on `workspace/Cargo.toml`; the reports must be identical.

## GitHub Actions

Building takes minutes (cargo-outdated links the cargo library). Cache the installed binary and stamp, keyed on the pin
and the patch, so any change to either rebuilds:

```yaml
- uses: actions/cache@v4
  with:
    path: |
      ~/.cargo/bin/cargo-outdated
      ~/.cargo/bin/cargo-outdated.exe
      ~/.cargo/bin/.patched-crates/cargo-outdated
    key: patched-cargo-outdated-${{ runner.os }}-${{ hashFiles('scripts/patched-crates/cargo-outdated/**') }}
- run: pwsh scripts/patched-crates/install.ps1 cargo-outdated
```

On a cache hit the stamp matches and `install.ps1` returns immediately.
