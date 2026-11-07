type US0_BitZero = { readonly tag: 0 };
type US0_BitOne = { readonly tag: 1 };
type US0 = US0_BitZero | US0_BitOne;
const US0_BitZero_shared: US0 = { tag: 0 }; function US0_BitZero(): US0 { return US0_BitZero_shared; }
const US0_BitOne_shared: US0 = { tag: 1 }; function US0_BitOne(): US0 { return US0_BitOne_shared; }
type UH0_RegexEmpty = { readonly tag: 0 };
type UH0_RegexEpsilon = { readonly tag: 1 };
type UH0_RegexChar = { readonly tag: 2, readonly f0: US0 };
type UH0_RegexAlt = { readonly tag: 3, readonly f0: UH0, readonly f1: UH0 };
type UH0_RegexCat = { readonly tag: 4, readonly f0: UH0, readonly f1: UH0 };
type UH0_RegexStar = { readonly tag: 5, readonly f0: UH0 };
type UH0 = UH0_RegexEmpty | UH0_RegexEpsilon | UH0_RegexChar | UH0_RegexAlt | UH0_RegexCat | UH0_RegexStar;
const UH0_RegexEmpty_shared: UH0 = { tag: 0 }; function UH0_RegexEmpty(): UH0 { return UH0_RegexEmpty_shared; }
const UH0_RegexEpsilon_shared: UH0 = { tag: 1 }; function UH0_RegexEpsilon(): UH0 { return UH0_RegexEpsilon_shared; }
function UH0_RegexChar(f0: US0): UH0 { return { tag: 2, f0: f0 }; }
function UH0_RegexAlt(f0: UH0, f1: UH0): UH0 { return { tag: 3, f0: f0, f1: f1 }; }
function UH0_RegexCat(f0: UH0, f1: UH0): UH0 { return { tag: 4, f0: f0, f1: f1 }; }
function UH0_RegexStar(f0: UH0): UH0 { return { tag: 5, f0: f0 }; }
type UH1_InputEmpty = { readonly tag: 0 };
type UH1_InputCons = { readonly tag: 1, readonly f0: US0, readonly f1: UH1 };
type UH1 = UH1_InputEmpty | UH1_InputCons;
const UH1_InputEmpty_shared: UH1 = { tag: 0 }; function UH1_InputEmpty(): UH1 { return UH1_InputEmpty_shared; }
function UH1_InputCons(f0: US0, f1: UH1): UH1 { return { tag: 1, f0: f0, f1: f1 }; }
type US1_SymbolLess = { readonly tag: 0 };
type US1_SymbolSame = { readonly tag: 1 };
type US1_SymbolGreater = { readonly tag: 2 };
type US1 = US1_SymbolLess | US1_SymbolSame | US1_SymbolGreater;
const US1_SymbolLess_shared: US1 = { tag: 0 }; function US1_SymbolLess(): US1 { return US1_SymbolLess_shared; }
const US1_SymbolSame_shared: US1 = { tag: 1 }; function US1_SymbolSame(): US1 { return US1_SymbolSame_shared; }
const US1_SymbolGreater_shared: US1 = { tag: 2 }; function US1_SymbolGreater(): US1 { return US1_SymbolGreater_shared; }
type US2_Nullable = { readonly tag: 0 };
type US2_NonNullable = { readonly tag: 1 };
type US2 = US2_Nullable | US2_NonNullable;
const US2_Nullable_shared: US2 = { tag: 0 }; function US2_Nullable(): US2 { return US2_Nullable_shared; }
const US2_NonNullable_shared: US2 = { tag: 1 }; function US2_NonNullable(): US2 { return US2_NonNullable_shared; }
type US3_TriA = { readonly tag: 0 };
type US3_TriB = { readonly tag: 1 };
type US3_TriC = { readonly tag: 2 };
type US3 = US3_TriA | US3_TriB | US3_TriC;
const US3_TriA_shared: US3 = { tag: 0 }; function US3_TriA(): US3 { return US3_TriA_shared; }
const US3_TriB_shared: US3 = { tag: 1 }; function US3_TriB(): US3 { return US3_TriB_shared; }
const US3_TriC_shared: US3 = { tag: 2 }; function US3_TriC(): US3 { return US3_TriC_shared; }
type UH2_RegexEmpty = { readonly tag: 0 };
type UH2_RegexEpsilon = { readonly tag: 1 };
type UH2_RegexChar = { readonly tag: 2, readonly f0: US3 };
type UH2_RegexAlt = { readonly tag: 3, readonly f0: UH2, readonly f1: UH2 };
type UH2_RegexCat = { readonly tag: 4, readonly f0: UH2, readonly f1: UH2 };
type UH2_RegexStar = { readonly tag: 5, readonly f0: UH2 };
type UH2 = UH2_RegexEmpty | UH2_RegexEpsilon | UH2_RegexChar | UH2_RegexAlt | UH2_RegexCat | UH2_RegexStar;
const UH2_RegexEmpty_shared: UH2 = { tag: 0 }; function UH2_RegexEmpty(): UH2 { return UH2_RegexEmpty_shared; }
const UH2_RegexEpsilon_shared: UH2 = { tag: 1 }; function UH2_RegexEpsilon(): UH2 { return UH2_RegexEpsilon_shared; }
function UH2_RegexChar(f0: US3): UH2 { return { tag: 2, f0: f0 }; }
function UH2_RegexAlt(f0: UH2, f1: UH2): UH2 { return { tag: 3, f0: f0, f1: f1 }; }
function UH2_RegexCat(f0: UH2, f1: UH2): UH2 { return { tag: 4, f0: f0, f1: f1 }; }
function UH2_RegexStar(f0: UH2): UH2 { return { tag: 5, f0: f0 }; }
type UH3_InputEmpty = { readonly tag: 0 };
type UH3_InputCons = { readonly tag: 1, readonly f0: US3, readonly f1: UH3 };
type UH3 = UH3_InputEmpty | UH3_InputCons;
const UH3_InputEmpty_shared: UH3 = { tag: 0 }; function UH3_InputEmpty(): UH3 { return UH3_InputEmpty_shared; }
function UH3_InputCons(f0: US3, f1: UH3): UH3 { return { tag: 1, f0: f0, f1: f1 }; }
function random_bit_input_1(v0: bigint, v1: number, v2: UH1): [UH1, bigint] {
    tail: while (true) {
        let v3: boolean = 0 < v1;
        if (v3) {
            let v4: bigint = BigInt.asUintN(64, v0 * 1103515245n);
            const v5: bigint = BigInt.asUintN(64, v4 + 12345n);
            const v6: bigint = v5 & 2147483647n;
            const v7: number = (v1 - 1) | 0;
            const v8: bigint = v6 >> BigInt(16 & 63);
            const v9: bigint = v8 & 1n;
            let v10: boolean = v9 === 0n;
            let v13: US0;
            if (v10) {
                let v11: US0 = US0_BitZero();
                v13 = v11;
            } else {
                const v12: US0 = US0_BitOne();
                v13 = v12;
            }
            let v14: UH1 = UH1_InputCons(v13, v2);
            v0 = v6;
            v1 = v7;
            v2 = v14;
            continue tail;
        } else {
            return [v2, v0];
        }
    }
}
function run_2(v0: number, v1: UH1): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                let v4: US0 = v1.f0;
                const v5: UH1 = v1.f1;
                const v6: boolean = v0 === 0;
                let v19: number;
                if (v6) {
                    let v10: US1;
                    switch (v4.tag) {
                        case 1: {
                            v10 = US1_SymbolGreater();
                            break;
                        }
                        case 0: {
                            v10 = US1_SymbolSame();
                            break;
                        }
                        default: throw new Error("Compiler error: unreachable union case.");
                    }
                    let v11: boolean;
                    switch (v10.tag) {
                        case 1: {
                            v11 = true;
                            break;
                        }
                        default: {
                            v11 = false;
                        }
                    }
                    if (v11) {
                        v19 = 1;
                    } else {
                        v19 = 0;
                    }
                } else {
                    let v16: US1;
                    switch (v4.tag) {
                        case 1: {
                            v16 = US1_SymbolGreater();
                            break;
                        }
                        case 0: {
                            v16 = US1_SymbolSame();
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
                        v19 = 0;
                    }
                }
                v0 = v19;
                v1 = v5;
                continue tail;
            }
            case 0: {
                let v2: boolean = v0 === 0;
                let v3: boolean = v2 === false;
                return v3;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function regex_compare_8(v0: UH0, v1: UH0): US1 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                const v53: UH0 = v0.f0;
                const v54: UH0 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        const v55: UH0 = v1.f0;
                        const v56: UH0 = v1.f1;
                        const v57: US1 = regex_compare_8(v53, v55);
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
                        return US1_SymbolGreater();
                    }
                }
                break;
            }
            case 4: {
                let v28: UH0 = v0.f0;
                const v29: UH0 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        const v34: UH0 = v1.f0;
                        const v35: UH0 = v1.f1;
                        let v36: US1 = regex_compare_8(v28, v34);
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
                        return US1_SymbolGreater();
                    }
                    case 0: {
                        return US1_SymbolGreater();
                    }
                    case 1: {
                        return US1_SymbolGreater();
                    }
                    default: {
                        return US1_SymbolLess();
                    }
                }
                break;
            }
            case 2: {
                let v10: US0 = v0.f0;
                switch (v1.tag) {
                    case 2: {
                        let v13: US0 = v1.f0;
                        switch (v10.tag) {
                            case 1: {
                                switch (v13.tag) {
                                    case 1: {
                                        return US1_SymbolSame();
                                    }
                                    case 0: {
                                        return US1_SymbolGreater();
                                    }
                                    default: throw new Error("Compiler error: unreachable union case.");
                                }
                                break;
                            }
                            case 0: {
                                switch (v13.tag) {
                                    case 1: {
                                        return US1_SymbolLess();
                                    }
                                    case 0: {
                                        return US1_SymbolSame();
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
                        return US1_SymbolGreater();
                    }
                    case 1: {
                        return US1_SymbolGreater();
                    }
                    default: {
                        return US1_SymbolLess();
                    }
                }
                break;
            }
            case 0: {
                switch (v1.tag) {
                    case 0: {
                        return US1_SymbolSame();
                    }
                    default: {
                        return US1_SymbolLess();
                    }
                }
                break;
            }
            case 1: {
                switch (v1.tag) {
                    case 0: {
                        return US1_SymbolGreater();
                    }
                    case 1: {
                        return US1_SymbolSame();
                    }
                    default: {
                        return US1_SymbolLess();
                    }
                }
                break;
            }
            case 5: {
                const v44: UH0 = v0.f0;
                switch (v1.tag) {
                    case 3: {
                        const v45: UH0 = v1.f0;
                        const v46: UH0 = v1.f1;
                        return US1_SymbolLess();
                    }
                    case 5: {
                        const v48: UH0 = v1.f0;
                        v0 = v44;
                        v1 = v48;
                        continue tail;
                    }
                    default: {
                        return US1_SymbolGreater();
                    }
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function alt_insert_sorted_7(v0: UH0, v1: UH0): UH0 {
    switch (v1.tag) {
        case 3: {
            let v2: UH0 = v1.f0;
            let v3: UH0 = v1.f1;
            let v4: US1 = regex_compare_8(v0, v2);
            switch (v4.tag) {
                case 2: {
                    const v6: UH0 = alt_insert_sorted_7(v0, v3);
                    return UH0_RegexAlt(v2, v6);
                }
                case 0: {
                    return UH0_RegexAlt(v0, v1);
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
            let v11: US1 = regex_compare_8(v0, v1);
            switch (v11.tag) {
                case 2: {
                    return UH0_RegexAlt(v1, v0);
                }
                case 0: {
                    return UH0_RegexAlt(v0, v1);
                }
                case 1: {
                    return v1;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
        }
    }
}
function make_alt_6(v0: UH0, v1: UH0): UH0 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                let v2: UH0 = v0.f0;
                let v3: UH0 = v0.f1;
                let v4: UH0 = alt_insert_sorted_7(v2, v1);
                v0 = v3;
                v1 = v4;
                continue tail;
            }
            case 0: {
                return v1;
            }
            default: {
                return alt_insert_sorted_7(v0, v1);
            }
        }
    }
}
function regex_equal_10(v0: UH0, v1: UH0): boolean {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                let v18: UH0 = v0.f0;
                let v19: UH0 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        let v20: UH0 = v1.f0;
                        let v21: UH0 = v1.f1;
                        let v22: boolean = regex_equal_10(v18, v20);
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
                let v26: UH0 = v0.f0;
                const v27: UH0 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        let v28: UH0 = v1.f0;
                        const v29: UH0 = v1.f1;
                        const v30: boolean = regex_equal_10(v26, v28);
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
                        let v15: US1;
                        switch (v4.tag) {
                            case 1: {
                                switch (v5.tag) {
                                    case 1: {
                                        v15 = US1_SymbolSame();
                                        break;
                                    }
                                    case 0: {
                                        v15 = US1_SymbolGreater();
                                        break;
                                    }
                                    default: throw new Error("Compiler error: unreachable union case.");
                                }
                                break;
                            }
                            case 0: {
                                switch (v5.tag) {
                                    case 1: {
                                        v15 = US1_SymbolLess();
                                        break;
                                    }
                                    case 0: {
                                        v15 = US1_SymbolSame();
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
                const v34: UH0 = v0.f0;
                switch (v1.tag) {
                    case 5: {
                        const v35: UH0 = v1.f0;
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
function make_cat_9(v0: UH0, v1: UH0): UH0 {
    switch (v0.tag) {
        case 0: {
            return UH0_RegexEmpty();
        }
        default: {
            switch (v1.tag) {
                case 0: {
                    return UH0_RegexEmpty();
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
                                            const v12: UH0 = v0.f0;
                                            let v13: UH0 = v0.f1;
                                            let v14: UH0 = make_cat_9(v13, v1);
                                            return UH0_RegexCat(v12, v14);
                                        }
                                        case 5: {
                                            let v4: UH0 = v0.f0;
                                            switch (v1.tag) {
                                                case 5: {
                                                    const v5: UH0 = v1.f0;
                                                    const v6: boolean = regex_equal_10(v4, v5);
                                                    if (v6) {
                                                        return UH0_RegexStar(v4);
                                                    } else {
                                                        return UH0_RegexCat(v0, v1);
                                                    }
                                                    break;
                                                }
                                                default: {
                                                    return UH0_RegexCat(v0, v1);
                                                }
                                            }
                                            break;
                                        }
                                        default: {
                                            return UH0_RegexCat(v0, v1);
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
function make_star_11(v0: UH0): UH0 {
    switch (v0.tag) {
        case 0: {
            return UH0_RegexEpsilon();
        }
        case 1: {
            return UH0_RegexEpsilon();
        }
        case 5: {
            let v3: UH0 = v0.f0;
            return UH0_RegexStar(v3);
        }
        default: {
            return UH0_RegexStar(v0);
        }
    }
}
function normalize_5(v0: UH0): UH0 {
    switch (v0.tag) {
        case 3: {
            const v5: UH0 = v0.f0;
            const v6: UH0 = v0.f1;
            const v7: UH0 = normalize_5(v5);
            const v8: UH0 = normalize_5(v6);
            return make_alt_6(v7, v8);
        }
        case 4: {
            let v10: UH0 = v0.f0;
            let v11: UH0 = v0.f1;
            const v12: UH0 = normalize_5(v10);
            let v13: UH0 = normalize_5(v11);
            return make_cat_9(v12, v13);
        }
        case 2: {
            let v3: US0 = v0.f0;
            return UH0_RegexChar(v3);
        }
        case 0: {
            return UH0_RegexEmpty();
        }
        case 1: {
            return UH0_RegexEpsilon();
        }
        case 5: {
            let v15: UH0 = v0.f0;
            let v16: UH0 = normalize_5(v15);
            return make_star_11(v16);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function nullable_13(v0: UH0): US2 {
    switch (v0.tag) {
        case 3: {
            const v5: UH0 = v0.f0;
            const v6: UH0 = v0.f1;
            const v7: US2 = nullable_13(v5);
            const v8: US2 = nullable_13(v6);
            switch (v7.tag) {
                case 0: {
                    return US2_Nullable();
                }
                default: {
                    switch (v8.tag) {
                        case 0: {
                            return US2_Nullable();
                        }
                        default: {
                            switch (v7.tag) {
                                case 1: {
                                    switch (v8.tag) {
                                        case 1: {
                                            return US2_NonNullable();
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
            let v16: UH0 = v0.f0;
            let v17: UH0 = v0.f1;
            let v18: US2 = nullable_13(v16);
            let v19: US2 = nullable_13(v17);
            switch (v18.tag) {
                case 0: {
                    switch (v19.tag) {
                        case 0: {
                            return US2_Nullable();
                        }
                        default: {
                            return US2_NonNullable();
                        }
                    }
                    break;
                }
                default: {
                    return US2_NonNullable();
                }
            }
            break;
        }
        case 2: {
            let v3: US0 = v0.f0;
            return US2_NonNullable();
        }
        case 0: {
            return US2_NonNullable();
        }
        case 1: {
            return US2_Nullable();
        }
        case 5: {
            let v25: UH0 = v0.f0;
            return US2_Nullable();
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function derivative_12(v0: UH0, v1: US0): UH0 {
    switch (v0.tag) {
        case 3: {
            let v19: UH0 = v0.f0;
            let v20: UH0 = v0.f1;
            let v21: UH0 = derivative_12(v19, v1);
            let v22: UH0 = derivative_12(v20, v1);
            return make_alt_6(v21, v22);
        }
        case 4: {
            let v24: UH0 = v0.f0;
            let v25: UH0 = v0.f1;
            let v26: US2 = nullable_13(v24);
            switch (v26.tag) {
                case 1: {
                    const v31: UH0 = derivative_12(v24, v1);
                    return make_cat_9(v31, v25);
                }
                case 0: {
                    const v27: UH0 = derivative_12(v24, v1);
                    let v28: UH0 = make_cat_9(v27, v25);
                    const v29: UH0 = derivative_12(v25, v1);
                    return make_alt_6(v28, v29);
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        case 2: {
            let v4: US0 = v0.f0;
            let v14: US1;
            switch (v4.tag) {
                case 1: {
                    switch (v1.tag) {
                        case 1: {
                            v14 = US1_SymbolSame();
                            break;
                        }
                        case 0: {
                            v14 = US1_SymbolGreater();
                            break;
                        }
                        default: throw new Error("Compiler error: unreachable union case.");
                    }
                    break;
                }
                case 0: {
                    switch (v1.tag) {
                        case 1: {
                            v14 = US1_SymbolLess();
                            break;
                        }
                        case 0: {
                            v14 = US1_SymbolSame();
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
                return UH0_RegexEpsilon();
            } else {
                return UH0_RegexEmpty();
            }
            break;
        }
        case 0: {
            return UH0_RegexEmpty();
        }
        case 1: {
            return UH0_RegexEmpty();
        }
        case 5: {
            const v35: UH0 = v0.f0;
            let v36: UH0 = derivative_12(v35, v1);
            let v37: UH0 = make_star_11(v35);
            return make_cat_9(v36, v37);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function canonical_derivative_4(v0: UH0, v1: US0): UH0 {
    let v2: UH0 = normalize_5(v0);
    let v3: UH0 = derivative_12(v2, v1);
    return normalize_5(v3);
}
function accepts_3(v0: UH0, v1: UH1): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                const v6: US0 = v1.f0;
                const v7: UH1 = v1.f1;
                const v8: UH0 = canonical_derivative_4(v0, v6);
                v0 = v8;
                v1 = v7;
                continue tail;
            }
            case 0: {
                let v2: UH0 = normalize_5(v0);
                let v3: US2 = nullable_13(v2);
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
function loop_0(v0: number, v1: UH0, v2: number, v3: bigint, v4: number): number {
    tail: while (true) {
        const v5: boolean = 0 < v2;
        if (v5) {
            const v6: UH1 = UH1_InputEmpty();
            let [v7, v8]: [UH1, bigint] = random_bit_input_1(v3, v0, v6);
            const v9: number = 0;
            let v10: boolean = run_2(v9, v7);
            let v11: boolean = accepts_3(v1, v7);
            let v13: boolean;
            if (v10) {
                v13 = v11;
            } else {
                const v12: boolean = false === v11;
                v13 = v12;
            }
            if (v13) {
                let v14: number = (v2 - 1) | 0;
                let v16: number;
                if (v10) {
                    let v15: number = (v4 + 1) | 0;
                    v16 = v15;
                } else {
                    v16 = v4;
                }
                v2 = v14;
                v3 = v8;
                v4 = v16;
                continue tail;
            } else {
                throw new Error("brzozowski-compiled-core-disagrees-on-random-input");
            }
        } else {
            return v4;
        }
    }
}
function zeros_input_15(v0: number, v1: UH1): UH1 {
    tail: while (true) {
        let v2: boolean = 0 < v0;
        if (v2) {
            let v3: number = (v0 - 1) | 0;
            let v4: US0 = US0_BitZero();
            const v5: UH1 = UH1_InputCons(v4, v1);
            v0 = v3;
            v1 = v5;
            continue tail;
        } else {
            return v1;
        }
    }
}
function run_16(v0: number, v1: UH1): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                const v5: US0 = v1.f0;
                const v6: UH1 = v1.f1;
                const v7: boolean = v0 === 0;
                let v26: number;
                if (v7) {
                    v26 = 1;
                } else {
                    let v13: boolean = v0 === 1;
                    if (v13) {
                        v26 = 1;
                    } else {
                        let v22: US1;
                        switch (v5.tag) {
                            case 1: {
                                v22 = US1_SymbolGreater();
                                break;
                            }
                            case 0: {
                                v22 = US1_SymbolSame();
                                break;
                            }
                            default: throw new Error("Compiler error: unreachable union case.");
                        }
                        let v23: boolean;
                        switch (v22.tag) {
                            case 1: {
                                v23 = true;
                                break;
                            }
                            default: {
                                v23 = false;
                            }
                        }
                        if (v23) {
                            v26 = 2;
                        } else {
                            v26 = 0;
                        }
                    }
                }
                v0 = v26;
                v1 = v6;
                continue tail;
            }
            case 0: {
                let v2: boolean = v0 === 0;
                if (v2) {
                    return true;
                } else {
                    return false;
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function loop_14(v0: number, v1: UH0, v2: number, v3: number): number {
    tail: while (true) {
        let v4: boolean = v0 < v2;
        if (v4) {
            return v3;
        } else {
            const v5: UH1 = UH1_InputEmpty();
            const v6: UH1 = zeros_input_15(v2, v5);
            const v7: number = 2;
            const v8: boolean = run_16(v7, v6);
            const v9: boolean = accepts_3(v1, v6);
            let v11: boolean;
            if (v8) {
                v11 = v9;
            } else {
                let v10: boolean = false === v9;
                v11 = v10;
            }
            let v15: number;
            if (v11) {
                if (v8) {
                    const v12: number = (v3 + 1) | 0;
                    v15 = v12;
                } else {
                    v15 = v3;
                }
            } else {
                throw new Error("brzozowski-compiled-core-disagrees-on-zero-run");
            }
            let v16: US0 = US0_BitOne();
            let v17: UH1 = UH1_InputEmpty();
            let v18: UH1 = UH1_InputCons(v16, v17);
            let v19: UH1 = zeros_input_15(v2, v18);
            let v20: number = 2;
            let v21: boolean = run_16(v20, v19);
            let v22: boolean = accepts_3(v1, v19);
            let v24: boolean;
            if (v21) {
                v24 = v22;
            } else {
                let v23: boolean = false === v22;
                v24 = v23;
            }
            let v28: number;
            if (v24) {
                if (v21) {
                    let v25: number = (v15 + 1) | 0;
                    v28 = v25;
                } else {
                    v28 = v15;
                }
            } else {
                throw new Error("brzozowski-compiled-core-disagrees-on-zero-run");
            }
            const v29: number = (v2 + 1) | 0;
            v2 = v29;
            v3 = v28;
            continue tail;
        }
    }
}
function run_17(v0: number, v1: UH3): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                const v5: US3 = v1.f0;
                const v6: UH3 = v1.f1;
                const v7: boolean = v0 === 0;
                let v47: number;
                if (v7) {
                    let v10: US1;
                    switch (v5.tag) {
                        case 0: {
                            v10 = US1_SymbolSame();
                            break;
                        }
                        default: {
                            v10 = US1_SymbolGreater();
                        }
                    }
                    let v11: boolean;
                    switch (v10.tag) {
                        case 1: {
                            v11 = true;
                            break;
                        }
                        default: {
                            v11 = false;
                        }
                    }
                    if (v11) {
                        v47 = 0;
                    } else {
                        let v17: US1;
                        switch (v5.tag) {
                            case 0: {
                                v17 = US1_SymbolLess();
                                break;
                            }
                            case 1: {
                                v17 = US1_SymbolSame();
                                break;
                            }
                            case 2: {
                                v17 = US1_SymbolGreater();
                                break;
                            }
                            default: throw new Error("Compiler error: unreachable union case.");
                        }
                        let v18: boolean;
                        switch (v17.tag) {
                            case 1: {
                                v18 = true;
                                break;
                            }
                            default: {
                                v18 = false;
                            }
                        }
                        if (v18) {
                            v47 = 0;
                        } else {
                            v47 = 1;
                        }
                    }
                } else {
                    let v21: boolean = v0 === 1;
                    if (v21) {
                        let v24: US1;
                        switch (v5.tag) {
                            case 0: {
                                v24 = US1_SymbolSame();
                                break;
                            }
                            default: {
                                v24 = US1_SymbolGreater();
                            }
                        }
                        let v25: boolean;
                        switch (v24.tag) {
                            case 1: {
                                v25 = true;
                                break;
                            }
                            default: {
                                v25 = false;
                            }
                        }
                        if (v25) {
                            v47 = 2;
                        } else {
                            v47 = 2;
                        }
                    } else {
                        let v36: US1;
                        switch (v5.tag) {
                            case 0: {
                                v36 = US1_SymbolSame();
                                break;
                            }
                            default: {
                                v36 = US1_SymbolGreater();
                            }
                        }
                        let v37: boolean;
                        switch (v36.tag) {
                            case 1: {
                                v37 = true;
                                break;
                            }
                            default: {
                                v37 = false;
                            }
                        }
                        if (v37) {
                            v47 = 2;
                        } else {
                            v47 = 2;
                        }
                    }
                }
                v0 = v47;
                v1 = v6;
                continue tail;
            }
            case 0: {
                let v2: boolean = v0 === 0;
                if (v2) {
                    return false;
                } else {
                    let v3: boolean = v0 === 1;
                    return v3;
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function regex_compare_23(v0: UH2, v1: UH2): US1 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                const v59: UH2 = v0.f0;
                const v60: UH2 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        const v61: UH2 = v1.f0;
                        let v62: UH2 = v1.f1;
                        const v63: US1 = regex_compare_23(v59, v61);
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
                        return US1_SymbolGreater();
                    }
                }
                break;
            }
            case 4: {
                const v34: UH2 = v0.f0;
                const v35: UH2 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        const v40: UH2 = v1.f0;
                        const v41: UH2 = v1.f1;
                        const v42: US1 = regex_compare_23(v34, v40);
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
                        const v38: US3 = v1.f0;
                        return US1_SymbolGreater();
                    }
                    case 0: {
                        return US1_SymbolGreater();
                    }
                    case 1: {
                        return US1_SymbolGreater();
                    }
                    default: {
                        return US1_SymbolLess();
                    }
                }
                break;
            }
            case 2: {
                let v10: US3 = v0.f0;
                switch (v1.tag) {
                    case 2: {
                        let v13: US3 = v1.f0;
                        switch (v10.tag) {
                            case 0: {
                                switch (v13.tag) {
                                    case 0: {
                                        return US1_SymbolSame();
                                    }
                                    default: {
                                        return US1_SymbolLess();
                                    }
                                }
                                break;
                            }
                            default: {
                                switch (v13.tag) {
                                    case 0: {
                                        return US1_SymbolGreater();
                                    }
                                    default: {
                                        switch (v10.tag) {
                                            case 1: {
                                                switch (v13.tag) {
                                                    case 1: {
                                                        return US1_SymbolSame();
                                                    }
                                                    case 2: {
                                                        return US1_SymbolLess();
                                                    }
                                                    default: throw new Error("Compiler error: unreachable union case.");
                                                }
                                                break;
                                            }
                                            case 2: {
                                                switch (v13.tag) {
                                                    case 1: {
                                                        return US1_SymbolGreater();
                                                    }
                                                    case 2: {
                                                        return US1_SymbolSame();
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
                        return US1_SymbolGreater();
                    }
                    case 1: {
                        return US1_SymbolGreater();
                    }
                    default: {
                        return US1_SymbolLess();
                    }
                }
                break;
            }
            case 0: {
                switch (v1.tag) {
                    case 0: {
                        return US1_SymbolSame();
                    }
                    default: {
                        return US1_SymbolLess();
                    }
                }
                break;
            }
            case 1: {
                switch (v1.tag) {
                    case 0: {
                        return US1_SymbolGreater();
                    }
                    case 1: {
                        return US1_SymbolSame();
                    }
                    default: {
                        return US1_SymbolLess();
                    }
                }
                break;
            }
            case 5: {
                const v50: UH2 = v0.f0;
                switch (v1.tag) {
                    case 3: {
                        const v51: UH2 = v1.f0;
                        const v52: UH2 = v1.f1;
                        return US1_SymbolLess();
                    }
                    case 5: {
                        const v54: UH2 = v1.f0;
                        v0 = v50;
                        v1 = v54;
                        continue tail;
                    }
                    default: {
                        return US1_SymbolGreater();
                    }
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function alt_insert_sorted_22(v0: UH2, v1: UH2): UH2 {
    switch (v1.tag) {
        case 3: {
            let v2: UH2 = v1.f0;
            let v3: UH2 = v1.f1;
            let v4: US1 = regex_compare_23(v0, v2);
            switch (v4.tag) {
                case 2: {
                    const v6: UH2 = alt_insert_sorted_22(v0, v3);
                    return UH2_RegexAlt(v2, v6);
                }
                case 0: {
                    return UH2_RegexAlt(v0, v1);
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
            let v11: US1 = regex_compare_23(v0, v1);
            switch (v11.tag) {
                case 2: {
                    return UH2_RegexAlt(v1, v0);
                }
                case 0: {
                    return UH2_RegexAlt(v0, v1);
                }
                case 1: {
                    return v1;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
        }
    }
}
function make_alt_21(v0: UH2, v1: UH2): UH2 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                let v2: UH2 = v0.f0;
                let v3: UH2 = v0.f1;
                let v4: UH2 = alt_insert_sorted_22(v2, v1);
                v0 = v3;
                v1 = v4;
                continue tail;
            }
            case 0: {
                return v1;
            }
            default: {
                return alt_insert_sorted_22(v0, v1);
            }
        }
    }
}
function regex_equal_25(v0: UH2, v1: UH2): boolean {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                let v24: UH2 = v0.f0;
                let v25: UH2 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        let v26: UH2 = v1.f0;
                        const v27: UH2 = v1.f1;
                        let v28: boolean = regex_equal_25(v24, v26);
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
                const v32: UH2 = v0.f0;
                const v33: UH2 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        const v34: UH2 = v1.f0;
                        const v35: UH2 = v1.f1;
                        let v36: boolean = regex_equal_25(v32, v34);
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
                let v4: US3 = v0.f0;
                switch (v1.tag) {
                    case 2: {
                        const v5: US3 = v1.f0;
                        let v21: US1;
                        switch (v4.tag) {
                            case 0: {
                                switch (v5.tag) {
                                    case 0: {
                                        v21 = US1_SymbolSame();
                                        break;
                                    }
                                    default: {
                                        v21 = US1_SymbolLess();
                                    }
                                }
                                break;
                            }
                            default: {
                                switch (v5.tag) {
                                    case 0: {
                                        v21 = US1_SymbolGreater();
                                        break;
                                    }
                                    default: {
                                        switch (v4.tag) {
                                            case 1: {
                                                switch (v5.tag) {
                                                    case 1: {
                                                        v21 = US1_SymbolSame();
                                                        break;
                                                    }
                                                    case 2: {
                                                        v21 = US1_SymbolLess();
                                                        break;
                                                    }
                                                    default: throw new Error("Compiler error: unreachable union case.");
                                                }
                                                break;
                                            }
                                            case 2: {
                                                switch (v5.tag) {
                                                    case 1: {
                                                        v21 = US1_SymbolGreater();
                                                        break;
                                                    }
                                                    case 2: {
                                                        v21 = US1_SymbolSame();
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
                const v40: UH2 = v0.f0;
                switch (v1.tag) {
                    case 5: {
                        const v41: UH2 = v1.f0;
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
function make_cat_24(v0: UH2, v1: UH2): UH2 {
    switch (v0.tag) {
        case 0: {
            return UH2_RegexEmpty();
        }
        default: {
            switch (v1.tag) {
                case 0: {
                    return UH2_RegexEmpty();
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
                                            const v12: UH2 = v0.f0;
                                            let v13: UH2 = v0.f1;
                                            let v14: UH2 = make_cat_24(v13, v1);
                                            return UH2_RegexCat(v12, v14);
                                        }
                                        case 5: {
                                            let v4: UH2 = v0.f0;
                                            switch (v1.tag) {
                                                case 5: {
                                                    const v5: UH2 = v1.f0;
                                                    const v6: boolean = regex_equal_25(v4, v5);
                                                    if (v6) {
                                                        return UH2_RegexStar(v4);
                                                    } else {
                                                        return UH2_RegexCat(v0, v1);
                                                    }
                                                    break;
                                                }
                                                default: {
                                                    return UH2_RegexCat(v0, v1);
                                                }
                                            }
                                            break;
                                        }
                                        default: {
                                            return UH2_RegexCat(v0, v1);
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
function make_star_26(v0: UH2): UH2 {
    switch (v0.tag) {
        case 0: {
            return UH2_RegexEpsilon();
        }
        case 1: {
            return UH2_RegexEpsilon();
        }
        case 5: {
            let v3: UH2 = v0.f0;
            return UH2_RegexStar(v3);
        }
        default: {
            return UH2_RegexStar(v0);
        }
    }
}
function normalize_20(v0: UH2): UH2 {
    switch (v0.tag) {
        case 3: {
            const v5: UH2 = v0.f0;
            const v6: UH2 = v0.f1;
            const v7: UH2 = normalize_20(v5);
            const v8: UH2 = normalize_20(v6);
            return make_alt_21(v7, v8);
        }
        case 4: {
            let v10: UH2 = v0.f0;
            let v11: UH2 = v0.f1;
            const v12: UH2 = normalize_20(v10);
            let v13: UH2 = normalize_20(v11);
            return make_cat_24(v12, v13);
        }
        case 2: {
            let v3: US3 = v0.f0;
            return UH2_RegexChar(v3);
        }
        case 0: {
            return UH2_RegexEmpty();
        }
        case 1: {
            return UH2_RegexEpsilon();
        }
        case 5: {
            let v15: UH2 = v0.f0;
            let v16: UH2 = normalize_20(v15);
            return make_star_26(v16);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function nullable_28(v0: UH2): US2 {
    switch (v0.tag) {
        case 3: {
            const v5: UH2 = v0.f0;
            const v6: UH2 = v0.f1;
            const v7: US2 = nullable_28(v5);
            const v8: US2 = nullable_28(v6);
            switch (v7.tag) {
                case 0: {
                    return US2_Nullable();
                }
                default: {
                    switch (v8.tag) {
                        case 0: {
                            return US2_Nullable();
                        }
                        default: {
                            switch (v7.tag) {
                                case 1: {
                                    switch (v8.tag) {
                                        case 1: {
                                            return US2_NonNullable();
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
            let v16: UH2 = v0.f0;
            let v17: UH2 = v0.f1;
            let v18: US2 = nullable_28(v16);
            let v19: US2 = nullable_28(v17);
            switch (v18.tag) {
                case 0: {
                    switch (v19.tag) {
                        case 0: {
                            return US2_Nullable();
                        }
                        default: {
                            return US2_NonNullable();
                        }
                    }
                    break;
                }
                default: {
                    return US2_NonNullable();
                }
            }
            break;
        }
        case 2: {
            let v3: US3 = v0.f0;
            return US2_NonNullable();
        }
        case 0: {
            return US2_NonNullable();
        }
        case 1: {
            return US2_Nullable();
        }
        case 5: {
            let v25: UH2 = v0.f0;
            return US2_Nullable();
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function derivative_27(v0: UH2, v1: US3): UH2 {
    switch (v0.tag) {
        case 3: {
            let v25: UH2 = v0.f0;
            let v26: UH2 = v0.f1;
            const v27: UH2 = derivative_27(v25, v1);
            let v28: UH2 = derivative_27(v26, v1);
            return make_alt_21(v27, v28);
        }
        case 4: {
            const v30: UH2 = v0.f0;
            const v31: UH2 = v0.f1;
            const v32: US2 = nullable_28(v30);
            switch (v32.tag) {
                case 1: {
                    let v37: UH2 = derivative_27(v30, v1);
                    return make_cat_24(v37, v31);
                }
                case 0: {
                    const v33: UH2 = derivative_27(v30, v1);
                    const v34: UH2 = make_cat_24(v33, v31);
                    const v35: UH2 = derivative_27(v31, v1);
                    return make_alt_21(v34, v35);
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        case 2: {
            let v4: US3 = v0.f0;
            let v20: US1;
            switch (v4.tag) {
                case 0: {
                    switch (v1.tag) {
                        case 0: {
                            v20 = US1_SymbolSame();
                            break;
                        }
                        default: {
                            v20 = US1_SymbolLess();
                        }
                    }
                    break;
                }
                default: {
                    switch (v1.tag) {
                        case 0: {
                            v20 = US1_SymbolGreater();
                            break;
                        }
                        default: {
                            switch (v4.tag) {
                                case 1: {
                                    switch (v1.tag) {
                                        case 1: {
                                            v20 = US1_SymbolSame();
                                            break;
                                        }
                                        case 2: {
                                            v20 = US1_SymbolLess();
                                            break;
                                        }
                                        default: throw new Error("Compiler error: unreachable union case.");
                                    }
                                    break;
                                }
                                case 2: {
                                    switch (v1.tag) {
                                        case 1: {
                                            v20 = US1_SymbolGreater();
                                            break;
                                        }
                                        case 2: {
                                            v20 = US1_SymbolSame();
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
                return UH2_RegexEpsilon();
            } else {
                return UH2_RegexEmpty();
            }
            break;
        }
        case 0: {
            return UH2_RegexEmpty();
        }
        case 1: {
            return UH2_RegexEmpty();
        }
        case 5: {
            const v41: UH2 = v0.f0;
            const v42: UH2 = derivative_27(v41, v1);
            const v43: UH2 = make_star_26(v41);
            return make_cat_24(v42, v43);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function canonical_derivative_19(v0: UH2, v1: US3): UH2 {
    let v2: UH2 = normalize_20(v0);
    let v3: UH2 = derivative_27(v2, v1);
    return normalize_20(v3);
}
function accepts_18(v0: UH2, v1: UH3): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                const v6: US3 = v1.f0;
                const v7: UH3 = v1.f1;
                const v8: UH2 = canonical_derivative_19(v0, v6);
                v0 = v8;
                v1 = v7;
                continue tail;
            }
            case 0: {
                let v2: UH2 = normalize_20(v0);
                let v3: US2 = nullable_28(v2);
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
export function main(): number {
    let v0: number = 200;
    let v1: number = 32;
    let v2: number = 16;
    let v3: US0 = US0_BitZero();
    let v4: UH0 = UH0_RegexChar(v3);
    const v5: US0 = US0_BitOne();
    const v6: UH0 = UH0_RegexChar(v5);
    const v7: UH0 = UH0_RegexAlt(v4, v6);
    const v8: UH0 = UH0_RegexStar(v7);
    const v9: US0 = US0_BitZero();
    let v10: UH0 = UH0_RegexChar(v9);
    let v11: UH0 = UH0_RegexCat(v8, v10);
    const v12: bigint = 1n;
    let v13: number = 0;
    let v14: number = loop_0(v1, v11, v0, v12, v13);
    let v15: boolean = v14 === 93;
    if (v15) {
    } else {
        throw new Error("brzozowski-compiled-ends-with-zero-count");
    }
    let v16: US0 = US0_BitZero();
    let v17: UH0 = UH0_RegexChar(v16);
    let v18: US0 = US0_BitZero();
    let v19: UH0 = UH0_RegexChar(v18);
    let v20: US0 = US0_BitZero();
    let v21: UH0 = UH0_RegexChar(v20);
    let v22: UH0 = UH0_RegexCat(v19, v21);
    let v23: UH0 = UH0_RegexAlt(v17, v22);
    let v24: UH0 = UH0_RegexStar(v23);
    let v25: US0 = US0_BitOne();
    let v26: UH0 = UH0_RegexChar(v25);
    const v27: UH0 = UH0_RegexCat(v24, v26);
    let v28: number = 1;
    const v29: number = 0;
    const v30: number = loop_14(v2, v27, v28, v29);
    const v31: boolean = v30 === 16;
    if (v31) {
    } else {
        throw new Error("brzozowski-compiled-zero-runs-count");
    }
    const v32: US3 = US3_TriA();
    const v33: UH2 = UH2_RegexChar(v32);
    const v34: US3 = US3_TriB();
    const v35: UH2 = UH2_RegexChar(v34);
    let v36: UH2 = UH2_RegexAlt(v33, v35);
    let v37: UH2 = UH2_RegexStar(v36);
    const v38: US3 = US3_TriC();
    const v39: UH2 = UH2_RegexChar(v38);
    const v40: UH2 = UH2_RegexCat(v37, v39);
    const v41: US3 = US3_TriA();
    const v42: US3 = US3_TriB();
    const v43: US3 = US3_TriA();
    const v44: US3 = US3_TriC();
    const v45: UH3 = UH3_InputEmpty();
    const v46: UH3 = UH3_InputCons(v44, v45);
    let v47: UH3 = UH3_InputCons(v43, v46);
    const v48: UH3 = UH3_InputCons(v42, v47);
    const v49: UH3 = UH3_InputCons(v41, v48);
    const v50: US3 = US3_TriA();
    const v51: US3 = US3_TriB();
    const v52: US3 = US3_TriA();
    const v53: US3 = US3_TriB();
    const v54: UH3 = UH3_InputEmpty();
    const v55: UH3 = UH3_InputCons(v53, v54);
    const v56: UH3 = UH3_InputCons(v52, v55);
    const v57: UH3 = UH3_InputCons(v51, v56);
    const v58: UH3 = UH3_InputCons(v50, v57);
    const v59: number = 0;
    const v60: boolean = run_17(v59, v49);
    let v62: boolean;
    if (v60) {
        v62 = accepts_18(v40, v49);
    } else {
        v62 = false;
    }
    let v68: boolean;
    if (v62) {
        const v63: number = 0;
        const v64: boolean = run_17(v63, v58);
        if (v64) {
            v68 = false;
        } else {
            const v65: boolean = accepts_18(v40, v58);
            const v66: boolean = v65 === false;
            v68 = v66;
        }
    } else {
        v68 = false;
    }
    if (v68) {
        return 0;
    } else {
        throw new Error("brzozowski-compiled-ternary-disagrees");
    }
}
process.exitCode = main();
