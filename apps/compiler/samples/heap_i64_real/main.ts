type Heap0 = { readonly l0: bigint, readonly l1: number };
export function main(): number {
    const v0: bigint = 5000000000n;
    const v1: number = 1.5;
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: bigint = v2.l0;
    const v4: number = v2.l1;
    const v5: boolean = v3 === 5000000000n;
    let v7: boolean;
    if (v5) {
        const v6: boolean = v4 === 1.5;
        v7 = v6;
    } else {
        v7 = false;
    }
    if (v7) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
