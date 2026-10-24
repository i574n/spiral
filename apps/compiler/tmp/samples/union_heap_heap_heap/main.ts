type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: number };
type Heap2 = { readonly l0: Heap1, readonly l1: number };
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Heap2 };
type US0 = US0_None | US0_Held;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Held(f0: Heap2): US0 { return { tag: 1, f0: f0 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            const v1: Heap2 = v0.f0;
            const v2: Heap1 = v1.l0;
            const v3: number = v1.l1;
            const v4: Heap0 = v2.l0;
            const v5: number = v2.l1;
            const v6: number = v4.l0;
            const v7: string = v4.l1;
            const v8: boolean = v6 === 7;
            let v10: boolean;
            if (v8) {
                const v9: boolean = v7 === "hi";
                v10 = v9;
            } else {
                v10 = false;
            }
            let v12: boolean;
            if (v10) {
                const v11: boolean = v5 === 1;
                v12 = v11;
            } else {
                v12 = false;
            }
            let v14: boolean;
            if (v12) {
                const v13: boolean = v3 === 2;
                v14 = v13;
            } else {
                v14 = false;
            }
            if (v14) {
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
    const v0: number = 7;
    const v1: string = "hi";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 1;
    const v4: Heap1 = { l0: v2, l1: v3 };
    const v5: number = 2;
    const v6: Heap2 = { l0: v4, l1: v5 };
    const v7: boolean = true;
    let v10: US0;
    if (v7) {
        v10 = US0_Held(v6);
    } else {
        v10 = US0_None();
    }
    return score_0(v10);
}
process.exitCode = main();
