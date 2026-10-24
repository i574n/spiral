import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_BitZero: US0 { var tag: Int32 { 0 } }
struct US0_BitOne: US0 { var tag: Int32 { 1 } }
protocol UH1 { var tag: Int32 { get } }
struct UH1_RegexEmpty: UH1 { var tag: Int32 { 0 } }
struct UH1_RegexEpsilon: UH1 { var tag: Int32 { 1 } }
struct UH1_RegexChar: UH1 { var f0: US0; var tag: Int32 { 2 } }
struct UH1_RegexAlt: UH1 { var f0: UH1; var f1: UH1; var tag: Int32 { 3 } }
struct UH1_RegexCat: UH1 { var f0: UH1; var f1: UH1; var tag: Int32 { 4 } }
struct UH1_RegexStar: UH1 { var f0: UH1; var tag: Int32 { 5 } }
protocol UH2 { var tag: Int32 { get } }
struct UH2_InputEmpty: UH2 { var tag: Int32 { 0 } }
struct UH2_InputCons: UH2 { var f0: US0; var f1: UH2; var tag: Int32 { 1 } }
protocol US3 { var tag: Int32 { get } }
struct US3_SymbolLess: US3 { var tag: Int32 { 0 } }
struct US3_SymbolSame: US3 { var tag: Int32 { 1 } }
struct US3_SymbolGreater: US3 { var tag: Int32 { 2 } }
protocol US4 { var tag: Int32 { get } }
struct US4_Nullable: US4 { var tag: Int32 { 0 } }
struct US4_NonNullable: US4 { var tag: Int32 { 1 } }
protocol US5 { var tag: Int32 { get } }
struct US5_TriA: US5 { var tag: Int32 { 0 } }
struct US5_TriB: US5 { var tag: Int32 { 1 } }
struct US5_TriC: US5 { var tag: Int32 { 2 } }
protocol UH6 { var tag: Int32 { get } }
struct UH6_RegexEmpty: UH6 { var tag: Int32 { 0 } }
struct UH6_RegexEpsilon: UH6 { var tag: Int32 { 1 } }
struct UH6_RegexChar: UH6 { var f0: US5; var tag: Int32 { 2 } }
struct UH6_RegexAlt: UH6 { var f0: UH6; var f1: UH6; var tag: Int32 { 3 } }
struct UH6_RegexCat: UH6 { var f0: UH6; var f1: UH6; var tag: Int32 { 4 } }
struct UH6_RegexStar: UH6 { var f0: UH6; var tag: Int32 { 5 } }
protocol UH7 { var tag: Int32 { get } }
struct UH7_InputEmpty: UH7 { var tag: Int32 { 0 } }
struct UH7_InputCons: UH7 { var f0: US5; var f1: UH7; var tag: Int32 { 1 } }
func sp_random_bit_input_1(_ p0: UInt64, _ p1: Int32, _ p2: UH2) -> (UH2, UInt64) {
    var v0: UInt64 = p0
    var v1: Int32 = p1
    var v2: UH2 = p2
    while true {
        var v3: Bool = false
        v3 = (0 < v1)
        if (v3) {
            var v4: UInt64 = (0 as UInt64)
            v4 = (v0 &* (1103515245 as UInt64))
            var v5: UInt64 = (0 as UInt64)
            v5 = (v4 &+ (12345 as UInt64))
            var v6: UInt64 = (0 as UInt64)
            v6 = (v5 & (2147483647 as UInt64))
            var v7: Int32 = 0
            v7 = (v1 &- 1)
            var v8: UInt64 = (0 as UInt64)
            v8 = (v6 >> 16)
            var v9: UInt64 = (0 as UInt64)
            v9 = (v8 & (1 as UInt64))
            var v10: Bool = false
            v10 = (v9 == (0 as UInt64))
            var v13: US0 = US0_BitZero()
            if (v10) {
                var v11: US0 = US0_BitZero()
                v11 = US0_BitZero()
                v13 = v11
            } else {
                var v12: US0 = US0_BitZero()
                v12 = US0_BitOne()
                v13 = v12
            }
            var v14: UH2 = UH2_InputEmpty()
            v14 = UH2_InputCons(f0: v13, f1: v2)
            v0 = v6
            v1 = v7
            v2 = v14
            continue
        } else {
            return (v2, v0)
        }
    }
    return (UH2_InputEmpty(), (0 as UInt64))
}
func sp_run_2(_ p0: Int32, _ p1: UH2) -> Bool {
    var v0: Int32 = p0
    var v1: UH2 = p1
    switch v1.tag {
        case 1:
            var v4: US0 = (v1 as! UH2_InputCons).f0
            var v5: UH2 = (v1 as! UH2_InputCons).f1
            var v6: Bool = false
            v6 = (v0 == 0)
            var v19: Int32 = 0
            if (v6) {
                var v10: US3 = US3_SymbolLess()
                switch v4.tag {
                    case 1:
                        v10 = US3_SymbolGreater()
                    case 0:
                        v10 = US3_SymbolSame()
                    default:
                        fatalError("unreachable union case")
                }
                var v11: Bool = false
                switch v10.tag {
                    case 1:
                        v11 = true
                    default:
                        v11 = false
                }
                if (v11) {
                    v19 = 1
                } else {
                    v19 = 0
                }
            } else {
                var v16: US3 = US3_SymbolLess()
                switch v4.tag {
                    case 1:
                        v16 = US3_SymbolGreater()
                    case 0:
                        v16 = US3_SymbolSame()
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
                    v19 = 0
                }
            }
            return sp_run_2(v19, v5)
        case 0:
            var v2: Bool = false
            v2 = (v0 == 0)
            var v3: Bool = false
            v3 = (v2 == false)
            return v3
        default:
            fatalError("unreachable union case")
    }
}
func sp_regex_compare_8(_ p0: UH1, _ p1: UH1) -> US3 {
    var v0: UH1 = p0
    var v1: UH1 = p1
    switch v0.tag {
        case 3:
            var v53: UH1 = (v0 as! UH1_RegexAlt).f0
            var v54: UH1 = (v0 as! UH1_RegexAlt).f1
            switch v1.tag {
                case 3:
                    var v55: UH1 = (v1 as! UH1_RegexAlt).f0
                    var v56: UH1 = (v1 as! UH1_RegexAlt).f1
                    var v57: US3 = US3_SymbolLess()
                    v57 = sp_regex_compare_8(v53, v55)
                    switch v57.tag {
                        case 1:
                            return sp_regex_compare_8(v54, v56)
                        default:
                            return v57
                    }
                default:
                    return US3_SymbolGreater()
            }
        case 4:
            var v28: UH1 = (v0 as! UH1_RegexCat).f0
            var v29: UH1 = (v0 as! UH1_RegexCat).f1
            switch v1.tag {
                case 4:
                    var v34: UH1 = (v1 as! UH1_RegexCat).f0
                    var v35: UH1 = (v1 as! UH1_RegexCat).f1
                    var v36: US3 = US3_SymbolLess()
                    v36 = sp_regex_compare_8(v28, v34)
                    switch v36.tag {
                        case 1:
                            return sp_regex_compare_8(v29, v35)
                        default:
                            return v36
                    }
                case 2:
                    var v32: US0 = (v1 as! UH1_RegexChar).f0
                    return US3_SymbolGreater()
                case 0:
                    return US3_SymbolGreater()
                case 1:
                    return US3_SymbolGreater()
                default:
                    return US3_SymbolLess()
            }
        case 2:
            var v10: US0 = (v0 as! UH1_RegexChar).f0
            switch v1.tag {
                case 2:
                    var v13: US0 = (v1 as! UH1_RegexChar).f0
                    switch v10.tag {
                        case 1:
                            switch v13.tag {
                                case 1:
                                    return US3_SymbolSame()
                                case 0:
                                    return US3_SymbolGreater()
                                default:
                                    fatalError("unreachable union case")
                            }
                        case 0:
                            switch v13.tag {
                                case 1:
                                    return US3_SymbolLess()
                                case 0:
                                    return US3_SymbolSame()
                                default:
                                    fatalError("unreachable union case")
                            }
                        default:
                            fatalError("unreachable union case")
                    }
                case 0:
                    return US3_SymbolGreater()
                case 1:
                    return US3_SymbolGreater()
                default:
                    return US3_SymbolLess()
            }
        case 0:
            switch v1.tag {
                case 0:
                    return US3_SymbolSame()
                default:
                    return US3_SymbolLess()
            }
        case 1:
            switch v1.tag {
                case 0:
                    return US3_SymbolGreater()
                case 1:
                    return US3_SymbolSame()
                default:
                    return US3_SymbolLess()
            }
        case 5:
            var v44: UH1 = (v0 as! UH1_RegexStar).f0
            switch v1.tag {
                case 3:
                    var v45: UH1 = (v1 as! UH1_RegexAlt).f0
                    var v46: UH1 = (v1 as! UH1_RegexAlt).f1
                    return US3_SymbolLess()
                case 5:
                    var v48: UH1 = (v1 as! UH1_RegexStar).f0
                    return sp_regex_compare_8(v44, v48)
                default:
                    return US3_SymbolGreater()
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_alt_insert_sorted_7(_ p0: UH1, _ p1: UH1) -> UH1 {
    var v0: UH1 = p0
    var v1: UH1 = p1
    switch v1.tag {
        case 3:
            var v2: UH1 = (v1 as! UH1_RegexAlt).f0
            var v3: UH1 = (v1 as! UH1_RegexAlt).f1
            var v4: US3 = US3_SymbolLess()
            v4 = sp_regex_compare_8(v0, v2)
            switch v4.tag {
                case 2:
                    var v6: UH1 = UH1_RegexEmpty()
                    v6 = sp_alt_insert_sorted_7(v0, v3)
                    return UH1_RegexAlt(f0: v2, f1: v6)
                case 0:
                    return UH1_RegexAlt(f0: v0, f1: v1)
                case 1:
                    return v1
                default:
                    fatalError("unreachable union case")
            }
        case 0:
            return v0
        default:
            var v11: US3 = US3_SymbolLess()
            v11 = sp_regex_compare_8(v0, v1)
            switch v11.tag {
                case 2:
                    return UH1_RegexAlt(f0: v1, f1: v0)
                case 0:
                    return UH1_RegexAlt(f0: v0, f1: v1)
                case 1:
                    return v1
                default:
                    fatalError("unreachable union case")
            }
    }
}
func sp_make_alt_6(_ p0: UH1, _ p1: UH1) -> UH1 {
    var v0: UH1 = p0
    var v1: UH1 = p1
    switch v0.tag {
        case 3:
            var v2: UH1 = (v0 as! UH1_RegexAlt).f0
            var v3: UH1 = (v0 as! UH1_RegexAlt).f1
            var v4: UH1 = UH1_RegexEmpty()
            v4 = sp_alt_insert_sorted_7(v2, v1)
            return sp_make_alt_6(v3, v4)
        case 0:
            return v1
        default:
            return sp_alt_insert_sorted_7(v0, v1)
    }
}
func sp_regex_equal_10(_ p0: UH1, _ p1: UH1) -> Bool {
    var v0: UH1 = p0
    var v1: UH1 = p1
    switch v0.tag {
        case 3:
            var v18: UH1 = (v0 as! UH1_RegexAlt).f0
            var v19: UH1 = (v0 as! UH1_RegexAlt).f1
            switch v1.tag {
                case 3:
                    var v20: UH1 = (v1 as! UH1_RegexAlt).f0
                    var v21: UH1 = (v1 as! UH1_RegexAlt).f1
                    var v22: Bool = false
                    v22 = sp_regex_equal_10(v18, v20)
                    if (v22) {
                        return sp_regex_equal_10(v19, v21)
                    } else {
                        return false
                    }
                default:
                    return false
            }
        case 4:
            var v26: UH1 = (v0 as! UH1_RegexCat).f0
            var v27: UH1 = (v0 as! UH1_RegexCat).f1
            switch v1.tag {
                case 4:
                    var v28: UH1 = (v1 as! UH1_RegexCat).f0
                    var v29: UH1 = (v1 as! UH1_RegexCat).f1
                    var v30: Bool = false
                    v30 = sp_regex_equal_10(v26, v28)
                    if (v30) {
                        return sp_regex_equal_10(v27, v29)
                    } else {
                        return false
                    }
                default:
                    return false
            }
        case 2:
            var v4: US0 = (v0 as! UH1_RegexChar).f0
            switch v1.tag {
                case 2:
                    var v5: US0 = (v1 as! UH1_RegexChar).f0
                    var v15: US3 = US3_SymbolLess()
                    switch v4.tag {
                        case 1:
                            switch v5.tag {
                                case 1:
                                    v15 = US3_SymbolSame()
                                case 0:
                                    v15 = US3_SymbolGreater()
                                default:
                                    fatalError("unreachable union case")
                            }
                        case 0:
                            switch v5.tag {
                                case 1:
                                    v15 = US3_SymbolLess()
                                case 0:
                                    v15 = US3_SymbolSame()
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
            var v34: UH1 = (v0 as! UH1_RegexStar).f0
            switch v1.tag {
                case 5:
                    var v35: UH1 = (v1 as! UH1_RegexStar).f0
                    return sp_regex_equal_10(v34, v35)
                default:
                    return false
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_make_cat_9(_ p0: UH1, _ p1: UH1) -> UH1 {
    var v0: UH1 = p0
    var v1: UH1 = p1
    switch v0.tag {
        case 0:
            return UH1_RegexEmpty()
        default:
            switch v1.tag {
                case 0:
                    return UH1_RegexEmpty()
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
                                            var v12: UH1 = (v0 as! UH1_RegexCat).f0
                                            var v13: UH1 = (v0 as! UH1_RegexCat).f1
                                            var v14: UH1 = UH1_RegexEmpty()
                                            v14 = sp_make_cat_9(v13, v1)
                                            return UH1_RegexCat(f0: v12, f1: v14)
                                        case 5:
                                            var v4: UH1 = (v0 as! UH1_RegexStar).f0
                                            switch v1.tag {
                                                case 5:
                                                    var v5: UH1 = (v1 as! UH1_RegexStar).f0
                                                    var v6: Bool = false
                                                    v6 = sp_regex_equal_10(v4, v5)
                                                    if (v6) {
                                                        return UH1_RegexStar(f0: v4)
                                                    } else {
                                                        return UH1_RegexCat(f0: v0, f1: v1)
                                                    }
                                                default:
                                                    return UH1_RegexCat(f0: v0, f1: v1)
                                            }
                                        default:
                                            return UH1_RegexCat(f0: v0, f1: v1)
                                    }
                            }
                    }
            }
    }
}
func sp_make_star_11(_ p0: UH1) -> UH1 {
    var v0: UH1 = p0
    switch v0.tag {
        case 0:
            return UH1_RegexEpsilon()
        case 1:
            return UH1_RegexEpsilon()
        case 5:
            var v3: UH1 = (v0 as! UH1_RegexStar).f0
            return UH1_RegexStar(f0: v3)
        default:
            return UH1_RegexStar(f0: v0)
    }
}
func sp_normalize_5(_ p0: UH1) -> UH1 {
    var v0: UH1 = p0
    switch v0.tag {
        case 3:
            var v5: UH1 = (v0 as! UH1_RegexAlt).f0
            var v6: UH1 = (v0 as! UH1_RegexAlt).f1
            var v7: UH1 = UH1_RegexEmpty()
            v7 = sp_normalize_5(v5)
            var v8: UH1 = UH1_RegexEmpty()
            v8 = sp_normalize_5(v6)
            return sp_make_alt_6(v7, v8)
        case 4:
            var v10: UH1 = (v0 as! UH1_RegexCat).f0
            var v11: UH1 = (v0 as! UH1_RegexCat).f1
            var v12: UH1 = UH1_RegexEmpty()
            v12 = sp_normalize_5(v10)
            var v13: UH1 = UH1_RegexEmpty()
            v13 = sp_normalize_5(v11)
            return sp_make_cat_9(v12, v13)
        case 2:
            var v3: US0 = (v0 as! UH1_RegexChar).f0
            return UH1_RegexChar(f0: v3)
        case 0:
            return UH1_RegexEmpty()
        case 1:
            return UH1_RegexEpsilon()
        case 5:
            var v15: UH1 = (v0 as! UH1_RegexStar).f0
            var v16: UH1 = UH1_RegexEmpty()
            v16 = sp_normalize_5(v15)
            return sp_make_star_11(v16)
        default:
            fatalError("unreachable union case")
    }
}
func sp_nullable_13(_ p0: UH1) -> US4 {
    var v0: UH1 = p0
    switch v0.tag {
        case 3:
            var v5: UH1 = (v0 as! UH1_RegexAlt).f0
            var v6: UH1 = (v0 as! UH1_RegexAlt).f1
            var v7: US4 = US4_Nullable()
            v7 = sp_nullable_13(v5)
            var v8: US4 = US4_Nullable()
            v8 = sp_nullable_13(v6)
            switch v7.tag {
                case 0:
                    return US4_Nullable()
                default:
                    switch v8.tag {
                        case 0:
                            return US4_Nullable()
                        default:
                            switch v7.tag {
                                case 1:
                                    switch v8.tag {
                                        case 1:
                                            return US4_NonNullable()
                                        default:
                                            fatalError("unreachable union case")
                                    }
                                default:
                                    fatalError("unreachable union case")
                            }
                    }
            }
        case 4:
            var v16: UH1 = (v0 as! UH1_RegexCat).f0
            var v17: UH1 = (v0 as! UH1_RegexCat).f1
            var v18: US4 = US4_Nullable()
            v18 = sp_nullable_13(v16)
            var v19: US4 = US4_Nullable()
            v19 = sp_nullable_13(v17)
            switch v18.tag {
                case 0:
                    switch v19.tag {
                        case 0:
                            return US4_Nullable()
                        default:
                            return US4_NonNullable()
                    }
                default:
                    return US4_NonNullable()
            }
        case 2:
            var v3: US0 = (v0 as! UH1_RegexChar).f0
            return US4_NonNullable()
        case 0:
            return US4_NonNullable()
        case 1:
            return US4_Nullable()
        case 5:
            var v25: UH1 = (v0 as! UH1_RegexStar).f0
            return US4_Nullable()
        default:
            fatalError("unreachable union case")
    }
}
func sp_derivative_12(_ p0: UH1, _ p1: US0) -> UH1 {
    var v0: UH1 = p0
    var v1: US0 = p1
    switch v0.tag {
        case 3:
            var v19: UH1 = (v0 as! UH1_RegexAlt).f0
            var v20: UH1 = (v0 as! UH1_RegexAlt).f1
            var v21: UH1 = UH1_RegexEmpty()
            v21 = sp_derivative_12(v19, v1)
            var v22: UH1 = UH1_RegexEmpty()
            v22 = sp_derivative_12(v20, v1)
            return sp_make_alt_6(v21, v22)
        case 4:
            var v24: UH1 = (v0 as! UH1_RegexCat).f0
            var v25: UH1 = (v0 as! UH1_RegexCat).f1
            var v26: US4 = US4_Nullable()
            v26 = sp_nullable_13(v24)
            switch v26.tag {
                case 1:
                    var v31: UH1 = UH1_RegexEmpty()
                    v31 = sp_derivative_12(v24, v1)
                    return sp_make_cat_9(v31, v25)
                case 0:
                    var v27: UH1 = UH1_RegexEmpty()
                    v27 = sp_derivative_12(v24, v1)
                    var v28: UH1 = UH1_RegexEmpty()
                    v28 = sp_make_cat_9(v27, v25)
                    var v29: UH1 = UH1_RegexEmpty()
                    v29 = sp_derivative_12(v25, v1)
                    return sp_make_alt_6(v28, v29)
                default:
                    fatalError("unreachable union case")
            }
        case 2:
            var v4: US0 = (v0 as! UH1_RegexChar).f0
            var v14: US3 = US3_SymbolLess()
            switch v4.tag {
                case 1:
                    switch v1.tag {
                        case 1:
                            v14 = US3_SymbolSame()
                        case 0:
                            v14 = US3_SymbolGreater()
                        default:
                            fatalError("unreachable union case")
                    }
                case 0:
                    switch v1.tag {
                        case 1:
                            v14 = US3_SymbolLess()
                        case 0:
                            v14 = US3_SymbolSame()
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
                return UH1_RegexEpsilon()
            } else {
                return UH1_RegexEmpty()
            }
        case 0:
            return UH1_RegexEmpty()
        case 1:
            return UH1_RegexEmpty()
        case 5:
            var v35: UH1 = (v0 as! UH1_RegexStar).f0
            var v36: UH1 = UH1_RegexEmpty()
            v36 = sp_derivative_12(v35, v1)
            var v37: UH1 = UH1_RegexEmpty()
            v37 = sp_make_star_11(v35)
            return sp_make_cat_9(v36, v37)
        default:
            fatalError("unreachable union case")
    }
}
func sp_canonical_derivative_4(_ p0: UH1, _ p1: US0) -> UH1 {
    var v0: UH1 = p0
    var v1: US0 = p1
    var v2: UH1 = UH1_RegexEmpty()
    v2 = sp_normalize_5(v0)
    var v3: UH1 = UH1_RegexEmpty()
    v3 = sp_derivative_12(v2, v1)
    return sp_normalize_5(v3)
}
func sp_accepts_3(_ p0: UH1, _ p1: UH2) -> Bool {
    var v0: UH1 = p0
    var v1: UH2 = p1
    switch v1.tag {
        case 1:
            var v6: US0 = (v1 as! UH2_InputCons).f0
            var v7: UH2 = (v1 as! UH2_InputCons).f1
            var v8: UH1 = UH1_RegexEmpty()
            v8 = sp_canonical_derivative_4(v0, v6)
            return sp_accepts_3(v8, v7)
        case 0:
            var v2: UH1 = UH1_RegexEmpty()
            v2 = sp_normalize_5(v0)
            var v3: US4 = US4_Nullable()
            v3 = sp_nullable_13(v2)
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
func sp_loop_0(_ p0: Int32, _ p1: UH1, _ p2: Int32, _ p3: UInt64, _ p4: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: UH1 = p1
    var v2: Int32 = p2
    var v3: UInt64 = p3
    var v4: Int32 = p4
    while true {
        var v5: Bool = false
        v5 = (0 < v2)
        if (v5) {
            var v6: UH2 = UH2_InputEmpty()
            v6 = UH2_InputEmpty()
            var v7: UH2 = UH2_InputEmpty()
            var v8: UInt64 = (0 as UInt64)
            let spiral_tuple467 = sp_random_bit_input_1(v3, v0, v6)
            v7 = spiral_tuple467.0
            v8 = spiral_tuple467.1
            var v9: Int32 = 0
            v9 = 0
            var v10: Bool = false
            v10 = sp_run_2(v9, v7)
            var v11: Bool = false
            v11 = sp_accepts_3(v1, v7)
            var v13: Bool = false
            if (v10) {
                v13 = v11
            } else {
                var v12: Bool = false
                v12 = (false == v11)
                v13 = v12
            }
            if (v13) {
                var v14: Int32 = 0
                v14 = (v2 &- 1)
                var v16: Int32 = 0
                if (v10) {
                    var v15: Int32 = 0
                    v15 = (v4 &+ 1)
                    v16 = v15
                } else {
                    v16 = v4
                }
                v2 = v14
                v3 = v8
                v4 = v16
                continue
            } else {
                "brzozowski-compiled-core-disagrees-on-random-input".withCString { ptr in _ = fputs(ptr, stderr) }
                fputs("\n", stderr)
                exit(1)
            }
        } else {
            return v4
        }
    }
    return 0
}
func sp_zeros_input_15(_ p0: Int32, _ p1: UH2) -> UH2 {
    var v0: Int32 = p0
    var v1: UH2 = p1
    while true {
        var v2: Bool = false
        v2 = (0 < v0)
        if (v2) {
            var v3: Int32 = 0
            v3 = (v0 &- 1)
            var v4: US0 = US0_BitZero()
            v4 = US0_BitZero()
            var v5: UH2 = UH2_InputEmpty()
            v5 = UH2_InputCons(f0: v4, f1: v1)
            v0 = v3
            v1 = v5
            continue
        } else {
            return v1
        }
    }
    return UH2_InputEmpty()
}
func sp_run_16(_ p0: Int32, _ p1: UH2) -> Bool {
    var v0: Int32 = p0
    var v1: UH2 = p1
    switch v1.tag {
        case 1:
            var v5: US0 = (v1 as! UH2_InputCons).f0
            var v6: UH2 = (v1 as! UH2_InputCons).f1
            var v7: Bool = false
            v7 = (v0 == 0)
            var v26: Int32 = 0
            if (v7) {
                v26 = 1
            } else {
                var v13: Bool = false
                v13 = (v0 == 1)
                if (v13) {
                    v26 = 1
                } else {
                    var v22: US3 = US3_SymbolLess()
                    switch v5.tag {
                        case 1:
                            v22 = US3_SymbolGreater()
                        case 0:
                            v22 = US3_SymbolSame()
                        default:
                            fatalError("unreachable union case")
                    }
                    var v23: Bool = false
                    switch v22.tag {
                        case 1:
                            v23 = true
                        default:
                            v23 = false
                    }
                    if (v23) {
                        v26 = 2
                    } else {
                        v26 = 0
                    }
                }
            }
            return sp_run_16(v26, v6)
        case 0:
            var v2: Bool = false
            v2 = (v0 == 0)
            if (v2) {
                return true
            } else {
                return false
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_loop_14(_ p0: Int32, _ p1: UH1, _ p2: Int32, _ p3: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: UH1 = p1
    var v2: Int32 = p2
    var v3: Int32 = p3
    while true {
        var v4: Bool = false
        v4 = (v0 < v2)
        if (v4) {
            return v3
        } else {
            var v5: UH2 = UH2_InputEmpty()
            v5 = UH2_InputEmpty()
            var v6: UH2 = UH2_InputEmpty()
            v6 = sp_zeros_input_15(v2, v5)
            var v7: Int32 = 0
            v7 = 2
            var v8: Bool = false
            v8 = sp_run_16(v7, v6)
            var v9: Bool = false
            v9 = sp_accepts_3(v1, v6)
            var v11: Bool = false
            if (v8) {
                v11 = v9
            } else {
                var v10: Bool = false
                v10 = (false == v9)
                v11 = v10
            }
            var v15: Int32 = 0
            if (v11) {
                if (v8) {
                    var v12: Int32 = 0
                    v12 = (v3 &+ 1)
                    v15 = v12
                } else {
                    v15 = v3
                }
            } else {
                "brzozowski-compiled-core-disagrees-on-zero-run".withCString { ptr in _ = fputs(ptr, stderr) }
                fputs("\n", stderr)
                exit(1)
            }
            var v16: US0 = US0_BitZero()
            v16 = US0_BitOne()
            var v17: UH2 = UH2_InputEmpty()
            v17 = UH2_InputEmpty()
            var v18: UH2 = UH2_InputEmpty()
            v18 = UH2_InputCons(f0: v16, f1: v17)
            var v19: UH2 = UH2_InputEmpty()
            v19 = sp_zeros_input_15(v2, v18)
            var v20: Int32 = 0
            v20 = 2
            var v21: Bool = false
            v21 = sp_run_16(v20, v19)
            var v22: Bool = false
            v22 = sp_accepts_3(v1, v19)
            var v24: Bool = false
            if (v21) {
                v24 = v22
            } else {
                var v23: Bool = false
                v23 = (false == v22)
                v24 = v23
            }
            var v28: Int32 = 0
            if (v24) {
                if (v21) {
                    var v25: Int32 = 0
                    v25 = (v15 &+ 1)
                    v28 = v25
                } else {
                    v28 = v15
                }
            } else {
                "brzozowski-compiled-core-disagrees-on-zero-run".withCString { ptr in _ = fputs(ptr, stderr) }
                fputs("\n", stderr)
                exit(1)
            }
            var v29: Int32 = 0
            v29 = (v2 &+ 1)
            v2 = v29
            v3 = v28
            continue
        }
    }
    return 0
}
func sp_run_17(_ p0: Int32, _ p1: UH7) -> Bool {
    var v0: Int32 = p0
    var v1: UH7 = p1
    switch v1.tag {
        case 1:
            var v5: US5 = (v1 as! UH7_InputCons).f0
            var v6: UH7 = (v1 as! UH7_InputCons).f1
            var v7: Bool = false
            v7 = (v0 == 0)
            var v47: Int32 = 0
            if (v7) {
                var v10: US3 = US3_SymbolLess()
                switch v5.tag {
                    case 0:
                        v10 = US3_SymbolSame()
                    default:
                        v10 = US3_SymbolGreater()
                }
                var v11: Bool = false
                switch v10.tag {
                    case 1:
                        v11 = true
                    default:
                        v11 = false
                }
                if (v11) {
                    v47 = 0
                } else {
                    var v17: US3 = US3_SymbolLess()
                    switch v5.tag {
                        case 0:
                            v17 = US3_SymbolLess()
                        case 1:
                            v17 = US3_SymbolSame()
                        case 2:
                            v17 = US3_SymbolGreater()
                        default:
                            fatalError("unreachable union case")
                    }
                    var v18: Bool = false
                    switch v17.tag {
                        case 1:
                            v18 = true
                        default:
                            v18 = false
                    }
                    if (v18) {
                        v47 = 0
                    } else {
                        v47 = 1
                    }
                }
            } else {
                var v21: Bool = false
                v21 = (v0 == 1)
                if (v21) {
                    var v24: US3 = US3_SymbolLess()
                    switch v5.tag {
                        case 0:
                            v24 = US3_SymbolSame()
                        default:
                            v24 = US3_SymbolGreater()
                    }
                    var v25: Bool = false
                    switch v24.tag {
                        case 1:
                            v25 = true
                        default:
                            v25 = false
                    }
                    if (v25) {
                        v47 = 2
                    } else {
                        v47 = 2
                    }
                } else {
                    var v36: US3 = US3_SymbolLess()
                    switch v5.tag {
                        case 0:
                            v36 = US3_SymbolSame()
                        default:
                            v36 = US3_SymbolGreater()
                    }
                    var v37: Bool = false
                    switch v36.tag {
                        case 1:
                            v37 = true
                        default:
                            v37 = false
                    }
                    if (v37) {
                        v47 = 2
                    } else {
                        v47 = 2
                    }
                }
            }
            return sp_run_17(v47, v6)
        case 0:
            var v2: Bool = false
            v2 = (v0 == 0)
            if (v2) {
                return false
            } else {
                var v3: Bool = false
                v3 = (v0 == 1)
                return v3
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_regex_compare_23(_ p0: UH6, _ p1: UH6) -> US3 {
    var v0: UH6 = p0
    var v1: UH6 = p1
    switch v0.tag {
        case 3:
            var v59: UH6 = (v0 as! UH6_RegexAlt).f0
            var v60: UH6 = (v0 as! UH6_RegexAlt).f1
            switch v1.tag {
                case 3:
                    var v61: UH6 = (v1 as! UH6_RegexAlt).f0
                    var v62: UH6 = (v1 as! UH6_RegexAlt).f1
                    var v63: US3 = US3_SymbolLess()
                    v63 = sp_regex_compare_23(v59, v61)
                    switch v63.tag {
                        case 1:
                            return sp_regex_compare_23(v60, v62)
                        default:
                            return v63
                    }
                default:
                    return US3_SymbolGreater()
            }
        case 4:
            var v34: UH6 = (v0 as! UH6_RegexCat).f0
            var v35: UH6 = (v0 as! UH6_RegexCat).f1
            switch v1.tag {
                case 4:
                    var v40: UH6 = (v1 as! UH6_RegexCat).f0
                    var v41: UH6 = (v1 as! UH6_RegexCat).f1
                    var v42: US3 = US3_SymbolLess()
                    v42 = sp_regex_compare_23(v34, v40)
                    switch v42.tag {
                        case 1:
                            return sp_regex_compare_23(v35, v41)
                        default:
                            return v42
                    }
                case 2:
                    var v38: US5 = (v1 as! UH6_RegexChar).f0
                    return US3_SymbolGreater()
                case 0:
                    return US3_SymbolGreater()
                case 1:
                    return US3_SymbolGreater()
                default:
                    return US3_SymbolLess()
            }
        case 2:
            var v10: US5 = (v0 as! UH6_RegexChar).f0
            switch v1.tag {
                case 2:
                    var v13: US5 = (v1 as! UH6_RegexChar).f0
                    switch v10.tag {
                        case 0:
                            switch v13.tag {
                                case 0:
                                    return US3_SymbolSame()
                                default:
                                    return US3_SymbolLess()
                            }
                        default:
                            switch v13.tag {
                                case 0:
                                    return US3_SymbolGreater()
                                default:
                                    switch v10.tag {
                                        case 1:
                                            switch v13.tag {
                                                case 1:
                                                    return US3_SymbolSame()
                                                case 2:
                                                    return US3_SymbolLess()
                                                default:
                                                    fatalError("unreachable union case")
                                            }
                                        case 2:
                                            switch v13.tag {
                                                case 1:
                                                    return US3_SymbolGreater()
                                                case 2:
                                                    return US3_SymbolSame()
                                                default:
                                                    fatalError("unreachable union case")
                                            }
                                        default:
                                            fatalError("unreachable union case")
                                    }
                            }
                    }
                case 0:
                    return US3_SymbolGreater()
                case 1:
                    return US3_SymbolGreater()
                default:
                    return US3_SymbolLess()
            }
        case 0:
            switch v1.tag {
                case 0:
                    return US3_SymbolSame()
                default:
                    return US3_SymbolLess()
            }
        case 1:
            switch v1.tag {
                case 0:
                    return US3_SymbolGreater()
                case 1:
                    return US3_SymbolSame()
                default:
                    return US3_SymbolLess()
            }
        case 5:
            var v50: UH6 = (v0 as! UH6_RegexStar).f0
            switch v1.tag {
                case 3:
                    var v51: UH6 = (v1 as! UH6_RegexAlt).f0
                    var v52: UH6 = (v1 as! UH6_RegexAlt).f1
                    return US3_SymbolLess()
                case 5:
                    var v54: UH6 = (v1 as! UH6_RegexStar).f0
                    return sp_regex_compare_23(v50, v54)
                default:
                    return US3_SymbolGreater()
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_alt_insert_sorted_22(_ p0: UH6, _ p1: UH6) -> UH6 {
    var v0: UH6 = p0
    var v1: UH6 = p1
    switch v1.tag {
        case 3:
            var v2: UH6 = (v1 as! UH6_RegexAlt).f0
            var v3: UH6 = (v1 as! UH6_RegexAlt).f1
            var v4: US3 = US3_SymbolLess()
            v4 = sp_regex_compare_23(v0, v2)
            switch v4.tag {
                case 2:
                    var v6: UH6 = UH6_RegexEmpty()
                    v6 = sp_alt_insert_sorted_22(v0, v3)
                    return UH6_RegexAlt(f0: v2, f1: v6)
                case 0:
                    return UH6_RegexAlt(f0: v0, f1: v1)
                case 1:
                    return v1
                default:
                    fatalError("unreachable union case")
            }
        case 0:
            return v0
        default:
            var v11: US3 = US3_SymbolLess()
            v11 = sp_regex_compare_23(v0, v1)
            switch v11.tag {
                case 2:
                    return UH6_RegexAlt(f0: v1, f1: v0)
                case 0:
                    return UH6_RegexAlt(f0: v0, f1: v1)
                case 1:
                    return v1
                default:
                    fatalError("unreachable union case")
            }
    }
}
func sp_make_alt_21(_ p0: UH6, _ p1: UH6) -> UH6 {
    var v0: UH6 = p0
    var v1: UH6 = p1
    switch v0.tag {
        case 3:
            var v2: UH6 = (v0 as! UH6_RegexAlt).f0
            var v3: UH6 = (v0 as! UH6_RegexAlt).f1
            var v4: UH6 = UH6_RegexEmpty()
            v4 = sp_alt_insert_sorted_22(v2, v1)
            return sp_make_alt_21(v3, v4)
        case 0:
            return v1
        default:
            return sp_alt_insert_sorted_22(v0, v1)
    }
}
func sp_regex_equal_25(_ p0: UH6, _ p1: UH6) -> Bool {
    var v0: UH6 = p0
    var v1: UH6 = p1
    switch v0.tag {
        case 3:
            var v24: UH6 = (v0 as! UH6_RegexAlt).f0
            var v25: UH6 = (v0 as! UH6_RegexAlt).f1
            switch v1.tag {
                case 3:
                    var v26: UH6 = (v1 as! UH6_RegexAlt).f0
                    var v27: UH6 = (v1 as! UH6_RegexAlt).f1
                    var v28: Bool = false
                    v28 = sp_regex_equal_25(v24, v26)
                    if (v28) {
                        return sp_regex_equal_25(v25, v27)
                    } else {
                        return false
                    }
                default:
                    return false
            }
        case 4:
            var v32: UH6 = (v0 as! UH6_RegexCat).f0
            var v33: UH6 = (v0 as! UH6_RegexCat).f1
            switch v1.tag {
                case 4:
                    var v34: UH6 = (v1 as! UH6_RegexCat).f0
                    var v35: UH6 = (v1 as! UH6_RegexCat).f1
                    var v36: Bool = false
                    v36 = sp_regex_equal_25(v32, v34)
                    if (v36) {
                        return sp_regex_equal_25(v33, v35)
                    } else {
                        return false
                    }
                default:
                    return false
            }
        case 2:
            var v4: US5 = (v0 as! UH6_RegexChar).f0
            switch v1.tag {
                case 2:
                    var v5: US5 = (v1 as! UH6_RegexChar).f0
                    var v21: US3 = US3_SymbolLess()
                    switch v4.tag {
                        case 0:
                            switch v5.tag {
                                case 0:
                                    v21 = US3_SymbolSame()
                                default:
                                    v21 = US3_SymbolLess()
                            }
                        default:
                            switch v5.tag {
                                case 0:
                                    v21 = US3_SymbolGreater()
                                default:
                                    switch v4.tag {
                                        case 1:
                                            switch v5.tag {
                                                case 1:
                                                    v21 = US3_SymbolSame()
                                                case 2:
                                                    v21 = US3_SymbolLess()
                                                default:
                                                    fatalError("unreachable union case")
                                            }
                                        case 2:
                                            switch v5.tag {
                                                case 1:
                                                    v21 = US3_SymbolGreater()
                                                case 2:
                                                    v21 = US3_SymbolSame()
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
            var v40: UH6 = (v0 as! UH6_RegexStar).f0
            switch v1.tag {
                case 5:
                    var v41: UH6 = (v1 as! UH6_RegexStar).f0
                    return sp_regex_equal_25(v40, v41)
                default:
                    return false
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_make_cat_24(_ p0: UH6, _ p1: UH6) -> UH6 {
    var v0: UH6 = p0
    var v1: UH6 = p1
    switch v0.tag {
        case 0:
            return UH6_RegexEmpty()
        default:
            switch v1.tag {
                case 0:
                    return UH6_RegexEmpty()
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
                                            var v12: UH6 = (v0 as! UH6_RegexCat).f0
                                            var v13: UH6 = (v0 as! UH6_RegexCat).f1
                                            var v14: UH6 = UH6_RegexEmpty()
                                            v14 = sp_make_cat_24(v13, v1)
                                            return UH6_RegexCat(f0: v12, f1: v14)
                                        case 5:
                                            var v4: UH6 = (v0 as! UH6_RegexStar).f0
                                            switch v1.tag {
                                                case 5:
                                                    var v5: UH6 = (v1 as! UH6_RegexStar).f0
                                                    var v6: Bool = false
                                                    v6 = sp_regex_equal_25(v4, v5)
                                                    if (v6) {
                                                        return UH6_RegexStar(f0: v4)
                                                    } else {
                                                        return UH6_RegexCat(f0: v0, f1: v1)
                                                    }
                                                default:
                                                    return UH6_RegexCat(f0: v0, f1: v1)
                                            }
                                        default:
                                            return UH6_RegexCat(f0: v0, f1: v1)
                                    }
                            }
                    }
            }
    }
}
func sp_make_star_26(_ p0: UH6) -> UH6 {
    var v0: UH6 = p0
    switch v0.tag {
        case 0:
            return UH6_RegexEpsilon()
        case 1:
            return UH6_RegexEpsilon()
        case 5:
            var v3: UH6 = (v0 as! UH6_RegexStar).f0
            return UH6_RegexStar(f0: v3)
        default:
            return UH6_RegexStar(f0: v0)
    }
}
func sp_normalize_20(_ p0: UH6) -> UH6 {
    var v0: UH6 = p0
    switch v0.tag {
        case 3:
            var v5: UH6 = (v0 as! UH6_RegexAlt).f0
            var v6: UH6 = (v0 as! UH6_RegexAlt).f1
            var v7: UH6 = UH6_RegexEmpty()
            v7 = sp_normalize_20(v5)
            var v8: UH6 = UH6_RegexEmpty()
            v8 = sp_normalize_20(v6)
            return sp_make_alt_21(v7, v8)
        case 4:
            var v10: UH6 = (v0 as! UH6_RegexCat).f0
            var v11: UH6 = (v0 as! UH6_RegexCat).f1
            var v12: UH6 = UH6_RegexEmpty()
            v12 = sp_normalize_20(v10)
            var v13: UH6 = UH6_RegexEmpty()
            v13 = sp_normalize_20(v11)
            return sp_make_cat_24(v12, v13)
        case 2:
            var v3: US5 = (v0 as! UH6_RegexChar).f0
            return UH6_RegexChar(f0: v3)
        case 0:
            return UH6_RegexEmpty()
        case 1:
            return UH6_RegexEpsilon()
        case 5:
            var v15: UH6 = (v0 as! UH6_RegexStar).f0
            var v16: UH6 = UH6_RegexEmpty()
            v16 = sp_normalize_20(v15)
            return sp_make_star_26(v16)
        default:
            fatalError("unreachable union case")
    }
}
func sp_nullable_28(_ p0: UH6) -> US4 {
    var v0: UH6 = p0
    switch v0.tag {
        case 3:
            var v5: UH6 = (v0 as! UH6_RegexAlt).f0
            var v6: UH6 = (v0 as! UH6_RegexAlt).f1
            var v7: US4 = US4_Nullable()
            v7 = sp_nullable_28(v5)
            var v8: US4 = US4_Nullable()
            v8 = sp_nullable_28(v6)
            switch v7.tag {
                case 0:
                    return US4_Nullable()
                default:
                    switch v8.tag {
                        case 0:
                            return US4_Nullable()
                        default:
                            switch v7.tag {
                                case 1:
                                    switch v8.tag {
                                        case 1:
                                            return US4_NonNullable()
                                        default:
                                            fatalError("unreachable union case")
                                    }
                                default:
                                    fatalError("unreachable union case")
                            }
                    }
            }
        case 4:
            var v16: UH6 = (v0 as! UH6_RegexCat).f0
            var v17: UH6 = (v0 as! UH6_RegexCat).f1
            var v18: US4 = US4_Nullable()
            v18 = sp_nullable_28(v16)
            var v19: US4 = US4_Nullable()
            v19 = sp_nullable_28(v17)
            switch v18.tag {
                case 0:
                    switch v19.tag {
                        case 0:
                            return US4_Nullable()
                        default:
                            return US4_NonNullable()
                    }
                default:
                    return US4_NonNullable()
            }
        case 2:
            var v3: US5 = (v0 as! UH6_RegexChar).f0
            return US4_NonNullable()
        case 0:
            return US4_NonNullable()
        case 1:
            return US4_Nullable()
        case 5:
            var v25: UH6 = (v0 as! UH6_RegexStar).f0
            return US4_Nullable()
        default:
            fatalError("unreachable union case")
    }
}
func sp_derivative_27(_ p0: UH6, _ p1: US5) -> UH6 {
    var v0: UH6 = p0
    var v1: US5 = p1
    switch v0.tag {
        case 3:
            var v25: UH6 = (v0 as! UH6_RegexAlt).f0
            var v26: UH6 = (v0 as! UH6_RegexAlt).f1
            var v27: UH6 = UH6_RegexEmpty()
            v27 = sp_derivative_27(v25, v1)
            var v28: UH6 = UH6_RegexEmpty()
            v28 = sp_derivative_27(v26, v1)
            return sp_make_alt_21(v27, v28)
        case 4:
            var v30: UH6 = (v0 as! UH6_RegexCat).f0
            var v31: UH6 = (v0 as! UH6_RegexCat).f1
            var v32: US4 = US4_Nullable()
            v32 = sp_nullable_28(v30)
            switch v32.tag {
                case 1:
                    var v37: UH6 = UH6_RegexEmpty()
                    v37 = sp_derivative_27(v30, v1)
                    return sp_make_cat_24(v37, v31)
                case 0:
                    var v33: UH6 = UH6_RegexEmpty()
                    v33 = sp_derivative_27(v30, v1)
                    var v34: UH6 = UH6_RegexEmpty()
                    v34 = sp_make_cat_24(v33, v31)
                    var v35: UH6 = UH6_RegexEmpty()
                    v35 = sp_derivative_27(v31, v1)
                    return sp_make_alt_21(v34, v35)
                default:
                    fatalError("unreachable union case")
            }
        case 2:
            var v4: US5 = (v0 as! UH6_RegexChar).f0
            var v20: US3 = US3_SymbolLess()
            switch v4.tag {
                case 0:
                    switch v1.tag {
                        case 0:
                            v20 = US3_SymbolSame()
                        default:
                            v20 = US3_SymbolLess()
                    }
                default:
                    switch v1.tag {
                        case 0:
                            v20 = US3_SymbolGreater()
                        default:
                            switch v4.tag {
                                case 1:
                                    switch v1.tag {
                                        case 1:
                                            v20 = US3_SymbolSame()
                                        case 2:
                                            v20 = US3_SymbolLess()
                                        default:
                                            fatalError("unreachable union case")
                                    }
                                case 2:
                                    switch v1.tag {
                                        case 1:
                                            v20 = US3_SymbolGreater()
                                        case 2:
                                            v20 = US3_SymbolSame()
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
                return UH6_RegexEpsilon()
            } else {
                return UH6_RegexEmpty()
            }
        case 0:
            return UH6_RegexEmpty()
        case 1:
            return UH6_RegexEmpty()
        case 5:
            var v41: UH6 = (v0 as! UH6_RegexStar).f0
            var v42: UH6 = UH6_RegexEmpty()
            v42 = sp_derivative_27(v41, v1)
            var v43: UH6 = UH6_RegexEmpty()
            v43 = sp_make_star_26(v41)
            return sp_make_cat_24(v42, v43)
        default:
            fatalError("unreachable union case")
    }
}
func sp_canonical_derivative_19(_ p0: UH6, _ p1: US5) -> UH6 {
    var v0: UH6 = p0
    var v1: US5 = p1
    var v2: UH6 = UH6_RegexEmpty()
    v2 = sp_normalize_20(v0)
    var v3: UH6 = UH6_RegexEmpty()
    v3 = sp_derivative_27(v2, v1)
    return sp_normalize_20(v3)
}
func sp_accepts_18(_ p0: UH6, _ p1: UH7) -> Bool {
    var v0: UH6 = p0
    var v1: UH7 = p1
    switch v1.tag {
        case 1:
            var v6: US5 = (v1 as! UH7_InputCons).f0
            var v7: UH7 = (v1 as! UH7_InputCons).f1
            var v8: UH6 = UH6_RegexEmpty()
            v8 = sp_canonical_derivative_19(v0, v6)
            return sp_accepts_18(v8, v7)
        case 0:
            var v2: UH6 = UH6_RegexEmpty()
            v2 = sp_normalize_20(v0)
            var v3: US4 = US4_Nullable()
            v3 = sp_nullable_28(v2)
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
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 200
    var v1: Int32 = 0
    v1 = 32
    var v2: Int32 = 0
    v2 = 16
    var v3: US0 = US0_BitZero()
    v3 = US0_BitZero()
    var v4: UH1 = UH1_RegexEmpty()
    v4 = UH1_RegexChar(f0: v3)
    var v5: US0 = US0_BitZero()
    v5 = US0_BitOne()
    var v6: UH1 = UH1_RegexEmpty()
    v6 = UH1_RegexChar(f0: v5)
    var v7: UH1 = UH1_RegexEmpty()
    v7 = UH1_RegexAlt(f0: v4, f1: v6)
    var v8: UH1 = UH1_RegexEmpty()
    v8 = UH1_RegexStar(f0: v7)
    var v9: US0 = US0_BitZero()
    v9 = US0_BitZero()
    var v10: UH1 = UH1_RegexEmpty()
    v10 = UH1_RegexChar(f0: v9)
    var v11: UH1 = UH1_RegexEmpty()
    v11 = UH1_RegexCat(f0: v8, f1: v10)
    var v12: UInt64 = (0 as UInt64)
    v12 = (1 as UInt64)
    var v13: Int32 = 0
    v13 = 0
    var v14: Int32 = 0
    v14 = sp_loop_0(v1, v11, v0, v12, v13)
    var v15: Bool = false
    v15 = (v14 == 93)
    if (v15) {
    } else {
        "brzozowski-compiled-ends-with-zero-count".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    var v16: US0 = US0_BitZero()
    v16 = US0_BitZero()
    var v17: UH1 = UH1_RegexEmpty()
    v17 = UH1_RegexChar(f0: v16)
    var v18: US0 = US0_BitZero()
    v18 = US0_BitZero()
    var v19: UH1 = UH1_RegexEmpty()
    v19 = UH1_RegexChar(f0: v18)
    var v20: US0 = US0_BitZero()
    v20 = US0_BitZero()
    var v21: UH1 = UH1_RegexEmpty()
    v21 = UH1_RegexChar(f0: v20)
    var v22: UH1 = UH1_RegexEmpty()
    v22 = UH1_RegexCat(f0: v19, f1: v21)
    var v23: UH1 = UH1_RegexEmpty()
    v23 = UH1_RegexAlt(f0: v17, f1: v22)
    var v24: UH1 = UH1_RegexEmpty()
    v24 = UH1_RegexStar(f0: v23)
    var v25: US0 = US0_BitZero()
    v25 = US0_BitOne()
    var v26: UH1 = UH1_RegexEmpty()
    v26 = UH1_RegexChar(f0: v25)
    var v27: UH1 = UH1_RegexEmpty()
    v27 = UH1_RegexCat(f0: v24, f1: v26)
    var v28: Int32 = 0
    v28 = 1
    var v29: Int32 = 0
    v29 = 0
    var v30: Int32 = 0
    v30 = sp_loop_14(v2, v27, v28, v29)
    var v31: Bool = false
    v31 = (v30 == 16)
    if (v31) {
    } else {
        "brzozowski-compiled-zero-runs-count".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    var v32: US5 = US5_TriA()
    v32 = US5_TriA()
    var v33: UH6 = UH6_RegexEmpty()
    v33 = UH6_RegexChar(f0: v32)
    var v34: US5 = US5_TriA()
    v34 = US5_TriB()
    var v35: UH6 = UH6_RegexEmpty()
    v35 = UH6_RegexChar(f0: v34)
    var v36: UH6 = UH6_RegexEmpty()
    v36 = UH6_RegexAlt(f0: v33, f1: v35)
    var v37: UH6 = UH6_RegexEmpty()
    v37 = UH6_RegexStar(f0: v36)
    let v38: US5 = US5_TriC()
    let v39: UH6 = UH6_RegexChar(f0: v38)
    let v40: UH6 = UH6_RegexCat(f0: v37, f1: v39)
    let v41: US5 = US5_TriA()
    var v42: US5 = US5_TriA()
    v42 = US5_TriB()
    var v43: US5 = US5_TriA()
    v43 = US5_TriA()
    let v44: US5 = US5_TriC()
    let v45: UH7 = UH7_InputEmpty()
    let v46: UH7 = UH7_InputCons(f0: v44, f1: v45)
    var v47: UH7 = UH7_InputEmpty()
    v47 = UH7_InputCons(f0: v43, f1: v46)
    let v48: UH7 = UH7_InputCons(f0: v42, f1: v47)
    let v49: UH7 = UH7_InputCons(f0: v41, f1: v48)
    let v50: US5 = US5_TriA()
    let v51: US5 = US5_TriB()
    let v52: US5 = US5_TriA()
    let v53: US5 = US5_TriB()
    let v54: UH7 = UH7_InputEmpty()
    let v55: UH7 = UH7_InputCons(f0: v53, f1: v54)
    let v56: UH7 = UH7_InputCons(f0: v52, f1: v55)
    var v57: UH7 = UH7_InputEmpty()
    v57 = UH7_InputCons(f0: v51, f1: v56)
    let v58: UH7 = UH7_InputCons(f0: v50, f1: v57)
    let v59: Int32 = 0
    let v60: Bool = sp_run_17(v59, v49)
    var v62: Bool = false
    if (v60) {
        v62 = sp_accepts_18(v40, v49)
    } else {
        v62 = false
    }
    var v68: Bool = false
    if (v62) {
        var v63: Int32 = 0
        v63 = 0
        let v64: Bool = sp_run_17(v63, v58)
        if (v64) {
            v68 = false
        } else {
            let v65: Bool = sp_accepts_18(v40, v58)
            let v66: Bool = (v65 == false)
            v68 = v66
        }
    } else {
        v68 = false
    }
    if (v68) {
        return 0
    } else {
        "brzozowski-compiled-ternary-disagrees".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
