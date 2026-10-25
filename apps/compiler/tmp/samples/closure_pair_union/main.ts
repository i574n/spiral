type US0_None = { readonly tag: 0 };
type US0_Some = { readonly tag: 1, readonly f0: number };
type US0 = US0_None | US0_Some;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Some(f0: number): US0 { return { tag: 1, f0: f0 }; }
function f_c0(v0: number): ((a0: number) => [US0, US0]) {
    return (v1: number): [US0, US0] => {
        let v2: boolean = v1 === 0;
        if (v2) {
            let v3: US0 = US0_None();
            let v4: US0 = US0_None();
            return [v3, v4];
        } else {
            let v5: US0 = US0_Some(v0);
            let v6: US0 = US0_None();
            return [v5, v6];
        }
    };
}
export function main(): number {
    let v0: number = 7;
    let v1: ((a0: number) => [US0, US0]) = f_c0(v0);
    let [v2, v3]: [US0, US0] = v1(1);
    switch (v2.tag) {
        case 0: {
            return 1;
            break;
        }
        case 1: {
            let v4: number = v2.f0;
            switch (v3.tag) {
                case 0: {
                    let v5: boolean = v4 === 7;
                    if (v5) {
                        return 0;
                    } else {
                        return 1;
                    }
                    break;
                }
                case 1: {
                    let v7: number = v3.f0;
                    return 1;
                    break;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
process.exitCode = main();
