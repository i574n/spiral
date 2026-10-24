type US0_North = { readonly tag: 0 };
type US0_East = { readonly tag: 1 };
type US0_South = { readonly tag: 2 };
type US0_West = { readonly tag: 3 };
type US0 = US0_North | US0_East | US0_South | US0_West;
const US0_North_shared: US0 = { tag: 0 }; function US0_North(): US0 { return US0_North_shared; }
const US0_East_shared: US0 = { tag: 1 }; function US0_East(): US0 { return US0_East_shared; }
const US0_South_shared: US0 = { tag: 2 }; function US0_South(): US0 { return US0_South_shared; }
const US0_West_shared: US0 = { tag: 3 }; function US0_West(): US0 { return US0_West_shared; }
export function main(): number {
    const v0: US0 = US0_North();
    let v8: US0;
    switch (v0.tag) {
        case 1: {
            v8 = US0_South();
            break;
        }
        case 0: {
            v8 = US0_East();
            break;
        }
        case 2: {
            v8 = US0_West();
            break;
        }
        case 3: {
            v8 = US0_North();
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v16: US0;
    switch (v8.tag) {
        case 1: {
            v16 = US0_South();
            break;
        }
        case 0: {
            v16 = US0_East();
            break;
        }
        case 2: {
            v16 = US0_West();
            break;
        }
        case 3: {
            v16 = US0_North();
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    const v17: US0 = US0_South();
    let v18: boolean;
    switch (v16.tag === v17.tag ? v16.tag : -1) {
        case 1: {
            v18 = true;
            break;
        }
        case 0: {
            v18 = true;
            break;
        }
        case 2: {
            v18 = true;
            break;
        }
        case 3: {
            v18 = true;
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
    let v21: number;
    switch (v0.tag) {
        case 1: {
            v21 = 2;
            break;
        }
        case 0: {
            v21 = 1;
            break;
        }
        default: {
            v21 = 7;
        }
    }
    let v23: number;
    switch (v8.tag) {
        case 1: {
            v23 = 2;
            break;
        }
        case 0: {
            v23 = 1;
            break;
        }
        default: {
            v23 = 7;
        }
    }
    const v24: number = Math.imul(v23, 3);
    const v25: number = (v21 + v24) | 0;
    let v27: number;
    switch (v16.tag) {
        case 1: {
            v27 = 2;
            break;
        }
        case 0: {
            v27 = 1;
            break;
        }
        default: {
            v27 = 7;
        }
    }
    const v28: number = Math.imul(v27, 9);
    const v29: number = (v25 + v28) | 0;
    const v30: number = (v29 + v19) | 0;
    return v30;
}
process.exitCode = main();
