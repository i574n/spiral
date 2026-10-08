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

pub fn method2() -> Int {
    14
}
pub fn method1() -> Int {
    let v0 = method2()
    let v1 = spiral_wrap_signed(14 + v0, 32)
    v1
}
pub fn method0() -> Int {
    let v0 = method1()
    let v1 = spiral_wrap_signed(14 + v0, 32)
    v1
}
pub fn main() {
method0()
}
