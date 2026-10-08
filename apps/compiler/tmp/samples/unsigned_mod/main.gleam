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

pub fn method0(v0: Int) -> Bool {
    let v1 = spiral_wrap_unsigned(v0 + 5, 32)
    let v2 = v1 % 4
    let v3 = v2 == 0
    v3
}
pub fn main() {
let v0 = 7
let v1 = method0(v0)
case v1 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
