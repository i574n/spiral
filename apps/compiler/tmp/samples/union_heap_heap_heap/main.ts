type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: number };
type Heap2 = { readonly l0: Heap1, readonly l1: number };
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Heap2 };
type US0 = US0_None | US0_Held;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Held(f0: Heap2): US0 { return { tag: 1, f0: f0 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            let v1: Heap2 = v0.f0;
            let v2: Heap1 = v1.l0;
            let v3: number = v1.l1;
            let v4: Heap0 = v2.l0;
            let v5: number = v2.l1;
            let v6: number = v4.l0;
            let v7: string = v4.l1;
            let v8: boolean = v6 === 7;
            let v10: boolean;
            if (v8) {
                let v9: boolean = v7 === "hi";
                v10 = v9;
            } else {
                v10 = false;
            }
            let v12: boolean;
            if (v10) {
                let v11: boolean = v5 === 1;
                v12 = v11;
            } else {
                v12 = false;
            }
            let v14: boolean;
            if (v12) {
                let v13: boolean = v3 === 2;
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
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: number = 7;
    let v1: string = "hi";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 1;
    let v4: Heap1 = { l0: v2, l1: v3 };
    let v5: number = 2;
    let v6: Heap2 = { l0: v4, l1: v5 };
    let v7: boolean = true;
    let v10: US0;
    if (v7) {
        v10 = US0_Held(v6);
    } else {
        v10 = US0_None();
    }
    return score_0(v10);
}
process.exitCode = main();
