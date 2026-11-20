function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
export function main(): number {
    const v0: Array<number> = new Array<number>(4).fill(0);
    spiral_array_set(v0, 0, 2);
    spiral_array_set(v0, 1, 3);
    spiral_array_set(v0, 2, 5);
    spiral_array_set(v0, 3, 7);
    const v1: number = 1;
    spiral_array_set(v0, v1, 11);
    const v2: number = spiral_array_index(v0, 0);
    const v3: number = spiral_array_index(v0, 1);
    const v4: number = spiral_array_index(v0, 2);
    const v5: number = spiral_array_index(v0, 3);
    const v6: number = (v2 + v3) | 0;
    const v7: number = (v6 + v4) | 0;
    const v8: number = (v7 + v5) | 0;
    const v9: number = (v8 - 25) | 0;
    return v9;
}
process.exitCode = main();
