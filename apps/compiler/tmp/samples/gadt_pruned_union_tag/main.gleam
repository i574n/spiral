import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub type Us0 {
    Us0First
    Us0Second
}
pub fn main() {
    let v1 = case Us0Second { Us0First -> 1 Us0Second -> 2 }
    let v2 = spiral_wrap_signed(v1 * 10, 32)
    spiral_wrap_signed(v2 + 2, 32)
}
