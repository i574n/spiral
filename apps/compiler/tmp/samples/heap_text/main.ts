type Heap0 = { readonly l0: string };
export function main(): number {
    let v0: string = "hi";
    let v1: Heap0 = { l0: v0 };
    let v2: string = v1.l0;
    let v3: boolean = v2 === "hi";
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
