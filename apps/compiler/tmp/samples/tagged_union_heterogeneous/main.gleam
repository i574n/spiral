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
    Us0i0(f0i0 : Int)
    Us0i1(f1i0 : Bool)
}
pub fn method0(v0: Us0) -> Int {
    case v0  {
        Us0i1(v2) -> {
            case v2 {
                True -> {
                    9
                }
                False -> {
                    4
                }
            }
        }
        Us0i0(v1) -> {
            v1
        }
    }
}
pub fn main() {
let v0 = False
let v3 =
    case v0 {
        True -> {
            Us0i0(7)
        }
        False -> {
            Us0i1(True)
        }
    }
let v4 = method0(v3)
let v5 = spiral_wrap_signed(v4 - 9, 32)
v5
}
