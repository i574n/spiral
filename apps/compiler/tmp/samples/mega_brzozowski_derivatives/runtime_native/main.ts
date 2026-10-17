type US0_BitZero = { readonly tag: 0 };
type US0_BitOne = { readonly tag: 1 };
type US0 = US0_BitZero | US0_BitOne;
function US0_BitZero(): US0 { return { tag: 0 }; }
function US0_BitOne(): US0 { return { tag: 1 }; }
type UH0_InputEmpty = { readonly tag: 0 };
type UH0_InputCons = { readonly tag: 1, readonly f0: US0, readonly f1: UH0 };
type UH0 = UH0_InputEmpty | UH0_InputCons;
function UH0_InputEmpty(): UH0 { return { tag: 0 }; }
function UH0_InputCons(f0: US0, f1: UH0): UH0 { return { tag: 1, f0: f0, f1: f1 }; }
type US1_TriA = { readonly tag: 0 };
type US1_TriB = { readonly tag: 1 };
type US1_TriC = { readonly tag: 2 };
type US1 = US1_TriA | US1_TriB | US1_TriC;
function US1_TriA(): US1 { return { tag: 0 }; }
function US1_TriB(): US1 { return { tag: 1 }; }
function US1_TriC(): US1 { return { tag: 2 }; }
type UH1_InputEmpty = { readonly tag: 0 };
type UH1_InputCons = { readonly tag: 1, readonly f0: US1, readonly f1: UH1 };
type UH1 = UH1_InputEmpty | UH1_InputCons;
function UH1_InputEmpty(): UH1 { return { tag: 0 }; }
function UH1_InputCons(f0: US1, f1: UH1): UH1 { return { tag: 1, f0: f0, f1: f1 }; }
type UH2_RegexEmpty = { readonly tag: 0 };
type UH2_RegexEpsilon = { readonly tag: 1 };
type UH2_RegexChar = { readonly tag: 2, readonly f0: US0 };
type UH2_RegexAlt = { readonly tag: 3, readonly f0: UH2, readonly f1: UH2 };
type UH2_RegexCat = { readonly tag: 4, readonly f0: UH2, readonly f1: UH2 };
type UH2_RegexStar = { readonly tag: 5, readonly f0: UH2 };
type UH2 = UH2_RegexEmpty | UH2_RegexEpsilon | UH2_RegexChar | UH2_RegexAlt | UH2_RegexCat | UH2_RegexStar;
function UH2_RegexEmpty(): UH2 { return { tag: 0 }; }
function UH2_RegexEpsilon(): UH2 { return { tag: 1 }; }
function UH2_RegexChar(f0: US0): UH2 { return { tag: 2, f0: f0 }; }
function UH2_RegexAlt(f0: UH2, f1: UH2): UH2 { return { tag: 3, f0: f0, f1: f1 }; }
function UH2_RegexCat(f0: UH2, f1: UH2): UH2 { return { tag: 4, f0: f0, f1: f1 }; }
function UH2_RegexStar(f0: UH2): UH2 { return { tag: 5, f0: f0 }; }
type US2_SymbolLess = { readonly tag: 0 };
type US2_SymbolSame = { readonly tag: 1 };
type US2_SymbolGreater = { readonly tag: 2 };
type US2 = US2_SymbolLess | US2_SymbolSame | US2_SymbolGreater;
function US2_SymbolLess(): US2 { return { tag: 0 }; }
function US2_SymbolSame(): US2 { return { tag: 1 }; }
function US2_SymbolGreater(): US2 { return { tag: 2 }; }
type US3_Nullable = { readonly tag: 0 };
type US3_NonNullable = { readonly tag: 1 };
type US3 = US3_Nullable | US3_NonNullable;
function US3_Nullable(): US3 { return { tag: 0 }; }
function US3_NonNullable(): US3 { return { tag: 1 }; }
type UH3_RegexEmpty = { readonly tag: 0 };
type UH3_RegexEpsilon = { readonly tag: 1 };
type UH3_RegexChar = { readonly tag: 2, readonly f0: US1 };
type UH3_RegexAlt = { readonly tag: 3, readonly f0: UH3, readonly f1: UH3 };
type UH3_RegexCat = { readonly tag: 4, readonly f0: UH3, readonly f1: UH3 };
type UH3_RegexStar = { readonly tag: 5, readonly f0: UH3 };
type UH3 = UH3_RegexEmpty | UH3_RegexEpsilon | UH3_RegexChar | UH3_RegexAlt | UH3_RegexCat | UH3_RegexStar;
function UH3_RegexEmpty(): UH3 { return { tag: 0 }; }
function UH3_RegexEpsilon(): UH3 { return { tag: 1 }; }
function UH3_RegexChar(f0: US1): UH3 { return { tag: 2, f0: f0 }; }
function UH3_RegexAlt(f0: UH3, f1: UH3): UH3 { return { tag: 3, f0: f0, f1: f1 }; }
function UH3_RegexCat(f0: UH3, f1: UH3): UH3 { return { tag: 4, f0: f0, f1: f1 }; }
function UH3_RegexStar(f0: UH3): UH3 { return { tag: 5, f0: f0 }; }
type US4_BitMatcherRaw = { readonly tag: 0, readonly f0: UH2, readonly f1: UH0 };
type US4 = US4_BitMatcherRaw;
function US4_BitMatcherRaw(f0: UH2, f1: UH0): US4 { return { tag: 0, f0: f0, f1: f1 }; }
type US5_BitMatcherDecided = { readonly tag: 1, readonly f0: UH2, readonly f1: UH0, readonly f2: boolean };
type US5 = US5_BitMatcherDecided;
function US5_BitMatcherDecided(f0: UH2, f1: UH0, f2: boolean): US5 { return { tag: 1, f0: f0, f1: f1, f2: f2 }; }
function regex_compare_5(v0: UH2, v1: UH2): US2 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                let v53: UH2 = v0.f0;
                let v54: UH2 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        let v55: UH2 = v1.f0;
                        let v56: UH2 = v1.f1;
                        let v57: US2 = regex_compare_5(v53, v55);
                        switch (v57.tag) {
                            case 1: {
                                {
                                    let t0 = v54;
                                    let t1 = v56;
                                    v0 = t0;
                                    v1 = t1;
                                }
                                continue tail;
                                break;
                            }
                            default: {
                                return v57;
                            }
                        }
                        break;
                    }
                    default: {
                        return US2_SymbolGreater();
                    }
                }
                break;
            }
            case 4: {
                let v28: UH2 = v0.f0;
                let v29: UH2 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        let v34: UH2 = v1.f0;
                        let v35: UH2 = v1.f1;
                        let v36: US2 = regex_compare_5(v28, v34);
                        switch (v36.tag) {
                            case 1: {
                                {
                                    let t0 = v29;
                                    let t1 = v35;
                                    v0 = t0;
                                    v1 = t1;
                                }
                                continue tail;
                                break;
                            }
                            default: {
                                return v36;
                            }
                        }
                        break;
                    }
                    case 2: {
                        let v32: US0 = v1.f0;
                        return US2_SymbolGreater();
                        break;
                    }
                    case 0: {
                        return US2_SymbolGreater();
                        break;
                    }
                    case 1: {
                        return US2_SymbolGreater();
                        break;
                    }
                    default: {
                        return US2_SymbolLess();
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
                                        return US2_SymbolSame();
                                        break;
                                    }
                                    case 0: {
                                        return US2_SymbolGreater();
                                        break;
                                    }
                                    default: throw new Error("Compiler error: unreachable union case.");
                                }
                                break;
                            }
                            case 0: {
                                switch (v13.tag) {
                                    case 1: {
                                        return US2_SymbolLess();
                                        break;
                                    }
                                    case 0: {
                                        return US2_SymbolSame();
                                        break;
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
                        return US2_SymbolGreater();
                        break;
                    }
                    case 1: {
                        return US2_SymbolGreater();
                        break;
                    }
                    default: {
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            case 0: {
                switch (v1.tag) {
                    case 0: {
                        return US2_SymbolSame();
                        break;
                    }
                    default: {
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            case 1: {
                switch (v1.tag) {
                    case 0: {
                        return US2_SymbolGreater();
                        break;
                    }
                    case 1: {
                        return US2_SymbolSame();
                        break;
                    }
                    default: {
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            case 5: {
                let v44: UH2 = v0.f0;
                switch (v1.tag) {
                    case 3: {
                        let v45: UH2 = v1.f0;
                        let v46: UH2 = v1.f1;
                        return US2_SymbolLess();
                        break;
                    }
                    case 5: {
                        let v48: UH2 = v1.f0;
                        {
                            let t0 = v44;
                            let t1 = v48;
                            v0 = t0;
                            v1 = t1;
                        }
                        continue tail;
                        break;
                    }
                    default: {
                        return US2_SymbolGreater();
                    }
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function alt_insert_sorted_4(v0: UH2, v1: UH2): UH2 {
    switch (v1.tag) {
        case 3: {
            let v2: UH2 = v1.f0;
            let v3: UH2 = v1.f1;
            let v4: US2 = regex_compare_5(v0, v2);
            switch (v4.tag) {
                case 2: {
                    let v6: UH2 = alt_insert_sorted_4(v0, v3);
                    return UH2_RegexAlt(v2, v6);
                    break;
                }
                case 0: {
                    return UH2_RegexAlt(v0, v1);
                    break;
                }
                case 1: {
                    return v1;
                    break;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        case 0: {
            return v0;
            break;
        }
        default: {
            let v11: US2 = regex_compare_5(v0, v1);
            switch (v11.tag) {
                case 2: {
                    return UH2_RegexAlt(v1, v0);
                    break;
                }
                case 0: {
                    return UH2_RegexAlt(v0, v1);
                    break;
                }
                case 1: {
                    return v1;
                    break;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
        }
    }
}
function make_alt_3(v0: UH2, v1: UH2): UH2 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                let v2: UH2 = v0.f0;
                let v3: UH2 = v0.f1;
                let v4: UH2 = alt_insert_sorted_4(v2, v1);
                {
                    let t0 = v3;
                    let t1 = v4;
                    v0 = t0;
                    v1 = t1;
                }
                continue tail;
                break;
            }
            case 0: {
                return v1;
                break;
            }
            default: {
                return alt_insert_sorted_4(v0, v1);
            }
        }
    }
}
function regex_equal_7(v0: UH2, v1: UH2): boolean {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                let v18: UH2 = v0.f0;
                let v19: UH2 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        let v20: UH2 = v1.f0;
                        let v21: UH2 = v1.f1;
                        let v22: boolean = regex_equal_7(v18, v20);
                        if (v22) {
                            {
                                let t0 = v19;
                                let t1 = v21;
                                v0 = t0;
                                v1 = t1;
                            }
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
                let v26: UH2 = v0.f0;
                let v27: UH2 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        let v28: UH2 = v1.f0;
                        let v29: UH2 = v1.f1;
                        let v30: boolean = regex_equal_7(v26, v28);
                        if (v30) {
                            {
                                let t0 = v27;
                                let t1 = v29;
                                v0 = t0;
                                v1 = t1;
                            }
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
                        let v5: US0 = v1.f0;
                        let v15: US2;
                        switch (v4.tag) {
                            case 1: {
                                switch (v5.tag) {
                                    case 1: {
                                        v15 = US2_SymbolSame();
                                        break;
                                    }
                                    case 0: {
                                        v15 = US2_SymbolGreater();
                                        break;
                                    }
                                    default: throw new Error("Compiler error: unreachable union case.");
                                }
                                break;
                            }
                            case 0: {
                                switch (v5.tag) {
                                    case 1: {
                                        v15 = US2_SymbolLess();
                                        break;
                                    }
                                    case 0: {
                                        v15 = US2_SymbolSame();
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
                                break;
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
                        break;
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
                        break;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            case 5: {
                let v34: UH2 = v0.f0;
                switch (v1.tag) {
                    case 5: {
                        let v35: UH2 = v1.f0;
                        {
                            let t0 = v34;
                            let t1 = v35;
                            v0 = t0;
                            v1 = t1;
                        }
                        continue tail;
                        break;
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
function make_cat_6(v0: UH2, v1: UH2): UH2 {
    switch (v0.tag) {
        case 0: {
            return UH2_RegexEmpty();
            break;
        }
        default: {
            switch (v1.tag) {
                case 0: {
                    return UH2_RegexEmpty();
                    break;
                }
                default: {
                    switch (v0.tag) {
                        case 1: {
                            return v1;
                            break;
                        }
                        default: {
                            switch (v1.tag) {
                                case 1: {
                                    return v0;
                                    break;
                                }
                                default: {
                                    switch (v0.tag) {
                                        case 4: {
                                            let v12: UH2 = v0.f0;
                                            let v13: UH2 = v0.f1;
                                            let v14: UH2 = make_cat_6(v13, v1);
                                            return UH2_RegexCat(v12, v14);
                                            break;
                                        }
                                        case 5: {
                                            let v4: UH2 = v0.f0;
                                            switch (v1.tag) {
                                                case 5: {
                                                    let v5: UH2 = v1.f0;
                                                    let v6: boolean = regex_equal_7(v4, v5);
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
function make_star_8(v0: UH2): UH2 {
    switch (v0.tag) {
        case 0: {
            return UH2_RegexEpsilon();
            break;
        }
        case 1: {
            return UH2_RegexEpsilon();
            break;
        }
        case 5: {
            let v3: UH2 = v0.f0;
            return UH2_RegexStar(v3);
            break;
        }
        default: {
            return UH2_RegexStar(v0);
        }
    }
}
function normalize_2(v0: UH2): UH2 {
    switch (v0.tag) {
        case 3: {
            let v5: UH2 = v0.f0;
            let v6: UH2 = v0.f1;
            let v7: UH2 = normalize_2(v5);
            let v8: UH2 = normalize_2(v6);
            return make_alt_3(v7, v8);
            break;
        }
        case 4: {
            let v10: UH2 = v0.f0;
            let v11: UH2 = v0.f1;
            let v12: UH2 = normalize_2(v10);
            let v13: UH2 = normalize_2(v11);
            return make_cat_6(v12, v13);
            break;
        }
        case 2: {
            let v3: US0 = v0.f0;
            return UH2_RegexChar(v3);
            break;
        }
        case 0: {
            return UH2_RegexEmpty();
            break;
        }
        case 1: {
            return UH2_RegexEpsilon();
            break;
        }
        case 5: {
            let v15: UH2 = v0.f0;
            let v16: UH2 = normalize_2(v15);
            return make_star_8(v16);
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function nullable_10(v0: UH2): US3 {
    switch (v0.tag) {
        case 3: {
            let v5: UH2 = v0.f0;
            let v6: UH2 = v0.f1;
            let v7: US3 = nullable_10(v5);
            let v8: US3 = nullable_10(v6);
            switch (v7.tag) {
                case 0: {
                    return US3_Nullable();
                    break;
                }
                default: {
                    switch (v8.tag) {
                        case 0: {
                            return US3_Nullable();
                            break;
                        }
                        default: {
                            switch (v7.tag) {
                                case 1: {
                                    switch (v8.tag) {
                                        case 1: {
                                            return US3_NonNullable();
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
            break;
        }
        case 4: {
            let v16: UH2 = v0.f0;
            let v17: UH2 = v0.f1;
            let v18: US3 = nullable_10(v16);
            let v19: US3 = nullable_10(v17);
            switch (v18.tag) {
                case 0: {
                    switch (v19.tag) {
                        case 0: {
                            return US3_Nullable();
                            break;
                        }
                        default: {
                            return US3_NonNullable();
                        }
                    }
                    break;
                }
                default: {
                    return US3_NonNullable();
                }
            }
            break;
        }
        case 2: {
            let v3: US0 = v0.f0;
            return US3_NonNullable();
            break;
        }
        case 0: {
            return US3_NonNullable();
            break;
        }
        case 1: {
            return US3_Nullable();
            break;
        }
        case 5: {
            let v25: UH2 = v0.f0;
            return US3_Nullable();
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function derivative_9(v0: UH2, v1: US0): UH2 {
    switch (v0.tag) {
        case 3: {
            let v19: UH2 = v0.f0;
            let v20: UH2 = v0.f1;
            let v21: UH2 = derivative_9(v19, v1);
            let v22: UH2 = derivative_9(v20, v1);
            return make_alt_3(v21, v22);
            break;
        }
        case 4: {
            let v24: UH2 = v0.f0;
            let v25: UH2 = v0.f1;
            let v26: US3 = nullable_10(v24);
            switch (v26.tag) {
                case 1: {
                    let v31: UH2 = derivative_9(v24, v1);
                    return make_cat_6(v31, v25);
                    break;
                }
                case 0: {
                    let v27: UH2 = derivative_9(v24, v1);
                    let v28: UH2 = make_cat_6(v27, v25);
                    let v29: UH2 = derivative_9(v25, v1);
                    return make_alt_3(v28, v29);
                    break;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        case 2: {
            let v4: US0 = v0.f0;
            let v14: US2;
            switch (v4.tag) {
                case 1: {
                    switch (v1.tag) {
                        case 1: {
                            v14 = US2_SymbolSame();
                            break;
                        }
                        case 0: {
                            v14 = US2_SymbolGreater();
                            break;
                        }
                        default: throw new Error("Compiler error: unreachable union case.");
                    }
                    break;
                }
                case 0: {
                    switch (v1.tag) {
                        case 1: {
                            v14 = US2_SymbolLess();
                            break;
                        }
                        case 0: {
                            v14 = US2_SymbolSame();
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
                return UH2_RegexEpsilon();
            } else {
                return UH2_RegexEmpty();
            }
            break;
        }
        case 0: {
            return UH2_RegexEmpty();
            break;
        }
        case 1: {
            return UH2_RegexEmpty();
            break;
        }
        case 5: {
            let v35: UH2 = v0.f0;
            let v36: UH2 = derivative_9(v35, v1);
            let v37: UH2 = make_star_8(v35);
            return make_cat_6(v36, v37);
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function canonical_derivative_1(v0: UH2, v1: US0): UH2 {
    let v2: UH2 = normalize_2(v0);
    let v3: UH2 = derivative_9(v2, v1);
    return normalize_2(v3);
}
function accepts_0(v0: UH2, v1: UH0): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                let v6: US0 = v1.f0;
                let v7: UH0 = v1.f1;
                let v8: UH2 = canonical_derivative_1(v0, v6);
                {
                    let t0 = v8;
                    let t1 = v7;
                    v0 = t0;
                    v1 = t1;
                }
                continue tail;
                break;
            }
            case 0: {
                let v2: UH2 = normalize_2(v0);
                let v3: US3 = nullable_10(v2);
                switch (v3.tag) {
                    case 1: {
                        return false;
                        break;
                    }
                    case 0: {
                        return true;
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
function regex_compare_16(v0: UH3, v1: UH3): US2 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                let v59: UH3 = v0.f0;
                let v60: UH3 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        let v61: UH3 = v1.f0;
                        let v62: UH3 = v1.f1;
                        let v63: US2 = regex_compare_16(v59, v61);
                        switch (v63.tag) {
                            case 1: {
                                {
                                    let t0 = v60;
                                    let t1 = v62;
                                    v0 = t0;
                                    v1 = t1;
                                }
                                continue tail;
                                break;
                            }
                            default: {
                                return v63;
                            }
                        }
                        break;
                    }
                    default: {
                        return US2_SymbolGreater();
                    }
                }
                break;
            }
            case 4: {
                let v34: UH3 = v0.f0;
                let v35: UH3 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        let v40: UH3 = v1.f0;
                        let v41: UH3 = v1.f1;
                        let v42: US2 = regex_compare_16(v34, v40);
                        switch (v42.tag) {
                            case 1: {
                                {
                                    let t0 = v35;
                                    let t1 = v41;
                                    v0 = t0;
                                    v1 = t1;
                                }
                                continue tail;
                                break;
                            }
                            default: {
                                return v42;
                            }
                        }
                        break;
                    }
                    case 2: {
                        let v38: US1 = v1.f0;
                        return US2_SymbolGreater();
                        break;
                    }
                    case 0: {
                        return US2_SymbolGreater();
                        break;
                    }
                    case 1: {
                        return US2_SymbolGreater();
                        break;
                    }
                    default: {
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            case 2: {
                let v10: US1 = v0.f0;
                switch (v1.tag) {
                    case 2: {
                        let v13: US1 = v1.f0;
                        switch (v10.tag) {
                            case 0: {
                                switch (v13.tag) {
                                    case 0: {
                                        return US2_SymbolSame();
                                        break;
                                    }
                                    default: {
                                        return US2_SymbolLess();
                                    }
                                }
                                break;
                            }
                            default: {
                                switch (v13.tag) {
                                    case 0: {
                                        return US2_SymbolGreater();
                                        break;
                                    }
                                    default: {
                                        switch (v10.tag) {
                                            case 1: {
                                                switch (v13.tag) {
                                                    case 1: {
                                                        return US2_SymbolSame();
                                                        break;
                                                    }
                                                    case 2: {
                                                        return US2_SymbolLess();
                                                        break;
                                                    }
                                                    default: throw new Error("Compiler error: unreachable union case.");
                                                }
                                                break;
                                            }
                                            case 2: {
                                                switch (v13.tag) {
                                                    case 1: {
                                                        return US2_SymbolGreater();
                                                        break;
                                                    }
                                                    case 2: {
                                                        return US2_SymbolSame();
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
                        break;
                    }
                    case 0: {
                        return US2_SymbolGreater();
                        break;
                    }
                    case 1: {
                        return US2_SymbolGreater();
                        break;
                    }
                    default: {
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            case 0: {
                switch (v1.tag) {
                    case 0: {
                        return US2_SymbolSame();
                        break;
                    }
                    default: {
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            case 1: {
                switch (v1.tag) {
                    case 0: {
                        return US2_SymbolGreater();
                        break;
                    }
                    case 1: {
                        return US2_SymbolSame();
                        break;
                    }
                    default: {
                        return US2_SymbolLess();
                    }
                }
                break;
            }
            case 5: {
                let v50: UH3 = v0.f0;
                switch (v1.tag) {
                    case 3: {
                        let v51: UH3 = v1.f0;
                        let v52: UH3 = v1.f1;
                        return US2_SymbolLess();
                        break;
                    }
                    case 5: {
                        let v54: UH3 = v1.f0;
                        {
                            let t0 = v50;
                            let t1 = v54;
                            v0 = t0;
                            v1 = t1;
                        }
                        continue tail;
                        break;
                    }
                    default: {
                        return US2_SymbolGreater();
                    }
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function alt_insert_sorted_15(v0: UH3, v1: UH3): UH3 {
    switch (v1.tag) {
        case 3: {
            let v2: UH3 = v1.f0;
            let v3: UH3 = v1.f1;
            let v4: US2 = regex_compare_16(v0, v2);
            switch (v4.tag) {
                case 2: {
                    let v6: UH3 = alt_insert_sorted_15(v0, v3);
                    return UH3_RegexAlt(v2, v6);
                    break;
                }
                case 0: {
                    return UH3_RegexAlt(v0, v1);
                    break;
                }
                case 1: {
                    return v1;
                    break;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        case 0: {
            return v0;
            break;
        }
        default: {
            let v11: US2 = regex_compare_16(v0, v1);
            switch (v11.tag) {
                case 2: {
                    return UH3_RegexAlt(v1, v0);
                    break;
                }
                case 0: {
                    return UH3_RegexAlt(v0, v1);
                    break;
                }
                case 1: {
                    return v1;
                    break;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
        }
    }
}
function make_alt_14(v0: UH3, v1: UH3): UH3 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                let v2: UH3 = v0.f0;
                let v3: UH3 = v0.f1;
                let v4: UH3 = alt_insert_sorted_15(v2, v1);
                {
                    let t0 = v3;
                    let t1 = v4;
                    v0 = t0;
                    v1 = t1;
                }
                continue tail;
                break;
            }
            case 0: {
                return v1;
                break;
            }
            default: {
                return alt_insert_sorted_15(v0, v1);
            }
        }
    }
}
function regex_equal_18(v0: UH3, v1: UH3): boolean {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                let v24: UH3 = v0.f0;
                let v25: UH3 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        let v26: UH3 = v1.f0;
                        let v27: UH3 = v1.f1;
                        let v28: boolean = regex_equal_18(v24, v26);
                        if (v28) {
                            {
                                let t0 = v25;
                                let t1 = v27;
                                v0 = t0;
                                v1 = t1;
                            }
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
                let v32: UH3 = v0.f0;
                let v33: UH3 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        let v34: UH3 = v1.f0;
                        let v35: UH3 = v1.f1;
                        let v36: boolean = regex_equal_18(v32, v34);
                        if (v36) {
                            {
                                let t0 = v33;
                                let t1 = v35;
                                v0 = t0;
                                v1 = t1;
                            }
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
                        let v5: US1 = v1.f0;
                        let v21: US2;
                        switch (v4.tag) {
                            case 0: {
                                switch (v5.tag) {
                                    case 0: {
                                        v21 = US2_SymbolSame();
                                        break;
                                    }
                                    default: {
                                        v21 = US2_SymbolLess();
                                    }
                                }
                                break;
                            }
                            default: {
                                switch (v5.tag) {
                                    case 0: {
                                        v21 = US2_SymbolGreater();
                                        break;
                                    }
                                    default: {
                                        switch (v4.tag) {
                                            case 1: {
                                                switch (v5.tag) {
                                                    case 1: {
                                                        v21 = US2_SymbolSame();
                                                        break;
                                                    }
                                                    case 2: {
                                                        v21 = US2_SymbolLess();
                                                        break;
                                                    }
                                                    default: throw new Error("Compiler error: unreachable union case.");
                                                }
                                                break;
                                            }
                                            case 2: {
                                                switch (v5.tag) {
                                                    case 1: {
                                                        v21 = US2_SymbolGreater();
                                                        break;
                                                    }
                                                    case 2: {
                                                        v21 = US2_SymbolSame();
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
                                break;
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
                        break;
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
                        break;
                    }
                    default: {
                        return false;
                    }
                }
                break;
            }
            case 5: {
                let v40: UH3 = v0.f0;
                switch (v1.tag) {
                    case 5: {
                        let v41: UH3 = v1.f0;
                        {
                            let t0 = v40;
                            let t1 = v41;
                            v0 = t0;
                            v1 = t1;
                        }
                        continue tail;
                        break;
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
function make_cat_17(v0: UH3, v1: UH3): UH3 {
    switch (v0.tag) {
        case 0: {
            return UH3_RegexEmpty();
            break;
        }
        default: {
            switch (v1.tag) {
                case 0: {
                    return UH3_RegexEmpty();
                    break;
                }
                default: {
                    switch (v0.tag) {
                        case 1: {
                            return v1;
                            break;
                        }
                        default: {
                            switch (v1.tag) {
                                case 1: {
                                    return v0;
                                    break;
                                }
                                default: {
                                    switch (v0.tag) {
                                        case 4: {
                                            let v12: UH3 = v0.f0;
                                            let v13: UH3 = v0.f1;
                                            let v14: UH3 = make_cat_17(v13, v1);
                                            return UH3_RegexCat(v12, v14);
                                            break;
                                        }
                                        case 5: {
                                            let v4: UH3 = v0.f0;
                                            switch (v1.tag) {
                                                case 5: {
                                                    let v5: UH3 = v1.f0;
                                                    let v6: boolean = regex_equal_18(v4, v5);
                                                    if (v6) {
                                                        return UH3_RegexStar(v4);
                                                    } else {
                                                        return UH3_RegexCat(v0, v1);
                                                    }
                                                    break;
                                                }
                                                default: {
                                                    return UH3_RegexCat(v0, v1);
                                                }
                                            }
                                            break;
                                        }
                                        default: {
                                            return UH3_RegexCat(v0, v1);
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
function make_star_19(v0: UH3): UH3 {
    switch (v0.tag) {
        case 0: {
            return UH3_RegexEpsilon();
            break;
        }
        case 1: {
            return UH3_RegexEpsilon();
            break;
        }
        case 5: {
            let v3: UH3 = v0.f0;
            return UH3_RegexStar(v3);
            break;
        }
        default: {
            return UH3_RegexStar(v0);
        }
    }
}
function normalize_13(v0: UH3): UH3 {
    switch (v0.tag) {
        case 3: {
            let v5: UH3 = v0.f0;
            let v6: UH3 = v0.f1;
            let v7: UH3 = normalize_13(v5);
            let v8: UH3 = normalize_13(v6);
            return make_alt_14(v7, v8);
            break;
        }
        case 4: {
            let v10: UH3 = v0.f0;
            let v11: UH3 = v0.f1;
            let v12: UH3 = normalize_13(v10);
            let v13: UH3 = normalize_13(v11);
            return make_cat_17(v12, v13);
            break;
        }
        case 2: {
            let v3: US1 = v0.f0;
            return UH3_RegexChar(v3);
            break;
        }
        case 0: {
            return UH3_RegexEmpty();
            break;
        }
        case 1: {
            return UH3_RegexEpsilon();
            break;
        }
        case 5: {
            let v15: UH3 = v0.f0;
            let v16: UH3 = normalize_13(v15);
            return make_star_19(v16);
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function nullable_21(v0: UH3): US3 {
    switch (v0.tag) {
        case 3: {
            let v5: UH3 = v0.f0;
            let v6: UH3 = v0.f1;
            let v7: US3 = nullable_21(v5);
            let v8: US3 = nullable_21(v6);
            switch (v7.tag) {
                case 0: {
                    return US3_Nullable();
                    break;
                }
                default: {
                    switch (v8.tag) {
                        case 0: {
                            return US3_Nullable();
                            break;
                        }
                        default: {
                            switch (v7.tag) {
                                case 1: {
                                    switch (v8.tag) {
                                        case 1: {
                                            return US3_NonNullable();
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
            break;
        }
        case 4: {
            let v16: UH3 = v0.f0;
            let v17: UH3 = v0.f1;
            let v18: US3 = nullable_21(v16);
            let v19: US3 = nullable_21(v17);
            switch (v18.tag) {
                case 0: {
                    switch (v19.tag) {
                        case 0: {
                            return US3_Nullable();
                            break;
                        }
                        default: {
                            return US3_NonNullable();
                        }
                    }
                    break;
                }
                default: {
                    return US3_NonNullable();
                }
            }
            break;
        }
        case 2: {
            let v3: US1 = v0.f0;
            return US3_NonNullable();
            break;
        }
        case 0: {
            return US3_NonNullable();
            break;
        }
        case 1: {
            return US3_Nullable();
            break;
        }
        case 5: {
            let v25: UH3 = v0.f0;
            return US3_Nullable();
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function derivative_20(v0: UH3, v1: US1): UH3 {
    switch (v0.tag) {
        case 3: {
            let v25: UH3 = v0.f0;
            let v26: UH3 = v0.f1;
            let v27: UH3 = derivative_20(v25, v1);
            let v28: UH3 = derivative_20(v26, v1);
            return make_alt_14(v27, v28);
            break;
        }
        case 4: {
            let v30: UH3 = v0.f0;
            let v31: UH3 = v0.f1;
            let v32: US3 = nullable_21(v30);
            switch (v32.tag) {
                case 1: {
                    let v37: UH3 = derivative_20(v30, v1);
                    return make_cat_17(v37, v31);
                    break;
                }
                case 0: {
                    let v33: UH3 = derivative_20(v30, v1);
                    let v34: UH3 = make_cat_17(v33, v31);
                    let v35: UH3 = derivative_20(v31, v1);
                    return make_alt_14(v34, v35);
                    break;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        case 2: {
            let v4: US1 = v0.f0;
            let v20: US2;
            switch (v4.tag) {
                case 0: {
                    switch (v1.tag) {
                        case 0: {
                            v20 = US2_SymbolSame();
                            break;
                        }
                        default: {
                            v20 = US2_SymbolLess();
                        }
                    }
                    break;
                }
                default: {
                    switch (v1.tag) {
                        case 0: {
                            v20 = US2_SymbolGreater();
                            break;
                        }
                        default: {
                            switch (v4.tag) {
                                case 1: {
                                    switch (v1.tag) {
                                        case 1: {
                                            v20 = US2_SymbolSame();
                                            break;
                                        }
                                        case 2: {
                                            v20 = US2_SymbolLess();
                                            break;
                                        }
                                        default: throw new Error("Compiler error: unreachable union case.");
                                    }
                                    break;
                                }
                                case 2: {
                                    switch (v1.tag) {
                                        case 1: {
                                            v20 = US2_SymbolGreater();
                                            break;
                                        }
                                        case 2: {
                                            v20 = US2_SymbolSame();
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
                return UH3_RegexEpsilon();
            } else {
                return UH3_RegexEmpty();
            }
            break;
        }
        case 0: {
            return UH3_RegexEmpty();
            break;
        }
        case 1: {
            return UH3_RegexEmpty();
            break;
        }
        case 5: {
            let v41: UH3 = v0.f0;
            let v42: UH3 = derivative_20(v41, v1);
            let v43: UH3 = make_star_19(v41);
            return make_cat_17(v42, v43);
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function canonical_derivative_12(v0: UH3, v1: US1): UH3 {
    let v2: UH3 = normalize_13(v0);
    let v3: UH3 = derivative_20(v2, v1);
    return normalize_13(v3);
}
function accepts_11(v0: UH3, v1: UH1): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                let v6: US1 = v1.f0;
                let v7: UH1 = v1.f1;
                let v8: UH3 = canonical_derivative_12(v0, v6);
                {
                    let t0 = v8;
                    let t1 = v7;
                    v0 = t0;
                    v1 = t1;
                }
                continue tail;
                break;
            }
            case 0: {
                let v2: UH3 = normalize_13(v0);
                let v3: US3 = nullable_21(v2);
                switch (v3.tag) {
                    case 1: {
                        return false;
                        break;
                    }
                    case 0: {
                        return true;
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
function decide_bit_match_22(v0: US4): US5 {
    switch (v0.tag) {
        case 0: {
            let v1: UH2 = v0.f0;
            let v2: UH0 = v0.f1;
            let v3: boolean = accepts_0(v1, v2);
            return US5_BitMatcherDecided(v1, v2, v3);
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function bit_match_value_23(v0: US5): boolean {
    switch (v0.tag) {
        case 1: {
            let v1: UH2 = v0.f0;
            let v2: UH0 = v0.f1;
            let v3: boolean = v0.f2;
            return v3;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: US0 = US0_BitOne();
    let v1: US0 = US0_BitOne();
    let v2: US0 = US0_BitZero();
    let v3: UH0 = UH0_InputEmpty();
    let v4: UH0 = UH0_InputCons(v2, v3);
    let v5: UH0 = UH0_InputCons(v1, v4);
    let v6: UH0 = UH0_InputCons(v0, v5);
    let v7: US0 = US0_BitOne();
    let v8: US0 = US0_BitOne();
    let v9: US0 = US0_BitOne();
    let v10: UH0 = UH0_InputEmpty();
    let v11: UH0 = UH0_InputCons(v9, v10);
    let v12: UH0 = UH0_InputCons(v8, v11);
    let v13: UH0 = UH0_InputCons(v7, v12);
    let v14: US1 = US1_TriA();
    let v15: US1 = US1_TriA();
    let v16: US1 = US1_TriA();
    let v17: UH1 = UH1_InputEmpty();
    let v18: UH1 = UH1_InputCons(v16, v17);
    let v19: UH1 = UH1_InputCons(v15, v18);
    let v20: UH1 = UH1_InputCons(v14, v19);
    let v21: US1 = US1_TriA();
    let v22: US1 = US1_TriA();
    let v23: US1 = US1_TriB();
    let v24: UH1 = UH1_InputEmpty();
    let v25: UH1 = UH1_InputCons(v23, v24);
    let v26: UH1 = UH1_InputCons(v22, v25);
    let v27: UH1 = UH1_InputCons(v21, v26);
    let v28: US0 = US0_BitZero();
    let v29: UH2 = UH2_RegexChar(v28);
    let v30: US0 = US0_BitOne();
    let v31: UH2 = UH2_RegexChar(v30);
    let v32: UH2 = UH2_RegexAlt(v29, v31);
    let v33: UH2 = UH2_RegexStar(v32);
    let v34: US0 = US0_BitZero();
    let v35: UH2 = UH2_RegexChar(v34);
    let v36: UH2 = UH2_RegexCat(v33, v35);
    let v37: boolean = accepts_0(v36, v6);
    if (v37) {
    } else {
        throw new Error("brzozowski-expected-true");
    }
    let v38: US0 = US0_BitZero();
    let v39: UH2 = UH2_RegexChar(v38);
    let v40: US0 = US0_BitOne();
    let v41: UH2 = UH2_RegexChar(v40);
    let v42: UH2 = UH2_RegexAlt(v39, v41);
    let v43: UH2 = UH2_RegexStar(v42);
    let v44: US0 = US0_BitZero();
    let v45: UH2 = UH2_RegexChar(v44);
    let v46: UH2 = UH2_RegexCat(v43, v45);
    let v47: boolean = accepts_0(v46, v13);
    if (v47) {
        throw new Error("brzozowski-expected-false");
    }
    let v48: US1 = US1_TriA();
    let v49: UH3 = UH3_RegexChar(v48);
    let v50: UH3 = UH3_RegexStar(v49);
    let v51: boolean = accepts_11(v50, v20);
    if (v51) {
    } else {
        throw new Error("brzozowski-expected-true");
    }
    let v52: US1 = US1_TriA();
    let v53: UH3 = UH3_RegexChar(v52);
    let v54: UH3 = UH3_RegexStar(v53);
    let v55: boolean = accepts_11(v54, v27);
    if (v55) {
        throw new Error("brzozowski-expected-false");
    }
    let v56: US0 = US0_BitZero();
    let v57: UH2 = UH2_RegexChar(v56);
    let v58: US0 = US0_BitOne();
    let v59: UH2 = UH2_RegexChar(v58);
    let v60: UH2 = UH2_RegexAlt(v57, v59);
    let v61: UH2 = UH2_RegexStar(v60);
    let v62: US0 = US0_BitZero();
    let v63: UH2 = UH2_RegexChar(v62);
    let v64: UH2 = UH2_RegexCat(v61, v63);
    let v65: US4 = US4_BitMatcherRaw(v64, v6);
    let v66: US5 = decide_bit_match_22(v65);
    let v67: US0 = US0_BitZero();
    let v68: UH2 = UH2_RegexChar(v67);
    let v69: US0 = US0_BitOne();
    let v70: UH2 = UH2_RegexChar(v69);
    let v71: UH2 = UH2_RegexAlt(v68, v70);
    let v72: UH2 = UH2_RegexStar(v71);
    let v73: US0 = US0_BitZero();
    let v74: UH2 = UH2_RegexChar(v73);
    let v75: UH2 = UH2_RegexCat(v72, v74);
    let v76: US4 = US4_BitMatcherRaw(v75, v13);
    let v77: US5 = decide_bit_match_22(v76);
    let v78: boolean = bit_match_value_23(v66);
    if (v78) {
    } else {
        throw new Error("brzozowski-expected-true");
    }
    let v79: boolean = bit_match_value_23(v77);
    if (v79) {
        throw new Error("brzozowski-expected-false");
    }
    return 0;
}
process.exitCode = main();
