type US0_Circle = { readonly tag: 0, readonly f0: number };
type US0_Rect = { readonly tag: 1, readonly f0: number, readonly f1: number };
type US0_Empty = { readonly tag: 2 };
type US0 = US0_Circle | US0_Rect | US0_Empty;
function US0_Circle(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_Rect(f0: number, f1: number): US0 { return { tag: 1, f0: f0, f1: f1 }; }
const US0_Empty_shared: US0 = { tag: 2 }; function US0_Empty(): US0 { return US0_Empty_shared; }
export function main(): number {
    const v0: number = 2;
    const v1: US0 = US0_Circle(v0);
    const v2: number = 3;
    const v3: number = 4;
    const v4: US0 = US0_Rect(v2, v3);
    const v5: US0 = US0_Empty();
    const v6: number = 2;
    const v7: US0 = US0_Circle(v6);
    let v18: boolean;
    switch (v1.tag === v7.tag ? v1.tag : -1) {
        case 0: {
            const v8: number = (v1 as US0_Circle).f0;
            const v9: number = (v7 as US0_Circle).f0;
            const v10: boolean = v8 === v9;
            v18 = v10;
            break;
        }
        case 2: {
            v18 = true;
            break;
        }
        case 1: {
            const v11: number = (v1 as US0_Rect).f0;
            const v12: number = (v1 as US0_Rect).f1;
            const v13: number = (v7 as US0_Rect).f0;
            const v14: number = (v7 as US0_Rect).f1;
            const v15: boolean = v11 === v13;
            if (v15) {
                const v16: boolean = v12 === v14;
                v18 = v16;
            } else {
                v18 = false;
            }
            break;
        }
        default: {
            v18 = false;
        }
    }
    let v19: number;
    if (v18) {
        v19 = 100;
    } else {
        v19 = 0;
    }
    let v28: number;
    switch (v1.tag) {
        case 0: {
            const v20: number = v1.f0;
            const v21: number = Math.imul(3, v20);
            const v22: number = Math.imul(v21, v20);
            v28 = v22;
            break;
        }
        case 2: {
            v28 = 0;
            break;
        }
        case 1: {
            const v23: number = v1.f0;
            const v24: number = v1.f1;
            const v25: number = Math.imul(v23, v24);
            v28 = v25;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v37: number;
    switch (v4.tag) {
        case 0: {
            const v29: number = v4.f0;
            const v30: number = Math.imul(3, v29);
            const v31: number = Math.imul(v30, v29);
            v37 = v31;
            break;
        }
        case 2: {
            v37 = 0;
            break;
        }
        case 1: {
            const v32: number = v4.f0;
            const v33: number = v4.f1;
            const v34: number = Math.imul(v32, v33);
            v37 = v34;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v38: number = (v28 + v37) | 0;
    let v47: number;
    switch (v5.tag) {
        case 0: {
            const v39: number = v5.f0;
            const v40: number = Math.imul(3, v39);
            const v41: number = Math.imul(v40, v39);
            v47 = v41;
            break;
        }
        case 2: {
            v47 = 0;
            break;
        }
        case 1: {
            const v42: number = v5.f0;
            const v43: number = v5.f1;
            const v44: number = Math.imul(v42, v43);
            v47 = v44;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v48: number = (v38 + v47) | 0;
    const v49: number = (v48 + v19) | 0;
    return v49;
}
process.exitCode = main();
