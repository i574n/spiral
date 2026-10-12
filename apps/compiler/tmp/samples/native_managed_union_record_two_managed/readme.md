# Native managed union record with two managed fields

This source-real authority covers `Empty | Item (string * array i32)` returned by a capture-free closure. Rust and Delphi project packages reconstruct a concrete second owner by tag, clone the `String` and `Array` fields independently, and destroy both fields for both owners. The Rust regression specifically forbids dropping the whole tuple after a field move; managed fields are dropped individually so mixed records remain valid under `-D warnings`.

The fixture without an immediate destination remains an exact negative. Nested records, nested unions and interprocedural owners remain outside authority.
