import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn main() {
    let v0 = 6
    let v1 = 7
    let v2 = spiral_wrap_signed(v0 * v1, 32)
    let v3 = v2 == 42
    case v3 {
        True -> 0
        False -> 1
    }
}
