function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
export function main(): number {
    let v0: number = 4;
    let v1: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v1, 0, 10);
    spiral_array_set(v1, 1, 20);
    spiral_array_set(v1, 2, 30);
    let v2: number = spiral_array_index(v1, 0);
    let v3: number = spiral_array_index(v1, 1);
    let v4: number = (v2 + v3) | 0;
    spiral_array_set(v1, 3, v4);
    let v5: number = spiral_array_index(v1, 2);
    let v6: number = spiral_array_index(v1, 3);
    let v7: number = (v5 + v6) | 0;
    let v8: number = v1.length;
    let v9: boolean = v8 === v0;
    let v11: boolean;
    if (v9) {
        let v10: boolean = v7 === 60;
        v11 = v10;
    } else {
        v11 = false;
    }
    if (v11) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
