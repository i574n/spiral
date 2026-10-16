type US1_A = { readonly tag: 0, readonly f0: number };
type US1_B = { readonly tag: 1, readonly f0: number };
type US1 = US1_A | US1_B;
function US1_A(f0: number): US1 { return { tag: 0, f0: f0 }; }
function US1_B(f0: number): US1 { return { tag: 1, f0: f0 }; }
type US0_Wrap = { readonly tag: 0, readonly f0: US1 };
type US0_Other = { readonly tag: 1, readonly f0: number };
type US0 = US0_Wrap | US0_Other;
function US0_Wrap(f0: US1): US0 { return { tag: 0, f0: f0 }; }
function US0_Other(f0: number): US0 { return { tag: 1, f0: f0 }; }
function score_inner_1(v0: US1): number {
    switch (v0.tag) {
        case 0: {
            let v1: number = v0.f0;
            return v1;
            break;
        }
        case 1: {
            let v2: number = v0.f0;
            let v3: number = (-v2) | 0;
            return v3;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            let v3: number = v0.f0;
            return v3;
            break;
        }
        case 0: {
            let v1: US1 = v0.f0;
            return score_inner_1(v1);
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: boolean = true;
    let v4: US0;
    if (v0) {
        let v1: US1 = US1_A(7);
        v4 = US0_Wrap(v1);
    } else {
        v4 = US0_Other(1);
    }
    let v8: US0;
    if (v0) {
        v8 = US0_Other(4);
    } else {
        let v6: US1 = US1_B(2);
        v8 = US0_Wrap(v6);
    }
    let v9: number = score_0(v4);
    let v10: boolean = v9 === 7;
    let v13: boolean;
    if (v10) {
        let v11: number = score_0(v8);
        let v12: boolean = v11 === 4;
        v13 = v12;
    } else {
        v13 = false;
    }
    if (v13) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
