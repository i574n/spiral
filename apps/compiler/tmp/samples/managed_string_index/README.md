# Managed string byte indexing

Exercises a dynamic byte lookup through Spiral's C string representation. Rust lowers the zero-based access through a checked `SpiralStringIndex` helper over `Rc<str>` bytes. Delphi uses an equivalent range-checked helper and compensates for one-based `AnsiString` indexing. The fixture compares the selected byte and returns zero on all three native targets.
