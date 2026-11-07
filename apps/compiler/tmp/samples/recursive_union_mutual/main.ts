type UH1_B = { readonly tag: 0, readonly f0: UH0 };
type UH1_StopB = { readonly tag: 1 };
type UH1 = UH1_B | UH1_StopB;
function UH1_B(f0: UH0): UH1 { return { tag: 0, f0: f0 }; }
const UH1_StopB_shared: UH1 = { tag: 1 }; function UH1_StopB(): UH1 { return UH1_StopB_shared; }
type UH0_A = { readonly tag: 0, readonly f0: UH1 };
type UH0_StopA = { readonly tag: 1 };
type UH0 = UH0_A | UH0_StopA;
function UH0_A(f0: UH1): UH0 { return { tag: 0, f0: f0 }; }
const UH0_StopA_shared: UH0 = { tag: 1 }; function UH0_StopA(): UH0 { return UH0_StopA_shared; }
export function main(): number {
    const v0: boolean = true;
    let v5: UH0;
    if (v0) {
        const v1: UH0 = UH0_StopA();
        const v2: UH1 = UH1_B(v1);
        v5 = UH0_A(v2);
    } else {
        v5 = UH0_StopA();
    }
    switch (v5.tag) {
        case 0: {
            const v6: UH1 = v5.f0;
            return 0;
        }
        case 1: {
            return 0;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
process.exitCode = main();
