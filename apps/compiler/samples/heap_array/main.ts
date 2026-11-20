function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Heap0 = { readonly l0: Array<number> };
export function main(): number {
    const v0: number = 2;
    const v1: Array<number> = new Array<number>(v0).fill(0);
    const v2: number = 7;
    spiral_array_set(v1, 0, v2);
    const v3: Heap0 = { l0: v1 };
    const v4: Array<number> = v3.l0;
    const v5: number = spiral_array_index(v4, 0);
    const v6: boolean = v5 === 7;
    if (v6) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
