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
    const v1: Array<number> = new Array<number>(v0).fill(0);
    const v2: number = 1.5;
    spiral_array_set(v1, 0, v2);
    spiral_array_set(v1, 1, 2.5);
    const v3: number = spiral_array_index(v1, 0);
    const v4: boolean = v3 === 1.5;
    if (v4) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
