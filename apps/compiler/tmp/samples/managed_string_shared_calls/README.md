# Managed string shared calls

Passes one Spiral string through two non-inline consumers. The Rust residue uses `Rc<str>` and clones the managed argument at each consuming call, preserving the original value. Delphi relies on managed `AnsiString` sharing. C, Rust and Delphi all return zero.
