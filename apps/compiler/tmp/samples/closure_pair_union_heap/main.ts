type Heap0 = { readonly l0: number };
type US0_None = { readonly tag: 0 };
type US0_Some = { readonly tag: 1, readonly f0: number };
type US0 = US0_None | US0_Some;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Some(f0: number): US0 { return { tag: 1, f0: f0 }; }
function f_c0(v0: number, v1: Heap0): ((a0: number) => [US0, Heap0]) {
    return (v2: number): [US0, Heap0] => {
        let v3: boolean = v2 === 0;
        if (v3) {
            let v4: US0 = US0_None();
            return [v4, v1];
        } else {
            let v5: US0 = US0_Some(v0);
            return [v5, v1];
        }
    };
}
export function main(): number {
    let v0: number = 3;
    let v1: number = 4;
    let v2: Heap0 = { l0: v1 };
    let v3: ((a0: number) => [US0, Heap0]) = f_c0(v0, v2);
    let [v4, v5]: [US0, Heap0] = v3(1);
    switch (v4.tag) {
        case 0: {
            return 1;
            break;
        }
        case 1: {
            let v6: number = v4.f0;
            let v7: number = v5.l0;
            let v8: number = (v6 + v7) | 0;
            let v9: boolean = v8 === 7;
            if (v9) {
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
