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

pub fn count_down_0(v0: Int, v1: Int) -> Int {
    let v2 = 0 < v0
    case v2 {
        True -> {
            let v3 = spiral_wrap_signed(v0 - 1, 32)
            let v4 = spiral_wrap_signed(v1 + 1, 32)
            count_down_0(v3, v4)
        }
        False -> {
            v1
        }
    }
}
pub fn main() {
let v0 = 5000
let v1 = 0
let v2 = count_down_0(v0, v1)
let v3 = v2 == 5000
case v3 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
