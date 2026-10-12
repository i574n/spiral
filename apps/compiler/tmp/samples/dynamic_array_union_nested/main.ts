function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type US0_Empty = { readonly tag: 0 };
type US0_Nested = { readonly tag: 1, readonly f0: Array<Array<number>> };
type US0 = US0_Empty | US0_Nested;
function US0_Empty(): US0 { return { tag: 0 }; }
function US0_Nested(f0: Array<Array<number>>): US0 { return { tag: 1, f0: f0 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 0: {
            return 0;
            break;
        }
        case 1: {
            let v1: Array<Array<number>> = v0.f0;
            let v2: Array<number> = spiral_array_index(v1, 0);
            let v3: Array<number> = spiral_array_index(v1, 1);
            let v4: number = v1.length;
            let v5: number = spiral_array_index(v2, 0);
            let v6: number = (v4 + v5) | 0;
            let v7: number = spiral_array_index(v2, 1);
            let v8: number = (v6 + v7) | 0;
            let v9: number = spiral_array_index(v3, 0);
            let v10: number = (v8 + v9) | 0;
            let v11: number = spiral_array_index(v3, 1);
            let v12: number = (v10 + v11) | 0;
            return v12;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: number = 2;
    let v1: Array<Array<number>> = new Array<Array<number>>(v0).fill(undefined as unknown as Array<number>);
    let v2: Array<number> = new Array<number>(v0).fill(0);
    let v3: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v2, 0, 3);
    spiral_array_set(v2, 1, 4);
    spiral_array_set(v3, 0, 5);
    spiral_array_set(v3, 1, 6);
    spiral_array_set(v1, 0, v2);
    spiral_array_set(v1, 1, v3);
    let v4: US0 = US0_Nested(v1);
    let v5: number = score_0(v4);
    let v6: number = (v5 - 20) | 0;
    return v6;
}
process.exitCode = main();
