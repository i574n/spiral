function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Mut0 = { l0: number, l1: string };
export function main(): number {
    const v0: number = 3;
    const v1: string = "no";
    const v2: Mut0 = { l0: v0, l1: v1 };
    const v3: Array<Mut0> = new Array<Mut0>(1).fill(undefined as unknown as Mut0);
    spiral_array_set(v3, 0, v2);
    let v4: Mut0 = spiral_array_index(v3, 0);
    const v5: number = 7;
    const v6: string = "hi";
    v4.l0 = v5;
    v4.l1 = v6;
    const v7: number = v4.l0;
    const v8: string = v4.l1;
    const v9: boolean = v7 === 7;
    let v11: boolean;
    if (v9) {
        const v10: boolean = v8 === "hi";
        v11 = v10;
    } else {
        v11 = false;
    }
    if (v11) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
