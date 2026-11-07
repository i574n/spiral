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
const US0_Empty_shared: US0 = { tag: 0 }; function US0_Empty(): US0 { return US0_Empty_shared; }
function US0_Nested(f0: Array<Array<number>>): US0 { return { tag: 1, f0: f0 }; }
function bump_0(v0: US0): number {
    switch (v0.tag) {
        case 0: {
            return 0;
        }
        case 1: {
            const v1: Array<Array<number>> = v0.f0;
            const v2: Array<number> = spiral_array_index(v1, 0);
            const v3: number = spiral_array_index(v2, 0);
            const v4: number = (v3 + 1) | 0;
            spiral_array_set(v2, 0, v4);
            return 0;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function score_1(v0: US0): number {
    switch (v0.tag) {
        case 0: {
            return 0;
        }
        case 1: {
            const v1: Array<Array<number>> = v0.f0;
            const v2: Array<number> = spiral_array_index(v1, 0);
            const v3: Array<number> = spiral_array_index(v1, 1);
            const v4: number = spiral_array_index(v2, 0);
            const v5: number = spiral_array_index(v2, 1);
            const v6: number = (v4 + v5) | 0;
            const v7: number = spiral_array_index(v3, 0);
            const v8: number = (v6 + v7) | 0;
            const v9: number = spiral_array_index(v3, 1);
            const v10: number = (v8 + v9) | 0;
            return v10;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: number = 2;
    const v1: Array<Array<number>> = new Array<Array<number>>(v0).fill(undefined as unknown as Array<number>);
    const v2: Array<number> = new Array<number>(v0).fill(0);
    const v3: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v2, 0, 3);
    spiral_array_set(v2, 1, 4);
    spiral_array_set(v3, 0, 5);
    spiral_array_set(v3, 1, 6);
    spiral_array_set(v1, 0, v2);
    spiral_array_set(v1, 1, v3);
    const v4: US0 = US0_Nested(v1);
    const v5: number = bump_0(v4);
    const v6: US0 = US0_Nested(v1);
    const v7: number = score_1(v6);
    const v8: number = (v7 + v5) | 0;
    const v9: number = (v8 - 19) | 0;
    return v9;
}
process.exitCode = main();
