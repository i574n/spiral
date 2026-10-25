pub type Us0 {
    Us0BitZero
    Us0BitOne
}
pub type Uh0 {
    Uh0InputEmpty
    Uh0InputCons(Us0, Uh0)
}
pub type Us1 {
    Us1TriA
    Us1TriB
    Us1TriC
}
pub type Uh1 {
    Uh1InputEmpty
    Uh1InputCons(Us1, Uh1)
}
pub type Uh2 {
    Uh2RegexEmpty
    Uh2RegexEpsilon
    Uh2RegexChar(Us0)
    Uh2RegexAlt(Uh2, Uh2)
    Uh2RegexCat(Uh2, Uh2)
    Uh2RegexStar(Uh2)
}
pub type Us2 {
    Us2SymbolLess
    Us2SymbolSame
    Us2SymbolGreater
}
pub type Us3 {
    Us3Nullable
    Us3NonNullable
}
pub type Uh3 {
    Uh3RegexEmpty
    Uh3RegexEpsilon
    Uh3RegexChar(Us1)
    Uh3RegexAlt(Uh3, Uh3)
    Uh3RegexCat(Uh3, Uh3)
    Uh3RegexStar(Uh3)
}
pub type Us4 {
    Us4BitMatcherRaw(f0i0 : Uh2, f0i1 : Uh0)
}
pub type Us5 {
    Us5BitMatcherDecided(f0i0 : Uh2, f0i1 : Uh0, f0i2 : Bool)
}
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
pub fn make_star_19(v0: Uh3) -> Uh3 {
    case v0  {
        Uh3RegexEmpty -> {
            Uh3RegexEpsilon
        }
        Uh3RegexEpsilon -> {
            Uh3RegexEpsilon
        }
        Uh3RegexStar(v3) -> {
            Uh3RegexStar(v3)
        }
        _ -> {
            Uh3RegexStar(v0)
        }
    }
}
pub fn normalize_13(v0: Uh3) -> Uh3 {
    case v0  {
        Uh3RegexAlt(v5, v6) -> {
            let v7 = normalize_13(v5)
            let v8 = normalize_13(v6)
            make_alt_14(v7, v8)
        }
        Uh3RegexCat(v10, v11) -> {
            let v12 = normalize_13(v10)
            let v13 = normalize_13(v11)
            make_cat_17(v12, v13)
        }
        Uh3RegexChar(v3) -> {
            Uh3RegexChar(v3)
        }
        Uh3RegexEmpty -> {
            Uh3RegexEmpty
        }
        Uh3RegexEpsilon -> {
            Uh3RegexEpsilon
        }
        Uh3RegexStar(v15) -> {
            let v16 = normalize_13(v15)
            make_star_19(v16)
        }
    }
}
pub fn nullable_21(v0: Uh3) -> Us3 {
    case v0  {
        Uh3RegexAlt(v5, v6) -> {
            let v7 = nullable_21(v5)
            let v8 = nullable_21(v6)
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
        Uh3RegexCat(v16, v17) -> {
            let v18 = nullable_21(v16)
            let v19 = nullable_21(v17)
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
        Uh3RegexChar(v3) -> {
            Us3NonNullable
        }
        Uh3RegexEmpty -> {
            Us3NonNullable
        }
        Uh3RegexEpsilon -> {
            Us3Nullable
        }
        Uh3RegexStar(v25) -> {
            Us3Nullable
        }
    }
}
pub fn derivative_20(v0: Uh3, v1: Us1) -> Uh3 {
    case v0  {
        Uh3RegexAlt(v25, v26) -> {
            let v27 = derivative_20(v25, v1)
            let v28 = derivative_20(v26, v1)
            make_alt_14(v27, v28)
        }
        Uh3RegexCat(v30, v31) -> {
            let v32 = nullable_21(v30)
            case v32  {
                Us3NonNullable -> {
                    let v37 = derivative_20(v30, v1)
                    make_cat_17(v37, v31)
                }
                Us3Nullable -> {
                    let v33 = derivative_20(v30, v1)
                    let v34 = make_cat_17(v33, v31)
                    let v35 = derivative_20(v31, v1)
                    make_alt_14(v34, v35)
                }
            }
        }
        Uh3RegexChar(v4) -> {
            let v20 =
                case v4  {
                    Us1TriA -> {
                        case v1  {
                            Us1TriA -> {
                                Us2SymbolSame
                            }
                            _ -> {
                                Us2SymbolLess
                            }
                        }
                    }
                    _ -> {
                        case v1  {
                            Us1TriA -> {
                                Us2SymbolGreater
                            }
                            _ -> {
                                case v4  {
                                    Us1TriB -> {
                                        case v1  {
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
                                        case v1  {
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
            let v21 =
                case v20  {
                    Us2SymbolSame -> {
                        True
                    }
                    _ -> {
                        False
                    }
                }
            case v21 {
                True -> {
                    Uh3RegexEpsilon
                }
                False -> {
                    Uh3RegexEmpty
                }
            }
        }
        Uh3RegexEmpty -> {
            Uh3RegexEmpty
        }
        Uh3RegexEpsilon -> {
            Uh3RegexEmpty
        }
        Uh3RegexStar(v41) -> {
            let v42 = derivative_20(v41, v1)
            let v43 = make_star_19(v41)
            make_cat_17(v42, v43)
        }
    }
}
pub fn canonical_derivative_12(v0: Uh3, v1: Us1) -> Uh3 {
    let v2 = normalize_13(v0)
    let v3 = derivative_20(v2, v1)
    normalize_13(v3)
}
pub fn accepts_11(v0: Uh3, v1: Uh1) -> Bool {
    case v1  {
        Uh1InputCons(v6, v7) -> {
            let v8 = canonical_derivative_12(v0, v6)
            accepts_11(v8, v7)
        }
        Uh1InputEmpty -> {
            let v2 = normalize_13(v0)
            let v3 = nullable_21(v2)
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
pub fn decide_bit_match_22(v0: Us4) -> Us5 {
    case v0  {
        Us4BitMatcherRaw(v1, v2) -> {
            let v3 = accepts_0(v1, v2)
            Us5BitMatcherDecided(v1, v2, v3)
        }
    }
}
pub fn bit_match_value_23(v0: Us5) -> Bool {
    case v0  {
        Us5BitMatcherDecided(v1, v2, v3) -> {
            v3
        }
    }
}
pub fn main() {
let v0 = Us0BitOne
let v1 = Us0BitOne
let v2 = Us0BitZero
let v3 = Uh0InputEmpty
let v4 = Uh0InputCons(v2, v3)
let v5 = Uh0InputCons(v1, v4)
let v6 = Uh0InputCons(v0, v5)
let v7 = Us0BitOne
let v8 = Us0BitOne
let v9 = Us0BitOne
let v10 = Uh0InputEmpty
let v11 = Uh0InputCons(v9, v10)
let v12 = Uh0InputCons(v8, v11)
let v13 = Uh0InputCons(v7, v12)
let v14 = Us1TriA
let v15 = Us1TriA
let v16 = Us1TriA
let v17 = Uh1InputEmpty
let v18 = Uh1InputCons(v16, v17)
let v19 = Uh1InputCons(v15, v18)
let v20 = Uh1InputCons(v14, v19)
let v21 = Us1TriA
let v22 = Us1TriA
let v23 = Us1TriB
let v24 = Uh1InputEmpty
let v25 = Uh1InputCons(v23, v24)
let v26 = Uh1InputCons(v22, v25)
let v27 = Uh1InputCons(v21, v26)
let v28 = Us0BitZero
let v29 = Uh2RegexChar(v28)
let v30 = Us0BitOne
let v31 = Uh2RegexChar(v30)
let v32 = Uh2RegexAlt(v29, v31)
let v33 = Uh2RegexStar(v32)
let v34 = Us0BitZero
let v35 = Uh2RegexChar(v34)
let v36 = Uh2RegexCat(v33, v35)
let v37 = accepts_0(v36, v6)
case v37 {
    True -> {
        Nil
    }
    False -> {
        panic as "brzozowski-expected-true"
    }
}
let v38 = Us0BitZero
let v39 = Uh2RegexChar(v38)
let v40 = Us0BitOne
let v41 = Uh2RegexChar(v40)
let v42 = Uh2RegexAlt(v39, v41)
let v43 = Uh2RegexStar(v42)
let v44 = Us0BitZero
let v45 = Uh2RegexChar(v44)
let v46 = Uh2RegexCat(v43, v45)
let v47 = accepts_0(v46, v13)
case v47 {
    True -> {
        panic as "brzozowski-expected-false"
    }
    False -> {
    Nil
    }
}
let v48 = Us1TriA
let v49 = Uh3RegexChar(v48)
let v50 = Uh3RegexStar(v49)
let v51 = accepts_11(v50, v20)
case v51 {
    True -> {
        Nil
    }
    False -> {
        panic as "brzozowski-expected-true"
    }
}
let v52 = Us1TriA
let v53 = Uh3RegexChar(v52)
let v54 = Uh3RegexStar(v53)
let v55 = accepts_11(v54, v27)
case v55 {
    True -> {
        panic as "brzozowski-expected-false"
    }
    False -> {
    Nil
    }
}
let v56 = Us0BitZero
let v57 = Uh2RegexChar(v56)
let v58 = Us0BitOne
let v59 = Uh2RegexChar(v58)
let v60 = Uh2RegexAlt(v57, v59)
let v61 = Uh2RegexStar(v60)
let v62 = Us0BitZero
let v63 = Uh2RegexChar(v62)
let v64 = Uh2RegexCat(v61, v63)
let v65 = Us4BitMatcherRaw(v64, v6)
let v66 = decide_bit_match_22(v65)
let v67 = Us0BitZero
let v68 = Uh2RegexChar(v67)
let v69 = Us0BitOne
let v70 = Uh2RegexChar(v69)
let v71 = Uh2RegexAlt(v68, v70)
let v72 = Uh2RegexStar(v71)
let v73 = Us0BitZero
let v74 = Uh2RegexChar(v73)
let v75 = Uh2RegexCat(v72, v74)
let v76 = Us4BitMatcherRaw(v75, v13)
let v77 = decide_bit_match_22(v76)
let v78 = bit_match_value_23(v66)
case v78 {
    True -> {
        Nil
    }
    False -> {
        panic as "brzozowski-expected-true"
    }
}
let v79 = bit_match_value_23(v77)
case v79 {
    True -> {
        panic as "brzozowski-expected-false"
    }
    False -> {
    Nil
    }
}
0
}
