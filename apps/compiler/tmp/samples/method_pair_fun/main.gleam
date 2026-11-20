import gleam/int
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


pub fn left_c0(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = v0 == 0
        case v2 {
            True -> 0
            False -> {
                spiral_wrap_i32(v1 + v0)
            }
        }
    }
}
pub fn right_c1(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        let v2 = v0 == 0
        case v2 {
            True -> 0
            False -> {
                spiral_wrap_i32(v1 + v0)
            }
        }
    }
}
pub fn method0(v0: Int, v1: Int) -> #(fn(Int) -> Int, fn(Int) -> Int) {
    let v2 = left_c0(#(v0))
    let v3 = right_c1(#(v1))
    #(v2, v3)
}
pub fn main() {
    let #(v2, v3) = method0(3, 4)
    let v4 = v2(0)
    let v5 = v3(0)
    let v6 = spiral_wrap_i32(v4 + v5)
    let v7 = v6 == 7
    case v7 {
        True -> 0
        False -> 1
    }
}
