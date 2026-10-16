type Heap0 = { readonly l0: number, readonly l1: string };
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Heap0, readonly f1: Heap0 };
type US0 = US0_None | US0_Held;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Held(f0: Heap0, f1: Heap0): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            let v1: Heap0 = v0.f0;
            let v2: Heap0 = v0.f1;
            let v3: number = v1.l0;
            let v4: string = v1.l1;
            let v5: number = v2.l0;
            let v6: string = v2.l1;
            let v7: boolean = v3 === 7;
            let v9: boolean;
            if (v7) {
                let v8: boolean = v4 === "hi";
                v9 = v8;
            } else {
                v9 = false;
            }
            let v11: boolean;
            if (v9) {
                let v10: boolean = v5 === 4;
                v11 = v10;
            } else {
                v11 = false;
            }
            let v13: boolean;
            if (v11) {
                let v12: boolean = v6 === "yo";
                v13 = v12;
            } else {
                v13 = false;
            }
            if (v13) {
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
    let v3: number = 4;
    let v4: string = "yo";
    let v5: Heap0 = { l0: v3, l1: v4 };
    let v6: boolean = true;
    let v9: US0;
    if (v6) {
        v9 = US0_Held(v2, v5);
    } else {
        v9 = US0_None();
    }
    return score_0(v9);
}
process.exitCode = main();
