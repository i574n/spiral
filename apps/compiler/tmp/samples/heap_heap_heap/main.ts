type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: number };
type Heap2 = { readonly l0: Heap1, readonly l1: number };
export function main(): number {
    let v0: number = 7;
    let v1: string = "hi";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 1;
    let v4: Heap1 = { l0: v2, l1: v3 };
    let v5: number = 2;
    let v6: Heap2 = { l0: v4, l1: v5 };
    let v7: Heap1 = v6.l0;
    let v8: number = v6.l1;
    let v9: Heap0 = v7.l0;
    let v10: number = v7.l1;
    let v11: number = v9.l0;
    let v12: string = v9.l1;
    let v13: boolean = v11 === 7;
    let v15: boolean;
    if (v13) {
        let v14: boolean = v12 === "hi";
        v15 = v14;
    } else {
        v15 = false;
    }
    let v17: boolean;
    if (v15) {
        let v16: boolean = v10 === 1;
        v17 = v16;
    } else {
        v17 = false;
    }
    let v19: boolean;
    if (v17) {
        let v18: boolean = v8 === 2;
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
