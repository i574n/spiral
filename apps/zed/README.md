# Spiral for Zed

Development-stage Spiral language support for [Zed](https://zed.dev).

> [!IMPORTANT]
> This is not yet a verified end-to-end editor integration. The native helper
> passes its unit and compiler-probe tests, but the latest observed Zed startup
> still used a stale `extension.wasm` and failed to locate `spiral-zed.exe`.
> Rebuild the dev extension in Zed and complete the manual checklist below
> before treating diagnostics, hover, semantic tokens, or build actions as
> working.

See [`DEVELOPMENT.md`](DEVELOPMENT.md) for the architecture, Zed API contracts,
known gaps, failed approaches, and continuation checklist.

## Current status

| Area | Status |
| --- | --- |
| `.spi` and `.spir` association | Implemented |
| `.spiproj` association | Implemented, parsed with the same line grammar |
| Tree-sitter grammar | `tree-sitter-spiral` line grammar (exact test headers, directives, comments); expressions are not parsed |
| Highlighting/outline/runnables queries | From the grammar; brackets and indents queries are empty; expression highlighting comes from semantic tokens |
| Native `spiral-zed` helper | Unit-tested and compiler-probed on Windows |
| Zed-to-helper launch | Blocked pending a dev-extension rebuild and manual verification |
| Diagnostics, hover, semantic tokens, build actions | Implemented in the helper, not currently verified in Zed |
| `.spiproj` links/actions | Partial implementation, not verified in Zed |
| Test task picker entries | Repository-local developer tooling only |
| Gutter run-test button | `runnables.scm` tags each `test name =` with `spiral-test`; not yet verified in Zed |
| Linux/macOS support | Not validated; known URI/path correctness work remains |
| Registry publication | Blocked by helper-distribution requirements |

The files in `src/types.rs` demonstrate GADT-, existential-, and HKT-like Rust
encodings with `PhantomData`. They are tested examples, but they are not used by
the extension or language-server runtime.

## Architecture

The integration currently has three separate pieces:

1. `extension.wasm`: the sandboxed Zed extension component.
2. `dist/spiral-zed.exe`: a native stdio LSP bridge built from
   `src/bin/spiral_zed.rs`.
3. `SpiralCompiler.dll`: the single-flight Spiral compiler invoked by the
   native bridge.

Zed builds only the WASM component. It does **not** build the native helper.
The helper is ignored by Git and must currently be built in each developer
checkout.

## Prerequisites

- Zed 1.23.2 or another version compatible with `zed_extension_api = "0.7.0"`.
- Rust installed through `rustup`.
- PowerShell 7 (`pwsh`).
- The Spiral single-flight compiler cache, normally under:

  ```text
  %LOCALAPPDATA%\spiral-bin\bin\single-flight\SpiralCompiler\Release\net11.0\SpiralCompiler.dll
  ```

- Its matching .NET toolchain, normally under:

  ```text
  %LOCALAPPDATA%\spiral-bin\toolchains\dotnet\dotnet.exe
  ```

The discovery code also recognizes these host environment variables:

- `SPIRAL_COMPILER`: absolute path to `SpiralCompiler.dll`.
- `SPIRAL_BIN_CACHE_DIR`: root of the Spiral binary cache.
- `SPIRAL_DOTNET`: absolute path to `dotnet`/`dotnet.exe`.
- `SPIRAL_WORKSPACE_ROOT`: optional compiler workspace root passed to the helper.

## Build the helper and run native checks

From PowerShell:

```powershell
pwsh -NoProfile -File C:\home\git\spiral\apps\zed\test.ps1
```

This command:

1. runs the Rust unit tests;
2. builds the native `spiral-zed` helper in release mode;
3. copies it to `apps/zed/dist/spiral-zed.exe`;
4. verifies that `fixtures/ok/main.spi` succeeds; and
5. verifies that `fixtures/bad/main.spi` fails.

The latest recorded run passed 21 Rust tests and both compiler probes. That
proves the native helper path, not the Zed integration.

## Install or rebuild the dev extension

1. Open Zed's command palette.
2. Run **Zed: Install Dev Extension**.
3. Select:

   ```text
   C:\home\git\spiral\apps\zed
   ```

4. If it is already installed, run **Zed: Rebuild Dev Extension**.
5. Restart the `spiral-lsp` language server or reopen the Spiral project.
6. Open **Zed: Open Log** and confirm that Zed launches
   `dist/spiral-zed.exe` and the server prints `spiral-zed: ready`.

A direct command such as:

```powershell
cargo build --release --target wasm32-wasip1 --lib
```

produces a raw WASI module. It does **not** encode the Zed component and does
not update the `extension.wasm` loaded by a dev extension. Use Zed's rebuild
action for that boundary.

## Configuration

Enable lexical semantic tokens for Spiral in Zed settings:

```json
{
  "languages": {
    "Spiral": {
      "semantic_tokens": "combined"
    }
  },
  "lsp": {
    "spiral-lsp": {
      "settings": {
        "spiral": {
          "backend": "Rust"
        }
      }
    }
  }
}
```

Do not configure `lsp.spiral-lsp.binary.path` to `SpiralCompiler.dll`. In Zed
1.23.2, a configured binary path bypasses this extension's
`language_server_command` and Zed tries to launch that path directly. A DLL is
not a stdio LSP executable.

Also avoid `binary.arguments` for the default helper launch. Zed replaces the
arguments returned by the extension, which would remove required
`--dotnet`, `--compiler`, and `--backend` flags.

## Manual acceptance test

After rebuilding the dev extension:

1. Open `apps/zed/fixtures/ok/main.spi`.
   - The language selector should show **Spiral**.
   - The log should contain `spiral-zed: ready`.
   - Zed should show `Spiral ready`.
   - No diagnostic should be published.
2. Open `apps/zed/fixtures/bad/main.spi`.
   - Exactly one compiler diagnostic should appear.
3. Request hover on an identifier.
4. Confirm semantic-token coloring with
   `languages.Spiral.semantic_tokens = "combined"`.
5. Invoke **Spiral: Show compiler** and **Spiral: Build file** from code actions.
6. Open a representative `package.spiproj` and test its links and create/delete
   actions.
7. Repeat helper discovery with these project roots:
   - `C:\home\git\spiral`
   - `C:\home\git`
   - a sibling project such as `C:\home\git\eoie`

Record the Zed version, extension rebuild time, relevant log lines, and result
in `DEVELOPMENT.md`. Until this checklist passes, editor-facing behavior remains
unverified.

## Tests and the run button

`spiral/.zed/tasks.json` and `apps/zed/tasks/test-at-row.ps1` provide two
monorepo-only task-picker entries:

- `spiral: run test at cursor`
- `spiral: run file tests`

They are not installed with the extension and do not create gutter buttons in
downstream Spiral projects.

`languages/spiral/runnables.scm` tags every `test_header` node with
`spiral-test` and exposes the name as `ZED_CUSTOM_spiral_test_name`; the
monorepo task `spiral: run test $ZED_CUSTOM_spiral_test_name` carries that tag,
so each test block gets a gutter button once the dev extension is rebuilt.

## Known limitations

- The grammar is line-level: every token is a whole line, so test headers,
  `///>` targets and comments are exact, while expressions get their colors
  only from the language server's semantic tokens.
- The native helper is not packaged or downloaded and has no release/version
  compatibility protocol with `extension.wasm` or `SpiralCompiler.dll`.
- Compiler checks and builds block the helper's single LSP loop for up to 90 or
  180 seconds.
- Checks use on-disk files on open/save; unsaved edits are not compiled.
- Semantic tokens are lexical, not compiler-resolved, and currently count Rust
  `char`s rather than LSP UTF-16 code units.
- `.spiproj` parsing handles only a narrow multiline form and has URI/edit edge
  cases documented in `DEVELOPMENT.md`.
- Quote auto-closing is not configured; only `()`, `[]`, and `{}` are paired.
- Linux/macOS paths and file URIs need correction and end-to-end testing.

## Troubleshooting

Open **Zed: Open Log**. On Windows the log is normally:

```text
%LOCALAPPDATA%\Zed\logs\Zed.log
```

Common failures:

- **`spiral-zed.exe was not found`**: run `test.ps1`, then rebuild the dev
  extension in Zed. If it persists, the WASM helper-discovery path still needs
  work.
- **`attempted to parse a wasm module with a component parser`**: a raw Cargo
  WASM artifact was copied to `extension.wasm`; rebuild through Zed.
- **Zed starts `SpiralCompiler.dll` directly**: remove the DLL from
  `lsp.spiral-lsp.binary.path`; configure discovery with host environment
  variables instead.
- **No gutter test button**: rebuild the dev extension so Zed fetches the
  `spiral` grammar at the `rev` in `extension.toml`, and open the file from the
  `spiral` worktree so `.zed/tasks.json` is loaded.
