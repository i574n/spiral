# Single-flight lane

The stable compiler: the sequential evaluator with its F#, C, Rust and Delphi backends.

- Core: `apps/compiler/spiral_compiler.fs`, the repo's main compiler source. Each backend generates its
  target directly from the typed IR (`codegenFsharp`, `CodegenC`, `codegenRust`, `codegenDelphi`); none is
  translated from another backend's output. C is the semantic oracle for native behaviour.
- Rust (`codegenRust`, modelled on the F# backend): values that are not primitives are shared behind `Rc`
  and cloned at each use; arrays and mutable layouts are `Rc<RefCell<_>>`, closures `Rc<dyn Fn>`, heap
  unions `Rc<enum>`, stack unions `enum`; strings are `Rc<str>` with byte semantics like C.
- Delphi (`codegenDelphi`, statement-oriented like the C backend; FPC 3.2): locals in `var` sections,
  values assigned to their targets; arrays are dynamic arrays and strings AnsiStrings (both
  reference-counted, byte semantics); heap unions, mutable layouts and closures are classes (FPC 3.2 has
  no ARC for classes, so these are not freed), immutable layouts, stack unions and tuples records.
- Tail calls: both backends turn a method's self tail call into a loop, as the C compiler does. Mutual
  tail recursion still recurses; the programs get a large stack (1 GB thread in Rust, 256 MB in FPC).
- Proof: `pwsh scripts/test.ps1 -Suite examples -Native` builds and runs every C/Rust/Delphi output;
  Rust and Delphi must agree with C (`oracle` column). 2026-09-28: Rust 104 ran, 103 agree (the other is
  a known bounds-check difference); Delphi 102 ran, 102 agree; 0 DISAGREE.
- Known wall: compiling the full `apps/spiral` app overflows the stack.

## Backend-specific code in samples

A sample that needs target code per backend uses `!!!!BackendSwitch({C = ...; Rust = ...; Delphi = ...;
Fsharp = ...})` (e.g. `set'` in `while_control`, NaN in `native_float_nan_is`). Samples that exercise the C
runtime itself (`dynamic_array_*` through C shims, `abi_external_*` through the C ABI) are C-only in
`tests/harness.psd1` (`Backends`).

## Known gap: rejected programs report no diagnostic

159 of the 162 negative contract cases (`samples/contract_*`, e.g. `contract_illegal_transition`) are
rejected with `BuildFile returned no code and no diagnostic arrived`: the program is refused, but the
type error never reaches the `--batch` result. The oracle therefore only checks *that* these programs are
rejected, not *why*. Surfacing the diagnostic in the host would turn them into real negative tests.

## The C-to-Rust/Delphi translator is gone

The host used to lower the core's C text to Rust/Delphi (`PortableBackends.fs`, 8,759 lines, plus an
older copy inside `Program.fs`), rewrite C/F# output, and compile some sources itself ("typed-source").
All of it was deleted on 2026-09-28 once eoie built with `!!!!Export` and the native Rust backend
(`RUST_LIBRARY_PLAN.md`); so were the `--lower-portable*` commands. The sixteen samples written in ops only
the translator understood (`native_layout_*`, `native_closure_managed_branch`) were removed before.
