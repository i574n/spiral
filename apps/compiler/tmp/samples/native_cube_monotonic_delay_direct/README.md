# Native Cube monotonic delay

This source-real Spiral authority reuses one 160x44 frame, emits three complete terminal frames and requests two bounded monotonic delays between them.

Each delay requests 25 milliseconds through `MonotonicDelayMs`. The portable C residual uses `poll`, Rust uses `std::thread::sleep(Duration::from_millis(...))`, and Delphi uses `Sleep`. A steady-clock harness requires at least 35 milliseconds for the complete process, while the requested total is 50 milliseconds. The lower bound is deliberately tolerant of startup and scheduler variation.

C, Rust and Delphi preserve the same 21258 stdout bytes, the spatial checksums 45702, 43786 and 43631, the deterministic work receipt 1931, and return 42.

This authority is scoped to the current Linux toolchains. It does not claim exact wake-up time, an upper latency bound, explicit stdout flush, TTY detection, input or infinite animation.
