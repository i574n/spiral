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
        let v3 = spiral_wrap_signed(v2 + v1, 32)
        v3
    }
}
pub fn main() {
    let v0 = "abc"
    let v1 = f_c0(#(v0))
    let v2 = v1(10)
    let v3 = v1(20)
    let v4 = v1(3)
    let v5 = spiral_wrap_signed(v2 + v3, 32)
    let v6 = spiral_wrap_signed(v5 + v4, 32)
    v6
}
