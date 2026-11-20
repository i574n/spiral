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


pub fn method2(v0: Int, v1: Int, v2: Int) -> #(Int, Int) {
    let v3 = spiral_wrap_i32(v0 - 1)
    let v4 = spiral_wrap_i32(v1 + 1)
    let v5 = spiral_wrap_i32(v2 + 2)
    let v6 = v3 == 0
    case v6 {
        True -> #(v4, v5)
        False -> method2(v3, v4, v5)
    }
}
pub fn method1(v0: Int) -> #(Int, Int) {
    let v1 = 0
    let v2 = 0
    let v3 = v0 == 0
    case v3 {
        True -> #(v1, v2)
        False -> method2(v0, v1, v2)
    }
}
pub fn method0(v0: Int) -> Int {
    let #(v1, v2) = method1(v0)
    let v3 = v1 == 4
    let v5 =
        case v3 {
            True -> {
                v2 == 8
            }
            False -> False
        }
    case v5 {
        True -> 0
        False -> 1
    }
}
pub fn main() {
    method0(4)
}
