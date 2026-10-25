function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
function method0(): [Array<number>, number] {
    let v0: number = 2;
    let v1: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v1, 0, 4);
    spiral_array_set(v1, 1, 5);
    return [v1, 1];
}
function method1(v0: Array<number>, v1: number): number {
    let v2: number = spiral_array_index(v0, 0);
    let v3: number = spiral_array_index(v0, 1);
    let v4: number = (v2 + v3) | 0;
    let v5: number = (v4 + v1) | 0;
    let v6: number = (v5 - 10) | 0;
    return v6;
}
export function main(): number {
    let [v0, v1]: [Array<number>, number] = method0();
    return method1(v0, v1);
}
process.exitCode = main();
