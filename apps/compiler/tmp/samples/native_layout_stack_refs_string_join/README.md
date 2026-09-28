# Managed string stack references

This typed Spiral fixture proves that a managed string stored behind `stack_refs` can be replaced inside a conditional, observed through a later alias and finalized with its local storage. Rust uses `RefCell<String>` and Delphi uses pointers to local `UnicodeString` storage. Expected native exit code: 15.
