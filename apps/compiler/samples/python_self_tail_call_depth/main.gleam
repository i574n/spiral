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


pub fn count_down_0(v0: Int, v1: Int) -> Int {
    let v2 = 0 < v0
    case v2 {
        True -> {
            let v3 = spiral_wrap_i32(v0 - 1)
            let v4 = spiral_wrap_i32(v1 + 1)
            count_down_0(v3, v4)
        }
        False -> v1
    }
}
pub fn main() {
    let v2 = count_down_0(5000, 0)
    let v3 = v2 == 5000
    case v3 {
        True -> 0
        False -> 1
    }
}
