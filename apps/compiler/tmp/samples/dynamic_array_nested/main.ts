function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
export function main(): number {
    let v0: number = 2;
    let v1: Array<Array<number>> = new Array<Array<number>>(v0).fill(undefined as unknown as Array<number>);
    let v2: Array<number> = new Array<number>(v0).fill(0);
    let v3: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v2, 0, 3);
    spiral_array_set(v2, 1, 4);
    spiral_array_set(v3, 0, 5);
    spiral_array_set(v3, 1, 6);
    spiral_array_set(v1, 0, v2);
    spiral_array_set(v1, 1, v3);
    let v4: Array<number> = spiral_array_index(v1, 0);
    let v5: Array<number> = spiral_array_index(v1, 1);
    let v6: number = spiral_array_index(v4, 0);
    let v7: number = spiral_array_index(v4, 1);
    let v8: number = (v6 + v7) | 0;
    let v9: number = spiral_array_index(v5, 0);
    let v10: number = (v8 + v9) | 0;
    let v11: number = spiral_array_index(v5, 1);
    let v12: number = (v10 + v11) | 0;
    let v13: number = (v12 - 18) | 0;
    return v13;
}
process.exitCode = main();
