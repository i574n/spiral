type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: number };
type Heap2 = { readonly l0: Heap1, readonly l1: number };
function f_c0(v0: Heap2): ((a0: number) => Heap2) {
    return (v1: number): Heap2 => {
        return v0;
    };
}
export function main(): number {
    const v0: number = 7;
    const v1: string = "hi";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 1;
    const v4: Heap1 = { l0: v2, l1: v3 };
    const v5: number = 2;
    const v6: Heap2 = { l0: v4, l1: v5 };
    const v7: ((a0: number) => Heap2) = f_c0(v6);
    const v8: Heap2 = v7(1);
    const v9: Heap1 = v8.l0;
    const v10: number = v8.l1;
    const v11: Heap0 = v9.l0;
    const v12: number = v9.l1;
    const v13: number = v11.l0;
    const v14: string = v11.l1;
    const v15: boolean = v13 === 7;
    let v17: boolean;
    if (v15) {
        const v16: boolean = v14 === "hi";
        v17 = v16;
    } else {
        v17 = false;
    }
    let v19: boolean;
    if (v17) {
        const v18: boolean = v12 === 1;
        v19 = v18;
    } else {
        v19 = false;
    }
    let v21: boolean;
    if (v19) {
        const v20: boolean = v10 === 2;
        v21 = v20;
    } else {
        v21 = false;
    }
    if (v21) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
