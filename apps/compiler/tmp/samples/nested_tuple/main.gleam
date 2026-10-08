import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn spiral_int_power(base: Int, exponent: Int) -> Int {
  case exponent <= 0 {
    True -> 1
    False -> base * spiral_int_power(base, exponent - 1)
  }
}

@external(erlang, "math", "pow")
pub fn spiral_math_pow(base: Float, exponent: Float) -> Float

pub fn method0(v0: Int) -> #(Int, Int, Int, Int) {
    let v1 = spiral_wrap_signed(v0 + 1, 32)
    let v2 = spiral_wrap_signed(v0 + 2, 32)
    let v3 = spiral_wrap_signed(v0 + 3, 32)
    #(v0, v1, v2, v3)
}
pub fn method1(v0: Int, v1: Int, v2: Int, v3: Int) -> Int {
    let v4 = spiral_wrap_signed(v0 + v1, 32)
    let v5 = spiral_wrap_signed(v4 + v2, 32)
    let v6 = spiral_wrap_signed(v5 + v3, 32)
    let v7 = spiral_wrap_signed(v6 - 10, 32)
    v7
}
pub fn main() {
let v0 = 1
let #(v1, v2, v3, v4) = method0(v0)
method1(v1, v2, v3, v4)
}
