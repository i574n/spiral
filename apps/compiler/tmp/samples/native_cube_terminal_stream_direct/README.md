# Native Cube terminal stream direct

This source-real authority emits three complete deterministic Cube frames through the typed Spiral `Printf` operation. Each frame is preceded by the three-byte ANSI cursor-home sequence `ESC[H`; no sleep, input, terminal detection, clear-screen command, or infinite loop is involved.

The snapshots retain the exact C, Rust and Delphi residuals plus a single binary stdout oracle. The gate requires all three native programs to return 42 and emit the same 21,258 bytes: three repetitions of a 3-byte cursor prefix followed by a 7,083-byte frame.

The compiler change is backend-neutral. C `printf("%s", value->ptr)` is normalized to `PortablePrint`; Rust renders it as `print!("{}", value)` and Delphi as `Write(value)`, without an implicit newline.
