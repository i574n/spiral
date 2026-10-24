type Heap0 = { readonly l0: number, readonly l1: number };
export function main(): number {
    const v0: number = 3;
    const v1: number = 4;
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = v2.l0;
    const v4: number = v2.l1;
    const v5: number = (v3 + v4) | 0;
    const v6: boolean = v5 === 7;
    if (v6) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
