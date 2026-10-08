type UH0_0 = { readonly tag: 0 };
type UH0_1 = { readonly tag: 1, readonly f0: Array<number>, readonly f1: UH0 };
type UH0 = UH0_0 | UH0_1;
function UH0_0(): UH0 { return { tag: 0 }; }
function UH0_1(f0: Array<number>, f1: UH0): UH0 { return { tag: 1, f0: f0, f1: f1 }; }
function sum_0(v0: UH0): number {
    switch (v0.tag) {
        case 1: {
            let v1: Array<number> = v0.f0;
            let v2: UH0 = v0.f1;
            let v3: number = v1.length;
            let v4: number = sum_0(v2);
            let v5: number = (v3 + v4) | 0;
            return v5;
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
    let v0: number = 2;
    let v1: Array<number> = new Array<number>(v0).fill(0);
    let v2: UH0 = UH0_0();
    let v3: UH0 = UH0_1(v1, v2);
    let v4: UH0 = UH0_1(v1, v3);
    let v5: number = sum_0(v4);
    let v6: number = (v5 - 4) | 0;
    return v6;
}
process.exitCode = main();
