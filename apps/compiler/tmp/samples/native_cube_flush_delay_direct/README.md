# Direct Cube flush-delay authority

This source-real Spiral project extends the monotonic-delay Cube authority with a typed `StdoutFlush` immediately after each complete frame write.

The shared compiler lowers the operation to `fflush(stdout)` in C. Portable normalization emits `std::io::Write::flush(&mut std::io::stdout()).expect("stdout flush failed")` for Rust and `Flush(Output)` for Delphi.

The focused gate proves one source-level flush site executed in all three bounded frame iterations, static write-before-flush-before-delay ordering in every target, the unchanged 21,258-byte stdout oracle, two requested 25 ms delays, spatial checksums 45,702 / 43,786 / 43,631, pace receipt 1,931 and native exit 42.

TTY detection, cursor restoration, input, cancellation and infinite animation remain outside this authority.
