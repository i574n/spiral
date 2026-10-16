type US0_None = { readonly tag: 0 };
type US0_Some = { readonly tag: 1, readonly f0: number };
type US0 = US0_None | US0_Some;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Some(f0: number): US0 { return { tag: 1, f0: f0 }; }
function method0(v0: number): [US0, number] {
    let v1: boolean = v0 === 0;
    if (v1) {
        let v2: US0 = US0_None();
        return [v2, 0];
    } else {
        let v3: US0 = US0_Some(v0);
        return [v3, v0];
    }
}
export function main(): number {
    let v0: number = 7;
    let [v1, v2]: [US0, number] = method0(v0);
    switch (v1.tag) {
        case 0: {
            return 1;
            break;
        }
        case 1: {
            let v3: number = v1.f0;
            let v4: boolean = v3 === 7;
            let v6: boolean;
            if (v4) {
                let v5: boolean = v2 === 7;
                v6 = v5;
            } else {
                v6 = false;
            }
            if (v6) {
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
