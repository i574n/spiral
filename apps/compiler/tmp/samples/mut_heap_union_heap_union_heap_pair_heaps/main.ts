type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: Heap0 };
type Heap2 = { readonly l0: Heap1, readonly l1: number };
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Heap2 };
type US0 = US0_None | US0_Held;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Held(f0: Heap2): US0 { return { tag: 1, f0: f0 }; }
type Heap3 = { readonly l0: US0 };
type US1_Absent = { readonly tag: 0 };
type US1_Box = { readonly tag: 1, readonly f0: Heap3 };
type US1 = US1_Absent | US1_Box;
const US1_Absent_shared: US1 = { tag: 0 }; function US1_Absent(): US1 { return US1_Absent_shared; }
function US1_Box(f0: Heap3): US1 { return { tag: 1, f0: f0 }; }
type Heap4 = { readonly l0: US1 };
type Mut0 = { l0: Heap4 };
function score_0(v0: US1): number {
    switch (v0.tag) {
        case 0: {
            return 1;
        }
        case 1: {
            const v1: Heap3 = v0.f0;
            const v2: US0 = v1.l0;
            switch (v2.tag) {
                case 1: {
                    const v3: Heap2 = v2.f0;
                    const v4: Heap1 = v3.l0;
                    const v5: number = v3.l1;
                    const v6: Heap0 = v4.l0;
                    const v7: Heap0 = v4.l1;
                    const v8: number = v6.l0;
                    const v9: string = v6.l1;
                    const v10: number = v7.l0;
                    const v11: string = v7.l1;
                    let v12: boolean = v8 === 7;
                    let v14: boolean;
                    if (v12) {
                        const v13: boolean = v9 === "hi";
                        v14 = v13;
                    } else {
                        v14 = false;
                    }
                    let v16: boolean;
                    if (v14) {
                        const v15: boolean = v10 === 4;
                        v16 = v15;
                    } else {
                        v16 = false;
                    }
                    let v18: boolean;
                    if (v16) {
                        let v17: boolean = v11 === "yo";
                        v18 = v17;
                    } else {
                        v18 = false;
                    }
                    let v20: boolean;
                    if (v18) {
                        let v19: boolean = v5 === 2;
                        v20 = v19;
                    } else {
                        v20 = false;
                    }
                    if (v20) {
                        return 0;
                    } else {
                        return 1;
                    }
                    break;
                }
                case 0: {
                    return 1;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: number = 1;
    const v1: string = "no";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 2;
    const v4: string = "zz";
    const v5: Heap0 = { l0: v3, l1: v4 };
    const v6: Heap1 = { l0: v2, l1: v5 };
    const v7: number = 3;
    const v8: Heap2 = { l0: v6, l1: v7 };
    const v9: boolean = true;
    let v12: US0;
    if (v9) {
        v12 = US0_Held(v8);
    } else {
        v12 = US0_None();
    }
    const v13: Heap3 = { l0: v12 };
    let v14: boolean = true;
    let v17: US1;
    if (v14) {
        v17 = US1_Box(v13);
    } else {
        v17 = US1_Absent();
    }
    let v18: Heap4 = { l0: v17 };
    let v19: Mut0 = { l0: v18 };
    let v20: number = 7;
    const v21: string = "hi";
    const v22: Heap0 = { l0: v20, l1: v21 };
    const v23: number = 4;
    const v24: string = "yo";
    const v25: Heap0 = { l0: v23, l1: v24 };
    const v26: Heap1 = { l0: v22, l1: v25 };
    const v27: number = 2;
    const v28: Heap2 = { l0: v26, l1: v27 };
    const v29: boolean = true;
    let v32: US0;
    if (v29) {
        v32 = US0_Held(v28);
    } else {
        v32 = US0_None();
    }
    const v33: Heap3 = { l0: v32 };
    const v34: boolean = true;
    let v37: US1;
    if (v34) {
        v37 = US1_Box(v33);
    } else {
        v37 = US1_Absent();
    }
    const v38: Heap4 = { l0: v37 };
    v19.l0 = v38;
    const v39: Heap4 = v19.l0;
    const v40: US1 = v39.l0;
    return score_0(v40);
}
process.exitCode = main();
