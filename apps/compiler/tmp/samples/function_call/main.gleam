import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn method0(v0: Int, v1: Int) -> Int {
    let v2 = spiral_wrap_signed(v0 + v1, 32)
    let v3 = spiral_wrap_signed(v2 - 42, 32)
    v3
}
pub fn main() {
    let v0 = 20
    let v1 = 22
    method0(v0, v1)
}
