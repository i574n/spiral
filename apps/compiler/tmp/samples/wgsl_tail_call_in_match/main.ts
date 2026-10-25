type US0_Done = { readonly tag: 0, readonly f0: number };
type US0_More = { readonly tag: 1, readonly f0: number };
type US0 = US0_Done | US0_More;
function US0_Done(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_More(f0: number): US0 { return { tag: 1, f0: f0 }; }
function layers_0(v0: number): number {
    tail: while (true) {
        let v1: boolean = v0 >= 5;
        let v4: US0;
        if (v1) {
            v4 = US0_Done(v0);
        } else {
            v4 = US0_More(v0);
        }
        switch (v4.tag) {
            case 0: {
                let v8: number = v4.f0;
                let v9: number = Math.imul(v8, 2);
                return v9;
                break;
            }
            case 1: {
                let v5: number = v4.f0;
                let v6: number = (v5 + 1) | 0;
                v0 = v6;
                continue tail;
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
export function main(): number {
    let v0: number = 0;
    return layers_0(v0);
}
process.exitCode = main();
