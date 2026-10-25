type Heap0 = { readonly l0: number };
type US0_None = { readonly tag: 0 };
type US0_Some = { readonly tag: 1, readonly f0: number };
type US0 = US0_None | US0_Some;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Some(f0: number): US0 { return { tag: 1, f0: f0 }; }
function method0(v0: number, v1: Heap0): [US0, Heap0] {
    const v2: US0 = US0_Some(v0);
    return [v2, v1];
}
export function main(): number {
    const v0: number = 3;
    const v1: number = 4;
    const v2: Heap0 = { l0: v1 };
    let [v3, v4]: [US0, Heap0] = method0(v0, v2);
    switch (v3.tag) {
        case 0: {
            return 1;
        }
        case 1: {
            const v5: number = v3.f0;
            const v6: number = v4.l0;
            const v7: number = (v5 + v6) | 0;
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
