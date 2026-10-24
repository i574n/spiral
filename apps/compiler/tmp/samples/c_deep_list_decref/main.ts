type UH0_Link = { readonly tag: 0, readonly f0: number, readonly f1: UH0 };
type UH0_End = { readonly tag: 1 };
type UH0 = UH0_Link | UH0_End;
function UH0_Link(f0: number, f1: UH0): UH0 { return { tag: 0, f0: f0, f1: f1 }; }
const UH0_End_shared: UH0 = { tag: 1 }; function UH0_End(): UH0 { return UH0_End_shared; }
function build_0(v0: number, v1: UH0): UH0 {
    tail: while (true) {
        const v2: boolean = v0 === 0;
        if (v2) {
            return v1;
        } else {
            const v3: number = (v0 - 1) | 0;
            const v4: UH0 = UH0_Link(v0, v1);
            v0 = v3;
            v1 = v4;
            continue tail;
        }
    }
}
function sum_1(v0: UH0, v1: number): number {
    tail: while (true) {
        switch (v0.tag) {
            case 1: {
                return v1;
            }
            case 0: {
                const v2: number = v0.f0;
                const v3: UH0 = v0.f1;
                const v4: number = Math.imul(v1, 31);
                const v5: number = (v4 + v2) | 0;
                const v6: number = (v5 % 9973) | 0;
                v0 = v3;
                v1 = v6;
                continue tail;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
export function main(): number {
    let v0: number = 1000000;
    let v1: UH0 = UH0_End();
    const v2: UH0 = build_0(v0, v1);
    const v3: number = 0;
    const v4: number = sum_1(v2, v3);
    const v5: number = (v4 % 256) | 0;
    return v5;
}
process.exitCode = main();
