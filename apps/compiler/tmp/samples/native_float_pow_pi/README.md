# Native float power and pi

This fixture proves reference-parity lowering for `Pow` at `f32` and `f64`, plus typed `Pi` constants. The exact checks use `2^3 = 8` and the bounded interval `3 < pi < 4` across C, Rust and Delphi.
