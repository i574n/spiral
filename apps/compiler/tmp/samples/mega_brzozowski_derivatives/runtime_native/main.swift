import CRT
import WinSDK
protocol US0 { var tag: Int32 { get } }
struct US0_BitZero: US0 { var tag: Int32 { 0 } }
struct US0_BitOne: US0 { var tag: Int32 { 1 } }
protocol UH1 { var tag: Int32 { get } }
struct UH1_InputEmpty: UH1 { var tag: Int32 { 0 } }
struct UH1_InputCons: UH1 { var f0: US0; var f1: UH1; var tag: Int32 { 1 } }
protocol US2 { var tag: Int32 { get } }
struct US2_TriA: US2 { var tag: Int32 { 0 } }
struct US2_TriB: US2 { var tag: Int32 { 1 } }
struct US2_TriC: US2 { var tag: Int32 { 2 } }
protocol UH3 { var tag: Int32 { get } }
struct UH3_InputEmpty: UH3 { var tag: Int32 { 0 } }
struct UH3_InputCons: UH3 { var f0: US2; var f1: UH3; var tag: Int32 { 1 } }
protocol UH4 { var tag: Int32 { get } }
struct UH4_RegexEmpty: UH4 { var tag: Int32 { 0 } }
struct UH4_RegexEpsilon: UH4 { var tag: Int32 { 1 } }
struct UH4_RegexChar: UH4 { var f0: US0; var tag: Int32 { 2 } }
struct UH4_RegexAlt: UH4 { var f0: UH4; var f1: UH4; var tag: Int32 { 3 } }
struct UH4_RegexCat: UH4 { var f0: UH4; var f1: UH4; var tag: Int32 { 4 } }
struct UH4_RegexStar: UH4 { var f0: UH4; var tag: Int32 { 5 } }
protocol US5 { var tag: Int32 { get } }
struct US5_SymbolLess: US5 { var tag: Int32 { 0 } }
struct US5_SymbolSame: US5 { var tag: Int32 { 1 } }
struct US5_SymbolGreater: US5 { var tag: Int32 { 2 } }
protocol US6 { var tag: Int32 { get } }
struct US6_Nullable: US6 { var tag: Int32 { 0 } }
struct US6_NonNullable: US6 { var tag: Int32 { 1 } }
protocol UH7 { var tag: Int32 { get } }
struct UH7_RegexEmpty: UH7 { var tag: Int32 { 0 } }
struct UH7_RegexEpsilon: UH7 { var tag: Int32 { 1 } }
struct UH7_RegexChar: UH7 { var f0: US2; var tag: Int32 { 2 } }
struct UH7_RegexAlt: UH7 { var f0: UH7; var f1: UH7; var tag: Int32 { 3 } }
struct UH7_RegexCat: UH7 { var f0: UH7; var f1: UH7; var tag: Int32 { 4 } }
struct UH7_RegexStar: UH7 { var f0: UH7; var tag: Int32 { 5 } }
protocol US8 { var tag: Int32 { get } }
struct US8_BitMatcherRaw: US8 { var f0: UH4; var f1: UH1; var tag: Int32 { 0 } }
protocol US9 { var tag: Int32 { get } }
struct US9_BitMatcherDecided: US9 { var f0: UH4; var f1: UH1; var f2: Bool; var tag: Int32 { 1 } }
func sp_regex_compare_5(_ p0: UH4, _ p1: UH4) -> US5 {
    var v0: UH4 = p0
    var v1: UH4 = p1
    switch v0.tag {
        case 3:
            var v53: UH4 = (v0 as! UH4_RegexAlt).f0
            var v54: UH4 = (v0 as! UH4_RegexAlt).f1
            switch v1.tag {
                case 3:
                    var v55: UH4 = (v1 as! UH4_RegexAlt).f0
                    var v56: UH4 = (v1 as! UH4_RegexAlt).f1
                    var v57: US5 = US5_SymbolLess()
                    v57 = sp_regex_compare_5(v53, v55)
                    switch v57.tag {
                        case 1:
                            return sp_regex_compare_5(v54, v56)
                        default:
                            return v57
                    }
                default:
                    return US5_SymbolGreater()
            }
        case 4:
            var v28: UH4 = (v0 as! UH4_RegexCat).f0
            var v29: UH4 = (v0 as! UH4_RegexCat).f1
            switch v1.tag {
                case 4:
                    var v34: UH4 = (v1 as! UH4_RegexCat).f0
                    var v35: UH4 = (v1 as! UH4_RegexCat).f1
                    var v36: US5 = US5_SymbolLess()
                    v36 = sp_regex_compare_5(v28, v34)
                    switch v36.tag {
                        case 1:
                            return sp_regex_compare_5(v29, v35)
                        default:
                            return v36
                    }
                case 2:
                    var v32: US0 = (v1 as! UH4_RegexChar).f0
                    return US5_SymbolGreater()
                case 0:
                    return US5_SymbolGreater()
                case 1:
                    return US5_SymbolGreater()
                default:
                    return US5_SymbolLess()
            }
        case 2:
            var v10: US0 = (v0 as! UH4_RegexChar).f0
            switch v1.tag {
                case 2:
                    var v13: US0 = (v1 as! UH4_RegexChar).f0
                    switch v10.tag {
                        case 1:
                            switch v13.tag {
                                case 1:
                                    return US5_SymbolSame()
                                case 0:
                                    return US5_SymbolGreater()
                                default:
                                    fatalError("unreachable union case")
                            }
                        case 0:
                            switch v13.tag {
                                case 1:
                                    return US5_SymbolLess()
                                case 0:
                                    return US5_SymbolSame()
                                default:
                                    fatalError("unreachable union case")
                            }
                        default:
                            fatalError("unreachable union case")
                    }
                case 0:
                    return US5_SymbolGreater()
                case 1:
                    return US5_SymbolGreater()
                default:
                    return US5_SymbolLess()
            }
        case 0:
            switch v1.tag {
                case 0:
                    return US5_SymbolSame()
                default:
                    return US5_SymbolLess()
            }
        case 1:
            switch v1.tag {
                case 0:
                    return US5_SymbolGreater()
                case 1:
                    return US5_SymbolSame()
                default:
                    return US5_SymbolLess()
            }
        case 5:
            var v44: UH4 = (v0 as! UH4_RegexStar).f0
            switch v1.tag {
                case 3:
                    var v45: UH4 = (v1 as! UH4_RegexAlt).f0
                    var v46: UH4 = (v1 as! UH4_RegexAlt).f1
                    return US5_SymbolLess()
                case 5:
                    var v48: UH4 = (v1 as! UH4_RegexStar).f0
                    return sp_regex_compare_5(v44, v48)
                default:
                    return US5_SymbolGreater()
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_alt_insert_sorted_4(_ p0: UH4, _ p1: UH4) -> UH4 {
    var v0: UH4 = p0
    var v1: UH4 = p1
    switch v1.tag {
        case 3:
            var v2: UH4 = (v1 as! UH4_RegexAlt).f0
            var v3: UH4 = (v1 as! UH4_RegexAlt).f1
            var v4: US5 = US5_SymbolLess()
            v4 = sp_regex_compare_5(v0, v2)
            switch v4.tag {
                case 2:
                    var v6: UH4 = UH4_RegexEmpty()
                    v6 = sp_alt_insert_sorted_4(v0, v3)
                    return UH4_RegexAlt(f0: v2, f1: v6)
                case 0:
                    return UH4_RegexAlt(f0: v0, f1: v1)
                case 1:
                    return v1
                default:
                    fatalError("unreachable union case")
            }
        case 0:
            return v0
        default:
            var v11: US5 = US5_SymbolLess()
            v11 = sp_regex_compare_5(v0, v1)
            switch v11.tag {
                case 2:
                    return UH4_RegexAlt(f0: v1, f1: v0)
                case 0:
                    return UH4_RegexAlt(f0: v0, f1: v1)
                case 1:
                    return v1
                default:
                    fatalError("unreachable union case")
            }
    }
}
func sp_make_alt_3(_ p0: UH4, _ p1: UH4) -> UH4 {
    var v0: UH4 = p0
    var v1: UH4 = p1
    switch v0.tag {
        case 3:
            var v2: UH4 = (v0 as! UH4_RegexAlt).f0
            var v3: UH4 = (v0 as! UH4_RegexAlt).f1
            var v4: UH4 = UH4_RegexEmpty()
            v4 = sp_alt_insert_sorted_4(v2, v1)
            return sp_make_alt_3(v3, v4)
        case 0:
            return v1
        default:
            return sp_alt_insert_sorted_4(v0, v1)
    }
}
func sp_regex_equal_7(_ p0: UH4, _ p1: UH4) -> Bool {
    var v0: UH4 = p0
    var v1: UH4 = p1
    switch v0.tag {
        case 3:
            var v18: UH4 = (v0 as! UH4_RegexAlt).f0
            var v19: UH4 = (v0 as! UH4_RegexAlt).f1
            switch v1.tag {
                case 3:
                    var v20: UH4 = (v1 as! UH4_RegexAlt).f0
                    var v21: UH4 = (v1 as! UH4_RegexAlt).f1
                    var v22: Bool = false
                    v22 = sp_regex_equal_7(v18, v20)
                    if (v22) {
                        return sp_regex_equal_7(v19, v21)
                    } else {
                        return false
                    }
                default:
                    return false
            }
        case 4:
            var v26: UH4 = (v0 as! UH4_RegexCat).f0
            var v27: UH4 = (v0 as! UH4_RegexCat).f1
            switch v1.tag {
                case 4:
                    var v28: UH4 = (v1 as! UH4_RegexCat).f0
                    var v29: UH4 = (v1 as! UH4_RegexCat).f1
                    var v30: Bool = false
                    v30 = sp_regex_equal_7(v26, v28)
                    if (v30) {
                        return sp_regex_equal_7(v27, v29)
                    } else {
                        return false
                    }
                default:
                    return false
            }
        case 2:
            var v4: US0 = (v0 as! UH4_RegexChar).f0
            switch v1.tag {
                case 2:
                    var v5: US0 = (v1 as! UH4_RegexChar).f0
                    var v15: US5 = US5_SymbolLess()
                    switch v4.tag {
                        case 1:
                            switch v5.tag {
                                case 1:
                                    v15 = US5_SymbolSame()
                                case 0:
                                    v15 = US5_SymbolGreater()
                                default:
                                    fatalError("unreachable union case")
                            }
                        case 0:
                            switch v5.tag {
                                case 1:
                                    v15 = US5_SymbolLess()
                                case 0:
                                    v15 = US5_SymbolSame()
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
            var v34: UH4 = (v0 as! UH4_RegexStar).f0
            switch v1.tag {
                case 5:
                    var v35: UH4 = (v1 as! UH4_RegexStar).f0
                    return sp_regex_equal_7(v34, v35)
                default:
                    return false
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_make_cat_6(_ p0: UH4, _ p1: UH4) -> UH4 {
    var v0: UH4 = p0
    var v1: UH4 = p1
    switch v0.tag {
        case 0:
            return UH4_RegexEmpty()
        default:
            switch v1.tag {
                case 0:
                    return UH4_RegexEmpty()
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
                                            var v12: UH4 = (v0 as! UH4_RegexCat).f0
                                            var v13: UH4 = (v0 as! UH4_RegexCat).f1
                                            var v14: UH4 = UH4_RegexEmpty()
                                            v14 = sp_make_cat_6(v13, v1)
                                            return UH4_RegexCat(f0: v12, f1: v14)
                                        case 5:
                                            var v4: UH4 = (v0 as! UH4_RegexStar).f0
                                            switch v1.tag {
                                                case 5:
                                                    var v5: UH4 = (v1 as! UH4_RegexStar).f0
                                                    var v6: Bool = false
                                                    v6 = sp_regex_equal_7(v4, v5)
                                                    if (v6) {
                                                        return UH4_RegexStar(f0: v4)
                                                    } else {
                                                        return UH4_RegexCat(f0: v0, f1: v1)
                                                    }
                                                default:
                                                    return UH4_RegexCat(f0: v0, f1: v1)
                                            }
                                        default:
                                            return UH4_RegexCat(f0: v0, f1: v1)
                                    }
                            }
                    }
            }
    }
}
func sp_make_star_8(_ p0: UH4) -> UH4 {
    var v0: UH4 = p0
    switch v0.tag {
        case 0:
            return UH4_RegexEpsilon()
        case 1:
            return UH4_RegexEpsilon()
        case 5:
            var v3: UH4 = (v0 as! UH4_RegexStar).f0
            return UH4_RegexStar(f0: v3)
        default:
            return UH4_RegexStar(f0: v0)
    }
}
func sp_normalize_2(_ p0: UH4) -> UH4 {
    var v0: UH4 = p0
    switch v0.tag {
        case 3:
            var v5: UH4 = (v0 as! UH4_RegexAlt).f0
            var v6: UH4 = (v0 as! UH4_RegexAlt).f1
            var v7: UH4 = UH4_RegexEmpty()
            v7 = sp_normalize_2(v5)
            var v8: UH4 = UH4_RegexEmpty()
            v8 = sp_normalize_2(v6)
            return sp_make_alt_3(v7, v8)
        case 4:
            var v10: UH4 = (v0 as! UH4_RegexCat).f0
            var v11: UH4 = (v0 as! UH4_RegexCat).f1
            var v12: UH4 = UH4_RegexEmpty()
            v12 = sp_normalize_2(v10)
            var v13: UH4 = UH4_RegexEmpty()
            v13 = sp_normalize_2(v11)
            return sp_make_cat_6(v12, v13)
        case 2:
            var v3: US0 = (v0 as! UH4_RegexChar).f0
            return UH4_RegexChar(f0: v3)
        case 0:
            return UH4_RegexEmpty()
        case 1:
            return UH4_RegexEpsilon()
        case 5:
            var v15: UH4 = (v0 as! UH4_RegexStar).f0
            var v16: UH4 = UH4_RegexEmpty()
            v16 = sp_normalize_2(v15)
            return sp_make_star_8(v16)
        default:
            fatalError("unreachable union case")
    }
}
func sp_nullable_10(_ p0: UH4) -> US6 {
    var v0: UH4 = p0
    switch v0.tag {
        case 3:
            var v5: UH4 = (v0 as! UH4_RegexAlt).f0
            var v6: UH4 = (v0 as! UH4_RegexAlt).f1
            var v7: US6 = US6_Nullable()
            v7 = sp_nullable_10(v5)
            var v8: US6 = US6_Nullable()
            v8 = sp_nullable_10(v6)
            switch v7.tag {
                case 0:
                    return US6_Nullable()
                default:
                    switch v8.tag {
                        case 0:
                            return US6_Nullable()
                        default:
                            switch v7.tag {
                                case 1:
                                    switch v8.tag {
                                        case 1:
                                            return US6_NonNullable()
                                        default:
                                            fatalError("unreachable union case")
                                    }
                                default:
                                    fatalError("unreachable union case")
                            }
                    }
            }
        case 4:
            var v16: UH4 = (v0 as! UH4_RegexCat).f0
            var v17: UH4 = (v0 as! UH4_RegexCat).f1
            var v18: US6 = US6_Nullable()
            v18 = sp_nullable_10(v16)
            var v19: US6 = US6_Nullable()
            v19 = sp_nullable_10(v17)
            switch v18.tag {
                case 0:
                    switch v19.tag {
                        case 0:
                            return US6_Nullable()
                        default:
                            return US6_NonNullable()
                    }
                default:
                    return US6_NonNullable()
            }
        case 2:
            var v3: US0 = (v0 as! UH4_RegexChar).f0
            return US6_NonNullable()
        case 0:
            return US6_NonNullable()
        case 1:
            return US6_Nullable()
        case 5:
            var v25: UH4 = (v0 as! UH4_RegexStar).f0
            return US6_Nullable()
        default:
            fatalError("unreachable union case")
    }
}
func sp_derivative_9(_ p0: UH4, _ p1: US0) -> UH4 {
    var v0: UH4 = p0
    var v1: US0 = p1
    switch v0.tag {
        case 3:
            var v19: UH4 = (v0 as! UH4_RegexAlt).f0
            var v20: UH4 = (v0 as! UH4_RegexAlt).f1
            var v21: UH4 = UH4_RegexEmpty()
            v21 = sp_derivative_9(v19, v1)
            var v22: UH4 = UH4_RegexEmpty()
            v22 = sp_derivative_9(v20, v1)
            return sp_make_alt_3(v21, v22)
        case 4:
            var v24: UH4 = (v0 as! UH4_RegexCat).f0
            var v25: UH4 = (v0 as! UH4_RegexCat).f1
            var v26: US6 = US6_Nullable()
            v26 = sp_nullable_10(v24)
            switch v26.tag {
                case 1:
                    var v31: UH4 = UH4_RegexEmpty()
                    v31 = sp_derivative_9(v24, v1)
                    return sp_make_cat_6(v31, v25)
                case 0:
                    var v27: UH4 = UH4_RegexEmpty()
                    v27 = sp_derivative_9(v24, v1)
                    var v28: UH4 = UH4_RegexEmpty()
                    v28 = sp_make_cat_6(v27, v25)
                    var v29: UH4 = UH4_RegexEmpty()
                    v29 = sp_derivative_9(v25, v1)
                    return sp_make_alt_3(v28, v29)
                default:
                    fatalError("unreachable union case")
            }
        case 2:
            var v4: US0 = (v0 as! UH4_RegexChar).f0
            var v14: US5 = US5_SymbolLess()
            switch v4.tag {
                case 1:
                    switch v1.tag {
                        case 1:
                            v14 = US5_SymbolSame()
                        case 0:
                            v14 = US5_SymbolGreater()
                        default:
                            fatalError("unreachable union case")
                    }
                case 0:
                    switch v1.tag {
                        case 1:
                            v14 = US5_SymbolLess()
                        case 0:
                            v14 = US5_SymbolSame()
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
                return UH4_RegexEpsilon()
            } else {
                return UH4_RegexEmpty()
            }
        case 0:
            return UH4_RegexEmpty()
        case 1:
            return UH4_RegexEmpty()
        case 5:
            var v35: UH4 = (v0 as! UH4_RegexStar).f0
            var v36: UH4 = UH4_RegexEmpty()
            v36 = sp_derivative_9(v35, v1)
            var v37: UH4 = UH4_RegexEmpty()
            v37 = sp_make_star_8(v35)
            return sp_make_cat_6(v36, v37)
        default:
            fatalError("unreachable union case")
    }
}
func sp_canonical_derivative_1(_ p0: UH4, _ p1: US0) -> UH4 {
    var v0: UH4 = p0
    var v1: US0 = p1
    var v2: UH4 = UH4_RegexEmpty()
    v2 = sp_normalize_2(v0)
    var v3: UH4 = UH4_RegexEmpty()
    v3 = sp_derivative_9(v2, v1)
    return sp_normalize_2(v3)
}
func sp_accepts_0(_ p0: UH4, _ p1: UH1) -> Bool {
    var v0: UH4 = p0
    var v1: UH1 = p1
    switch v1.tag {
        case 1:
            var v6: US0 = (v1 as! UH1_InputCons).f0
            var v7: UH1 = (v1 as! UH1_InputCons).f1
            var v8: UH4 = UH4_RegexEmpty()
            v8 = sp_canonical_derivative_1(v0, v6)
            return sp_accepts_0(v8, v7)
        case 0:
            var v2: UH4 = UH4_RegexEmpty()
            v2 = sp_normalize_2(v0)
            var v3: US6 = US6_Nullable()
            v3 = sp_nullable_10(v2)
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
func sp_regex_compare_16(_ p0: UH7, _ p1: UH7) -> US5 {
    var v0: UH7 = p0
    var v1: UH7 = p1
    switch v0.tag {
        case 3:
            var v59: UH7 = (v0 as! UH7_RegexAlt).f0
            var v60: UH7 = (v0 as! UH7_RegexAlt).f1
            switch v1.tag {
                case 3:
                    var v61: UH7 = (v1 as! UH7_RegexAlt).f0
                    var v62: UH7 = (v1 as! UH7_RegexAlt).f1
                    var v63: US5 = US5_SymbolLess()
                    v63 = sp_regex_compare_16(v59, v61)
                    switch v63.tag {
                        case 1:
                            return sp_regex_compare_16(v60, v62)
                        default:
                            return v63
                    }
                default:
                    return US5_SymbolGreater()
            }
        case 4:
            var v34: UH7 = (v0 as! UH7_RegexCat).f0
            var v35: UH7 = (v0 as! UH7_RegexCat).f1
            switch v1.tag {
                case 4:
                    var v40: UH7 = (v1 as! UH7_RegexCat).f0
                    var v41: UH7 = (v1 as! UH7_RegexCat).f1
                    var v42: US5 = US5_SymbolLess()
                    v42 = sp_regex_compare_16(v34, v40)
                    switch v42.tag {
                        case 1:
                            return sp_regex_compare_16(v35, v41)
                        default:
                            return v42
                    }
                case 2:
                    var v38: US2 = (v1 as! UH7_RegexChar).f0
                    return US5_SymbolGreater()
                case 0:
                    return US5_SymbolGreater()
                case 1:
                    return US5_SymbolGreater()
                default:
                    return US5_SymbolLess()
            }
        case 2:
            var v10: US2 = (v0 as! UH7_RegexChar).f0
            switch v1.tag {
                case 2:
                    var v13: US2 = (v1 as! UH7_RegexChar).f0
                    switch v10.tag {
                        case 0:
                            switch v13.tag {
                                case 0:
                                    return US5_SymbolSame()
                                default:
                                    return US5_SymbolLess()
                            }
                        default:
                            switch v13.tag {
                                case 0:
                                    return US5_SymbolGreater()
                                default:
                                    switch v10.tag {
                                        case 1:
                                            switch v13.tag {
                                                case 1:
                                                    return US5_SymbolSame()
                                                case 2:
                                                    return US5_SymbolLess()
                                                default:
                                                    fatalError("unreachable union case")
                                            }
                                        case 2:
                                            switch v13.tag {
                                                case 1:
                                                    return US5_SymbolGreater()
                                                case 2:
                                                    return US5_SymbolSame()
                                                default:
                                                    fatalError("unreachable union case")
                                            }
                                        default:
                                            fatalError("unreachable union case")
                                    }
                            }
                    }
                case 0:
                    return US5_SymbolGreater()
                case 1:
                    return US5_SymbolGreater()
                default:
                    return US5_SymbolLess()
            }
        case 0:
            switch v1.tag {
                case 0:
                    return US5_SymbolSame()
                default:
                    return US5_SymbolLess()
            }
        case 1:
            switch v1.tag {
                case 0:
                    return US5_SymbolGreater()
                case 1:
                    return US5_SymbolSame()
                default:
                    return US5_SymbolLess()
            }
        case 5:
            var v50: UH7 = (v0 as! UH7_RegexStar).f0
            switch v1.tag {
                case 3:
                    var v51: UH7 = (v1 as! UH7_RegexAlt).f0
                    var v52: UH7 = (v1 as! UH7_RegexAlt).f1
                    return US5_SymbolLess()
                case 5:
                    var v54: UH7 = (v1 as! UH7_RegexStar).f0
                    return sp_regex_compare_16(v50, v54)
                default:
                    return US5_SymbolGreater()
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_alt_insert_sorted_15(_ p0: UH7, _ p1: UH7) -> UH7 {
    var v0: UH7 = p0
    var v1: UH7 = p1
    switch v1.tag {
        case 3:
            var v2: UH7 = (v1 as! UH7_RegexAlt).f0
            var v3: UH7 = (v1 as! UH7_RegexAlt).f1
            var v4: US5 = US5_SymbolLess()
            v4 = sp_regex_compare_16(v0, v2)
            switch v4.tag {
                case 2:
                    var v6: UH7 = UH7_RegexEmpty()
                    v6 = sp_alt_insert_sorted_15(v0, v3)
                    return UH7_RegexAlt(f0: v2, f1: v6)
                case 0:
                    return UH7_RegexAlt(f0: v0, f1: v1)
                case 1:
                    return v1
                default:
                    fatalError("unreachable union case")
            }
        case 0:
            return v0
        default:
            var v11: US5 = US5_SymbolLess()
            v11 = sp_regex_compare_16(v0, v1)
            switch v11.tag {
                case 2:
                    return UH7_RegexAlt(f0: v1, f1: v0)
                case 0:
                    return UH7_RegexAlt(f0: v0, f1: v1)
                case 1:
                    return v1
                default:
                    fatalError("unreachable union case")
            }
    }
}
func sp_make_alt_14(_ p0: UH7, _ p1: UH7) -> UH7 {
    var v0: UH7 = p0
    var v1: UH7 = p1
    switch v0.tag {
        case 3:
            var v2: UH7 = (v0 as! UH7_RegexAlt).f0
            var v3: UH7 = (v0 as! UH7_RegexAlt).f1
            var v4: UH7 = UH7_RegexEmpty()
            v4 = sp_alt_insert_sorted_15(v2, v1)
            return sp_make_alt_14(v3, v4)
        case 0:
            return v1
        default:
            return sp_alt_insert_sorted_15(v0, v1)
    }
}
func sp_regex_equal_18(_ p0: UH7, _ p1: UH7) -> Bool {
    var v0: UH7 = p0
    var v1: UH7 = p1
    switch v0.tag {
        case 3:
            var v24: UH7 = (v0 as! UH7_RegexAlt).f0
            var v25: UH7 = (v0 as! UH7_RegexAlt).f1
            switch v1.tag {
                case 3:
                    var v26: UH7 = (v1 as! UH7_RegexAlt).f0
                    var v27: UH7 = (v1 as! UH7_RegexAlt).f1
                    var v28: Bool = false
                    v28 = sp_regex_equal_18(v24, v26)
                    if (v28) {
                        return sp_regex_equal_18(v25, v27)
                    } else {
                        return false
                    }
                default:
                    return false
            }
        case 4:
            var v32: UH7 = (v0 as! UH7_RegexCat).f0
            var v33: UH7 = (v0 as! UH7_RegexCat).f1
            switch v1.tag {
                case 4:
                    var v34: UH7 = (v1 as! UH7_RegexCat).f0
                    var v35: UH7 = (v1 as! UH7_RegexCat).f1
                    var v36: Bool = false
                    v36 = sp_regex_equal_18(v32, v34)
                    if (v36) {
                        return sp_regex_equal_18(v33, v35)
                    } else {
                        return false
                    }
                default:
                    return false
            }
        case 2:
            var v4: US2 = (v0 as! UH7_RegexChar).f0
            switch v1.tag {
                case 2:
                    var v5: US2 = (v1 as! UH7_RegexChar).f0
                    var v21: US5 = US5_SymbolLess()
                    switch v4.tag {
                        case 0:
                            switch v5.tag {
                                case 0:
                                    v21 = US5_SymbolSame()
                                default:
                                    v21 = US5_SymbolLess()
                            }
                        default:
                            switch v5.tag {
                                case 0:
                                    v21 = US5_SymbolGreater()
                                default:
                                    switch v4.tag {
                                        case 1:
                                            switch v5.tag {
                                                case 1:
                                                    v21 = US5_SymbolSame()
                                                case 2:
                                                    v21 = US5_SymbolLess()
                                                default:
                                                    fatalError("unreachable union case")
                                            }
                                        case 2:
                                            switch v5.tag {
                                                case 1:
                                                    v21 = US5_SymbolGreater()
                                                case 2:
                                                    v21 = US5_SymbolSame()
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
            var v40: UH7 = (v0 as! UH7_RegexStar).f0
            switch v1.tag {
                case 5:
                    var v41: UH7 = (v1 as! UH7_RegexStar).f0
                    return sp_regex_equal_18(v40, v41)
                default:
                    return false
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_make_cat_17(_ p0: UH7, _ p1: UH7) -> UH7 {
    var v0: UH7 = p0
    var v1: UH7 = p1
    switch v0.tag {
        case 0:
            return UH7_RegexEmpty()
        default:
            switch v1.tag {
                case 0:
                    return UH7_RegexEmpty()
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
                                            var v12: UH7 = (v0 as! UH7_RegexCat).f0
                                            var v13: UH7 = (v0 as! UH7_RegexCat).f1
                                            var v14: UH7 = UH7_RegexEmpty()
                                            v14 = sp_make_cat_17(v13, v1)
                                            return UH7_RegexCat(f0: v12, f1: v14)
                                        case 5:
                                            var v4: UH7 = (v0 as! UH7_RegexStar).f0
                                            switch v1.tag {
                                                case 5:
                                                    var v5: UH7 = (v1 as! UH7_RegexStar).f0
                                                    var v6: Bool = false
                                                    v6 = sp_regex_equal_18(v4, v5)
                                                    if (v6) {
                                                        return UH7_RegexStar(f0: v4)
                                                    } else {
                                                        return UH7_RegexCat(f0: v0, f1: v1)
                                                    }
                                                default:
                                                    return UH7_RegexCat(f0: v0, f1: v1)
                                            }
                                        default:
                                            return UH7_RegexCat(f0: v0, f1: v1)
                                    }
                            }
                    }
            }
    }
}
func sp_make_star_19(_ p0: UH7) -> UH7 {
    var v0: UH7 = p0
    switch v0.tag {
        case 0:
            return UH7_RegexEpsilon()
        case 1:
            return UH7_RegexEpsilon()
        case 5:
            var v3: UH7 = (v0 as! UH7_RegexStar).f0
            return UH7_RegexStar(f0: v3)
        default:
            return UH7_RegexStar(f0: v0)
    }
}
func sp_normalize_13(_ p0: UH7) -> UH7 {
    var v0: UH7 = p0
    switch v0.tag {
        case 3:
            var v5: UH7 = (v0 as! UH7_RegexAlt).f0
            var v6: UH7 = (v0 as! UH7_RegexAlt).f1
            var v7: UH7 = UH7_RegexEmpty()
            v7 = sp_normalize_13(v5)
            var v8: UH7 = UH7_RegexEmpty()
            v8 = sp_normalize_13(v6)
            return sp_make_alt_14(v7, v8)
        case 4:
            var v10: UH7 = (v0 as! UH7_RegexCat).f0
            var v11: UH7 = (v0 as! UH7_RegexCat).f1
            var v12: UH7 = UH7_RegexEmpty()
            v12 = sp_normalize_13(v10)
            var v13: UH7 = UH7_RegexEmpty()
            v13 = sp_normalize_13(v11)
            return sp_make_cat_17(v12, v13)
        case 2:
            var v3: US2 = (v0 as! UH7_RegexChar).f0
            return UH7_RegexChar(f0: v3)
        case 0:
            return UH7_RegexEmpty()
        case 1:
            return UH7_RegexEpsilon()
        case 5:
            var v15: UH7 = (v0 as! UH7_RegexStar).f0
            var v16: UH7 = UH7_RegexEmpty()
            v16 = sp_normalize_13(v15)
            return sp_make_star_19(v16)
        default:
            fatalError("unreachable union case")
    }
}
func sp_nullable_21(_ p0: UH7) -> US6 {
    var v0: UH7 = p0
    switch v0.tag {
        case 3:
            var v5: UH7 = (v0 as! UH7_RegexAlt).f0
            var v6: UH7 = (v0 as! UH7_RegexAlt).f1
            var v7: US6 = US6_Nullable()
            v7 = sp_nullable_21(v5)
            var v8: US6 = US6_Nullable()
            v8 = sp_nullable_21(v6)
            switch v7.tag {
                case 0:
                    return US6_Nullable()
                default:
                    switch v8.tag {
                        case 0:
                            return US6_Nullable()
                        default:
                            switch v7.tag {
                                case 1:
                                    switch v8.tag {
                                        case 1:
                                            return US6_NonNullable()
                                        default:
                                            fatalError("unreachable union case")
                                    }
                                default:
                                    fatalError("unreachable union case")
                            }
                    }
            }
        case 4:
            var v16: UH7 = (v0 as! UH7_RegexCat).f0
            var v17: UH7 = (v0 as! UH7_RegexCat).f1
            var v18: US6 = US6_Nullable()
            v18 = sp_nullable_21(v16)
            var v19: US6 = US6_Nullable()
            v19 = sp_nullable_21(v17)
            switch v18.tag {
                case 0:
                    switch v19.tag {
                        case 0:
                            return US6_Nullable()
                        default:
                            return US6_NonNullable()
                    }
                default:
                    return US6_NonNullable()
            }
        case 2:
            var v3: US2 = (v0 as! UH7_RegexChar).f0
            return US6_NonNullable()
        case 0:
            return US6_NonNullable()
        case 1:
            return US6_Nullable()
        case 5:
            var v25: UH7 = (v0 as! UH7_RegexStar).f0
            return US6_Nullable()
        default:
            fatalError("unreachable union case")
    }
}
func sp_derivative_20(_ p0: UH7, _ p1: US2) -> UH7 {
    var v0: UH7 = p0
    var v1: US2 = p1
    switch v0.tag {
        case 3:
            var v25: UH7 = (v0 as! UH7_RegexAlt).f0
            var v26: UH7 = (v0 as! UH7_RegexAlt).f1
            var v27: UH7 = UH7_RegexEmpty()
            v27 = sp_derivative_20(v25, v1)
            var v28: UH7 = UH7_RegexEmpty()
            v28 = sp_derivative_20(v26, v1)
            return sp_make_alt_14(v27, v28)
        case 4:
            var v30: UH7 = (v0 as! UH7_RegexCat).f0
            var v31: UH7 = (v0 as! UH7_RegexCat).f1
            var v32: US6 = US6_Nullable()
            v32 = sp_nullable_21(v30)
            switch v32.tag {
                case 1:
                    var v37: UH7 = UH7_RegexEmpty()
                    v37 = sp_derivative_20(v30, v1)
                    return sp_make_cat_17(v37, v31)
                case 0:
                    var v33: UH7 = UH7_RegexEmpty()
                    v33 = sp_derivative_20(v30, v1)
                    var v34: UH7 = UH7_RegexEmpty()
                    v34 = sp_make_cat_17(v33, v31)
                    var v35: UH7 = UH7_RegexEmpty()
                    v35 = sp_derivative_20(v31, v1)
                    return sp_make_alt_14(v34, v35)
                default:
                    fatalError("unreachable union case")
            }
        case 2:
            var v4: US2 = (v0 as! UH7_RegexChar).f0
            var v20: US5 = US5_SymbolLess()
            switch v4.tag {
                case 0:
                    switch v1.tag {
                        case 0:
                            v20 = US5_SymbolSame()
                        default:
                            v20 = US5_SymbolLess()
                    }
                default:
                    switch v1.tag {
                        case 0:
                            v20 = US5_SymbolGreater()
                        default:
                            switch v4.tag {
                                case 1:
                                    switch v1.tag {
                                        case 1:
                                            v20 = US5_SymbolSame()
                                        case 2:
                                            v20 = US5_SymbolLess()
                                        default:
                                            fatalError("unreachable union case")
                                    }
                                case 2:
                                    switch v1.tag {
                                        case 1:
                                            v20 = US5_SymbolGreater()
                                        case 2:
                                            v20 = US5_SymbolSame()
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
                return UH7_RegexEpsilon()
            } else {
                return UH7_RegexEmpty()
            }
        case 0:
            return UH7_RegexEmpty()
        case 1:
            return UH7_RegexEmpty()
        case 5:
            var v41: UH7 = (v0 as! UH7_RegexStar).f0
            var v42: UH7 = UH7_RegexEmpty()
            v42 = sp_derivative_20(v41, v1)
            var v43: UH7 = UH7_RegexEmpty()
            v43 = sp_make_star_19(v41)
            return sp_make_cat_17(v42, v43)
        default:
            fatalError("unreachable union case")
    }
}
func sp_canonical_derivative_12(_ p0: UH7, _ p1: US2) -> UH7 {
    var v0: UH7 = p0
    var v1: US2 = p1
    var v2: UH7 = UH7_RegexEmpty()
    v2 = sp_normalize_13(v0)
    var v3: UH7 = UH7_RegexEmpty()
    v3 = sp_derivative_20(v2, v1)
    return sp_normalize_13(v3)
}
func sp_accepts_11(_ p0: UH7, _ p1: UH3) -> Bool {
    var v0: UH7 = p0
    var v1: UH3 = p1
    switch v1.tag {
        case 1:
            var v6: US2 = (v1 as! UH3_InputCons).f0
            var v7: UH3 = (v1 as! UH3_InputCons).f1
            var v8: UH7 = UH7_RegexEmpty()
            v8 = sp_canonical_derivative_12(v0, v6)
            return sp_accepts_11(v8, v7)
        case 0:
            var v2: UH7 = UH7_RegexEmpty()
            v2 = sp_normalize_13(v0)
            var v3: US6 = US6_Nullable()
            v3 = sp_nullable_21(v2)
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
func sp_decide_bit_match_22(_ p0: US8) -> US9 {
    var v0: US8 = p0
    switch v0.tag {
        case 0:
            var v1: UH4 = (v0 as! US8_BitMatcherRaw).f0
            var v2: UH1 = (v0 as! US8_BitMatcherRaw).f1
            var v3: Bool = false
            v3 = sp_accepts_0(v1, v2)
            return US9_BitMatcherDecided(f0: v1, f1: v2, f2: v3)
        default:
            fatalError("unreachable union case")
    }
}
func sp_bit_match_value_23(_ p0: US9) -> Bool {
    var v0: US9 = p0
    switch v0.tag {
        case 1:
            var v1: UH4 = (v0 as! US9_BitMatcherDecided).f0
            var v2: UH1 = (v0 as! US9_BitMatcherDecided).f1
            var v3: Bool = (v0 as! US9_BitMatcherDecided).f2
            return v3
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: US0 = US0_BitZero()
    v0 = US0_BitOne()
    var v1: US0 = US0_BitZero()
    v1 = US0_BitOne()
    var v2: US0 = US0_BitZero()
    v2 = US0_BitZero()
    var v3: UH1 = UH1_InputEmpty()
    v3 = UH1_InputEmpty()
    var v4: UH1 = UH1_InputEmpty()
    v4 = UH1_InputCons(f0: v2, f1: v3)
    var v5: UH1 = UH1_InputEmpty()
    v5 = UH1_InputCons(f0: v1, f1: v4)
    var v6: UH1 = UH1_InputEmpty()
    v6 = UH1_InputCons(f0: v0, f1: v5)
    var v7: US0 = US0_BitZero()
    v7 = US0_BitOne()
    var v8: US0 = US0_BitZero()
    v8 = US0_BitOne()
    var v9: US0 = US0_BitZero()
    v9 = US0_BitOne()
    var v10: UH1 = UH1_InputEmpty()
    v10 = UH1_InputEmpty()
    var v11: UH1 = UH1_InputEmpty()
    v11 = UH1_InputCons(f0: v9, f1: v10)
    var v12: UH1 = UH1_InputEmpty()
    v12 = UH1_InputCons(f0: v8, f1: v11)
    var v13: UH1 = UH1_InputEmpty()
    v13 = UH1_InputCons(f0: v7, f1: v12)
    var v14: US2 = US2_TriA()
    v14 = US2_TriA()
    var v15: US2 = US2_TriA()
    v15 = US2_TriA()
    var v16: US2 = US2_TriA()
    v16 = US2_TriA()
    var v17: UH3 = UH3_InputEmpty()
    v17 = UH3_InputEmpty()
    var v18: UH3 = UH3_InputEmpty()
    v18 = UH3_InputCons(f0: v16, f1: v17)
    var v19: UH3 = UH3_InputEmpty()
    v19 = UH3_InputCons(f0: v15, f1: v18)
    var v20: UH3 = UH3_InputEmpty()
    v20 = UH3_InputCons(f0: v14, f1: v19)
    var v21: US2 = US2_TriA()
    v21 = US2_TriA()
    var v22: US2 = US2_TriA()
    v22 = US2_TriA()
    var v23: US2 = US2_TriA()
    v23 = US2_TriB()
    var v24: UH3 = UH3_InputEmpty()
    v24 = UH3_InputEmpty()
    var v25: UH3 = UH3_InputEmpty()
    v25 = UH3_InputCons(f0: v23, f1: v24)
    var v26: UH3 = UH3_InputEmpty()
    v26 = UH3_InputCons(f0: v22, f1: v25)
    var v27: UH3 = UH3_InputEmpty()
    v27 = UH3_InputCons(f0: v21, f1: v26)
    var v28: US0 = US0_BitZero()
    v28 = US0_BitZero()
    var v29: UH4 = UH4_RegexEmpty()
    v29 = UH4_RegexChar(f0: v28)
    var v30: US0 = US0_BitZero()
    v30 = US0_BitOne()
    var v31: UH4 = UH4_RegexEmpty()
    v31 = UH4_RegexChar(f0: v30)
    var v32: UH4 = UH4_RegexEmpty()
    v32 = UH4_RegexAlt(f0: v29, f1: v31)
    var v33: UH4 = UH4_RegexEmpty()
    v33 = UH4_RegexStar(f0: v32)
    var v34: US0 = US0_BitZero()
    v34 = US0_BitZero()
    var v35: UH4 = UH4_RegexEmpty()
    v35 = UH4_RegexChar(f0: v34)
    var v36: UH4 = UH4_RegexEmpty()
    v36 = UH4_RegexCat(f0: v33, f1: v35)
    var v37: Bool = false
    v37 = sp_accepts_0(v36, v6)
    if (v37) {
    } else {
        "brzozowski-expected-true".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    var v38: US0 = US0_BitZero()
    v38 = US0_BitZero()
    var v39: UH4 = UH4_RegexEmpty()
    v39 = UH4_RegexChar(f0: v38)
    var v40: US0 = US0_BitZero()
    v40 = US0_BitOne()
    var v41: UH4 = UH4_RegexEmpty()
    v41 = UH4_RegexChar(f0: v40)
    var v42: UH4 = UH4_RegexEmpty()
    v42 = UH4_RegexAlt(f0: v39, f1: v41)
    var v43: UH4 = UH4_RegexEmpty()
    v43 = UH4_RegexStar(f0: v42)
    var v44: US0 = US0_BitZero()
    v44 = US0_BitZero()
    var v45: UH4 = UH4_RegexEmpty()
    v45 = UH4_RegexChar(f0: v44)
    var v46: UH4 = UH4_RegexEmpty()
    v46 = UH4_RegexCat(f0: v43, f1: v45)
    var v47: Bool = false
    v47 = sp_accepts_0(v46, v13)
    if (v47) {
        "brzozowski-expected-false".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    } else {
    }
    var v48: US2 = US2_TriA()
    v48 = US2_TriA()
    var v49: UH7 = UH7_RegexEmpty()
    v49 = UH7_RegexChar(f0: v48)
    var v50: UH7 = UH7_RegexEmpty()
    v50 = UH7_RegexStar(f0: v49)
    var v51: Bool = false
    v51 = sp_accepts_11(v50, v20)
    if (v51) {
    } else {
        "brzozowski-expected-true".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    var v52: US2 = US2_TriA()
    v52 = US2_TriA()
    var v53: UH7 = UH7_RegexEmpty()
    v53 = UH7_RegexChar(f0: v52)
    var v54: UH7 = UH7_RegexEmpty()
    v54 = UH7_RegexStar(f0: v53)
    var v55: Bool = false
    v55 = sp_accepts_11(v54, v27)
    if (v55) {
        "brzozowski-expected-false".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    } else {
    }
    var v56: US0 = US0_BitZero()
    v56 = US0_BitZero()
    var v57: UH4 = UH4_RegexEmpty()
    v57 = UH4_RegexChar(f0: v56)
    var v58: US0 = US0_BitZero()
    v58 = US0_BitOne()
    var v59: UH4 = UH4_RegexEmpty()
    v59 = UH4_RegexChar(f0: v58)
    var v60: UH4 = UH4_RegexEmpty()
    v60 = UH4_RegexAlt(f0: v57, f1: v59)
    var v61: UH4 = UH4_RegexEmpty()
    v61 = UH4_RegexStar(f0: v60)
    var v62: US0 = US0_BitZero()
    v62 = US0_BitZero()
    var v63: UH4 = UH4_RegexEmpty()
    v63 = UH4_RegexChar(f0: v62)
    var v64: UH4 = UH4_RegexEmpty()
    v64 = UH4_RegexCat(f0: v61, f1: v63)
    var v65: US8 = US8_BitMatcherRaw(f0: UH4_RegexEmpty(), f1: UH1_InputEmpty())
    v65 = US8_BitMatcherRaw(f0: v64, f1: v6)
    var v66: US9 = US9_BitMatcherDecided(f0: UH4_RegexEmpty(), f1: UH1_InputEmpty(), f2: false)
    v66 = sp_decide_bit_match_22(v65)
    var v67: US0 = US0_BitZero()
    v67 = US0_BitZero()
    var v68: UH4 = UH4_RegexEmpty()
    v68 = UH4_RegexChar(f0: v67)
    var v69: US0 = US0_BitZero()
    v69 = US0_BitOne()
    var v70: UH4 = UH4_RegexEmpty()
    v70 = UH4_RegexChar(f0: v69)
    var v71: UH4 = UH4_RegexEmpty()
    v71 = UH4_RegexAlt(f0: v68, f1: v70)
    var v72: UH4 = UH4_RegexEmpty()
    v72 = UH4_RegexStar(f0: v71)
    var v73: US0 = US0_BitZero()
    v73 = US0_BitZero()
    var v74: UH4 = UH4_RegexEmpty()
    v74 = UH4_RegexChar(f0: v73)
    var v75: UH4 = UH4_RegexEmpty()
    v75 = UH4_RegexCat(f0: v72, f1: v74)
    var v76: US8 = US8_BitMatcherRaw(f0: UH4_RegexEmpty(), f1: UH1_InputEmpty())
    v76 = US8_BitMatcherRaw(f0: v75, f1: v13)
    var v77: US9 = US9_BitMatcherDecided(f0: UH4_RegexEmpty(), f1: UH1_InputEmpty(), f2: false)
    v77 = sp_decide_bit_match_22(v76)
    var v78: Bool = false
    v78 = sp_bit_match_value_23(v66)
    if (v78) {
    } else {
        "brzozowski-expected-true".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    var v79: Bool = false
    v79 = sp_bit_match_value_23(v77)
    if (v79) {
        "brzozowski-expected-false".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    } else {
    }
    return 0
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
