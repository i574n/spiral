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


pub fn f_c0(capt: #(Int, Int)) -> fn(Int) -> Int {
    fn (v2) {
        let #(v0, v1) = capt
        let v3 = spiral_wrap_i32(v0 + v1)
        spiral_wrap_i32(v3 + v2)
    }
}
pub fn main() {
    let v2 = f_c0(#(1, 2))
    let v3 = v2(10)
    let v4 = v2(20)
    let v5 = v2(3)
    let v6 = spiral_wrap_i32(v3 + v4)
    spiral_wrap_i32(v6 + v5)
}
