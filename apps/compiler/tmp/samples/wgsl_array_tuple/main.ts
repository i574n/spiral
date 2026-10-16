function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
export function main(): number {
    let v0: number = 3;
    let v1: Array<[number, boolean]> = Array.from({ length: v0 }, (): [number, boolean] => [0, false]);
    let v2: number = 4;
    spiral_array_set(v1, 0, [v2, true]);
    spiral_array_set(v1, 1, [7, false]);
    spiral_array_set(v1, 2, [9, true]);
    let [v3, v4]: [number, boolean] = spiral_array_index(v1, 0);
    let [v5, v6]: [number, boolean] = spiral_array_index(v1, 1);
    let v7: number = 2;
    let [v8, v9]: [number, boolean] = spiral_array_index(v1, v7);
    let v10: number;
    if (v4) {
        v10 = 1;
    } else {
        v10 = 0;
    }
    let v11: number;
    if (v6) {
        v11 = 10;
    } else {
        v11 = 0;
    }
    let v12: number;
    if (v9) {
        v12 = 100;
    } else {
        v12 = 0;
    }
    let v13: number = (v3 + v5) | 0;
    let v14: number = (v13 + v8) | 0;
    let v15: number = (v14 + v10) | 0;
    let v16: number = (v15 + v11) | 0;
    let v17: number = (v16 + v12) | 0;
    return v17;
}
process.exitCode = main();
