# Native float NaN classification

This fixture proves reference-parity lowering for Spiral's mature `NanIs` operation at both `f32` and `f64` widths.

The same Spiral source creates quiet NaN values through the C-shaped portable expressions `nanf("")` and `nan("")`, classifies them with `NanIs`, and also proves that finite values are rejected by the predicate.

Expected projections:

```text
C:       nanf / nan + isnan
Rust:    f32::NAN / f64::NAN + is_nan
Delphi:  NaN + IsNan, with conditional Math import
```

The contract is bounded. It does not claim complete floating-point parity, NaN payload preservation, signaling-NaN behavior, total ordering, signed-zero equivalence, rounding-mode control or target-identical exception semantics.
