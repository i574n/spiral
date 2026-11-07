type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: number };
export function main(): number {
    const v0: number = 7;
    const v1: string = "hi";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 1;
    const v4: Heap1 = { l0: v2, l1: v3 };
    const v5: Heap0 = v4.l0;
    const v6: number = v4.l1;
    const v7: number = v5.l0;
    const v8: string = v5.l1;
    const v9: boolean = v7 === 7;
    let v11: boolean;
    if (v9) {
        const v10: boolean = v8 === "hi";
        v11 = v10;
    } else {
        v11 = false;
    }
    let v13: boolean;
    if (v11) {
        const v12: boolean = v6 === 1;
        v13 = v12;
    } else {
        v13 = false;
    }
    if (v13) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
