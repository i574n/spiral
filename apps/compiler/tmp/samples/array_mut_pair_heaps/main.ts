function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Heap0 = { readonly l0: number, readonly l1: string };
type Mut0 = { l0: Heap0, l1: Heap0 };
export function main(): number {
    let v0: number = 1;
    let v1: string = "no";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 2;
    let v4: string = "zz";
    let v5: Heap0 = { l0: v3, l1: v4 };
    let v6: Mut0 = { l0: v2, l1: v5 };
    let v7: Array<Mut0> = new Array<Mut0>(1).fill(undefined as unknown as Mut0);
    spiral_array_set(v7, 0, v6);
    let v8: number = 7;
    let v9: string = "hi";
    let v10: Heap0 = { l0: v8, l1: v9 };
    let v11: number = 4;
    let v12: string = "yo";
    let v13: Heap0 = { l0: v11, l1: v12 };
    let v14: Mut0 = spiral_array_index(v7, 0);
    v14.l0 = v10;
    v14.l1 = v13;
    let v15: Heap0 = v14.l0;
    let v16: Heap0 = v14.l1;
    let v17: number = v15.l0;
    let v18: string = v15.l1;
    let v19: number = v16.l0;
    let v20: string = v16.l1;
    let v21: boolean = v17 === 7;
    let v23: boolean;
    if (v21) {
        let v22: boolean = v18 === "hi";
        v23 = v22;
    } else {
        v23 = false;
    }
    let v25: boolean;
    if (v23) {
        let v24: boolean = v19 === 4;
        v25 = v24;
    } else {
        v25 = false;
    }
    let v27: boolean;
    if (v25) {
        let v26: boolean = v20 === "yo";
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
