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


pub type Uh0 {
    Uh0Empty
    Uh0Node(String, Uh0, Uh0)
}
pub fn score_0(v0: Uh0) -> Int {
    case v0  {
        Uh0Empty -> 0
        Uh0Node(v1, v2, v3) -> {
            let v4 = spiral_string_length(v1)
            let v5 = score_0(v2)
            let v6 = spiral_wrap_signed(v4 + v5, 32)
            let v7 = score_0(v3)
            let v8 = spiral_wrap_signed(v6 + v7, 32)
            v8
        }
    }
}
pub fn main() {
    let v0 = "ab"
    let v1 = "qwe"
    let v2 = Uh0Empty
    let v3 = Uh0Node(v1, v2, v2)
    let v4 = Uh0Node(v0, v3, v3)
    let v5 = score_0(v4)
    let v6 = Uh0Empty
    let v7 = Uh0Node(v1, v6, v6)
    let v8 = Uh0Node(v0, v7, v7)
    let v9 = score_0(v8)
    let v10 = spiral_wrap_signed(v5 + v9, 32)
    let v11 = spiral_wrap_signed(v10 - 16, 32)
    v11
}
