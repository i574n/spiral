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
export function main(): number {
    let v0: number = 7;
    let v1: string = "hi";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 4;
    let v4: string = "yo";
    let v5: Heap0 = { l0: v3, l1: v4 };
    let v6: Heap1 = { l0: v2, l1: v5 };
    let v7: Array<Heap1> = new Array<Heap1>(1).fill(undefined as unknown as Heap1);
    spiral_array_set(v7, 0, v6);
    let v8: Heap1 = spiral_array_index(v7, 0);
    let v9: Heap0 = v8.l0;
    let v10: Heap0 = v8.l1;
    let v11: number = v9.l0;
    let v12: string = v9.l1;
    let v13: number = v10.l0;
    let v14: string = v10.l1;
    let v15: boolean = v11 === 7;
    let v17: boolean;
    if (v15) {
        let v16: boolean = v12 === "hi";
        v17 = v16;
    } else {
        v17 = false;
    }
    let v19: boolean;
    if (v17) {
        let v18: boolean = v13 === 4;
        v19 = v18;
    } else {
        v19 = false;
    }
    let v21: boolean;
    if (v19) {
        let v20: boolean = v14 === "yo";
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
