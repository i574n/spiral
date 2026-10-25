function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: number };
type Mut0 = { l0: Heap1 };
export function main(): number {
    let v0: number = 3;
    let v1: string = "no";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 1;
    let v4: Heap1 = { l0: v2, l1: v3 };
    let v5: Mut0 = { l0: v4 };
    let v6: Array<Mut0> = new Array<Mut0>(1).fill(undefined as unknown as Mut0);
    spiral_array_set(v6, 0, v5);
    let v7: number = 7;
    let v8: string = "hi";
    let v9: Heap0 = { l0: v7, l1: v8 };
    let v10: number = 4;
    let v11: Heap1 = { l0: v9, l1: v10 };
    let v12: Mut0 = spiral_array_index(v6, 0);
    v12.l0 = v11;
    let v13: Heap1 = v12.l0;
    let v14: Heap0 = v13.l0;
    let v15: number = v13.l1;
    let v16: number = v14.l0;
    let v17: string = v14.l1;
    let v18: boolean = v16 === 7;
    let v20: boolean;
    if (v18) {
        let v19: boolean = v17 === "hi";
        v20 = v19;
    } else {
        v20 = false;
    }
    let v22: boolean;
    if (v20) {
        let v21: boolean = v15 === 4;
        v22 = v21;
    } else {
        v22 = false;
    }
    if (v22) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
