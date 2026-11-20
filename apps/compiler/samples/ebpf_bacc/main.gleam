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


pub fn method1(v0: Int, v1: Bool) -> Bool {
    let v2 = spiral_wrap_i32(v0 - 1)
    let v4 =
        case v1 {
            True -> {
                v0 > 0
            }
            False -> False
        }
    let v5 = v2 == 0
    case v5 {
        True -> v4
        False -> method1(v2, v4)
    }
}
pub fn method0(v0: Int) -> Bool {
    let v1 = True
    let v2 = v0 == 0
    case v2 {
        True -> v1
        False -> method1(v0, v1)
    }
}
pub fn method2(v0: Int) -> Bool {
    let v1 = False
    let v2 = v0 == 0
    case v2 {
        True -> v1
        False -> method1(v0, v1)
    }
}
pub fn main() {
    let v0 = 3
    let v1 = method0(v0)
    let v2 = method2(v0)
    case v1 {
        True -> {
            case v2 {
                True -> 1
                False -> 0
            }
        }
        False -> 2
    }
}
