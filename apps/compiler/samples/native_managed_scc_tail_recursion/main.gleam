import gleam/bit_array
import gleam/string
import gleam/int
pub fn spiral_string_length(text: String) -> Int {
  bit_array.byte_size(bit_array.from_string(text))
}

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


pub fn method2(v0: Int, v1: String) -> Int {
    let v2 = spiral_wrap_i32(v0 - 1)
    let v3 = v2 == 0
    case v3 {
        True -> {
            spiral_string_length(v1)
        }
        False -> method1(v2, v1)
    }
}
pub fn method1(v0: Int, v1: String) -> Int {
    let v2 = spiral_wrap_i32(v0 - 1)
    let v3 = v2 == 0
    case v3 {
        True -> 99
        False -> method2(v2, v1)
    }
}
pub fn method0(v0: Int, v1: String) -> Int {
    let v2 = v0 == 0
    let v5 =
        case v2 {
            True -> {
                spiral_string_length(v1)
            }
            False -> method1(v0, v1)
        }
    spiral_wrap_i32(v5 - 2)
}
pub fn main() {
    let v0 = 1000000
    let v1 = v0 % 2
    let v2 = v1 == 0
    let v5 =
        case v2 {
            True -> {
                "ok"
            }
            False -> {
                "go"
            }
        }
    method0(v0, v5)
}
