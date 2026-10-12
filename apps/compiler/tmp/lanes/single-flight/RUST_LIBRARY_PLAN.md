# Plan: Rust libraries and exports without the translator (eoie)

Status (2026-09-28): steps 1, 2, 4 and 5 done in single-flight (eoie: 88/88 owners, cargo check and all
tests incl. compiler contracts pass; the translator is deleted). Open: step 3 (no eoie use), the hopac
build, the post-deletion `-Suite all -Native` review (see `NEXT.md`), and moving `--plan-ir` into eoie. Goal: eoie builds with the native `codegenRust` backend, and
`compiler/host/PortableBackends.fs` (8,759 lines) is deleted.

## What eoie relies on today

About 80 eoie domain packages (`eoie/.../*.spi` in the [eoie](https://github.com/i574n/eoie) repository, 84 files) compile to a Rust library through markers
that only the translator understands:

| marker | uses | meaning |
|---|---:|---|
| `$"RustLibrary()"` | 79 | emit a library crate (no `main`) |
| `$"RustExportI32Binary(\"export_x\",\"x\")"` | 246 | `pub fn export_x(a: i32, b: i32) -> i32` calling the Spiral function `x` |
| `RustExportU64Unary`, `RustExportStringUnary`, `RustExportI32` | 83 | same shape, other signatures |
| `RustExportStringTuple5Unary`, `RustExportU64String5` | 7 | tuple/string ABIs |
| `portable.target_global` | 1 | raw item text for a target |

The contract test is `scripts/test-rust-exports.ps1` (fixtures in `tests/rust-exports`; a real Rust consumer
links the generated rlib). eoie's `compiler-contracts/test-attestation.ps1` checks the same outputs.

## Design

1. **One generic export op in the core**, not per-signature markers: `!!!!Export("export_x", f)` with `f` a
   Spiral function. Peval turns `f` into a join point method (as a `join` call would) and records
   `(name, method)` in the build's export list. Every backend decides what an export means; the op carries
   no backend name.
2. **Library output**: a program whose `main` result is `()` and that declares exports is a library.
   `codegenRust` then emits the exports as `pub fn export_x(<params>) -> <range> { method<N>(...) }` and no
   `fn main`. Parameter and result types come from the method's typed signature, so the per-signature
   markers disappear; strings cross as `Rc<str>`, tuples as Rust tuples (the consumer side adapts).
3. **Target items**: `portable.target_global` becomes `!!!!BackendSwitch({Rust = fun () => !!!!Global("..."); ...})`
   (the core already has `Global`); drop the `SPIRAL_TARGET_GLOBAL_*` string convention.
4. **eoie migration**: a small Spiral module (e.g. `eoie/export.spi`) with `inl export name f = !!!!Export(name, f)`;
   a scripted rewrite of the 84 files replaces `$"RustExport...(\"a\",\"b\")"` by `export "a" b` and removes
   `rust_library ()`. Update `tests/rust-exports` and its consumer to the new signatures.
5. **Delete**: `PortableBackends.fs`, the host's `lowerPortableBackend`/`tryLowerPortableSource` calls, the
   `--lower-portable*` commands, `restoreC`/`awaitCoreWrite`'s C branch, and `PORTABLE_BACKENDS.md`.

## Progress

- `!!!!Export(name, f)` (peval: `f` must be an annotated function without runtime captures) and Rust library
  mode are in `apps/compiler/spiral_compiler.fs`; `scripts/test-rust-exports.ps1` passes.
- eoie sources were rewritten by `eoie/compiler-contracts/migrate-native-rust.py` (exports, `RustLibrary`,
  `RustGlobal` helpers, Fable `emitRustExpr` calls -> `$'...' : type`) and `merge-rust-globals.py`.
- `pwsh ../eoie/compiler-contracts/test-regeneration.ps1 -CargoCheck` compiles every owner in a staged copy;
  it only replaces the committed `.rs` in that copy. Copy the outputs into the tree once `-Test` also passes.

Translator behaviours eoie silently relied on, and what replaced them:

| translator behaviour | native replacement |
|---|---|
| globals emitted in order, never deduplicated | globals are deduplicated by text (as in C); line-per-call Rust was merged into one global per block (`merge-rust-globals.py`) |
| `// SPIRAL_PRUNE_BEGIN:id ... END:id` blocks deleted from globals | the four dead "shadow" blocks were deleted from `legacy_operations_entry/legacy_terminal.spi` |
| `#![...]` globals hoisted to the top | `codegenRust` emits inner-attribute globals before its `use` lines (both cores) |
| export names resolved regardless of scope | `command_spec_domain/main.spi` opens `model` |
| stale committed outputs hid a missing Cargo dependency | `eoie_patch_scan` depends on `canonical-plan-ir-domain` |

Pitfalls met during the migration: in a macro, `!name'` reads the closing quote as part of the name (write
`!name '`); `"""` strings are unusable for code blocks (the tokenizer tracks them in a process-wide flag and
the parser splits top-level statements at column-0 lines); a failing dependency package makes the batch
report "no code and no diagnostic" (the core's fatal now lists the package's own type errors, not its
dependencies').

Still eoie-specific in the host after the translator is gone: `--plan-ir` (`lowerPlanIrManifest` in
`Program.fs`) parses `RustPlanOp(...)` markers out of the generated `spiral_main` into an `EOIE-PLAN-IR`
manifest. Move that parser into eoie (it can run `--backend Rust` and parse the output itself), then delete
the host mode. `--check` is generic and stays.

## Order

Core op + Rust library mode in single-flight (test with `tests/rust-exports`), then port to hopac (same
pattern as the backends, see `lanes/hopac/FRONTIER.md` fix 17), then the eoie rewrite and its attestation,
then the deletions. Delphi libraries are not needed by eoie; the same op can later emit a Pascal `unit`.
