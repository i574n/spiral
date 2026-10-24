type US0_None = { readonly tag: 0 };
type US0_All = { readonly tag: 1, readonly f0: number, readonly f1: string, readonly f2: boolean };
type US0 = US0_None | US0_All;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_All(f0: number, f1: string, f2: boolean): US0 { return { tag: 1, f0: f0, f1: f1, f2: f2 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            const v1: number = v0.f0;
            const v2: string = v0.f1;
            const v3: boolean = v0.f2;
            const v4: boolean = v1 === 4000000000;
            let v6: boolean;
            if (v4) {
                const v5: boolean = v2 === "hi";
                v6 = v5;
            } else {
                v6 = false;
            }
            const v7: boolean = v6 && v3;
            if (v7) {
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
    const v0: number = 4000000000;
    const v1: string = "hi";
    const v2: boolean = true;
    const v3: boolean = true;
    let v6: US0;
    if (v3) {
        v6 = US0_All(v0, v1, v2);
    } else {
        v6 = US0_None();
    }
    return score_0(v6);
}
process.exitCode = main();
