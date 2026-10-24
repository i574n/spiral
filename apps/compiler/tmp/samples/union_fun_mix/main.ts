type US0_None = { readonly tag: 0 };
type US0_Call = { readonly tag: 1, readonly f0: ((a0: number) => number), readonly f1: number };
type US0 = US0_None | US0_Call;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Call(f0: ((a0: number) => number), f1: number): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function add_c0(v0: number): ((a0: number) => number) {
    return (v1: number): number => {
        const v2: number = (v1 + v0) | 0;
        return v2;
    };
}
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            const v1: ((a0: number) => number) = v0.f0;
            const v2: number = v0.f1;
            const v3: number = v1(0);
            const v4: number = (v3 + v2) | 0;
            const v5: boolean = v4 === 7;
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
    const v0: number = 3;
    const v1: number = 4;
    const v2: boolean = true;
    let v6: US0;
    if (v2) {
        const v3: ((a0: number) => number) = add_c0(v0);
        v6 = US0_Call(v3, v1);
    } else {
        v6 = US0_None();
    }
    return score_0(v6);
}
process.exitCode = main();
