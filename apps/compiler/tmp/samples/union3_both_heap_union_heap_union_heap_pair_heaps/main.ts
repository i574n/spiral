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
type US1_Mark = { readonly tag: 2, readonly f0: number };
type US1 = US1_Absent | US1_Box | US1_Mark;
const US1_Absent_shared: US1 = { tag: 0 }; function US1_Absent(): US1 { return US1_Absent_shared; }
function US1_Box(f0: Heap3): US1 { return { tag: 1, f0: f0 }; }
function US1_Mark(f0: number): US1 { return { tag: 2, f0: f0 }; }
function score_0(v0: US1): number {
    switch (v0.tag) {
        case 0: {
            return 1;
        }
        case 1: {
            const v3: Heap3 = v0.f0;
            const v4: US0 = v3.l0;
            switch (v4.tag) {
                case 1: {
                    const v5: Heap2 = v4.f0;
                    const v6: Heap1 = v5.l0;
                    const v7: number = v5.l1;
                    const v8: Heap0 = v6.l0;
                    const v9: Heap0 = v6.l1;
                    const v10: number = v8.l0;
                    const v11: string = v8.l1;
                    let v12: number = v9.l0;
                    const v13: string = v9.l1;
                    const v14: boolean = v10 === 7;
                    let v16: boolean;
                    if (v14) {
                        const v15: boolean = v11 === "hi";
                        v16 = v15;
                    } else {
                        v16 = false;
                    }
                    let v18: boolean;
                    if (v16) {
                        let v17: boolean = v12 === 4;
                        v18 = v17;
                    } else {
                        v18 = false;
                    }
                    let v20: boolean;
                    if (v18) {
                        const v19: boolean = v13 === "yo";
                        v20 = v19;
                    } else {
                        v20 = false;
                    }
                    let v22: boolean;
                    if (v20) {
                        const v21: boolean = v7 === 2;
                        v22 = v21;
                    } else {
                        v22 = false;
                    }
                    if (v22) {
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
        case 2: {
            const v1: number = v0.f0;
            return 1;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: number = 7;
    const v1: string = "hi";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 4;
    const v4: string = "yo";
    const v5: Heap0 = { l0: v3, l1: v4 };
    const v6: Heap1 = { l0: v2, l1: v5 };
    const v7: number = 2;
    const v8: Heap2 = { l0: v6, l1: v7 };
    const v9: boolean = true;
    let v12: US0;
    if (v9) {
        v12 = US0_Held(v8);
    } else {
        v12 = US0_None();
    }
    const v13: Heap3 = { l0: v12 };
    const v14: boolean = true;
    let v17: US1;
    if (v14) {
        v17 = US1_Box(v13);
    } else {
        v17 = US1_Mark(1);
    }
    let v18: number = 3;
    const v19: number = score_0(v17);
    let v20: US1 = US1_Mark(v18);
    const v21: number = score_0(v20);
    let v22: boolean = v19 === 0;
    let v24: boolean;
    if (v22) {
        const v23: boolean = v21 === 1;
        v24 = v23;
    } else {
        v24 = false;
    }
    if (v24) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
