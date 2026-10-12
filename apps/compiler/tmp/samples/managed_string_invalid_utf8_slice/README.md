# Invalid UTF-8 slice boundary

This native-negative fixture slices the second byte of the two-byte UTF-8 encoding of `é`. Compilation must succeed for C, Rust and Delphi, but every generated executable must terminate with a non-zero status because the byte interval does not preserve codepoint boundaries.
