import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn count_0(v0: Int) -> Int {
    let v1 = v0 <= 0
    case v1 {
        True -> {
            0
        }
        False -> {
            let v2 = spiral_wrap_signed(v0 - 1, 32)
            count_0(v2)
        }
    }
}
pub fn main() {
let v0 = 5
count_0(v0)
}
