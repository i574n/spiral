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

pub fn method0(v0: Int, v1: Int) -> Bool {
    let v2 = -v0 
    let v3 = v2 <= 0
    case v3 {
        True -> {
            let v4 = spiral_wrap_signed(v1 * 2, 32)
            let v5 = spiral_wrap_signed(v0 + v4, 32)
            let v6 = v5 >= 9
            case v6 {
                True -> {
                    True
                }
                False -> {
                    let v7 = v1 == 0
                    v7
                }
            }
        }
        False -> {
            False
        }
    }
}
pub fn main() {
let v0 = 3
let v1 = 3
let v2 = method0(v0, v1)
case v2 {
    True -> {
        0
    }
    False -> {
        1
    }
}
}
