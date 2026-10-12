# Nested dynamic array resize

Positive Spiral-bin fixture for Rust, Delphi and the C oracle.

The program stores resizable dynamic arrays inside another resizable array, passes similarly named variables through separate residual functions, shrinks the outer array and grows it again. Removed managed elements must be dropped, retained aliases must remain valid and newly exposed slots must contain default empty arrays rather than stale references.

This fixture also guards helper rebinding scope: local names such as `v0` may recur in different functions while referring to different array families. Rust validates clone/drop behavior with nested `Rc<RefCell<Vec<_>>>`; Delphi validates nested reference counting and explicit truncation cleanup. The C residual is validated with `scripts/dynamic-array-resize-nested-c-shim.h`.