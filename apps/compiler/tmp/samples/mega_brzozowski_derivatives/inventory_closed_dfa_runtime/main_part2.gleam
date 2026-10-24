import main_types.{type Us1, type Uh5, type Uh4, type Uh6, type Us3, type Us4, type Us5, type Uh8, Uh4InputListCons, Uh4InputListNil, Uh5InputCons, Uh5InputEmpty, Uh6InputCons, Uh6InputEmpty, Uh8RegexAlt, Uh8RegexCat, Uh8RegexChar, Uh8RegexEmpty, Uh8RegexEpsilon, Uh8RegexStar, Us1TriA, Us1TriB, Us1TriC, Us2ModelA, Us2ModelB, Us2ModelC, Us3InventoryDfaAccepted, Us3InventoryDfaInputOutsideInventory, Us3InventoryDfaRejected, Us4SymbolGreater, Us4SymbolLess, Us4SymbolSame, Us5NonNullable, Us5Nullable}

pub fn loop_22(v0: Int, v1: Uh5) -> Us3 {
    case v1  {
        Uh5InputCons(v8, v9) -> {
            let v12 =
                case v8  {
                    Us1TriA -> {
                        Us4SymbolSame
                    }
                    _ -> {
                        Us4SymbolGreater
                    }
                }
            let v13 =
                case v12  {
                    Us4SymbolSame -> {
                        True
                    }
                    _ -> {
                        False
                    }
                }
            let v30 =
                case v13 {
                    True -> {
                        0
                    }
                    False -> {
                        let v19 =
                            case v8  {
                                Us1TriA -> {
                                    Us4SymbolLess
                                }
                                Us1TriB -> {
                                    Us4SymbolSame
                                }
                                Us1TriC -> {
                                    Us4SymbolGreater
                                }
                            }
                        let v20 =
                            case v19  {
                                Us4SymbolSame -> {
                                    True
                                }
                                _ -> {
                                    False
                                }
                            }
                        case v20 {
                            True -> {
                                1
                            }
                            False -> {
                                let v26 =
                                    case v8  {
                                        Us1TriA -> {
                                            Us4SymbolLess
                                        }
                                        Us1TriB -> {
                                            Us4SymbolLess
                                        }
                                        Us1TriC -> {
                                            Us4SymbolSame
                                        }
                                    }
                                let v27 =
                                    case v26  {
                                        Us4SymbolSame -> {
                                            True
                                        }
                                        _ -> {
                                            False
                                        }
                                    }
                                case v27 {
                                    True -> {
                                        2
                                    }
                                    False -> {
                                        -1
                                    }
                                }
                            }
                        }
                    }
                }
            let v31 = v30 < 0
            case v31 {
                True -> {
                    Us3InventoryDfaInputOutsideInventory
                }
                False -> {
                    let v33 = v0 == 0
                    let v46 =
                        case v33 {
                            True -> {
                                let v34 = v30 == 0
                                case v34 {
                                    True -> {
                                        0
                                    }
                                    False -> {
                                        0
                                    }
                                }
                            }
                            False -> {
                                let v37 = v0 == 1
                                case v37 {
                                    True -> {
                                        let v38 = v30 == 0
                                        case v38 {
                                            True -> {
                                                0
                                            }
                                            False -> {
                                                0
                                            }
                                        }
                                    }
                                    False -> {
                                        let v41 = v30 == 0
                                        case v41 {
                                            True -> {
                                                2
                                            }
                                            False -> {
                                                let v42 = v30 == 1
                                                case v42 {
                                                    True -> {
                                                        2
                                                    }
                                                    False -> {
                                                        1
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    loop_22(v46, v9)
                }
            }
        }
        Uh5InputEmpty -> {
            let v2 = v0 == 0
            let v4 =
                case v2 {
                    True -> {
                        False
                    }
                    False -> {
                        let v3 = v0 == 1
                        v3
                    }
                }
            case v4 {
                True -> {
                    Us3InventoryDfaAccepted
                }
                False -> {
                    Us3InventoryDfaRejected
                }
            }
        }
    }
}

pub fn regex_compare_28(v0: Uh8, v1: Uh8) -> Us4 {
    case v0  {
        Uh8RegexAlt(v59, v60) -> {
            case v1  {
                Uh8RegexAlt(v61, v62) -> {
                    let v63 = regex_compare_28(v59, v61)
                    case v63  {
                        Us4SymbolSame -> {
                            regex_compare_28(v60, v62)
                        }
                        _ -> {
                            v63
                        }
                    }
                }
                _ -> {
                    Us4SymbolGreater
                }
            }
        }
        Uh8RegexCat(v34, v35) -> {
            case v1  {
                Uh8RegexCat(v40, v41) -> {
                    let v42 = regex_compare_28(v34, v40)
                    case v42  {
                        Us4SymbolSame -> {
                            regex_compare_28(v35, v41)
                        }
                        _ -> {
                            v42
                        }
                    }
                }
                Uh8RegexChar(v38) -> {
                    Us4SymbolGreater
                }
                Uh8RegexEmpty -> {
                    Us4SymbolGreater
                }
                Uh8RegexEpsilon -> {
                    Us4SymbolGreater
                }
                _ -> {
                    Us4SymbolLess
                }
            }
        }
        Uh8RegexChar(v10) -> {
            case v1  {
                Uh8RegexChar(v13) -> {
                    case v10  {
                        Us1TriA -> {
                            case v13  {
                                Us1TriA -> {
                                    Us4SymbolSame
                                }
                                _ -> {
                                    Us4SymbolLess
                                }
                            }
                        }
                        _ -> {
                            case v13  {
                                Us1TriA -> {
                                    Us4SymbolGreater
                                }
                                _ -> {
                                    case v10  {
                                        Us1TriB -> {
                                            case v13  {
                                                Us1TriB -> {
                                                    Us4SymbolSame
                                                }
                                                Us1TriC -> {
                                                    Us4SymbolLess
                                                }
                                                _ -> panic as "spiral: union case ruled out by partial evaluation"
                                            }
                                        }
                                        Us1TriC -> {
                                            case v13  {
                                                Us1TriB -> {
                                                    Us4SymbolGreater
                                                }
                                                Us1TriC -> {
                                                    Us4SymbolSame
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
                Uh8RegexEmpty -> {
                    Us4SymbolGreater
                }
                Uh8RegexEpsilon -> {
                    Us4SymbolGreater
                }
                _ -> {
                    Us4SymbolLess
                }
            }
        }
        Uh8RegexEmpty -> {
            case v1  {
                Uh8RegexEmpty -> {
                    Us4SymbolSame
                }
                _ -> {
                    Us4SymbolLess
                }
            }
        }
        Uh8RegexEpsilon -> {
            case v1  {
                Uh8RegexEmpty -> {
                    Us4SymbolGreater
                }
                Uh8RegexEpsilon -> {
                    Us4SymbolSame
                }
                _ -> {
                    Us4SymbolLess
                }
            }
        }
        Uh8RegexStar(v50) -> {
            case v1  {
                Uh8RegexAlt(v51, v52) -> {
                    Us4SymbolLess
                }
                Uh8RegexStar(v54) -> {
                    regex_compare_28(v50, v54)
                }
                _ -> {
                    Us4SymbolGreater
                }
            }
        }
    }
}

pub fn alt_insert_sorted_27(v0: Uh8, v1: Uh8) -> Uh8 {
    case v1  {
        Uh8RegexAlt(v2, v3) -> {
            let v4 = regex_compare_28(v0, v2)
            case v4  {
                Us4SymbolGreater -> {
                    let v6 = alt_insert_sorted_27(v0, v3)
                    Uh8RegexAlt(v2, v6)
                }
                Us4SymbolLess -> {
                    Uh8RegexAlt(v0, v1)
                }
                Us4SymbolSame -> {
                    v1
                }
            }
        }
        Uh8RegexEmpty -> {
            v0
        }
        _ -> {
            let v11 = regex_compare_28(v0, v1)
            case v11  {
                Us4SymbolGreater -> {
                    Uh8RegexAlt(v1, v0)
                }
                Us4SymbolLess -> {
                    Uh8RegexAlt(v0, v1)
                }
                Us4SymbolSame -> {
                    v1
                }
            }
        }
    }
}

pub fn make_alt_26(v0: Uh8, v1: Uh8) -> Uh8 {
    case v0  {
        Uh8RegexAlt(v2, v3) -> {
            let v4 = alt_insert_sorted_27(v2, v1)
            make_alt_26(v3, v4)
        }
        Uh8RegexEmpty -> {
            v1
        }
        _ -> {
            alt_insert_sorted_27(v0, v1)
        }
    }
}

pub fn regex_equal_30(v0: Uh8, v1: Uh8) -> Bool {
    case v0  {
        Uh8RegexAlt(v24, v25) -> {
            case v1  {
                Uh8RegexAlt(v26, v27) -> {
                    let v28 = regex_equal_30(v24, v26)
                    case v28 {
                        True -> {
                            regex_equal_30(v25, v27)
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
        Uh8RegexCat(v32, v33) -> {
            case v1  {
                Uh8RegexCat(v34, v35) -> {
                    let v36 = regex_equal_30(v32, v34)
                    case v36 {
                        True -> {
                            regex_equal_30(v33, v35)
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
        Uh8RegexChar(v4) -> {
            case v1  {
                Uh8RegexChar(v5) -> {
                    let v21 =
                        case v4  {
                            Us1TriA -> {
                                case v5  {
                                    Us1TriA -> {
                                        Us4SymbolSame
                                    }
                                    _ -> {
                                        Us4SymbolLess
                                    }
                                }
                            }
                            _ -> {
                                case v5  {
                                    Us1TriA -> {
                                        Us4SymbolGreater
                                    }
                                    _ -> {
                                        case v4  {
                                            Us1TriB -> {
                                                case v5  {
                                                    Us1TriB -> {
                                                        Us4SymbolSame
                                                    }
                                                    Us1TriC -> {
                                                        Us4SymbolLess
                                                    }
                                                    _ -> panic as "spiral: union case ruled out by partial evaluation"
                                                }
                                            }
                                            Us1TriC -> {
                                                case v5  {
                                                    Us1TriB -> {
                                                        Us4SymbolGreater
                                                    }
                                                    Us1TriC -> {
                                                        Us4SymbolSame
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
                        Us4SymbolSame -> {
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
        Uh8RegexEmpty -> {
            case v1  {
                Uh8RegexEmpty -> {
                    True
                }
                _ -> {
                    False
                }
            }
        }
        Uh8RegexEpsilon -> {
            case v1  {
                Uh8RegexEpsilon -> {
                    True
                }
                _ -> {
                    False
                }
            }
        }
        Uh8RegexStar(v40) -> {
            case v1  {
                Uh8RegexStar(v41) -> {
                    regex_equal_30(v40, v41)
                }
                _ -> {
                    False
                }
            }
        }
    }
}

pub fn make_cat_29(v0: Uh8, v1: Uh8) -> Uh8 {
    case v0  {
        Uh8RegexEmpty -> {
            Uh8RegexEmpty
        }
        _ -> {
            case v1  {
                Uh8RegexEmpty -> {
                    Uh8RegexEmpty
                }
                _ -> {
                    case v0  {
                        Uh8RegexEpsilon -> {
                            v1
                        }
                        _ -> {
                            case v1  {
                                Uh8RegexEpsilon -> {
                                    v0
                                }
                                _ -> {
                                    case v0  {
                                        Uh8RegexCat(v12, v13) -> {
                                            let v14 = make_cat_29(v13, v1)
                                            Uh8RegexCat(v12, v14)
                                        }
                                        Uh8RegexStar(v4) -> {
                                            case v1  {
                                                Uh8RegexStar(v5) -> {
                                                    let v6 = regex_equal_30(v4, v5)
                                                    case v6 {
                                                        True -> {
                                                            Uh8RegexStar(v4)
                                                        }
                                                        False -> {
                                                            Uh8RegexCat(v0, v1)
                                                        }
                                                    }
                                                }
                                                _ -> {
                                                    Uh8RegexCat(v0, v1)
                                                }
                                            }
                                        }
                                        _ -> {
                                            Uh8RegexCat(v0, v1)
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

pub fn make_star_31(v0: Uh8) -> Uh8 {
    case v0  {
        Uh8RegexEmpty -> {
            Uh8RegexEpsilon
        }
        Uh8RegexEpsilon -> {
            Uh8RegexEpsilon
        }
        Uh8RegexStar(v3) -> {
            Uh8RegexStar(v3)
        }
        _ -> {
            Uh8RegexStar(v0)
        }
    }
}

pub fn normalize_25(v0: Uh8) -> Uh8 {
    case v0  {
        Uh8RegexAlt(v5, v6) -> {
            let v7 = normalize_25(v5)
            let v8 = normalize_25(v6)
            make_alt_26(v7, v8)
        }
        Uh8RegexCat(v10, v11) -> {
            let v12 = normalize_25(v10)
            let v13 = normalize_25(v11)
            make_cat_29(v12, v13)
        }
        Uh8RegexChar(v3) -> {
            Uh8RegexChar(v3)
        }
        Uh8RegexEmpty -> {
            Uh8RegexEmpty
        }
        Uh8RegexEpsilon -> {
            Uh8RegexEpsilon
        }
        Uh8RegexStar(v15) -> {
            let v16 = normalize_25(v15)
            make_star_31(v16)
        }
    }
}

pub fn nullable_33(v0: Uh8) -> Us5 {
    case v0  {
        Uh8RegexAlt(v5, v6) -> {
            let v7 = nullable_33(v5)
            let v8 = nullable_33(v6)
            case v7  {
                Us5Nullable -> {
                    Us5Nullable
                }
                _ -> {
                    case v8  {
                        Us5Nullable -> {
                            Us5Nullable
                        }
                        _ -> {
                            case v7  {
                                Us5NonNullable -> {
                                    case v8  {
                                        Us5NonNullable -> {
                                            Us5NonNullable
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
        Uh8RegexCat(v16, v17) -> {
            let v18 = nullable_33(v16)
            let v19 = nullable_33(v17)
            case v18  {
                Us5Nullable -> {
                    case v19  {
                        Us5Nullable -> {
                            Us5Nullable
                        }
                        _ -> {
                            Us5NonNullable
                        }
                    }
                }
                _ -> {
                    Us5NonNullable
                }
            }
        }
        Uh8RegexChar(v3) -> {
            Us5NonNullable
        }
        Uh8RegexEmpty -> {
            Us5NonNullable
        }
        Uh8RegexEpsilon -> {
            Us5Nullable
        }
        Uh8RegexStar(v25) -> {
            Us5Nullable
        }
    }
}

pub fn derivative_32(v0: Uh8, v1: Us1) -> Uh8 {
    case v0  {
        Uh8RegexAlt(v25, v26) -> {
            let v27 = derivative_32(v25, v1)
            let v28 = derivative_32(v26, v1)
            make_alt_26(v27, v28)
        }
        Uh8RegexCat(v30, v31) -> {
            let v32 = nullable_33(v30)
            case v32  {
                Us5NonNullable -> {
                    let v37 = derivative_32(v30, v1)
                    make_cat_29(v37, v31)
                }
                Us5Nullable -> {
                    let v33 = derivative_32(v30, v1)
                    let v34 = make_cat_29(v33, v31)
                    let v35 = derivative_32(v31, v1)
                    make_alt_26(v34, v35)
                }
            }
        }
        Uh8RegexChar(v4) -> {
            let v20 =
                case v4  {
                    Us1TriA -> {
                        case v1  {
                            Us1TriA -> {
                                Us4SymbolSame
                            }
                            _ -> {
                                Us4SymbolLess
                            }
                        }
                    }
                    _ -> {
                        case v1  {
                            Us1TriA -> {
                                Us4SymbolGreater
                            }
                            _ -> {
                                case v4  {
                                    Us1TriB -> {
                                        case v1  {
                                            Us1TriB -> {
                                                Us4SymbolSame
                                            }
                                            Us1TriC -> {
                                                Us4SymbolLess
                                            }
                                            _ -> panic as "spiral: union case ruled out by partial evaluation"
                                        }
                                    }
                                    Us1TriC -> {
                                        case v1  {
                                            Us1TriB -> {
                                                Us4SymbolGreater
                                            }
                                            Us1TriC -> {
                                                Us4SymbolSame
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
                    Us4SymbolSame -> {
                        True
                    }
                    _ -> {
                        False
                    }
                }
            case v21 {
                True -> {
                    Uh8RegexEpsilon
                }
                False -> {
                    Uh8RegexEmpty
                }
            }
        }
        Uh8RegexEmpty -> {
            Uh8RegexEmpty
        }
        Uh8RegexEpsilon -> {
            Uh8RegexEmpty
        }
        Uh8RegexStar(v41) -> {
            let v42 = derivative_32(v41, v1)
            let v43 = make_star_31(v41)
            make_cat_29(v42, v43)
        }
    }
}

pub fn canonical_derivative_24(v0: Uh8, v1: Us1) -> Uh8 {
    let v2 = normalize_25(v0)
    let v3 = derivative_32(v2, v1)
    normalize_25(v3)
}

pub fn accepts_23(v0: Uh8, v1: Uh5) -> Bool {
    case v1  {
        Uh5InputCons(v6, v7) -> {
            let v8 = canonical_derivative_24(v0, v6)
            accepts_23(v8, v7)
        }
        Uh5InputEmpty -> {
            let v2 = normalize_25(v0)
            let v3 = nullable_33(v2)
            case v3  {
                Us5NonNullable -> {
                    False
                }
                Us5Nullable -> {
                    True
                }
            }
        }
    }
}

pub fn loop_21(v0: Uh8, v1: Uh4) -> Bool {
    case v1  {
        Uh4InputListCons(v2, v3) -> {
            let v4 = 2
            let v5 = loop_22(v4, v2)
            let v11 =
                case v5  {
                    Us3InventoryDfaAccepted -> {
                        accepts_23(v0, v2)
                    }
                    Us3InventoryDfaInputOutsideInventory -> {
                        False
                    }
                    Us3InventoryDfaRejected -> {
                        let v7 = accepts_23(v0, v2)
                        let v8 = v7 == False
                        v8
                    }
                }
            case v11 {
                True -> {
                    loop_21(v0, v3)
                }
                False -> {
                    False
                }
            }
        }
        Uh4InputListNil -> {
            True
        }
    }
}

pub fn loop_34(v0: Int, v1: Uh6) -> Us3 {
    case v1  {
        Uh6InputCons(v7, v8) -> {
            let v11 =
                case v7  {
                    Us2ModelA -> {
                        Us4SymbolSame
                    }
                    _ -> {
                        Us4SymbolGreater
                    }
                }
            let v12 =
                case v11  {
                    Us4SymbolSame -> {
                        True
                    }
                    _ -> {
                        False
                    }
                }
            let v21 =
                case v12 {
                    True -> {
                        0
                    }
                    False -> {
                        let v18 =
                            case v7  {
                                Us2ModelA -> {
                                    Us4SymbolLess
                                }
                                Us2ModelB -> {
                                    Us4SymbolSame
                                }
                                Us2ModelC -> {
                                    Us4SymbolGreater
                                }
                            }
                        let v19 =
                            case v18  {
                                Us4SymbolSame -> {
                                    True
                                }
                                _ -> {
                                    False
                                }
                            }
                        case v19 {
                            True -> {
                                1
                            }
                            False -> {
                                -1
                            }
                        }
                    }
                }
            let v22 = v21 < 0
            case v22 {
                True -> {
                    Us3InventoryDfaInputOutsideInventory
                }
                False -> {
                    let v24 = v0 == 0
                    let v28 =
                        case v24 {
                            True -> {
                                0
                            }
                            False -> {
                                let v26 = v21 == 0
                                case v26 {
                                    True -> {
                                        1
                                    }
                                    False -> {
                                        0
                                    }
                                }
                            }
                        }
                    loop_34(v28, v8)
                }
            }
        }
        Uh6InputEmpty -> {
            let v2 = v0 == 0
            let v3 = v2 == False
            case v3 {
                True -> {
                    Us3InventoryDfaAccepted
                }
                False -> {
                    Us3InventoryDfaRejected
                }
            }
        }
    }
}
