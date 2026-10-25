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
    let v0: number = 1;
    let v1: string = "no";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 2;
    let v4: string = "zz";
    let v5: Heap0 = { l0: v3, l1: v4 };
    let v6: number = 3;
    let v7: string = "aa";
    let v8: Heap0 = { l0: v6, l1: v7 };
    let v9: Mut0 = { l0: v2, l1: v5, l2: v8 };
    let v10: Array<Mut0> = new Array<Mut0>(1).fill(undefined as unknown as Mut0);
    spiral_array_set(v10, 0, v9);
    let v11: number = 7;
    let v12: string = "hi";
    let v13: Heap0 = { l0: v11, l1: v12 };
    let v14: number = 4;
    let v15: string = "yo";
    let v16: Heap0 = { l0: v14, l1: v15 };
    let v17: number = 9;
    let v18: string = "ok";
    let v19: Heap0 = { l0: v17, l1: v18 };
    let v20: Mut0 = spiral_array_index(v10, 0);
    v20.l0 = v13;
    v20.l1 = v16;
    v20.l2 = v19;
    let v21: Heap0 = v20.l0;
    let v22: Heap0 = v20.l1;
    let v23: Heap0 = v20.l2;
    let v24: number = v21.l0;
    let v25: string = v21.l1;
    let v26: number = v22.l0;
    let v27: string = v22.l1;
    let v28: number = v23.l0;
    let v29: string = v23.l1;
    let v30: boolean = v24 === 7;
    let v32: boolean;
    if (v30) {
        let v31: boolean = v25 === "hi";
        v32 = v31;
    } else {
        v32 = false;
    }
    let v34: boolean;
    if (v32) {
        let v33: boolean = v26 === 4;
        v34 = v33;
    } else {
        v34 = false;
    }
    let v36: boolean;
    if (v34) {
        let v35: boolean = v27 === "yo";
        v36 = v35;
    } else {
        v36 = false;
    }
    let v38: boolean;
    if (v36) {
        let v37: boolean = v28 === 9;
        v38 = v37;
    } else {
        v38 = false;
    }
    let v40: boolean;
    if (v38) {
        let v39: boolean = v29 === "ok";
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
