# Native float square roots

This fixture closes a direct parity gap with the mature Lua and Gleam backends. The same Spiral source applies the built-in `Sqrt` primitive to `f32` and `f64` values.

The C oracle emits `sqrtf` and `sqrt`. Rust projects both operations as the inherent `.sqrt()` method while preserving `f32` and `f64`. Delphi projects both operations as `Sqrt` and imports the `Math` unit only when the generated program needs it.

The fixture checks exact roots so the native programs return zero only when both widths are lowered and executed correctly. It does not claim general floating-point parity: NaN, infinities, rounding modes, transcendental functions, fused operations and cross-target reproducibility remain outside this contract.
