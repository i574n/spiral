import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn main() {
    let v0 = 7
    let v1 = 2
    let v2 = 4294967295
    let v3 = spiral_wrap_signed(0 - v0, 32)
    let v4 = -3
    let v5 = -12
    let v6 = -4
    let v7 = -1
    let v8 = v3 / v1
    let v9 = v8 == v4
    case v9 {
        True -> {
            let v10 = v3 % v1
            let v11 = v10 == v7
            case v11 {
                True -> {
                    let v12 = int.bitwise_shift_right(v3, 1)
                    let v13 = v12 == v6
                    case v13 {
                        True -> {
                            let v14 = spiral_wrap_signed(int.bitwise_shift_left(v4, 2), 32)
                            let v15 = v14 == v5
                            case v15 {
                                True -> {
                                    let v16 = spiral_wrap_unsigned(v2 + 1, 32)
                                    let v17 = v16 == 0
                                    case v17 {
                                        True -> {
                                            let v18 = spiral_wrap_unsigned(v2 * v2, 32)
                                            let v19 = v18 == 1
                                            case v19 {
                                                True -> {
                                                    let v20 = int.bitwise_shift_right(v2, 28)
                                                    let v21 = v20 == 15
                                                    case v21 {
                                                        True -> 0
                                                        False -> 7
                                                    }
                                                }
                                                False -> 6
                                            }
                                        }
                                        False -> 5
                                    }
                                }
                                False -> 4
                            }
                        }
                        False -> 3
                    }
                }
                False -> 2
            }
        }
        False -> 1
    }
}
