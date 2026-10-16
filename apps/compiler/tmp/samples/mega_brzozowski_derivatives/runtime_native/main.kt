sealed interface US0 { val tag: Int }
class US0_BitZero : US0 { override val tag: Int = 0 }
class US0_BitOne : US0 { override val tag: Int = 1 }
sealed interface UH1 { val tag: Int }
class UH1_InputEmpty : UH1 { override val tag: Int = 0 }
data class UH1_InputCons(val f0: US0, val f1: UH1) : UH1 { override val tag: Int = 1 }
sealed interface US2 { val tag: Int }
class US2_TriA : US2 { override val tag: Int = 0 }
class US2_TriB : US2 { override val tag: Int = 1 }
class US2_TriC : US2 { override val tag: Int = 2 }
sealed interface UH3 { val tag: Int }
class UH3_InputEmpty : UH3 { override val tag: Int = 0 }
data class UH3_InputCons(val f0: US2, val f1: UH3) : UH3 { override val tag: Int = 1 }
sealed interface UH4 { val tag: Int }
class UH4_RegexEmpty : UH4 { override val tag: Int = 0 }
class UH4_RegexEpsilon : UH4 { override val tag: Int = 1 }
data class UH4_RegexChar(val f0: US0) : UH4 { override val tag: Int = 2 }
data class UH4_RegexAlt(val f0: UH4, val f1: UH4) : UH4 { override val tag: Int = 3 }
data class UH4_RegexCat(val f0: UH4, val f1: UH4) : UH4 { override val tag: Int = 4 }
data class UH4_RegexStar(val f0: UH4) : UH4 { override val tag: Int = 5 }
sealed interface US5 { val tag: Int }
class US5_SymbolLess : US5 { override val tag: Int = 0 }
class US5_SymbolSame : US5 { override val tag: Int = 1 }
class US5_SymbolGreater : US5 { override val tag: Int = 2 }
sealed interface US6 { val tag: Int }
class US6_Nullable : US6 { override val tag: Int = 0 }
class US6_NonNullable : US6 { override val tag: Int = 1 }
sealed interface UH7 { val tag: Int }
class UH7_RegexEmpty : UH7 { override val tag: Int = 0 }
class UH7_RegexEpsilon : UH7 { override val tag: Int = 1 }
data class UH7_RegexChar(val f0: US2) : UH7 { override val tag: Int = 2 }
data class UH7_RegexAlt(val f0: UH7, val f1: UH7) : UH7 { override val tag: Int = 3 }
data class UH7_RegexCat(val f0: UH7, val f1: UH7) : UH7 { override val tag: Int = 4 }
data class UH7_RegexStar(val f0: UH7) : UH7 { override val tag: Int = 5 }
sealed interface US8 { val tag: Int }
data class US8_BitMatcherRaw(val f0: UH4, val f1: UH1) : US8 { override val tag: Int = 0 }
sealed interface US9 { val tag: Int }
data class US9_BitMatcherDecided(val f0: UH4, val f1: UH1, val f2: Boolean) : US9 { override val tag: Int = 1 }
fun sp_regex_compare_5(p0: UH4, p1: UH4): US5 {
    var v0: UH4 = p0
    var v1: UH4 = p1
    when (v0.tag) {
        3 -> {
            var v53: UH4 = (v0 as UH4_RegexAlt).f0
            var v54: UH4 = (v0 as UH4_RegexAlt).f1
            when (v1.tag) {
                3 -> {
                    var v55: UH4 = (v1 as UH4_RegexAlt).f0
                    var v56: UH4 = (v1 as UH4_RegexAlt).f1
                    var v57: US5 = US5_SymbolLess()
                    v57 = sp_regex_compare_5(v53, v55)
                    when (v57.tag) {
                        1 -> {
                            return sp_regex_compare_5(v54, v56)
                        }
                        else -> {
                            return v57
                        }
                    }
                }
                else -> {
                    return US5_SymbolGreater()
                }
            }
        }
        4 -> {
            var v28: UH4 = (v0 as UH4_RegexCat).f0
            var v29: UH4 = (v0 as UH4_RegexCat).f1
            when (v1.tag) {
                4 -> {
                    var v34: UH4 = (v1 as UH4_RegexCat).f0
                    var v35: UH4 = (v1 as UH4_RegexCat).f1
                    var v36: US5 = US5_SymbolLess()
                    v36 = sp_regex_compare_5(v28, v34)
                    when (v36.tag) {
                        1 -> {
                            return sp_regex_compare_5(v29, v35)
                        }
                        else -> {
                            return v36
                        }
                    }
                }
                2 -> {
                    var v32: US0 = (v1 as UH4_RegexChar).f0
                    return US5_SymbolGreater()
                }
                0 -> {
                    return US5_SymbolGreater()
                }
                1 -> {
                    return US5_SymbolGreater()
                }
                else -> {
                    return US5_SymbolLess()
                }
            }
        }
        2 -> {
            var v10: US0 = (v0 as UH4_RegexChar).f0
            when (v1.tag) {
                2 -> {
                    var v13: US0 = (v1 as UH4_RegexChar).f0
                    when (v10.tag) {
                        1 -> {
                            when (v13.tag) {
                                1 -> {
                                    return US5_SymbolSame()
                                }
                                0 -> {
                                    return US5_SymbolGreater()
                                }
                                else -> throw RuntimeException()
                            }
                        }
                        0 -> {
                            when (v13.tag) {
                                1 -> {
                                    return US5_SymbolLess()
                                }
                                0 -> {
                                    return US5_SymbolSame()
                                }
                                else -> throw RuntimeException()
                            }
                        }
                        else -> throw RuntimeException()
                    }
                }
                0 -> {
                    return US5_SymbolGreater()
                }
                1 -> {
                    return US5_SymbolGreater()
                }
                else -> {
                    return US5_SymbolLess()
                }
            }
        }
        0 -> {
            when (v1.tag) {
                0 -> {
                    return US5_SymbolSame()
                }
                else -> {
                    return US5_SymbolLess()
                }
            }
        }
        1 -> {
            when (v1.tag) {
                0 -> {
                    return US5_SymbolGreater()
                }
                1 -> {
                    return US5_SymbolSame()
                }
                else -> {
                    return US5_SymbolLess()
                }
            }
        }
        5 -> {
            var v44: UH4 = (v0 as UH4_RegexStar).f0
            when (v1.tag) {
                3 -> {
                    var v45: UH4 = (v1 as UH4_RegexAlt).f0
                    var v46: UH4 = (v1 as UH4_RegexAlt).f1
                    return US5_SymbolLess()
                }
                5 -> {
                    var v48: UH4 = (v1 as UH4_RegexStar).f0
                    return sp_regex_compare_5(v44, v48)
                }
                else -> {
                    return US5_SymbolGreater()
                }
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_alt_insert_sorted_4(p0: UH4, p1: UH4): UH4 {
    var v0: UH4 = p0
    var v1: UH4 = p1
    when (v1.tag) {
        3 -> {
            var v2: UH4 = (v1 as UH4_RegexAlt).f0
            var v3: UH4 = (v1 as UH4_RegexAlt).f1
            var v4: US5 = US5_SymbolLess()
            v4 = sp_regex_compare_5(v0, v2)
            when (v4.tag) {
                2 -> {
                    var v6: UH4 = UH4_RegexEmpty()
                    v6 = sp_alt_insert_sorted_4(v0, v3)
                    return UH4_RegexAlt(v2, v6)
                }
                0 -> {
                    return UH4_RegexAlt(v0, v1)
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
            var v11: US5 = US5_SymbolLess()
            v11 = sp_regex_compare_5(v0, v1)
            when (v11.tag) {
                2 -> {
                    return UH4_RegexAlt(v1, v0)
                }
                0 -> {
                    return UH4_RegexAlt(v0, v1)
                }
                1 -> {
                    return v1
                }
                else -> throw RuntimeException()
            }
        }
    }
}
fun sp_make_alt_3(p0: UH4, p1: UH4): UH4 {
    var v0: UH4 = p0
    var v1: UH4 = p1
    when (v0.tag) {
        3 -> {
            var v2: UH4 = (v0 as UH4_RegexAlt).f0
            var v3: UH4 = (v0 as UH4_RegexAlt).f1
            var v4: UH4 = UH4_RegexEmpty()
            v4 = sp_alt_insert_sorted_4(v2, v1)
            return sp_make_alt_3(v3, v4)
        }
        0 -> {
            return v1
        }
        else -> {
            return sp_alt_insert_sorted_4(v0, v1)
        }
    }
}
fun sp_regex_equal_7(p0: UH4, p1: UH4): Boolean {
    var v0: UH4 = p0
    var v1: UH4 = p1
    when (v0.tag) {
        3 -> {
            var v18: UH4 = (v0 as UH4_RegexAlt).f0
            var v19: UH4 = (v0 as UH4_RegexAlt).f1
            when (v1.tag) {
                3 -> {
                    var v20: UH4 = (v1 as UH4_RegexAlt).f0
                    var v21: UH4 = (v1 as UH4_RegexAlt).f1
                    var v22: Boolean = false
                    v22 = sp_regex_equal_7(v18, v20)
                    if (v22) {
                        return sp_regex_equal_7(v19, v21)
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
            var v26: UH4 = (v0 as UH4_RegexCat).f0
            var v27: UH4 = (v0 as UH4_RegexCat).f1
            when (v1.tag) {
                4 -> {
                    var v28: UH4 = (v1 as UH4_RegexCat).f0
                    var v29: UH4 = (v1 as UH4_RegexCat).f1
                    var v30: Boolean = false
                    v30 = sp_regex_equal_7(v26, v28)
                    if (v30) {
                        return sp_regex_equal_7(v27, v29)
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
            var v4: US0 = (v0 as UH4_RegexChar).f0
            when (v1.tag) {
                2 -> {
                    var v5: US0 = (v1 as UH4_RegexChar).f0
                    var v15: US5 = US5_SymbolLess()
                    when (v4.tag) {
                        1 -> {
                            when (v5.tag) {
                                1 -> {
                                    v15 = US5_SymbolSame()
                                }
                                0 -> {
                                    v15 = US5_SymbolGreater()
                                }
                                else -> throw RuntimeException()
                            }
                        }
                        0 -> {
                            when (v5.tag) {
                                1 -> {
                                    v15 = US5_SymbolLess()
                                }
                                0 -> {
                                    v15 = US5_SymbolSame()
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
            var v34: UH4 = (v0 as UH4_RegexStar).f0
            when (v1.tag) {
                5 -> {
                    var v35: UH4 = (v1 as UH4_RegexStar).f0
                    return sp_regex_equal_7(v34, v35)
                }
                else -> {
                    return false
                }
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_make_cat_6(p0: UH4, p1: UH4): UH4 {
    var v0: UH4 = p0
    var v1: UH4 = p1
    when (v0.tag) {
        0 -> {
            return UH4_RegexEmpty()
        }
        else -> {
            when (v1.tag) {
                0 -> {
                    return UH4_RegexEmpty()
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
                                            var v12: UH4 = (v0 as UH4_RegexCat).f0
                                            var v13: UH4 = (v0 as UH4_RegexCat).f1
                                            var v14: UH4 = UH4_RegexEmpty()
                                            v14 = sp_make_cat_6(v13, v1)
                                            return UH4_RegexCat(v12, v14)
                                        }
                                        5 -> {
                                            var v4: UH4 = (v0 as UH4_RegexStar).f0
                                            when (v1.tag) {
                                                5 -> {
                                                    var v5: UH4 = (v1 as UH4_RegexStar).f0
                                                    var v6: Boolean = false
                                                    v6 = sp_regex_equal_7(v4, v5)
                                                    if (v6) {
                                                        return UH4_RegexStar(v4)
                                                    } else {
                                                        return UH4_RegexCat(v0, v1)
                                                    }
                                                }
                                                else -> {
                                                    return UH4_RegexCat(v0, v1)
                                                }
                                            }
                                        }
                                        else -> {
                                            return UH4_RegexCat(v0, v1)
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
fun sp_make_star_8(p0: UH4): UH4 {
    var v0: UH4 = p0
    when (v0.tag) {
        0 -> {
            return UH4_RegexEpsilon()
        }
        1 -> {
            return UH4_RegexEpsilon()
        }
        5 -> {
            var v3: UH4 = (v0 as UH4_RegexStar).f0
            return UH4_RegexStar(v3)
        }
        else -> {
            return UH4_RegexStar(v0)
        }
    }
}
fun sp_normalize_2(p0: UH4): UH4 {
    var v0: UH4 = p0
    when (v0.tag) {
        3 -> {
            var v5: UH4 = (v0 as UH4_RegexAlt).f0
            var v6: UH4 = (v0 as UH4_RegexAlt).f1
            var v7: UH4 = UH4_RegexEmpty()
            v7 = sp_normalize_2(v5)
            var v8: UH4 = UH4_RegexEmpty()
            v8 = sp_normalize_2(v6)
            return sp_make_alt_3(v7, v8)
        }
        4 -> {
            var v10: UH4 = (v0 as UH4_RegexCat).f0
            var v11: UH4 = (v0 as UH4_RegexCat).f1
            var v12: UH4 = UH4_RegexEmpty()
            v12 = sp_normalize_2(v10)
            var v13: UH4 = UH4_RegexEmpty()
            v13 = sp_normalize_2(v11)
            return sp_make_cat_6(v12, v13)
        }
        2 -> {
            var v3: US0 = (v0 as UH4_RegexChar).f0
            return UH4_RegexChar(v3)
        }
        0 -> {
            return UH4_RegexEmpty()
        }
        1 -> {
            return UH4_RegexEpsilon()
        }
        5 -> {
            var v15: UH4 = (v0 as UH4_RegexStar).f0
            var v16: UH4 = UH4_RegexEmpty()
            v16 = sp_normalize_2(v15)
            return sp_make_star_8(v16)
        }
        else -> throw RuntimeException()
    }
}
fun sp_nullable_10(p0: UH4): US6 {
    var v0: UH4 = p0
    when (v0.tag) {
        3 -> {
            var v5: UH4 = (v0 as UH4_RegexAlt).f0
            var v6: UH4 = (v0 as UH4_RegexAlt).f1
            var v7: US6 = US6_Nullable()
            v7 = sp_nullable_10(v5)
            var v8: US6 = US6_Nullable()
            v8 = sp_nullable_10(v6)
            when (v7.tag) {
                0 -> {
                    return US6_Nullable()
                }
                else -> {
                    when (v8.tag) {
                        0 -> {
                            return US6_Nullable()
                        }
                        else -> {
                            when (v7.tag) {
                                1 -> {
                                    when (v8.tag) {
                                        1 -> {
                                            return US6_NonNullable()
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
            var v16: UH4 = (v0 as UH4_RegexCat).f0
            var v17: UH4 = (v0 as UH4_RegexCat).f1
            var v18: US6 = US6_Nullable()
            v18 = sp_nullable_10(v16)
            var v19: US6 = US6_Nullable()
            v19 = sp_nullable_10(v17)
            when (v18.tag) {
                0 -> {
                    when (v19.tag) {
                        0 -> {
                            return US6_Nullable()
                        }
                        else -> {
                            return US6_NonNullable()
                        }
                    }
                }
                else -> {
                    return US6_NonNullable()
                }
            }
        }
        2 -> {
            var v3: US0 = (v0 as UH4_RegexChar).f0
            return US6_NonNullable()
        }
        0 -> {
            return US6_NonNullable()
        }
        1 -> {
            return US6_Nullable()
        }
        5 -> {
            var v25: UH4 = (v0 as UH4_RegexStar).f0
            return US6_Nullable()
        }
        else -> throw RuntimeException()
    }
}
fun sp_derivative_9(p0: UH4, p1: US0): UH4 {
    var v0: UH4 = p0
    var v1: US0 = p1
    when (v0.tag) {
        3 -> {
            var v19: UH4 = (v0 as UH4_RegexAlt).f0
            var v20: UH4 = (v0 as UH4_RegexAlt).f1
            var v21: UH4 = UH4_RegexEmpty()
            v21 = sp_derivative_9(v19, v1)
            var v22: UH4 = UH4_RegexEmpty()
            v22 = sp_derivative_9(v20, v1)
            return sp_make_alt_3(v21, v22)
        }
        4 -> {
            var v24: UH4 = (v0 as UH4_RegexCat).f0
            var v25: UH4 = (v0 as UH4_RegexCat).f1
            var v26: US6 = US6_Nullable()
            v26 = sp_nullable_10(v24)
            when (v26.tag) {
                1 -> {
                    var v31: UH4 = UH4_RegexEmpty()
                    v31 = sp_derivative_9(v24, v1)
                    return sp_make_cat_6(v31, v25)
                }
                0 -> {
                    var v27: UH4 = UH4_RegexEmpty()
                    v27 = sp_derivative_9(v24, v1)
                    var v28: UH4 = UH4_RegexEmpty()
                    v28 = sp_make_cat_6(v27, v25)
                    var v29: UH4 = UH4_RegexEmpty()
                    v29 = sp_derivative_9(v25, v1)
                    return sp_make_alt_3(v28, v29)
                }
                else -> throw RuntimeException()
            }
        }
        2 -> {
            var v4: US0 = (v0 as UH4_RegexChar).f0
            var v14: US5 = US5_SymbolLess()
            when (v4.tag) {
                1 -> {
                    when (v1.tag) {
                        1 -> {
                            v14 = US5_SymbolSame()
                        }
                        0 -> {
                            v14 = US5_SymbolGreater()
                        }
                        else -> throw RuntimeException()
                    }
                }
                0 -> {
                    when (v1.tag) {
                        1 -> {
                            v14 = US5_SymbolLess()
                        }
                        0 -> {
                            v14 = US5_SymbolSame()
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
                return UH4_RegexEpsilon()
            } else {
                return UH4_RegexEmpty()
            }
        }
        0 -> {
            return UH4_RegexEmpty()
        }
        1 -> {
            return UH4_RegexEmpty()
        }
        5 -> {
            var v35: UH4 = (v0 as UH4_RegexStar).f0
            var v36: UH4 = UH4_RegexEmpty()
            v36 = sp_derivative_9(v35, v1)
            var v37: UH4 = UH4_RegexEmpty()
            v37 = sp_make_star_8(v35)
            return sp_make_cat_6(v36, v37)
        }
        else -> throw RuntimeException()
    }
}
fun sp_canonical_derivative_1(p0: UH4, p1: US0): UH4 {
    var v0: UH4 = p0
    var v1: US0 = p1
    var v2: UH4 = UH4_RegexEmpty()
    v2 = sp_normalize_2(v0)
    var v3: UH4 = UH4_RegexEmpty()
    v3 = sp_derivative_9(v2, v1)
    return sp_normalize_2(v3)
}
fun sp_accepts_0(p0: UH4, p1: UH1): Boolean {
    var v0: UH4 = p0
    var v1: UH1 = p1
    when (v1.tag) {
        1 -> {
            var v6: US0 = (v1 as UH1_InputCons).f0
            var v7: UH1 = (v1 as UH1_InputCons).f1
            var v8: UH4 = UH4_RegexEmpty()
            v8 = sp_canonical_derivative_1(v0, v6)
            return sp_accepts_0(v8, v7)
        }
        0 -> {
            var v2: UH4 = UH4_RegexEmpty()
            v2 = sp_normalize_2(v0)
            var v3: US6 = US6_Nullable()
            v3 = sp_nullable_10(v2)
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
fun sp_regex_compare_16(p0: UH7, p1: UH7): US5 {
    var v0: UH7 = p0
    var v1: UH7 = p1
    when (v0.tag) {
        3 -> {
            var v59: UH7 = (v0 as UH7_RegexAlt).f0
            var v60: UH7 = (v0 as UH7_RegexAlt).f1
            when (v1.tag) {
                3 -> {
                    var v61: UH7 = (v1 as UH7_RegexAlt).f0
                    var v62: UH7 = (v1 as UH7_RegexAlt).f1
                    var v63: US5 = US5_SymbolLess()
                    v63 = sp_regex_compare_16(v59, v61)
                    when (v63.tag) {
                        1 -> {
                            return sp_regex_compare_16(v60, v62)
                        }
                        else -> {
                            return v63
                        }
                    }
                }
                else -> {
                    return US5_SymbolGreater()
                }
            }
        }
        4 -> {
            var v34: UH7 = (v0 as UH7_RegexCat).f0
            var v35: UH7 = (v0 as UH7_RegexCat).f1
            when (v1.tag) {
                4 -> {
                    var v40: UH7 = (v1 as UH7_RegexCat).f0
                    var v41: UH7 = (v1 as UH7_RegexCat).f1
                    var v42: US5 = US5_SymbolLess()
                    v42 = sp_regex_compare_16(v34, v40)
                    when (v42.tag) {
                        1 -> {
                            return sp_regex_compare_16(v35, v41)
                        }
                        else -> {
                            return v42
                        }
                    }
                }
                2 -> {
                    var v38: US2 = (v1 as UH7_RegexChar).f0
                    return US5_SymbolGreater()
                }
                0 -> {
                    return US5_SymbolGreater()
                }
                1 -> {
                    return US5_SymbolGreater()
                }
                else -> {
                    return US5_SymbolLess()
                }
            }
        }
        2 -> {
            var v10: US2 = (v0 as UH7_RegexChar).f0
            when (v1.tag) {
                2 -> {
                    var v13: US2 = (v1 as UH7_RegexChar).f0
                    when (v10.tag) {
                        0 -> {
                            when (v13.tag) {
                                0 -> {
                                    return US5_SymbolSame()
                                }
                                else -> {
                                    return US5_SymbolLess()
                                }
                            }
                        }
                        else -> {
                            when (v13.tag) {
                                0 -> {
                                    return US5_SymbolGreater()
                                }
                                else -> {
                                    when (v10.tag) {
                                        1 -> {
                                            when (v13.tag) {
                                                1 -> {
                                                    return US5_SymbolSame()
                                                }
                                                2 -> {
                                                    return US5_SymbolLess()
                                                }
                                                else -> throw RuntimeException()
                                            }
                                        }
                                        2 -> {
                                            when (v13.tag) {
                                                1 -> {
                                                    return US5_SymbolGreater()
                                                }
                                                2 -> {
                                                    return US5_SymbolSame()
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
                0 -> {
                    return US5_SymbolGreater()
                }
                1 -> {
                    return US5_SymbolGreater()
                }
                else -> {
                    return US5_SymbolLess()
                }
            }
        }
        0 -> {
            when (v1.tag) {
                0 -> {
                    return US5_SymbolSame()
                }
                else -> {
                    return US5_SymbolLess()
                }
            }
        }
        1 -> {
            when (v1.tag) {
                0 -> {
                    return US5_SymbolGreater()
                }
                1 -> {
                    return US5_SymbolSame()
                }
                else -> {
                    return US5_SymbolLess()
                }
            }
        }
        5 -> {
            var v50: UH7 = (v0 as UH7_RegexStar).f0
            when (v1.tag) {
                3 -> {
                    var v51: UH7 = (v1 as UH7_RegexAlt).f0
                    var v52: UH7 = (v1 as UH7_RegexAlt).f1
                    return US5_SymbolLess()
                }
                5 -> {
                    var v54: UH7 = (v1 as UH7_RegexStar).f0
                    return sp_regex_compare_16(v50, v54)
                }
                else -> {
                    return US5_SymbolGreater()
                }
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_alt_insert_sorted_15(p0: UH7, p1: UH7): UH7 {
    var v0: UH7 = p0
    var v1: UH7 = p1
    when (v1.tag) {
        3 -> {
            var v2: UH7 = (v1 as UH7_RegexAlt).f0
            var v3: UH7 = (v1 as UH7_RegexAlt).f1
            var v4: US5 = US5_SymbolLess()
            v4 = sp_regex_compare_16(v0, v2)
            when (v4.tag) {
                2 -> {
                    var v6: UH7 = UH7_RegexEmpty()
                    v6 = sp_alt_insert_sorted_15(v0, v3)
                    return UH7_RegexAlt(v2, v6)
                }
                0 -> {
                    return UH7_RegexAlt(v0, v1)
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
            var v11: US5 = US5_SymbolLess()
            v11 = sp_regex_compare_16(v0, v1)
            when (v11.tag) {
                2 -> {
                    return UH7_RegexAlt(v1, v0)
                }
                0 -> {
                    return UH7_RegexAlt(v0, v1)
                }
                1 -> {
                    return v1
                }
                else -> throw RuntimeException()
            }
        }
    }
}
fun sp_make_alt_14(p0: UH7, p1: UH7): UH7 {
    var v0: UH7 = p0
    var v1: UH7 = p1
    when (v0.tag) {
        3 -> {
            var v2: UH7 = (v0 as UH7_RegexAlt).f0
            var v3: UH7 = (v0 as UH7_RegexAlt).f1
            var v4: UH7 = UH7_RegexEmpty()
            v4 = sp_alt_insert_sorted_15(v2, v1)
            return sp_make_alt_14(v3, v4)
        }
        0 -> {
            return v1
        }
        else -> {
            return sp_alt_insert_sorted_15(v0, v1)
        }
    }
}
fun sp_regex_equal_18(p0: UH7, p1: UH7): Boolean {
    var v0: UH7 = p0
    var v1: UH7 = p1
    when (v0.tag) {
        3 -> {
            var v24: UH7 = (v0 as UH7_RegexAlt).f0
            var v25: UH7 = (v0 as UH7_RegexAlt).f1
            when (v1.tag) {
                3 -> {
                    var v26: UH7 = (v1 as UH7_RegexAlt).f0
                    var v27: UH7 = (v1 as UH7_RegexAlt).f1
                    var v28: Boolean = false
                    v28 = sp_regex_equal_18(v24, v26)
                    if (v28) {
                        return sp_regex_equal_18(v25, v27)
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
            var v32: UH7 = (v0 as UH7_RegexCat).f0
            var v33: UH7 = (v0 as UH7_RegexCat).f1
            when (v1.tag) {
                4 -> {
                    var v34: UH7 = (v1 as UH7_RegexCat).f0
                    var v35: UH7 = (v1 as UH7_RegexCat).f1
                    var v36: Boolean = false
                    v36 = sp_regex_equal_18(v32, v34)
                    if (v36) {
                        return sp_regex_equal_18(v33, v35)
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
            var v4: US2 = (v0 as UH7_RegexChar).f0
            when (v1.tag) {
                2 -> {
                    var v5: US2 = (v1 as UH7_RegexChar).f0
                    var v21: US5 = US5_SymbolLess()
                    when (v4.tag) {
                        0 -> {
                            when (v5.tag) {
                                0 -> {
                                    v21 = US5_SymbolSame()
                                }
                                else -> {
                                    v21 = US5_SymbolLess()
                                }
                            }
                        }
                        else -> {
                            when (v5.tag) {
                                0 -> {
                                    v21 = US5_SymbolGreater()
                                }
                                else -> {
                                    when (v4.tag) {
                                        1 -> {
                                            when (v5.tag) {
                                                1 -> {
                                                    v21 = US5_SymbolSame()
                                                }
                                                2 -> {
                                                    v21 = US5_SymbolLess()
                                                }
                                                else -> throw RuntimeException()
                                            }
                                        }
                                        2 -> {
                                            when (v5.tag) {
                                                1 -> {
                                                    v21 = US5_SymbolGreater()
                                                }
                                                2 -> {
                                                    v21 = US5_SymbolSame()
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
                    when (v21.tag) {
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
            var v40: UH7 = (v0 as UH7_RegexStar).f0
            when (v1.tag) {
                5 -> {
                    var v41: UH7 = (v1 as UH7_RegexStar).f0
                    return sp_regex_equal_18(v40, v41)
                }
                else -> {
                    return false
                }
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_make_cat_17(p0: UH7, p1: UH7): UH7 {
    var v0: UH7 = p0
    var v1: UH7 = p1
    when (v0.tag) {
        0 -> {
            return UH7_RegexEmpty()
        }
        else -> {
            when (v1.tag) {
                0 -> {
                    return UH7_RegexEmpty()
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
                                            var v12: UH7 = (v0 as UH7_RegexCat).f0
                                            var v13: UH7 = (v0 as UH7_RegexCat).f1
                                            var v14: UH7 = UH7_RegexEmpty()
                                            v14 = sp_make_cat_17(v13, v1)
                                            return UH7_RegexCat(v12, v14)
                                        }
                                        5 -> {
                                            var v4: UH7 = (v0 as UH7_RegexStar).f0
                                            when (v1.tag) {
                                                5 -> {
                                                    var v5: UH7 = (v1 as UH7_RegexStar).f0
                                                    var v6: Boolean = false
                                                    v6 = sp_regex_equal_18(v4, v5)
                                                    if (v6) {
                                                        return UH7_RegexStar(v4)
                                                    } else {
                                                        return UH7_RegexCat(v0, v1)
                                                    }
                                                }
                                                else -> {
                                                    return UH7_RegexCat(v0, v1)
                                                }
                                            }
                                        }
                                        else -> {
                                            return UH7_RegexCat(v0, v1)
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
fun sp_make_star_19(p0: UH7): UH7 {
    var v0: UH7 = p0
    when (v0.tag) {
        0 -> {
            return UH7_RegexEpsilon()
        }
        1 -> {
            return UH7_RegexEpsilon()
        }
        5 -> {
            var v3: UH7 = (v0 as UH7_RegexStar).f0
            return UH7_RegexStar(v3)
        }
        else -> {
            return UH7_RegexStar(v0)
        }
    }
}
fun sp_normalize_13(p0: UH7): UH7 {
    var v0: UH7 = p0
    when (v0.tag) {
        3 -> {
            var v5: UH7 = (v0 as UH7_RegexAlt).f0
            var v6: UH7 = (v0 as UH7_RegexAlt).f1
            var v7: UH7 = UH7_RegexEmpty()
            v7 = sp_normalize_13(v5)
            var v8: UH7 = UH7_RegexEmpty()
            v8 = sp_normalize_13(v6)
            return sp_make_alt_14(v7, v8)
        }
        4 -> {
            var v10: UH7 = (v0 as UH7_RegexCat).f0
            var v11: UH7 = (v0 as UH7_RegexCat).f1
            var v12: UH7 = UH7_RegexEmpty()
            v12 = sp_normalize_13(v10)
            var v13: UH7 = UH7_RegexEmpty()
            v13 = sp_normalize_13(v11)
            return sp_make_cat_17(v12, v13)
        }
        2 -> {
            var v3: US2 = (v0 as UH7_RegexChar).f0
            return UH7_RegexChar(v3)
        }
        0 -> {
            return UH7_RegexEmpty()
        }
        1 -> {
            return UH7_RegexEpsilon()
        }
        5 -> {
            var v15: UH7 = (v0 as UH7_RegexStar).f0
            var v16: UH7 = UH7_RegexEmpty()
            v16 = sp_normalize_13(v15)
            return sp_make_star_19(v16)
        }
        else -> throw RuntimeException()
    }
}
fun sp_nullable_21(p0: UH7): US6 {
    var v0: UH7 = p0
    when (v0.tag) {
        3 -> {
            var v5: UH7 = (v0 as UH7_RegexAlt).f0
            var v6: UH7 = (v0 as UH7_RegexAlt).f1
            var v7: US6 = US6_Nullable()
            v7 = sp_nullable_21(v5)
            var v8: US6 = US6_Nullable()
            v8 = sp_nullable_21(v6)
            when (v7.tag) {
                0 -> {
                    return US6_Nullable()
                }
                else -> {
                    when (v8.tag) {
                        0 -> {
                            return US6_Nullable()
                        }
                        else -> {
                            when (v7.tag) {
                                1 -> {
                                    when (v8.tag) {
                                        1 -> {
                                            return US6_NonNullable()
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
            var v16: UH7 = (v0 as UH7_RegexCat).f0
            var v17: UH7 = (v0 as UH7_RegexCat).f1
            var v18: US6 = US6_Nullable()
            v18 = sp_nullable_21(v16)
            var v19: US6 = US6_Nullable()
            v19 = sp_nullable_21(v17)
            when (v18.tag) {
                0 -> {
                    when (v19.tag) {
                        0 -> {
                            return US6_Nullable()
                        }
                        else -> {
                            return US6_NonNullable()
                        }
                    }
                }
                else -> {
                    return US6_NonNullable()
                }
            }
        }
        2 -> {
            var v3: US2 = (v0 as UH7_RegexChar).f0
            return US6_NonNullable()
        }
        0 -> {
            return US6_NonNullable()
        }
        1 -> {
            return US6_Nullable()
        }
        5 -> {
            var v25: UH7 = (v0 as UH7_RegexStar).f0
            return US6_Nullable()
        }
        else -> throw RuntimeException()
    }
}
fun sp_derivative_20(p0: UH7, p1: US2): UH7 {
    var v0: UH7 = p0
    var v1: US2 = p1
    when (v0.tag) {
        3 -> {
            var v25: UH7 = (v0 as UH7_RegexAlt).f0
            var v26: UH7 = (v0 as UH7_RegexAlt).f1
            var v27: UH7 = UH7_RegexEmpty()
            v27 = sp_derivative_20(v25, v1)
            var v28: UH7 = UH7_RegexEmpty()
            v28 = sp_derivative_20(v26, v1)
            return sp_make_alt_14(v27, v28)
        }
        4 -> {
            var v30: UH7 = (v0 as UH7_RegexCat).f0
            var v31: UH7 = (v0 as UH7_RegexCat).f1
            var v32: US6 = US6_Nullable()
            v32 = sp_nullable_21(v30)
            when (v32.tag) {
                1 -> {
                    var v37: UH7 = UH7_RegexEmpty()
                    v37 = sp_derivative_20(v30, v1)
                    return sp_make_cat_17(v37, v31)
                }
                0 -> {
                    var v33: UH7 = UH7_RegexEmpty()
                    v33 = sp_derivative_20(v30, v1)
                    var v34: UH7 = UH7_RegexEmpty()
                    v34 = sp_make_cat_17(v33, v31)
                    var v35: UH7 = UH7_RegexEmpty()
                    v35 = sp_derivative_20(v31, v1)
                    return sp_make_alt_14(v34, v35)
                }
                else -> throw RuntimeException()
            }
        }
        2 -> {
            var v4: US2 = (v0 as UH7_RegexChar).f0
            var v20: US5 = US5_SymbolLess()
            when (v4.tag) {
                0 -> {
                    when (v1.tag) {
                        0 -> {
                            v20 = US5_SymbolSame()
                        }
                        else -> {
                            v20 = US5_SymbolLess()
                        }
                    }
                }
                else -> {
                    when (v1.tag) {
                        0 -> {
                            v20 = US5_SymbolGreater()
                        }
                        else -> {
                            when (v4.tag) {
                                1 -> {
                                    when (v1.tag) {
                                        1 -> {
                                            v20 = US5_SymbolSame()
                                        }
                                        2 -> {
                                            v20 = US5_SymbolLess()
                                        }
                                        else -> throw RuntimeException()
                                    }
                                }
                                2 -> {
                                    when (v1.tag) {
                                        1 -> {
                                            v20 = US5_SymbolGreater()
                                        }
                                        2 -> {
                                            v20 = US5_SymbolSame()
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
            var v21: Boolean = false
            when (v20.tag) {
                1 -> {
                    v21 = true
                }
                else -> {
                    v21 = false
                }
            }
            if (v21) {
                return UH7_RegexEpsilon()
            } else {
                return UH7_RegexEmpty()
            }
        }
        0 -> {
            return UH7_RegexEmpty()
        }
        1 -> {
            return UH7_RegexEmpty()
        }
        5 -> {
            var v41: UH7 = (v0 as UH7_RegexStar).f0
            var v42: UH7 = UH7_RegexEmpty()
            v42 = sp_derivative_20(v41, v1)
            var v43: UH7 = UH7_RegexEmpty()
            v43 = sp_make_star_19(v41)
            return sp_make_cat_17(v42, v43)
        }
        else -> throw RuntimeException()
    }
}
fun sp_canonical_derivative_12(p0: UH7, p1: US2): UH7 {
    var v0: UH7 = p0
    var v1: US2 = p1
    var v2: UH7 = UH7_RegexEmpty()
    v2 = sp_normalize_13(v0)
    var v3: UH7 = UH7_RegexEmpty()
    v3 = sp_derivative_20(v2, v1)
    return sp_normalize_13(v3)
}
fun sp_accepts_11(p0: UH7, p1: UH3): Boolean {
    var v0: UH7 = p0
    var v1: UH3 = p1
    when (v1.tag) {
        1 -> {
            var v6: US2 = (v1 as UH3_InputCons).f0
            var v7: UH3 = (v1 as UH3_InputCons).f1
            var v8: UH7 = UH7_RegexEmpty()
            v8 = sp_canonical_derivative_12(v0, v6)
            return sp_accepts_11(v8, v7)
        }
        0 -> {
            var v2: UH7 = UH7_RegexEmpty()
            v2 = sp_normalize_13(v0)
            var v3: US6 = US6_Nullable()
            v3 = sp_nullable_21(v2)
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
fun sp_decide_bit_match_22(p0: US8): US9 {
    var v0: US8 = p0
    when (v0.tag) {
        0 -> {
            var v1: UH4 = (v0 as US8_BitMatcherRaw).f0
            var v2: UH1 = (v0 as US8_BitMatcherRaw).f1
            var v3: Boolean = false
            v3 = sp_accepts_0(v1, v2)
            return US9_BitMatcherDecided(v1, v2, v3)
        }
        else -> throw RuntimeException()
    }
}
fun sp_bit_match_value_23(p0: US9): Boolean {
    var v0: US9 = p0
    when (v0.tag) {
        1 -> {
            var v1: UH4 = (v0 as US9_BitMatcherDecided).f0
            var v2: UH1 = (v0 as US9_BitMatcherDecided).f1
            var v3: Boolean = (v0 as US9_BitMatcherDecided).f2
            return v3
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: US0 = US0_BitZero()
    v0 = US0_BitOne()
    var v1: US0 = US0_BitZero()
    v1 = US0_BitOne()
    var v2: US0 = US0_BitZero()
    v2 = US0_BitZero()
    var v3: UH1 = UH1_InputEmpty()
    v3 = UH1_InputEmpty()
    var v4: UH1 = UH1_InputEmpty()
    v4 = UH1_InputCons(v2, v3)
    var v5: UH1 = UH1_InputEmpty()
    v5 = UH1_InputCons(v1, v4)
    var v6: UH1 = UH1_InputEmpty()
    v6 = UH1_InputCons(v0, v5)
    var v7: US0 = US0_BitZero()
    v7 = US0_BitOne()
    var v8: US0 = US0_BitZero()
    v8 = US0_BitOne()
    var v9: US0 = US0_BitZero()
    v9 = US0_BitOne()
    var v10: UH1 = UH1_InputEmpty()
    v10 = UH1_InputEmpty()
    var v11: UH1 = UH1_InputEmpty()
    v11 = UH1_InputCons(v9, v10)
    var v12: UH1 = UH1_InputEmpty()
    v12 = UH1_InputCons(v8, v11)
    var v13: UH1 = UH1_InputEmpty()
    v13 = UH1_InputCons(v7, v12)
    var v14: US2 = US2_TriA()
    v14 = US2_TriA()
    var v15: US2 = US2_TriA()
    v15 = US2_TriA()
    var v16: US2 = US2_TriA()
    v16 = US2_TriA()
    var v17: UH3 = UH3_InputEmpty()
    v17 = UH3_InputEmpty()
    var v18: UH3 = UH3_InputEmpty()
    v18 = UH3_InputCons(v16, v17)
    var v19: UH3 = UH3_InputEmpty()
    v19 = UH3_InputCons(v15, v18)
    var v20: UH3 = UH3_InputEmpty()
    v20 = UH3_InputCons(v14, v19)
    var v21: US2 = US2_TriA()
    v21 = US2_TriA()
    var v22: US2 = US2_TriA()
    v22 = US2_TriA()
    var v23: US2 = US2_TriA()
    v23 = US2_TriB()
    var v24: UH3 = UH3_InputEmpty()
    v24 = UH3_InputEmpty()
    var v25: UH3 = UH3_InputEmpty()
    v25 = UH3_InputCons(v23, v24)
    var v26: UH3 = UH3_InputEmpty()
    v26 = UH3_InputCons(v22, v25)
    var v27: UH3 = UH3_InputEmpty()
    v27 = UH3_InputCons(v21, v26)
    var v28: US0 = US0_BitZero()
    v28 = US0_BitZero()
    var v29: UH4 = UH4_RegexEmpty()
    v29 = UH4_RegexChar(v28)
    var v30: US0 = US0_BitZero()
    v30 = US0_BitOne()
    var v31: UH4 = UH4_RegexEmpty()
    v31 = UH4_RegexChar(v30)
    var v32: UH4 = UH4_RegexEmpty()
    v32 = UH4_RegexAlt(v29, v31)
    var v33: UH4 = UH4_RegexEmpty()
    v33 = UH4_RegexStar(v32)
    var v34: US0 = US0_BitZero()
    v34 = US0_BitZero()
    var v35: UH4 = UH4_RegexEmpty()
    v35 = UH4_RegexChar(v34)
    var v36: UH4 = UH4_RegexEmpty()
    v36 = UH4_RegexCat(v33, v35)
    var v37: Boolean = false
    v37 = sp_accepts_0(v36, v6)
    if (v37) {
    } else {
        System.err.println("brzozowski-expected-true")
        System.exit(1)
        throw RuntimeException()
    }
    var v38: US0 = US0_BitZero()
    v38 = US0_BitZero()
    var v39: UH4 = UH4_RegexEmpty()
    v39 = UH4_RegexChar(v38)
    var v40: US0 = US0_BitZero()
    v40 = US0_BitOne()
    var v41: UH4 = UH4_RegexEmpty()
    v41 = UH4_RegexChar(v40)
    var v42: UH4 = UH4_RegexEmpty()
    v42 = UH4_RegexAlt(v39, v41)
    var v43: UH4 = UH4_RegexEmpty()
    v43 = UH4_RegexStar(v42)
    var v44: US0 = US0_BitZero()
    v44 = US0_BitZero()
    var v45: UH4 = UH4_RegexEmpty()
    v45 = UH4_RegexChar(v44)
    var v46: UH4 = UH4_RegexEmpty()
    v46 = UH4_RegexCat(v43, v45)
    var v47: Boolean = false
    v47 = sp_accepts_0(v46, v13)
    if (v47) {
        System.err.println("brzozowski-expected-false")
        System.exit(1)
        throw RuntimeException()
    } else {
    }
    var v48: US2 = US2_TriA()
    v48 = US2_TriA()
    var v49: UH7 = UH7_RegexEmpty()
    v49 = UH7_RegexChar(v48)
    var v50: UH7 = UH7_RegexEmpty()
    v50 = UH7_RegexStar(v49)
    var v51: Boolean = false
    v51 = sp_accepts_11(v50, v20)
    if (v51) {
    } else {
        System.err.println("brzozowski-expected-true")
        System.exit(1)
        throw RuntimeException()
    }
    var v52: US2 = US2_TriA()
    v52 = US2_TriA()
    var v53: UH7 = UH7_RegexEmpty()
    v53 = UH7_RegexChar(v52)
    var v54: UH7 = UH7_RegexEmpty()
    v54 = UH7_RegexStar(v53)
    var v55: Boolean = false
    v55 = sp_accepts_11(v54, v27)
    if (v55) {
        System.err.println("brzozowski-expected-false")
        System.exit(1)
        throw RuntimeException()
    } else {
    }
    var v56: US0 = US0_BitZero()
    v56 = US0_BitZero()
    var v57: UH4 = UH4_RegexEmpty()
    v57 = UH4_RegexChar(v56)
    var v58: US0 = US0_BitZero()
    v58 = US0_BitOne()
    var v59: UH4 = UH4_RegexEmpty()
    v59 = UH4_RegexChar(v58)
    var v60: UH4 = UH4_RegexEmpty()
    v60 = UH4_RegexAlt(v57, v59)
    var v61: UH4 = UH4_RegexEmpty()
    v61 = UH4_RegexStar(v60)
    var v62: US0 = US0_BitZero()
    v62 = US0_BitZero()
    var v63: UH4 = UH4_RegexEmpty()
    v63 = UH4_RegexChar(v62)
    var v64: UH4 = UH4_RegexEmpty()
    v64 = UH4_RegexCat(v61, v63)
    var v65: US8 = US8_BitMatcherRaw(UH4_RegexEmpty(), UH1_InputEmpty())
    v65 = US8_BitMatcherRaw(v64, v6)
    var v66: US9 = US9_BitMatcherDecided(UH4_RegexEmpty(), UH1_InputEmpty(), false)
    v66 = sp_decide_bit_match_22(v65)
    var v67: US0 = US0_BitZero()
    v67 = US0_BitZero()
    var v68: UH4 = UH4_RegexEmpty()
    v68 = UH4_RegexChar(v67)
    var v69: US0 = US0_BitZero()
    v69 = US0_BitOne()
    var v70: UH4 = UH4_RegexEmpty()
    v70 = UH4_RegexChar(v69)
    var v71: UH4 = UH4_RegexEmpty()
    v71 = UH4_RegexAlt(v68, v70)
    var v72: UH4 = UH4_RegexEmpty()
    v72 = UH4_RegexStar(v71)
    var v73: US0 = US0_BitZero()
    v73 = US0_BitZero()
    var v74: UH4 = UH4_RegexEmpty()
    v74 = UH4_RegexChar(v73)
    var v75: UH4 = UH4_RegexEmpty()
    v75 = UH4_RegexCat(v72, v74)
    var v76: US8 = US8_BitMatcherRaw(UH4_RegexEmpty(), UH1_InputEmpty())
    v76 = US8_BitMatcherRaw(v75, v13)
    var v77: US9 = US9_BitMatcherDecided(UH4_RegexEmpty(), UH1_InputEmpty(), false)
    v77 = sp_decide_bit_match_22(v76)
    var v78: Boolean = false
    v78 = sp_bit_match_value_23(v66)
    if (v78) {
    } else {
        System.err.println("brzozowski-expected-true")
        System.exit(1)
        throw RuntimeException()
    }
    var v79: Boolean = false
    v79 = sp_bit_match_value_23(v77)
    if (v79) {
        System.err.println("brzozowski-expected-false")
        System.exit(1)
        throw RuntimeException()
    } else {
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
