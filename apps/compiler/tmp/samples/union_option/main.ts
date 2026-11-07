type US0_Empty = { readonly tag: 0 };
type US0_Full = { readonly tag: 1, readonly f0: number };
type US0 = US0_Empty | US0_Full;
const US0_Empty_shared: US0 = { tag: 0 }; function US0_Empty(): US0 { return US0_Empty_shared; }
function US0_Full(f0: number): US0 { return { tag: 1, f0: f0 }; }
function pick_0(v0: US0): number {
    switch (v0.tag) {
        case 0: {
            return 0;
        }
        case 1: {
            const v1: number = v0.f0;
            return v1;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: boolean = true;
    let v3: US0;
    if (v0) {
        v3 = US0_Full(7);
    } else {
        v3 = US0_Empty();
    }
    let v6: US0;
    if (v0) {
        v6 = US0_Empty();
    } else {
        v6 = US0_Full(1);
    }
    const v7: number = pick_0(v3);
    const v8: boolean = v7 === 7;
    let v11: boolean;
    if (v8) {
        const v9: number = pick_0(v6);
        const v10: boolean = v9 === 0;
        v11 = v10;
    } else {
        v11 = false;
    }
    if (v11) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
