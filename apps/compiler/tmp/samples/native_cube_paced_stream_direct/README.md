# Native Cube bounded pacing

This source-real Spiral authority reuses one 160x44 frame, emits three complete terminal frames and executes two deterministic pacing intervals between them.

The pacing policy is work-unit based rather than wall-clock based: each interval performs exactly 4096 bounded integer state transitions. The two receipts are 965 and 966, producing aggregate receipt 1931. C, Rust and Delphi emit the same 21258 stdout bytes and return 42.

This does not claim milliseconds, sleep, monotonic clocks, TTY detection, input or infinite animation.
