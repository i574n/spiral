# Managed string recursive payload

Exercises a recursive union whose non-empty case carries a managed Spiral string and two recursive children. The graph shares both subtrees and root aliases across consumers. Rust must keep `Rc<str>` distinct from recursive `Rc` nodes, clone repeated constructor arguments, and avoid rewriting string refcount traffic as recursive clone helpers. Delphi relies on `AnsiString` management while preserving recursive class refcounts. C, Rust and Delphi all return zero.
