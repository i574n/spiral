import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Us0 {
    Us0BitZero
    Us0BitOne
}
pub type Uh0 {
    Uh0RegexEmpty
    Uh0RegexEpsilon
    Uh0RegexChar(Us0)
    Uh0RegexAlt(Uh0, Uh0)
    Uh0RegexCat(Uh0, Uh0)
    Uh0RegexStar(Uh0)
}
pub type Uh1 {
    Uh1InputEmpty
    Uh1InputCons(Us0, Uh1)
}
pub type Us1 {
    Us1SymbolLess
    Us1SymbolSame
    Us1SymbolGreater
}
pub type Us2 {
    Us2Nullable
    Us2NonNullable
}
pub type Us3 {
    Us3TriA
    Us3TriB
    Us3TriC
}
pub type Uh2 {
    Uh2RegexEmpty
    Uh2RegexEpsilon
    Uh2RegexChar(Us3)
    Uh2RegexAlt(Uh2, Uh2)
    Uh2RegexCat(Uh2, Uh2)
    Uh2RegexStar(Uh2)
}
pub type Uh3 {
    Uh3InputEmpty
    Uh3InputCons(Us3, Uh3)
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
pub fn run_17(v0: Int, v1: Uh3) -> Bool {
    case v1  {
        Uh3InputCons(v5, v6) -> {
            let v7 = v0 == 0
            let v47 =
                case v7 {
                    True -> {
                        let v10 =
                            case v5  {
                                Us3TriA -> {
                                    Us1SymbolSame
                                }
                                _ -> {
                                    Us1SymbolGreater
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
                                0
                            }
                            False -> {
                                let v17 =
                                    case v5  {
                                        Us3TriA -> {
                                            Us1SymbolLess
                                        }
                                        Us3TriB -> {
                                            Us1SymbolSame
                                        }
                                        Us3TriC -> {
                                            Us1SymbolGreater
                                        }
                                    }
                                let v18 =
                                    case v17  {
                                        Us1SymbolSame -> {
                                            True
                                        }
                                        _ -> {
                                            False
                                        }
                                    }
                                case v18 {
                                    True -> {
                                        0
                                    }
                                    False -> {
                                        1
                                    }
                                }
                            }
                        }
                    }
                    False -> {
                        let v21 = v0 == 1
                        case v21 {
                            True -> {
                                let v24 =
                                    case v5  {
                                        Us3TriA -> {
                                            Us1SymbolSame
                                        }
                                        _ -> {
                                            Us1SymbolGreater
                                        }
                                    }
                                let v25 =
                                    case v24  {
                                        Us1SymbolSame -> {
                                            True
                                        }
                                        _ -> {
                                            False
                                        }
                                    }
                                case v25 {
                                    True -> {
                                        2
                                    }
                                    False -> {
                                        2
                                    }
                                }
                            }
                            False -> {
                                let v36 =
                                    case v5  {
                                        Us3TriA -> {
                                            Us1SymbolSame
                                        }
                                        _ -> {
                                            Us1SymbolGreater
                                        }
                                    }
                                let v37 =
                                    case v36  {
                                        Us1SymbolSame -> {
                                            True
                                        }
                                        _ -> {
                                            False
                                        }
                                    }
                                case v37 {
                                    True -> {
                                        2
                                    }
                                    False -> {
                                        2
                                    }
                                }
                            }
                        }
                    }
                }
            run_17(v47, v6)
        }
        Uh3InputEmpty -> {
            let v2 = v0 == 0
            case v2 {
                True -> {
                    False
                }
                False -> {
                    let v3 = v0 == 1
                    v3
                }
            }
        }
    }
}
pub fn regex_compare_23(v0: Uh2, v1: Uh2) -> Us1 {
    case v0  {
        Uh2RegexAlt(v59, v60) -> {
            case v1  {
                Uh2RegexAlt(v61, v62) -> {
                    let v63 = regex_compare_23(v59, v61)
                    case v63  {
                        Us1SymbolSame -> {
                            regex_compare_23(v60, v62)
                        }
                        _ -> {
                            v63
                        }
                    }
                }
                _ -> {
                    Us1SymbolGreater
                }
            }
        }
        Uh2RegexCat(v34, v35) -> {
            case v1  {
                Uh2RegexCat(v40, v41) -> {
                    let v42 = regex_compare_23(v34, v40)
                    case v42  {
                        Us1SymbolSame -> {
                            regex_compare_23(v35, v41)
                        }
                        _ -> {
                            v42
                        }
                    }
                }
                Uh2RegexChar(v38) -> {
                    Us1SymbolGreater
                }
                Uh2RegexEmpty -> {
                    Us1SymbolGreater
                }
                Uh2RegexEpsilon -> {
                    Us1SymbolGreater
                }
                _ -> {
                    Us1SymbolLess
                }
            }
        }
        Uh2RegexChar(v10) -> {
            case v1  {
                Uh2RegexChar(v13) -> {
                    case v10  {
                        Us3TriA -> {
                            case v13  {
                                Us3TriA -> {
                                    Us1SymbolSame
                                }
                                _ -> {
                                    Us1SymbolLess
                                }
                            }
                        }
                        _ -> {
                            case v13  {
                                Us3TriA -> {
                                    Us1SymbolGreater
                                }
                                _ -> {
                                    case v10  {
                                        Us3TriB -> {
                                            case v13  {
                                                Us3TriB -> {
                                                    Us1SymbolSame
                                                }
                                                Us3TriC -> {
                                                    Us1SymbolLess
                                                }
                                                _ -> panic as "spiral: union case ruled out by partial evaluation"
                                            }
                                        }
                                        Us3TriC -> {
                                            case v13  {
                                                Us3TriB -> {
                                                    Us1SymbolGreater
                                                }
                                                Us3TriC -> {
                                                    Us1SymbolSame
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
                Uh2RegexEmpty -> {
                    Us1SymbolGreater
                }
                Uh2RegexEpsilon -> {
                    Us1SymbolGreater
                }
                _ -> {
                    Us1SymbolLess
                }
            }
        }
        Uh2RegexEmpty -> {
            case v1  {
                Uh2RegexEmpty -> {
                    Us1SymbolSame
                }
                _ -> {
                    Us1SymbolLess
                }
            }
        }
        Uh2RegexEpsilon -> {
            case v1  {
                Uh2RegexEmpty -> {
                    Us1SymbolGreater
                }
                Uh2RegexEpsilon -> {
                    Us1SymbolSame
                }
                _ -> {
                    Us1SymbolLess
                }
            }
        }
        Uh2RegexStar(v50) -> {
            case v1  {
                Uh2RegexAlt(v51, v52) -> {
                    Us1SymbolLess
                }
                Uh2RegexStar(v54) -> {
                    regex_compare_23(v50, v54)
                }
                _ -> {
                    Us1SymbolGreater
                }
            }
        }
    }
}
pub fn alt_insert_sorted_22(v0: Uh2, v1: Uh2) -> Uh2 {
    case v1  {
        Uh2RegexAlt(v2, v3) -> {
            let v4 = regex_compare_23(v0, v2)
            case v4  {
                Us1SymbolGreater -> {
                    let v6 = alt_insert_sorted_22(v0, v3)
                    Uh2RegexAlt(v2, v6)
                }
                Us1SymbolLess -> {
                    Uh2RegexAlt(v0, v1)
                }
                Us1SymbolSame -> {
                    v1
                }
            }
        }
        Uh2RegexEmpty -> {
            v0
        }
        _ -> {
            let v11 = regex_compare_23(v0, v1)
            case v11  {
                Us1SymbolGreater -> {
                    Uh2RegexAlt(v1, v0)
                }
                Us1SymbolLess -> {
                    Uh2RegexAlt(v0, v1)
                }
                Us1SymbolSame -> {
                    v1
                }
            }
        }
    }
}
pub fn make_alt_21(v0: Uh2, v1: Uh2) -> Uh2 {
    case v0  {
        Uh2RegexAlt(v2, v3) -> {
            let v4 = alt_insert_sorted_22(v2, v1)
            make_alt_21(v3, v4)
        }
        Uh2RegexEmpty -> {
            v1
        }
        _ -> {
            alt_insert_sorted_22(v0, v1)
        }
    }
}
pub fn regex_equal_25(v0: Uh2, v1: Uh2) -> Bool {
    case v0  {
        Uh2RegexAlt(v24, v25) -> {
            case v1  {
                Uh2RegexAlt(v26, v27) -> {
                    let v28 = regex_equal_25(v24, v26)
                    case v28 {
                        True -> {
                            regex_equal_25(v25, v27)
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
        Uh2RegexCat(v32, v33) -> {
            case v1  {
                Uh2RegexCat(v34, v35) -> {
                    let v36 = regex_equal_25(v32, v34)
                    case v36 {
                        True -> {
                            regex_equal_25(v33, v35)
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
        Uh2RegexChar(v4) -> {
            case v1  {
                Uh2RegexChar(v5) -> {
                    let v21 =
                        case v4  {
                            Us3TriA -> {
                                case v5  {
                                    Us3TriA -> {
                                        Us1SymbolSame
                                    }
                                    _ -> {
                                        Us1SymbolLess
                                    }
                                }
                            }
                            _ -> {
                                case v5  {
                                    Us3TriA -> {
                                        Us1SymbolGreater
                                    }
                                    _ -> {
                                        case v4  {
                                            Us3TriB -> {
                                                case v5  {
                                                    Us3TriB -> {
                                                        Us1SymbolSame
                                                    }
                                                    Us3TriC -> {
                                                        Us1SymbolLess
                                                    }
                                                    _ -> panic as "spiral: union case ruled out by partial evaluation"
                                                }
                                            }
                                            Us3TriC -> {
                                                case v5  {
                                                    Us3TriB -> {
                                                        Us1SymbolGreater
                                                    }
                                                    Us3TriC -> {
                                                        Us1SymbolSame
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
                    case v21  {
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
        Uh2RegexEmpty -> {
            case v1  {
                Uh2RegexEmpty -> {
                    True
                }
                _ -> {
                    False
                }
            }
        }
        Uh2RegexEpsilon -> {
            case v1  {
                Uh2RegexEpsilon -> {
                    True
                }
                _ -> {
                    False
                }
            }
        }
        Uh2RegexStar(v40) -> {
            case v1  {
                Uh2RegexStar(v41) -> {
                    regex_equal_25(v40, v41)
                }
                _ -> {
                    False
                }
            }
        }
    }
}
pub fn make_cat_24(v0: Uh2, v1: Uh2) -> Uh2 {
    case v0  {
        Uh2RegexEmpty -> {
            Uh2RegexEmpty
        }
        _ -> {
            case v1  {
                Uh2RegexEmpty -> {
                    Uh2RegexEmpty
                }
                _ -> {
                    case v0  {
                        Uh2RegexEpsilon -> {
                            v1
                        }
                        _ -> {
                            case v1  {
                                Uh2RegexEpsilon -> {
                                    v0
                                }
                                _ -> {
                                    case v0  {
                                        Uh2RegexCat(v12, v13) -> {
                                            let v14 = make_cat_24(v13, v1)
                                            Uh2RegexCat(v12, v14)
                                        }
                                        Uh2RegexStar(v4) -> {
                                            case v1  {
                                                Uh2RegexStar(v5) -> {
                                                    let v6 = regex_equal_25(v4, v5)
                                                    case v6 {
                                                        True -> {
                                                            Uh2RegexStar(v4)
                                                        }
                                                        False -> {
                                                            Uh2RegexCat(v0, v1)
                                                        }
                                                    }
                                                }
                                                _ -> {
                                                    Uh2RegexCat(v0, v1)
                                                }
                                            }
                                        }
                                        _ -> {
                                            Uh2RegexCat(v0, v1)
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
pub fn make_star_26(v0: Uh2) -> Uh2 {
    case v0  {
        Uh2RegexEmpty -> {
            Uh2RegexEpsilon
        }
        Uh2RegexEpsilon -> {
            Uh2RegexEpsilon
        }
        Uh2RegexStar(v3) -> {
            Uh2RegexStar(v3)
        }
        _ -> {
            Uh2RegexStar(v0)
        }
    }
}
pub fn normalize_20(v0: Uh2) -> Uh2 {
    case v0  {
        Uh2RegexAlt(v5, v6) -> {
            let v7 = normalize_20(v5)
            let v8 = normalize_20(v6)
            make_alt_21(v7, v8)
        }
        Uh2RegexCat(v10, v11) -> {
            let v12 = normalize_20(v10)
            let v13 = normalize_20(v11)
            make_cat_24(v12, v13)
        }
        Uh2RegexChar(v3) -> {
            Uh2RegexChar(v3)
        }
        Uh2RegexEmpty -> {
            Uh2RegexEmpty
        }
        Uh2RegexEpsilon -> {
            Uh2RegexEpsilon
        }
        Uh2RegexStar(v15) -> {
            let v16 = normalize_20(v15)
            make_star_26(v16)
        }
    }
}
pub fn nullable_28(v0: Uh2) -> Us2 {
    case v0  {
        Uh2RegexAlt(v5, v6) -> {
            let v7 = nullable_28(v5)
            let v8 = nullable_28(v6)
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
        Uh2RegexCat(v16, v17) -> {
            let v18 = nullable_28(v16)
            let v19 = nullable_28(v17)
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
        Uh2RegexChar(v3) -> {
            Us2NonNullable
        }
        Uh2RegexEmpty -> {
            Us2NonNullable
        }
        Uh2RegexEpsilon -> {
            Us2Nullable
        }
        Uh2RegexStar(v25) -> {
            Us2Nullable
        }
    }
}
pub fn derivative_27(v0: Uh2, v1: Us3) -> Uh2 {
    case v0  {
        Uh2RegexAlt(v25, v26) -> {
            let v27 = derivative_27(v25, v1)
            let v28 = derivative_27(v26, v1)
            make_alt_21(v27, v28)
        }
        Uh2RegexCat(v30, v31) -> {
            let v32 = nullable_28(v30)
            case v32  {
                Us2NonNullable -> {
                    let v37 = derivative_27(v30, v1)
                    make_cat_24(v37, v31)
                }
                Us2Nullable -> {
                    let v33 = derivative_27(v30, v1)
                    let v34 = make_cat_24(v33, v31)
                    let v35 = derivative_27(v31, v1)
                    make_alt_21(v34, v35)
                }
            }
        }
        Uh2RegexChar(v4) -> {
            let v20 =
                case v4  {
                    Us3TriA -> {
                        case v1  {
                            Us3TriA -> {
                                Us1SymbolSame
                            }
                            _ -> {
                                Us1SymbolLess
                            }
                        }
                    }
                    _ -> {
                        case v1  {
                            Us3TriA -> {
                                Us1SymbolGreater
                            }
                            _ -> {
                                case v4  {
                                    Us3TriB -> {
                                        case v1  {
                                            Us3TriB -> {
                                                Us1SymbolSame
                                            }
                                            Us3TriC -> {
                                                Us1SymbolLess
                                            }
                                            _ -> panic as "spiral: union case ruled out by partial evaluation"
                                        }
                                    }
                                    Us3TriC -> {
                                        case v1  {
                                            Us3TriB -> {
                                                Us1SymbolGreater
                                            }
                                            Us3TriC -> {
                                                Us1SymbolSame
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
            let v21 =
                case v20  {
                    Us1SymbolSame -> {
                        True
                    }
                    _ -> {
                        False
                    }
                }
            case v21 {
                True -> {
                    Uh2RegexEpsilon
                }
                False -> {
                    Uh2RegexEmpty
                }
            }
        }
        Uh2RegexEmpty -> {
            Uh2RegexEmpty
        }
        Uh2RegexEpsilon -> {
            Uh2RegexEmpty
        }
        Uh2RegexStar(v41) -> {
            let v42 = derivative_27(v41, v1)
            let v43 = make_star_26(v41)
            make_cat_24(v42, v43)
        }
    }
}
pub fn canonical_derivative_19(v0: Uh2, v1: Us3) -> Uh2 {
    let v2 = normalize_20(v0)
    let v3 = derivative_27(v2, v1)
    normalize_20(v3)
}
pub fn accepts_18(v0: Uh2, v1: Uh3) -> Bool {
    case v1  {
        Uh3InputCons(v6, v7) -> {
            let v8 = canonical_derivative_19(v0, v6)
            accepts_18(v8, v7)
        }
        Uh3InputEmpty -> {
            let v2 = normalize_20(v0)
            let v3 = nullable_28(v2)
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
pub fn main() {
    let v0 = 200
    let v1 = 32
    let v2 = 16
    let v3 = Us0BitZero
    let v4 = Uh0RegexChar(v3)
    let v5 = Us0BitOne
    let v6 = Uh0RegexChar(v5)
    let v7 = Uh0RegexAlt(v4, v6)
    let v8 = Uh0RegexStar(v7)
    let v9 = Us0BitZero
    let v10 = Uh0RegexChar(v9)
    let v11 = Uh0RegexCat(v8, v10)
    let v12 = 1
    let v13 = 0
    let v14 = loop_0(v1, v11, v0, v12, v13)
    let v15 = v14 == 93
    case v15 {
        True -> {
            Nil
        }
        False -> {
            panic as "brzozowski-compiled-ends-with-zero-count"
        }
    }
    let v16 = Us0BitZero
    let v17 = Uh0RegexChar(v16)
    let v18 = Us0BitZero
    let v19 = Uh0RegexChar(v18)
    let v20 = Us0BitZero
    let v21 = Uh0RegexChar(v20)
    let v22 = Uh0RegexCat(v19, v21)
    let v23 = Uh0RegexAlt(v17, v22)
    let v24 = Uh0RegexStar(v23)
    let v25 = Us0BitOne
    let v26 = Uh0RegexChar(v25)
    let v27 = Uh0RegexCat(v24, v26)
    let v28 = 1
    let v29 = 0
    let v30 = loop_14(v2, v27, v28, v29)
    let v31 = v30 == 16
    case v31 {
        True -> {
            Nil
        }
        False -> {
            panic as "brzozowski-compiled-zero-runs-count"
        }
    }
    let v32 = Us3TriA
    let v33 = Uh2RegexChar(v32)
    let v34 = Us3TriB
    let v35 = Uh2RegexChar(v34)
    let v36 = Uh2RegexAlt(v33, v35)
    let v37 = Uh2RegexStar(v36)
    let v38 = Us3TriC
    let v39 = Uh2RegexChar(v38)
    let v40 = Uh2RegexCat(v37, v39)
    let v41 = Us3TriA
    let v42 = Us3TriB
    let v43 = Us3TriA
    let v44 = Us3TriC
    let v45 = Uh3InputEmpty
    let v46 = Uh3InputCons(v44, v45)
    let v47 = Uh3InputCons(v43, v46)
    let v48 = Uh3InputCons(v42, v47)
    let v49 = Uh3InputCons(v41, v48)
    let v50 = Us3TriA
    let v51 = Us3TriB
    let v52 = Us3TriA
    let v53 = Us3TriB
    let v54 = Uh3InputEmpty
    let v55 = Uh3InputCons(v53, v54)
    let v56 = Uh3InputCons(v52, v55)
    let v57 = Uh3InputCons(v51, v56)
    let v58 = Uh3InputCons(v50, v57)
    let v59 = 0
    let v60 = run_17(v59, v49)
    let v62 =
        case v60 {
            True -> {
                accepts_18(v40, v49)
            }
            False -> {
                False
            }
        }
    let v68 =
        case v62 {
            True -> {
                let v63 = 0
                let v64 = run_17(v63, v58)
                case v64 {
                    True -> {
                        False
                    }
                    False -> {
                        let v65 = accepts_18(v40, v58)
                        let v66 = v65 == False
                        v66
                    }
                }
            }
            False -> {
                False
            }
        }
    case v68 {
        True -> {
            0
        }
        False -> {
            panic as "brzozowski-compiled-ternary-disagrees"
        }
    }
}
