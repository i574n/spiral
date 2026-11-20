type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: Heap0, readonly l2: Heap0 };
export function main(): number {
    const v0: number = 7;
    const v1: string = "hi";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 4;
    const v4: string = "yo";
    const v5: Heap0 = { l0: v3, l1: v4 };
    const v6: number = 9;
    const v7: string = "ok";
    const v8: Heap0 = { l0: v6, l1: v7 };
    const v9: Heap1 = { l0: v2, l1: v5, l2: v8 };
    const v10: Heap0 = v9.l0;
    const v11: Heap0 = v9.l1;
    const v12: Heap0 = v9.l2;
    const v13: number = v10.l0;
    const v14: string = v10.l1;
    const v15: number = v11.l0;
    const v16: string = v11.l1;
    const v17: number = v12.l0;
    const v18: string = v12.l1;
    const v19: boolean = v13 === 7;
    let v21: boolean;
    if (v19) {
        const v20: boolean = v14 === "hi";
        v21 = v20;
    } else {
        v21 = false;
    }
    let v23: boolean;
    if (v21) {
        const v22: boolean = v15 === 4;
        v23 = v22;
    } else {
        v23 = false;
    }
    let v25: boolean;
    if (v23) {
        const v24: boolean = v16 === "yo";
        v25 = v24;
    } else {
        v25 = false;
    }
    let v27: boolean;
    if (v25) {
        const v26: boolean = v17 === 9;
        v27 = v26;
    } else {
        v27 = false;
    }
    let v29: boolean;
    if (v27) {
        const v28: boolean = v18 === "ok";
        v29 = v28;
    } else {
        v29 = false;
    }
    if (v29) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
