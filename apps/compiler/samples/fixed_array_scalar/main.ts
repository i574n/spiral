function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
export function main(): number {
    const v0: Array<number> = new Array<number>(3).fill(0);
    spiral_array_set(v0, 0, 2);
    spiral_array_set(v0, 1, 3);
    spiral_array_set(v0, 2, 5);
    const v1: number = spiral_array_index(v0, 0);
    const v2: number = spiral_array_index(v0, 1);
    const v3: number = spiral_array_index(v0, 2);
    const v4: number = (v1 + v2) | 0;
    const v5: number = (v4 + v3) | 0;
    const v6: number = (v5 - 10) | 0;
    return v6;
}
process.exitCode = main();
