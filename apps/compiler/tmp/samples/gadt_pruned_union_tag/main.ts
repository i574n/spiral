type US0_First = { readonly tag: 1 };
type US0_Second = { readonly tag: 2 };
type US0 = US0_First | US0_Second;
const US0_First_shared: US0 = { tag: 1 }; function US0_First(): US0 { return US0_First_shared; }
const US0_Second_shared: US0 = { tag: 2 }; function US0_Second(): US0 { return US0_Second_shared; }
export function main(): number {
    const v0: US0 = US0_Second();
    const v1: number = v0.tag;
    const v2: number = Math.imul(v1, 10);
    const v3: number = (v2 + 2) | 0;
    return v3;
}
process.exitCode = main();
