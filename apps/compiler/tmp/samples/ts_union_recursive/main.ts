type UH0_Nil = { readonly tag: 0 };
type UH0_Cons = { readonly tag: 1, readonly f0: number, readonly f1: UH0 };
type UH0 = UH0_Nil | UH0_Cons;
function UH0_Nil(): UH0 { return { tag: 0 }; }
function UH0_Cons(f0: number, f1: UH0): UH0 { return { tag: 1, f0: f0, f1: f1 }; }
function sum_0(v0: UH0): number {
    switch (v0.tag) {
        case 1: {
            let v1: number = v0.f0;
            let v2: UH0 = v0.f1;
            let v3: number = sum_0(v2);
            let v4: number = (v1 + v3) | 0;
            return v4;
            break;
        }
        case 0: {
            return 0;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: number = 1;
    let v1: number = 2;
    let v2: number = 3;
    let v3: UH0 = UH0_Nil();
    let v4: UH0 = UH0_Cons(v2, v3);
    let v5: UH0 = UH0_Cons(v1, v4);
    let v6: UH0 = UH0_Cons(v0, v5);
    let v7: number = sum_0(v6);
    let v8: number = (v7 - 6) | 0;
    return v8;
}
process.exitCode = main();
