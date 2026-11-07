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
export function main(): number {
    const v0: number = 7;
    const v1: string = "hi";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 1;
    const v4: Heap1 = { l0: v2, l1: v3 };
    const v5: Array<Heap1> = new Array<Heap1>(1).fill(undefined as unknown as Heap1);
    spiral_array_set(v5, 0, v4);
    const v6: Heap1 = spiral_array_index(v5, 0);
    const v7: Heap0 = v6.l0;
    const v8: number = v6.l1;
    const v9: number = v7.l0;
    const v10: string = v7.l1;
    const v11: boolean = v9 === 7;
    let v13: boolean;
    if (v11) {
        const v12: boolean = v10 === "hi";
        v13 = v12;
    } else {
        v13 = false;
    }
    let v15: boolean;
    if (v13) {
        const v14: boolean = v8 === 1;
        v15 = v14;
    } else {
        v15 = false;
    }
    if (v15) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
