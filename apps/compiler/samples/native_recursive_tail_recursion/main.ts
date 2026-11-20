type UH0_Empty = { readonly tag: 0 };
type UH0_Box = { readonly tag: 1, readonly f0: number, readonly f1: UH0 };
type UH0 = UH0_Empty | UH0_Box;
const UH0_Empty_shared: UH0 = { tag: 0 }; function UH0_Empty(): UH0 { return UH0_Empty_shared; }
function UH0_Box(f0: number, f1: UH0): UH0 { return { tag: 1, f0: f0, f1: f1 }; }
function method2(v0: number): UH0 {
    const v1: number = (v0 - 1) | 0;
    const v2: boolean = v1 === 0;
    if (v2) {
        const v3: UH0 = UH0_Empty();
        return UH0_Box(7, v3);
    } else {
        return method1(v1);
    }
}
function method1(v0: number): UH0 {
    const v1: number = (v0 - 1) | 0;
    const v2: boolean = v1 === 0;
    if (v2) {
        const v3: UH0 = UH0_Empty();
        return UH0_Box(11, v3);
    } else {
        return method2(v1);
    }
}
function method0(): UH0 {
    const v0: number = 1000000;
    const v1: boolean = v0 === 0;
    if (v1) {
        const v2: UH0 = UH0_Empty();
        return UH0_Box(7, v2);
    } else {
        return method1(v0);
    }
}
export function main(): number {
    const v0: UH0 = method0();
    switch (v0.tag) {
        case 1: {
            const v1: number = v0.f0;
            const v2: UH0 = v0.f1;
            const v3: boolean = v1 === 7;
            if (v3) {
                return 0;
            } else {
                return 3;
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
