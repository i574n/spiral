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
protocol UH5 { var tag: Int32 { get } }
struct UH5_RegexListNil: UH5 { var tag: Int32 { 0 } }
struct UH5_RegexListCons: UH5 { var f0: UH1; var f1: UH5; var tag: Int32 { 1 } }
final class SpiralArray<T> {
    var items: [T]
    init(_ items: [T]) { self.items = items }
}
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
            let t1227_6: UInt64 = v6
            let t1265_7: Int32 = v7
            let t1302_14: UH2 = v14
            v0 = t1227_6
            v1 = t1265_7
            v2 = t1302_14
            continue
        } else {
            return (v2, v0)
        }
    }
    return (UH2_InputEmpty(), (0 as UInt64))
}
func sp_regex_compare_7(_ p0: UH1, _ p1: UH1) -> US3 {
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
                    v57 = sp_regex_compare_7(v53, v55)
                    switch v57.tag {
                        case 1:
                            return sp_regex_compare_7(v54, v56)
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
                    v36 = sp_regex_compare_7(v28, v34)
                    switch v36.tag {
                        case 1:
                            return sp_regex_compare_7(v29, v35)
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
                    return sp_regex_compare_7(v44, v48)
                default:
                    return US3_SymbolGreater()
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_alt_insert_sorted_6(_ p0: UH1, _ p1: UH1) -> UH1 {
    var v0: UH1 = p0
    var v1: UH1 = p1
    switch v1.tag {
        case 3:
            var v2: UH1 = (v1 as! UH1_RegexAlt).f0
            var v3: UH1 = (v1 as! UH1_RegexAlt).f1
            var v4: US3 = US3_SymbolLess()
            v4 = sp_regex_compare_7(v0, v2)
            switch v4.tag {
                case 2:
                    var v6: UH1 = UH1_RegexEmpty()
                    v6 = sp_alt_insert_sorted_6(v0, v3)
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
            v11 = sp_regex_compare_7(v0, v1)
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
func sp_make_alt_5(_ p0: UH1, _ p1: UH1) -> UH1 {
    var v0: UH1 = p0
    var v1: UH1 = p1
    switch v0.tag {
        case 3:
            var v2: UH1 = (v0 as! UH1_RegexAlt).f0
            var v3: UH1 = (v0 as! UH1_RegexAlt).f1
            var v4: UH1 = UH1_RegexEmpty()
            v4 = sp_alt_insert_sorted_6(v2, v1)
            return sp_make_alt_5(v3, v4)
        case 0:
            return v1
        default:
            return sp_alt_insert_sorted_6(v0, v1)
    }
}
func sp_regex_equal_9(_ p0: UH1, _ p1: UH1) -> Bool {
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
                    v22 = sp_regex_equal_9(v18, v20)
                    if (v22) {
                        return sp_regex_equal_9(v19, v21)
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
                    v30 = sp_regex_equal_9(v26, v28)
                    if (v30) {
                        return sp_regex_equal_9(v27, v29)
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
                    return sp_regex_equal_9(v34, v35)
                default:
                    return false
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_make_cat_8(_ p0: UH1, _ p1: UH1) -> UH1 {
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
                                            v14 = sp_make_cat_8(v13, v1)
                                            return UH1_RegexCat(f0: v12, f1: v14)
                                        case 5:
                                            var v4: UH1 = (v0 as! UH1_RegexStar).f0
                                            switch v1.tag {
                                                case 5:
                                                    var v5: UH1 = (v1 as! UH1_RegexStar).f0
                                                    var v6: Bool = false
                                                    v6 = sp_regex_equal_9(v4, v5)
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
func sp_make_star_10(_ p0: UH1) -> UH1 {
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
func sp_normalize_4(_ p0: UH1) -> UH1 {
    var v0: UH1 = p0
    switch v0.tag {
        case 3:
            var v5: UH1 = (v0 as! UH1_RegexAlt).f0
            var v6: UH1 = (v0 as! UH1_RegexAlt).f1
            var v7: UH1 = UH1_RegexEmpty()
            v7 = sp_normalize_4(v5)
            var v8: UH1 = UH1_RegexEmpty()
            v8 = sp_normalize_4(v6)
            return sp_make_alt_5(v7, v8)
        case 4:
            var v10: UH1 = (v0 as! UH1_RegexCat).f0
            var v11: UH1 = (v0 as! UH1_RegexCat).f1
            var v12: UH1 = UH1_RegexEmpty()
            v12 = sp_normalize_4(v10)
            var v13: UH1 = UH1_RegexEmpty()
            v13 = sp_normalize_4(v11)
            return sp_make_cat_8(v12, v13)
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
            v16 = sp_normalize_4(v15)
            return sp_make_star_10(v16)
        default:
            fatalError("unreachable union case")
    }
}
func sp_nullable_12(_ p0: UH1) -> US4 {
    var v0: UH1 = p0
    switch v0.tag {
        case 3:
            var v5: UH1 = (v0 as! UH1_RegexAlt).f0
            var v6: UH1 = (v0 as! UH1_RegexAlt).f1
            var v7: US4 = US4_Nullable()
            v7 = sp_nullable_12(v5)
            var v8: US4 = US4_Nullable()
            v8 = sp_nullable_12(v6)
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
            v18 = sp_nullable_12(v16)
            var v19: US4 = US4_Nullable()
            v19 = sp_nullable_12(v17)
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
func sp_derivative_11(_ p0: UH1, _ p1: US0) -> UH1 {
    var v0: UH1 = p0
    var v1: US0 = p1
    switch v0.tag {
        case 3:
            var v19: UH1 = (v0 as! UH1_RegexAlt).f0
            var v20: UH1 = (v0 as! UH1_RegexAlt).f1
            var v21: UH1 = UH1_RegexEmpty()
            v21 = sp_derivative_11(v19, v1)
            var v22: UH1 = UH1_RegexEmpty()
            v22 = sp_derivative_11(v20, v1)
            return sp_make_alt_5(v21, v22)
        case 4:
            var v24: UH1 = (v0 as! UH1_RegexCat).f0
            var v25: UH1 = (v0 as! UH1_RegexCat).f1
            var v26: US4 = US4_Nullable()
            v26 = sp_nullable_12(v24)
            switch v26.tag {
                case 1:
                    var v31: UH1 = UH1_RegexEmpty()
                    v31 = sp_derivative_11(v24, v1)
                    return sp_make_cat_8(v31, v25)
                case 0:
                    var v27: UH1 = UH1_RegexEmpty()
                    v27 = sp_derivative_11(v24, v1)
                    var v28: UH1 = UH1_RegexEmpty()
                    v28 = sp_make_cat_8(v27, v25)
                    var v29: UH1 = UH1_RegexEmpty()
                    v29 = sp_derivative_11(v25, v1)
                    return sp_make_alt_5(v28, v29)
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
            v36 = sp_derivative_11(v35, v1)
            var v37: UH1 = UH1_RegexEmpty()
            v37 = sp_make_star_10(v35)
            return sp_make_cat_8(v36, v37)
        default:
            fatalError("unreachable union case")
    }
}
func sp_canonical_derivative_3(_ p0: UH1, _ p1: US0) -> UH1 {
    var v0: UH1 = p0
    var v1: US0 = p1
    var v2: UH1 = UH1_RegexEmpty()
    v2 = sp_normalize_4(v0)
    var v3: UH1 = UH1_RegexEmpty()
    v3 = sp_derivative_11(v2, v1)
    return sp_normalize_4(v3)
}
func sp_accepts_2(_ p0: UH1, _ p1: UH2) -> Bool {
    var v0: UH1 = p0
    var v1: UH2 = p1
    switch v1.tag {
        case 1:
            var v6: US0 = (v1 as! UH2_InputCons).f0
            var v7: UH2 = (v1 as! UH2_InputCons).f1
            var v8: UH1 = UH1_RegexEmpty()
            v8 = sp_canonical_derivative_3(v0, v6)
            return sp_accepts_2(v8, v7)
        case 0:
            var v2: UH1 = UH1_RegexEmpty()
            v2 = sp_normalize_4(v0)
            var v3: US4 = US4_Nullable()
            v3 = sp_nullable_12(v2)
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
func sp_loop_0(_ p0: UH1, _ p1: Int32, _ p2: Int32, _ p3: UInt64, _ p4: Int32) -> Int32 {
    var v0: UH1 = p0
    var v1: Int32 = p1
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
            let spiral_tuple467 = sp_random_bit_input_1(v3, v1, v6)
            v7 = spiral_tuple467.0
            v8 = spiral_tuple467.1
            var v9: Bool = false
            v9 = sp_accepts_2(v0, v7)
            var v11: Int32 = 0
            if (v9) {
                var v10: Int32 = 0
                v10 = (v4 &+ 1)
                v11 = v10
            } else {
                v11 = v4
            }
            var v12: Int32 = 0
            v12 = (v2 &- 1)
            let t956_0: UH1 = v0
            let t990_1: Int32 = v1
            let t1026_12: Int32 = v12
            let t1065_8: UInt64 = v8
            let t1103_11: Int32 = v11
            v0 = t956_0
            v1 = t990_1
            v2 = t1026_12
            v3 = t1065_8
            v4 = t1103_11
            continue
        } else {
            return v4
        }
    }
    return 0
}
func sp_zeros_input_14(_ p0: Int32, _ p1: UH2) -> UH2 {
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
            let t417_3: Int32 = v3
            let t453_5: UH2 = v5
            v0 = t417_3
            v1 = t453_5
            continue
        } else {
            return v1
        }
    }
    return UH2_InputEmpty()
}
func sp_loop_13(_ p0: UH1, _ p1: Int32, _ p2: Int32, _ p3: Int32) -> Int32 {
    var v0: UH1 = p0
    var v1: Int32 = p1
    var v2: Int32 = p2
    var v3: Int32 = p3
    while true {
        var v4: Bool = false
        v4 = (v1 < v2)
        if (v4) {
            return v3
        } else {
            var v5: UH2 = UH2_InputEmpty()
            v5 = UH2_InputEmpty()
            var v6: UH2 = UH2_InputEmpty()
            v6 = sp_zeros_input_14(v2, v5)
            var v7: Bool = false
            v7 = sp_accepts_2(v0, v6)
            var v9: Int32 = 0
            if (v7) {
                var v8: Int32 = 0
                v8 = (v3 &+ 1)
                v9 = v8
            } else {
                v9 = v3
            }
            var v10: US0 = US0_BitZero()
            v10 = US0_BitOne()
            var v11: UH2 = UH2_InputEmpty()
            v11 = UH2_InputEmpty()
            var v12: UH2 = UH2_InputEmpty()
            v12 = UH2_InputCons(f0: v10, f1: v11)
            var v13: UH2 = UH2_InputEmpty()
            v13 = sp_zeros_input_14(v2, v12)
            var v14: Bool = false
            v14 = sp_accepts_2(v0, v13)
            var v16: Int32 = 0
            if (v14) {
                var v15: Int32 = 0
                v15 = (v9 &+ 1)
                v16 = v15
            } else {
                v16 = v9
            }
            var v17: Int32 = 0
            v17 = (v2 &+ 1)
            let t1446_0: UH1 = v0
            let t1481_1: Int32 = v1
            let t1518_17: Int32 = v17
            let t1557_16: Int32 = v16
            v0 = t1446_0
            v1 = t1481_1
            v2 = t1518_17
            v3 = t1557_16
            continue
        }
    }
    return 0
}
func sp_backtrack_stack_16(_ p0: UH5, _ p1: UH2) -> Bool {
    var v0: UH5 = p0
    var v1: UH2 = p1
    switch v0.tag {
        case 1:
            var v6: UH1 = (v0 as! UH5_RegexListCons).f0
            var v7: UH5 = (v0 as! UH5_RegexListCons).f1
            switch v6.tag {
                case 3:
                    var v27: UH1 = (v6 as! UH1_RegexAlt).f0
                    var v28: UH1 = (v6 as! UH1_RegexAlt).f1
                    var v29: UH5 = UH5_RegexListNil()
                    v29 = UH5_RegexListCons(f0: v27, f1: v7)
                    var v30: Bool = false
                    v30 = sp_backtrack_stack_16(v29, v1)
                    if (v30) {
                        return true
                    } else {
                        var v31: UH5 = UH5_RegexListNil()
                        v31 = UH5_RegexListCons(f0: v28, f1: v7)
                        return sp_backtrack_stack_16(v31, v1)
                    }
                case 4:
                    var v34: UH1 = (v6 as! UH1_RegexCat).f0
                    var v35: UH1 = (v6 as! UH1_RegexCat).f1
                    var v36: UH5 = UH5_RegexListNil()
                    v36 = UH5_RegexListCons(f0: v35, f1: v7)
                    var v37: UH5 = UH5_RegexListNil()
                    v37 = UH5_RegexListCons(f0: v34, f1: v36)
                    return sp_backtrack_stack_16(v37, v1)
                case 2:
                    var v9: US0 = (v6 as! UH1_RegexChar).f0
                    switch v1.tag {
                        case 1:
                            var v10: US0 = (v1 as! UH2_InputCons).f0
                            var v11: UH2 = (v1 as! UH2_InputCons).f1
                            var v21: US3 = US3_SymbolLess()
                            switch v9.tag {
                                case 1:
                                    switch v10.tag {
                                        case 1:
                                            v21 = US3_SymbolSame()
                                        case 0:
                                            v21 = US3_SymbolGreater()
                                        default:
                                            fatalError("unreachable union case")
                                    }
                                case 0:
                                    switch v10.tag {
                                        case 1:
                                            v21 = US3_SymbolLess()
                                        case 0:
                                            v21 = US3_SymbolSame()
                                        default:
                                            fatalError("unreachable union case")
                                    }
                                default:
                                    fatalError("unreachable union case")
                            }
                            var v22: Bool = false
                            switch v21.tag {
                                case 1:
                                    v22 = true
                                default:
                                    v22 = false
                            }
                            if (v22) {
                                return sp_backtrack_stack_16(v7, v11)
                            } else {
                                return false
                            }
                        case 0:
                            return false
                        default:
                            fatalError("unreachable union case")
                    }
                case 0:
                    return false
                case 1:
                    return sp_backtrack_stack_16(v7, v1)
                case 5:
                    var v39: UH1 = (v6 as! UH1_RegexStar).f0
                    var v40: UH5 = UH5_RegexListNil()
                    v40 = UH5_RegexListCons(f0: v39, f1: v0)
                    var v41: Bool = false
                    v41 = sp_backtrack_stack_16(v40, v1)
                    if (v41) {
                        return true
                    } else {
                        return sp_backtrack_stack_16(v7, v1)
                    }
                default:
                    fatalError("unreachable union case")
            }
        case 0:
            switch v1.tag {
                case 1:
                    var v2: US0 = (v1 as! UH2_InputCons).f0
                    var v3: UH2 = (v1 as! UH2_InputCons).f1
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
func sp_loop_15(_ p0: UH1, _ p1: Int32, _ p2: Int32, _ p3: UInt64, _ p4: Int32) -> Int32 {
    var v0: UH1 = p0
    var v1: Int32 = p1
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
            let spiral_tuple468 = sp_random_bit_input_1(v3, v1, v6)
            v7 = spiral_tuple468.0
            v8 = spiral_tuple468.1
            var v9: UH5 = UH5_RegexListNil()
            v9 = UH5_RegexListNil()
            var v10: UH5 = UH5_RegexListNil()
            v10 = UH5_RegexListCons(f0: v0, f1: v9)
            var v11: Bool = false
            v11 = sp_backtrack_stack_16(v10, v7)
            var v13: Int32 = 0
            if (v11) {
                var v12: Int32 = 0
                v12 = (v4 &+ 1)
                v13 = v12
            } else {
                v13 = v4
            }
            var v14: Int32 = 0
            v14 = (v2 &- 1)
            let t1153_0: UH1 = v0
            let t1188_1: Int32 = v1
            let t1225_14: Int32 = v14
            let t1264_8: UInt64 = v8
            let t1302_13: Int32 = v13
            v0 = t1153_0
            v1 = t1188_1
            v2 = t1225_14
            v3 = t1264_8
            v4 = t1302_13
            continue
        } else {
            return v4
        }
    }
    return 0
}
func sp_loop_17(_ p0: UH1, _ p1: Int32, _ p2: Int32, _ p3: Int32) -> Int32 {
    var v0: UH1 = p0
    var v1: Int32 = p1
    var v2: Int32 = p2
    var v3: Int32 = p3
    while true {
        var v4: Bool = false
        v4 = (v1 < v2)
        if (v4) {
            return v3
        } else {
            var v5: UH2 = UH2_InputEmpty()
            v5 = UH2_InputEmpty()
            var v6: UH2 = UH2_InputEmpty()
            v6 = sp_zeros_input_14(v2, v5)
            var v7: UH5 = UH5_RegexListNil()
            v7 = UH5_RegexListNil()
            var v8: UH5 = UH5_RegexListNil()
            v8 = UH5_RegexListCons(f0: v0, f1: v7)
            var v9: Bool = false
            v9 = sp_backtrack_stack_16(v8, v6)
            var v11: Int32 = 0
            if (v9) {
                var v10: Int32 = 0
                v10 = (v3 &+ 1)
                v11 = v10
            } else {
                v11 = v3
            }
            var v12: US0 = US0_BitZero()
            v12 = US0_BitOne()
            var v13: UH2 = UH2_InputEmpty()
            v13 = UH2_InputEmpty()
            var v14: UH2 = UH2_InputEmpty()
            v14 = UH2_InputCons(f0: v12, f1: v13)
            var v15: UH2 = UH2_InputEmpty()
            v15 = sp_zeros_input_14(v2, v14)
            var v16: UH5 = UH5_RegexListNil()
            v16 = UH5_RegexListNil()
            var v17: UH5 = UH5_RegexListNil()
            v17 = UH5_RegexListCons(f0: v0, f1: v16)
            var v18: Bool = false
            v18 = sp_backtrack_stack_16(v17, v15)
            var v20: Int32 = 0
            if (v18) {
                var v19: Int32 = 0
                v19 = (v11 &+ 1)
                v20 = v19
            } else {
                v20 = v11
            }
            var v21: Int32 = 0
            v21 = (v2 &+ 1)
            let t1840_0: UH1 = v0
            let t1875_1: Int32 = v1
            let t1912_21: Int32 = v21
            let t1951_20: Int32 = v20
            v0 = t1840_0
            v1 = t1875_1
            v2 = t1912_21
            v3 = t1951_20
            continue
        }
    }
    return 0
}
func sp_run_19(_ p0: Int32, _ p1: UH2) -> Bool {
    var v0: Int32 = p0
    var v1: UH2 = p1
    switch v1.tag {
        case 1:
            var v3: US0 = (v1 as! UH2_InputCons).f0
            var v4: UH2 = (v1 as! UH2_InputCons).f1
            switch v3.tag {
                case 1:
                    var v9: Int32 = 0
                    v9 = 0
                    return sp_run_19(v9, v4)
                case 0:
                    var v6: Int32 = 0
                    v6 = 1
                    return sp_run_19(v6, v4)
                default:
                    fatalError("unreachable union case")
            }
        case 0:
            var v2: Bool = false
            v2 = (v0 == 1)
            return v2
        default:
            fatalError("unreachable union case")
    }
}
func sp_loop_18(_ p0: Int32, _ p1: Int32, _ p2: UInt64, _ p3: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: UInt64 = p2
    var v3: Int32 = p3
    while true {
        var v4: Bool = false
        v4 = (0 < v1)
        if (v4) {
            var v5: UH2 = UH2_InputEmpty()
            v5 = UH2_InputEmpty()
            var v6: UH2 = UH2_InputEmpty()
            var v7: UInt64 = (0 as UInt64)
            let spiral_tuple435 = sp_random_bit_input_1(v2, v0, v5)
            v6 = spiral_tuple435.0
            v7 = spiral_tuple435.1
            var v8: Int32 = 0
            v8 = 0
            var v9: Bool = false
            v9 = sp_run_19(v8, v6)
            var v11: Int32 = 0
            if (v9) {
                var v10: Int32 = 0
                v10 = (v3 &+ 1)
                v11 = v10
            } else {
                v11 = v3
            }
            var v12: Int32 = 0
            v12 = (v1 &- 1)
            let t972_0: Int32 = v0
            let t1008_12: Int32 = v12
            let t1047_7: UInt64 = v7
            let t1085_11: Int32 = v11
            v0 = t972_0
            v1 = t1008_12
            v2 = t1047_7
            v3 = t1085_11
            continue
        } else {
            return v3
        }
    }
    return 0
}
func sp_run_21(_ p0: Int32, _ p1: UH2) -> Bool {
    var v0: Int32 = p0
    var v1: UH2 = p1
    switch v1.tag {
        case 1:
            var v17: US0 = (v1 as! UH2_InputCons).f0
            var v18: UH2 = (v1 as! UH2_InputCons).f1
            switch v17.tag {
                case 1:
                    var v50: Bool = false
                    v50 = (v0 == 0)
                    var v79: Int32 = 0
                    if (v50) {
                        v79 = 1
                    } else {
                        var v51: Bool = false
                        v51 = (v0 == 1)
                        if (v51) {
                            v79 = 6
                        } else {
                            var v52: Bool = false
                            v52 = (v0 == 2)
                            if (v52) {
                                v79 = 11
                            } else {
                                var v53: Bool = false
                                v53 = (v0 == 3)
                                if (v53) {
                                    v79 = 5
                                } else {
                                    var v54: Bool = false
                                    v54 = (v0 == 4)
                                    if (v54) {
                                        v79 = 1
                                    } else {
                                        var v55: Bool = false
                                        v55 = (v0 == 5)
                                        if (v55) {
                                            v79 = 6
                                        } else {
                                            var v56: Bool = false
                                            v56 = (v0 == 6)
                                            if (v56) {
                                                v79 = 13
                                            } else {
                                                var v57: Bool = false
                                                v57 = (v0 == 7)
                                                if (v57) {
                                                    v79 = 9
                                                } else {
                                                    var v58: Bool = false
                                                    v58 = (v0 == 8)
                                                    if (v58) {
                                                        v79 = 5
                                                    } else {
                                                        var v59: Bool = false
                                                        v59 = (v0 == 9)
                                                        if (v59) {
                                                            v79 = 12
                                                        } else {
                                                            var v60: Bool = false
                                                            v60 = (v0 == 10)
                                                            if (v60) {
                                                                v79 = 11
                                                            } else {
                                                                var v61: Bool = false
                                                                v61 = (v0 == 11)
                                                                if (v61) {
                                                                    v79 = 12
                                                                } else {
                                                                    var v62: Bool = false
                                                                    v62 = (v0 == 12)
                                                                    if (v62) {
                                                                        v79 = 13
                                                                    } else {
                                                                        var v63: Bool = false
                                                                        v63 = (v0 == 13)
                                                                        if (v63) {
                                                                            v79 = 15
                                                                        } else {
                                                                            var v64: Bool = false
                                                                            v64 = (v0 == 14)
                                                                            if (v64) {
                                                                                v79 = 9
                                                                            } else {
                                                                                v79 = 15
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
                                }
                            }
                        }
                    }
                    return sp_run_21(v79, v18)
                case 0:
                    var v19: Bool = false
                    v19 = (v0 == 0)
                    var v48: Int32 = 0
                    if (v19) {
                        v48 = 0
                    } else {
                        var v20: Bool = false
                        v20 = (v0 == 1)
                        if (v20) {
                            v48 = 2
                        } else {
                            var v21: Bool = false
                            v21 = (v0 == 2)
                            if (v21) {
                                v48 = 3
                            } else {
                                var v22: Bool = false
                                v22 = (v0 == 3)
                                if (v22) {
                                    v48 = 4
                                } else {
                                    var v23: Bool = false
                                    v23 = (v0 == 4)
                                    if (v23) {
                                        v48 = 0
                                    } else {
                                        var v24: Bool = false
                                        v24 = (v0 == 5)
                                        if (v24) {
                                            v48 = 2
                                        } else {
                                            var v25: Bool = false
                                            v25 = (v0 == 6)
                                            if (v25) {
                                                v48 = 7
                                            } else {
                                                var v26: Bool = false
                                                v26 = (v0 == 7)
                                                if (v26) {
                                                    v48 = 8
                                                } else {
                                                    var v27: Bool = false
                                                    v27 = (v0 == 8)
                                                    if (v27) {
                                                        v48 = 4
                                                    } else {
                                                        var v28: Bool = false
                                                        v28 = (v0 == 9)
                                                        if (v28) {
                                                            v48 = 10
                                                        } else {
                                                            var v29: Bool = false
                                                            v29 = (v0 == 10)
                                                            if (v29) {
                                                                v48 = 3
                                                            } else {
                                                                var v30: Bool = false
                                                                v30 = (v0 == 11)
                                                                if (v30) {
                                                                    v48 = 10
                                                                } else {
                                                                    var v31: Bool = false
                                                                    v31 = (v0 == 12)
                                                                    if (v31) {
                                                                        v48 = 7
                                                                    } else {
                                                                        var v32: Bool = false
                                                                        v32 = (v0 == 13)
                                                                        if (v32) {
                                                                            v48 = 14
                                                                        } else {
                                                                            var v33: Bool = false
                                                                            v33 = (v0 == 14)
                                                                            if (v33) {
                                                                                v48 = 8
                                                                            } else {
                                                                                v48 = 14
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
                                }
                            }
                        }
                    }
                    return sp_run_21(v48, v18)
                default:
                    fatalError("unreachable union case")
            }
        case 0:
            var v2: Bool = false
            v2 = (v0 == 4)
            if (v2) {
                return true
            } else {
                var v3: Bool = false
                v3 = (v0 == 5)
                if (v3) {
                    return true
                } else {
                    var v4: Bool = false
                    v4 = (v0 == 8)
                    if (v4) {
                        return true
                    } else {
                        var v5: Bool = false
                        v5 = (v0 == 9)
                        if (v5) {
                            return true
                        } else {
                            var v6: Bool = false
                            v6 = (v0 == 10)
                            if (v6) {
                                return true
                            } else {
                                var v7: Bool = false
                                v7 = (v0 == 12)
                                if (v7) {
                                    return true
                                } else {
                                    var v8: Bool = false
                                    v8 = (v0 == 14)
                                    if (v8) {
                                        return true
                                    } else {
                                        var v9: Bool = false
                                        v9 = (v0 == 15)
                                        return v9
                                    }
                                }
                            }
                        }
                    }
                }
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_loop_20(_ p0: Int32, _ p1: Int32, _ p2: UInt64, _ p3: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: UInt64 = p2
    var v3: Int32 = p3
    while true {
        var v4: Bool = false
        v4 = (0 < v1)
        if (v4) {
            var v5: UH2 = UH2_InputEmpty()
            v5 = UH2_InputEmpty()
            var v6: UH2 = UH2_InputEmpty()
            var v7: UInt64 = (0 as UInt64)
            let spiral_tuple435 = sp_random_bit_input_1(v2, v0, v5)
            v6 = spiral_tuple435.0
            v7 = spiral_tuple435.1
            var v8: Int32 = 0
            v8 = 0
            var v9: Bool = false
            v9 = sp_run_21(v8, v6)
            var v11: Int32 = 0
            if (v9) {
                var v10: Int32 = 0
                v10 = (v3 &+ 1)
                v11 = v10
            } else {
                v11 = v3
            }
            var v12: Int32 = 0
            v12 = (v1 &- 1)
            let t972_0: Int32 = v0
            let t1008_12: Int32 = v12
            let t1047_7: UInt64 = v7
            let t1085_11: Int32 = v11
            v0 = t972_0
            v1 = t1008_12
            v2 = t1047_7
            v3 = t1085_11
            continue
        } else {
            return v3
        }
    }
    return 0
}
func sp_run_23(_ p0: Int32, _ p1: UH2) -> Bool {
    var v0: Int32 = p0
    var v1: UH2 = p1
    switch v1.tag {
        case 1:
            var v3: US0 = (v1 as! UH2_InputCons).f0
            var v4: UH2 = (v1 as! UH2_InputCons).f1
            switch v3.tag {
                case 1:
                    var v13: Bool = false
                    v13 = (v0 == 0)
                    var v19: Int32 = 0
                    if (v13) {
                        v19 = 3
                    } else {
                        var v14: Bool = false
                        v14 = (v0 == 1)
                        if (v14) {
                            v19 = 3
                        } else {
                            var v15: Bool = false
                            v15 = (v0 == 2)
                            if (v15) {
                                v19 = 3
                            } else {
                                v19 = 4
                            }
                        }
                    }
                    return sp_run_23(v19, v4)
                case 0:
                    var v5: Bool = false
                    v5 = (v0 == 0)
                    var v11: Int32 = 0
                    if (v5) {
                        v11 = 1
                    } else {
                        var v6: Bool = false
                        v6 = (v0 == 1)
                        if (v6) {
                            v11 = 2
                        } else {
                            var v7: Bool = false
                            v7 = (v0 == 2)
                            if (v7) {
                                v11 = 2
                            } else {
                                v11 = 4
                            }
                        }
                    }
                    return sp_run_23(v11, v4)
                default:
                    fatalError("unreachable union case")
            }
        case 0:
            var v2: Bool = false
            v2 = (v0 == 3)
            return v2
        default:
            fatalError("unreachable union case")
    }
}
func sp_loop_22(_ p0: Int32, _ p1: Int32, _ p2: Int32) -> Int32 {
    var v0: Int32 = p0
    var v1: Int32 = p1
    var v2: Int32 = p2
    while true {
        var v3: Bool = false
        v3 = (v0 < v1)
        if (v3) {
            return v2
        } else {
            var v4: UH2 = UH2_InputEmpty()
            v4 = UH2_InputEmpty()
            var v5: UH2 = UH2_InputEmpty()
            v5 = sp_zeros_input_14(v1, v4)
            var v6: Int32 = 0
            v6 = 0
            var v7: Bool = false
            v7 = sp_run_23(v6, v5)
            var v9: Int32 = 0
            if (v7) {
                var v8: Int32 = 0
                v8 = (v2 &+ 1)
                v9 = v8
            } else {
                v9 = v2
            }
            var v10: US0 = US0_BitZero()
            v10 = US0_BitOne()
            var v11: UH2 = UH2_InputEmpty()
            v11 = UH2_InputEmpty()
            var v12: UH2 = UH2_InputEmpty()
            v12 = UH2_InputCons(f0: v10, f1: v11)
            var v13: UH2 = UH2_InputEmpty()
            v13 = sp_zeros_input_14(v1, v12)
            var v14: Int32 = 0
            v14 = 0
            var v15: Bool = false
            v15 = sp_run_23(v14, v13)
            var v17: Int32 = 0
            if (v15) {
                var v16: Int32 = 0
                v16 = (v9 &+ 1)
                v17 = v16
            } else {
                v17 = v9
            }
            var v18: Int32 = 0
            v18 = (v1 &+ 1)
            let t1512_0: Int32 = v0
            let t1549_18: Int32 = v18
            let t1588_17: Int32 = v17
            v0 = t1512_0
            v1 = t1549_18
            v2 = t1588_17
            continue
        }
    }
    return 0
}
func sp_loop_24(_ p0: SpiralArray<Int32>, _ p1: Int32) {
    var v0: SpiralArray<Int32> = p0
    var v1: Int32 = p1
    while true {
        var v2: Bool = false
        v2 = (v1 < 8192)
        if (v2) {
            v0.items[Int(v1)] = 0
            var v3: Int32 = 0
            v3 = (v1 &+ 1)
            let t306_0: SpiralArray<Int32> = v0
            let t355_3: Int32 = v3
            v0 = t306_0
            v1 = t355_3
            continue
        } else {
            return
        }
    }
}
func sp_loop_25(_ p0: SpiralArray<Int32>, _ p1: Int32) {
    var v0: SpiralArray<Int32> = p0
    var v1: Int32 = p1
    while true {
        var v2: Bool = false
        v2 = (v1 < 1)
        if (v2) {
            v0.items[Int(v1)] = 0
            var v3: Int32 = 0
            v3 = (v1 &+ 1)
            let t303_0: SpiralArray<Int32> = v0
            let t352_3: Int32 = v3
            v0 = t303_0
            v1 = t352_3
            continue
        } else {
            return
        }
    }
}
func sp_probe_27(_ p0: SpiralArray<Int32>, _ p1: SpiralArray<Int32>, _ p2: SpiralArray<Int32>, _ p3: SpiralArray<Int32>, _ p4: SpiralArray<Int32>, _ p5: SpiralArray<Int32>, _ p6: SpiralArray<Int32>, _ p7: Int32, _ p8: Int32, _ p9: Int32, _ p10: Int32) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: SpiralArray<Int32> = p1
    var v2: SpiralArray<Int32> = p2
    var v3: SpiralArray<Int32> = p3
    var v4: SpiralArray<Int32> = p4
    var v5: SpiralArray<Int32> = p5
    var v6: SpiralArray<Int32> = p6
    var v7: Int32 = p7
    var v8: Int32 = p8
    var v9: Int32 = p9
    var v10: Int32 = p10
    while true {
        var v11: Int32 = 0
        v11 = v4.items[Int(v10)]
        var v12: Bool = false
        v12 = (v11 == 0)
        if (v12) {
            var v13: Int32 = 0
            v13 = v6.items[Int(0)]
            var v14: Bool = false
            v14 = (v13 < 4096)
            if (v14) {
                v0.items[Int(v13)] = v7
                v1.items[Int(v13)] = v8
                v2.items[Int(v13)] = v9
                var v15: Bool = false
                v15 = (v7 == 1)
                var v32: Bool = false
                if (v15) {
                    v32 = true
                } else {
                    var v16: Bool = false
                    v16 = (v7 == 5)
                    if (v16) {
                        v32 = true
                    } else {
                        var v17: Bool = false
                        v17 = (v7 == 3)
                        if (v17) {
                            var v18: Int32 = 0
                            v18 = v3.items[Int(v8)]
                            var v19: Bool = false
                            v19 = (v18 == 1)
                            if (v19) {
                                v32 = true
                            } else {
                                var v20: Int32 = 0
                                v20 = v3.items[Int(v9)]
                                var v21: Bool = false
                                v21 = (v20 == 1)
                                v32 = v21
                            }
                        } else {
                            var v23: Bool = false
                            v23 = (v7 == 4)
                            if (v23) {
                                var v24: Int32 = 0
                                v24 = v3.items[Int(v8)]
                                var v25: Bool = false
                                v25 = (v24 == 1)
                                if (v25) {
                                    var v26: Int32 = 0
                                    v26 = v3.items[Int(v9)]
                                    var v27: Bool = false
                                    v27 = (v26 == 1)
                                    v32 = v27
                                } else {
                                    v32 = false
                                }
                            } else {
                                v32 = false
                            }
                        }
                    }
                }
                var v33: Int32 = 0
                if (v32) {
                    v33 = 1
                } else {
                    v33 = 0
                }
                v3.items[Int(v13)] = v33
                var v34: Int32 = 0
                v34 = (v13 &+ 1)
                v4.items[Int(v10)] = v34
                v6.items[Int(0)] = v34
                return v13
            } else {
                "brzozowski-interned-store-full".withCString { ptr in _ = fputs(ptr, stderr) }
                fputs("\n", stderr)
                exit(1)
            }
        } else {
            var v37: Int32 = 0
            v37 = (v11 &- 1)
            var v38: Int32 = 0
            v38 = v0.items[Int(v37)]
            var v39: Bool = false
            v39 = (v38 == v7)
            var v42: Bool = false
            if (v39) {
                var v40: Int32 = 0
                v40 = v1.items[Int(v37)]
                var v41: Bool = false
                v41 = (v40 == v8)
                v42 = v41
            } else {
                v42 = false
            }
            var v45: Bool = false
            if (v42) {
                var v43: Int32 = 0
                v43 = v2.items[Int(v37)]
                var v44: Bool = false
                v44 = (v43 == v9)
                v45 = v44
            } else {
                v45 = false
            }
            if (v45) {
                return v37
            } else {
                var v46: Int32 = 0
                v46 = (v10 &+ 1)
                var v47: Int32 = 0
                v47 = (v46 & 8191)
                let t4805_0: SpiralArray<Int32> = v0
                let t4859_1: SpiralArray<Int32> = v1
                let t4913_2: SpiralArray<Int32> = v2
                let t4967_3: SpiralArray<Int32> = v3
                let t5021_4: SpiralArray<Int32> = v4
                let t5075_5: SpiralArray<Int32> = v5
                let t5129_6: SpiralArray<Int32> = v6
                let t5183_7: Int32 = v7
                let t5224_8: Int32 = v8
                let t5265_9: Int32 = v9
                let t5306_47: Int32 = v47
                v0 = t4805_0
                v1 = t4859_1
                v2 = t4913_2
                v3 = t4967_3
                v4 = t5021_4
                v5 = t5075_5
                v6 = t5129_6
                v7 = t5183_7
                v8 = t5224_8
                v9 = t5265_9
                v10 = t5306_47
                continue
            }
        }
    }
    return 0
}
func sp_interned_node_26(_ p0: SpiralArray<Int32>, _ p1: SpiralArray<Int32>, _ p2: SpiralArray<Int32>, _ p3: SpiralArray<Int32>, _ p4: SpiralArray<Int32>, _ p5: SpiralArray<Int32>, _ p6: SpiralArray<Int32>, _ p7: Int32, _ p8: Int32, _ p9: Int32) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: SpiralArray<Int32> = p1
    var v2: SpiralArray<Int32> = p2
    var v3: SpiralArray<Int32> = p3
    var v4: SpiralArray<Int32> = p4
    var v5: SpiralArray<Int32> = p5
    var v6: SpiralArray<Int32> = p6
    var v7: Int32 = p7
    var v8: Int32 = p8
    var v9: Int32 = p9
    var v10: Int32 = 0
    v10 = (v7 &* 1024)
    var v11: Int32 = 0
    v11 = (v10 &+ v8)
    var v12: Int32 = 0
    v12 = (v11 &* 4099)
    var v13: Int32 = 0
    v13 = (v12 &+ v9)
    var v14: Int32 = 0
    v14 = (v13 & 8191)
    return sp_probe_27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14)
}
func sp_interned_alt_insert_30(_ p0: SpiralArray<Int32>, _ p1: SpiralArray<Int32>, _ p2: SpiralArray<Int32>, _ p3: SpiralArray<Int32>, _ p4: SpiralArray<Int32>, _ p5: SpiralArray<Int32>, _ p6: SpiralArray<Int32>, _ p7: Int32, _ p8: Int32) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: SpiralArray<Int32> = p1
    var v2: SpiralArray<Int32> = p2
    var v3: SpiralArray<Int32> = p3
    var v4: SpiralArray<Int32> = p4
    var v5: SpiralArray<Int32> = p5
    var v6: SpiralArray<Int32> = p6
    var v7: Int32 = p7
    var v8: Int32 = p8
    var v9: Bool = false
    v9 = (v8 == 0)
    if (v9) {
        return v7
    } else {
        var v10: Int32 = 0
        v10 = v0.items[Int(v8)]
        var v11: Bool = false
        v11 = (v10 == 3)
        if (v11) {
            var v12: Int32 = 0
            v12 = v1.items[Int(v8)]
            var v13: Bool = false
            v13 = (v7 < v12)
            if (v13) {
                var v14: Int32 = 0
                v14 = 3
                return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8)
            } else {
                var v16: Bool = false
                v16 = (v7 == v12)
                if (v16) {
                    return v8
                } else {
                    var v17: Int32 = 0
                    v17 = 3
                    var v18: Int32 = 0
                    v18 = v2.items[Int(v8)]
                    var v19: Int32 = 0
                    v19 = sp_interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v18)
                    return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19)
                }
            }
        } else {
            var v23: Bool = false
            v23 = (v7 < v8)
            if (v23) {
                var v24: Int32 = 0
                v24 = 3
                return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8)
            } else {
                var v26: Bool = false
                v26 = (v7 == v8)
                if (v26) {
                    return v8
                } else {
                    var v27: Int32 = 0
                    v27 = 3
                    return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7)
                }
            }
        }
    }
}
func sp_interned_make_alt_29(_ p0: SpiralArray<Int32>, _ p1: SpiralArray<Int32>, _ p2: SpiralArray<Int32>, _ p3: SpiralArray<Int32>, _ p4: SpiralArray<Int32>, _ p5: SpiralArray<Int32>, _ p6: SpiralArray<Int32>, _ p7: Int32, _ p8: Int32) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: SpiralArray<Int32> = p1
    var v2: SpiralArray<Int32> = p2
    var v3: SpiralArray<Int32> = p3
    var v4: SpiralArray<Int32> = p4
    var v5: SpiralArray<Int32> = p5
    var v6: SpiralArray<Int32> = p6
    var v7: Int32 = p7
    var v8: Int32 = p8
    while true {
        var v9: Bool = false
        v9 = (v7 == 0)
        if (v9) {
            return v8
        } else {
            var v10: Int32 = 0
            v10 = v0.items[Int(v7)]
            var v11: Bool = false
            v11 = (v10 == 3)
            if (v11) {
                var v12: Int32 = 0
                v12 = v2.items[Int(v7)]
                var v13: Int32 = 0
                v13 = v1.items[Int(v7)]
                var v14: Int32 = 0
                v14 = sp_interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v13, v8)
                let t1122_0: SpiralArray<Int32> = v0
                let t1176_1: SpiralArray<Int32> = v1
                let t1230_2: SpiralArray<Int32> = v2
                let t1284_3: SpiralArray<Int32> = v3
                let t1338_4: SpiralArray<Int32> = v4
                let t1392_5: SpiralArray<Int32> = v5
                let t1446_6: SpiralArray<Int32> = v6
                let t1500_12: Int32 = v12
                let t1543_14: Int32 = v14
                v0 = t1122_0
                v1 = t1176_1
                v2 = t1230_2
                v3 = t1284_3
                v4 = t1338_4
                v5 = t1392_5
                v6 = t1446_6
                v7 = t1500_12
                v8 = t1543_14
                continue
            } else {
                return sp_interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v8)
            }
        }
    }
    return 0
}
func sp_interned_make_cat_31(_ p0: SpiralArray<Int32>, _ p1: SpiralArray<Int32>, _ p2: SpiralArray<Int32>, _ p3: SpiralArray<Int32>, _ p4: SpiralArray<Int32>, _ p5: SpiralArray<Int32>, _ p6: SpiralArray<Int32>, _ p7: Int32, _ p8: Int32) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: SpiralArray<Int32> = p1
    var v2: SpiralArray<Int32> = p2
    var v3: SpiralArray<Int32> = p3
    var v4: SpiralArray<Int32> = p4
    var v5: SpiralArray<Int32> = p5
    var v6: SpiralArray<Int32> = p6
    var v7: Int32 = p7
    var v8: Int32 = p8
    var v9: Bool = false
    v9 = (v7 == 0)
    if (v9) {
        return 0
    } else {
        var v10: Bool = false
        v10 = (v8 == 0)
        if (v10) {
            return 0
        } else {
            var v11: Bool = false
            v11 = (v7 == 1)
            if (v11) {
                return v8
            } else {
                var v12: Bool = false
                v12 = (v8 == 1)
                if (v12) {
                    return v7
                } else {
                    var v13: Int32 = 0
                    v13 = v0.items[Int(v7)]
                    var v14: Bool = false
                    v14 = (v13 == 5)
                    var v17: Bool = false
                    if (v14) {
                        var v15: Int32 = 0
                        v15 = v0.items[Int(v8)]
                        var v16: Bool = false
                        v16 = (v15 == 5)
                        v17 = v16
                    } else {
                        v17 = false
                    }
                    if (v17) {
                        var v18: Int32 = 0
                        v18 = v1.items[Int(v7)]
                        var v19: Int32 = 0
                        v19 = v1.items[Int(v8)]
                        var v20: Bool = false
                        v20 = (v18 == v19)
                        if (v20) {
                            return v7
                        } else {
                            var v21: Int32 = 0
                            v21 = 4
                            return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8)
                        }
                    } else {
                        var v24: Int32 = 0
                        v24 = v0.items[Int(v7)]
                        var v25: Bool = false
                        v25 = (v24 == 4)
                        if (v25) {
                            var v26: Int32 = 0
                            v26 = 4
                            var v27: Int32 = 0
                            v27 = v1.items[Int(v7)]
                            var v28: Int32 = 0
                            v28 = v2.items[Int(v7)]
                            var v29: Int32 = 0
                            v29 = sp_interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v8)
                            return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29)
                        } else {
                            var v31: Int32 = 0
                            v31 = 4
                            return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8)
                        }
                    }
                }
            }
        }
    }
}
func sp_interned_of_regex_raw_28(_ p0: SpiralArray<Int32>, _ p1: SpiralArray<Int32>, _ p2: SpiralArray<Int32>, _ p3: SpiralArray<Int32>, _ p4: SpiralArray<Int32>, _ p5: SpiralArray<Int32>, _ p6: SpiralArray<Int32>, _ p7: UH1) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: SpiralArray<Int32> = p1
    var v2: SpiralArray<Int32> = p2
    var v3: SpiralArray<Int32> = p3
    var v4: SpiralArray<Int32> = p4
    var v5: SpiralArray<Int32> = p5
    var v6: SpiralArray<Int32> = p6
    var v7: UH1 = p7
    switch v7.tag {
        case 3:
            var v14: UH1 = (v7 as! UH1_RegexAlt).f0
            var v15: UH1 = (v7 as! UH1_RegexAlt).f1
            var v16: Int32 = 0
            v16 = sp_interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v14)
            var v17: Int32 = 0
            v17 = sp_interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v15)
            return sp_interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v16, v17)
        case 4:
            var v19: UH1 = (v7 as! UH1_RegexCat).f0
            var v20: UH1 = (v7 as! UH1_RegexCat).f1
            var v21: Int32 = 0
            v21 = sp_interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v19)
            var v22: Int32 = 0
            v22 = sp_interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v20)
            return sp_interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v21, v22)
        case 2:
            var v8: US0 = (v7 as! UH1_RegexChar).f0
            var v9: Int32 = 0
            v9 = 2
            var v11: Int32 = 0
            switch v8.tag {
                case 1:
                    v11 = 1
                case 0:
                    v11 = 0
                default:
                    fatalError("unreachable union case")
            }
            var v12: Int32 = 0
            v12 = 0
            return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12)
        case 0:
            return 0
        case 1:
            return 1
        case 5:
            var v24: UH1 = (v7 as! UH1_RegexStar).f0
            var v25: Int32 = 0
            v25 = sp_interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v24)
            var v26: Int32 = 0
            v26 = v0.items[Int(v25)]
            var v27: Bool = false
            v27 = (v26 < 2)
            if (v27) {
                return 1
            } else {
                var v28: Bool = false
                v28 = (v26 == 5)
                if (v28) {
                    return v25
                } else {
                    var v29: Int32 = 0
                    v29 = 5
                    var v30: Int32 = 0
                    v30 = 0
                    return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30)
                }
            }
        default:
            fatalError("unreachable union case")
    }
}
func sp_interned_derivative_raw_35(_ p0: SpiralArray<Int32>, _ p1: SpiralArray<Int32>, _ p2: SpiralArray<Int32>, _ p3: SpiralArray<Int32>, _ p4: SpiralArray<Int32>, _ p5: SpiralArray<Int32>, _ p6: SpiralArray<Int32>, _ p7: Int32, _ p8: Int32) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: SpiralArray<Int32> = p1
    var v2: SpiralArray<Int32> = p2
    var v3: SpiralArray<Int32> = p3
    var v4: SpiralArray<Int32> = p4
    var v5: SpiralArray<Int32> = p5
    var v6: SpiralArray<Int32> = p6
    var v7: Int32 = p7
    var v8: Int32 = p8
    var v9: Int32 = 0
    v9 = (v7 &* 2)
    var v10: Int32 = 0
    v10 = (v9 &+ v8)
    var v11: Int32 = 0
    v11 = v5.items[Int(v10)]
    var v12: Bool = false
    v12 = (v11 == 0)
    if (v12) {
        var v13: Int32 = 0
        v13 = v0.items[Int(v7)]
        var v14: Bool = false
        v14 = (v13 < 2)
        var v41: Int32 = 0
        if (v14) {
            v41 = 0
        } else {
            var v15: Bool = false
            v15 = (v13 == 2)
            if (v15) {
                var v16: Int32 = 0
                v16 = v1.items[Int(v7)]
                var v17: Bool = false
                v17 = (v16 == v8)
                if (v17) {
                    v41 = 1
                } else {
                    v41 = 0
                }
            } else {
                var v19: Bool = false
                v19 = (v13 == 3)
                if (v19) {
                    var v20: Int32 = 0
                    v20 = v1.items[Int(v7)]
                    var v21: Int32 = 0
                    v21 = sp_interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v20, v8)
                    var v22: Int32 = 0
                    v22 = v2.items[Int(v7)]
                    var v23: Int32 = 0
                    v23 = sp_interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v22, v8)
                    v41 = sp_interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v21, v23)
                } else {
                    var v25: Bool = false
                    v25 = (v13 == 4)
                    if (v25) {
                        var v26: Int32 = 0
                        v26 = v1.items[Int(v7)]
                        var v27: Int32 = 0
                        v27 = v2.items[Int(v7)]
                        var v28: Int32 = 0
                        v28 = sp_interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v26, v8)
                        var v29: Int32 = 0
                        v29 = sp_interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v27)
                        var v30: Int32 = 0
                        v30 = v3.items[Int(v26)]
                        var v31: Bool = false
                        v31 = (v30 == 1)
                        if (v31) {
                            var v32: Int32 = 0
                            v32 = sp_interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v27, v8)
                            v41 = sp_interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v29, v32)
                        } else {
                            v41 = v29
                        }
                    } else {
                        var v35: Int32 = 0
                        v35 = v1.items[Int(v7)]
                        var v36: Int32 = 0
                        v36 = sp_interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v35, v8)
                        v41 = sp_interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v36, v7)
                    }
                }
            }
        }
        var v42: Int32 = 0
        v42 = (v41 &+ 1)
        v5.items[Int(v10)] = v42
        return v41
    } else {
        var v43: Int32 = 0
        v43 = (v11 &- 1)
        return v43
    }
}
func sp_loop_34(_ p0: SpiralArray<Int32>, _ p1: SpiralArray<Int32>, _ p2: SpiralArray<Int32>, _ p3: SpiralArray<Int32>, _ p4: SpiralArray<Int32>, _ p5: SpiralArray<Int32>, _ p6: SpiralArray<Int32>, _ p7: Int32, _ p8: UH2) -> Bool {
    var v0: SpiralArray<Int32> = p0
    var v1: SpiralArray<Int32> = p1
    var v2: SpiralArray<Int32> = p2
    var v3: SpiralArray<Int32> = p3
    var v4: SpiralArray<Int32> = p4
    var v5: SpiralArray<Int32> = p5
    var v6: SpiralArray<Int32> = p6
    var v7: Int32 = p7
    var v8: UH2 = p8
    var v9: Bool = false
    v9 = (v7 == 0)
    if (v9) {
        return false
    } else {
        switch v8.tag {
            case 1:
                var v12: US0 = (v8 as! UH2_InputCons).f0
                var v13: UH2 = (v8 as! UH2_InputCons).f1
                var v15: Int32 = 0
                switch v12.tag {
                    case 1:
                        v15 = 1
                    case 0:
                        v15 = 0
                    default:
                        fatalError("unreachable union case")
                }
                var v16: Int32 = 0
                v16 = sp_interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v7, v15)
                return sp_loop_34(v0, v1, v2, v3, v4, v5, v6, v16, v13)
            case 0:
                var v10: Int32 = 0
                v10 = v3.items[Int(v7)]
                var v11: Bool = false
                v11 = (v10 == 1)
                return v11
            default:
                fatalError("unreachable union case")
        }
    }
}
func sp_interned_accepts_33(_ p0: SpiralArray<Int32>, _ p1: SpiralArray<Int32>, _ p2: SpiralArray<Int32>, _ p3: SpiralArray<Int32>, _ p4: SpiralArray<Int32>, _ p5: SpiralArray<Int32>, _ p6: SpiralArray<Int32>, _ p7: Int32, _ p8: UH2) -> Bool {
    var v0: SpiralArray<Int32> = p0
    var v1: SpiralArray<Int32> = p1
    var v2: SpiralArray<Int32> = p2
    var v3: SpiralArray<Int32> = p3
    var v4: SpiralArray<Int32> = p4
    var v5: SpiralArray<Int32> = p5
    var v6: SpiralArray<Int32> = p6
    var v7: Int32 = p7
    var v8: UH2 = p8
    return sp_loop_34(v0, v1, v2, v3, v4, v5, v6, v7, v8)
}
func sp_loop_32(_ p0: SpiralArray<Int32>, _ p1: SpiralArray<Int32>, _ p2: SpiralArray<Int32>, _ p3: SpiralArray<Int32>, _ p4: SpiralArray<Int32>, _ p5: SpiralArray<Int32>, _ p6: SpiralArray<Int32>, _ p7: Int32, _ p8: Int32, _ p9: Int32, _ p10: UInt64, _ p11: Int32) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: SpiralArray<Int32> = p1
    var v2: SpiralArray<Int32> = p2
    var v3: SpiralArray<Int32> = p3
    var v4: SpiralArray<Int32> = p4
    var v5: SpiralArray<Int32> = p5
    var v6: SpiralArray<Int32> = p6
    var v7: Int32 = p7
    var v8: Int32 = p8
    var v9: Int32 = p9
    var v10: UInt64 = p10
    var v11: Int32 = p11
    while true {
        var v12: Bool = false
        v12 = (0 < v9)
        if (v12) {
            var v13: UH2 = UH2_InputEmpty()
            v13 = UH2_InputEmpty()
            var v14: UH2 = UH2_InputEmpty()
            var v15: UInt64 = (0 as UInt64)
            let spiral_tuple926 = sp_random_bit_input_1(v10, v7, v13)
            v14 = spiral_tuple926.0
            v15 = spiral_tuple926.1
            var v16: Bool = false
            v16 = sp_interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v14)
            var v18: Int32 = 0
            if (v16) {
                var v17: Int32 = 0
                v17 = (v11 &+ 1)
                v18 = v17
            } else {
                v18 = v11
            }
            var v19: Int32 = 0
            v19 = (v9 &- 1)
            let t1463_0: SpiralArray<Int32> = v0
            let t1513_1: SpiralArray<Int32> = v1
            let t1563_2: SpiralArray<Int32> = v2
            let t1613_3: SpiralArray<Int32> = v3
            let t1663_4: SpiralArray<Int32> = v4
            let t1713_5: SpiralArray<Int32> = v5
            let t1763_6: SpiralArray<Int32> = v6
            let t1813_7: Int32 = v7
            let t1850_8: Int32 = v8
            let t1887_19: Int32 = v19
            let t1926_15: UInt64 = v15
            let t1966_18: Int32 = v18
            v0 = t1463_0
            v1 = t1513_1
            v2 = t1563_2
            v3 = t1613_3
            v4 = t1663_4
            v5 = t1713_5
            v6 = t1763_6
            v7 = t1813_7
            v8 = t1850_8
            v9 = t1887_19
            v10 = t1926_15
            v11 = t1966_18
            continue
        } else {
            return v11
        }
    }
    return 0
}
func sp_loop_36(_ p0: SpiralArray<Int32>, _ p1: SpiralArray<Int32>, _ p2: SpiralArray<Int32>, _ p3: SpiralArray<Int32>, _ p4: SpiralArray<Int32>, _ p5: SpiralArray<Int32>, _ p6: SpiralArray<Int32>, _ p7: Int32, _ p8: Int32, _ p9: Int32, _ p10: Int32) -> Int32 {
    var v0: SpiralArray<Int32> = p0
    var v1: SpiralArray<Int32> = p1
    var v2: SpiralArray<Int32> = p2
    var v3: SpiralArray<Int32> = p3
    var v4: SpiralArray<Int32> = p4
    var v5: SpiralArray<Int32> = p5
    var v6: SpiralArray<Int32> = p6
    var v7: Int32 = p7
    var v8: Int32 = p8
    var v9: Int32 = p9
    var v10: Int32 = p10
    while true {
        var v11: Bool = false
        v11 = (v7 < v9)
        if (v11) {
            return v10
        } else {
            var v12: UH2 = UH2_InputEmpty()
            v12 = UH2_InputEmpty()
            var v13: UH2 = UH2_InputEmpty()
            v13 = sp_zeros_input_14(v9, v12)
            var v14: Bool = false
            v14 = sp_interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v13)
            var v16: Int32 = 0
            if (v14) {
                var v15: Int32 = 0
                v15 = (v10 &+ 1)
                v16 = v15
            } else {
                v16 = v10
            }
            var v17: US0 = US0_BitZero()
            v17 = US0_BitOne()
            var v18: UH2 = UH2_InputEmpty()
            v18 = UH2_InputEmpty()
            var v19: UH2 = UH2_InputEmpty()
            v19 = UH2_InputCons(f0: v17, f1: v18)
            var v20: UH2 = UH2_InputEmpty()
            v20 = sp_zeros_input_14(v9, v19)
            var v21: Bool = false
            v21 = sp_interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v20)
            var v23: Int32 = 0
            if (v21) {
                var v22: Int32 = 0
                v22 = (v16 &+ 1)
                v23 = v22
            } else {
                v23 = v16
            }
            var v24: Int32 = 0
            v24 = (v9 &+ 1)
            let t1993_0: SpiralArray<Int32> = v0
            let t2043_1: SpiralArray<Int32> = v1
            let t2093_2: SpiralArray<Int32> = v2
            let t2143_3: SpiralArray<Int32> = v3
            let t2193_4: SpiralArray<Int32> = v4
            let t2243_5: SpiralArray<Int32> = v5
            let t2293_6: SpiralArray<Int32> = v6
            let t2343_7: Int32 = v7
            let t2380_8: Int32 = v8
            let t2417_24: Int32 = v24
            let t2456_23: Int32 = v23
            v0 = t1993_0
            v1 = t2043_1
            v2 = t2093_2
            v3 = t2143_3
            v4 = t2193_4
            v5 = t2243_5
            v6 = t2293_6
            v7 = t2343_7
            v8 = t2380_8
            v9 = t2417_24
            v10 = t2456_23
            continue
        }
    }
    return 0
}
func spiral_main() -> Int32 {
    var v0: Int32 = 0
    v0 = 200
    var v1: Int32 = 0
    v1 = 32
    var v2: US0 = US0_BitZero()
    v2 = US0_BitZero()
    var v3: UH1 = UH1_RegexEmpty()
    v3 = UH1_RegexChar(f0: v2)
    var v4: US0 = US0_BitZero()
    v4 = US0_BitOne()
    var v5: UH1 = UH1_RegexEmpty()
    v5 = UH1_RegexChar(f0: v4)
    var v6: UH1 = UH1_RegexEmpty()
    v6 = UH1_RegexAlt(f0: v3, f1: v5)
    var v7: UH1 = UH1_RegexEmpty()
    v7 = UH1_RegexStar(f0: v6)
    var v8: US0 = US0_BitZero()
    v8 = US0_BitZero()
    var v9: UH1 = UH1_RegexEmpty()
    v9 = UH1_RegexChar(f0: v8)
    var v10: UH1 = UH1_RegexEmpty()
    v10 = UH1_RegexCat(f0: v7, f1: v9)
    var v11: US0 = US0_BitZero()
    v11 = US0_BitZero()
    var v12: UH1 = UH1_RegexEmpty()
    v12 = UH1_RegexChar(f0: v11)
    var v13: US0 = US0_BitZero()
    v13 = US0_BitOne()
    var v14: UH1 = UH1_RegexEmpty()
    v14 = UH1_RegexChar(f0: v13)
    var v15: UH1 = UH1_RegexEmpty()
    v15 = UH1_RegexAlt(f0: v12, f1: v14)
    var v16: UH1 = UH1_RegexEmpty()
    v16 = UH1_RegexStar(f0: v15)
    var v17: US0 = US0_BitZero()
    v17 = US0_BitOne()
    var v18: UH1 = UH1_RegexEmpty()
    v18 = UH1_RegexChar(f0: v17)
    var v19: US0 = US0_BitZero()
    v19 = US0_BitZero()
    var v20: UH1 = UH1_RegexEmpty()
    v20 = UH1_RegexChar(f0: v19)
    var v21: US0 = US0_BitZero()
    v21 = US0_BitOne()
    var v22: UH1 = UH1_RegexEmpty()
    v22 = UH1_RegexChar(f0: v21)
    var v23: UH1 = UH1_RegexEmpty()
    v23 = UH1_RegexAlt(f0: v20, f1: v22)
    var v24: US0 = US0_BitZero()
    v24 = US0_BitZero()
    var v25: UH1 = UH1_RegexEmpty()
    v25 = UH1_RegexChar(f0: v24)
    var v26: US0 = US0_BitZero()
    v26 = US0_BitOne()
    var v27: UH1 = UH1_RegexEmpty()
    v27 = UH1_RegexChar(f0: v26)
    var v28: UH1 = UH1_RegexEmpty()
    v28 = UH1_RegexAlt(f0: v25, f1: v27)
    var v29: US0 = US0_BitZero()
    v29 = US0_BitZero()
    var v30: UH1 = UH1_RegexEmpty()
    v30 = UH1_RegexChar(f0: v29)
    var v31: US0 = US0_BitZero()
    v31 = US0_BitOne()
    var v32: UH1 = UH1_RegexEmpty()
    v32 = UH1_RegexChar(f0: v31)
    var v33: UH1 = UH1_RegexEmpty()
    v33 = UH1_RegexAlt(f0: v30, f1: v32)
    var v34: UH1 = UH1_RegexEmpty()
    v34 = UH1_RegexCat(f0: v28, f1: v33)
    var v35: UH1 = UH1_RegexEmpty()
    v35 = UH1_RegexCat(f0: v23, f1: v34)
    var v36: UH1 = UH1_RegexEmpty()
    v36 = UH1_RegexCat(f0: v18, f1: v35)
    var v37: UH1 = UH1_RegexEmpty()
    v37 = UH1_RegexCat(f0: v16, f1: v36)
    var v38: UInt64 = (0 as UInt64)
    v38 = (1 as UInt64)
    var v39: Int32 = 0
    v39 = 0
    var v40: Int32 = 0
    v40 = sp_loop_0(v10, v1, v0, v38, v39)
    var v41: Int32 = 0
    v41 = sp_loop_0(v37, v1, v0, v38, v39)
    var v42: Int32 = 0
    v42 = 16
    var v43: US0 = US0_BitZero()
    v43 = US0_BitZero()
    var v44: UH1 = UH1_RegexEmpty()
    v44 = UH1_RegexChar(f0: v43)
    var v45: US0 = US0_BitZero()
    v45 = US0_BitZero()
    var v46: UH1 = UH1_RegexEmpty()
    v46 = UH1_RegexChar(f0: v45)
    var v47: US0 = US0_BitZero()
    v47 = US0_BitZero()
    var v48: UH1 = UH1_RegexEmpty()
    v48 = UH1_RegexChar(f0: v47)
    var v49: UH1 = UH1_RegexEmpty()
    v49 = UH1_RegexCat(f0: v46, f1: v48)
    var v50: UH1 = UH1_RegexEmpty()
    v50 = UH1_RegexAlt(f0: v44, f1: v49)
    var v51: UH1 = UH1_RegexEmpty()
    v51 = UH1_RegexStar(f0: v50)
    var v52: US0 = US0_BitZero()
    v52 = US0_BitOne()
    var v53: UH1 = UH1_RegexEmpty()
    v53 = UH1_RegexChar(f0: v52)
    var v54: UH1 = UH1_RegexEmpty()
    v54 = UH1_RegexCat(f0: v51, f1: v53)
    var v55: Int32 = 0
    v55 = 0
    var v56: Int32 = 0
    v56 = 1
    var v57: Int32 = 0
    v57 = sp_loop_13(v54, v42, v56, v55)
    var v58: Int32 = 0
    v58 = 200
    var v59: Int32 = 0
    v59 = 32
    var v60: US0 = US0_BitZero()
    v60 = US0_BitZero()
    var v61: UH1 = UH1_RegexEmpty()
    v61 = UH1_RegexChar(f0: v60)
    var v62: US0 = US0_BitZero()
    v62 = US0_BitOne()
    var v63: UH1 = UH1_RegexEmpty()
    v63 = UH1_RegexChar(f0: v62)
    var v64: UH1 = UH1_RegexEmpty()
    v64 = UH1_RegexAlt(f0: v61, f1: v63)
    var v65: UH1 = UH1_RegexEmpty()
    v65 = UH1_RegexStar(f0: v64)
    var v66: US0 = US0_BitZero()
    v66 = US0_BitZero()
    var v67: UH1 = UH1_RegexEmpty()
    v67 = UH1_RegexChar(f0: v66)
    var v68: UH1 = UH1_RegexEmpty()
    v68 = UH1_RegexCat(f0: v65, f1: v67)
    var v69: US0 = US0_BitZero()
    v69 = US0_BitZero()
    var v70: UH1 = UH1_RegexEmpty()
    v70 = UH1_RegexChar(f0: v69)
    var v71: US0 = US0_BitZero()
    v71 = US0_BitOne()
    var v72: UH1 = UH1_RegexEmpty()
    v72 = UH1_RegexChar(f0: v71)
    var v73: UH1 = UH1_RegexEmpty()
    v73 = UH1_RegexAlt(f0: v70, f1: v72)
    var v74: UH1 = UH1_RegexEmpty()
    v74 = UH1_RegexStar(f0: v73)
    var v75: US0 = US0_BitZero()
    v75 = US0_BitOne()
    var v76: UH1 = UH1_RegexEmpty()
    v76 = UH1_RegexChar(f0: v75)
    var v77: US0 = US0_BitZero()
    v77 = US0_BitZero()
    var v78: UH1 = UH1_RegexEmpty()
    v78 = UH1_RegexChar(f0: v77)
    var v79: US0 = US0_BitZero()
    v79 = US0_BitOne()
    var v80: UH1 = UH1_RegexEmpty()
    v80 = UH1_RegexChar(f0: v79)
    var v81: UH1 = UH1_RegexEmpty()
    v81 = UH1_RegexAlt(f0: v78, f1: v80)
    var v82: US0 = US0_BitZero()
    v82 = US0_BitZero()
    var v83: UH1 = UH1_RegexEmpty()
    v83 = UH1_RegexChar(f0: v82)
    var v84: US0 = US0_BitZero()
    v84 = US0_BitOne()
    var v85: UH1 = UH1_RegexEmpty()
    v85 = UH1_RegexChar(f0: v84)
    var v86: UH1 = UH1_RegexEmpty()
    v86 = UH1_RegexAlt(f0: v83, f1: v85)
    var v87: US0 = US0_BitZero()
    v87 = US0_BitZero()
    var v88: UH1 = UH1_RegexEmpty()
    v88 = UH1_RegexChar(f0: v87)
    var v89: US0 = US0_BitZero()
    v89 = US0_BitOne()
    var v90: UH1 = UH1_RegexEmpty()
    v90 = UH1_RegexChar(f0: v89)
    var v91: UH1 = UH1_RegexEmpty()
    v91 = UH1_RegexAlt(f0: v88, f1: v90)
    var v92: UH1 = UH1_RegexEmpty()
    v92 = UH1_RegexCat(f0: v86, f1: v91)
    var v93: UH1 = UH1_RegexEmpty()
    v93 = UH1_RegexCat(f0: v81, f1: v92)
    var v94: UH1 = UH1_RegexEmpty()
    v94 = UH1_RegexCat(f0: v76, f1: v93)
    var v95: UH1 = UH1_RegexEmpty()
    v95 = UH1_RegexCat(f0: v74, f1: v94)
    var v96: UInt64 = (0 as UInt64)
    v96 = (1 as UInt64)
    var v97: Int32 = 0
    v97 = 0
    var v98: Int32 = 0
    v98 = sp_loop_15(v68, v59, v58, v96, v97)
    var v99: Int32 = 0
    v99 = sp_loop_15(v95, v59, v58, v96, v97)
    var v100: Int32 = 0
    v100 = 16
    var v101: US0 = US0_BitZero()
    v101 = US0_BitZero()
    var v102: UH1 = UH1_RegexEmpty()
    v102 = UH1_RegexChar(f0: v101)
    var v103: US0 = US0_BitZero()
    v103 = US0_BitZero()
    var v104: UH1 = UH1_RegexEmpty()
    v104 = UH1_RegexChar(f0: v103)
    var v105: US0 = US0_BitZero()
    v105 = US0_BitZero()
    var v106: UH1 = UH1_RegexEmpty()
    v106 = UH1_RegexChar(f0: v105)
    var v107: UH1 = UH1_RegexEmpty()
    v107 = UH1_RegexCat(f0: v104, f1: v106)
    var v108: UH1 = UH1_RegexEmpty()
    v108 = UH1_RegexAlt(f0: v102, f1: v107)
    var v109: UH1 = UH1_RegexEmpty()
    v109 = UH1_RegexStar(f0: v108)
    var v110: US0 = US0_BitZero()
    v110 = US0_BitOne()
    var v111: UH1 = UH1_RegexEmpty()
    v111 = UH1_RegexChar(f0: v110)
    var v112: UH1 = UH1_RegexEmpty()
    v112 = UH1_RegexCat(f0: v109, f1: v111)
    var v113: Int32 = 0
    v113 = 0
    var v114: Int32 = 0
    v114 = 1
    var v115: Int32 = 0
    v115 = sp_loop_17(v112, v100, v114, v113)
    var v116: Bool = false
    v116 = (v40 == v98)
    var v118: Bool = false
    if (v116) {
        var v117: Bool = false
        v117 = (v41 == v99)
        v118 = v117
    } else {
        v118 = false
    }
    var v120: Bool = false
    if (v118) {
        var v119: Bool = false
        v119 = (v57 == v115)
        v120 = v119
    } else {
        v120 = false
    }
    if (v120) {
    } else {
        "brzozowski-bench-engines-disagree".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    var v121: Int32 = 0
    v121 = 200
    var v122: Int32 = 0
    v122 = 32
    var v123: UInt64 = (0 as UInt64)
    v123 = (1 as UInt64)
    var v124: Int32 = 0
    v124 = 0
    var v125: Int32 = 0
    v125 = sp_loop_18(v122, v121, v123, v124)
    var v126: Int32 = 0
    v126 = sp_loop_20(v122, v121, v123, v124)
    var v127: Int32 = 0
    v127 = 16
    var v128: Int32 = 0
    v128 = 0
    var v129: Int32 = 0
    v129 = 1
    var v130: Int32 = 0
    v130 = sp_loop_22(v127, v129, v128)
    var v131: Bool = false
    v131 = (v40 == v125)
    var v133: Bool = false
    if (v131) {
        var v132: Bool = false
        v132 = (v41 == v126)
        v133 = v132
    } else {
        v133 = false
    }
    var v135: Bool = false
    if (v133) {
        var v134: Bool = false
        v134 = (v57 == v130)
        v135 = v134
    } else {
        v135 = false
    }
    if (v135) {
    } else {
        "brzozowski-bench-engines-disagree".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    var v136: Int32 = 0
    v136 = 200
    var v137: Int32 = 0
    v137 = 32
    var v138: SpiralArray<Int32> = SpiralArray<Int32>([])
    v138 = SpiralArray<Int32>(Array(repeating: 0, count: Int(4096)))
    var v139: SpiralArray<Int32> = SpiralArray<Int32>([])
    v139 = SpiralArray<Int32>(Array(repeating: 0, count: Int(4096)))
    var v140: SpiralArray<Int32> = SpiralArray<Int32>([])
    v140 = SpiralArray<Int32>(Array(repeating: 0, count: Int(4096)))
    var v141: SpiralArray<Int32> = SpiralArray<Int32>([])
    v141 = SpiralArray<Int32>(Array(repeating: 0, count: Int(4096)))
    var v142: SpiralArray<Int32> = SpiralArray<Int32>([])
    v142 = SpiralArray<Int32>(Array(repeating: 0, count: Int(8192)))
    var v143: SpiralArray<Int32> = SpiralArray<Int32>([])
    v143 = SpiralArray<Int32>(Array(repeating: 0, count: Int(8192)))
    var v144: SpiralArray<Int32> = SpiralArray<Int32>([])
    v144 = SpiralArray<Int32>(Array(repeating: 0, count: Int(1)))
    var v145: Int32 = 0
    v145 = 0
    sp_loop_24(v142, v145)
    var v146: Int32 = 0
    v146 = 0
    sp_loop_24(v143, v146)
    var v147: Int32 = 0
    v147 = 0
    sp_loop_25(v144, v147)
    var v148: Int32 = 0
    v148 = 0
    var v149: Int32 = 0
    v149 = 0
    var v150: Int32 = 0
    v150 = 0
    var v151: Int32 = 0
    v151 = sp_interned_node_26(v138, v139, v140, v141, v142, v143, v144, v148, v149, v150)
    var v152: Int32 = 0
    v152 = 1
    var v153: Int32 = 0
    v153 = 0
    var v154: Int32 = 0
    v154 = 0
    var v155: Int32 = 0
    v155 = sp_interned_node_26(v138, v139, v140, v141, v142, v143, v144, v152, v153, v154)
    var v156: Bool = false
    v156 = (v151 == 0)
    var v158: Bool = false
    if (v156) {
        var v157: Bool = false
        v157 = (v155 == 1)
        v158 = v157
    } else {
        v158 = false
    }
    var v166: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v167: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v168: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v169: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v170: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v171: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v172: SpiralArray<Int32> = SpiralArray<Int32>([])
    if (v158) {
        v166 = v138
        v167 = v139
        v168 = v140
        v169 = v141
        v170 = v142
        v171 = v143
        v172 = v144
    } else {
        "brzozowski-interned-store-init".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    var v173: US0 = US0_BitZero()
    v173 = US0_BitZero()
    var v174: UH1 = UH1_RegexEmpty()
    v174 = UH1_RegexChar(f0: v173)
    var v175: US0 = US0_BitZero()
    v175 = US0_BitOne()
    var v176: UH1 = UH1_RegexEmpty()
    v176 = UH1_RegexChar(f0: v175)
    var v177: UH1 = UH1_RegexEmpty()
    v177 = UH1_RegexAlt(f0: v174, f1: v176)
    var v178: UH1 = UH1_RegexEmpty()
    v178 = UH1_RegexStar(f0: v177)
    var v179: US0 = US0_BitZero()
    v179 = US0_BitZero()
    var v180: UH1 = UH1_RegexEmpty()
    v180 = UH1_RegexChar(f0: v179)
    var v181: UH1 = UH1_RegexEmpty()
    v181 = UH1_RegexCat(f0: v178, f1: v180)
    var v182: Int32 = 0
    v182 = sp_interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v181)
    var v183: UInt64 = (0 as UInt64)
    v183 = (1 as UInt64)
    var v184: Int32 = 0
    v184 = 0
    var v185: Int32 = 0
    v185 = sp_loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v182, v136, v183, v184)
    var v186: US0 = US0_BitZero()
    v186 = US0_BitZero()
    var v187: UH1 = UH1_RegexEmpty()
    v187 = UH1_RegexChar(f0: v186)
    var v188: US0 = US0_BitZero()
    v188 = US0_BitOne()
    var v189: UH1 = UH1_RegexEmpty()
    v189 = UH1_RegexChar(f0: v188)
    var v190: UH1 = UH1_RegexEmpty()
    v190 = UH1_RegexAlt(f0: v187, f1: v189)
    var v191: UH1 = UH1_RegexEmpty()
    v191 = UH1_RegexStar(f0: v190)
    var v192: US0 = US0_BitZero()
    v192 = US0_BitOne()
    var v193: UH1 = UH1_RegexEmpty()
    v193 = UH1_RegexChar(f0: v192)
    var v194: US0 = US0_BitZero()
    v194 = US0_BitZero()
    var v195: UH1 = UH1_RegexEmpty()
    v195 = UH1_RegexChar(f0: v194)
    var v196: US0 = US0_BitZero()
    v196 = US0_BitOne()
    var v197: UH1 = UH1_RegexEmpty()
    v197 = UH1_RegexChar(f0: v196)
    var v198: UH1 = UH1_RegexEmpty()
    v198 = UH1_RegexAlt(f0: v195, f1: v197)
    var v199: US0 = US0_BitZero()
    v199 = US0_BitZero()
    var v200: UH1 = UH1_RegexEmpty()
    v200 = UH1_RegexChar(f0: v199)
    var v201: US0 = US0_BitZero()
    v201 = US0_BitOne()
    var v202: UH1 = UH1_RegexEmpty()
    v202 = UH1_RegexChar(f0: v201)
    var v203: UH1 = UH1_RegexEmpty()
    v203 = UH1_RegexAlt(f0: v200, f1: v202)
    var v204: US0 = US0_BitZero()
    v204 = US0_BitZero()
    var v205: UH1 = UH1_RegexEmpty()
    v205 = UH1_RegexChar(f0: v204)
    var v206: US0 = US0_BitZero()
    v206 = US0_BitOne()
    var v207: UH1 = UH1_RegexEmpty()
    v207 = UH1_RegexChar(f0: v206)
    var v208: UH1 = UH1_RegexEmpty()
    v208 = UH1_RegexAlt(f0: v205, f1: v207)
    var v209: UH1 = UH1_RegexEmpty()
    v209 = UH1_RegexCat(f0: v203, f1: v208)
    var v210: UH1 = UH1_RegexEmpty()
    v210 = UH1_RegexCat(f0: v198, f1: v209)
    var v211: UH1 = UH1_RegexEmpty()
    v211 = UH1_RegexCat(f0: v193, f1: v210)
    var v212: UH1 = UH1_RegexEmpty()
    v212 = UH1_RegexCat(f0: v191, f1: v211)
    var v213: Int32 = 0
    v213 = sp_interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v212)
    var v214: UInt64 = (0 as UInt64)
    v214 = (1 as UInt64)
    var v215: Int32 = 0
    v215 = 0
    var v216: Int32 = 0
    v216 = sp_loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v213, v136, v214, v215)
    var v217: Int32 = 0
    v217 = 16
    var v218: SpiralArray<Int32> = SpiralArray<Int32>([])
    v218 = SpiralArray<Int32>(Array(repeating: 0, count: Int(4096)))
    var v219: SpiralArray<Int32> = SpiralArray<Int32>([])
    v219 = SpiralArray<Int32>(Array(repeating: 0, count: Int(4096)))
    var v220: SpiralArray<Int32> = SpiralArray<Int32>([])
    v220 = SpiralArray<Int32>(Array(repeating: 0, count: Int(4096)))
    var v221: SpiralArray<Int32> = SpiralArray<Int32>([])
    v221 = SpiralArray<Int32>(Array(repeating: 0, count: Int(4096)))
    var v222: SpiralArray<Int32> = SpiralArray<Int32>([])
    v222 = SpiralArray<Int32>(Array(repeating: 0, count: Int(8192)))
    var v223: SpiralArray<Int32> = SpiralArray<Int32>([])
    v223 = SpiralArray<Int32>(Array(repeating: 0, count: Int(8192)))
    var v224: SpiralArray<Int32> = SpiralArray<Int32>([])
    v224 = SpiralArray<Int32>(Array(repeating: 0, count: Int(1)))
    var v225: Int32 = 0
    v225 = 0
    sp_loop_24(v222, v225)
    var v226: Int32 = 0
    v226 = 0
    sp_loop_24(v223, v226)
    var v227: Int32 = 0
    v227 = 0
    sp_loop_25(v224, v227)
    var v228: Int32 = 0
    v228 = 0
    var v229: Int32 = 0
    v229 = 0
    var v230: Int32 = 0
    v230 = 0
    var v231: Int32 = 0
    v231 = sp_interned_node_26(v218, v219, v220, v221, v222, v223, v224, v228, v229, v230)
    var v232: Int32 = 0
    v232 = 1
    var v233: Int32 = 0
    v233 = 0
    var v234: Int32 = 0
    v234 = 0
    var v235: Int32 = 0
    v235 = sp_interned_node_26(v218, v219, v220, v221, v222, v223, v224, v232, v233, v234)
    var v236: Bool = false
    v236 = (v231 == 0)
    var v238: Bool = false
    if (v236) {
        var v237: Bool = false
        v237 = (v235 == 1)
        v238 = v237
    } else {
        v238 = false
    }
    var v246: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v247: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v248: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v249: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v250: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v251: SpiralArray<Int32> = SpiralArray<Int32>([])
    var v252: SpiralArray<Int32> = SpiralArray<Int32>([])
    if (v238) {
        v246 = v218
        v247 = v219
        v248 = v220
        v249 = v221
        v250 = v222
        v251 = v223
        v252 = v224
    } else {
        "brzozowski-interned-store-init".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    var v253: US0 = US0_BitZero()
    v253 = US0_BitZero()
    var v254: UH1 = UH1_RegexEmpty()
    v254 = UH1_RegexChar(f0: v253)
    var v255: US0 = US0_BitZero()
    v255 = US0_BitZero()
    var v256: UH1 = UH1_RegexEmpty()
    v256 = UH1_RegexChar(f0: v255)
    var v257: US0 = US0_BitZero()
    v257 = US0_BitZero()
    var v258: UH1 = UH1_RegexEmpty()
    v258 = UH1_RegexChar(f0: v257)
    var v259: UH1 = UH1_RegexEmpty()
    v259 = UH1_RegexCat(f0: v256, f1: v258)
    var v260: UH1 = UH1_RegexEmpty()
    v260 = UH1_RegexAlt(f0: v254, f1: v259)
    var v261: UH1 = UH1_RegexEmpty()
    v261 = UH1_RegexStar(f0: v260)
    var v262: US0 = US0_BitZero()
    v262 = US0_BitOne()
    var v263: UH1 = UH1_RegexEmpty()
    v263 = UH1_RegexChar(f0: v262)
    var v264: UH1 = UH1_RegexEmpty()
    v264 = UH1_RegexCat(f0: v261, f1: v263)
    var v265: Int32 = 0
    v265 = sp_interned_of_regex_raw_28(v246, v247, v248, v249, v250, v251, v252, v264)
    var v266: Int32 = 0
    v266 = 1
    var v267: Int32 = 0
    v267 = 0
    var v268: Int32 = 0
    v268 = sp_loop_36(v246, v247, v248, v249, v250, v251, v252, v217, v265, v266, v267)
    var v269: Bool = false
    v269 = (v40 == v185)
    var v271: Bool = false
    if (v269) {
        var v270: Bool = false
        v270 = (v41 == v216)
        v271 = v270
    } else {
        v271 = false
    }
    var v273: Bool = false
    if (v271) {
        var v272: Bool = false
        v272 = (v57 == v268)
        v273 = v272
    } else {
        v273 = false
    }
    if (v273) {
    } else {
        "brzozowski-bench-engines-disagree".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    var v274: Bool = false
    v274 = (v57 == 16)
    if (v274) {
    } else {
        "brzozowski-bench-zero-runs-count".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    var v275: Bool = false
    v275 = (v40 == 93)
    if (v275) {
    } else {
        "brzozowski-bench-ends-with-zero-count".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    var v276: Bool = false
    v276 = (v41 == 97)
    if (v276) {
    } else {
        "brzozowski-bench-fourth-from-end-count".withCString { ptr in _ = fputs(ptr, stderr) }
        fputs("\n", stderr)
        exit(1)
    }
    return 0
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
