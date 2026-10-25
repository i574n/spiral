type US0_Real = { readonly tag: 0, readonly f0: number };
type US0_Whole = { readonly tag: 1, readonly f0: number };
type US0 = US0_Real | US0_Whole;
function US0_Real(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_Whole(f0: number): US0 { return { tag: 1, f0: f0 }; }
function twice_1(v0: number): number {
    let v1: number = v0 * 2;
    let v2: number = (v1) | 0;
    return v2;
}
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 0: {
            let v1: number = v0.f0;
            return twice_1(v1);
            break;
        }
        case 1: {
            let v3: number = v0.f0;
            return v3;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: boolean = true;
    let v1: number = 1.5;
    let v4: US0;
    if (v0) {
        v4 = US0_Real(v1);
    } else {
        v4 = US0_Whole(1);
    }
    let v7: US0;
    if (v0) {
        v7 = US0_Whole(5);
    } else {
        v7 = US0_Real(v1);
    }
    let v8: number = score_0(v4);
    let v9: boolean = v8 === 3;
    let v12: boolean;
    if (v9) {
        let v10: number = score_0(v7);
        let v11: boolean = v10 === 5;
        v12 = v11;
    } else {
        v12 = false;
    }
    if (v12) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
