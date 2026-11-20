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


pub fn method0(v0: Int, v1: Int) -> Bool {
    let v2 = -v0 
    let v3 = v2 <= 0
    case v3 {
        True -> {
            let v4 = spiral_wrap_i32(v1 * 2)
            let v5 = spiral_wrap_i32(v0 + v4)
            let v6 = v5 >= 9
            case v6 {
                True -> True
                False -> {
                    v1 == 0
                }
            }
        }
        False -> False
    }
}
pub fn main() {
    let v2 = method0(3, 3)
    case v2 {
        True -> 0
        False -> 1
    }
}
