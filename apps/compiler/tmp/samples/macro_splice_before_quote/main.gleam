import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn main() {
    let v0 = 7
    let v1 = 5
    let v2 = v1 * 2
    let v3 = v0
    let v4 = spiral_wrap_signed(v2 + v3, 32)
    v4
}
