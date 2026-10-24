import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn main() {
    let v0 = 5000000000
    let v1 = -4
    let v2 = v0 / v1
    let v3 = 1000000
    let v4 = spiral_wrap_signed(v3 * v3, 64)
    let v5 = -8
    let v6 = int.bitwise_shift_right(v5, 1)
    let v7 = 7
    let v8 = spiral_wrap_signed(v7, 64)
    let v9 = 9
    let v10 = spiral_wrap_signed(v9, 32)
    let v11 = 4294967296
    let v12 = spiral_wrap_unsigned(v11 + 1, 64)
    let v13 = int.bitwise_shift_right(v11, 1)
    let v14 = spiral_wrap_unsigned(v7, 64)
    let v15 = v2 == -1250000000
    let v17 =
        case v15 {
            True -> {
                let v16 = v4 == 1000000000000
                v16
            }
            False -> {
                False
            }
        }
    let v19 =
        case v17 {
            True -> {
                let v18 = v6 == -4
                v18
            }
            False -> {
                False
            }
        }
    let v21 =
        case v19 {
            True -> {
                let v20 = v8 == 7
                v20
            }
            False -> {
                False
            }
        }
    let v23 =
        case v21 {
            True -> {
                let v22 = v10 == 9
                v22
            }
            False -> {
                False
            }
        }
    let v25 =
        case v23 {
            True -> {
                let v24 = v12 == 4294967297
                v24
            }
            False -> {
                False
            }
        }
    let v27 =
        case v25 {
            True -> {
                let v26 = v13 == 2147483648
                v26
            }
            False -> {
                False
            }
        }
    let v29 =
        case v27 {
            True -> {
                let v28 = v14 == 7
                v28
            }
            False -> {
                False
            }
        }
    case v29 {
        True -> {
            0
        }
        False -> {
            1
        }
    }
}
