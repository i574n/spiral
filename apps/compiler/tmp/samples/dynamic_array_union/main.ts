function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type US0_0 = { readonly tag: 0 };
type US0_1 = { readonly tag: 1, readonly f0: Array<number> };
type US0 = US0_0 | US0_1;
function US0_0(): US0 { return { tag: 0 }; }
function US0_1(f0: Array<number>): US0 { return { tag: 1, f0: f0 }; }
function method0(v0: US0): number {
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
    let v2: US0 = US0_1(v1);
    let v3: number = method0(v2);
    let v4: number = (v3 - 11) | 0;
    return v4;
}
process.exitCode = main();
