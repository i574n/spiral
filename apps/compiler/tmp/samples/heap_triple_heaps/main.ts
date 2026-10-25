type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: Heap0, readonly l2: Heap0 };
export function main(): number {
    let v0: number = 7;
    let v1: string = "hi";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 4;
    let v4: string = "yo";
    let v5: Heap0 = { l0: v3, l1: v4 };
    let v6: number = 9;
    let v7: string = "ok";
    let v8: Heap0 = { l0: v6, l1: v7 };
    let v9: Heap1 = { l0: v2, l1: v5, l2: v8 };
    let v10: Heap0 = v9.l0;
    let v11: Heap0 = v9.l1;
    let v12: Heap0 = v9.l2;
    let v13: number = v10.l0;
    let v14: string = v10.l1;
    let v15: number = v11.l0;
    let v16: string = v11.l1;
    let v17: number = v12.l0;
    let v18: string = v12.l1;
    let v19: boolean = v13 === 7;
    let v21: boolean;
    if (v19) {
        let v20: boolean = v14 === "hi";
        v21 = v20;
    } else {
        v21 = false;
    }
    let v23: boolean;
    if (v21) {
        let v22: boolean = v15 === 4;
        v23 = v22;
    } else {
        v23 = false;
    }
    let v25: boolean;
    if (v23) {
        let v24: boolean = v16 === "yo";
        v25 = v24;
    } else {
        v25 = false;
    }
    let v27: boolean;
    if (v25) {
        let v26: boolean = v17 === 9;
        v27 = v26;
    } else {
        v27 = false;
    }
    let v29: boolean;
    if (v27) {
        let v28: boolean = v18 === "ok";
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
