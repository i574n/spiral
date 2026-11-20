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


pub fn count_0(v0: Int) -> Int {
    let v1 = v0 <= 0
    case v1 {
        True -> 0
        False -> {
            let v2 = spiral_wrap_i32(v0 - 1)
            count_0(v2)
        }
    }
}
pub fn main() {
    count_0(5)
}
