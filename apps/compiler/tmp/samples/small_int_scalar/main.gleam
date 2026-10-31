import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn main() {
    let v0 = 100
    let v1 = spiral_wrap_signed(v0 + v0, 8)
    let v2 = 200
    let v3 = 100
    let v4 = spiral_wrap_unsigned(v2 + v3, 8)
    let v5 = -8
    let v6 = int.bitwise_shift_right(v5, 1)
    let v7 = int.bitwise_shift_right(v2, 1)
    let v8 = 20000
    let v9 = spiral_wrap_signed(v8 + v8, 16)
    let v10 = 40000
    let v11 = spiral_wrap_unsigned(v10 + v10, 16)
    let v12 = 7
    let v13 = spiral_wrap_signed(v12, 8)
    let v14 = 9
    let v15 = spiral_wrap_signed(v14, 32)
    let v16 = v1 == -56
    let v18 =
        case v16 {
            True -> {
                let v17 = v4 == 44
                v17
            }
            False -> False
        }
    let v20 =
        case v18 {
            True -> {
                let v19 = v6 == -4
                v19
            }
            False -> False
        }
    let v22 =
        case v20 {
            True -> {
                let v21 = v7 == 100
                v21
            }
            False -> False
        }
    let v24 =
        case v22 {
            True -> {
                let v23 = v9 == -25536
                v23
            }
            False -> False
        }
    let v26 =
        case v24 {
            True -> {
                let v25 = v11 == 14464
                v25
            }
            False -> False
        }
    let v28 =
        case v26 {
            True -> {
                let v27 = v13 == 7
                v27
            }
            False -> False
        }
    let v30 =
        case v28 {
            True -> {
                let v29 = v15 == 9
                v29
            }
            False -> False
        }
    case v30 {
        True -> 0
        False -> 1
    }
}
