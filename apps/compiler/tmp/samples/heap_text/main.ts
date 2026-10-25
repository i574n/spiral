type Heap0 = { readonly l0: string };
export function main(): number {
    const v0: string = "hi";
    const v1: Heap0 = { l0: v0 };
    const v2: string = v1.l0;
    const v3: boolean = v2 === "hi";
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
