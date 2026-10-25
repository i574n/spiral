function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Heap0 = { readonly l0: Array<number>, readonly l1: number };
export function main(): number {
    let v0: number = 3;
    let v1: number = 4;
    let v2: Array<number> = new Array<number>(1).fill(0);
    spiral_array_set(v2, 0, v0);
    let v3: Heap0 = { l0: v2, l1: v1 };
    let v4: Array<number> = v3.l0;
    let v5: number = v3.l1;
    let v6: number = spiral_array_index(v4, 0);
    let v7: number = (v6 + v5) | 0;
    let v8: boolean = v7 === 7;
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
