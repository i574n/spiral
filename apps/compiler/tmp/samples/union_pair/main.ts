type US0_One = { readonly tag: 0, readonly f0: number };
type US0_Both = { readonly tag: 1, readonly f0: number, readonly f1: number };
type US0 = US0_One | US0_Both;
function US0_One(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_Both(f0: number, f1: number): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function sum_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            const v2: number = v0.f0;
            let v3: number = v0.f1;
            const v4: number = Math.imul(v2, 10);
            const v5: number = (v4 + v3) | 0;
            return v5;
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
    let v3: US0;
    if (v0) {
        v3 = US0_Both(3, 4);
    } else {
        v3 = US0_One(1);
    }
    let v6: US0;
    if (v0) {
        v6 = US0_One(5);
    } else {
        v6 = US0_Both(1, 1);
    }
    const v7: number = sum_0(v3);
    const v8: boolean = v7 === 34;
    let v11: boolean;
    if (v8) {
        const v9: number = sum_0(v6);
        const v10: boolean = v9 === 5;
        v11 = v10;
    } else {
        v11 = false;
    }
    if (v11) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
