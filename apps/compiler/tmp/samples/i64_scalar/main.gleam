import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn main() {
    let v2 = 5000000000 / -4
    let v3 = 1000000
    let v4 = spiral_wrap_signed(v3 * v3, 64)
    let v6 = int.bitwise_shift_right(-8, 1)
    let v7 = 7
    let v8 = spiral_wrap_signed(v7, 64)
    let v10 = spiral_wrap_signed(9, 32)
    let v11 = 4294967296
    let v12 = spiral_wrap_unsigned(v11 + 1, 64)
    let v13 = int.bitwise_shift_right(v11, 1)
    let v14 = spiral_wrap_unsigned(v7, 64)
    let v15 = v2 == -1250000000
    let v17 =
        case v15 {
            True -> {
                v4 == 1000000000000
            }
            False -> False
        }
    let v19 =
        case v17 {
            True -> {
                v6 == -4
            }
            False -> False
        }
    let v21 =
        case v19 {
            True -> {
                v8 == 7
            }
            False -> False
        }
    let v23 =
        case v21 {
            True -> {
                v10 == 9
            }
            False -> False
        }
    let v25 =
        case v23 {
            True -> {
                v12 == 4294967297
            }
            False -> False
        }
    let v27 =
        case v25 {
            True -> {
                v13 == 2147483648
            }
            False -> False
        }
    let v29 =
        case v27 {
            True -> {
                v14 == 7
            }
            False -> False
        }
    case v29 {
        True -> 0
        False -> 1
    }
}
