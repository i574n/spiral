import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn main() {
let v0 = 250
let v1 = 10
let v2 = 4294967295
let v3 = 18446744073709551615
let v4 = 127
let v5 = 1
let v6 = 7
let v7 = 2
let v8 = 9223372036854775807
let v9 = spiral_wrap_signed(0 - v6, 32)
let v10 = spiral_wrap_signed(0 - v8, 64)
let v11 = spiral_wrap_unsigned(v0 + v1, 8)
let v12 = v11 == 4
case v12 {
    True -> {
        let v13 = spiral_wrap_unsigned(v2 + 1, 32)
        let v14 = v13 == 0
        case v14 {
            True -> {
                let v15 = spiral_wrap_unsigned(v2 * v2, 32)
                let v16 = v15 == 1
                case v16 {
                    True -> {
                        let v17 = spiral_wrap_unsigned(v3 + 1, 64)
                        let v18 = v17 == 0
                        case v18 {
                            True -> {
                                let v19 = spiral_wrap_unsigned(v3 * v3, 64)
                                let v20 = v19 == 1
                                case v20 {
                                    True -> {
                                        let v21 = v3 / 3
                                        let v22 = v21 == 6148914691236517205
                                        case v22 {
                                            True -> {
                                                let v23 = spiral_wrap_signed(v4 + v5, 8)
                                                let v24 = v23 < 0
                                                case v24 {
                                                    True -> {
                                                        let v25 = v9 / v7
                                                        let v26 = v25 == -3
                                                        case v26 {
                                                            True -> {
                                                                let v27 = v9 % v7
                                                                let v28 = v27 == -1
                                                                case v28 {
                                                                    True -> {
                                                                        let v29 = v10 % 10
                                                                        let v30 = v29 == -7
                                                                        case v30 {
                                                                            True -> {
                                                                                let v31 = int.bitwise_shift_right(v2, 28)
                                                                                let v32 = v31 == 15
                                                                                case v32 {
                                                                                    True -> {
                                                                                        let v33 = int.bitwise_shift_right(v9, 1)
                                                                                        let v34 = v33 == -4
                                                                                        case v34 {
                                                                                            True -> {
                                                                                                0
                                                                                            }
                                                                                            False -> {
                                                                                                12
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    False -> {
                                                                                        11
                                                                                    }
                                                                                }
                                                                            }
                                                                            False -> {
                                                                                10
                                                                            }
                                                                        }
                                                                    }
                                                                    False -> {
                                                                        9
                                                                    }
                                                                }
                                                            }
                                                            False -> {
                                                                8
                                                            }
                                                        }
                                                    }
                                                    False -> {
                                                        7
                                                    }
                                                }
                                            }
                                            False -> {
                                                6
                                            }
                                        }
                                    }
                                    False -> {
                                        5
                                    }
                                }
                            }
                            False -> {
                                4
                            }
                        }
                    }
                    False -> {
                        3
                    }
                }
            }
            False -> {
                2
            }
        }
    }
    False -> {
        1
    }
}
}
