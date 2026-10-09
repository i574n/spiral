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
    Us0Cold
    Us0Warm
    Us0Hot
    Us0Done
}
pub fn score_0(v0: Us0) -> Int {
    case v0  {
        Us0Cold -> {
            1
        }
        Us0Done -> {
            4
        }
        Us0Hot -> {
            3
        }
        Us0Warm -> {
            2
        }
    }
}
pub fn main() {
let v0 = 3
let v1 = v0 == 0
let v10 =
    case v1 {
        True -> {
            Us0Cold
        }
        False -> {
            let v3 = v0 == 1
            case v3 {
                True -> {
                    Us0Warm
                }
                False -> {
                    let v5 = v0 == 2
                    case v5 {
                        True -> {
                            Us0Hot
                        }
                        False -> {
                            Us0Done
                        }
                    }
                }
            }
        }
    }
let v11 = score_0(v10)
let v12 = spiral_wrap_signed(v11 - 4, 32)
v12
}
