# Portable ABI managed UTF-8 string

A runtime Spiral string crosses a registered borrowed UTF-8 ABI binding to libc `strlen`. C, Rust and Delphi must all exit with code 6. Rust materializes a temporary NUL-terminated buffer; Delphi borrows the managed `AnsiString` storage for the duration of the call.
