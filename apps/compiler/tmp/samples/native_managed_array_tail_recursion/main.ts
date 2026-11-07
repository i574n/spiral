function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
function method1(v0: number, v1: Array<number>, v2: Array<number>): Array<number> {
    tail: while (true) {
        const v3: number = (v0 - 1) | 0;
        const v4: boolean = v3 === 0;
        if (v4) {
            return v2;
        } else {
            {
                v0 = v3;
                const t0 = v1;
                v1 = v2;
                v2 = t0;
            }
            continue tail;
        }
    }
}
function method0(v0: Array<number>, v1: Array<number>): Array<number> {
    let v2: number = 1000000;
    const v3: boolean = v2 === 0;
    if (v3) {
        return v0;
    } else {
        return method1(v2, v0, v1);
    }
}
export function main(): number {
    let v0: number = 1;
    let v1: Array<number> = new Array<number>(v0).fill(0);
    let v2: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v1, 0, 7);
    spiral_array_set(v2, 0, 11);
    const v3: Array<number> = method0(v1, v2);
    spiral_array_set(v3, 0, 13);
    const v4: number = spiral_array_index(v1, 0);
    const v5: boolean = v4 === 13;
    if (v5) {
        const v6: number = spiral_array_index(v2, 0);
        const v7: boolean = v6 === 11;
        if (v7) {
            return 0;
        } else {
            return 2;
        }
    } else {
        return 1;
    }
}
process.exitCode = main();
