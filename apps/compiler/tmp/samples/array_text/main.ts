function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
export function main(): number {
    let v0: number = 2;
    let v1: Array<string> = new Array<string>(v0).fill("");
    let v2: string = "hi";
    spiral_array_set(v1, 0, v2);
    let v3: string = "yo";
    spiral_array_set(v1, 1, v3);
    let v4: string = spiral_array_index(v1, 0);
    let v5: boolean = v4 === "hi";
    if (v5) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
