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

pub fn choose_0(v0: Bool) -> String {
    case v0 {
        True -> {
            let v1 = "alpha"
            v1
        }
        False -> {
            let v2 = "beta"
            v2
        }
    }
}
pub fn measure_1(v0: String) -> Int {
    let v1 = spiral_string_length(v0)
    v1
}
pub fn main() {
let v0 = True
let v1 = choose_0(v0)
let v2 = False
let v3 = choose_0(v2)
let v4 = measure_1(v1)
let v5 = measure_1(v1)
let v6 = spiral_wrap_signed(v4 + v5, 32)
let v7 = measure_1(v3)
let v8 = spiral_wrap_signed(v6 + v7, 32)
let v9 = spiral_wrap_signed(v8 - 14, 32)
v9
}
