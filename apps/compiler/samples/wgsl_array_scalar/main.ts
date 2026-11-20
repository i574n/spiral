function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
export function main(): number {
    const v0: number = 5;
    const v1: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v1, 0, 0);
    spiral_array_set(v1, 1, 1);
    spiral_array_set(v1, 2, 4);
    const v2: number = 3;
    spiral_array_set(v1, v2, 9);
    const v3: number = (v2 + 1) | 0;
    spiral_array_set(v1, v3, 16);
    const v4: Array<boolean> = new Array<boolean>(3).fill(false);
    spiral_array_set(v4, 0, false);
    spiral_array_set(v4, 1, true);
    spiral_array_set(v4, 2, false);
    const v5: number = spiral_array_index(v1, 1);
    const v6: number = spiral_array_index(v1, 2);
    const v7: number = (v5 + v6) | 0;
    const v8: number = spiral_array_index(v1, 3);
    const v9: number = (v7 + v8) | 0;
    const v10: number = spiral_array_index(v1, 4);
    const v11: number = (v9 + v10) | 0;
    const v12: boolean = spiral_array_index(v4, 1);
    let v15: number;
    if (v12) {
        const v13: boolean = spiral_array_index(v4, 0);
        if (v13) {
            v15 = 0;
        } else {
            v15 = 100;
        }
    } else {
        v15 = 0;
    }
    const v16: number = (v11 + v15) | 0;
    const v17: number = v1.length;
    const v18: number = (v16 + v17) | 0;
    return v18;
}
process.exitCode = main();
