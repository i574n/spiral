type UH0_0 = { readonly tag: 0 };
type UH0_1 = { readonly tag: 1, readonly f0: number, readonly f1: UH0, readonly f2: UH0 };
type UH0 = UH0_0 | UH0_1;
function UH0_0(): UH0 { return { tag: 0 }; }
function UH0_1(f0: number, f1: UH0, f2: UH0): UH0 { return { tag: 1, f0: f0, f1: f1, f2: f2 }; }
function method1(v0: UH0): number {
    switch (v0.tag) {
        case 0: {
            return 0;
            break;
        }
        case 1: {
            let v1: number = v0.f0;
            let v2: UH0 = v0.f1;
            let v3: UH0 = v0.f2;
            let v4: number = method1(v2);
            let v5: number = method1(v3);
            let v6: number = (v4 + v5) | 0;
            let v7: number = (v1 + v6) | 0;
            return v7;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function method0(v0: UH0, v1: UH0): number {
    let v2: number = method1(v0);
    let v3: number = method1(v1);
    let v4: number = (v2 + v3) | 0;
    return v4;
}
export function main(): number {
    let v0: number = 1;
    let v1: number = 2;
    let v2: UH0 = UH0_0();
    let v3: UH0 = UH0_1(v1, v2, v2);
    let v4: UH0 = UH0_1(v0, v3, v3);
    let v5: number = 1;
    let v6: number = 2;
    let v7: UH0 = UH0_0();
    let v8: UH0 = UH0_1(v6, v7, v7);
    let v9: UH0 = UH0_1(v5, v8, v8);
    let v10: number = method0(v4, v9);
    let v11: number = (v10 - 10) | 0;
    return v11;
}
process.exitCode = main();
