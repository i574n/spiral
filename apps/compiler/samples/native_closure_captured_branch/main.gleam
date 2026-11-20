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


pub fn a_c0(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        spiral_wrap_i32(v1 + v0)
    }
}
pub fn b_c1(capt: #(Int)) -> fn(Int) -> Int {
    fn (v1) {
        let #(v0) = capt
        spiral_wrap_i32(v1 + v0)
    }
}
pub fn method0(v0: fn(Int) -> Int) -> Int {
    v0(40)
}
pub fn main() {
    let v5 =
        case True {
            True -> a_c0(#(2))
            False -> b_c1(#(3))
        }
    method0(v5)
}
