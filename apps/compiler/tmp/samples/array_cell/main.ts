function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Heap0 = { readonly l0: number };
export function main(): number {
    let v0: number = 2;
    let v1: Array<Heap0> = new Array<Heap0>(v0).fill(undefined as unknown as Heap0);
    let v2: number = 4;
    let v3: number = 6;
    let v4: Heap0 = { l0: v2 };
    spiral_array_set(v1, 0, v4);
    let v5: Heap0 = { l0: v3 };
    spiral_array_set(v1, 1, v5);
    let v6: Heap0 = spiral_array_index(v1, 0);
    let v7: number = v6.l0;
    let v8: Heap0 = spiral_array_index(v1, 1);
    let v9: number = v8.l0;
    let v10: number = (v7 + v9) | 0;
    let v11: boolean = v10 === 10;
    if (v11) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
