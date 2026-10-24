type US0_Circle = { readonly tag: 0, readonly f0: number };
type US0_Square = { readonly tag: 1, readonly f0: number };
type US0_Tri = { readonly tag: 2, readonly f0: number };
type US0_Dot = { readonly tag: 3 };
type US0 = US0_Circle | US0_Square | US0_Tri | US0_Dot;
function US0_Circle(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_Square(f0: number): US0 { return { tag: 1, f0: f0 }; }
function US0_Tri(f0: number): US0 { return { tag: 2, f0: f0 }; }
const US0_Dot_shared: US0 = { tag: 3 }; function US0_Dot(): US0 { return US0_Dot_shared; }
function pick_0(v0: number): US0 {
    const v1: boolean = v0 === 0;
    if (v1) {
        return US0_Circle(5);
    } else {
        const v3: boolean = v0 === 1;
        if (v3) {
            return US0_Square(4);
        } else {
            const v5: boolean = v0 === 2;
            if (v5) {
                return US0_Tri(7);
            } else {
                return US0_Dot();
            }
        }
    }
}
function measure_1(v0: US0, v1: number): number {
    switch (v0.tag) {
        case 0: {
            const v2: number = v0.f0;
            const v3: number = Math.imul(v2, 3);
            return v3;
        }
        default: {
            const v4: number = Math.imul(v1, v1);
            const v5: boolean = v4 > 3;
            switch (v0.tag) {
                case 3: {
                    return v4;
                }
                case 1: {
                    const v6: number = v0.f0;
                    if (v5) {
                        const v7: number = Math.imul(v6, v6);
                        return v7;
                    } else {
                        return v6;
                    }
                    break;
                }
                case 2: {
                    const v9: number = v0.f0;
                    if (v5) {
                        const v10: number = Math.imul(v9, 2);
                        return v10;
                    } else {
                        return v9;
                    }
                    break;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
        }
    }
}
function measure_tri_2(v0: US0, v1: number): number {
    switch (v0.tag) {
        case 0: {
            const v2: number = v0.f0;
            return v2;
        }
        case 3: {
            return 0;
        }
        case 1: {
            const v3: number = v0.f0;
            return v3;
        }
        default: {
            const v4: number = (v1 + 2) | 0;
            switch (v0.tag) {
                case 2: {
                    const v5: number = v0.f0;
                    const v6: number = Math.imul(v5, v4);
                    return v6;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
        }
    }
}
export function main(): number {
    const v0: number = 0;
    const v1: US0 = pick_0(v0);
    const v2: number = measure_1(v1, v0);
    const v3: number = (v0 + 1) | 0;
    const v4: US0 = pick_0(v3);
    const v5: number = measure_1(v4, v3);
    const v6: number = (v2 + v5) | 0;
    const v7: number = (v0 + 2) | 0;
    const v8: US0 = pick_0(v7);
    const v9: number = measure_1(v8, v7);
    const v10: number = (v6 + v9) | 0;
    const v11: number = (v0 + 3) | 0;
    const v12: US0 = pick_0(v11);
    const v13: number = measure_1(v12, v11);
    const v14: number = (v10 + v13) | 0;
    const v15: US0 = pick_0(v7);
    const v16: number = measure_tri_2(v15, v0);
    const v17: number = (v14 + v16) | 0;
    const v18: US0 = pick_0(v0);
    const v19: number = measure_tri_2(v18, v0);
    const v20: number = (v17 + v19) | 0;
    return v20;
}
process.exitCode = main();
