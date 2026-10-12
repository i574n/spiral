# Native bitwise scalar operations

This fixture promotes ordinary integer bitwise and shift operations already present in Spiral and its mature backends.

`main.spi` is compiled by Spiral to the retained `main.c` oracle. The portable lowerers then emit exact Rust and Delphi snapshots covering bitwise AND, OR, XOR, complement, left shift and right shift. Every native executable returns 42.

`precedence.c` is a focused C residual that keeps `|`, `^`, `&` and `<<` in one unparenthesized expression. Its native C, Rust and Delphi executions prove that the shared parser preserves C operator precedence. It is intentionally separate because Spiral's C codegen introduces temporaries around the source-level operations.

The fixture does not define target-specific operators or carry syntax through a side channel. Rust maps C complement `~` to `!`; Delphi maps the family to `and`, `or`, `xor`, `not`, `shl` and `shr`.
