type US0_One = { readonly tag: 0, readonly f0: number };
type US0_Both = { readonly tag: 1, readonly f0: number, readonly f1: string };
type US0 = US0_One | US0_Both;
function US0_One(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_Both(f0: number, f1: string): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function method0(v0: number, v1: string): US0 {
    const v2: boolean = v0 === 0;
    if (v2) {
        return US0_One(0);
    } else {
        return US0_Both(v0, v1);
    }
}
export function main(): number {
    const v0: number = 3;
    const v1: string = "hi";
    const v2: US0 = method0(v0, v1);
    switch (v2.tag) {
        case 1: {
            const v4: number = v2.f0;
            const v5: string = v2.f1;
            const v6: boolean = v4 === 3;
            let v8: boolean;
            if (v6) {
                const v7: boolean = v5 === "hi";
                v8 = v7;
            } else {
                v8 = false;
            }
            if (v8) {
                return 0;
            } else {
                return 1;
            }
            break;
        }
        case 0: {
            const v3: number = v2.f0;
            return 1;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
process.exitCode = main();
