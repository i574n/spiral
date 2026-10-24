// m1
// a1
// c1
// a2
// b1
// m2
import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn leaf_c_1() -> Int {
    0
}
pub fn slow_a_0() -> Int {
    let v0 = leaf_c_1()
    v0
}
pub fn fast_b_2() -> Int {
    0
}
pub fn main() {
    let v0 = slow_a_0()
    let v1 = fast_b_2()
    let v2 = spiral_wrap_signed(v0 + v1, 32)
    v2
}
