function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
export function main(): number {
    let v0: number = 5;
    let v1: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v1, 0, 0);
    spiral_array_set(v1, 1, 1);
    spiral_array_set(v1, 2, 4);
    let v2: number = 3;
    spiral_array_set(v1, v2, 9);
    let v3: number = (v2 + 1) | 0;
    spiral_array_set(v1, v3, 16);
    let v4: Array<boolean> = new Array<boolean>(3).fill(false);
    spiral_array_set(v4, 0, false);
    spiral_array_set(v4, 1, true);
    spiral_array_set(v4, 2, false);
    let v5: number = spiral_array_index(v1, 1);
    let v6: number = spiral_array_index(v1, 2);
    let v7: number = (v5 + v6) | 0;
    let v8: number = spiral_array_index(v1, 3);
    let v9: number = (v7 + v8) | 0;
    let v10: number = spiral_array_index(v1, 4);
    let v11: number = (v9 + v10) | 0;
    let v12: boolean = spiral_array_index(v4, 1);
    let v15: number;
    if (v12) {
        let v13: boolean = spiral_array_index(v4, 0);
        if (v13) {
            v15 = 0;
        } else {
            v15 = 100;
        }
    } else {
        v15 = 0;
    }
    let v16: number = (v11 + v15) | 0;
    let v17: number = v1.length;
    let v18: number = (v16 + v17) | 0;
    return v18;
}
process.exitCode = main();
