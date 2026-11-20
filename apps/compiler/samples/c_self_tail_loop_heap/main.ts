function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
function loop_0(v0: number, v1: Array<number>, v2: number, v3: number, v4: number): number {
    tail: while (true) {
        const v5: boolean = v3 >= v0;
        if (v5) {
            return v4;
        } else {
            const v6: number = (v3 % 4) | 0;
            const v7: number = spiral_array_index(v1, v6);
            const v8: number = (v3 + 1) | 0;
            const v9: number = Math.imul(v4, 7);
            const v10: number = (v9 + v7) | 0;
            const v11: number = (v10 + v2) | 0;
            const v12: number = (v11 % 9973) | 0;
            v3 = v8;
            v4 = v12;
            continue tail;
        }
    }
}
export function main(): number {
    const v0: Array<number> = new Array<number>(4).fill(0);
    spiral_array_set(v0, 0, 1);
    spiral_array_set(v0, 1, 2);
    spiral_array_set(v0, 2, 3);
    spiral_array_set(v0, 3, 4);
    const v1: number = 0;
    const v2: number = 1000000;
    let v3: number = 0;
    let v4: number = 0;
    const v5: number = loop_0(v2, v0, v1, v3, v4);
    const v6: number = (v5 % 256) | 0;
    return v6;
}
process.exitCode = main();
