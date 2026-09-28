# Direct Cube sample

A compact, source-real adaptation of the uploaded Cube project for the portable backends. It preserves the three-cube projection math, nominal cube/rotation records, trigonometric intrinsics, a captured scoring closure and a projected union. The executable returns 42 when all three projected cubes are visible.

The adaptation intentionally removes Fable runtime dependencies, asynchronous animation, string building and backend_switch blocks. Those remain future parity surfaces; this sample is the first direct Rust/Delphi authority.
