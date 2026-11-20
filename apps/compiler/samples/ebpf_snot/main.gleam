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


pub fn main() {
    let v2 = spiral_wrap_i32(int.bitwise_not(-1))
    let v3 = spiral_wrap_i32(int.bitwise_not(-8))
    let v4 = v2 == 0
    let v6 =
        case v4 {
            True -> {
                v3 == 7
            }
            False -> False
        }
    case v6 {
        True -> 0
        False -> 1
    }
}
