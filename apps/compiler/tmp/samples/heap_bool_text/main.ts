type Heap0 = { readonly l0: boolean, readonly l1: string };
export function main(): number {
    let v0: boolean = true;
    let v1: string = "hi";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: boolean = v2.l0;
    let v4: string = v2.l1;
    let v6: boolean;
    if (v3) {
        let v5: boolean = v4 === "hi";
        v6 = v5;
    } else {
        v6 = false;
    }
    if (v6) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
