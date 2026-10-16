function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
function f_c0(v0: number): ((a0: number) => number) {
    return (v1: number): number => {
        let v2: number = (v1 + v0) | 0;
        return v2;
    };
}
export function main(): number {
    let v0: number = 3;
    let v1: ((a0: number) => number) = f_c0(v0);
    let v2: number = 1;
    let v3: Array<((a0: number) => number)> = new Array<((a0: number) => number)>(v2).fill(undefined as unknown as ((a0: number) => number));
    spiral_array_set(v3, 0, v1);
    let v4: ((a0: number) => number) = spiral_array_index(v3, 0);
    let v5: number = v4(4);
    let v6: boolean = v5 === 7;
    if (v6) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
