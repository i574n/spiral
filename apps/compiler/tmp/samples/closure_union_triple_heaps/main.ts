type Heap0 = { readonly l0: number, readonly l1: string };
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Heap0, readonly f1: Heap0, readonly f2: Heap0 };
type US0 = US0_None | US0_Held;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Held(f0: Heap0, f1: Heap0, f2: Heap0): US0 { return { tag: 1, f0: f0, f1: f1, f2: f2 }; }
function f_c0(v0: Heap0, v1: Heap0, v2: Heap0): ((a0: number) => US0) {
    return (v3: number): US0 => {
        let v4: boolean = v3 === 0;
        if (v4) {
            return US0_None();
        } else {
            return US0_Held(v0, v1, v2);
        }
    };
}
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            let v1: Heap0 = v0.f0;
            let v2: Heap0 = v0.f1;
            let v3: Heap0 = v0.f2;
            let v4: number = v1.l0;
            let v5: string = v1.l1;
            let v6: number = v2.l0;
            let v7: string = v2.l1;
            let v8: number = v3.l0;
            let v9: string = v3.l1;
            let v10: boolean = v4 === 7;
            let v12: boolean;
            if (v10) {
                let v11: boolean = v5 === "hi";
                v12 = v11;
            } else {
                v12 = false;
            }
            let v14: boolean;
            if (v12) {
                let v13: boolean = v6 === 4;
                v14 = v13;
            } else {
                v14 = false;
            }
            let v16: boolean;
            if (v14) {
                let v15: boolean = v7 === "yo";
                v16 = v15;
            } else {
                v16 = false;
            }
            let v18: boolean;
            if (v16) {
                let v17: boolean = v8 === 9;
                v18 = v17;
            } else {
                v18 = false;
            }
            let v20: boolean;
            if (v18) {
                let v19: boolean = v9 === "ok";
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
    let v6: number = 9;
    let v7: string = "ok";
    let v8: Heap0 = { l0: v6, l1: v7 };
    let v9: ((a0: number) => US0) = f_c0(v2, v5, v8);
    let v10: US0 = v9(1);
    return score_0(v10);
}
process.exitCode = main();
