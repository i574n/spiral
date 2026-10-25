sealed interface US0 { val tag: Int }
class US0_BitZero : US0 { override val tag: Int = 0 }
class US0_BitOne : US0 { override val tag: Int = 1 }
sealed interface UH1 { val tag: Int }
class UH1_SymbolListNil : UH1 { override val tag: Int = 0 }
data class UH1_SymbolListCons(val f0: US0, val f1: UH1) : UH1 { override val tag: Int = 1 }
sealed interface UH3 { val tag: Int }
class UH3_InputEmpty : UH3 { override val tag: Int = 0 }
data class UH3_InputCons(val f0: US0, val f1: UH3) : UH3 { override val tag: Int = 1 }
sealed interface UH2 { val tag: Int }
class UH2_InputListNil : UH2 { override val tag: Int = 0 }
data class UH2_InputListCons(val f0: UH3, val f1: UH2) : UH2 { override val tag: Int = 1 }
sealed interface US4 { val tag: Int }
class US4_TriA : US4 { override val tag: Int = 0 }
class US4_TriB : US4 { override val tag: Int = 1 }
class US4_TriC : US4 { override val tag: Int = 2 }
sealed interface UH5 { val tag: Int }
class UH5_SymbolListNil : UH5 { override val tag: Int = 0 }
data class UH5_SymbolListCons(val f0: US4, val f1: UH5) : UH5 { override val tag: Int = 1 }
sealed interface UH7 { val tag: Int }
class UH7_InputEmpty : UH7 { override val tag: Int = 0 }
data class UH7_InputCons(val f0: US4, val f1: UH7) : UH7 { override val tag: Int = 1 }
sealed interface UH6 { val tag: Int }
class UH6_InputListNil : UH6 { override val tag: Int = 0 }
data class UH6_InputListCons(val f0: UH7, val f1: UH6) : UH6 { override val tag: Int = 1 }
sealed interface US8 { val tag: Int }
class US8_ModelA : US8 { override val tag: Int = 0 }
class US8_ModelB : US8 { override val tag: Int = 1 }
class US8_ModelC : US8 { override val tag: Int = 2 }
sealed interface UH9 { val tag: Int }
class UH9_InputEmpty : UH9 { override val tag: Int = 0 }
data class UH9_InputCons(val f0: US8, val f1: UH9) : UH9 { override val tag: Int = 1 }
sealed interface UH10 { val tag: Int }
class UH10_RegexEmpty : UH10 { override val tag: Int = 0 }
class UH10_RegexEpsilon : UH10 { override val tag: Int = 1 }
data class UH10_RegexChar(val f0: US0) : UH10 { override val tag: Int = 2 }
data class UH10_RegexAlt(val f0: UH10, val f1: UH10) : UH10 { override val tag: Int = 3 }
data class UH10_RegexCat(val f0: UH10, val f1: UH10) : UH10 { override val tag: Int = 4 }
data class UH10_RegexStar(val f0: UH10) : UH10 { override val tag: Int = 5 }
sealed interface US11 { val tag: Int }
class US11_InventoryDfaAccepted : US11 { override val tag: Int = 0 }
class US11_InventoryDfaRejected : US11 { override val tag: Int = 1 }
class US11_InventoryDfaInputOutsideInventory : US11 { override val tag: Int = 2 }
sealed interface US12 { val tag: Int }
class US12_SymbolLess : US12 { override val tag: Int = 0 }
class US12_SymbolSame : US12 { override val tag: Int = 1 }
class US12_SymbolGreater : US12 { override val tag: Int = 2 }
sealed interface US13 { val tag: Int }
class US13_Nullable : US13 { override val tag: Int = 0 }
class US13_NonNullable : US13 { override val tag: Int = 1 }
sealed interface UH14 { val tag: Int }
class UH14_RegexEmpty : UH14 { override val tag: Int = 0 }
class UH14_RegexEpsilon : UH14 { override val tag: Int = 1 }
data class UH14_RegexChar(val f0: US4) : UH14 { override val tag: Int = 2 }
data class UH14_RegexAlt(val f0: UH14, val f1: UH14) : UH14 { override val tag: Int = 3 }
data class UH14_RegexCat(val f0: UH14, val f1: UH14) : UH14 { override val tag: Int = 4 }
data class UH14_RegexStar(val f0: UH14) : UH14 { override val tag: Int = 5 }
fun sp_input_singletons_from_symbols_0(p0: UH1): UH2 {
    var v0: UH1 = p0
    when (v0.tag) {
        1 -> {
            var v2: US0 = (v0 as UH1_SymbolListCons).f0
            var v3: UH1 = (v0 as UH1_SymbolListCons).f1
            var v4: UH2 = UH2_InputListNil()
            v4 = sp_input_singletons_from_symbols_0(v3)
            var v5: UH3 = UH3_InputEmpty()
            v5 = UH3_InputEmpty()
            var v6: UH3 = UH3_InputEmpty()
            v6 = UH3_InputCons(v2, v5)
            return UH2_InputListCons(v6, v4)
        }
        0 -> {
            return UH2_InputListNil()
        }
        else -> throw RuntimeException()
    }
}
fun sp_input_prepend_symbol_to_corpus_2(p0: US0, p1: UH2): UH2 {
    var v0: US0 = p0
    var v1: UH2 = p1
    when (v1.tag) {
        1 -> {
            var v3: UH3 = (v1 as UH2_InputListCons).f0
            var v4: UH2 = (v1 as UH2_InputListCons).f1
            var v5: UH2 = UH2_InputListNil()
            v5 = sp_input_prepend_symbol_to_corpus_2(v0, v4)
            var v6: UH3 = UH3_InputEmpty()
            v6 = UH3_InputCons(v0, v3)
            return UH2_InputListCons(v6, v5)
        }
        0 -> {
            return UH2_InputListNil()
        }
        else -> throw RuntimeException()
    }
}
fun sp_input_list_append_3(p0: UH2, p1: UH2): UH2 {
    var v0: UH2 = p0
    var v1: UH2 = p1
    when (v0.tag) {
        1 -> {
            var v2: UH3 = (v0 as UH2_InputListCons).f0
            var v3: UH2 = (v0 as UH2_InputListCons).f1
            var v4: UH2 = UH2_InputListNil()
            v4 = sp_input_list_append_3(v3, v1)
            return UH2_InputListCons(v2, v4)
        }
        0 -> {
            return v1
        }
        else -> throw RuntimeException()
    }
}
fun sp_input_prepend_symbols_to_corpus_1(p0: UH1, p1: UH2): UH2 {
    var v0: UH1 = p0
    var v1: UH2 = p1
    when (v0.tag) {
        1 -> {
            var v3: US0 = (v0 as UH1_SymbolListCons).f0
            var v4: UH1 = (v0 as UH1_SymbolListCons).f1
            var v5: UH2 = UH2_InputListNil()
            v5 = sp_input_prepend_symbol_to_corpus_2(v3, v1)
            var v6: UH2 = UH2_InputListNil()
            v6 = sp_input_prepend_symbols_to_corpus_1(v4, v1)
            return sp_input_list_append_3(v5, v6)
        }
        0 -> {
            return UH2_InputListNil()
        }
        else -> throw RuntimeException()
    }
}
fun sp_input_singletons_from_symbols_4(p0: UH5): UH6 {
    var v0: UH5 = p0
    when (v0.tag) {
        1 -> {
            var v2: US4 = (v0 as UH5_SymbolListCons).f0
            var v3: UH5 = (v0 as UH5_SymbolListCons).f1
            var v4: UH6 = UH6_InputListNil()
            v4 = sp_input_singletons_from_symbols_4(v3)
            var v5: UH7 = UH7_InputEmpty()
            v5 = UH7_InputEmpty()
            var v6: UH7 = UH7_InputEmpty()
            v6 = UH7_InputCons(v2, v5)
            return UH6_InputListCons(v6, v4)
        }
        0 -> {
            return UH6_InputListNil()
        }
        else -> throw RuntimeException()
    }
}
fun sp_input_prepend_symbol_to_corpus_6(p0: US4, p1: UH6): UH6 {
    var v0: US4 = p0
    var v1: UH6 = p1
    when (v1.tag) {
        1 -> {
            var v3: UH7 = (v1 as UH6_InputListCons).f0
            var v4: UH6 = (v1 as UH6_InputListCons).f1
            var v5: UH6 = UH6_InputListNil()
            v5 = sp_input_prepend_symbol_to_corpus_6(v0, v4)
            var v6: UH7 = UH7_InputEmpty()
            v6 = UH7_InputCons(v0, v3)
            return UH6_InputListCons(v6, v5)
        }
        0 -> {
            return UH6_InputListNil()
        }
        else -> throw RuntimeException()
    }
}
fun sp_input_list_append_7(p0: UH6, p1: UH6): UH6 {
    var v0: UH6 = p0
    var v1: UH6 = p1
    when (v0.tag) {
        1 -> {
            var v2: UH7 = (v0 as UH6_InputListCons).f0
            var v3: UH6 = (v0 as UH6_InputListCons).f1
            var v4: UH6 = UH6_InputListNil()
            v4 = sp_input_list_append_7(v3, v1)
            return UH6_InputListCons(v2, v4)
        }
        0 -> {
            return v1
        }
        else -> throw RuntimeException()
    }
}
fun sp_input_prepend_symbols_to_corpus_5(p0: UH5, p1: UH6): UH6 {
    var v0: UH5 = p0
    var v1: UH6 = p1
    when (v0.tag) {
        1 -> {
            var v3: US4 = (v0 as UH5_SymbolListCons).f0
            var v4: UH5 = (v0 as UH5_SymbolListCons).f1
            var v5: UH6 = UH6_InputListNil()
            v5 = sp_input_prepend_symbol_to_corpus_6(v3, v1)
            var v6: UH6 = UH6_InputListNil()
            v6 = sp_input_prepend_symbols_to_corpus_5(v4, v1)
            return sp_input_list_append_7(v5, v6)
        }
        0 -> {
            return UH6_InputListNil()
        }
        else -> throw RuntimeException()
    }
}
fun sp_loop_9(p0: Int, p1: UH3): US11 {
    var v0: Int = p0
    var v1: UH3 = p1
    when (v1.tag) {
        1 -> {
            var v6: US0 = (v1 as UH3_InputCons).f0
            var v7: UH3 = (v1 as UH3_InputCons).f1
            var v11: US12 = US12_SymbolLess()
            when (v6.tag) {
                1 -> {
                    v11 = US12_SymbolGreater()
                }
                0 -> {
                    v11 = US12_SymbolSame()
                }
                else -> throw RuntimeException()
            }
            var v12: Boolean = false
            when (v11.tag) {
                1 -> {
                    v12 = true
                }
                else -> {
                    v12 = false
                }
            }
            var v19: Int = 0
            if (v12) {
                v19 = 0
            } else {
                var v16: US12 = US12_SymbolLess()
                when (v6.tag) {
                    1 -> {
                        v16 = US12_SymbolSame()
                    }
                    0 -> {
                        v16 = US12_SymbolLess()
                    }
                    else -> throw RuntimeException()
                }
                var v17: Boolean = false
                when (v16.tag) {
                    1 -> {
                        v17 = true
                    }
                    else -> {
                        v17 = false
                    }
                }
                if (v17) {
                    v19 = 1
                } else {
                    v19 = -1
                }
            }
            var v20: Boolean = false
            v20 = (v19 < 0)
            if (v20) {
                return US11_InventoryDfaInputOutsideInventory()
            } else {
                var v22: Boolean = false
                v22 = (v0 == 0)
                var v27: Int = 0
                if (v22) {
                    var v23: Boolean = false
                    v23 = (v19 == 0)
                    if (v23) {
                        v27 = 0
                    } else {
                        v27 = 1
                    }
                } else {
                    var v25: Boolean = false
                    v25 = (v19 == 0)
                    if (v25) {
                        v27 = 0
                    } else {
                        v27 = 1
                    }
                }
                return sp_loop_9(v27, v7)
            }
        }
        0 -> {
            var v2: Boolean = false
            v2 = (v0 == 0)
            if (v2) {
                return US11_InventoryDfaAccepted()
            } else {
                return US11_InventoryDfaRejected()
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_regex_compare_15(p0: UH10, p1: UH10): US12 {
    var v0: UH10 = p0
    var v1: UH10 = p1
    when (v0.tag) {
        3 -> {
            var v53: UH10 = (v0 as UH10_RegexAlt).f0
            var v54: UH10 = (v0 as UH10_RegexAlt).f1
            when (v1.tag) {
                3 -> {
                    var v55: UH10 = (v1 as UH10_RegexAlt).f0
                    var v56: UH10 = (v1 as UH10_RegexAlt).f1
                    var v57: US12 = US12_SymbolLess()
                    v57 = sp_regex_compare_15(v53, v55)
                    when (v57.tag) {
                        1 -> {
                            return sp_regex_compare_15(v54, v56)
                        }
                        else -> {
                            return v57
                        }
                    }
                }
                else -> {
                    return US12_SymbolGreater()
                }
            }
        }
        4 -> {
            var v28: UH10 = (v0 as UH10_RegexCat).f0
            var v29: UH10 = (v0 as UH10_RegexCat).f1
            when (v1.tag) {
                4 -> {
                    var v34: UH10 = (v1 as UH10_RegexCat).f0
                    var v35: UH10 = (v1 as UH10_RegexCat).f1
                    var v36: US12 = US12_SymbolLess()
                    v36 = sp_regex_compare_15(v28, v34)
                    when (v36.tag) {
                        1 -> {
                            return sp_regex_compare_15(v29, v35)
                        }
                        else -> {
                            return v36
                        }
                    }
                }
                2 -> {
                    var v32: US0 = (v1 as UH10_RegexChar).f0
                    return US12_SymbolGreater()
                }
                0 -> {
                    return US12_SymbolGreater()
                }
                1 -> {
                    return US12_SymbolGreater()
                }
                else -> {
                    return US12_SymbolLess()
                }
            }
        }
        2 -> {
            var v10: US0 = (v0 as UH10_RegexChar).f0
            when (v1.tag) {
                2 -> {
                    var v13: US0 = (v1 as UH10_RegexChar).f0
                    when (v10.tag) {
                        1 -> {
                            when (v13.tag) {
                                1 -> {
                                    return US12_SymbolSame()
                                }
                                0 -> {
                                    return US12_SymbolGreater()
                                }
                                else -> throw RuntimeException()
                            }
                        }
                        0 -> {
                            when (v13.tag) {
                                1 -> {
                                    return US12_SymbolLess()
                                }
                                0 -> {
                                    return US12_SymbolSame()
                                }
                                else -> throw RuntimeException()
                            }
                        }
                        else -> throw RuntimeException()
                    }
                }
                0 -> {
                    return US12_SymbolGreater()
                }
                1 -> {
                    return US12_SymbolGreater()
                }
                else -> {
                    return US12_SymbolLess()
                }
            }
        }
        0 -> {
            when (v1.tag) {
                0 -> {
                    return US12_SymbolSame()
                }
                else -> {
                    return US12_SymbolLess()
                }
            }
        }
        1 -> {
            when (v1.tag) {
                0 -> {
                    return US12_SymbolGreater()
                }
                1 -> {
                    return US12_SymbolSame()
                }
                else -> {
                    return US12_SymbolLess()
                }
            }
        }
        5 -> {
            var v44: UH10 = (v0 as UH10_RegexStar).f0
            when (v1.tag) {
                3 -> {
                    var v45: UH10 = (v1 as UH10_RegexAlt).f0
                    var v46: UH10 = (v1 as UH10_RegexAlt).f1
                    return US12_SymbolLess()
                }
                5 -> {
                    var v48: UH10 = (v1 as UH10_RegexStar).f0
                    return sp_regex_compare_15(v44, v48)
                }
                else -> {
                    return US12_SymbolGreater()
                }
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_alt_insert_sorted_14(p0: UH10, p1: UH10): UH10 {
    var v0: UH10 = p0
    var v1: UH10 = p1
    when (v1.tag) {
        3 -> {
            var v2: UH10 = (v1 as UH10_RegexAlt).f0
            var v3: UH10 = (v1 as UH10_RegexAlt).f1
            var v4: US12 = US12_SymbolLess()
            v4 = sp_regex_compare_15(v0, v2)
            when (v4.tag) {
                2 -> {
                    var v6: UH10 = UH10_RegexEmpty()
                    v6 = sp_alt_insert_sorted_14(v0, v3)
                    return UH10_RegexAlt(v2, v6)
                }
                0 -> {
                    return UH10_RegexAlt(v0, v1)
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
            var v11: US12 = US12_SymbolLess()
            v11 = sp_regex_compare_15(v0, v1)
            when (v11.tag) {
                2 -> {
                    return UH10_RegexAlt(v1, v0)
                }
                0 -> {
                    return UH10_RegexAlt(v0, v1)
                }
                1 -> {
                    return v1
                }
                else -> throw RuntimeException()
            }
        }
    }
}
fun sp_make_alt_13(p0: UH10, p1: UH10): UH10 {
    var v0: UH10 = p0
    var v1: UH10 = p1
    when (v0.tag) {
        3 -> {
            var v2: UH10 = (v0 as UH10_RegexAlt).f0
            var v3: UH10 = (v0 as UH10_RegexAlt).f1
            var v4: UH10 = UH10_RegexEmpty()
            v4 = sp_alt_insert_sorted_14(v2, v1)
            return sp_make_alt_13(v3, v4)
        }
        0 -> {
            return v1
        }
        else -> {
            return sp_alt_insert_sorted_14(v0, v1)
        }
    }
}
fun sp_regex_equal_17(p0: UH10, p1: UH10): Boolean {
    var v0: UH10 = p0
    var v1: UH10 = p1
    when (v0.tag) {
        3 -> {
            var v18: UH10 = (v0 as UH10_RegexAlt).f0
            var v19: UH10 = (v0 as UH10_RegexAlt).f1
            when (v1.tag) {
                3 -> {
                    var v20: UH10 = (v1 as UH10_RegexAlt).f0
                    var v21: UH10 = (v1 as UH10_RegexAlt).f1
                    var v22: Boolean = false
                    v22 = sp_regex_equal_17(v18, v20)
                    if (v22) {
                        return sp_regex_equal_17(v19, v21)
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
            var v26: UH10 = (v0 as UH10_RegexCat).f0
            var v27: UH10 = (v0 as UH10_RegexCat).f1
            when (v1.tag) {
                4 -> {
                    var v28: UH10 = (v1 as UH10_RegexCat).f0
                    var v29: UH10 = (v1 as UH10_RegexCat).f1
                    var v30: Boolean = false
                    v30 = sp_regex_equal_17(v26, v28)
                    if (v30) {
                        return sp_regex_equal_17(v27, v29)
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
            var v4: US0 = (v0 as UH10_RegexChar).f0
            when (v1.tag) {
                2 -> {
                    var v5: US0 = (v1 as UH10_RegexChar).f0
                    var v15: US12 = US12_SymbolLess()
                    when (v4.tag) {
                        1 -> {
                            when (v5.tag) {
                                1 -> {
                                    v15 = US12_SymbolSame()
                                }
                                0 -> {
                                    v15 = US12_SymbolGreater()
                                }
                                else -> throw RuntimeException()
                            }
                        }
                        0 -> {
                            when (v5.tag) {
                                1 -> {
                                    v15 = US12_SymbolLess()
                                }
                                0 -> {
                                    v15 = US12_SymbolSame()
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
            var v34: UH10 = (v0 as UH10_RegexStar).f0
            when (v1.tag) {
                5 -> {
                    var v35: UH10 = (v1 as UH10_RegexStar).f0
                    return sp_regex_equal_17(v34, v35)
                }
                else -> {
                    return false
                }
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_make_cat_16(p0: UH10, p1: UH10): UH10 {
    var v0: UH10 = p0
    var v1: UH10 = p1
    when (v0.tag) {
        0 -> {
            return UH10_RegexEmpty()
        }
        else -> {
            when (v1.tag) {
                0 -> {
                    return UH10_RegexEmpty()
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
                                            var v12: UH10 = (v0 as UH10_RegexCat).f0
                                            var v13: UH10 = (v0 as UH10_RegexCat).f1
                                            var v14: UH10 = UH10_RegexEmpty()
                                            v14 = sp_make_cat_16(v13, v1)
                                            return UH10_RegexCat(v12, v14)
                                        }
                                        5 -> {
                                            var v4: UH10 = (v0 as UH10_RegexStar).f0
                                            when (v1.tag) {
                                                5 -> {
                                                    var v5: UH10 = (v1 as UH10_RegexStar).f0
                                                    var v6: Boolean = false
                                                    v6 = sp_regex_equal_17(v4, v5)
                                                    if (v6) {
                                                        return UH10_RegexStar(v4)
                                                    } else {
                                                        return UH10_RegexCat(v0, v1)
                                                    }
                                                }
                                                else -> {
                                                    return UH10_RegexCat(v0, v1)
                                                }
                                            }
                                        }
                                        else -> {
                                            return UH10_RegexCat(v0, v1)
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
fun sp_make_star_18(p0: UH10): UH10 {
    var v0: UH10 = p0
    when (v0.tag) {
        0 -> {
            return UH10_RegexEpsilon()
        }
        1 -> {
            return UH10_RegexEpsilon()
        }
        5 -> {
            var v3: UH10 = (v0 as UH10_RegexStar).f0
            return UH10_RegexStar(v3)
        }
        else -> {
            return UH10_RegexStar(v0)
        }
    }
}
fun sp_normalize_12(p0: UH10): UH10 {
    var v0: UH10 = p0
    when (v0.tag) {
        3 -> {
            var v5: UH10 = (v0 as UH10_RegexAlt).f0
            var v6: UH10 = (v0 as UH10_RegexAlt).f1
            var v7: UH10 = UH10_RegexEmpty()
            v7 = sp_normalize_12(v5)
            var v8: UH10 = UH10_RegexEmpty()
            v8 = sp_normalize_12(v6)
            return sp_make_alt_13(v7, v8)
        }
        4 -> {
            var v10: UH10 = (v0 as UH10_RegexCat).f0
            var v11: UH10 = (v0 as UH10_RegexCat).f1
            var v12: UH10 = UH10_RegexEmpty()
            v12 = sp_normalize_12(v10)
            var v13: UH10 = UH10_RegexEmpty()
            v13 = sp_normalize_12(v11)
            return sp_make_cat_16(v12, v13)
        }
        2 -> {
            var v3: US0 = (v0 as UH10_RegexChar).f0
            return UH10_RegexChar(v3)
        }
        0 -> {
            return UH10_RegexEmpty()
        }
        1 -> {
            return UH10_RegexEpsilon()
        }
        5 -> {
            var v15: UH10 = (v0 as UH10_RegexStar).f0
            var v16: UH10 = UH10_RegexEmpty()
            v16 = sp_normalize_12(v15)
            return sp_make_star_18(v16)
        }
        else -> throw RuntimeException()
    }
}
fun sp_nullable_20(p0: UH10): US13 {
    var v0: UH10 = p0
    when (v0.tag) {
        3 -> {
            var v5: UH10 = (v0 as UH10_RegexAlt).f0
            var v6: UH10 = (v0 as UH10_RegexAlt).f1
            var v7: US13 = US13_Nullable()
            v7 = sp_nullable_20(v5)
            var v8: US13 = US13_Nullable()
            v8 = sp_nullable_20(v6)
            when (v7.tag) {
                0 -> {
                    return US13_Nullable()
                }
                else -> {
                    when (v8.tag) {
                        0 -> {
                            return US13_Nullable()
                        }
                        else -> {
                            when (v7.tag) {
                                1 -> {
                                    when (v8.tag) {
                                        1 -> {
                                            return US13_NonNullable()
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
            var v16: UH10 = (v0 as UH10_RegexCat).f0
            var v17: UH10 = (v0 as UH10_RegexCat).f1
            var v18: US13 = US13_Nullable()
            v18 = sp_nullable_20(v16)
            var v19: US13 = US13_Nullable()
            v19 = sp_nullable_20(v17)
            when (v18.tag) {
                0 -> {
                    when (v19.tag) {
                        0 -> {
                            return US13_Nullable()
                        }
                        else -> {
                            return US13_NonNullable()
                        }
                    }
                }
                else -> {
                    return US13_NonNullable()
                }
            }
        }
        2 -> {
            var v3: US0 = (v0 as UH10_RegexChar).f0
            return US13_NonNullable()
        }
        0 -> {
            return US13_NonNullable()
        }
        1 -> {
            return US13_Nullable()
        }
        5 -> {
            var v25: UH10 = (v0 as UH10_RegexStar).f0
            return US13_Nullable()
        }
        else -> throw RuntimeException()
    }
}
fun sp_derivative_19(p0: UH10, p1: US0): UH10 {
    var v0: UH10 = p0
    var v1: US0 = p1
    when (v0.tag) {
        3 -> {
            var v19: UH10 = (v0 as UH10_RegexAlt).f0
            var v20: UH10 = (v0 as UH10_RegexAlt).f1
            var v21: UH10 = UH10_RegexEmpty()
            v21 = sp_derivative_19(v19, v1)
            var v22: UH10 = UH10_RegexEmpty()
            v22 = sp_derivative_19(v20, v1)
            return sp_make_alt_13(v21, v22)
        }
        4 -> {
            var v24: UH10 = (v0 as UH10_RegexCat).f0
            var v25: UH10 = (v0 as UH10_RegexCat).f1
            var v26: US13 = US13_Nullable()
            v26 = sp_nullable_20(v24)
            when (v26.tag) {
                1 -> {
                    var v31: UH10 = UH10_RegexEmpty()
                    v31 = sp_derivative_19(v24, v1)
                    return sp_make_cat_16(v31, v25)
                }
                0 -> {
                    var v27: UH10 = UH10_RegexEmpty()
                    v27 = sp_derivative_19(v24, v1)
                    var v28: UH10 = UH10_RegexEmpty()
                    v28 = sp_make_cat_16(v27, v25)
                    var v29: UH10 = UH10_RegexEmpty()
                    v29 = sp_derivative_19(v25, v1)
                    return sp_make_alt_13(v28, v29)
                }
                else -> throw RuntimeException()
            }
        }
        2 -> {
            var v4: US0 = (v0 as UH10_RegexChar).f0
            var v14: US12 = US12_SymbolLess()
            when (v4.tag) {
                1 -> {
                    when (v1.tag) {
                        1 -> {
                            v14 = US12_SymbolSame()
                        }
                        0 -> {
                            v14 = US12_SymbolGreater()
                        }
                        else -> throw RuntimeException()
                    }
                }
                0 -> {
                    when (v1.tag) {
                        1 -> {
                            v14 = US12_SymbolLess()
                        }
                        0 -> {
                            v14 = US12_SymbolSame()
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
                return UH10_RegexEpsilon()
            } else {
                return UH10_RegexEmpty()
            }
        }
        0 -> {
            return UH10_RegexEmpty()
        }
        1 -> {
            return UH10_RegexEmpty()
        }
        5 -> {
            var v35: UH10 = (v0 as UH10_RegexStar).f0
            var v36: UH10 = UH10_RegexEmpty()
            v36 = sp_derivative_19(v35, v1)
            var v37: UH10 = UH10_RegexEmpty()
            v37 = sp_make_star_18(v35)
            return sp_make_cat_16(v36, v37)
        }
        else -> throw RuntimeException()
    }
}
fun sp_canonical_derivative_11(p0: UH10, p1: US0): UH10 {
    var v0: UH10 = p0
    var v1: US0 = p1
    var v2: UH10 = UH10_RegexEmpty()
    v2 = sp_normalize_12(v0)
    var v3: UH10 = UH10_RegexEmpty()
    v3 = sp_derivative_19(v2, v1)
    return sp_normalize_12(v3)
}
fun sp_accepts_10(p0: UH10, p1: UH3): Boolean {
    var v0: UH10 = p0
    var v1: UH3 = p1
    when (v1.tag) {
        1 -> {
            var v6: US0 = (v1 as UH3_InputCons).f0
            var v7: UH3 = (v1 as UH3_InputCons).f1
            var v8: UH10 = UH10_RegexEmpty()
            v8 = sp_canonical_derivative_11(v0, v6)
            return sp_accepts_10(v8, v7)
        }
        0 -> {
            var v2: UH10 = UH10_RegexEmpty()
            v2 = sp_normalize_12(v0)
            var v3: US13 = US13_Nullable()
            v3 = sp_nullable_20(v2)
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
fun sp_loop_8(p0: UH10, p1: UH2): Boolean {
    var v0: UH10 = p0
    var v1: UH2 = p1
    when (v1.tag) {
        1 -> {
            var v2: UH3 = (v1 as UH2_InputListCons).f0
            var v3: UH2 = (v1 as UH2_InputListCons).f1
            var v4: Int = 0
            v4 = 1
            var v5: US11 = US11_InventoryDfaAccepted()
            v5 = sp_loop_9(v4, v2)
            var v11: Boolean = false
            when (v5.tag) {
                0 -> {
                    v11 = sp_accepts_10(v0, v2)
                }
                2 -> {
                    v11 = false
                }
                1 -> {
                    var v7: Boolean = false
                    v7 = sp_accepts_10(v0, v2)
                    var v8: Boolean = false
                    v8 = (v7 == false)
                    v11 = v8
                }
                else -> throw RuntimeException()
            }
            if (v11) {
                return sp_loop_8(v0, v3)
            } else {
                return false
            }
        }
        0 -> {
            return true
        }
        else -> throw RuntimeException()
    }
}
fun sp_loop_22(p0: Int, p1: UH7): US11 {
    var v0: Int = p0
    var v1: UH7 = p1
    when (v1.tag) {
        1 -> {
            var v8: US4 = (v1 as UH7_InputCons).f0
            var v9: UH7 = (v1 as UH7_InputCons).f1
            var v12: US12 = US12_SymbolLess()
            when (v8.tag) {
                0 -> {
                    v12 = US12_SymbolSame()
                }
                else -> {
                    v12 = US12_SymbolGreater()
                }
            }
            var v13: Boolean = false
            when (v12.tag) {
                1 -> {
                    v13 = true
                }
                else -> {
                    v13 = false
                }
            }
            var v30: Int = 0
            if (v13) {
                v30 = 0
            } else {
                var v19: US12 = US12_SymbolLess()
                when (v8.tag) {
                    0 -> {
                        v19 = US12_SymbolLess()
                    }
                    1 -> {
                        v19 = US12_SymbolSame()
                    }
                    2 -> {
                        v19 = US12_SymbolGreater()
                    }
                    else -> throw RuntimeException()
                }
                var v20: Boolean = false
                when (v19.tag) {
                    1 -> {
                        v20 = true
                    }
                    else -> {
                        v20 = false
                    }
                }
                if (v20) {
                    v30 = 1
                } else {
                    var v26: US12 = US12_SymbolLess()
                    when (v8.tag) {
                        0 -> {
                            v26 = US12_SymbolLess()
                        }
                        1 -> {
                            v26 = US12_SymbolLess()
                        }
                        2 -> {
                            v26 = US12_SymbolSame()
                        }
                        else -> throw RuntimeException()
                    }
                    var v27: Boolean = false
                    when (v26.tag) {
                        1 -> {
                            v27 = true
                        }
                        else -> {
                            v27 = false
                        }
                    }
                    if (v27) {
                        v30 = 2
                    } else {
                        v30 = -1
                    }
                }
            }
            var v31: Boolean = false
            v31 = (v30 < 0)
            if (v31) {
                return US11_InventoryDfaInputOutsideInventory()
            } else {
                var v33: Boolean = false
                v33 = (v0 == 0)
                var v46: Int = 0
                if (v33) {
                    var v34: Boolean = false
                    v34 = (v30 == 0)
                    if (v34) {
                        v46 = 0
                    } else {
                        v46 = 0
                    }
                } else {
                    var v37: Boolean = false
                    v37 = (v0 == 1)
                    if (v37) {
                        var v38: Boolean = false
                        v38 = (v30 == 0)
                        if (v38) {
                            v46 = 0
                        } else {
                            v46 = 0
                        }
                    } else {
                        var v41: Boolean = false
                        v41 = (v30 == 0)
                        if (v41) {
                            v46 = 2
                        } else {
                            var v42: Boolean = false
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
        }
        0 -> {
            var v2: Boolean = false
            v2 = (v0 == 0)
            var v4: Boolean = false
            if (v2) {
                v4 = false
            } else {
                var v3: Boolean = false
                v3 = (v0 == 1)
                v4 = v3
            }
            if (v4) {
                return US11_InventoryDfaAccepted()
            } else {
                return US11_InventoryDfaRejected()
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_regex_compare_28(p0: UH14, p1: UH14): US12 {
    var v0: UH14 = p0
    var v1: UH14 = p1
    when (v0.tag) {
        3 -> {
            var v59: UH14 = (v0 as UH14_RegexAlt).f0
            var v60: UH14 = (v0 as UH14_RegexAlt).f1
            when (v1.tag) {
                3 -> {
                    var v61: UH14 = (v1 as UH14_RegexAlt).f0
                    var v62: UH14 = (v1 as UH14_RegexAlt).f1
                    var v63: US12 = US12_SymbolLess()
                    v63 = sp_regex_compare_28(v59, v61)
                    when (v63.tag) {
                        1 -> {
                            return sp_regex_compare_28(v60, v62)
                        }
                        else -> {
                            return v63
                        }
                    }
                }
                else -> {
                    return US12_SymbolGreater()
                }
            }
        }
        4 -> {
            var v34: UH14 = (v0 as UH14_RegexCat).f0
            var v35: UH14 = (v0 as UH14_RegexCat).f1
            when (v1.tag) {
                4 -> {
                    var v40: UH14 = (v1 as UH14_RegexCat).f0
                    var v41: UH14 = (v1 as UH14_RegexCat).f1
                    var v42: US12 = US12_SymbolLess()
                    v42 = sp_regex_compare_28(v34, v40)
                    when (v42.tag) {
                        1 -> {
                            return sp_regex_compare_28(v35, v41)
                        }
                        else -> {
                            return v42
                        }
                    }
                }
                2 -> {
                    var v38: US4 = (v1 as UH14_RegexChar).f0
                    return US12_SymbolGreater()
                }
                0 -> {
                    return US12_SymbolGreater()
                }
                1 -> {
                    return US12_SymbolGreater()
                }
                else -> {
                    return US12_SymbolLess()
                }
            }
        }
        2 -> {
            var v10: US4 = (v0 as UH14_RegexChar).f0
            when (v1.tag) {
                2 -> {
                    var v13: US4 = (v1 as UH14_RegexChar).f0
                    when (v10.tag) {
                        0 -> {
                            when (v13.tag) {
                                0 -> {
                                    return US12_SymbolSame()
                                }
                                else -> {
                                    return US12_SymbolLess()
                                }
                            }
                        }
                        else -> {
                            when (v13.tag) {
                                0 -> {
                                    return US12_SymbolGreater()
                                }
                                else -> {
                                    when (v10.tag) {
                                        1 -> {
                                            when (v13.tag) {
                                                1 -> {
                                                    return US12_SymbolSame()
                                                }
                                                2 -> {
                                                    return US12_SymbolLess()
                                                }
                                                else -> throw RuntimeException()
                                            }
                                        }
                                        2 -> {
                                            when (v13.tag) {
                                                1 -> {
                                                    return US12_SymbolGreater()
                                                }
                                                2 -> {
                                                    return US12_SymbolSame()
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
                    return US12_SymbolGreater()
                }
                1 -> {
                    return US12_SymbolGreater()
                }
                else -> {
                    return US12_SymbolLess()
                }
            }
        }
        0 -> {
            when (v1.tag) {
                0 -> {
                    return US12_SymbolSame()
                }
                else -> {
                    return US12_SymbolLess()
                }
            }
        }
        1 -> {
            when (v1.tag) {
                0 -> {
                    return US12_SymbolGreater()
                }
                1 -> {
                    return US12_SymbolSame()
                }
                else -> {
                    return US12_SymbolLess()
                }
            }
        }
        5 -> {
            var v50: UH14 = (v0 as UH14_RegexStar).f0
            when (v1.tag) {
                3 -> {
                    var v51: UH14 = (v1 as UH14_RegexAlt).f0
                    var v52: UH14 = (v1 as UH14_RegexAlt).f1
                    return US12_SymbolLess()
                }
                5 -> {
                    var v54: UH14 = (v1 as UH14_RegexStar).f0
                    return sp_regex_compare_28(v50, v54)
                }
                else -> {
                    return US12_SymbolGreater()
                }
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_alt_insert_sorted_27(p0: UH14, p1: UH14): UH14 {
    var v0: UH14 = p0
    var v1: UH14 = p1
    when (v1.tag) {
        3 -> {
            var v2: UH14 = (v1 as UH14_RegexAlt).f0
            var v3: UH14 = (v1 as UH14_RegexAlt).f1
            var v4: US12 = US12_SymbolLess()
            v4 = sp_regex_compare_28(v0, v2)
            when (v4.tag) {
                2 -> {
                    var v6: UH14 = UH14_RegexEmpty()
                    v6 = sp_alt_insert_sorted_27(v0, v3)
                    return UH14_RegexAlt(v2, v6)
                }
                0 -> {
                    return UH14_RegexAlt(v0, v1)
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
            var v11: US12 = US12_SymbolLess()
            v11 = sp_regex_compare_28(v0, v1)
            when (v11.tag) {
                2 -> {
                    return UH14_RegexAlt(v1, v0)
                }
                0 -> {
                    return UH14_RegexAlt(v0, v1)
                }
                1 -> {
                    return v1
                }
                else -> throw RuntimeException()
            }
        }
    }
}
fun sp_make_alt_26(p0: UH14, p1: UH14): UH14 {
    var v0: UH14 = p0
    var v1: UH14 = p1
    when (v0.tag) {
        3 -> {
            var v2: UH14 = (v0 as UH14_RegexAlt).f0
            var v3: UH14 = (v0 as UH14_RegexAlt).f1
            var v4: UH14 = UH14_RegexEmpty()
            v4 = sp_alt_insert_sorted_27(v2, v1)
            return sp_make_alt_26(v3, v4)
        }
        0 -> {
            return v1
        }
        else -> {
            return sp_alt_insert_sorted_27(v0, v1)
        }
    }
}
fun sp_regex_equal_30(p0: UH14, p1: UH14): Boolean {
    var v0: UH14 = p0
    var v1: UH14 = p1
    when (v0.tag) {
        3 -> {
            var v24: UH14 = (v0 as UH14_RegexAlt).f0
            var v25: UH14 = (v0 as UH14_RegexAlt).f1
            when (v1.tag) {
                3 -> {
                    var v26: UH14 = (v1 as UH14_RegexAlt).f0
                    var v27: UH14 = (v1 as UH14_RegexAlt).f1
                    var v28: Boolean = false
                    v28 = sp_regex_equal_30(v24, v26)
                    if (v28) {
                        return sp_regex_equal_30(v25, v27)
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
            var v32: UH14 = (v0 as UH14_RegexCat).f0
            var v33: UH14 = (v0 as UH14_RegexCat).f1
            when (v1.tag) {
                4 -> {
                    var v34: UH14 = (v1 as UH14_RegexCat).f0
                    var v35: UH14 = (v1 as UH14_RegexCat).f1
                    var v36: Boolean = false
                    v36 = sp_regex_equal_30(v32, v34)
                    if (v36) {
                        return sp_regex_equal_30(v33, v35)
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
            var v4: US4 = (v0 as UH14_RegexChar).f0
            when (v1.tag) {
                2 -> {
                    var v5: US4 = (v1 as UH14_RegexChar).f0
                    var v21: US12 = US12_SymbolLess()
                    when (v4.tag) {
                        0 -> {
                            when (v5.tag) {
                                0 -> {
                                    v21 = US12_SymbolSame()
                                }
                                else -> {
                                    v21 = US12_SymbolLess()
                                }
                            }
                        }
                        else -> {
                            when (v5.tag) {
                                0 -> {
                                    v21 = US12_SymbolGreater()
                                }
                                else -> {
                                    when (v4.tag) {
                                        1 -> {
                                            when (v5.tag) {
                                                1 -> {
                                                    v21 = US12_SymbolSame()
                                                }
                                                2 -> {
                                                    v21 = US12_SymbolLess()
                                                }
                                                else -> throw RuntimeException()
                                            }
                                        }
                                        2 -> {
                                            when (v5.tag) {
                                                1 -> {
                                                    v21 = US12_SymbolGreater()
                                                }
                                                2 -> {
                                                    v21 = US12_SymbolSame()
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
            var v40: UH14 = (v0 as UH14_RegexStar).f0
            when (v1.tag) {
                5 -> {
                    var v41: UH14 = (v1 as UH14_RegexStar).f0
                    return sp_regex_equal_30(v40, v41)
                }
                else -> {
                    return false
                }
            }
        }
        else -> throw RuntimeException()
    }
}
fun sp_make_cat_29(p0: UH14, p1: UH14): UH14 {
    var v0: UH14 = p0
    var v1: UH14 = p1
    when (v0.tag) {
        0 -> {
            return UH14_RegexEmpty()
        }
        else -> {
            when (v1.tag) {
                0 -> {
                    return UH14_RegexEmpty()
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
                                            var v12: UH14 = (v0 as UH14_RegexCat).f0
                                            var v13: UH14 = (v0 as UH14_RegexCat).f1
                                            var v14: UH14 = UH14_RegexEmpty()
                                            v14 = sp_make_cat_29(v13, v1)
                                            return UH14_RegexCat(v12, v14)
                                        }
                                        5 -> {
                                            var v4: UH14 = (v0 as UH14_RegexStar).f0
                                            when (v1.tag) {
                                                5 -> {
                                                    var v5: UH14 = (v1 as UH14_RegexStar).f0
                                                    var v6: Boolean = false
                                                    v6 = sp_regex_equal_30(v4, v5)
                                                    if (v6) {
                                                        return UH14_RegexStar(v4)
                                                    } else {
                                                        return UH14_RegexCat(v0, v1)
                                                    }
                                                }
                                                else -> {
                                                    return UH14_RegexCat(v0, v1)
                                                }
                                            }
                                        }
                                        else -> {
                                            return UH14_RegexCat(v0, v1)
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
fun sp_make_star_31(p0: UH14): UH14 {
    var v0: UH14 = p0
    when (v0.tag) {
        0 -> {
            return UH14_RegexEpsilon()
        }
        1 -> {
            return UH14_RegexEpsilon()
        }
        5 -> {
            var v3: UH14 = (v0 as UH14_RegexStar).f0
            return UH14_RegexStar(v3)
        }
        else -> {
            return UH14_RegexStar(v0)
        }
    }
}
fun sp_normalize_25(p0: UH14): UH14 {
    var v0: UH14 = p0
    when (v0.tag) {
        3 -> {
            var v5: UH14 = (v0 as UH14_RegexAlt).f0
            var v6: UH14 = (v0 as UH14_RegexAlt).f1
            var v7: UH14 = UH14_RegexEmpty()
            v7 = sp_normalize_25(v5)
            var v8: UH14 = UH14_RegexEmpty()
            v8 = sp_normalize_25(v6)
            return sp_make_alt_26(v7, v8)
        }
        4 -> {
            var v10: UH14 = (v0 as UH14_RegexCat).f0
            var v11: UH14 = (v0 as UH14_RegexCat).f1
            var v12: UH14 = UH14_RegexEmpty()
            v12 = sp_normalize_25(v10)
            var v13: UH14 = UH14_RegexEmpty()
            v13 = sp_normalize_25(v11)
            return sp_make_cat_29(v12, v13)
        }
        2 -> {
            var v3: US4 = (v0 as UH14_RegexChar).f0
            return UH14_RegexChar(v3)
        }
        0 -> {
            return UH14_RegexEmpty()
        }
        1 -> {
            return UH14_RegexEpsilon()
        }
        5 -> {
            var v15: UH14 = (v0 as UH14_RegexStar).f0
            var v16: UH14 = UH14_RegexEmpty()
            v16 = sp_normalize_25(v15)
            return sp_make_star_31(v16)
        }
        else -> throw RuntimeException()
    }
}
fun sp_nullable_33(p0: UH14): US13 {
    var v0: UH14 = p0
    when (v0.tag) {
        3 -> {
            var v5: UH14 = (v0 as UH14_RegexAlt).f0
            var v6: UH14 = (v0 as UH14_RegexAlt).f1
            var v7: US13 = US13_Nullable()
            v7 = sp_nullable_33(v5)
            var v8: US13 = US13_Nullable()
            v8 = sp_nullable_33(v6)
            when (v7.tag) {
                0 -> {
                    return US13_Nullable()
                }
                else -> {
                    when (v8.tag) {
                        0 -> {
                            return US13_Nullable()
                        }
                        else -> {
                            when (v7.tag) {
                                1 -> {
                                    when (v8.tag) {
                                        1 -> {
                                            return US13_NonNullable()
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
            var v16: UH14 = (v0 as UH14_RegexCat).f0
            var v17: UH14 = (v0 as UH14_RegexCat).f1
            var v18: US13 = US13_Nullable()
            v18 = sp_nullable_33(v16)
            var v19: US13 = US13_Nullable()
            v19 = sp_nullable_33(v17)
            when (v18.tag) {
                0 -> {
                    when (v19.tag) {
                        0 -> {
                            return US13_Nullable()
                        }
                        else -> {
                            return US13_NonNullable()
                        }
                    }
                }
                else -> {
                    return US13_NonNullable()
                }
            }
        }
        2 -> {
            var v3: US4 = (v0 as UH14_RegexChar).f0
            return US13_NonNullable()
        }
        0 -> {
            return US13_NonNullable()
        }
        1 -> {
            return US13_Nullable()
        }
        5 -> {
            var v25: UH14 = (v0 as UH14_RegexStar).f0
            return US13_Nullable()
        }
        else -> throw RuntimeException()
    }
}
fun sp_derivative_32(p0: UH14, p1: US4): UH14 {
    var v0: UH14 = p0
    var v1: US4 = p1
    when (v0.tag) {
        3 -> {
            var v25: UH14 = (v0 as UH14_RegexAlt).f0
            var v26: UH14 = (v0 as UH14_RegexAlt).f1
            var v27: UH14 = UH14_RegexEmpty()
            v27 = sp_derivative_32(v25, v1)
            var v28: UH14 = UH14_RegexEmpty()
            v28 = sp_derivative_32(v26, v1)
            return sp_make_alt_26(v27, v28)
        }
        4 -> {
            var v30: UH14 = (v0 as UH14_RegexCat).f0
            var v31: UH14 = (v0 as UH14_RegexCat).f1
            var v32: US13 = US13_Nullable()
            v32 = sp_nullable_33(v30)
            when (v32.tag) {
                1 -> {
                    var v37: UH14 = UH14_RegexEmpty()
                    v37 = sp_derivative_32(v30, v1)
                    return sp_make_cat_29(v37, v31)
                }
                0 -> {
                    var v33: UH14 = UH14_RegexEmpty()
                    v33 = sp_derivative_32(v30, v1)
                    var v34: UH14 = UH14_RegexEmpty()
                    v34 = sp_make_cat_29(v33, v31)
                    var v35: UH14 = UH14_RegexEmpty()
                    v35 = sp_derivative_32(v31, v1)
                    return sp_make_alt_26(v34, v35)
                }
                else -> throw RuntimeException()
            }
        }
        2 -> {
            var v4: US4 = (v0 as UH14_RegexChar).f0
            var v20: US12 = US12_SymbolLess()
            when (v4.tag) {
                0 -> {
                    when (v1.tag) {
                        0 -> {
                            v20 = US12_SymbolSame()
                        }
                        else -> {
                            v20 = US12_SymbolLess()
                        }
                    }
                }
                else -> {
                    when (v1.tag) {
                        0 -> {
                            v20 = US12_SymbolGreater()
                        }
                        else -> {
                            when (v4.tag) {
                                1 -> {
                                    when (v1.tag) {
                                        1 -> {
                                            v20 = US12_SymbolSame()
                                        }
                                        2 -> {
                                            v20 = US12_SymbolLess()
                                        }
                                        else -> throw RuntimeException()
                                    }
                                }
                                2 -> {
                                    when (v1.tag) {
                                        1 -> {
                                            v20 = US12_SymbolGreater()
                                        }
                                        2 -> {
                                            v20 = US12_SymbolSame()
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
                return UH14_RegexEpsilon()
            } else {
                return UH14_RegexEmpty()
            }
        }
        0 -> {
            return UH14_RegexEmpty()
        }
        1 -> {
            return UH14_RegexEmpty()
        }
        5 -> {
            var v41: UH14 = (v0 as UH14_RegexStar).f0
            var v42: UH14 = UH14_RegexEmpty()
            v42 = sp_derivative_32(v41, v1)
            var v43: UH14 = UH14_RegexEmpty()
            v43 = sp_make_star_31(v41)
            return sp_make_cat_29(v42, v43)
        }
        else -> throw RuntimeException()
    }
}
fun sp_canonical_derivative_24(p0: UH14, p1: US4): UH14 {
    var v0: UH14 = p0
    var v1: US4 = p1
    var v2: UH14 = UH14_RegexEmpty()
    v2 = sp_normalize_25(v0)
    var v3: UH14 = UH14_RegexEmpty()
    v3 = sp_derivative_32(v2, v1)
    return sp_normalize_25(v3)
}
fun sp_accepts_23(p0: UH14, p1: UH7): Boolean {
    var v0: UH14 = p0
    var v1: UH7 = p1
    when (v1.tag) {
        1 -> {
            var v6: US4 = (v1 as UH7_InputCons).f0
            var v7: UH7 = (v1 as UH7_InputCons).f1
            var v8: UH14 = UH14_RegexEmpty()
            v8 = sp_canonical_derivative_24(v0, v6)
            return sp_accepts_23(v8, v7)
        }
        0 -> {
            var v2: UH14 = UH14_RegexEmpty()
            v2 = sp_normalize_25(v0)
            var v3: US13 = US13_Nullable()
            v3 = sp_nullable_33(v2)
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
fun sp_loop_21(p0: UH14, p1: UH6): Boolean {
    var v0: UH14 = p0
    var v1: UH6 = p1
    when (v1.tag) {
        1 -> {
            var v2: UH7 = (v1 as UH6_InputListCons).f0
            var v3: UH6 = (v1 as UH6_InputListCons).f1
            var v4: Int = 0
            v4 = 2
            var v5: US11 = US11_InventoryDfaAccepted()
            v5 = sp_loop_22(v4, v2)
            var v11: Boolean = false
            when (v5.tag) {
                0 -> {
                    v11 = sp_accepts_23(v0, v2)
                }
                2 -> {
                    v11 = false
                }
                1 -> {
                    var v7: Boolean = false
                    v7 = sp_accepts_23(v0, v2)
                    var v8: Boolean = false
                    v8 = (v7 == false)
                    v11 = v8
                }
                else -> throw RuntimeException()
            }
            if (v11) {
                return sp_loop_21(v0, v3)
            } else {
                return false
            }
        }
        0 -> {
            return true
        }
        else -> throw RuntimeException()
    }
}
fun sp_loop_34(p0: Int, p1: UH9): US11 {
    var v0: Int = p0
    var v1: UH9 = p1
    when (v1.tag) {
        1 -> {
            var v7: US8 = (v1 as UH9_InputCons).f0
            var v8: UH9 = (v1 as UH9_InputCons).f1
            var v11: US12 = US12_SymbolLess()
            when (v7.tag) {
                0 -> {
                    v11 = US12_SymbolSame()
                }
                else -> {
                    v11 = US12_SymbolGreater()
                }
            }
            var v12: Boolean = false
            when (v11.tag) {
                1 -> {
                    v12 = true
                }
                else -> {
                    v12 = false
                }
            }
            var v21: Int = 0
            if (v12) {
                v21 = 0
            } else {
                var v18: US12 = US12_SymbolLess()
                when (v7.tag) {
                    0 -> {
                        v18 = US12_SymbolLess()
                    }
                    1 -> {
                        v18 = US12_SymbolSame()
                    }
                    2 -> {
                        v18 = US12_SymbolGreater()
                    }
                    else -> throw RuntimeException()
                }
                var v19: Boolean = false
                when (v18.tag) {
                    1 -> {
                        v19 = true
                    }
                    else -> {
                        v19 = false
                    }
                }
                if (v19) {
                    v21 = 1
                } else {
                    v21 = -1
                }
            }
            var v22: Boolean = false
            v22 = (v21 < 0)
            if (v22) {
                return US11_InventoryDfaInputOutsideInventory()
            } else {
                var v24: Boolean = false
                v24 = (v0 == 0)
                var v28: Int = 0
                if (v24) {
                    v28 = 0
                } else {
                    var v26: Boolean = false
                    v26 = (v21 == 0)
                    if (v26) {
                        v28 = 1
                    } else {
                        v28 = 0
                    }
                }
                return sp_loop_34(v28, v8)
            }
        }
        0 -> {
            var v2: Boolean = false
            v2 = (v0 == 0)
            var v3: Boolean = false
            v3 = (v2 == false)
            if (v3) {
                return US11_InventoryDfaAccepted()
            } else {
                return US11_InventoryDfaRejected()
            }
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: US0 = US0_BitZero()
    v0 = US0_BitZero()
    var v1: US0 = US0_BitZero()
    v1 = US0_BitOne()
    var v2: UH1 = UH1_SymbolListNil()
    v2 = UH1_SymbolListNil()
    var v3: UH1 = UH1_SymbolListNil()
    v3 = UH1_SymbolListCons(v1, v2)
    var v4: UH1 = UH1_SymbolListNil()
    v4 = UH1_SymbolListCons(v0, v3)
    var v5: UH2 = UH2_InputListNil()
    v5 = sp_input_singletons_from_symbols_0(v4)
    var v6: UH3 = UH3_InputEmpty()
    v6 = UH3_InputEmpty()
    var v7: UH2 = UH2_InputListNil()
    v7 = UH2_InputListCons(v6, v5)
    var v8: US0 = US0_BitZero()
    v8 = US0_BitZero()
    var v9: US0 = US0_BitZero()
    v9 = US0_BitOne()
    var v10: UH1 = UH1_SymbolListNil()
    v10 = UH1_SymbolListNil()
    var v11: UH1 = UH1_SymbolListNil()
    v11 = UH1_SymbolListCons(v9, v10)
    var v12: UH1 = UH1_SymbolListNil()
    v12 = UH1_SymbolListCons(v8, v11)
    var v13: US0 = US0_BitZero()
    v13 = US0_BitZero()
    var v14: US0 = US0_BitZero()
    v14 = US0_BitOne()
    var v15: UH1 = UH1_SymbolListNil()
    v15 = UH1_SymbolListNil()
    var v16: UH1 = UH1_SymbolListNil()
    v16 = UH1_SymbolListCons(v14, v15)
    var v17: UH1 = UH1_SymbolListNil()
    v17 = UH1_SymbolListCons(v13, v16)
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
    v25 = UH5_SymbolListCons(v23, v24)
    var v26: UH5 = UH5_SymbolListNil()
    v26 = UH5_SymbolListCons(v22, v25)
    var v27: UH5 = UH5_SymbolListNil()
    v27 = UH5_SymbolListCons(v21, v26)
    var v28: UH6 = UH6_InputListNil()
    v28 = sp_input_singletons_from_symbols_4(v27)
    var v29: UH7 = UH7_InputEmpty()
    v29 = UH7_InputEmpty()
    var v30: UH6 = UH6_InputListNil()
    v30 = UH6_InputListCons(v29, v28)
    var v31: US4 = US4_TriA()
    v31 = US4_TriA()
    var v32: US4 = US4_TriA()
    v32 = US4_TriB()
    var v33: US4 = US4_TriA()
    v33 = US4_TriC()
    var v34: UH5 = UH5_SymbolListNil()
    v34 = UH5_SymbolListNil()
    var v35: UH5 = UH5_SymbolListNil()
    v35 = UH5_SymbolListCons(v33, v34)
    var v36: UH5 = UH5_SymbolListNil()
    v36 = UH5_SymbolListCons(v32, v35)
    var v37: UH5 = UH5_SymbolListNil()
    v37 = UH5_SymbolListCons(v31, v36)
    var v38: US4 = US4_TriA()
    v38 = US4_TriA()
    var v39: US4 = US4_TriA()
    v39 = US4_TriB()
    var v40: US4 = US4_TriA()
    v40 = US4_TriC()
    var v41: UH5 = UH5_SymbolListNil()
    v41 = UH5_SymbolListNil()
    var v42: UH5 = UH5_SymbolListNil()
    v42 = UH5_SymbolListCons(v40, v41)
    var v43: UH5 = UH5_SymbolListNil()
    v43 = UH5_SymbolListCons(v39, v42)
    var v44: UH5 = UH5_SymbolListNil()
    v44 = UH5_SymbolListCons(v38, v43)
    var v45: UH6 = UH6_InputListNil()
    v45 = sp_input_singletons_from_symbols_4(v44)
    var v46: UH6 = UH6_InputListNil()
    v46 = sp_input_prepend_symbols_to_corpus_5(v37, v45)
    var v47: UH6 = UH6_InputListNil()
    v47 = sp_input_list_append_7(v30, v46)
    var v48: US8 = US8_ModelA()
    v48 = US8_ModelC()
    var v49: UH9 = UH9_InputEmpty()
    v49 = UH9_InputEmpty()
    var v50: UH9 = UH9_InputEmpty()
    v50 = UH9_InputCons(v48, v49)
    var v51: US0 = US0_BitZero()
    v51 = US0_BitZero()
    var v52: UH10 = UH10_RegexEmpty()
    v52 = UH10_RegexChar(v51)
    var v53: US0 = US0_BitZero()
    v53 = US0_BitOne()
    var v54: UH10 = UH10_RegexEmpty()
    v54 = UH10_RegexChar(v53)
    var v55: UH10 = UH10_RegexEmpty()
    v55 = UH10_RegexAlt(v52, v54)
    var v56: UH10 = UH10_RegexEmpty()
    v56 = UH10_RegexStar(v55)
    var v57: US0 = US0_BitZero()
    v57 = US0_BitZero()
    var v58: UH10 = UH10_RegexEmpty()
    v58 = UH10_RegexChar(v57)
    var v59: UH10 = UH10_RegexEmpty()
    v59 = UH10_RegexCat(v56, v58)
    var v60: Boolean = false
    v60 = sp_loop_8(v59, v20)
    var v75: Boolean = false
    if (v60) {
        var v61: US4 = US4_TriA()
        v61 = US4_TriA()
        var v62: UH14 = UH14_RegexEmpty()
        v62 = UH14_RegexChar(v61)
        var v63: US4 = US4_TriA()
        v63 = US4_TriB()
        var v64: UH14 = UH14_RegexEmpty()
        v64 = UH14_RegexChar(v63)
        var v65: UH14 = UH14_RegexEmpty()
        v65 = UH14_RegexAlt(v62, v64)
        var v66: UH14 = UH14_RegexEmpty()
        v66 = UH14_RegexStar(v65)
        var v67: US4 = US4_TriA()
        v67 = US4_TriC()
        var v68: UH14 = UH14_RegexEmpty()
        v68 = UH14_RegexChar(v67)
        var v69: UH14 = UH14_RegexEmpty()
        v69 = UH14_RegexCat(v66, v68)
        var v70: Boolean = false
        v70 = sp_loop_21(v69, v47)
        if (v70) {
            var v71: Int = 0
            v71 = 1
            var v72: US11 = US11_InventoryDfaAccepted()
            v72 = sp_loop_34(v71, v50)
            when (v72.tag) {
                2 -> {
                    v75 = true
                }
                else -> {
                    v75 = false
                }
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
fun main() {
    var spiral_exit_code = 0
    val spiral_thread = Thread(null, { spiral_exit_code = spiral_main() }, "spiral_main", 1L shl 30)
    spiral_thread.start()
    spiral_thread.join()
    System.exit(spiral_exit_code)
}
