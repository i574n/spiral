import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_BitZero: US0 { var tag: Int32 { 0 } }
struct US0_BitOne: US0 { var tag: Int32 { 1 } }
protocol UH1 { var tag: Int32 { get } }
struct UH1_SymbolListNil: UH1 { var tag: Int32 { 0 } }
struct UH1_SymbolListCons: UH1 { var f0: US0; var f1: UH1; var tag: Int32 { 1 } }
protocol UH3 { var tag: Int32 { get } }
struct UH3_InputEmpty: UH3 { var tag: Int32 { 0 } }
struct UH3_InputCons: UH3 { var f0: US0; var f1: UH3; var tag: Int32 { 1 } }
protocol UH2 { var tag: Int32 { get } }
struct UH2_InputListNil: UH2 { var tag: Int32 { 0 } }
struct UH2_InputListCons: UH2 { var f0: UH3; var f1: UH2; var tag: Int32 { 1 } }
protocol US4 { var tag: Int32 { get } }
struct US4_TriA: US4 { var tag: Int32 { 0 } }
struct US4_TriB: US4 { var tag: Int32 { 1 } }
struct US4_TriC: US4 { var tag: Int32 { 2 } }
protocol UH5 { var tag: Int32 { get } }
struct UH5_SymbolListNil: UH5 { var tag: Int32 { 0 } }
struct UH5_SymbolListCons: UH5 { var f0: US4; var f1: UH5; var tag: Int32 { 1 } }
protocol UH7 { var tag: Int32 { get } }
struct UH7_InputEmpty: UH7 { var tag: Int32 { 0 } }
struct UH7_InputCons: UH7 { var f0: US4; var f1: UH7; var tag: Int32 { 1 } }
protocol UH6 { var tag: Int32 { get } }
struct UH6_InputListNil: UH6 { var tag: Int32 { 0 } }
struct UH6_InputListCons: UH6 { var f0: UH7; var f1: UH6; var tag: Int32 { 1 } }
protocol US8 { var tag: Int32 { get } }
struct US8_ModelA: US8 { var tag: Int32 { 0 } }
struct US8_ModelB: US8 { var tag: Int32 { 1 } }
struct US8_ModelC: US8 { var tag: Int32 { 2 } }
protocol UH9 { var tag: Int32 { get } }
struct UH9_InputEmpty: UH9 { var tag: Int32 { 0 } }
struct UH9_InputCons: UH9 { var f0: US8; var f1: UH9; var tag: Int32 { 1 } }
protocol UH10 { var tag: Int32 { get } }
struct UH10_RegexEmpty: UH10 { var tag: Int32 { 0 } }
struct UH10_RegexEpsilon: UH10 { var tag: Int32 { 1 } }
struct UH10_RegexChar: UH10 { var f0: US0; var tag: Int32 { 2 } }
struct UH10_RegexAlt: UH10 { var f0: UH10; var f1: UH10; var tag: Int32 { 3 } }
struct UH10_RegexCat: UH10 { var f0: UH10; var f1: UH10; var tag: Int32 { 4 } }
struct UH10_RegexStar: UH10 { var f0: UH10; var tag: Int32 { 5 } }
protocol US11 { var tag: Int32 { get } }
struct US11_InventoryDfaAccepted: US11 { var tag: Int32 { 0 } }
struct US11_InventoryDfaRejected: US11 { var tag: Int32 { 1 } }
struct US11_InventoryDfaInputOutsideInventory: US11 { var tag: Int32 { 2 } }
protocol US12 { var tag: Int32 { get } }
struct US12_SymbolLess: US12 { var tag: Int32 { 0 } }
struct US12_SymbolSame: US12 { var tag: Int32 { 1 } }
struct US12_SymbolGreater: US12 { var tag: Int32 { 2 } }
protocol US13 { var tag: Int32 { get } }
struct US13_Nullable: US13 { var tag: Int32 { 0 } }
struct US13_NonNullable: US13 { var tag: Int32 { 1 } }
protocol UH14 { var tag: Int32 { get } }
struct UH14_RegexEmpty: UH14 { var tag: Int32 { 0 } }
struct UH14_RegexEpsilon: UH14 { var tag: Int32 { 1 } }
struct UH14_RegexChar: UH14 { var f0: US4; var tag: Int32 { 2 } }
struct UH14_RegexAlt: UH14 { var f0: UH14; var f1: UH14; var tag: Int32 { 3 } }
struct UH14_RegexCat: UH14 { var f0: UH14; var f1: UH14; var tag: Int32 { 4 } }
struct UH14_RegexStar: UH14 { var f0: UH14; var tag: Int32 { 5 } }
func sp_input_singletons_from_symbols_0(_ p0: UH1) -> UH2 {
    var v0: UH1 = p0
    switch v0.tag {
        case 1:
            var v2: US0 = (v0 as! UH1_SymbolListCons).f0
            var v3: UH1 = (v0 as! UH1_SymbolListCons).f1
            var v4: UH2 = UH2_InputListNil()
            v4 = sp_input_singletons_from_symbols_0(v3)
            var v5: UH3 = UH3_InputEmpty()
            v5 = UH3_InputEmpty()
            var v6: UH3 = UH3_InputEmpty()
            v6 = UH3_InputCons(f0: v2, f1: v5)
            return UH2_InputListCons(f0: v6, f1: v4)
        case 0:
            return UH2_InputListNil()
        default:
            fatalError("unreachable union case")
    }
}
func sp_input_prepend_symbol_to_corpus_2(_ p0: US0, _ p1: UH2) -> UH2 {
    var v0: US0 = p0
    var v1: UH2 = p1
    switch v1.tag {
        case 1:
            var v3: UH3 = (v1 as! UH2_InputListCons).f0
            var v4: UH2 = (v1 as! UH2_InputListCons).f1
            var v5: UH2 = UH2_InputListNil()
            v5 = sp_input_prepend_symbol_to_corpus_2(v0, v4)
            var v6: UH3 = UH3_InputEmpty()
            v6 = UH3_InputCons(f0: v0, f1: v3)
            return UH2_InputListCons(f0: v6, f1: v5)
        case 0:
            return UH2_InputListNil()
        default:
            fatalError("unreachable union case")
    }
}
func sp_input_list_append_3(_ p0: UH2, _ p1: UH2) -> UH2 {
    var v0: UH2 = p0
    var v1: UH2 = p1
    switch v0.tag {
        case 1:
            var v2: UH3 = (v0 as! UH2_InputListCons).f0
            var v3: UH2 = (v0 as! UH2_InputListCons).f1
            var v4: UH2 = UH2_InputListNil()
            v4 = sp_input_list_append_3(v3, v1)
            return UH2_InputListCons(f0: v2, f1: v4)
        case 0:
            return v1
        default:
            fatalError("unreachable union case")
    }
}
func sp_input_prepend_symbols_to_corpus_1(_ p0: UH1, _ p1: UH2) -> UH2 {
    var v0: UH1 = p0
    var v1: UH2 = p1
    switch v0.tag {
        case 1:
            var v3: US0 = (v0 as! UH1_SymbolListCons).f0
            var v4: UH1 = (v0 as! UH1_SymbolListCons).f1
            var v5: UH2 = UH2_InputListNil()
            v5 = sp_input_prepend_symbol_to_corpus_2(v3, v1)
            var v6: UH2 = UH2_InputListNil()
            v6 = sp_input_prepend_symbols_to_corpus_1(v4, v1)
            return sp_input_list_append_3(v5, v6)
        case 0:
            return UH2_InputListNil()
        default:
            fatalError("unreachable union case")
    }
}
func sp_input_singletons_from_symbols_4(_ p0: UH5) -> UH6 {
    var v0: UH5 = p0
    switch v0.tag {
        case 1:
            var v2: US4 = (v0 as! UH5_SymbolListCons).f0
            var v3: UH5 = (v0 as! UH5_SymbolListCons).f1
            var v4: UH6 = UH6_InputListNil()
            v4 = sp_input_singletons_from_symbols_4(v3)
            var v5: UH7 = UH7_InputEmpty()
            v5 = UH7_InputEmpty()
            var v6: UH7 = UH7_InputEmpty()
            v6 = UH7_InputCons(f0: v2, f1: v5)
            return UH6_InputListCons(f0: v6, f1: v4)
        case 0:
            return UH6_InputListNil()
        default:
            fatalError("unreachable union case")
    }
}
func sp_input_prepend_symbol_to_corpus_6(_ p0: US4, _ p1: UH6) -> UH6 {
    var v0: US4 = p0
    var v1: UH6 = p1
    switch v1.tag {
        case 1:
            var v3: UH7 = (v1 as! UH6_InputListCons).f0
            var v4: UH6 = (v1 as! UH6_InputListCons).f1
            var v5: UH6 = UH6_InputListNil()
            v5 = sp_input_prepend_symbol_to_corpus_6(v0, v4)
            var v6: UH7 = UH7_InputEmpty()
            v6 = UH7_InputCons(f0: v0, f1: v3)
            return UH6_InputListCons(f0: v6, f1: v5)
        case 0:
            return UH6_InputListNil()
        default:
            fatalError("unreachable union case")
    }
}
func sp_input_list_append_7(_ p0: UH6, _ p1: UH6) -> UH6 {
    var v0: UH6 = p0
    var v1: UH6 = p1
    switch v0.tag {
        case 1:
            var v2: UH7 = (v0 as! UH6_InputListCons).f0
            var v3: UH6 = (v0 as! UH6_InputListCons).f1
            var v4: UH6 = UH6_InputListNil()
            v4 = sp_input_list_append_7(v3, v1)
            return UH6_InputListCons(f0: v2, f1: v4)
        case 0:
            return v1
        default:
            fatalError("unreachable union case")
    }
}
func sp_input_prepend_symbols_to_corpus_5(_ p0: UH5, _ p1: UH6) -> UH6 {
    var v0: UH5 = p0
    var v1: UH6 = p1
    switch v0.tag {
        case 1:
            var v3: US4 = (v0 as! UH5_SymbolListCons).f0
            var v4: UH5 = (v0 as! UH5_SymbolListCons).f1
            var v5: UH6 = UH6_InputListNil()
            v5 = sp_input_prepend_symbol_to_corpus_6(v3, v1)
            var v6: UH6 = UH6_InputListNil()
            v6 = sp_input_prepend_symbols_to_corpus_5(v4, v1)
            return sp_input_list_append_7(v5, v6)
        case 0:
            return UH6_InputListNil()
        default:
            fatalError("unreachable union case")
    }
}
func sp_loop_9(_ p0: Int32, _ p1: UH3) -> US11 {
    var v0: Int32 = p0
    var v1: UH3 = p1
    switch v1.tag {
        case 1:
            var v6: US0 = (v1 as! UH3_InputCons).f0
            var v7: UH3 = (v1 as! UH3_InputCons).f1
            var v11: US12 = US12_SymbolLess()
            switch v6.tag {
                case 1:
                    v11 = US12_SymbolGreater()
                case 0:
                    v11 = US12_SymbolSame()
                default:
                    fatalError("unreachable union case")
            }
            var v12: Bool = false
            switch v11.tag {
                case 1:
                    v12 = true
                default:
                    v12 = false
            }
            var v19: Int32 = 0
            if (v12) {
                v19 = 0
            } else {
                var v16: US12 = US12_SymbolLess()
                switch v6.tag {
                    case 1:
                        v16 = US12_SymbolSame()
                    case 0:
                        v16 = US12_SymbolLess()
                    default:
                        fatalError("unreachable union case")
                }
                var v17: Bool = false
                switch v16.tag {
                    case 1:
                        v17 = true
                    default:
                        v17 = false
                }
                if (v17) {
                    v19 = 1
                } else {
                    v19 = -1
                }
            }
            var v20: Bool = false
            v20 = (v19 < 0)
            if (v20) {
                return US11_InventoryDfaInputOutsideInventory()
            } else {
                var v22: Bool = false
                v22 = (v0 == 0)
                var v27: Int32 = 0
                if (v22) {
                    var v23: Bool = false
                    v23 = (v19 == 0)
                    if (v23) {
                        v27 = 0
                    } else {
                        v27 = 1
                    }
                } else {
                    var v25: Bool = false
                    v25 = (v19 == 0)
                    if (v25) {
                        v27 = 0
                    } else {
                        v27 = 1
                    }
                }
                return sp_loop_9(v27, v7)
            }
        case 0:
            var v2: Bool = false
            v2 = (v0 == 0)
            if (v2) {
                return US11_InventoryDfaAccepted()
            } else {
                return US11_InventoryDfaRejected()
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_regex_compare_15(_ p0: UH10, _ p1: UH10) -> US12 {
    var v0: UH10 = p0
    var v1: UH10 = p1
    switch v0.tag {
        case 3:
            var v53: UH10 = (v0 as! UH10_RegexAlt).f0
            var v54: UH10 = (v0 as! UH10_RegexAlt).f1
            switch v1.tag {
                case 3:
                    var v55: UH10 = (v1 as! UH10_RegexAlt).f0
                    var v56: UH10 = (v1 as! UH10_RegexAlt).f1
                    var v57: US12 = US12_SymbolLess()
                    v57 = sp_regex_compare_15(v53, v55)
                    switch v57.tag {
                        case 1:
                            return sp_regex_compare_15(v54, v56)
                        default:
                            return v57
                    }
                default:
                    return US12_SymbolGreater()
            }
        case 4:
            var v28: UH10 = (v0 as! UH10_RegexCat).f0
            var v29: UH10 = (v0 as! UH10_RegexCat).f1
            switch v1.tag {
                case 4:
                    var v34: UH10 = (v1 as! UH10_RegexCat).f0
                    var v35: UH10 = (v1 as! UH10_RegexCat).f1
                    var v36: US12 = US12_SymbolLess()
                    v36 = sp_regex_compare_15(v28, v34)
                    switch v36.tag {
                        case 1:
                            return sp_regex_compare_15(v29, v35)
                        default:
                            return v36
                    }
                case 2:
                    var v32: US0 = (v1 as! UH10_RegexChar).f0
                    return US12_SymbolGreater()
                case 0:
                    return US12_SymbolGreater()
                case 1:
                    return US12_SymbolGreater()
                default:
                    return US12_SymbolLess()
            }
        case 2:
            var v10: US0 = (v0 as! UH10_RegexChar).f0
            switch v1.tag {
                case 2:
                    var v13: US0 = (v1 as! UH10_RegexChar).f0
                    switch v10.tag {
                        case 1:
                            switch v13.tag {
                                case 1:
                                    return US12_SymbolSame()
                                case 0:
                                    return US12_SymbolGreater()
                                default:
                                    fatalError("unreachable union case")
                            }
                        case 0:
                            switch v13.tag {
                                case 1:
                                    return US12_SymbolLess()
                                case 0:
                                    return US12_SymbolSame()
                                default:
                                    fatalError("unreachable union case")
                            }
                        default:
                            fatalError("unreachable union case")
                    }
                case 0:
                    return US12_SymbolGreater()
                case 1:
                    return US12_SymbolGreater()
                default:
                    return US12_SymbolLess()
            }
        case 0:
            switch v1.tag {
                case 0:
                    return US12_SymbolSame()
                default:
                    return US12_SymbolLess()
            }
        case 1:
            switch v1.tag {
                case 0:
                    return US12_SymbolGreater()
                case 1:
                    return US12_SymbolSame()
                default:
                    return US12_SymbolLess()
            }
        case 5:
            var v44: UH10 = (v0 as! UH10_RegexStar).f0
            switch v1.tag {
                case 3:
                    var v45: UH10 = (v1 as! UH10_RegexAlt).f0
                    var v46: UH10 = (v1 as! UH10_RegexAlt).f1
                    return US12_SymbolLess()
                case 5:
                    var v48: UH10 = (v1 as! UH10_RegexStar).f0
                    return sp_regex_compare_15(v44, v48)
                default:
                    return US12_SymbolGreater()
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_alt_insert_sorted_14(_ p0: UH10, _ p1: UH10) -> UH10 {
    var v0: UH10 = p0
    var v1: UH10 = p1
    switch v1.tag {
        case 3:
            var v2: UH10 = (v1 as! UH10_RegexAlt).f0
            var v3: UH10 = (v1 as! UH10_RegexAlt).f1
            var v4: US12 = US12_SymbolLess()
            v4 = sp_regex_compare_15(v0, v2)
            switch v4.tag {
                case 2:
                    var v6: UH10 = UH10_RegexEmpty()
                    v6 = sp_alt_insert_sorted_14(v0, v3)
                    return UH10_RegexAlt(f0: v2, f1: v6)
                case 0:
                    return UH10_RegexAlt(f0: v0, f1: v1)
                case 1:
                    return v1
                default:
                    fatalError("unreachable union case")
            }
        case 0:
            return v0
        default:
            var v11: US12 = US12_SymbolLess()
            v11 = sp_regex_compare_15(v0, v1)
            switch v11.tag {
                case 2:
                    return UH10_RegexAlt(f0: v1, f1: v0)
                case 0:
                    return UH10_RegexAlt(f0: v0, f1: v1)
                case 1:
                    return v1
                default:
                    fatalError("unreachable union case")
            }
    }
}
func sp_make_alt_13(_ p0: UH10, _ p1: UH10) -> UH10 {
    var v0: UH10 = p0
    var v1: UH10 = p1
    switch v0.tag {
        case 3:
            var v2: UH10 = (v0 as! UH10_RegexAlt).f0
            var v3: UH10 = (v0 as! UH10_RegexAlt).f1
            var v4: UH10 = UH10_RegexEmpty()
            v4 = sp_alt_insert_sorted_14(v2, v1)
            return sp_make_alt_13(v3, v4)
        case 0:
            return v1
        default:
            return sp_alt_insert_sorted_14(v0, v1)
    }
}
func sp_regex_equal_17(_ p0: UH10, _ p1: UH10) -> Bool {
    var v0: UH10 = p0
    var v1: UH10 = p1
    switch v0.tag {
        case 3:
            var v18: UH10 = (v0 as! UH10_RegexAlt).f0
            var v19: UH10 = (v0 as! UH10_RegexAlt).f1
            switch v1.tag {
                case 3:
                    var v20: UH10 = (v1 as! UH10_RegexAlt).f0
                    var v21: UH10 = (v1 as! UH10_RegexAlt).f1
                    var v22: Bool = false
                    v22 = sp_regex_equal_17(v18, v20)
                    if (v22) {
                        return sp_regex_equal_17(v19, v21)
                    } else {
                        return false
                    }
                default:
                    return false
            }
        case 4:
            var v26: UH10 = (v0 as! UH10_RegexCat).f0
            var v27: UH10 = (v0 as! UH10_RegexCat).f1
            switch v1.tag {
                case 4:
                    var v28: UH10 = (v1 as! UH10_RegexCat).f0
                    var v29: UH10 = (v1 as! UH10_RegexCat).f1
                    var v30: Bool = false
                    v30 = sp_regex_equal_17(v26, v28)
                    if (v30) {
                        return sp_regex_equal_17(v27, v29)
                    } else {
                        return false
                    }
                default:
                    return false
            }
        case 2:
            var v4: US0 = (v0 as! UH10_RegexChar).f0
            switch v1.tag {
                case 2:
                    var v5: US0 = (v1 as! UH10_RegexChar).f0
                    var v15: US12 = US12_SymbolLess()
                    switch v4.tag {
                        case 1:
                            switch v5.tag {
                                case 1:
                                    v15 = US12_SymbolSame()
                                case 0:
                                    v15 = US12_SymbolGreater()
                                default:
                                    fatalError("unreachable union case")
                            }
                        case 0:
                            switch v5.tag {
                                case 1:
                                    v15 = US12_SymbolLess()
                                case 0:
                                    v15 = US12_SymbolSame()
                                default:
                                    fatalError("unreachable union case")
                            }
                        default:
                            fatalError("unreachable union case")
                    }
                    switch v15.tag {
                        case 1:
                            return true
                        default:
                            return false
                    }
                default:
                    return false
            }
        case 0:
            switch v1.tag {
                case 0:
                    return true
                default:
                    return false
            }
        case 1:
            switch v1.tag {
                case 1:
                    return true
                default:
                    return false
            }
        case 5:
            var v34: UH10 = (v0 as! UH10_RegexStar).f0
            switch v1.tag {
                case 5:
                    var v35: UH10 = (v1 as! UH10_RegexStar).f0
                    return sp_regex_equal_17(v34, v35)
                default:
                    return false
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_make_cat_16(_ p0: UH10, _ p1: UH10) -> UH10 {
    var v0: UH10 = p0
    var v1: UH10 = p1
    switch v0.tag {
        case 0:
            return UH10_RegexEmpty()
        default:
            switch v1.tag {
                case 0:
                    return UH10_RegexEmpty()
                default:
                    switch v0.tag {
                        case 1:
                            return v1
                        default:
                            switch v1.tag {
                                case 1:
                                    return v0
                                default:
                                    switch v0.tag {
                                        case 4:
                                            var v12: UH10 = (v0 as! UH10_RegexCat).f0
                                            var v13: UH10 = (v0 as! UH10_RegexCat).f1
                                            var v14: UH10 = UH10_RegexEmpty()
                                            v14 = sp_make_cat_16(v13, v1)
                                            return UH10_RegexCat(f0: v12, f1: v14)
                                        case 5:
                                            var v4: UH10 = (v0 as! UH10_RegexStar).f0
                                            switch v1.tag {
                                                case 5:
                                                    var v5: UH10 = (v1 as! UH10_RegexStar).f0
                                                    var v6: Bool = false
                                                    v6 = sp_regex_equal_17(v4, v5)
                                                    if (v6) {
                                                        return UH10_RegexStar(f0: v4)
                                                    } else {
                                                        return UH10_RegexCat(f0: v0, f1: v1)
                                                    }
                                                default:
                                                    return UH10_RegexCat(f0: v0, f1: v1)
                                            }
                                        default:
                                            return UH10_RegexCat(f0: v0, f1: v1)
                                    }
                            }
                    }
            }
    }
}
func sp_make_star_18(_ p0: UH10) -> UH10 {
    var v0: UH10 = p0
    switch v0.tag {
        case 0:
            return UH10_RegexEpsilon()
        case 1:
            return UH10_RegexEpsilon()
        case 5:
            var v3: UH10 = (v0 as! UH10_RegexStar).f0
            return UH10_RegexStar(f0: v3)
        default:
            return UH10_RegexStar(f0: v0)
    }
}
func sp_normalize_12(_ p0: UH10) -> UH10 {
    var v0: UH10 = p0
    switch v0.tag {
        case 3:
            var v5: UH10 = (v0 as! UH10_RegexAlt).f0
            var v6: UH10 = (v0 as! UH10_RegexAlt).f1
            var v7: UH10 = UH10_RegexEmpty()
            v7 = sp_normalize_12(v5)
            var v8: UH10 = UH10_RegexEmpty()
            v8 = sp_normalize_12(v6)
            return sp_make_alt_13(v7, v8)
        case 4:
            var v10: UH10 = (v0 as! UH10_RegexCat).f0
            var v11: UH10 = (v0 as! UH10_RegexCat).f1
            var v12: UH10 = UH10_RegexEmpty()
            v12 = sp_normalize_12(v10)
            var v13: UH10 = UH10_RegexEmpty()
            v13 = sp_normalize_12(v11)
            return sp_make_cat_16(v12, v13)
        case 2:
            var v3: US0 = (v0 as! UH10_RegexChar).f0
            return UH10_RegexChar(f0: v3)
        case 0:
            return UH10_RegexEmpty()
        case 1:
            return UH10_RegexEpsilon()
        case 5:
            var v15: UH10 = (v0 as! UH10_RegexStar).f0
            var v16: UH10 = UH10_RegexEmpty()
            v16 = sp_normalize_12(v15)
            return sp_make_star_18(v16)
        default:
            fatalError("unreachable union case")
    }
}
func sp_nullable_20(_ p0: UH10) -> US13 {
    var v0: UH10 = p0
    switch v0.tag {
        case 3:
            var v5: UH10 = (v0 as! UH10_RegexAlt).f0
            var v6: UH10 = (v0 as! UH10_RegexAlt).f1
            var v7: US13 = US13_Nullable()
            v7 = sp_nullable_20(v5)
            var v8: US13 = US13_Nullable()
            v8 = sp_nullable_20(v6)
            switch v7.tag {
                case 0:
                    return US13_Nullable()
                default:
                    switch v8.tag {
                        case 0:
                            return US13_Nullable()
                        default:
                            switch v7.tag {
                                case 1:
                                    switch v8.tag {
                                        case 1:
                                            return US13_NonNullable()
                                        default:
                                            fatalError("unreachable union case")
                                    }
                                default:
                                    fatalError("unreachable union case")
                            }
                    }
            }
        case 4:
            var v16: UH10 = (v0 as! UH10_RegexCat).f0
            var v17: UH10 = (v0 as! UH10_RegexCat).f1
            var v18: US13 = US13_Nullable()
            v18 = sp_nullable_20(v16)
            var v19: US13 = US13_Nullable()
            v19 = sp_nullable_20(v17)
            switch v18.tag {
                case 0:
                    switch v19.tag {
                        case 0:
                            return US13_Nullable()
                        default:
                            return US13_NonNullable()
                    }
                default:
                    return US13_NonNullable()
            }
        case 2:
            var v3: US0 = (v0 as! UH10_RegexChar).f0
            return US13_NonNullable()
        case 0:
            return US13_NonNullable()
        case 1:
            return US13_Nullable()
        case 5:
            var v25: UH10 = (v0 as! UH10_RegexStar).f0
            return US13_Nullable()
        default:
            fatalError("unreachable union case")
    }
}
func sp_derivative_19(_ p0: UH10, _ p1: US0) -> UH10 {
    var v0: UH10 = p0
    var v1: US0 = p1
    switch v0.tag {
        case 3:
            var v19: UH10 = (v0 as! UH10_RegexAlt).f0
            var v20: UH10 = (v0 as! UH10_RegexAlt).f1
            var v21: UH10 = UH10_RegexEmpty()
            v21 = sp_derivative_19(v19, v1)
            var v22: UH10 = UH10_RegexEmpty()
            v22 = sp_derivative_19(v20, v1)
            return sp_make_alt_13(v21, v22)
        case 4:
            var v24: UH10 = (v0 as! UH10_RegexCat).f0
            var v25: UH10 = (v0 as! UH10_RegexCat).f1
            var v26: US13 = US13_Nullable()
            v26 = sp_nullable_20(v24)
            switch v26.tag {
                case 1:
                    var v31: UH10 = UH10_RegexEmpty()
                    v31 = sp_derivative_19(v24, v1)
                    return sp_make_cat_16(v31, v25)
                case 0:
                    var v27: UH10 = UH10_RegexEmpty()
                    v27 = sp_derivative_19(v24, v1)
                    var v28: UH10 = UH10_RegexEmpty()
                    v28 = sp_make_cat_16(v27, v25)
                    var v29: UH10 = UH10_RegexEmpty()
                    v29 = sp_derivative_19(v25, v1)
                    return sp_make_alt_13(v28, v29)
                default:
                    fatalError("unreachable union case")
            }
        case 2:
            var v4: US0 = (v0 as! UH10_RegexChar).f0
            var v14: US12 = US12_SymbolLess()
            switch v4.tag {
                case 1:
                    switch v1.tag {
                        case 1:
                            v14 = US12_SymbolSame()
                        case 0:
                            v14 = US12_SymbolGreater()
                        default:
                            fatalError("unreachable union case")
                    }
                case 0:
                    switch v1.tag {
                        case 1:
                            v14 = US12_SymbolLess()
                        case 0:
                            v14 = US12_SymbolSame()
                        default:
                            fatalError("unreachable union case")
                    }
                default:
                    fatalError("unreachable union case")
            }
            var v15: Bool = false
            switch v14.tag {
                case 1:
                    v15 = true
                default:
                    v15 = false
            }
            if (v15) {
                return UH10_RegexEpsilon()
            } else {
                return UH10_RegexEmpty()
            }
        case 0:
            return UH10_RegexEmpty()
        case 1:
            return UH10_RegexEmpty()
        case 5:
            var v35: UH10 = (v0 as! UH10_RegexStar).f0
            var v36: UH10 = UH10_RegexEmpty()
            v36 = sp_derivative_19(v35, v1)
            var v37: UH10 = UH10_RegexEmpty()
            v37 = sp_make_star_18(v35)
            return sp_make_cat_16(v36, v37)
        default:
            fatalError("unreachable union case")
    }
}
func sp_canonical_derivative_11(_ p0: UH10, _ p1: US0) -> UH10 {
    var v0: UH10 = p0
    var v1: US0 = p1
    var v2: UH10 = UH10_RegexEmpty()
    v2 = sp_normalize_12(v0)
    var v3: UH10 = UH10_RegexEmpty()
    v3 = sp_derivative_19(v2, v1)
    return sp_normalize_12(v3)
}
func sp_accepts_10(_ p0: UH10, _ p1: UH3) -> Bool {
    var v0: UH10 = p0
    var v1: UH3 = p1
    switch v1.tag {
        case 1:
            var v6: US0 = (v1 as! UH3_InputCons).f0
            var v7: UH3 = (v1 as! UH3_InputCons).f1
            var v8: UH10 = UH10_RegexEmpty()
            v8 = sp_canonical_derivative_11(v0, v6)
            return sp_accepts_10(v8, v7)
        case 0:
            var v2: UH10 = UH10_RegexEmpty()
            v2 = sp_normalize_12(v0)
            var v3: US13 = US13_Nullable()
            v3 = sp_nullable_20(v2)
            switch v3.tag {
                case 1:
                    return false
                case 0:
                    return true
                default:
                    fatalError("unreachable union case")
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_loop_8(_ p0: UH10, _ p1: UH2) -> Bool {
    var v0: UH10 = p0
    var v1: UH2 = p1
    switch v1.tag {
        case 1:
            var v2: UH3 = (v1 as! UH2_InputListCons).f0
            var v3: UH2 = (v1 as! UH2_InputListCons).f1
            var v4: Int32 = 0
            v4 = 1
            var v5: US11 = US11_InventoryDfaAccepted()
            v5 = sp_loop_9(v4, v2)
            var v11: Bool = false
            switch v5.tag {
                case 0:
                    v11 = sp_accepts_10(v0, v2)
                case 2:
                    v11 = false
                case 1:
                    var v7: Bool = false
                    v7 = sp_accepts_10(v0, v2)
                    var v8: Bool = false
                    v8 = (v7 == false)
                    v11 = v8
                default:
                    fatalError("unreachable union case")
            }
            if (v11) {
                return sp_loop_8(v0, v3)
            } else {
                return false
            }
        case 0:
            return true
        default:
            fatalError("unreachable union case")
    }
}
func sp_loop_22(_ p0: Int32, _ p1: UH7) -> US11 {
    var v0: Int32 = p0
    var v1: UH7 = p1
    switch v1.tag {
        case 1:
            var v8: US4 = (v1 as! UH7_InputCons).f0
            var v9: UH7 = (v1 as! UH7_InputCons).f1
            var v12: US12 = US12_SymbolLess()
            switch v8.tag {
                case 0:
                    v12 = US12_SymbolSame()
                default:
                    v12 = US12_SymbolGreater()
            }
            var v13: Bool = false
            switch v12.tag {
                case 1:
                    v13 = true
                default:
                    v13 = false
            }
            var v30: Int32 = 0
            if (v13) {
                v30 = 0
            } else {
                var v19: US12 = US12_SymbolLess()
                switch v8.tag {
                    case 0:
                        v19 = US12_SymbolLess()
                    case 1:
                        v19 = US12_SymbolSame()
                    case 2:
                        v19 = US12_SymbolGreater()
                    default:
                        fatalError("unreachable union case")
                }
                var v20: Bool = false
                switch v19.tag {
                    case 1:
                        v20 = true
                    default:
                        v20 = false
                }
                if (v20) {
                    v30 = 1
                } else {
                    var v26: US12 = US12_SymbolLess()
                    switch v8.tag {
                        case 0:
                            v26 = US12_SymbolLess()
                        case 1:
                            v26 = US12_SymbolLess()
                        case 2:
                            v26 = US12_SymbolSame()
                        default:
                            fatalError("unreachable union case")
                    }
                    var v27: Bool = false
                    switch v26.tag {
                        case 1:
                            v27 = true
                        default:
                            v27 = false
                    }
                    if (v27) {
                        v30 = 2
                    } else {
                        v30 = -1
                    }
                }
            }
            var v31: Bool = false
            v31 = (v30 < 0)
            if (v31) {
                return US11_InventoryDfaInputOutsideInventory()
            } else {
                var v33: Bool = false
                v33 = (v0 == 0)
                var v46: Int32 = 0
                if (v33) {
                    var v34: Bool = false
                    v34 = (v30 == 0)
                    if (v34) {
                        v46 = 0
                    } else {
                        v46 = 0
                    }
                } else {
                    var v37: Bool = false
                    v37 = (v0 == 1)
                    if (v37) {
                        var v38: Bool = false
                        v38 = (v30 == 0)
                        if (v38) {
                            v46 = 0
                        } else {
                            v46 = 0
                        }
                    } else {
                        var v41: Bool = false
                        v41 = (v30 == 0)
                        if (v41) {
                            v46 = 2
                        } else {
                            var v42: Bool = false
                            v42 = (v30 == 1)
                            if (v42) {
                                v46 = 2
                            } else {
                                v46 = 1
                            }
                        }
                    }
                }
                return sp_loop_22(v46, v9)
            }
        case 0:
            var v2: Bool = false
            v2 = (v0 == 0)
            var v4: Bool = false
            if (v2) {
                v4 = false
            } else {
                var v3: Bool = false
                v3 = (v0 == 1)
                v4 = v3
            }
            if (v4) {
                return US11_InventoryDfaAccepted()
            } else {
                return US11_InventoryDfaRejected()
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_regex_compare_28(_ p0: UH14, _ p1: UH14) -> US12 {
    var v0: UH14 = p0
    var v1: UH14 = p1
    switch v0.tag {
        case 3:
            var v59: UH14 = (v0 as! UH14_RegexAlt).f0
            var v60: UH14 = (v0 as! UH14_RegexAlt).f1
            switch v1.tag {
                case 3:
                    var v61: UH14 = (v1 as! UH14_RegexAlt).f0
                    var v62: UH14 = (v1 as! UH14_RegexAlt).f1
                    var v63: US12 = US12_SymbolLess()
                    v63 = sp_regex_compare_28(v59, v61)
                    switch v63.tag {
                        case 1:
                            return sp_regex_compare_28(v60, v62)
                        default:
                            return v63
                    }
                default:
                    return US12_SymbolGreater()
            }
        case 4:
            var v34: UH14 = (v0 as! UH14_RegexCat).f0
            var v35: UH14 = (v0 as! UH14_RegexCat).f1
            switch v1.tag {
                case 4:
                    var v40: UH14 = (v1 as! UH14_RegexCat).f0
                    var v41: UH14 = (v1 as! UH14_RegexCat).f1
                    var v42: US12 = US12_SymbolLess()
                    v42 = sp_regex_compare_28(v34, v40)
                    switch v42.tag {
                        case 1:
                            return sp_regex_compare_28(v35, v41)
                        default:
                            return v42
                    }
                case 2:
                    var v38: US4 = (v1 as! UH14_RegexChar).f0
                    return US12_SymbolGreater()
                case 0:
                    return US12_SymbolGreater()
                case 1:
                    return US12_SymbolGreater()
                default:
                    return US12_SymbolLess()
            }
        case 2:
            var v10: US4 = (v0 as! UH14_RegexChar).f0
            switch v1.tag {
                case 2:
                    var v13: US4 = (v1 as! UH14_RegexChar).f0
                    switch v10.tag {
                        case 0:
                            switch v13.tag {
                                case 0:
                                    return US12_SymbolSame()
                                default:
                                    return US12_SymbolLess()
                            }
                        default:
                            switch v13.tag {
                                case 0:
                                    return US12_SymbolGreater()
                                default:
                                    switch v10.tag {
                                        case 1:
                                            switch v13.tag {
                                                case 1:
                                                    return US12_SymbolSame()
                                                case 2:
                                                    return US12_SymbolLess()
                                                default:
                                                    fatalError("unreachable union case")
                                            }
                                        case 2:
                                            switch v13.tag {
                                                case 1:
                                                    return US12_SymbolGreater()
                                                case 2:
                                                    return US12_SymbolSame()
                                                default:
                                                    fatalError("unreachable union case")
                                            }
                                        default:
                                            fatalError("unreachable union case")
                                    }
                            }
                    }
                case 0:
                    return US12_SymbolGreater()
                case 1:
                    return US12_SymbolGreater()
                default:
                    return US12_SymbolLess()
            }
        case 0:
            switch v1.tag {
                case 0:
                    return US12_SymbolSame()
                default:
                    return US12_SymbolLess()
            }
        case 1:
            switch v1.tag {
                case 0:
                    return US12_SymbolGreater()
                case 1:
                    return US12_SymbolSame()
                default:
                    return US12_SymbolLess()
            }
        case 5:
            var v50: UH14 = (v0 as! UH14_RegexStar).f0
            switch v1.tag {
                case 3:
                    var v51: UH14 = (v1 as! UH14_RegexAlt).f0
                    var v52: UH14 = (v1 as! UH14_RegexAlt).f1
                    return US12_SymbolLess()
                case 5:
                    var v54: UH14 = (v1 as! UH14_RegexStar).f0
                    return sp_regex_compare_28(v50, v54)
                default:
                    return US12_SymbolGreater()
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_alt_insert_sorted_27(_ p0: UH14, _ p1: UH14) -> UH14 {
    var v0: UH14 = p0
    var v1: UH14 = p1
    switch v1.tag {
        case 3:
            var v2: UH14 = (v1 as! UH14_RegexAlt).f0
            var v3: UH14 = (v1 as! UH14_RegexAlt).f1
            var v4: US12 = US12_SymbolLess()
            v4 = sp_regex_compare_28(v0, v2)
            switch v4.tag {
                case 2:
                    var v6: UH14 = UH14_RegexEmpty()
                    v6 = sp_alt_insert_sorted_27(v0, v3)
                    return UH14_RegexAlt(f0: v2, f1: v6)
                case 0:
                    return UH14_RegexAlt(f0: v0, f1: v1)
                case 1:
                    return v1
                default:
                    fatalError("unreachable union case")
            }
        case 0:
            return v0
        default:
            var v11: US12 = US12_SymbolLess()
            v11 = sp_regex_compare_28(v0, v1)
            switch v11.tag {
                case 2:
                    return UH14_RegexAlt(f0: v1, f1: v0)
                case 0:
                    return UH14_RegexAlt(f0: v0, f1: v1)
                case 1:
                    return v1
                default:
                    fatalError("unreachable union case")
            }
    }
}
func sp_make_alt_26(_ p0: UH14, _ p1: UH14) -> UH14 {
    var v0: UH14 = p0
    var v1: UH14 = p1
    switch v0.tag {
        case 3:
            var v2: UH14 = (v0 as! UH14_RegexAlt).f0
            var v3: UH14 = (v0 as! UH14_RegexAlt).f1
            var v4: UH14 = UH14_RegexEmpty()
            v4 = sp_alt_insert_sorted_27(v2, v1)
            return sp_make_alt_26(v3, v4)
        case 0:
            return v1
        default:
            return sp_alt_insert_sorted_27(v0, v1)
    }
}
func sp_regex_equal_30(_ p0: UH14, _ p1: UH14) -> Bool {
    var v0: UH14 = p0
    var v1: UH14 = p1
    switch v0.tag {
        case 3:
            var v24: UH14 = (v0 as! UH14_RegexAlt).f0
            var v25: UH14 = (v0 as! UH14_RegexAlt).f1
            switch v1.tag {
                case 3:
                    var v26: UH14 = (v1 as! UH14_RegexAlt).f0
                    var v27: UH14 = (v1 as! UH14_RegexAlt).f1
                    var v28: Bool = false
                    v28 = sp_regex_equal_30(v24, v26)
                    if (v28) {
                        return sp_regex_equal_30(v25, v27)
                    } else {
                        return false
                    }
                default:
                    return false
            }
        case 4:
            var v32: UH14 = (v0 as! UH14_RegexCat).f0
            var v33: UH14 = (v0 as! UH14_RegexCat).f1
            switch v1.tag {
                case 4:
                    var v34: UH14 = (v1 as! UH14_RegexCat).f0
                    var v35: UH14 = (v1 as! UH14_RegexCat).f1
                    var v36: Bool = false
                    v36 = sp_regex_equal_30(v32, v34)
                    if (v36) {
                        return sp_regex_equal_30(v33, v35)
                    } else {
                        return false
                    }
                default:
                    return false
            }
        case 2:
            var v4: US4 = (v0 as! UH14_RegexChar).f0
            switch v1.tag {
                case 2:
                    var v5: US4 = (v1 as! UH14_RegexChar).f0
                    var v21: US12 = US12_SymbolLess()
                    switch v4.tag {
                        case 0:
                            switch v5.tag {
                                case 0:
                                    v21 = US12_SymbolSame()
                                default:
                                    v21 = US12_SymbolLess()
                            }
                        default:
                            switch v5.tag {
                                case 0:
                                    v21 = US12_SymbolGreater()
                                default:
                                    switch v4.tag {
                                        case 1:
                                            switch v5.tag {
                                                case 1:
                                                    v21 = US12_SymbolSame()
                                                case 2:
                                                    v21 = US12_SymbolLess()
                                                default:
                                                    fatalError("unreachable union case")
                                            }
                                        case 2:
                                            switch v5.tag {
                                                case 1:
                                                    v21 = US12_SymbolGreater()
                                                case 2:
                                                    v21 = US12_SymbolSame()
                                                default:
                                                    fatalError("unreachable union case")
                                            }
                                        default:
                                            fatalError("unreachable union case")
                                    }
                            }
                    }
                    switch v21.tag {
                        case 1:
                            return true
                        default:
                            return false
                    }
                default:
                    return false
            }
        case 0:
            switch v1.tag {
                case 0:
                    return true
                default:
                    return false
            }
        case 1:
            switch v1.tag {
                case 1:
                    return true
                default:
                    return false
            }
        case 5:
            var v40: UH14 = (v0 as! UH14_RegexStar).f0
            switch v1.tag {
                case 5:
                    var v41: UH14 = (v1 as! UH14_RegexStar).f0
                    return sp_regex_equal_30(v40, v41)
                default:
                    return false
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_make_cat_29(_ p0: UH14, _ p1: UH14) -> UH14 {
    var v0: UH14 = p0
    var v1: UH14 = p1
    switch v0.tag {
        case 0:
            return UH14_RegexEmpty()
        default:
            switch v1.tag {
                case 0:
                    return UH14_RegexEmpty()
                default:
                    switch v0.tag {
                        case 1:
                            return v1
                        default:
                            switch v1.tag {
                                case 1:
                                    return v0
                                default:
                                    switch v0.tag {
                                        case 4:
                                            var v12: UH14 = (v0 as! UH14_RegexCat).f0
                                            var v13: UH14 = (v0 as! UH14_RegexCat).f1
                                            var v14: UH14 = UH14_RegexEmpty()
                                            v14 = sp_make_cat_29(v13, v1)
                                            return UH14_RegexCat(f0: v12, f1: v14)
                                        case 5:
                                            var v4: UH14 = (v0 as! UH14_RegexStar).f0
                                            switch v1.tag {
                                                case 5:
                                                    var v5: UH14 = (v1 as! UH14_RegexStar).f0
                                                    var v6: Bool = false
                                                    v6 = sp_regex_equal_30(v4, v5)
                                                    if (v6) {
                                                        return UH14_RegexStar(f0: v4)
                                                    } else {
                                                        return UH14_RegexCat(f0: v0, f1: v1)
                                                    }
                                                default:
                                                    return UH14_RegexCat(f0: v0, f1: v1)
                                            }
                                        default:
                                            return UH14_RegexCat(f0: v0, f1: v1)
                                    }
                            }
                    }
            }
    }
}
func sp_make_star_31(_ p0: UH14) -> UH14 {
    var v0: UH14 = p0
    switch v0.tag {
        case 0:
            return UH14_RegexEpsilon()
        case 1:
            return UH14_RegexEpsilon()
        case 5:
            var v3: UH14 = (v0 as! UH14_RegexStar).f0
            return UH14_RegexStar(f0: v3)
        default:
            return UH14_RegexStar(f0: v0)
    }
}
func sp_normalize_25(_ p0: UH14) -> UH14 {
    var v0: UH14 = p0
    switch v0.tag {
        case 3:
            var v5: UH14 = (v0 as! UH14_RegexAlt).f0
            var v6: UH14 = (v0 as! UH14_RegexAlt).f1
            var v7: UH14 = UH14_RegexEmpty()
            v7 = sp_normalize_25(v5)
            var v8: UH14 = UH14_RegexEmpty()
            v8 = sp_normalize_25(v6)
            return sp_make_alt_26(v7, v8)
        case 4:
            var v10: UH14 = (v0 as! UH14_RegexCat).f0
            var v11: UH14 = (v0 as! UH14_RegexCat).f1
            var v12: UH14 = UH14_RegexEmpty()
            v12 = sp_normalize_25(v10)
            var v13: UH14 = UH14_RegexEmpty()
            v13 = sp_normalize_25(v11)
            return sp_make_cat_29(v12, v13)
        case 2:
            var v3: US4 = (v0 as! UH14_RegexChar).f0
            return UH14_RegexChar(f0: v3)
        case 0:
            return UH14_RegexEmpty()
        case 1:
            return UH14_RegexEpsilon()
        case 5:
            var v15: UH14 = (v0 as! UH14_RegexStar).f0
            var v16: UH14 = UH14_RegexEmpty()
            v16 = sp_normalize_25(v15)
            return sp_make_star_31(v16)
        default:
            fatalError("unreachable union case")
    }
}
func sp_nullable_33(_ p0: UH14) -> US13 {
    var v0: UH14 = p0
    switch v0.tag {
        case 3:
            var v5: UH14 = (v0 as! UH14_RegexAlt).f0
            var v6: UH14 = (v0 as! UH14_RegexAlt).f1
            var v7: US13 = US13_Nullable()
            v7 = sp_nullable_33(v5)
            var v8: US13 = US13_Nullable()
            v8 = sp_nullable_33(v6)
            switch v7.tag {
                case 0:
                    return US13_Nullable()
                default:
                    switch v8.tag {
                        case 0:
                            return US13_Nullable()
                        default:
                            switch v7.tag {
                                case 1:
                                    switch v8.tag {
                                        case 1:
                                            return US13_NonNullable()
                                        default:
                                            fatalError("unreachable union case")
                                    }
                                default:
                                    fatalError("unreachable union case")
                            }
                    }
            }
        case 4:
            var v16: UH14 = (v0 as! UH14_RegexCat).f0
            var v17: UH14 = (v0 as! UH14_RegexCat).f1
            var v18: US13 = US13_Nullable()
            v18 = sp_nullable_33(v16)
            var v19: US13 = US13_Nullable()
            v19 = sp_nullable_33(v17)
            switch v18.tag {
                case 0:
                    switch v19.tag {
                        case 0:
                            return US13_Nullable()
                        default:
                            return US13_NonNullable()
                    }
                default:
                    return US13_NonNullable()
            }
        case 2:
            var v3: US4 = (v0 as! UH14_RegexChar).f0
            return US13_NonNullable()
        case 0:
            return US13_NonNullable()
        case 1:
            return US13_Nullable()
        case 5:
            var v25: UH14 = (v0 as! UH14_RegexStar).f0
            return US13_Nullable()
        default:
            fatalError("unreachable union case")
    }
}
func sp_derivative_32(_ p0: UH14, _ p1: US4) -> UH14 {
    var v0: UH14 = p0
    var v1: US4 = p1
    switch v0.tag {
        case 3:
            var v25: UH14 = (v0 as! UH14_RegexAlt).f0
            var v26: UH14 = (v0 as! UH14_RegexAlt).f1
            var v27: UH14 = UH14_RegexEmpty()
            v27 = sp_derivative_32(v25, v1)
            var v28: UH14 = UH14_RegexEmpty()
            v28 = sp_derivative_32(v26, v1)
            return sp_make_alt_26(v27, v28)
        case 4:
            var v30: UH14 = (v0 as! UH14_RegexCat).f0
            var v31: UH14 = (v0 as! UH14_RegexCat).f1
            var v32: US13 = US13_Nullable()
            v32 = sp_nullable_33(v30)
            switch v32.tag {
                case 1:
                    var v37: UH14 = UH14_RegexEmpty()
                    v37 = sp_derivative_32(v30, v1)
                    return sp_make_cat_29(v37, v31)
                case 0:
                    var v33: UH14 = UH14_RegexEmpty()
                    v33 = sp_derivative_32(v30, v1)
                    var v34: UH14 = UH14_RegexEmpty()
                    v34 = sp_make_cat_29(v33, v31)
                    var v35: UH14 = UH14_RegexEmpty()
                    v35 = sp_derivative_32(v31, v1)
                    return sp_make_alt_26(v34, v35)
                default:
                    fatalError("unreachable union case")
            }
        case 2:
            var v4: US4 = (v0 as! UH14_RegexChar).f0
            var v20: US12 = US12_SymbolLess()
            switch v4.tag {
                case 0:
                    switch v1.tag {
                        case 0:
                            v20 = US12_SymbolSame()
                        default:
                            v20 = US12_SymbolLess()
                    }
                default:
                    switch v1.tag {
                        case 0:
                            v20 = US12_SymbolGreater()
                        default:
                            switch v4.tag {
                                case 1:
                                    switch v1.tag {
                                        case 1:
                                            v20 = US12_SymbolSame()
                                        case 2:
                                            v20 = US12_SymbolLess()
                                        default:
                                            fatalError("unreachable union case")
                                    }
                                case 2:
                                    switch v1.tag {
                                        case 1:
                                            v20 = US12_SymbolGreater()
                                        case 2:
                                            v20 = US12_SymbolSame()
                                        default:
                                            fatalError("unreachable union case")
                                    }
                                default:
                                    fatalError("unreachable union case")
                            }
                    }
            }
            var v21: Bool = false
            switch v20.tag {
                case 1:
                    v21 = true
                default:
                    v21 = false
            }
            if (v21) {
                return UH14_RegexEpsilon()
            } else {
                return UH14_RegexEmpty()
            }
        case 0:
            return UH14_RegexEmpty()
        case 1:
            return UH14_RegexEmpty()
        case 5:
            var v41: UH14 = (v0 as! UH14_RegexStar).f0
            var v42: UH14 = UH14_RegexEmpty()
            v42 = sp_derivative_32(v41, v1)
            var v43: UH14 = UH14_RegexEmpty()
            v43 = sp_make_star_31(v41)
            return sp_make_cat_29(v42, v43)
        default:
            fatalError("unreachable union case")
    }
}
func sp_canonical_derivative_24(_ p0: UH14, _ p1: US4) -> UH14 {
    var v0: UH14 = p0
    var v1: US4 = p1
    var v2: UH14 = UH14_RegexEmpty()
    v2 = sp_normalize_25(v0)
    var v3: UH14 = UH14_RegexEmpty()
    v3 = sp_derivative_32(v2, v1)
    return sp_normalize_25(v3)
}
func sp_accepts_23(_ p0: UH14, _ p1: UH7) -> Bool {
    var v0: UH14 = p0
    var v1: UH7 = p1
    switch v1.tag {
        case 1:
            var v6: US4 = (v1 as! UH7_InputCons).f0
            var v7: UH7 = (v1 as! UH7_InputCons).f1
            var v8: UH14 = UH14_RegexEmpty()
            v8 = sp_canonical_derivative_24(v0, v6)
            return sp_accepts_23(v8, v7)
        case 0:
            var v2: UH14 = UH14_RegexEmpty()
            v2 = sp_normalize_25(v0)
            var v3: US13 = US13_Nullable()
            v3 = sp_nullable_33(v2)
            switch v3.tag {
                case 1:
                    return false
                case 0:
                    return true
                default:
                    fatalError("unreachable union case")
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_loop_21(_ p0: UH14, _ p1: UH6) -> Bool {
    var v0: UH14 = p0
    var v1: UH6 = p1
    switch v1.tag {
        case 1:
            var v2: UH7 = (v1 as! UH6_InputListCons).f0
            var v3: UH6 = (v1 as! UH6_InputListCons).f1
            var v4: Int32 = 0
            v4 = 2
            var v5: US11 = US11_InventoryDfaAccepted()
            v5 = sp_loop_22(v4, v2)
            var v11: Bool = false
            switch v5.tag {
                case 0:
                    v11 = sp_accepts_23(v0, v2)
                case 2:
                    v11 = false
                case 1:
                    var v7: Bool = false
                    v7 = sp_accepts_23(v0, v2)
                    var v8: Bool = false
                    v8 = (v7 == false)
                    v11 = v8
                default:
                    fatalError("unreachable union case")
            }
            if (v11) {
                return sp_loop_21(v0, v3)
            } else {
                return false
            }
        case 0:
            return true
        default:
            fatalError("unreachable union case")
    }
}
func sp_loop_34(_ p0: Int32, _ p1: UH9) -> US11 {
    var v0: Int32 = p0
    var v1: UH9 = p1
    switch v1.tag {
        case 1:
            var v7: US8 = (v1 as! UH9_InputCons).f0
            var v8: UH9 = (v1 as! UH9_InputCons).f1
            var v11: US12 = US12_SymbolLess()
            switch v7.tag {
                case 0:
                    v11 = US12_SymbolSame()
                default:
                    v11 = US12_SymbolGreater()
            }
            var v12: Bool = false
            switch v11.tag {
                case 1:
                    v12 = true
                default:
                    v12 = false
            }
            var v21: Int32 = 0
            if (v12) {
                v21 = 0
            } else {
                var v18: US12 = US12_SymbolLess()
                switch v7.tag {
                    case 0:
                        v18 = US12_SymbolLess()
                    case 1:
                        v18 = US12_SymbolSame()
                    case 2:
                        v18 = US12_SymbolGreater()
                    default:
                        fatalError("unreachable union case")
                }
                var v19: Bool = false
                switch v18.tag {
                    case 1:
                        v19 = true
                    default:
                        v19 = false
                }
                if (v19) {
                    v21 = 1
                } else {
                    v21 = -1
                }
            }
            var v22: Bool = false
            v22 = (v21 < 0)
            if (v22) {
                return US11_InventoryDfaInputOutsideInventory()
            } else {
                var v24: Bool = false
                v24 = (v0 == 0)
                var v28: Int32 = 0
                if (v24) {
                    v28 = 0
                } else {
                    var v26: Bool = false
                    v26 = (v21 == 0)
                    if (v26) {
                        v28 = 1
                    } else {
                        v28 = 0
                    }
                }
                return sp_loop_34(v28, v8)
            }
        case 0:
            var v2: Bool = false
            v2 = (v0 == 0)
            var v3: Bool = false
            v3 = (v2 == false)
            if (v3) {
                return US11_InventoryDfaAccepted()
            } else {
                return US11_InventoryDfaRejected()
            }
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    let v0: US0 = US0_BitZero()
    let v1: US0 = US0_BitOne()
    var v2: UH1 = UH1_SymbolListNil()
    v2 = UH1_SymbolListNil()
    var v3: UH1 = UH1_SymbolListNil()
    v3 = UH1_SymbolListCons(f0: v1, f1: v2)
    var v4: UH1 = UH1_SymbolListNil()
    v4 = UH1_SymbolListCons(f0: v0, f1: v3)
    var v5: UH2 = UH2_InputListNil()
    v5 = sp_input_singletons_from_symbols_0(v4)
    var v6: UH3 = UH3_InputEmpty()
    v6 = UH3_InputEmpty()
    var v7: UH2 = UH2_InputListNil()
    v7 = UH2_InputListCons(f0: v6, f1: v5)
    var v8: US0 = US0_BitZero()
    v8 = US0_BitZero()
    let v9: US0 = US0_BitOne()
    let v10: UH1 = UH1_SymbolListNil()
    var v11: UH1 = UH1_SymbolListNil()
    v11 = UH1_SymbolListCons(f0: v9, f1: v10)
    var v12: UH1 = UH1_SymbolListNil()
    v12 = UH1_SymbolListCons(f0: v8, f1: v11)
    var v13: US0 = US0_BitZero()
    v13 = US0_BitZero()
    var v14: US0 = US0_BitZero()
    v14 = US0_BitOne()
    var v15: UH1 = UH1_SymbolListNil()
    v15 = UH1_SymbolListNil()
    var v16: UH1 = UH1_SymbolListNil()
    v16 = UH1_SymbolListCons(f0: v14, f1: v15)
    var v17: UH1 = UH1_SymbolListNil()
    v17 = UH1_SymbolListCons(f0: v13, f1: v16)
    var v18: UH2 = UH2_InputListNil()
    v18 = sp_input_singletons_from_symbols_0(v17)
    var v19: UH2 = UH2_InputListNil()
    v19 = sp_input_prepend_symbols_to_corpus_1(v12, v18)
    var v20: UH2 = UH2_InputListNil()
    v20 = sp_input_list_append_3(v7, v19)
    var v21: US4 = US4_TriA()
    v21 = US4_TriA()
    var v22: US4 = US4_TriA()
    v22 = US4_TriB()
    var v23: US4 = US4_TriA()
    v23 = US4_TriC()
    var v24: UH5 = UH5_SymbolListNil()
    v24 = UH5_SymbolListNil()
    var v25: UH5 = UH5_SymbolListNil()
    v25 = UH5_SymbolListCons(f0: v23, f1: v24)
    var v26: UH5 = UH5_SymbolListNil()
    v26 = UH5_SymbolListCons(f0: v22, f1: v25)
    var v27: UH5 = UH5_SymbolListNil()
    v27 = UH5_SymbolListCons(f0: v21, f1: v26)
    var v28: UH6 = UH6_InputListNil()
    v28 = sp_input_singletons_from_symbols_4(v27)
    var v29: UH7 = UH7_InputEmpty()
    v29 = UH7_InputEmpty()
    var v30: UH6 = UH6_InputListNil()
    v30 = UH6_InputListCons(f0: v29, f1: v28)
    var v31: US4 = US4_TriA()
    v31 = US4_TriA()
    var v32: US4 = US4_TriA()
    v32 = US4_TriB()
    var v33: US4 = US4_TriA()
    v33 = US4_TriC()
    var v34: UH5 = UH5_SymbolListNil()
    v34 = UH5_SymbolListNil()
    var v35: UH5 = UH5_SymbolListNil()
    v35 = UH5_SymbolListCons(f0: v33, f1: v34)
    var v36: UH5 = UH5_SymbolListNil()
    v36 = UH5_SymbolListCons(f0: v32, f1: v35)
    var v37: UH5 = UH5_SymbolListNil()
    v37 = UH5_SymbolListCons(f0: v31, f1: v36)
    var v38: US4 = US4_TriA()
    v38 = US4_TriA()
    let v39: US4 = US4_TriB()
    let v40: US4 = US4_TriC()
    var v41: UH5 = UH5_SymbolListNil()
    v41 = UH5_SymbolListNil()
    var v42: UH5 = UH5_SymbolListNil()
    v42 = UH5_SymbolListCons(f0: v40, f1: v41)
    var v43: UH5 = UH5_SymbolListNil()
    v43 = UH5_SymbolListCons(f0: v39, f1: v42)
    let v44: UH5 = UH5_SymbolListCons(f0: v38, f1: v43)
    let v45: UH6 = sp_input_singletons_from_symbols_4(v44)
    var v46: UH6 = UH6_InputListNil()
    v46 = sp_input_prepend_symbols_to_corpus_5(v37, v45)
    let v47: UH6 = sp_input_list_append_7(v30, v46)
    let v48: US8 = US8_ModelC()
    let v49: UH9 = UH9_InputEmpty()
    let v50: UH9 = UH9_InputCons(f0: v48, f1: v49)
    let v51: US0 = US0_BitZero()
    let v52: UH10 = UH10_RegexChar(f0: v51)
    let v53: US0 = US0_BitOne()
    let v54: UH10 = UH10_RegexChar(f0: v53)
    let v55: UH10 = UH10_RegexAlt(f0: v52, f1: v54)
    let v56: UH10 = UH10_RegexStar(f0: v55)
    var v57: US0 = US0_BitZero()
    v57 = US0_BitZero()
    let v58: UH10 = UH10_RegexChar(f0: v57)
    let v59: UH10 = UH10_RegexCat(f0: v56, f1: v58)
    let v60: Bool = sp_loop_8(v59, v20)
    var v75: Bool = false
    if (v60) {
        let v61: US4 = US4_TriA()
        let v62: UH14 = UH14_RegexChar(f0: v61)
        var v63: US4 = US4_TriA()
        v63 = US4_TriB()
        let v64: UH14 = UH14_RegexChar(f0: v63)
        let v65: UH14 = UH14_RegexAlt(f0: v62, f1: v64)
        let v66: UH14 = UH14_RegexStar(f0: v65)
        let v67: US4 = US4_TriC()
        let v68: UH14 = UH14_RegexChar(f0: v67)
        let v69: UH14 = UH14_RegexCat(f0: v66, f1: v68)
        let v70: Bool = sp_loop_21(v69, v47)
        if (v70) {
            let v71: Int32 = 1
            let v72: US11 = sp_loop_34(v71, v50)
            switch v72.tag {
                case 2:
                    v75 = true
                default:
                    v75 = false
            }
        } else {
            v75 = false
        }
    } else {
        v75 = false
    }
    if (v75) {
        return 0
    } else {
        return 1
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
