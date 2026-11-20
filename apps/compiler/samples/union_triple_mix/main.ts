type US0_One = { readonly tag: 0, readonly f0: number };
type US0_All = { readonly tag: 1, readonly f0: number, readonly f1: string, readonly f2: boolean };
type US0 = US0_One | US0_All;
function US0_One(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_All(f0: number, f1: string, f2: boolean): US0 { return { tag: 1, f0: f0, f1: f1, f2: f2 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            const v2: number = v0.f0;
            const v3: string = v0.f1;
            const v4: boolean = v0.f2;
            const v5: boolean = v2 === 7;
            let v7: boolean;
            if (v5) {
                let v6: boolean = v3 === "hi";
                v7 = v6;
            } else {
                v7 = false;
            }
            const v8: boolean = v7 && v4;
            if (v8) {
                return 0;
            } else {
                return 1;
            }
            break;
        }
        case 0: {
            const v1: number = v0.f0;
            return v1;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: boolean = true;
    const v1: number = 7;
    const v2: string = "hi";
    const v3: boolean = true;
    let v6: US0;
    if (v0) {
        v6 = US0_All(v1, v2, v3);
    } else {
        v6 = US0_One(1);
    }
    return score_0(v6);
}
process.exitCode = main();
