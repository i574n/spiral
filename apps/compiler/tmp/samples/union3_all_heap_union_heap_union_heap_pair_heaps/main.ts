type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: Heap0 };
type Heap2 = { readonly l0: Heap1, readonly l1: number };
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Heap2 };
type US0 = US0_None | US0_Held;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Held(f0: Heap2): US0 { return { tag: 1, f0: f0 }; }
type Heap3 = { readonly l0: US0 };
type US1_Absent = { readonly tag: 0 };
type US1_Box = { readonly tag: 1, readonly f0: Heap3 };
type US1_Mark = { readonly tag: 2, readonly f0: number };
type US1 = US1_Absent | US1_Box | US1_Mark;
function US1_Absent(): US1 { return { tag: 0 }; }
function US1_Box(f0: Heap3): US1 { return { tag: 1, f0: f0 }; }
function US1_Mark(f0: number): US1 { return { tag: 2, f0: f0 }; }
function score_0(v0: US1): number {
    switch (v0.tag) {
        case 0: {
            return 1;
            break;
        }
        case 1: {
            let v3: Heap3 = v0.f0;
            let v4: US0 = v3.l0;
            switch (v4.tag) {
                case 1: {
                    let v5: Heap2 = v4.f0;
                    let v6: Heap1 = v5.l0;
                    let v7: number = v5.l1;
                    let v8: Heap0 = v6.l0;
                    let v9: Heap0 = v6.l1;
                    let v10: number = v8.l0;
                    let v11: string = v8.l1;
                    let v12: number = v9.l0;
                    let v13: string = v9.l1;
                    let v14: boolean = v10 === 7;
                    let v16: boolean;
                    if (v14) {
                        let v15: boolean = v11 === "hi";
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
                        let v19: boolean = v13 === "yo";
                        v20 = v19;
                    } else {
                        v20 = false;
                    }
                    let v22: boolean;
                    if (v20) {
                        let v21: boolean = v7 === 2;
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
                    break;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        case 2: {
            let v1: number = v0.f0;
            return 1;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: number = 7;
    let v1: string = "hi";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 4;
    let v4: string = "yo";
    let v5: Heap0 = { l0: v3, l1: v4 };
    let v6: Heap1 = { l0: v2, l1: v5 };
    let v7: number = 2;
    let v8: Heap2 = { l0: v6, l1: v7 };
    let v9: boolean = true;
    let v12: US0;
    if (v9) {
        v12 = US0_Held(v8);
    } else {
        v12 = US0_None();
    }
    let v13: Heap3 = { l0: v12 };
    let v14: boolean = true;
    let v17: US1;
    if (v14) {
        v17 = US1_Box(v13);
    } else {
        v17 = US1_Mark(1);
    }
    let v18: number = 3;
    let v19: number = score_0(v17);
    let v20: US1 = US1_Mark(v18);
    let v21: number = score_0(v20);
    let v22: US1 = US1_Absent();
    let v23: number = score_0(v22);
    let v24: boolean = v19 === 0;
    let v26: boolean;
    if (v24) {
        let v25: boolean = v21 === 1;
        v26 = v25;
    } else {
        v26 = false;
    }
    let v28: boolean;
    if (v26) {
        let v27: boolean = v23 === 1;
        v28 = v27;
    } else {
        v28 = false;
    }
    if (v28) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
