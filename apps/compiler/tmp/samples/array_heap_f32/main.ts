function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Heap0 = { readonly l0: number, readonly l1: string };
export function main(): number {
    let v0: number = 1.5;
    let v1: string = "hi";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: Array<Heap0> = new Array<Heap0>(1).fill(undefined as unknown as Heap0);
    spiral_array_set(v3, 0, v2);
    let v4: Heap0 = spiral_array_index(v3, 0);
    let v5: number = v4.l0;
    let v6: string = v4.l1;
    let v7: boolean = v5 === 1.5;
    let v9: boolean;
    if (v7) {
        let v8: boolean = v6 === "hi";
        v9 = v8;
    } else {
        v9 = false;
    }
    if (v9) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
