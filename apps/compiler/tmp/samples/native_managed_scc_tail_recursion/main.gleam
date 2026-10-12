import gleam/bit_array
import gleam/string
import gleam/int
pub fn spiral_string_length(text: String) -> Int {
  bit_array.byte_size(bit_array.from_string(text))
}

pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn method2(v0: Int, v1: String) -> Int {
    let v2 = spiral_wrap_signed(v0 - 1, 32)
    let v3 = v2 == 0
    case v3 {
        True -> {
            let v4 = spiral_string_length(v1)
            v4
        }
        False -> {
            method1(v2, v1)
        }
    }
}
pub fn method1(v0: Int, v1: String) -> Int {
    let v2 = spiral_wrap_signed(v0 - 1, 32)
    let v3 = v2 == 0
    case v3 {
        True -> {
            99
        }
        False -> {
            method2(v2, v1)
        }
    }
}
pub fn method0(v0: Int, v1: String) -> Int {
    let v2 = v0 == 0
    let v5 =
        case v2 {
            True -> {
                let v3 = spiral_string_length(v1)
                v3
            }
            False -> {
                method1(v0, v1)
            }
        }
    let v6 = spiral_wrap_signed(v5 - 2, 32)
    v6
}
pub fn main() {
let v0 = 1000000
let v1 = v0 % 2
let v2 = v1 == 0
let v5 =
    case v2 {
        True -> {
            let v3 = "ok"
            v3
        }
        False -> {
            let v4 = "go"
            v4
        }
    }
method0(v0, v5)
}
