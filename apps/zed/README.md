# Spiral Language Extension for Zed

This extension provides first-class support for **The Spiral Language** (`.spi`, `.spir`, `.spiproj`, `.dib`) in the [Zed](https://zed.dev) editor.

It is modeled after the official Spiral VS Code extension (`VS Code Plugin`), adapting its configuration, semantic captures, and language server protocol client for Zed's native extension architecture.

---

## Features

- **File Types**: Automatically associates `.spi`, `.spir`, `.spiproj`, and `.dib` files with the Spiral language.
- **Syntax Highlighting & Colors**:
  - Keywords: `inl`, `inm`, `inb`, `forall`, `union`, `nominal`, `real`, `type`, `open`, `match`, `typecase`, `function`, `with`, `without`, `as`, `when`, `let`, `rec`, `if`, `then`, `elif`, `else`, `join`, `join_backend`, `prototype`, `instance`, `in`, `and`, `fun`, `exists`.
  - Primitive Types: `i8`, `i16`, `i32`, `i64`, `u8`, `u16`, `u32`, `u64`, `f32`, `f64`, `bool`, `string`, `char`, `unit`.
  - Type Constructors: PascalCase type and union identifiers (`GadtExpr`, `CanonicalReleaseMeasurement`, etc.).
  - Operators: `=`, `::`, `->`, `=>`, `+`, `-`, `*`, `/`, `==`, `!=`, `<`, `>`, `&&`, `||`, `|`, `&`, `^`, `!`, `~`, `$`.
  - Comments: line comments (`// ` with the required space) and block comments (`(* ... *)`, also with a space after `(*`).
  - Literals: Typed integers, floats, booleans (`true`/`false`), and quoted strings.
- **Bracket Matching & Auto-closing**: Smart auto-closing and pairing for `()`, `[]`, `{}`, `""`, and `''`.
- **Indentation Rules**: Out-of-the-box block and match expression indentation.
- **Symbols & Code Outline**: The Rust grammar's function, struct, and enum items. An `inl` binding is highlighted, and it is not yet an outline entry because the extension reuses Zed's Rust tree-sitter grammar.
- **Compiler**: Zed starts the single-flight `SpiralCompiler.dll` built from `spiral/apps/compiler`. The default backend is Rust (`--backend Rust`). There is no separate `spiral-lsp` binary.
- **Type-Level Architecture with `PhantomData`**:
  - **GADTs**: Type-safe abstract syntax trees and protocol state machines parametrized by phantom tags (`IntTag`, `BoolTag`, `StringTag`, etc.) where constructors enforce type correctness at compile time.
  - **Existentials**: Heterogeneous token streams and dynamic capability wrappers that safely encapsulate phantom witnesses.
  - **HKTs**: Higher-Kinded Types simulated using the lightweight brand / type family pattern (`Functor`, `Applicative`, `Monad`).

---

## Type-Level Design (`PhantomData`)

The Rust extension implementation (`src/types.rs`) showcases how advanced type-level concepts from functional programming can be simulated in Rust via `PhantomData`:

### 1. GADTs (Generalized Algebraic Data Types)
```rust
pub struct GadtExpr<T: TypeTag> {
    raw: ExprRaw,
    _phantom: PhantomData<fn() -> T>,
}

// Statically constrained constructors:
let one: GadtExpr<IntTag> = GadtExpr::lit_int(1);
let two: GadtExpr<IntTag> = GadtExpr::lit_int(2);
let three: GadtExpr<IntTag> = GadtExpr::add(one, two);

// Type-safe equality and evaluation:
let is_three: GadtExpr<BoolTag> = GadtExpr::equals(three, GadtExpr::lit_int(3));
assert!(is_three.eval());
```

### 2. Existentials
```rust
// Heterogeneous token stream packing arbitrary phantom-tagged tokens:
let kw: GadtToken<KeywordTag> = GadtToken::new("inl", 1, 1);
let op: GadtToken<OperatorTag> = GadtToken::new("->", 1, 5);

let stream: Vec<ExistentialToken> = vec![
    ExistentialToken::pack(kw),
    ExistentialToken::pack(op),
];
```

### 3. HKTs (Higher-Kinded Types)
```rust
// Type families and functors over type constructors:
pub trait Functor: Hkt {
    fn fmap<A, B, F>(fa: Self::Applied<A>, f: F) -> Self::Applied<B>
    where
        F: FnMut(A) -> B;
}

let doubled = VecFamily::fmap(vec![1, 2, 3], |x| x * 2);
assert_eq!(doubled, vec![2, 4, 6]);
```

---

## How to Install in Zed

### Method 1: Install as a Dev Extension (Recommended)

1. Open **Zed**.
2. Open the Command Palette:
   - **Windows / Linux**: `Ctrl+Shift+P`
   - **macOS**: `Cmd+Shift+P`
3. Type and select:
   ```text
   zed: install dev extension
   ```
4. In the folder picker dialog, select the extension directory:
   ```text
   C:\home\git\spiral\apps\zed
   ```
   *(or `/home/git/spiral/apps/zed` on Linux)*
5. Zed will compile/load the extension. The extension will appear under `Installed Extensions` as **Spiral (dev)**.

---

## How to Test

### 1. Run the Extension Test Suite
In a terminal, test the extension's Rust unit tests:
```powershell
cd C:\home\git\spiral\apps\zed
cargo test
```
All tests for GADTs, Existentials, HKTs, and protocol state machines will execute and pass.

### 2. Test Syntax Highlighting in Zed
1. Open any Spiral file in Zed, for example:
   ```text
   C:\home\git\spiral\apps\eoie\state\coverage.spi
   ```
   or
   ```text
   C:\home\git\spiral\apps\eoie\src\eoie_fs_actions\main.spi
   ```
2. Verify that:
   - Keywords (`inl`, `union`, `open`, `match`, etc.) are colored according to your theme.
   - Types (`u32`, `i32`, `string`, `CoverageFloor`, etc.) are highlighted.
   - Comments (`// `, `(* *)`) and strings (`"..."`) are correctly styled. `//` is highlighted by the Rust grammar. `(* *)` is the comment command's syntax; the Rust grammar does not yet color it as a comment.
   - Matching brackets highlight when moving the cursor across `()`, `[]`, `{}`.
   - Auto-indentation works when pressing `Enter` inside blocks.

### 3. Compiler and logs
Zed starts `spiral-zed`, which speaks the language server protocol and runs the single-flight compiler. The compiler dll is:

`%LOCALAPPDATA%\spiral-bin\bin\single-flight\SpiralCompiler\Release\net11.0\SpiralCompiler.dll`

The log is the `spiral-lsp` language server trace. The first lines are `spiral-zed: ready` with the dotnet path, the dll path, and the backend. Hover a name for the token and the latest compiler note. The code action **Spiral: Build file** runs `SpiralCompiler --backend Rust` and writes the `.rs` next to the module. Build and check output is appended to that same trace.

```json
{
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
