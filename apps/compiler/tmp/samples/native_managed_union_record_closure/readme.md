# Managed union record closure

Source-real authority for `Empty | Item (string * i32)`. A capture-free closure returns either case. The portable lowering flattens the active managed record into one `String` field plus one scalar field, clones only the managed field for a concrete tag-selected destination, copies the scalar directly, and drops both owners symmetrically in Rust and Delphi. The missing-target fixture remains a negative authority.
