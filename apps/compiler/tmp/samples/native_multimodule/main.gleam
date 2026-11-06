import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn method0(v0: Int, v1: Int, v2: Int) -> Int {
    let v3 = spiral_wrap_signed(v0 * v1, 32)
    let v4 = spiral_wrap_signed(v3 + v2, 32)
    spiral_wrap_signed(v4 - 42, 32)
}
pub fn main() {
    method0(5, 8, 2)
}
