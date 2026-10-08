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

pub fn method0(v0: Int) -> Int {
    let v1 = v0 <= 1
    case v1 {
        True -> {
            v0
        }
        False -> {
            let v2 = spiral_wrap_signed(v0 - 1, 32)
            let v3 = method0(v2)
            let v4 = spiral_wrap_signed(v0 - 2, 32)
            let v5 = method0(v4)
            let v6 = spiral_wrap_signed(v3 + v5, 32)
            v6
        }
    }
}
pub fn main() {
let v0 = 10
let v1 = method0(v0)
let v2 = spiral_wrap_signed(v1 - 55, 32)
v2
}
