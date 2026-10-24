type Heap0 = { readonly l0: boolean };
export function main(): number {
    const v0: boolean = true;
    const v1: Heap0 = { l0: v0 };
    const v2: boolean = v1.l0;
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
