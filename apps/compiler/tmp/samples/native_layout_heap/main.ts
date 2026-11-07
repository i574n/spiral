type Heap0 = { readonly l0: number, readonly l1: number };
export function main(): number {
    const v0: Heap0 = { l0: 9, l1: 10 };
    const v1: number = v0.l0;
    const v2: number = v0.l1;
    const v3: number = (v1 + v2) | 0;
    return v3;
}
process.exitCode = main();
