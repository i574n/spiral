import gleam/int
import main_types.{type SpiralArray, type Uh0, type Uh1, SpiralArray, Uh0RegexAlt, Uh0RegexCat, Uh0RegexChar, Uh0RegexEmpty, Uh0RegexEpsilon, Uh0RegexStar, Uh1InputCons, Uh1InputEmpty, Us0BitOne, Us0BitZero}
import main_part1.{random_bit_input_1, run_19, spiral_array_get, spiral_array_set, spiral_wrap_signed, zeros_input_14}

pub fn loop_18(v0: Int, v1: Int, v2: Int, v3: Int) -> Int {
    let v4 = 0 < v1
    case v4 {
        True -> {
            let v5 = Uh1InputEmpty
            let #(v6, v7) = random_bit_input_1(v2, v0, v5)
            let v8 = 0
            let v9 = run_19(v8, v6)
            let v11 =
                case v9 {
                    True -> {
                        let v10 = spiral_wrap_signed(v3 + 1, 32)
                        v10
                    }
                    False -> {
                        v3
                    }
                }
            let v12 = spiral_wrap_signed(v1 - 1, 32)
            loop_18(v0, v12, v7, v11)
        }
        False -> {
            v3
        }
    }
}

pub fn run_21(v0: Int, v1: Uh1) -> Bool {
    case v1  {
        Uh1InputCons(v17, v18) -> {
            case v17  {
                Us0BitOne -> {
                    let v50 = v0 == 0
                    let v79 =
                        case v50 {
                            True -> {
                                1
                            }
                            False -> {
                                let v51 = v0 == 1
                                case v51 {
                                    True -> {
                                        6
                                    }
                                    False -> {
                                        let v52 = v0 == 2
                                        case v52 {
                                            True -> {
                                                11
                                            }
                                            False -> {
                                                let v53 = v0 == 3
                                                case v53 {
                                                    True -> {
                                                        5
                                                    }
                                                    False -> {
                                                        let v54 = v0 == 4
                                                        case v54 {
                                                            True -> {
                                                                1
                                                            }
                                                            False -> {
                                                                let v55 = v0 == 5
                                                                case v55 {
                                                                    True -> {
                                                                        6
                                                                    }
                                                                    False -> {
                                                                        let v56 = v0 == 6
                                                                        case v56 {
                                                                            True -> {
                                                                                13
                                                                            }
                                                                            False -> {
                                                                                let v57 = v0 == 7
                                                                                case v57 {
                                                                                    True -> {
                                                                                        9
                                                                                    }
                                                                                    False -> {
                                                                                        let v58 = v0 == 8
                                                                                        case v58 {
                                                                                            True -> {
                                                                                                5
                                                                                            }
                                                                                            False -> {
                                                                                                let v59 = v0 == 9
                                                                                                case v59 {
                                                                                                    True -> {
                                                                                                        12
                                                                                                    }
                                                                                                    False -> {
                                                                                                        let v60 = v0 == 10
                                                                                                        case v60 {
                                                                                                            True -> {
                                                                                                                11
                                                                                                            }
                                                                                                            False -> {
                                                                                                                let v61 = v0 == 11
                                                                                                                case v61 {
                                                                                                                    True -> {
                                                                                                                        12
                                                                                                                    }
                                                                                                                    False -> {
                                                                                                                        let v62 = v0 == 12
                                                                                                                        case v62 {
                                                                                                                            True -> {
                                                                                                                                13
                                                                                                                            }
                                                                                                                            False -> {
                                                                                                                                let v63 = v0 == 13
                                                                                                                                case v63 {
                                                                                                                                    True -> {
                                                                                                                                        15
                                                                                                                                    }
                                                                                                                                    False -> {
                                                                                                                                        let v64 = v0 == 14
                                                                                                                                        case v64 {
                                                                                                                                            True -> {
                                                                                                                                                9
                                                                                                                                            }
                                                                                                                                            False -> {
                                                                                                                                                15
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    run_21(v79, v18)
                }
                Us0BitZero -> {
                    let v19 = v0 == 0
                    let v48 =
                        case v19 {
                            True -> {
                                0
                            }
                            False -> {
                                let v20 = v0 == 1
                                case v20 {
                                    True -> {
                                        2
                                    }
                                    False -> {
                                        let v21 = v0 == 2
                                        case v21 {
                                            True -> {
                                                3
                                            }
                                            False -> {
                                                let v22 = v0 == 3
                                                case v22 {
                                                    True -> {
                                                        4
                                                    }
                                                    False -> {
                                                        let v23 = v0 == 4
                                                        case v23 {
                                                            True -> {
                                                                0
                                                            }
                                                            False -> {
                                                                let v24 = v0 == 5
                                                                case v24 {
                                                                    True -> {
                                                                        2
                                                                    }
                                                                    False -> {
                                                                        let v25 = v0 == 6
                                                                        case v25 {
                                                                            True -> {
                                                                                7
                                                                            }
                                                                            False -> {
                                                                                let v26 = v0 == 7
                                                                                case v26 {
                                                                                    True -> {
                                                                                        8
                                                                                    }
                                                                                    False -> {
                                                                                        let v27 = v0 == 8
                                                                                        case v27 {
                                                                                            True -> {
                                                                                                4
                                                                                            }
                                                                                            False -> {
                                                                                                let v28 = v0 == 9
                                                                                                case v28 {
                                                                                                    True -> {
                                                                                                        10
                                                                                                    }
                                                                                                    False -> {
                                                                                                        let v29 = v0 == 10
                                                                                                        case v29 {
                                                                                                            True -> {
                                                                                                                3
                                                                                                            }
                                                                                                            False -> {
                                                                                                                let v30 = v0 == 11
                                                                                                                case v30 {
                                                                                                                    True -> {
                                                                                                                        10
                                                                                                                    }
                                                                                                                    False -> {
                                                                                                                        let v31 = v0 == 12
                                                                                                                        case v31 {
                                                                                                                            True -> {
                                                                                                                                7
                                                                                                                            }
                                                                                                                            False -> {
                                                                                                                                let v32 = v0 == 13
                                                                                                                                case v32 {
                                                                                                                                    True -> {
                                                                                                                                        14
                                                                                                                                    }
                                                                                                                                    False -> {
                                                                                                                                        let v33 = v0 == 14
                                                                                                                                        case v33 {
                                                                                                                                            True -> {
                                                                                                                                                8
                                                                                                                                            }
                                                                                                                                            False -> {
                                                                                                                                                14
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    run_21(v48, v18)
                }
            }
        }
        Uh1InputEmpty -> {
            let v2 = v0 == 4
            case v2 {
                True -> {
                    True
                }
                False -> {
                    let v3 = v0 == 5
                    case v3 {
                        True -> {
                            True
                        }
                        False -> {
                            let v4 = v0 == 8
                            case v4 {
                                True -> {
                                    True
                                }
                                False -> {
                                    let v5 = v0 == 9
                                    case v5 {
                                        True -> {
                                            True
                                        }
                                        False -> {
                                            let v6 = v0 == 10
                                            case v6 {
                                                True -> {
                                                    True
                                                }
                                                False -> {
                                                    let v7 = v0 == 12
                                                    case v7 {
                                                        True -> {
                                                            True
                                                        }
                                                        False -> {
                                                            let v8 = v0 == 14
                                                            case v8 {
                                                                True -> {
                                                                    True
                                                                }
                                                                False -> {
                                                                    let v9 = v0 == 15
                                                                    v9
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

pub fn loop_20(v0: Int, v1: Int, v2: Int, v3: Int) -> Int {
    let v4 = 0 < v1
    case v4 {
        True -> {
            let v5 = Uh1InputEmpty
            let #(v6, v7) = random_bit_input_1(v2, v0, v5)
            let v8 = 0
            let v9 = run_21(v8, v6)
            let v11 =
                case v9 {
                    True -> {
                        let v10 = spiral_wrap_signed(v3 + 1, 32)
                        v10
                    }
                    False -> {
                        v3
                    }
                }
            let v12 = spiral_wrap_signed(v1 - 1, 32)
            loop_20(v0, v12, v7, v11)
        }
        False -> {
            v3
        }
    }
}

pub fn run_23(v0: Int, v1: Uh1) -> Bool {
    case v1  {
        Uh1InputCons(v3, v4) -> {
            case v3  {
                Us0BitOne -> {
                    let v13 = v0 == 0
                    let v19 =
                        case v13 {
                            True -> {
                                3
                            }
                            False -> {
                                let v14 = v0 == 1
                                case v14 {
                                    True -> {
                                        3
                                    }
                                    False -> {
                                        let v15 = v0 == 2
                                        case v15 {
                                            True -> {
                                                3
                                            }
                                            False -> {
                                                4
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    run_23(v19, v4)
                }
                Us0BitZero -> {
                    let v5 = v0 == 0
                    let v11 =
                        case v5 {
                            True -> {
                                1
                            }
                            False -> {
                                let v6 = v0 == 1
                                case v6 {
                                    True -> {
                                        2
                                    }
                                    False -> {
                                        let v7 = v0 == 2
                                        case v7 {
                                            True -> {
                                                2
                                            }
                                            False -> {
                                                4
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    run_23(v11, v4)
                }
            }
        }
        Uh1InputEmpty -> {
            let v2 = v0 == 3
            v2
        }
    }
}

pub fn loop_22(v0: Int, v1: Int, v2: Int) -> Int {
    let v3 = v0 < v1
    case v3 {
        True -> {
            v2
        }
        False -> {
            let v4 = Uh1InputEmpty
            let v5 = zeros_input_14(v1, v4)
            let v6 = 0
            let v7 = run_23(v6, v5)
            let v9 =
                case v7 {
                    True -> {
                        let v8 = spiral_wrap_signed(v2 + 1, 32)
                        v8
                    }
                    False -> {
                        v2
                    }
                }
            let v10 = Us0BitOne
            let v11 = Uh1InputEmpty
            let v12 = Uh1InputCons(v10, v11)
            let v13 = zeros_input_14(v1, v12)
            let v14 = 0
            let v15 = run_23(v14, v13)
            let v17 =
                case v15 {
                    True -> {
                        let v16 = spiral_wrap_signed(v9 + 1, 32)
                        v16
                    }
                    False -> {
                        v9
                    }
                }
            let v18 = spiral_wrap_signed(v1 + 1, 32)
            loop_22(v0, v18, v17)
        }
    }
}

pub fn loop_24(v0: SpiralArray(Int), v1: Int) -> Nil {
    let v2 = v1 < 8192
    case v2 {
        True -> {
            spiral_array_set(v0, v1, 0)
            let v3 = spiral_wrap_signed(v1 + 1, 32)
            loop_24(v0, v3)
        }
        False -> {
        Nil
        }
    }
}

pub fn loop_25(v0: SpiralArray(Int), v1: Int) -> Nil {
    let v2 = v1 < 1
    case v2 {
        True -> {
            spiral_array_set(v0, v1, 0)
            let v3 = spiral_wrap_signed(v1 + 1, 32)
            loop_25(v0, v3)
        }
        False -> {
        Nil
        }
    }
}

pub fn probe_27(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int, v9: Int, v10: Int) -> Int {
    let v11 = spiral_array_get(v4, v10)
    let v12 = v11 == 0
    case v12 {
        True -> {
            let v13 = spiral_array_get(v6, 0)
            let v14 = v13 < 4096
            case v14 {
                True -> {
                    spiral_array_set(v0, v13, v7)
                    spiral_array_set(v1, v13, v8)
                    spiral_array_set(v2, v13, v9)
                    let v15 = v7 == 1
                    let v32 =
                        case v15 {
                            True -> {
                                True
                            }
                            False -> {
                                let v16 = v7 == 5
                                case v16 {
                                    True -> {
                                        True
                                    }
                                    False -> {
                                        let v17 = v7 == 3
                                        case v17 {
                                            True -> {
                                                let v18 = spiral_array_get(v3, v8)
                                                let v19 = v18 == 1
                                                case v19 {
                                                    True -> {
                                                        True
                                                    }
                                                    False -> {
                                                        let v20 = spiral_array_get(v3, v9)
                                                        let v21 = v20 == 1
                                                        v21
                                                    }
                                                }
                                            }
                                            False -> {
                                                let v23 = v7 == 4
                                                case v23 {
                                                    True -> {
                                                        let v24 = spiral_array_get(v3, v8)
                                                        let v25 = v24 == 1
                                                        case v25 {
                                                            True -> {
                                                                let v26 = spiral_array_get(v3, v9)
                                                                let v27 = v26 == 1
                                                                v27
                                                            }
                                                            False -> {
                                                                False
                                                            }
                                                        }
                                                    }
                                                    False -> {
                                                        False
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    let v33 =
                        case v32 {
                            True -> {
                                1
                            }
                            False -> {
                                0
                            }
                        }
                    spiral_array_set(v3, v13, v33)
                    let v34 = spiral_wrap_signed(v13 + 1, 32)
                    spiral_array_set(v4, v10, v34)
                    spiral_array_set(v6, 0, v34)
                    v13
                }
                False -> {
                    panic as "brzozowski-interned-store-full"
                }
            }
        }
        False -> {
            let v37 = spiral_wrap_signed(v11 - 1, 32)
            let v38 = spiral_array_get(v0, v37)
            let v39 = v38 == v7
            let v42 =
                case v39 {
                    True -> {
                        let v40 = spiral_array_get(v1, v37)
                        let v41 = v40 == v8
                        v41
                    }
                    False -> {
                        False
                    }
                }
            let v45 =
                case v42 {
                    True -> {
                        let v43 = spiral_array_get(v2, v37)
                        let v44 = v43 == v9
                        v44
                    }
                    False -> {
                        False
                    }
                }
            case v45 {
                True -> {
                    v37
                }
                False -> {
                    let v46 = spiral_wrap_signed(v10 + 1, 32)
                    let v47 = int.bitwise_and(v46, 8191)
                    probe_27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v47)
                }
            }
        }
    }
}

pub fn interned_node_26(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int, v9: Int) -> Int {
    let v10 = spiral_wrap_signed(v7 * 1024, 32)
    let v11 = spiral_wrap_signed(v10 + v8, 32)
    let v12 = spiral_wrap_signed(v11 * 4099, 32)
    let v13 = spiral_wrap_signed(v12 + v9, 32)
    let v14 = int.bitwise_and(v13, 8191)
    probe_27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14)
}

pub fn interned_alt_insert_30(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int) -> Int {
    let v9 = v8 == 0
    case v9 {
        True -> {
            v7
        }
        False -> {
            let v10 = spiral_array_get(v0, v8)
            let v11 = v10 == 3
            case v11 {
                True -> {
                    let v12 = spiral_array_get(v1, v8)
                    let v13 = v7 < v12
                    case v13 {
                        True -> {
                            let v14 = 3
                            interned_node_26(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8)
                        }
                        False -> {
                            let v16 = v7 == v12
                            case v16 {
                                True -> {
                                    v8
                                }
                                False -> {
                                    let v17 = 3
                                    let v18 = spiral_array_get(v2, v8)
                                    let v19 = interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v18)
                                    interned_node_26(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19)
                                }
                            }
                        }
                    }
                }
                False -> {
                    let v23 = v7 < v8
                    case v23 {
                        True -> {
                            let v24 = 3
                            interned_node_26(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8)
                        }
                        False -> {
                            let v26 = v7 == v8
                            case v26 {
                                True -> {
                                    v8
                                }
                                False -> {
                                    let v27 = 3
                                    interned_node_26(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7)
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

pub fn interned_make_alt_29(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int) -> Int {
    let v9 = v7 == 0
    case v9 {
        True -> {
            v8
        }
        False -> {
            let v10 = spiral_array_get(v0, v7)
            let v11 = v10 == 3
            case v11 {
                True -> {
                    let v12 = spiral_array_get(v2, v7)
                    let v13 = spiral_array_get(v1, v7)
                    let v14 = interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v13, v8)
                    interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v12, v14)
                }
                False -> {
                    interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v8)
                }
            }
        }
    }
}

pub fn interned_make_cat_31(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Int, v8: Int) -> Int {
    let v9 = v7 == 0
    case v9 {
        True -> {
            0
        }
        False -> {
            let v10 = v8 == 0
            case v10 {
                True -> {
                    0
                }
                False -> {
                    let v11 = v7 == 1
                    case v11 {
                        True -> {
                            v8
                        }
                        False -> {
                            let v12 = v8 == 1
                            case v12 {
                                True -> {
                                    v7
                                }
                                False -> {
                                    let v13 = spiral_array_get(v0, v7)
                                    let v14 = v13 == 5
                                    let v17 =
                                        case v14 {
                                            True -> {
                                                let v15 = spiral_array_get(v0, v8)
                                                let v16 = v15 == 5
                                                v16
                                            }
                                            False -> {
                                                False
                                            }
                                        }
                                    case v17 {
                                        True -> {
                                            let v18 = spiral_array_get(v1, v7)
                                            let v19 = spiral_array_get(v1, v8)
                                            let v20 = v18 == v19
                                            case v20 {
                                                True -> {
                                                    v7
                                                }
                                                False -> {
                                                    let v21 = 4
                                                    interned_node_26(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8)
                                                }
                                            }
                                        }
                                        False -> {
                                            let v24 = spiral_array_get(v0, v7)
                                            let v25 = v24 == 4
                                            case v25 {
                                                True -> {
                                                    let v26 = 4
                                                    let v27 = spiral_array_get(v1, v7)
                                                    let v28 = spiral_array_get(v2, v7)
                                                    let v29 = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v8)
                                                    interned_node_26(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29)
                                                }
                                                False -> {
                                                    let v31 = 4
                                                    interned_node_26(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8)
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

pub fn interned_of_regex_raw_28(v0: SpiralArray(Int), v1: SpiralArray(Int), v2: SpiralArray(Int), v3: SpiralArray(Int), v4: SpiralArray(Int), v5: SpiralArray(Int), v6: SpiralArray(Int), v7: Uh0) -> Int {
    case v7  {
        Uh0RegexAlt(v14, v15) -> {
            let v16 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v14)
            let v17 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v15)
            interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v16, v17)
        }
        Uh0RegexCat(v19, v20) -> {
            let v21 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v19)
            let v22 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v20)
            interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v21, v22)
        }
        Uh0RegexChar(v8) -> {
            let v9 = 2
            let v11 =
                case v8  {
                    Us0BitOne -> {
                        1
                    }
                    Us0BitZero -> {
                        0
                    }
                }
            let v12 = 0
            interned_node_26(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12)
        }
        Uh0RegexEmpty -> {
            0
        }
        Uh0RegexEpsilon -> {
            1
        }
        Uh0RegexStar(v24) -> {
            let v25 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v24)
            let v26 = spiral_array_get(v0, v25)
            let v27 = v26 < 2
            case v27 {
                True -> {
                    1
                }
                False -> {
                    let v28 = v26 == 5
                    case v28 {
                        True -> {
                            v25
                        }
                        False -> {
                            let v29 = 5
                            let v30 = 0
                            interned_node_26(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30)
                        }
                    }
                }
            }
        }
    }
}
