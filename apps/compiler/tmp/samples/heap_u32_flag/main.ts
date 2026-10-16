type Heap0 = { readonly l0: number, readonly l1: string, readonly l2: boolean };
export function main(): number {
    let v0: number = 4000000000;
    let v1: string = "hi";
    let v2: boolean = true;
    let v3: Heap0 = { l0: v0, l1: v1, l2: v2 };
    let v4: number = v3.l0;
    let v5: string = v3.l1;
    let v6: boolean = v3.l2;
    let v7: boolean = v4 === 4000000000;
    let v9: boolean;
    if (v7) {
        let v8: boolean = v5 === "hi";
        v9 = v8;
    } else {
        v9 = false;
    }
    let v10: boolean = v9 && v6;
    if (v10) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
