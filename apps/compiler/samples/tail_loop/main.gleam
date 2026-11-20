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


pub fn method1(v0: Int, v1: Int) -> Int {
    let v2 = spiral_wrap_i32(v0 - 1)
    let v3 = spiral_wrap_i32(v1 + v0)
    let v4 = v2 == 0
    case v4 {
        True -> v3
        False -> method1(v2, v3)
    }
}
pub fn method0(v0: Int) -> Int {
    let v1 = 0
    let v2 = v0 == 0
    let v4 =
        case v2 {
            True -> v1
            False -> method1(v0, v1)
        }
    spiral_wrap_i32(v4 - 55)
}
pub fn main() {
    method0(10)
}
