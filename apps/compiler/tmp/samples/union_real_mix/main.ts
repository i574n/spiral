type US0_None = { readonly tag: 0 };
type US0_Both = { readonly tag: 1, readonly f0: number, readonly f1: number };
type US0 = US0_None | US0_Both;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Both(f0: number, f1: number): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            const v1: number = v0.f0;
            const v2: number = v0.f1;
            const v3: boolean = v1 === 1.5;
            let v5: boolean;
            if (v3) {
                const v4: boolean = v2 === 7;
                v5 = v4;
            } else {
                v5 = false;
            }
            if (v5) {
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
    const v0: number = 1.5;
    const v1: number = 7;
    const v2: boolean = true;
    let v5: US0;
    if (v2) {
        v5 = US0_Both(v0, v1);
    } else {
        v5 = US0_None();
    }
    return score_0(v5);
}
process.exitCode = main();
