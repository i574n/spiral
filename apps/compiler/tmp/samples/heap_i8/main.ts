type Heap0 = { readonly l0: number };
export function main(): number {
    let v0: number = 100;
    let v1: Heap0 = { l0: v0 };
    let v2: number = v1.l0;
    let v3: boolean = v2 === 100;
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
