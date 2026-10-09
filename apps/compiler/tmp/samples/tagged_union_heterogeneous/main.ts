type US0_Hit = { readonly tag: 0, readonly f0: number };
type US0_Flag = { readonly tag: 1, readonly f0: boolean };
type US0 = US0_Hit | US0_Flag;
function US0_Hit(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_Flag(f0: boolean): US0 { return { tag: 1, f0: f0 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            let v2: boolean = v0.f0;
            if (v2) {
                return 9;
            } else {
                return 4;
            }
            break;
        }
        case 0: {
            let v1: number = v0.f0;
            return v1;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: boolean = false;
    let v3: US0;
    if (v0) {
        v3 = US0_Hit(7);
    } else {
        v3 = US0_Flag(true);
    }
    let v4: number = score_0(v3);
    let v5: number = (v4 - 9) | 0;
    return v5;
}
process.exitCode = main();
