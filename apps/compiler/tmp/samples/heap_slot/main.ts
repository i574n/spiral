type US0_None = { readonly tag: 0 };
type US0_Some = { readonly tag: 1, readonly f0: number };
type US0 = US0_None | US0_Some;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Some(f0: number): US0 { return { tag: 1, f0: f0 }; }
type Heap0 = { readonly l0: US0, readonly l1: number };
export function main(): number {
    let v0: number = 3;
    let v1: number = 4;
    let v2: US0 = US0_Some(v0);
    let v3: Heap0 = { l0: v2, l1: v1 };
    let v4: US0 = v3.l0;
    let v5: number = v3.l1;
    switch (v4.tag) {
        case 0: {
            return 1;
            break;
        }
        case 1: {
            let v6: number = v4.f0;
            let v7: number = (v6 + v5) | 0;
            let v8: boolean = v7 === 7;
            if (v8) {
                return 0;
            } else {
                return 1;
            }
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
process.exitCode = main();
