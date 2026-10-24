import gleam/int

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn main() {
    let v0 = 65536
    let v1 = 65536
    let v2 = 4294967295
    let v3 = 3
    let v4 = spiral_wrap_unsigned(v0 * v1, 32)
    let v5 = spiral_wrap_unsigned(v2 * v3, 32)
    let v6 = v4 == 0
    let v8 =
        case v6 {
            True -> {
                let v7 = v5 == 4294967293
                v7
            }
            False -> {
                False
            }
        }
    case v8 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
