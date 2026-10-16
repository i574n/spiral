function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
function method0(v0: number): Array<number> {
    let v1: Array<number> = new Array<number>(1).fill(0);
    spiral_array_set(v1, 0, v0);
    return v1;
}
export function main(): number {
    let v0: number = 7;
    let v1: Array<number> = method0(v0);
    let v2: number = spiral_array_index(v1, 0);
    let v3: boolean = v2 === 7;
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
