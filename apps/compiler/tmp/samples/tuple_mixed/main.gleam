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

pub fn method0(v0: Float) -> #(Bool, Float, Int) {
    let v1 = v0 >=. 3.5
    #(v1, v0, 7)
}
pub fn method1(v0: Bool, v1: Float, v2: Int) -> Int {
    case v0 {
        True -> {
            let v3 = v1 >=. 3.5
            case v3 {
                True -> {
                    let v4 = spiral_wrap_signed(v2 - 7, 32)
                    v4
                }
                False -> {
                    1
                }
            }
        }
        False -> {
            2
        }
    }
}
pub fn main() {
let v0 = 4.0
let #(v1, v2, v3) = method0(v0)
method1(v1, v2, v3)
}
