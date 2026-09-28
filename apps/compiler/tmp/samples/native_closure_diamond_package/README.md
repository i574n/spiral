# Native closure diamond package

This fixture proves deterministic package-graph lowering when two sibling packages depend on one shared package.

The normal root declares `left` then `right`; `reversed-package.spiproj` declares them in the opposite order. Both must produce byte-identical Rust and Delphi package trees.

`foundation/transport` is emitted exactly once. Both `left/use` and `right/use` depend on it. The program captures a managed string in one closure and returns 42 through both branches.

`duplicate-package.spiproj` proves that duplicate package references are rejected before output is created.
