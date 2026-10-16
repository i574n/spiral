type Heap0 = { readonly l0: string, readonly l1: string };
export function main(): number {
    let v0: string = "hi";
    let v1: Heap0 = { l0: v0, l1: v0 };
    let v2: string = v1.l0;
    let v3: string = v1.l1;
    let v4: boolean = v2 === v3;
    if (v4) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
