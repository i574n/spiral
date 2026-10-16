type UH0_Link = { readonly tag: 0, readonly f0: number, readonly f1: UH0 };
type UH0_End = { readonly tag: 1 };
type UH0 = UH0_Link | UH0_End;
function UH0_Link(f0: number, f1: UH0): UH0 { return { tag: 0, f0: f0, f1: f1 }; }
function UH0_End(): UH0 { return { tag: 1 }; }
function build_0(v0: number, v1: UH0): UH0 {
    tail: while (true) {
        let v2: boolean = v0 === 0;
        if (v2) {
            return v1;
        } else {
            let v3: number = (v0 - 1) | 0;
            let v4: UH0 = UH0_Link(v0, v1);
            {
                let t0 = v3;
                let t1 = v4;
                v0 = t0;
                v1 = t1;
            }
            continue tail;
        }
    }
}
function sum_1(v0: UH0, v1: number): number {
    tail: while (true) {
        switch (v0.tag) {
            case 1: {
                return v1;
                break;
            }
            case 0: {
                let v2: number = v0.f0;
                let v3: UH0 = v0.f1;
                let v4: number = Math.imul(v1, 31);
                let v5: number = (v4 + v2) | 0;
                let v6: number = (v5 % 9973) | 0;
                {
                    let t0 = v3;
                    let t1 = v6;
                    v0 = t0;
                    v1 = t1;
                }
                continue tail;
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
export function main(): number {
    let v0: number = 1000000;
    let v1: UH0 = UH0_End();
    let v2: UH0 = build_0(v0, v1);
    let v3: number = 0;
    let v4: number = sum_1(v2, v3);
    let v5: number = (v4 % 256) | 0;
    return v5;
}
process.exitCode = main();
