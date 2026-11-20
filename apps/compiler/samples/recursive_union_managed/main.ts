type UH0_Nil = { readonly tag: 0 };
type UH0_Cons = { readonly tag: 1, readonly f0: Array<number>, readonly f1: UH0 };
type UH0 = UH0_Nil | UH0_Cons;
const UH0_Nil_shared: UH0 = { tag: 0 }; function UH0_Nil(): UH0 { return UH0_Nil_shared; }
function UH0_Cons(f0: Array<number>, f1: UH0): UH0 { return { tag: 1, f0: f0, f1: f1 }; }
function sum_0(v0: UH0): number {
    switch (v0.tag) {
        case 1: {
            const v1: Array<number> = v0.f0;
            const v2: UH0 = v0.f1;
            const v3: number = v1.length;
            const v4: number = sum_0(v2);
            const v5: number = (v3 + v4) | 0;
            return v5;
        }
        case 0: {
            return 0;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: number = 2;
    const v1: Array<number> = new Array<number>(v0).fill(0);
    const v2: UH0 = UH0_Nil();
    const v3: UH0 = UH0_Cons(v1, v2);
    const v4: UH0 = UH0_Cons(v1, v3);
    const v5: number = sum_0(v4);
    const v6: number = (v5 - 4) | 0;
    return v6;
}
process.exitCode = main();
