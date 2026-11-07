type Heap0 = { readonly l0: number, readonly l1: string };
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Heap0, readonly f1: Heap0 };
type US0 = US0_None | US0_Held;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Held(f0: Heap0, f1: Heap0): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            const v1: Heap0 = v0.f0;
            const v2: Heap0 = v0.f1;
            const v3: number = v1.l0;
            const v4: string = v1.l1;
            const v5: number = v2.l0;
            const v6: string = v2.l1;
            const v7: boolean = v3 === 7;
            let v9: boolean;
            if (v7) {
                const v8: boolean = v4 === "hi";
                v9 = v8;
            } else {
                v9 = false;
            }
            let v11: boolean;
            if (v9) {
                const v10: boolean = v5 === 4;
                v11 = v10;
            } else {
                v11 = false;
            }
            let v13: boolean;
            if (v11) {
                const v12: boolean = v6 === "yo";
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
    const v6: boolean = true;
    let v9: US0;
    if (v6) {
        v9 = US0_Held(v2, v5);
    } else {
        v9 = US0_None();
    }
    return score_0(v9);
}
process.exitCode = main();
