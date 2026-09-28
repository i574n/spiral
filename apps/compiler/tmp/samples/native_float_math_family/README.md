# Portable float math family

This sample exercises the mature Spiral `Log`, `Exp`, `Tanh`, `Sin` and `Cos` primitives at both `f32` and `f64` widths. The same Spiral source must emit and execute as C, Rust and Delphi.

The fixture uses exact identity points (`log(1) = 0`, `exp(0) = 1`, `tanh(0) = 0`, `sin(0) = 0`, `cos(0) = 1`) so the gate tests call projection and width preservation without conflating the result with cross-library approximation tolerances.

`Sin` and `Cos` required a parity patch in the original C backend before they could flow through the shared C-shaped portable authority. They are not tunneled directly into Rust or Delphi through a target-specific workaround.
