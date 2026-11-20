type Heap0 = { readonly l0: number, readonly l1: string, readonly l2: boolean };
export function main(): number {
    const v0: number = 7;
    const v1: string = "hi";
    const v2: boolean = true;
    const v3: Heap0 = { l0: v0, l1: v1, l2: v2 };
    const v4: number = v3.l0;
    const v5: string = v3.l1;
    const v6: boolean = v3.l2;
    const v7: boolean = v4 === 7;
    let v9: boolean;
    if (v7) {
        const v8: boolean = v5 === "hi";
        v9 = v8;
    } else {
        v9 = false;
    }
    const v10: boolean = v9 && v6;
    if (v10) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
