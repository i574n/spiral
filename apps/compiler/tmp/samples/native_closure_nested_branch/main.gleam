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


pub fn left_c0(capt: #(String, Int)) -> fn(Int) -> Int {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v2 > 0
        case v3 {
            True -> {
                let v4 = spiral_string_length(v0)
                let v5 = spiral_wrap_i32(v4 + v1)
                spiral_wrap_i32(v5 + v2)
            }
            False -> 0
        }
    }
}
pub fn right_c1(capt: #(String, Int)) -> fn(Int) -> Int {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v2 > 0
        case v3 {
            True -> {
                let v4 = spiral_string_length(v0)
                let v5 = spiral_wrap_i32(v4 + v1)
                let v6 = spiral_wrap_i32(v5 + v2)
                spiral_wrap_i32(v6 - 1)
            }
            False -> -1
        }
    }
}
pub fn method0(v0: fn(Int) -> Int) -> Int {
    v0(37)
}
pub fn main() {
    let v7 =
        case True {
            True -> left_c0(#("abc", 2))
            False -> right_c1(#("wxyz", 2))
        }
    method0(v7)
}
