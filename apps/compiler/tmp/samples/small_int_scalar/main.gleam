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
    let v4 = spiral_wrap_unsigned(v2 + 100, 8)
    let v6 = int.bitwise_shift_right(-8, 1)
    let v7 = int.bitwise_shift_right(v2, 1)
    let v8 = 20000
    let v9 = spiral_wrap_signed(v8 + v8, 16)
    let v10 = 40000
    let v11 = spiral_wrap_unsigned(v10 + v10, 16)
    let v13 = spiral_wrap_signed(7, 8)
    let v15 = spiral_wrap_signed(9, 32)
    let v16 = v1 == -56
    let v18 =
        case v16 {
            True -> {
                v4 == 44
            }
            False -> False
        }
    let v20 =
        case v18 {
            True -> {
                v6 == -4
            }
            False -> False
        }
    let v22 =
        case v20 {
            True -> {
                v7 == 100
            }
            False -> False
        }
    let v24 =
        case v22 {
            True -> {
                v9 == -25536
            }
            False -> False
        }
    let v26 =
        case v24 {
            True -> {
                v11 == 14464
            }
            False -> False
        }
    let v28 =
        case v26 {
            True -> {
                v13 == 7
            }
            False -> False
        }
    let v30 =
        case v28 {
            True -> {
                v15 == 9
            }
            False -> False
        }
    case v30 {
        True -> 0
        False -> 1
    }
}
