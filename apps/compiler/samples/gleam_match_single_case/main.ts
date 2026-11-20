type US0_Step = { readonly tag: 0, readonly f0: number, readonly f1: number, readonly f2: number };
type US0 = US0_Step;
function US0_Step(f0: number, f1: number, f2: number): US0 { return { tag: 0, f0: f0, f1: f1, f2: f2 }; }
function walk_0(v0: number): number {
    const v1: boolean = v0 > 2;
    let v6: US0;
    if (v1) {
        const v2: number = (v0 + 1) | 0;
        const v3: number = (v0 + 2) | 0;
        v6 = US0_Step(v0, v2, v3);
    } else {
        v6 = US0_Step(0, 1, 2);
    }
    switch (v6.tag) {
        case 0: {
            const v7: number = v6.f0;
            const v8: number = v6.f1;
            const v9: number = v6.f2;
            const v10: number = Math.imul(v8, v9);
            const v11: number = (v7 + v10) | 0;
            return v11;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: number = 5;
    const v1: number = walk_0(v0);
    const v2: number = (v0 - 4) | 0;
    const v3: number = walk_0(v2);
    const v4: number = (v1 + v3) | 0;
    return v4;
}
process.exitCode = main();
