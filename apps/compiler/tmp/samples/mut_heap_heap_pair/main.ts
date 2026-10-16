type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: Heap0 };
type Heap2 = { readonly l0: Heap1, readonly l1: number };
type Mut0 = { l0: Heap2 };
export function main(): number {
    let v0: number = 1;
    let v1: string = "no";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 2;
    let v4: string = "zz";
    let v5: Heap0 = { l0: v3, l1: v4 };
    let v6: Heap1 = { l0: v2, l1: v5 };
    let v7: number = 3;
    let v8: Heap2 = { l0: v6, l1: v7 };
    let v9: Mut0 = { l0: v8 };
    let v10: number = 7;
    let v11: string = "hi";
    let v12: Heap0 = { l0: v10, l1: v11 };
    let v13: number = 4;
    let v14: string = "yo";
    let v15: Heap0 = { l0: v13, l1: v14 };
    let v16: Heap1 = { l0: v12, l1: v15 };
    let v17: number = 2;
    let v18: Heap2 = { l0: v16, l1: v17 };
    v9.l0 = v18;
    let v19: Heap2 = v9.l0;
    let v20: Heap1 = v19.l0;
    let v21: number = v19.l1;
    let v22: Heap0 = v20.l0;
    let v23: Heap0 = v20.l1;
    let v24: number = v22.l0;
    let v25: string = v22.l1;
    let v26: number = v23.l0;
    let v27: string = v23.l1;
    let v28: boolean = v24 === 7;
    let v30: boolean;
    if (v28) {
        let v29: boolean = v25 === "hi";
        v30 = v29;
    } else {
        v30 = false;
    }
    let v32: boolean;
    if (v30) {
        let v31: boolean = v26 === 4;
        v32 = v31;
    } else {
        v32 = false;
    }
    let v34: boolean;
    if (v32) {
        let v33: boolean = v27 === "yo";
        v34 = v33;
    } else {
        v34 = false;
    }
    let v36: boolean;
    if (v34) {
        let v35: boolean = v21 === 2;
        v36 = v35;
    } else {
        v36 = false;
    }
    if (v36) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
