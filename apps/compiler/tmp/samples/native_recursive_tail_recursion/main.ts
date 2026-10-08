type UH0_0 = { readonly tag: 0 };
type UH0_1 = { readonly tag: 1, readonly f0: number, readonly f1: UH0 };
type UH0 = UH0_0 | UH0_1;
function UH0_0(): UH0 { return { tag: 0 }; }
function UH0_1(f0: number, f1: UH0): UH0 { return { tag: 1, f0: f0, f1: f1 }; }
function method2(v0: number): UH0 {
    let v1: number = (v0 - 1) | 0;
    let v2: boolean = v1 === 0;
    if (v2) {
        let v3: UH0 = UH0_0();
        return UH0_1(7, v3);
    } else {
        return method1(v1);
    }
}
function method1(v0: number): UH0 {
    let v1: number = (v0 - 1) | 0;
    let v2: boolean = v1 === 0;
    if (v2) {
        let v3: UH0 = UH0_0();
        return UH0_1(11, v3);
    } else {
        return method2(v1);
    }
}
function method0(): UH0 {
    let v0: number = 1000000;
    let v1: boolean = v0 === 0;
    if (v1) {
        let v2: UH0 = UH0_0();
        return UH0_1(7, v2);
    } else {
        return method1(v0);
    }
}
export function main(): number {
    let v0: UH0 = method0();
    switch (v0.tag) {
        case 1: {
            let v1: number = v0.f0;
            let v2: UH0 = v0.f1;
            let v3: boolean = v1 === 7;
            if (v3) {
                return 0;
            } else {
                return 3;
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
