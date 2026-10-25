function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Heap0 = { readonly l0: Array<string>, readonly l1: boolean };
export function main(): number {
    let v0: Array<string> = new Array<string>(1).fill("");
    let v1: string = "hi";
    spiral_array_set(v0, 0, v1);
    let v2: boolean = true;
    let v3: Heap0 = { l0: v0, l1: v2 };
    let v4: Array<string> = v3.l0;
    let v5: boolean = v3.l1;
    let v6: string = spiral_array_index(v4, 0);
    let v7: boolean = v6 === "hi";
    let v8: boolean = v7 && v5;
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
