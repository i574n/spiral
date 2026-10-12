# ABI aggregate argument by value

This fixture calls libm `cabs` through a native complex value passed by value. Spiral supplies scalar components; the Rust and Delphi wrappers construct ABI-compatible two-double aggregates and expect magnitude 5 for 3+4i.
