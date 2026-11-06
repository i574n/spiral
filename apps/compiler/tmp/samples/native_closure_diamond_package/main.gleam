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


pub fn f_c0(capt: #(String)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = spiral_string_length(v0)
        spiral_wrap_signed(v2 + v1, 32)
    }
}
pub fn apply_1(v0: fn(Int) -> Int, v1: Int) -> Int {
    v0(v1)
}
pub fn method0(v0: fn(Int) -> Int, v1: Int) -> Int {
    let v2 = apply_1(v0, v1)
    spiral_wrap_signed(v2 + 1, 32)
}
pub fn method2(v0: fn(Int) -> Int, v1: Int) -> Int {
    let v2 = apply_1(v0, v1)
    spiral_wrap_signed(v2 + 2, 32)
}
pub fn main() {
    let v1 = f_c0(#("abc"))
    let v3 = method0(v1, 16)
    let v5 = method2(v1, 17)
    spiral_wrap_signed(v3 + v5, 32)
}
