function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: Heap0 };
type Heap2 = { readonly l0: Heap1, readonly l1: number };
export function main(): number {
    let v0: number = 7;
    let v1: string = "hi";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 4;
    let v4: string = "yo";
    let v5: Heap0 = { l0: v3, l1: v4 };
    let v6: Heap1 = { l0: v2, l1: v5 };
    let v7: number = 2;
    let v8: Heap2 = { l0: v6, l1: v7 };
    let v9: Array<Heap2> = new Array<Heap2>(1).fill(undefined as unknown as Heap2);
    spiral_array_set(v9, 0, v8);
    let v10: Heap2 = spiral_array_index(v9, 0);
    let v11: Heap1 = v10.l0;
    let v12: number = v10.l1;
    let v13: Heap0 = v11.l0;
    let v14: Heap0 = v11.l1;
    let v15: number = v13.l0;
    let v16: string = v13.l1;
    let v17: number = v14.l0;
    let v18: string = v14.l1;
    let v19: boolean = v15 === 7;
    let v21: boolean;
    if (v19) {
        let v20: boolean = v16 === "hi";
        v21 = v20;
    } else {
        v21 = false;
    }
    let v23: boolean;
    if (v21) {
        let v22: boolean = v17 === 4;
        v23 = v22;
    } else {
        v23 = false;
    }
    let v25: boolean;
    if (v23) {
        let v24: boolean = v18 === "yo";
        v25 = v24;
    } else {
        v25 = false;
    }
    let v27: boolean;
    if (v25) {
        let v26: boolean = v12 === 2;
        v27 = v26;
    } else {
        v27 = false;
    }
    if (v27) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
