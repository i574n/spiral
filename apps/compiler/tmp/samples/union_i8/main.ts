type US0_Missing = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: number };
type US0 = US0_Missing | US0_Held;
const US0_Missing_shared: US0 = { tag: 0 }; function US0_Missing(): US0 { return US0_Missing_shared; }
function US0_Held(f0: number): US0 { return { tag: 1, f0: f0 }; }
export function main(): number {
    const v0: number = 100;
    const v1: boolean = true;
    let v4: US0;
    if (v1) {
        v4 = US0_Held(v0);
    } else {
        v4 = US0_Missing();
    }
    switch (v4.tag) {
        case 1: {
            const v5: number = v4.f0;
            const v6: boolean = v5 === 100;
            if (v6) {
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
