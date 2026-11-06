import gleam/int

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn main() {
    let v4 = spiral_wrap_unsigned(65536 * 65536, 32)
    let v5 = spiral_wrap_unsigned(4294967295 * 3, 32)
    let v6 = v4 == 0
    let v8 =
        case v6 {
            True -> {
                v5 == 4294967293
            }
            False -> False
        }
    case v8 {
        True -> 0
        False -> 1
    }
}
