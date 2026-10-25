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
    spiral_array_set(v0, 0, 7);
    spiral_array_set(v0, 1, 7);
    spiral_array_set(v0, 2, 7);
    spiral_array_set(v0, 3, 7);
    const v1: number = spiral_array_index(v0, 3);
    const v2: Array<number> = new Array<number>(4).fill(0);
    spiral_array_set(v2, 0, 5);
    const v3: number = spiral_array_index(v2, 3);
    const v4: number = spiral_array_index(v2, 0);
    const v5: number = Math.imul(v3, 100);
    const v6: number = (v5 + v4) | 0;
    const v7: number = (v1 - 7) | 0;
    const v8: number = (v6 + v7) | 0;
    return v8;
}
process.exitCode = main();
