type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: Heap0 };
type Heap2 = { readonly l0: Heap1, readonly l1: number };
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Heap2 };
type US0 = US0_None | US0_Held;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Held(f0: Heap2): US0 { return { tag: 1, f0: f0 }; }
type Heap3 = { readonly l0: US0 };
type Mut0 = { l0: Heap3 };
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            const v1: Heap2 = v0.f0;
            const v2: Heap1 = v1.l0;
            const v3: number = v1.l1;
            const v4: Heap0 = v2.l0;
            const v5: Heap0 = v2.l1;
            const v6: number = v4.l0;
            const v7: string = v4.l1;
            const v8: number = v5.l0;
            const v9: string = v5.l1;
            const v10: boolean = v6 === 7;
            let v12: boolean;
            if (v10) {
                const v11: boolean = v7 === "hi";
                v12 = v11;
            } else {
                v12 = false;
            }
            let v14: boolean;
            if (v12) {
                const v13: boolean = v8 === 4;
                v14 = v13;
            } else {
                v14 = false;
            }
            let v16: boolean;
            if (v14) {
                const v15: boolean = v9 === "yo";
                v16 = v15;
            } else {
                v16 = false;
            }
            let v18: boolean;
            if (v16) {
                const v17: boolean = v3 === 2;
                v18 = v17;
            } else {
                v18 = false;
            }
            if (v18) {
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
    let v14: Mut0 = { l0: v13 };
    const v15: number = 7;
    let v16: string = "hi";
    const v17: Heap0 = { l0: v15, l1: v16 };
    let v18: number = 4;
    const v19: string = "yo";
    const v20: Heap0 = { l0: v18, l1: v19 };
    const v21: Heap1 = { l0: v17, l1: v20 };
    const v22: number = 2;
    const v23: Heap2 = { l0: v21, l1: v22 };
    const v24: boolean = true;
    let v27: US0;
    if (v24) {
        v27 = US0_Held(v23);
    } else {
        v27 = US0_None();
    }
    const v28: Heap3 = { l0: v27 };
    v14.l0 = v28;
    const v29: Heap3 = v14.l0;
    const v30: US0 = v29.l0;
    return score_0(v30);
}
process.exitCode = main();
