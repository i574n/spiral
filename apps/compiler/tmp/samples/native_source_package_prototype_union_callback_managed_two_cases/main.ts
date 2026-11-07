type US0_Idle = { readonly tag: 0 };
type US0_Text = { readonly tag: 1, readonly f0: string };
type US0_Note = { readonly tag: 2, readonly f0: string };
type US0 = US0_Idle | US0_Text | US0_Note;
const US0_Idle_shared: US0 = { tag: 0 }; function US0_Idle(): US0 { return US0_Idle_shared; }
function US0_Text(f0: string): US0 { return { tag: 1, f0: f0 }; }
function US0_Note(f0: string): US0 { return { tag: 2, f0: f0 }; }
function closure0(): ((a0: number) => US0) {
    return (v0: number): US0 => {
        const v1: boolean = v0 === 1;
        if (v1) {
            const v2: string = "alpha";
            return US0_Text(v2);
        } else {
            const v4: string = "beta";
            return US0_Note(v4);
        }
    };
}
function method0(v0: ((a0: number) => US0)): US0 {
    return v0(1);
}
function method1(v0: ((a0: number) => US0)): US0 {
    return v0(2);
}
export function main(): number {
    const v0: ((a0: number) => US0) = closure0();
    const v1: US0 = method0(v0);
    let v6: number;
    switch (v1.tag) {
        case 0: {
            v6 = 3;
            break;
        }
        case 2: {
            const v3: string = v1.f0;
            v6 = 6;
            break;
        }
        case 1: {
            const v2: string = v1.f0;
            v6 = 5;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v7: US0 = method1(v0);
    let v12: number;
    switch (v7.tag) {
        case 0: {
            v12 = 3;
            break;
        }
        case 2: {
            const v9: string = v7.f0;
            v12 = 6;
            break;
        }
        case 1: {
            const v8: string = v7.f0;
            v12 = 5;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v13: number = (v6 + v12) | 0;
    const v14: number = (v13 + 31) | 0;
    return v14;
}
process.exitCode = main();
