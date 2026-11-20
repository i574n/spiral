// m1
// a1
// c1
// a2
// b1
// m2
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


pub fn leaf_c_1() -> Int {
    0
}
pub fn slow_a_0() -> Int {
    leaf_c_1()
}
pub fn fast_b_2() -> Int {
    0
}
pub fn main() {
    let v0 = slow_a_0()
    let v1 = fast_b_2()
    spiral_wrap_i32(v0 + v1)
}
