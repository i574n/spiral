function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
function f_c0(v0: number, v1: number): ((a0: number) => [Array<number>, Array<number>]) {
    return (v2: number): [Array<number>, Array<number>] => {
        let v3: Array<number> = new Array<number>(1).fill(0);
        let v4: Array<number> = new Array<number>(1).fill(0);
        let v5: boolean = v2 === 0;
        if (v5) {
            spiral_array_set(v3, 0, 0);
            spiral_array_set(v4, 0, 0);
            return [v3, v4];
        } else {
            spiral_array_set(v3, 0, v0);
            spiral_array_set(v4, 0, v1);
            return [v3, v4];
        }
    };
}
export function main(): number {
    let v0: number = 3;
    let v1: number = 4;
    let v2: ((a0: number) => [Array<number>, Array<number>]) = f_c0(v0, v1);
    let [v3, v4]: [Array<number>, Array<number>] = v2(1);
    let v5: number = spiral_array_index(v3, 0);
    let v6: number = spiral_array_index(v4, 0);
    let v7: number = (v5 + v6) | 0;
    let v8: boolean = v7 === 7;
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
