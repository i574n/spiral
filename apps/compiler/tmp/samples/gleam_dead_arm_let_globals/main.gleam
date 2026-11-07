import spiral_dead_arm_marker
import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn picked_0(v0: Int) -> Int {
    v0
}
pub fn main() {
    let v1 = picked_0(5)
    spiral_wrap_signed(v1 + 1, 32)
}
