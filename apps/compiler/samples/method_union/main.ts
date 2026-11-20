type US0_None = { readonly tag: 0 };
type US0_Some = { readonly tag: 1, readonly f0: number };
type US0 = US0_None | US0_Some;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Some(f0: number): US0 { return { tag: 1, f0: f0 }; }
function method0(v0: number): US0 {
    const v1: boolean = v0 === 0;
    if (v1) {
        return US0_None();
    } else {
        return US0_Some(v0);
    }
}
export function main(): number {
    const v0: number = 7;
    const v1: US0 = method0(v0);
    switch (v1.tag) {
        case 0: {
            return 1;
        }
        case 1: {
            const v2: number = v1.f0;
            const v3: boolean = v2 === 7;
            if (v3) {
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
