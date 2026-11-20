function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
function method0(v0: number): number {
    const v1: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v1, 0, 2);
    spiral_array_set(v1, 1, 3);
    spiral_array_set(v1, 2, 5);
    spiral_array_set(v1, 3, 7);
    const v2: number = 2;
    const v3: number = spiral_array_index(v1, v2);
    const v4: number = v1.length;
    const v5: number = (v3 + v4) | 0;
    const v6: number = (v5 - 9) | 0;
    return v6;
}
export function main(): number {
    const v0: number = 4;
    return method0(v0);
}
process.exitCode = main();
