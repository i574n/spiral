# Direct Cube multi-frame authority

This source-real sample compiles a bounded three-frame Cube sequence through C, Rust and Delphi without Fable, sleeping or terminal control. A source-level `while'` loop selects three rotations, allocates a fresh 160 x 44 frame, projects three cubes, builds the complete 7083-byte text and stores one spatial checksum per iteration.

Every frame preserves the complete text authority: 7040 cells, 44 rows, 160 columns, 43 newline bytes and scalar checksum 324274. Position-sensitive checksums combine the three projected indexes and are `45702`, `43786` and `43631`, proving that the rotations produce distinct frames rather than repeating the same buffer.

The sample exposed a generic fixed-array optimization boundary. A three-slot checksum array appears after many source-real helper functions, so extracting only the allocation owner would discard unrelated executable definitions. `PortableBackends.fs` now skips fixed-array scalarization whenever unrelated prelude functions exist and preserves the mature dynamic-array lowering instead.

The focused gate is `scripts/portable-cube-multiframe-direct-gate.sh`. It validates exact C, Rust and Delphi snapshots, three native builds and runs, three complete frames, the three spatial checksums, the dynamic checksum array fallback, projected casts and native exit code 42.

Timing, terminal clearing, cursor movement and unbounded animation remain outside this authority. The next semantic cut is buffer reuse across iterations, followed by a bounded terminal-output protocol only after ownership remains symmetric in Rust and Delphi.
