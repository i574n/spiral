type US0_Zero = { readonly tag: 0 };
type US0_One = { readonly tag: 1 };
type US0 = US0_Zero | US0_One;
const US0_Zero_shared: US0 = { tag: 0 }; function US0_Zero(): US0 { return US0_Zero_shared; }
const US0_One_shared: US0 = { tag: 1 }; function US0_One(): US0 { return US0_One_shared; }
export function main(): number {
    const v0: US0 = US0_Zero();
    let v2: boolean;
    switch (v0.tag) {
        case 1: {
            v2 = false;
            break;
        }
        case 0: {
            v2 = true;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
