# Native float infinity

This fixture proves the mature `Infinity` IR primitive at both `f32` and `f64` widths through the same Spiral source.

The C oracle emits `HUGE_VALF` and `HUGE_VAL`, Rust projects them to `f32::INFINITY` and `f64::INFINITY`, and Delphi projects both widths to the `Math.Infinity` value while retaining the declared `Single` or `Double` destination type.

The executable contract checks positive and negative infinity against finite values. A finite `NanIs` guard keeps the C oracle's required `<math.h>` include explicit without relying on target-specific payloads or on `Infinity - Infinity`, whose exception behavior differs across runtimes.

This fixture does not claim infinity classification, floating-point exception equivalence, signed-zero behavior, rounding-mode parity, NaN payload semantics or complete mathematical-library coverage.
