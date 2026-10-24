type US0_Idle = { readonly tag: 0 };
type US0_Text = { readonly tag: 1, readonly f0: string };
type US0 = US0_Idle | US0_Text;
const US0_Idle_shared: US0 = { tag: 0 }; function US0_Idle(): US0 { return US0_Idle_shared; }
function US0_Text(f0: string): US0 { return { tag: 1, f0: f0 }; }
function closure0(): ((a0: number) => US0) {
    return (v0: number): US0 => {
        const v1: string = "managed";
        return US0_Text(v1);
    };
}
function method0(v0: ((a0: number) => US0)): US0 {
    return v0(2);
}
export function main(): number {
    const v0: ((a0: number) => US0) = closure0();
    const v1: US0 = method0(v0);
    let v4: number;
    switch (v1.tag) {
        case 0: {
            v4 = 3;
            break;
        }
        case 1: {
            const v2: string = v1.f0;
            v4 = 11;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v5: number = (v4 + 31) | 0;
    return v5;
}
process.exitCode = main();
