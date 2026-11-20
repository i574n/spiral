function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
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
    const v9: Mut0 = { l0: v2, l1: v5, l2: v8 };
    const v10: Array<Mut0> = new Array<Mut0>(1).fill(undefined as unknown as Mut0);
    spiral_array_set(v10, 0, v9);
    const v11: number = 7;
    const v12: string = "hi";
    const v13: Heap0 = { l0: v11, l1: v12 };
    const v14: number = 4;
    const v15: string = "yo";
    const v16: Heap0 = { l0: v14, l1: v15 };
    const v17: number = 9;
    const v18: string = "ok";
    const v19: Heap0 = { l0: v17, l1: v18 };
    let v20: Mut0 = spiral_array_index(v10, 0);
    v20.l0 = v13;
    v20.l1 = v16;
    v20.l2 = v19;
    const v21: Heap0 = v20.l0;
    const v22: Heap0 = v20.l1;
    const v23: Heap0 = v20.l2;
    const v24: number = v21.l0;
    const v25: string = v21.l1;
    const v26: number = v22.l0;
    const v27: string = v22.l1;
    const v28: number = v23.l0;
    const v29: string = v23.l1;
    const v30: boolean = v24 === 7;
    let v32: boolean;
    if (v30) {
        const v31: boolean = v25 === "hi";
        v32 = v31;
    } else {
        v32 = false;
    }
    let v34: boolean;
    if (v32) {
        const v33: boolean = v26 === 4;
        v34 = v33;
    } else {
        v34 = false;
    }
    let v36: boolean;
    if (v34) {
        const v35: boolean = v27 === "yo";
        v36 = v35;
    } else {
        v36 = false;
    }
    let v38: boolean;
    if (v36) {
        const v37: boolean = v28 === 9;
        v38 = v37;
    } else {
        v38 = false;
    }
    let v40: boolean;
    if (v38) {
        const v39: boolean = v29 === "ok";
        v40 = v39;
    } else {
        v40 = false;
    }
    if (v40) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
