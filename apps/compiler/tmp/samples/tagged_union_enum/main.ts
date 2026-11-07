type US0_Cold = { readonly tag: 0 };
type US0_Warm = { readonly tag: 1 };
type US0_Hot = { readonly tag: 2 };
type US0_Done = { readonly tag: 3 };
type US0 = US0_Cold | US0_Warm | US0_Hot | US0_Done;
const US0_Cold_shared: US0 = { tag: 0 }; function US0_Cold(): US0 { return US0_Cold_shared; }
const US0_Warm_shared: US0 = { tag: 1 }; function US0_Warm(): US0 { return US0_Warm_shared; }
const US0_Hot_shared: US0 = { tag: 2 }; function US0_Hot(): US0 { return US0_Hot_shared; }
const US0_Done_shared: US0 = { tag: 3 }; function US0_Done(): US0 { return US0_Done_shared; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 0: {
            return 1;
        }
        case 3: {
            return 4;
        }
        case 2: {
            return 3;
        }
        case 1: {
            return 2;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: number = 3;
    const v1: boolean = v0 === 0;
    let v10: US0;
    if (v1) {
        v10 = US0_Cold();
    } else {
        const v3: boolean = v0 === 1;
        if (v3) {
            v10 = US0_Warm();
        } else {
            const v5: boolean = v0 === 2;
            if (v5) {
                v10 = US0_Hot();
            } else {
                v10 = US0_Done();
            }
        }
    }
    const v11: number = score_0(v10);
    const v12: number = (v11 - 4) | 0;
    return v12;
}
process.exitCode = main();
