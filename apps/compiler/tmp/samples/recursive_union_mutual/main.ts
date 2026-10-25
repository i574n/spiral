type UH1_B = { readonly tag: 0, readonly f0: UH0 };
type UH1_StopB = { readonly tag: 1 };
type UH1 = UH1_B | UH1_StopB;
function UH1_B(f0: UH0): UH1 { return { tag: 0, f0: f0 }; }
function UH1_StopB(): UH1 { return { tag: 1 }; }
type UH0_A = { readonly tag: 0, readonly f0: UH1 };
type UH0_StopA = { readonly tag: 1 };
type UH0 = UH0_A | UH0_StopA;
function UH0_A(f0: UH1): UH0 { return { tag: 0, f0: f0 }; }
function UH0_StopA(): UH0 { return { tag: 1 }; }
export function main(): number {
    let v0: boolean = true;
    let v5: UH0;
    if (v0) {
        let v1: UH0 = UH0_StopA();
        let v2: UH1 = UH1_B(v1);
        v5 = UH0_A(v2);
    } else {
        v5 = UH0_StopA();
    }
    switch (v5.tag) {
        case 0: {
            let v6: UH1 = v5.f0;
            return 0;
            break;
        }
        case 1: {
            return 0;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
process.exitCode = main();
