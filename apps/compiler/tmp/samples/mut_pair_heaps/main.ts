type Heap0 = { readonly l0: number, readonly l1: string };
type Mut0 = { l0: Heap0, l1: Heap0 };
export function main(): number {
    const v0: number = 1;
    const v1: string = "no";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 2;
    const v4: string = "zz";
    const v5: Heap0 = { l0: v3, l1: v4 };
    let v6: Mut0 = { l0: v2, l1: v5 };
    const v7: number = 7;
    const v8: string = "hi";
    const v9: Heap0 = { l0: v7, l1: v8 };
    const v10: number = 4;
    const v11: string = "yo";
    const v12: Heap0 = { l0: v10, l1: v11 };
    v6.l0 = v9;
    v6.l1 = v12;
    const v13: Heap0 = v6.l0;
    const v14: Heap0 = v6.l1;
    const v15: number = v13.l0;
    const v16: string = v13.l1;
    const v17: number = v14.l0;
    const v18: string = v14.l1;
    const v19: boolean = v15 === 7;
    let v21: boolean;
    if (v19) {
        const v20: boolean = v16 === "hi";
        v21 = v20;
    } else {
        v21 = false;
    }
    let v23: boolean;
    if (v21) {
        const v22: boolean = v17 === 4;
        v23 = v22;
    } else {
        v23 = false;
    }
    let v25: boolean;
    if (v23) {
        const v24: boolean = v18 === "yo";
        v25 = v24;
    } else {
        v25 = false;
    }
    if (v25) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
