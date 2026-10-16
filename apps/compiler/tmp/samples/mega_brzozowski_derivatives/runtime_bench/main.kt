sealed interface US0 { val tag: Int }
class US0_BitZero : US0 { override val tag: Int = 0 }
class US0_BitOne : US0 { override val tag: Int = 1 }
sealed interface UH1 { val tag: Int }
class UH1_RegexEmpty : UH1 { override val tag: Int = 0 }
class UH1_RegexEpsilon : UH1 { override val tag: Int = 1 }
data class UH1_RegexChar(val f0: US0) : UH1 { override val tag: Int = 2 }
data class UH1_RegexAlt(val f0: UH1, val f1: UH1) : UH1 { override val tag: Int = 3 }
data class UH1_RegexCat(val f0: UH1, val f1: UH1) : UH1 { override val tag: Int = 4 }
data class UH1_RegexStar(val f0: UH1) : UH1 { override val tag: Int = 5 }
sealed interface UH2 { val tag: Int }
class UH2_InputEmpty : UH2 { override val tag: Int = 0 }
data class UH2_InputCons(val f0: US0, val f1: UH2) : UH2 { override val tag: Int = 1 }
sealed interface US3 { val tag: Int }
class US3_SymbolLess : US3 { override val tag: Int = 0 }
class US3_SymbolSame : US3 { override val tag: Int = 1 }
class US3_SymbolGreater : US3 { override val tag: Int = 2 }
sealed interface US4 { val tag: Int }
class US4_Nullable : US4 { override val tag: Int = 0 }
class US4_NonNullable : US4 { override val tag: Int = 1 }
sealed interface UH5 { val tag: Int }
class UH5_RegexListNil : UH5 { override val tag: Int = 0 }
data class UH5_RegexListCons(val f0: UH1, val f1: UH5) : UH5 { override val tag: Int = 1 }
class SpiralTuple0(val v0: UH2, val v1: ULong)
fun sp_random_bit_input_1(p0: ULong, p1: Int, p2: UH2): SpiralTuple0 {
    var v0: ULong = p0
    var v1: Int = p1
    var v2: UH2 = p2
    while (true) {
        var v3: Boolean = false
        v3 = (0 < v1)
        if (v3) {
            var v4: ULong = 0uL
            v4 = (v0 * 1103515245uL)
            var v5: ULong = 0uL
            v5 = (v4 + 12345uL)
            var v6: ULong = 0uL
            v6 = (v5 and 2147483647uL)
            var v7: Int = 0
            v7 = (v1 - 1)
            var v8: ULong = 0uL
            v8 = (v6 shr 16)
            var v9: ULong = 0uL
            v9 = (v8 and 1uL)
            var v10: Boolean = false
            v10 = (v9 == 0uL)
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
            v14 = UH2_InputCons(v13, v2)
            val t1106_6: ULong = v6
            val t1143_7: Int = v7
            val t1178_14: UH2 = v14
            v0 = t1106_6
            v1 = t1143_7
            v2 = t1178_14
            continue
        } else {
            return SpiralTuple0(v2, v0)
        }
    }
    return SpiralTuple0(UH2_InputEmpty(), 0uL)
}
fun sp_regex_compare_7(p0: UH1, p1: UH1): US3 {
    var v0: UH1 = p0
    var v1: UH1 = p1
    when (v0.tag) {
        3 -> {
            var v53: UH1 = (v0 as UH1_RegexAlt).f0
            var v54: UH1 = (v0 as UH1_RegexAlt).f1
            when (v1.tag) {
                3 -> {
                    var v55: UH1 = (v1 as UH1_RegexAlt).f0
                    var v56: UH1 = (v1 as UH1_RegexAlt).f1
                    var v57: US3 = US3_SymbolLess()
                    v57 = sp_regex_compare_7(v53, v55)
                    when (v57.tag) {
                        1 -> {
                            return sp_regex_compare_7(v54, v56)
                        }
                        else -> {
                            return v57
                        }
                    }
                }
                else -> {
                    return US3_SymbolGreater()
                }
            }
        }
        4 -> {
            var v28: UH1 = (v0 as UH1_RegexCat).f0
            var v29: UH1 = (v0 as UH1_RegexCat).f1
            when (v1.tag) {
                4 -> {
                    var v34: UH1 = (v1 as UH1_RegexCat).f0
                    var v35: UH1 = (v1 as UH1_RegexCat).f1
                    var v36: US3 = US3_SymbolLess()
                    v36 = sp_regex_compare_7(v28, v34)
                    when (v36.tag) {
                        1 -> {
                            return sp_regex_compare_7(v29, v35)
                        }
                        else -> {
                            return v36
                        }
                    }
                }
                2 -> {
                    var v32: US0 = (v1 as UH1_RegexChar).f0
                    return US3_SymbolGreater()
                }
                0 -> {
                    return US3_SymbolGreater()
                }
                1 -> {
                    return US3_SymbolGreater()
                }
                else -> {
                    return US3_SymbolLess()
                }
            }
        }
        2 -> {
            var v10: US0 = (v0 as UH1_RegexChar).f0
            when (v1.tag) {
                2 -> {
                    var v13: US0 = (v1 as UH1_RegexChar).f0
                    when (v10.tag) {
                        1 -> {
                            when (v13.tag) {
                                1 -> {
                                    return US3_SymbolSame()
                                }
                                0 -> {
                                    return US3_SymbolGreater()
                                }
                                else -> throw RuntimeException()
                            }
                        }
                        0 -> {
                            when (v13.tag) {
                                1 -> {
                                    return US3_SymbolLess()
                                }
                                0 -> {
                                    return US3_SymbolSame()
                                }
                                else -> throw RuntimeException()
                            }
                        }
                        else -> throw RuntimeException()
                    }
                }
                0 -> {
                    return US3_SymbolGreater()
                }
                1 -> {
                    return US3_SymbolGreater()
                }
                else -> {
                    return US3_SymbolLess()
                }
            }
        }
        0 -> {
            when (v1.tag) {
                0 -> {
                    return US3_SymbolSame()
                }
                else -> {
                    return US3_SymbolLess()
                }
            }
        }
        1 -> {
            when (v1.tag) {
                0 -> {
                    return US3_SymbolGreater()
                }
                1 -> {
                    return US3_SymbolSame()
                }
                else -> {
                    return US3_SymbolLess()
                }
            }
        }
        5 -> {
            var v44: UH1 = (v0 as UH1_RegexStar).f0
            when (v1.tag) {
                3 -> {
                    var v45: UH1 = (v1 as UH1_RegexAlt).f0
                    var v46: UH1 = (v1 as UH1_RegexAlt).f1
                    return US3_SymbolLess()
                }
                5 -> {
                    var v48: UH1 = (v1 as UH1_RegexStar).f0
                    return sp_regex_compare_7(v44, v48)
                }
                else -> {
                    return US3_SymbolGreater()
                }
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_alt_insert_sorted_6(p0: UH1, p1: UH1): UH1 {
    var v0: UH1 = p0
    var v1: UH1 = p1
    when (v1.tag) {
        3 -> {
            var v2: UH1 = (v1 as UH1_RegexAlt).f0
            var v3: UH1 = (v1 as UH1_RegexAlt).f1
            var v4: US3 = US3_SymbolLess()
            v4 = sp_regex_compare_7(v0, v2)
            when (v4.tag) {
                2 -> {
                    var v6: UH1 = UH1_RegexEmpty()
                    v6 = sp_alt_insert_sorted_6(v0, v3)
                    return UH1_RegexAlt(v2, v6)
                }
                0 -> {
                    return UH1_RegexAlt(v0, v1)
                }
                1 -> {
                    return v1
                }
                else -> throw RuntimeException()
            }
        }
        0 -> {
            return v0
        }
        else -> {
            var v11: US3 = US3_SymbolLess()
            v11 = sp_regex_compare_7(v0, v1)
            when (v11.tag) {
                2 -> {
                    return UH1_RegexAlt(v1, v0)
                }
                0 -> {
                    return UH1_RegexAlt(v0, v1)
                }
                1 -> {
                    return v1
                }
                else -> throw RuntimeException()
            }
        }
    }
}
fun sp_make_alt_5(p0: UH1, p1: UH1): UH1 {
    var v0: UH1 = p0
    var v1: UH1 = p1
    when (v0.tag) {
        3 -> {
            var v2: UH1 = (v0 as UH1_RegexAlt).f0
            var v3: UH1 = (v0 as UH1_RegexAlt).f1
            var v4: UH1 = UH1_RegexEmpty()
            v4 = sp_alt_insert_sorted_6(v2, v1)
            return sp_make_alt_5(v3, v4)
        }
        0 -> {
            return v1
        }
        else -> {
            return sp_alt_insert_sorted_6(v0, v1)
        }
    }
}
fun sp_regex_equal_9(p0: UH1, p1: UH1): Boolean {
    var v0: UH1 = p0
    var v1: UH1 = p1
    when (v0.tag) {
        3 -> {
            var v18: UH1 = (v0 as UH1_RegexAlt).f0
            var v19: UH1 = (v0 as UH1_RegexAlt).f1
            when (v1.tag) {
                3 -> {
                    var v20: UH1 = (v1 as UH1_RegexAlt).f0
                    var v21: UH1 = (v1 as UH1_RegexAlt).f1
                    var v22: Boolean = false
                    v22 = sp_regex_equal_9(v18, v20)
                    if (v22) {
                        return sp_regex_equal_9(v19, v21)
                    } else {
                        return false
                    }
                }
                else -> {
                    return false
                }
            }
        }
        4 -> {
            var v26: UH1 = (v0 as UH1_RegexCat).f0
            var v27: UH1 = (v0 as UH1_RegexCat).f1
            when (v1.tag) {
                4 -> {
                    var v28: UH1 = (v1 as UH1_RegexCat).f0
                    var v29: UH1 = (v1 as UH1_RegexCat).f1
                    var v30: Boolean = false
                    v30 = sp_regex_equal_9(v26, v28)
                    if (v30) {
                        return sp_regex_equal_9(v27, v29)
                    } else {
                        return false
                    }
                }
                else -> {
                    return false
                }
            }
        }
        2 -> {
            var v4: US0 = (v0 as UH1_RegexChar).f0
            when (v1.tag) {
                2 -> {
                    var v5: US0 = (v1 as UH1_RegexChar).f0
                    var v15: US3 = US3_SymbolLess()
                    when (v4.tag) {
                        1 -> {
                            when (v5.tag) {
                                1 -> {
                                    v15 = US3_SymbolSame()
                                }
                                0 -> {
                                    v15 = US3_SymbolGreater()
                                }
                                else -> throw RuntimeException()
                            }
                        }
                        0 -> {
                            when (v5.tag) {
                                1 -> {
                                    v15 = US3_SymbolLess()
                                }
                                0 -> {
                                    v15 = US3_SymbolSame()
                                }
                                else -> throw RuntimeException()
                            }
                        }
                        else -> throw RuntimeException()
                    }
                    when (v15.tag) {
                        1 -> {
                            return true
                        }
                        else -> {
                            return false
                        }
                    }
                }
                else -> {
                    return false
                }
            }
        }
        0 -> {
            when (v1.tag) {
                0 -> {
                    return true
                }
                else -> {
                    return false
                }
            }
        }
        1 -> {
            when (v1.tag) {
                1 -> {
                    return true
                }
                else -> {
                    return false
                }
            }
        }
        5 -> {
            var v34: UH1 = (v0 as UH1_RegexStar).f0
            when (v1.tag) {
                5 -> {
                    var v35: UH1 = (v1 as UH1_RegexStar).f0
                    return sp_regex_equal_9(v34, v35)
                }
                else -> {
                    return false
                }
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_make_cat_8(p0: UH1, p1: UH1): UH1 {
    var v0: UH1 = p0
    var v1: UH1 = p1
    when (v0.tag) {
        0 -> {
            return UH1_RegexEmpty()
        }
        else -> {
            when (v1.tag) {
                0 -> {
                    return UH1_RegexEmpty()
                }
                else -> {
                    when (v0.tag) {
                        1 -> {
                            return v1
                        }
                        else -> {
                            when (v1.tag) {
                                1 -> {
                                    return v0
                                }
                                else -> {
                                    when (v0.tag) {
                                        4 -> {
                                            var v12: UH1 = (v0 as UH1_RegexCat).f0
                                            var v13: UH1 = (v0 as UH1_RegexCat).f1
                                            var v14: UH1 = UH1_RegexEmpty()
                                            v14 = sp_make_cat_8(v13, v1)
                                            return UH1_RegexCat(v12, v14)
                                        }
                                        5 -> {
                                            var v4: UH1 = (v0 as UH1_RegexStar).f0
                                            when (v1.tag) {
                                                5 -> {
                                                    var v5: UH1 = (v1 as UH1_RegexStar).f0
                                                    var v6: Boolean = false
                                                    v6 = sp_regex_equal_9(v4, v5)
                                                    if (v6) {
                                                        return UH1_RegexStar(v4)
                                                    } else {
                                                        return UH1_RegexCat(v0, v1)
                                                    }
                                                }
                                                else -> {
                                                    return UH1_RegexCat(v0, v1)
                                                }
                                            }
                                        }
                                        else -> {
                                            return UH1_RegexCat(v0, v1)
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
fun sp_make_star_10(p0: UH1): UH1 {
    var v0: UH1 = p0
    when (v0.tag) {
        0 -> {
            return UH1_RegexEpsilon()
        }
        1 -> {
            return UH1_RegexEpsilon()
        }
        5 -> {
            var v3: UH1 = (v0 as UH1_RegexStar).f0
            return UH1_RegexStar(v3)
        }
        else -> {
            return UH1_RegexStar(v0)
        }
    }
}
fun sp_normalize_4(p0: UH1): UH1 {
    var v0: UH1 = p0
    when (v0.tag) {
        3 -> {
            var v5: UH1 = (v0 as UH1_RegexAlt).f0
            var v6: UH1 = (v0 as UH1_RegexAlt).f1
            var v7: UH1 = UH1_RegexEmpty()
            v7 = sp_normalize_4(v5)
            var v8: UH1 = UH1_RegexEmpty()
            v8 = sp_normalize_4(v6)
            return sp_make_alt_5(v7, v8)
        }
        4 -> {
            var v10: UH1 = (v0 as UH1_RegexCat).f0
            var v11: UH1 = (v0 as UH1_RegexCat).f1
            var v12: UH1 = UH1_RegexEmpty()
            v12 = sp_normalize_4(v10)
            var v13: UH1 = UH1_RegexEmpty()
            v13 = sp_normalize_4(v11)
            return sp_make_cat_8(v12, v13)
        }
        2 -> {
            var v3: US0 = (v0 as UH1_RegexChar).f0
            return UH1_RegexChar(v3)
        }
        0 -> {
            return UH1_RegexEmpty()
        }
        1 -> {
            return UH1_RegexEpsilon()
        }
        5 -> {
            var v15: UH1 = (v0 as UH1_RegexStar).f0
            var v16: UH1 = UH1_RegexEmpty()
            v16 = sp_normalize_4(v15)
            return sp_make_star_10(v16)
        }
        else -> throw RuntimeException()
    }
}
fun sp_nullable_12(p0: UH1): US4 {
    var v0: UH1 = p0
    when (v0.tag) {
        3 -> {
            var v5: UH1 = (v0 as UH1_RegexAlt).f0
            var v6: UH1 = (v0 as UH1_RegexAlt).f1
            var v7: US4 = US4_Nullable()
            v7 = sp_nullable_12(v5)
            var v8: US4 = US4_Nullable()
            v8 = sp_nullable_12(v6)
            when (v7.tag) {
                0 -> {
                    return US4_Nullable()
                }
                else -> {
                    when (v8.tag) {
                        0 -> {
                            return US4_Nullable()
                        }
                        else -> {
                            when (v7.tag) {
                                1 -> {
                                    when (v8.tag) {
                                        1 -> {
                                            return US4_NonNullable()
                                        }
                                        else -> throw RuntimeException()
                                    }
                                }
                                else -> throw RuntimeException()
                            }
                        }
                    }
                }
            }
        }
        4 -> {
            var v16: UH1 = (v0 as UH1_RegexCat).f0
            var v17: UH1 = (v0 as UH1_RegexCat).f1
            var v18: US4 = US4_Nullable()
            v18 = sp_nullable_12(v16)
            var v19: US4 = US4_Nullable()
            v19 = sp_nullable_12(v17)
            when (v18.tag) {
                0 -> {
                    when (v19.tag) {
                        0 -> {
                            return US4_Nullable()
                        }
                        else -> {
                            return US4_NonNullable()
                        }
                    }
                }
                else -> {
                    return US4_NonNullable()
                }
            }
        }
        2 -> {
            var v3: US0 = (v0 as UH1_RegexChar).f0
            return US4_NonNullable()
        }
        0 -> {
            return US4_NonNullable()
        }
        1 -> {
            return US4_Nullable()
        }
        5 -> {
            var v25: UH1 = (v0 as UH1_RegexStar).f0
            return US4_Nullable()
        }
        else -> throw RuntimeException()
    }
}
fun sp_derivative_11(p0: UH1, p1: US0): UH1 {
    var v0: UH1 = p0
    var v1: US0 = p1
    when (v0.tag) {
        3 -> {
            var v19: UH1 = (v0 as UH1_RegexAlt).f0
            var v20: UH1 = (v0 as UH1_RegexAlt).f1
            var v21: UH1 = UH1_RegexEmpty()
            v21 = sp_derivative_11(v19, v1)
            var v22: UH1 = UH1_RegexEmpty()
            v22 = sp_derivative_11(v20, v1)
            return sp_make_alt_5(v21, v22)
        }
        4 -> {
            var v24: UH1 = (v0 as UH1_RegexCat).f0
            var v25: UH1 = (v0 as UH1_RegexCat).f1
            var v26: US4 = US4_Nullable()
            v26 = sp_nullable_12(v24)
            when (v26.tag) {
                1 -> {
                    var v31: UH1 = UH1_RegexEmpty()
                    v31 = sp_derivative_11(v24, v1)
                    return sp_make_cat_8(v31, v25)
                }
                0 -> {
                    var v27: UH1 = UH1_RegexEmpty()
                    v27 = sp_derivative_11(v24, v1)
                    var v28: UH1 = UH1_RegexEmpty()
                    v28 = sp_make_cat_8(v27, v25)
                    var v29: UH1 = UH1_RegexEmpty()
                    v29 = sp_derivative_11(v25, v1)
                    return sp_make_alt_5(v28, v29)
                }
                else -> throw RuntimeException()
            }
        }
        2 -> {
            var v4: US0 = (v0 as UH1_RegexChar).f0
            var v14: US3 = US3_SymbolLess()
            when (v4.tag) {
                1 -> {
                    when (v1.tag) {
                        1 -> {
                            v14 = US3_SymbolSame()
                        }
                        0 -> {
                            v14 = US3_SymbolGreater()
                        }
                        else -> throw RuntimeException()
                    }
                }
                0 -> {
                    when (v1.tag) {
                        1 -> {
                            v14 = US3_SymbolLess()
                        }
                        0 -> {
                            v14 = US3_SymbolSame()
                        }
                        else -> throw RuntimeException()
                    }
                }
                else -> throw RuntimeException()
            }
            var v15: Boolean = false
            when (v14.tag) {
                1 -> {
                    v15 = true
                }
                else -> {
                    v15 = false
                }
            }
            if (v15) {
                return UH1_RegexEpsilon()
            } else {
                return UH1_RegexEmpty()
            }
        }
        0 -> {
            return UH1_RegexEmpty()
        }
        1 -> {
            return UH1_RegexEmpty()
        }
        5 -> {
            var v35: UH1 = (v0 as UH1_RegexStar).f0
            var v36: UH1 = UH1_RegexEmpty()
            v36 = sp_derivative_11(v35, v1)
            var v37: UH1 = UH1_RegexEmpty()
            v37 = sp_make_star_10(v35)
            return sp_make_cat_8(v36, v37)
        }
        else -> throw RuntimeException()
    }
}
fun sp_canonical_derivative_3(p0: UH1, p1: US0): UH1 {
    var v0: UH1 = p0
    var v1: US0 = p1
    var v2: UH1 = UH1_RegexEmpty()
    v2 = sp_normalize_4(v0)
    var v3: UH1 = UH1_RegexEmpty()
    v3 = sp_derivative_11(v2, v1)
    return sp_normalize_4(v3)
}
fun sp_accepts_2(p0: UH1, p1: UH2): Boolean {
    var v0: UH1 = p0
    var v1: UH2 = p1
    when (v1.tag) {
        1 -> {
            var v6: US0 = (v1 as UH2_InputCons).f0
            var v7: UH2 = (v1 as UH2_InputCons).f1
            var v8: UH1 = UH1_RegexEmpty()
            v8 = sp_canonical_derivative_3(v0, v6)
            return sp_accepts_2(v8, v7)
        }
        0 -> {
            var v2: UH1 = UH1_RegexEmpty()
            v2 = sp_normalize_4(v0)
            var v3: US4 = US4_Nullable()
            v3 = sp_nullable_12(v2)
            when (v3.tag) {
                1 -> {
                    return false
                }
                0 -> {
                    return true
                }
                else -> throw RuntimeException()
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_loop_0(p0: UH1, p1: Int, p2: Int, p3: ULong, p4: Int): Int {
    var v0: UH1 = p0
    var v1: Int = p1
    var v2: Int = p2
    var v3: ULong = p3
    var v4: Int = p4
    while (true) {
        var v5: Boolean = false
        v5 = (0 < v2)
        if (v5) {
            var v6: UH2 = UH2_InputEmpty()
            v6 = UH2_InputEmpty()
            var v7: UH2 = UH2_InputEmpty()
            var v8: ULong = 0uL
            val spiral_tuple432 = sp_random_bit_input_1(v3, v1, v6)
            v7 = spiral_tuple432.v0
            v8 = spiral_tuple432.v1
            var v9: Boolean = false
            v9 = sp_accepts_2(v0, v7)
            var v11: Int = 0
            if (v9) {
                var v10: Int = 0
                v10 = (v4 + 1)
                v11 = v10
            } else {
                v11 = v4
            }
            var v12: Int = 0
            v12 = (v2 - 1)
            val t918_0: UH1 = v0
            val t952_1: Int = v1
            val t986_12: Int = v12
            val t1022_8: ULong = v8
            val t1059_11: Int = v11
            v0 = t918_0
            v1 = t952_1
            v2 = t986_12
            v3 = t1022_8
            v4 = t1059_11
            continue
        } else {
            return v4
        }
    }
    return 0
}
fun sp_zeros_input_14(p0: Int, p1: UH2): UH2 {
    var v0: Int = p0
    var v1: UH2 = p1
    while (true) {
        var v2: Boolean = false
        v2 = (0 < v0)
        if (v2) {
            var v3: Int = 0
            v3 = (v0 - 1)
            var v4: US0 = US0_BitZero()
            v4 = US0_BitZero()
            var v5: UH2 = UH2_InputEmpty()
            v5 = UH2_InputCons(v4, v1)
            val t400_3: Int = v3
            val t434_5: UH2 = v5
            v0 = t400_3
            v1 = t434_5
            continue
        } else {
            return v1
        }
    }
    return UH2_InputEmpty()
}
fun sp_loop_13(p0: UH1, p1: Int, p2: Int, p3: Int): Int {
    var v0: UH1 = p0
    var v1: Int = p1
    var v2: Int = p2
    var v3: Int = p3
    while (true) {
        var v4: Boolean = false
        v4 = (v1 < v2)
        if (v4) {
            return v3
        } else {
            var v5: UH2 = UH2_InputEmpty()
            v5 = UH2_InputEmpty()
            var v6: UH2 = UH2_InputEmpty()
            v6 = sp_zeros_input_14(v2, v5)
            var v7: Boolean = false
            v7 = sp_accepts_2(v0, v6)
            var v9: Int = 0
            if (v7) {
                var v8: Int = 0
                v8 = (v3 + 1)
                v9 = v8
            } else {
                v9 = v3
            }
            var v10: US0 = US0_BitZero()
            v10 = US0_BitOne()
            var v11: UH2 = UH2_InputEmpty()
            v11 = UH2_InputEmpty()
            var v12: UH2 = UH2_InputEmpty()
            v12 = UH2_InputCons(v10, v11)
            var v13: UH2 = UH2_InputEmpty()
            v13 = sp_zeros_input_14(v2, v12)
            var v14: Boolean = false
            v14 = sp_accepts_2(v0, v13)
            var v16: Int = 0
            if (v14) {
                var v15: Int = 0
                v15 = (v9 + 1)
                v16 = v15
            } else {
                v16 = v9
            }
            var v17: Int = 0
            v17 = (v2 + 1)
            val t1411_0: UH1 = v0
            val t1446_1: Int = v1
            val t1481_17: Int = v17
            val t1518_16: Int = v16
            v0 = t1411_0
            v1 = t1446_1
            v2 = t1481_17
            v3 = t1518_16
            continue
        }
    }
    return 0
}
fun sp_backtrack_stack_16(p0: UH5, p1: UH2): Boolean {
    var v0: UH5 = p0
    var v1: UH2 = p1
    when (v0.tag) {
        1 -> {
            var v6: UH1 = (v0 as UH5_RegexListCons).f0
            var v7: UH5 = (v0 as UH5_RegexListCons).f1
            when (v6.tag) {
                3 -> {
                    var v27: UH1 = (v6 as UH1_RegexAlt).f0
                    var v28: UH1 = (v6 as UH1_RegexAlt).f1
                    var v29: UH5 = UH5_RegexListNil()
                    v29 = UH5_RegexListCons(v27, v7)
                    var v30: Boolean = false
                    v30 = sp_backtrack_stack_16(v29, v1)
                    if (v30) {
                        return true
                    } else {
                        var v31: UH5 = UH5_RegexListNil()
                        v31 = UH5_RegexListCons(v28, v7)
                        return sp_backtrack_stack_16(v31, v1)
                    }
                }
                4 -> {
                    var v34: UH1 = (v6 as UH1_RegexCat).f0
                    var v35: UH1 = (v6 as UH1_RegexCat).f1
                    var v36: UH5 = UH5_RegexListNil()
                    v36 = UH5_RegexListCons(v35, v7)
                    var v37: UH5 = UH5_RegexListNil()
                    v37 = UH5_RegexListCons(v34, v36)
                    return sp_backtrack_stack_16(v37, v1)
                }
                2 -> {
                    var v9: US0 = (v6 as UH1_RegexChar).f0
                    when (v1.tag) {
                        1 -> {
                            var v10: US0 = (v1 as UH2_InputCons).f0
                            var v11: UH2 = (v1 as UH2_InputCons).f1
                            var v21: US3 = US3_SymbolLess()
                            when (v9.tag) {
                                1 -> {
                                    when (v10.tag) {
                                        1 -> {
                                            v21 = US3_SymbolSame()
                                        }
                                        0 -> {
                                            v21 = US3_SymbolGreater()
                                        }
                                        else -> throw RuntimeException()
                                    }
                                }
                                0 -> {
                                    when (v10.tag) {
                                        1 -> {
                                            v21 = US3_SymbolLess()
                                        }
                                        0 -> {
                                            v21 = US3_SymbolSame()
                                        }
                                        else -> throw RuntimeException()
                                    }
                                }
                                else -> throw RuntimeException()
                            }
                            var v22: Boolean = false
                            when (v21.tag) {
                                1 -> {
                                    v22 = true
                                }
                                else -> {
                                    v22 = false
                                }
                            }
                            if (v22) {
                                return sp_backtrack_stack_16(v7, v11)
                            } else {
                                return false
                            }
                        }
                        0 -> {
                            return false
                        }
                        else -> throw RuntimeException()
                    }
                }
                0 -> {
                    return false
                }
                1 -> {
                    return sp_backtrack_stack_16(v7, v1)
                }
                5 -> {
                    var v39: UH1 = (v6 as UH1_RegexStar).f0
                    var v40: UH5 = UH5_RegexListNil()
                    v40 = UH5_RegexListCons(v39, v0)
                    var v41: Boolean = false
                    v41 = sp_backtrack_stack_16(v40, v1)
                    if (v41) {
                        return true
                    } else {
                        return sp_backtrack_stack_16(v7, v1)
                    }
                }
                else -> throw RuntimeException()
            }
        }
        0 -> {
            when (v1.tag) {
                1 -> {
                    var v2: US0 = (v1 as UH2_InputCons).f0
                    var v3: UH2 = (v1 as UH2_InputCons).f1
                    return false
                }
                0 -> {
                    return true
                }
                else -> throw RuntimeException()
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_loop_15(p0: UH1, p1: Int, p2: Int, p3: ULong, p4: Int): Int {
    var v0: UH1 = p0
    var v1: Int = p1
    var v2: Int = p2
    var v3: ULong = p3
    var v4: Int = p4
    while (true) {
        var v5: Boolean = false
        v5 = (0 < v2)
        if (v5) {
            var v6: UH2 = UH2_InputEmpty()
            v6 = UH2_InputEmpty()
            var v7: UH2 = UH2_InputEmpty()
            var v8: ULong = 0uL
            val spiral_tuple433 = sp_random_bit_input_1(v3, v1, v6)
            v7 = spiral_tuple433.v0
            v8 = spiral_tuple433.v1
            var v9: UH5 = UH5_RegexListNil()
            v9 = UH5_RegexListNil()
            var v10: UH5 = UH5_RegexListNil()
            v10 = UH5_RegexListCons(v0, v9)
            var v11: Boolean = false
            v11 = sp_backtrack_stack_16(v10, v7)
            var v13: Int = 0
            if (v11) {
                var v12: Int = 0
                v12 = (v4 + 1)
                v13 = v12
            } else {
                v13 = v4
            }
            var v14: Int = 0
            v14 = (v2 - 1)
            val t1107_0: UH1 = v0
            val t1142_1: Int = v1
            val t1177_14: Int = v14
            val t1214_8: ULong = v8
            val t1251_13: Int = v13
            v0 = t1107_0
            v1 = t1142_1
            v2 = t1177_14
            v3 = t1214_8
            v4 = t1251_13
            continue
        } else {
            return v4
        }
    }
    return 0
}
fun sp_loop_17(p0: UH1, p1: Int, p2: Int, p3: Int): Int {
    var v0: UH1 = p0
    var v1: Int = p1
    var v2: Int = p2
    var v3: Int = p3
    while (true) {
        var v4: Boolean = false
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
            v8 = UH5_RegexListCons(v0, v7)
            var v9: Boolean = false
            v9 = sp_backtrack_stack_16(v8, v6)
            var v11: Int = 0
            if (v9) {
                var v10: Int = 0
                v10 = (v3 + 1)
                v11 = v10
            } else {
                v11 = v3
            }
            var v12: US0 = US0_BitZero()
            v12 = US0_BitOne()
            var v13: UH2 = UH2_InputEmpty()
            v13 = UH2_InputEmpty()
            var v14: UH2 = UH2_InputEmpty()
            v14 = UH2_InputCons(v12, v13)
            var v15: UH2 = UH2_InputEmpty()
            v15 = sp_zeros_input_14(v2, v14)
            var v16: UH5 = UH5_RegexListNil()
            v16 = UH5_RegexListNil()
            var v17: UH5 = UH5_RegexListNil()
            v17 = UH5_RegexListCons(v0, v16)
            var v18: Boolean = false
            v18 = sp_backtrack_stack_16(v17, v15)
            var v20: Int = 0
            if (v18) {
                var v19: Int = 0
                v19 = (v11 + 1)
                v20 = v19
            } else {
                v20 = v11
            }
            var v21: Int = 0
            v21 = (v2 + 1)
            val t1789_0: UH1 = v0
            val t1824_1: Int = v1
            val t1859_21: Int = v21
            val t1896_20: Int = v20
            v0 = t1789_0
            v1 = t1824_1
            v2 = t1859_21
            v3 = t1896_20
            continue
        }
    }
    return 0
}
fun sp_run_19(p0: Int, p1: UH2): Boolean {
    var v0: Int = p0
    var v1: UH2 = p1
    when (v1.tag) {
        1 -> {
            var v3: US0 = (v1 as UH2_InputCons).f0
            var v4: UH2 = (v1 as UH2_InputCons).f1
            when (v3.tag) {
                1 -> {
                    var v9: Int = 0
                    v9 = 0
                    return sp_run_19(v9, v4)
                }
                0 -> {
                    var v6: Int = 0
                    v6 = 1
                    return sp_run_19(v6, v4)
                }
                else -> throw RuntimeException()
            }
        }
        0 -> {
            var v2: Boolean = false
            v2 = (v0 == 1)
            return v2
        }
        else -> throw RuntimeException()
    }
}
fun sp_loop_18(p0: Int, p1: Int, p2: ULong, p3: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: ULong = p2
    var v3: Int = p3
    while (true) {
        var v4: Boolean = false
        v4 = (0 < v1)
        if (v4) {
            var v5: UH2 = UH2_InputEmpty()
            v5 = UH2_InputEmpty()
            var v6: UH2 = UH2_InputEmpty()
            var v7: ULong = 0uL
            val spiral_tuple402 = sp_random_bit_input_1(v2, v0, v5)
            v6 = spiral_tuple402.v0
            v7 = spiral_tuple402.v1
            var v8: Int = 0
            v8 = 0
            var v9: Boolean = false
            v9 = sp_run_19(v8, v6)
            var v11: Int = 0
            if (v9) {
                var v10: Int = 0
                v10 = (v3 + 1)
                v11 = v10
            } else {
                v11 = v3
            }
            var v12: Int = 0
            v12 = (v1 - 1)
            val t934_0: Int = v0
            val t968_12: Int = v12
            val t1004_7: ULong = v7
            val t1041_11: Int = v11
            v0 = t934_0
            v1 = t968_12
            v2 = t1004_7
            v3 = t1041_11
            continue
        } else {
            return v3
        }
    }
    return 0
}
fun sp_run_21(p0: Int, p1: UH2): Boolean {
    var v0: Int = p0
    var v1: UH2 = p1
    when (v1.tag) {
        1 -> {
            var v17: US0 = (v1 as UH2_InputCons).f0
            var v18: UH2 = (v1 as UH2_InputCons).f1
            when (v17.tag) {
                1 -> {
                    var v50: Boolean = false
                    v50 = (v0 == 0)
                    var v79: Int = 0
                    if (v50) {
                        v79 = 1
                    } else {
                        var v51: Boolean = false
                        v51 = (v0 == 1)
                        if (v51) {
                            v79 = 6
                        } else {
                            var v52: Boolean = false
                            v52 = (v0 == 2)
                            if (v52) {
                                v79 = 11
                            } else {
                                var v53: Boolean = false
                                v53 = (v0 == 3)
                                if (v53) {
                                    v79 = 5
                                } else {
                                    var v54: Boolean = false
                                    v54 = (v0 == 4)
                                    if (v54) {
                                        v79 = 1
                                    } else {
                                        var v55: Boolean = false
                                        v55 = (v0 == 5)
                                        if (v55) {
                                            v79 = 6
                                        } else {
                                            var v56: Boolean = false
                                            v56 = (v0 == 6)
                                            if (v56) {
                                                v79 = 13
                                            } else {
                                                var v57: Boolean = false
                                                v57 = (v0 == 7)
                                                if (v57) {
                                                    v79 = 9
                                                } else {
                                                    var v58: Boolean = false
                                                    v58 = (v0 == 8)
                                                    if (v58) {
                                                        v79 = 5
                                                    } else {
                                                        var v59: Boolean = false
                                                        v59 = (v0 == 9)
                                                        if (v59) {
                                                            v79 = 12
                                                        } else {
                                                            var v60: Boolean = false
                                                            v60 = (v0 == 10)
                                                            if (v60) {
                                                                v79 = 11
                                                            } else {
                                                                var v61: Boolean = false
                                                                v61 = (v0 == 11)
                                                                if (v61) {
                                                                    v79 = 12
                                                                } else {
                                                                    var v62: Boolean = false
                                                                    v62 = (v0 == 12)
                                                                    if (v62) {
                                                                        v79 = 13
                                                                    } else {
                                                                        var v63: Boolean = false
                                                                        v63 = (v0 == 13)
                                                                        if (v63) {
                                                                            v79 = 15
                                                                        } else {
                                                                            var v64: Boolean = false
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
                }
                0 -> {
                    var v19: Boolean = false
                    v19 = (v0 == 0)
                    var v48: Int = 0
                    if (v19) {
                        v48 = 0
                    } else {
                        var v20: Boolean = false
                        v20 = (v0 == 1)
                        if (v20) {
                            v48 = 2
                        } else {
                            var v21: Boolean = false
                            v21 = (v0 == 2)
                            if (v21) {
                                v48 = 3
                            } else {
                                var v22: Boolean = false
                                v22 = (v0 == 3)
                                if (v22) {
                                    v48 = 4
                                } else {
                                    var v23: Boolean = false
                                    v23 = (v0 == 4)
                                    if (v23) {
                                        v48 = 0
                                    } else {
                                        var v24: Boolean = false
                                        v24 = (v0 == 5)
                                        if (v24) {
                                            v48 = 2
                                        } else {
                                            var v25: Boolean = false
                                            v25 = (v0 == 6)
                                            if (v25) {
                                                v48 = 7
                                            } else {
                                                var v26: Boolean = false
                                                v26 = (v0 == 7)
                                                if (v26) {
                                                    v48 = 8
                                                } else {
                                                    var v27: Boolean = false
                                                    v27 = (v0 == 8)
                                                    if (v27) {
                                                        v48 = 4
                                                    } else {
                                                        var v28: Boolean = false
                                                        v28 = (v0 == 9)
                                                        if (v28) {
                                                            v48 = 10
                                                        } else {
                                                            var v29: Boolean = false
                                                            v29 = (v0 == 10)
                                                            if (v29) {
                                                                v48 = 3
                                                            } else {
                                                                var v30: Boolean = false
                                                                v30 = (v0 == 11)
                                                                if (v30) {
                                                                    v48 = 10
                                                                } else {
                                                                    var v31: Boolean = false
                                                                    v31 = (v0 == 12)
                                                                    if (v31) {
                                                                        v48 = 7
                                                                    } else {
                                                                        var v32: Boolean = false
                                                                        v32 = (v0 == 13)
                                                                        if (v32) {
                                                                            v48 = 14
                                                                        } else {
                                                                            var v33: Boolean = false
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
                }
                else -> throw RuntimeException()
            }
        }
        0 -> {
            var v2: Boolean = false
            v2 = (v0 == 4)
            if (v2) {
                return true
            } else {
                var v3: Boolean = false
                v3 = (v0 == 5)
                if (v3) {
                    return true
                } else {
                    var v4: Boolean = false
                    v4 = (v0 == 8)
                    if (v4) {
                        return true
                    } else {
                        var v5: Boolean = false
                        v5 = (v0 == 9)
                        if (v5) {
                            return true
                        } else {
                            var v6: Boolean = false
                            v6 = (v0 == 10)
                            if (v6) {
                                return true
                            } else {
                                var v7: Boolean = false
                                v7 = (v0 == 12)
                                if (v7) {
                                    return true
                                } else {
                                    var v8: Boolean = false
                                    v8 = (v0 == 14)
                                    if (v8) {
                                        return true
                                    } else {
                                        var v9: Boolean = false
                                        v9 = (v0 == 15)
                                        return v9
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_loop_20(p0: Int, p1: Int, p2: ULong, p3: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: ULong = p2
    var v3: Int = p3
    while (true) {
        var v4: Boolean = false
        v4 = (0 < v1)
        if (v4) {
            var v5: UH2 = UH2_InputEmpty()
            v5 = UH2_InputEmpty()
            var v6: UH2 = UH2_InputEmpty()
            var v7: ULong = 0uL
            val spiral_tuple402 = sp_random_bit_input_1(v2, v0, v5)
            v6 = spiral_tuple402.v0
            v7 = spiral_tuple402.v1
            var v8: Int = 0
            v8 = 0
            var v9: Boolean = false
            v9 = sp_run_21(v8, v6)
            var v11: Int = 0
            if (v9) {
                var v10: Int = 0
                v10 = (v3 + 1)
                v11 = v10
            } else {
                v11 = v3
            }
            var v12: Int = 0
            v12 = (v1 - 1)
            val t934_0: Int = v0
            val t968_12: Int = v12
            val t1004_7: ULong = v7
            val t1041_11: Int = v11
            v0 = t934_0
            v1 = t968_12
            v2 = t1004_7
            v3 = t1041_11
            continue
        } else {
            return v3
        }
    }
    return 0
}
fun sp_run_23(p0: Int, p1: UH2): Boolean {
    var v0: Int = p0
    var v1: UH2 = p1
    when (v1.tag) {
        1 -> {
            var v3: US0 = (v1 as UH2_InputCons).f0
            var v4: UH2 = (v1 as UH2_InputCons).f1
            when (v3.tag) {
                1 -> {
                    var v13: Boolean = false
                    v13 = (v0 == 0)
                    var v19: Int = 0
                    if (v13) {
                        v19 = 3
                    } else {
                        var v14: Boolean = false
                        v14 = (v0 == 1)
                        if (v14) {
                            v19 = 3
                        } else {
                            var v15: Boolean = false
                            v15 = (v0 == 2)
                            if (v15) {
                                v19 = 3
                            } else {
                                v19 = 4
                            }
                        }
                    }
                    return sp_run_23(v19, v4)
                }
                0 -> {
                    var v5: Boolean = false
                    v5 = (v0 == 0)
                    var v11: Int = 0
                    if (v5) {
                        v11 = 1
                    } else {
                        var v6: Boolean = false
                        v6 = (v0 == 1)
                        if (v6) {
                            v11 = 2
                        } else {
                            var v7: Boolean = false
                            v7 = (v0 == 2)
                            if (v7) {
                                v11 = 2
                            } else {
                                v11 = 4
                            }
                        }
                    }
                    return sp_run_23(v11, v4)
                }
                else -> throw RuntimeException()
            }
        }
        0 -> {
            var v2: Boolean = false
            v2 = (v0 == 3)
            return v2
        }
        else -> throw RuntimeException()
    }
}
fun sp_loop_22(p0: Int, p1: Int, p2: Int): Int {
    var v0: Int = p0
    var v1: Int = p1
    var v2: Int = p2
    while (true) {
        var v3: Boolean = false
        v3 = (v0 < v1)
        if (v3) {
            return v2
        } else {
            var v4: UH2 = UH2_InputEmpty()
            v4 = UH2_InputEmpty()
            var v5: UH2 = UH2_InputEmpty()
            v5 = sp_zeros_input_14(v1, v4)
            var v6: Int = 0
            v6 = 0
            var v7: Boolean = false
            v7 = sp_run_23(v6, v5)
            var v9: Int = 0
            if (v7) {
                var v8: Int = 0
                v8 = (v2 + 1)
                v9 = v8
            } else {
                v9 = v2
            }
            var v10: US0 = US0_BitZero()
            v10 = US0_BitOne()
            var v11: UH2 = UH2_InputEmpty()
            v11 = UH2_InputEmpty()
            var v12: UH2 = UH2_InputEmpty()
            v12 = UH2_InputCons(v10, v11)
            var v13: UH2 = UH2_InputEmpty()
            v13 = sp_zeros_input_14(v1, v12)
            var v14: Int = 0
            v14 = 0
            var v15: Boolean = false
            v15 = sp_run_23(v14, v13)
            var v17: Int = 0
            if (v15) {
                var v16: Int = 0
                v16 = (v9 + 1)
                v17 = v16
            } else {
                v17 = v9
            }
            var v18: Int = 0
            v18 = (v1 + 1)
            val t1475_0: Int = v0
            val t1510_18: Int = v18
            val t1547_17: Int = v17
            v0 = t1475_0
            v1 = t1510_18
            v2 = t1547_17
            continue
        }
    }
    return 0
}
fun sp_loop_24(p0: Array<Int>, p1: Int) {
    var v0: Array<Int> = p0
    var v1: Int = p1
    while (true) {
        var v2: Boolean = false
        v2 = (v1 < 8192)
        if (v2) {
            v0[v1] = 0
            var v3: Int = 0
            v3 = (v1 + 1)
            val t272_0: Array<Int> = v0
            val t313_3: Int = v3
            v0 = t272_0
            v1 = t313_3
            continue
        } else {
            return
        }
    }
}
fun sp_loop_25(p0: Array<Int>, p1: Int) {
    var v0: Array<Int> = p0
    var v1: Int = p1
    while (true) {
        var v2: Boolean = false
        v2 = (v1 < 1)
        if (v2) {
            v0[v1] = 0
            var v3: Int = 0
            v3 = (v1 + 1)
            val t269_0: Array<Int> = v0
            val t310_3: Int = v3
            v0 = t269_0
            v1 = t310_3
            continue
        } else {
            return
        }
    }
}
fun sp_probe_27(p0: Array<Int>, p1: Array<Int>, p2: Array<Int>, p3: Array<Int>, p4: Array<Int>, p5: Array<Int>, p6: Array<Int>, p7: Int, p8: Int, p9: Int, p10: Int): Int {
    var v0: Array<Int> = p0
    var v1: Array<Int> = p1
    var v2: Array<Int> = p2
    var v3: Array<Int> = p3
    var v4: Array<Int> = p4
    var v5: Array<Int> = p5
    var v6: Array<Int> = p6
    var v7: Int = p7
    var v8: Int = p8
    var v9: Int = p9
    var v10: Int = p10
    while (true) {
        var v11: Int = 0
        v11 = v4[v10]
        var v12: Boolean = false
        v12 = (v11 == 0)
        if (v12) {
            var v13: Int = 0
            v13 = v6[0]
            var v14: Boolean = false
            v14 = (v13 < 4096)
            if (v14) {
                v0[v13] = v7
                v1[v13] = v8
                v2[v13] = v9
                var v15: Boolean = false
                v15 = (v7 == 1)
                var v32: Boolean = false
                if (v15) {
                    v32 = true
                } else {
                    var v16: Boolean = false
                    v16 = (v7 == 5)
                    if (v16) {
                        v32 = true
                    } else {
                        var v17: Boolean = false
                        v17 = (v7 == 3)
                        if (v17) {
                            var v18: Int = 0
                            v18 = v3[v8]
                            var v19: Boolean = false
                            v19 = (v18 == 1)
                            if (v19) {
                                v32 = true
                            } else {
                                var v20: Int = 0
                                v20 = v3[v9]
                                var v21: Boolean = false
                                v21 = (v20 == 1)
                                v32 = v21
                            }
                        } else {
                            var v23: Boolean = false
                            v23 = (v7 == 4)
                            if (v23) {
                                var v24: Int = 0
                                v24 = v3[v8]
                                var v25: Boolean = false
                                v25 = (v24 == 1)
                                if (v25) {
                                    var v26: Int = 0
                                    v26 = v3[v9]
                                    var v27: Boolean = false
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
                var v33: Int = 0
                if (v32) {
                    v33 = 1
                } else {
                    v33 = 0
                }
                v3[v13] = v33
                var v34: Int = 0
                v34 = (v13 + 1)
                v4[v10] = v34
                v6[0] = v34
                return v13
            } else {
                System.err.println("brzozowski-interned-store-full")
                System.exit(1)
                throw RuntimeException()
            }
        } else {
            var v37: Int = 0
            v37 = (v11 - 1)
            var v38: Int = 0
            v38 = v0[v37]
            var v39: Boolean = false
            v39 = (v38 == v7)
            var v42: Boolean = false
            if (v39) {
                var v40: Int = 0
                v40 = v1[v37]
                var v41: Boolean = false
                v41 = (v40 == v8)
                v42 = v41
            } else {
                v42 = false
            }
            var v45: Boolean = false
            if (v42) {
                var v43: Int = 0
                v43 = v2[v37]
                var v44: Boolean = false
                v44 = (v43 == v9)
                v45 = v44
            } else {
                v45 = false
            }
            if (v45) {
                return v37
            } else {
                var v46: Int = 0
                v46 = (v10 + 1)
                var v47: Int = 0
                v47 = (v46 and 8191)
                val t4492_0: Array<Int> = v0
                val t4538_1: Array<Int> = v1
                val t4584_2: Array<Int> = v2
                val t4630_3: Array<Int> = v3
                val t4676_4: Array<Int> = v4
                val t4722_5: Array<Int> = v5
                val t4768_6: Array<Int> = v6
                val t4814_7: Int = v7
                val t4853_8: Int = v8
                val t4892_9: Int = v9
                val t4931_47: Int = v47
                v0 = t4492_0
                v1 = t4538_1
                v2 = t4584_2
                v3 = t4630_3
                v4 = t4676_4
                v5 = t4722_5
                v6 = t4768_6
                v7 = t4814_7
                v8 = t4853_8
                v9 = t4892_9
                v10 = t4931_47
                continue
            }
        }
    }
    return 0
}
fun sp_interned_node_26(p0: Array<Int>, p1: Array<Int>, p2: Array<Int>, p3: Array<Int>, p4: Array<Int>, p5: Array<Int>, p6: Array<Int>, p7: Int, p8: Int, p9: Int): Int {
    var v0: Array<Int> = p0
    var v1: Array<Int> = p1
    var v2: Array<Int> = p2
    var v3: Array<Int> = p3
    var v4: Array<Int> = p4
    var v5: Array<Int> = p5
    var v6: Array<Int> = p6
    var v7: Int = p7
    var v8: Int = p8
    var v9: Int = p9
    var v10: Int = 0
    v10 = (v7 * 1024)
    var v11: Int = 0
    v11 = (v10 + v8)
    var v12: Int = 0
    v12 = (v11 * 4099)
    var v13: Int = 0
    v13 = (v12 + v9)
    var v14: Int = 0
    v14 = (v13 and 8191)
    return sp_probe_27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14)
}
fun sp_interned_alt_insert_30(p0: Array<Int>, p1: Array<Int>, p2: Array<Int>, p3: Array<Int>, p4: Array<Int>, p5: Array<Int>, p6: Array<Int>, p7: Int, p8: Int): Int {
    var v0: Array<Int> = p0
    var v1: Array<Int> = p1
    var v2: Array<Int> = p2
    var v3: Array<Int> = p3
    var v4: Array<Int> = p4
    var v5: Array<Int> = p5
    var v6: Array<Int> = p6
    var v7: Int = p7
    var v8: Int = p8
    var v9: Boolean = false
    v9 = (v8 == 0)
    if (v9) {
        return v7
    } else {
        var v10: Int = 0
        v10 = v0[v8]
        var v11: Boolean = false
        v11 = (v10 == 3)
        if (v11) {
            var v12: Int = 0
            v12 = v1[v8]
            var v13: Boolean = false
            v13 = (v7 < v12)
            if (v13) {
                var v14: Int = 0
                v14 = 3
                return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8)
            } else {
                var v16: Boolean = false
                v16 = (v7 == v12)
                if (v16) {
                    return v8
                } else {
                    var v17: Int = 0
                    v17 = 3
                    var v18: Int = 0
                    v18 = v2[v8]
                    var v19: Int = 0
                    v19 = sp_interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v18)
                    return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19)
                }
            }
        } else {
            var v23: Boolean = false
            v23 = (v7 < v8)
            if (v23) {
                var v24: Int = 0
                v24 = 3
                return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8)
            } else {
                var v26: Boolean = false
                v26 = (v7 == v8)
                if (v26) {
                    return v8
                } else {
                    var v27: Int = 0
                    v27 = 3
                    return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7)
                }
            }
        }
    }
}
fun sp_interned_make_alt_29(p0: Array<Int>, p1: Array<Int>, p2: Array<Int>, p3: Array<Int>, p4: Array<Int>, p5: Array<Int>, p6: Array<Int>, p7: Int, p8: Int): Int {
    var v0: Array<Int> = p0
    var v1: Array<Int> = p1
    var v2: Array<Int> = p2
    var v3: Array<Int> = p3
    var v4: Array<Int> = p4
    var v5: Array<Int> = p5
    var v6: Array<Int> = p6
    var v7: Int = p7
    var v8: Int = p8
    while (true) {
        var v9: Boolean = false
        v9 = (v7 == 0)
        if (v9) {
            return v8
        } else {
            var v10: Int = 0
            v10 = v0[v7]
            var v11: Boolean = false
            v11 = (v10 == 3)
            if (v11) {
                var v12: Int = 0
                v12 = v2[v7]
                var v13: Int = 0
                v13 = v1[v7]
                var v14: Int = 0
                v14 = sp_interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v13, v8)
                val t946_0: Array<Int> = v0
                val t991_1: Array<Int> = v1
                val t1036_2: Array<Int> = v2
                val t1082_3: Array<Int> = v3
                val t1128_4: Array<Int> = v4
                val t1174_5: Array<Int> = v5
                val t1220_6: Array<Int> = v6
                val t1266_12: Int = v12
                val t1307_14: Int = v14
                v0 = t946_0
                v1 = t991_1
                v2 = t1036_2
                v3 = t1082_3
                v4 = t1128_4
                v5 = t1174_5
                v6 = t1220_6
                v7 = t1266_12
                v8 = t1307_14
                continue
            } else {
                return sp_interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v8)
            }
        }
    }
    return 0
}
fun sp_interned_make_cat_31(p0: Array<Int>, p1: Array<Int>, p2: Array<Int>, p3: Array<Int>, p4: Array<Int>, p5: Array<Int>, p6: Array<Int>, p7: Int, p8: Int): Int {
    var v0: Array<Int> = p0
    var v1: Array<Int> = p1
    var v2: Array<Int> = p2
    var v3: Array<Int> = p3
    var v4: Array<Int> = p4
    var v5: Array<Int> = p5
    var v6: Array<Int> = p6
    var v7: Int = p7
    var v8: Int = p8
    var v9: Boolean = false
    v9 = (v7 == 0)
    if (v9) {
        return 0
    } else {
        var v10: Boolean = false
        v10 = (v8 == 0)
        if (v10) {
            return 0
        } else {
            var v11: Boolean = false
            v11 = (v7 == 1)
            if (v11) {
                return v8
            } else {
                var v12: Boolean = false
                v12 = (v8 == 1)
                if (v12) {
                    return v7
                } else {
                    var v13: Int = 0
                    v13 = v0[v7]
                    var v14: Boolean = false
                    v14 = (v13 == 5)
                    var v17: Boolean = false
                    if (v14) {
                        var v15: Int = 0
                        v15 = v0[v8]
                        var v16: Boolean = false
                        v16 = (v15 == 5)
                        v17 = v16
                    } else {
                        v17 = false
                    }
                    if (v17) {
                        var v18: Int = 0
                        v18 = v1[v7]
                        var v19: Int = 0
                        v19 = v1[v8]
                        var v20: Boolean = false
                        v20 = (v18 == v19)
                        if (v20) {
                            return v7
                        } else {
                            var v21: Int = 0
                            v21 = 4
                            return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8)
                        }
                    } else {
                        var v24: Int = 0
                        v24 = v0[v7]
                        var v25: Boolean = false
                        v25 = (v24 == 4)
                        if (v25) {
                            var v26: Int = 0
                            v26 = 4
                            var v27: Int = 0
                            v27 = v1[v7]
                            var v28: Int = 0
                            v28 = v2[v7]
                            var v29: Int = 0
                            v29 = sp_interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v8)
                            return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29)
                        } else {
                            var v31: Int = 0
                            v31 = 4
                            return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8)
                        }
                    }
                }
            }
        }
    }
}
fun sp_interned_of_regex_raw_28(p0: Array<Int>, p1: Array<Int>, p2: Array<Int>, p3: Array<Int>, p4: Array<Int>, p5: Array<Int>, p6: Array<Int>, p7: UH1): Int {
    var v0: Array<Int> = p0
    var v1: Array<Int> = p1
    var v2: Array<Int> = p2
    var v3: Array<Int> = p3
    var v4: Array<Int> = p4
    var v5: Array<Int> = p5
    var v6: Array<Int> = p6
    var v7: UH1 = p7
    when (v7.tag) {
        3 -> {
            var v14: UH1 = (v7 as UH1_RegexAlt).f0
            var v15: UH1 = (v7 as UH1_RegexAlt).f1
            var v16: Int = 0
            v16 = sp_interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v14)
            var v17: Int = 0
            v17 = sp_interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v15)
            return sp_interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v16, v17)
        }
        4 -> {
            var v19: UH1 = (v7 as UH1_RegexCat).f0
            var v20: UH1 = (v7 as UH1_RegexCat).f1
            var v21: Int = 0
            v21 = sp_interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v19)
            var v22: Int = 0
            v22 = sp_interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v20)
            return sp_interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v21, v22)
        }
        2 -> {
            var v8: US0 = (v7 as UH1_RegexChar).f0
            var v9: Int = 0
            v9 = 2
            var v11: Int = 0
            when (v8.tag) {
                1 -> {
                    v11 = 1
                }
                0 -> {
                    v11 = 0
                }
                else -> throw RuntimeException()
            }
            var v12: Int = 0
            v12 = 0
            return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12)
        }
        0 -> {
            return 0
        }
        1 -> {
            return 1
        }
        5 -> {
            var v24: UH1 = (v7 as UH1_RegexStar).f0
            var v25: Int = 0
            v25 = sp_interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v24)
            var v26: Int = 0
            v26 = v0[v25]
            var v27: Boolean = false
            v27 = (v26 < 2)
            if (v27) {
                return 1
            } else {
                var v28: Boolean = false
                v28 = (v26 == 5)
                if (v28) {
                    return v25
                } else {
                    var v29: Int = 0
                    v29 = 5
                    var v30: Int = 0
                    v30 = 0
                    return sp_interned_node_26(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30)
                }
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_interned_derivative_raw_35(p0: Array<Int>, p1: Array<Int>, p2: Array<Int>, p3: Array<Int>, p4: Array<Int>, p5: Array<Int>, p6: Array<Int>, p7: Int, p8: Int): Int {
    var v0: Array<Int> = p0
    var v1: Array<Int> = p1
    var v2: Array<Int> = p2
    var v3: Array<Int> = p3
    var v4: Array<Int> = p4
    var v5: Array<Int> = p5
    var v6: Array<Int> = p6
    var v7: Int = p7
    var v8: Int = p8
    var v9: Int = 0
    v9 = (v7 * 2)
    var v10: Int = 0
    v10 = (v9 + v8)
    var v11: Int = 0
    v11 = v5[v10]
    var v12: Boolean = false
    v12 = (v11 == 0)
    if (v12) {
        var v13: Int = 0
        v13 = v0[v7]
        var v14: Boolean = false
        v14 = (v13 < 2)
        var v41: Int = 0
        if (v14) {
            v41 = 0
        } else {
            var v15: Boolean = false
            v15 = (v13 == 2)
            if (v15) {
                var v16: Int = 0
                v16 = v1[v7]
                var v17: Boolean = false
                v17 = (v16 == v8)
                if (v17) {
                    v41 = 1
                } else {
                    v41 = 0
                }
            } else {
                var v19: Boolean = false
                v19 = (v13 == 3)
                if (v19) {
                    var v20: Int = 0
                    v20 = v1[v7]
                    var v21: Int = 0
                    v21 = sp_interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v20, v8)
                    var v22: Int = 0
                    v22 = v2[v7]
                    var v23: Int = 0
                    v23 = sp_interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v22, v8)
                    v41 = sp_interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v21, v23)
                } else {
                    var v25: Boolean = false
                    v25 = (v13 == 4)
                    if (v25) {
                        var v26: Int = 0
                        v26 = v1[v7]
                        var v27: Int = 0
                        v27 = v2[v7]
                        var v28: Int = 0
                        v28 = sp_interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v26, v8)
                        var v29: Int = 0
                        v29 = sp_interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v27)
                        var v30: Int = 0
                        v30 = v3[v26]
                        var v31: Boolean = false
                        v31 = (v30 == 1)
                        if (v31) {
                            var v32: Int = 0
                            v32 = sp_interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v27, v8)
                            v41 = sp_interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v29, v32)
                        } else {
                            v41 = v29
                        }
                    } else {
                        var v35: Int = 0
                        v35 = v1[v7]
                        var v36: Int = 0
                        v36 = sp_interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v35, v8)
                        v41 = sp_interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v36, v7)
                    }
                }
            }
        }
        var v42: Int = 0
        v42 = (v41 + 1)
        v5[v10] = v42
        return v41
    } else {
        var v43: Int = 0
        v43 = (v11 - 1)
        return v43
    }
}
fun sp_loop_34(p0: Array<Int>, p1: Array<Int>, p2: Array<Int>, p3: Array<Int>, p4: Array<Int>, p5: Array<Int>, p6: Array<Int>, p7: Int, p8: UH2): Boolean {
    var v0: Array<Int> = p0
    var v1: Array<Int> = p1
    var v2: Array<Int> = p2
    var v3: Array<Int> = p3
    var v4: Array<Int> = p4
    var v5: Array<Int> = p5
    var v6: Array<Int> = p6
    var v7: Int = p7
    var v8: UH2 = p8
    var v9: Boolean = false
    v9 = (v7 == 0)
    if (v9) {
        return false
    } else {
        when (v8.tag) {
            1 -> {
                var v12: US0 = (v8 as UH2_InputCons).f0
                var v13: UH2 = (v8 as UH2_InputCons).f1
                var v15: Int = 0
                when (v12.tag) {
                    1 -> {
                        v15 = 1
                    }
                    0 -> {
                        v15 = 0
                    }
                    else -> throw RuntimeException()
                }
                var v16: Int = 0
                v16 = sp_interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v7, v15)
                return sp_loop_34(v0, v1, v2, v3, v4, v5, v6, v16, v13)
            }
            0 -> {
                var v10: Int = 0
                v10 = v3[v7]
                var v11: Boolean = false
                v11 = (v10 == 1)
                return v11
            }
            else -> throw RuntimeException()
        }
    }
}
fun sp_interned_accepts_33(p0: Array<Int>, p1: Array<Int>, p2: Array<Int>, p3: Array<Int>, p4: Array<Int>, p5: Array<Int>, p6: Array<Int>, p7: Int, p8: UH2): Boolean {
    var v0: Array<Int> = p0
    var v1: Array<Int> = p1
    var v2: Array<Int> = p2
    var v3: Array<Int> = p3
    var v4: Array<Int> = p4
    var v5: Array<Int> = p5
    var v6: Array<Int> = p6
    var v7: Int = p7
    var v8: UH2 = p8
    return sp_loop_34(v0, v1, v2, v3, v4, v5, v6, v7, v8)
}
fun sp_loop_32(p0: Array<Int>, p1: Array<Int>, p2: Array<Int>, p3: Array<Int>, p4: Array<Int>, p5: Array<Int>, p6: Array<Int>, p7: Int, p8: Int, p9: Int, p10: ULong, p11: Int): Int {
    var v0: Array<Int> = p0
    var v1: Array<Int> = p1
    var v2: Array<Int> = p2
    var v3: Array<Int> = p3
    var v4: Array<Int> = p4
    var v5: Array<Int> = p5
    var v6: Array<Int> = p6
    var v7: Int = p7
    var v8: Int = p8
    var v9: Int = p9
    var v10: ULong = p10
    var v11: Int = p11
    while (true) {
        var v12: Boolean = false
        v12 = (0 < v9)
        if (v12) {
            var v13: UH2 = UH2_InputEmpty()
            v13 = UH2_InputEmpty()
            var v14: UH2 = UH2_InputEmpty()
            var v15: ULong = 0uL
            val spiral_tuple761 = sp_random_bit_input_1(v10, v7, v13)
            v14 = spiral_tuple761.v0
            v15 = spiral_tuple761.v1
            var v16: Boolean = false
            v16 = sp_interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v14)
            var v18: Int = 0
            if (v16) {
                var v17: Int = 0
                v17 = (v11 + 1)
                v18 = v17
            } else {
                v18 = v11
            }
            var v19: Int = 0
            v19 = (v9 - 1)
            val t1295_0: Array<Int> = v0
            val t1337_1: Array<Int> = v1
            val t1379_2: Array<Int> = v2
            val t1421_3: Array<Int> = v3
            val t1463_4: Array<Int> = v4
            val t1505_5: Array<Int> = v5
            val t1547_6: Array<Int> = v6
            val t1589_7: Int = v7
            val t1624_8: Int = v8
            val t1659_19: Int = v19
            val t1696_15: ULong = v15
            val t1735_18: Int = v18
            v0 = t1295_0
            v1 = t1337_1
            v2 = t1379_2
            v3 = t1421_3
            v4 = t1463_4
            v5 = t1505_5
            v6 = t1547_6
            v7 = t1589_7
            v8 = t1624_8
            v9 = t1659_19
            v10 = t1696_15
            v11 = t1735_18
            continue
        } else {
            return v11
        }
    }
    return 0
}
fun sp_loop_36(p0: Array<Int>, p1: Array<Int>, p2: Array<Int>, p3: Array<Int>, p4: Array<Int>, p5: Array<Int>, p6: Array<Int>, p7: Int, p8: Int, p9: Int, p10: Int): Int {
    var v0: Array<Int> = p0
    var v1: Array<Int> = p1
    var v2: Array<Int> = p2
    var v3: Array<Int> = p3
    var v4: Array<Int> = p4
    var v5: Array<Int> = p5
    var v6: Array<Int> = p6
    var v7: Int = p7
    var v8: Int = p8
    var v9: Int = p9
    var v10: Int = p10
    while (true) {
        var v11: Boolean = false
        v11 = (v7 < v9)
        if (v11) {
            return v10
        } else {
            var v12: UH2 = UH2_InputEmpty()
            v12 = UH2_InputEmpty()
            var v13: UH2 = UH2_InputEmpty()
            v13 = sp_zeros_input_14(v9, v12)
            var v14: Boolean = false
            v14 = sp_interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v13)
            var v16: Int = 0
            if (v14) {
                var v15: Int = 0
                v15 = (v10 + 1)
                v16 = v15
            } else {
                v16 = v10
            }
            var v17: US0 = US0_BitZero()
            v17 = US0_BitOne()
            var v18: UH2 = UH2_InputEmpty()
            v18 = UH2_InputEmpty()
            var v19: UH2 = UH2_InputEmpty()
            v19 = UH2_InputCons(v17, v18)
            var v20: UH2 = UH2_InputEmpty()
            v20 = sp_zeros_input_14(v9, v19)
            var v21: Boolean = false
            v21 = sp_interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v20)
            var v23: Int = 0
            if (v21) {
                var v22: Int = 0
                v22 = (v16 + 1)
                v23 = v22
            } else {
                v23 = v16
            }
            var v24: Int = 0
            v24 = (v9 + 1)
            val t1828_0: Array<Int> = v0
            val t1870_1: Array<Int> = v1
            val t1912_2: Array<Int> = v2
            val t1954_3: Array<Int> = v3
            val t1996_4: Array<Int> = v4
            val t2038_5: Array<Int> = v5
            val t2080_6: Array<Int> = v6
            val t2122_7: Int = v7
            val t2157_8: Int = v8
            val t2192_24: Int = v24
            val t2229_23: Int = v23
            v0 = t1828_0
            v1 = t1870_1
            v2 = t1912_2
            v3 = t1954_3
            v4 = t1996_4
            v5 = t2038_5
            v6 = t2080_6
            v7 = t2122_7
            v8 = t2157_8
            v9 = t2192_24
            v10 = t2229_23
            continue
        }
    }
    return 0
}
fun spiral_main(): Int {
    var v0: Int = 0
    v0 = 200
    var v1: Int = 0
    v1 = 32
    var v2: US0 = US0_BitZero()
    v2 = US0_BitZero()
    var v3: UH1 = UH1_RegexEmpty()
    v3 = UH1_RegexChar(v2)
    var v4: US0 = US0_BitZero()
    v4 = US0_BitOne()
    var v5: UH1 = UH1_RegexEmpty()
    v5 = UH1_RegexChar(v4)
    var v6: UH1 = UH1_RegexEmpty()
    v6 = UH1_RegexAlt(v3, v5)
    var v7: UH1 = UH1_RegexEmpty()
    v7 = UH1_RegexStar(v6)
    var v8: US0 = US0_BitZero()
    v8 = US0_BitZero()
    var v9: UH1 = UH1_RegexEmpty()
    v9 = UH1_RegexChar(v8)
    var v10: UH1 = UH1_RegexEmpty()
    v10 = UH1_RegexCat(v7, v9)
    var v11: US0 = US0_BitZero()
    v11 = US0_BitZero()
    var v12: UH1 = UH1_RegexEmpty()
    v12 = UH1_RegexChar(v11)
    var v13: US0 = US0_BitZero()
    v13 = US0_BitOne()
    var v14: UH1 = UH1_RegexEmpty()
    v14 = UH1_RegexChar(v13)
    var v15: UH1 = UH1_RegexEmpty()
    v15 = UH1_RegexAlt(v12, v14)
    var v16: UH1 = UH1_RegexEmpty()
    v16 = UH1_RegexStar(v15)
    var v17: US0 = US0_BitZero()
    v17 = US0_BitOne()
    var v18: UH1 = UH1_RegexEmpty()
    v18 = UH1_RegexChar(v17)
    var v19: US0 = US0_BitZero()
    v19 = US0_BitZero()
    var v20: UH1 = UH1_RegexEmpty()
    v20 = UH1_RegexChar(v19)
    var v21: US0 = US0_BitZero()
    v21 = US0_BitOne()
    var v22: UH1 = UH1_RegexEmpty()
    v22 = UH1_RegexChar(v21)
    var v23: UH1 = UH1_RegexEmpty()
    v23 = UH1_RegexAlt(v20, v22)
    var v24: US0 = US0_BitZero()
    v24 = US0_BitZero()
    var v25: UH1 = UH1_RegexEmpty()
    v25 = UH1_RegexChar(v24)
    var v26: US0 = US0_BitZero()
    v26 = US0_BitOne()
    var v27: UH1 = UH1_RegexEmpty()
    v27 = UH1_RegexChar(v26)
    var v28: UH1 = UH1_RegexEmpty()
    v28 = UH1_RegexAlt(v25, v27)
    var v29: US0 = US0_BitZero()
    v29 = US0_BitZero()
    var v30: UH1 = UH1_RegexEmpty()
    v30 = UH1_RegexChar(v29)
    var v31: US0 = US0_BitZero()
    v31 = US0_BitOne()
    var v32: UH1 = UH1_RegexEmpty()
    v32 = UH1_RegexChar(v31)
    var v33: UH1 = UH1_RegexEmpty()
    v33 = UH1_RegexAlt(v30, v32)
    var v34: UH1 = UH1_RegexEmpty()
    v34 = UH1_RegexCat(v28, v33)
    var v35: UH1 = UH1_RegexEmpty()
    v35 = UH1_RegexCat(v23, v34)
    var v36: UH1 = UH1_RegexEmpty()
    v36 = UH1_RegexCat(v18, v35)
    var v37: UH1 = UH1_RegexEmpty()
    v37 = UH1_RegexCat(v16, v36)
    var v38: ULong = 0uL
    v38 = 1uL
    var v39: Int = 0
    v39 = 0
    var v40: Int = 0
    v40 = sp_loop_0(v10, v1, v0, v38, v39)
    var v41: Int = 0
    v41 = sp_loop_0(v37, v1, v0, v38, v39)
    var v42: Int = 0
    v42 = 16
    var v43: US0 = US0_BitZero()
    v43 = US0_BitZero()
    var v44: UH1 = UH1_RegexEmpty()
    v44 = UH1_RegexChar(v43)
    var v45: US0 = US0_BitZero()
    v45 = US0_BitZero()
    var v46: UH1 = UH1_RegexEmpty()
    v46 = UH1_RegexChar(v45)
    var v47: US0 = US0_BitZero()
    v47 = US0_BitZero()
    var v48: UH1 = UH1_RegexEmpty()
    v48 = UH1_RegexChar(v47)
    var v49: UH1 = UH1_RegexEmpty()
    v49 = UH1_RegexCat(v46, v48)
    var v50: UH1 = UH1_RegexEmpty()
    v50 = UH1_RegexAlt(v44, v49)
    var v51: UH1 = UH1_RegexEmpty()
    v51 = UH1_RegexStar(v50)
    var v52: US0 = US0_BitZero()
    v52 = US0_BitOne()
    var v53: UH1 = UH1_RegexEmpty()
    v53 = UH1_RegexChar(v52)
    var v54: UH1 = UH1_RegexEmpty()
    v54 = UH1_RegexCat(v51, v53)
    var v55: Int = 0
    v55 = 0
    var v56: Int = 0
    v56 = 1
    var v57: Int = 0
    v57 = sp_loop_13(v54, v42, v56, v55)
    var v58: Int = 0
    v58 = 200
    var v59: Int = 0
    v59 = 32
    var v60: US0 = US0_BitZero()
    v60 = US0_BitZero()
    var v61: UH1 = UH1_RegexEmpty()
    v61 = UH1_RegexChar(v60)
    var v62: US0 = US0_BitZero()
    v62 = US0_BitOne()
    var v63: UH1 = UH1_RegexEmpty()
    v63 = UH1_RegexChar(v62)
    var v64: UH1 = UH1_RegexEmpty()
    v64 = UH1_RegexAlt(v61, v63)
    var v65: UH1 = UH1_RegexEmpty()
    v65 = UH1_RegexStar(v64)
    var v66: US0 = US0_BitZero()
    v66 = US0_BitZero()
    var v67: UH1 = UH1_RegexEmpty()
    v67 = UH1_RegexChar(v66)
    var v68: UH1 = UH1_RegexEmpty()
    v68 = UH1_RegexCat(v65, v67)
    var v69: US0 = US0_BitZero()
    v69 = US0_BitZero()
    var v70: UH1 = UH1_RegexEmpty()
    v70 = UH1_RegexChar(v69)
    var v71: US0 = US0_BitZero()
    v71 = US0_BitOne()
    var v72: UH1 = UH1_RegexEmpty()
    v72 = UH1_RegexChar(v71)
    var v73: UH1 = UH1_RegexEmpty()
    v73 = UH1_RegexAlt(v70, v72)
    var v74: UH1 = UH1_RegexEmpty()
    v74 = UH1_RegexStar(v73)
    var v75: US0 = US0_BitZero()
    v75 = US0_BitOne()
    var v76: UH1 = UH1_RegexEmpty()
    v76 = UH1_RegexChar(v75)
    var v77: US0 = US0_BitZero()
    v77 = US0_BitZero()
    var v78: UH1 = UH1_RegexEmpty()
    v78 = UH1_RegexChar(v77)
    var v79: US0 = US0_BitZero()
    v79 = US0_BitOne()
    var v80: UH1 = UH1_RegexEmpty()
    v80 = UH1_RegexChar(v79)
    var v81: UH1 = UH1_RegexEmpty()
    v81 = UH1_RegexAlt(v78, v80)
    var v82: US0 = US0_BitZero()
    v82 = US0_BitZero()
    var v83: UH1 = UH1_RegexEmpty()
    v83 = UH1_RegexChar(v82)
    var v84: US0 = US0_BitZero()
    v84 = US0_BitOne()
    var v85: UH1 = UH1_RegexEmpty()
    v85 = UH1_RegexChar(v84)
    var v86: UH1 = UH1_RegexEmpty()
    v86 = UH1_RegexAlt(v83, v85)
    var v87: US0 = US0_BitZero()
    v87 = US0_BitZero()
    var v88: UH1 = UH1_RegexEmpty()
    v88 = UH1_RegexChar(v87)
    var v89: US0 = US0_BitZero()
    v89 = US0_BitOne()
    var v90: UH1 = UH1_RegexEmpty()
    v90 = UH1_RegexChar(v89)
    var v91: UH1 = UH1_RegexEmpty()
    v91 = UH1_RegexAlt(v88, v90)
    var v92: UH1 = UH1_RegexEmpty()
    v92 = UH1_RegexCat(v86, v91)
    var v93: UH1 = UH1_RegexEmpty()
    v93 = UH1_RegexCat(v81, v92)
    var v94: UH1 = UH1_RegexEmpty()
    v94 = UH1_RegexCat(v76, v93)
    var v95: UH1 = UH1_RegexEmpty()
    v95 = UH1_RegexCat(v74, v94)
    var v96: ULong = 0uL
    v96 = 1uL
    var v97: Int = 0
    v97 = 0
    var v98: Int = 0
    v98 = sp_loop_15(v68, v59, v58, v96, v97)
    var v99: Int = 0
    v99 = sp_loop_15(v95, v59, v58, v96, v97)
    var v100: Int = 0
    v100 = 16
    var v101: US0 = US0_BitZero()
    v101 = US0_BitZero()
    var v102: UH1 = UH1_RegexEmpty()
    v102 = UH1_RegexChar(v101)
    var v103: US0 = US0_BitZero()
    v103 = US0_BitZero()
    var v104: UH1 = UH1_RegexEmpty()
    v104 = UH1_RegexChar(v103)
    var v105: US0 = US0_BitZero()
    v105 = US0_BitZero()
    var v106: UH1 = UH1_RegexEmpty()
    v106 = UH1_RegexChar(v105)
    var v107: UH1 = UH1_RegexEmpty()
    v107 = UH1_RegexCat(v104, v106)
    var v108: UH1 = UH1_RegexEmpty()
    v108 = UH1_RegexAlt(v102, v107)
    var v109: UH1 = UH1_RegexEmpty()
    v109 = UH1_RegexStar(v108)
    var v110: US0 = US0_BitZero()
    v110 = US0_BitOne()
    var v111: UH1 = UH1_RegexEmpty()
    v111 = UH1_RegexChar(v110)
    var v112: UH1 = UH1_RegexEmpty()
    v112 = UH1_RegexCat(v109, v111)
    var v113: Int = 0
    v113 = 0
    var v114: Int = 0
    v114 = 1
    var v115: Int = 0
    v115 = sp_loop_17(v112, v100, v114, v113)
    var v116: Boolean = false
    v116 = (v40 == v98)
    var v118: Boolean = false
    if (v116) {
        var v117: Boolean = false
        v117 = (v41 == v99)
        v118 = v117
    } else {
        v118 = false
    }
    var v120: Boolean = false
    if (v118) {
        var v119: Boolean = false
        v119 = (v57 == v115)
        v120 = v119
    } else {
        v120 = false
    }
    if (v120) {
    } else {
        System.err.println("brzozowski-bench-engines-disagree")
        System.exit(1)
        throw RuntimeException()
    }
    var v121: Int = 0
    v121 = 200
    var v122: Int = 0
    v122 = 32
    var v123: ULong = 0uL
    v123 = 1uL
    var v124: Int = 0
    v124 = 0
    var v125: Int = 0
    v125 = sp_loop_18(v122, v121, v123, v124)
    var v126: Int = 0
    v126 = sp_loop_20(v122, v121, v123, v124)
    var v127: Int = 0
    v127 = 16
    var v128: Int = 0
    v128 = 0
    var v129: Int = 0
    v129 = 1
    var v130: Int = 0
    v130 = sp_loop_22(v127, v129, v128)
    var v131: Boolean = false
    v131 = (v40 == v125)
    var v133: Boolean = false
    if (v131) {
        var v132: Boolean = false
        v132 = (v41 == v126)
        v133 = v132
    } else {
        v133 = false
    }
    var v135: Boolean = false
    if (v133) {
        var v134: Boolean = false
        v134 = (v57 == v130)
        v135 = v134
    } else {
        v135 = false
    }
    if (v135) {
    } else {
        System.err.println("brzozowski-bench-engines-disagree")
        System.exit(1)
        throw RuntimeException()
    }
    var v136: Int = 0
    v136 = 200
    var v137: Int = 0
    v137 = 32
    var v138: Array<Int> = emptyArray<Int>()
    v138 = Array(4096) { 0 }
    var v139: Array<Int> = emptyArray<Int>()
    v139 = Array(4096) { 0 }
    var v140: Array<Int> = emptyArray<Int>()
    v140 = Array(4096) { 0 }
    var v141: Array<Int> = emptyArray<Int>()
    v141 = Array(4096) { 0 }
    var v142: Array<Int> = emptyArray<Int>()
    v142 = Array(8192) { 0 }
    var v143: Array<Int> = emptyArray<Int>()
    v143 = Array(8192) { 0 }
    var v144: Array<Int> = emptyArray<Int>()
    v144 = Array(1) { 0 }
    var v145: Int = 0
    v145 = 0
    sp_loop_24(v142, v145)
    var v146: Int = 0
    v146 = 0
    sp_loop_24(v143, v146)
    var v147: Int = 0
    v147 = 0
    sp_loop_25(v144, v147)
    var v148: Int = 0
    v148 = 0
    var v149: Int = 0
    v149 = 0
    var v150: Int = 0
    v150 = 0
    var v151: Int = 0
    v151 = sp_interned_node_26(v138, v139, v140, v141, v142, v143, v144, v148, v149, v150)
    var v152: Int = 0
    v152 = 1
    var v153: Int = 0
    v153 = 0
    var v154: Int = 0
    v154 = 0
    var v155: Int = 0
    v155 = sp_interned_node_26(v138, v139, v140, v141, v142, v143, v144, v152, v153, v154)
    var v156: Boolean = false
    v156 = (v151 == 0)
    var v158: Boolean = false
    if (v156) {
        var v157: Boolean = false
        v157 = (v155 == 1)
        v158 = v157
    } else {
        v158 = false
    }
    var v166: Array<Int> = emptyArray<Int>()
    var v167: Array<Int> = emptyArray<Int>()
    var v168: Array<Int> = emptyArray<Int>()
    var v169: Array<Int> = emptyArray<Int>()
    var v170: Array<Int> = emptyArray<Int>()
    var v171: Array<Int> = emptyArray<Int>()
    var v172: Array<Int> = emptyArray<Int>()
    if (v158) {
        v166 = v138
        v167 = v139
        v168 = v140
        v169 = v141
        v170 = v142
        v171 = v143
        v172 = v144
    } else {
        System.err.println("brzozowski-interned-store-init")
        System.exit(1)
        throw RuntimeException()
    }
    var v173: US0 = US0_BitZero()
    v173 = US0_BitZero()
    var v174: UH1 = UH1_RegexEmpty()
    v174 = UH1_RegexChar(v173)
    var v175: US0 = US0_BitZero()
    v175 = US0_BitOne()
    var v176: UH1 = UH1_RegexEmpty()
    v176 = UH1_RegexChar(v175)
    var v177: UH1 = UH1_RegexEmpty()
    v177 = UH1_RegexAlt(v174, v176)
    var v178: UH1 = UH1_RegexEmpty()
    v178 = UH1_RegexStar(v177)
    var v179: US0 = US0_BitZero()
    v179 = US0_BitZero()
    var v180: UH1 = UH1_RegexEmpty()
    v180 = UH1_RegexChar(v179)
    var v181: UH1 = UH1_RegexEmpty()
    v181 = UH1_RegexCat(v178, v180)
    var v182: Int = 0
    v182 = sp_interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v181)
    var v183: ULong = 0uL
    v183 = 1uL
    var v184: Int = 0
    v184 = 0
    var v185: Int = 0
    v185 = sp_loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v182, v136, v183, v184)
    var v186: US0 = US0_BitZero()
    v186 = US0_BitZero()
    var v187: UH1 = UH1_RegexEmpty()
    v187 = UH1_RegexChar(v186)
    var v188: US0 = US0_BitZero()
    v188 = US0_BitOne()
    var v189: UH1 = UH1_RegexEmpty()
    v189 = UH1_RegexChar(v188)
    var v190: UH1 = UH1_RegexEmpty()
    v190 = UH1_RegexAlt(v187, v189)
    var v191: UH1 = UH1_RegexEmpty()
    v191 = UH1_RegexStar(v190)
    var v192: US0 = US0_BitZero()
    v192 = US0_BitOne()
    var v193: UH1 = UH1_RegexEmpty()
    v193 = UH1_RegexChar(v192)
    var v194: US0 = US0_BitZero()
    v194 = US0_BitZero()
    var v195: UH1 = UH1_RegexEmpty()
    v195 = UH1_RegexChar(v194)
    var v196: US0 = US0_BitZero()
    v196 = US0_BitOne()
    var v197: UH1 = UH1_RegexEmpty()
    v197 = UH1_RegexChar(v196)
    var v198: UH1 = UH1_RegexEmpty()
    v198 = UH1_RegexAlt(v195, v197)
    var v199: US0 = US0_BitZero()
    v199 = US0_BitZero()
    var v200: UH1 = UH1_RegexEmpty()
    v200 = UH1_RegexChar(v199)
    var v201: US0 = US0_BitZero()
    v201 = US0_BitOne()
    var v202: UH1 = UH1_RegexEmpty()
    v202 = UH1_RegexChar(v201)
    var v203: UH1 = UH1_RegexEmpty()
    v203 = UH1_RegexAlt(v200, v202)
    var v204: US0 = US0_BitZero()
    v204 = US0_BitZero()
    var v205: UH1 = UH1_RegexEmpty()
    v205 = UH1_RegexChar(v204)
    var v206: US0 = US0_BitZero()
    v206 = US0_BitOne()
    var v207: UH1 = UH1_RegexEmpty()
    v207 = UH1_RegexChar(v206)
    var v208: UH1 = UH1_RegexEmpty()
    v208 = UH1_RegexAlt(v205, v207)
    var v209: UH1 = UH1_RegexEmpty()
    v209 = UH1_RegexCat(v203, v208)
    var v210: UH1 = UH1_RegexEmpty()
    v210 = UH1_RegexCat(v198, v209)
    var v211: UH1 = UH1_RegexEmpty()
    v211 = UH1_RegexCat(v193, v210)
    var v212: UH1 = UH1_RegexEmpty()
    v212 = UH1_RegexCat(v191, v211)
    var v213: Int = 0
    v213 = sp_interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v212)
    var v214: ULong = 0uL
    v214 = 1uL
    var v215: Int = 0
    v215 = 0
    var v216: Int = 0
    v216 = sp_loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v213, v136, v214, v215)
    var v217: Int = 0
    v217 = 16
    var v218: Array<Int> = emptyArray<Int>()
    v218 = Array(4096) { 0 }
    var v219: Array<Int> = emptyArray<Int>()
    v219 = Array(4096) { 0 }
    var v220: Array<Int> = emptyArray<Int>()
    v220 = Array(4096) { 0 }
    var v221: Array<Int> = emptyArray<Int>()
    v221 = Array(4096) { 0 }
    var v222: Array<Int> = emptyArray<Int>()
    v222 = Array(8192) { 0 }
    var v223: Array<Int> = emptyArray<Int>()
    v223 = Array(8192) { 0 }
    var v224: Array<Int> = emptyArray<Int>()
    v224 = Array(1) { 0 }
    var v225: Int = 0
    v225 = 0
    sp_loop_24(v222, v225)
    var v226: Int = 0
    v226 = 0
    sp_loop_24(v223, v226)
    var v227: Int = 0
    v227 = 0
    sp_loop_25(v224, v227)
    var v228: Int = 0
    v228 = 0
    var v229: Int = 0
    v229 = 0
    var v230: Int = 0
    v230 = 0
    var v231: Int = 0
    v231 = sp_interned_node_26(v218, v219, v220, v221, v222, v223, v224, v228, v229, v230)
    var v232: Int = 0
    v232 = 1
    var v233: Int = 0
    v233 = 0
    var v234: Int = 0
    v234 = 0
    var v235: Int = 0
    v235 = sp_interned_node_26(v218, v219, v220, v221, v222, v223, v224, v232, v233, v234)
    var v236: Boolean = false
    v236 = (v231 == 0)
    var v238: Boolean = false
    if (v236) {
        var v237: Boolean = false
        v237 = (v235 == 1)
        v238 = v237
    } else {
        v238 = false
    }
    var v246: Array<Int> = emptyArray<Int>()
    var v247: Array<Int> = emptyArray<Int>()
    var v248: Array<Int> = emptyArray<Int>()
    var v249: Array<Int> = emptyArray<Int>()
    var v250: Array<Int> = emptyArray<Int>()
    var v251: Array<Int> = emptyArray<Int>()
    var v252: Array<Int> = emptyArray<Int>()
    if (v238) {
        v246 = v218
        v247 = v219
        v248 = v220
        v249 = v221
        v250 = v222
        v251 = v223
        v252 = v224
    } else {
        System.err.println("brzozowski-interned-store-init")
        System.exit(1)
        throw RuntimeException()
    }
    var v253: US0 = US0_BitZero()
    v253 = US0_BitZero()
    var v254: UH1 = UH1_RegexEmpty()
    v254 = UH1_RegexChar(v253)
    var v255: US0 = US0_BitZero()
    v255 = US0_BitZero()
    var v256: UH1 = UH1_RegexEmpty()
    v256 = UH1_RegexChar(v255)
    var v257: US0 = US0_BitZero()
    v257 = US0_BitZero()
    var v258: UH1 = UH1_RegexEmpty()
    v258 = UH1_RegexChar(v257)
    var v259: UH1 = UH1_RegexEmpty()
    v259 = UH1_RegexCat(v256, v258)
    var v260: UH1 = UH1_RegexEmpty()
    v260 = UH1_RegexAlt(v254, v259)
    var v261: UH1 = UH1_RegexEmpty()
    v261 = UH1_RegexStar(v260)
    var v262: US0 = US0_BitZero()
    v262 = US0_BitOne()
    var v263: UH1 = UH1_RegexEmpty()
    v263 = UH1_RegexChar(v262)
    var v264: UH1 = UH1_RegexEmpty()
    v264 = UH1_RegexCat(v261, v263)
    var v265: Int = 0
    v265 = sp_interned_of_regex_raw_28(v246, v247, v248, v249, v250, v251, v252, v264)
    var v266: Int = 0
    v266 = 1
    var v267: Int = 0
    v267 = 0
    var v268: Int = 0
    v268 = sp_loop_36(v246, v247, v248, v249, v250, v251, v252, v217, v265, v266, v267)
    var v269: Boolean = false
    v269 = (v40 == v185)
    var v271: Boolean = false
    if (v269) {
        var v270: Boolean = false
        v270 = (v41 == v216)
        v271 = v270
    } else {
        v271 = false
    }
    var v273: Boolean = false
    if (v271) {
        var v272: Boolean = false
        v272 = (v57 == v268)
        v273 = v272
    } else {
        v273 = false
    }
    if (v273) {
    } else {
        System.err.println("brzozowski-bench-engines-disagree")
        System.exit(1)
        throw RuntimeException()
    }
    var v274: Boolean = false
    v274 = (v57 == 16)
    if (v274) {
    } else {
        System.err.println("brzozowski-bench-zero-runs-count")
        System.exit(1)
        throw RuntimeException()
    }
    var v275: Boolean = false
    v275 = (v40 == 93)
    if (v275) {
    } else {
        System.err.println("brzozowski-bench-ends-with-zero-count")
        System.exit(1)
        throw RuntimeException()
    }
    var v276: Boolean = false
    v276 = (v41 == 97)
    if (v276) {
    } else {
        System.err.println("brzozowski-bench-fourth-from-end-count")
        System.exit(1)
        throw RuntimeException()
    }
    return 0
}
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
