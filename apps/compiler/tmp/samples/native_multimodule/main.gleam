import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn method0(v0: Int, v1: Int, v2: Int) -> Int {
    let v3 = spiral_wrap_signed(v0 * v1, 32)
    let v4 = spiral_wrap_signed(v3 + v2, 32)
    let v5 = spiral_wrap_signed(v4 - 42, 32)
    v5
}
pub fn main() {
    let v0 = 5
    let v1 = 8
    let v2 = 2
    method0(v0, v1, v2)
}
