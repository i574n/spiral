import main_types.{type Us1, type Us2, type Us3, type Uh2, type Uh3, Uh2RegexAlt, Uh2RegexCat, Uh2RegexChar, Uh2RegexEmpty, Uh2RegexEpsilon, Uh2RegexStar, Uh3InputCons, Uh3InputEmpty, Us1SymbolGreater, Us1SymbolLess, Us1SymbolSame, Us2NonNullable, Us2Nullable, Us3TriA, Us3TriB, Us3TriC}

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
