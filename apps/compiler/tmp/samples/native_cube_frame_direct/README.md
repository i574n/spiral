# Direct Cube frame authority

This source-real sample compiles a deterministic 160 x 44 Cube frame through C, Rust and Delphi without Fable. A 7040-cell dynamic buffer is initialized to dots, three projected cubes derive their indexes from bounded `f64` coordinates and write `#`, `@` and `+` markers.

The buffer is then converted into the complete textual frame: 44 rows of 160 characters separated by 43 newline bytes. The result is 7083 UTF-8 bytes with checksum 324274. Six scalar probes verify the first cell, first newline, all three projected markers and the last cell.

The row builder uses runtime `StringConcat` and a self-tail recursive loop rather than raw mutable assignment of managed strings. This exercises full string ownership through the mature C residual and both portable targets.

The authority exposed two generic backend gaps. Delphi string literals now lower `\\n`, `\\r` and `\\t` into Pascal control fragments such as `#10`. Rust managed array clone analysis is now function-scoped and runs independently of recursive type declarations, so an array passed to the text builder is cloned before its later drop without over-cloning unrelated variables or borrow-only helper calls.

The focused gate is `scripts/portable-cube-frame-direct-gate.sh`. It validates exact snapshots, 7083 text bytes, 44 rows, 160 columns, 43 newlines, checksum 324274, one Delphi control fragment, one Rust frame-array clone, six projected casts per target and native exit code 42.

The remaining Cube frontier is a bounded multi-frame rotation loop. Timing, terminal clearing and interactive animation remain outside this authority.
