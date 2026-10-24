import main_types.{type Us0, type Uh0, type Uh2, type Uh1, type Us1, type Uh3, type Uh4, type Uh7, type Us3, type Us4, type Us5, Uh0SymbolListCons, Uh0SymbolListNil, Uh1InputListCons, Uh1InputListNil, Uh2InputCons, Uh2InputEmpty, Uh3SymbolListCons, Uh3SymbolListNil, Uh4InputListCons, Uh4InputListNil, Uh5InputCons, Uh5InputEmpty, Uh7RegexAlt, Uh7RegexCat, Uh7RegexChar, Uh7RegexEmpty, Uh7RegexEpsilon, Uh7RegexStar, Us0BitOne, Us0BitZero, Us3InventoryDfaAccepted, Us3InventoryDfaInputOutsideInventory, Us3InventoryDfaRejected, Us4SymbolGreater, Us4SymbolLess, Us4SymbolSame, Us5NonNullable, Us5Nullable}

pub fn input_singletons_from_symbols_0(v0: Uh0) -> Uh1 {
    case v0  {
        Uh0SymbolListCons(v2, v3) -> {
            let v4 = input_singletons_from_symbols_0(v3)
            let v5 = Uh2InputEmpty
            let v6 = Uh2InputCons(v2, v5)
            Uh1InputListCons(v6, v4)
        }
        Uh0SymbolListNil -> {
            Uh1InputListNil
        }
    }
}

pub fn input_prepend_symbol_to_corpus_2(v0: Us0, v1: Uh1) -> Uh1 {
    case v1  {
        Uh1InputListCons(v3, v4) -> {
            let v5 = input_prepend_symbol_to_corpus_2(v0, v4)
            let v6 = Uh2InputCons(v0, v3)
            Uh1InputListCons(v6, v5)
        }
        Uh1InputListNil -> {
            Uh1InputListNil
        }
    }
}

pub fn input_list_append_3(v0: Uh1, v1: Uh1) -> Uh1 {
    case v0  {
        Uh1InputListCons(v2, v3) -> {
            let v4 = input_list_append_3(v3, v1)
            Uh1InputListCons(v2, v4)
        }
        Uh1InputListNil -> {
            v1
        }
    }
}

pub fn input_prepend_symbols_to_corpus_1(v0: Uh0, v1: Uh1) -> Uh1 {
    case v0  {
        Uh0SymbolListCons(v3, v4) -> {
            let v5 = input_prepend_symbol_to_corpus_2(v3, v1)
            let v6 = input_prepend_symbols_to_corpus_1(v4, v1)
            input_list_append_3(v5, v6)
        }
        Uh0SymbolListNil -> {
            Uh1InputListNil
        }
    }
}

pub fn input_singletons_from_symbols_4(v0: Uh3) -> Uh4 {
    case v0  {
        Uh3SymbolListCons(v2, v3) -> {
            let v4 = input_singletons_from_symbols_4(v3)
            let v5 = Uh5InputEmpty
            let v6 = Uh5InputCons(v2, v5)
            Uh4InputListCons(v6, v4)
        }
        Uh3SymbolListNil -> {
            Uh4InputListNil
        }
    }
}

pub fn input_prepend_symbol_to_corpus_6(v0: Us1, v1: Uh4) -> Uh4 {
    case v1  {
        Uh4InputListCons(v3, v4) -> {
            let v5 = input_prepend_symbol_to_corpus_6(v0, v4)
            let v6 = Uh5InputCons(v0, v3)
            Uh4InputListCons(v6, v5)
        }
        Uh4InputListNil -> {
            Uh4InputListNil
        }
    }
}

pub fn input_list_append_7(v0: Uh4, v1: Uh4) -> Uh4 {
    case v0  {
        Uh4InputListCons(v2, v3) -> {
            let v4 = input_list_append_7(v3, v1)
            Uh4InputListCons(v2, v4)
        }
        Uh4InputListNil -> {
            v1
        }
    }
}

pub fn input_prepend_symbols_to_corpus_5(v0: Uh3, v1: Uh4) -> Uh4 {
    case v0  {
        Uh3SymbolListCons(v3, v4) -> {
            let v5 = input_prepend_symbol_to_corpus_6(v3, v1)
            let v6 = input_prepend_symbols_to_corpus_5(v4, v1)
            input_list_append_7(v5, v6)
        }
        Uh3SymbolListNil -> {
            Uh4InputListNil
        }
    }
}

pub fn loop_9(v0: Int, v1: Uh2) -> Us3 {
    case v1  {
        Uh2InputCons(v6, v7) -> {
            let v11 =
                case v6  {
                    Us0BitOne -> {
                        Us4SymbolGreater
                    }
                    Us0BitZero -> {
                        Us4SymbolSame
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
            let v19 =
                case v12 {
                    True -> {
                        0
                    }
                    False -> {
                        let v16 =
                            case v6  {
                                Us0BitOne -> {
                                    Us4SymbolSame
                                }
                                Us0BitZero -> {
                                    Us4SymbolLess
                                }
                            }
                        let v17 =
                            case v16  {
                                Us4SymbolSame -> {
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
                                -1
                            }
                        }
                    }
                }
            let v20 = v19 < 0
            case v20 {
                True -> {
                    Us3InventoryDfaInputOutsideInventory
                }
                False -> {
                    let v22 = v0 == 0
                    let v27 =
                        case v22 {
                            True -> {
                                let v23 = v19 == 0
                                case v23 {
                                    True -> {
                                        0
                                    }
                                    False -> {
                                        1
                                    }
                                }
                            }
                            False -> {
                                let v25 = v19 == 0
                                case v25 {
                                    True -> {
                                        0
                                    }
                                    False -> {
                                        1
                                    }
                                }
                            }
                        }
                    loop_9(v27, v7)
                }
            }
        }
        Uh2InputEmpty -> {
            let v2 = v0 == 0
            case v2 {
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

pub fn regex_compare_15(v0: Uh7, v1: Uh7) -> Us4 {
    case v0  {
        Uh7RegexAlt(v53, v54) -> {
            case v1  {
                Uh7RegexAlt(v55, v56) -> {
                    let v57 = regex_compare_15(v53, v55)
                    case v57  {
                        Us4SymbolSame -> {
                            regex_compare_15(v54, v56)
                        }
                        _ -> {
                            v57
                        }
                    }
                }
                _ -> {
                    Us4SymbolGreater
                }
            }
        }
        Uh7RegexCat(v28, v29) -> {
            case v1  {
                Uh7RegexCat(v34, v35) -> {
                    let v36 = regex_compare_15(v28, v34)
                    case v36  {
                        Us4SymbolSame -> {
                            regex_compare_15(v29, v35)
                        }
                        _ -> {
                            v36
                        }
                    }
                }
                Uh7RegexChar(v32) -> {
                    Us4SymbolGreater
                }
                Uh7RegexEmpty -> {
                    Us4SymbolGreater
                }
                Uh7RegexEpsilon -> {
                    Us4SymbolGreater
                }
                _ -> {
                    Us4SymbolLess
                }
            }
        }
        Uh7RegexChar(v10) -> {
            case v1  {
                Uh7RegexChar(v13) -> {
                    case v10  {
                        Us0BitOne -> {
                            case v13  {
                                Us0BitOne -> {
                                    Us4SymbolSame
                                }
                                Us0BitZero -> {
                                    Us4SymbolGreater
                                }
                            }
                        }
                        Us0BitZero -> {
                            case v13  {
                                Us0BitOne -> {
                                    Us4SymbolLess
                                }
                                Us0BitZero -> {
                                    Us4SymbolSame
                                }
                            }
                        }
                    }
                }
                Uh7RegexEmpty -> {
                    Us4SymbolGreater
                }
                Uh7RegexEpsilon -> {
                    Us4SymbolGreater
                }
                _ -> {
                    Us4SymbolLess
                }
            }
        }
        Uh7RegexEmpty -> {
            case v1  {
                Uh7RegexEmpty -> {
                    Us4SymbolSame
                }
                _ -> {
                    Us4SymbolLess
                }
            }
        }
        Uh7RegexEpsilon -> {
            case v1  {
                Uh7RegexEmpty -> {
                    Us4SymbolGreater
                }
                Uh7RegexEpsilon -> {
                    Us4SymbolSame
                }
                _ -> {
                    Us4SymbolLess
                }
            }
        }
        Uh7RegexStar(v44) -> {
            case v1  {
                Uh7RegexAlt(v45, v46) -> {
                    Us4SymbolLess
                }
                Uh7RegexStar(v48) -> {
                    regex_compare_15(v44, v48)
                }
                _ -> {
                    Us4SymbolGreater
                }
            }
        }
    }
}

pub fn alt_insert_sorted_14(v0: Uh7, v1: Uh7) -> Uh7 {
    case v1  {
        Uh7RegexAlt(v2, v3) -> {
            let v4 = regex_compare_15(v0, v2)
            case v4  {
                Us4SymbolGreater -> {
                    let v6 = alt_insert_sorted_14(v0, v3)
                    Uh7RegexAlt(v2, v6)
                }
                Us4SymbolLess -> {
                    Uh7RegexAlt(v0, v1)
                }
                Us4SymbolSame -> {
                    v1
                }
            }
        }
        Uh7RegexEmpty -> {
            v0
        }
        _ -> {
            let v11 = regex_compare_15(v0, v1)
            case v11  {
                Us4SymbolGreater -> {
                    Uh7RegexAlt(v1, v0)
                }
                Us4SymbolLess -> {
                    Uh7RegexAlt(v0, v1)
                }
                Us4SymbolSame -> {
                    v1
                }
            }
        }
    }
}

pub fn make_alt_13(v0: Uh7, v1: Uh7) -> Uh7 {
    case v0  {
        Uh7RegexAlt(v2, v3) -> {
            let v4 = alt_insert_sorted_14(v2, v1)
            make_alt_13(v3, v4)
        }
        Uh7RegexEmpty -> {
            v1
        }
        _ -> {
            alt_insert_sorted_14(v0, v1)
        }
    }
}

pub fn regex_equal_17(v0: Uh7, v1: Uh7) -> Bool {
    case v0  {
        Uh7RegexAlt(v18, v19) -> {
            case v1  {
                Uh7RegexAlt(v20, v21) -> {
                    let v22 = regex_equal_17(v18, v20)
                    case v22 {
                        True -> {
                            regex_equal_17(v19, v21)
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
        Uh7RegexCat(v26, v27) -> {
            case v1  {
                Uh7RegexCat(v28, v29) -> {
                    let v30 = regex_equal_17(v26, v28)
                    case v30 {
                        True -> {
                            regex_equal_17(v27, v29)
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
        Uh7RegexChar(v4) -> {
            case v1  {
                Uh7RegexChar(v5) -> {
                    let v15 =
                        case v4  {
                            Us0BitOne -> {
                                case v5  {
                                    Us0BitOne -> {
                                        Us4SymbolSame
                                    }
                                    Us0BitZero -> {
                                        Us4SymbolGreater
                                    }
                                }
                            }
                            Us0BitZero -> {
                                case v5  {
                                    Us0BitOne -> {
                                        Us4SymbolLess
                                    }
                                    Us0BitZero -> {
                                        Us4SymbolSame
                                    }
                                }
                            }
                        }
                    case v15  {
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
        Uh7RegexEmpty -> {
            case v1  {
                Uh7RegexEmpty -> {
                    True
                }
                _ -> {
                    False
                }
            }
        }
        Uh7RegexEpsilon -> {
            case v1  {
                Uh7RegexEpsilon -> {
                    True
                }
                _ -> {
                    False
                }
            }
        }
        Uh7RegexStar(v34) -> {
            case v1  {
                Uh7RegexStar(v35) -> {
                    regex_equal_17(v34, v35)
                }
                _ -> {
                    False
                }
            }
        }
    }
}

pub fn make_cat_16(v0: Uh7, v1: Uh7) -> Uh7 {
    case v0  {
        Uh7RegexEmpty -> {
            Uh7RegexEmpty
        }
        _ -> {
            case v1  {
                Uh7RegexEmpty -> {
                    Uh7RegexEmpty
                }
                _ -> {
                    case v0  {
                        Uh7RegexEpsilon -> {
                            v1
                        }
                        _ -> {
                            case v1  {
                                Uh7RegexEpsilon -> {
                                    v0
                                }
                                _ -> {
                                    case v0  {
                                        Uh7RegexCat(v12, v13) -> {
                                            let v14 = make_cat_16(v13, v1)
                                            Uh7RegexCat(v12, v14)
                                        }
                                        Uh7RegexStar(v4) -> {
                                            case v1  {
                                                Uh7RegexStar(v5) -> {
                                                    let v6 = regex_equal_17(v4, v5)
                                                    case v6 {
                                                        True -> {
                                                            Uh7RegexStar(v4)
                                                        }
                                                        False -> {
                                                            Uh7RegexCat(v0, v1)
                                                        }
                                                    }
                                                }
                                                _ -> {
                                                    Uh7RegexCat(v0, v1)
                                                }
                                            }
                                        }
                                        _ -> {
                                            Uh7RegexCat(v0, v1)
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

pub fn make_star_18(v0: Uh7) -> Uh7 {
    case v0  {
        Uh7RegexEmpty -> {
            Uh7RegexEpsilon
        }
        Uh7RegexEpsilon -> {
            Uh7RegexEpsilon
        }
        Uh7RegexStar(v3) -> {
            Uh7RegexStar(v3)
        }
        _ -> {
            Uh7RegexStar(v0)
        }
    }
}

pub fn normalize_12(v0: Uh7) -> Uh7 {
    case v0  {
        Uh7RegexAlt(v5, v6) -> {
            let v7 = normalize_12(v5)
            let v8 = normalize_12(v6)
            make_alt_13(v7, v8)
        }
        Uh7RegexCat(v10, v11) -> {
            let v12 = normalize_12(v10)
            let v13 = normalize_12(v11)
            make_cat_16(v12, v13)
        }
        Uh7RegexChar(v3) -> {
            Uh7RegexChar(v3)
        }
        Uh7RegexEmpty -> {
            Uh7RegexEmpty
        }
        Uh7RegexEpsilon -> {
            Uh7RegexEpsilon
        }
        Uh7RegexStar(v15) -> {
            let v16 = normalize_12(v15)
            make_star_18(v16)
        }
    }
}

pub fn nullable_20(v0: Uh7) -> Us5 {
    case v0  {
        Uh7RegexAlt(v5, v6) -> {
            let v7 = nullable_20(v5)
            let v8 = nullable_20(v6)
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
        Uh7RegexCat(v16, v17) -> {
            let v18 = nullable_20(v16)
            let v19 = nullable_20(v17)
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
        Uh7RegexChar(v3) -> {
            Us5NonNullable
        }
        Uh7RegexEmpty -> {
            Us5NonNullable
        }
        Uh7RegexEpsilon -> {
            Us5Nullable
        }
        Uh7RegexStar(v25) -> {
            Us5Nullable
        }
    }
}

pub fn derivative_19(v0: Uh7, v1: Us0) -> Uh7 {
    case v0  {
        Uh7RegexAlt(v19, v20) -> {
            let v21 = derivative_19(v19, v1)
            let v22 = derivative_19(v20, v1)
            make_alt_13(v21, v22)
        }
        Uh7RegexCat(v24, v25) -> {
            let v26 = nullable_20(v24)
            case v26  {
                Us5NonNullable -> {
                    let v31 = derivative_19(v24, v1)
                    make_cat_16(v31, v25)
                }
                Us5Nullable -> {
                    let v27 = derivative_19(v24, v1)
                    let v28 = make_cat_16(v27, v25)
                    let v29 = derivative_19(v25, v1)
                    make_alt_13(v28, v29)
                }
            }
        }
        Uh7RegexChar(v4) -> {
            let v14 =
                case v4  {
                    Us0BitOne -> {
                        case v1  {
                            Us0BitOne -> {
                                Us4SymbolSame
                            }
                            Us0BitZero -> {
                                Us4SymbolGreater
                            }
                        }
                    }
                    Us0BitZero -> {
                        case v1  {
                            Us0BitOne -> {
                                Us4SymbolLess
                            }
                            Us0BitZero -> {
                                Us4SymbolSame
                            }
                        }
                    }
                }
            let v15 =
                case v14  {
                    Us4SymbolSame -> {
                        True
                    }
                    _ -> {
                        False
                    }
                }
            case v15 {
                True -> {
                    Uh7RegexEpsilon
                }
                False -> {
                    Uh7RegexEmpty
                }
            }
        }
        Uh7RegexEmpty -> {
            Uh7RegexEmpty
        }
        Uh7RegexEpsilon -> {
            Uh7RegexEmpty
        }
        Uh7RegexStar(v35) -> {
            let v36 = derivative_19(v35, v1)
            let v37 = make_star_18(v35)
            make_cat_16(v36, v37)
        }
    }
}

pub fn canonical_derivative_11(v0: Uh7, v1: Us0) -> Uh7 {
    let v2 = normalize_12(v0)
    let v3 = derivative_19(v2, v1)
    normalize_12(v3)
}

pub fn accepts_10(v0: Uh7, v1: Uh2) -> Bool {
    case v1  {
        Uh2InputCons(v6, v7) -> {
            let v8 = canonical_derivative_11(v0, v6)
            accepts_10(v8, v7)
        }
        Uh2InputEmpty -> {
            let v2 = normalize_12(v0)
            let v3 = nullable_20(v2)
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

pub fn loop_8(v0: Uh7, v1: Uh1) -> Bool {
    case v1  {
        Uh1InputListCons(v2, v3) -> {
            let v4 = 1
            let v5 = loop_9(v4, v2)
            let v11 =
                case v5  {
                    Us3InventoryDfaAccepted -> {
                        accepts_10(v0, v2)
                    }
                    Us3InventoryDfaInputOutsideInventory -> {
                        False
                    }
                    Us3InventoryDfaRejected -> {
                        let v7 = accepts_10(v0, v2)
                        let v8 = v7 == False
                        v8
                    }
                }
            case v11 {
                True -> {
                    loop_8(v0, v3)
                }
                False -> {
                    False
                }
            }
        }
        Uh1InputListNil -> {
            True
        }
    }
}
