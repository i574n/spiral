type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: number };
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Heap1 };
type US0 = US0_None | US0_Held;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Held(f0: Heap1): US0 { return { tag: 1, f0: f0 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            let v1: Heap1 = v0.f0;
            let v2: Heap0 = v1.l0;
            let v3: number = v1.l1;
            let v4: number = v2.l0;
            let v5: string = v2.l1;
            let v6: boolean = v4 === 7;
            let v8: boolean;
            if (v6) {
                let v7: boolean = v5 === "hi";
                v8 = v7;
            } else {
                v8 = false;
            }
            let v10: boolean;
            if (v8) {
                let v9: boolean = v3 === 1;
                v10 = v9;
            } else {
                v10 = false;
            }
            if (v10) {
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
    let v5: boolean = true;
    let v8: US0;
    if (v5) {
        v8 = US0_Held(v4);
    } else {
        v8 = US0_None();
    }
    return score_0(v8);
}
process.exitCode = main();
