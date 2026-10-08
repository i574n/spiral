type US0_0 = { readonly tag: 0 };
type US0_1 = { readonly tag: 1, readonly f0: number };
type US0_2 = { readonly tag: 2, readonly f0: boolean };
type US0 = US0_0 | US0_1 | US0_2;
function US0_0(): US0 { return { tag: 0 }; }
function US0_1(f0: number): US0 { return { tag: 1, f0: f0 }; }
function US0_2(f0: boolean): US0 { return { tag: 2, f0: f0 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 2: {
            let v2: boolean = v0.f0;
            if (v2) {
                return 11;
            } else {
                return 5;
            }
            break;
        }
        case 1: {
            let v1: number = v0.f0;
            return v1;
            break;
        }
        case 0: {
            return 3;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: number = 2;
    let v1: boolean = v0 === 0;
    let v7: US0;
    if (v1) {
        v7 = US0_0();
    } else {
        let v3: boolean = v0 === 1;
        if (v3) {
            v7 = US0_1(7);
        } else {
            v7 = US0_2(true);
        }
    }
    let v8: number = score_0(v7);
    let v9: number = (v8 - 11) | 0;
    return v9;
}
process.exitCode = main();
