type US0_BitZero = { readonly tag: 0 };
type US0_BitOne = { readonly tag: 1 };
type US0 = US0_BitZero | US0_BitOne;
const US0_BitZero_shared: US0 = { tag: 0 }; function US0_BitZero(): US0 { return US0_BitZero_shared; }
const US0_BitOne_shared: US0 = { tag: 1 }; function US0_BitOne(): US0 { return US0_BitOne_shared; }
type UH0_SymbolListNil = { readonly tag: 0 };
type UH0_SymbolListCons = { readonly tag: 1, readonly f0: US0, readonly f1: UH0 };
type UH0 = UH0_SymbolListNil | UH0_SymbolListCons;
const UH0_SymbolListNil_shared: UH0 = { tag: 0 }; function UH0_SymbolListNil(): UH0 { return UH0_SymbolListNil_shared; }
function UH0_SymbolListCons(f0: US0, f1: UH0): UH0 { return { tag: 1, f0: f0, f1: f1 }; }
type UH2_InputEmpty = { readonly tag: 0 };
type UH2_InputCons = { readonly tag: 1, readonly f0: US0, readonly f1: UH2 };
type UH2 = UH2_InputEmpty | UH2_InputCons;
const UH2_InputEmpty_shared: UH2 = { tag: 0 }; function UH2_InputEmpty(): UH2 { return UH2_InputEmpty_shared; }
function UH2_InputCons(f0: US0, f1: UH2): UH2 { return { tag: 1, f0: f0, f1: f1 }; }
type UH1_InputListNil = { readonly tag: 0 };
type UH1_InputListCons = { readonly tag: 1, readonly f0: UH2, readonly f1: UH1 };
type UH1 = UH1_InputListNil | UH1_InputListCons;
const UH1_InputListNil_shared: UH1 = { tag: 0 }; function UH1_InputListNil(): UH1 { return UH1_InputListNil_shared; }
function UH1_InputListCons(f0: UH2, f1: UH1): UH1 { return { tag: 1, f0: f0, f1: f1 }; }
type US1_TriA = { readonly tag: 0 };
type US1_TriB = { readonly tag: 1 };
type US1_TriC = { readonly tag: 2 };
type US1 = US1_TriA | US1_TriB | US1_TriC;
const US1_TriA_shared: US1 = { tag: 0 }; function US1_TriA(): US1 { return US1_TriA_shared; }
const US1_TriB_shared: US1 = { tag: 1 }; function US1_TriB(): US1 { return US1_TriB_shared; }
const US1_TriC_shared: US1 = { tag: 2 }; function US1_TriC(): US1 { return US1_TriC_shared; }
type UH3_SymbolListNil = { readonly tag: 0 };
type UH3_SymbolListCons = { readonly tag: 1, readonly f0: US1, readonly f1: UH3 };
type UH3 = UH3_SymbolListNil | UH3_SymbolListCons;
const UH3_SymbolListNil_shared: UH3 = { tag: 0 }; function UH3_SymbolListNil(): UH3 { return UH3_SymbolListNil_shared; }
function UH3_SymbolListCons(f0: US1, f1: UH3): UH3 { return { tag: 1, f0: f0, f1: f1 }; }
type UH5_InputEmpty = { readonly tag: 0 };
type UH5_InputCons = { readonly tag: 1, readonly f0: US1, readonly f1: UH5 };
type UH5 = UH5_InputEmpty | UH5_InputCons;
const UH5_InputEmpty_shared: UH5 = { tag: 0 }; function UH5_InputEmpty(): UH5 { return UH5_InputEmpty_shared; }
function UH5_InputCons(f0: US1, f1: UH5): UH5 { return { tag: 1, f0: f0, f1: f1 }; }
type UH4_InputListNil = { readonly tag: 0 };
type UH4_InputListCons = { readonly tag: 1, readonly f0: UH5, readonly f1: UH4 };
type UH4 = UH4_InputListNil | UH4_InputListCons;
const UH4_InputListNil_shared: UH4 = { tag: 0 }; function UH4_InputListNil(): UH4 { return UH4_InputListNil_shared; }
function UH4_InputListCons(f0: UH5, f1: UH4): UH4 { return { tag: 1, f0: f0, f1: f1 }; }
type US2_ModelA = { readonly tag: 0 };
type US2_ModelB = { readonly tag: 1 };
type US2_ModelC = { readonly tag: 2 };
type US2 = US2_ModelA | US2_ModelB | US2_ModelC;
const US2_ModelA_shared: US2 = { tag: 0 }; function US2_ModelA(): US2 { return US2_ModelA_shared; }
const US2_ModelB_shared: US2 = { tag: 1 }; function US2_ModelB(): US2 { return US2_ModelB_shared; }
const US2_ModelC_shared: US2 = { tag: 2 }; function US2_ModelC(): US2 { return US2_ModelC_shared; }
type UH6_InputEmpty = { readonly tag: 0 };
type UH6_InputCons = { readonly tag: 1, readonly f0: US2, readonly f1: UH6 };
type UH6 = UH6_InputEmpty | UH6_InputCons;
const UH6_InputEmpty_shared: UH6 = { tag: 0 }; function UH6_InputEmpty(): UH6 { return UH6_InputEmpty_shared; }
function UH6_InputCons(f0: US2, f1: UH6): UH6 { return { tag: 1, f0: f0, f1: f1 }; }
type UH7_RegexEmpty = { readonly tag: 0 };
type UH7_RegexEpsilon = { readonly tag: 1 };
type UH7_RegexChar = { readonly tag: 2, readonly f0: US0 };
type UH7_RegexAlt = { readonly tag: 3, readonly f0: UH7, readonly f1: UH7 };
type UH7_RegexCat = { readonly tag: 4, readonly f0: UH7, readonly f1: UH7 };
type UH7_RegexStar = { readonly tag: 5, readonly f0: UH7 };
type UH7 = UH7_RegexEmpty | UH7_RegexEpsilon | UH7_RegexChar | UH7_RegexAlt | UH7_RegexCat | UH7_RegexStar;
const UH7_RegexEmpty_shared: UH7 = { tag: 0 }; function UH7_RegexEmpty(): UH7 { return UH7_RegexEmpty_shared; }
const UH7_RegexEpsilon_shared: UH7 = { tag: 1 }; function UH7_RegexEpsilon(): UH7 { return UH7_RegexEpsilon_shared; }
function UH7_RegexChar(f0: US0): UH7 { return { tag: 2, f0: f0 }; }
function UH7_RegexAlt(f0: UH7, f1: UH7): UH7 { return { tag: 3, f0: f0, f1: f1 }; }
function UH7_RegexCat(f0: UH7, f1: UH7): UH7 { return { tag: 4, f0: f0, f1: f1 }; }
function UH7_RegexStar(f0: UH7): UH7 { return { tag: 5, f0: f0 }; }
type US3_InventoryDfaAccepted = { readonly tag: 0 };
type US3_InventoryDfaRejected = { readonly tag: 1 };
type US3_InventoryDfaInputOutsideInventory = { readonly tag: 2 };
type US3 = US3_InventoryDfaAccepted | US3_InventoryDfaRejected | US3_InventoryDfaInputOutsideInventory;
const US3_InventoryDfaAccepted_shared: US3 = { tag: 0 }; function US3_InventoryDfaAccepted(): US3 { return US3_InventoryDfaAccepted_shared; }
const US3_InventoryDfaRejected_shared: US3 = { tag: 1 }; function US3_InventoryDfaRejected(): US3 { return US3_InventoryDfaRejected_shared; }
const US3_InventoryDfaInputOutsideInventory_shared: US3 = { tag: 2 }; function US3_InventoryDfaInputOutsideInventory(): US3 { return US3_InventoryDfaInputOutsideInventory_shared; }
type US4_SymbolLess = { readonly tag: 0 };
type US4_SymbolSame = { readonly tag: 1 };
type US4_SymbolGreater = { readonly tag: 2 };
type US4 = US4_SymbolLess | US4_SymbolSame | US4_SymbolGreater;
const US4_SymbolLess_shared: US4 = { tag: 0 }; function US4_SymbolLess(): US4 { return US4_SymbolLess_shared; }
const US4_SymbolSame_shared: US4 = { tag: 1 }; function US4_SymbolSame(): US4 { return US4_SymbolSame_shared; }
const US4_SymbolGreater_shared: US4 = { tag: 2 }; function US4_SymbolGreater(): US4 { return US4_SymbolGreater_shared; }
type US5_Nullable = { readonly tag: 0 };
type US5_NonNullable = { readonly tag: 1 };
type US5 = US5_Nullable | US5_NonNullable;
const US5_Nullable_shared: US5 = { tag: 0 }; function US5_Nullable(): US5 { return US5_Nullable_shared; }
const US5_NonNullable_shared: US5 = { tag: 1 }; function US5_NonNullable(): US5 { return US5_NonNullable_shared; }
type UH8_RegexEmpty = { readonly tag: 0 };
type UH8_RegexEpsilon = { readonly tag: 1 };
type UH8_RegexChar = { readonly tag: 2, readonly f0: US1 };
type UH8_RegexAlt = { readonly tag: 3, readonly f0: UH8, readonly f1: UH8 };
type UH8_RegexCat = { readonly tag: 4, readonly f0: UH8, readonly f1: UH8 };
type UH8_RegexStar = { readonly tag: 5, readonly f0: UH8 };
type UH8 = UH8_RegexEmpty | UH8_RegexEpsilon | UH8_RegexChar | UH8_RegexAlt | UH8_RegexCat | UH8_RegexStar;
const UH8_RegexEmpty_shared: UH8 = { tag: 0 }; function UH8_RegexEmpty(): UH8 { return UH8_RegexEmpty_shared; }
const UH8_RegexEpsilon_shared: UH8 = { tag: 1 }; function UH8_RegexEpsilon(): UH8 { return UH8_RegexEpsilon_shared; }
function UH8_RegexChar(f0: US1): UH8 { return { tag: 2, f0: f0 }; }
function UH8_RegexAlt(f0: UH8, f1: UH8): UH8 { return { tag: 3, f0: f0, f1: f1 }; }
function UH8_RegexCat(f0: UH8, f1: UH8): UH8 { return { tag: 4, f0: f0, f1: f1 }; }
function UH8_RegexStar(f0: UH8): UH8 { return { tag: 5, f0: f0 }; }
function input_singletons_from_symbols_0(v0: UH0): UH1 {
    switch (v0.tag) {
        case 1: {
            const v2: US0 = v0.f0;
            const v3: UH0 = v0.f1;
            let v4: UH1 = input_singletons_from_symbols_0(v3);
            const v5: UH2 = UH2_InputEmpty();
            const v6: UH2 = UH2_InputCons(v2, v5);
            return UH1_InputListCons(v6, v4);
        }
        case 0: {
            return UH1_InputListNil();
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function input_list_append_2(v0: UH1, v1: UH1): UH1 {
    switch (v0.tag) {
        case 1: {
            const v2: UH2 = v0.f0;
            const v3: UH1 = v0.f1;
            let v4: UH1 = input_list_append_2(v3, v1);
            return UH1_InputListCons(v2, v4);
        }
        case 0: {
            return v1;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function input_prepend_symbol_to_corpus_3(v0: US0, v1: UH1): UH1 {
    switch (v1.tag) {
        case 1: {
            const v3: UH2 = v1.f0;
            let v4: UH1 = v1.f1;
            const v5: UH1 = input_prepend_symbol_to_corpus_3(v0, v4);
            const v6: UH2 = UH2_InputCons(v0, v3);
            return UH1_InputListCons(v6, v5);
        }
        case 0: {
            return UH1_InputListNil();
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function input_prepend_symbols_to_corpus_1(v0: UH0, v1: UH1): UH1 {
    switch (v0.tag) {
        case 1: {
            const v3: US0 = v0.f0;
            let v4: UH0 = v0.f1;
            const v5: UH1 = input_prepend_symbol_to_corpus_3(v3, v1);
            const v6: UH1 = input_prepend_symbols_to_corpus_1(v4, v1);
            return input_list_append_2(v5, v6);
        }
        case 0: {
            return UH1_InputListNil();
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function input_singletons_from_symbols_4(v0: UH3): UH4 {
    switch (v0.tag) {
        case 1: {
            const v2: US1 = v0.f0;
            const v3: UH3 = v0.f1;
            let v4: UH4 = input_singletons_from_symbols_4(v3);
            const v5: UH5 = UH5_InputEmpty();
            const v6: UH5 = UH5_InputCons(v2, v5);
            return UH4_InputListCons(v6, v4);
        }
        case 0: {
            return UH4_InputListNil();
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function input_list_append_6(v0: UH4, v1: UH4): UH4 {
    switch (v0.tag) {
        case 1: {
            const v2: UH5 = v0.f0;
            const v3: UH4 = v0.f1;
            let v4: UH4 = input_list_append_6(v3, v1);
            return UH4_InputListCons(v2, v4);
        }
        case 0: {
            return v1;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function input_prepend_symbol_to_corpus_7(v0: US1, v1: UH4): UH4 {
    switch (v1.tag) {
        case 1: {
            const v3: UH5 = v1.f0;
            let v4: UH4 = v1.f1;
            const v5: UH4 = input_prepend_symbol_to_corpus_7(v0, v4);
            const v6: UH5 = UH5_InputCons(v0, v3);
            return UH4_InputListCons(v6, v5);
        }
        case 0: {
            return UH4_InputListNil();
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function input_prepend_symbols_to_corpus_5(v0: UH3, v1: UH4): UH4 {
    switch (v0.tag) {
        case 1: {
            const v3: US1 = v0.f0;
            let v4: UH3 = v0.f1;
            const v5: UH4 = input_prepend_symbol_to_corpus_7(v3, v1);
            const v6: UH4 = input_prepend_symbols_to_corpus_5(v4, v1);
            return input_list_append_6(v5, v6);
        }
        case 0: {
            return UH4_InputListNil();
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function loop_9(v0: number, v1: UH2): US3 {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                const v6: US0 = v1.f0;
                const v7: UH2 = v1.f1;
                let v11: US4;
                switch (v6.tag) {
                    case 1: {
                        v11 = US4_SymbolGreater();
                        break;
                    }
                    case 0: {
                        v11 = US4_SymbolSame();
                        break;
                    }
                    default: throw new Error("Compiler error: unreachable union case.");
                }
                let v12: boolean;
                switch (v11.tag) {
                    case 1: {
                        v12 = true;
                        break;
                    }
                    default: {
                        v12 = false;
                    }
                }
                let v19: number;
                if (v12) {
                    v19 = 0;
                } else {
                    let v16: US4;
                    switch (v6.tag) {
                        case 1: {
                            v16 = US4_SymbolSame();
                            break;
                        }
                        case 0: {
                            v16 = US4_SymbolLess();
                            break;
                        }
                        default: throw new Error("Compiler error: unreachable union case.");
                    }
                    let v17: boolean;
                    switch (v16.tag) {
                        case 1: {
                            v17 = true;
                            break;
                        }
                        default: {
                            v17 = false;
                        }
                    }
                    if (v17) {
                        v19 = 1;
                    } else {
                        v19 = (-1);
                    }
                }
                let v20: boolean = v19 < 0;
                if (v20) {
                    return US3_InventoryDfaInputOutsideInventory();
                } else {
                    const v22: boolean = v0 === 0;
                    let v27: number;
                    if (v22) {
                        const v23: boolean = v19 === 0;
                        if (v23) {
                            v27 = 0;
                        } else {
                            v27 = 1;
                        }
                    } else {
                        const v25: boolean = v19 === 0;
                        if (v25) {
                            v27 = 0;
                        } else {
                            v27 = 1;
                        }
                    }
                    v0 = v27;
                    v1 = v7;
                    continue tail;
                }
                break;
            }
            case 0: {
                const v2: boolean = v0 === 0;
                if (v2) {
                    return US3_InventoryDfaAccepted();
                } else {
                    return US3_InventoryDfaRejected();
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function regex_compare_15(v0: UH7, v1: UH7): US4 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                const v53: UH7 = v0.f0;
                const v54: UH7 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        const v55: UH7 = v1.f0;
                        const v56: UH7 = v1.f1;
                        const v57: US4 = regex_compare_15(v53, v55);
                        switch (v57.tag) {
                            case 1: {
                                v0 = v54;
                                v1 = v56;
                                continue tail;
                            }
                            default: {
                                return v57;
                            }
                        }
                        break;
                    }
                    default: {
                        return US4_SymbolGreater();
                    }
                }
                break;
            }
            case 4: {
                let v28: UH7 = v0.f0;
                const v29: UH7 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        const v34: UH7 = v1.f0;
                        const v35: UH7 = v1.f1;
                        const v36: US4 = regex_compare_15(v28, v34);
                        switch (v36.tag) {
                            case 1: {
                                v0 = v29;
                                v1 = v35;
                                continue tail;
                            }
                            default: {
                                return v36;
                            }
                        }
                        break;
                    }
                    case 2: {
                        const v32: US0 = v1.f0;
                        return US4_SymbolGreater();
                    }
                    case 0: {
                        return US4_SymbolGreater();
                    }
                    case 1: {
                        return US4_SymbolGreater();
                    }
                    default: {
                        return US4_SymbolLess();
                    }
                }
                break;
            }
            case 2: {
                const v10: US0 = v0.f0;
                switch (v1.tag) {
                    case 2: {
                        let v13: US0 = v1.f0;
                        switch (v10.tag) {
                            case 1: {
                                switch (v13.tag) {
                                    case 1: {
                                        return US4_SymbolSame();
                                    }
                                    case 0: {
                                        return US4_SymbolGreater();
                                    }
                                    default: throw new Error("Compiler error: unreachable union case.");
                                }
                                break;
                            }
                            case 0: {
                                switch (v13.tag) {
                                    case 1: {
                                        return US4_SymbolLess();
                                    }
                                    case 0: {
                                        return US4_SymbolSame();
                                    }
                                    default: throw new Error("Compiler error: unreachable union case.");
                                }
                                break;
                            }
                            default: throw new Error("Compiler error: unreachable union case.");
                        }
                        break;
                    }
                    case 0: {
                        return US4_SymbolGreater();
                    }
                    case 1: {
                        return US4_SymbolGreater();
                    }
                    default: {
                        return US4_SymbolLess();
                    }
                }
                break;
            }
            case 0: {
                switch (v1.tag) {
                    case 0: {
                        return US4_SymbolSame();
                    }
                    default: {
                        return US4_SymbolLess();
                    }
                }
                break;
            }
            case 1: {
                switch (v1.tag) {
                    case 0: {
                        return US4_SymbolGreater();
                    }
                    case 1: {
                        return US4_SymbolSame();
                    }
                    default: {
                        return US4_SymbolLess();
                    }
                }
                break;
            }
            case 5: {
                const v44: UH7 = v0.f0;
                switch (v1.tag) {
                    case 3: {
                        const v45: UH7 = v1.f0;
                        let v46: UH7 = v1.f1;
                        return US4_SymbolLess();
                    }
                    case 5: {
                        const v48: UH7 = v1.f0;
                        v0 = v44;
                        v1 = v48;
                        continue tail;
                    }
                    default: {
                        return US4_SymbolGreater();
                    }
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function alt_insert_sorted_14(v0: UH7, v1: UH7): UH7 {
    switch (v1.tag) {
        case 3: {
            const v2: UH7 = v1.f0;
            const v3: UH7 = v1.f1;
            let v4: US4 = regex_compare_15(v0, v2);
            switch (v4.tag) {
                case 2: {
                    const v6: UH7 = alt_insert_sorted_14(v0, v3);
                    return UH7_RegexAlt(v2, v6);
                }
                case 0: {
                    return UH7_RegexAlt(v0, v1);
                }
                case 1: {
                    return v1;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        case 0: {
            return v0;
        }
        default: {
            let v11: US4 = regex_compare_15(v0, v1);
            switch (v11.tag) {
                case 2: {
                    return UH7_RegexAlt(v1, v0);
                }
                case 0: {
                    return UH7_RegexAlt(v0, v1);
                }
                case 1: {
                    return v1;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
        }
    }
}
function make_alt_13(v0: UH7, v1: UH7): UH7 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                const v2: UH7 = v0.f0;
                const v3: UH7 = v0.f1;
                let v4: UH7 = alt_insert_sorted_14(v2, v1);
                v0 = v3;
                v1 = v4;
                continue tail;
            }
            case 0: {
                return v1;
            }
            default: {
                return alt_insert_sorted_14(v0, v1);
            }
        }
    }
}
function regex_equal_17(v0: UH7, v1: UH7): boolean {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                let v18: UH7 = v0.f0;
                let v19: UH7 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        let v20: UH7 = v1.f0;
                        let v21: UH7 = v1.f1;
                        const v22: boolean = regex_equal_17(v18, v20);
                        if (v22) {
                            v0 = v19;
                            v1 = v21;
                            continue tail;
                        } else {
                            return false;
                        }
                        break;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            case 4: {
                let v26: UH7 = v0.f0;
                let v27: UH7 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        let v28: UH7 = v1.f0;
                        const v29: UH7 = v1.f1;
                        let v30: boolean = regex_equal_17(v26, v28);
                        if (v30) {
                            v0 = v27;
                            v1 = v29;
                            continue tail;
                        } else {
                            return false;
                        }
                        break;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            case 2: {
                let v4: US0 = v0.f0;
                switch (v1.tag) {
                    case 2: {
                        const v5: US0 = v1.f0;
                        let v15: US4;
                        switch (v4.tag) {
                            case 1: {
                                switch (v5.tag) {
                                    case 1: {
                                        v15 = US4_SymbolSame();
                                        break;
                                    }
                                    case 0: {
                                        v15 = US4_SymbolGreater();
                                        break;
                                    }
                                    default: throw new Error("Compiler error: unreachable union case.");
                                }
                                break;
                            }
                            case 0: {
                                switch (v5.tag) {
                                    case 1: {
                                        v15 = US4_SymbolLess();
                                        break;
                                    }
                                    case 0: {
                                        v15 = US4_SymbolSame();
                                        break;
                                    }
                                    default: throw new Error("Compiler error: unreachable union case.");
                                }
                                break;
                            }
                            default: throw new Error("Compiler error: unreachable union case.");
                        }
                        switch (v15.tag) {
                            case 1: {
                                return true;
                            }
                            default: {
                                return false;
                            }
                        }
                        break;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            case 0: {
                switch (v1.tag) {
                    case 0: {
                        return true;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            case 1: {
                switch (v1.tag) {
                    case 1: {
                        return true;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            case 5: {
                const v34: UH7 = v0.f0;
                switch (v1.tag) {
                    case 5: {
                        const v35: UH7 = v1.f0;
                        v0 = v34;
                        v1 = v35;
                        continue tail;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function make_cat_16(v0: UH7, v1: UH7): UH7 {
    switch (v0.tag) {
        case 0: {
            return UH7_RegexEmpty();
        }
        default: {
            switch (v1.tag) {
                case 0: {
                    return UH7_RegexEmpty();
                }
                default: {
                    switch (v0.tag) {
                        case 1: {
                            return v1;
                        }
                        default: {
                            switch (v1.tag) {
                                case 1: {
                                    return v0;
                                }
                                default: {
                                    switch (v0.tag) {
                                        case 4: {
                                            let v12: UH7 = v0.f0;
                                            let v13: UH7 = v0.f1;
                                            let v14: UH7 = make_cat_16(v13, v1);
                                            return UH7_RegexCat(v12, v14);
                                        }
                                        case 5: {
                                            let v4: UH7 = v0.f0;
                                            switch (v1.tag) {
                                                case 5: {
                                                    const v5: UH7 = v1.f0;
                                                    const v6: boolean = regex_equal_17(v4, v5);
                                                    if (v6) {
                                                        return UH7_RegexStar(v4);
                                                    } else {
                                                        return UH7_RegexCat(v0, v1);
                                                    }
                                                    break;
                                                }
                                                default: {
                                                    return UH7_RegexCat(v0, v1);
                                                }
                                            }
                                            break;
                                        }
                                        default: {
                                            return UH7_RegexCat(v0, v1);
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
function make_star_18(v0: UH7): UH7 {
    switch (v0.tag) {
        case 0: {
            return UH7_RegexEpsilon();
        }
        case 1: {
            return UH7_RegexEpsilon();
        }
        case 5: {
            const v3: UH7 = v0.f0;
            return UH7_RegexStar(v3);
        }
        default: {
            return UH7_RegexStar(v0);
        }
    }
}
function normalize_12(v0: UH7): UH7 {
    switch (v0.tag) {
        case 3: {
            const v5: UH7 = v0.f0;
            const v6: UH7 = v0.f1;
            const v7: UH7 = normalize_12(v5);
            const v8: UH7 = normalize_12(v6);
            return make_alt_13(v7, v8);
        }
        case 4: {
            const v10: UH7 = v0.f0;
            let v11: UH7 = v0.f1;
            let v12: UH7 = normalize_12(v10);
            let v13: UH7 = normalize_12(v11);
            return make_cat_16(v12, v13);
        }
        case 2: {
            const v3: US0 = v0.f0;
            return UH7_RegexChar(v3);
        }
        case 0: {
            return UH7_RegexEmpty();
        }
        case 1: {
            return UH7_RegexEpsilon();
        }
        case 5: {
            let v15: UH7 = v0.f0;
            let v16: UH7 = normalize_12(v15);
            return make_star_18(v16);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function nullable_20(v0: UH7): US5 {
    switch (v0.tag) {
        case 3: {
            const v5: UH7 = v0.f0;
            const v6: UH7 = v0.f1;
            const v7: US5 = nullable_20(v5);
            const v8: US5 = nullable_20(v6);
            switch (v7.tag) {
                case 0: {
                    return US5_Nullable();
                }
                default: {
                    switch (v8.tag) {
                        case 0: {
                            return US5_Nullable();
                        }
                        default: {
                            switch (v7.tag) {
                                case 1: {
                                    switch (v8.tag) {
                                        case 1: {
                                            return US5_NonNullable();
                                        }
                                        default: throw new Error("Compiler error: unreachable union case.");
                                    }
                                    break;
                                }
                                default: throw new Error("Compiler error: unreachable union case.");
                            }
                        }
                    }
                }
            }
            break;
        }
        case 4: {
            let v16: UH7 = v0.f0;
            let v17: UH7 = v0.f1;
            let v18: US5 = nullable_20(v16);
            let v19: US5 = nullable_20(v17);
            switch (v18.tag) {
                case 0: {
                    switch (v19.tag) {
                        case 0: {
                            return US5_Nullable();
                        }
                        default: {
                            return US5_NonNullable();
                        }
                    }
                    break;
                }
                default: {
                    return US5_NonNullable();
                }
            }
            break;
        }
        case 2: {
            const v3: US0 = v0.f0;
            return US5_NonNullable();
        }
        case 0: {
            return US5_NonNullable();
        }
        case 1: {
            return US5_Nullable();
        }
        case 5: {
            const v25: UH7 = v0.f0;
            return US5_Nullable();
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function derivative_19(v0: UH7, v1: US0): UH7 {
    switch (v0.tag) {
        case 3: {
            let v19: UH7 = v0.f0;
            let v20: UH7 = v0.f1;
            let v21: UH7 = derivative_19(v19, v1);
            const v22: UH7 = derivative_19(v20, v1);
            return make_alt_13(v21, v22);
        }
        case 4: {
            const v24: UH7 = v0.f0;
            const v25: UH7 = v0.f1;
            let v26: US5 = nullable_20(v24);
            switch (v26.tag) {
                case 1: {
                    const v31: UH7 = derivative_19(v24, v1);
                    return make_cat_16(v31, v25);
                }
                case 0: {
                    let v27: UH7 = derivative_19(v24, v1);
                    let v28: UH7 = make_cat_16(v27, v25);
                    const v29: UH7 = derivative_19(v25, v1);
                    return make_alt_13(v28, v29);
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        case 2: {
            let v4: US0 = v0.f0;
            let v14: US4;
            switch (v4.tag) {
                case 1: {
                    switch (v1.tag) {
                        case 1: {
                            v14 = US4_SymbolSame();
                            break;
                        }
                        case 0: {
                            v14 = US4_SymbolGreater();
                            break;
                        }
                        default: throw new Error("Compiler error: unreachable union case.");
                    }
                    break;
                }
                case 0: {
                    switch (v1.tag) {
                        case 1: {
                            v14 = US4_SymbolLess();
                            break;
                        }
                        case 0: {
                            v14 = US4_SymbolSame();
                            break;
                        }
                        default: throw new Error("Compiler error: unreachable union case.");
                    }
                    break;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            let v15: boolean;
            switch (v14.tag) {
                case 1: {
                    v15 = true;
                    break;
                }
                default: {
                    v15 = false;
                }
            }
            if (v15) {
                return UH7_RegexEpsilon();
            } else {
                return UH7_RegexEmpty();
            }
            break;
        }
        case 0: {
            return UH7_RegexEmpty();
        }
        case 1: {
            return UH7_RegexEmpty();
        }
        case 5: {
            const v35: UH7 = v0.f0;
            const v36: UH7 = derivative_19(v35, v1);
            const v37: UH7 = make_star_18(v35);
            return make_cat_16(v36, v37);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function canonical_derivative_11(v0: UH7, v1: US0): UH7 {
    const v2: UH7 = normalize_12(v0);
    const v3: UH7 = derivative_19(v2, v1);
    return normalize_12(v3);
}
function accepts_10(v0: UH7, v1: UH2): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                const v6: US0 = v1.f0;
                const v7: UH2 = v1.f1;
                const v8: UH7 = canonical_derivative_11(v0, v6);
                v0 = v8;
                v1 = v7;
                continue tail;
            }
            case 0: {
                const v2: UH7 = normalize_12(v0);
                const v3: US5 = nullable_20(v2);
                switch (v3.tag) {
                    case 1: {
                        return false;
                    }
                    case 0: {
                        return true;
                    }
                    default: throw new Error("Compiler error: unreachable union case.");
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function loop_8(v0: UH7, v1: UH1): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                const v2: UH2 = v1.f0;
                const v3: UH1 = v1.f1;
                let v4: number = 1;
                const v5: US3 = loop_9(v4, v2);
                let v11: boolean;
                switch (v5.tag) {
                    case 0: {
                        v11 = accepts_10(v0, v2);
                        break;
                    }
                    case 2: {
                        v11 = false;
                        break;
                    }
                    case 1: {
                        const v7: boolean = accepts_10(v0, v2);
                        const v8: boolean = v7 === false;
                        v11 = v8;
                        break;
                    }
                    default: throw new Error("Compiler error: unreachable union case.");
                }
                if (v11) {
                    v1 = v3;
                    continue tail;
                } else {
                    return false;
                }
                break;
            }
            case 0: {
                return true;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function loop_22(v0: number, v1: UH5): US3 {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                const v8: US1 = v1.f0;
                const v9: UH5 = v1.f1;
                let v12: US4;
                switch (v8.tag) {
                    case 0: {
                        v12 = US4_SymbolSame();
                        break;
                    }
                    default: {
                        v12 = US4_SymbolGreater();
                    }
                }
                let v13: boolean;
                switch (v12.tag) {
                    case 1: {
                        v13 = true;
                        break;
                    }
                    default: {
                        v13 = false;
                    }
                }
                let v30: number;
                if (v13) {
                    v30 = 0;
                } else {
                    let v19: US4;
                    switch (v8.tag) {
                        case 0: {
                            v19 = US4_SymbolLess();
                            break;
                        }
                        case 1: {
                            v19 = US4_SymbolSame();
                            break;
                        }
                        case 2: {
                            v19 = US4_SymbolGreater();
                            break;
                        }
                        default: throw new Error("Compiler error: unreachable union case.");
                    }
                    let v20: boolean;
                    switch (v19.tag) {
                        case 1: {
                            v20 = true;
                            break;
                        }
                        default: {
                            v20 = false;
                        }
                    }
                    if (v20) {
                        v30 = 1;
                    } else {
                        let v26: US4;
                        switch (v8.tag) {
                            case 0: {
                                v26 = US4_SymbolLess();
                                break;
                            }
                            case 1: {
                                v26 = US4_SymbolLess();
                                break;
                            }
                            case 2: {
                                v26 = US4_SymbolSame();
                                break;
                            }
                            default: throw new Error("Compiler error: unreachable union case.");
                        }
                        let v27: boolean;
                        switch (v26.tag) {
                            case 1: {
                                v27 = true;
                                break;
                            }
                            default: {
                                v27 = false;
                            }
                        }
                        if (v27) {
                            v30 = 2;
                        } else {
                            v30 = (-1);
                        }
                    }
                }
                const v31: boolean = v30 < 0;
                if (v31) {
                    return US3_InventoryDfaInputOutsideInventory();
                } else {
                    const v33: boolean = v0 === 0;
                    let v46: number;
                    if (v33) {
                        const v34: boolean = v30 === 0;
                        if (v34) {
                            v46 = 0;
                        } else {
                            v46 = 0;
                        }
                    } else {
                        const v37: boolean = v0 === 1;
                        if (v37) {
                            const v38: boolean = v30 === 0;
                            if (v38) {
                                v46 = 0;
                            } else {
                                v46 = 0;
                            }
                        } else {
                            const v41: boolean = v30 === 0;
                            if (v41) {
                                v46 = 2;
                            } else {
                                const v42: boolean = v30 === 1;
                                if (v42) {
                                    v46 = 2;
                                } else {
                                    v46 = 1;
                                }
                            }
                        }
                    }
                    v0 = v46;
                    v1 = v9;
                    continue tail;
                }
                break;
            }
            case 0: {
                const v2: boolean = v0 === 0;
                let v4: boolean;
                if (v2) {
                    v4 = false;
                } else {
                    const v3: boolean = v0 === 1;
                    v4 = v3;
                }
                if (v4) {
                    return US3_InventoryDfaAccepted();
                } else {
                    return US3_InventoryDfaRejected();
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function regex_compare_28(v0: UH8, v1: UH8): US4 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                const v59: UH8 = v0.f0;
                const v60: UH8 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        const v61: UH8 = v1.f0;
                        const v62: UH8 = v1.f1;
                        const v63: US4 = regex_compare_28(v59, v61);
                        switch (v63.tag) {
                            case 1: {
                                v0 = v60;
                                v1 = v62;
                                continue tail;
                            }
                            default: {
                                return v63;
                            }
                        }
                        break;
                    }
                    default: {
                        return US4_SymbolGreater();
                    }
                }
                break;
            }
            case 4: {
                const v34: UH8 = v0.f0;
                const v35: UH8 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        const v40: UH8 = v1.f0;
                        const v41: UH8 = v1.f1;
                        const v42: US4 = regex_compare_28(v34, v40);
                        switch (v42.tag) {
                            case 1: {
                                v0 = v35;
                                v1 = v41;
                                continue tail;
                            }
                            default: {
                                return v42;
                            }
                        }
                        break;
                    }
                    case 2: {
                        const v38: US1 = v1.f0;
                        return US4_SymbolGreater();
                    }
                    case 0: {
                        return US4_SymbolGreater();
                    }
                    case 1: {
                        return US4_SymbolGreater();
                    }
                    default: {
                        return US4_SymbolLess();
                    }
                }
                break;
            }
            case 2: {
                const v10: US1 = v0.f0;
                switch (v1.tag) {
                    case 2: {
                        let v13: US1 = v1.f0;
                        switch (v10.tag) {
                            case 0: {
                                switch (v13.tag) {
                                    case 0: {
                                        return US4_SymbolSame();
                                    }
                                    default: {
                                        return US4_SymbolLess();
                                    }
                                }
                                break;
                            }
                            default: {
                                switch (v13.tag) {
                                    case 0: {
                                        return US4_SymbolGreater();
                                    }
                                    default: {
                                        switch (v10.tag) {
                                            case 1: {
                                                switch (v13.tag) {
                                                    case 1: {
                                                        return US4_SymbolSame();
                                                    }
                                                    case 2: {
                                                        return US4_SymbolLess();
                                                    }
                                                    default: throw new Error("Compiler error: unreachable union case.");
                                                }
                                                break;
                                            }
                                            case 2: {
                                                switch (v13.tag) {
                                                    case 1: {
                                                        return US4_SymbolGreater();
                                                    }
                                                    case 2: {
                                                        return US4_SymbolSame();
                                                    }
                                                    default: throw new Error("Compiler error: unreachable union case.");
                                                }
                                                break;
                                            }
                                            default: throw new Error("Compiler error: unreachable union case.");
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                    case 0: {
                        return US4_SymbolGreater();
                    }
                    case 1: {
                        return US4_SymbolGreater();
                    }
                    default: {
                        return US4_SymbolLess();
                    }
                }
                break;
            }
            case 0: {
                switch (v1.tag) {
                    case 0: {
                        return US4_SymbolSame();
                    }
                    default: {
                        return US4_SymbolLess();
                    }
                }
                break;
            }
            case 1: {
                switch (v1.tag) {
                    case 0: {
                        return US4_SymbolGreater();
                    }
                    case 1: {
                        return US4_SymbolSame();
                    }
                    default: {
                        return US4_SymbolLess();
                    }
                }
                break;
            }
            case 5: {
                const v50: UH8 = v0.f0;
                switch (v1.tag) {
                    case 3: {
                        const v51: UH8 = v1.f0;
                        const v52: UH8 = v1.f1;
                        return US4_SymbolLess();
                    }
                    case 5: {
                        const v54: UH8 = v1.f0;
                        v0 = v50;
                        v1 = v54;
                        continue tail;
                    }
                    default: {
                        return US4_SymbolGreater();
                    }
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function alt_insert_sorted_27(v0: UH8, v1: UH8): UH8 {
    switch (v1.tag) {
        case 3: {
            const v2: UH8 = v1.f0;
            const v3: UH8 = v1.f1;
            let v4: US4 = regex_compare_28(v0, v2);
            switch (v4.tag) {
                case 2: {
                    const v6: UH8 = alt_insert_sorted_27(v0, v3);
                    return UH8_RegexAlt(v2, v6);
                }
                case 0: {
                    return UH8_RegexAlt(v0, v1);
                }
                case 1: {
                    return v1;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        case 0: {
            return v0;
        }
        default: {
            let v11: US4 = regex_compare_28(v0, v1);
            switch (v11.tag) {
                case 2: {
                    return UH8_RegexAlt(v1, v0);
                }
                case 0: {
                    return UH8_RegexAlt(v0, v1);
                }
                case 1: {
                    return v1;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
        }
    }
}
function make_alt_26(v0: UH8, v1: UH8): UH8 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                const v2: UH8 = v0.f0;
                const v3: UH8 = v0.f1;
                let v4: UH8 = alt_insert_sorted_27(v2, v1);
                v0 = v3;
                v1 = v4;
                continue tail;
            }
            case 0: {
                return v1;
            }
            default: {
                return alt_insert_sorted_27(v0, v1);
            }
        }
    }
}
function regex_equal_30(v0: UH8, v1: UH8): boolean {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                const v24: UH8 = v0.f0;
                const v25: UH8 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        let v26: UH8 = v1.f0;
                        let v27: UH8 = v1.f1;
                        let v28: boolean = regex_equal_30(v24, v26);
                        if (v28) {
                            v0 = v25;
                            v1 = v27;
                            continue tail;
                        } else {
                            return false;
                        }
                        break;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            case 4: {
                const v32: UH8 = v0.f0;
                const v33: UH8 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        const v34: UH8 = v1.f0;
                        const v35: UH8 = v1.f1;
                        const v36: boolean = regex_equal_30(v32, v34);
                        if (v36) {
                            v0 = v33;
                            v1 = v35;
                            continue tail;
                        } else {
                            return false;
                        }
                        break;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            case 2: {
                let v4: US1 = v0.f0;
                switch (v1.tag) {
                    case 2: {
                        const v5: US1 = v1.f0;
                        let v21: US4;
                        switch (v4.tag) {
                            case 0: {
                                switch (v5.tag) {
                                    case 0: {
                                        v21 = US4_SymbolSame();
                                        break;
                                    }
                                    default: {
                                        v21 = US4_SymbolLess();
                                    }
                                }
                                break;
                            }
                            default: {
                                switch (v5.tag) {
                                    case 0: {
                                        v21 = US4_SymbolGreater();
                                        break;
                                    }
                                    default: {
                                        switch (v4.tag) {
                                            case 1: {
                                                switch (v5.tag) {
                                                    case 1: {
                                                        v21 = US4_SymbolSame();
                                                        break;
                                                    }
                                                    case 2: {
                                                        v21 = US4_SymbolLess();
                                                        break;
                                                    }
                                                    default: throw new Error("Compiler error: unreachable union case.");
                                                }
                                                break;
                                            }
                                            case 2: {
                                                switch (v5.tag) {
                                                    case 1: {
                                                        v21 = US4_SymbolGreater();
                                                        break;
                                                    }
                                                    case 2: {
                                                        v21 = US4_SymbolSame();
                                                        break;
                                                    }
                                                    default: throw new Error("Compiler error: unreachable union case.");
                                                }
                                                break;
                                            }
                                            default: throw new Error("Compiler error: unreachable union case.");
                                        }
                                    }
                                }
                            }
                        }
                        switch (v21.tag) {
                            case 1: {
                                return true;
                            }
                            default: {
                                return false;
                            }
                        }
                        break;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            case 0: {
                switch (v1.tag) {
                    case 0: {
                        return true;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            case 1: {
                switch (v1.tag) {
                    case 1: {
                        return true;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            case 5: {
                const v40: UH8 = v0.f0;
                switch (v1.tag) {
                    case 5: {
                        const v41: UH8 = v1.f0;
                        v0 = v40;
                        v1 = v41;
                        continue tail;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function make_cat_29(v0: UH8, v1: UH8): UH8 {
    switch (v0.tag) {
        case 0: {
            return UH8_RegexEmpty();
        }
        default: {
            switch (v1.tag) {
                case 0: {
                    return UH8_RegexEmpty();
                }
                default: {
                    switch (v0.tag) {
                        case 1: {
                            return v1;
                        }
                        default: {
                            switch (v1.tag) {
                                case 1: {
                                    return v0;
                                }
                                default: {
                                    switch (v0.tag) {
                                        case 4: {
                                            let v12: UH8 = v0.f0;
                                            let v13: UH8 = v0.f1;
                                            let v14: UH8 = make_cat_29(v13, v1);
                                            return UH8_RegexCat(v12, v14);
                                        }
                                        case 5: {
                                            let v4: UH8 = v0.f0;
                                            switch (v1.tag) {
                                                case 5: {
                                                    const v5: UH8 = v1.f0;
                                                    const v6: boolean = regex_equal_30(v4, v5);
                                                    if (v6) {
                                                        return UH8_RegexStar(v4);
                                                    } else {
                                                        return UH8_RegexCat(v0, v1);
                                                    }
                                                    break;
                                                }
                                                default: {
                                                    return UH8_RegexCat(v0, v1);
                                                }
                                            }
                                            break;
                                        }
                                        default: {
                                            return UH8_RegexCat(v0, v1);
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
function make_star_31(v0: UH8): UH8 {
    switch (v0.tag) {
        case 0: {
            return UH8_RegexEpsilon();
        }
        case 1: {
            return UH8_RegexEpsilon();
        }
        case 5: {
            const v3: UH8 = v0.f0;
            return UH8_RegexStar(v3);
        }
        default: {
            return UH8_RegexStar(v0);
        }
    }
}
function normalize_25(v0: UH8): UH8 {
    switch (v0.tag) {
        case 3: {
            const v5: UH8 = v0.f0;
            const v6: UH8 = v0.f1;
            const v7: UH8 = normalize_25(v5);
            const v8: UH8 = normalize_25(v6);
            return make_alt_26(v7, v8);
        }
        case 4: {
            const v10: UH8 = v0.f0;
            let v11: UH8 = v0.f1;
            let v12: UH8 = normalize_25(v10);
            let v13: UH8 = normalize_25(v11);
            return make_cat_29(v12, v13);
        }
        case 2: {
            const v3: US1 = v0.f0;
            return UH8_RegexChar(v3);
        }
        case 0: {
            return UH8_RegexEmpty();
        }
        case 1: {
            return UH8_RegexEpsilon();
        }
        case 5: {
            let v15: UH8 = v0.f0;
            let v16: UH8 = normalize_25(v15);
            return make_star_31(v16);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function nullable_33(v0: UH8): US5 {
    switch (v0.tag) {
        case 3: {
            const v5: UH8 = v0.f0;
            const v6: UH8 = v0.f1;
            const v7: US5 = nullable_33(v5);
            const v8: US5 = nullable_33(v6);
            switch (v7.tag) {
                case 0: {
                    return US5_Nullable();
                }
                default: {
                    switch (v8.tag) {
                        case 0: {
                            return US5_Nullable();
                        }
                        default: {
                            switch (v7.tag) {
                                case 1: {
                                    switch (v8.tag) {
                                        case 1: {
                                            return US5_NonNullable();
                                        }
                                        default: throw new Error("Compiler error: unreachable union case.");
                                    }
                                    break;
                                }
                                default: throw new Error("Compiler error: unreachable union case.");
                            }
                        }
                    }
                }
            }
            break;
        }
        case 4: {
            let v16: UH8 = v0.f0;
            let v17: UH8 = v0.f1;
            let v18: US5 = nullable_33(v16);
            let v19: US5 = nullable_33(v17);
            switch (v18.tag) {
                case 0: {
                    switch (v19.tag) {
                        case 0: {
                            return US5_Nullable();
                        }
                        default: {
                            return US5_NonNullable();
                        }
                    }
                    break;
                }
                default: {
                    return US5_NonNullable();
                }
            }
            break;
        }
        case 2: {
            const v3: US1 = v0.f0;
            return US5_NonNullable();
        }
        case 0: {
            return US5_NonNullable();
        }
        case 1: {
            return US5_Nullable();
        }
        case 5: {
            const v25: UH8 = v0.f0;
            return US5_Nullable();
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function derivative_32(v0: UH8, v1: US1): UH8 {
    switch (v0.tag) {
        case 3: {
            const v25: UH8 = v0.f0;
            let v26: UH8 = v0.f1;
            let v27: UH8 = derivative_32(v25, v1);
            let v28: UH8 = derivative_32(v26, v1);
            return make_alt_26(v27, v28);
        }
        case 4: {
            let v30: UH8 = v0.f0;
            const v31: UH8 = v0.f1;
            const v32: US5 = nullable_33(v30);
            switch (v32.tag) {
                case 1: {
                    const v37: UH8 = derivative_32(v30, v1);
                    return make_cat_29(v37, v31);
                }
                case 0: {
                    const v33: UH8 = derivative_32(v30, v1);
                    const v34: UH8 = make_cat_29(v33, v31);
                    const v35: UH8 = derivative_32(v31, v1);
                    return make_alt_26(v34, v35);
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        case 2: {
            let v4: US1 = v0.f0;
            let v20: US4;
            switch (v4.tag) {
                case 0: {
                    switch (v1.tag) {
                        case 0: {
                            v20 = US4_SymbolSame();
                            break;
                        }
                        default: {
                            v20 = US4_SymbolLess();
                        }
                    }
                    break;
                }
                default: {
                    switch (v1.tag) {
                        case 0: {
                            v20 = US4_SymbolGreater();
                            break;
                        }
                        default: {
                            switch (v4.tag) {
                                case 1: {
                                    switch (v1.tag) {
                                        case 1: {
                                            v20 = US4_SymbolSame();
                                            break;
                                        }
                                        case 2: {
                                            v20 = US4_SymbolLess();
                                            break;
                                        }
                                        default: throw new Error("Compiler error: unreachable union case.");
                                    }
                                    break;
                                }
                                case 2: {
                                    switch (v1.tag) {
                                        case 1: {
                                            v20 = US4_SymbolGreater();
                                            break;
                                        }
                                        case 2: {
                                            v20 = US4_SymbolSame();
                                            break;
                                        }
                                        default: throw new Error("Compiler error: unreachable union case.");
                                    }
                                    break;
                                }
                                default: throw new Error("Compiler error: unreachable union case.");
                            }
                        }
                    }
                }
            }
            let v21: boolean;
            switch (v20.tag) {
                case 1: {
                    v21 = true;
                    break;
                }
                default: {
                    v21 = false;
                }
            }
            if (v21) {
                return UH8_RegexEpsilon();
            } else {
                return UH8_RegexEmpty();
            }
            break;
        }
        case 0: {
            return UH8_RegexEmpty();
        }
        case 1: {
            return UH8_RegexEmpty();
        }
        case 5: {
            const v41: UH8 = v0.f0;
            const v42: UH8 = derivative_32(v41, v1);
            const v43: UH8 = make_star_31(v41);
            return make_cat_29(v42, v43);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function canonical_derivative_24(v0: UH8, v1: US1): UH8 {
    const v2: UH8 = normalize_25(v0);
    const v3: UH8 = derivative_32(v2, v1);
    return normalize_25(v3);
}
function accepts_23(v0: UH8, v1: UH5): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                const v6: US1 = v1.f0;
                const v7: UH5 = v1.f1;
                const v8: UH8 = canonical_derivative_24(v0, v6);
                v0 = v8;
                v1 = v7;
                continue tail;
            }
            case 0: {
                const v2: UH8 = normalize_25(v0);
                const v3: US5 = nullable_33(v2);
                switch (v3.tag) {
                    case 1: {
                        return false;
                    }
                    case 0: {
                        return true;
                    }
                    default: throw new Error("Compiler error: unreachable union case.");
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function loop_21(v0: UH8, v1: UH4): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                const v2: UH5 = v1.f0;
                const v3: UH4 = v1.f1;
                let v4: number = 2;
                const v5: US3 = loop_22(v4, v2);
                let v11: boolean;
                switch (v5.tag) {
                    case 0: {
                        v11 = accepts_23(v0, v2);
                        break;
                    }
                    case 2: {
                        v11 = false;
                        break;
                    }
                    case 1: {
                        const v7: boolean = accepts_23(v0, v2);
                        const v8: boolean = v7 === false;
                        v11 = v8;
                        break;
                    }
                    default: throw new Error("Compiler error: unreachable union case.");
                }
                if (v11) {
                    v1 = v3;
                    continue tail;
                } else {
                    return false;
                }
                break;
            }
            case 0: {
                return true;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function loop_34(v0: number, v1: UH6): US3 {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                const v7: US2 = v1.f0;
                const v8: UH6 = v1.f1;
                let v11: US4;
                switch (v7.tag) {
                    case 0: {
                        v11 = US4_SymbolSame();
                        break;
                    }
                    default: {
                        v11 = US4_SymbolGreater();
                    }
                }
                let v12: boolean;
                switch (v11.tag) {
                    case 1: {
                        v12 = true;
                        break;
                    }
                    default: {
                        v12 = false;
                    }
                }
                let v21: number;
                if (v12) {
                    v21 = 0;
                } else {
                    let v18: US4;
                    switch (v7.tag) {
                        case 0: {
                            v18 = US4_SymbolLess();
                            break;
                        }
                        case 1: {
                            v18 = US4_SymbolSame();
                            break;
                        }
                        case 2: {
                            v18 = US4_SymbolGreater();
                            break;
                        }
                        default: throw new Error("Compiler error: unreachable union case.");
                    }
                    let v19: boolean;
                    switch (v18.tag) {
                        case 1: {
                            v19 = true;
                            break;
                        }
                        default: {
                            v19 = false;
                        }
                    }
                    if (v19) {
                        v21 = 1;
                    } else {
                        v21 = (-1);
                    }
                }
                const v22: boolean = v21 < 0;
                if (v22) {
                    return US3_InventoryDfaInputOutsideInventory();
                } else {
                    const v24: boolean = v0 === 0;
                    let v28: number;
                    if (v24) {
                        v28 = 0;
                    } else {
                        let v26: boolean = v21 === 0;
                        if (v26) {
                            v28 = 1;
                        } else {
                            v28 = 0;
                        }
                    }
                    v0 = v28;
                    v1 = v8;
                    continue tail;
                }
                break;
            }
            case 0: {
                const v2: boolean = v0 === 0;
                const v3: boolean = v2 === false;
                if (v3) {
                    return US3_InventoryDfaAccepted();
                } else {
                    return US3_InventoryDfaRejected();
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
export function main(): number {
    let v0: US0 = US0_BitZero();
    let v1: US0 = US0_BitOne();
    const v2: UH0 = UH0_SymbolListNil();
    const v3: UH0 = UH0_SymbolListCons(v1, v2);
    let v4: UH0 = UH0_SymbolListCons(v0, v3);
    const v5: UH1 = input_singletons_from_symbols_0(v4);
    const v6: UH2 = UH2_InputEmpty();
    const v7: UH1 = UH1_InputListCons(v6, v5);
    const v8: US0 = US0_BitZero();
    const v9: US0 = US0_BitOne();
    const v10: UH0 = UH0_SymbolListNil();
    let v11: UH0 = UH0_SymbolListCons(v9, v10);
    let v12: UH0 = UH0_SymbolListCons(v8, v11);
    let v13: US0 = US0_BitZero();
    let v14: US0 = US0_BitOne();
    let v15: UH0 = UH0_SymbolListNil();
    let v16: UH0 = UH0_SymbolListCons(v14, v15);
    let v17: UH0 = UH0_SymbolListCons(v13, v16);
    let v18: UH1 = input_singletons_from_symbols_0(v17);
    let v19: UH1 = input_prepend_symbols_to_corpus_1(v12, v18);
    let v20: UH1 = input_list_append_2(v7, v19);
    let v21: US1 = US1_TriA();
    const v22: US1 = US1_TriB();
    const v23: US1 = US1_TriC();
    const v24: UH3 = UH3_SymbolListNil();
    const v25: UH3 = UH3_SymbolListCons(v23, v24);
    let v26: UH3 = UH3_SymbolListCons(v22, v25);
    let v27: UH3 = UH3_SymbolListCons(v21, v26);
    let v28: UH4 = input_singletons_from_symbols_4(v27);
    const v29: UH5 = UH5_InputEmpty();
    let v30: UH4 = UH4_InputListCons(v29, v28);
    const v31: US1 = US1_TriA();
    const v32: US1 = US1_TriB();
    const v33: US1 = US1_TriC();
    const v34: UH3 = UH3_SymbolListNil();
    const v35: UH3 = UH3_SymbolListCons(v33, v34);
    const v36: UH3 = UH3_SymbolListCons(v32, v35);
    const v37: UH3 = UH3_SymbolListCons(v31, v36);
    const v38: US1 = US1_TriA();
    const v39: US1 = US1_TriB();
    const v40: US1 = US1_TriC();
    const v41: UH3 = UH3_SymbolListNil();
    const v42: UH3 = UH3_SymbolListCons(v40, v41);
    const v43: UH3 = UH3_SymbolListCons(v39, v42);
    const v44: UH3 = UH3_SymbolListCons(v38, v43);
    const v45: UH4 = input_singletons_from_symbols_4(v44);
    let v46: UH4 = input_prepend_symbols_to_corpus_5(v37, v45);
    const v47: UH4 = input_list_append_6(v30, v46);
    const v48: US2 = US2_ModelC();
    const v49: UH6 = UH6_InputEmpty();
    const v50: UH6 = UH6_InputCons(v48, v49);
    const v51: US0 = US0_BitZero();
    const v52: UH7 = UH7_RegexChar(v51);
    const v53: US0 = US0_BitOne();
    const v54: UH7 = UH7_RegexChar(v53);
    const v55: UH7 = UH7_RegexAlt(v52, v54);
    const v56: UH7 = UH7_RegexStar(v55);
    const v57: US0 = US0_BitZero();
    const v58: UH7 = UH7_RegexChar(v57);
    const v59: UH7 = UH7_RegexCat(v56, v58);
    const v60: boolean = loop_8(v59, v20);
    let v75: boolean;
    if (v60) {
        const v61: US1 = US1_TriA();
        const v62: UH8 = UH8_RegexChar(v61);
        const v63: US1 = US1_TriB();
        const v64: UH8 = UH8_RegexChar(v63);
        const v65: UH8 = UH8_RegexAlt(v62, v64);
        const v66: UH8 = UH8_RegexStar(v65);
        const v67: US1 = US1_TriC();
        const v68: UH8 = UH8_RegexChar(v67);
        const v69: UH8 = UH8_RegexCat(v66, v68);
        const v70: boolean = loop_21(v69, v47);
        if (v70) {
            const v71: number = 1;
            const v72: US3 = loop_34(v71, v50);
            switch (v72.tag) {
                case 2: {
                    v75 = true;
                    break;
                }
                default: {
                    v75 = false;
                }
            }
        } else {
            v75 = false;
        }
    } else {
        v75 = false;
    }
    if (v75) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
