type US0_Idle = { readonly tag: 0 };
type US0_Hit = { readonly tag: 1, readonly f0: number };
type US0_Flag = { readonly tag: 2, readonly f0: boolean };
type US0 = US0_Idle | US0_Hit | US0_Flag;
const US0_Idle_shared: US0 = { tag: 0 }; function US0_Idle(): US0 { return US0_Idle_shared; }
function US0_Hit(f0: number): US0 { return { tag: 1, f0: f0 }; }
function US0_Flag(f0: boolean): US0 { return { tag: 2, f0: f0 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 2: {
            const v2: boolean = v0.f0;
            if (v2) {
                return 11;
            } else {
                return 5;
            }
            break;
        }
        case 1: {
            const v1: number = v0.f0;
            return v1;
        }
        case 0: {
            return 3;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function closure0(v0: US0): ((a0: number) => number) {
    return (v1: number): number => {
        const v2: number = score_0(v0);
        const v3: number = (v2 + v1) | 0;
        return v3;
    };
}
function method1(v0: ((a0: number) => number)): number {
    return v0(31);
}
export function main(): number {
    const v0: number = 2;
    const v1: boolean = v0 === 0;
    let v7: US0;
    if (v1) {
        v7 = US0_Idle();
    } else {
        const v3: boolean = v0 === 1;
        if (v3) {
            v7 = US0_Hit(7);
        } else {
            v7 = US0_Flag(true);
        }
    }
    const v8: ((a0: number) => number) = closure0(v7);
    return method1(v8);
}
process.exitCode = main();
