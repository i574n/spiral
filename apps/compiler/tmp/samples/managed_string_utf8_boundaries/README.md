# Managed UTF-8 byte boundaries

This fixture fixes the public string contract across C, Rust and Delphi. `StringLength`, `StringIndex` and `StringSlice` remain byte-oriented. A non-empty slice must start and end on UTF-8 codepoint boundaries. The source `éλ` occupies four bytes; slicing `0..1` and `2..3` yields two valid codepoints, and concatenating them reconstructs the original string.
