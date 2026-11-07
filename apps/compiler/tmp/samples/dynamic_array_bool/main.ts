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
    const v1: Array<boolean> = new Array<boolean>(v0).fill(false);
    spiral_array_set(v1, 0, true);
    spiral_array_set(v1, 1, false);
    const v2: number = 0;
    const v3: boolean = spiral_array_index(v1, v2);
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
