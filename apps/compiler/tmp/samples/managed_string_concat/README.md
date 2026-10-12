# Managed string concatenation

Combines runtime-selected string fragments through nested concatenation. The result must be independently owned, reusable and byte-indexable in C, Rust and Delphi. Rust lowers to `Rc<str>` construction through a capacity-aware helper; Delphi lowers to managed `AnsiString` concatenation.
