type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: number };
type Heap2 = { readonly l0: Heap1, readonly l1: number };
type Mut0 = { l0: Heap2 };
export function main(): number {
    const v0: number = 3;
    const v1: string = "no";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 1;
    const v4: Heap1 = { l0: v2, l1: v3 };
    const v5: number = 2;
    const v6: Heap2 = { l0: v4, l1: v5 };
    let v7: Mut0 = { l0: v6 };
    const v8: number = 7;
    const v9: string = "hi";
    const v10: Heap0 = { l0: v8, l1: v9 };
    const v11: number = 4;
    const v12: Heap1 = { l0: v10, l1: v11 };
    const v13: number = 5;
    const v14: Heap2 = { l0: v12, l1: v13 };
    v7.l0 = v14;
    const v15: Heap2 = v7.l0;
    const v16: Heap1 = v15.l0;
    const v17: number = v15.l1;
    const v18: Heap0 = v16.l0;
    const v19: number = v16.l1;
    const v20: number = v18.l0;
    const v21: string = v18.l1;
    const v22: boolean = v20 === 7;
    let v24: boolean;
    if (v22) {
        const v23: boolean = v21 === "hi";
        v24 = v23;
    } else {
        v24 = false;
    }
    let v26: boolean;
    if (v24) {
        const v25: boolean = v19 === 4;
        v26 = v25;
    } else {
        v26 = false;
    }
    let v28: boolean;
    if (v26) {
        const v27: boolean = v17 === 5;
        v28 = v27;
    } else {
        v28 = false;
    }
    if (v28) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
