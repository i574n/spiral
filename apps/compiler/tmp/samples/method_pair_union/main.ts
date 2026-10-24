type US0_None = { readonly tag: 0 };
type US0_Some = { readonly tag: 1, readonly f0: number };
type US0 = US0_None | US0_Some;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Some(f0: number): US0 { return { tag: 1, f0: f0 }; }
function method0(v0: number): [US0, US0] {
    const v1: boolean = v0 === 0;
    if (v1) {
        const v2: US0 = US0_None();
        const v3: US0 = US0_None();
        return [v2, v3];
    } else {
        const v4: US0 = US0_Some(v0);
        const v5: US0 = US0_None();
        return [v4, v5];
    }
}
export function main(): number {
    const v0: number = 7;
    let [v1, v2]: [US0, US0] = method0(v0);
    switch (v1.tag) {
        case 0: {
            return 1;
        }
        case 1: {
            const v3: number = v1.f0;
            switch (v2.tag) {
                case 0: {
                    const v4: boolean = v3 === 7;
                    if (v4) {
                        return 0;
                    } else {
                        return 1;
                    }
                    break;
                }
                case 1: {
                    const v6: number = v2.f0;
                    return 1;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
process.exitCode = main();
