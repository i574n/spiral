import gleam/bit_array
import gleam/string
import gleam/int
pub fn spiral_string_length(text: String) -> Int {
  bit_array.byte_size(bit_array.from_string(text))
}

pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  case value >= 0 - half && value < half {
    True -> value
    False -> int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
  }
}

pub fn spiral_wrap_i32(value: Int) -> Int {
  case value >= -2147483648 && value <= 2147483647 {
    True -> value
    False -> spiral_wrap_signed(value, 32)
  }
}


pub type Us0 {
    Us0Empty
    Us0Item(f1i0 : String, f1i1 : Int)
}
pub fn closure0(capt: Nil) -> fn(Int) -> Us0 {
    fn (v0) {
        let v1 = v0 == 0
        case v1 {
            True -> Us0Empty
            False -> {
                Us0Item("managed", 32)
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
            Us0Empty -> 3
            Us0Item(v2, v3) -> {
                let v4 = spiral_string_length(v2)
                spiral_wrap_i32(v4 + v3)
            }
        }
    let v8 = method1(v0)
    let v14 =
        case v8  {
            Us0Empty -> 3
            Us0Item(v9, v10) -> {
                let v11 = spiral_string_length(v9)
                spiral_wrap_i32(v11 + v10)
            }
        }
    spiral_wrap_i32(v7 + v14)
}
