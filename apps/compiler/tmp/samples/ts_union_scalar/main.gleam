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

pub type Us0 {
    Us0Hit(f0i0 : Int)
    Us0Miss(f1i0 : Int)
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Hit(v1) -> {
            v1
        }
        Us0Miss(v2) -> {
            let v3 = spiral_wrap_signed(0 - v2, 32)
            v3
        }
    }
}
pub fn main() {
let v0 = True
let v3 =
    case v0 {
        True -> {
            Us0Hit(7)
        }
        False -> {
            Us0Miss(3)
        }
    }
let v4 = score_0(v3)
let v5 = spiral_wrap_signed(v4 - 7, 32)
v5
}
