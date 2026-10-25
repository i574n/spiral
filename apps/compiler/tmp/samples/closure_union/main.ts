type US0_None = { readonly tag: 0 };
type US0_Some = { readonly tag: 1, readonly f0: number };
type US0 = US0_None | US0_Some;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Some(f0: number): US0 { return { tag: 1, f0: f0 }; }
function f_c0(v0: number): ((a0: number) => US0) {
    return (v1: number): US0 => {
        let v2: boolean = v1 === 0;
        if (v2) {
            return US0_None();
        } else {
            return US0_Some(v0);
        }
    };
}
export function main(): number {
    let v0: number = 7;
    let v1: ((a0: number) => US0) = f_c0(v0);
    let v2: US0 = v1(1);
    switch (v2.tag) {
        case 0: {
            return 1;
            break;
        }
        case 1: {
            let v3: number = v2.f0;
            let v4: boolean = v3 === 7;
            if (v4) {
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
