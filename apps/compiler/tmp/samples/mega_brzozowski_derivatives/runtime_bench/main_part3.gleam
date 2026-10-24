import main_types.{type SpiralArray, type Uh1, SpiralArray, Uh1InputCons, Uh1InputEmpty, Us0BitOne, Us0BitZero}
import main_part1.{random_bit_input_1, spiral_array_get, spiral_array_set, spiral_wrap_signed, zeros_input_14}
import main_part2.{interned_make_alt_29, interned_make_cat_31}

pub fn interned_derivative_raw_35(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int) -> Int {
    let v9 = spiral_wrap_signed(v7 * 2, 32)
    let v10 = spiral_wrap_signed(v9 + v8, 32)
    let v11 = spiral_array_get(v5, v10)
    let v12 = v11 == 0
    case v12 {
        True -> {
            let v13 = spiral_array_get(v0, v7)
            let v14 = v13 < 2
            let v41 =
                case v14 {
                    True -> {
                        0
                    }
                    False -> {
                        let v15 = v13 == 2
                        case v15 {
                            True -> {
                                let v16 = spiral_array_get(v1, v7)
                                let v17 = v16 == v8
                                case v17 {
                                    True -> {
                                        1
                                    }
                                    False -> {
                                        0
                                    }
                                }
                            }
                            False -> {
                                let v19 = v13 == 3
                                case v19 {
                                    True -> {
                                        let v20 = spiral_array_get(v1, v7)
                                        let v21 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v20, v8)
                                        let v22 = spiral_array_get(v2, v7)
                                        let v23 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v22, v8)
                                        interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v21, v23)
                                    }
                                    False -> {
                                        let v25 = v13 == 4
                                        case v25 {
                                            True -> {
                                                let v26 = spiral_array_get(v1, v7)
                                                let v27 = spiral_array_get(v2, v7)
                                                let v28 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v26, v8)
                                                let v29 = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v27)
                                                let v30 = spiral_array_get(v3, v26)
                                                let v31 = v30 == 1
                                                case v31 {
                                                    True -> {
                                                        let v32 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v27, v8)
                                                        interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v29, v32)
                                                    }
                                                    False -> {
                                                        v29
                                                    }
                                                }
                                            }
                                            False -> {
                                                let v35 = spiral_array_get(v1, v7)
                                                let v36 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v35, v8)
                                                interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v36, v7)
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            let v42 = spiral_wrap_signed(v41 + 1, 32)
            spiral_array_set(v5, v10, v42)
            v41
        }
        False -> {
            let v43 = spiral_wrap_signed(v11 - 1, 32)
            v43
        }
    }
}

pub fn loop_34(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Uh1) -> Bool {
    let v9 = v7 == 0
    case v9 {
        True -> {
            False
        }
        False -> {
            case v8  {
                Uh1InputCons(v12, v13) -> {
                    let v15 =
                        case v12  {
                            Us0BitOne -> {
                                1
                            }
                            Us0BitZero -> {
                                0
                            }
                        }
                    let v16 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v7, v15)
                    loop_34(v0, v1, v2, v3, v4, v5, v6, v16, v13)
                }
                Uh1InputEmpty -> {
                    let v10 = spiral_array_get(v3, v7)
                    let v11 = v10 == 1
                    v11
                }
            }
        }
    }
}

pub fn interned_accepts_33(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Uh1) -> Bool {
    loop_34(v0, v1, v2, v3, v4, v5, v6, v7, v8)
}

pub fn loop_32(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int, v9: Int, v10: Int, v11: Int) -> Int {
    let v12 = 0 < v9
    case v12 {
        True -> {
            let v13 = Uh1InputEmpty
            let #(v14, v15) = random_bit_input_1(v10, v7, v13)
            let v16 = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v14)
            let v18 =
                case v16 {
                    True -> {
                        let v17 = spiral_wrap_signed(v11 + 1, 32)
                        v17
                    }
                    False -> {
                        v11
                    }
                }
            let v19 = spiral_wrap_signed(v9 - 1, 32)
            loop_32(v0, v1, v2, v3, v4, v5, v6, v7, v8, v19, v15, v18)
        }
        False -> {
            v11
        }
    }
}

pub fn loop_36(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int, v9: Int, v10: Int) -> Int {
    let v11 = v7 < v9
    case v11 {
        True -> {
            v10
        }
        False -> {
            let v12 = Uh1InputEmpty
            let v13 = zeros_input_14(v9, v12)
            let v14 = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v13)
            let v16 =
                case v14 {
                    True -> {
                        let v15 = spiral_wrap_signed(v10 + 1, 32)
                        v15
                    }
                    False -> {
                        v10
                    }
                }
            let v17 = Us0BitOne
            let v18 = Uh1InputEmpty
            let v19 = Uh1InputCons(v17, v18)
            let v20 = zeros_input_14(v9, v19)
            let v21 = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v20)
            let v23 =
                case v21 {
                    True -> {
                        let v22 = spiral_wrap_signed(v16 + 1, 32)
                        v22
                    }
                    False -> {
                        v16
                    }
                }
            let v24 = spiral_wrap_signed(v9 + 1, 32)
            loop_36(v0, v1, v2, v3, v4, v5, v6, v7, v8, v24, v23)
        }
    }
}
