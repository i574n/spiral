function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
export function main(): number {
    const v0: number = 3;
    const v1: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v1, 0, 4000000000);
    spiral_array_set(v1, 1, 1);
    const v2: number = spiral_array_index(v1, 0);
    const v3: number = spiral_array_index(v1, 1);
    const v4: number = (v2 + v3) >>> 0;
    const v5: number = v1.length;
    const v6: boolean = v5 === v0;
    let v8: boolean;
    if (v6) {
        const v7: boolean = v4 === 4000000001;
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
