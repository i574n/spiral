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

pub fn left_c0(capt: #(String)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = spiral_string_length(v0)
        let v3 = spiral_wrap_signed(v2 + v1, 32)
        v3
    }
}
pub fn right_c1(capt: #(String)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = spiral_string_length(v0)
        let v3 = spiral_wrap_signed(v2 + v1, 32)
        let v4 = spiral_wrap_signed(v3 - 1, 32)
        v4
    }
}
pub fn method0(v0: fn(Int) -> Int) -> Int {
    v0( 39  )
}
pub fn main() {
let v0 = "abc"
let v1 = "wxyz"
let v2 = True
let v5 =
    case v2 {
        True -> {
            left_c0(#(v0))
        }
        False -> {
            right_c1(#(v1))
        }
    }
method0(v5)
}
