function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
export function main(): number {
    const v0: number = 2;
    const v1: Array<Array<number>> = new Array<Array<number>>(v0).fill(undefined as unknown as Array<number>);
    const v2: Array<number> = new Array<number>(v0).fill(0);
    const v3: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v2, 0, 3);
    spiral_array_set(v2, 1, 4);
    spiral_array_set(v3, 0, 5);
    spiral_array_set(v3, 1, 6);
    spiral_array_set(v1, 0, v2);
    spiral_array_set(v1, 1, v3);
    const v4: Array<number> = spiral_array_index(v1, 0);
    const v5: Array<number> = spiral_array_index(v1, 1);
    const v6: number = spiral_array_index(v4, 0);
    const v7: number = spiral_array_index(v4, 1);
    const v8: number = (v6 + v7) | 0;
    const v9: number = spiral_array_index(v5, 0);
    const v10: number = (v8 + v9) | 0;
    const v11: number = spiral_array_index(v5, 1);
    const v12: number = (v10 + v11) | 0;
    const v13: number = (v12 - 18) | 0;
    return v13;
}
process.exitCode = main();
