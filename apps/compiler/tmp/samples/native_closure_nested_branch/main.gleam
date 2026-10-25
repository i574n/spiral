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


pub fn left_c0(capt: #(String, Int)) -> fn(Int) -> Int {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = v2 > 0
        case v3 {
            True -> {
                let v4 = spiral_string_length(v0)
                let v5 = spiral_wrap_signed(v4 + v1, 32)
                let v6 = spiral_wrap_signed(v5 + v2, 32)
                v6
            }
            False -> {
                0
            }
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
                let v5 = spiral_wrap_signed(v4 + v1, 32)
                let v6 = spiral_wrap_signed(v5 + v2, 32)
                let v7 = spiral_wrap_signed(v6 - 1, 32)
                v7
            }
            False -> {
                -1
            }
        }
    }
}
pub fn method0(v0: fn(Int) -> Int) -> Int {
    v0(37)
}
pub fn main() {
    let v0 = "abc"
    let v1 = "wxyz"
    let v2 = 2
    let v3 = 2
    let v4 = True
    let v7 =
        case v4 {
            True -> {
                left_c0(#(v0, v2))
            }
            False -> {
                right_c1(#(v1, v3))
            }
        }
    method0(v7)
}
