type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: Heap0 };
export function main(): number {
    let v0: number = 7;
    let v1: string = "hi";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 4;
    let v4: string = "yo";
    let v5: Heap0 = { l0: v3, l1: v4 };
    let v6: Heap1 = { l0: v2, l1: v5 };
    let v7: Heap0 = v6.l0;
    let v8: Heap0 = v6.l1;
    let v9: number = v7.l0;
    let v10: string = v7.l1;
    let v11: number = v8.l0;
    let v12: string = v8.l1;
    let v13: boolean = v9 === 7;
    let v15: boolean;
    if (v13) {
        let v14: boolean = v10 === "hi";
        v15 = v14;
    } else {
        v15 = false;
    }
    let v17: boolean;
    if (v15) {
        let v16: boolean = v11 === 4;
        v17 = v16;
    } else {
        v17 = false;
    }
    let v19: boolean;
    if (v17) {
        let v18: boolean = v12 === "yo";
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
