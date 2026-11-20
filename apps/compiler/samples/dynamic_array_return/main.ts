function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
function method0(v0: number): Array<number> {
    const v1: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v1, 0, 3);
    spiral_array_set(v1, 1, 4);
    spiral_array_set(v1, 2, 8);
    return v1;
}
function method1(v0: Array<number>, v1: number): number {
    const v2: number = spiral_array_index(v0, v1);
    const v3: number = v0.length;
    const v4: number = (v2 + v3) | 0;
    const v5: number = (v4 - 11) | 0;
    return v5;
}
export function main(): number {
    const v0: number = 3;
    const v1: Array<number> = method0(v0);
    const v2: number = 2;
    return method1(v1, v2);
}
process.exitCode = main();
