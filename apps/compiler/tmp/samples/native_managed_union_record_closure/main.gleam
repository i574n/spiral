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


pub type Us0 {
    Us0Empty
    Us0Item(f1i0 : String, f1i1 : Int)
}
pub fn closure0(capt: Nil) -> fn(Int) -> Us0 {
    fn (v0) {
        let v1 = v0 == 0
        case v1 {
            True -> {
                Us0Empty
            }
            False -> {
                let v3 = "managed"
                Us0Item(v3, 32)
            }
        }
    }
}
pub fn method0(v0: fn(Int) -> Us0) -> Us0 {
    v0(0)
}
pub fn method1(v0: fn(Int) -> Us0) -> Us0 {
    v0(1)
}
pub fn main() {
    let v0 = closure0(Nil)
    let v1 = method0(v0)
    let v7 =
        case v1  {
            Us0Empty -> {
                3
            }
            Us0Item(v2, v3) -> {
                let v4 = spiral_string_length(v2)
                let v5 = spiral_wrap_signed(v4 + v3, 32)
                v5
            }
        }
    let v8 = method1(v0)
    let v14 =
        case v8  {
            Us0Empty -> {
                3
            }
            Us0Item(v9, v10) -> {
                let v11 = spiral_string_length(v9)
                let v12 = spiral_wrap_signed(v11 + v10, 32)
                v12
            }
        }
    let v15 = spiral_wrap_signed(v7 + v14, 32)
    v15
}
