type Heap0 = { readonly l0: number };
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Heap0, readonly f1: number };
type US0 = US0_None | US0_Held;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Held(f0: Heap0, f1: number): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            let v1: Heap0 = v0.f0;
            let v2: number = v0.f1;
            let v3: number = v1.l0;
            let v4: number = (v3 + v2) | 0;
            let v5: boolean = v4 === 7;
            if (v5) {
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
    let v0: number = 3;
    let v1: number = 4;
    let v2: Heap0 = { l0: v0 };
    let v3: boolean = true;
    let v6: US0;
    if (v3) {
        v6 = US0_Held(v2, v1);
    } else {
        v6 = US0_None();
    }
    return score_0(v6);
}
process.exitCode = main();
