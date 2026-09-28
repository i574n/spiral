# Mutable borrowed byte-buffer ABI

This fixture passes a managed `array u8` through the portable ABI registry to libc `memset`. The binding is typed as a mutable borrowed byte buffer plus byte value and explicit length. C, Rust and Delphi write the first three bytes, return the written length and then verify that the mutation is visible through the original Spiral array.

The Rust adapter clones only the `Rc` handle before borrowing the `Vec<u8>` mutably, so ownership remains with the Spiral value. The Delphi adapter takes the dynamic array by `var`. The sibling negative fixtures prove runtime length bounds and reject an owned-buffer contract when only a borrowed mutable buffer is available.