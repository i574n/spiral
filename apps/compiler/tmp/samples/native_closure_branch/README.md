# Native closure branch selection

This fixture proves that two noncapturing callable implementations with the same signature can be selected dynamically and transported through one callable type. The true branch selects addition by 2, so C, Rust, and Delphi must all exit with code 42.

The portable representation uses a tagged callable environment. Different capture layouts remain rejected until a typed environment union is implemented.
