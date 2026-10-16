function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
export function main(): number {
    let v0: Array<number> = new Array<number>(1).fill(0);
    let v1: number = 200;
    spiral_array_set(v0, 0, v1);
    let v2: number = spiral_array_index(v0, 0);
    let v3: boolean = v2 === 200;
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
