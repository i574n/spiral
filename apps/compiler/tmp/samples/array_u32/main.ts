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
    let v1: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v1, 0, 4000000000);
    spiral_array_set(v1, 1, 1);
    let v2: number = spiral_array_index(v1, 0);
    let v3: number = spiral_array_index(v1, 1);
    let v4: number = (v2 + v3) >>> 0;
    let v5: number = v1.length;
    let v6: boolean = v5 === v0;
    let v8: boolean;
    if (v6) {
        let v7: boolean = v4 === 4000000001;
        v8 = v7;
    } else {
        v8 = false;
    }
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
