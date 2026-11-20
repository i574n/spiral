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


pub fn method0(v0: Int, v1: Int, v2: Int) -> Int {
    let v3 = spiral_wrap_i32(v0 * v1)
    let v4 = spiral_wrap_i32(v3 + v2)
    spiral_wrap_i32(v4 - 42)
}
pub fn main() {
    method0(5, 8, 2)
}
