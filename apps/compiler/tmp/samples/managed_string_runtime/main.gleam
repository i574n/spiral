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


pub fn main() {
    let v0 = "qwe"
    let v1 = spiral_string_length(v0)
    let v2 = spiral_wrap_signed(v1 + v1, 32)
    let v3 = spiral_wrap_signed(v2 - 6, 32)
    v3
}
