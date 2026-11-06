import gleam/int
import gleam/float
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub fn main() {
    let v0 = -2147483648
    let v1 = 4294967295
    let v2 = -1
    let v9 = 0.0 -. 1.9
    let v10 = spiral_wrap_unsigned(v0, 32)
    let v11 = spiral_wrap_signed(v10, 32)
    let v12 = spiral_wrap_signed(v1, 32)
    let v13 = spiral_wrap_unsigned(v2, 32)
    let v14 = float.truncate(v9)
    let v15 = float.truncate(2.9)
    let v16 = v10 / 2
    let v17 = 4294967294 / 2
    let v18 = 5 % 3
    let v19 = spiral_wrap_unsigned(int.bitwise_not(0), 32)
    let v20 = int.bitwise_shift_right(v1, 31)
    let v21 = v0 < -1
    let v23 =
        case v21 {
            True -> {
                v0 <= v0
            }
            False -> False
        }
    let v26 =
        case v23 {
            True -> {
                let v24 = v0 > 0
                v24 == False
            }
            False -> False
        }
    case v26 {
        True -> {
            let v27 = v10 > 1
            let v29 =
                case v27 {
                    True -> {
                        v11 == v0
                    }
                    False -> False
                }
            let v31 =
                case v29 {
                    True -> {
                        v12 == v2
                    }
                    False -> False
                }
            let v33 =
                case v31 {
                    True -> {
                        v13 == v1
                    }
                    False -> False
                }
            case v33 {
                True -> {
                    let v34 = v14 == v2
                    let v36 =
                        case v34 {
                            True -> {
                                v15 == 2
                            }
                            False -> False
                        }
                    case v36 {
                        True -> {
                            let v37 = v16 == 1073741824
                            let v39 =
                                case v37 {
                                    True -> {
                                        v17 == 2147483647
                                    }
                                    False -> False
                                }
                            let v41 =
                                case v39 {
                                    True -> {
                                        v18 == 2
                                    }
                                    False -> False
                                }
                            case v41 {
                                True -> {
                                    let v42 = v19 == v1
                                    let v44 =
                                        case v42 {
                                            True -> {
                                                v20 == 1
                                            }
                                            False -> False
                                        }
                                    case v44 {
                                        True -> 0
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
