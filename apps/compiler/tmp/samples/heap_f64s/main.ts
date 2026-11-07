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
    const v0: Array<number> = new Array<number>(1).fill(0);
    const v1: number = 1.5;
    spiral_array_set(v0, 0, v1);
    const v2: Heap0 = { l0: v0 };
    const v3: Array<number> = v2.l0;
    const v4: number = spiral_array_index(v3, 0);
    const v5: boolean = v4 === 1.5;
    if (v5) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
