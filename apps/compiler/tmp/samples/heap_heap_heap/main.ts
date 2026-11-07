type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: number };
type Heap2 = { readonly l0: Heap1, readonly l1: number };
export function main(): number {
    const v0: number = 7;
    const v1: string = "hi";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 1;
    const v4: Heap1 = { l0: v2, l1: v3 };
    const v5: number = 2;
    const v6: Heap2 = { l0: v4, l1: v5 };
    const v7: Heap1 = v6.l0;
    const v8: number = v6.l1;
    const v9: Heap0 = v7.l0;
    const v10: number = v7.l1;
    const v11: number = v9.l0;
    const v12: string = v9.l1;
    const v13: boolean = v11 === 7;
    let v15: boolean;
    if (v13) {
        const v14: boolean = v12 === "hi";
        v15 = v14;
    } else {
        v15 = false;
    }
    let v17: boolean;
    if (v15) {
        const v16: boolean = v10 === 1;
        v17 = v16;
    } else {
        v17 = false;
    }
    let v19: boolean;
    if (v17) {
        const v18: boolean = v8 === 2;
        v19 = v18;
    } else {
        v19 = false;
    }
    if (v19) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
