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
    Us0i0
    Us0i1(f1i0 : Int)
    Us0i2(f2i0 : Bool)
}
pub fn method0(v0: Us0) -> Int {
    case v0  {
        Us0i2(v2) -> {
            case v2 {
                True -> {
                    11
                }
                False -> {
                    5
                }
            }
        }
        Us0i1(v1) -> {
            v1
        }
        Us0i0 -> {
            3
        }
    }
}
pub fn main() {
let v0 = 2
let v1 = v0 == 0
let v7 =
    case v1 {
        True -> {
            Us0i0
        }
        False -> {
            let v3 = v0 == 1
            case v3 {
                True -> {
                    Us0i1(7)
                }
                False -> {
                    Us0i2(True)
                }
            }
        }
    }
let v8 = method0(v7)
let v9 = spiral_wrap_signed(v8 - 11, 32)
v9
}
