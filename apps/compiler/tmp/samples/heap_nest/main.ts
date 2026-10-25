type Heap0 = { readonly l0: number };
type Heap1 = { readonly l0: Heap0 };
export function main(): number {
    const v0: number = 7;
    const v1: Heap0 = { l0: v0 };
    const v2: Heap1 = { l0: v1 };
    const v3: Heap0 = v2.l0;
    const v4: number = v3.l0;
    const v5: boolean = v4 === 7;
    if (v5) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
