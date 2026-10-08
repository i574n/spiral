type US0_0 = { readonly tag: 0 };
type US0_1 = { readonly tag: 1 };
type US0_2 = { readonly tag: 2 };
type US0_3 = { readonly tag: 3 };
type US0 = US0_0 | US0_1 | US0_2 | US0_3;
function US0_0(): US0 { return { tag: 0 }; }
function US0_1(): US0 { return { tag: 1 }; }
function US0_2(): US0 { return { tag: 2 }; }
function US0_3(): US0 { return { tag: 3 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 0: {
            return 1;
            break;
        }
        case 3: {
            return 4;
            break;
        }
        case 2: {
            return 3;
            break;
        }
        case 1: {
            return 2;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: number = 3;
    let v1: boolean = v0 === 0;
    let v10: US0;
    if (v1) {
        v10 = US0_0();
    } else {
        let v3: boolean = v0 === 1;
        if (v3) {
            v10 = US0_1();
        } else {
            let v5: boolean = v0 === 2;
            if (v5) {
                v10 = US0_2();
            } else {
                v10 = US0_3();
            }
        }
    }
    let v11: number = score_0(v10);
    let v12: number = (v11 - 4) | 0;
    return v12;
}
process.exitCode = main();
