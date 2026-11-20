type US0_Hit = { readonly tag: 0, readonly f0: number };
type US0_Miss = { readonly tag: 1, readonly f0: number };
type US0 = US0_Hit | US0_Miss;
function US0_Hit(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_Miss(f0: number): US0 { return { tag: 1, f0: f0 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 0: {
            const v1: number = v0.f0;
            return v1;
        }
        case 1: {
            const v2: number = v0.f0;
            let v3: number = (-v2) | 0;
            return v3;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: boolean = true;
    let v3: US0;
    if (v0) {
        v3 = US0_Hit(7);
    } else {
        v3 = US0_Miss(3);
    }
    const v4: number = score_0(v3);
    const v5: number = (v4 - 7) | 0;
    return v5;
}
process.exitCode = main();
