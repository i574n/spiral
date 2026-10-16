type US0_One = { readonly tag: 0, readonly f0: number };
type US0_Both = { readonly tag: 1, readonly f0: number, readonly f1: string };
type US0 = US0_One | US0_Both;
function US0_One(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_Both(f0: number, f1: string): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            let v2: number = v0.f0;
            let v3: string = v0.f1;
            let v4: boolean = v2 === 3;
            let v6: boolean;
            if (v4) {
                let v5: boolean = v3 === "hi";
                v6 = v5;
            } else {
                v6 = false;
            }
            if (v6) {
                return 0;
            } else {
                return 1;
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
    let v0: boolean = true;
    let v1: number = 3;
    let v2: string = "hi";
    let v5: US0;
    if (v0) {
        v5 = US0_Both(v1, v2);
    } else {
        v5 = US0_One(1);
    }
    return score_0(v5);
}
process.exitCode = main();
