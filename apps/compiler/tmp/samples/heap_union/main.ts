type US0_None = { readonly tag: 0 };
type US0_Some = { readonly tag: 1, readonly f0: number };
type US0 = US0_None | US0_Some;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Some(f0: number): US0 { return { tag: 1, f0: f0 }; }
type Heap0 = { readonly l0: US0 };
export function main(): number {
    const v0: number = 7;
    const v1: boolean = true;
    let v4: US0;
    if (v1) {
        v4 = US0_Some(v0);
    } else {
        v4 = US0_None();
    }
    const v5: Heap0 = { l0: v4 };
    const v6: US0 = v5.l0;
    switch (v6.tag) {
        case 0: {
            return 1;
        }
        case 1: {
            const v7: number = v6.f0;
            const v8: boolean = v7 === 7;
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
