function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
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
    let v10: Array<Heap1> = new Array<Heap1>(1).fill(undefined as unknown as Heap1);
    spiral_array_set(v10, 0, v9);
    let v11: Heap1 = spiral_array_index(v10, 0);
    let v12: Heap0 = v11.l0;
    let v13: Heap0 = v11.l1;
    let v14: Heap0 = v11.l2;
    let v15: number = v12.l0;
    let v16: string = v12.l1;
    let v17: number = v13.l0;
    let v18: string = v13.l1;
    let v19: number = v14.l0;
    let v20: string = v14.l1;
    let v21: boolean = v15 === 7;
    let v23: boolean;
    if (v21) {
        let v22: boolean = v16 === "hi";
        v23 = v22;
    } else {
        v23 = false;
    }
    let v25: boolean;
    if (v23) {
        let v24: boolean = v17 === 4;
        v25 = v24;
    } else {
        v25 = false;
    }
    let v27: boolean;
    if (v25) {
        let v26: boolean = v18 === "yo";
        v27 = v26;
    } else {
        v27 = false;
    }
    let v29: boolean;
    if (v27) {
        let v28: boolean = v19 === 9;
        v29 = v28;
    } else {
        v29 = false;
    }
    let v31: boolean;
    if (v29) {
        let v30: boolean = v20 === "ok";
        v31 = v30;
    } else {
        v31 = false;
    }
    if (v31) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
