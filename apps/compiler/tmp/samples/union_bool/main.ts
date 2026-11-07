type US0_No = { readonly tag: 0, readonly f0: boolean };
type US0_Yes = { readonly tag: 1, readonly f0: number };
type US0 = US0_No | US0_Yes;
function US0_No(f0: boolean): US0 { return { tag: 0, f0: f0 }; }
function US0_Yes(f0: number): US0 { return { tag: 1, f0: f0 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 0: {
            const v1: boolean = v0.f0;
            if (v1) {
                return 1;
            } else {
                return 2;
            }
            break;
        }
        case 1: {
            let v3: number = v0.f0;
            return v3;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: boolean = true;
    let v3: US0;
    if (v0) {
        v3 = US0_Yes(7);
    } else {
        v3 = US0_No(false);
    }
    let v6: US0;
    if (v0) {
        v6 = US0_No(true);
    } else {
        v6 = US0_Yes(1);
    }
    const v7: number = score_0(v3);
    const v8: boolean = v7 === 7;
    let v11: boolean;
    if (v8) {
        const v9: number = score_0(v6);
        const v10: boolean = v9 === 1;
        v11 = v10;
    } else {
        v11 = false;
    }
    if (v11) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
