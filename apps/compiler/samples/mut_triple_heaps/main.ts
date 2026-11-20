type Heap0 = { readonly l0: number, readonly l1: string };
type Mut0 = { l0: Heap0, l1: Heap0, l2: Heap0 };
export function main(): number {
    const v0: number = 1;
    const v1: string = "no";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 2;
    const v4: string = "zz";
    const v5: Heap0 = { l0: v3, l1: v4 };
    const v6: number = 3;
    const v7: string = "aa";
    const v8: Heap0 = { l0: v6, l1: v7 };
    let v9: Mut0 = { l0: v2, l1: v5, l2: v8 };
    const v10: number = 7;
    const v11: string = "hi";
    const v12: Heap0 = { l0: v10, l1: v11 };
    const v13: number = 4;
    const v14: string = "yo";
    const v15: Heap0 = { l0: v13, l1: v14 };
    const v16: number = 9;
    const v17: string = "ok";
    const v18: Heap0 = { l0: v16, l1: v17 };
    v9.l0 = v12;
    v9.l1 = v15;
    v9.l2 = v18;
    const v19: Heap0 = v9.l0;
    const v20: Heap0 = v9.l1;
    const v21: Heap0 = v9.l2;
    const v22: number = v19.l0;
    const v23: string = v19.l1;
    const v24: number = v20.l0;
    const v25: string = v20.l1;
    const v26: number = v21.l0;
    const v27: string = v21.l1;
    const v28: boolean = v22 === 7;
    let v30: boolean;
    if (v28) {
        const v29: boolean = v23 === "hi";
        v30 = v29;
    } else {
        v30 = false;
    }
    let v32: boolean;
    if (v30) {
        const v31: boolean = v24 === 4;
        v32 = v31;
    } else {
        v32 = false;
    }
    let v34: boolean;
    if (v32) {
        const v33: boolean = v25 === "yo";
        v34 = v33;
    } else {
        v34 = false;
    }
    let v36: boolean;
    if (v34) {
        const v35: boolean = v26 === 9;
        v36 = v35;
    } else {
        v36 = false;
    }
    let v38: boolean;
    if (v36) {
        const v37: boolean = v27 === "ok";
        v38 = v37;
    } else {
        v38 = false;
    }
    if (v38) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
