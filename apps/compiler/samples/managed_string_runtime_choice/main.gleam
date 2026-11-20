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


pub fn choose_0(v0: Bool) -> String {
    case v0 {
        True -> {
            "alpha"
        }
        False -> {
            "beta"
        }
    }
}
pub fn measure_1(v0: String) -> Int {
    spiral_string_length(v0)
}
pub fn main() {
    let v1 = choose_0(True)
    let v3 = choose_0(False)
    let v4 = measure_1(v1)
    let v5 = measure_1(v1)
    let v6 = spiral_wrap_i32(v4 + v5)
    let v7 = measure_1(v3)
    let v8 = spiral_wrap_i32(v6 + v7)
    spiral_wrap_i32(v8 - 14)
}
