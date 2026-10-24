import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn main() {
    let v0 = -1
    let v1 = -8
    let v2 = spiral_wrap_signed(int.bitwise_not(v0), 32)
    let v3 = spiral_wrap_signed(int.bitwise_not(v1), 32)
    let v4 = v2 == 0
    let v6 =
        case v4 {
            True -> {
                let v5 = v3 == 7
                v5
            }
            False -> {
                False
            }
        }
    case v6 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
