# Native managed closure branch

This fixture selects at runtime between two closure values that share the same managed capture layout.

Both alternatives capture a string plus an integer bias. The selected closure receives `39i32`; either branch returns `42`, proving that branch selection preserves callable identity and managed environment ownership.

The portable source bridge recognizes the generic operations `ManagedClosureString` and `InvokeManagedClosure`; it does not dispatch on this fixture name. Rust lowers the managed field to `Rc<str>`, Delphi to `UnicodeString`, C to a borrowed string literal, and F# to a tuple environment.

Expected process exit code: `42`.
