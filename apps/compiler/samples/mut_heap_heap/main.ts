type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: number };
type Mut0 = { l0: Heap1 };
export function main(): number {
    const v0: number = 3;
    const v1: string = "no";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 1;
    const v4: Heap1 = { l0: v2, l1: v3 };
    let v5: Mut0 = { l0: v4 };
    const v6: number = 7;
    const v7: string = "hi";
    const v8: Heap0 = { l0: v6, l1: v7 };
    const v9: number = 4;
    const v10: Heap1 = { l0: v8, l1: v9 };
    v5.l0 = v10;
    const v11: Heap1 = v5.l0;
    const v12: Heap0 = v11.l0;
    const v13: number = v11.l1;
    const v14: number = v12.l0;
    const v15: string = v12.l1;
    const v16: boolean = v14 === 7;
    let v18: boolean;
    if (v16) {
        const v17: boolean = v15 === "hi";
        v18 = v17;
    } else {
        v18 = false;
    }
    let v20: boolean;
    if (v18) {
        const v19: boolean = v13 === 4;
        v20 = v19;
    } else {
        v20 = false;
    }
    if (v20) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
