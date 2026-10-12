function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type US0_Empty = { readonly tag: 0 };
type US0_Values = { readonly tag: 1, readonly f0: Array<number> };
type US0 = US0_Empty | US0_Values;
function US0_Empty(): US0 { return { tag: 0 }; }
function US0_Values(f0: Array<number>): US0 { return { tag: 1, f0: f0 }; }
function bump_0(v0: US0): number {
    switch (v0.tag) {
        case 0: {
            return 0;
            break;
        }
        case 1: {
            let v1: Array<number> = v0.f0;
            let v2: number = spiral_array_index(v1, 0);
            let v3: number = (v2 + 1) | 0;
            spiral_array_set(v1, 0, v3);
            return 0;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function score_1(v0: US0): number {
    switch (v0.tag) {
        case 0: {
            return 0;
            break;
        }
        case 1: {
            let v1: Array<number> = v0.f0;
            let v2: number = v1.length;
            let v3: number = spiral_array_index(v1, 0);
            let v4: number = (v2 + v3) | 0;
            let v5: number = spiral_array_index(v1, 1);
            let v6: number = (v4 + v5) | 0;
            return v6;
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: number = 2;
    let v1: Array<number> = new Array<number>(v0).fill(0);
    spiral_array_set(v1, 0, 4);
    spiral_array_set(v1, 1, 5);
    let v2: US0 = US0_Values(v1);
    let v3: number = bump_0(v2);
    let v4: US0 = US0_Values(v1);
    let v5: number = score_1(v4);
    let v6: number = (v5 + v3) | 0;
    let v7: number = (v6 - 12) | 0;
    return v7;
}
process.exitCode = main();
