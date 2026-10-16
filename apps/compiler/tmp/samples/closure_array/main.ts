function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
function f_c0(v0: number): ((a0: number) => Array<number>) {
    return (v1: number): Array<number> => {
        let v2: Array<number> = new Array<number>(1).fill(0);
        spiral_array_set(v2, 0, v0);
        return v2;
    };
}
export function main(): number {
    let v0: number = 7;
    let v1: ((a0: number) => Array<number>) = f_c0(v0);
    let v2: Array<number> = v1(1);
    let v3: number = spiral_array_index(v2, 0);
    let v4: boolean = v3 === 7;
    if (v4) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
