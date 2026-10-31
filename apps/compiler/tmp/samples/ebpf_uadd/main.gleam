import gleam/int

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn main() {
    let v0 = 2147483647
    let v1 = 2
    let v2 = 1
    let v3 = spiral_wrap_unsigned(v0 + v1, 32)
    let v4 = spiral_wrap_unsigned(v0 + v2, 32)
    let v5 = v3 == 2147483649
    let v7 =
        case v5 {
            True -> {
                let v6 = v4 == 2147483648
                v6
            }
            False -> False
        }
    case v7 {
        True -> 0
        False -> 1
    }
}
