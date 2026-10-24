function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
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
type UH2_RegexListNil = { readonly tag: 0 };
type UH2_RegexListCons = { readonly tag: 1, readonly f0: UH0, readonly f1: UH2 };
type UH2 = UH2_RegexListNil | UH2_RegexListCons;
const UH2_RegexListNil_shared: UH2 = { tag: 0 }; function UH2_RegexListNil(): UH2 { return UH2_RegexListNil_shared; }
function UH2_RegexListCons(f0: UH0, f1: UH2): UH2 { return { tag: 1, f0: f0, f1: f1 }; }
function random_bit_input_1(v0: bigint, v1: number, v2: UH1): [UH1, bigint] {
    tail: while (true) {
        let v3: boolean = 0 < v1;
        if (v3) {
            let v4: bigint = BigInt.asUintN(64, v0 * 1103515245n);
            const v5: bigint = BigInt.asUintN(64, v4 + 12345n);
            const v6: bigint = v5 & 2147483647n;
            let v7: number = (v1 - 1) | 0;
            let v8: bigint = v6 >> BigInt(16 & 63);
            let v9: bigint = v8 & 1n;
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
function regex_compare_7(v0: UH0, v1: UH0): US1 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                const v53: UH0 = v0.f0;
                const v54: UH0 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        const v55: UH0 = v1.f0;
                        const v56: UH0 = v1.f1;
                        const v57: US1 = regex_compare_7(v53, v55);
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
                const v28: UH0 = v0.f0;
                const v29: UH0 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        const v34: UH0 = v1.f0;
                        const v35: UH0 = v1.f1;
                        const v36: US1 = regex_compare_7(v28, v34);
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
                        let v32: US0 = v1.f0;
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
                        let v45: UH0 = v1.f0;
                        const v46: UH0 = v1.f1;
                        return US1_SymbolLess();
                    }
                    case 5: {
                        let v48: UH0 = v1.f0;
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
function alt_insert_sorted_6(v0: UH0, v1: UH0): UH0 {
    switch (v1.tag) {
        case 3: {
            let v2: UH0 = v1.f0;
            let v3: UH0 = v1.f1;
            let v4: US1 = regex_compare_7(v0, v2);
            switch (v4.tag) {
                case 2: {
                    const v6: UH0 = alt_insert_sorted_6(v0, v3);
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
            let v11: US1 = regex_compare_7(v0, v1);
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
function make_alt_5(v0: UH0, v1: UH0): UH0 {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                let v2: UH0 = v0.f0;
                let v3: UH0 = v0.f1;
                let v4: UH0 = alt_insert_sorted_6(v2, v1);
                v0 = v3;
                v1 = v4;
                continue tail;
            }
            case 0: {
                return v1;
            }
            default: {
                return alt_insert_sorted_6(v0, v1);
            }
        }
    }
}
function regex_equal_9(v0: UH0, v1: UH0): boolean {
    tail: while (true) {
        switch (v0.tag) {
            case 3: {
                let v18: UH0 = v0.f0;
                let v19: UH0 = v0.f1;
                switch (v1.tag) {
                    case 3: {
                        let v20: UH0 = v1.f0;
                        let v21: UH0 = v1.f1;
                        let v22: boolean = regex_equal_9(v18, v20);
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
                const v26: UH0 = v0.f0;
                const v27: UH0 = v0.f1;
                switch (v1.tag) {
                    case 4: {
                        const v28: UH0 = v1.f0;
                        const v29: UH0 = v1.f1;
                        const v30: boolean = regex_equal_9(v26, v28);
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
function make_cat_8(v0: UH0, v1: UH0): UH0 {
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
                                            let v14: UH0 = make_cat_8(v13, v1);
                                            return UH0_RegexCat(v12, v14);
                                        }
                                        case 5: {
                                            let v4: UH0 = v0.f0;
                                            switch (v1.tag) {
                                                case 5: {
                                                    const v5: UH0 = v1.f0;
                                                    const v6: boolean = regex_equal_9(v4, v5);
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
function make_star_10(v0: UH0): UH0 {
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
function normalize_4(v0: UH0): UH0 {
    switch (v0.tag) {
        case 3: {
            const v5: UH0 = v0.f0;
            const v6: UH0 = v0.f1;
            let v7: UH0 = normalize_4(v5);
            let v8: UH0 = normalize_4(v6);
            return make_alt_5(v7, v8);
        }
        case 4: {
            let v10: UH0 = v0.f0;
            let v11: UH0 = v0.f1;
            const v12: UH0 = normalize_4(v10);
            let v13: UH0 = normalize_4(v11);
            return make_cat_8(v12, v13);
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
            let v16: UH0 = normalize_4(v15);
            return make_star_10(v16);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function nullable_12(v0: UH0): US2 {
    switch (v0.tag) {
        case 3: {
            const v5: UH0 = v0.f0;
            const v6: UH0 = v0.f1;
            let v7: US2 = nullable_12(v5);
            let v8: US2 = nullable_12(v6);
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
            let v18: US2 = nullable_12(v16);
            let v19: US2 = nullable_12(v17);
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
            const v25: UH0 = v0.f0;
            return US2_Nullable();
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function derivative_11(v0: UH0, v1: US0): UH0 {
    switch (v0.tag) {
        case 3: {
            let v19: UH0 = v0.f0;
            let v20: UH0 = v0.f1;
            let v21: UH0 = derivative_11(v19, v1);
            let v22: UH0 = derivative_11(v20, v1);
            return make_alt_5(v21, v22);
        }
        case 4: {
            const v24: UH0 = v0.f0;
            const v25: UH0 = v0.f1;
            const v26: US2 = nullable_12(v24);
            switch (v26.tag) {
                case 1: {
                    const v31: UH0 = derivative_11(v24, v1);
                    return make_cat_8(v31, v25);
                }
                case 0: {
                    const v27: UH0 = derivative_11(v24, v1);
                    const v28: UH0 = make_cat_8(v27, v25);
                    const v29: UH0 = derivative_11(v25, v1);
                    return make_alt_5(v28, v29);
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
            const v36: UH0 = derivative_11(v35, v1);
            const v37: UH0 = make_star_10(v35);
            return make_cat_8(v36, v37);
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function canonical_derivative_3(v0: UH0, v1: US0): UH0 {
    let v2: UH0 = normalize_4(v0);
    let v3: UH0 = derivative_11(v2, v1);
    return normalize_4(v3);
}
function accepts_2(v0: UH0, v1: UH1): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                const v6: US0 = v1.f0;
                let v7: UH1 = v1.f1;
                let v8: UH0 = canonical_derivative_3(v0, v6);
                v0 = v8;
                v1 = v7;
                continue tail;
            }
            case 0: {
                let v2: UH0 = normalize_4(v0);
                let v3: US2 = nullable_12(v2);
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
function loop_0(v0: UH0, v1: number, v2: number, v3: bigint, v4: number): number {
    tail: while (true) {
        const v5: boolean = 0 < v2;
        if (v5) {
            const v6: UH1 = UH1_InputEmpty();
            let [v7, v8]: [UH1, bigint] = random_bit_input_1(v3, v1, v6);
            let v9: boolean = accepts_2(v0, v7);
            let v11: number;
            if (v9) {
                let v10: number = (v4 + 1) | 0;
                v11 = v10;
            } else {
                v11 = v4;
            }
            const v12: number = (v2 - 1) | 0;
            v2 = v12;
            v3 = v8;
            v4 = v11;
            continue tail;
        } else {
            return v4;
        }
    }
}
function zeros_input_14(v0: number, v1: UH1): UH1 {
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
function loop_13(v0: UH0, v1: number, v2: number, v3: number): number {
    tail: while (true) {
        let v4: boolean = v1 < v2;
        if (v4) {
            return v3;
        } else {
            const v5: UH1 = UH1_InputEmpty();
            const v6: UH1 = zeros_input_14(v2, v5);
            let v7: boolean = accepts_2(v0, v6);
            let v9: number;
            if (v7) {
                let v8: number = (v3 + 1) | 0;
                v9 = v8;
            } else {
                v9 = v3;
            }
            let v10: US0 = US0_BitOne();
            let v11: UH1 = UH1_InputEmpty();
            const v12: UH1 = UH1_InputCons(v10, v11);
            let v13: UH1 = zeros_input_14(v2, v12);
            let v14: boolean = accepts_2(v0, v13);
            let v16: number;
            if (v14) {
                let v15: number = (v9 + 1) | 0;
                v16 = v15;
            } else {
                v16 = v9;
            }
            let v17: number = (v2 + 1) | 0;
            v2 = v17;
            v3 = v16;
            continue tail;
        }
    }
}
function backtrack_stack_16(v0: UH2, v1: UH1): boolean {
    tail: while (true) {
        switch (v0.tag) {
            case 1: {
                const v6: UH0 = v0.f0;
                let v7: UH2 = v0.f1;
                switch (v6.tag) {
                    case 3: {
                        const v27: UH0 = v6.f0;
                        const v28: UH0 = v6.f1;
                        const v29: UH2 = UH2_RegexListCons(v27, v7);
                        const v30: boolean = backtrack_stack_16(v29, v1);
                        if (v30) {
                            return true;
                        } else {
                            const v31: UH2 = UH2_RegexListCons(v28, v7);
                            v0 = v31;
                            continue tail;
                        }
                        break;
                    }
                    case 4: {
                        const v34: UH0 = v6.f0;
                        const v35: UH0 = v6.f1;
                        const v36: UH2 = UH2_RegexListCons(v35, v7);
                        const v37: UH2 = UH2_RegexListCons(v34, v36);
                        v0 = v37;
                        continue tail;
                    }
                    case 2: {
                        let v9: US0 = v6.f0;
                        switch (v1.tag) {
                            case 1: {
                                let v10: US0 = v1.f0;
                                let v11: UH1 = v1.f1;
                                let v21: US1;
                                switch (v9.tag) {
                                    case 1: {
                                        switch (v10.tag) {
                                            case 1: {
                                                v21 = US1_SymbolSame();
                                                break;
                                            }
                                            case 0: {
                                                v21 = US1_SymbolGreater();
                                                break;
                                            }
                                            default: throw new Error("Compiler error: unreachable union case.");
                                        }
                                        break;
                                    }
                                    case 0: {
                                        switch (v10.tag) {
                                            case 1: {
                                                v21 = US1_SymbolLess();
                                                break;
                                            }
                                            case 0: {
                                                v21 = US1_SymbolSame();
                                                break;
                                            }
                                            default: throw new Error("Compiler error: unreachable union case.");
                                        }
                                        break;
                                    }
                                    default: throw new Error("Compiler error: unreachable union case.");
                                }
                                let v22: boolean;
                                switch (v21.tag) {
                                    case 1: {
                                        v22 = true;
                                        break;
                                    }
                                    default: {
                                        v22 = false;
                                    }
                                }
                                if (v22) {
                                    v0 = v7;
                                    v1 = v11;
                                    continue tail;
                                } else {
                                    return false;
                                }
                                break;
                            }
                            case 0: {
                                return false;
                            }
                            default: throw new Error("Compiler error: unreachable union case.");
                        }
                        break;
                    }
                    case 0: {
                        return false;
                    }
                    case 1: {
                        v0 = v7;
                        continue tail;
                    }
                    case 5: {
                        const v39: UH0 = v6.f0;
                        const v40: UH2 = UH2_RegexListCons(v39, v0);
                        let v41: boolean = backtrack_stack_16(v40, v1);
                        if (v41) {
                            return true;
                        } else {
                            v0 = v7;
                            continue tail;
                        }
                        break;
                    }
                    default: throw new Error("Compiler error: unreachable union case.");
                }
                break;
            }
            case 0: {
                switch (v1.tag) {
                    case 1: {
                        let v2: US0 = v1.f0;
                        let v3: UH1 = v1.f1;
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
function loop_15(v0: UH0, v1: number, v2: number, v3: bigint, v4: number): number {
    tail: while (true) {
        const v5: boolean = 0 < v2;
        if (v5) {
            const v6: UH1 = UH1_InputEmpty();
            let [v7, v8]: [UH1, bigint] = random_bit_input_1(v3, v1, v6);
            let v9: UH2 = UH2_RegexListNil();
            let v10: UH2 = UH2_RegexListCons(v0, v9);
            let v11: boolean = backtrack_stack_16(v10, v7);
            let v13: number;
            if (v11) {
                const v12: number = (v4 + 1) | 0;
                v13 = v12;
            } else {
                v13 = v4;
            }
            let v14: number = (v2 - 1) | 0;
            v2 = v14;
            v3 = v8;
            v4 = v13;
            continue tail;
        } else {
            return v4;
        }
    }
}
function loop_17(v0: UH0, v1: number, v2: number, v3: number): number {
    tail: while (true) {
        let v4: boolean = v1 < v2;
        if (v4) {
            return v3;
        } else {
            const v5: UH1 = UH1_InputEmpty();
            const v6: UH1 = zeros_input_14(v2, v5);
            let v7: UH2 = UH2_RegexListNil();
            let v8: UH2 = UH2_RegexListCons(v0, v7);
            let v9: boolean = backtrack_stack_16(v8, v6);
            let v11: number;
            if (v9) {
                let v10: number = (v3 + 1) | 0;
                v11 = v10;
            } else {
                v11 = v3;
            }
            const v12: US0 = US0_BitOne();
            let v13: UH1 = UH1_InputEmpty();
            let v14: UH1 = UH1_InputCons(v12, v13);
            let v15: UH1 = zeros_input_14(v2, v14);
            let v16: UH2 = UH2_RegexListNil();
            let v17: UH2 = UH2_RegexListCons(v0, v16);
            let v18: boolean = backtrack_stack_16(v17, v15);
            let v20: number;
            if (v18) {
                let v19: number = (v11 + 1) | 0;
                v20 = v19;
            } else {
                v20 = v11;
            }
            let v21: number = (v2 + 1) | 0;
            v2 = v21;
            v3 = v20;
            continue tail;
        }
    }
}
function run_19(v0: number, v1: UH1): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                let v3: US0 = v1.f0;
                let v4: UH1 = v1.f1;
                switch (v3.tag) {
                    case 1: {
                        let v9: number = 0;
                        v0 = v9;
                        v1 = v4;
                        continue tail;
                    }
                    case 0: {
                        const v6: number = 1;
                        v0 = v6;
                        v1 = v4;
                        continue tail;
                    }
                    default: throw new Error("Compiler error: unreachable union case.");
                }
                break;
            }
            case 0: {
                let v2: boolean = v0 === 1;
                return v2;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function loop_18(v0: number, v1: number, v2: bigint, v3: number): number {
    tail: while (true) {
        let v4: boolean = 0 < v1;
        if (v4) {
            const v5: UH1 = UH1_InputEmpty();
            let [v6, v7]: [UH1, bigint] = random_bit_input_1(v2, v0, v5);
            let v8: number = 0;
            let v9: boolean = run_19(v8, v6);
            let v11: number;
            if (v9) {
                let v10: number = (v3 + 1) | 0;
                v11 = v10;
            } else {
                v11 = v3;
            }
            const v12: number = (v1 - 1) | 0;
            v1 = v12;
            v2 = v7;
            v3 = v11;
            continue tail;
        } else {
            return v3;
        }
    }
}
function run_21(v0: number, v1: UH1): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                let v17: US0 = v1.f0;
                let v18: UH1 = v1.f1;
                switch (v17.tag) {
                    case 1: {
                        const v50: boolean = v0 === 0;
                        let v79: number;
                        if (v50) {
                            v79 = 1;
                        } else {
                            const v51: boolean = v0 === 1;
                            if (v51) {
                                v79 = 6;
                            } else {
                                const v52: boolean = v0 === 2;
                                if (v52) {
                                    v79 = 11;
                                } else {
                                    const v53: boolean = v0 === 3;
                                    if (v53) {
                                        v79 = 5;
                                    } else {
                                        const v54: boolean = v0 === 4;
                                        if (v54) {
                                            v79 = 1;
                                        } else {
                                            const v55: boolean = v0 === 5;
                                            if (v55) {
                                                v79 = 6;
                                            } else {
                                                const v56: boolean = v0 === 6;
                                                if (v56) {
                                                    v79 = 13;
                                                } else {
                                                    const v57: boolean = v0 === 7;
                                                    if (v57) {
                                                        v79 = 9;
                                                    } else {
                                                        const v58: boolean = v0 === 8;
                                                        if (v58) {
                                                            v79 = 5;
                                                        } else {
                                                            const v59: boolean = v0 === 9;
                                                            if (v59) {
                                                                v79 = 12;
                                                            } else {
                                                                const v60: boolean = v0 === 10;
                                                                if (v60) {
                                                                    v79 = 11;
                                                                } else {
                                                                    const v61: boolean = v0 === 11;
                                                                    if (v61) {
                                                                        v79 = 12;
                                                                    } else {
                                                                        const v62: boolean = v0 === 12;
                                                                        if (v62) {
                                                                            v79 = 13;
                                                                        } else {
                                                                            const v63: boolean = v0 === 13;
                                                                            if (v63) {
                                                                                v79 = 15;
                                                                            } else {
                                                                                const v64: boolean = v0 === 14;
                                                                                if (v64) {
                                                                                    v79 = 9;
                                                                                } else {
                                                                                    v79 = 15;
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
                        v0 = v79;
                        v1 = v18;
                        continue tail;
                    }
                    case 0: {
                        let v19: boolean = v0 === 0;
                        let v48: number;
                        if (v19) {
                            v48 = 0;
                        } else {
                            let v20: boolean = v0 === 1;
                            if (v20) {
                                v48 = 2;
                            } else {
                                let v21: boolean = v0 === 2;
                                if (v21) {
                                    v48 = 3;
                                } else {
                                    let v22: boolean = v0 === 3;
                                    if (v22) {
                                        v48 = 4;
                                    } else {
                                        let v23: boolean = v0 === 4;
                                        if (v23) {
                                            v48 = 0;
                                        } else {
                                            const v24: boolean = v0 === 5;
                                            if (v24) {
                                                v48 = 2;
                                            } else {
                                                const v25: boolean = v0 === 6;
                                                if (v25) {
                                                    v48 = 7;
                                                } else {
                                                    const v26: boolean = v0 === 7;
                                                    if (v26) {
                                                        v48 = 8;
                                                    } else {
                                                        const v27: boolean = v0 === 8;
                                                        if (v27) {
                                                            v48 = 4;
                                                        } else {
                                                            const v28: boolean = v0 === 9;
                                                            if (v28) {
                                                                v48 = 10;
                                                            } else {
                                                                const v29: boolean = v0 === 10;
                                                                if (v29) {
                                                                    v48 = 3;
                                                                } else {
                                                                    const v30: boolean = v0 === 11;
                                                                    if (v30) {
                                                                        v48 = 10;
                                                                    } else {
                                                                        const v31: boolean = v0 === 12;
                                                                        if (v31) {
                                                                            v48 = 7;
                                                                        } else {
                                                                            let v32: boolean = v0 === 13;
                                                                            if (v32) {
                                                                                v48 = 14;
                                                                            } else {
                                                                                let v33: boolean = v0 === 14;
                                                                                if (v33) {
                                                                                    v48 = 8;
                                                                                } else {
                                                                                    v48 = 14;
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
                        v0 = v48;
                        v1 = v18;
                        continue tail;
                    }
                    default: throw new Error("Compiler error: unreachable union case.");
                }
                break;
            }
            case 0: {
                let v2: boolean = v0 === 4;
                if (v2) {
                    return true;
                } else {
                    let v3: boolean = v0 === 5;
                    if (v3) {
                        return true;
                    } else {
                        let v4: boolean = v0 === 8;
                        if (v4) {
                            return true;
                        } else {
                            const v5: boolean = v0 === 9;
                            if (v5) {
                                return true;
                            } else {
                                const v6: boolean = v0 === 10;
                                if (v6) {
                                    return true;
                                } else {
                                    let v7: boolean = v0 === 12;
                                    if (v7) {
                                        return true;
                                    } else {
                                        let v8: boolean = v0 === 14;
                                        if (v8) {
                                            return true;
                                        } else {
                                            let v9: boolean = v0 === 15;
                                            return v9;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function loop_20(v0: number, v1: number, v2: bigint, v3: number): number {
    tail: while (true) {
        let v4: boolean = 0 < v1;
        if (v4) {
            const v5: UH1 = UH1_InputEmpty();
            let [v6, v7]: [UH1, bigint] = random_bit_input_1(v2, v0, v5);
            let v8: number = 0;
            let v9: boolean = run_21(v8, v6);
            let v11: number;
            if (v9) {
                let v10: number = (v3 + 1) | 0;
                v11 = v10;
            } else {
                v11 = v3;
            }
            const v12: number = (v1 - 1) | 0;
            v1 = v12;
            v2 = v7;
            v3 = v11;
            continue tail;
        } else {
            return v3;
        }
    }
}
function run_23(v0: number, v1: UH1): boolean {
    tail: while (true) {
        switch (v1.tag) {
            case 1: {
                let v3: US0 = v1.f0;
                let v4: UH1 = v1.f1;
                switch (v3.tag) {
                    case 1: {
                        let v13: boolean = v0 === 0;
                        let v19: number;
                        if (v13) {
                            v19 = 3;
                        } else {
                            let v14: boolean = v0 === 1;
                            if (v14) {
                                v19 = 3;
                            } else {
                                let v15: boolean = v0 === 2;
                                if (v15) {
                                    v19 = 3;
                                } else {
                                    v19 = 4;
                                }
                            }
                        }
                        v0 = v19;
                        v1 = v4;
                        continue tail;
                    }
                    case 0: {
                        const v5: boolean = v0 === 0;
                        let v11: number;
                        if (v5) {
                            v11 = 1;
                        } else {
                            const v6: boolean = v0 === 1;
                            if (v6) {
                                v11 = 2;
                            } else {
                                let v7: boolean = v0 === 2;
                                if (v7) {
                                    v11 = 2;
                                } else {
                                    v11 = 4;
                                }
                            }
                        }
                        v0 = v11;
                        v1 = v4;
                        continue tail;
                    }
                    default: throw new Error("Compiler error: unreachable union case.");
                }
                break;
            }
            case 0: {
                let v2: boolean = v0 === 3;
                return v2;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
function loop_22(v0: number, v1: number, v2: number): number {
    tail: while (true) {
        let v3: boolean = v0 < v1;
        if (v3) {
            return v2;
        } else {
            let v4: UH1 = UH1_InputEmpty();
            const v5: UH1 = zeros_input_14(v1, v4);
            const v6: number = 0;
            let v7: boolean = run_23(v6, v5);
            let v9: number;
            if (v7) {
                let v8: number = (v2 + 1) | 0;
                v9 = v8;
            } else {
                v9 = v2;
            }
            let v10: US0 = US0_BitOne();
            let v11: UH1 = UH1_InputEmpty();
            const v12: UH1 = UH1_InputCons(v10, v11);
            let v13: UH1 = zeros_input_14(v1, v12);
            let v14: number = 0;
            let v15: boolean = run_23(v14, v13);
            let v17: number;
            if (v15) {
                let v16: number = (v9 + 1) | 0;
                v17 = v16;
            } else {
                v17 = v9;
            }
            let v18: number = (v1 + 1) | 0;
            v1 = v18;
            v2 = v17;
            continue tail;
        }
    }
}
function loop_24(v0: Array<number>, v1: number): void {
    tail: while (true) {
        let v2: boolean = v1 < 8192;
        if (v2) {
            spiral_array_set(v0, v1, 0);
            let v3: number = (v1 + 1) | 0;
            v1 = v3;
            continue tail;
        } else {
            return;
        }
    }
}
function loop_25(v0: Array<number>, v1: number): void {
    tail: while (true) {
        let v2: boolean = v1 < 1;
        if (v2) {
            spiral_array_set(v0, v1, 0);
            let v3: number = (v1 + 1) | 0;
            v1 = v3;
            continue tail;
        } else {
            return;
        }
    }
}
function probe_27(v0: Array<number>, v1: Array<number>, v2: Array<number>, v3: Array<number>, v4: Array<number>, v5: Array<number>, v6: Array<number>, v7: number, v8: number, v9: number, v10: number): number {
    tail: while (true) {
        let v11: number = spiral_array_index(v4, v10);
        const v12: boolean = v11 === 0;
        if (v12) {
            let v13: number = spiral_array_index(v6, 0);
            let v14: boolean = v13 < 4096;
            if (v14) {
                spiral_array_set(v0, v13, v7);
                spiral_array_set(v1, v13, v8);
                spiral_array_set(v2, v13, v9);
                let v15: boolean = v7 === 1;
                let v32: boolean;
                if (v15) {
                    v32 = true;
                } else {
                    let v16: boolean = v7 === 5;
                    if (v16) {
                        v32 = true;
                    } else {
                        let v17: boolean = v7 === 3;
                        if (v17) {
                            let v18: number = spiral_array_index(v3, v8);
                            let v19: boolean = v18 === 1;
                            if (v19) {
                                v32 = true;
                            } else {
                                let v20: number = spiral_array_index(v3, v9);
                                let v21: boolean = v20 === 1;
                                v32 = v21;
                            }
                        } else {
                            let v23: boolean = v7 === 4;
                            if (v23) {
                                const v24: number = spiral_array_index(v3, v8);
                                const v25: boolean = v24 === 1;
                                if (v25) {
                                    const v26: number = spiral_array_index(v3, v9);
                                    const v27: boolean = v26 === 1;
                                    v32 = v27;
                                } else {
                                    v32 = false;
                                }
                            } else {
                                v32 = false;
                            }
                        }
                    }
                }
                let v33: number;
                if (v32) {
                    v33 = 1;
                } else {
                    v33 = 0;
                }
                spiral_array_set(v3, v13, v33);
                const v34: number = (v13 + 1) | 0;
                spiral_array_set(v4, v10, v34);
                spiral_array_set(v6, 0, v34);
                return v13;
            } else {
                throw new Error("brzozowski-interned-store-full");
            }
        } else {
            const v37: number = (v11 - 1) | 0;
            const v38: number = spiral_array_index(v0, v37);
            const v39: boolean = v38 === v7;
            let v42: boolean;
            if (v39) {
                const v40: number = spiral_array_index(v1, v37);
                let v41: boolean = v40 === v8;
                v42 = v41;
            } else {
                v42 = false;
            }
            let v45: boolean;
            if (v42) {
                const v43: number = spiral_array_index(v2, v37);
                const v44: boolean = v43 === v9;
                v45 = v44;
            } else {
                v45 = false;
            }
            if (v45) {
                return v37;
            } else {
                const v46: number = (v10 + 1) | 0;
                const v47: number = v46 & 8191;
                v10 = v47;
                continue tail;
            }
        }
    }
}
function interned_node_26(v0: Array<number>, v1: Array<number>, v2: Array<number>, v3: Array<number>, v4: Array<number>, v5: Array<number>, v6: Array<number>, v7: number, v8: number, v9: number): number {
    let v10: number = Math.imul(v7, 1024);
    let v11: number = (v10 + v8) | 0;
    const v12: number = Math.imul(v11, 4099);
    let v13: number = (v12 + v9) | 0;
    let v14: number = v13 & 8191;
    return probe_27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14);
}
function interned_alt_insert_30(v0: Array<number>, v1: Array<number>, v2: Array<number>, v3: Array<number>, v4: Array<number>, v5: Array<number>, v6: Array<number>, v7: number, v8: number): number {
    let v9: boolean = v8 === 0;
    if (v9) {
        return v7;
    } else {
        let v10: number = spiral_array_index(v0, v8);
        let v11: boolean = v10 === 3;
        if (v11) {
            const v12: number = spiral_array_index(v1, v8);
            let v13: boolean = v7 < v12;
            if (v13) {
                let v14: number = 3;
                return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8);
            } else {
                let v16: boolean = v7 === v12;
                if (v16) {
                    return v8;
                } else {
                    let v17: number = 3;
                    let v18: number = spiral_array_index(v2, v8);
                    let v19: number = interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v18);
                    return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19);
                }
            }
        } else {
            let v23: boolean = v7 < v8;
            if (v23) {
                const v24: number = 3;
                return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8);
            } else {
                const v26: boolean = v7 === v8;
                if (v26) {
                    return v8;
                } else {
                    const v27: number = 3;
                    return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7);
                }
            }
        }
    }
}
function interned_make_alt_29(v0: Array<number>, v1: Array<number>, v2: Array<number>, v3: Array<number>, v4: Array<number>, v5: Array<number>, v6: Array<number>, v7: number, v8: number): number {
    tail: while (true) {
        let v9: boolean = v7 === 0;
        if (v9) {
            return v8;
        } else {
            let v10: number = spiral_array_index(v0, v7);
            let v11: boolean = v10 === 3;
            if (v11) {
                const v12: number = spiral_array_index(v2, v7);
                let v13: number = spiral_array_index(v1, v7);
                let v14: number = interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v13, v8);
                v7 = v12;
                v8 = v14;
                continue tail;
            } else {
                return interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v8);
            }
        }
    }
}
function interned_make_cat_31(v0: Array<number>, v1: Array<number>, v2: Array<number>, v3: Array<number>, v4: Array<number>, v5: Array<number>, v6: Array<number>, v7: number, v8: number): number {
    let v9: boolean = v7 === 0;
    if (v9) {
        return 0;
    } else {
        let v10: boolean = v8 === 0;
        if (v10) {
            return 0;
        } else {
            let v11: boolean = v7 === 1;
            if (v11) {
                return v8;
            } else {
                const v12: boolean = v8 === 1;
                if (v12) {
                    return v7;
                } else {
                    let v13: number = spiral_array_index(v0, v7);
                    let v14: boolean = v13 === 5;
                    let v17: boolean;
                    if (v14) {
                        let v15: number = spiral_array_index(v0, v8);
                        let v16: boolean = v15 === 5;
                        v17 = v16;
                    } else {
                        v17 = false;
                    }
                    if (v17) {
                        let v18: number = spiral_array_index(v1, v7);
                        let v19: number = spiral_array_index(v1, v8);
                        let v20: boolean = v18 === v19;
                        if (v20) {
                            return v7;
                        } else {
                            let v21: number = 4;
                            return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8);
                        }
                    } else {
                        const v24: number = spiral_array_index(v0, v7);
                        const v25: boolean = v24 === 4;
                        if (v25) {
                            const v26: number = 4;
                            const v27: number = spiral_array_index(v1, v7);
                            const v28: number = spiral_array_index(v2, v7);
                            const v29: number = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v8);
                            return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29);
                        } else {
                            const v31: number = 4;
                            return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8);
                        }
                    }
                }
            }
        }
    }
}
function interned_of_regex_raw_28(v0: Array<number>, v1: Array<number>, v2: Array<number>, v3: Array<number>, v4: Array<number>, v5: Array<number>, v6: Array<number>, v7: UH0): number {
    switch (v7.tag) {
        case 3: {
            let v14: UH0 = v7.f0;
            let v15: UH0 = v7.f1;
            let v16: number = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v14);
            let v17: number = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v15);
            return interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v16, v17);
        }
        case 4: {
            let v19: UH0 = v7.f0;
            let v20: UH0 = v7.f1;
            let v21: number = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v19);
            let v22: number = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v20);
            return interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v21, v22);
        }
        case 2: {
            let v8: US0 = v7.f0;
            let v9: number = 2;
            let v11: number;
            switch (v8.tag) {
                case 1: {
                    v11 = 1;
                    break;
                }
                case 0: {
                    v11 = 0;
                    break;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            const v12: number = 0;
            return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12);
        }
        case 0: {
            return 0;
        }
        case 1: {
            return 1;
        }
        case 5: {
            const v24: UH0 = v7.f0;
            const v25: number = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v24);
            const v26: number = spiral_array_index(v0, v25);
            const v27: boolean = v26 < 2;
            if (v27) {
                return 1;
            } else {
                const v28: boolean = v26 === 5;
                if (v28) {
                    return v25;
                } else {
                    const v29: number = 5;
                    const v30: number = 0;
                    return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30);
                }
            }
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function interned_derivative_raw_35(v0: Array<number>, v1: Array<number>, v2: Array<number>, v3: Array<number>, v4: Array<number>, v5: Array<number>, v6: Array<number>, v7: number, v8: number): number {
    let v9: number = Math.imul(v7, 2);
    let v10: number = (v9 + v8) | 0;
    let v11: number = spiral_array_index(v5, v10);
    const v12: boolean = v11 === 0;
    if (v12) {
        let v13: number = spiral_array_index(v0, v7);
        let v14: boolean = v13 < 2;
        let v41: number;
        if (v14) {
            v41 = 0;
        } else {
            let v15: boolean = v13 === 2;
            if (v15) {
                let v16: number = spiral_array_index(v1, v7);
                let v17: boolean = v16 === v8;
                if (v17) {
                    v41 = 1;
                } else {
                    v41 = 0;
                }
            } else {
                let v19: boolean = v13 === 3;
                if (v19) {
                    let v20: number = spiral_array_index(v1, v7);
                    let v21: number = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v20, v8);
                    let v22: number = spiral_array_index(v2, v7);
                    let v23: number = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v22, v8);
                    v41 = interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v21, v23);
                } else {
                    const v25: boolean = v13 === 4;
                    if (v25) {
                        const v26: number = spiral_array_index(v1, v7);
                        const v27: number = spiral_array_index(v2, v7);
                        const v28: number = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v26, v8);
                        const v29: number = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v27);
                        const v30: number = spiral_array_index(v3, v26);
                        const v31: boolean = v30 === 1;
                        if (v31) {
                            let v32: number = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v27, v8);
                            v41 = interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v29, v32);
                        } else {
                            v41 = v29;
                        }
                    } else {
                        const v35: number = spiral_array_index(v1, v7);
                        const v36: number = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v35, v8);
                        v41 = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v36, v7);
                    }
                }
            }
        }
        let v42: number = (v41 + 1) | 0;
        spiral_array_set(v5, v10, v42);
        return v41;
    } else {
        const v43: number = (v11 - 1) | 0;
        return v43;
    }
}
function loop_34(v0: Array<number>, v1: Array<number>, v2: Array<number>, v3: Array<number>, v4: Array<number>, v5: Array<number>, v6: Array<number>, v7: number, v8: UH1): boolean {
    tail: while (true) {
        let v9: boolean = v7 === 0;
        if (v9) {
            return false;
        } else {
            switch (v8.tag) {
                case 1: {
                    const v12: US0 = v8.f0;
                    let v13: UH1 = v8.f1;
                    let v15: number;
                    switch (v12.tag) {
                        case 1: {
                            v15 = 1;
                            break;
                        }
                        case 0: {
                            v15 = 0;
                            break;
                        }
                        default: throw new Error("Compiler error: unreachable union case.");
                    }
                    let v16: number = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v7, v15);
                    v7 = v16;
                    v8 = v13;
                    continue tail;
                }
                case 0: {
                    let v10: number = spiral_array_index(v3, v7);
                    let v11: boolean = v10 === 1;
                    return v11;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
        }
    }
}
function interned_accepts_33(v0: Array<number>, v1: Array<number>, v2: Array<number>, v3: Array<number>, v4: Array<number>, v5: Array<number>, v6: Array<number>, v7: number, v8: UH1): boolean {
    return loop_34(v0, v1, v2, v3, v4, v5, v6, v7, v8);
}
function loop_32(v0: Array<number>, v1: Array<number>, v2: Array<number>, v3: Array<number>, v4: Array<number>, v5: Array<number>, v6: Array<number>, v7: number, v8: number, v9: number, v10: bigint, v11: number): number {
    tail: while (true) {
        const v12: boolean = 0 < v9;
        if (v12) {
            let v13: UH1 = UH1_InputEmpty();
            let [v14, v15]: [UH1, bigint] = random_bit_input_1(v10, v7, v13);
            let v16: boolean = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v14);
            let v18: number;
            if (v16) {
                let v17: number = (v11 + 1) | 0;
                v18 = v17;
            } else {
                v18 = v11;
            }
            let v19: number = (v9 - 1) | 0;
            v9 = v19;
            v10 = v15;
            v11 = v18;
            continue tail;
        } else {
            return v11;
        }
    }
}
function loop_36(v0: Array<number>, v1: Array<number>, v2: Array<number>, v3: Array<number>, v4: Array<number>, v5: Array<number>, v6: Array<number>, v7: number, v8: number, v9: number, v10: number): number {
    tail: while (true) {
        let v11: boolean = v7 < v9;
        if (v11) {
            return v10;
        } else {
            const v12: UH1 = UH1_InputEmpty();
            let v13: UH1 = zeros_input_14(v9, v12);
            let v14: boolean = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v13);
            let v16: number;
            if (v14) {
                let v15: number = (v10 + 1) | 0;
                v16 = v15;
            } else {
                v16 = v10;
            }
            let v17: US0 = US0_BitOne();
            let v18: UH1 = UH1_InputEmpty();
            let v19: UH1 = UH1_InputCons(v17, v18);
            let v20: UH1 = zeros_input_14(v9, v19);
            let v21: boolean = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v20);
            let v23: number;
            if (v21) {
                let v22: number = (v16 + 1) | 0;
                v23 = v22;
            } else {
                v23 = v16;
            }
            const v24: number = (v9 + 1) | 0;
            v9 = v24;
            v10 = v23;
            continue tail;
        }
    }
}
export function main(): number {
    let v0: number = 200;
    let v1: number = 32;
    let v2: US0 = US0_BitZero();
    let v3: UH0 = UH0_RegexChar(v2);
    let v4: US0 = US0_BitOne();
    const v5: UH0 = UH0_RegexChar(v4);
    const v6: UH0 = UH0_RegexAlt(v3, v5);
    let v7: UH0 = UH0_RegexStar(v6);
    let v8: US0 = US0_BitZero();
    let v9: UH0 = UH0_RegexChar(v8);
    let v10: UH0 = UH0_RegexCat(v7, v9);
    let v11: US0 = US0_BitZero();
    const v12: UH0 = UH0_RegexChar(v11);
    let v13: US0 = US0_BitOne();
    let v14: UH0 = UH0_RegexChar(v13);
    let v15: UH0 = UH0_RegexAlt(v12, v14);
    let v16: UH0 = UH0_RegexStar(v15);
    let v17: US0 = US0_BitOne();
    let v18: UH0 = UH0_RegexChar(v17);
    let v19: US0 = US0_BitZero();
    let v20: UH0 = UH0_RegexChar(v19);
    let v21: US0 = US0_BitOne();
    let v22: UH0 = UH0_RegexChar(v21);
    let v23: UH0 = UH0_RegexAlt(v20, v22);
    const v24: US0 = US0_BitZero();
    const v25: UH0 = UH0_RegexChar(v24);
    const v26: US0 = US0_BitOne();
    const v27: UH0 = UH0_RegexChar(v26);
    const v28: UH0 = UH0_RegexAlt(v25, v27);
    const v29: US0 = US0_BitZero();
    const v30: UH0 = UH0_RegexChar(v29);
    const v31: US0 = US0_BitOne();
    let v32: UH0 = UH0_RegexChar(v31);
    let v33: UH0 = UH0_RegexAlt(v30, v32);
    const v34: UH0 = UH0_RegexCat(v28, v33);
    const v35: UH0 = UH0_RegexCat(v23, v34);
    const v36: UH0 = UH0_RegexCat(v18, v35);
    const v37: UH0 = UH0_RegexCat(v16, v36);
    const v38: bigint = 1n;
    const v39: number = 0;
    const v40: number = loop_0(v10, v1, v0, v38, v39);
    let v41: number = loop_0(v37, v1, v0, v38, v39);
    let v42: number = 16;
    const v43: US0 = US0_BitZero();
    const v44: UH0 = UH0_RegexChar(v43);
    let v45: US0 = US0_BitZero();
    const v46: UH0 = UH0_RegexChar(v45);
    const v47: US0 = US0_BitZero();
    let v48: UH0 = UH0_RegexChar(v47);
    const v49: UH0 = UH0_RegexCat(v46, v48);
    const v50: UH0 = UH0_RegexAlt(v44, v49);
    const v51: UH0 = UH0_RegexStar(v50);
    const v52: US0 = US0_BitOne();
    const v53: UH0 = UH0_RegexChar(v52);
    const v54: UH0 = UH0_RegexCat(v51, v53);
    const v55: number = 0;
    const v56: number = 1;
    const v57: number = loop_13(v54, v42, v56, v55);
    const v58: number = 200;
    const v59: number = 32;
    const v60: US0 = US0_BitZero();
    const v61: UH0 = UH0_RegexChar(v60);
    const v62: US0 = US0_BitOne();
    const v63: UH0 = UH0_RegexChar(v62);
    const v64: UH0 = UH0_RegexAlt(v61, v63);
    const v65: UH0 = UH0_RegexStar(v64);
    const v66: US0 = US0_BitZero();
    const v67: UH0 = UH0_RegexChar(v66);
    const v68: UH0 = UH0_RegexCat(v65, v67);
    const v69: US0 = US0_BitZero();
    const v70: UH0 = UH0_RegexChar(v69);
    const v71: US0 = US0_BitOne();
    const v72: UH0 = UH0_RegexChar(v71);
    const v73: UH0 = UH0_RegexAlt(v70, v72);
    const v74: UH0 = UH0_RegexStar(v73);
    const v75: US0 = US0_BitOne();
    const v76: UH0 = UH0_RegexChar(v75);
    const v77: US0 = US0_BitZero();
    const v78: UH0 = UH0_RegexChar(v77);
    let v79: US0 = US0_BitOne();
    const v80: UH0 = UH0_RegexChar(v79);
    const v81: UH0 = UH0_RegexAlt(v78, v80);
    const v82: US0 = US0_BitZero();
    const v83: UH0 = UH0_RegexChar(v82);
    const v84: US0 = US0_BitOne();
    const v85: UH0 = UH0_RegexChar(v84);
    const v86: UH0 = UH0_RegexAlt(v83, v85);
    const v87: US0 = US0_BitZero();
    const v88: UH0 = UH0_RegexChar(v87);
    const v89: US0 = US0_BitOne();
    const v90: UH0 = UH0_RegexChar(v89);
    const v91: UH0 = UH0_RegexAlt(v88, v90);
    const v92: UH0 = UH0_RegexCat(v86, v91);
    const v93: UH0 = UH0_RegexCat(v81, v92);
    const v94: UH0 = UH0_RegexCat(v76, v93);
    const v95: UH0 = UH0_RegexCat(v74, v94);
    const v96: bigint = 1n;
    const v97: number = 0;
    const v98: number = loop_15(v68, v59, v58, v96, v97);
    const v99: number = loop_15(v95, v59, v58, v96, v97);
    const v100: number = 16;
    const v101: US0 = US0_BitZero();
    const v102: UH0 = UH0_RegexChar(v101);
    const v103: US0 = US0_BitZero();
    const v104: UH0 = UH0_RegexChar(v103);
    const v105: US0 = US0_BitZero();
    const v106: UH0 = UH0_RegexChar(v105);
    const v107: UH0 = UH0_RegexCat(v104, v106);
    const v108: UH0 = UH0_RegexAlt(v102, v107);
    const v109: UH0 = UH0_RegexStar(v108);
    const v110: US0 = US0_BitOne();
    const v111: UH0 = UH0_RegexChar(v110);
    const v112: UH0 = UH0_RegexCat(v109, v111);
    const v113: number = 0;
    const v114: number = 1;
    const v115: number = loop_17(v112, v100, v114, v113);
    const v116: boolean = v40 === v98;
    let v118: boolean;
    if (v116) {
        const v117: boolean = v41 === v99;
        v118 = v117;
    } else {
        v118 = false;
    }
    let v120: boolean;
    if (v118) {
        const v119: boolean = v57 === v115;
        v120 = v119;
    } else {
        v120 = false;
    }
    if (v120) {
    } else {
        throw new Error("brzozowski-bench-engines-disagree");
    }
    const v121: number = 200;
    const v122: number = 32;
    const v123: bigint = 1n;
    const v124: number = 0;
    const v125: number = loop_18(v122, v121, v123, v124);
    const v126: number = loop_20(v122, v121, v123, v124);
    const v127: number = 16;
    const v128: number = 0;
    const v129: number = 1;
    const v130: number = loop_22(v127, v129, v128);
    const v131: boolean = v40 === v125;
    let v133: boolean;
    if (v131) {
        const v132: boolean = v41 === v126;
        v133 = v132;
    } else {
        v133 = false;
    }
    let v135: boolean;
    if (v133) {
        const v134: boolean = v57 === v130;
        v135 = v134;
    } else {
        v135 = false;
    }
    if (v135) {
    } else {
        throw new Error("brzozowski-bench-engines-disagree");
    }
    const v136: number = 200;
    const v137: number = 32;
    const v138: Array<number> = new Array<number>(4096).fill(0);
    const v139: Array<number> = new Array<number>(4096).fill(0);
    const v140: Array<number> = new Array<number>(4096).fill(0);
    const v141: Array<number> = new Array<number>(4096).fill(0);
    const v142: Array<number> = new Array<number>(8192).fill(0);
    const v143: Array<number> = new Array<number>(8192).fill(0);
    const v144: Array<number> = new Array<number>(1).fill(0);
    const v145: number = 0;
    loop_24(v142, v145);
    const v146: number = 0;
    loop_24(v143, v146);
    const v147: number = 0;
    loop_25(v144, v147);
    const v148: number = 0;
    const v149: number = 0;
    const v150: number = 0;
    const v151: number = interned_node_26(v138, v139, v140, v141, v142, v143, v144, v148, v149, v150);
    const v152: number = 1;
    const v153: number = 0;
    const v154: number = 0;
    const v155: number = interned_node_26(v138, v139, v140, v141, v142, v143, v144, v152, v153, v154);
    const v156: boolean = v151 === 0;
    let v158: boolean;
    if (v156) {
        const v157: boolean = v155 === 1;
        v158 = v157;
    } else {
        v158 = false;
    }
    let v166: Array<number>;
    let v167: Array<number>;
    let v168: Array<number>;
    let v169: Array<number>;
    let v170: Array<number>;
    let v171: Array<number>;
    let v172: Array<number>;
    if (v158) {
        v166 = v138;
        v167 = v139;
        v168 = v140;
        v169 = v141;
        v170 = v142;
        v171 = v143;
        v172 = v144;
    } else {
        throw new Error("brzozowski-interned-store-init");
    }
    const v173: US0 = US0_BitZero();
    const v174: UH0 = UH0_RegexChar(v173);
    const v175: US0 = US0_BitOne();
    const v176: UH0 = UH0_RegexChar(v175);
    const v177: UH0 = UH0_RegexAlt(v174, v176);
    const v178: UH0 = UH0_RegexStar(v177);
    const v179: US0 = US0_BitZero();
    const v180: UH0 = UH0_RegexChar(v179);
    const v181: UH0 = UH0_RegexCat(v178, v180);
    const v182: number = interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v181);
    const v183: bigint = 1n;
    const v184: number = 0;
    const v185: number = loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v182, v136, v183, v184);
    const v186: US0 = US0_BitZero();
    const v187: UH0 = UH0_RegexChar(v186);
    const v188: US0 = US0_BitOne();
    const v189: UH0 = UH0_RegexChar(v188);
    const v190: UH0 = UH0_RegexAlt(v187, v189);
    const v191: UH0 = UH0_RegexStar(v190);
    const v192: US0 = US0_BitOne();
    const v193: UH0 = UH0_RegexChar(v192);
    const v194: US0 = US0_BitZero();
    const v195: UH0 = UH0_RegexChar(v194);
    const v196: US0 = US0_BitOne();
    const v197: UH0 = UH0_RegexChar(v196);
    const v198: UH0 = UH0_RegexAlt(v195, v197);
    const v199: US0 = US0_BitZero();
    const v200: UH0 = UH0_RegexChar(v199);
    const v201: US0 = US0_BitOne();
    const v202: UH0 = UH0_RegexChar(v201);
    const v203: UH0 = UH0_RegexAlt(v200, v202);
    const v204: US0 = US0_BitZero();
    const v205: UH0 = UH0_RegexChar(v204);
    const v206: US0 = US0_BitOne();
    const v207: UH0 = UH0_RegexChar(v206);
    const v208: UH0 = UH0_RegexAlt(v205, v207);
    const v209: UH0 = UH0_RegexCat(v203, v208);
    const v210: UH0 = UH0_RegexCat(v198, v209);
    const v211: UH0 = UH0_RegexCat(v193, v210);
    const v212: UH0 = UH0_RegexCat(v191, v211);
    const v213: number = interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v212);
    const v214: bigint = 1n;
    const v215: number = 0;
    const v216: number = loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v213, v136, v214, v215);
    const v217: number = 16;
    const v218: Array<number> = new Array<number>(4096).fill(0);
    const v219: Array<number> = new Array<number>(4096).fill(0);
    const v220: Array<number> = new Array<number>(4096).fill(0);
    const v221: Array<number> = new Array<number>(4096).fill(0);
    const v222: Array<number> = new Array<number>(8192).fill(0);
    const v223: Array<number> = new Array<number>(8192).fill(0);
    const v224: Array<number> = new Array<number>(1).fill(0);
    const v225: number = 0;
    loop_24(v222, v225);
    const v226: number = 0;
    loop_24(v223, v226);
    const v227: number = 0;
    loop_25(v224, v227);
    const v228: number = 0;
    const v229: number = 0;
    const v230: number = 0;
    const v231: number = interned_node_26(v218, v219, v220, v221, v222, v223, v224, v228, v229, v230);
    const v232: number = 1;
    const v233: number = 0;
    const v234: number = 0;
    const v235: number = interned_node_26(v218, v219, v220, v221, v222, v223, v224, v232, v233, v234);
    const v236: boolean = v231 === 0;
    let v238: boolean;
    if (v236) {
        const v237: boolean = v235 === 1;
        v238 = v237;
    } else {
        v238 = false;
    }
    let v246: Array<number>;
    let v247: Array<number>;
    let v248: Array<number>;
    let v249: Array<number>;
    let v250: Array<number>;
    let v251: Array<number>;
    let v252: Array<number>;
    if (v238) {
        v246 = v218;
        v247 = v219;
        v248 = v220;
        v249 = v221;
        v250 = v222;
        v251 = v223;
        v252 = v224;
    } else {
        throw new Error("brzozowski-interned-store-init");
    }
    const v253: US0 = US0_BitZero();
    const v254: UH0 = UH0_RegexChar(v253);
    const v255: US0 = US0_BitZero();
    const v256: UH0 = UH0_RegexChar(v255);
    const v257: US0 = US0_BitZero();
    const v258: UH0 = UH0_RegexChar(v257);
    const v259: UH0 = UH0_RegexCat(v256, v258);
    const v260: UH0 = UH0_RegexAlt(v254, v259);
    const v261: UH0 = UH0_RegexStar(v260);
    const v262: US0 = US0_BitOne();
    const v263: UH0 = UH0_RegexChar(v262);
    const v264: UH0 = UH0_RegexCat(v261, v263);
    const v265: number = interned_of_regex_raw_28(v246, v247, v248, v249, v250, v251, v252, v264);
    const v266: number = 1;
    const v267: number = 0;
    const v268: number = loop_36(v246, v247, v248, v249, v250, v251, v252, v217, v265, v266, v267);
    const v269: boolean = v40 === v185;
    let v271: boolean;
    if (v269) {
        const v270: boolean = v41 === v216;
        v271 = v270;
    } else {
        v271 = false;
    }
    let v273: boolean;
    if (v271) {
        const v272: boolean = v57 === v268;
        v273 = v272;
    } else {
        v273 = false;
    }
    if (v273) {
    } else {
        throw new Error("brzozowski-bench-engines-disagree");
    }
    const v274: boolean = v57 === 16;
    if (v274) {
    } else {
        throw new Error("brzozowski-bench-zero-runs-count");
    }
    const v275: boolean = v40 === 93;
    if (v275) {
    } else {
        throw new Error("brzozowski-bench-ends-with-zero-count");
    }
    const v276: boolean = v41 === 97;
    if (v276) {
    } else {
        throw new Error("brzozowski-bench-fourth-from-end-count");
    }
    return 0;
}
process.exitCode = main();
