type US0_Missing = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: number };
type US0 = US0_Missing | US0_Held;
function US0_Missing(): US0 { return { tag: 0 }; }
function US0_Held(f0: number): US0 { return { tag: 1, f0: f0 }; }
export function main(): number {
    let v0: number = 100;
    let v1: boolean = true;
    let v4: US0;
    if (v1) {
        v4 = US0_Held(v0);
    } else {
        v4 = US0_Missing();
    }
    switch (v4.tag) {
        case 1: {
            let v5: number = v4.f0;
            let v6: boolean = v5 === 100;
            if (v6) {
                return 0;
            } else {
                return 1;
            }
            break;
        }
        case 0: {
            return 1;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
process.exitCode = main();
