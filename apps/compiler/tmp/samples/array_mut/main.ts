function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Mut0 = { l0: number };
export function main(): number {
    let v0: Array<Mut0> = new Array<Mut0>(1).fill(undefined as unknown as Mut0);
    let v1: Mut0 = { l0: 1 };
    spiral_array_set(v0, 0, v1);
    let v2: Mut0 = spiral_array_index(v0, 0);
    v2.l0 = 7;
    let v3: number = v2.l0;
    let v4: boolean = v3 === 7;
    if (v4) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
