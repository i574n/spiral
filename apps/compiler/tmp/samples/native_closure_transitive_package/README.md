# Transitive external package fixture

This fixture proves a real non-included package graph across three ownership levels.

`main` depends on package `shared`; `shared` depends on sibling package `foundation`. The callable helper `apply1` belongs to `foundation/transport`, while `method0` belongs to `shared/offset`. Rust and Delphi consume the same dependency projection and both execute with exit code 42.

The portable manifest records package identities and edges separately from module dependencies. Packages are emitted once in dependency-first order, so diamond reuse can remain deterministic.

`cycle-package.spiproj` exercises the negative boundary. `cycle_a -> cycle_b -> cycle_a` must fail before a target directory is created.

This fixture does not claim arbitrary package graphs, dependency groups, package-owned type provenance, or cross-package cycles. It promotes only bounded acyclic transitive callable ownership.
