import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  case value >= 0 - half && value < half {
    True -> value
    False -> int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
  }
}

pub fn spiral_wrap_i32(value: Int) -> Int {
  case value >= -2147483648 && value <= 2147483647 {
    True -> value
    False -> spiral_wrap_signed(value, 32)
  }
}


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
                    spiral_wrap_i32(v2 - 7)
                }
                False -> 1
            }
        }
        False -> 2
    }
}
pub fn main() {
    let #(v1, v2, v3) = method0(4.0)
    method1(v1, v2, v3)
}
