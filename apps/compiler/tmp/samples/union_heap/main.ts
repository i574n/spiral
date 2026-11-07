type Heap0 = { readonly l0: number };
type US0_Missing = { readonly tag: 0 };
type US0_Box = { readonly tag: 1, readonly f0: Heap0 };
type US0 = US0_Missing | US0_Box;
const US0_Missing_shared: US0 = { tag: 0 }; function US0_Missing(): US0 { return US0_Missing_shared; }
function US0_Box(f0: Heap0): US0 { return { tag: 1, f0: f0 }; }
export function main(): number {
    const v0: number = 7;
    const v1: Heap0 = { l0: v0 };
    const v2: boolean = true;
    let v5: US0;
    if (v2) {
        v5 = US0_Box(v1);
    } else {
        v5 = US0_Missing();
    }
    switch (v5.tag) {
        case 1: {
            const v6: Heap0 = v5.f0;
            const v7: number = v6.l0;
            const v8: boolean = v7 === 7;
            if (v8) {
                return 0;
            } else {
                return 1;
            }
            break;
        }
        case 0: {
            return 1;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
process.exitCode = main();
