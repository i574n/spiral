# Native scalar tail recursion

This fixture forces one million recursive steps. The portable Rust and Delphi emitters must lower the direct scalar self-tail-call to a native loop with simultaneous parameter updates. The generated source must not rely on LLVM, clang or FPC tail-call optimization.
