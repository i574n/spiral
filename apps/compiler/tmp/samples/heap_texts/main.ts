function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Heap0 = { readonly l0: Array<string> };
export function main(): number {
    const v0: Array<string> = new Array<string>(1).fill("");
    const v1: string = "hi";
    spiral_array_set(v0, 0, v1);
    const v2: Heap0 = { l0: v0 };
    const v3: Array<string> = v2.l0;
    const v4: string = spiral_array_index(v3, 0);
    const v5: boolean = v4 === "hi";
    if (v5) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
