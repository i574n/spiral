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
        let v5: boolean = v3 >= v0;
        if (v5) {
            return v4;
        } else {
            let v6: number = (v3 % 4) | 0;
            let v7: number = spiral_array_index(v1, v6);
            let v8: number = (v3 + 1) | 0;
            let v9: number = Math.imul(v4, 7);
            let v10: number = (v9 + v7) | 0;
            let v11: number = (v10 + v2) | 0;
            let v12: number = (v11 % 9973) | 0;
            {
                let t0 = v0;
                let t1 = v1;
                let t2 = v2;
                let t3 = v8;
                let t4 = v12;
                v0 = t0;
                v1 = t1;
                v2 = t2;
                v3 = t3;
                v4 = t4;
            }
            continue tail;
        }
    }
}
export function main(): number {
    let v0: Array<number> = new Array<number>(4).fill(0);
    spiral_array_set(v0, 0, 1);
    spiral_array_set(v0, 1, 2);
    spiral_array_set(v0, 2, 3);
    spiral_array_set(v0, 3, 4);
    let v1: number = 0;
    let v2: number = 1000000;
    let v3: number = 0;
    let v4: number = 0;
    let v5: number = loop_0(v2, v0, v1, v3, v4);
    let v6: number = (v5 % 256) | 0;
    return v6;
}
process.exitCode = main();
