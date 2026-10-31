sealed interface US0 { val tag: Int }
object US0_BitZero : US0 { override val tag: Int = 0 }
object US0_BitOne : US0 { override val tag: Int = 1 }
sealed interface UH1 { val tag: Int }
object UH1_RegexEmpty : UH1 { override val tag: Int = 0 }
object UH1_RegexEpsilon : UH1 { override val tag: Int = 1 }
data class UH1_RegexChar(val f0: US0) : UH1 { override val tag: Int = 2 }
data class UH1_RegexAlt(val f0: UH1, val f1: UH1) : UH1 { override val tag: Int = 3 }
data class UH1_RegexCat(val f0: UH1, val f1: UH1) : UH1 { override val tag: Int = 4 }
data class UH1_RegexStar(val f0: UH1) : UH1 { override val tag: Int = 5 }
sealed interface UH2 { val tag: Int }
object UH2_InputEmpty : UH2 { override val tag: Int = 0 }
data class UH2_InputCons(val f0: US0, val f1: UH2) : UH2 { override val tag: Int = 1 }
sealed interface US3 { val tag: Int }
object US3_SymbolLess : US3 { override val tag: Int = 0 }
object US3_SymbolSame : US3 { override val tag: Int = 1 }
object US3_SymbolGreater : US3 { override val tag: Int = 2 }
sealed interface US4 { val tag: Int }
object US4_Nullable : US4 { override val tag: Int = 0 }
object US4_NonNullable : US4 { override val tag: Int = 1 }
sealed interface UH5 { val tag: Int }
object UH5_RegexListNil : UH5 { override val tag: Int = 0 }
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
            var v13: US0 = US0_BitZero
            if (v10) {
                var v11: US0 = US0_BitZero
                v11 = US0_BitZero
                v13 = v11
            } else {
                var v12: US0 = US0_BitZero
                v12 = US0_BitOne
                v13 = v12
            }
            var v14: UH2 = UH2_InputEmpty
            v14 = UH2_InputCons(v13, v2)
            v0 = v6
            v1 = v7
            v2 = v14
            continue
        } else {
            return SpiralTuple0(v2, v0)
        }
    }
    return SpiralTuple0(UH2_InputEmpty, 0uL)
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
                    var v57: US3 = US3_SymbolLess
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
                    return US3_SymbolGreater
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
                    var v36: US3 = US3_SymbolLess
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
                    return US3_SymbolGreater
                }
                0 -> {
                    return US3_SymbolGreater
                }
                1 -> {
                    return US3_SymbolGreater
                }
                else -> {
                    return US3_SymbolLess
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
                                    return US3_SymbolSame
                                }
                                0 -> {
                                    return US3_SymbolGreater
                                }
                                else -> throw RuntimeException()
                            }
                        }
                        0 -> {
                            when (v13.tag) {
                                1 -> {
                                    return US3_SymbolLess
                                }
                                0 -> {
                                    return US3_SymbolSame
                                }
                                else -> throw RuntimeException()
                            }
                        }
                        else -> throw RuntimeException()
                    }
                }
                0 -> {
                    return US3_SymbolGreater
                }
                1 -> {
                    return US3_SymbolGreater
                }
                else -> {
                    return US3_SymbolLess
                }
            }
        }
        0 -> {
            when (v1.tag) {
                0 -> {
                    return US3_SymbolSame
                }
                else -> {
                    return US3_SymbolLess
                }
            }
        }
        1 -> {
            when (v1.tag) {
                0 -> {
                    return US3_SymbolGreater
                }
                1 -> {
                    return US3_SymbolSame
                }
                else -> {
                    return US3_SymbolLess
                }
            }
        }
        5 -> {
            var v44: UH1 = (v0 as UH1_RegexStar).f0
            when (v1.tag) {
                3 -> {
                    var v45: UH1 = (v1 as UH1_RegexAlt).f0
                    var v46: UH1 = (v1 as UH1_RegexAlt).f1
                    return US3_SymbolLess
                }
                5 -> {
                    var v48: UH1 = (v1 as UH1_RegexStar).f0
                    return sp_regex_compare_7(v44, v48)
                }
                else -> {
                    return US3_SymbolGreater
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
            var v4: US3 = US3_SymbolLess
            v4 = sp_regex_compare_7(v0, v2)
            when (v4.tag) {
                2 -> {
                    var v6: UH1 = UH1_RegexEmpty
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
            var v11: US3 = US3_SymbolLess
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
            var v4: UH1 = UH1_RegexEmpty
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
                    var v15: US3 = US3_SymbolLess
                    when (v4.tag) {
                        1 -> {
                            when (v5.tag) {
                                1 -> {
                                    v15 = US3_SymbolSame
                                }
                                0 -> {
                                    v15 = US3_SymbolGreater
                                }
                                else -> throw RuntimeException()
                            }
                        }
                        0 -> {
                            when (v5.tag) {
                                1 -> {
                                    v15 = US3_SymbolLess
                                }
                                0 -> {
                                    v15 = US3_SymbolSame
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
            return UH1_RegexEmpty
        }
        else -> {
            when (v1.tag) {
                0 -> {
                    return UH1_RegexEmpty
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
                                            var v14: UH1 = UH1_RegexEmpty
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
            return UH1_RegexEpsilon
        }
        1 -> {
            return UH1_RegexEpsilon
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
            var v7: UH1 = UH1_RegexEmpty
            v7 = sp_normalize_4(v5)
            var v8: UH1 = UH1_RegexEmpty
            v8 = sp_normalize_4(v6)
            return sp_make_alt_5(v7, v8)
        }
        4 -> {
            var v10: UH1 = (v0 as UH1_RegexCat).f0
            var v11: UH1 = (v0 as UH1_RegexCat).f1
            var v12: UH1 = UH1_RegexEmpty
            v12 = sp_normalize_4(v10)
            var v13: UH1 = UH1_RegexEmpty
            v13 = sp_normalize_4(v11)
            return sp_make_cat_8(v12, v13)
        }
        2 -> {
            var v3: US0 = (v0 as UH1_RegexChar).f0
            return UH1_RegexChar(v3)
        }
        0 -> {
            return UH1_RegexEmpty
        }
        1 -> {
            return UH1_RegexEpsilon
        }
        5 -> {
            var v15: UH1 = (v0 as UH1_RegexStar).f0
            var v16: UH1 = UH1_RegexEmpty
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
            var v7: US4 = US4_Nullable
            v7 = sp_nullable_12(v5)
            var v8: US4 = US4_Nullable
            v8 = sp_nullable_12(v6)
            when (v7.tag) {
                0 -> {
                    return US4_Nullable
                }
                else -> {
                    when (v8.tag) {
                        0 -> {
                            return US4_Nullable
                        }
                        else -> {
                            when (v7.tag) {
                                1 -> {
                                    when (v8.tag) {
                                        1 -> {
                                            return US4_NonNullable
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
            var v18: US4 = US4_Nullable
            v18 = sp_nullable_12(v16)
            var v19: US4 = US4_Nullable
            v19 = sp_nullable_12(v17)
            when (v18.tag) {
                0 -> {
                    when (v19.tag) {
                        0 -> {
                            return US4_Nullable
                        }
                        else -> {
                            return US4_NonNullable
                        }
                    }
                }
                else -> {
                    return US4_NonNullable
                }
            }
        }
        2 -> {
            var v3: US0 = (v0 as UH1_RegexChar).f0
            return US4_NonNullable
        }
        0 -> {
            return US4_NonNullable
        }
        1 -> {
            return US4_Nullable
        }
        5 -> {
            var v25: UH1 = (v0 as UH1_RegexStar).f0
            return US4_Nullable
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
            var v21: UH1 = UH1_RegexEmpty
            v21 = sp_derivative_11(v19, v1)
            var v22: UH1 = UH1_RegexEmpty
            v22 = sp_derivative_11(v20, v1)
            return sp_make_alt_5(v21, v22)
        }
        4 -> {
            var v24: UH1 = (v0 as UH1_RegexCat).f0
            var v25: UH1 = (v0 as UH1_RegexCat).f1
            var v26: US4 = US4_Nullable
            v26 = sp_nullable_12(v24)
            when (v26.tag) {
                1 -> {
                    var v31: UH1 = UH1_RegexEmpty
                    v31 = sp_derivative_11(v24, v1)
                    return sp_make_cat_8(v31, v25)
                }
                0 -> {
                    var v27: UH1 = UH1_RegexEmpty
                    v27 = sp_derivative_11(v24, v1)
                    var v28: UH1 = UH1_RegexEmpty
                    v28 = sp_make_cat_8(v27, v25)
                    var v29: UH1 = UH1_RegexEmpty
                    v29 = sp_derivative_11(v25, v1)
                    return sp_make_alt_5(v28, v29)
                }
                else -> throw RuntimeException()
            }
        }
        2 -> {
            var v4: US0 = (v0 as UH1_RegexChar).f0
            var v14: US3 = US3_SymbolLess
            when (v4.tag) {
                1 -> {
                    when (v1.tag) {
                        1 -> {
                            v14 = US3_SymbolSame
                        }
                        0 -> {
                            v14 = US3_SymbolGreater
                        }
                        else -> throw RuntimeException()
                    }
                }
                0 -> {
                    when (v1.tag) {
                        1 -> {
                            v14 = US3_SymbolLess
                        }
                        0 -> {
                            v14 = US3_SymbolSame
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
                return UH1_RegexEpsilon
            } else {
                return UH1_RegexEmpty
            }
        }
        0 -> {
            return UH1_RegexEmpty
        }
        1 -> {
            return UH1_RegexEmpty
        }
        5 -> {
            var v35: UH1 = (v0 as UH1_RegexStar).f0
            var v36: UH1 = UH1_RegexEmpty
            v36 = sp_derivative_11(v35, v1)
            var v37: UH1 = UH1_RegexEmpty
            v37 = sp_make_star_10(v35)
            return sp_make_cat_8(v36, v37)
        }
        else -> throw RuntimeException()
    }
}
fun sp_canonical_derivative_3(p0: UH1, p1: US0): UH1 {
    var v0: UH1 = p0
    var v1: US0 = p1
    var v2: UH1 = UH1_RegexEmpty
    v2 = sp_normalize_4(v0)
    var v3: UH1 = UH1_RegexEmpty
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
            var v8: UH1 = UH1_RegexEmpty
            v8 = sp_canonical_derivative_3(v0, v6)
            return sp_accepts_2(v8, v7)
        }
        0 -> {
            var v2: UH1 = UH1_RegexEmpty
            v2 = sp_normalize_4(v0)
            var v3: US4 = US4_Nullable
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
            var v6: UH2 = UH2_InputEmpty
            v6 = UH2_InputEmpty
            var v7: UH2 = UH2_InputEmpty
            var v8: ULong = 0uL
            val spiral_tuple412 = sp_random_bit_input_1(v3, v1, v6)
            v7 = spiral_tuple412.v0
            v8 = spiral_tuple412.v1
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
            v2 = v12
            v3 = v8
            v4 = v11
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
            var v4: US0 = US0_BitZero
            v4 = US0_BitZero
            var v5: UH2 = UH2_InputEmpty
            v5 = UH2_InputCons(v4, v1)
            v0 = v3
            v1 = v5
            continue
        } else {
            return v1
        }
    }
    return UH2_InputEmpty
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
            var v5: UH2 = UH2_InputEmpty
            v5 = UH2_InputEmpty
            var v6: UH2 = UH2_InputEmpty
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
            var v10: US0 = US0_BitZero
            v10 = US0_BitOne
            var v11: UH2 = UH2_InputEmpty
            v11 = UH2_InputEmpty
            var v12: UH2 = UH2_InputEmpty
            v12 = UH2_InputCons(v10, v11)
            var v13: UH2 = UH2_InputEmpty
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
            v2 = v17
            v3 = v16
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
                    var v29: UH5 = UH5_RegexListNil
                    v29 = UH5_RegexListCons(v27, v7)
                    var v30: Boolean = false
                    v30 = sp_backtrack_stack_16(v29, v1)
                    if (v30) {
                        return true
                    } else {
                        var v31: UH5 = UH5_RegexListNil
                        v31 = UH5_RegexListCons(v28, v7)
                        return sp_backtrack_stack_16(v31, v1)
                    }
                }
                4 -> {
                    var v34: UH1 = (v6 as UH1_RegexCat).f0
                    var v35: UH1 = (v6 as UH1_RegexCat).f1
                    var v36: UH5 = UH5_RegexListNil
                    v36 = UH5_RegexListCons(v35, v7)
                    var v37: UH5 = UH5_RegexListNil
                    v37 = UH5_RegexListCons(v34, v36)
                    return sp_backtrack_stack_16(v37, v1)
                }
                2 -> {
                    var v9: US0 = (v6 as UH1_RegexChar).f0
                    when (v1.tag) {
                        1 -> {
                            var v10: US0 = (v1 as UH2_InputCons).f0
                            var v11: UH2 = (v1 as UH2_InputCons).f1
                            var v21: US3 = US3_SymbolLess
                            when (v9.tag) {
                                1 -> {
                                    when (v10.tag) {
                                        1 -> {
                                            v21 = US3_SymbolSame
                                        }
                                        0 -> {
                                            v21 = US3_SymbolGreater
                                        }
                                        else -> throw RuntimeException()
                                    }
                                }
                                0 -> {
                                    when (v10.tag) {
                                        1 -> {
                                            v21 = US3_SymbolLess
                                        }
                                        0 -> {
                                            v21 = US3_SymbolSame
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
                    var v40: UH5 = UH5_RegexListNil
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
            var v6: UH2 = UH2_InputEmpty
            v6 = UH2_InputEmpty
            var v7: UH2 = UH2_InputEmpty
            var v8: ULong = 0uL
            val spiral_tuple413 = sp_random_bit_input_1(v3, v1, v6)
            v7 = spiral_tuple413.v0
            v8 = spiral_tuple413.v1
            var v9: UH5 = UH5_RegexListNil
            v9 = UH5_RegexListNil
            var v10: UH5 = UH5_RegexListNil
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
            v2 = v14
            v3 = v8
            v4 = v13
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
            var v5: UH2 = UH2_InputEmpty
            v5 = UH2_InputEmpty
            var v6: UH2 = UH2_InputEmpty
            v6 = sp_zeros_input_14(v2, v5)
            var v7: UH5 = UH5_RegexListNil
            v7 = UH5_RegexListNil
            var v8: UH5 = UH5_RegexListNil
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
            var v12: US0 = US0_BitZero
            v12 = US0_BitOne
            var v13: UH2 = UH2_InputEmpty
            v13 = UH2_InputEmpty
            var v14: UH2 = UH2_InputEmpty
            v14 = UH2_InputCons(v12, v13)
            var v15: UH2 = UH2_InputEmpty
            v15 = sp_zeros_input_14(v2, v14)
            var v16: UH5 = UH5_RegexListNil
            v16 = UH5_RegexListNil
            var v17: UH5 = UH5_RegexListNil
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
            v2 = v21
            v3 = v20
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
            var v5: UH2 = UH2_InputEmpty
            v5 = UH2_InputEmpty
            var v6: UH2 = UH2_InputEmpty
            var v7: ULong = 0uL
            val spiral_tuple383 = sp_random_bit_input_1(v2, v0, v5)
            v6 = spiral_tuple383.v0
            v7 = spiral_tuple383.v1
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
            v1 = v12
            v2 = v7
            v3 = v11
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
            var v5: UH2 = UH2_InputEmpty
            v5 = UH2_InputEmpty
            var v6: UH2 = UH2_InputEmpty
            var v7: ULong = 0uL
            val spiral_tuple383 = sp_random_bit_input_1(v2, v0, v5)
            v6 = spiral_tuple383.v0
            v7 = spiral_tuple383.v1
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
            v1 = v12
            v2 = v7
            v3 = v11
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
            var v4: UH2 = UH2_InputEmpty
            v4 = UH2_InputEmpty
            var v5: UH2 = UH2_InputEmpty
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
            var v10: US0 = US0_BitZero
            v10 = US0_BitOne
            var v11: UH2 = UH2_InputEmpty
            v11 = UH2_InputEmpty
            var v12: UH2 = UH2_InputEmpty
            v12 = UH2_InputCons(v10, v11)
            var v13: UH2 = UH2_InputEmpty
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
            v1 = v18
            v2 = v17
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
            v1 = v3
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
            v1 = v3
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
                v10 = v47
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
                v7 = v12
                v8 = v14
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
            var v13: UH2 = UH2_InputEmpty
            v13 = UH2_InputEmpty
            var v14: UH2 = UH2_InputEmpty
            var v15: ULong = 0uL
            val spiral_tuple734 = sp_random_bit_input_1(v10, v7, v13)
            v14 = spiral_tuple734.v0
            v15 = spiral_tuple734.v1
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
            v9 = v19
            v10 = v15
            v11 = v18
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
            var v12: UH2 = UH2_InputEmpty
            v12 = UH2_InputEmpty
            var v13: UH2 = UH2_InputEmpty
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
            var v17: US0 = US0_BitZero
            v17 = US0_BitOne
            var v18: UH2 = UH2_InputEmpty
            v18 = UH2_InputEmpty
            var v19: UH2 = UH2_InputEmpty
            v19 = UH2_InputCons(v17, v18)
            var v20: UH2 = UH2_InputEmpty
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
            v9 = v24
            v10 = v23
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
    var v2: US0 = US0_BitZero
    v2 = US0_BitZero
    var v3: UH1 = UH1_RegexEmpty
    v3 = UH1_RegexChar(v2)
    var v4: US0 = US0_BitZero
    v4 = US0_BitOne
    var v5: UH1 = UH1_RegexEmpty
    v5 = UH1_RegexChar(v4)
    var v6: UH1 = UH1_RegexEmpty
    v6 = UH1_RegexAlt(v3, v5)
    var v7: UH1 = UH1_RegexEmpty
    v7 = UH1_RegexStar(v6)
    var v8: US0 = US0_BitZero
    v8 = US0_BitZero
    var v9: UH1 = UH1_RegexEmpty
    v9 = UH1_RegexChar(v8)
    var v10: UH1 = UH1_RegexEmpty
    v10 = UH1_RegexCat(v7, v9)
    var v11: US0 = US0_BitZero
    v11 = US0_BitZero
    var v12: UH1 = UH1_RegexEmpty
    v12 = UH1_RegexChar(v11)
    var v13: US0 = US0_BitZero
    v13 = US0_BitOne
    var v14: UH1 = UH1_RegexEmpty
    v14 = UH1_RegexChar(v13)
    var v15: UH1 = UH1_RegexEmpty
    v15 = UH1_RegexAlt(v12, v14)
    var v16: UH1 = UH1_RegexEmpty
    v16 = UH1_RegexStar(v15)
    var v17: US0 = US0_BitZero
    v17 = US0_BitOne
    var v18: UH1 = UH1_RegexEmpty
    v18 = UH1_RegexChar(v17)
    var v19: US0 = US0_BitZero
    v19 = US0_BitZero
    var v20: UH1 = UH1_RegexEmpty
    v20 = UH1_RegexChar(v19)
    var v21: US0 = US0_BitZero
    v21 = US0_BitOne
    var v22: UH1 = UH1_RegexEmpty
    v22 = UH1_RegexChar(v21)
    var v23: UH1 = UH1_RegexEmpty
    v23 = UH1_RegexAlt(v20, v22)
    var v24: US0 = US0_BitZero
    v24 = US0_BitZero
    var v25: UH1 = UH1_RegexEmpty
    v25 = UH1_RegexChar(v24)
    var v26: US0 = US0_BitZero
    v26 = US0_BitOne
    var v27: UH1 = UH1_RegexEmpty
    v27 = UH1_RegexChar(v26)
    var v28: UH1 = UH1_RegexEmpty
    v28 = UH1_RegexAlt(v25, v27)
    var v29: US0 = US0_BitZero
    v29 = US0_BitZero
    var v30: UH1 = UH1_RegexEmpty
    v30 = UH1_RegexChar(v29)
    var v31: US0 = US0_BitZero
    v31 = US0_BitOne
    var v32: UH1 = UH1_RegexEmpty
    v32 = UH1_RegexChar(v31)
    var v33: UH1 = UH1_RegexEmpty
    v33 = UH1_RegexAlt(v30, v32)
    var v34: UH1 = UH1_RegexEmpty
    v34 = UH1_RegexCat(v28, v33)
    var v35: UH1 = UH1_RegexEmpty
    v35 = UH1_RegexCat(v23, v34)
    var v36: UH1 = UH1_RegexEmpty
    v36 = UH1_RegexCat(v18, v35)
    var v37: UH1 = UH1_RegexEmpty
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
    var v43: US0 = US0_BitZero
    v43 = US0_BitZero
    var v44: UH1 = UH1_RegexEmpty
    v44 = UH1_RegexChar(v43)
    var v45: US0 = US0_BitZero
    v45 = US0_BitZero
    var v46: UH1 = UH1_RegexEmpty
    v46 = UH1_RegexChar(v45)
    var v47: US0 = US0_BitZero
    v47 = US0_BitZero
    var v48: UH1 = UH1_RegexEmpty
    v48 = UH1_RegexChar(v47)
    val v49: UH1 = UH1_RegexCat(v46, v48)
    var v50: UH1 = UH1_RegexEmpty
    v50 = UH1_RegexAlt(v44, v49)
    var v51: UH1 = UH1_RegexEmpty
    v51 = UH1_RegexStar(v50)
    var v52: US0 = US0_BitZero
    v52 = US0_BitOne
    var v53: UH1 = UH1_RegexEmpty
    v53 = UH1_RegexChar(v52)
    var v54: UH1 = UH1_RegexEmpty
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
    var v60: US0 = US0_BitZero
    v60 = US0_BitZero
    var v61: UH1 = UH1_RegexEmpty
    v61 = UH1_RegexChar(v60)
    var v62: US0 = US0_BitZero
    v62 = US0_BitOne
    var v63: UH1 = UH1_RegexEmpty
    v63 = UH1_RegexChar(v62)
    var v64: UH1 = UH1_RegexEmpty
    v64 = UH1_RegexAlt(v61, v63)
    val v65: UH1 = UH1_RegexStar(v64)
    val v66: US0 = US0_BitZero
    val v67: UH1 = UH1_RegexChar(v66)
    val v68: UH1 = UH1_RegexCat(v65, v67)
    val v69: US0 = US0_BitZero
    val v70: UH1 = UH1_RegexChar(v69)
    val v71: US0 = US0_BitOne
    val v72: UH1 = UH1_RegexChar(v71)
    val v73: UH1 = UH1_RegexAlt(v70, v72)
    val v74: UH1 = UH1_RegexStar(v73)
    val v75: US0 = US0_BitOne
    val v76: UH1 = UH1_RegexChar(v75)
    val v77: US0 = US0_BitZero
    val v78: UH1 = UH1_RegexChar(v77)
    var v79: US0 = US0_BitZero
    v79 = US0_BitOne
    val v80: UH1 = UH1_RegexChar(v79)
    val v81: UH1 = UH1_RegexAlt(v78, v80)
    val v82: US0 = US0_BitZero
    val v83: UH1 = UH1_RegexChar(v82)
    val v84: US0 = US0_BitOne
    val v85: UH1 = UH1_RegexChar(v84)
    val v86: UH1 = UH1_RegexAlt(v83, v85)
    val v87: US0 = US0_BitZero
    val v88: UH1 = UH1_RegexChar(v87)
    val v89: US0 = US0_BitOne
    val v90: UH1 = UH1_RegexChar(v89)
    val v91: UH1 = UH1_RegexAlt(v88, v90)
    val v92: UH1 = UH1_RegexCat(v86, v91)
    val v93: UH1 = UH1_RegexCat(v81, v92)
    val v94: UH1 = UH1_RegexCat(v76, v93)
    val v95: UH1 = UH1_RegexCat(v74, v94)
    val v96: ULong = 1uL
    val v97: Int = 0
    val v98: Int = sp_loop_15(v68, v59, v58, v96, v97)
    val v99: Int = sp_loop_15(v95, v59, v58, v96, v97)
    val v100: Int = 16
    val v101: US0 = US0_BitZero
    val v102: UH1 = UH1_RegexChar(v101)
    val v103: US0 = US0_BitZero
    val v104: UH1 = UH1_RegexChar(v103)
    val v105: US0 = US0_BitZero
    val v106: UH1 = UH1_RegexChar(v105)
    val v107: UH1 = UH1_RegexCat(v104, v106)
    val v108: UH1 = UH1_RegexAlt(v102, v107)
    val v109: UH1 = UH1_RegexStar(v108)
    val v110: US0 = US0_BitOne
    val v111: UH1 = UH1_RegexChar(v110)
    val v112: UH1 = UH1_RegexCat(v109, v111)
    val v113: Int = 0
    val v114: Int = 1
    val v115: Int = sp_loop_17(v112, v100, v114, v113)
    val v116: Boolean = (v40 == v98)
    var v118: Boolean = false
    if (v116) {
        val v117: Boolean = (v41 == v99)
        v118 = v117
    } else {
        v118 = false
    }
    var v120: Boolean = false
    if (v118) {
        val v119: Boolean = (v57 == v115)
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
    val v121: Int = 200
    val v122: Int = 32
    val v123: ULong = 1uL
    val v124: Int = 0
    val v125: Int = sp_loop_18(v122, v121, v123, v124)
    val v126: Int = sp_loop_20(v122, v121, v123, v124)
    val v127: Int = 16
    val v128: Int = 0
    val v129: Int = 1
    val v130: Int = sp_loop_22(v127, v129, v128)
    val v131: Boolean = (v40 == v125)
    var v133: Boolean = false
    if (v131) {
        val v132: Boolean = (v41 == v126)
        v133 = v132
    } else {
        v133 = false
    }
    var v135: Boolean = false
    if (v133) {
        val v134: Boolean = (v57 == v130)
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
    val v136: Int = 200
    val v137: Int = 32
    val v138: Array<Int> = Array(4096) { 0 }
    val v139: Array<Int> = Array(4096) { 0 }
    val v140: Array<Int> = Array(4096) { 0 }
    val v141: Array<Int> = Array(4096) { 0 }
    val v142: Array<Int> = Array(8192) { 0 }
    val v143: Array<Int> = Array(8192) { 0 }
    val v144: Array<Int> = Array(1) { 0 }
    val v145: Int = 0
    sp_loop_24(v142, v145)
    val v146: Int = 0
    sp_loop_24(v143, v146)
    val v147: Int = 0
    sp_loop_25(v144, v147)
    val v148: Int = 0
    val v149: Int = 0
    val v150: Int = 0
    val v151: Int = sp_interned_node_26(v138, v139, v140, v141, v142, v143, v144, v148, v149, v150)
    val v152: Int = 1
    val v153: Int = 0
    val v154: Int = 0
    val v155: Int = sp_interned_node_26(v138, v139, v140, v141, v142, v143, v144, v152, v153, v154)
    val v156: Boolean = (v151 == 0)
    var v158: Boolean = false
    if (v156) {
        val v157: Boolean = (v155 == 1)
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
    val v173: US0 = US0_BitZero
    val v174: UH1 = UH1_RegexChar(v173)
    val v175: US0 = US0_BitOne
    val v176: UH1 = UH1_RegexChar(v175)
    val v177: UH1 = UH1_RegexAlt(v174, v176)
    val v178: UH1 = UH1_RegexStar(v177)
    val v179: US0 = US0_BitZero
    val v180: UH1 = UH1_RegexChar(v179)
    val v181: UH1 = UH1_RegexCat(v178, v180)
    val v182: Int = sp_interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v181)
    val v183: ULong = 1uL
    val v184: Int = 0
    val v185: Int = sp_loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v182, v136, v183, v184)
    val v186: US0 = US0_BitZero
    val v187: UH1 = UH1_RegexChar(v186)
    val v188: US0 = US0_BitOne
    val v189: UH1 = UH1_RegexChar(v188)
    val v190: UH1 = UH1_RegexAlt(v187, v189)
    val v191: UH1 = UH1_RegexStar(v190)
    val v192: US0 = US0_BitOne
    val v193: UH1 = UH1_RegexChar(v192)
    val v194: US0 = US0_BitZero
    val v195: UH1 = UH1_RegexChar(v194)
    val v196: US0 = US0_BitOne
    val v197: UH1 = UH1_RegexChar(v196)
    val v198: UH1 = UH1_RegexAlt(v195, v197)
    val v199: US0 = US0_BitZero
    val v200: UH1 = UH1_RegexChar(v199)
    val v201: US0 = US0_BitOne
    val v202: UH1 = UH1_RegexChar(v201)
    val v203: UH1 = UH1_RegexAlt(v200, v202)
    val v204: US0 = US0_BitZero
    val v205: UH1 = UH1_RegexChar(v204)
    val v206: US0 = US0_BitOne
    val v207: UH1 = UH1_RegexChar(v206)
    val v208: UH1 = UH1_RegexAlt(v205, v207)
    val v209: UH1 = UH1_RegexCat(v203, v208)
    val v210: UH1 = UH1_RegexCat(v198, v209)
    val v211: UH1 = UH1_RegexCat(v193, v210)
    val v212: UH1 = UH1_RegexCat(v191, v211)
    val v213: Int = sp_interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v212)
    val v214: ULong = 1uL
    val v215: Int = 0
    val v216: Int = sp_loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v213, v136, v214, v215)
    val v217: Int = 16
    val v218: Array<Int> = Array(4096) { 0 }
    val v219: Array<Int> = Array(4096) { 0 }
    val v220: Array<Int> = Array(4096) { 0 }
    val v221: Array<Int> = Array(4096) { 0 }
    val v222: Array<Int> = Array(8192) { 0 }
    val v223: Array<Int> = Array(8192) { 0 }
    val v224: Array<Int> = Array(1) { 0 }
    val v225: Int = 0
    sp_loop_24(v222, v225)
    val v226: Int = 0
    sp_loop_24(v223, v226)
    val v227: Int = 0
    sp_loop_25(v224, v227)
    val v228: Int = 0
    val v229: Int = 0
    val v230: Int = 0
    val v231: Int = sp_interned_node_26(v218, v219, v220, v221, v222, v223, v224, v228, v229, v230)
    val v232: Int = 1
    val v233: Int = 0
    val v234: Int = 0
    val v235: Int = sp_interned_node_26(v218, v219, v220, v221, v222, v223, v224, v232, v233, v234)
    val v236: Boolean = (v231 == 0)
    var v238: Boolean = false
    if (v236) {
        val v237: Boolean = (v235 == 1)
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
    val v253: US0 = US0_BitZero
    val v254: UH1 = UH1_RegexChar(v253)
    val v255: US0 = US0_BitZero
    val v256: UH1 = UH1_RegexChar(v255)
    val v257: US0 = US0_BitZero
    val v258: UH1 = UH1_RegexChar(v257)
    val v259: UH1 = UH1_RegexCat(v256, v258)
    val v260: UH1 = UH1_RegexAlt(v254, v259)
    val v261: UH1 = UH1_RegexStar(v260)
    val v262: US0 = US0_BitOne
    val v263: UH1 = UH1_RegexChar(v262)
    val v264: UH1 = UH1_RegexCat(v261, v263)
    val v265: Int = sp_interned_of_regex_raw_28(v246, v247, v248, v249, v250, v251, v252, v264)
    val v266: Int = 1
    val v267: Int = 0
    val v268: Int = sp_loop_36(v246, v247, v248, v249, v250, v251, v252, v217, v265, v266, v267)
    val v269: Boolean = (v40 == v185)
    var v271: Boolean = false
    if (v269) {
        val v270: Boolean = (v41 == v216)
        v271 = v270
    } else {
        v271 = false
    }
    var v273: Boolean = false
    if (v271) {
        val v272: Boolean = (v57 == v268)
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
    val v274: Boolean = (v57 == 16)
    if (v274) {
    } else {
        System.err.println("brzozowski-bench-zero-runs-count")
        System.exit(1)
        throw RuntimeException()
    }
    val v275: Boolean = (v40 == 93)
    if (v275) {
    } else {
        System.err.println("brzozowski-bench-ends-with-zero-count")
        System.exit(1)
        throw RuntimeException()
    }
    val v276: Boolean = (v41 == 97)
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
