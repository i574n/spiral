type US0_One = { readonly tag: 0, readonly f0: number };
type US0_Both = { readonly tag: 1, readonly f0: number, readonly f1: string };
type US0 = US0_One | US0_Both;
function US0_One(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_Both(f0: number, f1: string): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function f_c0(v0: number, v1: string): ((a0: number) => US0) {
    return (v2: number): US0 => {
        const v3: boolean = v2 === 0;
        if (v3) {
            return US0_One(0);
        } else {
            return US0_Both(v0, v1);
        }
    };
}
export function main(): number {
    const v0: number = 3;
    const v1: string = "hi";
    const v2: ((a0: number) => US0) = f_c0(v0, v1);
    const v3: US0 = v2(1);
    switch (v3.tag) {
        case 1: {
            const v5: number = v3.f0;
            const v6: string = v3.f1;
            const v7: boolean = v5 === 3;
            let v9: boolean;
            if (v7) {
                const v8: boolean = v6 === "hi";
                v9 = v8;
            } else {
                v9 = false;
            }
            if (v9) {
                return 0;
            } else {
                return 1;
            }
            break;
        }
        case 0: {
            const v4: number = v3.f0;
            return 1;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
process.exitCode = main();
