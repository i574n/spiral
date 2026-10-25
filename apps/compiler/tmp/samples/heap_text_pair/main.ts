type Heap0 = { readonly l0: string, readonly l1: string };
export function main(): number {
    let v0: string = "hi";
    let v1: string = "yo";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: string = v2.l0;
    let v4: string = v2.l1;
    let v5: boolean = v3 === "hi";
    let v7: boolean;
    if (v5) {
        let v6: boolean = v4 === "yo";
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
