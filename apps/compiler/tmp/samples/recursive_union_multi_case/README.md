# Recursive union multi-case frontier

Negative frontier fixture retained in Spiral-bin.

The public compiler accepts the three-case recursive union declaration, construction and an inline match. It fails when the recursive value crosses a separately declared function parameter boundary, before portable lowering runs. The release gate expects status 5 (`FatalError`) and verifies that no residual file is produced.

This remains an inference/compiler-frontier task, not a Rust or Delphi lowering workaround.
