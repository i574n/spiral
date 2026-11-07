import gleam/int

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn main() {
    let v0 = 1
    let v2 = 31
    let v3 = spiral_wrap_unsigned(int.bitwise_shift_left(v0, v2), 32)
    let v4 = int.bitwise_shift_right(v3, v2)
    let v5 = spiral_wrap_unsigned(int.bitwise_shift_left(v0, 0), 32)
    let v6 = v3 == 2147483648
    let v8 =
        case v6 {
            True -> {
                v4 == 1
            }
            False -> False
        }
    let v10 =
        case v8 {
            True -> {
                v5 == 1
            }
            False -> False
        }
    case v10 {
        True -> 0
        False -> 1
    }
}
