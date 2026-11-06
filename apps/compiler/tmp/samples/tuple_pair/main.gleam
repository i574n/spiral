import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn method0(v0: Int, v1: Int) -> #(Int, Int) {
    #(v0, v1)
}
pub fn method1(v0: Int, v1: Int) -> Int {
    spiral_wrap_signed(v0 + v1, 32)
}
pub fn main() {
    let #(v2, v3) = method0(20, 22)
    let v4 = method1(v2, v3)
    spiral_wrap_signed(v4 - 42, 32)
}
