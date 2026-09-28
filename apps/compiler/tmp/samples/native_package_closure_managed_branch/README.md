# Package-owned managed closure branch

This fixture keeps the managed String, callable interface and two closure environments in the `types/callable` package. `selector/select` chooses one environment through a branch, `consumer/use` invokes it, and the root returns 42. Rust and Delphi must preserve one owner for the whole callable type group, derive package dependencies, and release the selected managed capture exactly once.
