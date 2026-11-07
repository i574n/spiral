function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
export function main(): number {
    const v0: Array<bigint> = new Array<bigint>(1).fill(0n);
    const v1: bigint = 5000000000n;
    spiral_array_set(v0, 0, v1);
    const v2: bigint = spiral_array_index(v0, 0);
    const v3: boolean = v2 === 5000000000n;
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
