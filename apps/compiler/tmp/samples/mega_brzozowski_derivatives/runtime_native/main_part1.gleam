import main_types.{type Us0, type Uh0, type Uh2, type Us2, type Us3, type Uh3, Uh0InputCons, Uh0InputEmpty, Uh2RegexAlt, Uh2RegexCat, Uh2RegexChar, Uh2RegexEmpty, Uh2RegexEpsilon, Uh2RegexStar, Uh3RegexAlt, Uh3RegexCat, Uh3RegexChar, Uh3RegexEmpty, Uh3RegexEpsilon, Uh3RegexStar, Us0BitOne, Us0BitZero, Us1TriA, Us1TriB, Us1TriC, Us2SymbolGreater, Us2SymbolLess, Us2SymbolSame, Us3NonNullable, Us3Nullable}

pub fn regex_compare_5(v0: Uh2, v1: Uh2) -> Us2 {
    case v0  {
        Uh2RegexAlt(v53, v54) -> {
            case v1  {
                Uh2RegexAlt(v55, v56) -> {
                    let v57 = regex_compare_5(v53, v55)
                    case v57  {
                        Us2SymbolSame -> {
                            regex_compare_5(v54, v56)
                        }
                        _ -> {
                            v57
                        }
                    }
                }
                _ -> {
                    Us2SymbolGreater
                }
            }
        }
        Uh2RegexCat(v28, v29) -> {
            case v1  {
                Uh2RegexCat(v34, v35) -> {
                    let v36 = regex_compare_5(v28, v34)
                    case v36  {
                        Us2SymbolSame -> {
                            regex_compare_5(v29, v35)
                        }
                        _ -> {
                            v36
                        }
                    }
                }
                Uh2RegexChar(v32) -> {
                    Us2SymbolGreater
                }
                Uh2RegexEmpty -> {
                    Us2SymbolGreater
                }
                Uh2RegexEpsilon -> {
                    Us2SymbolGreater
                }
                _ -> {
                    Us2SymbolLess
                }
            }
        }
        Uh2RegexChar(v10) -> {
            case v1  {
                Uh2RegexChar(v13) -> {
                    case v10  {
                        Us0BitOne -> {
                            case v13  {
                                Us0BitOne -> {
                                    Us2SymbolSame
                                }
                                Us0BitZero -> {
                                    Us2SymbolGreater
                                }
                            }
                        }
                        Us0BitZero -> {
                            case v13  {
                                Us0BitOne -> {
                                    Us2SymbolLess
                                }
                                Us0BitZero -> {
                                    Us2SymbolSame
                                }
                            }
                        }
                    }
                }
                Uh2RegexEmpty -> {
                    Us2SymbolGreater
                }
                Uh2RegexEpsilon -> {
                    Us2SymbolGreater
                }
                _ -> {
                    Us2SymbolLess
                }
            }
        }
        Uh2RegexEmpty -> {
            case v1  {
                Uh2RegexEmpty -> {
                    Us2SymbolSame
                }
                _ -> {
                    Us2SymbolLess
                }
            }
        }
        Uh2RegexEpsilon -> {
            case v1  {
                Uh2RegexEmpty -> {
                    Us2SymbolGreater
                }
                Uh2RegexEpsilon -> {
                    Us2SymbolSame
                }
                _ -> {
                    Us2SymbolLess
                }
            }
        }
        Uh2RegexStar(v44) -> {
            case v1  {
                Uh2RegexAlt(v45, v46) -> {
                    Us2SymbolLess
                }
                Uh2RegexStar(v48) -> {
                    regex_compare_5(v44, v48)
                }
                _ -> {
                    Us2SymbolGreater
                }
            }
        }
    }
}

pub fn alt_insert_sorted_4(v0: Uh2, v1: Uh2) -> Uh2 {
    case v1  {
        Uh2RegexAlt(v2, v3) -> {
            let v4 = regex_compare_5(v0, v2)
            case v4  {
                Us2SymbolGreater -> {
                    let v6 = alt_insert_sorted_4(v0, v3)
                    Uh2RegexAlt(v2, v6)
                }
                Us2SymbolLess -> {
                    Uh2RegexAlt(v0, v1)
                }
                Us2SymbolSame -> {
                    v1
                }
            }
        }
        Uh2RegexEmpty -> {
            v0
        }
        _ -> {
            let v11 = regex_compare_5(v0, v1)
            case v11  {
                Us2SymbolGreater -> {
                    Uh2RegexAlt(v1, v0)
                }
                Us2SymbolLess -> {
                    Uh2RegexAlt(v0, v1)
                }
                Us2SymbolSame -> {
                    v1
                }
            }
        }
    }
}

pub fn make_alt_3(v0: Uh2, v1: Uh2) -> Uh2 {
    case v0  {
        Uh2RegexAlt(v2, v3) -> {
            let v4 = alt_insert_sorted_4(v2, v1)
            make_alt_3(v3, v4)
        }
        Uh2RegexEmpty -> {
            v1
        }
        _ -> {
            alt_insert_sorted_4(v0, v1)
        }
    }
}

pub fn regex_equal_7(v0: Uh2, v1: Uh2) -> Bool {
    case v0  {
        Uh2RegexAlt(v18, v19) -> {
            case v1  {
                Uh2RegexAlt(v20, v21) -> {
                    let v22 = regex_equal_7(v18, v20)
                    case v22 {
                        True -> {
                            regex_equal_7(v19, v21)
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
        Uh2RegexCat(v26, v27) -> {
            case v1  {
                Uh2RegexCat(v28, v29) -> {
                    let v30 = regex_equal_7(v26, v28)
                    case v30 {
                        True -> {
                            regex_equal_7(v27, v29)
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
                    let v15 =
                        case v4  {
                            Us0BitOne -> {
                                case v5  {
                                    Us0BitOne -> {
                                        Us2SymbolSame
                                    }
                                    Us0BitZero -> {
                                        Us2SymbolGreater
                                    }
                                }
                            }
                            Us0BitZero -> {
                                case v5  {
                                    Us0BitOne -> {
                                        Us2SymbolLess
                                    }
                                    Us0BitZero -> {
                                        Us2SymbolSame
                                    }
                                }
                            }
                        }
                    case v15  {
                        Us2SymbolSame -> {
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
        Uh2RegexStar(v34) -> {
            case v1  {
                Uh2RegexStar(v35) -> {
                    regex_equal_7(v34, v35)
                }
                _ -> {
                    False
                }
            }
        }
    }
}

pub fn make_cat_6(v0: Uh2, v1: Uh2) -> Uh2 {
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
                                            let v14 = make_cat_6(v13, v1)
                                            Uh2RegexCat(v12, v14)
                                        }
                                        Uh2RegexStar(v4) -> {
                                            case v1  {
                                                Uh2RegexStar(v5) -> {
                                                    let v6 = regex_equal_7(v4, v5)
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

pub fn make_star_8(v0: Uh2) -> Uh2 {
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

pub fn normalize_2(v0: Uh2) -> Uh2 {
    case v0  {
        Uh2RegexAlt(v5, v6) -> {
            let v7 = normalize_2(v5)
            let v8 = normalize_2(v6)
            make_alt_3(v7, v8)
        }
        Uh2RegexCat(v10, v11) -> {
            let v12 = normalize_2(v10)
            let v13 = normalize_2(v11)
            make_cat_6(v12, v13)
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
            let v16 = normalize_2(v15)
            make_star_8(v16)
        }
    }
}

pub fn nullable_10(v0: Uh2) -> Us3 {
    case v0  {
        Uh2RegexAlt(v5, v6) -> {
            let v7 = nullable_10(v5)
            let v8 = nullable_10(v6)
            case v7  {
                Us3Nullable -> {
                    Us3Nullable
                }
                _ -> {
                    case v8  {
                        Us3Nullable -> {
                            Us3Nullable
                        }
                        _ -> {
                            case v7  {
                                Us3NonNullable -> {
                                    case v8  {
                                        Us3NonNullable -> {
                                            Us3NonNullable
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
            let v18 = nullable_10(v16)
            let v19 = nullable_10(v17)
            case v18  {
                Us3Nullable -> {
                    case v19  {
                        Us3Nullable -> {
                            Us3Nullable
                        }
                        _ -> {
                            Us3NonNullable
                        }
                    }
                }
                _ -> {
                    Us3NonNullable
                }
            }
        }
        Uh2RegexChar(v3) -> {
            Us3NonNullable
        }
        Uh2RegexEmpty -> {
            Us3NonNullable
        }
        Uh2RegexEpsilon -> {
            Us3Nullable
        }
        Uh2RegexStar(v25) -> {
            Us3Nullable
        }
    }
}

pub fn derivative_9(v0: Uh2, v1: Us0) -> Uh2 {
    case v0  {
        Uh2RegexAlt(v19, v20) -> {
            let v21 = derivative_9(v19, v1)
            let v22 = derivative_9(v20, v1)
            make_alt_3(v21, v22)
        }
        Uh2RegexCat(v24, v25) -> {
            let v26 = nullable_10(v24)
            case v26  {
                Us3NonNullable -> {
                    let v31 = derivative_9(v24, v1)
                    make_cat_6(v31, v25)
                }
                Us3Nullable -> {
                    let v27 = derivative_9(v24, v1)
                    let v28 = make_cat_6(v27, v25)
                    let v29 = derivative_9(v25, v1)
                    make_alt_3(v28, v29)
                }
            }
        }
        Uh2RegexChar(v4) -> {
            let v14 =
                case v4  {
                    Us0BitOne -> {
                        case v1  {
                            Us0BitOne -> {
                                Us2SymbolSame
                            }
                            Us0BitZero -> {
                                Us2SymbolGreater
                            }
                        }
                    }
                    Us0BitZero -> {
                        case v1  {
                            Us0BitOne -> {
                                Us2SymbolLess
                            }
                            Us0BitZero -> {
                                Us2SymbolSame
                            }
                        }
                    }
                }
            let v15 =
                case v14  {
                    Us2SymbolSame -> {
                        True
                    }
                    _ -> {
                        False
                    }
                }
            case v15 {
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
        Uh2RegexStar(v35) -> {
            let v36 = derivative_9(v35, v1)
            let v37 = make_star_8(v35)
            make_cat_6(v36, v37)
        }
    }
}

pub fn canonical_derivative_1(v0: Uh2, v1: Us0) -> Uh2 {
    let v2 = normalize_2(v0)
    let v3 = derivative_9(v2, v1)
    normalize_2(v3)
}

pub fn accepts_0(v0: Uh2, v1: Uh0) -> Bool {
    case v1  {
        Uh0InputCons(v6, v7) -> {
            let v8 = canonical_derivative_1(v0, v6)
            accepts_0(v8, v7)
        }
        Uh0InputEmpty -> {
            let v2 = normalize_2(v0)
            let v3 = nullable_10(v2)
            case v3  {
                Us3NonNullable -> {
                    False
                }
                Us3Nullable -> {
                    True
                }
            }
        }
    }
}

pub fn regex_compare_16(v0: Uh3, v1: Uh3) -> Us2 {
    case v0  {
        Uh3RegexAlt(v59, v60) -> {
            case v1  {
                Uh3RegexAlt(v61, v62) -> {
                    let v63 = regex_compare_16(v59, v61)
                    case v63  {
                        Us2SymbolSame -> {
                            regex_compare_16(v60, v62)
                        }
                        _ -> {
                            v63
                        }
                    }
                }
                _ -> {
                    Us2SymbolGreater
                }
            }
        }
        Uh3RegexCat(v34, v35) -> {
            case v1  {
                Uh3RegexCat(v40, v41) -> {
                    let v42 = regex_compare_16(v34, v40)
                    case v42  {
                        Us2SymbolSame -> {
                            regex_compare_16(v35, v41)
                        }
                        _ -> {
                            v42
                        }
                    }
                }
                Uh3RegexChar(v38) -> {
                    Us2SymbolGreater
                }
                Uh3RegexEmpty -> {
                    Us2SymbolGreater
                }
                Uh3RegexEpsilon -> {
                    Us2SymbolGreater
                }
                _ -> {
                    Us2SymbolLess
                }
            }
        }
        Uh3RegexChar(v10) -> {
            case v1  {
                Uh3RegexChar(v13) -> {
                    case v10  {
                        Us1TriA -> {
                            case v13  {
                                Us1TriA -> {
                                    Us2SymbolSame
                                }
                                _ -> {
                                    Us2SymbolLess
                                }
                            }
                        }
                        _ -> {
                            case v13  {
                                Us1TriA -> {
                                    Us2SymbolGreater
                                }
                                _ -> {
                                    case v10  {
                                        Us1TriB -> {
                                            case v13  {
                                                Us1TriB -> {
                                                    Us2SymbolSame
                                                }
                                                Us1TriC -> {
                                                    Us2SymbolLess
                                                }
                                                _ -> panic as "spiral: union case ruled out by partial evaluation"
                                            }
                                        }
                                        Us1TriC -> {
                                            case v13  {
                                                Us1TriB -> {
                                                    Us2SymbolGreater
                                                }
                                                Us1TriC -> {
                                                    Us2SymbolSame
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
                Uh3RegexEmpty -> {
                    Us2SymbolGreater
                }
                Uh3RegexEpsilon -> {
                    Us2SymbolGreater
                }
                _ -> {
                    Us2SymbolLess
                }
            }
        }
        Uh3RegexEmpty -> {
            case v1  {
                Uh3RegexEmpty -> {
                    Us2SymbolSame
                }
                _ -> {
                    Us2SymbolLess
                }
            }
        }
        Uh3RegexEpsilon -> {
            case v1  {
                Uh3RegexEmpty -> {
                    Us2SymbolGreater
                }
                Uh3RegexEpsilon -> {
                    Us2SymbolSame
                }
                _ -> {
                    Us2SymbolLess
                }
            }
        }
        Uh3RegexStar(v50) -> {
            case v1  {
                Uh3RegexAlt(v51, v52) -> {
                    Us2SymbolLess
                }
                Uh3RegexStar(v54) -> {
                    regex_compare_16(v50, v54)
                }
                _ -> {
                    Us2SymbolGreater
                }
            }
        }
    }
}

pub fn alt_insert_sorted_15(v0: Uh3, v1: Uh3) -> Uh3 {
    case v1  {
        Uh3RegexAlt(v2, v3) -> {
            let v4 = regex_compare_16(v0, v2)
            case v4  {
                Us2SymbolGreater -> {
                    let v6 = alt_insert_sorted_15(v0, v3)
                    Uh3RegexAlt(v2, v6)
                }
                Us2SymbolLess -> {
                    Uh3RegexAlt(v0, v1)
                }
                Us2SymbolSame -> {
                    v1
                }
            }
        }
        Uh3RegexEmpty -> {
            v0
        }
        _ -> {
            let v11 = regex_compare_16(v0, v1)
            case v11  {
                Us2SymbolGreater -> {
                    Uh3RegexAlt(v1, v0)
                }
                Us2SymbolLess -> {
                    Uh3RegexAlt(v0, v1)
                }
                Us2SymbolSame -> {
                    v1
                }
            }
        }
    }
}

pub fn make_alt_14(v0: Uh3, v1: Uh3) -> Uh3 {
    case v0  {
        Uh3RegexAlt(v2, v3) -> {
            let v4 = alt_insert_sorted_15(v2, v1)
            make_alt_14(v3, v4)
        }
        Uh3RegexEmpty -> {
            v1
        }
        _ -> {
            alt_insert_sorted_15(v0, v1)
        }
    }
}

pub fn regex_equal_18(v0: Uh3, v1: Uh3) -> Bool {
    case v0  {
        Uh3RegexAlt(v24, v25) -> {
            case v1  {
                Uh3RegexAlt(v26, v27) -> {
                    let v28 = regex_equal_18(v24, v26)
                    case v28 {
                        True -> {
                            regex_equal_18(v25, v27)
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
        Uh3RegexCat(v32, v33) -> {
            case v1  {
                Uh3RegexCat(v34, v35) -> {
                    let v36 = regex_equal_18(v32, v34)
                    case v36 {
                        True -> {
                            regex_equal_18(v33, v35)
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
        Uh3RegexChar(v4) -> {
            case v1  {
                Uh3RegexChar(v5) -> {
                    let v21 =
                        case v4  {
                            Us1TriA -> {
                                case v5  {
                                    Us1TriA -> {
                                        Us2SymbolSame
                                    }
                                    _ -> {
                                        Us2SymbolLess
                                    }
                                }
                            }
                            _ -> {
                                case v5  {
                                    Us1TriA -> {
                                        Us2SymbolGreater
                                    }
                                    _ -> {
                                        case v4  {
                                            Us1TriB -> {
                                                case v5  {
                                                    Us1TriB -> {
                                                        Us2SymbolSame
                                                    }
                                                    Us1TriC -> {
                                                        Us2SymbolLess
                                                    }
                                                    _ -> panic as "spiral: union case ruled out by partial evaluation"
                                                }
                                            }
                                            Us1TriC -> {
                                                case v5  {
                                                    Us1TriB -> {
                                                        Us2SymbolGreater
                                                    }
                                                    Us1TriC -> {
                                                        Us2SymbolSame
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
                        Us2SymbolSame -> {
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
        Uh3RegexEmpty -> {
            case v1  {
                Uh3RegexEmpty -> {
                    True
                }
                _ -> {
                    False
                }
            }
        }
        Uh3RegexEpsilon -> {
            case v1  {
                Uh3RegexEpsilon -> {
                    True
                }
                _ -> {
                    False
                }
            }
        }
        Uh3RegexStar(v40) -> {
            case v1  {
                Uh3RegexStar(v41) -> {
                    regex_equal_18(v40, v41)
                }
                _ -> {
                    False
                }
            }
        }
    }
}

pub fn make_cat_17(v0: Uh3, v1: Uh3) -> Uh3 {
    case v0  {
        Uh3RegexEmpty -> {
            Uh3RegexEmpty
        }
        _ -> {
            case v1  {
                Uh3RegexEmpty -> {
                    Uh3RegexEmpty
                }
                _ -> {
                    case v0  {
                        Uh3RegexEpsilon -> {
                            v1
                        }
                        _ -> {
                            case v1  {
                                Uh3RegexEpsilon -> {
                                    v0
                                }
                                _ -> {
                                    case v0  {
                                        Uh3RegexCat(v12, v13) -> {
                                            let v14 = make_cat_17(v13, v1)
                                            Uh3RegexCat(v12, v14)
                                        }
                                        Uh3RegexStar(v4) -> {
                                            case v1  {
                                                Uh3RegexStar(v5) -> {
                                                    let v6 = regex_equal_18(v4, v5)
                                                    case v6 {
                                                        True -> {
                                                            Uh3RegexStar(v4)
                                                        }
                                                        False -> {
                                                            Uh3RegexCat(v0, v1)
                                                        }
                                                    }
                                                }
                                                _ -> {
                                                    Uh3RegexCat(v0, v1)
                                                }
                                            }
                                        }
                                        _ -> {
                                            Uh3RegexCat(v0, v1)
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
