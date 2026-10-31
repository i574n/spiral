pub type Us0 {
    Us0BitZero
    Us0BitOne
}
pub type Uh0 {
    Uh0SymbolListNil
    Uh0SymbolListCons(Us0, Uh0)
}
pub type Uh2 {
    Uh2InputEmpty
    Uh2InputCons(Us0, Uh2)
}
pub type Uh1 {
    Uh1InputListNil
    Uh1InputListCons(Uh2, Uh1)
}
pub type Us1 {
    Us1TriA
    Us1TriB
    Us1TriC
}
pub type Uh3 {
    Uh3SymbolListNil
    Uh3SymbolListCons(Us1, Uh3)
}
pub type Uh5 {
    Uh5InputEmpty
    Uh5InputCons(Us1, Uh5)
}
pub type Uh4 {
    Uh4InputListNil
    Uh4InputListCons(Uh5, Uh4)
}
pub type Us2 {
    Us2ModelA
    Us2ModelB
    Us2ModelC
}
pub type Uh6 {
    Uh6InputEmpty
    Uh6InputCons(Us2, Uh6)
}
pub type Uh7 {
    Uh7RegexEmpty
    Uh7RegexEpsilon
    Uh7RegexChar(Us0)
    Uh7RegexAlt(Uh7, Uh7)
    Uh7RegexCat(Uh7, Uh7)
    Uh7RegexStar(Uh7)
}
pub type Us3 {
    Us3InventoryDfaAccepted
    Us3InventoryDfaRejected
    Us3InventoryDfaInputOutsideInventory
}
pub type Us4 {
    Us4SymbolLess
    Us4SymbolSame
    Us4SymbolGreater
}
pub type Us5 {
    Us5Nullable
    Us5NonNullable
}
pub type Uh8 {
    Uh8RegexEmpty
    Uh8RegexEpsilon
    Uh8RegexChar(Us1)
    Uh8RegexAlt(Uh8, Uh8)
    Uh8RegexCat(Uh8, Uh8)
    Uh8RegexStar(Uh8)
}
pub fn input_singletons_from_symbols_0(v0: Uh0) -> Uh1 {
    case v0  {
        Uh0SymbolListCons(v2, v3) -> {
            let v4 = input_singletons_from_symbols_0(v3)
            let v5 = Uh2InputEmpty
            let v6 = Uh2InputCons(v2, v5)
            Uh1InputListCons(v6, v4)
        }
        Uh0SymbolListNil -> Uh1InputListNil
    }
}
pub fn input_prepend_symbol_to_corpus_2(v0: Us0, v1: Uh1) -> Uh1 {
    case v1  {
        Uh1InputListCons(v3, v4) -> {
            let v5 = input_prepend_symbol_to_corpus_2(v0, v4)
            let v6 = Uh2InputCons(v0, v3)
            Uh1InputListCons(v6, v5)
        }
        Uh1InputListNil -> Uh1InputListNil
    }
}
pub fn input_list_append_3(v0: Uh1, v1: Uh1) -> Uh1 {
    case v0  {
        Uh1InputListCons(v2, v3) -> {
            let v4 = input_list_append_3(v3, v1)
            Uh1InputListCons(v2, v4)
        }
        Uh1InputListNil -> v1
    }
}
pub fn input_prepend_symbols_to_corpus_1(v0: Uh0, v1: Uh1) -> Uh1 {
    case v0  {
        Uh0SymbolListCons(v3, v4) -> {
            let v5 = input_prepend_symbol_to_corpus_2(v3, v1)
            let v6 = input_prepend_symbols_to_corpus_1(v4, v1)
            input_list_append_3(v5, v6)
        }
        Uh0SymbolListNil -> Uh1InputListNil
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
        Uh3SymbolListNil -> Uh4InputListNil
    }
}
pub fn input_prepend_symbol_to_corpus_6(v0: Us1, v1: Uh4) -> Uh4 {
    case v1  {
        Uh4InputListCons(v3, v4) -> {
            let v5 = input_prepend_symbol_to_corpus_6(v0, v4)
            let v6 = Uh5InputCons(v0, v3)
            Uh4InputListCons(v6, v5)
        }
        Uh4InputListNil -> Uh4InputListNil
    }
}
pub fn input_list_append_7(v0: Uh4, v1: Uh4) -> Uh4 {
    case v0  {
        Uh4InputListCons(v2, v3) -> {
            let v4 = input_list_append_7(v3, v1)
            Uh4InputListCons(v2, v4)
        }
        Uh4InputListNil -> v1
    }
}
pub fn input_prepend_symbols_to_corpus_5(v0: Uh3, v1: Uh4) -> Uh4 {
    case v0  {
        Uh3SymbolListCons(v3, v4) -> {
            let v5 = input_prepend_symbol_to_corpus_6(v3, v1)
            let v6 = input_prepend_symbols_to_corpus_5(v4, v1)
            input_list_append_7(v5, v6)
        }
        Uh3SymbolListNil -> Uh4InputListNil
    }
}
pub fn loop_9(v0: Int, v1: Uh2) -> Us3 {
    case v1  {
        Uh2InputCons(v6, v7) -> {
            let v11 =
                case v6  {
                    Us0BitOne -> Us4SymbolGreater
                    Us0BitZero -> Us4SymbolSame
                }
            let v12 =
                case v11  {
                    Us4SymbolSame -> True
                    _ -> False
                }
            let v19 =
                case v12 {
                    True -> 0
                    False -> {
                        let v16 =
                            case v6  {
                                Us0BitOne -> Us4SymbolSame
                                Us0BitZero -> Us4SymbolLess
                            }
                        let v17 =
                            case v16  {
                                Us4SymbolSame -> True
                                _ -> False
                            }
                        case v17 {
                            True -> 1
                            False -> -1
                        }
                    }
                }
            let v20 = v19 < 0
            case v20 {
                True -> Us3InventoryDfaInputOutsideInventory
                False -> {
                    let v22 = v0 == 0
                    let v27 =
                        case v22 {
                            True -> {
                                let v23 = v19 == 0
                                case v23 {
                                    True -> 0
                                    False -> 1
                                }
                            }
                            False -> {
                                let v25 = v19 == 0
                                case v25 {
                                    True -> 0
                                    False -> 1
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
                True -> Us3InventoryDfaAccepted
                False -> Us3InventoryDfaRejected
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
                        Us4SymbolSame -> regex_compare_15(v54, v56)
                        _ -> v57
                    }
                }
                _ -> Us4SymbolGreater
            }
        }
        Uh7RegexCat(v28, v29) -> {
            case v1  {
                Uh7RegexCat(v34, v35) -> {
                    let v36 = regex_compare_15(v28, v34)
                    case v36  {
                        Us4SymbolSame -> regex_compare_15(v29, v35)
                        _ -> v36
                    }
                }
                Uh7RegexChar(v32) -> Us4SymbolGreater
                Uh7RegexEmpty -> Us4SymbolGreater
                Uh7RegexEpsilon -> Us4SymbolGreater
                _ -> Us4SymbolLess
            }
        }
        Uh7RegexChar(v10) -> {
            case v1  {
                Uh7RegexChar(v13) -> {
                    case v10  {
                        Us0BitOne -> {
                            case v13  {
                                Us0BitOne -> Us4SymbolSame
                                Us0BitZero -> Us4SymbolGreater
                            }
                        }
                        Us0BitZero -> {
                            case v13  {
                                Us0BitOne -> Us4SymbolLess
                                Us0BitZero -> Us4SymbolSame
                            }
                        }
                    }
                }
                Uh7RegexEmpty -> Us4SymbolGreater
                Uh7RegexEpsilon -> Us4SymbolGreater
                _ -> Us4SymbolLess
            }
        }
        Uh7RegexEmpty -> {
            case v1  {
                Uh7RegexEmpty -> Us4SymbolSame
                _ -> Us4SymbolLess
            }
        }
        Uh7RegexEpsilon -> {
            case v1  {
                Uh7RegexEmpty -> Us4SymbolGreater
                Uh7RegexEpsilon -> Us4SymbolSame
                _ -> Us4SymbolLess
            }
        }
        Uh7RegexStar(v44) -> {
            case v1  {
                Uh7RegexAlt(v45, v46) -> Us4SymbolLess
                Uh7RegexStar(v48) -> regex_compare_15(v44, v48)
                _ -> Us4SymbolGreater
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
                Us4SymbolLess -> Uh7RegexAlt(v0, v1)
                Us4SymbolSame -> v1
            }
        }
        Uh7RegexEmpty -> v0
        _ -> {
            let v11 = regex_compare_15(v0, v1)
            case v11  {
                Us4SymbolGreater -> Uh7RegexAlt(v1, v0)
                Us4SymbolLess -> Uh7RegexAlt(v0, v1)
                Us4SymbolSame -> v1
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
        Uh7RegexEmpty -> v1
        _ -> alt_insert_sorted_14(v0, v1)
    }
}
pub fn regex_equal_17(v0: Uh7, v1: Uh7) -> Bool {
    case v0  {
        Uh7RegexAlt(v18, v19) -> {
            case v1  {
                Uh7RegexAlt(v20, v21) -> {
                    let v22 = regex_equal_17(v18, v20)
                    case v22 {
                        True -> regex_equal_17(v19, v21)
                        False -> False
                    }
                }
                _ -> False
            }
        }
        Uh7RegexCat(v26, v27) -> {
            case v1  {
                Uh7RegexCat(v28, v29) -> {
                    let v30 = regex_equal_17(v26, v28)
                    case v30 {
                        True -> regex_equal_17(v27, v29)
                        False -> False
                    }
                }
                _ -> False
            }
        }
        Uh7RegexChar(v4) -> {
            case v1  {
                Uh7RegexChar(v5) -> {
                    let v15 =
                        case v4  {
                            Us0BitOne -> {
                                case v5  {
                                    Us0BitOne -> Us4SymbolSame
                                    Us0BitZero -> Us4SymbolGreater
                                }
                            }
                            Us0BitZero -> {
                                case v5  {
                                    Us0BitOne -> Us4SymbolLess
                                    Us0BitZero -> Us4SymbolSame
                                }
                            }
                        }
                    case v15  {
                        Us4SymbolSame -> True
                        _ -> False
                    }
                }
                _ -> False
            }
        }
        Uh7RegexEmpty -> {
            case v1  {
                Uh7RegexEmpty -> True
                _ -> False
            }
        }
        Uh7RegexEpsilon -> {
            case v1  {
                Uh7RegexEpsilon -> True
                _ -> False
            }
        }
        Uh7RegexStar(v34) -> {
            case v1  {
                Uh7RegexStar(v35) -> regex_equal_17(v34, v35)
                _ -> False
            }
        }
    }
}
pub fn make_cat_16(v0: Uh7, v1: Uh7) -> Uh7 {
    case v0  {
        Uh7RegexEmpty -> Uh7RegexEmpty
        _ -> {
            case v1  {
                Uh7RegexEmpty -> Uh7RegexEmpty
                _ -> {
                    case v0  {
                        Uh7RegexEpsilon -> v1
                        _ -> {
                            case v1  {
                                Uh7RegexEpsilon -> v0
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
                                                        True -> Uh7RegexStar(v4)
                                                        False -> Uh7RegexCat(v0, v1)
                                                    }
                                                }
                                                _ -> Uh7RegexCat(v0, v1)
                                            }
                                        }
                                        _ -> Uh7RegexCat(v0, v1)
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
        Uh7RegexEmpty -> Uh7RegexEpsilon
        Uh7RegexEpsilon -> Uh7RegexEpsilon
        Uh7RegexStar(v3) -> Uh7RegexStar(v3)
        _ -> Uh7RegexStar(v0)
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
        Uh7RegexChar(v3) -> Uh7RegexChar(v3)
        Uh7RegexEmpty -> Uh7RegexEmpty
        Uh7RegexEpsilon -> Uh7RegexEpsilon
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
                Us5Nullable -> Us5Nullable
                _ -> {
                    case v8  {
                        Us5Nullable -> Us5Nullable
                        _ -> {
                            case v7  {
                                Us5NonNullable -> {
                                    case v8  {
                                        Us5NonNullable -> Us5NonNullable
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
                        Us5Nullable -> Us5Nullable
                        _ -> Us5NonNullable
                    }
                }
                _ -> Us5NonNullable
            }
        }
        Uh7RegexChar(v3) -> Us5NonNullable
        Uh7RegexEmpty -> Us5NonNullable
        Uh7RegexEpsilon -> Us5Nullable
        Uh7RegexStar(v25) -> Us5Nullable
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
                            Us0BitOne -> Us4SymbolSame
                            Us0BitZero -> Us4SymbolGreater
                        }
                    }
                    Us0BitZero -> {
                        case v1  {
                            Us0BitOne -> Us4SymbolLess
                            Us0BitZero -> Us4SymbolSame
                        }
                    }
                }
            let v15 =
                case v14  {
                    Us4SymbolSame -> True
                    _ -> False
                }
            case v15 {
                True -> Uh7RegexEpsilon
                False -> Uh7RegexEmpty
            }
        }
        Uh7RegexEmpty -> Uh7RegexEmpty
        Uh7RegexEpsilon -> Uh7RegexEmpty
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
                Us5NonNullable -> False
                Us5Nullable -> True
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
                    Us3InventoryDfaAccepted -> accepts_10(v0, v2)
                    Us3InventoryDfaInputOutsideInventory -> False
                    Us3InventoryDfaRejected -> {
                        let v7 = accepts_10(v0, v2)
                        let v8 = v7 == False
                        v8
                    }
                }
            case v11 {
                True -> loop_8(v0, v3)
                False -> False
            }
        }
        Uh1InputListNil -> True
    }
}
pub fn loop_22(v0: Int, v1: Uh5) -> Us3 {
    case v1  {
        Uh5InputCons(v8, v9) -> {
            let v12 =
                case v8  {
                    Us1TriA -> Us4SymbolSame
                    _ -> Us4SymbolGreater
                }
            let v13 =
                case v12  {
                    Us4SymbolSame -> True
                    _ -> False
                }
            let v30 =
                case v13 {
                    True -> 0
                    False -> {
                        let v19 =
                            case v8  {
                                Us1TriA -> Us4SymbolLess
                                Us1TriB -> Us4SymbolSame
                                Us1TriC -> Us4SymbolGreater
                            }
                        let v20 =
                            case v19  {
                                Us4SymbolSame -> True
                                _ -> False
                            }
                        case v20 {
                            True -> 1
                            False -> {
                                let v26 =
                                    case v8  {
                                        Us1TriA -> Us4SymbolLess
                                        Us1TriB -> Us4SymbolLess
                                        Us1TriC -> Us4SymbolSame
                                    }
                                let v27 =
                                    case v26  {
                                        Us4SymbolSame -> True
                                        _ -> False
                                    }
                                case v27 {
                                    True -> 2
                                    False -> -1
                                }
                            }
                        }
                    }
                }
            let v31 = v30 < 0
            case v31 {
                True -> Us3InventoryDfaInputOutsideInventory
                False -> {
                    let v33 = v0 == 0
                    let v46 =
                        case v33 {
                            True -> {
                                let v34 = v30 == 0
                                case v34 {
                                    True -> 0
                                    False -> 0
                                }
                            }
                            False -> {
                                let v37 = v0 == 1
                                case v37 {
                                    True -> {
                                        let v38 = v30 == 0
                                        case v38 {
                                            True -> 0
                                            False -> 0
                                        }
                                    }
                                    False -> {
                                        let v41 = v30 == 0
                                        case v41 {
                                            True -> 2
                                            False -> {
                                                let v42 = v30 == 1
                                                case v42 {
                                                    True -> 2
                                                    False -> 1
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
                    True -> False
                    False -> {
                        let v3 = v0 == 1
                        v3
                    }
                }
            case v4 {
                True -> Us3InventoryDfaAccepted
                False -> Us3InventoryDfaRejected
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
                        Us4SymbolSame -> regex_compare_28(v60, v62)
                        _ -> v63
                    }
                }
                _ -> Us4SymbolGreater
            }
        }
        Uh8RegexCat(v34, v35) -> {
            case v1  {
                Uh8RegexCat(v40, v41) -> {
                    let v42 = regex_compare_28(v34, v40)
                    case v42  {
                        Us4SymbolSame -> regex_compare_28(v35, v41)
                        _ -> v42
                    }
                }
                Uh8RegexChar(v38) -> Us4SymbolGreater
                Uh8RegexEmpty -> Us4SymbolGreater
                Uh8RegexEpsilon -> Us4SymbolGreater
                _ -> Us4SymbolLess
            }
        }
        Uh8RegexChar(v10) -> {
            case v1  {
                Uh8RegexChar(v13) -> {
                    case v10  {
                        Us1TriA -> {
                            case v13  {
                                Us1TriA -> Us4SymbolSame
                                _ -> Us4SymbolLess
                            }
                        }
                        _ -> {
                            case v13  {
                                Us1TriA -> Us4SymbolGreater
                                _ -> {
                                    case v10  {
                                        Us1TriB -> {
                                            case v13  {
                                                Us1TriB -> Us4SymbolSame
                                                Us1TriC -> Us4SymbolLess
                                                _ -> panic as "spiral: union case ruled out by partial evaluation"
                                            }
                                        }
                                        Us1TriC -> {
                                            case v13  {
                                                Us1TriB -> Us4SymbolGreater
                                                Us1TriC -> Us4SymbolSame
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
                Uh8RegexEmpty -> Us4SymbolGreater
                Uh8RegexEpsilon -> Us4SymbolGreater
                _ -> Us4SymbolLess
            }
        }
        Uh8RegexEmpty -> {
            case v1  {
                Uh8RegexEmpty -> Us4SymbolSame
                _ -> Us4SymbolLess
            }
        }
        Uh8RegexEpsilon -> {
            case v1  {
                Uh8RegexEmpty -> Us4SymbolGreater
                Uh8RegexEpsilon -> Us4SymbolSame
                _ -> Us4SymbolLess
            }
        }
        Uh8RegexStar(v50) -> {
            case v1  {
                Uh8RegexAlt(v51, v52) -> Us4SymbolLess
                Uh8RegexStar(v54) -> regex_compare_28(v50, v54)
                _ -> Us4SymbolGreater
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
                Us4SymbolLess -> Uh8RegexAlt(v0, v1)
                Us4SymbolSame -> v1
            }
        }
        Uh8RegexEmpty -> v0
        _ -> {
            let v11 = regex_compare_28(v0, v1)
            case v11  {
                Us4SymbolGreater -> Uh8RegexAlt(v1, v0)
                Us4SymbolLess -> Uh8RegexAlt(v0, v1)
                Us4SymbolSame -> v1
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
        Uh8RegexEmpty -> v1
        _ -> alt_insert_sorted_27(v0, v1)
    }
}
pub fn regex_equal_30(v0: Uh8, v1: Uh8) -> Bool {
    case v0  {
        Uh8RegexAlt(v24, v25) -> {
            case v1  {
                Uh8RegexAlt(v26, v27) -> {
                    let v28 = regex_equal_30(v24, v26)
                    case v28 {
                        True -> regex_equal_30(v25, v27)
                        False -> False
                    }
                }
                _ -> False
            }
        }
        Uh8RegexCat(v32, v33) -> {
            case v1  {
                Uh8RegexCat(v34, v35) -> {
                    let v36 = regex_equal_30(v32, v34)
                    case v36 {
                        True -> regex_equal_30(v33, v35)
                        False -> False
                    }
                }
                _ -> False
            }
        }
        Uh8RegexChar(v4) -> {
            case v1  {
                Uh8RegexChar(v5) -> {
                    let v21 =
                        case v4  {
                            Us1TriA -> {
                                case v5  {
                                    Us1TriA -> Us4SymbolSame
                                    _ -> Us4SymbolLess
                                }
                            }
                            _ -> {
                                case v5  {
                                    Us1TriA -> Us4SymbolGreater
                                    _ -> {
                                        case v4  {
                                            Us1TriB -> {
                                                case v5  {
                                                    Us1TriB -> Us4SymbolSame
                                                    Us1TriC -> Us4SymbolLess
                                                    _ -> panic as "spiral: union case ruled out by partial evaluation"
                                                }
                                            }
                                            Us1TriC -> {
                                                case v5  {
                                                    Us1TriB -> Us4SymbolGreater
                                                    Us1TriC -> Us4SymbolSame
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
                        Us4SymbolSame -> True
                        _ -> False
                    }
                }
                _ -> False
            }
        }
        Uh8RegexEmpty -> {
            case v1  {
                Uh8RegexEmpty -> True
                _ -> False
            }
        }
        Uh8RegexEpsilon -> {
            case v1  {
                Uh8RegexEpsilon -> True
                _ -> False
            }
        }
        Uh8RegexStar(v40) -> {
            case v1  {
                Uh8RegexStar(v41) -> regex_equal_30(v40, v41)
                _ -> False
            }
        }
    }
}
pub fn make_cat_29(v0: Uh8, v1: Uh8) -> Uh8 {
    case v0  {
        Uh8RegexEmpty -> Uh8RegexEmpty
        _ -> {
            case v1  {
                Uh8RegexEmpty -> Uh8RegexEmpty
                _ -> {
                    case v0  {
                        Uh8RegexEpsilon -> v1
                        _ -> {
                            case v1  {
                                Uh8RegexEpsilon -> v0
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
                                                        True -> Uh8RegexStar(v4)
                                                        False -> Uh8RegexCat(v0, v1)
                                                    }
                                                }
                                                _ -> Uh8RegexCat(v0, v1)
                                            }
                                        }
                                        _ -> Uh8RegexCat(v0, v1)
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
        Uh8RegexEmpty -> Uh8RegexEpsilon
        Uh8RegexEpsilon -> Uh8RegexEpsilon
        Uh8RegexStar(v3) -> Uh8RegexStar(v3)
        _ -> Uh8RegexStar(v0)
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
        Uh8RegexChar(v3) -> Uh8RegexChar(v3)
        Uh8RegexEmpty -> Uh8RegexEmpty
        Uh8RegexEpsilon -> Uh8RegexEpsilon
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
                Us5Nullable -> Us5Nullable
                _ -> {
                    case v8  {
                        Us5Nullable -> Us5Nullable
                        _ -> {
                            case v7  {
                                Us5NonNullable -> {
                                    case v8  {
                                        Us5NonNullable -> Us5NonNullable
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
                        Us5Nullable -> Us5Nullable
                        _ -> Us5NonNullable
                    }
                }
                _ -> Us5NonNullable
            }
        }
        Uh8RegexChar(v3) -> Us5NonNullable
        Uh8RegexEmpty -> Us5NonNullable
        Uh8RegexEpsilon -> Us5Nullable
        Uh8RegexStar(v25) -> Us5Nullable
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
                            Us1TriA -> Us4SymbolSame
                            _ -> Us4SymbolLess
                        }
                    }
                    _ -> {
                        case v1  {
                            Us1TriA -> Us4SymbolGreater
                            _ -> {
                                case v4  {
                                    Us1TriB -> {
                                        case v1  {
                                            Us1TriB -> Us4SymbolSame
                                            Us1TriC -> Us4SymbolLess
                                            _ -> panic as "spiral: union case ruled out by partial evaluation"
                                        }
                                    }
                                    Us1TriC -> {
                                        case v1  {
                                            Us1TriB -> Us4SymbolGreater
                                            Us1TriC -> Us4SymbolSame
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
                    Us4SymbolSame -> True
                    _ -> False
                }
            case v21 {
                True -> Uh8RegexEpsilon
                False -> Uh8RegexEmpty
            }
        }
        Uh8RegexEmpty -> Uh8RegexEmpty
        Uh8RegexEpsilon -> Uh8RegexEmpty
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
                Us5NonNullable -> False
                Us5Nullable -> True
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
                    Us3InventoryDfaAccepted -> accepts_23(v0, v2)
                    Us3InventoryDfaInputOutsideInventory -> False
                    Us3InventoryDfaRejected -> {
                        let v7 = accepts_23(v0, v2)
                        let v8 = v7 == False
                        v8
                    }
                }
            case v11 {
                True -> loop_21(v0, v3)
                False -> False
            }
        }
        Uh4InputListNil -> True
    }
}
pub fn loop_34(v0: Int, v1: Uh6) -> Us3 {
    case v1  {
        Uh6InputCons(v7, v8) -> {
            let v11 =
                case v7  {
                    Us2ModelA -> Us4SymbolSame
                    _ -> Us4SymbolGreater
                }
            let v12 =
                case v11  {
                    Us4SymbolSame -> True
                    _ -> False
                }
            let v21 =
                case v12 {
                    True -> 0
                    False -> {
                        let v18 =
                            case v7  {
                                Us2ModelA -> Us4SymbolLess
                                Us2ModelB -> Us4SymbolSame
                                Us2ModelC -> Us4SymbolGreater
                            }
                        let v19 =
                            case v18  {
                                Us4SymbolSame -> True
                                _ -> False
                            }
                        case v19 {
                            True -> 1
                            False -> -1
                        }
                    }
                }
            let v22 = v21 < 0
            case v22 {
                True -> Us3InventoryDfaInputOutsideInventory
                False -> {
                    let v24 = v0 == 0
                    let v28 =
                        case v24 {
                            True -> 0
                            False -> {
                                let v26 = v21 == 0
                                case v26 {
                                    True -> 1
                                    False -> 0
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
                True -> Us3InventoryDfaAccepted
                False -> Us3InventoryDfaRejected
            }
        }
    }
}
pub fn main() {
    let v0 = Us0BitZero
    let v1 = Us0BitOne
    let v2 = Uh0SymbolListNil
    let v3 = Uh0SymbolListCons(v1, v2)
    let v4 = Uh0SymbolListCons(v0, v3)
    let v5 = input_singletons_from_symbols_0(v4)
    let v6 = Uh2InputEmpty
    let v7 = Uh1InputListCons(v6, v5)
    let v8 = Us0BitZero
    let v9 = Us0BitOne
    let v10 = Uh0SymbolListNil
    let v11 = Uh0SymbolListCons(v9, v10)
    let v12 = Uh0SymbolListCons(v8, v11)
    let v13 = Us0BitZero
    let v14 = Us0BitOne
    let v15 = Uh0SymbolListNil
    let v16 = Uh0SymbolListCons(v14, v15)
    let v17 = Uh0SymbolListCons(v13, v16)
    let v18 = input_singletons_from_symbols_0(v17)
    let v19 = input_prepend_symbols_to_corpus_1(v12, v18)
    let v20 = input_list_append_3(v7, v19)
    let v21 = Us1TriA
    let v22 = Us1TriB
    let v23 = Us1TriC
    let v24 = Uh3SymbolListNil
    let v25 = Uh3SymbolListCons(v23, v24)
    let v26 = Uh3SymbolListCons(v22, v25)
    let v27 = Uh3SymbolListCons(v21, v26)
    let v28 = input_singletons_from_symbols_4(v27)
    let v29 = Uh5InputEmpty
    let v30 = Uh4InputListCons(v29, v28)
    let v31 = Us1TriA
    let v32 = Us1TriB
    let v33 = Us1TriC
    let v34 = Uh3SymbolListNil
    let v35 = Uh3SymbolListCons(v33, v34)
    let v36 = Uh3SymbolListCons(v32, v35)
    let v37 = Uh3SymbolListCons(v31, v36)
    let v38 = Us1TriA
    let v39 = Us1TriB
    let v40 = Us1TriC
    let v41 = Uh3SymbolListNil
    let v42 = Uh3SymbolListCons(v40, v41)
    let v43 = Uh3SymbolListCons(v39, v42)
    let v44 = Uh3SymbolListCons(v38, v43)
    let v45 = input_singletons_from_symbols_4(v44)
    let v46 = input_prepend_symbols_to_corpus_5(v37, v45)
    let v47 = input_list_append_7(v30, v46)
    let v48 = Us2ModelC
    let v49 = Uh6InputEmpty
    let v50 = Uh6InputCons(v48, v49)
    let v51 = Us0BitZero
    let v52 = Uh7RegexChar(v51)
    let v53 = Us0BitOne
    let v54 = Uh7RegexChar(v53)
    let v55 = Uh7RegexAlt(v52, v54)
    let v56 = Uh7RegexStar(v55)
    let v57 = Us0BitZero
    let v58 = Uh7RegexChar(v57)
    let v59 = Uh7RegexCat(v56, v58)
    let v60 = loop_8(v59, v20)
    let v75 =
        case v60 {
            True -> {
                let v61 = Us1TriA
                let v62 = Uh8RegexChar(v61)
                let v63 = Us1TriB
                let v64 = Uh8RegexChar(v63)
                let v65 = Uh8RegexAlt(v62, v64)
                let v66 = Uh8RegexStar(v65)
                let v67 = Us1TriC
                let v68 = Uh8RegexChar(v67)
                let v69 = Uh8RegexCat(v66, v68)
                let v70 = loop_21(v69, v47)
                case v70 {
                    True -> {
                        let v71 = 1
                        let v72 = loop_34(v71, v50)
                        case v72  {
                            Us3InventoryDfaInputOutsideInventory -> True
                            _ -> False
                        }
                    }
                    False -> False
                }
            }
            False -> False
        }
    case v75 {
        True -> 0
        False -> 1
    }
}
