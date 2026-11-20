type US0_Idle = { readonly tag: 0 };
type US0_Hit = { readonly tag: 1, readonly f0: number };
type US0_Flag = { readonly tag: 2, readonly f0: boolean };
type US0 = US0_Idle | US0_Hit | US0_Flag;
const US0_Idle_shared: US0 = { tag: 0 }; function US0_Idle(): US0 { return US0_Idle_shared; }
function US0_Hit(f0: number): US0 { return { tag: 1, f0: f0 }; }
function US0_Flag(f0: boolean): US0 { return { tag: 2, f0: f0 }; }
function closure0(v0: number): ((a0: number) => US0) {
    return (v1: number): US0 => {
        const v2: boolean = v1 === v0;
        return US0_Flag(v2);
    };
}
function method0(v0: ((a0: number) => US0), v1: number): US0 {
    return v0(v1);
}
export function main(): number {
    const v0: number = 2;
    const v1: ((a0: number) => US0) = closure0(v0);
    const v2: US0 = method0(v1, v0);
    let v8: number;
    switch (v2.tag) {
        case 2: {
            const v4: boolean = v2.f0;
            if (v4) {
                v8 = 11;
            } else {
                v8 = 5;
            }
            break;
        }
        case 1: {
            const v3: number = v2.f0;
            v8 = v3;
            break;
        }
        case 0: {
            v8 = 3;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v9: number = (v8 + 31) | 0;
    return v9;
}
process.exitCode = main();
