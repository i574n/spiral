import gleam/int
import main_types.{type Us0, type Uh0, type Uh1, type Us1, type Us2, Uh0RegexAlt, Uh0RegexCat, Uh0RegexChar, Uh0RegexEmpty, Uh0RegexEpsilon, Uh0RegexStar, Uh1InputCons, Uh1InputEmpty, Us0BitOne, Us0BitZero, Us1SymbolGreater, Us1SymbolLess, Us1SymbolSame, Us2NonNullable, Us2Nullable}

pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}


pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}


pub fn random_bit_input_1(v0: Int, v1: Int, v2: Uh1) -> #(Uh1, Int) {
    let v3 = 0 < v1
    case v3 {
        True -> {
            let v4 = spiral_wrap_unsigned(v0 * 1103515245, 64)
            let v5 = spiral_wrap_unsigned(v4 + 12345, 64)
            let v6 = int.bitwise_and(v5, 2147483647)
            let v7 = spiral_wrap_signed(v1 - 1, 32)
            let v8 = int.bitwise_shift_right(v6, 16)
            let v9 = int.bitwise_and(v8, 1)
            let v10 = v9 == 0
            let v13 =
                case v10 {
                    True -> {
                        let v11 = Us0BitZero
                        v11
                    }
                    False -> {
                        let v12 = Us0BitOne
                        v12
                    }
                }
            let v14 = Uh1InputCons(v13, v2)
            random_bit_input_1(v6, v7, v14)
        }
        False -> {
            #(v2, v0)
        }
    }
}

pub fn run_2(v0: Int, v1: Uh1) -> Bool {
    case v1  {
        Uh1InputCons(v4, v5) -> {
            let v6 = v0 == 0
            let v19 =
                case v6 {
                    True -> {
                        let v10 =
                            case v4  {
                                Us0BitOne -> {
                                    Us1SymbolGreater
                                }
                                Us0BitZero -> {
                                    Us1SymbolSame
                                }
                            }
                        let v11 =
                            case v10  {
                                Us1SymbolSame -> {
                                    True
                                }
                                _ -> {
                                    False
                                }
                            }
                        case v11 {
                            True -> {
                                1
                            }
                            False -> {
                                0
                            }
                        }
                    }
                    False -> {
                        let v16 =
                            case v4  {
                                Us0BitOne -> {
                                    Us1SymbolGreater
                                }
                                Us0BitZero -> {
                                    Us1SymbolSame
                                }
                            }
                        let v17 =
                            case v16  {
                                Us1SymbolSame -> {
                                    True
                                }
                                _ -> {
                                    False
                                }
                            }
                        case v17 {
                            True -> {
                                1
                            }
                            False -> {
                                0
                            }
                        }
                    }
                }
            run_2(v19, v5)
        }
        Uh1InputEmpty -> {
            let v2 = v0 == 0
            let v3 = v2 == False
            v3
        }
    }
}

pub fn regex_compare_8(v0: Uh0, v1: Uh0) -> Us1 {
    case v0  {
        Uh0RegexAlt(v53, v54) -> {
            case v1  {
                Uh0RegexAlt(v55, v56) -> {
                    let v57 = regex_compare_8(v53, v55)
                    case v57  {
                        Us1SymbolSame -> {
                            regex_compare_8(v54, v56)
                        }
                        _ -> {
                            v57
                        }
                    }
                }
                _ -> {
                    Us1SymbolGreater
                }
            }
        }
        Uh0RegexCat(v28, v29) -> {
            case v1  {
                Uh0RegexCat(v34, v35) -> {
                    let v36 = regex_compare_8(v28, v34)
                    case v36  {
                        Us1SymbolSame -> {
                            regex_compare_8(v29, v35)
                        }
                        _ -> {
                            v36
                        }
                    }
                }
                Uh0RegexChar(v32) -> {
                    Us1SymbolGreater
                }
                Uh0RegexEmpty -> {
                    Us1SymbolGreater
                }
                Uh0RegexEpsilon -> {
                    Us1SymbolGreater
                }
                _ -> {
                    Us1SymbolLess
                }
            }
        }
        Uh0RegexChar(v10) -> {
            case v1  {
                Uh0RegexChar(v13) -> {
                    case v10  {
                        Us0BitOne -> {
                            case v13  {
                                Us0BitOne -> {
                                    Us1SymbolSame
                                }
                                Us0BitZero -> {
                                    Us1SymbolGreater
                                }
                            }
                        }
                        Us0BitZero -> {
                            case v13  {
                                Us0BitOne -> {
                                    Us1SymbolLess
                                }
                                Us0BitZero -> {
                                    Us1SymbolSame
                                }
                            }
                        }
                    }
                }
                Uh0RegexEmpty -> {
                    Us1SymbolGreater
                }
                Uh0RegexEpsilon -> {
                    Us1SymbolGreater
                }
                _ -> {
                    Us1SymbolLess
                }
            }
        }
        Uh0RegexEmpty -> {
            case v1  {
                Uh0RegexEmpty -> {
                    Us1SymbolSame
                }
                _ -> {
                    Us1SymbolLess
                }
            }
        }
        Uh0RegexEpsilon -> {
            case v1  {
                Uh0RegexEmpty -> {
                    Us1SymbolGreater
                }
                Uh0RegexEpsilon -> {
                    Us1SymbolSame
                }
                _ -> {
                    Us1SymbolLess
                }
            }
        }
        Uh0RegexStar(v44) -> {
            case v1  {
                Uh0RegexAlt(v45, v46) -> {
                    Us1SymbolLess
                }
                Uh0RegexStar(v48) -> {
                    regex_compare_8(v44, v48)
                }
                _ -> {
                    Us1SymbolGreater
                }
            }
        }
    }
}

pub fn alt_insert_sorted_7(v0: Uh0, v1: Uh0) -> Uh0 {
    case v1  {
        Uh0RegexAlt(v2, v3) -> {
            let v4 = regex_compare_8(v0, v2)
            case v4  {
                Us1SymbolGreater -> {
                    let v6 = alt_insert_sorted_7(v0, v3)
                    Uh0RegexAlt(v2, v6)
                }
                Us1SymbolLess -> {
                    Uh0RegexAlt(v0, v1)
                }
                Us1SymbolSame -> {
                    v1
                }
            }
        }
        Uh0RegexEmpty -> {
            v0
        }
        _ -> {
            let v11 = regex_compare_8(v0, v1)
            case v11  {
                Us1SymbolGreater -> {
                    Uh0RegexAlt(v1, v0)
                }
                Us1SymbolLess -> {
                    Uh0RegexAlt(v0, v1)
                }
                Us1SymbolSame -> {
                    v1
                }
            }
        }
    }
}

pub fn make_alt_6(v0: Uh0, v1: Uh0) -> Uh0 {
    case v0  {
        Uh0RegexAlt(v2, v3) -> {
            let v4 = alt_insert_sorted_7(v2, v1)
            make_alt_6(v3, v4)
        }
        Uh0RegexEmpty -> {
            v1
        }
        _ -> {
            alt_insert_sorted_7(v0, v1)
        }
    }
}

pub fn regex_equal_10(v0: Uh0, v1: Uh0) -> Bool {
    case v0  {
        Uh0RegexAlt(v18, v19) -> {
            case v1  {
                Uh0RegexAlt(v20, v21) -> {
                    let v22 = regex_equal_10(v18, v20)
                    case v22 {
                        True -> {
                            regex_equal_10(v19, v21)
                        }
                        False -> {
                            False
                        }
                    }
                }
                _ -> {
                    False
                }
            }
        }
        Uh0RegexCat(v26, v27) -> {
            case v1  {
                Uh0RegexCat(v28, v29) -> {
                    let v30 = regex_equal_10(v26, v28)
                    case v30 {
                        True -> {
                            regex_equal_10(v27, v29)
                        }
                        False -> {
                            False
                        }
                    }
                }
                _ -> {
                    False
                }
            }
        }
        Uh0RegexChar(v4) -> {
            case v1  {
                Uh0RegexChar(v5) -> {
                    let v15 =
                        case v4  {
                            Us0BitOne -> {
                                case v5  {
                                    Us0BitOne -> {
                                        Us1SymbolSame
                                    }
                                    Us0BitZero -> {
                                        Us1SymbolGreater
                                    }
                                }
                            }
                            Us0BitZero -> {
                                case v5  {
                                    Us0BitOne -> {
                                        Us1SymbolLess
                                    }
                                    Us0BitZero -> {
                                        Us1SymbolSame
                                    }
                                }
                            }
                        }
                    case v15  {
                        Us1SymbolSame -> {
                            True
                        }
                        _ -> {
                            False
                        }
                    }
                }
                _ -> {
                    False
                }
            }
        }
        Uh0RegexEmpty -> {
            case v1  {
                Uh0RegexEmpty -> {
                    True
                }
                _ -> {
                    False
                }
            }
        }
        Uh0RegexEpsilon -> {
            case v1  {
                Uh0RegexEpsilon -> {
                    True
                }
                _ -> {
                    False
                }
            }
        }
        Uh0RegexStar(v34) -> {
            case v1  {
                Uh0RegexStar(v35) -> {
                    regex_equal_10(v34, v35)
                }
                _ -> {
                    False
                }
            }
        }
    }
}

pub fn make_cat_9(v0: Uh0, v1: Uh0) -> Uh0 {
    case v0  {
        Uh0RegexEmpty -> {
            Uh0RegexEmpty
        }
        _ -> {
            case v1  {
                Uh0RegexEmpty -> {
                    Uh0RegexEmpty
                }
                _ -> {
                    case v0  {
                        Uh0RegexEpsilon -> {
                            v1
                        }
                        _ -> {
                            case v1  {
                                Uh0RegexEpsilon -> {
                                    v0
                                }
                                _ -> {
                                    case v0  {
                                        Uh0RegexCat(v12, v13) -> {
                                            let v14 = make_cat_9(v13, v1)
                                            Uh0RegexCat(v12, v14)
                                        }
                                        Uh0RegexStar(v4) -> {
                                            case v1  {
                                                Uh0RegexStar(v5) -> {
                                                    let v6 = regex_equal_10(v4, v5)
                                                    case v6 {
                                                        True -> {
                                                            Uh0RegexStar(v4)
                                                        }
                                                        False -> {
                                                            Uh0RegexCat(v0, v1)
                                                        }
                                                    }
                                                }
                                                _ -> {
                                                    Uh0RegexCat(v0, v1)
                                                }
                                            }
                                        }
                                        _ -> {
                                            Uh0RegexCat(v0, v1)
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

pub fn make_star_11(v0: Uh0) -> Uh0 {
    case v0  {
        Uh0RegexEmpty -> {
            Uh0RegexEpsilon
        }
        Uh0RegexEpsilon -> {
            Uh0RegexEpsilon
        }
        Uh0RegexStar(v3) -> {
            Uh0RegexStar(v3)
        }
        _ -> {
            Uh0RegexStar(v0)
        }
    }
}

pub fn normalize_5(v0: Uh0) -> Uh0 {
    case v0  {
        Uh0RegexAlt(v5, v6) -> {
            let v7 = normalize_5(v5)
            let v8 = normalize_5(v6)
            make_alt_6(v7, v8)
        }
        Uh0RegexCat(v10, v11) -> {
            let v12 = normalize_5(v10)
            let v13 = normalize_5(v11)
            make_cat_9(v12, v13)
        }
        Uh0RegexChar(v3) -> {
            Uh0RegexChar(v3)
        }
        Uh0RegexEmpty -> {
            Uh0RegexEmpty
        }
        Uh0RegexEpsilon -> {
            Uh0RegexEpsilon
        }
        Uh0RegexStar(v15) -> {
            let v16 = normalize_5(v15)
            make_star_11(v16)
        }
    }
}

pub fn nullable_13(v0: Uh0) -> Us2 {
    case v0  {
        Uh0RegexAlt(v5, v6) -> {
            let v7 = nullable_13(v5)
            let v8 = nullable_13(v6)
            case v7  {
                Us2Nullable -> {
                    Us2Nullable
                }
                _ -> {
                    case v8  {
                        Us2Nullable -> {
                            Us2Nullable
                        }
                        _ -> {
                            case v7  {
                                Us2NonNullable -> {
                                    case v8  {
                                        Us2NonNullable -> {
                                            Us2NonNullable
                                        }
                                        _ -> panic as "spiral: union case ruled out by partial evaluation"
                                    }
                                }
                                _ -> panic as "spiral: union case ruled out by partial evaluation"
                            }
                        }
                    }
                }
            }
        }
        Uh0RegexCat(v16, v17) -> {
            let v18 = nullable_13(v16)
            let v19 = nullable_13(v17)
            case v18  {
                Us2Nullable -> {
                    case v19  {
                        Us2Nullable -> {
                            Us2Nullable
                        }
                        _ -> {
                            Us2NonNullable
                        }
                    }
                }
                _ -> {
                    Us2NonNullable
                }
            }
        }
        Uh0RegexChar(v3) -> {
            Us2NonNullable
        }
        Uh0RegexEmpty -> {
            Us2NonNullable
        }
        Uh0RegexEpsilon -> {
            Us2Nullable
        }
        Uh0RegexStar(v25) -> {
            Us2Nullable
        }
    }
}

pub fn derivative_12(v0: Uh0, v1: Us0) -> Uh0 {
    case v0  {
        Uh0RegexAlt(v19, v20) -> {
            let v21 = derivative_12(v19, v1)
            let v22 = derivative_12(v20, v1)
            make_alt_6(v21, v22)
        }
        Uh0RegexCat(v24, v25) -> {
            let v26 = nullable_13(v24)
            case v26  {
                Us2NonNullable -> {
                    let v31 = derivative_12(v24, v1)
                    make_cat_9(v31, v25)
                }
                Us2Nullable -> {
                    let v27 = derivative_12(v24, v1)
                    let v28 = make_cat_9(v27, v25)
                    let v29 = derivative_12(v25, v1)
                    make_alt_6(v28, v29)
                }
            }
        }
        Uh0RegexChar(v4) -> {
            let v14 =
                case v4  {
                    Us0BitOne -> {
                        case v1  {
                            Us0BitOne -> {
                                Us1SymbolSame
                            }
                            Us0BitZero -> {
                                Us1SymbolGreater
                            }
                        }
                    }
                    Us0BitZero -> {
                        case v1  {
                            Us0BitOne -> {
                                Us1SymbolLess
                            }
                            Us0BitZero -> {
                                Us1SymbolSame
                            }
                        }
                    }
                }
            let v15 =
                case v14  {
                    Us1SymbolSame -> {
                        True
                    }
                    _ -> {
                        False
                    }
                }
            case v15 {
                True -> {
                    Uh0RegexEpsilon
                }
                False -> {
                    Uh0RegexEmpty
                }
            }
        }
        Uh0RegexEmpty -> {
            Uh0RegexEmpty
        }
        Uh0RegexEpsilon -> {
            Uh0RegexEmpty
        }
        Uh0RegexStar(v35) -> {
            let v36 = derivative_12(v35, v1)
            let v37 = make_star_11(v35)
            make_cat_9(v36, v37)
        }
    }
}

pub fn canonical_derivative_4(v0: Uh0, v1: Us0) -> Uh0 {
    let v2 = normalize_5(v0)
    let v3 = derivative_12(v2, v1)
    normalize_5(v3)
}

pub fn accepts_3(v0: Uh0, v1: Uh1) -> Bool {
    case v1  {
        Uh1InputCons(v6, v7) -> {
            let v8 = canonical_derivative_4(v0, v6)
            accepts_3(v8, v7)
        }
        Uh1InputEmpty -> {
            let v2 = normalize_5(v0)
            let v3 = nullable_13(v2)
            case v3  {
                Us2NonNullable -> {
                    False
                }
                Us2Nullable -> {
                    True
                }
            }
        }
    }
}

pub fn loop_0(v0: Int, v1: Uh0, v2: Int, v3: Int, v4: Int) -> Int {
    let v5 = 0 < v2
    case v5 {
        True -> {
            let v6 = Uh1InputEmpty
            let #(v7, v8) = random_bit_input_1(v3, v0, v6)
            let v9 = 0
            let v10 = run_2(v9, v7)
            let v11 = accepts_3(v1, v7)
            let v13 =
                case v10 {
                    True -> {
                        v11
                    }
                    False -> {
                        let v12 = False == v11
                        v12
                    }
                }
            case v13 {
                True -> {
                    let v14 = spiral_wrap_signed(v2 - 1, 32)
                    let v16 =
                        case v10 {
                            True -> {
                                let v15 = spiral_wrap_signed(v4 + 1, 32)
                                v15
                            }
                            False -> {
                                v4
                            }
                        }
                    loop_0(v0, v1, v14, v8, v16)
                }
                False -> {
                    panic as "brzozowski-compiled-core-disagrees-on-random-input"
                }
            }
        }
        False -> {
            v4
        }
    }
}

pub fn zeros_input_15(v0: Int, v1: Uh1) -> Uh1 {
    let v2 = 0 < v0
    case v2 {
        True -> {
            let v3 = spiral_wrap_signed(v0 - 1, 32)
            let v4 = Us0BitZero
            let v5 = Uh1InputCons(v4, v1)
            zeros_input_15(v3, v5)
        }
        False -> {
            v1
        }
    }
}

pub fn run_16(v0: Int, v1: Uh1) -> Bool {
    case v1  {
        Uh1InputCons(v5, v6) -> {
            let v7 = v0 == 0
            let v26 =
                case v7 {
                    True -> {
                        1
                    }
                    False -> {
                        let v13 = v0 == 1
                        case v13 {
                            True -> {
                                1
                            }
                            False -> {
                                let v22 =
                                    case v5  {
                                        Us0BitOne -> {
                                            Us1SymbolGreater
                                        }
                                        Us0BitZero -> {
                                            Us1SymbolSame
                                        }
                                    }
                                let v23 =
                                    case v22  {
                                        Us1SymbolSame -> {
                                            True
                                        }
                                        _ -> {
                                            False
                                        }
                                    }
                                case v23 {
                                    True -> {
                                        2
                                    }
                                    False -> {
                                        0
                                    }
                                }
                            }
                        }
                    }
                }
            run_16(v26, v6)
        }
        Uh1InputEmpty -> {
            let v2 = v0 == 0
            case v2 {
                True -> {
                    True
                }
                False -> {
                    False
                }
            }
        }
    }
}

pub fn loop_14(v0: Int, v1: Uh0, v2: Int, v3: Int) -> Int {
    let v4 = v0 < v2
    case v4 {
        True -> {
            v3
        }
        False -> {
            let v5 = Uh1InputEmpty
            let v6 = zeros_input_15(v2, v5)
            let v7 = 2
            let v8 = run_16(v7, v6)
            let v9 = accepts_3(v1, v6)
            let v11 =
                case v8 {
                    True -> {
                        v9
                    }
                    False -> {
                        let v10 = False == v9
                        v10
                    }
                }
            let v15 =
                case v11 {
                    True -> {
                        case v8 {
                            True -> {
                                let v12 = spiral_wrap_signed(v3 + 1, 32)
                                v12
                            }
                            False -> {
                                v3
                            }
                        }
                    }
                    False -> {
                        panic as "brzozowski-compiled-core-disagrees-on-zero-run"
                    }
                }
            let v16 = Us0BitOne
            let v17 = Uh1InputEmpty
            let v18 = Uh1InputCons(v16, v17)
            let v19 = zeros_input_15(v2, v18)
            let v20 = 2
            let v21 = run_16(v20, v19)
            let v22 = accepts_3(v1, v19)
            let v24 =
                case v21 {
                    True -> {
                        v22
                    }
                    False -> {
                        let v23 = False == v22
                        v23
                    }
                }
            let v28 =
                case v24 {
                    True -> {
                        case v21 {
                            True -> {
                                let v25 = spiral_wrap_signed(v15 + 1, 32)
                                v25
                            }
                            False -> {
                                v15
                            }
                        }
                    }
                    False -> {
                        panic as "brzozowski-compiled-core-disagrees-on-zero-run"
                    }
                }
            let v29 = spiral_wrap_signed(v2 + 1, 32)
            loop_14(v0, v1, v29, v28)
        }
    }
}
