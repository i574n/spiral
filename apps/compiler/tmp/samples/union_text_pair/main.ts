type US0_None = { readonly tag: 0 };
type US0_Both = { readonly tag: 1, readonly f0: string, readonly f1: string };
type US0 = US0_None | US0_Both;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Both(f0: string, f1: string): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            let v1: string = v0.f0;
            let v2: string = v0.f1;
            let v3: boolean = v1 === "hi";
            let v5: boolean;
            if (v3) {
                let v4: boolean = v2 === "yo";
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
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: string = "hi";
    let v1: string = "yo";
    let v2: boolean = true;
    let v5: US0;
    if (v2) {
        v5 = US0_Both(v0, v1);
    } else {
        v5 = US0_None();
    }
    return score_0(v5);
}
process.exitCode = main();
