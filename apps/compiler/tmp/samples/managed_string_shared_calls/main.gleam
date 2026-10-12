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

pub fn measure_0(v0: String) -> Int {
    let v1 = spiral_string_length(v0)
    v1
}
pub fn main() {
let v0 = "qwe"
let v1 = measure_0(v0)
let v2 = measure_0(v0)
let v3 = spiral_wrap_signed(v1 + v2, 32)
let v4 = spiral_wrap_signed(v3 - 6, 32)
v4
}
