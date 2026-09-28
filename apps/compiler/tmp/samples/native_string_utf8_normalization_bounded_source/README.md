# Bounded UTF-8 canonical normalization

This fixture proves a deliberately limited canonical composition/decomposition table shared by the portable C, Rust and Delphi backends.

The supported table contains sixteen Latin pairs used by common Portuguese text. Unsupported scalars decompose to `(scalar, -1)`, and unsupported pairs remain two scalars. This is not full Unicode normalization and does not claim UAX #15 conformance.
