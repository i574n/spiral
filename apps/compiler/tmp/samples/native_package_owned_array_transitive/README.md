# Package-owned managed array across a transitive graph

This fixture keeps `Array0` and `Tuple0` in `types/record`, relays the owned aggregate through `relay/forward`, and consumes it in `consumer/use`.

The native program verifies that the managed array reaches the relay with one live owner, is cloned only for the returned aggregate, and is released by the final consumer. C, Rust and Delphi all exit with 42.

The contract intentionally proves only owner-preserving transitive transport. General type relocation, recursive package-owned families and dependency groups remain outside scope.
