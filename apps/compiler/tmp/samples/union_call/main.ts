type US0_Missing = { readonly tag: 0 };
type US0_Call = { readonly tag: 1, readonly f0: ((a0: number) => number) };
type US0 = US0_Missing | US0_Call;
function US0_Missing(): US0 { return { tag: 0 }; }
function US0_Call(f0: ((a0: number) => number)): US0 { return { tag: 1, f0: f0 }; }
function f_c0(v0: number): ((a0: number) => number) {
    return (v1: number): number => {
        let v2: number = (v1 + v0) | 0;
        return v2;
    };
}
export function main(): number {
    let v0: number = 3;
    let v1: ((a0: number) => number) = f_c0(v0);
    let v2: boolean = true;
    let v5: US0;
    if (v2) {
        v5 = US0_Call(v1);
    } else {
        v5 = US0_Missing();
    }
    switch (v5.tag) {
        case 1: {
            let v6: ((a0: number) => number) = v5.f0;
            let v7: number = v6(4);
            let v8: boolean = v7 === 7;
            if (v8) {
                return 0;
            } else {
                return 1;
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
