function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
function fill_0(v0: number, v1: Array<number>, v2: number): void {
    tail: while (true) {
        const v3: boolean = v2 < v0;
        if (v3) {
            spiral_array_set(v1, v2, v2);
            const v4: number = (v2 + 1) | 0;
            v2 = v4;
            continue tail;
        } else {
            return;
        }
    }
}
export function main(): number {
    const v0: number = 6;
    const v1: Array<number> = new Array<number>(6).fill(0);
    let v2: number = 0;
    fill_0(v0, v1, v2);
    const v3: number = spiral_array_index(v1, 5);
    const v4: number = (v3 + 2) | 0;
    return v4;
}
process.exitCode = main();
