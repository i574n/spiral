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


pub fn measure_0(v0: String) -> Int {
    spiral_string_length(v0)
}
pub fn main() {
    let v0 = "qwe"
    let v1 = measure_0(v0)
    let v2 = measure_0(v0)
    let v3 = spiral_wrap_signed(v1 + v2, 32)
    spiral_wrap_signed(v3 - 6, 32)
}
